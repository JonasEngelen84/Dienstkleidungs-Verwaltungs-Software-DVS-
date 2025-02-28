﻿using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Forms;
using DVS.WPF.ViewModels.ListingItems;
using DVS.WPF.ViewModels.Views;

namespace DVS.WPF.Commands.EmployeeCommands
{
    public class AddEmployeeCommand(
        AddEmployeeViewModel addEmployeeViewModel,
        EmployeeStore employeeStore,
        ClothesStore clothesStore,
        ClothesSizeStore clothesSizeStore,
        ModalNavigationStore modalNavigationStore)
        : AsyncCommandBase
    {
        private readonly AddEmployeeViewModel _addEmployeeViewModel = addEmployeeViewModel;
        private readonly EmployeeStore _employeeStore = employeeStore;
        private readonly ClothesStore _clothesStore = clothesStore;
        private readonly ClothesSizeStore _clothesSizeStore = clothesSizeStore;
        private readonly ModalNavigationStore _modalNavigationStore = modalNavigationStore;


        public override async Task ExecuteAsync(object parameter)
        {
            AddEmployeeFormViewModel addEmployeeFormViewModel = _addEmployeeViewModel.AddEmployeeFormViewModel;


            if (CheckEmployeeId(addEmployeeFormViewModel) != null)
                ShowErrorMessageBox("Die eingegebene Id ist bereits vergeben!\nBitte eine andere Id eingeben.", "Vorhandene Id");
            else
            {
                addEmployeeFormViewModel.HasError = false;
                addEmployeeFormViewModel.IsSubmitting = true;

                List<ClothesSize> editedClothesSizesList = [];

                await UpdateClothesSizes(editedClothesSizesList, addEmployeeFormViewModel);
                await UpdateClothes(editedClothesSizesList, addEmployeeFormViewModel);
                Employee newEmployee = CreateNewEmployee(addEmployeeFormViewModel);
                await AddEmployeeToDB(newEmployee, addEmployeeFormViewModel);

                addEmployeeFormViewModel.IsSubmitting = false;
                _modalNavigationStore.Close();
            }
        }

        private Employee CheckEmployeeId(AddEmployeeFormViewModel addEmployeeFormViewModel)
        {
            Employee? existingEmployeeId = _employeeStore.Employees
                .FirstOrDefault(e => e.Id == addEmployeeFormViewModel.Id);

            return existingEmployeeId;
        }

        private async Task UpdateClothesSizes(List<ClothesSize> editedClothesSizesList, AddEmployeeFormViewModel addEmployeeFormViewModel)
        {
            List<AvailableClothesSizeItem> ClothesSizesToEdit = addEmployeeFormViewModel.AddEditEmployeeListingViewModel.GetAllClothesSizesToEdit();

            foreach (AvailableClothesSizeItem acsi in ClothesSizesToEdit)
            {
                ClothesSize existingClothesSize = _clothesSizeStore.ClothesSizes.First(cs => cs.GuidId == acsi.ClothesSizeId);

                if (existingClothesSize != null)
                {
                    AvailableClothesSizeItem existingAcsi = ClothesSizesToEdit.First(acsi => acsi.ClothesSize.GuidId == existingClothesSize.GuidId);

                    ClothesSize editedClothesSize = new(existingClothesSize.GuidId,
                                                        existingClothesSize.Clothes,
                                                        existingClothesSize.Size,
                                                        existingAcsi.Quantity,
                                                        existingClothesSize.Comment)
                    {
                        EmployeeClothesSizes = []
                    };

                    editedClothesSizesList.Add(editedClothesSize);

                    try
                    {
                        await _clothesSizeStore.Update(editedClothesSize);
                    }
                    catch
                    {
                        ShowErrorMessageBox("Erstellen des Mitarbeiters ist fehlgeschlagen!", "AddEmployeeCommand, UpdateClothesSizes");
                        addEmployeeFormViewModel.HasError = true;
                    }
                }
            }
        }

        private async Task UpdateClothes(List<ClothesSize> editedClothesSizesList, AddEmployeeFormViewModel addEmployeeFormViewModel)
        {
            List<Clothes> clothesToEdited = addEmployeeFormViewModel.AddEditEmployeeListingViewModel.GetAllClothesToEdit();

            foreach (Clothes clothes in clothesToEdited)
            {
                Clothes editedClothes = new(
                    clothes.Id,
                    clothes.Name,
                    clothes.Category,
                    clothes.Season,
                    clothes.Comment)
                {
                    Sizes = clothes.Sizes
                };

                foreach (ClothesSize editedClothesSize in editedClothesSizesList)
                {
                    if (editedClothesSize.ClothesId == clothes.Id)
                    {                        
                        ClothesSize existingClothesSize = editedClothes.Sizes .First(cs => cs.GuidId == editedClothesSize.GuidId);

                        if (existingClothesSize != null)
                        {
                            editedClothes.Sizes.Remove(existingClothesSize);
                            editedClothes.Sizes.Add(editedClothesSize);
                        }
                    }
                }
                
                try
                {
                    await _clothesStore.Update(editedClothes);
                }
                catch
                {
                    ShowErrorMessageBox("Erstellen des Mitarbeiters ist fehlgeschlagen!", "AddEmployeeCommand, UpdateClothes");
                    addEmployeeFormViewModel.HasError = true;
                }
            }
        }

        private static Employee CreateNewEmployee(AddEmployeeFormViewModel addEmployeeFormViewModel)
        {
            Employee newEmployee = new(addEmployeeFormViewModel.Id,
                                       addEmployeeFormViewModel.Lastname,
                                       addEmployeeFormViewModel.Firstname,
                                       addEmployeeFormViewModel.Comment)
            {
                Clothes = []
            };

            foreach (EmployeeClothesSizeListingItemViewModel ecslivm in addEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                EmployeeClothesSize employeeClothesSize = new(Guid.NewGuid(), newEmployee, ecslivm.ClothesSize, ecslivm.Quantity, ecslivm.Comment);
                newEmployee.Clothes.Add(employeeClothesSize);
            }

            return newEmployee;
        }

        private async Task AddEmployeeToDB(Employee newEmployee, AddEmployeeFormViewModel addEmployeeFormViewModel)
        {
            try
            {
                await _employeeStore.Add(newEmployee);
            }
            catch
            {
                ShowErrorMessageBox("Erstellen des Mitarbeiters ist fehlgeschlagen!", "AddEmployeeCommand, UpdateClothesSizes");
                addEmployeeFormViewModel.HasError = true;
            }
        }
    }
}
