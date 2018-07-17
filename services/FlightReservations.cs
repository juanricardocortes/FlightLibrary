using System;
using System.Collections.Generic;
using System.IO;

namespace FlightReservationLibrary {
    public class FlightReservations {
        // singleton
        private static FlightReservations FlightReservationsInstance = null;
        public static FlightReservations GetInstance {
            get {
                if (FlightReservationsInstance == null) {
                    FlightReservationsInstance = new FlightReservations ();
                }
                return FlightReservationsInstance;
            }
        }
        // Service Methods
        public bool FlightExists (ReservationModel Reservation, List<FlightModel> AllFlights) {
            foreach (FlightModel Flight in AllFlights) {
                if (Flight.strAirlineCode == Reservation.strAirlineCode && Flight.strFlightNumber == Reservation.strFlightNumber) {
                    return true;
                }
            }
            return false;
        }
        public List<FlightModel> GetMatchingFlights (List<FlightModel> AllFlights, ReservationModel Reservation) {
            List<FlightModel> FilteredFlights = new List<FlightModel> ();
            foreach (FlightModel Flight in AllFlights) {
                if (Flight.strFlightNumber == Reservation.strFlightNumber && Flight.strAirlineCode == Reservation.strAirlineCode) {
                    FilteredFlights.Add (Flight);
                }
            }
            return FilteredFlights;
        }
        public ReservationModel AddReservation (ReservationModel Reservation) {
            Reservation.strPNR = Utilities.GeneratePNR ();
            Reservation.strAge = Utilities.GetAge (DateTime.Parse (Reservation.strBirthday));
            string newFileName = (@"C:\Users\jcortes\Desktop\FlightReservations\src\main\savedfiles\ReservedFlights.csv");
            string ReservationDetails =
                Reservation.strAirlineCode + "," +
                Reservation.strFlightNumber + "," +
                Reservation.strDepartureStation + "," +
                Reservation.strArrivalStation + "," +
                Reservation.strSTA + "," +
                Reservation.strSTD + "," +
                Reservation.strFlightDate + "," +
                Reservation.strPNR + "," +
                Reservation.strFirstName + "," +
                Reservation.strLastName + "," +
                Reservation.strBirthday + "," +
                Reservation.strAge +
                Environment.NewLine;
            if (!File.Exists (newFileName)) {
                string ReservationHeader =
                    "Airline Code" + "," +
                    "Flight Number" + "," +
                    "Departure Station" + "," +
                    "Arrival Station" + "," +
                    "STA" + "," +
                    "STD" + "," +
                    "Flight Date" + "," +
                    "PNR" + "," +
                    "First Name" + "," +
                    "Last Name" + "," +
                    "Birthday" + "," +
                    "Age" +
                    Environment.NewLine;
                File.WriteAllText (newFileName, ReservationHeader);
            }
            File.AppendAllText (newFileName, ReservationDetails);
            return Reservation;
        }
        public ReservationModel ReserveFlight (ReservationModel Reservation, FlightModel Flight) {
            Reservation.strArrivalStation = Flight.strArrivalStation;
            Reservation.strDepartureStation = Flight.strDepartureStation;
            Reservation.strSTA = Flight.strSTA;
            Reservation.strSTD = Flight.strSTD;
            return Reservation;
        }
        public List<ReservationModel> GetFlightReservations () {
            List<ReservationModel> ReservationsList = new List<ReservationModel> ();
            try {
                string line = null;
                using (StreamReader reader = File.OpenText (@"C:\Users\jcortes\Desktop\FlightReservations\src\main\savedfiles\ReservedFlights.csv")) {
                    while ((line = reader.ReadLine ()) != null) {
                        var values = line.Split (',');
                        if (!(values[0] == "Airline Code")) {
                            ReservationModel Reservation = new ReservationModel (values[0], values[1], values[2], values[3], values[5], values[4], values[6], values[7], values[8], values[9], values[10], values[11]);
                            ReservationsList.Add (Reservation);
                        }

                    }
                }
            } catch (Exception) {
                //do something.
            }
            return ReservationsList;
        }
        public ReservationModel SearchByPNR (string PNR, List<ReservationModel> ReservationsList) {
            ReservationModel MatchingReservation = new ReservationModel ();
            foreach(ReservationModel Reservation in ReservationsList) {
                if (Reservation.strPNR == PNR) {
                    MatchingReservation = Reservation;
                }
            }
            return MatchingReservation;
        }
    }
}