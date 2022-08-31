using back_Fluxi.Interfaces;
using back_Fluxi.Models;
using back_Fluxi.Repositories;
using back_Fluxi.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FluxiAdmin.ViewModel
{
    public class FilmViewModel
    {
        private BaseRepository<Video> _filmRepository;
        private BaseRepository<Categorie> _categorieRepository;
        private DataContextService dataContext;
        private Video selectVideo;
        private string image;
        private HttpClient httpClient;
        private int idFilm;


        public ObservableCollection<Video> Films { get; set; }
        public Video Video { get; set; }
        public Video SelectVideo { get => selectVideo;set => selectVideo = value; }
        public string Name { get; set; }
        public int Id { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }
        public ICommand DeletteCommand { get; set; }


        public FilmViewModel()
        {
            dataContext = new DataContextService();
            _filmRepository = new VideoRepository(dataContext);
            _categorieRepository = new CategorieRepository(dataContext);
            httpClient = new HttpClient();


            AddCommand = new RelayCommand(Add);
            DeletteCommand = new RelayCommand(Delette);
            OpenFileCommand = new RelayCommand(OpenFile);

            Films = new ObservableCollection<Video>(_filmRepository.FindAll(a => true));
        }

        public void Add()
        {
            Video video = new Video()
            {

                Name = Name,
                Categorie = _categorieRepository.Find(c => c.Id == Id),
                Images = new Image()
                {
                    UrlImage = upload().ToString(),
                    UrlImageBack = upload().ToString(),
                    UrlVideo = upload().ToString(),
                }
            };

            _filmRepository.Add(video);
            Films.Add(video);
        }

        public void Delette()
        {
            if (SelectVideo != null)
            {
                _filmRepository.Delete(SelectVideo);
                Films.Remove(SelectVideo);
            }
        }

        public void OpenFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".jpg"; 
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

  
            bool? result = dialog.ShowDialog();


            if (result == true)
            {

                image = dialog.FileName;

            }
        }

        public async Task<string> upload()
        {
            var multipartFormContent = new MultipartFormDataContent();

            var fileStreamContent = new StreamContent(File.OpenRead(image));

            multipartFormContent.Add(fileStreamContent, name: "image", fileName: "house.png");

            var response = await httpClient.PutAsync("http://localhost:7008/api/film/6/image", multipartFormContent);

            response.EnsureSuccessStatusCode();
            return image;


        }






    }
}
