#region First class functions

var helloWorld = () => WriteLine("Hello World!");
var helloName = () => WriteLine($"Hello, {ReadLine()}!");
var multicast = helloWorld + helloName;

WritePrompt("Run helloWorld and helloName separately");

helloWorld();
helloName();

WritePrompt("Run composition from multicast delegate");

multicast();

multicast -= helloName;

WritePrompt("Run updated multicast delegate");

multicast();

#endregion

#region Higher-order functions

static T ReceiveFunction<T>(Func<T> func) => func();
static Func<T> ReturnFunction<T>(T value) => () => value;

WritePrompt("Run higher-order functions");
WriteLine(ReceiveFunction(ReturnFunction(10)));

#endregion

#region Immutability

const int immutableVariable = 10; // local constant in C#
var immutableRecord = new ImmutableRecord(immutableVariable, "Peter"); // records have 'init' properties by default

/* This will cause compile errors */
// immutableVariable = 20;
// rec.A += 10;
// rec.B = "Vasya";

WritePrompt("Dumps");

WriteLine(immutableRecord);
WriteLine(immutableRecord with { A = immutableRecord.A + 10 });

#endregion

#region Expressions over statements

var cond = RandomNumberGenerator.GetInt32(2) == 1;

/* Statements: if */
int result = 0;
if (cond)
{
    result = 10;
}
WriteLine(result);

/* Expressions: ternary operator */
WriteLine(cond ? 10 : 0);

#endregion

#region Pattern matching, recursion

/* Pattern matching */
WriteLine(cond switch
{
    true => "True",
    false => "False"
});
WriteLine(RandomNumberGenerator.GetInt32(10) switch
{
    0 => "ZERO",
    1 or 2 => "1 OR 2",
    > 2 => ">2"
});

/* Recursion + pattern matching */
static int RecursiveCount<T>(List<T> enumeration) => enumeration switch
{
    [] => 0,
    [_, .. var rest] => 1 + RecursiveCount(rest)
};

WriteLine(RecursiveCount<int>([]));
WriteLine(RecursiveCount([1]));
WriteLine(RecursiveCount([1, 2, 3]));

#endregion

static void WritePrompt(string prompt)
{
    var color = ForegroundColor;
    ForegroundColor = ConsoleColor.Green;
    WriteLine(prompt);
    ForegroundColor = color;
}

public record ImmutableRecord(int A, string B);
