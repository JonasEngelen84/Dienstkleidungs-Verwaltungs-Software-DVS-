﻿using DVS.Stores;
using DVS.ViewModels.View_ViewModels;

namespace DVS.Commands.AddCategorieViewCommands
{
    public class SubmitAddCategorieCommand(AddEditCategorieViewModel addEditCategorieViewModel, ModalNavigationStore modalNavigationStore) : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore = modalNavigationStore;

        public override void Execute(object parameter) => _modalNavigationStore.Close();
    }
}
