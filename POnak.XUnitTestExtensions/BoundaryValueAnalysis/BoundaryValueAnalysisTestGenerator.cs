using System.Collections.Generic;

namespace POnak.XUnitTestExtensions.BoundaryValueAnalysis
{
    /// <summary>
    ///     Generates test cases using boundary value analysis strategy
    /// </summary>
    internal class BoundaryValueAnalysisTestGenerator<TType>
    {
        private readonly bool _inclusive;
        private readonly BoundaryTestingStrategy _strategy;

        /// <summary>
        ///     Creates new instance of generator.
        /// </summary>
        /// <param name="strategy">Testing strategy to use.</param>
        /// <param name="inclusive">If inclusive boundaries will be considered valid cases.</param>
        public BoundaryValueAnalysisTestGenerator(BoundaryTestingStrategy strategy, bool inclusive)
        {
            _strategy = strategy;
            _inclusive = inclusive;
        }

        /// <summary>
        ///     Generates test cases, TType is expected to be numeric type like int or double with arithmetic operators.
        /// </summary>
        /// <param name="low">Lower boundary.</param>
        /// <param name="high">High boundary.</param>
        /// <param name="epsilons">List of epsilons which will be used to find neighboring points near low and high boundaries.</param>
        public IEnumerable<GeneratorEntry<TType>> GenerateNumericTestCases(TType low, TType high,
            params TType[] epsilons)
        {
            dynamic dLow = low;
            dynamic dHigh = high;

            foreach (var neighbor in epsilons) yield return new GeneratorEntry<TType>(false, dLow - neighbor);

            yield return new GeneratorEntry<TType>(_inclusive, dLow);

            if (_strategy == BoundaryTestingStrategy.ThreePoint)
                foreach (var neighbor in epsilons)
                    yield return new GeneratorEntry<TType>(true, dLow + neighbor);

            var middle = (dLow + dHigh) / 2;
            yield return new GeneratorEntry<TType>(true, middle);


            if (_strategy == BoundaryTestingStrategy.ThreePoint)
                foreach (var neighbor in epsilons)
                    yield return new GeneratorEntry<TType>(true, dHigh - neighbor);

            yield return new GeneratorEntry<TType>(_inclusive, dHigh);


            foreach (var neighbor in epsilons) yield return new GeneratorEntry<TType>(false, dHigh + neighbor);
        }
    }
}