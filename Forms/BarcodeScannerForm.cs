using ComicCollection.Helpers;
using OpenCvSharp;
using OpenCvSharp.GdipExtensions;
using ZXing;
using ZXing.Windows.Compatibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComicCollection.Forms
{
    public partial class BarcodeScannerForm : Form
    {

        private VideoCapture? _camera;
        private CancellationTokenSource? _cameraCancellation;
        private readonly BarcodeReader _barcodeReader = new BarcodeReader();
        private DateTime _lastBarcodeTime = DateTime.MinValue;
        private const double ScanWidthRatio = 0.80;
        private const double ScanHeightRatio = 0.35;
        public BarcodeScannerForm()
        {
            InitializeComponent();

            ApplyTheme();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // On form load, make sure camera is available
        private void BarcodeScammerFormLoad(object send, EventArgs e)
        {
            try
            {
                _camera = new VideoCapture(0);



                if (!_camera.IsOpened())
                {
                    MessageBox.Show(
                        "Unable to access the webcam.",
                        "Camera Error,",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Close();
                    return;
                }

                StatusLabel.Text = "Camera ready";

                _cameraCancellation = new CancellationTokenSource();

                _ = Task.Run(() => CameraLoop(_cameraCancellation.Token) );
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to start the webcam. \n\n{ex.Message}",
                    "Camera Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }

        // camera loop
        private void CameraLoop (CancellationToken cancellationToken)
        {
            using Mat frame = new Mat();

            while (!cancellationToken.IsCancellationRequested)
            {
                if (_camera == null)
                {
                    break;
                }

                _camera.Read(frame);

                if (frame.Empty())
                {
                    continue;
                }

                // Calculate barcode scanning area
                int scanWidth = (int)(frame.Width * ScanWidthRatio);
                int scanHeight = (int)(frame.Width * ScanHeightRatio);
                int scanX = (frame.Width - scanWidth) / 2;
                int scanY = (frame.Height - scanHeight) / 2;

                Rect scanArea = new Rect(scanX, scanY, scanWidth, scanHeight);

                // draw scanning rectangle on camera frame
                Cv2.Rectangle(frame, scanArea, Scalar.LightBlue, 2);

                // Crop center area for barcode detection
                using Mat scanFrame = new Mat(frame, scanArea);

                // convert scan area to bitmap
                using Bitmap scanBitmap = BitmapConverter.ToBitmap(scanFrame);

                // try to find barcode
                Result? result = _barcodeReader.Decode(scanBitmap);
                if (result != null)
                {
                    HandleBarcode(result);
                }

                // Convert complete frame for display
                Bitmap bitmap = BitmapConverter.ToBitmap(frame);

                try
                {
                    Invoke(() =>
                    {
                        Image? oldImage = CameraPictureBox.Image;

                        CameraPictureBox.Image = bitmap;

                        oldImage?.Dispose();
                    });
                }
                catch
                {
                    bitmap.Dispose();
                    break;
                }
            }
        }

        // Handle barcode
        private void HandleBarcode (Result result)
        {
            // ignore repeated detections
            if ((DateTime.Now - _lastBarcodeTime).TotalMilliseconds < 2000)
            {
                return;
            }

            string barcode = result.Text;

            // only accept numeric barcodes
            string normalizedUPC = new string(barcode.Where(char.IsDigit).ToArray());

            // comic UPCs need to be reasonably long
            if (normalizedUPC.Length < 10)
            {
                return;
            }

            _lastBarcodeTime = DateTime.Now;

            BeginInvoke(() =>
            {
                StatusLabel.Text = $"Barcode detected: {normalizedUPC}";
            });
        }

        // Form closing
        private void BarcodeScannerForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _cameraCancellation?.Cancel();

            _camera?.Release();
            _camera?.Dispose();

            _camera = null;
        }


        // -- STYLING --

        private void ApplyTheme()
        {
            UIHelper.StyleButton(ExitButton);
            UIHelper.StyleForm(this);
        }

    }
}
