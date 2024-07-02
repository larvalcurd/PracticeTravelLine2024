using System;

internal class Program
{
    private static bool isOrderCorrect = false;
    private static DateTime currentDate = DateTime.Now;
    private static DateTime deliveryDate = currentDate.AddDays( 3 );
    private static string product;
    private static string ordererAddress;
    private static string ordererName;
    private static int count;

    private static void Main( string[] args )
    {

        while ( !isOrderCorrect )
        {
            GetOrderData();
            CheckOrderData();
        }

        Console.WriteLine( $"Your order of {count} {product} will be delivered to {ordererAddress} on {deliveryDate.ToString( "dd mmm yyyy" )}" );
    }

    private static void GetOrderData()
    {
        Console.Write( "Enter the product name: " );
        product = Console.ReadLine();

        while ( string.IsNullOrWhiteSpace( product ) )
        {
            Console.WriteLine( "Incorrect input..." );
            Console.Write( "Enter the product name: " );
            product = Console.ReadLine();
        }

        Console.Write( $"Enter the desired amount of {product}: " );
        string inputCount = Console.ReadLine();

        while ( !int.TryParse( inputCount, out count ) || count <= 0 )
        {
            Console.WriteLine( "incorrect input..." );
            Console.Write( "enter the desired amount of product: " );
            inputCount = Console.ReadLine();
        }

        Console.Write( "Enter your name: " );
        ordererName = Console.ReadLine();

        while ( string.IsNullOrWhiteSpace( ordererName ) )
        {
            Console.WriteLine( "Incorrect input..." );
            Console.Write( "Enter your name: " );
            ordererName = Console.ReadLine();
        }

        Console.Write( "Enter your desired delivery address: " );
        ordererAddress = Console.ReadLine();

        while ( string.IsNullOrWhiteSpace( ordererName ) )
        {
            Console.WriteLine( "Incorrect input..." );
            Console.Write( "Enter your desired delivery address: " );
            ordererAddress = Console.ReadLine();
        }
    }

    private static void CheckOrderData()
    {
        Console.WriteLine( $"Hello, {ordererName}, you ordered {count} {product} to {ordererAddress}, is everything correct? [Y/N]" );
        string response = Console.ReadLine().ToUpper();

        while ( response.Length == 0 || response[ 0 ] != 'Y' && response[ 0 ] != 'N' )
        {
            Console.WriteLine( "Please enter Y or N." );
            response = Console.ReadLine().ToUpper();
        }

        isOrderCorrect = response[ 0 ] == 'Y';
    }
}

