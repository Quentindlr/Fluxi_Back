using back_Fluxi.Models;
using back_Fluxi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FluxiAdmin.Pages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        

        public Home()
        {
            InitializeComponent();
            
        }

        private void FilmClick(object sender, RoutedEventArgs e)
        {
            FilmPage f = new FilmPage();
            f.Show();
        }

        public void CategorieClick(object sender, RoutedEventArgs e)
        {
            CategoriePage c = new CategoriePage();
            c.Show();
        }

        private void FaqClick(object sender, RoutedEventArgs e)
        {
            FaqPage f = new FaqPage();
            f.Show();
        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            ClientPage f = new ClientPage();
            f.Show();
        }
    }
}
