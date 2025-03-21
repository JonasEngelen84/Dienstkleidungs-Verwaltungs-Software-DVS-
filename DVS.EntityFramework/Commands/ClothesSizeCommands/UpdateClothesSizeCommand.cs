﻿using DVS.Domain.Commands.ClothesSizeCommands;
using DVS.Domain.Models;

namespace DVS.EntityFramework.Commands.ClothesSizeCommands
{
    public class UpdateClothesSizeCommand(DVSDbContextFactory contextFactory) : IUpdateClothesSizeCommand
    {
        private readonly DVSDbContextFactory _contextFactory = contextFactory;

        public async Task Execute(ClothesSize editedClothesSize)
        {
            using DVSDbContext context = _contextFactory.Create();

            var existingClothesSize = await context.ClothesSizes.FindAsync(editedClothesSize.Id);

            if (existingClothesSize != null)
            {
                context.Entry(existingClothesSize).CurrentValues.SetValues(editedClothesSize);
            }

        }
    }
}
