﻿using DVS.WPF.Stores;
using DVS.WPF.ViewModels.Views;

namespace DVS.WPF.Commands.AddEditSeasonCommands
{
    public class CloseAddEditSeasonCommand(ModalNavigationStore modalNavigationStore,
        AddClothesViewModel addClothesViewModel, EditClothesViewModel editClothesViewModel) : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore = modalNavigationStore;
        private readonly AddClothesViewModel _addClothesViewModel = addClothesViewModel;
        private readonly EditClothesViewModel _editClothesViewModel = editClothesViewModel;

        public override void Execute(object parameter)
        {
            _modalNavigationStore.CurrentViewModel =
                _addClothesViewModel != null ? _addClothesViewModel : _editClothesViewModel;
        }
    }
}
