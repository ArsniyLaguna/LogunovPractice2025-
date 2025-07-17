using System;
using System.Threading;

namespace task14;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsNumber)
    {
        double result = 0.0;
        object locker = new object();
        int totalSteps = (int)((b - a) / step);
        int stepsPerThread = totalSteps / threadsNumber;

        Barrier barrier = new Barrier(threadsNumber);

        Thread[] threads = new Thread[threadsNumber];

        for (int i = 0; i < threadsNumber; i++)
        {
            int threadIndex = i;
            threads[i] = new Thread(() =>
            {
                int start = threadIndex * stepsPerThread;
                int end = (threadIndex == threadsNumber - 1) ? totalSteps : start + stepsPerThread;

                double partialSum = 0.0;
                for (int j = start; j < end; j++)
                {
                    double x0 = a + j * step;
                    double x1 = x0 + step;
                    partialSum += (function(x0) + function(x1)) * (x1 - x0) / 2;
                }

                Interlocked.Exchange(ref result, result + partialSum);

                barrier.SignalAndWait();
            });

            threads[i].Start();
        }

        foreach (var thread in threads)
            thread.Join();

        return result;
    }
}