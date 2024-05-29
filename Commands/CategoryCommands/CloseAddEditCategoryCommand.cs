﻿using DVS.Stores;
using DVS.ViewModels.View_ViewModels;

namespace DVS.Commands.CategoryCommands
{
    public class CloseAddEditCategoryCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly CategoryStore _categoryStore;
        private readonly SeasonStore _seasonStore;
        private readonly SelectedCategoryStore _selectedCategoryStore;
        private readonly SelectedSeasonStore _selectedSeasonStore;

        public CloseAddEditCategoryCommand(ModalNavigationStore modalNavigationStore, CategoryStore categoryStore, SeasonStore seasonStore,
            SelectedCategoryStore selectedCategoryStore, SelectedSeasonStore selectedSeasonStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _categoryStore = categoryStore;
            _seasonStore = seasonStore;
            _selectedCategoryStore = selectedCategoryStore;
            _selectedSeasonStore = selectedSeasonStore;
        }

        public override void Execute(object parameter)
        {
            AddClothesViewModel addClothesViewModel = new(_modalNavigationStore, _categoryStore, _seasonStore, _selectedCategoryStore, _selectedSeasonStore);
            _modalNavigationStore.CurrentViewModel = addClothesViewModel;
        }
    }
}