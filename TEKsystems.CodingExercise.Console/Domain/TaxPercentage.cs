namespace TEKsystems.CodingExercise.Console.Domain
{
    public static class TaxPercentage
    {
        public static decimal GetTaxPercentage(string Name)
        {
            switch (Name)
            {
                case "SalesTax": return .1m;
                case "ImportedTax": return .05m;
                
                default: return 0m;
            }
        }
    }
}
