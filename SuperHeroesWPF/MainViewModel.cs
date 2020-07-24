using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SuperHeroesWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name { get; set; }
        private int _strenght { get; set; }
        private int _intelligence { get; set; }
        private int _stamina { get; set; }
        private int _charism { get; set; }

        private ICommand _saveCommand;
        private ObservableCollection<SuperHeroClient> _superHeroes;

        public string Name
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(value)));
                }
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(value)));
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(value)));
                }
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new DelegateCommand(Save, CanSave));
            }

        }

        public ObservableCollection<Contact> Contacts { get => _contacts ?? (_contacts = LoadContacts()); } // ajoute l'observablecollection qui contient le datareader du querry

        private ObservableCollection<Contact> LoadContacts()
        {
            Connection Co = new Connection(SqlClientFactory.Instance, @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mikaDB; Integrated Security = True;");
            Command cmd = new Command("Select Id, LastName, FirstName, Email from Contacts");
            return new ObservableCollection<Contact>(Co.ExecuteReader(cmd, (datareader) => new Contact((int)datareader["Id"], (string)datareader["LastName"], (string)datareader["FirstName"], (string)datareader["Email"]))); // 

        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(LastName) &&
                 !string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(Email);
        }

        private void Save()
        {
            Connection Co = new Connection(SqlClientFactory.Instance, @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mikaDB; Integrated Security = True;");
            Command cmd = new Command("SP_AddContacts", true);
            cmd.AddParameter("LastName", LastName);
            cmd.AddParameter("FirstName", FirstName);
            cmd.AddParameter("Email", Email);
            int Id = (int)Co.ExecuteScalar(cmd);

            Contacts.Add(new Contact(Id, LastName, FirstName, Email)); //

            LastName = FirstName = Email = null;
        }

    }
}
