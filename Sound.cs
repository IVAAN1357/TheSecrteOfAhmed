using System;

namespace TheSecretOfAhmed
{
    class Sound
    {
        public void Play(string Notes)
        {
            int delay = 100;
            switch (Notes)
            {
                case "Win": // победная мелодия
                    int[,] winMelody = { { 330, 300 }, { 349, 200 }, { 392, 300 }, { 523, 400 }, { 294, 300 }, { 330, 200 }, { 349, 400 }, { 349, 300 }, { 392, 200 }, { 440, 300 }, { 698, 400 }, { 440, 300 }, { 494, 200 }, { 523, 400 }, { 587, 400 }, { 659, 400 }, { 330, 300 }, { 349, 200 }, { 392, 300 }, { 523, 400 }, { 587, 300 }, { 659, 200 }, { 698, 400 }, { 392, 300 }, { 392, 200 }, { 659, 400 }, { 587, 250 }, { 392, 200 }, { 659, 400 }, { 587, 250 }, { 392, 200 }, { 659, 400 }, { 587, 250 }, { 392, 200 }, { 659, 300 }, { 587, 300 } };
                    for (int i = 0; i < winMelody.GetLength(0); i++)
                    {
                        Console.Beep(winMelody[i, 0], winMelody[i, 1]);
                    }
                    break;
                case "1": // мелодия бега
                    Notes = "C1E1C1E1";
                    goto default;
                case "2": // Money
                    int[,] moneyMelody = { { 247, 300 }, { 494, 200 }, { 349, 100 }, { 247, 300 }, { 175, 300 }, { 220, 300 }, { 247, 300 }, { 294, 300 }, { 247, 300 } };
                    for (int i = 0; i < moneyMelody.GetLength(0); i++)
                    {
                        Console.Beep(moneyMelody[i, 0], moneyMelody[i, 1]);
                    }
                    break;
                case "3": // Atom Heart Mother
                    int[,] atomHeartMotherMelody = { { 196, 200 }, { 165, 200 }, { 196, 200 }, { 330, 200 }, { 294, 400 }, { 247, 200 }, { 196, 200 }, { 262, 400 }, { 220, 200 }, { 175, 200 }, { 196, 400 } };
                    for (int i = 0; i < atomHeartMotherMelody.GetLength(0); i++)
                    {
                        Console.Beep(atomHeartMotherMelody[i, 0], atomHeartMotherMelody[i, 1]);
                    }
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
