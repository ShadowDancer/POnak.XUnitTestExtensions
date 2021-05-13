using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace POnak.XUnitTestExtensions.BoundaryValueAnalysis
{
    /// <summary>
    ///     Generates boundary data around boundary including boundary itself.
    ///     Consuming test method should have <see cref="TheoryAttribute" /> attribute, and (bool, int) signature.
    ///     First bool parameter defines if test should pass, second int is parameter to test.
    /// </summary>
    public class IntInclusiveBoundaryData : DataAttribute
    {
        /// <summary>
        ///     Configures boundaries and epsilons to test.
        /// </summary>
        /// <inheritdoc cref="Low" />
        /// <inheritdoc cref="High" />
        /// <inheritdoc cref="Epsilons" />
        public IntInclusiveBoundaryData(int low, int high)
        {
            Low = low;
            High = high;
        }

        /// <summary>
        ///     Low boundary.
        /// </summary>
        public int Low { get; }

        /// <summary>
        ///     High boundary.
        /// </summary>
        public int High { get; }

        /// <summary>
        ///     Epsilons which will be used to modify boundaries.
        /// </summary>
        public int[] Epsilons { get; set; } = {1};

        /// <summary>
        ///     Testing strategy to use.
        /// </summary>
        public BoundaryTestingStrategy Strategy { get; set; } = BoundaryTestingStrategy.ThreePoint;

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var generator = new BoundaryValueAnalysisTestGenerator<int>(Strategy, true);
            return generator.GenerateNumericTestCases(Low, High, Epsilons).Select(n => n.ToArray());
        }
    }
}