using SomeName;
using SomeName.Util;
using SomeName.Annotation;
using System;

namespace SomeNameSample
{
    public class User
    {
        [Required(Message = "Full name is required.")]
        public string Fullname { get; set; }

        [Required(Message = "Username is required.")]
        [MinLength(Message = "Min length must be at least 5 characters", Length = 5)]
        public string Username { get; set; }

        [Required(Message = "Email is required.")]
        [Regex(Message = "Email is not valid.", Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required(Message = "Password is required.")]
        [MinLength(Message = "Password length must be at least 5 characters.", Length = 5)]
        [MaxLength(Message = "Password length must be at most 16 characters.", Length = 16)]
        public string Password { get; set; }

        [Required(Message = "Confirm password is required.")]
        public string ConfirmPassword { get; set; }

        [Range(DataType = DataType.DateTime, Minimum = "1/1/1995", Maximum = "1/1/2010",
            Message ="Date of birth must between '1/1/1995' - '1/1/2010'")]
        public DateTime DOB { get; set; }
    }
}