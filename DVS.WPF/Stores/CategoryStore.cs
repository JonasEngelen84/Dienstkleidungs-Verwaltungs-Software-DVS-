﻿using DVS.Domain.Commands.CategoryCommands;
using DVS.Domain.Models;
using DVS.WPF.ViewModels.Forms;

namespace DVS.WPF.Stores
{
    public class CategoryStore(ICreateCategoryCommand createCategoryCommand,
                               IUpdateCategoryCommand updateCategoryCommand,
                               IDeleteCategoryCommand deleteCategoryCommand)
    {
        public Category Categoryless { get; }

        private readonly List<Category> _categories = [];
        public IEnumerable<Category> Categories => _categories;

        public event Action<Category, AddEditCategoryFormViewModel> CategoryAdded;
        public event Action<Category, AddEditCategoryFormViewModel> CategoryUpdated;
        public event Action<Guid, AddEditCategoryFormViewModel> CategoryDeleted;
        public event Action<AddEditCategoryFormViewModel> AllCategoriesDeleted;


        public void Load(List<Category> categorie)
        {
            _categories.Clear();

            if (categorie != null)
            {
                _categories.AddRange(categorie);
            }
        }

        public async Task Add(Category category, AddEditCategoryFormViewModel addEditCategoryFormViewModel)
        {
            await createCategoryCommand.Execute(category);

            _categories.Add(category);

            CategoryAdded.Invoke(category, addEditCategoryFormViewModel);
        }

        public async Task Update(Category updatedCategory, AddEditCategoryFormViewModel? addEditCategoryFormViewModel)
        {
            await updateCategoryCommand.Execute(updatedCategory);

            int index = _categories.FindIndex(y => y.GuidId == updatedCategory.GuidId);

            if (index > -1)
            {
                _categories[index] = updatedCategory;
                CategoryUpdated.Invoke(updatedCategory, addEditCategoryFormViewModel != null ? addEditCategoryFormViewModel : null);
            }
            else
            {
                throw new InvalidOperationException("Umbenennen der Kategorie nicht möglich.");
            }
        }

        public async Task Delete(Category category, AddEditCategoryFormViewModel addEditCategoryFormViewModel)
        {
            await deleteCategoryCommand.Execute(category);

            int index = _categories.FindIndex(y => y.GuidId == category.GuidId);

            if (index > -1)
            {
                _categories.RemoveAll(y => y.GuidId == category.GuidId);
                CategoryDeleted.Invoke(category.GuidId, addEditCategoryFormViewModel);
            }
            else
            {
                throw new InvalidOperationException("Löschen der Kategorie nicht möglich.");
            }            
        }
    }
}
