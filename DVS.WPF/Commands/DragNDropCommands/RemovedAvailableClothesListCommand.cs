﻿using DVS.Domain.Models;
using DVS.WPF.ViewModels;

namespace DVS.WPF.Commands.DragNDropCommands
{
    public class RemovedAvailableClothesListCommand(
        AddEditEmployeeListingViewModel addEditEmployeeListingViewModel,
        Action<AvailableClothesSizeItem> addItemToEditedClothesSizesList,
        Action<AvailableClothesSizeItem> removeItemFromEditedClothesSizesList,
        Action<Clothes> addItemToEditedClothesList,
        Action<Clothes> removeItemFromEditedClothesList)
        : CommandBase
    {
        public override void Execute(object parameter)
        {
            switch (addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity)
            {
                case 0:
                    ShowErrorMessageBox("Diese Bekleidung ist zur Zeit nicht vorrätig!", "Bekleidung nicht vorhanden");
                    break;

                case 1:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung nicht mehr vorrätig!", "Letztes Bekleidungsstück");
                    addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity -= 1;
                    UpdateEditedList();
                    break;

                case 2:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung noch  1  mal vorrätig!", "Sehr geringer Bestand");
                    addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity -= 1;
                    UpdateEditedList();
                    break;

                case 3:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung noch  2  mal vorrätig!", "geringer Bestand");
                    addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity -= 1;
                    UpdateEditedList();
                    break;

                default:
                    addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity -= 1;
                    UpdateEditedList();
                    break;
            }
        }

        private void UpdateEditedList()
        {
            AvailableClothesSizeItem? existingAcsi = addEditEmployeeListingViewModel.GetClothesSizeFrom_editedClothesSizesList();
            if (existingAcsi == null)
                addItemToEditedClothesSizesList.Invoke(addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem);

            Clothes? existingClothes = addEditEmployeeListingViewModel.GetClothesFrom_editedClothesList();
            if (existingClothes == null)
                addItemToEditedClothesList.Invoke(addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.ClothesSize.Clothes);
        }
    }
}
