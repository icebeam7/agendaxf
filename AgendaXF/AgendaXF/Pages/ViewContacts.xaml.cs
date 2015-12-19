using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AgendaXF.Pages
{
	public partial class ViewContacts : ContentPage
	{
		public ViewContacts ()
		{
			InitializeComponent ();

            lsvContacts.ItemSelected += (sender, e) => 
            {
                if (lsvContacts.SelectedItem == null)
                    return;

                var contact = lsvContacts.SelectedItem as Classes.Contact;
                Navigate(contact);
                lsvContacts.SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvContacts.ItemsSource = App.DB.GetContacts();
        }

        void btnAdd_Clicked(object sender, EventArgs a)
        {
            Navigate(new Classes.Contact() { Id = 0 });
        }

        void Navigate(Classes.Contact contact)
        {
            var page = new EditContact();
            page.contact = contact;
            Navigation.PushAsync(page);
        }


	}
}
