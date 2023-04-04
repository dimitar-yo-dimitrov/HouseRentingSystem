﻿using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.Agent;

namespace HouseRentingSystem.Core.ViewModels.Agents
{
    public class BecomeAgentInputModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        public string PhoneNumber { get; init; } = null!;
    }
}
