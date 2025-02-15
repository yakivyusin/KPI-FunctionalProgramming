module xUnitTests

open ModuleUnderTest
open Xunit

[<Fact>]
let isLargeAndYoungTeam_TeamIsLargeAndYoung_ReturnsTrue () =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.True(department |> isLargeAndYoungTeam)

[<Fact>]
let ``Large, young teams are correctly identified`` () =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.True(department |> isLargeAndYoungTeam)

[<Theory>]
[<InlineData(11)>]
[<InlineData(12)>]
[<InlineData(20)>]
let ``Large teams with various size are correctly identified`` size =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.True(department |> isLargeDepartment)

[<Theory>]
[<MemberData("generateSmallTeams")>]
let ``Small teams with various size are correctly identified`` team =
    let department =
        { Name = "Super Team"
          Team = team }

    Assert.False(department |> isLargeDepartment)

let generateSmallTeams () = seq {
    let generateTeamWithSpecifiedSize size = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ]

    yield [| generateTeamWithSpecifiedSize 1 |]
    yield [| generateTeamWithSpecifiedSize 9 |]
    yield [| generateTeamWithSpecifiedSize 10 |]
}
