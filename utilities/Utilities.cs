using System;
using System.Linq;

namespace FlightReservationLibrary {
    public class Utilities {
        private static Random random = new Random ();
        public static string GeneratePNR () {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string firstchar = new string (Enumerable.Repeat (chars, 1)
                .Select (s => s[random.Next (s.Length)]).ToArray ());
            chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string nextchar = new string (Enumerable.Repeat (chars, 5)
                .Select (s => s[random.Next (s.Length)]).ToArray ());
            return firstchar + nextchar;
        }
        public static string GetAge (DateTime birthday) {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears (age)) age--;

            return age.ToString ();
        }
    }
}