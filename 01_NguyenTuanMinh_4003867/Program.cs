using _01_NguyenTuanMinh_4003867.Views;

namespace _01_NguyenTuanMinh_4003867
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Show login form first
            using var loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login successful, show main form
                Application.Run(new NguyenTuanMinh_4003867());
            }
        }
    }
}