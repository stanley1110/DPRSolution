using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DPRSolution.Models
{
    public class AutoFileDetail
    {
        [Key]
        public int Id { get; set; }
        public string filename { get; set; }
        public string Email { get; set; }
        public string FileExtension { get; set; }
        public string filepath { get; set; }
        public int? AutoId { get; set; }
        [ForeignKey("AutoId")]
        public AutomobileOwner? Automobile { get; set; }
        public int? StationId { get; set; }
        [ForeignKey("StationId")]
        public StationOwner?  Station { get; set; }



    }



}

