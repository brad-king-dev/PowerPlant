using PowerPlant.Core.Manufacturing;
using PowerPlant.Core.Models;
using PowerPlant.Core.Power;
using PowerPlant.Core.TimeSimulation;

var energyStore = new ThermalEnergyStorage();
var powerPlant = new CoalPowerPlant(energyStore);
var widgetPlant = new WidgetManufacturingPlant(energyStore);

var daySimulator = new DaySimulator(powerPlant, widgetPlant);

var createdWidgets = daySimulator.SimulateProductionForDays(
    forDays: 30,
    manufacturingDaysOff: new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday},
    powerDaysOff: new List<DayOfWeek>());

Console.WriteLine("_________________________________________________________________");
var consoleReporter = new WidgetCollectionConsoleReporter(createdWidgets);
consoleReporter.WriteTotal();
consoleReporter.WriteQualitySummary();
Console.WriteLine("_________________________________________________________________");


Console.ReadLine();