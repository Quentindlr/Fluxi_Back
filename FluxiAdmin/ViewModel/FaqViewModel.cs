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

namespace FluxiAdmin.ViewModel
{
    public class FaqViewModel
    {
        private BaseRepository<Faq> _faqRepository;
        private DataContextService dataContext;
        private Faq selectFaq;

        public ObservableCollection<Faq> Faqs { get; set; }
        public Faq Faq { get; set; }
        public Faq SelectFaq { get => selectFaq; set => selectFaq = value; }
        public string Text { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeletteCommand { get; set; }

        public FaqViewModel()
        {
            dataContext = new DataContextService();
            _faqRepository = new FaqRepository(dataContext);
            AddCommand = new RelayCommand(Add);
            DeletteCommand = new RelayCommand(Delette);
            Faqs = new ObservableCollection<Faq>(_faqRepository.FindAll(a => true));
        }

        public void Add()
        {
            Faq faq = new Faq()
            {
                Text = Text,
            };
            _faqRepository.Add(faq);
            Faqs.Add(faq);
        }

        public void Delette()
        {
            if (SelectFaq != null)
            {
                _faqRepository.Delete(SelectFaq);
                Faqs.Remove(SelectFaq);
            }

        }
    }
}
