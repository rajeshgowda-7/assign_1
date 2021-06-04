using System;
using System.Text;

namespace RAJESH_A1
{
    class Program
    {
        static void Main(string[] args)
        {

            //QUESTION 1
            Console.WriteLine("Q1. Please enter sequence of moves [U/D/L/R]");
            string moves = Console.ReadLine();
            //Calling it
            bool pos = JudgeCircle(moves);
            //Checking the return value
            if (pos)
                Console.WriteLine("The Robot returns to the initial position (0,0)\n");
            else
                Console.WriteLine("The Robot does not return to the initial postion (0,0)\n");


            //QUESTION 2
            Console.WriteLine("Q2. Enter the string to check for pangram");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            //Check for the return value 
            if (flag)
                Console.WriteLine("Yes, the given string is a pangram\n");
            else
                Console.WriteLine("No, the given string is not a pangram\n");


            //QUESTION 3
            Console.WriteLine("Q3. Enter the array of numbers to check for identical pairs");
            string str = (Console.ReadLine());
            string[] strlist = str.Split(',');
            int[] arr = new int[strlist.Length];
            try
            {
                for (int i = 0; i < strlist.Length; i++)
                    arr[i] = (int.Parse(strlist[i]));
                int res = NumIdenticalPairs(arr);
                Console.WriteLine("Number of identical pairs is {0}\n", res);
            }
            catch
            {
                Console.WriteLine("Please enter valid input\n");
            }


            //QUESTION 4
            Console.WriteLine("Q4. Enter the array of numbers to check for pivot index");
            string str1 = (Console.ReadLine());
            string[] strlist1 = str1.Split(',');
            int[] lst = new int[strlist1.Length];
            try
            {
                for (int i = 0; i < strlist1.Length; i++)
                    lst[i] = (int.Parse(strlist1[i]));
                int pvresult = PivotIndex(lst);
                Console.WriteLine("The pivot index is at position {0}\n", pvresult);
            }
            catch
            {
                Console.WriteLine("Please enter valid input\n");
            }


            //QUESTION 5
            Console.WriteLine("Q5. Enter two strings to merge alternately");
            string a = (Console.ReadLine());
            string b = (Console.ReadLine());
            string result = MergeAlternately(a, b);
            Console.WriteLine("Result is {0}\n", result);


            //QUESTION 6
            Console.WriteLine("Q6. Enter string to convert to Goat Latin");
            string gl = (Console.ReadLine());
            string glresult = ToGoatLatin(gl);
            Console.WriteLine("Result is {0}\n", glresult);


        }


        public static bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;
            try
            {
                char[] array = moves.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    //inputting the value of x for horizontal motion 
                    if (array[i] == 'R')
                        x++;
                    else if (array[i] == 'L')
                        x--;
                    //inputting the value of y for vertical motion
                    else if (array[i] == 'U')
                        y++;
                    else if (array[i] == 'D')
                        y--;
                    else
                        Console.WriteLine("{0} is invalid input ", array[i]);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured in JudgeCircle\n");
                throw;
            }
            //returns true if x==0 and y==0 which gives the posituon (0,0)
            return (x == 0 && y == 0);
        }



        public static bool CheckIfPangram(string sentence)
        {
            //Initialising the string 
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            int count = 0;
            try
            {
                foreach (char c in alpha)
                {
                    //Looping  the input string to run the comparison
                    foreach (char l in sentence.ToLower())
                    {
                        //comparing alphabets and increasing count
                        if (c == l)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured in CheckIfPangram\n");
                throw;
            }

            if (count == 26)
                return true;
            else
                return false;
        }



        public static int NumIdenticalPairs(int[] nums)
        {
            int count = 0;
            try
            {
                //for compare elements inside the array
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    // for comparing elements with particular element 
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] == nums[j] && i < j)
                            count++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured in NumIdenticalPairs\n");
            }
            //returns the matches
            return count;
        }



        public static int PivotIndex(int[] lst)
        {
            try
            {
                int ts = 0;
                //  for calculating the sum
                for (int i = 0; i < lst.Length; i++)
                {
                    ts += lst[i];
                }
                // for identifying position i
                for (int i = 1; i < lst.Length; i++)
                {
                    int rs = 0;
                    int ls = 0;
                    // for calculating right sum for particular position 
                    for (int j = i + 1; j < lst.Length; j++)
                    {
                        rs += lst[j];
                    }
                    //for calculating left sum for a particular position i
                    ls = ts - rs - lst[i];
                    if (ls == rs)
                        return i;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured in PivotIndex\n");
                throw;
            }
            return -1;
        }



        public static string MergeAlternately(string word1, string word2)
        {
            try
            {
                // checking null
                if (word1 == null || word1.Length == 0)
                    return word2;
                if (word2 == null || word2.Length == 0)
                    return word1;

                int i1 = 0, i2 = 0;
                StringBuilder sb = new StringBuilder();

                while (i1 < word1.Length && i2 < word2.Length)
                {
                    sb.Append(word1[i1++]);
                    sb.Append(word2[i2++]);
                }

                while (i1 < word1.Length)
                    sb.Append(word1[i1++]);
                while (i2 < word2.Length)
                    sb.Append(word2[i2++]);
                return sb.ToString();
            }
            catch
            {
                Console.WriteLine("Exception occured in MergeAlternately\n");
                throw;
            }
        }



        public static string ToGoatLatin(string sentence)
        {
            try
            {
                var words = sentence.Split(' ');

                StringBuilder sb = new StringBuilder();
                int count = 0;
                foreach (string w in words)
                {
                    count++;

                    if (
                        w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' ||
                        w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U'
                      )
                    {
                        sb.Append(w);
                    }

                    else
                    {
                        for (int i = 1; i < w.Length; i++)
                            sb.Append(w[i]);
                        // appending first letter at the end
                        sb.Append(w[0]);
                    }
                    sb.Append("ma");
                    for (int i = 0; i < count; i++)
                        sb.Append('a');
                    // adding space before next word
                    if (count < words.Length)
                        sb.Append(' ');

                }
                return sb.ToString();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured in ToGoatLatin\n");
                throw;
            }
        }


    }

}





