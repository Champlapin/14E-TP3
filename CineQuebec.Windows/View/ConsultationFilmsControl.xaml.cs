﻿using CineQuebec.Windows.DAL;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.Exceptions;
using CineQuebec.Windows.Ressources.i18n;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour ConsultationFilmsControl.xaml
    /// </summary>
    public partial class ConsultationFilmsControl : UserControl
    {
        private readonly DatabasePeleMele databasePeleMele = new DatabasePeleMele();
        private List<Film> films = new List<Film>();
        public ConsultationFilmsControl()
        {
            try
            {
                InitializeComponent();
                lstFilms.ItemsSource = databasePeleMele.ReadFilms();
            }
            catch(MongoDataConnectionException err) {
                MessageBox.Show(err.Message, Resource.erreur, MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(Resource.erreurGenerique, Resource.erreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
