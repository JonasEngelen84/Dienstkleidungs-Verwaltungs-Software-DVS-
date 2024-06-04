﻿using DVS.Stores;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace DVS.ViewModels.Forms
{
    public class AddClothesFormViewModel : ViewModelBase
    {
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _size;
        public string Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        private string _quantity;
        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedSeason;
        public string SelectedSeason
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
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

        //TODO: CanSubmit
        //public bool CanSubmit => !string.IsNullOrEmpty(Username);

        //TODO: Category-/Season-ComboBoxes sortieren
        private readonly ObservableCollection<string> _categories;
        //private readonly CollectionViewSource _categoryCollectionViewSource;
        public IEnumerable<string> Categories => _categories;

        private  ObservableCollection<string> _seasons;
        //private readonly CollectionViewSource _seasonCollectionViewSource;
        public IEnumerable<string> Seasons => _seasons; //_seasonCollectionViewSource.View.Cast<string>()

        private readonly CategoryStore _categoryStore;
        private readonly SeasonStore _seasonStore;

        public ClothesListViewViewModel ClothesListViewViewModel { get; }

        public ICommand OpenAddEditCategoriesCommand { get; }
        public ICommand OpenAddEditSeasonsCommand { get; }
        public ICommand AddClothesCommand { get; }
        public ICommand CancelClothesCommand { get; }

        public AddClothesFormViewModel(
            CategoryStore categoryStore,
            SeasonStore seasonStore,
            ClothesListViewViewModel clothesListViewViewModel,
            ICommand openAddEditCategoriesCommand,
            ICommand openAddEditSeasonsCommand,
            ICommand addClothesCommand,
            ICommand cancelClothesCommand)
        {
            _categoryStore = categoryStore;
            _seasonStore = seasonStore;

            ClothesListViewViewModel = clothesListViewViewModel;

            _categories = ["Hose", "Pullover", "Shirt", "Jacke", "Kopfbedeckung", "Hose2", "Pullover2", "Shirt2", "Jacke2", "Kopfbedeckung2"];
            //_categoryCollectionViewSource = new CollectionViewSource { Source = _categories };
            //_categoryCollectionViewSource.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
            
            _seasons = ["Saisonlos", "Sommer", "Winter"];
            //_seasonCollectionViewSource = new CollectionViewSource { Source = _seasons };
            //_seasonCollectionViewSource.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));

            OpenAddEditCategoriesCommand = openAddEditCategoriesCommand;
            OpenAddEditSeasonsCommand = openAddEditSeasonsCommand;
            AddClothesCommand = addClothesCommand;
            CancelClothesCommand = cancelClothesCommand;
        }

    }
}
