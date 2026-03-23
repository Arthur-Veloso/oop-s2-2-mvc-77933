using FoodSafety.domain.Enums;
using FoodSafety.domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodSafety.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Premises> Premises { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            // PREMISES (12)
            
            modelBuilder.Entity<Premises>().HasData(
                new Premises { Id = 1, Name = "Cafe One", Address = "Main St", Town = "Dublin", RiskRating = RiskRating.Low },
                new Premises { Id = 2, Name = "Burger Spot", Address = "High St", Town = "Dublin", RiskRating = RiskRating.High },
                new Premises { Id = 3, Name = "Pizza Place", Address = "Market St", Town = "Dublin", RiskRating = RiskRating.Medium },
                new Premises { Id = 4, Name = "Sushi Bar", Address = "River Rd", Town = "Cork", RiskRating = RiskRating.Low },
                new Premises { Id = 5, Name = "Steak House", Address = "King St", Town = "Cork", RiskRating = RiskRating.High },
                new Premises { Id = 6, Name = "Vegan Hub", Address = "Green St", Town = "Cork", RiskRating = RiskRating.Medium },
                new Premises { Id = 7, Name = "Taco Town", Address = "Ocean Rd", Town = "Galway", RiskRating = RiskRating.Low },
                new Premises { Id = 8, Name = "BBQ Grill", Address = "Hill St", Town = "Galway", RiskRating = RiskRating.High },
                new Premises { Id = 9, Name = "Pasta Corner", Address = "Bridge St", Town = "Galway", RiskRating = RiskRating.Medium },
                new Premises { Id = 10, Name = "Bakery Bliss", Address = "Sunset Blvd", Town = "Dublin", RiskRating = RiskRating.Low },
                new Premises { Id = 11, Name = "Coffee Express", Address = "Central Ave", Town = "Cork", RiskRating = RiskRating.Medium },
                new Premises { Id = 12, Name = "Fast Bites", Address = "Station Rd", Town = "Galway", RiskRating = RiskRating.High }
            );

            
            // INSPECTIONS (25)
            
            modelBuilder.Entity<Inspection>().HasData(
                new Inspection { Id = 1, PremisesId = 1, InspectionDate = new DateTime(2026, 1, 1), Score = 90, Outcome = Outcome.Pass },
                new Inspection { Id = 2, PremisesId = 2, InspectionDate = new DateTime(2026, 1, 2), Score = 45, Outcome = Outcome.Fail },
                new Inspection { Id = 3, PremisesId = 3, InspectionDate = new DateTime(2026, 1, 3), Score = 75, Outcome = Outcome.Pass },
                new Inspection { Id = 4, PremisesId = 4, InspectionDate = new DateTime(2026, 1, 4), Score = 88, Outcome = Outcome.Pass },
                new Inspection { Id = 5, PremisesId = 5, InspectionDate = new DateTime(2026, 1, 5), Score = 50, Outcome = Outcome.Fail },
                new Inspection { Id = 6, PremisesId = 6, InspectionDate = new DateTime(2026, 1, 6), Score = 70, Outcome = Outcome.Pass },
                new Inspection { Id = 7, PremisesId = 7, InspectionDate = new DateTime(2026, 1, 7), Score = 95, Outcome = Outcome.Pass },
                new Inspection { Id = 8, PremisesId = 8, InspectionDate = new DateTime(2026, 1, 8), Score = 30, Outcome = Outcome.Fail },
                new Inspection { Id = 9, PremisesId = 9, InspectionDate = new DateTime(2026, 1, 9), Score = 65, Outcome = Outcome.Pass },
                new Inspection { Id = 10, PremisesId = 10, InspectionDate = new DateTime(2026, 1, 10), Score = 85, Outcome = Outcome.Pass },
                new Inspection { Id = 11, PremisesId = 11, InspectionDate = new DateTime(2026, 1, 11), Score = 55, Outcome = Outcome.Fail },
                new Inspection { Id = 12, PremisesId = 12, InspectionDate = new DateTime(2026, 1, 12), Score = 60, Outcome = Outcome.Pass },
                new Inspection { Id = 13, PremisesId = 1, InspectionDate = new DateTime(2026, 2, 1), Score = 92, Outcome = Outcome.Pass },
                new Inspection { Id = 14, PremisesId = 2, InspectionDate = new DateTime(2026, 2, 2), Score = 40, Outcome = Outcome.Fail },
                new Inspection { Id = 15, PremisesId = 3, InspectionDate = new DateTime(2026, 2, 3), Score = 78, Outcome = Outcome.Pass },
                new Inspection { Id = 16, PremisesId = 4, InspectionDate = new DateTime(2026, 2, 4), Score = 80, Outcome = Outcome.Pass },
                new Inspection { Id = 17, PremisesId = 5, InspectionDate = new DateTime(2026, 2, 5), Score = 35, Outcome = Outcome.Fail },
                new Inspection { Id = 18, PremisesId = 6, InspectionDate = new DateTime(2026, 2, 6), Score = 72, Outcome = Outcome.Pass },
                new Inspection { Id = 19, PremisesId = 7, InspectionDate = new DateTime(2026, 2, 7), Score = 88, Outcome = Outcome.Pass },
                new Inspection { Id = 20, PremisesId = 8, InspectionDate = new DateTime(2026, 2, 8), Score = 25, Outcome = Outcome.Fail },
                new Inspection { Id = 21, PremisesId = 9, InspectionDate = new DateTime(2026, 2, 9), Score = 68, Outcome = Outcome.Pass },
                new Inspection { Id = 22, PremisesId = 10, InspectionDate = new DateTime(2026, 2, 10), Score = 90, Outcome = Outcome.Pass },
                new Inspection { Id = 23, PremisesId = 11, InspectionDate = new DateTime(2026, 2, 11), Score = 50, Outcome = Outcome.Fail },
                new Inspection { Id = 24, PremisesId = 12, InspectionDate = new DateTime(2026, 2, 12), Score = 62, Outcome = Outcome.Pass },
                new Inspection { Id = 25, PremisesId = 1, InspectionDate = new DateTime(2026, 3, 1), Score = 93, Outcome = Outcome.Pass }
            );

            
            // FOLLOW UPS (10)
            
            modelBuilder.Entity<FollowUp>().HasData(
                new FollowUp { Id = 1, InspectionId = 2, DueDate = new DateTime(2026, 1, 20), Status = FollowUpStatus.Open },
                new FollowUp { Id = 2, InspectionId = 5, DueDate = new DateTime(2026, 1, 25), Status = FollowUpStatus.Open },
                new FollowUp { Id = 3, InspectionId = 8, DueDate = new DateTime(2026, 1, 15), Status = FollowUpStatus.Closed, ClosedDate = new DateTime(2026, 1, 16) },
                new FollowUp { Id = 4, InspectionId = 11, DueDate = new DateTime(2026, 2, 1), Status = FollowUpStatus.Open },
                new FollowUp { Id = 5, InspectionId = 14, DueDate = new DateTime(2026, 2, 10), Status = FollowUpStatus.Open },
                new FollowUp { Id = 6, InspectionId = 17, DueDate = new DateTime(2026, 2, 15), Status = FollowUpStatus.Closed, ClosedDate = new DateTime(2026, 2, 16) },
                new FollowUp { Id = 7, InspectionId = 20, DueDate = new DateTime(2026, 2, 20), Status = FollowUpStatus.Open },
                new FollowUp { Id = 8, InspectionId = 23, DueDate = new DateTime(2026, 2, 25), Status = FollowUpStatus.Open },
                new FollowUp { Id = 9, InspectionId = 2, DueDate = new DateTime(2026, 3, 5), Status = FollowUpStatus.Open },
                new FollowUp { Id = 10, InspectionId = 5, DueDate = new DateTime(2026, 3, 10), Status = FollowUpStatus.Closed, ClosedDate = new DateTime(2026, 3, 11) }
            );
        }
    }
}
