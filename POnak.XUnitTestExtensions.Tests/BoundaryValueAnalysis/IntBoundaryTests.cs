using System.Linq;
using POnak.XUnitTestExtensions.BoundaryValueAnalysis;
using Xunit;

namespace POnak.XUnitTestExtensions.Tests.BoundaryValueAnalysis
{
    public class IntBoundaryTests
    {
        [Fact]
        public void IntExclusiveBoundaryTest()
        {
            var generator = new IntExclusiveBoundaryData(-10, 10);

            var testMethod = typeof(IntBoundaryTests).GetMethod(nameof(IntExclusiveBoundaryTest));
            var testCases = generator.GetData(testMethod).ToList();

            var expectedTestCases = new[]
            {
                new GeneratorEntry<int>(false, -10 - 1),

                // Low boundary
                new GeneratorEntry<int>(false, -10),

                new GeneratorEntry<int>(true, -10 + 1),

                // Middle point
                new GeneratorEntry<int>(true, 0),

                new GeneratorEntry<int>(true, 10 - 1),

                // High boundary
                new GeneratorEntry<int>(false, 10),

                new GeneratorEntry<int>(false, 10 + 1)
            };

            Assertions.AssertTestCases(expectedTestCases, testCases);
        }

        [Fact]
        public void IntInclusiveBoundaryTest()
        {
            var generator = new IntInclusiveBoundaryData(-10, 10);

            var testMethod = typeof(IntBoundaryTests).GetMethod(nameof(IntExclusiveBoundaryTest));
            var testCases = generator.GetData(testMethod).ToList();

            var expectedTestCases = new[]
            {
                new GeneratorEntry<int>(false, -10 - 1),

                // Low boundary
                new GeneratorEntry<int>(true, -10),

                new GeneratorEntry<int>(true, -10 + 1),

                // Middle point
                new GeneratorEntry<int>(true, 0),

                new GeneratorEntry<int>(true, 10 - 1),

                // High boundary
                new GeneratorEntry<int>(true, 10),

                new GeneratorEntry<int>(false, 10 + 1)
            };

            Assertions.AssertTestCases(expectedTestCases, testCases);
        }
    }
}