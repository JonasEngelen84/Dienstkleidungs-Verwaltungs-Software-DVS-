﻿using DVS.Stores;
using DVS.ViewModels.Views;

namespace DVS.Commands.DVSDetailedViewCommands
{
    public class OpenAddClothesCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly CategoryStore _categoryStore;
        private readonly SeasonStore _seasonStore;
        private readonly ClothesStore _clothesStore;

        public OpenAddClothesCommand(ModalNavigationStore modalNavigationStore,
                                     CategoryStore categoryStore,
                                     SeasonStore seasonStore,
                                     ClothesStore clothesStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _categoryStore = categoryStore;
            _seasonStore = seasonStore;
            _clothesStore = clothesStore;
        }

        public override void Execute(object parameter)
        {
            AddEditClothesViewModel addEditClothesViewModel = new(_modalNavigationStore,
                                                                  _categoryStore,
                                                                  _seasonStore,
                                                                  _clothesStore);

            addEditClothesViewModel.AddEditClothesFormViewModel.ID = "ID";
            addEditClothesViewModel.AddEditClothesFormViewModel.Name = "Name";
            addEditClothesViewModel.AddEditClothesFormViewModel.Comment = "Kommentar";

            _modalNavigationStore.CurrentViewModel = addEditClothesViewModel;
        }
    }
}
