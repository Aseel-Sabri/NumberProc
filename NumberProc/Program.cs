int[] array = { 1, 2, 3 };
var numberProc = new NumberProc(array);

numberProc
    .Add(3)
    .Sub(2)
    .Div(2);

numberProc.Print();


public class NumberProc
{
    private IEnumerable<int> _numbers;
    private readonly List<Func<int, int>> _operations = new();

    public NumberProc(IEnumerable<int> initialNumbers)
    {
        _numbers = new List<int>(initialNumbers);
    }

    public NumberProc Add(int value)
    {
        _operations.Add(x => x + value);
        return this;
    }

    public NumberProc Sub(int value)
    {
        _operations.Add(x => x - value);
        return this;
    }

    public NumberProc Div(int value)
    {
        _operations.Add(x => x / value);
        return this;
    }

    public void Print()
    {
        _numbers = _numbers.Select(x => _operations.Aggregate(x, (current, operation) => operation(current))).ToList();
        _operations.Clear();
        Console.WriteLine(string.Join(", ", _numbers));
    }
}