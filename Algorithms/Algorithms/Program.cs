﻿namespace Algorithms
{
    class Program
    {
        static void Main(string[] Args)
        {
            //merge sort
            int[] numbers = new int[] { 4, 5, 26, 246, 34, 7, 352, 7, 2454, 72 };
            Console.WriteLine(String.Join(" ", Split(numbers)));

            // binary search
            // BinarySearch();
        }

        ////////////////////////////////////// BINARY SEARCH /////////////////////////////////////////////////////////

        // https://www.youtube.com/watch?v=P3YID7liBug

        /// <summary>
        /// 
        /// The role of binary search is to find something very fast.
        /// The principle of the algoritm is quite simple, divide the array (in this case list)
        /// until you find the element you are looking for.
        /// 
        /// The implemention consists of several variables
        /// 1. The array (MUST BE SORTED)
        /// 2. First point
        /// 3. Last point
        /// 4. Middle point
        /// 5. The element we want to find
        /// 
        /// In this example they are:
        /// 1. 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19
        /// 2. 0 
        /// 3. 19
        /// 4. 9
        /// 5. 5
        /// 
        /// NOW FOLLOW THE IMPLEMENTAION
        /// 
        /// The first point is basically the zero index
        /// The last point is the last index
        /// The middle point is calculated with the formula (first + (last - first) / 2)
        /// 
        /// The whole logic is inside a while loop, if the first point is bigger than the last point
        /// that means that the beginning is after the end, which is nonsense.
        /// 
        /// At the beginning of each cycle we calculate the middlePoint (which is just an index), then we check
        /// if the element in that index is the element we are looking for. If it is, we end the program.
        /// 
        /// If not we check if the 'x' element is smaller than the middlePoint if it is, that means that
        /// the element WILL ALWAYS BE ON THE LEFT SIDE OF THE MIDDLE POINT. In that case with don't need
        /// the part of the array that's on the right side of the middlePoint, so we just ignore it.
        /// The same thing happens if 'x element is bigger than the middlePoint, which means that the 'x' element
        /// WILL ALWAYS BE ON THE RIGHT SIDE OF THE ARRAY,so we ignore the left part.
        /// 
        /// HOW THAT HAPPENS
        /// 
        /// REMEMBER FIRST / LAST / MIDDLEPOINT ARE JUST INDEXES
        /// DONT BE FOOLED BY THE NUMBERS FROM 0 TO 19
        /// 
        /// 1. FIRST CYCLE
        /// 
        /// first = 0
        /// last = 19
        /// x = 5
        /// middlePoint = 9
        /// array (in this case list) 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19
        /// 
        /// 2. SECOND CYCLE
        /// 
        /// 5 < 9 -> we don't need the part of the list which is after 9 (middlePoint), so we change the last point
        /// 
        /// first = 0
        /// last = middlePoint - 1 ->  (9 - 1 = 8)
        /// x = 5
        /// middlePoint = first + (last - first) / 2  -> 0 + (8 - 0) / 2 -> 4
        /// array (in this case list) 0 1 2 3 4 5 6 7 8
        /// 
        /// 3. THIRD CYCLE
        /// 
        /// 5 > 4 -> we don't need that part of the list which is before 4, so we ignore it
        /// 
        /// first = middlePoint + 1 -> 4 + 1 = 5
        /// last = 8
        /// x = 5
        /// middlePoint = first + (last - first) / 2  -> 5 + ( 8 - 5) / 2 -> 5 + 1 = 6
        /// array (in this case list)  5 6 7 8
        /// 
        /// 4. 
        /// </summary>
        static void BinarySearch()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 20; i++) numbers.Add(i);

            int first = 0;
            int last = numbers.Count() - 1;
            int x = 5;
            bool found = false;

            while (first <= last)
            {
                int midPoint = first + (last - first) / 2;

                if (numbers[midPoint] == x)
                {
                    found = true;
                    break;
                }

                else if (x < midPoint)
                    last = midPoint - 1;

                else if (x > midPoint)
                    first = midPoint + 1;
            }

            if (found) Console.WriteLine("Number Found!");
            else Console.WriteLine("Number does not exists!");
        }
        ////////////////////////////////////// BINARY SEARCH /////////////////////////////////////////////////////////


        ////////////////////////////////////// MERGE SORT /////////////////////////////////////////////////////////

        // https://www.youtube.com/watch?v=bOk35XmHPKs

        /// <summary>
        /// 
        /// The merge sort algorithm consists of three steps
        /// 
        /// 1. Splitting the array into many arrays
        /// 2. Sorting all of the little arrays
        /// 3. Merging the little arrays back into one big array
        /// 
        /// Ex: We have an input array of [1,4,6,2,7,2,6,8]
        /// Now we split until we have many arrays consisting of only 2 elements
        /// 
        ///                            [1,4,6,2,7,2,6,8]
        ///                   [1,4,6,2]                 [7,2,6,8]
        ///               [1,4]       [6,2]         [7,2]        [6,8]
        ///               
        /// After we are done, we have to sort each and every one
        /// 
        /// 
        ///                   [1,4,6,2,7,2,6,8] - input
        ///           [1,4,6,2]                 [7,2,6,8]
        ///       [1,4]       [6,2]         [7,2]        [6,8]
        ///       [1,4]       [2,6]         [2,7]        [6,8]
        ///           [1,2,4,6]                  [2,6,7,8]
        ///                    [1,2,2,4,6,6,7,8] - output
        ///                    
        /// HOW?
        /// 
        /// FIRST PART:
        /// Split(int[] numbers) method
        /// which takes the input array and Splits it into many 2 elements array
        /// 
        /// 1. We check if the length is less then two, because if it is, that means one of two things
        /// a) the array has only one element
        /// b) it's empty
        /// Both things mean we don't need to continue.
        /// 
        /// 2. We get the middle point 
        /// 
        /// 3. We create two arrays (left and right)
        /// a)  Array is [1,2,3,4]
        /// Middle Point is length / 2 -> 4 / 2 = 2
        /// Left array is [1,2]
        /// Right array is [3,4]
        ///  
        /// b) Array is [1,2,3,4,5]
        /// Middle Point is length / 2 -> 5 / 2 = 2,5 (so 2)
        /// Left array is [1,2]
        /// Right array is [3,4,5]
        /// 
        /// 4. We fill the arrays with array.copy
        /// 
        /// 5. We call the method again (recursion)
        /// 
        /// 6. Then each and every time we call the second method:
        /// 
        /// SECOND PART:
        /// MergeSort(int[] numbers, int[] leftSide, int[] rightSide)
        /// 
        /// Array is [1,3,2,4,8,5,7,6]
        /// 
        /// After the split from the previous step this is what we pass to the second method
        /// ( [1,3,2,4,8,5,7,6],  [1,3,2,4], [8,5,7,6])
        ///   original array,     left side, right side
        /// 
        /// 1. Now we create three indexes and take the count of the left and side arrays
        /// 
        /// 2. We sort
        /// 
        /// While (if the index is bigger than the count you should know what happens)
        /// {
        ///     if (leftSide[0] <= rightSide[0])
        ///         numbers[0] = leftSide[0]
        ///         leftSideIndex++;
        ///     
        /// This means that the first element of the left array is smaller
        /// Than the first element of the right array so we put it as 
        /// the first element of the original array, and we continue
        /// to the second element of the left array so we can compare it 
        /// to the first element of the right array. 
        /// 
        ///     else{does the same thing for the right side array}
        /// }
        /// 
        /// While (on of the indexes is still smaller than the count which means we have exess element)
        /// so we just put it in the original array.
        /// 
        /// </summary>

        static int[] Split(int[] numbers)
        {
            if (numbers.Length < 2) return numbers;

            int midPoint = numbers.Length / 2;

            int[] leftSide = new int[midPoint];
            int[] rightSide = new int[numbers.Length - midPoint];

            Array.Copy(numbers, 0, leftSide, 0, midPoint);
            Array.Copy(numbers, midPoint, rightSide, 0, numbers.Length - midPoint);

            Split(leftSide);
            Split(rightSide);

            return MergeSort(numbers, leftSide, rightSide);
        }
        static int[] MergeSort(int[] numbers, int[] leftSide, int[] rightSide)
        {
            int originalArrIndex = 0;
            int leftSideIndex = 0;
            int rightSideIndex = 0;

            int leftSideCount = leftSide.Length;
            int rightSideCount = rightSide.Length;

            while (leftSideIndex < leftSideCount && rightSideIndex < rightSideCount)
            {
                if (leftSide[leftSideIndex] <= rightSide[rightSideIndex])
                {
                    numbers[originalArrIndex] = leftSide[leftSideIndex];
                    leftSideIndex++;
                }

                else
                {
                    numbers[originalArrIndex] = rightSide[rightSideIndex];
                    rightSideIndex++;
                }

                originalArrIndex++;
            }

            while (leftSideIndex < leftSideCount)
            {
                numbers[originalArrIndex] = leftSide[leftSideIndex];
                originalArrIndex++;
                leftSideIndex++;
            }

            while (rightSideIndex < rightSideCount)
            {
                numbers[originalArrIndex] = rightSide[rightSideIndex];
                originalArrIndex++;
                rightSideIndex++;
            }

            return numbers;
        }

        ////////////////////////////////////// MERGE SORT /////////////////////////////////////////////////////////
    }
}