using AgendaXF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AgendaXF
{
	public class App : Application
	{
        public static Database DB;

        public App ()
		{
            string db = "agendaxf.db3";
            string path = System.IO.Path.Combine(Environment.GetFolderPath(
                              Environment.SpecialFolder.Personal), db);
            DB = new Database(path);

            // The root page of your application
            MainPage = new NavigationPage(new Pages.ViewContacts());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
