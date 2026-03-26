using FoodSafety.domain.Enums;

namespace FoodSafety.domain.Models
{
    public class Premises
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Town { get; set; }

        public RiskRating RiskRating { get; set; }

        public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
