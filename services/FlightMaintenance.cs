using System;
using System.Collections.Generic;
using System.IO;

namespace FlightReservationLibrary {
    public class FlightMaintenance {

        // Singleton
        private static FlightMaintenance FlightMaintenanceInstance = null;
        public static FlightMaintenance GetInstance {
            get {
                if (FlightMaintenanceInstance == null) {
                    FlightMaintenanceInstance = new FlightMaintenance ();
                }
                return FlightMaintenanceInstance;
            }
        }
        private FlightMaintenance () { }
        // Flight Maintenance Methods
        public List<FlightModel> GetAllFlights () {
            List<FlightModel> FlightList = new List<FlightModel> ();
            try {
                string line = null;
                using (StreamReader reader = File.OpenText (@"C:\Users\jcortes\Desktop\FlightReservations\src\main\savedfiles\SavedFlights.csv")) {
                    while ((line = reader.ReadLine ()) != null) {
                        var values = line.Split (',');
                        FlightModel flight = new FlightModel (values[0], values[1], values[3], values[2], values[4], values[5]);
                        FlightList.Add (flight);
                    }
                }
            } catch (Exception e) {
                //do something.
            }

            return FlightList;
        }
        public void AddFlight (FlightModel flight) {
            string newFileName = (@"C:\Users\jcortes\Desktop\FlightReservations\src\main\savedfiles\SavedFlights.csv");
            string clientDetails = flight.strAirlineCode + "," +
                flight.strFlightNumber + "," +
                flight.strDepartureStation + "," +
                flight.strArrivalStation + "," +
                flight.strSTA + "," +
                flight.strSTD +
                Environment.NewLine;
            if (!File.Exists (newFileName)) {
                string clientHeader = "Airline Code" + "," + "Flight Number" + "," + "Departure Station" + "," + "Arrival Station" + "," + "STA" + "," + "STD" + Environment.NewLine;
                File.WriteAllText (newFileName, clientHeader);
            }
            File.AppendAllText (newFileName, clientDetails);
        }
        public List<FlightModel> SearchFlight (string FilterBy, List<FlightModel> FlightList, string SearchBy) {
            List<FlightModel> FilteredFlightList = new List<FlightModel> ();
            foreach (FlightModel Flight in FlightList) {
                if (SearchBy == "FlightNumber" && FilterBy == Flight.strFlightNumber) {
                    FilteredFlightList.Add (Flight);
                }
                if (SearchBy == "AirlineCode" && FilterBy == Flight.strAirlineCode) {
                    FilteredFlightList.Add (Flight);
                }
                if (SearchBy == "OriginDestination" && FilterBy == Flight.strDepartureStation + Flight.strArrivalStation) {
                    FilteredFlightList.Add (Flight);
                }
            }
            return FilteredFlightList;
        }
        public bool FlightExists (ReservationModel Reservation, List<FlightModel> AllFlights) {
            foreach(FlightModel Flight in AllFlights) {
                if(Flight.strAirlineCode == Reservation.strAirlineCode && Flight.strFlightNumber == Reservation.strFlightNumber) {
                    return true;
                }
            }
            return false;
        }
    }
}