namespace FlightReservationLibrary {
    public class ReservationModel : FlightModel {
        public ReservationModel (string airlinecode, string flightnumber, string departurestation, string arrivalstation, string std, string sta, string flightdate, string pnr, string firstname, string lastname, string birthday, string age) {
            this.strAirlineCode = airlinecode;
            this.strFlightNumber = flightnumber;
            this.strDepartureStation = departurestation;
            this.strArrivalStation = arrivalstation;
            this.strSTD = std;
            this.strSTA = sta;
            this.strFlightDate = flightdate;
            this.strPNR = pnr;
            this.strFirstName = firstname;
            this.strLastName = lastname;
            this.strBirthday = birthday;
            this.strAge = age;
        }
        public string strBirthday { get; set; }
        public string strLastName { get; set; }
        public string strFirstName { get; set; }
        public string strFlightDate { get; set; }
        public string strPNR { get; set; }
        public string strAge { get; set; }
        public ReservationModel () {

        }
    }
}