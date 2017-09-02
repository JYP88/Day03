using System;



namespace Day03

{

    class Program

    {
        static bool isRunning = true;

        static void Main(string[] args)

        {


            int[,] map =

            {

                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

                {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},

                {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},

                {1, 0, 1, 1, 1, 1, 0, 0, 0, 1},

                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1},

                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1},

                {1, 1, 1, 1, 0, 1, 0, 0, 0, 1},

                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},

                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},

                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}

            }; //10 x 10 Array



            int playerX = 1;

            int playerY = 1;

            Random gRandom = new Random();
            int goalX = gRandom.Next(1, 8);
            int goalY = gRandom.Next(1, 8);
            map[goalY, goalX] = 2;

            while (isRunning)

            {

                string key = Input();

                Process(key , ref playerX, ref playerY, map);

                Clear();

                Render(map, playerX, playerY);

            }

        }



        static string Input()

        {

            ConsoleKeyInfo info =  Console.ReadKey();
            info.Key.ToString();

            return info.Key.ToString();

        }



        static int Process(string key, ref int playerX, ref int playerY, int[,] map)

        {

            //여기는 처리 

            if (key == "UpArrow")

            {
                if (map[playerY - 1, playerX] != 1)
                    playerY--;
            }
            else if (key == "DownArrow")
            {
                if (map[playerY + 1, playerX] != 1)
                    playerY++;
            }
            else if (key == "LeftArrow")
            {
                if (map[playerY , playerX - 1] != 1)
                    playerX--;
            }
            else if (key == "RightArrow")
            {
                if (map[playerY , playerX + 1] != 1)
                    playerX++;
            }

            if (map[playerY, playerX] == 2)
            {
                isRunning = false;
            }

            return 0;

        }



        static void Clear()

        {

            Console.Clear();

        }



        static void Render(int[,] _map, int playerX, int playerY)

        {

            for (int y = 0; y < 10; ++y)

            {

                for (int x = 0; x < 10; ++x)

                {

                    if (_map[y, x] == 1)

                    { //맵 데이터에 1이면 출력

                        Console.Write(_map[y, x]);

                    }

                    else if (playerX == x && playerY == y)

                    { //주인공 위치에는 P를 출력

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("P");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    else if (_map[y, x] == 2)

                    { //맵 데이터에 1이면 출력

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("G");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    else

                    { //맵데이터에 0 이면 공백 출력

                        Console.Write(" ");

                    }

                    Console.Write(" "); // 이쁘게 하기 위해서 출력

                }

                Console.WriteLine();

            }

        }

    }

}
