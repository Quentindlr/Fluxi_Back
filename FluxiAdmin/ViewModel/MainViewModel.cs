using back_Fluxi.Interfaces;
using back_Fluxi.Models;
using FluxiAdmin.Pages;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FluxiAdmin.ViewModel
{
    public class MainViewModel
    {
        private HttpClient httpClient;
        public ICommand ConnectionCommand { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public MainViewModel()
        {
            httpClient = new HttpClient();
            ConnectionCommand = new RelayCommand(Connection);

        }

        public async void Connection()
        {
            UserDTO client = new UserDTO(Email, Password);
            string json = JsonConvert.SerializeObject(client);
            HttpContent userDTO = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:7008/api/login", userDTO);
            if (response.IsSuccessStatusCode)
            {
                Home c = new Home();
                c.Show();
            }
        }


    }
}
