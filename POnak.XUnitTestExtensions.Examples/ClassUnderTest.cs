namespace POnak.XUnitTestExtensions.Examples
{
    public class ClassUnderTest
    {
        public bool Between0And100(int value)
        {
            return value >= 0 && value <= 100;
        }

        public bool Between0And100(double value)
        {
            return value >= 0 && value <= 100;
        }
    }
}