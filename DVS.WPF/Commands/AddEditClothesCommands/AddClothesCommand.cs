﻿using DVS.Domain.Models;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels;
using DVS.WPF.ViewModels.Forms;
using DVS.WPF.ViewModels.Views;

namespace DVS.WPF.Commands.AddEditClothesCommands
{
    public class AddClothesCommand(AddClothesViewModel addClothesViewModel,
                                   ClothesStore clothesStore,
                                   ModalNavigationStore modalNavigationStore)
                                   : AsyncCommandBase
    {
        private readonly AddClothesViewModel _addClothesViewModel = addClothesViewModel;
        private readonly ClothesStore _clothesStore = clothesStore;
        private readonly ModalNavigationStore _modalNavigationStore = modalNavigationStore;

        public override async Task ExecuteAsync(object parameter)
        {
            AddEditClothesFormViewModel addEditClothesFormViewModel = _addClothesViewModel.AddEditClothesFormViewModel;

            addEditClothesFormViewModel.ErrorMessage = null;
            addEditClothesFormViewModel.IsSubmitting = true;

            ClothesModel clothes = new(Guid.NewGuid(),
                                       addEditClothesFormViewModel.ID,
                                       addEditClothesFormViewModel.Name,
                                       addEditClothesFormViewModel.Category,
                                       addEditClothesFormViewModel.Season,
                                       addEditClothesFormViewModel.Comment);

            // Alle ausgewählten Größen in eine ZwischenListe speichern.
            // Diese wird der GrößenListe (Size) des ClothesModel hinzugefügt.
            var selectedSizes = addEditClothesFormViewModel.AddEditListingViewModel.AvailableSizesUS.Any(size => size.IsSelected)
                ? addEditClothesFormViewModel.AddEditListingViewModel.AvailableSizesUS.Where(size => size.IsSelected)
                : addEditClothesFormViewModel.AddEditListingViewModel.AvailableSizesEU.Where(size => size.IsSelected);

            foreach (ClothesSizeModel sizeModel in selectedSizes)
            {
                clothes.Sizes.Add(sizeModel);
            }

            try
            {
                await _clothesStore.Add(clothes);
            }
            catch (Exception)
            {
                addEditClothesFormViewModel.ErrorMessage =
                    "Erstellen der Bekleidung ist fehlgeschlagen!\nBitte versuchen Sie es erneut.";
            }
            finally
            {
                addEditClothesFormViewModel.IsSubmitting = false;
                _modalNavigationStore.Close();
            }
        }
    }
}