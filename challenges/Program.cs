using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace challenges
{
    public static class Challenges
    {
        static void Main(string[] args)
        {
                
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
