﻿using DVS.Domain.Models;
using System.Windows.Input;

namespace DVS.WPF.ViewModels.Forms
{
    public class AddEditCategoryFormViewModel(ICommand addCategoryCommand, ICommand editCategoryCommand,
        ICommand deleteCategoryCommand, ICommand clearCategoryListCommand,
        AddEditListingViewModel addEditListingViewModel) : ViewModelBase
    {
        public AddEditListingViewModel AddEditListingViewModel { get; } = addEditListingViewModel;
        public ICommand AddCategory { get; } = addCategoryCommand;
        public ICommand EditCategory { get; } = editCategoryCommand;
        public ICommand DeleteCategory { get; } = deleteCategoryCommand;
        public ICommand ClearCategoryList { get; } = clearCategoryListCommand;

        private string _addNewCategory;
        public string AddNewCategory
        {
            get => _addNewCategory;
            set
            {
                _addNewCategory = value;
                OnPropertyChanged(nameof(AddNewCategory));
                OnPropertyChanged(nameof(CanAdd));
            }
        }
        
        private string _editSelectedCategory;
        public string EditSelectedCategory
        {
            get => _editSelectedCategory;
            set
            {
                _editSelectedCategory = value;
                OnPropertyChanged(nameof(EditSelectedCategory));
                OnPropertyChanged(nameof(CanEdit));
            }
        }
        
        private CategoryModel _selectedCategory;
        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (value != null)
                {
                    _selectedCategory = value;
                    EditSelectedCategory = new(value.Name);
                    OnPropertyChanged(nameof(SelectedCategory));
                    OnPropertyChanged(nameof(CanDelete));
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

        public bool CanAdd =>
            !string.IsNullOrEmpty(AddNewCategory) &&
            !AddNewCategory.Equals("Neue Kategorie");

        public bool CanEdit =>
            !string.IsNullOrEmpty(EditSelectedCategory) &&
            !SelectedCategory.Name.Equals("Kategorie wählen") &&
            !SelectedCategory.Name.Equals(EditSelectedCategory);

        public bool CanDelete => !SelectedCategory.Name.Equals("Kategorie wählen");
        public bool CanDeleteAll => !AddEditListingViewModel.Categories.IsEmpty;
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
    }
}