namespace Algorithms
{
    class Program
    {
        static void Main(string[] Args)
        {
            BinarySearch();
        }
        /// <summary>
        /// 
        /// The role of binary search is to find something very fast.
        /// The principle of the algoritm as quite simple, divide the array (in this case list)
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
        /// If not we check is the 'x' element is smaller than the middlePoint if it is, that means that
        /// the element WILL ALWAYS BE ON THE LEFT SIDE OF THE MIDDLE POINT. In that case with don't need
        /// the part of the array that's on the right side of the middlePoint, so we just ignore it.
        /// The same thing happens if 'x element is bigget than the middlePoint', which means that the 'x' element
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
    }
}