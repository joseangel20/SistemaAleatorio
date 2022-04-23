using System;
using UtilidadesSistema;
namespace SistemaAleatorio
{
    class Program
    {
        static void Main()
        {

            Console.Title = "Selección participacion aleatoria";
            Funciones.LeerArchivo();

            MenuPrincipal();
        }

        static void MensajeMenuPrincipal()
        {
            /*Este metodo da la bienvenida y algunas informaciones principales 
            como guia del programa y algunos formatos de colores*/
            Console.Clear();

            Console.Write("\nBienvenios a su encuentro en vivo");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" de fundamentos de programación.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Por lo tanto preparados deben estar. ");
            Console.WriteLine(DateTime.Now.Date.ToString("dd/M/yyyy"));

            Console.WriteLine("\nSeleccione la opción deseada digitando un valor númerico "
                                + "segun el menu siguiente.");

            Console.WriteLine("\n1- Seleccionar Participantes\n" +
                    "2- Selección actual\n" +
                    "3- ver listado de estudiantes\n" +
                    "4- Detener el programa");
        }

        static void MenuPrincipal()
        {
            //Este es el menu princupal
            string opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                MensajeMenuPrincipal();

                opcion = Console.ReadLine()!;

                //Menu para principal que se muestra
                switch (opcion)
                {
                    case "1":
                        Principal();
                        break;
                    case "2":
                        MenuCasoDos();
                        break;
                    case "3":
                        MenuCasoTres();
                        break;
                    case "4":
                        FinPrograma();
                        break;
                }
            } while (opcion != "4");
        }

        private static void MenuCasoDos()
        {
            //Menu caso dos principal
            Sonido();
            string opcion = "";
            Console.Clear();
            if (Funciones.alumnos.Contains(Funciones.alumPrincipal) ||
            Funciones.alumnos.Contains(Funciones.alumSecundario))
            {
                Funciones.MensajeSubMenuPrincipalConSeleccion();
                ParticipantesActuales(opcion);
            }
            else
            {

                Console.WriteLine("\nNo hay Participantes seleccionados.");
                Console.Write("\nPresione una tecla para continuar.");
                Console.ReadLine();
            }
        }

        static void Principal()
        {
            Sonido();
            Eliminar();
            string opcion = "";

            //Con informacion en la declaracion
            Funciones.MensajeSubPrincipal();

            do
            {

                ParticipantesActuales(opcion);

            } while (true);
        }

        public static void ParticipantesActuales(string opcion)
        {
            do
            {
                Funciones.MensajeSubMenuPrincipalConSeleccion();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nPara continuar interactuando con el sistema digite según el menu.");

                Console.WriteLine("\n1- Nueva selección de participantes\n" +
                    "2- Listar participantes\n3- Reiniciar el sistema\n4- Detener el programa");

                opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Principal();
                        break;
                    case "2":
                        MenuCasoTres();
                        break;
                    case "3":
                        Sonido();
                        do
                        {
                            Funciones.alumPrincipal = "";
                            Funciones.alumSecundario = "";

                            Funciones.LeerArchivo();
                            MensajeMenuPrincipal();
                            opcion = Console.ReadLine()!;
                            switch (opcion)
                            {
                                case "1":
                                    Principal();
                                    break;
                                case "2":
                                    MenuCasoDos();
                                    break;
                                case "3":
                                    Sonido();
                                    MenuCasoTres();
                                    break;
                                case "4":
                                    FinPrograma();
                                    break;
                            }
                        } while (opcion != "3");
                        break;
                    case "4":
                        FinPrograma();
                        break;
                }
            } while (true);
        }

        static void ObtieneMuestaParticipantes(int countAlumn)
        {

            string opcion;
            for (int i = 0; i < countAlumn; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{i + 1,2} {Funciones.alumnos[i]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{(i + 1),2} {Funciones.alumnos[i]}");
                }

                if (i == Funciones.alumnos.Count - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nYa no hay más estudiantes, presione una tecla para continuar: ");
                    Console.ReadKey();
                    Sonido();
                }
                else if ((i + 1) % 10 == 0)
                {

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nDeseas ver más estudiantes?: digite [1], de lo contrario presione una tecla: ");
                    opcion = Console.ReadLine()!;

                    Sonido();

                    if (opcion != "1")
                    {
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                }
            }
        }

        static void MenuCasoTres()
        {
            Sonido();
            string opcion;
            do
            {
                Console.Clear();
                int countAlumn = Funciones.alumnos.Count;

                ObtieneMuestaParticipantes(countAlumn);

                do
                {
                    Console.Clear();
                    if (Funciones.alumnos.Count == 0) Console.WriteLine("\nNo hay participante.");

                    Console.Write("\nPara ir hacia el menu principal digite [1] o [2] detener el programa: ");

                    opcion = Console.ReadLine()!;
                    switch (opcion)
                    {
                        case "1":
                            Sonido();
                            MenuPrincipal();
                            break;
                        case "2":
                            FinPrograma();
                            break;
                    }
                } while (true);
            } while (true);
        }
        public static void FinPrograma()
        {
            Sonido();
            Console.Clear();
            Console.WriteLine("\nHasta la proxima clase.");
            Console.WriteLine("\nPresione una tecla para salir.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void Eliminar()
        {
            try
            {
                if (Funciones.alumnos.Contains(Funciones.alumPrincipal))
                {
                    Funciones.alumnos.Remove(Funciones.alumPrincipal);
                    Funciones.alumPrincipal = "";

                }

                if (Funciones.alumnos.Contains(Funciones.alumSecundario))
                {
                    Funciones.alumnos.Remove(Funciones.alumSecundario);
                    Funciones.alumSecundario = "";
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\nNo quedan mas participantes");
                Console.Write("\nPresione una tecla para salir.");
                Console.ReadKey();
            }
        }
        static void Sonido() => Console.Beep();
    }
}
