using System;
using System.Linq;
using System.Text;

using TEKsystems.CodingExercise.Console.Domain;
using static TEKsystems.CodingExercise.Console.Ext.TableBuilders;

namespace TEKsystems.CodingExercise.Console.Utility
{
	public class Receipt
	{
		private Receipt()
		{}

		private static readonly Lazy<Receipt> _instance = new Lazy<Receipt>( () => new Receipt() );

		public static Receipt Instance
		{ get { return _instance.Value; } }

		public string Create( Cart cart )
		{
			StringBuilder receipt = new StringBuilder();
			decimal totalTax = 0;
            int sno = 1;
            int count = 1;
            TableBuilder tb = new TableBuilder();
            tb.AddRow("S.No.", "Product Name", "Count", "Price", "Sales Tax");
            tb.AddRow("-----", "------------", "-----","-----","---------");

            foreach ( var product in cart.Products )
			{
				decimal tax = Taxes.ComputeSalesTax( product );
				totalTax += tax;
                decimal price = product.Price;				
                string name = String.Format("{0} {1}", product.IsImported ? "Imported " : "", product.Name);                
                tb.AddRow(sno++, name, count, price, tax);
            }
            receipt.Append(tb.Output());
            decimal total = Taxes.RoundingRule( cart.Products.Sum( p => p.Price ) + totalTax );
            receipt.Append("-------------------------------------------------------------------\n");
            receipt.Append( "Total Sales Taxes: " + Taxes.RoundingRule( totalTax ).ToString( "0.00" ) + Environment.NewLine );
			receipt.Append( "Total: " + total.ToString() );

            return receipt.ToString();
		}
	}
}
