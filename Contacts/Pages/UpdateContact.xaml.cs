using Android.Widget;
using Microsoft.Maui.Controls;
using The49.Maui.BottomSheet;
using static Contacts.App;
namespace Contacts.Pages;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;

public partial class UpdateContact
{

   
    public UpdateContact()
    {

        InitializeComponent();

      
        

        personIcon.Text = "\uf007";
        jobIcon.Text = "\ue0c8";

        phoneIcon.Text = "\uf095";

        cityIcon.Text = "\uf64f";

        mailIcon.Text = "\uf0e0";

        contactName.Text = selectedContact.name;
        contactOccupation.Text = selectedContact.occupation;
        contactPhone.Text = selectedContact.phoneNumber;
        contactAddress.Text = selectedContact.address;
        contactEmail.Text = selectedContact.email;


    }

   

    private async void CancelBotton_Clicked(object sender, EventArgs e)
    {

        contactName.IsEnabled = false;
        contactOccupation.IsEnabled = false;
        contactPhone.IsEnabled = false;
        contactAddress.IsEnabled = false;
        contactEmail.IsEnabled = false;
        await DismissAsync();


    }

    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {


        if (validateEntrys())
        {
            var contactNameVar = contactName.Text;
            var contactOccupationVar = contactOccupation.Text;
            var contactPhoneVar = contactPhone.Text;
            var contactAddressVar = contactAddress.Text;
            var contactEmailVar = contactEmail.Text;

            //contacts.Add(new ContactItem
            //{
            //    name = contactNameVar,
            //    occupation = contactOccupationVar,
            //    phoneNumber = contactPhoneVar,
            //    address = contactAddressVar,
            //    email = contactEmailVar,
            //    contactPicture = "defaultuser.jpg"
            //});


            selectedContact.name = contactNameVar;
            OnPropertyChanged(nameof(selectedContact.name));

            selectedContact.occupation = contactOccupationVar;
            OnPropertyChanged(nameof(selectedContact.occupation));

            selectedContact.phoneNumber = contactPhoneVar;
            OnPropertyChanged(nameof(selectedContact.phoneNumber));

            selectedContact.address = contactAddressVar;
            OnPropertyChanged(nameof(selectedContact.address));

            selectedContact.email = contactEmailVar;
            OnPropertyChanged(nameof(selectedContact.email));


            contactName.IsEnabled = false;
            contactOccupation.IsEnabled = false;
            contactPhone.IsEnabled = false;
            contactAddress.IsEnabled = false;
            contactEmail.IsEnabled = false;

          

            var toast = Toast.Make("Contact updated.");

            await toast.Show();

            await DismissAsync();

            
        }




    }

    private bool validateEntrys()
    {
        bool desicionName = true;
        bool desicionNumber = true;
        int ContactNamelength;
        int ContactPhonelenght;



        ContactNamelength = contactName.Text == null ? 0 : contactName.Text.Length;

        if (ContactNamelength < 1)
        {
            nameRequired.IsVisible = true;
            desicionName = false;
        }
        else
        {
            nameRequired.IsVisible = false;
            desicionName = true;
        }

        ContactPhonelenght = contactPhone.Text == null ? 0 : contactPhone.Text.Length;

        if (ContactPhonelenght < 3)
        {
            phoneRequired.IsVisible = true;
            desicionNumber = false;
        }
        else
        {
            phoneRequired.IsVisible = false;
            desicionNumber = true;
        }

        Console.WriteLine(IsValidEmail(contactEmail.Text));
        if (IsValidEmail(contactEmail.Text))
        {
            checkEmail.IsVisible = false;
        }
        else
        {
            checkEmail.IsVisible = true;
        }


        return desicionName && desicionNumber;

        

    }

    private bool IsValidEmail(string email)
    {
        if (email == null)
        {
            return true;
        }
        // Expresión regular para validar un correo electrónico
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);

        // Verifica si el correo electrónico coincide con el patrón de expresión regular
        return regex.IsMatch(email);
    }



    
}