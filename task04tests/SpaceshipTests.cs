using Xunit;
using task04;

namespace task04tests
{
    public class SpaceshipTests
    {
        [Fact]
        public void Cruiser_ShouldHaveCorrectStats()
        {
            ISpaceship cruiser = new Cruiser();
            Assert.Equal(50, cruiser.Speed);
            Assert.Equal(100, cruiser.FirePower);
        }

        [Fact]
        public void Fighter_ShouldBeFasterThanCruiser()
        {
            ISpaceship fighter = new Fighter();
            ISpaceship cruiser = new Cruiser();
            Assert.True(fighter.Speed > cruiser.Speed);
        }

        [Fact]
        public void Fighter_ShouldHaveLowerFirePowerThanCruiser()
        {
            ISpaceship fighter = new Fighter();
            ISpaceship cruiser = new Cruiser();
            Assert.True(fighter.FirePower < cruiser.FirePower);
        }

        [Fact]
        public void Cruiser_Methods_ShouldWork()
        {
            var cruiser = new Cruiser();
            cruiser.MoveForward();
            cruiser.Rotate(30);
            cruiser.Fire();
        }

        [Fact]
        public void Fighter_Methods_ShouldWork()
        {
            var fighter = new Fighter();
            fighter.MoveForward();
            fighter.Rotate(60);
            fighter.Fire();
        }
    }
}