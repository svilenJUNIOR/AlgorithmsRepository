namespace Algoritms
{
    class Program
    {
        static void Main(string[] Args)
        {
            BinarySearch();
        }

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
