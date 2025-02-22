﻿using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Forms;
using DVS.WPF.ViewModels.Views;

namespace DVS.WPF.Commands.AddEditClothesCommands
{
    public class EditClothesCommand(
        EditClothesViewModel editClothesViewModel,
        EmployeeStore employeeStore,
        ClothesStore clothesStore,
        ClothesSizeStore clothesSizeStore,
        EmployeeClothesSizeStore employeeClothesSizesStore,
        ModalNavigationStore modalNavigationStore) 
        : AsyncCommandBase
    {
        public override async Task ExecuteAsync(object parameter)
        {
            EditClothesFormViewModel editClothesFormViewModel = editClothesViewModel.EditClothesFormViewModel;

            if (Confirm($"Soll die Bekleidung  \"{editClothesFormViewModel.Name}\"  und Ihre Schnittstellen bearbeiten werden?", "Bekleidung bearbeiten"))
            {
                editClothesFormViewModel.HasError = false;
                editClothesFormViewModel.IsSubmitting = true;

                Clothes newClothes = CreateClothes(editClothesFormViewModel);
                List<Size> selectedSizes = GetSizes(editClothesFormViewModel);

                if (selectedSizes != null)
                {
                    await DeleteClothesSizesAsync(editClothesFormViewModel);
                    CreateClothesSizes(selectedSizes, newClothes);
                    AddClothesSizeToStore(newClothes);
                }

                await AddClothesToDB(newClothes, editClothesFormViewModel);

                editClothesFormViewModel.IsSubmitting = false;
                modalNavigationStore.Close();
            }
        }

        private static Clothes CreateClothes(EditClothesFormViewModel editClothesFormViewModel)
        {
            return new Clothes(
                editClothesFormViewModel.Id,
                editClothesFormViewModel.Name,
                editClothesFormViewModel.Category,
                editClothesFormViewModel.Season,
                editClothesFormViewModel.Comment)
            {
                Sizes = []
            };
        }

        private static List<Size> GetSizes(EditClothesFormViewModel editClothesFormViewModel)
        {
            return new List<Size>(editClothesFormViewModel.SizesCategoriesSeasonsListingViewModel.LoadedSizesUS.Any(size => size.IsSelected)
                    ? editClothesFormViewModel.SizesCategoriesSeasonsListingViewModel.LoadedSizesUS.Where(size => size.IsSelected)
                    : editClothesFormViewModel.SizesCategoriesSeasonsListingViewModel.LoadedSizesEU.Where(size => size.IsSelected))
                    .ToList();
        }
        
        private async Task DeleteClothesSizesAsync(EditClothesFormViewModel editClothesFormViewModel)
        {
            List<ClothesSize> ClothesSizesToDelete = new(editClothesFormViewModel.Clothes.Sizes);
            foreach (ClothesSize clothesSize in ClothesSizesToDelete)
            {
                try
                {
                    await clothesSizeStore.Delete(clothesSize);
                }
                catch
                {
                    ShowErrorMessageBox("Bearbeiten der Bekleidung ist fehlgeschlagen!", "AddClothesCommand CreateAndAddNewClothesAsync");
                    editClothesFormViewModel.HasError = true;
                }
            }
        }

        private static void CreateClothesSizes(List<Size> selectedSizes, Clothes newClothes)
        {
            foreach (Size size in selectedSizes)
            {
                ClothesSize newClothesSize = new(Guid.NewGuid(), newClothes, size.Name, size.Quantity, "");
                newClothes.Sizes.Add(newClothesSize);
            }
        }

        private async Task AddClothesToDB(Clothes newClothes, EditClothesFormViewModel editClothesFormViewModel)
        {
            try
            {
                await clothesStore.Add(newClothes);
            }
            catch (Exception)
            {
                ShowErrorMessageBox("Bearbeiten der Bekleidung ist fehlgeschlagen!", "AddClothesCommand CreateAndAddNewClothesAsync");
                editClothesFormViewModel.HasError = true;
            }
        }

        private void AddClothesSizeToStore(Clothes newClothes)
        {
            foreach (ClothesSize cs in newClothes.Sizes)
            {
                clothesSizeStore.AddToStore(cs);
            }
        }
    }
}
