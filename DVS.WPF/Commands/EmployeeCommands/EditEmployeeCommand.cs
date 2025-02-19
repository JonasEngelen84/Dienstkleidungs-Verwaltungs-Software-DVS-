﻿using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Forms;
using DVS.WPF.ViewModels.Views;
using System.Collections.ObjectModel;

namespace DVS.WPF.Commands.AddEditEmployeeCommands
{
    public class EditEmployeeCommand(
        EditEmployeeViewModel editEmployeeViewModel,
        EmployeeStore employeeStore,
        ClothesStore clothesStore,
        CategoryStore categoryStore,
        SeasonStore seasonStore,
        ClothesSizeStore clothesSizeStore,
        EmployeeClothesSizeStore employeeClothesSizesStore,
        ModalNavigationStore modalNavigationStore)
        : AsyncCommandBase
    {
        public override async Task ExecuteAsync(object parameter)
        {
            AddEditEmployeeFormViewModel editEmployeeFormViewModel = editEmployeeViewModel.AddEditEmployeeFormViewModel;
            
            if (Confirm($"Soll der/die Mitarbeiter/in  \"{editEmployeeFormViewModel.Lastname}\", \"{editEmployeeFormViewModel.Firstname}\"  bearbeiten werden?", "Mitarbeiter bearbeiten"))
            {
                editEmployeeFormViewModel.HasError = false;
                editEmployeeFormViewModel.IsSubmitting = true;

                Employee updatedEmployee = CreateUpdatedEmployee(editEmployeeFormViewModel);

                await DeleteRemovedEmployeeClothesSizesAsync(updatedEmployee, editEmployeeFormViewModel);
                await CreateAndAddNewEmployeeClothesSizesAsync(updatedEmployee, editEmployeeFormViewModel);
                await UpdateEmployeeClothesSizesAsync(updatedEmployee, editEmployeeFormViewModel);
                await UpdateEmployeeAsync(updatedEmployee, editEmployeeFormViewModel);
                await UpdateClothesSizeAsync(editEmployeeFormViewModel);
                await UpdateClothesAsync(editEmployeeFormViewModel);
                await UpdateCategoryAsync(editEmployeeFormViewModel);
                await UpdateSeasonAsync(editEmployeeFormViewModel);

                editEmployeeFormViewModel.IsSubmitting = false;

                modalNavigationStore.Close();
            }
        }

        private static Employee CreateUpdatedEmployee(AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            return new Employee(editEmployeeFormViewModel.Id,
                                editEmployeeFormViewModel.Lastname,
                                editEmployeeFormViewModel.Firstname,
                                editEmployeeFormViewModel.Comment)
            {
                Clothes = new ObservableCollection<EmployeeClothesSize>(editEmployeeFormViewModel.Employee.Clothes)
            };
        }

        private async Task DeleteRemovedEmployeeClothesSizesAsync(Employee updatedEmployee, AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            foreach (EmployeeClothesSize ecs in updatedEmployee.Clothes)
            {
                AvailableClothesSizeItem existingItem = editEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList
                    .FirstOrDefault(acsi => acsi.ClothesSize.GuidId == ecs.ClothesSizeGuidId);

                if (existingItem == null)
                {
                    updatedEmployee.Clothes.Remove(ecs);
                    ecs.ClothesSize.EmployeeClothesSizes.Remove(ecs);

                    try
                    {
                        await employeeClothesSizesStore.Delete(ecs);
                    }
                    catch (Exception)
                    {
                        ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                        editEmployeeFormViewModel.HasError = true;
                    }
                }
            }
        }

        private async Task CreateAndAddNewEmployeeClothesSizesAsync(Employee updatedEmployee, AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in editEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                EmployeeClothesSize? existingEcsi = updatedEmployee.Clothes.FirstOrDefault(ecs => ecs.ClothesSizeGuidId == acsi.ClothesSize.GuidId);

                if (existingEcsi == null)
                {
                    EmployeeClothesSize employeeClothesSize = new(Guid.NewGuid(), updatedEmployee, acsi.ClothesSize, (int)acsi.Quantity, null);

                    updatedEmployee.Clothes.Add(employeeClothesSize);
                    //dclivm.ClothesSize.EmployeeClothesSizes.Add(employeeClothesSize);

                    try
                    {
                        await employeeClothesSizesStore.Add(employeeClothesSize);
                    }
                    catch (Exception)
                    {
                        ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                        editEmployeeFormViewModel.HasError = true;
                    }
                }
            }
        }

        private async Task UpdateEmployeeClothesSizesAsync(Employee updatedEmployee, AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in editEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                EmployeeClothesSize? existingEcsi = updatedEmployee.Clothes.FirstOrDefault(ecs => ecs.ClothesSizeGuidId == acsi.ClothesSize.GuidId);

                if (existingEcsi != null)
                {
                    EmployeeClothesSize UpdatedEmployeeClothesSize = new(existingEcsi.GuidId, updatedEmployee, acsi.ClothesSize, (int)acsi.Quantity, null);

                    EmployeeClothesSize itemToRemove = updatedEmployee.Clothes.FirstOrDefault(ecs => ecs.GuidId == UpdatedEmployeeClothesSize.GuidId);

                    if (itemToRemove != null)
                    {
                        updatedEmployee.Clothes.Remove(itemToRemove);
                        updatedEmployee.Clothes.Add(UpdatedEmployeeClothesSize);
                    }


                    itemToRemove = UpdatedEmployeeClothesSize.ClothesSize.EmployeeClothesSizes.FirstOrDefault(ecs => ecs.GuidId == UpdatedEmployeeClothesSize.GuidId);

                    if (itemToRemove != null)
                    {
                        UpdatedEmployeeClothesSize.ClothesSize.EmployeeClothesSizes.Remove(itemToRemove);
                        UpdatedEmployeeClothesSize.ClothesSize.EmployeeClothesSizes.Add(UpdatedEmployeeClothesSize);
                    }


                    try
                    {
                        await employeeClothesSizesStore.Update(UpdatedEmployeeClothesSize);
                    }
                    catch (Exception)
                    {
                        ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                        editEmployeeFormViewModel.HasError = true;
                    }
                }
            }
        }

        private async Task UpdateEmployeeAsync(Employee updatedEmployee, AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            try
            {
                await employeeStore.Update(updatedEmployee);
            }
            catch (Exception)
            {
                ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                editEmployeeFormViewModel.HasError = true;
            }
        }

        private async Task UpdateClothesSizeAsync(AddEditEmployeeFormViewModel editEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in editEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                ClothesSize? csToRemove = acsi.ClothesSize.Clothes.Sizes.FirstOrDefault(cs => cs.GuidId == acsi.ClothesSize.GuidId);

                if (csToRemove != null)
                {
                    acsi.ClothesSize.Clothes.Sizes.Remove(csToRemove);
                    acsi.ClothesSize.Clothes.Sizes.Add(acsi.ClothesSize);
                }

                try
                {
                    await clothesSizeStore.Update(acsi.ClothesSize);
                }
                catch (Exception)
                {
                    ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                    editEmployeeFormViewModel.HasError = true;
                }
            }
        }

        private async Task UpdateClothesAsync(AddEditEmployeeFormViewModel addEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in addEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                var itemToRemove = acsi.ClothesSize.Clothes.Category.Clothes.FirstOrDefault(c => c.Id == acsi.ClothesSize.Clothes.Id);

                if (itemToRemove != null)
                {
                    acsi.ClothesSize.Clothes.Category.Clothes.Remove(itemToRemove);
                    acsi.ClothesSize.Clothes.Category.Clothes.Add(acsi.ClothesSize.Clothes);
                }

                itemToRemove = acsi.ClothesSize.Clothes.Season.Clothes.FirstOrDefault(c => c.Id == acsi.ClothesSize.Clothes.Id);

                if (itemToRemove != null)
                {
                    acsi.ClothesSize.Clothes.Season.Clothes.Remove(itemToRemove);
                    acsi.ClothesSize.Clothes.Season.Clothes.Add(acsi.ClothesSize.Clothes);
                }

                try
                {
                    await clothesStore.Update(acsi.ClothesSize.Clothes);
                }
                catch (Exception)
                {
                    ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                    addEmployeeFormViewModel.HasError = true;
                }
            }
        }

        private async Task UpdateCategoryAsync(AddEditEmployeeFormViewModel addEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in addEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                try
                {
                    await categoryStore.Update(acsi.ClothesSize.Clothes.Category, null);
                }
                catch (Exception)
                {
                    ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                    addEmployeeFormViewModel.HasError = true;
                }
            }
        }

        private async Task UpdateSeasonAsync(AddEditEmployeeFormViewModel addEmployeeFormViewModel)
        {
            foreach (AvailableClothesSizeItem acsi in addEmployeeFormViewModel.AddEditEmployeeListingViewModel.EmployeeClothesList)
            {
                try
                {
                    await seasonStore.Update(acsi.ClothesSize.Clothes.Season, null);
                }
                catch (Exception)
                {
                    ShowErrorMessageBox("Bearbeiten des Mitarbeiters ist fehlgeschlagen!\nBitte versuchen Sie es erneut.", "Mitarbeiter bearbeiten");
                    addEmployeeFormViewModel.HasError = true;
                }
                finally
                {
                    addEmployeeFormViewModel.IsSubmitting = false;
                }
            }
        }
    }
}
