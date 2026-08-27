using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ComicCollection.Services
{
    public class CoverService
    {
        private readonly WebView2 _webView;

        public CoverService(WebView2 webView)
        {
            _webView = webView;
        }

        // Download a GCD cover and save it using the local Comic ID
        public async Task<string> DownloadCoverAsync(
            string coverUrl,
            int comicId)
        {
            await _webView.EnsureCoreWebView2Async();

            string normalizedUrl = coverUrl.Replace(
                "comics.org//img/",
                "comics.org/img/"
            );

            Task navigationTask = WaitForNavigationAsync();

            _webView.Source = new Uri(normalizedUrl);

            // Wait until the browser has finished loading the image
            await navigationTask;

            // Get the image directly from the browser
            string result = await _webView.CoreWebView2.ExecuteScriptAsync(@"
        (() => {
            const img = document.querySelector('img');

            if (!img) {
                return null;
            }

            const canvas = document.createElement('canvas');

            canvas.width = img.naturalWidth;
            canvas.height = img.naturalHeight;

            const context = canvas.getContext('2d');

            context.drawImage(img, 0, 0);

            return canvas.toDataURL('image/jpeg', 1.0);
        })();
    ");

            if (result == "null")
            {
                throw new Exception(
                    "WebView2 loaded the cover, but the image could not be accessed."
                );
            }

            // WebView2 returns the JavaScript string as JSON
            string dataUrl =
                System.Text.Json.JsonSerializer.Deserialize<string>(result)
                ?? throw new Exception("Unable to read cover image data.");

            const string prefix = "data:image/jpeg;base64,";

            if (!dataUrl.StartsWith(prefix))
            {
                throw new Exception(
                    "The cover image was returned in an unexpected format."
                );
            }

            string base64 = dataUrl.Substring(prefix.Length);

            byte[] imageData =
                Convert.FromBase64String(base64);

            string coversDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Covers"
            );

            Directory.CreateDirectory(coversDirectory);

            string filePath = Path.Combine(
                coversDirectory,
                $"{comicId}.jpg"
            );

            await File.WriteAllBytesAsync(
                filePath,
                imageData
            );

            return Path.Combine(
                "Covers",
                $"{comicId}.jpg"
            );
        }

        private Task WaitForNavigationAsync()
        {
            var tcs = new TaskCompletionSource<bool>();

            void NavigationCompleted(
                object? sender,
                CoreWebView2NavigationCompletedEventArgs e)
            {
                _webView.NavigationCompleted -= NavigationCompleted;

                if (e.IsSuccess)
                {
                    tcs.SetResult(true);
                }
                else
                {
                    tcs.SetException(
                        new Exception("Unable to load the GCD cover.")
                    );
                }
            }

            _webView.NavigationCompleted += NavigationCompleted;

            return tcs.Task;
        }

        private Task<byte[]> WaitForImageResponseAsync()
        {
            var tcs = new TaskCompletionSource<byte[]>();

            void ResponseReceived(
                object? sender,
                CoreWebView2WebResourceResponseReceivedEventArgs e)
            {
                string contentType =
                    e.Response.Headers
                        .GetHeader("Content-Type");

                if (!contentType.StartsWith(
                    "image/",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _webView.CoreWebView2.WebResourceResponseReceived -=
                    ResponseReceived;

                _ = ReadResponseAsync(e, tcs);
            }

            _webView.CoreWebView2.WebResourceResponseReceived +=
                ResponseReceived;

            return tcs.Task;
        }

        private async Task ReadResponseAsync(
            CoreWebView2WebResourceResponseReceivedEventArgs e,
            TaskCompletionSource<byte[]> tcs)
        {
            try
            {
                Stream stream =
                    await e.Response.GetContentAsync();

                using MemoryStream memoryStream = new MemoryStream();

                await stream.CopyToAsync(memoryStream);

                tcs.SetResult(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }
    }
}