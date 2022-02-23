using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DPRSolution.DTO
{
    public class AutoMobileVM
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 chars")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 chars")]
        public string Lastname { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Complaints Description")]
        [Required(ErrorMessage = "Description is required")]
        public string CompDesc { get; set; }
        [Display(Name = "Documents")]
        [Required(ErrorMessage = "Supportind documents is required")]

       
        public List<IFormFile> Documents { get; set; }
    }
}
