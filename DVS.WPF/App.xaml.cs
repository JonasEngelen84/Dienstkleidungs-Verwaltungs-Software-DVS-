﻿using DVS.Domain.Commands.Category;
using DVS.Domain.Commands.Clothes;
using DVS.Domain.Commands.Employee;
using DVS.Domain.Commands.Season;
using DVS.Domain.Queries;
using DVS.EntityFramework;
using DVS.EntityFramework.Commands.Category;
using DVS.EntityFramework.Commands.Clothes;
using DVS.EntityFramework.Commands.Employee;
using DVS.EntityFramework.Commands.Season;
using DVS.EntityFramework.Queries;
using DVS.WPF.Stores;
using DVS.WPF.ViewModels;
using DVS.WPF.ViewModels.Views;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DVS.WPF
{
    public partial class App : Application
    {
        private readonly CategoryStore _categoryStore;
        private readonly SeasonStore _seasonStore;
        private readonly ClothesStore _clothesStore;
        private readonly EmployeeStore _employeeStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly DVSListingViewModel _dVSListingViewModel;
        private readonly DVSDetailedViewModel _dVSDetailedViewModel;
        private readonly DVSHeadViewModel _dVSHeadViewModel;
        private readonly SelectedDetailedClothesItemStore _selectedDetailedClothesItemStore;
        private readonly SelectedDetailedEmployeeClothesItemStore _selectedDetailedEmployeeClothesItemStore;

        private readonly DVSDbContextFactory _dVSDbContextFactory;

        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;
        private readonly ICreateCategoryCommand _createCategoryCommand;
        private readonly IUpdateCategoryCommand _updateCategoryCommand;
        private readonly IDeleteCategoryCommand _deleteCategoryCommand;
        private readonly IClearCategoriesCommand _clearCategoriesCommand;

        private readonly IGetAllSeasonsQuery _getAllSeasonsQuery;
        private readonly ICreateSeasonCommand _createSeasonCommand;
        private readonly IUpdateSeasonCommand _updateSeasonCommand;
        private readonly IDeleteSeasonCommand _deleteSeasonsCommand;

        private readonly IGetAllClothesQuery _getAllClothesQuery;
        private readonly ICreateClothesCommand _createClothesCommand;
        private readonly IUpdateClothesCommand _updateClothesCommand;
        private readonly IDeleteClothesCommand _deleteClothesCommand;

        private readonly IGetAllEmployeesQuery _getAllEmployeesQuery;
        private readonly ICreateEmployeeCommand _createEmployeeCommand;
        private readonly IUpdateEmployeeCommand _updateEmployeeCommand;
        private readonly IDeleteEmployeeCommand _deleteEmployeeCommand;


        public App()
        {
            string connectionString = "Data Source=DVS.db";
            _dVSDbContextFactory = new(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            _getAllCategoriesQuery = new GetAllCategoriesQuery(_dVSDbContextFactory);
            _createCategoryCommand = new CreateCategoryCommand(_dVSDbContextFactory);
            _updateCategoryCommand = new UpdateCategoryCommand(_dVSDbContextFactory);
            _deleteCategoryCommand = new DeleteCategoryCommand(_dVSDbContextFactory);
            _clearCategoriesCommand = new ClearCategoriesCommand(_dVSDbContextFactory);

            _getAllSeasonsQuery = new GetAllSeasonsQuery(_dVSDbContextFactory);
            _createSeasonCommand = new CreateSeasonCommand(_dVSDbContextFactory);
            _updateSeasonCommand = new UpdateSeasonCommand(_dVSDbContextFactory);
            _deleteSeasonsCommand = new DeleteSeasonCommand(_dVSDbContextFactory);

            _getAllClothesQuery = new GetAllClothesQuery(_dVSDbContextFactory);
            _createClothesCommand = new CreateClothesCommand(_dVSDbContextFactory);
            _updateClothesCommand = new UpdateClothesCommand(_dVSDbContextFactory);
            _deleteClothesCommand = new DeleteClothesCommand(_dVSDbContextFactory);

            _getAllEmployeesQuery = new GetAllEmployeesQuery(_dVSDbContextFactory);
            _createEmployeeCommand = new CreateEmployeeCommand(_dVSDbContextFactory);
            _updateEmployeeCommand = new UpdateEmployeeCommand(_dVSDbContextFactory);
            _deleteEmployeeCommand = new DeleteEmployeeCommand(_dVSDbContextFactory);

            _categoryStore = new(_getAllCategoriesQuery, _createCategoryCommand, _updateCategoryCommand, _deleteCategoryCommand);
            _seasonStore = new(_getAllSeasonsQuery, _createSeasonCommand, _updateSeasonCommand, _deleteSeasonsCommand);
            _clothesStore = new(_getAllClothesQuery, _createClothesCommand, _updateClothesCommand, _deleteClothesCommand);
            _employeeStore = new(_getAllEmployeesQuery, _createEmployeeCommand, _updateEmployeeCommand, _deleteEmployeeCommand);
            _modalNavigationStore = new();
            _selectedDetailedClothesItemStore = new();
            _selectedDetailedEmployeeClothesItemStore = new();

            _dVSListingViewModel = new(_clothesStore,
                                       _employeeStore,
                                       _modalNavigationStore,
                                       _categoryStore,
                                       _seasonStore,
                                       _selectedDetailedClothesItemStore,
                                       _selectedDetailedEmployeeClothesItemStore);

            _dVSDetailedViewModel = new(_dVSListingViewModel,
                                        _modalNavigationStore,
                                        _categoryStore,
                                        _seasonStore,
                                        _clothesStore,
                                        _employeeStore,
                                        _selectedDetailedClothesItemStore,
                                        _selectedDetailedEmployeeClothesItemStore);

            _dVSHeadViewModel = new(_dVSListingViewModel,
                                    _modalNavigationStore,
                                    _categoryStore,
                                    _seasonStore,
                                    _clothesStore,
                                    _employeeStore);
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_dVSHeadViewModel,
                                                _dVSDetailedViewModel,
                                                _modalNavigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
