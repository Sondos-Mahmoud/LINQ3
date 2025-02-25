using Demo;
using System.Diagnostics;
using System.Threading;

namespace LINQ3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Set Operators
         /*     1.Find the unique Category names from Product List
                2.Produce a Sequence containing the unique first letter from both product and customer names.
                3.Create one sequence that contains the common first letter from both product and customer names.
                4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
                5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
         */
             var Result01= ListGenerator.ProductList.Select(p => p.Category).Distinct();
               

            var productFirstLetters = ListGenerator.ProductList.Select(p => p.ProductName.FirstOrDefault()).Distinct();
            var customerFirstLetters = ListGenerator.CustomerList.Select(C => C.CustomerName.FirstOrDefault()).Distinct();
            var Result02=productFirstLetters.Union(customerFirstLetters).Distinct();

            var Result03=productFirstLetters.Intersect(customerFirstLetters);
            var Result04 = productFirstLetters.Except(customerFirstLetters);

            //foreach (var Category in Result04)
            //{
            //    Console.WriteLine(Category);
            //}


            #endregion
            #region  Partitioning Operators
            /*
            1. Get the first 3 orders from customers in Washington
            2. Get all but the first 2 orders from customers in Washington.
            3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};


            4.Get the elements of the array starting from the first element divisible by 3.
            int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            5. Get the elements of the array starting from the first element less than its position.
            int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            */
    //        var firstThreeOrders = ListGenerator.CustomerList.Where(o => o.Country == "Washington").Take(3);
    //        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    //        var remainingOrders = ListGenerator.CustomerList
    //.Where(o => o.Country == "Washington")
    //.Skip(2);
    //        var result = numbers.TakeWhile((num, index) => num >= index);

    //        Console.WriteLine(string.Join(", ", result));


            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = numbers.SkipWhile(num => num % 3 != 0);

            //Console.WriteLine(string.Join(", ", result));


            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = numbers.SkipWhile((num, index) => num >= index);

            //Console.WriteLine(string.Join(", ", result));

            #endregion
            #region  Quantifiers
            /*1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            3. Return a grouped a list of products only for categories that have all of their products in stock.
            */
            var words = File.ReadAllLines("dictionary_english.txt"); 
            bool containsEi = words.Any(word => word.Contains("ei"));

            Console.WriteLine($"Any word contains 'ei': {containsEi}");

            var groupedProducts = ListGenerator.ProductList.Where(p => p.UnitsInStock == 0).GroupBy(p => p.Category);
            var allInStockCategories = ListGenerator.ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0));
            #endregion
            #region Grouping Operators
            /*
            1. Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbers = new list<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

             2.Uses group by to partition a list of words by their first letter.
             Use dictionary_english.txt for Input

            3.Consider this Array as an Input
            String [] Arr = {"from", "salt", "earn", " last", "near", "form"};
            Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            */



            #endregion


        }
    }
}