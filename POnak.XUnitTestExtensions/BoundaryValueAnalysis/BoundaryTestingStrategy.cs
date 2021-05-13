namespace POnak.XUnitTestExtensions.BoundaryValueAnalysis
{
    /// <summary>
    ///     Testing strategy for boundary analysis. See more:
    ///     <see href="https://www.getsoftwareservice.com/boundary-value-analysis/" />
    /// </summary>
    public enum BoundaryTestingStrategy
    {
        /// <summary>
        ///     Use boundary itself, and invalid value.
        /// </summary>
        TwoPoint,

        /// <summary>
        ///     Use boundary itself, and one value on either side of the boundary.
        /// </summary>
        ThreePoint
    }
}