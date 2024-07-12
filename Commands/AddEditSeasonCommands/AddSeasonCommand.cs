﻿using DVS.Models;
using DVS.Stores;
using DVS.ViewModels.Forms;
using DVS.ViewModels.Views;

namespace DVS.Commands.AddEditSeasonCommands
{
    public class AddSeasonCommand(AddEditSeasonViewModel addEditSeasonViewModel,
                                  SeasonStore seasonStore)
                                  : CommandBase
    {
        private readonly AddEditSeasonViewModel _addEditSeasonViewModel = addEditSeasonViewModel;
        private readonly SeasonStore _seasonStore = seasonStore;

        public override async void Execute(object parameter)
        {
            AddEditSeasonFormViewModel addEditSeasonFormViewModel = addEditSeasonViewModel.AddEditSeasonFormViewModel;
            addEditSeasonFormViewModel.ErrorMessage = null;
            addEditSeasonFormViewModel.IsSubmitting = true;

            SeasonModel newSeason = new(Guid.NewGuid(), addEditSeasonFormViewModel.AddNewSeason);

            try
            {
                await seasonStore.Add(newSeason);
            }
            catch (Exception)
            {
                addEditSeasonFormViewModel.ErrorMessage = "Erstellen der Saison ist fehlgeschlagen!\nBitte versuchen Sie es erneut.";
            }
            finally
            {
                addEditSeasonFormViewModel.IsSubmitting = false;
            }
        }
    }
}
