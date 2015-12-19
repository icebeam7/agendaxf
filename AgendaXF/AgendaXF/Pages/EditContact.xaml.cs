using AgendaXF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AgendaXF.Pages
{
    public partial class EditContact : ContentPage
	{
        public Contact contact;

        public EditContact ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (contact.Id != 0)
            {
                txtName.Text = contact.Name;
                txtEmailAddress.Text = contact.EmailAddress;
                txtTelephoneNumber.Text = contact.TelephoneNumber;
            }
        }

        async void btnRegister_Clicked(object sender, EventArgs a)
        {
            Contact data = new Contact()
            {
                Id = contact.Id,
                Name = txtName.Text,
                TelephoneNumber = txtTelephoneNumber.Text,
                EmailAddress = txtEmailAddress.Text
            };

            bool result = App.DB.RegisterContact(data, (contact.Id == 0));
            await DisplayAlert(result ? "Success" : "Failure",
                result ? "Contact registered successfully!" : "An error happened", "OK");

            await Navigation.PopAsync();
        }
    }
}
