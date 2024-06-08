﻿using System.Windows.Input;

namespace DVS.ViewModels.AddViewModels.Forms
{
    public class EditEmployeeFormViewModel : ViewModelBase
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

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string? _comment;
        public string? Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand ClearEmployeeClothesListCommand { get; }
        public ICommand CancelEmployeeCommand { get; }

        public EditEmployeeFormViewModel(
            ICommand editEmployeeCommand,
            ICommand deleteEmployeeCommand,
            ICommand clearEmployeeClothesListCommand,
            ICommand cancelEmployeeCommand)
        {
            EditEmployeeCommand = editEmployeeCommand;
            ClearEmployeeClothesListCommand = clearEmployeeClothesListCommand;
            DeleteEmployeeCommand = deleteEmployeeCommand;
            CancelEmployeeCommand = cancelEmployeeCommand;
        }

    }
}
