﻿using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Views;

namespace DVS.WPF.ViewModels
{
    /// <summary>
    /// Hauptklasse zur Implementierung der allgemeinen Betrefflickeiten der App:
    /// Dieser Klasse wird in App.xaml.cs der Datenkontext zugeteilt.
    /// sowie die Instanzen von "ModalNavigationStore" und "DVSViewModel" übergeben.
    /// 
    /// In dieser Klasse wird das handling der Modals vorgenommen.
    /// Sobald sich das aktuelle Modal ändert wird _modalNavigationStore.CurrentViewModelChanged()
    /// aufgerufen, und das neue aktuelle Modal sowie der Zustand von IsOpen, anhand der Methode
    /// ModalNavigationStore_CurrentViewModelChanged() übergeben.
    /// Anhand von Dispose() wird das aktuelle Modal geschlossen.
    /// </summary>
    class MainViewModel : ViewModelBase
    {
        public DVSHeadViewModel DVSHeadViewModel { get; }
        public DVSSizeViewModel DVSSizeViewModel { get; }
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public bool IsModalOpen => _modalNavigationStore.IsOpen;


        public MainViewModel(
            DVSHeadViewModel dVSHeadViewModel,
            DVSSizeViewModel dVSViewModel,
            ModalNavigationStore modalNavigationStore)
        {
            DVSHeadViewModel = dVSHeadViewModel;
            DVSSizeViewModel = dVSViewModel;
            _modalNavigationStore = modalNavigationStore;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }


        // Aktualisieren des Modal-ViewModel.
        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
        
        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }
    }
}
