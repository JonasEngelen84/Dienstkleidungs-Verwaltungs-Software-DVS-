﻿using DVS.Domain.Commands.Season;
using DVS.Domain.Models;
using DVS.EntityFramework.DTOs;

namespace DVS.EntityFramework.Commands.Season
{
    public class CreateSeasonCommand(DVSDbContextFactory dVSDbContextFactory) : ICreateSeasonCommand
    {
        private readonly DVSDbContextFactory _dVSDbContextFactory = dVSDbContextFactory;

        public async Task Execute(SeasonModel season)
        {
            using DVSDbContext context = _dVSDbContextFactory.Create();

            SeasonDTO seasonDTO = new()
            {
                GuidID = season.GuidID,
                Name = season.Name,
            };

            context.Seasons.Add(seasonDTO);
            await context.SaveChangesAsync();
        }
    }
}
