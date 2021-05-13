namespace POnak.XUnitTestExtensions.BoundaryValueAnalysis
{
    public struct GeneratorEntry<TType>
    {
        public GeneratorEntry(bool valid, TType param)
        {
            Valid = valid;
            Param = param;
        }

        /// <summary>
        ///     Whenever test should fail or pass at boundary.
        /// </summary>
        public bool Valid { get; }

        /// <summary>
        ///     Param value to test.
        /// </summary>
        public TType Param { get; }

        /// <summary>
        ///     Converts this object to array of objects expect by XUnit.
        /// </summary>
        /// <returns></returns>
        public object[] ToArray()
        {
            return new object[] {Valid, Param};
        }
    }
}