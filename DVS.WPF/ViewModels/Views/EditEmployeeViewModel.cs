﻿using DVS.WPF.Commands.AddEditEmployeeCommands;
using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Forms;
using System.Windows.Input;

namespace DVS.WPF.ViewModels.Views
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeFormViewModel AddEditEmployeeFormViewModel { get; }
        public ICommand CloseAddEditEmployee { get; }


        public EditEmployeeViewModel(EmployeeModel employee, EmployeeStore employeeStore, ClothesStore clothesStore,
            ModalNavigationStore modalNavigationStore, DVSListingViewModel dVSListingViewModel)
        {
            ICommand editEmployee = new EditEmployeeCommand(this, employeeStore, modalNavigationStore, employee.GuidID);
            CloseAddEditEmployee = new CloseAddEditEmployeeCommand(clothesStore, modalNavigationStore);

            AddEditEmployeeFormViewModel = new(employee, dVSListingViewModel, editEmployee)
            {
                ID = employee.ID,
                Lastname = employee.Lastname,
                Firstname = employee.Firstname,
                Comment = employee.Comment
            };

            dVSListingViewModel.LoadNewEmployeeListingItemCollection(employee);
        }
    }
}