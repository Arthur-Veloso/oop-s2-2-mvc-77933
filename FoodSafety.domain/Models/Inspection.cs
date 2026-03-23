using FoodSafety.domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSafety.domain.Models
{
    public class Inspection
    {
        public int Id { get; set; }

    
        public int PremisesId { get; set; }

        [ForeignKey("PremisesId")]
        public Premises Premises { get; set; }

      
        public DateTime InspectionDate { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }

      
        public Outcome Outcome { get; set; }

        public string? Notes { get; set; }

        public List<FollowUp>? FollowUps { get; set; }
    }
}
