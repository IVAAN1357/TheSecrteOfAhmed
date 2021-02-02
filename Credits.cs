using System;
using System.Threading;

namespace TheSecretOfAhmed
{
    public class Credits
    {
        public void Start(string[] s, bool reverse)
        {
            if (reverse)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int[][] assits = new int[s.Length][];
                Random random = new Random();
                for (int i = 0; i < assits.Length; i++)
                {
                    assits[i] = new int[] { 'Ы', s[i].Length - 1, (Console.WindowWidth + s[i].Length) / 2 - 1 };
                }
                bool[] flags = new bool[s.Length];
                int chet = s.Length;
                while (chet != 0)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!flags[i])
                        {
                            Console.SetCursorPosition(assits[i][2], 4 * i + 3);
                            if (assits[i][1] == 0 || s[i][assits[i][1] - 1] == ' ')
                            {
                                Console.Write((char)assits[i][0]);
                            }
                            else
                            {
                                char temp = Char.ToLower((char)assits[i][0]);
                                Console.Write(temp);
                            }
                            Thread.Sleep(2);
                            if (assits[i][0] == s[i][assits[i][1]])
                            {
                                if (assits[i][1] == 0)
                                {
                                    flags[i] = true;
                                    chet--;
                                }
                                else
                                {
                                    assits[i][2]--;
                                    assits[i][1]--;
                                }
                            }
                            assits[i][0] = (char)random.Next(65, 93);
                            if (assits[i][0] == 91)
                            {
                                assits[i][0] = ' ';
                            }
                            else if (assits[i][0] == 92)
                            {
                                assits[i][0] = ',';
                            }
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                int[][] assits = new int[s.Length][];
                Random random = new Random();
                for (int i = 0; i < assits.Length; i++)
                {
                    assits[i] = new int[] { 'Ы', 0, ((Console.WindowWidth - s[i].Length) / 2) };
                }
                bool[] flags = new bool[s.Length];
                int chet = s.Length;
                while (chet != 0)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!flags[i])
                        {
                            Console.SetCursorPosition(assits[i][2], 4 * i + 1);
                            Console.Write((char)assits[i][0]);
                            Thread.Sleep(1);
                            if (assits[i][0] == s[i][assits[i][1]])
                            {
                                if (assits[i][1] == s[i].Length - 1)
                                {
                                    flags[i] = true;
                                    chet--;
                                }
                                else
                                {
                                    assits[i][2]++;
                                    assits[i][1]++;
                                }
                            }
                            assits[i][0] = (char)random.Next(65, 92);
                            if (assits[i][0] == 91)
                            {
                                assits[i][0] = ' ';
                            }
                        }
                    }
                }
            }
        }
    }
}
