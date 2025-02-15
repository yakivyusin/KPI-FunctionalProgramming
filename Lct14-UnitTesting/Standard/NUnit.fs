module NUnitTests

open ModuleUnderTest
open NUnit.Framework

[<Test>]
let isLargeAndYoungTeam_TeamIsLargeAndYoung_ReturnsTrue () =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.That(department |> isLargeAndYoungTeam, Is.True)

[<Test>]
let ``Large, young teams are correctly identified`` () =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..11 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.That(department |> isLargeAndYoungTeam, Is.True)

[<TestCase(11)>]
[<TestCase(12)>]
[<TestCase(20)>]
let ``Large teams with various size are correctly identified`` size =
    let department =
        { Name = "Super Team"
          Team = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ] }

    Assert.That(department |> isLargeDepartment, Is.True)

[<TestCaseSource("generateSmallTeams")>]
let ``Small teams with various size are correctly identified`` team =
    let department =
        { Name = "Super Team"
          Team = team }

    Assert.That(department |> isLargeDepartment, Is.False)

let generateSmallTeams () = seq {
    let generateTeamWithSpecifiedSize size = [ for i in 1..size -> { Name = sprintf "Person %d" i; Age = 19 } ]

    yield [| generateTeamWithSpecifiedSize 1 |]
    yield [| generateTeamWithSpecifiedSize 9 |]
    yield [| generateTeamWithSpecifiedSize 10 |]
}
