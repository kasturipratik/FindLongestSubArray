using System;

namespace FindLongestSubArray
{
    class Program
    {
        static void Main(string[] args)
        {

            RunApplication();
        }

        static void RunApplication()
        {
            var a = new int[] { 1, 1, 5, 1, 2 };
            var b = new int[] { 1, 2 };
            var c = new int[] { 2, 1 };
            var x = IsContignuousSubArray(a, b, c);


            Console.WriteLine((x) ? x.ToString()
                                   : "No Match found \n" + x.ToString());


            var a1 = new int[] { 11, 14, 1, 2, 17, 2, 11, 6, 11, 22, 14, 2, 17 };
            var b1 = new int[] { 11, 22, 14, 1 };
            var c1 = new int[] { 14, 22, 11, 1, 2 };
            var x1 = IsContignuousSubArray(a1, b1, c1);
            Console.WriteLine((x1) ? x1.ToString()
                                   : "No Match found \n" + x1.ToString());


            var a12 = new int[] { 11, 14, 1, 2, 17, 2, 11, 6, 11, 22, 14, 1, 2, 17 };
            var b12 = new int[] { 11, 22, 14, 1 };
            var c12 = new int[] { 14, 22, 11, 1 };
            var x12 = IsContignuousSubArray(a12, b12, c12);
            Console.WriteLine((x12) ? x12.ToString()
                                   : "No Match found \n" + x12.ToString());


        }


        static bool IsContignuousSubArray(int[] A, int [] B, int[] C)
        {
            
            if (B.Length > A.Length ||
                B.Length > C.Length ||
                !IsSubSetOf(B, C))
            {
                return false;
            }

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

        // check if one list is sub set of other
        static bool IsSubSetOf(int[] B, int[] C)
        {   
            for (int b = 0; b < B.Length; b++)
            {
                var flag = Array.Exists(C, c => c == B[b]);
                if (!flag) { return false; }
            }
            return true;
        }
    }
}
