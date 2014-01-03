using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class FrequencyOperators
    {
        [Fact]
        public void OpAddition() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var expected = new Frequency(2, FrequencyUnit.Hertz);
            (frequency1 + frequency2).ShouldEqual(expected);
            (frequency2 + frequency1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var frequency1 = new Frequency(2, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 / frequency2).ShouldBeWithinEpsilonOf(1);
            (frequency2 / frequency1).ShouldBeWithinEpsilonOf(1);

            (frequency1 / 2).ShouldEqual(new Frequency(1, FrequencyUnit.Hertz));
            (frequency2 / 2).ShouldEqual(new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond));
        }

        [Fact]
        public void OpEquals() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 == frequency2).ShouldBeTrue();
            (frequency2 == frequency1).ShouldBeTrue();
            (frequency1 == frequency3).ShouldBeFalse();
            (frequency3 == frequency1).ShouldBeFalse();
            frequency1.Equals(frequency2)
                      .ShouldBeTrue();
            frequency1.Equals((object)frequency2)
                      .ShouldBeTrue();
            frequency2.Equals(frequency1)
                      .ShouldBeTrue();
            frequency2.Equals((object)frequency1)
                      .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 > frequency3).ShouldBeFalse();
            (frequency3 > frequency1).ShouldBeTrue();
            (frequency1 > frequency2).ShouldBeFalse();
            (frequency2 > frequency1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 >= frequency3).ShouldBeFalse();
            (frequency3 >= frequency1).ShouldBeTrue();
            (frequency1 >= frequency2).ShouldBeTrue();
            (frequency2 >= frequency1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 != frequency2).ShouldBeFalse();
            (frequency2 != frequency1).ShouldBeFalse();
            (frequency1 != frequency3).ShouldBeTrue();
            (frequency3 != frequency1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 < frequency3).ShouldBeTrue();
            (frequency3 < frequency1).ShouldBeFalse();
            (frequency1 < frequency2).ShouldBeFalse();
            (frequency2 < frequency1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            var frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 <= frequency3).ShouldBeTrue();
            (frequency3 <= frequency1).ShouldBeFalse();
            (frequency1 <= frequency2).ShouldBeTrue();
            (frequency2 <= frequency1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var frequency = new Frequency(1, FrequencyUnit.Hertz);
            var expected = new Frequency(2, FrequencyUnit.Hertz);
            (frequency * 2).ShouldEqual(expected);
            (2 * frequency).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var frequency1 = new Frequency(10, FrequencyUnit.Hertz);
            var frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
            (frequency1 - frequency2).ShouldEqual(new Frequency(9, FrequencyUnit.Hertz));
            (frequency2 - frequency1).ShouldEqual(new Frequency(-9, FrequencyUnit.NumberOfCyclesPerSecond));
        }
    }
}