using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Contacts
{

    public partial class App : Application
    {
        public static ObservableCollection<ContactItem> contacts;

        public static ContactItem selectedContact;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


        }
    
        public class ContactItem : INotifyPropertyChanged
        {
            public string _name;
            public string name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged(nameof(name));
                    }
                }
            }



            private string _occupation;
            public string occupation
            {
                get { return _occupation; }
                set
                {
                    if (_occupation != value)
                    {
                        _occupation = value;
                        OnPropertyChanged(nameof(occupation));
                    }
                }
            }

            private string _phoneNumber;
            public string phoneNumber
            {
                get { return _phoneNumber; }
                set
                {
                    if (_phoneNumber != value)
                    {
                        _phoneNumber = value;
                        OnPropertyChanged(nameof(phoneNumber));
                    }
                }
            }

            private string _address;
            public string address
            {
                get { return _address; }
                set
                {
                    if (_address != value)
                    {
                        _address = value;
                        OnPropertyChanged(nameof(address));
                    }
                }
            }

            private string _email;
            public string email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        OnPropertyChanged(nameof(email));
                    }
                }
            }

            private string _contactPicture;
            public string contactPicture
            {
                get { return _contactPicture; }
                set
                {
                    if (_contactPicture != value)
                    {
                        _contactPicture = value;
                        OnPropertyChanged(nameof(contactPicture));
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
