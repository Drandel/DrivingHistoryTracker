using System;

namespace DrivingHistoryTracker
{
    public class Trip
    {
        public string DriverName { get; set; }
        public string TripStart { get; set; }
        public string TripEnd { get; set; }
        public double MilesDriven { get; set; }
        public double TripSpeed { get; set; }
        public double TripDuration { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="Trip"/>
        /// </summary>
        /// <param name="driverName">Driver's name.</param>
        /// <param name="tripStart">Time at the start of the Trip.</param>
        /// <param name="tripEnd">Time at the end of the Trip.</param>
        /// <param name="milesDriven">Number of miles driven during the Trip.</param>
        public Trip(string driverName, string tripStart, string tripEnd, string milesDriven)
        {
            DriverName = driverName;
            TripStart = tripStart;
            TripEnd = tripEnd;
            MilesDriven = Double.Parse(milesDriven);
            TripSpeed = GetTripSpeed(TripStart, TripEnd, MilesDriven);
            TripDuration = GetTripDuration(TripStart, TripEnd);
        }

        /// <summary>
        /// Calculates the speed of a Trip.
        /// </summary>
        /// <param name="start">Time at the start of the Trip.</param>
        /// <param name="end">Time at the end of the Trip.</param>
        /// <param name="milesDriven">Number of miles driven during the Trip.</param>
        /// <returns>Speed of the Trip.</returns>
        private double GetTripSpeed(string start, string end, double milesDriven)
        {
            TimeSpan duration = DateTime.Parse(end).Subtract(DateTime.Parse(start));
            return milesDriven / duration.TotalHours;
        }

        /// <summary>
        /// Calculates the duration of a trip in hours.
        /// </summary>
        /// <param name="start">Time at the start of a Trip.</param>
        /// <param name="end">Time at the end of a Trip.</param>
        /// <returns>Duration of a Trip.</returns>
        private double GetTripDuration(string start, string end)
        {
            TimeSpan duration = DateTime.Parse(end).Subtract(DateTime.Parse(start));
            return duration.TotalHours;
        }
    }
}
