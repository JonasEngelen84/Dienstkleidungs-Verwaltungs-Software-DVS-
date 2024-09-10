﻿using DVS.Domain.Models;
using DVS.Domain.Queries;
using DVS.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace DVS.EntityFramework.Queries
{
    public class GetAllEmployeeClothesSizesQuery(DVSDbContextFactory dVSDbContextFactory) : IGetAllEmployeeClothesSizesQuery
    {
        private readonly DVSDbContextFactory _dVSDbContextFactory = dVSDbContextFactory;

        public async Task<IEnumerable<EmployeeClothesSize>> Execute()
        {
            using DVSDbContext context = _dVSDbContextFactory.Create();

            IEnumerable<EmployeeClothesSizeDTO> employeeClothesSizeDTOs = await context.EmployeeClothesSizes.ToListAsync();

            List<EmployeeClothesSize> employeeClothesSizeList = [];

            foreach (var employeeClothesSizeDTO in employeeClothesSizeDTOs)
            {
                EmployeeDTO? employeeDTO = await context.Employees.FindAsync(employeeClothesSizeDTO.EmployeeGuidID);
                ClothesSizeDTO? clothesSizeDTO = await context.ClothesSizes.FindAsync(employeeClothesSizeDTO.ClothesSizeGuidID);
                SizeModelDTO? sizeDTO = await context.Sizes.FindAsync(clothesSizeDTO?.SizeGuidID);
                ClothesDTO? clothesDTO = await context.Clothes.FindAsync(clothesSizeDTO?.ClothesGuidID);
                CategoryDTO? categoryDTO = await context.Categories.FindAsync(clothesDTO?.CategoryGuidID);
                SeasonDTO? seasonDTO = await context.Seasons.FindAsync(clothesDTO?.SeasonGuidID);

                SizeModel size = CreateSize(sizeDTO);
                Category category = CreateCategory(categoryDTO);
                Season season = CreateSeason(seasonDTO);
                Clothes clothes = CreateClothes(clothesDTO, category, season);
                ClothesSize clothesSize = CreateClothesSize(clothesSizeDTO, clothes, size);
                Employee employee = CreateEmployee(employeeDTO);
                EmployeeClothesSize employeeClothesSize = CreateEmployeeClothesSize(employeeClothesSizeDTO, employee, clothesSize);

                employeeClothesSizeList.Add(employeeClothesSize);
            }

            return employeeClothesSizeList;
        }

        private SizeModel CreateSize(SizeModelDTO sizeDTO)
        {
            return new SizeModel(sizeDTO.GuidID, sizeDTO.Size, sizeDTO.IsSizeSystemEU)
            {
                ClothesSizes = new ObservableCollection<ClothesSize>(sizeDTO.ClothesSizes)
            };
        }

        private Category CreateCategory(CategoryDTO categoryDTO)
        {
            return new Category(categoryDTO.GuidID, categoryDTO.Name)
            {
                Clothes = new ObservableCollection<Clothes>(categoryDTO.Clothes)
            };
        }

        private Season CreateSeason(SeasonDTO seasonDTO)
        {
            return new Season(seasonDTO.GuidID, seasonDTO.Name)
            {
                Clothes = new ObservableCollection<Clothes>(seasonDTO.Clothes)
            };
        }

        private Clothes CreateClothes(ClothesDTO clothesDTO, Category category, Season season)
        {
            return new Clothes(clothesDTO.GuidID,
                               clothesDTO.ID,
                               clothesDTO.Name,
                               category,
                               season,
                               clothesDTO.Comment)
            {
                Sizes = new ObservableCollection<ClothesSize>(clothesDTO.Sizes)
            };
        }

        private ClothesSize CreateClothesSize(ClothesSizeDTO clothesSizeDTO, Clothes clothes, SizeModel size)
        {
            return new ClothesSize(clothesSizeDTO.GuidID,
                                   clothes,
                                   size,
                                   clothesSizeDTO.Quantity,
                                   clothesSizeDTO.Comment)
            {
                EmployeeClothesSizes = new ObservableCollection<EmployeeClothesSize>(clothesSizeDTO.EmployeeClothesSizes)
            };
        }

        private Employee CreateEmployee(EmployeeDTO employeeDTO)
        {
            return new Employee(employeeDTO.GuidID,
                                employeeDTO.ID,
                                employeeDTO.Lastname,
                                employeeDTO.Firstname,
                                employeeDTO.Comment)
            {
                Clothes = new ObservableCollection<EmployeeClothesSize>(employeeDTO.Clothes)
            };
        }

        private EmployeeClothesSize CreateEmployeeClothesSize(EmployeeClothesSizeDTO employeeClothesSizeDTO, Employee employee, ClothesSize clothesSize)
        {      
            return new EmployeeClothesSize(employeeClothesSizeDTO.GuidID,
                                           employee,
                                           clothesSize,
                                           employeeClothesSizeDTO.Quantity,
                                           employeeClothesSizeDTO.Comment);
        }
    }
}
