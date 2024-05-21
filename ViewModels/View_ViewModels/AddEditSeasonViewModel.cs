﻿using DVS.Commands.AddSeasonViewCommands;
using DVS.Stores;
using DVS.ViewModels.Forms;
using System.Windows.Input;

namespace DVS.ViewModels.View_ViewModels
{
    public class AddEditSeasonViewModel : ViewModelBase
    {
        public AddEditSeasonFormViewModel AddEditSeasonFormViewModel { get; }

        public AddEditSeasonViewModel(ModalNavigationStore _modalNavigationStore)
        {
            ICommand submitAddSeasonCommand = new SubmitAddSeasonCommand(this, _modalNavigationStore);
            ICommand editSeasonCommand = new EditSeasonCommand(this, _modalNavigationStore);
            ICommand deleteSeasonCommand = new DeleteSeasonCommand(this, _modalNavigationStore);
            ICommand clearSeasonListCommand = new ClearSeasonListCommand(this, _modalNavigationStore);
            ICommand closeAddSeasonCommand = new CloseAddSeasonCommand(_modalNavigationStore);

            AddEditSeasonFormViewModel = new AddEditSeasonFormViewModel(submitAddSeasonCommand,
                editSeasonCommand, deleteSeasonCommand, clearSeasonListCommand, closeAddSeasonCommand);
        }
    }
}
