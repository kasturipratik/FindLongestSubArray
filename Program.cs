using System;

namespace FindLongestSubArray
{
    class Program
    {
        // testing solution
        static void Main(string[] args)
        {
            RunApplication();
        }

        // check if one list is sub set of other
        static bool IsSubSetOf(int[] A, int[] B, int[] C)
        {
            if (B.Length > A.Length ||
                B.Length > C.Length)
            {
                return false;
            }

            for (int b = 0; b < B.Length; b++)
            {
                var flag = Array.Exists(C, c => c == B[b]);
                if (!flag) { return false; }
            }
            return true;
        }

        // main logic to check if array B is contignuous sub array of A or not
        static bool IsContignuousSubArray(int[] A, int [] B, int[] C)
        {

            if (!IsSubSetOf(A, B, C)) {
                return false;
            };

            var flag = false;
            var count = 0;

            for (int a = 0; a < A.Length; a++)
            { 
                for(int j =0; j < B.Length; j++)
                {
                    if(A[a+j] != B[j])
                    {
                        flag = false;
                        count = 0;
                        break;
                    }
                    else
                    {
                        count++;
                        flag = true;
                    }
                }
                // break out of loop if match is found
                if (count == B.Length)
                {

                    Console.WriteLine("Exact match is found at index: " + a + " through " + (a + B.Length - 1));
                    break;
                }
            }

            return flag;
        }

        // data for testing
        static void RunApplication()
        {
            // test 1
            var a = new int[] { 1, 1, 5, 1, 2 };
            var b = new int[] { 1, 2 };
            var c = new int[] { 2, 1 };
            PrintResult(IsContignuousSubArray(a, b, c));

            // test 2
            var a1 = new int[] { 11, 14, 1, 2, 17, 2, 11, 6, 11, 22, 14, 2, 17 };
            var b1 = new int[] { 11, 22, 14, 1 };
            var c1 = new int[] { 14, 22, 11, 1, 2 };
            PrintResult(IsContignuousSubArray(a1, b1, c1));

            // test 3
            var a12 = new int[] { 11, 14, 1, 2, 17, 2, 11, 6, 11, 22, 14, 1, 2, 17 };
            var b12 = new int[] { 11, 22, 14, 1 };
            var c12 = new int[] { 14, 22, 11, 1 };
            PrintResult(IsContignuousSubArray(a12, b12, c12));

        }

        // print result
        static void PrintResult(bool x)
        {
            Console.WriteLine((x) ? x.ToString()
                                  : "No Match found \n" + x.ToString());
        }

    }
}
