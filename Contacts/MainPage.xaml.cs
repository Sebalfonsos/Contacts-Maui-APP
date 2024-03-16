namespace Contacts;
using System.Collections.ObjectModel;
using static Contacts.App;
using System.Threading.Tasks;

using PartialMethodsPhoneDialer = InvokePlatformCodeDemos.Services.PartialMethods.PhoneDialer;
using Contacts.Pages;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Graphics;

public partial class MainPage : ContentPage
{
    //ObservableCollection<ContactItem> contacts;


    public MainPage()
    {
        InitializeComponent();
        contacts = new ObservableCollection<ContactItem>();
        contactsList.ItemsSource = contacts;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            // Si el texto de búsqueda está vacío, muestra todos los elementos
            contactsList.ItemsSource = contacts;
        }
        else
        {
            // Filtra los elementos basados en el texto de búsqueda
            contactsList.ItemsSource = contacts.Where(contact =>
                contact.name.ToLower().Contains(e.NewTextValue.ToLower()) ||
                contact.phoneNumber.ToLower().Contains(e.NewTextValue.ToLower())
                );

        }
    }




    private async void Message_Clicked(object sender, EventArgs e)
    {
        if (Sms.Default.IsComposeSupported)
        {
            string[] recipients = new[] { "000-000-0000" };
            string text = "";

            var message = new SmsMessage(text, recipients);

            await Sms.Default.ComposeAsync(message);
        }
    }



     void  addContactButton_Clicked(object sender, EventArgs e)
    {
        var pagina = new NewContact();
        pagina.CornerRadius = 20;
        pagina.HasBackdrop = true;
        pagina.ShowAsync(Window);

        
    }

    private async void contactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {

            var selectedItem = e.CurrentSelection.FirstOrDefault() as ContactItem;
            selectedContact = selectedItem;
            contactsList.SelectedItem = null;
            await Navigation.PushAsync(new Contact());

         


        }
    }
}
