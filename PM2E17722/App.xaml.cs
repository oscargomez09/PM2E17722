using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E17722
{
    public partial class App : Application
    {
        static Controllers.DBDatos dbDatos;
        public static Controllers.DBDatos Instancia
        {
            get
            {
                if (dbDatos == null)
                {
                    String dbname = "Datos.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    dbDatos = new Controllers.DBDatos(dbfulp);
                }
                return dbDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
