using myProject.Models;
using myProject.Pesenters;
using myProject.Views;
using myProject._Repositories;
using System.Data.SqlClient;
using System.Configuration;

namespace myProject
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
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            ApplicationConfiguration.Initialize();
            IMainView view = new MainView();
            new MainPresenter(view,sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}