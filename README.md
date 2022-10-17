# The Power Plant Project
This project was created to further demonstrate dependency injection, the usefulness of interfaces and various other C# techniques for Code Louisville.  Our strategy with this app is to rely on the Program.cs of PowerPlant.Console to orchestrate the dependencies, but let the respective services and models do the work 
 
 ## What the app is doing
Using state of the art technology, we can create widgets from electricity. Our first implementation uses a CoalPowerPlant to generate power and store generated energy into an energy store. Our WidgetManufacturingPlant withdraws energy from the energy store to create widgets. The DaySimulator simulates days and hours, generating power every hour, and generating widgets as long as there is enough power to do so. 
 
 ## V1 Concepts
**Examples of dependency injection can be observed throughout the app:**
- **Constructor Dependency Injection:** CoalPowerPlant is dependent on an IDepositEnergy interface.
- **Constructor Dependency Injection:**  WidgetManufacturingPlant is dependent on an IEnergyProvider interface
- **Constructor Dependency Injection:**  DaysSimulator is dependent on an IPowerPlant and IManufacturingPlantInterface
- **Constructor Dependency Injection:** WidgetCollectionConsoleReporter.cs is dependent on IEnumerable interface. 


**Other C# Concepts:**
 - PowerPlant.Core.Manufacturing.Extensions.QualityExtensions is an extension method that extends the functionality of the Quality enum to generate a pseudo-random
   quality value based on arbitrary weights of quality
 - PowerPlant.Core.Manufacturing.Extensions.QualityExtensions contains a private static Random used by the SimulateRandomProductionQuality method to generate random integers
 - PowerPlant.Core.Power.Exceptions.OutOfPowerException is an example of creating a custom exception
 - Various examples of null coalescing and defensive guarding against null values
 -- Ex: !powerDaysOff?.Contains(day.DayOfWeek) ?? false
 - WidgetCollectionCOnsoleReporter.WriteQualitySummary contains an example of using a LINQ group by statement and transforming the result into a flattened summary model.

