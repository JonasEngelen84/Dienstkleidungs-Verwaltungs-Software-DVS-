﻿using DVS.Stores;

namespace DVS.Commands.DVSViewCommands
{
    public class MinusCommand : CommandBase
    {
        private readonly SelectedClothesStore _selectedClothesStore;
        private readonly SelectedEmployeeClothesStore _selectedEmployeeClothesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public MinusCommand(SelectedClothesStore selectedClothesStore, SelectedEmployeeClothesStore selectedEmployeeClothesStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedClothesStore = selectedClothesStore;
            _selectedEmployeeClothesStore = selectedEmployeeClothesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
