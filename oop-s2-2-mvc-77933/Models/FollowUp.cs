using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using oop_s2_2_mvc_77933.Enums;

namespace oop_s2_2_mvc_77933.Models
{
    public class FollowUp
    {
        public int Id { get; set; }

        [Required]
        public int InspectionId { get; set; }

        [ForeignKey("InspectionId")]
        public Inspection Inspection { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public FollowUpStatus Status { get; set; }

        public DateTime? ClosedDate { get; set; }
    }
}