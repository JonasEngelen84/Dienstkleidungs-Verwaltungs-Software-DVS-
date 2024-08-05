﻿using DVS.Domain.Models;
using DVS.Domain.Queries;
using DVS.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DVS.EntityFramework.Queries
{
    public class GetAllEmployeesQuery(DVSDbContextFactory dVSDbContextFactory) : IGetAllEmployeesQuery
    {
        private readonly DVSDbContextFactory _dVSDbContextFactory = dVSDbContextFactory;

        public async Task<IEnumerable<EmployeeModel>> Execute()
        {
            using DVSDbContext context = _dVSDbContextFactory.Create();

            IEnumerable<EmployeeDTO> employeeDTOs = await context.Employees.ToListAsync();

            return employeeDTOs.Select(y => new EmployeeModel(y.GuidID, y.ID, y.Lastname, y.Firstname, y.Comment) { Clothes = y.Clothes } );
        }
    }
}
