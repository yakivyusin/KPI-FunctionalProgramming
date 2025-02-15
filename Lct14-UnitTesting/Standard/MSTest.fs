namespace global

open ModuleUnderTest
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type MSTestTests () =

    [<TestMethod>]
    member _.isLargeAndYoungTeam_TeamIsLargeAndYoung_ReturnsTrue () =
        let department =
            { Name = "Super Team"
              Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

        Assert.IsTrue(department |> isLargeAndYoungTeam)

    [<TestMethod>]
    member _.``Large, young teams are correctly identified`` () =
        let department =
            { Name = "Super Team"
              Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

        Assert.IsTrue(department |> isLargeAndYoungTeam)

    [<TestMethod>]
    [<DataRow(11)>]
    [<DataRow(12)>]
    [<DataRow(20)>]
    member _.``Large teams with various size are correctly identified`` size =
        let department =
            { Name = "Super Team"
              Team = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ] }

        Assert.IsTrue(department |> isLargeDepartment)

    [<TestMethod>]
    [<DynamicData("generateSmallTeams", DynamicDataSourceType.Method)>]
    member _.``Small teams with various size are correctly identified`` team =
        let department =
            { Name = "Super Team"
              Team = team }

        Assert.IsFalse(department |> isLargeDepartment)

    static member generateSmallTeams () = seq {
        let generateTeamWithSpecifiedSize size = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ]

        yield [| generateTeamWithSpecifiedSize 1 |]
        yield [| generateTeamWithSpecifiedSize 9 |]
        yield [| generateTeamWithSpecifiedSize 10 |]
    }
