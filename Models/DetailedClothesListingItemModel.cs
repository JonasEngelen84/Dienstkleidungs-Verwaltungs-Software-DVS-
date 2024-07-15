﻿namespace DVS.Models
{
    public class DetailedClothesListingItemModel : ModelBase
    {
        public ClothesModel Clothes {  get; private set; }
        public string ID => Clothes.ID;
        public string Name => Clothes.Name;
        public string Category => Clothes.Category.Name;
        public string Season => Clothes.Season.Name;
        public string Size { get; }
        public int? Quantity => Clothes.Sizes.FirstOrDefault(y => y.Size == Size)?.Quantity ?? null;
        public string Comment => Clothes.Sizes.FirstOrDefault(y => y.Size == Size)?.Comment ?? null;

        private bool _isDeleting;
        public bool IsDeleting
        {
            get => _isDeleting;
            set
            {
                if (_isDeleting != value)
                {
                    _isDeleting = value;
                    OnPropertyChanged(nameof(IsDeleting));
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                    OnPropertyChanged(nameof(HasErrorMessage));
                }
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);


        public DetailedClothesListingItemModel(ClothesModel clothes, string size)
        {
            Clothes = clothes;
            Size = size;
        }

        public void Edit(ClothesModel clothes)
        {
            Clothes = clothes;

            OnPropertyChanged(nameof(ID));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Category));
            OnPropertyChanged(nameof(Season));
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Comment));
        }
    }
}
