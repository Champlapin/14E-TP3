﻿using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Enums;
using CineQuebec.Windows.DAL.ServicesInterfaces;
using CineQuebec.Windows.Exceptions;
using CineQuebec.Windows.Ressources.i18n;
using CineQuebec.Windows.ViewModel;
using CineQuebec.Windows.ViewModel.Event;
using Prism.Events;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour ConsultationFilmsControl.xaml
    /// </summary>
    public partial class ConsultationFilmsProjectionsControl : UserControl
    {
        private readonly IFilmService _filmService;
        private readonly IProjectionService _projectionService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ConsultationFilmsProjectionsModel _viewModel;

        public ConsultationFilmsProjectionsControl(IFilmService filmService, IProjectionService projectionService,IEventAggregator eventAggregator)
        {
            _filmService = filmService;
            _projectionService = projectionService;
            _eventAggregator = eventAggregator;
            _viewModel = new ConsultationFilmsProjectionsModel(filmService, projectionService, eventAggregator);
            _eventAggregator = eventAggregator;
            DataContext = _viewModel;

            InitializeComponent();
            ChargerFilmProjection();
        }

        private async void ChargerFilmProjection()
        {
            try
            {
                lstFilms.ItemsSource = await _filmService.GetAllFilms();
                lstProjections.ItemsSource = _projectionService.GetAllProjections();
            }
            catch (MongoDataConnectionException err)
            {
                MessageBox.Show(err.Message, Resource.erreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(Resource.erreurGenerique, Resource.erreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Événement lancé lors de lu double click d'un élément dans la liste des films
        /// </summary>
        /// <param name="sender">ListBox contenant les films</param>
        /// <param name="e"></param>
        private void lstFilm_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstFilms.SelectedItem != null)
            {
                Film film = lstFilms.SelectedItem as Film;
                DetailFilm detailFilm = new DetailFilm(_filmService,_eventAggregator, film);

                if ((bool)detailFilm.ShowDialog())
                    ChargerFilmProjection();
            }
        }

        private void lstFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Film selectedFilm = lstFilms.SelectedItem as Film;
            if (selectedFilm is not null)
                _ = getprojectionsAsync(selectedFilm);
            gpoProjections.Header = selectedFilm is not null ? $"Projections ({selectedFilm.Titre})" : "Projections";
        }

        private async Task getprojectionsAsync(Film selectedFilm)
        {
            var projections = await _projectionService.GetProjectionsById(selectedFilm.Id);
            lstProjections.ItemsSource = projections;
        }

        private void btnAjoutFilm_Click(object sender, RoutedEventArgs e)
        {
            DetailFilm detailFilm = new DetailFilm(_filmService,_eventAggregator);
            if ((bool)detailFilm.ShowDialog())
                ChargerFilmProjection();
        }

        private void btnAjoutProjection_Click(object sender, RoutedEventArgs e)
        {
            AjoutDetailProjection detailProjection = new AjoutDetailProjection(_projectionService, _filmService,_eventAggregator);
            if ((bool)detailProjection.ShowDialog())
                ChargerFilmProjection();
        }
    }
}