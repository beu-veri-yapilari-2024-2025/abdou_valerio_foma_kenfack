using System;
using System.Collections.Generic;
using System.Linq;

class StandardDeviationCalculator
{
    // 1. Iterative method
    public static (double mean, double variance, double standardDeviation) CalculateIterative(double[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("At least 1 value is required");

        int n = values.Length;

        // Calculate mean
        double sum = 0;
        foreach (double value in values)
        {
            sum += value;
        }
        double mean = sum / n;

        // Calculate variance - CORRECTED: divided by n
        double sumOfSquaredDifferences = 0;
        foreach (double value in values)
        {
            double difference = value - mean;
            sumOfSquaredDifferences += difference * difference;
        }
        double variance = sumOfSquaredDifferences / n;  // Changed from (n-1) to n

        // Calculate standard deviation
        double standardDeviation = Math.Sqrt(variance);

        return (mean, variance, standardDeviation);
    }

    // 2. Recursive method - main entry point
    public static (double mean, double variance, double standardDeviation) CalculateRecursive(double[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("At least 1 value is required");

        int n = values.Length;

        // Calculate mean recursively
        double mean = CalculateMeanRecursive(values, 0, n);

        // Calculate variance recursively - CORRECTED: divided by n
        double variance = CalculateVarianceRecursive(values, mean, 0, n);

        // Calculate standard deviation
        double standardDeviation = Math.Sqrt(variance);

        return (mean, variance, standardDeviation);
    }

    // Recursive helper method to calculate mean
    private static double CalculateMeanRecursive(double[] values, int index, int n)
    {
        if (index == n - 1)
            return values[index] / n;

        return (values[index] / n) + CalculateMeanRecursive(values, index + 1, n);
    }

    // Recursive helper method to calculate variance - CORRECTED: divided by n
    private static double CalculateVarianceRecursive(double[] values, double mean, int index, int n)
    {
        if (index == n - 1)
            return Math.Pow(values[index] - mean, 2) / n;  // Changed from (n-1) to n

        return (Math.Pow(values[index] - mean, 2) / n) +  // Changed from (n-1) to n
               CalculateVarianceRecursive(values, mean, index + 1, n);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Test data
            double[] testValues = { 10, 12,};

            Console.WriteLine("Input values: " + string.Join(", ", testValues));
            Console.WriteLine($"Number of values (n): {testValues.Length}");
            Console.WriteLine();

            // Iterative calculation
            var iterativeResult = StandardDeviationCalculator.CalculateIterative(testValues);
            Console.WriteLine("=== ITERATIVE METHOD ===");
            Console.WriteLine($"Mean (xm): {iterativeResult.mean:F4}");
            Console.WriteLine($"Variance (V): {iterativeResult.variance:F4}");
            Console.WriteLine($"Standard Deviation (σ): {iterativeResult.standardDeviation:F4}");
            Console.WriteLine();

            // Recursive calculation
            var recursiveResult = StandardDeviationCalculator.CalculateRecursive(testValues);
            Console.WriteLine("=== RECURSIVE METHOD ===");
            Console.WriteLine($"Mean (xm): {recursiveResult.mean:F4}");
            Console.WriteLine($"Variance (V): {recursiveResult.variance:F4}");
            Console.WriteLine($"Standard Deviation (σ): {recursiveResult.standardDeviation:F4}");
            Console.WriteLine();

            // Manual calculation verification
            Console.WriteLine("=== MANUAL VERIFICATION ===");
            double manualMean = testValues.Average();
            double manualSumSquaredDiff = testValues.Sum(x => Math.Pow(x - manualMean, 2));
            double manualVariance = manualSumSquaredDiff / testValues.Length;  // Divided by n
            double manualStdDev = Math.Sqrt(manualVariance);

            Console.WriteLine($"Manual Mean: {manualMean:F4}");
            Console.WriteLine($"Manual Sum of Squared Differences: {manualSumSquaredDiff:F4}");
            Console.WriteLine($"Manual Variance (Sum/n): {manualVariance:F4}");
            Console.WriteLine($"Manual Standard Deviation: {manualStdDev:F4}");

            // Show the calculation steps
            Console.WriteLine("\n=== CALCULATION STEPS ===");
            Console.WriteLine($"1. Mean (xm) = Σx_k / n = {testValues.Sum()} / {testValues.Length} = {manualMean:F4}");
            Console.WriteLine($"2. Variance (V) = Σ(x_k - xm)² / n = {manualSumSquaredDiff:F4} / {testValues.Length} = {manualVariance:F4}");
            Console.WriteLine($"3. Standard Deviation (σ) = √V = √{manualVariance:F4} = {manualStdDev:F4}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}