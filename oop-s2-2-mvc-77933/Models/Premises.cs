using oop_s2_2_mvc_77933.Enums;

namespace oop_s2_2_mvc_77933.Models
{
    public class Premises
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Town { get; set; }

        public RiskRating RiskRating { get; set; }

        public List<Inspection> Inspections { get; set; }
    }
}
