using System;
using System.Collections.Generic;
using System.IO;

namespace FlightReservationLibrary
{
    public class Maintenance
    {
        public List<FlightModel> GetAllFlights () {
            List<FlightModel> flightList = new List<FlightModel> ();
            string line = null;
            using (StreamReader reader = File.OpenText (@"C:\Users\jcortes\Desktop\FlightReservations\src\main\savedfiles\SavedFlights.csv")) {
                while ((line = reader.ReadLine()) != null) {
                    var values = line.Split (',');
                    FlightModel flight = new FlightModel (values[0], values[1], values[3], values[2], values[4], values[5]);
                    flightList.Add (flight);
                }
            }
            return flightList;
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
    }
}