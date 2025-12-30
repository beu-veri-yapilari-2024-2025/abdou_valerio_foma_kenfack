using System;

class MergeSortExample
{
    // Main function where the program starts
    static void Main()
    {
        int[] numbers = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Original Array:");
        PrintArray(numbers);

        // Call Merge Sort
        MergeSort(numbers, 0, numbers.Length - 1);

        Console.WriteLine("\nSorted Array:");
        PrintArray(numbers);
    }

    // MergeSort function: divides the array into halves
    static void MergeSort(int[] array, int left, int right)
    {
        // Base condition: only split if more than one element
        if (left < right)
        {
            // Find the middle index
            int middle = left + (right - left) / 2;

            // Recursively sort first half
            MergeSort(array, left, middle);

            // Recursively sort second half
            MergeSort(array, middle + 1, right);

            // Merge the two sorted halves
            Merge(array, left, middle, right);
        }
    }

    // Merge function: merges two sorted subarrays
    static void Merge(int[] array, int left, int middle, int right)
    {
        // Sizes of the two subarrays
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        // Temporary arrays
        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        // Copy data to temporary arrays
        for (int i = 0; i < leftSize; i++)
            leftArray[i] = array[left + i];

        for (int j = 0; j < rightSize; j++)
            rightArray[j] = array[middle + 1 + j];

        int l = 0, r = 0;
        int k = left;

        // Merge the temporary arrays back into the original array
        while (l < leftSize && r < rightSize)
        {
            if (leftArray[l] <= rightArray[r])
            {
                array[k] = leftArray[l];
                l++;
            }
            else
            {
                array[k] = rightArray[r];
                r++;
            }
            k++;
        }

        // Copy remaining elements of leftArray (if any)
        while (l < leftSize)
        {
            array[k] = leftArray[l];
            l++;
            k++;
        }

        // Copy remaining elements of rightArray (if any)
        while (r < rightSize)
        {
            array[k] = rightArray[r];
            r++;
            k++;
        }
    }

    // Utility function to print the array
    static void PrintArray(int[] array)
    {
        foreach (int value in array)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}
