﻿using System.Collections.Generic;

using TEKsystems.CodingExercise.Console.Domain.Product;

namespace TEKsystems.CodingExercise.Console.Domain
{
    /// <summary>Represent a cart.</summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.Domain.BaseDomain" />
    public class BaseCart : BaseDomain
	{
		public BaseCart()
		{
			this.Products = new List<BaseProduct>();
		}

		public List<BaseProduct> Products { get; private set; }
	}
}
