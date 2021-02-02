using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Sound
    {
        public void Play(string Notes)
        {
            int delay = 100;
            switch (Notes)
            {
                case "Win": // победная мелодия
                    Console.Beep(330, 300);
                    Console.Beep(349, 200);
                    Console.Beep(392, 300);
                    Console.Beep(523, 400);
                    Console.Beep(294, 300);
                    Console.Beep(330, 200);
                    Console.Beep(349, 400);
                    Console.Beep(349, 300);
                    Console.Beep(392, 200);
                    Console.Beep(440, 300);
                    Console.Beep(698, 400);
                    Console.Beep(440, 300);
                    Console.Beep(494, 200);
                    Console.Beep(523, 400);
                    Console.Beep(587, 400);
                    Console.Beep(659, 400);
                    Console.Beep(330, 300); //выход на окончание
                    Console.Beep(349, 200);
                    Console.Beep(392, 300);
                    Console.Beep(523, 400);
                    Console.Beep(587, 300);
                    Console.Beep(659, 200);
                    Console.Beep(698, 400);
                    Console.Beep(392, 300);//скачки
                    Console.Beep(392, 200);
                    Console.Beep(659, 400);
                    Console.Beep(587, 250);
                    Console.Beep(392, 200);
                    Console.Beep(659, 400);
                    Console.Beep(587, 250);
                    Console.Beep(392, 200);
                    Console.Beep(659, 400);
                    Console.Beep(587, 250);
                    Console.Beep(392, 200);
                    Console.Beep(659, 300);
                    Console.Beep(587, 300);
                    break;
                case "1": // мелодия бега
                    Notes = "C1E1C1E1";
                    goto default;
                case "2": // Money
                    delay = 100;
                    Console.Beep(247, 3 * delay);
                    Console.Beep(494, 2 * delay);
                    Console.Beep(349, 1 * delay);
                    Console.Beep(247, 3 * delay);
                    Console.Beep(175, 3 * delay);
                    Console.Beep(220, 3 * delay);
                    Console.Beep(247, 3 * delay);
                    Console.Beep(294, 3 * delay);
                    Console.Beep(247, 3 * delay);
                    break;
                case "3": // Atom Heart Mother
                    delay = 100;
                    Console.Beep(196, 2 * delay);
                    Console.Beep(165, 2 * delay);
                    Console.Beep(196, 2 * delay);
                    Console.Beep(330, 2 * delay);
                    Console.Beep(294, 4 * delay);
                    Console.Beep(247, 2 * delay);
                    Console.Beep(196, 2 * delay);
                    Console.Beep(262, 4 * delay);
                    Console.Beep(220, 2 * delay);
                    Console.Beep(175, 2 * delay);
                    Console.Beep(196, 4 * delay);
                    break;
                default:
                    int note;
                    for (int i = 0; i < Notes.Length - 1; i += 2)
                    {
                        switch (Notes[i])
                        {
                            case 'A':
                                note = 440;
                                break;
                            case 'B':
                                note = 494;
                                break;
                            case 'C':
                                note = 262;
                                break;
                            case 'D':
                                note = 294;
                                break;
                            case 'E':
                                note = 330;
                                break;
                            case 'F':
                                note = 349;
                                break;
                            case 'G':
                                note = 392;
                                break;
                            default:
                                note = 0;
                                break;
                        }
                        int time = Convert.ToInt32(Notes[i + 1].ToString()) * 200;
                        Console.Beep(note, time);
                    }
                    break;
            }
        }
    }
}
