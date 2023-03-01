// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ListBenchmarkInteger>();
BenchmarkRunner.Run<ListBenchmarkString>();

[MemoryDiagnoser]
public class ListBenchmarkInteger
{
    [Params(1000, 10000)]
    public int size;

    [Benchmark(Baseline = true)]
    public void ListFillInt()
    {
        var list = new List<int>();
        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void LinkedListFillInt()
    {
        var linkedList = new LinkedList<int>();
        for (int i = 0; i < size; i++)
        {
            linkedList.AddLast(i);
        }
    }
}

[MemoryDiagnoser]
public class ListBenchmarkString
{
    [Params(1000, 10000)]
    public int size;

    [Benchmark(Baseline = true)]
    public void ListFillString()
    {
        var list = new List<string>();
        for (int i = 0; i < size; i++)
        {
            list.Add(i.ToString());
        }
    }

    [Benchmark]
    public void LinkedListFillString()
    {
        var linkedList = new LinkedList<string>();
        for (int i = 0; i < size; i++)
        {
            linkedList.AddLast(i.ToString());
        }
    }
}