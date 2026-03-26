using FoodSafety.Data;
using FoodSafety.domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodSafety.Controllers
{
    [Authorize(Roles = "Admin,Viewer")] 
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string town, RiskRating? riskRating)
        {
            var inspections = _context.Inspections.Include(i => i.Premises).AsQueryable();

            // Filters
            if (!string.IsNullOrEmpty(town))
            {
                inspections = inspections.Where(i => i.Premises.Town == town);
            }

            if (riskRating.HasValue)
            {
                inspections = inspections.Where(i => i.Premises.RiskRating == riskRating);
            }

            ViewBag.Towns = await _context.Premises.Select(p => p.Town).Distinct().ToListAsync();
            ViewBag.SelectedTown = town;
            ViewBag.SelectedRisk = riskRating;

            var now = DateTime.Now;

            ViewBag.InspectionsThisMonth = await inspections
                .Where(i => i.InspectionDate.Month == now.Month && i.InspectionDate.Year == now.Year)
                .CountAsync();

            ViewBag.FailedThisMonth = await inspections
                .Where(i => i.InspectionDate.Month == now.Month &&
                            i.InspectionDate.Year == now.Year &&
                            i.Outcome == Outcome.Fail)
                .CountAsync();

            var overdueFollowUps = _context.FollowUps
    .Include(f => f.Inspection)
    .ThenInclude(i => i.Premises)
    .AsQueryable();

            // Apply SAME filters
            if (!string.IsNullOrEmpty(town))
            {
                overdueFollowUps = overdueFollowUps
                    .Where(f => f.Inspection.Premises.Town == town);
            }

            if (riskRating.HasValue)
            {
                overdueFollowUps = overdueFollowUps
                    .Where(f => f.Inspection.Premises.RiskRating == riskRating);
            }

            // Final condition
            ViewBag.OverdueFollowUps = await overdueFollowUps
                .Where(f => f.Status == FollowUpStatus.Open && f.DueDate < now)
                .CountAsync();

            return View();
        }
    }
}