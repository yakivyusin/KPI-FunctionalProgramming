namespace FSharpModule

type DiskType =
    | MMC of NumberOfPins: int
    | HardDisk of Rpm: int * Platters: int
    | SolidState

type Disk =
    { Manufacturer: string
      ManufacturingDate: System.DateOnly
      Dimensions: decimal * decimal * decimal
      DiskType: DiskType }

module Functions =
    let defaultDisk =
        { Manufacturer = "Default"
          ManufacturingDate = System.DateOnly.MinValue
          Dimensions = (1.0m, 1.0m, 1.0m)
          DiskType = HardDisk (7200, 7) }

    let getDiskVolume { Dimensions = (x, y, z) } = x * y * z

    let create manufacturer date dimensions diskType =
        { Manufacturer = manufacturer
          ManufacturingDate = date
          Dimensions = dimensions
          DiskType = diskType }

    let createWesternDigital = create "Western Digital"

type Disk with
    member this.Volume = Functions.getDiskVolume this
    member this.IsSlowerThan other =
        match (this.DiskType, other.DiskType) with
        | (HardDisk (rpm1, _), HardDisk (rpm2, _)) -> rpm1 < rpm2
        | (HardDisk _, _) -> true
        | (MMC _, _) -> false
        | (SolidState, _) -> false
