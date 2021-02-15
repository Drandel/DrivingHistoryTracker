using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrivingHistoryTracker
{
    public class Driver
    {
        public string Name { get; set; }
        public double TotalMilesDriven { get; set; }
        public double TotalDrivingTime { get; set; }
        private List<Trip> _Trips { get; set; }
        public List<Trip> Trips
        {
            get { return _Trips; }
            set { 
                    _Trips = value; 
                    PurgeTrips();
                    GetTotalMilesDriven();
                    GetTotalTimeDriving();
            }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="Driver"/>.
        /// </summary>
        /// <param name="name">Driver's name</param>
        public Driver(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Calculates average speed of all the <see cref="Driver"/>'s <see cref="Trip"/>s.
        /// </summary>
        /// <returns>Average speed of all the <see cref="Driver"/>'s <see cref="Trip"/>s.</returns>
        public double GetAverageSpeed()
        {
            return TotalMilesDriven / TotalDrivingTime;
        }

        /// <summary>
        /// Remove any <see cref="Trip"/>s that have an AverageSpeed of less than 5 mph or greater than 100 mph.
        /// </summary>
        private void PurgeTrips()
        {
            _Trips.RemoveAll(t => t.TripSpeed > 100 || t.TripSpeed < 5);
        }

        /// <summary>
        /// Updates the TotalMilesDriven property with the sum of all <see cref="Trip"/> distances.
        /// </summary>
        private void GetTotalMilesDriven()
        {
            double totalMilesDriven = 0;
            foreach (Trip trip in _Trips)
            {
                totalMilesDriven += trip.MilesDriven;
            }
            TotalMilesDriven = totalMilesDriven;
        }

        /// <summary>
        /// Updates the TotalDrivingTime property with the sum of all <see cref="Trip"/> durations.
        /// </summary>
        private void GetTotalTimeDriving()
        {
            if(_Trips.Count() > 0)
            {
                TotalDrivingTime  = _Trips.Select(t => t.TripDuration).Sum();
            }
        }
    }
}
