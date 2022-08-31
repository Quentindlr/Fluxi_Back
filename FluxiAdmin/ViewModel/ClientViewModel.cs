using back_Fluxi.Models;
using back_Fluxi.Repositories;
using back_Fluxi.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace FluxiAdmin.ViewModel
{
    public class ClientViewModel
    {
        private BaseRepository<Client> _clientRepository;
        private DataContextService dataContext;
        private Client selectClient;

        public ObservableCollection<Client> Clients { get; set; }
        public Client Client { get;set; }
        public Client SelectClient { get => selectClient; set => selectClient = value; }

        public string Username { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string Role { get; set; }

        public ICommand AddCommand { get; set; }    
        public ICommand DeletteCommand { get; set; }

        public ClientViewModel()
        {
            dataContext = new DataContextService();
            _clientRepository = new ClientRepository(dataContext);
            AddCommand = new RelayCommand(Add);
            DeletteCommand = new RelayCommand(Delette);
            Clients = new ObservableCollection<Client>(_clientRepository.FindAll(a => true));

        }
        public void Add()
        {
            Client client = new Client()
            {
                Username = Username,
                Email = Email,
                Password = Password,
                Role = Role,
            };
            _clientRepository.Add(client);
            Clients.Add(client);
        }

        public void Delette()
        {
            if (SelectClient != null)
            {
                _clientRepository.Delete(SelectClient);
                Clients.Remove(SelectClient);
            }

        }
    }
}
