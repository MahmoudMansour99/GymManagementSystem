using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.TrainerViewModels
{
    public class UpdateTrainerViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email Must be Between 5 And 100 Characters")]
        public string? Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone Is Required")]
        [Phone(ErrorMessage = "Invalid Phone Format")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Phone Number Must Be Valid Egyptian Phone Number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Building Number Is Required")]
        [Range(1, 1000, ErrorMessage = "Building Number Must be Between 1 And 1000")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street Is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street Must be Between 2 And 30 Characters")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City Is Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "City Must be Between 2 And 30 Characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can Contain only Letters and Spaces")]
        public string City { get; set; } = null!;
        public Specialties Specialization { get; set; }
    }
}