﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HouseRentingSystem.Infrastructure.Data.Identity;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.House;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal PricePerMonth { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }

        public virtual Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }

        [ForeignKey(nameof(RenterId))]
        public virtual ApplicationUser? Renter { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
