using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace challenges
{
    public static partial class Challenges
    {
        static void Main(string[] args)
        {
                
        }


        /// <summary>
        /// https://www.hackerrank.com/challenges/largest-rectangle
        /// 
        /// https://www.youtube.com/watch?v=ZmnqCZp9bBs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int LargestRectangle(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var size = Convert.ToInt32(inputs[0]);
            var values = Array.ConvertAll(inputs[1].Split(new[] { " " }, StringSplitOptions.None), int.Parse);

            var stack = new Stack<int>();

            var maxArea = -1;
            int top;

            for (var i = 0; i < size; )
            {
                // if stack is empty or current value >= top of stack value, add index to stack
                if (!stack.Any() || values[i] >= values[stack.Peek()])
                {
                    stack.Push(i++);
                }
                else
                {
                    // currentValue < top of stack, let's calculate areas - removing from the stack - until we find a number <= to current value
                    top = stack.Pop();
                    var area = stack.Any() ? values[top] * (i - stack.Peek() - 1) : values[top] * i;
                    maxArea = area > maxArea ? area : maxArea;
                }
            }

            while (stack.Any())
            {
                top = stack.Pop();
                var area = stack.Any() ? values[top] * (size - stack.Peek() - 1) : values[top] * size;
                maxArea = area > maxArea ? area : maxArea;
            }

            return maxArea;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/countingsort3
        /// </summary>
        /// <param name="inputStrings"></param>
        /// <returns></returns>
        public static string CountSort3(List<string> inputStrings)
        {
            var list = new List<int>();
            var inputCursor = 0;
            var inputSize = int.Parse(inputStrings[0]);
            for (int a = 1; a <= inputSize; a++)
            {
                var input = inputStrings[a];
                var inputs = input.Trim().Split(' ');
                for (int i = 0; i < inputs.Length; i++)
                {
                    int number;
                    if (int.TryParse(inputs[i], out number))
                    {
                        list.Add(number);
                    }
                }
            }

            list.Sort();

            int j = 0;
            var result = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                if (j < list.Count && i >= list[j])
                {
                    j++;
                    while (j < list.Count && list[j - 1] == list[j])
                    {
                        j++;
                    }

                }
                result.Append(j).Append(" ");
            }

            return result.ToString().Trim();    
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/anagram
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Anagram(string input)
        {
            var result = new StringBuilder();
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var testCases = Convert.ToInt32(inputs[0]);

            for (var i = 1; i <= testCases; i++)
            {
                var s = inputs[i];

                if (s.Length % 2 != 0) { result.AppendLine("-1"); continue; }

                var letters = new Dictionary<char, int>();

                var half = s.Length / 2;
                for (var j = 0; j < half; j++)
                {
                    if (letters.ContainsKey(s[j])) letters[s[j]]++;
                    else letters.Add(s[j], 1);
                }

                var qtyDiff = 0;
                for (var k = half; k < s.Length; k++)
                {
                    if (letters.ContainsKey(s[k]) && letters[s[k]] > 0) letters[s[k]]--;
                    else qtyDiff++;
                }

                result.AppendLine(qtyDiff.ToString());
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/gem-stones
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GemStones(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var gemCount = Convert.ToInt32(inputs[0]);
            var gems = new Dictionary<char, int>();
            for(var i = 1;i <= gemCount; i++) {
                var gem = inputs[i];
                var chars = new List<char>();

                foreach (var t in gem.Where(t => !chars.Contains(t)))
                {
                    chars.Add(t);

                    if (gems.ContainsKey(t)) {
                        gems[t]++;
                    } else {
                        gems.Add(t, 1);
                    }
                }
                chars.Clear();
            }
            return gems.Count(g => g.Value >= gemCount);
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/reverse-shuffle-merge
        /// </summary>
        /// <param name="input"></param>
        /// <returns>FAILED</returns>
        public static string ReverseShuffleMerge(string input)
        {
            var letterDict = new Dictionary<char, int>();
            var letters = string.Concat(input.OrderBy(l => l));
            var sb = new StringBuilder();
            for (var i = 0; i < letters.Length; i++)
            {
                if (!letterDict.ContainsKey(letters[i]))
                {
                    letterDict.Add(letters[i], 1);
                    if (i == 0) continue;

                    sb.Append(new string(letters[i - 1], letterDict[letters[i - 1]] / 2));
                }
                else
                {
                    letterDict[letters[i]]++;
                }
            }

            // Add last letter
            sb.Append(new string(letters[letters.Length - 1], letterDict[letters[letters.Length - 1]] / 2));

            var result = String.Concat(sb.ToString().OrderBy(s => s));
            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/string-reduction
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StringReduction(string input)
        {
            var inputs = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            int res;
            var sb = new StringBuilder();
            var numcases = Convert.ToInt32(inputs[0]);
            for (var i = 0; i < numcases; i++)
            {
                var a = inputs[i + 1].Trim();
                var dic = new Dictionary<char, int>();
                for (int j = 0; j < a.Length; j++)
                {
                    if (dic.ContainsKey(a[j]))
                        dic[a[j]]++;
                    else
                        dic.Add(a[j], 1);
                }

                // if there's only 1 type of letter, then it's the array length
                // if all letters are in even number, or odd number then it reduces to 2, always
                // otherwise it reduces to 1
                if (dic.Keys.Count == 1)
                    res = a.Length;
                else if (dic.Values.All(v => v%2 == 0) || (dic.Values.All(v => v%2 != 0) && dic.Keys.Count == 3))
                    res = 2;
                else
                    res = 1;

                sb.Append(res);
                if (i != numcases - 1)
                    sb.AppendLine();

            }
            return sb.ToString();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/sherlock-and-valid-string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ValidString(string input)
        {
            var isValid = false;
            var lettersCount = new int[26];

            for (var i = 0; i < input.Length; i++)
            {
                lettersCount[char.ToUpper(input[i]) - 65]++;
            }

            var countList = lettersCount.OrderBy(l => l)
                                        .SkipWhile(l => l == 0).ToList();
            if (countList.First() == 1 && countList.Skip(1).Sum(c => c) == (countList.Count - 1) * countList.Last())
                isValid = true;
            else if (countList.Sum(c => c) <= countList.Count * countList.First() + 1)
                isValid = true;

            return isValid ? "YES" : "NO";
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/common-child
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int CommonChild(string input)
        {
            var inputs = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var word_1 = inputs[0];
            var word_2 = inputs[1];
            var L = new int[word_1.Length+1, word_2.Length+1];

            for (int i = 0; i < word_1.Length; i++)
            {
                for (int j = 0; j < word_2.Length; j++)
                {
                    if (word_1[i] == word_2[j])
                    {
                        L[i + 1, j + 1] = L[i, j] + 1;
                    }
                    else
                        L[i + 1, j + 1] = Math.Max(L[i + 1, j], L[i, j + 1]);
                }
            }

            return  L[word_1.Length, word_2.Length];
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/angry-children
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int MaxMin(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var n = Convert.ToInt32(inputs[0]);
            var k = Convert.ToInt32(inputs[1]);
            var ints = new List<int>();
            for (var i = 0; i < n; i++)
            {
                ints.Add(Convert.ToInt32(inputs[2 + i]));
            }

            var bestUnfairness = int.MaxValue;
            ints.Sort();

            for (var i = 0; i <= n - k; i++)
            {
                var unfairness = ints[(k+i)-1] - ints[i];
                if (unfairness < bestUnfairness)
                    bestUnfairness = unfairness;
            }

            return bestUnfairness;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/greedy-florist
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GreedyFlorist(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            int N, K;
            string NK = inputs[0];
            string[] NandK = NK.Split(' ', '\t', '\n' );
            N = Convert.ToInt32(NandK[0]);
            K = Convert.ToInt32(NandK[1]);

            var costs = new List<int>();

            string numbers = inputs[1];
            string[] split = numbers.Split(' ', '\t', '\n');

            foreach (string s in split)
            {
                if (s.Trim() != "")
                {
                    costs.Add(Convert.ToInt32(s));
                }
            }

            var persons = new int[K];
            int totalCost = 0;
            costs.Sort();
            var p = 0;
            for (var i = 1; i <= N; i++)
            {
                totalCost += costs[N - i]*(persons[p]++ + 1);
                p = (p + 1)%K;
            }

            return totalCost;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/pairs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Pairs(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var line = inputs[0];
            var lineSplit = line.Split(' ');
            var count = Convert.ToInt32(lineSplit[0]);
            var diff = Convert.ToInt32(lineSplit[1]);
            var nums = new List<int>();
            var numHash = new HashSet<int>();

            var itemLine = inputs[1];
            var items = itemLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < count; i++)
            {
                var item = Convert.ToInt32(items[i]);
                nums.Add(item);
                numHash.Add(item);
            }

            nums.Sort();
            var res = 0;
            for (var i = 1; i <= count; i++)
            {
                var num = nums[count - i];

                if (nums[count - i] < diff)
                    break;

                if (numHash.Contains(num - diff)) res++;

            }

            return res;
        }

        public static string QuicksortInPlace(string input)
        {
            var inputs = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var size = Convert.ToInt32(inputs[0]);
            var ints = inputs[1].Split(' ');
            var array = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                array[i] = Convert.ToInt32(ints[i]);
            }

            quicksort(array, 0, size -1);
            return"";
        }

        private static void quicksort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                var pivot = partition(arr, lo, hi);
                quicksort(arr, lo, pivot - 1);
                quicksort(arr, pivot + 1, hi);
            }
        }

        private static int partition(int[] arr, int lo, int hi)
        {
            var pivot = arr[hi];
            var i = lo;
            for (int j = lo; j < hi; j++)
            {
                if (arr[j] <= pivot)
                {
                    Swap(arr, j, i);
                    i++;
                }
            }
            Swap(arr, hi, i); // put pivot in its place
            return i;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        
        /// <summary>
        /// https://www.hackerrank.com/challenges/the-grid-search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GridSearch(string input)
        {
            var inputs = input.Split(new[] {"\r\n"}, StringSplitOptions.None);
            int t = Convert.ToInt32(inputs[0]);
            var index = 1;
            var result = "";
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_R = inputs[index++].Split(' ');
                int R = Convert.ToInt32(tokens_R[0]);
                int C = Convert.ToInt32(tokens_R[1]);
                string[] G = new string[R];
                for (int G_i = 0; G_i < R; G_i++)
                {
                    G[G_i] = inputs[index++];
                }
                string[] tokens_r = inputs[index++].Split(' ');
                int r = Convert.ToInt32(tokens_r[0]);
                int c = Convert.ToInt32(tokens_r[1]);
                string[] P = new string[r];
                for (int P_i = 0; P_i < r; P_i++)
                {
                    P[P_i] = inputs[index++];
                }
                result += HasPattern(R, G, r, c, P) + " ";
            }
            return result;
        }
        
        static string HasPattern(int rows, string[] matrix, int r, int c, string[] pattern)
        {
            for (int i = 0; i <= rows - r; i++)
            {
                if (matrix[i].Contains(pattern[0]))
                {
                    var indexes = findMatchIndexes(matrix[i], pattern[0]);
                    for (int j = 0; j < indexes.Length; j++)
                    {
                        if (verifyPattern(i, indexes[j], matrix, r, c, pattern))
                        return "YES";
                    }
                }
            }

            return "NO";
        }

        static int[] findMatchIndexes(string inputLine, string pattern)
        {
            var indexes = new List<int>();
            for (int i = 0; i <= inputLine.Length - pattern.Length; i++)
            {
                if (inputLine.Substring(i, pattern.Length) == pattern)
                {
                    indexes.Add(i);
                }
            }

            return indexes.ToArray();
        }

        static bool verifyPattern(int startR, int startC, string[] matrix, int r, int c, string[] pattern)
        {
            int patternRow = 0;
            for (int i = startR; i < startR + r; i++)
            {
                var extract = matrix[i].Substring(startC, c);
                if (extract != pattern[patternRow])
                {
                    return false;
                }
                patternRow++;

            }
            return true;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/matrix-rotation-algo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RotateMatrix(string input)
        {
            var inputs = input.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var specs = inputs[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var rows = Convert.ToInt32(specs[0]);
            var columns = Convert.ToInt32(specs[1]);
            var numRotation = Convert.ToInt32(specs[2]);
            var matrix = new int[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                var row = inputs[i+1].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = Convert.ToInt32(row[j]);
                }
            }

            // rotations here
            var numlayers = Math.Min(rows, columns) / 2;
            for (var r = 0; r < numlayers; r++)
            {
                var rotation = numRotation % ((rows - 2*r - 1) * 2 + (columns - 2*r - 1) * 2); // minimize the number of rotation needed (removing the complete rotations)
                rotate(matrix, rotation, r, rows - 1, columns - 1);
            }

            return printMatrix(matrix);
        }

        private static void rotate(int[,] matrix, int numRotation, int layer, int r, int c)
        {
            for (var k = 1; k <= numRotation; k++)
            {
                var i = layer;
                var j = layer;
                var currentValue = matrix[layer, layer];

                do
                {
                    var modifiers = getNextPosition(i, j, layer, r - layer, c - layer);
                    i += modifiers.X;
                    j += modifiers.Y;

                    var nextValue = matrix[i, j];
                    matrix[i, j] = currentValue;
                    currentValue = nextValue;

                } while (i != layer || j != layer);
            }
        }

        private static Coordinates getNextPosition(int posX, int posY, int min, int maxX, int maxY)
        {
            if (posX < maxX && posY == min)
                return new Coordinates {X = 1, Y = 0};
            if (posX == maxX && posY < maxY)
                return new Coordinates { X = 0, Y = 1 };
            if (posX <= maxX && posX > min && posY == maxY)
                return new Coordinates { X = -1, Y = 0};
            
            return new Coordinates { X = 0, Y = -1 };

        }

        private static string printMatrix(int[,] matrix)
        {
            var r = matrix.GetUpperBound(0);
            var c = matrix.GetUpperBound(1);
            var sb = new StringBuilder();

            for (int i = 0; i <= r; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    sb.Append(matrix[i, j]);
                    if (j != c)
                        sb.Append(" ");
                }
                if(i != r)
                    sb.AppendLine();
            }

            return sb.ToString();
        }

        public class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
