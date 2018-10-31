using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject
{
    class Program
    {
        public static AirlineCoordinator ac;

        static void showMenu()
        {
            Console.Clear();
            Console.WriteLine("XYZ Airines Limited.\nPlease select a choice from the menu below:\n");
            Console.WriteLine("1: Add Flight\n2: Add Customer\n3: View Flights\n4: View Customers" +
                "\n5: Delete Customer\n6: Delete Flight\n7: Add Booking\n8: View Bookings\n9: Exit");
        }

        static int chooseOption()
        {
            int choice;
            showMenu();
            while(!int.TryParse(Console.ReadLine(),out choice) || choice<1 || choice>9)
            {
                showMenu();
                Console.WriteLine("Please enter a valid option from the menu above!");
            }
            return choice;
        }

        static int validateInt(string prompt) //function will validate correct integer input
        {
            Console.Write(prompt);
            int input;
            while(!int.TryParse(Console.ReadLine(),out input))
            {
                Console.Write("Please enter valid number: ");
            }
            return input;
        }

        static string validateString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input) == true)
            {
                Console.Write("Enter a valid input: ");
                input = Console.ReadLine();
            }
            return input;
        }

        static void addFlight()
        {
            Console.Clear();
            Console.WriteLine("----------Add flight----------");
            
            int flightNum = validateInt("Please enter the flight number:");
            int maxSeats = validateInt("Please enter the maximum number of seats:");
            string origin = validateString("Please enter the port of origin:");
            string destination = validateString("Please enter the port of destination:");

            ac.addFlight(flightNum, origin, destination, maxSeats);
            Console.WriteLine("Flight successfully added..");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
        }

        static void viewFlight()
        {
            Console.Clear();
            Console.WriteLine(ac.flightList());
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void viewCustomers()
        {
            Console.Clear();
            Console.WriteLine(ac.customerList());
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void addCustomer()
        {
            Console.Clear();
            Console.WriteLine("----------Add Customer----------");
            string fName = validateString("Please enter the customer's first name:");
            string lName = validateString("Please enter the customer's last name:");
            string phone = validateString("Please enter the customer's phone:");

            if(ac.addCustomer(fName,lName,phone))
                Console.WriteLine("Customer successfully added..");
            else
                Console.WriteLine("Customer was not added..");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
        }

        static void deleteCustomer()
        {
            Console.Clear();
            Console.WriteLine(ac.customerList());
            int cId = validateInt("Please enter a customer id to delete:");
            if(ac.deleteCustomer(cId))
                Console.WriteLine("Customer with id {0} deleted",cId);
            else
                Console.WriteLine("Customer with id {0} was not found",cId);

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
        }

        static void deleteFlight()
        {
            Console.Clear();
            Console.WriteLine(ac.flightList());
            int fId = validateInt("Please enter a flight id to delete:");
            if (ac.deleteFlight(fId))
                Console.WriteLine("Flight with id {0} deleted", fId);
            else
                Console.WriteLine("Flight with id {0} was not found", fId);

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();

        }

        static void addBooking()
        {
            Console.Clear();
            Console.WriteLine(ac.customerList());
            Console.WriteLine(ac.flightList());
            int cId = validateInt("Please enter customer ID: ");
            int fId = validateInt("Please enter flight ID: ");
            if(ac.addBooking(cId,fId))
                Console.WriteLine("Customer {0} has been added to flight {1}!",cId,fId);
            else
                Console.WriteLine("Booking was unsuccessful!");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
        }

        static void viewBooking()
        {
            Console.Clear();
            Console.WriteLine(ac.viewBookings());
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            ac = new AirlineCoordinator(100, 50, 10, 1000, 1000);

            int choice = chooseOption();
            while(choice != 9)

            {
                if (choice == 1) { addFlight(); }
                if (choice == 2) { addCustomer(); }
                if (choice == 3) { viewFlight(); }
                if (choice == 4) { viewCustomers(); }
                if (choice == 5) { deleteCustomer(); }
                if (choice == 6) { deleteFlight(); }
                if (choice == 7) { addBooking(); }
                if (choice == 8) { viewBooking(); }
                choice = chooseOption();
            }
            Console.Clear();
            Console.WriteLine("Have a nice day!");

            Console.ReadKey();
        }
    }
}
