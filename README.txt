            DRIVING HISTORY TRACKER
            -----------------------

                    Classes:
                   ----------
        |------------------------------|
        |            Driver            |
        |------------------------------|
        | Name:                 string |
        | TotalMilesDriven:     double |
        | TotalDrivingTime:     double |
        | Trips:             ListTrip> |
        |------------------------------|
        | PurgeTrips()                 |
        | GetTotalMilesDriven()        |
        | GetTotalTimeDriving()        |
        | GetAverageSpeed()            |
        |------------------------------|


        |------------------------------|
        |            Trip              |
        |------------------------------|
        | DriverName:           string |
        | TripStart:            string |
        | TripEnd:              string |
        | MilesDriven:          double |
        | TripSpeed:            double |
        | TripDuration:         double |
        |------------------------------|
        | GetTripSpeed()               |
        | GetTripDuration()            |
        |------------------------------|


        |------------------------------|
        |    DrivingReportGenerator    |
        |------------------------------|
        | DrivingData:        string[] |
        | Drivers:        List<Driver> |
        |------------------------------|
        | MatchTripsToDrivers()        |
        | SortDrivers()                |
        | GenerateReport()             |
        | Round()                      |
        |------------------------------|


        |------------------------------|
        |          FileParser          |
        |------------------------------|
        | ParseDriverData()            |
        | ParseTripData()              |
        |------------------------------|

                Design Reasoning:
               -------------------
The formatting of the space delimited text file lent itself easily 
to an object oriented paradigm. The two critical "objects" of the 
text file were Drivers and Trips, which I modeled the main classes after. I 
decided  to organize the Trips as a property of the Driver class so that when 
the  calculations for TotalMilesDriven and TotalDrivingTime occured, the Trips 
would already be correlated to their respective Drivers. This allowed for 
a quick LINQ query to derive those desired values. 

I used LINQ for most of my iterative operations because of its readability and
maintainability. I understand that using vanilla for/foreach operations are more 
efficient and introduce less overhead in their calculations; however, given 
the scope of this project, I favored the brevity and readability of the LINQ 
expressions.

I used a backing value for the Trips property of the Driver class so that 
I could create a pseudo "property binding" functionality. Any time the Trips 
property is updated, all dependent properties are also updated to include the new
data. This gives the object model more flexibility. For example: if more trips  
needed to be added in a later stage of execution, the Driver's TotalDrivingTime 
and TotalMilesDriven would be updated as soon as the new Trips were added.

I abstracted the FileParser into it's own class for two reasons. First was to 
allow for the functionality of the parser to be extended if there were to be 
a new entry type that would also need to be parsed (accident, claim etc). Second 
was to maintain the separation of concerns.

The last class I created was the DrivingReportGenerator. I felt it was prudent 
to abstract this functionality into it's own class so that it could readily serve 
other endpoints sould the need arise.

My strategy for testing was to cover as many possible breaking points in the app
as possible. Thorough testing ensures proper functionality as well as providing a 
safety net for future developers.