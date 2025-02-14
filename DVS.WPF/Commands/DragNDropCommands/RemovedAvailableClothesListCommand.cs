﻿using DVS.WPF.ViewModels;

namespace DVS.WPF.Commands.DragNDropCommands
{
    public class RemovedAvailableClothesListCommand(AddEditEmployeeListingViewModel addEditEmployeeListingViewModel,
                                                    Action<Guid> addItemToEditedClothesList,
                                                    Action<Guid> removeItemFromEditedClothesList)
                                                    : CommandBase
    {
        private readonly AddEditEmployeeListingViewModel _addEditEmployeeListingViewModel = addEditEmployeeListingViewModel;

        public readonly Action<Guid> _addItemToEditedClothesList = addItemToEditedClothesList;
        public readonly Action<Guid> _removeItemFromEditedClothesList = removeItemFromEditedClothesList;

        public override void Execute(object parameter)
        {
            CheckQuantity();

            if (_addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity > 0)
            {
                _addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity -= 1;

                UpdateEditedClothesList();
            }
            else
                ShowErrorMessageBox("Diese Bekleidung ist zur Zeit nicht vorrätig!", "Bekleidung nicht vorhanden");
        }

        private void CheckQuantity()
        {
            switch (_addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.Quantity)
            {
                case 1:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung nicht mehr vorrätig!", "Letztes Bekleidungsstück");
                    break;

                case 2:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung noch  1  mal vorrätig!", "Sehr geringer Bestand");
                    break;

                case 3:
                    ShowErrorMessageBox("Nach der Transaktion ist diese Bekleidung noch  2  mal vorrätig!", "geringer Bestand");
                    break;

                default:
                    break;
            }
        }

        private void UpdateEditedClothesList()
        {
            Guid? existingClothesSize = _addEditEmployeeListingViewModel.GetClothesSizeFrom_editedClothesList();

            if (existingClothesSize == null)
            {
                addItemToEditedClothesList.Invoke(_addEditEmployeeListingViewModel.SelectedAvailableClothesSizeItem.ClothesSize.GuidId);
            }
        }
    }
}
