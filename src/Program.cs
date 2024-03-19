System.Console.WriteLine();
System.Console.WriteLine();
System.Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("╔═════════════════════════════════╗");
Console.WriteLine("║                                 ║");
Console.WriteLine("║           WELCOME TO            ║");
Console.WriteLine("║      TEPERATURE CONVERTOR       ║");
Console.WriteLine("║                                 ║");
Console.WriteLine("╚═════════════════════════════════╝");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine();
Console.WriteLine("------------  Level 1  ------------");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Blue;
TempConvert tempF = new(32, 'f');
TempConvert tempC = new(100, 'c');
Console.WriteLine();
Console.WriteLine("32 F Converted :" + tempF.Converted());
Console.WriteLine();
Console.WriteLine("100 C Converted :" + tempC.Converted());

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine();
Console.WriteLine("------------  Level 2  ------------");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("Enter a temperature and its unit (C or F):");
Console.ForegroundColor = ConsoleColor.White;
string? inputL2 = Console.ReadLine();
string[] infoL2 = inputL2.Split(' ');
double temperatureL2 = double.Parse(infoL2[0]);
char unitL2 = Convert.ToChar(infoL2[1].ToLower());
TempConvert measureL2 = new(temperatureL2, unitL2);
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine($"{temperatureL2} {unitL2} Converted = " + measureL2.Converted());

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine();
Console.WriteLine("------------  Level 3  ------------");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("Enter a temperature and its unit (C or F), or type 'Quit' to exit:");
Console.ForegroundColor = ConsoleColor.White;
string? input = Console.ReadLine();
Console.WriteLine();
while (true)
{
    try
    {
        if (input is null || input == "" || input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PROGRAM STOPPED!");
            Console.WriteLine();
            break;
        }
        string[] info = input.Split(' ');
        string unit = Convert.ToString(info[1].ToLower());
        if (double.TryParse(info[0], out double r))
        {
            double temperature = double.Parse(info[0]);
            if (unit.ToLower() == "f" || unit.ToLower() == "c")
            {
                TempConvert.Convert(unit, temperature);
            }
            else
            {
                throw new UnsupportedException("unsupported scales");
            }
        }
        else
        {
            throw new NonNumericException("non-numeric values");
        }
    }
    catch (NonNumericException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error occurred: " + ex.Message);
        Console.WriteLine("TEPERATURE IS NUMBER ONLY!");
        Console.WriteLine();
    }
    catch (UnsupportedException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error occurred: " + ex.Message);
        Console.WriteLine("ONLY CELSIUS OR FAHRENHIET!");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error occurred: " + ex.Message);
        Console.WriteLine("PLEASE ENTER VALID VALUES!");
        Console.WriteLine();
    }
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("Enter a temperature and its unit (C or F), or type 'Quit' to exit:");
    Console.ForegroundColor = ConsoleColor.White;
    input = Console.ReadLine();
    Console.WriteLine();
    continue;
}

Console.WriteLine("------------  ------------  ------------");

class TempConvert
{
    private double temperatureAmount;
    private char measurementUnit;

    public TempConvert(double amount, char unit)
    {
        temperatureAmount = amount;
        measurementUnit = unit;
    }

    public string Converted()
    {
        double? converted;
        if (measurementUnit is 'f')
        {
            converted = Math.Round((temperatureAmount - 32) / (1.8), 2);
            return converted + " C";
        }
        else if (measurementUnit is 'c')
        {
            converted = Math.Round(((1.8) * temperatureAmount) + 32, 2);
            return converted + " F";
        }
        return "not fahrenheit nor celsius";
    }
    public static void Convert(string measurementUnit, double temperatureAmount)
    {
        double? converted;
        if (measurementUnit is "f")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            converted = Math.Round((temperatureAmount - 32) / (1.8), 2);
            Console.WriteLine($"{temperatureAmount} f Converted is : {converted} c");
            Console.WriteLine();
        }
        else if (measurementUnit is "c")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            converted = Math.Round(((1.8) * temperatureAmount) + 32, 2);
            Console.WriteLine($"{temperatureAmount} c Converted is : {converted} f");
            Console.WriteLine();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("not fahrenheit nor celsius");
            Console.WriteLine();
        }
    }
}
public class UnsupportedException : Exception
{

    public UnsupportedException()
    {

    }
    public UnsupportedException(string message) : base(message)
    {
    }

}
public class NonNumericException : Exception
{

    public NonNumericException()
    {

    }
    public NonNumericException(string message) : base(message)
    {
    }

}