﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineProject
{
    class AirlineCoordinator
    {
        private FlightManager flightMan;
        private CustomerManager customMan;
        private BookingManager bookingMan;

        public AirlineCoordinator(int custIdSeed, int maxCustomers, int maxFlights, int bookingSeed, int maxBooking)
        {
            flightMan = new FlightManager(maxFlights);
            customMan = new CustomerManager(custIdSeed, maxCustomers);
            bookingMan = new BookingManager(bookingSeed, maxBooking);
        }

        public bool addFlight(int flNo, string orig, string dest, int maxSeats)
        {
            return flightMan.addFlight(flNo, orig, dest, maxSeats) ;
        }

        public bool addCustomer(string fName, string lName, string phone)
        {
            return customMan.addCustomer(fName, lName, phone);
        }

        public string flightList()
        {
            return flightMan.getFlightList();
        }

        public string customerList()
        {
            return customMan.getCustomerList();
        }

        public bool deleteCustomer(int cId)
        {
            return customMan.deleteCustomer(cId);
        }

        public bool deleteFlight(int cId)
        {
            return flightMan.deleteFlight(cId);
        }

        public bool addBooking(int custId, int flightNum)
        {
            if(!(customMan.customerExist(custId) && flightMan.flightExist(flightNum))) { return false; }

            Customer customer = customMan.getCustomer(custId);
            Flight flight = flightMan.getFlight(flightNum);

            if (!flight.addPassenger(customer)) { return false; } 
            
            return bookingMan.addBooking(customer, flight);          

        }

        public string viewBookings()
        {
            return bookingMan.getBookingList();
        }

    }
}
