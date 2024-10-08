﻿using DVS.Domain.Models;
using System.Windows.Input;

namespace DVS.WPF.ViewModels.Forms
{
    public class AddEditEmployeeFormViewModel(Employee? employee,
                                              AddEditEmployeeListingViewModel addEditEmployeeListingViewModel,
                                              ICommand submitCommand)
                                              : ViewModelBase
    {
        public AddEditEmployeeListingViewModel AddEditEmployeeListingViewModel { get; } = addEditEmployeeListingViewModel;

        public ICommand SubmitEmployee { get; } = submitCommand;

        public Employee? Employee { get; } = employee;

        private string _iD;
        public string ID
        {
            get => _iD;
            set
            {
                if (ID != value)
                {
                    _iD = value;
                    OnPropertyChanged(nameof(ID));
                    OnPropertyChanged(nameof(CanSubmit));
                }
            }
        }

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged(nameof(Lastname));
                    OnPropertyChanged(nameof(CanSubmit));
                }
            }
        }

        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged(nameof(Firstname));
                    OnPropertyChanged(nameof(CanSubmit));
                }
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (Comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
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
                if (_isSubmitting != value)
                {
                    _isSubmitting = value;
                    OnPropertyChanged(nameof(IsSubmitting));
                }
            }
        }

        public bool HasError;

        public bool CanSubmit
        {//TODO: canSubmitEmployee auf true setzen wenn Kleidungsliste verändert wird
            get
            {
                if (string.IsNullOrEmpty(ID) || ID == "ID" ||
                    string.IsNullOrEmpty(Lastname) || Lastname == "Nachname" ||
                    string.IsNullOrEmpty(Firstname) || Firstname == "Vorname")
                {
                    return false;
                }

                if (Employee != null)
                {
                    if (ID == Employee.ID &&
                        Lastname == Employee.Lastname &&
                        Firstname == Employee.Firstname)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
