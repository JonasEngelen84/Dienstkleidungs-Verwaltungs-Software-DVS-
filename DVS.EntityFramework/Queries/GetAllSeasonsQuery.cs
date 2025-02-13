﻿using DVS.Domain.Models;
using DVS.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace DVS.EntityFramework.Queries
{
    public class GetAllSeasonsQuery(DVSDbContextFactory dVSDbContextFactory) : IGetAllSeasonsQuery
    {
        private readonly DVSDbContextFactory _dVSDbContextFactory = dVSDbContextFactory;

        public async Task<IEnumerable<Season>> Execute()
        {
            using DVSDbContext context = _dVSDbContextFactory.Create();
            return await context.Seasons.ToListAsync();
        }
    }
}
