using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    public enum Product
    {
        Bananas,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Sausages,
        Butter,
        Eggs
    }
    public static class ProductData
    {
            private static readonly Dictionary<Product, double> Temperatures = new Dictionary<Product, double>
            {
                        { Product.Bananas, 13.3 },
                        { Product.Chocolate, 18 },
                        { Product.Fish, 2 },
                        { Product.Meat, -15 },
                        { Product.IceCream, -18 },
                        { Product.FrozenPizza, -30 },
                        { Product.Cheese, 7.2 },
                        { Product.Sausages, 5 },
                        { Product.Butter, 20.5 },
                        { Product.Eggs, 19 }
            };

            public static double getTemperature(Product product)
            {
                return Temperatures[product];
            }
    }
}
