using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPRSolution.Models
{
    public class StationOwner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Complaints Description")]
        [Required(ErrorMessage = "Description is required")]
        public string CompDesc { get; set; }
        [Display(Name = " Business Name")]
        [Required(ErrorMessage = "Business Name is required")]
        public string BusinessName { get; set; }

        public string CreadtedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<AutoFileDetail> Documents { get; set; }

        
    }
}
