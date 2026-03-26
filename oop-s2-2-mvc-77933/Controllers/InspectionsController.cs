using FoodSafety.Data;
using FoodSafety.domain.Enums;
using FoodSafety.domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace FoodSafety.Controllers
{
    [Authorize(Roles = "Admin,Inspector")]
    public class InspectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InspectionsController> _logger;

        public InspectionsController(ApplicationDbContext context, ILogger<InspectionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Inspections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inspections.Include(i => i.Premises);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(i => i.Premises)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        // GET: Inspections/Create
        public IActionResult Create()
        {
            ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name");
            return View();
        }

        // POST: Inspections/Create
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,PremisesId,InspectionDate,Score,Notes")] Inspection inspection)
{
    // Business logic
    if (inspection.Score >= 60)
    {
        inspection.Outcome = Outcome.Pass;
    }
    else
    {
        inspection.Outcome = Outcome.Fail;
        _logger.LogWarning("Low score inspection detected: {Score}", inspection.Score);
    }

    if (ModelState.IsValid)
    {
        try
        {
            //  Save inspection first
            _context.Add(inspection);
            await _context.SaveChangesAsync();

            //  SAFER: calculate avg WITHOUT Include
            var inspections = await _context.Inspections
                .Where(i => i.PremisesId == inspection.PremisesId)
                .ToListAsync();

            if (inspections.Any())
            {
                var avgScore = inspections.Average(i => i.Score);

                var premises = await _context.Premises.FindAsync(inspection.PremisesId);

                if (premises != null)
                {
                    if (avgScore < 50)
                        premises.RiskRating = RiskRating.High;
                    else if (avgScore < 70)
                        premises.RiskRating = RiskRating.Medium;
                    else
                        premises.RiskRating = RiskRating.Low;

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Premises {Id} risk updated to {Risk}", premises.Id, premises.RiskRating);
                }
            }

            // ✅ Log success
            _logger.LogInformation(
                "Inspection created successfully. PremisesId: {PremisesId}, Score: {Score}, Outcome: {Outcome}",
                inspection.PremisesId, inspection.Score, inspection.Outcome
            );

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving inspection");
        }
    }

    ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
    return View(inspection);
}

        // GET: Inspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }

            ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
            return View(inspection);
        }

        // POST: Inspections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PremisesId,InspectionDate,Score,Notes")] Inspection inspection)
        {
            if (id != inspection.Id)
            {
                return NotFound();
            }

            //  Recalculate Outcome
            if (inspection.Score >= 60)
            {
                inspection.Outcome = Outcome.Pass;
            }
            else
            {
                inspection.Outcome = Outcome.Fail;
                _logger.LogWarning("Low score inspection detected on edit: {Score}", inspection.Score);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspection);
                    await _context.SaveChangesAsync();

                    //  Recalculate Risk
                    var inspections = await _context.Inspections
                        .Where(i => i.PremisesId == inspection.PremisesId)
                        .ToListAsync();

                    if (inspections.Any())
                    {
                        var avgScore = inspections.Average(i => i.Score);

                        var premises = await _context.Premises.FindAsync(inspection.PremisesId);

                        if (premises != null)
                        {
                            if (avgScore < 50)
                                premises.RiskRating = RiskRating.High;
                            else if (avgScore < 70)
                                premises.RiskRating = RiskRating.Medium;
                            else
                                premises.RiskRating = RiskRating.Low;

                            await _context.SaveChangesAsync();

                            _logger.LogInformation("Premises {Id} risk updated after edit to {Risk}", premises.Id, premises.RiskRating);
                        }
                    }

                    _logger.LogInformation("Inspection updated: {Id}", inspection.Id);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionExists(inspection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["PremisesId"] = new SelectList(_context.Premises, "Id", "Name", inspection.PremisesId);
            return View(inspection);
        }

        // GET: Inspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(i => i.Premises)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        // POST: Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspection = await _context.Inspections.FindAsync(id);

            if (inspection != null)
            {
                _context.Inspections.Remove(inspection);
                _logger.LogInformation("Inspection deleted: {Id}", id);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionExists(int id)
        {
            return _context.Inspections.Any(e => e.Id == id);
        }
    }
}