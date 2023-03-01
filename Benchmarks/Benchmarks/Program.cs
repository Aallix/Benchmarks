// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ListBenchmarkInteger>();

[MemoryDiagnoser]
public class ListBenchmarkInteger
{
    [Params(1000, 10000)]
    public int size;

    [Benchmark(Baseline = true)]
    public void ListFill()
    {
        var list = new List<int>();
        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void LinkedListFill()
    {
        var linkedList = new LinkedList<int>();
        for (int i = 0; i < size; i++)
        {
            linkedList.AddLast(i);
        }
    }
}