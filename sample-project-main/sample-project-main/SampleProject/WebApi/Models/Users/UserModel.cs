using BusinessEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public UserTypes Type { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal? AnnualSalary { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}