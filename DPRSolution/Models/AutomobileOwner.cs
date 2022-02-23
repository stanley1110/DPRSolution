using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPRSolution.Models
{
    public class AutomobileOwner
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string Fullname { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Complaints Description")]
        [Required(ErrorMessage = "Description is required")]
        public string CompDesc { get; set; }
        [Display(Name = "COmplaint Description")]
        [Required(ErrorMessage = "Complaints Description is required")]

        public string CreadtedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<AutoFileDetail> Documents { get; set; }
       

    }
}
