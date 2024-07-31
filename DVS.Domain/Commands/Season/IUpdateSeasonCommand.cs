﻿using DVS.Domain.Models;

namespace DVS.Domain.Commands.Season
{
    public interface IUpdateSeasonCommand
    {
        Task Execute(SeasonModel season);
    }
}