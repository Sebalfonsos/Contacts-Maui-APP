namespace Contacts.Pages;

using Android.Content.Res;
using static Contacts.App;
using PartialMethodsPhoneDialer = InvokePlatformCodeDemos.Services.PartialMethods.PhoneDialer;

public partial class Contact : ContentPage
{

    
    //ContactItem contact;


    public Contact()
	{
		InitializeComponent();

        //this.contact = contact;

        //setContactInfo();

        BindingContext = selectedContact;

        Call.Text = "\uf095";
        Message.Text = "\uf4a6";

        phoneIcon.Text = "\uf095";
        cityIcon.Text = "\uf64f";
        mailIcon.Text = "\uf0e0";
    }

  

    private async void Message_Clicked(object sender, EventArgs e)
    {
        if (Sms.Default.IsComposeSupported)
        {
            string[] recipients = new[] { selectedContact.phoneNumber };
            string text = "";

            var message = new SmsMessage(text, recipients);

            await Sms.Default.ComposeAsync(message);
        }
    }

    private async void Call_Clicked(object sender, EventArgs e)
    {
        await RequestPhonePermission();
    }

    async Task RequestPhonePermission()
    {
        if (DeviceInfo.Platform != DevicePlatform.Android)
            return;

        var status = PermissionStatus.Unknown;
        {
            status = await Permissions.CheckStatusAsync<Permissions.Phone>();

            if (status == PermissionStatus.Granted)
            {
                var dialer = new PartialMethodsPhoneDialer();
                dialer.CallPhone(selectedContact.phoneNumber);
                return;
            }

            if (Permissions.ShouldShowRationale<Permissions.Phone>())
            {
                await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
            }

            status = await Permissions.RequestAsync<Permissions.Phone>();

        }


        if (status != PermissionStatus.Granted)
            await Shell.Current.DisplayAlert("Permission required",
                "Phone permission is required for calling. " +
                "We just want to do a test.", "OK");

        else if (status == PermissionStatus.Granted)
        {
            var dialer = new PartialMethodsPhoneDialer();
            dialer.CallPhone(selectedContact.phoneNumber);
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        contacts.Remove(selectedContact);

        Navigation.PopAsync();
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        var pagina = new UpdateContact();
        pagina.CornerRadius = 20;
        pagina.HasBackdrop = true;
        await pagina.ShowAsync(Window);


    }

    private async void icon_Tapped(object sender, TappedEventArgs e)
    {
        var result = await this.DisplayActionSheet("Change Picture", "Cancel", null, "Open camera", "Take from gallery");

        if (result == "Open camera")
        {

            
            var foto = await MediaPicker.CapturePhotoAsync();

            if(foto != null )
            {

                string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
                using Stream sourceStream = await foto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);


                selectedContact.contactPicture = localFilePath;
                OnPropertyChanged(nameof(selectedContact.contactPicture));
            }
        }
        else if (result == "Take from gallery")
        {
            var foto = await MediaPicker.PickPhotoAsync();

            if (foto != null)
            {

                string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
                using Stream sourceStream = await foto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);


                selectedContact.contactPicture = localFilePath;
                OnPropertyChanged(nameof(selectedContact.contactPicture));
            }

        }
    }
}