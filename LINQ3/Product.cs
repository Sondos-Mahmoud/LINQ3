using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class MyEqualityComaprer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if(x is null)
            {
                if (y is null) return true;
                return false;

            }
            return x.ProductID.Equals(y?.ProductID);
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.ProductID);
        }
    }

    class MyComparerUnitInStock : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            return x?.UnitsInStock.CompareTo(y?.UnitsInStock) ?? 0;
        }
    }

    class product02 : Product
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return $"Id : {Id}";
        }
    }
    class Product : IComparable<Product>
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CompareTo(Product? other)
        {
            return this.UnitPrice.CompareTo(other?.UnitPrice);
        }



        public override string ToString()
            => $"ProductID:{ProductID},ProductName:{ProductName},Category{Category},UnitPrice:{UnitPrice},UnitsInStock:{UnitsInStock}";

        public override bool Equals(object? obj)
        {
            Product other = obj as Product;
            if (other == null) return false;
            return this.ProductID == other.ProductID &&
                this.ProductName == other.ProductName &&
                this.Category == other.Category &&
                this.UnitPrice.Equals(other.UnitPrice) &&
                this.UnitsInStock.Equals(other.UnitsInStock);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductID, ProductName, Category,UnitPrice,UnitsInStock);
        }
    }
}
