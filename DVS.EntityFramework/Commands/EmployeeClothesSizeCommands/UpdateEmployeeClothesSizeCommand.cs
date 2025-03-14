﻿using DVS.Domain.Commands.EmployeeClothesSizeCommands;
using DVS.Domain.Models;

namespace DVS.EntityFramework.Commands.EmployeeClothesSizeCommands
{
    public class UpdateEmployeeClothesSizeCommand(DVSDbContextFactory contextFactory) : IUpdateEmployeeClothesSizeCommand
    {
        private readonly DVSDbContextFactory _contextFactory = contextFactory;

        public async Task Execute(EmployeeClothesSize editedEcs)
        {
            using DVSDbContext context = _contextFactory.Create();

            var existingEcs = await context.EmployeeClothesSizes.FindAsync(editedEcs.GuidId);

            if (existingEcs != null)
                context.Entry(existingEcs).CurrentValues.SetValues(editedEcs);
            else
            {
                Employee? existingEmployee = await context.Employees.FindAsync(editedEcs.EmployeeId);
                ClothesSize? existingClothesSize = await context.ClothesSizes.FindAsync(editedEcs.ClothesSizeGuidId);

                EmployeeClothesSize newEmployeeClothesSize = new(
                    editedEcs.GuidId,
                    existingEmployee,
                    existingClothesSize,
                    editedEcs.Quantity,
                    editedEcs.Comment);

                context.EmployeeClothesSizes.Add(newEmployeeClothesSize);
            }

            await context.SaveChangesAsync();
        }
    }
}
