﻿using DVS.WPF.Commands.AddEditEmployeeCommands;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Forms;
using System.Windows.Input;

namespace DVS.WPF.ViewModels.Views
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly AddEditEmployeeListingViewModel _addEditEmployeeListingViewModel;
        public AddEditEmployeeFormViewModel AddEditEmployeeFormViewModel { get; }
        public ICommand CloseAddEditEmployee { get; }


        public AddEmployeeViewModel(AddEditEmployeeListingViewModel addEditEmployeeListingViewModel,
                                    EmployeeStore employeeStore,
                                    ClothesStore clothesStore,
                                    ClothesSizeStore clothesSizeStore,
                                    ModalNavigationStore modalNavigationStore)
        {
            _addEditEmployeeListingViewModel = addEditEmployeeListingViewModel;

            ICommand addEmployee = new AddEmployeeCommand(this, employeeStore, clothesSizeStore, modalNavigationStore);

            CloseAddEditEmployee = new CloseAddEditEmployeeCommand(clothesStore, modalNavigationStore);

            AddEditEmployeeFormViewModel = new(null, _addEditEmployeeListingViewModel, addEmployee)
            {
                ID = "ID",
                Lastname = "Nachname",
                Firstname = "Vorname",
                Comment = "Kommentar"
            };
        }
    }
}
