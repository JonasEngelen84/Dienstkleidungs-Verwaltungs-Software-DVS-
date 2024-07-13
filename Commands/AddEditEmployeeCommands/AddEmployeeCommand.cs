﻿using DVS.Models;
using DVS.Stores;
using DVS.ViewModels.Forms;
using DVS.ViewModels.Views;

namespace DVS.Commands.AddEditEmployeeCommands
{
    public class AddEmployeeCommand(AddEmployeeViewModel addEmployeeViewModel, EmployeeStore employeeStore,
        ModalNavigationStore modalNavigationStore) : AsyncCommandBase
    {
        private readonly AddEmployeeViewModel _addEmployeeViewModel = addEmployeeViewModel;
        private readonly EmployeeStore _employeeStore = employeeStore;
        private readonly ModalNavigationStore _modalNavigationStore = modalNavigationStore;

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditEmployeeFormViewModel addEmployeeFormViewModel = _addEmployeeViewModel.AddEditEmployeeFormViewModel;

            addEmployeeFormViewModel.ErrorMessage = null;
            addEmployeeFormViewModel.IsSubmitting = true;

            EmployeeModel employee = new(Guid.NewGuid(),
                                         addEmployeeFormViewModel.ID,
                                         addEmployeeFormViewModel.Firstname,
                                         addEmployeeFormViewModel.Lastname,
                                         addEmployeeFormViewModel.Comment);

            foreach (DetailedClothesListingItemModel clothes in
                _addEmployeeViewModel.AddEditEmployeeFormViewModel.DVSListingViewModel.NewEmployeeListingItemCollection)
            {
                employee.Clothes.Add(clothes);
            }

            try
            {
                await _employeeStore.Add(employee);
            }
            catch (Exception)
            {
                addEmployeeFormViewModel.ErrorMessage = "Erstellen des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.";
            }
            finally
            {
                addEmployeeFormViewModel.IsSubmitting = false;
                _modalNavigationStore.Close();
            }
        }
    }
}