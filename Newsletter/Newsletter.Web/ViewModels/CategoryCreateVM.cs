﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class CategoryCreateVM
    {
        [Required]
        [DisplayName("Nom de la catégorie")]
        public string Name { get; set; } = default!;

        [MinLength(3)]
        public string Description { get; set; } = default!;

    }
}
