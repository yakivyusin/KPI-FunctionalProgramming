using FSharpModule;

var disk1 = new Disk(
    "Toshiba",
    new DateOnly(2024, 1, 1),
    (1.0m, 1.0m, 1.0m).ToTuple(), // старі кортежі - System.Tuple, нові - System.ValueTuple
    DiskType.NewMMC(10));

// fail: disk1.Manufacturer = "Western Digital";

Console.WriteLine(disk1);

var disk2 = new Disk(
    "Western Digital",
    new DateOnly(2023, 1, 1),
    Tuple.Create(0.25m, 0.5m, 0.25m),
    DiskType.SolidState);

Console.WriteLine($"disk1 = disk2: {disk1.Equals(disk2)}");

Console.WriteLine($"Volume: {disk2.Volume} cm^3");
Console.WriteLine($"disk1 is slower than disk2: {disk1.IsSlowerThan(disk2)}");

/*
 * Для роботи із об'єднаннями можна використовувати як властивості, так і зіставлення зі зразком.
 */

Console.WriteLine($"disk2 is Solid State: {disk2.DiskType.IsSolidState}");

var disk1Type = disk1.DiskType switch
{
    DiskType.MMC _ => "MMC",
    DiskType.HardDisk _ => "HDD",
    _ => "Solid State"
};

Console.WriteLine($"disk1 is {disk1Type}");

/*
 * Звичайні функції із модуля легко перетворюються на методи.
 * Виключення - частково застосовані функції.
 */
var disk3 = Functions.create(
    "Seagate",
    new DateOnly(2022, 1, 1),
    0.5m,
    0.2m,
    0.1m,
    DiskType.NewHardDisk(5400, 5));

var disk4 = Functions.createWesternDigital
    .Invoke(new DateOnly(2021, 1, 1))
    .Invoke(Tuple.Create(1.0m, 1.0m, 0.5m))
    .Invoke(DiskType.SolidState);

Console.WriteLine(disk3);
Console.WriteLine(disk4);
