using System.Collections.Generic;
using System.Linq;
using POnak.XUnitTestExtensions.BoundaryValueAnalysis;
using Xunit;

namespace POnak.XUnitTestExtensions.Tests.BoundaryValueAnalysis
{
    public class DoubleBoundaryTests
    {
        [Fact]
        public void DoubleExclusiveBoundaryTest()
        {
            var generator = new DoubleExclusiveBoundaryData(-10, 10, new[] {1, 0.01});

            var testMethod = typeof(DoubleBoundaryTests).GetMethod(nameof(DoubleExclusiveBoundaryTest));
            var testCases = generator.GetData(testMethod).ToList();

            var expectedTestCases = new[]
            {
                new GeneratorEntry<double>(false, -10 - 1),
                new GeneratorEntry<double>(false, -10 - 0.01),

                // Low boundary
                new GeneratorEntry<double>(false, -10),

                new GeneratorEntry<double>(true, -10 + 1),
                new GeneratorEntry<double>(true, -10 + 0.01),

                // Middle point
                new GeneratorEntry<double>(true, 0),

                new GeneratorEntry<double>(true, 10 - 1),
                new GeneratorEntry<double>(true, 10 - 0.01),

                // High boundary
                new GeneratorEntry<double>(false, 10),

                new GeneratorEntry<double>(false, 10 + 1),
                new GeneratorEntry<double>(false, 10 + 0.01)
            };

            AssertTestCases(expectedTestCases, testCases);
        }

        [Fact]
        public void DoubleInclusiveBoundaryTest()
        {
            var generator = new DoubleInclusiveBoundaryData(-10, 10, new[] {1, 0.01});

            var testMethod = typeof(DoubleBoundaryTests).GetMethod(nameof(DoubleExclusiveBoundaryTest));
            var testCases = generator.GetData(testMethod).ToList();

            var expectedTestCases = new[]
            {
                new GeneratorEntry<double>(false, -10 - 1),
                new GeneratorEntry<double>(false, -10 - 0.01),

                // Low boundary
                new GeneratorEntry<double>(true, -10),

                new GeneratorEntry<double>(true, -10 + 1),
                new GeneratorEntry<double>(true, -10 + 0.01),

                // Middle point
                new GeneratorEntry<double>(true, 0),

                new GeneratorEntry<double>(true, 10 - 1),
                new GeneratorEntry<double>(true, 10 - 0.01),

                // High boundary
                new GeneratorEntry<double>(true, 10),

                new GeneratorEntry<double>(false, 10 + 1),
                new GeneratorEntry<double>(false, 10 + 0.01)
            };

            AssertTestCases(expectedTestCases, testCases);
        }

        private void AssertTestCases(GeneratorEntry<double>[] expectedTestCases, List<object[]> testCases)
        {
            foreach (var expectedCase in expectedTestCases)
                Assert.Contains(testCases, x => x.SequenceEqual(expectedCase.ToArray()));

            Assert.Equal(testCases.Count, expectedTestCases.Length);
        }
    }
}