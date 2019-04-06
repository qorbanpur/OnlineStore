using BusinessLayer;
using System;
using System.Globalization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For claculate you order, please specify");

            var amount = GetNumberOfBicycles();
            var unitPrice = GetUnitPrice();
            var stateCode = GetStateCode();

            Console.WriteLine();

            var order = new Order(amount, unitPrice, stateCode);

            Console.WriteLine("Raw Value: " + order.RawValue.ToString("0,0", CultureInfo.InvariantCulture));
            Console.WriteLine("Discount Rate: " + order.GetDiscountPercentage().ToString("%#0.00", CultureInfo.InvariantCulture));
            Console.WriteLine("Tax Rate: " + Helper.TaxRates[stateCode].ToString("%#0.00", CultureInfo.InvariantCulture));
            Console.WriteLine("Total Price: " + order.GetTotalPrice().ToString("0,0", CultureInfo.InvariantCulture));

            Console.WriteLine("************");
            Console.WriteLine();
            Console.Write("Continue with next order (Y/N)? ");

            if (Console.ReadLine().ToUpperInvariant() == "Y")
            {
                Console.WriteLine();

                Main(null);
            }
        }

        static long GetNumberOfBicycles()
        {
            Console.Write("The number of bicycles: ");

            long result = 0;

            try
            {
                result = long.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString()); To be displayed in development environment; after adding necessary configs.
                Console.WriteLine("Please specify the number in correct format");

                result = GetNumberOfBicycles();
            }

            return result;
        }

        static long GetUnitPrice()
        {
            Console.Write("The price per bicycle: ");

            long result = 0;

            try
            {
                result = long.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString()); To be displayed in development environment; after adding necessary configs.
                Console.WriteLine("Please specify the unit price in correct format");

                result = GetUnitPrice();
            }

            return result;
        }

        static StateEnum GetStateCode()
        {
            Console.Write($"The state code ({string.Join(" / ", Enum.GetNames(typeof(StateEnum)))}): ");

            StateEnum result;
            
            try
            {
                result = Enum.Parse<StateEnum>(Console.ReadLine(), true);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString()); To be displayed in development environment; after adding necessary configs.
                Console.WriteLine("Please specify the state code in correct format.");

                result = GetStateCode();
            }

            if (!Enum.IsDefined(typeof(StateEnum), result))
            {
                //Console.WriteLine(ex.ToString()); To be displayed in development environment; after adding necessary configs.
                Console.WriteLine("Please specify the state code in correct format.");

                result = GetStateCode();
            }

            return result;
        }
    }
}