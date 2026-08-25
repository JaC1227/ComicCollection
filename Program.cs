using ComicCollection.Data;

namespace ComicCollection
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // create instance of Database class (Database.cs)
            Database database = new Database();
            // run database.Initialize to create comics.db & comics table if they don't exist
            database.Initialize();

            // start application
            Application.Run(new Form1());
        }
    }
}