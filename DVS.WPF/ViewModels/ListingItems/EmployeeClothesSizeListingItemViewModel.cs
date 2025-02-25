﻿using DVS.Domain.Models;

namespace DVS.WPF.ViewModels.ListingItems
{
    public class EmployeeClothesSizeListingItemViewModel(ClothesSize clothesSize) : ViewModelBase
    {
        public ClothesSize ClothesSize { get; } = clothesSize;
        public string ClothesId => ClothesSize.Clothes.Id;
        public string ClothesName => ClothesSize.Clothes.Name;
        public string Size => ClothesSize.Size;

        private string _comment = "";
        public string Comment
        {
            get { return _comment; }

            set
            {
                if (_comment != value)
                    _comment = value;
                
                OnPropertyChanged(nameof(Comment));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }

            set
            {
                if (_quantity != value)
                    _quantity = value;
                
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }
}
