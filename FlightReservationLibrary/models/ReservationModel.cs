namespace FlightReservationLibrary {
    public class ReservationModel {
        public ReservationModel (string strAirlineCode, string strFlightNumber, string strFlightDate, int intNumberOfPassengers, string strPassengerFirstName, string strPassengerLastName, string strPassengerBirthday, string strPassengerAge, string strPNRNumber) {
            this.strAirlineCode = strAirlineCode;
            this.strFlightNumber = strFlightNumber;
            this.strFlightDate = strFlightDate;
            this.intNumberOfPassengers = intNumberOfPassengers;
            this.strPassengerFirstName = strPassengerFirstName;
            this.strPassengerLastName = strPassengerLastName;
            this.strPassengerBirthday = strPassengerBirthday;
            this.strPassengerAge = strPassengerAge;
            this.strPNRNumber = strPNRNumber;
        }
        public ReservationModel () {
            
        }

        public void testFunction2 () {

        }
        public string strAirlineCode { get; set; }
        public string strFlightNumber { get; set; }
        public string strFlightDate { get; set; }
        public int intNumberOfPassengers { get; set; }
        public string strPassengerFirstName { get; set; }
        public string strPassengerLastName { get; set; }
        public string strPassengerBirthday { get; set; }
        public string strPassengerAge { get; set; }
        public string strPNRNumber { get; set; }
    }
}