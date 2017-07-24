namespace TEKsystems.CodingExercise.Console.Domain.Product
{
    /// <summary>Perfume product.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.Product.BaseProduct" />
    public class Perfume : BaseProduct
    {
        public override decimal TaxRate => TaxPercentage.GetTaxPercentage("SalesTax");
    }
}
