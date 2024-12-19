
class SimonDice
{
    // Inicializar secuencia y función random
    static List<char> secuencia = new List<char>();
    static Random random = new Random();
    static bool error = false;
    static int score = 0;
    static int maxscore = 0;

    static void Main()
    {
        ConsoleKey KeepPlaying = ConsoleKey.Y;

        while (KeepPlaying != ConsoleKey.N)
        {
            // Reiniciar variables
            score = 0;
            error = false;
            secuencia.Clear();

            // Mostrar pantalla de inicio
            MostrarPantallaInicio();

            // Bucle principal del juego
            while (true)
            {
                if (!error)
                {
                    AgregarALaSecuencia();
                    MostrarSecuencia();
                }

                LeerSecuencia();
                if (error)
                    break;

                Console.Clear();
                Console.WriteLine("¡Correcto! Sigue así...\n");

                // Añadir puntos
                score += 10;

                // Mostrar puntuación
                MostrarPuntuacion();

                // Actualizar maxscore
                if (maxscore < score)
                {
                    maxscore = score;
                }

                Thread.Sleep(1500);
            }

            // Mostrar mensaje de fin de juego
            MostrarFinDelJuego();

            // Preguntar si quiere seguir jugando
            KeepPlaying = PreguntarReinicio();
        }
    }

    static void MostrarPantallaInicio()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();

        string SimónDice =
            @"  
            ------------------------------------------------------------
            |     _____ _                         _____  _             |
            |    / ____(_)                       |  __ \(_)            |
            |   | (___  _ _ __ ___   ___  _ __   | |  | |_  ___ ___    |
            |    \___ \| | '_ ` _ \ / _ \| '_ \  | |  | | |/ __/ _ \   |
            |    ____) | | | | | | | (_) | | | | | |__| | | (_|  __/   |
            |   |_____/|_|_| |_| |_|\___/|_| |_| |_____/|_|\___\___|   |
            |                                                          |
            ------------------------------------------------------------
            ";

        Console.WriteLine(SimónDice);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("     COMO JUGAR:\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("     Simón te mostrará un patrón de colores aleatorio que tendrás que memorizar\n     y pulsar las teclas asignadas a cada color para repetir la secuencia.");
        Console.WriteLine("\n     Por cada ronda terminada obtendrás 10 puntos.");
        Console.WriteLine("\n     En caso de fallar algún color, se acabará el juego.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("     PRESIONA CUALQUIER TECLA PARA EMPEZAR...\n");
        Console.ReadKey();
        Console.Clear();
        MostrarPantallaDividida();
        Thread.Sleep(2000);
        Console.Clear();
    }

    static void MostrarPantallaDividida()
    {
        MostrarCuadrante(0, 0, ConsoleColor.Red);
        MostrarCuadrante(Console.WindowWidth / 2, 0, ConsoleColor.Green);
        MostrarCuadrante(0, Console.WindowHeight / 2, ConsoleColor.Blue);
        MostrarCuadrante(Console.WindowWidth / 2, Console.WindowHeight / 2, ConsoleColor.Yellow);
    }

    static void MostrarCuadrante(int startX, int startY, ConsoleColor color)
    {
        int width = Console.WindowWidth / 2;
        int height = Console.WindowHeight / 2;

        Console.BackgroundColor = color;
        for (int y = startY; y < startY + height; y++)
        {
            Console.SetCursorPosition(startX, y);
            Console.Write(new string(' ', width));
        }
        Console.ResetColor();
    }
    static void AgregarALaSecuencia()
    {
        char[] colores = { 'R', 'V', 'A', 'B' };
        secuencia.Add(colores[random.Next(0, 4)]);
    }

    static void MostrarSecuencia()
    {
        foreach (char color in secuencia)
        {
            MostrarUnicoColor(color);
            Thread.Sleep(1100);
            Console.Clear();
            MostrarPantallaDividida();
            Thread.Sleep(800);
        }
    }
    static void MostrarUnicoColor(char color)
    {
        Console.Clear();
        switch (color)
        {
            case 'R':
                MostrarCuadrante(0, 0, ConsoleColor.Red);
                break;
            case 'V':
                MostrarCuadrante(Console.WindowWidth / 2, 0, ConsoleColor.Green);
                break;
            case 'A':
                MostrarCuadrante(Console.WindowWidth / 2, Console.WindowHeight / 2, ConsoleColor.Yellow);
                break;
            case 'B':
                MostrarCuadrante(0, Console.WindowHeight / 2, ConsoleColor.Blue);
                break;
        }
    }

    static void LeerSecuencia()
    {
        Console.Clear();

        foreach (char color in secuencia)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n       Presiona la tecla que corresponde al color:  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("       R (Rojo)");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("      V (Verde) ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("      A (Amarillo)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("      B (Azul) ");

                char entrada = char.ToUpper(Console.ReadKey().KeyChar);

                if (entrada != 'R' && entrada != 'V' && entrada != 'A' && entrada != 'B')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nEntrada inválida. Debes presionar una de las teclas: R, V, A, B.\n");
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.White;

                if (entrada != color)
                {
                    error = true;
                    return;
                }

                break;
            }
        }
    }
    static void MostrarPuntuacion()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("************************************");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Tus Puntos son: " + score);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("************************************");
    }

    static void MostrarFinDelJuego()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n       ¡Has cometido un error! Fin del juego.\n\n\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("       ***************************************");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("        Tus Puntos totales son: " + score + " puntos");
        Console.WriteLine("        Tu mejor puntuaje ha sido de: " + maxscore + " puntos");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("       ***************************************");

        // Mostrar la secuencia correcta
        Console.Write("\n        El patrón correcto era: ");
        foreach (char color in secuencia)
        {
            switch (color)
            {
                case 'R': Console.ForegroundColor = ConsoleColor.Red; Console.Write("R "); break;
                case 'V': Console.ForegroundColor = ConsoleColor.Green; Console.Write("V "); break;
                case 'A': Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("A "); break;
                case 'B': Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("B "); break;
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("\n\n       ***************************************");
    }

    static ConsoleKey PreguntarReinicio()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n       ¿Quieres intentarlo de nuevo? (Y/N)");

        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
        } while (key != ConsoleKey.Y && key != ConsoleKey.N);

        return key;
    }
}
