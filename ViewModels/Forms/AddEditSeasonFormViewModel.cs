﻿using DVS.Stores;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace DVS.ViewModels.Forms
{
    public class AddEditSeasonFormViewModel : ViewModelBase
    {
        private string _addNewSeason;
        public string AddNewSeason
        {
            get => _addNewSeason;
            set
            {
                _addNewSeason = value;
                OnPropertyChanged(nameof(AddNewSeason));
            }
        }

        private string _editSeason;
        public string EditSeason
        {
            get => _editSeason;
            set
            {
                _selectedSeasonStore.SelectedSeason = value;
                _editSeason = value;
                OnPropertyChanged(nameof(EditSeason));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        //public bool CanSubmit => !string.IsNullOrEmpty(Username);

        private readonly SeasonStore _seasonStore;
        private readonly SelectedSeasonStore _selectedSeasonStore;

        //TODO: Dispose Collections?
        private readonly ObservableCollection<string> _seasonCollection;
        private readonly CollectionViewSource _seasonCollectionViewSource;
        public IEnumerable<string> SeasonCollection => _seasonCollectionViewSource.View.Cast<string>();

        public ICommand AddSeasonCommand { get; }
        public ICommand EditSeasonCommand { get; }
        public ICommand DeleteSeasonCommand { get; }
        public ICommand ClearSeasonListCommand { get; }
        public ICommand CloseAddSeasonCommand { get; } 

        public AddEditSeasonFormViewModel(
            SeasonStore seasonStore,
            SelectedSeasonStore selectedSeasonStore,
            ICommand addSeasonCommand,
            ICommand editSeasonCommand,
            ICommand deleteSeasonCommand,
            ICommand clearSeasonListCommand,
            ICommand closeAddSeasonCommand)
        {
            _seasonStore = seasonStore;
            _selectedSeasonStore = selectedSeasonStore;
            AddSeasonCommand = addSeasonCommand;
            EditSeasonCommand = editSeasonCommand;
            DeleteSeasonCommand = deleteSeasonCommand;
            ClearSeasonListCommand = clearSeasonListCommand;
            CloseAddSeasonCommand = closeAddSeasonCommand;

            EditSeason = "Saison wählen";

            _seasonCollection = [];
            _seasonCollectionViewSource = new CollectionViewSource { Source = _seasonCollection };
            _seasonCollectionViewSource.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));

            _seasonStore.SeasonsLoaded += SeasonStore_SeasonsLoaded;
            _seasonStore.SeasonsAdded += SeasonStore_SeasonAdded;
        }

        protected override void Dispose()
        {
            _seasonStore.SeasonsLoaded -= SeasonStore_SeasonsLoaded;
            _seasonStore.SeasonsAdded -= SeasonStore_SeasonAdded;

            base.Dispose();
        }

        private void SeasonStore_SeasonsLoaded()
        {
            _seasonCollection.Clear();

            foreach (string season in _seasonStore.Seasons)
            {
                AddSeason(season);
            }
        }

        private void SeasonStore_SeasonAdded(string season)
        {
            AddSeason(season);
        }

        private void Edit_Season()
        {

        }

        private void AddSeason(string season)
        {
            _seasonCollection.Add(season);
            _seasonCollectionViewSource.View.Refresh();
            AddNewSeason = "";
            OnPropertyChanged(nameof(SeasonCollection));
        }
    }
}
