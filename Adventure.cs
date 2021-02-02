using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Adventure
    {
        public string TheEnd(int a)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, a);
            Console.WriteLine("1. Играть снова");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2. Выйти");
            string res = "r";
            ConsoleKey butt = Console.ReadKey().Key;
            while (butt != ConsoleKey.Enter)
            {
                if (butt == ConsoleKey.UpArrow || butt == ConsoleKey.DownArrow)
                {
                    if (res == "r")
                    {
                        Console.SetCursorPosition(0, a);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("1. Играть снова");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("2. Выйти");
                        res = "q";
                    }
                    else
                    {
                        Console.SetCursorPosition(0, a);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1. Играть снова");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("2. Выйти");
                        res = "r";
                    }
                }
                butt = Console.ReadKey().Key;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            return res;
        }
        bool win = false;
        Hero player;
        Sound music = new Sound();
        Credits credits = new Credits();
        string bi = "";
        int damage = 0;
        string Flag;
        string quit = "";
        public Adventure(Hero player) { this.player = player; }
        public void BeutyText(string s, string Notes)
        {
            Task task = new Task(() => music.Play(Notes));
            task.Start();
            foreach (char f in s)
            {
                Console.Write(f);
                System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine();
        }
        public void Begin()
        {
            Console.ForegroundColor = ConsoleColor.Green; // начало игры
            Console.WriteLine("Привет, герой! Введи своё имя, чтобы начать приключение!\n(оно должно быть на русском языке с последней согласной буквой)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            player.Name = Console.ReadLine();
            do
            {
                player.Coins = 100;
                player.Health = 100;
                Console.Clear();
                Task task = new Task(() => music.Play("C1D1G1D1C1E1F1E1C1")); // музыка старта
                task.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorVisible = false;
                Console.Clear();
                var pos = (1, 0);
                string questText = GetQuest(pos);
                player.GetStatic();
                pos = (2, player.GetAction(questText));
                questText = GetQuest(pos);
                player.GetStatic();
                pos = (3, player.GetAction(questText));
                questText = GetQuest(pos);
                player.GetStatic();
                pos = (4, player.GetAction(questText));
                questText = GetQuest(pos);
                player.GetStatic();
                Console.CursorVisible = true;
                int a = 9;
                if (win)
                {
                    win = false;
                    Console.Write("Нажмите любую клавишу...");
                    Console.CursorVisible = false;
                    Console.ReadKey();
                    string[] s = { "GAME DIRECTOR", "PROGRAMMERS", "SOUND DESIGNER", "ART DIRECTOR", "TESTER", "ANIMATION DIRECTOR" };
                    string[] s2 = { "ILYA KOLPAKOV", "ILYA KOLPAKOV, IVAN SMIRNOV", "IVAN SMIRNOV", "ILYA KOLPAKOV", "IVAN SMIRNOV", "IVAN SMIRNOV" };
                    Console.Clear();
                    Task task2 = new Task(() => music.Play("Win")); // музыка победы
                    task2.Start();
                    credits.Start(s, false);
                    credits.Start(s2, true);
                    System.Threading.Thread.Sleep(4000);
                    for (int i = 0; i < 30; i++)
                    {
                        Console.MoveBufferArea(0, 1, Console.WindowWidth, 30, 0, 0);
                        System.Threading.Thread.Sleep(25);
                    }
                    System.Threading.Thread.Sleep(500);
                    Console.CursorVisible = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    a = 0;
                }
                quit = TheEnd(a);
                a = 9;
            }
            while (quit == "r");
            music.Play("G1E1C1"); // проигрывание музыки выхода
        }
        string GetQuest((int, int) n)
        {
            Random random = new Random();
            string s = "";
            if (n == (1, 0)) 
            {
                s = $@"Гуляя в лесу {player.Name} наткнулся на какого-то старика. 
Старик сказал, что его зовут Ахмед и ему очень жаль. 
{player.Name} чует что-то неладное. Ахмед собирается напасть на {player.Name}а.";
            }
            else if (n == (2, 1)) 
            {
                s = $@"{player.Name} бежал от Ахмеда на протяжении 4 часов. Ахмед потерял след.
{player.Name} наткнулся на торговца, который отказывается показывать чем торгует, пока {player.Name} не заплатит 100 монет.";
                Flag = "Побег от Ахмеда";
            }
            else if (n == (2, 2)) 
            {
                player.Coins -= 50;
                damage = random.Next(80, 98);
                player.Health -= damage;
                bi = damage % 10 >= 2 && damage % 10 <= 4 ? "ы" : damage % 10 == 1 ? "у" : "";
                s = $@"{player.Name} не хочет проблем, поэтому он даёт Ахмеду 50 монет. Но Ахмед напал на него
и избил до полусмерти. Здоровье {player.Name}а упало на {damage} единиц{bi}. 
{player.Name} очнулся через несколько часов рядом с каким-то гномом и большим слоном. 
Гном назвал себя Аркадием и согласился за 50 монет протестировать на {player.Name}е его Машину Времени.
";
                Flag = "Деньги Ахмеду";
            }
            else if (n == (2, 3)) 
            {
                damage = random.Next(70, 87);
                player.Health -= damage;
                bi = damage % 10 >= 2 && damage % 10 <= 4 ? "ы" : damage % 10 == 1 ? "у" : "";
                s = $@"В очень жестокой борьбе {player.Name} убил Ахмеда и потерял {damage} единиц{bi} здоровья.
{player.Name} из последних сил ползёт по лесу, надеясь, что его кто-то найдёт и спасёт. Вскоре {player.Name} теряет сознание.
Он приходит в себя через несколько часов, находясь рядом с каким-то гномом и большим слоном. 
Гном назвал себя Аркадием и согласился за 50 монет протестировать на {player.Name}е его Машину Времени.";
                Flag = "Драка с Ахмедом";
            }
            else if (n == (3, 1) && Flag == "Побег от Ахмеда") 
            {
                s = $@"{player.Name} зачем-то убежал от торговца. 
Но из-за того, что он уже слишком долго бежал, {player.Name} упал в обморок. 
Он очнулся в каком-то старом доме. Рядом он увидел Ахмеда, 
который точил свой нож и не заметил, как {player.Name} очнулся.";
                Flag = "Побег от торговца";
            }
            else if (n == (3, 2) && Flag == "Побег от Ахмеда") 
            {
                player.Coins = 0;
                s = $@"Торговец берёт с {player.Name}а 100 монет и даёт взамен огромный тазик.
Однако, в эту же секунду рядом с ним с небес падает большой слон.";
                Flag = "Сделка с торговцем";
            }
            else if (n == (3, 3) && Flag == "Побег от Ахмеда") 
            {
                damage = random.Next(2, 10);
                player.Health -= damage;
                bi = damage % 10 >= 2 && damage % 10 <= 4 ? "ы" : damage % 10 == 1 ? "у" : "";
                s = $@"{player.Name} с лёгкостью убивает торговца, получив лишь {damage} единиц{bi} урона и обыскиват его лавку. 
В ней {player.Name} нашёл огромный топор из стали. Однако, в эту же секунду рядом с ним с небес падает большой слон.";
                Flag = "Убийство торговца";
            }

            else if (n == (3, 1) && Flag == "Деньги Ахмеду") 
            {
                s = $@"{player.Name} убегает, думая, что у него совсем поехала крыша.
Гном Аркадий кричит, что в таком случае протестирует машину на своём слоне.
{player.Name} чуть живой находит старую крысу.";
                Flag = "Побег от Аркадия";
            }
            else if (n == (3, 2) && Flag == "Деньги Ахмеду") 
            {
                player.Coins -= 50;
                s = $@"{player.Name} заплатил 50 монет Гному Аркадию и сел на кресло Машины Времени.
Его перенесло на несколько часов назад в какое-то другое место этого леса. {player.Name} увидел самого себя без сознания,
лежавшего в луже крови.";
                Flag = "Сделка с Аркадием";
            }
            else if (n == (3, 3) && Flag == "Деньги Ахмеду") 
            {
                player.Health -= 1;
                s = $@"{player.Name} вступает в драку с Аркадием и убивает его, потеряв 1 единицу здоровья.
Однако слон Аркадия сразу же пошёл мстить за своего хозяина. {player.Name} в панике сел в Машину Времени Аркадия
и начал нажимать все кнопки. Его перенесло на 63 года назад куда-то в этот лес. {player.Name} взял себе
имя Ахмед, построил себе дом в этом лесу и жил там 63 года. В один день он увидел самого себя из прошлого.";
                Flag = "Убийство Аркадия";
            }
            else if (n == (3, 1) && Flag == "Драка с Ахмедом") 
            {
                s = $@"{player.Name} убегает, думая, что у него совсем поехала крыша.
Гном Аркадий кричит, что в таком случае протестирует машину на своём слоне.
{player.Name} чуть живой находит старую крысу.";
                Flag = "Побег от Аркадия";
            }
            else if (n == (3, 2) && Flag == "Драка с Ахмедом") 
            {
                player.Coins -= 50;
                s = $@"{player.Name} заплатил 50 монет Гному Аркадию и сел на кресло Машины Времени.
Его перенесло на несколько часов назад в какое-то другое место этого леса. {player.Name} увидел самого себя без сознания,
лежавшего в луже крови рядом с телом Ахмеда.";
                Flag = "Сделка с Аркадием2";
            }
            else if (n == (3, 3) && Flag == "Драка с Ахмедом") 
            {
                player.Health -= 1;
                s = $@"{player.Name} вступает в драку с Аркадием и убивает его, потеряв 1 единицу здоровья.
Однако слон Аркадия сразу же пошёл мстить за своего хозяина. {player.Name} в панике сел в Машину Времени Аркадия
и начал нажимать все кнопки. Его перенесло на 63 года назад куда-то в этот лес. {player.Name} взял себе
имя Ахмед, построил себе дом в этом лесу и жил там 63 года. В один день он увидел самого себя из прошлого.";
                Flag = "Убийство Аркадия2";
            }
            else if (n == (4, 1) && Flag == "Побег от торговца") 
            {
                player.Health = 0;
                s = $@"{player.Name} постарался встать и убежать. 
Однако, по всей видимости он был слишком долго без сознания и поэтому почувствовал сильную боль в ногах. 
Ахмед от неожиданности кинул в него свой нож.
{player.Name} умер.";
            }
            else if (n == (4, 2) && Flag == "Побег от торговца") 
            {
                player.Health = 0;
                player.Coins = 0;
                s = $@"{player.Name} решил отдать Ахмеду все свои деньги, чтобы он отпустил его. 
Ахмед сказал, что всё это ради его же блага. Он собирался было сказать что-то ещё, 
но его прервал огромный слон, упавший с небес на дом.
{player.Name} умер.";
            }
            else if (n == (4, 3) && Flag == "Побег от торговца") 
            {
                player.Health = 0;
                s = $@"{player.Name} незаметно встал и ударил Ахмеда, Ахмед упал. 
{player.Name} выхватил его нож и без проблем убил его. 
Однако, когда он собирался уходить, на дом с небес упал большой слон.
{player.Name} умер.";
            }
            else if (n == (4, 1) && Flag == "Сделка с торговцем") 
            {
                player.Health = 0;
                s = $@"{player.Name} старался со всег ног удрать от этого слона.
К сожалению, слон упал на {player.Name}а и раздавил его в лепёшку, не найдя при {player.Name}е ни копейки.
{player.Name} умер.";
            }
            else if (n == (4, 2) && Flag == "Сделка с торговцем") 
            {
                player.Health = 0;
                player.Coins = 0;
                s = $@"{player.Name} кинул слону свой пустой кошелёк. 
Слон принял это за оскорбление и напал на {player.Name}а, сев на него.
{player.Name} умер и превратился в лепёшку.";
            }
            else if (n == (4, 3) && Flag == "Сделка с торговцем") 
            {
                player.Health = 0;
                s = $@"{player.Name} хотел было сражаться, но потом понял насколько это тупо. 
Вместо это он накрылся огромным тазиком и стал молиться ради всего святого, чтобы слон прошёл мимо.
Слон решил поспать и улёгся на тазик. 
{player.Name} умер и преваратился в лепёшку.";
            }
            else if (n == (4, 1) && Flag == "Убийство торговца") 
            {
                player.Health = 0;
                player.Coins = 0;
                s = $@"{player.Name} старался со всех ног удрать от этого слона.
К сожалению, слон упал на {player.Name}а, раздавил его в лепёшку и забрал все деньги.
{player.Name} умер.";
            }
            else if (n == (4, 2) && Flag == "Убийство торговца") 
            {
                player.Coins = 0;
                player.Health = 0;
                s = $@"{player.Name} кинул слону все свои деньги. 
Слон подумал, что {player.Name} напал на него и сел на {player.Name}а.
{player.Name} умер и превратился в лепёшку.";
            }
            else if (n == (4, 3) && Flag == "Убийство торговца") 
            {
                player.Health = 0;
                s = $@"{player.Name} нападает на слона и бъёт его своим топором из стали. Слон умирает.
Мёртвое тело слона падает на {player.Name}а.
{player.Name} умирает и превращается в лепёшку.";
            }
            else if (n == (4, 1) && Flag == "Побег от Аркадия") 
            {
                player.Health = 0;
                s = $@"Убегая дальше вглубь леса {player.Name} теряет очень много крови.
{player.Name} умер от потери крови.";
            }
            else if (n == (4, 2) && Flag == "Побег от Аркадия") 
            {
                player.Coins = 0;
                player.Health = 100;
                s = $@"{player.Name} совсем поехал кукухой и отдал все свои последние деньги старой крысе.
Но к его удивлению крыса созвала всю свою семью, они все вместе подянли {player.Name}а и вывели из леса.
Вскоре {player.Name} обнаружил, что все его раны сами излечились и он совершенно здоров.";
                win = true; // победа
            }
            else if (n == (4, 3) && Flag == "Побег от Аркадия") 
            {
                player.Health = 0;
                player.Coins = 0;
                s = $@"{player.Name} без труда убивает старую крысу и съедает её. Его здоровье повышается на 35 единиц.
Однако вскоре на него падает огромный слон, раздавливает его в лепёшку и забирает все деньги.
{player.Name} умер.";
            }
            else if (n == (4, 1) && Flag == "Сделка с Аркадием") 
            {
                player.Health = 0;
                s = $@"{player.Name} убегает не веря своим глазам. Однако вскоре натыкается на какого-то торговца,
который принял {player.Name}а за сумасшедшего и ударил его своим стальным топором.
{player.Name} умер.";
            }
            else if (n == (4, 2) && Flag == "Сделка с Аркадием") 
            {
                player.Health = 0;
                s = $@"{player.Name} хотел было отдать самому себе из прошлого деньги, но потом понял,
что у него самого их нет. Он решает хоть как-то помочь самому себе, отнеся тело в безопасное место.
Через минут 20 {player.Name} случайно наткнулся на Аркадия и решил оставить самого себя из прошлого здесь.
Позже, идя по лесу, {player.Name} случайно раздавил крысу. Через 10 секунд на него напал целый рой крыс и съел его заживо.
{player.Name} умер.";
            }
            else if (n == (4, 3) && Flag == "Сделка с Аркадием") 
            {
                player.Health = 0;
                s = $@"{player.Name} по какой-то неведанной причине решает убить самого себя из прошлого.
У него это получается без каких либо проблем, так как его более молодая версия была в отключке.
Но сразу же после этого {player.Name} исчез.
{player.Name} умер. Полный идиот этот {player.Name}.";
            }
            else if (n == (4, 1) && Flag == "Убийство Аркадия") 
            {
                player.Coins += 50;
                player.Health = 0;
                s = $@"{player.Name} из прошлого кинул 50 монет настоящему {player.Name}у.
Затем, настоящий {player.Name} убежал от него. Через какое-то время он просто пропал.
{player.Name}а теперь не существует.";
            }
            else if (n == (4, 2) && Flag == "Убийство Аркадия") 
            {
                player.Coins = 50;
                player.Health = 0;
                s = $@"{player.Name} из настоящего бросает свои последние деньги {player.Name}у из прошлого.
Однако молодой {player.Name} тоже бросает 50 монет и в испуге убегает к торговцу, а позже на него падает слон.
{player.Name} из настоящего перестаёт существовать.";
            }
            else if (n == (4, 3) && Flag == "Убийство Аркадия") 
            {
                player.Coins += 50;
                s = $@"{player.Name} из прошлого отдаёт 50 монет {player.Name}у из настоящего,
но {player.Name} из настоящего неожиданно нападает и избивает до полусмерти самого себя из прошлого.
{player.Name} остаётся жить и доживает свои последние годы в своём уютном домике.";
                win = true; // победа
            }
            else if (n == (4, 1) && Flag == "Сделка с Аркадием2") 
            {
                player.Health = 0;
                s = $@"{player.Name} убегает, не веря своим глазам. Однако, вскоре натыкается на какого-то торговца,
который принял {player.Name}а за сумасшедшего и ударил его своим стальным топором.
{player.Name} умер.";
            }
            else if (n == (4, 2) && Flag == "Сделка с Аркадием2") 
            {
                player.Health = 0;
                player.Coins = 0;
                s = $@"{player.Name} отдаёт все свои последние деньги своей более молодой версии и уходит дальше в лес.
Позже, идя по лесу, {player.Name} случайно раздавил крысу. Через секунд 10 на него напал целый рой крыс и съел его заживо.
{player.Name} умер.";
            }
            else if (n == (4, 3) && Flag == "Сделка с Аркадием2") 
            {
                player.Health = 0;
                s = $@"{player.Name} по какой-то неведанной причине решает убить самого себя из прошлого.
У него это получается без каких-либо проблем, так как его более молодая версия была в отключке.
Но сразу же после этого {player.Name} исчез.
{player.Name} умер. Полный идиот этот {player.Name}.";
            }
            else if (n == (4, 1) && Flag == "Убийство Аркадия2") 
            {
                player.Health = 0;
                s = $@"{player.Name} из прошлого догнал и напал на старую версию {player.Name}а.
Молодой {player.Name} убил старого себя.";
            }
            else if (n == (4, 2) && Flag == "Убийство Аркадия2") 
            {
                player.Coins = 0;
                player.Health = 0;
                s = $@"старый {player.Name} бросает свои последние деньги молодому {player.Name}у.
Однако молодой {player.Name} думает, что тот на него напал и убивает его.
{player.Name} умер.";
            }
            else if (n == (4, 3) && Flag == "Убийство Аркадия2") 
            {
                player.Health = 0;
                s = $@"В очень жестокой борьбе молодой {player.Name} убил старого себя и потерял {damage} единц{bi} здоровья.
{player.Name} умер.";
            }
            BeutyText(s, n.Item2.ToString());
            return s;
        }
    }
}
