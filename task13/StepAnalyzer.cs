using System;
using System.Diagnostics;
using System.IO;

namespace task13
{
    public static class StepAnalyzer
    {
        public static void AnalyzeStep()
        {
            double a = -100;
            double b = 100;
            Func<double, double> func = Math.Sin;
            double actual = Math.Cos(a) - Math.Cos(b); 

            double[] steps = { 1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6 };

            string resultPath = "step_results.txt";
            using StreamWriter writer = new StreamWriter(resultPath, false);

            writer.WriteLine("Анализ производительности и точности по разным шагам:");

            foreach (double step in steps)
            {
                Stopwatch sw = Stopwatch.StartNew();
                double approx = DefiniteIntegral.Solve(func, a, b, step, threadCount: 4);
                sw.Stop();

                double error = Math.Abs(approx - actual);
                writer.WriteLine($"Шаг: {step}, Время: {sw.ElapsedMilliseconds} мс, Погрешность: {error}");
            }

            Console.WriteLine($"Результаты анализа шагов записаны в файл: {resultPath}");
        }
    }
}
