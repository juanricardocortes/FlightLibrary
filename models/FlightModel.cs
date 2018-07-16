namespace FlightReservationLibrary {
    public class FlightModel {
        public FlightModel (string strAirlineCode, string strFlightNumber, string strDepartureStation, string strArrivalStation, string strSTA, string strSTD) {
            this.strAirlineCode = strAirlineCode;
            this.strFlightNumber = strFlightNumber;
            this.strDepartureStation = strDepartureStation;
            this.strArrivalStation = strArrivalStation;
            this.strSTA = strSTA;
            this.strSTD = strSTD;
        }
        public FlightModel () {

        }
        public string strAirlineCode { get; set; } 
        public string strFlightNumber { get; set; }
        public string strDepartureStation { get; set; }
        public string strArrivalStation { get; set; }
        public string strSTA { get; set; }
        public string strSTD { get; set; }
    }
}