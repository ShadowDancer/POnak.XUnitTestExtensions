using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace POnak.XUnitTestExtensions.BoundaryValueAnalysis
{
    /// <summary>
    ///     Generates boundary data around boundary excluding boundary itself.
    ///     Consuming test method should have <see cref="TheoryAttribute" /> attribute, and (bool, double) signature.
    ///     First bool parameter defines if test should pass, second double is parameter to test.
    /// </summary>
    public class DoubleInclusiveBoundaryData : DataAttribute
    {
        /// <summary>
        ///     Configures boundaries and epsilons to test.
        /// </summary>
        /// <inheritdoc cref="Low" />
        /// <inheritdoc cref="High" />
        /// <inheritdoc cref="Epsilons" />
        public DoubleInclusiveBoundaryData(double low, double high, double[] epsilons)
        {
            Low = low;
            High = high;
            Epsilons = epsilons;
        }

        /// <summary>
        ///     Low boundary.
        /// </summary>
        public double Low { get; }

        /// <summary>
        ///     High boundary.
        /// </summary>
        public double High { get; }

        /// <summary>
        ///     Epsilons which will be used to modify boundaries.
        /// </summary>
        public double[] Epsilons { get; set; }

        /// <summary>
        ///     Testing strategy to use.
        /// </summary>
        public BoundaryTestingStrategy Strategy { get; set; } = BoundaryTestingStrategy.ThreePoint;

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var generator = new BoundaryValueAnalysisTestGenerator<double>(Strategy, true);
            return generator.GenerateNumericTestCases(Low, High, Epsilons).Select(n => n.ToArray());
        }
    }
}