using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HouseRentingSystem.Infrastructure.Data.Identity;
using static HouseRentingSystem.Common.GlobalConstants.ValidationConstants.Agent;

namespace HouseRentingSystem.Infrastructure.Data.Entities
{
    public class Agent
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; init; } = null!;
    }
}
