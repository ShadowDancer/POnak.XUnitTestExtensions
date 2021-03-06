using System.Collections.Generic;
using System.Linq;
using POnak.XUnitTestExtensions.BoundaryValueAnalysis;
using Xunit;

namespace POnak.XUnitTestExtensions.Tests.BoundaryValueAnalysis
{
    /// <summary>
    ///     Contains assertions for common test cases.
    /// </summary>
    public static class Assertions
    {
        /// <summary>
        /// Verifies that list of test cases 
        /// </summary>
        /// <param name="expectedTestCases">Expected test cases.</param>
        /// <param name="testCases">Actual test cases generated by attribute.</param>
        public static void AssertTestCases<TData>(GeneratorEntry<TData>[] expectedTestCases, List<object[]> testCases)
        {
            foreach (var expectedCase in expectedTestCases)
                Assert.Contains(testCases, x => x.SequenceEqual(expectedCase.ToArray()));

            Assert.Equal(testCases.Count, expectedTestCases.Length);
        }
    }
}