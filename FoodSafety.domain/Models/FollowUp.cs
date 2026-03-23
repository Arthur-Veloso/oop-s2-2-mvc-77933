using FoodSafety.domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSafety.domain.Models
{
    public class FollowUp
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }

        [ForeignKey("InspectionId")]
        public Inspection Inspection { get; set; }

        public DateTime DueDate { get; set; }

        public FollowUpStatus Status { get; set; }

        public DateTime? ClosedDate { get; set; }
    }
}