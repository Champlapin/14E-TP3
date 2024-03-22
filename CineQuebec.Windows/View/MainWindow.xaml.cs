﻿using CineQuebec.Windows.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            mainContentControl.Content = new ConnexionControl();
        }

        public void AdminHomeControl()
        {
            mainContentControl.Content = new AdminHomeControl();
        }
        public void ConsultationUtilisateursControl()
        {
            mainContentControl.Content = new ConsultationAbonnesControl();
        }
        public void ConsultationFilmsControls()
        {
            mainContentControl.Content = new ConsultationFilmsControl();
        }


    }
}