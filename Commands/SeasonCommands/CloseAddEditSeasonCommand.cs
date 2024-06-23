﻿using DVS.Stores;
using DVS.ViewModels.Views;

namespace DVS.Commands.SeasonCommands
{
    public class CloseAddEditSeasonCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly CategoryStore _categoryStore;
        private readonly SeasonStore _seasonStore;
        private readonly SelectedCategoryStore _selectedCategoryStore;
        private readonly SelectedSeasonStore _selectedSeasonStore;
        private readonly ClothesStore _clothesStore;

        public CloseAddEditSeasonCommand(ModalNavigationStore modalNavigationStore,
                                         CategoryStore categoryStore,
                                         SeasonStore seasonStore,
                                         SelectedCategoryStore selectedCategoryStore,
                                         SelectedSeasonStore selectedSeasonStore,
                                         ClothesStore clothesStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _categoryStore = categoryStore;
            _seasonStore = seasonStore;
            _selectedCategoryStore = selectedCategoryStore;
            _selectedSeasonStore = selectedSeasonStore;
            _clothesStore = clothesStore;
        }

        public override void Execute(object parameter)
        {
            AddClothesViewModel addClothesViewModel = new(_modalNavigationStore,
                                                          _categoryStore,
                                                          _seasonStore,
                                                          _selectedCategoryStore,
                                                          _selectedSeasonStore,
                                                          _clothesStore);

            _modalNavigationStore.CurrentViewModel = addClothesViewModel;
        }
    }
}
