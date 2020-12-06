using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AreULub.Models
{
    public class ServiceModel
    {

        // EF Core will configure the database to generate this value
        [Key]
        public int ServiceID { get; set; }
         [Required]
          [MaxLength(50, ErrorMessage ="Name between 1 and 50 chars")]
        public string ServiceName { get; set; }
          [Required]
         [MaxLength(50, ErrorMessage = "Description between 1 and 50 chars")]
        public string ServiceDescription { get; set; }
          [Required]
          [MaxLength(25, ErrorMessage = "Estimated time between 1 and 25 chars")]
        public string ServiceEstimated { get; set; }
          [Required]       
        [Range(1,2250, ErrorMessage = "Price between 1 and 2250 chars")]
        public decimal ServicePrice { get; set; }
        // public string UserLast { get; set; }
        
        public string UserID { get; set; }
        public User User { get; set; }

        public string Slug =>
       ServiceName?.Replace(' ', '-').ToLower() + '-' + ServiceDescription?.ToString();

    }
}
