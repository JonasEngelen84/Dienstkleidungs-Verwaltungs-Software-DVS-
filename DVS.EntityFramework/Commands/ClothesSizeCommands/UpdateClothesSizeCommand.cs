﻿using DVS.Domain.Commands.ClothesSizeCommands;
using DVS.Domain.Models;

namespace DVS.EntityFramework.Commands.ClothesSizeCommands
{
    public class UpdateClothesSizeCommand(DVSDbContextFactory contextFactory) : IUpdateClothesSizeCommand
    {
        private readonly DVSDbContextFactory _contextFactory = contextFactory;

        public async Task Execute(ClothesSize clothesSize)
        {
            using DVSDbContext context = _contextFactory.Create();

            //ClothesSize clothesSize = new()
            //{
            //    GuidID = clothesSize.GuidID,
            //    ClothesGuidID = clothesSize.ClothesGuidID,
            //    SizeGuidID = clothesSize.SizeGuidID,
            //    Quantity = clothesSize.Quantity,
            //    Comment = clothesSize.Comment,
            //    EmployeeClothesSizes = clothesSize.EmployeeClothesSizes
            //};

            context.ClothesSizes.Update(clothesSize);
            await context.SaveChangesAsync();
        }
    }
}
