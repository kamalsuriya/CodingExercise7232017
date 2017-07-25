namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Base class for all products.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.BaseDomain" />
    public abstract class BaseBook : BaseProduct
    {
        public override bool IsTaxable => false;
    }
}
