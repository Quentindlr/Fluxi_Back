using back_Fluxi.Models;
using back_Fluxi.Repositories;
using back_Fluxi.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace FluxiAdmin.ViewModel
{
    public class CategorieViewModel : ViewModelBase
    {
        private BaseRepository<Categorie> _categorieRepository;
        private DataContextService dataContext;
        private Categorie selectCategorie;


        public ObservableCollection<Categorie> Categories { get; set; }
        public Categorie Categorie { get; set; }
        public Categorie SelectCategorie { get => selectCategorie; set => selectCategorie = value; }
        public string Name { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeletteCommand { get; set; }

        public CategorieViewModel()
        {
            dataContext = new DataContextService();
            _categorieRepository = new CategorieRepository(dataContext);
            AddCommand = new RelayCommand(Add);
            DeletteCommand = new RelayCommand(Delette);
            Categories = new ObservableCollection<Categorie>(_categorieRepository.FindAll(a => true));
        }

        public void Add()
        {            
            Categorie categorie = new Categorie()
            {
                Name = Name,
            };
            _categorieRepository.Add(categorie);
            Categories.Add(categorie);
        }

        public void Delette()
        {
            if(SelectCategorie != null)
            {
                _categorieRepository.Delete(SelectCategorie);
                Categories.Remove(SelectCategorie);
            }

        }
    }
}
