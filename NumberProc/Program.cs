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

    public NumberProc(IEnumerable<int> initialNumbers)
    {
        _numbers = new List<int>(initialNumbers);
    }

    public NumberProc Add(int value)
    {
        _numbers = _numbers.Select(num => num + value);
        return this;
    }

    public NumberProc Sub(int value)
    {
        _numbers = _numbers.Select(num => num - value);
        return this;
    }

    public NumberProc Div(int value)
    {
        _numbers = _numbers.Select(num => num / value);
        return this;
    }

    public void Print()
    {
        Console.WriteLine(string.Join(", ", _numbers));
    }
}