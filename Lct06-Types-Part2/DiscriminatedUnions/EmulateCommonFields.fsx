(*
    Якби це у нас було ООП, то ми б мали ієрархію класів Disk <--- (MMC / SolidState / HardDisk).
    При цьому у базовому класі Disk ми могли б мати спільні поля.
    У F# об'єднання не можуть мати спільних полів.
    Вихід - використання композиції.
*)

type DiskType =
    | MMC of NumberOfPins: int
    | HardDisk of RPM: int * Platters: int
    | SolidState

type Disk =
    { Manufacturer: string
      ManufacturingDate: System.DateOnly
      DiskType: DiskType }

let myDisk =
    { Manufacturer = "Toshiba"
      ManufacturingDate = System.DateOnly (2024, 1, 1)
      DiskType = HardDisk (5400, 5) }
