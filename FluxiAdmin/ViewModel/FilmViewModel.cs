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
using System.Net.Http.Headers;
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
        private string imageBack;
        private string urlVideo;
        private HttpClient httpClient;
        private int idFilm;
        private string nameImage;
        private string nameImageBack;
        private string nameVideo;


        public ObservableCollection<Video> Films { get; set; }
        public Video Video { get; set; }
        public Video SelectVideo { get => selectVideo;set => selectVideo = value; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Synopsis { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }
        public ICommand OpenFileBackCommand { get; set; }
        public ICommand OpenFileVideoCommand { get; set; }
        public ICommand DeletteCommand { get; set; }


        public FilmViewModel()
        {
            dataContext = new DataContextService();
            _filmRepository = new VideoRepository(dataContext);
            _categorieRepository = new CategorieRepository(dataContext);
            httpClient = new HttpClient();


            AddCommand = new RelayCommand(Add);
            DeletteCommand = new RelayCommand(Delette);
            OpenFileBackCommand = new RelayCommand(OpenFileBack);
            OpenFileVideoCommand = new RelayCommand(OpenFileVideo);
            OpenFileCommand = new RelayCommand(OpenFile);

            Films = new ObservableCollection<Video>(_filmRepository.FindAll(a => true));
        }

        public async void Add()
        {
            using(var multipartFormContent = new MultipartFormDataContent())
            {
                multipartFormContent.Add(new StringContent(Name), name: "Name");
                multipartFormContent.Add(new StringContent(Id), name: "CategorieId");
                multipartFormContent.Add(new StringContent(Synopsis), name: "Synopsis");

                var fileStreamContent = new StreamContent(File.OpenRead(image));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                multipartFormContent.Add(fileStreamContent, name:"image",fileName:nameImage);

                var fileStreamContentBack = new StreamContent(File.OpenRead(imageBack));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                multipartFormContent.Add(fileStreamContentBack, name: "imageBack", fileName: nameImageBack);


                var fileStreamContentVideo = new StreamContent(File.OpenRead(urlVideo));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
                multipartFormContent.Add(fileStreamContentVideo, name: "urlVideo", fileName: nameVideo);

                var response = await httpClient.PostAsync("http://localhost:7008/api/film",multipartFormContent);
                response.EnsureSuccessStatusCode();
                string test = await response.Content.ReadAsStringAsync();
            }

            Video video = new Video()
            {
                Name = Name,
                CategorieId = Int32.Parse(Id),
                Synopsis = Synopsis,
                UrlImage = "images/" + nameImage,
                UrlImageBack ="images/" + nameImageBack,
                UrlVideo = "videos/" + nameVideo
            };
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
                nameImage = dialog.SafeFileName;

            }
        }

        public void OpenFileBack()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";


            bool? result = dialog.ShowDialog();


            if (result == true)
            {

                imageBack = dialog.FileName;
                nameImageBack = dialog.SafeFileName;
            }
        }

        public void OpenFileVideo()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".mp4";
            dialog.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.mv1;*.mp4;*.MP4;";


            bool? result = dialog.ShowDialog();


            if (result == true)
            {

                urlVideo = dialog.FileName;
                nameVideo = dialog.SafeFileName;

            }
        }









    }
}
