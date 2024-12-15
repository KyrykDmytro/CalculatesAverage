namespace Program_calculates_average
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The program calculates the average\nof the numbers. To finish entering \nnumbers, press ENTER." +
                "To start a new\ncalculation, press any button\n");
            while (true)
            {
                List<double> listNumbers = new List<double>();
                Console.WriteLine("======================================================Average===========================================================");

                while (true)
                {
                    Console.Write("Enter the following number:");
                    var valueFromConsole = Console.ReadLine();
                    if (valueFromConsole == "") break;
                    double Number = 0;
                    try
                    {
                        Number = double.Parse(valueFromConsole);
                    }
                    catch
                    {
                        Console.WriteLine("The entered value is not a number\n");
                        continue;
                    }
                    listNumbers.Add(Number);

                    Console.Write("List: ");
                    foreach (var item in listNumbers)
                    {
                        Console.Write("{0} ", item);
                    }
                    Console.WriteLine("\n");
                }

                int n = listNumbers.Count();
                double sum = 0;
                foreach (var item in listNumbers)
                    sum += item;

                Console.WriteLine("Results: {0}\n", sum / n);
                Console.ReadKey();
            }
        }
    }
}