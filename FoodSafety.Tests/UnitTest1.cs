using FoodSafety.domain.Enums;
using FoodSafety.domain.Models;

namespace FoodSafety.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FollowUp_IsOverdue_WhenDueDatePassed()
        {
            var followUp = new FollowUp
            {
                DueDate = DateTime.Now.AddDays(-1),
                Status = FollowUpStatus.Open
            };

            var isOverdue = followUp.DueDate < DateTime.Now && followUp.Status == FollowUpStatus.Open;

            Assert.True(isOverdue);
        }

        [Fact]
        public void FollowUp_ClosedWithoutDate_ShouldBeInvalid()
        {
            var followUp = new FollowUp
            {
                Status = FollowUpStatus.Closed,
                ClosedDate = null
            };

            var isValid = !(followUp.Status == FollowUpStatus.Closed && followUp.ClosedDate == null);

            Assert.False(isValid);
        }

        [Fact]
        public void Inspection_ScoreBelow60_ShouldFail()
        {
            var inspection = new Inspection
            {
                Score = 50
            };

            var outcome = inspection.Score >= 60 ? Outcome.Pass : Outcome.Fail;

            Assert.Equal(Outcome.Fail, outcome);
        }

        [Fact]
        public void Dashboard_ShouldCountInspections()
        {
            var inspections = new List<Inspection>
    {
        new Inspection { InspectionDate = DateTime.Now },
        new Inspection { InspectionDate = DateTime.Now }
    };

            var count = inspections.Count(i => i.InspectionDate.Month == DateTime.Now.Month);

            Assert.Equal(2, count);
        }
    }
}