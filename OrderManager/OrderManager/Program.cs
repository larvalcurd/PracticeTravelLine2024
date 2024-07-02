using System;

internal class Program
{
    private static bool isOrderCorrect = false;
    private static DateTime currentDate = DateTime.Now;
    private static DateTime deliveryDate = currentDate.AddDays( 3 );
    private static string productName;
    private static int productQuantity;
    private static string deliveryAddress;
    private static string ordererName;

    private static void Main( string[] args )
    {

        while ( !isOrderCorrect )
        {
            GetOrderData();
            CheckOrderData();
        }

        Console.WriteLine( $"Your order of {productQuantity} {productName} will be delivered to {deliveryAddress} on {deliveryDate.ToString( "dd MMMM yyyy" )}" );
    }

    private static void GetOrderData()
    {
        Console.Write( "Enter the product name: " );
        productName = Console.ReadLine();

        while ( string.IsNullOrWhiteSpace( productName ) )
        {
            Console.WriteLine( "Incorrect input..." );
            Console.Write( "Enter the product name: " );
            productName = Console.ReadLine();
        }

        Console.Write( $"Enter the desired quantity of {productName}: " );
        string inputQuantity = Console.ReadLine();

        while ( !int.TryParse( inputQuantity, out productQuantity ) || productQuantity <= 0 )
        {
            Console.WriteLine( "incorrect input..." );
            Console.Write( "enter the desired amount of product: " );
            inputQuantity = Console.ReadLine();
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
        deliveryAddress = Console.ReadLine();

        while ( string.IsNullOrWhiteSpace( deliveryAddress ) )
        {
            Console.WriteLine( "Incorrect input..." );
            Console.Write( "Enter your desired delivery address: " );
            deliveryAddress = Console.ReadLine();
        }
    }

    private static void CheckOrderData()
    {
        Console.WriteLine( $"Hello, {ordererName}, you ordered {productQuantity} {productName} to {deliveryAddress}, is everything correct? [Y/N]" );
        string response = Console.ReadLine().ToUpper();

        while ( response.Length == 0 || response[ 0 ] != 'Y' && response[ 0 ] != 'N' )
        {
            Console.WriteLine( "Please enter Y or N." );
            response = Console.ReadLine().ToUpper();
        }

        isOrderCorrect = response[ 0 ] == 'Y';
    }
}

