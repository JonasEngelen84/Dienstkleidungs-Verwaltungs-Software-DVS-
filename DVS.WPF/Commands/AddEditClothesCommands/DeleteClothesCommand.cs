﻿using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels.ListViewItems;

namespace DVS.WPF.Commands.AddEditClothesCommands
{
    public class DeleteClothesCommand(ClothesListingItemViewModel clothesListingItemViewModel,
                                      SizeStore sizeStore,
                                      ClothesStore clothesStore,
                                      CategoryStore categoryStore,
                                      SeasonStore seasonStore,
                                      ClothesSizeStore clothesSizeStore,
                                      EmployeeClothesSizesStore employeeClothesSizesStore,
                                      EmployeeStore employeeStore)
                                      : AsyncCommandBase
    {
        private readonly ClothesListingItemViewModel _clothesListingItemViewModel = clothesListingItemViewModel;
        private readonly SizeStore sizeStore = sizeStore;
        private readonly ClothesStore _clothesStore = clothesStore;
        private readonly CategoryStore _categoryStore = categoryStore;
        private readonly SeasonStore _seasonStore = seasonStore;
        private readonly ClothesSizeStore clothesSizeStore = clothesSizeStore;
        private readonly EmployeeClothesSizesStore employeeClothesSizesStore = employeeClothesSizesStore;
        private readonly EmployeeStore employeeStore = employeeStore;

        public override async Task ExecuteAsync(object parameter)
        {
            if (Confirm($"Die Bekleidung  \"{_clothesListingItemViewModel.Name}\"  wird gelöscht!" +
                $"\nDie Kleidungsstücke, dieser Bekleidung, bleiben den Mitarbeitern erhalten." +
                $"\n\nLöschen fortsetzen?", "Bekleidung löschen"))
            {
                _clothesListingItemViewModel.HasError = false;
                _clothesListingItemViewModel.IsDeleting = true;

                DeleteClothesSizes();
                await UpdateCategoryAndSeasonAsync();
                await DeleteClothesAsync();

                _clothesListingItemViewModel.IsDeleting = false;
            }
        }

        private void DeleteClothesSizes()
        {
            foreach (ClothesSize size in _clothesListingItemViewModel.Clothes.Sizes)
            {
                size.Size.ClothesSizes.Remove(size);
            }
        }

        private async Task UpdateCategoryAndSeasonAsync()
        {
            _clothesListingItemViewModel.Clothes.Category.Clothes.Remove(_clothesListingItemViewModel.Clothes);
            _clothesListingItemViewModel.Clothes.Season.Clothes.Remove(_clothesListingItemViewModel.Clothes);

            try
            {
                await _categoryStore.Update(_clothesListingItemViewModel.Clothes.Category, null);
                await _seasonStore.Update(_clothesListingItemViewModel.Clothes.Season, null);
            }
            catch (Exception)
            {
                ShowErrorMessageBox("Löschen der Bekleidung ist fehlgeschlagen!", "Bekleidung löschen");

                _clothesListingItemViewModel.HasError = true;
            }
        }

        private async Task DeleteClothesAsync()
        {
            try
            {
                await _clothesStore.Delete(_clothesListingItemViewModel.Clothes);
            }
            catch (Exception)
            {
                ShowErrorMessageBox("Löschen der Bekleidung ist fehlgeschlagen!", "Bekleidung löschen");

                _clothesListingItemViewModel.HasError = true;
            }
        }
    }
}
