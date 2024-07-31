﻿using System.ComponentModel.DataAnnotations;

namespace DVS.EntityFramework.DTOs
{
    public class CategoryDTO
    {
        [Key]
        public Guid? GuidID { get; set; }
        public string Name { get; set; }
    }
}