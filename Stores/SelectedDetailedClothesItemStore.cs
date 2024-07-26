﻿using DVS.Models;

namespace DVS.Stores
{
    public class SelectedDetailedClothesItemStore
    {
        private DetailedClothesListingItemModel _selectedDetailedClothesItem;
        public DetailedClothesListingItemModel SelectedDetailedClothesItem
        {
            get
            {
                return _selectedDetailedClothesItem;
            }
            set
            {
                _selectedDetailedClothesItem = value;
                SelectedDetailedClothesChanged?.Invoke();
            }
        }

        public event Action SelectedDetailedClothesChanged;
    }
}