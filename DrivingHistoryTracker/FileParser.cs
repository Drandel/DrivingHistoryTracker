using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrivingHistoryTracker
{
    public static class FileParser
    {
        /// <summary>
        /// Parses <see cref="Driver"/> information out of driving data.
        /// </summary>
        /// <param name="drivingData">A list of strings containing Driver and Trip information.</param>
        /// <returns>A list of strings containing only <see cref="Driver"/> information.</returns>
        public static List<Driver> ParseDriverData(string[] data)
        {
            List<string> driversRaw = data.Where(x => x.Split(" ")[0] == "Driver").ToList();
            return driversRaw.Select(d => new Driver(d.Split(" ")[1])).ToList();
        }

        /// <summary>
        /// Parses <see cref="Trip"/> information out of driving data.
        /// </summary>
        /// <param name="drivingData">A list of strings containing Driver and Trip information.</param>
        /// <returns>A list of strings containing only <see cref="Trip"/> information.</returns>
        public static List<Trip> ParseTripData(string[] data)
        {
            List<string> tripsRaw = data.Where(x => x.Split(" ")[0] == "Trip").ToList();
            return tripsRaw.Select(t =>
                new Trip(
                    t.Split(" ")[1],
                    t.Split(" ")[2],
                    t.Split(" ")[3],
                    t.Split(" ")[4])
                ).ToList();
        }
    }
}
