using Android.Widget;
using Microsoft.Maui.Controls;
using The49.Maui.BottomSheet;
using static Contacts.App;
namespace Contacts.Pages;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.ApplicationModel.Communication;
using System.IO;
using System.Text.RegularExpressions;

public partial class NewContact
{

    bool lessInfoVar = false;
	public NewContact()
	{

        InitializeComponent();
        

        Closebtn.Text = "\uf00d";
        Closebtn.FontFamily = "fa-regular-400";

        Checkbtn.Text = "\uf00c";
        Checkbtn.FontFamily = "fa-regular-400";

        personIcon.Text = "\uf007";
        jobIcon.Text = "\ue0c8";

        phoneIcon.Text = "\uf095";

        cityIcon.Text = "\uf64f";

        mailIcon.Text = "\uf0e0";


    }

    private async void CloseBotton_Clicked(object sender, EventArgs e)
    {

        contactName.IsEnabled = false;
        contactOccupation.IsEnabled = false;
        contactPhone.IsEnabled = false;
        contactAddress.IsEnabled = false;
        contactEmail.IsEnabled = false;
        await DismissAsync();


    }

    private async void CheckButton_Clicked(object sender, EventArgs e)
    {


        if (validateEntrys())
        {
            var contactNameVar = contactName.Text;
            var contactOccupationVar = contactOccupation.Text;
            var contactPhoneVar = contactPhone.Text;
            var contactAddressVar = contactAddress.Text;
            var contactEmailVar = contactEmail.Text;

            contacts.Add(new ContactItem
            {
                name = contactNameVar,
                occupation = contactOccupationVar,
                phoneNumber = contactPhoneVar,
                address = contactAddressVar,
                email = contactEmailVar,
                contactPicture = "defaultuser.jpg"
            });

            contactName.IsEnabled = false;
            contactOccupation.IsEnabled = false;
            contactPhone.IsEnabled = false;
            contactAddress.IsEnabled = false;
            contactEmail.IsEnabled = false;



            var toast = Toast.Make("New contact added.");

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

        if(lessInfoVar == false)
        {
            return desicionName && desicionNumber && IsValidEmail(contactEmail.Text);

        }
        else
        {
            return desicionName && desicionNumber;

        }

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



    private void lessInfo_Clicked(object sender, EventArgs e)
    {
        if(lessInfoVar == false)
        {
            lessInfoVar = true;
            lessInfo.Text = "Add more info";
            principalStack.HeightRequest = 250;
            occupationStack.IsVisible = false;
            addressStack.IsVisible = false;
            emailStack.IsVisible = false;

            contactOccupation.Text = "";
            contactAddress.Text = "";
            contactEmail.Text = "";

        }
        else
        {

            
            lessInfoVar = false;
            lessInfo.Text = "Add less info";
            principalStack.HeightRequest = 490;
            occupationStack.IsVisible = true;
            addressStack.IsVisible = true;
            emailStack.IsVisible = true;
        }
    }
}