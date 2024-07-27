﻿using System.Collections.ObjectModel;
using DVS.ViewModels;

namespace DVS.Models
{
    public class ClothesModel(Guid guidID, string id, string name, CategoryModel category, SeasonModel season, string? comment)
    {
        //TODO: setter entfernen!??
        public Guid GuidID { get; set; } = guidID;
        public string ID { get; set; } = id;
        public string Name { get; set; } = name;
        public CategoryModel Category { get; set; } = category;
        public SeasonModel Season { get; set; } = season;
        public string? Comment { get; set; } = comment;

        public ObservableCollection<ClothesSizeViewModel> Sizes { get; set; } = [];
    }
}
