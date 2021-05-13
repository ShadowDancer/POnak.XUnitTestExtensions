using POnak.XUnitTestExtensions.BoundaryValueAnalysis;
using Xunit;

namespace POnak.XUnitTestExtensions.Examples
{
    public class Tests

    {
        [Theory]
        [IntInclusiveBoundaryData(0, 100)]
        public void TestIntInclusiveBoundary(bool expectedPass, int value)
        {
            ClassUnderTest test = new ClassUnderTest();
            bool success = test.Between0And100(value);

            Assert.Equal(expectedPass, success);
        }


        [Theory]
        [DoubleInclusiveBoundaryData(0, 100, new []{1, 0.01})]
        public void TestDoubleInclusiveBoundary(bool expectedPass, double value)
        {
            ClassUnderTest test = new ClassUnderTest();
            bool success = test.Between0And100(value);

            Assert.Equal(expectedPass, success);
        }
    }
}
