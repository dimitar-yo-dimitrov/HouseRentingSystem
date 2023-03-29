﻿using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.Category;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<House> Houses { get; init; }
            = new HashSet<House>();
    }
}
