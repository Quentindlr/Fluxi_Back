using back_Fluxi.Models;
using back_Fluxi.Repositories;
using FluxiAdmin.ViewModel;
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
    /// Logique d'interaction pour CategoriePage.xaml
    /// </summary>
    public partial class CategoriePage : Window
    {
        
        
        public CategoriePage()
        {
            
            InitializeComponent();
            DataContext = new CategorieViewModel();
            
        }
    }
}
