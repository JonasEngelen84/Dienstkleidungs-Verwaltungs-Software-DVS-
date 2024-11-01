﻿using DVS.EntityFramework;
using DVS.WPF.Commands.AddEditClothesCommands;
using DVS.WPF.Commands.AddEditEmployeeCommands;
using DVS.WPF.Stores;
using System.Windows.Input;

namespace DVS.WPF.ViewModels.Views
{
    public class DVSHeadViewModel(DVSListingViewModel dVSListingViewModel,
                                  AddEditEmployeeListingViewModel addEditEmployeeListingViewModel,
                                  ModalNavigationStore modalNavigationStore,
                                  SizeStore sizeStore,
                                  CategoryStore categoryStore,
                                  SeasonStore seasonStore,
                                  ClothesStore clothesStore,
                                  ClothesSizeStore clothesSizeStore,
                                  EmployeeClothesSizesStore employeeClothesSizesStore,
                                  EmployeeStore employeeStore,
                                  DVSDbContextFactory dVSDbContextFactory)
                                  : ViewModelBase
    {
        public DVSListingViewModel DVSListingViewModel { get; } = dVSListingViewModel;

        public ICommand OpenAddEmployee { get; } = new OpenAddEmployeeCommand(addEditEmployeeListingViewModel,
                                                                              employeeStore,
                                                                              clothesStore,
                                                                              clothesSizeStore,
                                                                              modalNavigationStore);

        public ICommand OpenAddClothes { get; } = new OpenAddClothesCommand(modalNavigationStore,
                                                                            sizeStore,
                                                                            categoryStore,
                                                                            seasonStore,
                                                                            clothesStore,
                                                                            clothesSizeStore,
                                                                            employeeClothesSizesStore,
                                                                            employeeStore,
                                                                            dVSListingViewModel,
                                                                            dVSDbContextFactory);
    }
}
