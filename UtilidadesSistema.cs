using System.Text.RegularExpressions;

namespace UtilidadesSistema
{
    public class Funciones
    {
        public static int countAlumn = 0;
        public static List<String> alumnos = new(); // Aqui se almacenan los datos desde el archivo
        public static string alumPrincipal = "";    // Se almacena el alumno principal actual
        public static string alumSecundario = ""; // Se almacena el alumno secundatio actual

        static void SeleccionarAndCompararAlumnoPricipal()
        {
            //Si son iguales se repite la seleccion hasta que no sean iguales
            //De lo contrario sale del if y detiene el bucle infinito de la seleccion
            do
            {
                if (alumnos.Count == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nSolo queda un alumno y por lo tanto " +
                    "se asignará su proyecto y lo presentará.");
                    Console.Write("\nPresione una tecla para continuar: ");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    alumnos.Remove(alumPrincipal);
                    EstablecerAlumnoPrincipal();
                }
            } while (alumSecundario == alumPrincipal);

        }

        static void SeleccionarAndCompararAlumnoSecundario()
        {
            //Si son iguales se repite la seleccion hasta que no sean iguales
            //De lo contrario sale del if y detiene el bucle infinito de la seleccion
            do
            {
                if (alumnos.Count == 1)
                {

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nSolo queda un alumno y por lo tanto " +
                    "se asignará su proyecto y lo presentará.");
                    Console.Write("\nPresione una tecla para continuar: ");
                    Console.ReadLine();

                    break;
                }
                else
                {
                    alumnos.Remove(alumSecundario);
                    EstablecerAlumnoSecundario();
                }
            } while (alumSecundario == alumPrincipal);
        }

        static void SeleccionarAlumnos()
        {
            
            //Este metodo verifica que los alumnos no sean iguales
            // y si solo queda uno pues sera quien se asigna el proyecto
            // y lo presentara tambien
            //alumnos.Remove("Alberto José Guzmán Beltre");
            countAlumn = alumnos.Count;

            //Si el arreglo que contiene los participante esta vacio
            //Pues se presenta si quieres inicial el programa de cero o salir
            if (countAlumn == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nLos participantes participaron " +
                "todos o algunos no estuvieron en la clase y fueron desplazados.");
                Console.Write("\nPresione una tecla para salir: ");
                Console.ReadLine();
                Environment.Exit(0);
                //Se debe preguntar si se quiere reiniciar el programa desde cero
            }
            else if (countAlumn == 1)
            {
                //Si el arreglo que contiene los participante tiene un solo elemento
                //Entonces Hace toda la participacion
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nSolo queda un alumno y por lo tanto " +
                "se asignará su proyecto y lo presentará.");
                Console.Write("\nPresione una tecla para continuar: ");
                Console.ReadLine();
                MensajeSubMenuPrincipalConSeleccion();
                Console.Write("\nPresione una tecla para continuar: ");
                Console.ReadLine();
                SistemaAleatorio.Program.FinPrograma();
              
            }
            else
            {
                do
                {
                    //Si son iguales se repite la seleccion hasta que no sean iguales
                    //De lo contrario sale del if y detiene el bucle infinito de la seleccion

                    EstablecerAlumnoPrincipal();
                    EstablecerAlumnoSecundario();

                } while (alumPrincipal == alumSecundario);
            }
        }

        public static void EstablecerAlumnoPrincipal()
        {
            //Aqui se seleccion el alumno principal 
            //de manera aleatoria en cada ocacion eso cambia
            try
            {
                int numAleatorio = new Random().Next(0, alumnos.Count-1);
                alumPrincipal = alumnos[numAleatorio];
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\nNo quedan mas participantes");
                Console.Write("\nPresione una tecla para salir: ");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        static void EstablecerAlumnoSecundario()
        {
            //Aqui se selecciona el alumno secundario

            try
            {
                int numAleatorio = new Random().Next(0, alumnos.Count-1);
                alumSecundario = alumnos[numAleatorio];

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\nNo quedan mas participantes");
                Console.Write("\nPresione una tecla para salir: ");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        static void Asistencia(string alum, string mensaje)
            //Solo muestra un mensaje que indica y pregunta si el usuario asistio la clase
        {
            if (alumnos.Count == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nHasta pronto.\nPresione una tecla para salir: ");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nResponda con");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" [s] para si o [n] para no.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\nEl participante {mensaje}: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(alum);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" esta presente?: ");
        }

        public static void MensajeSubPrincipal()
        {
            /*Este es la entrada a la funcionalidades del programas
            donde muestra las mayorias de funcionalidades*/

            //Con informacion en la declaracion
            SeleccionarAlumnos();

            //Con informacion en la declaracion
            EstablecerParticipantePrincipal();

            //Con informacion en la declaracion
            EstablecerParticipanteSecundario();
        }

        static void EstablecerParticipantePrincipal()
        {
            // Este metodo verifica que el estudiante se encuentra en la clase
            // y si no esta pues selecciona otro estudiante de la misma manera.
            //Aleatoriamente
            string respuesta;
            do
            {
                //Con informacion en la declaracion
                MensajeSubMenuPrincipalConSeleccion();

                //Con informacion en la declaracion
                Asistencia(alumPrincipal, "principal");

                respuesta = Console.ReadLine()!.ToLower();

                switch (respuesta)
                {
                    case "n":
                        SeleccionarAndCompararAlumnoPricipal();
                        break;
                    case "s":
                        MensajeSubMenuPrincipalConSeleccion();
                        break;
                }
            } while (respuesta != "s");
        }

        static void EstablecerParticipanteSecundario()
        {
            // Este metodo verifica que el estudiante se encuentra en la clase
            // y si no esta pues selecciona otro estudiante de la misma manera.
            //Aleatoriamente
            string respuesta;
            do
            {
                //Con informacion en la declaracion
                MensajeSubMenuPrincipalConSeleccion();

                //Con informacion en la declaracion
                Asistencia(alumSecundario, "secundario");

                respuesta = Console.ReadLine()!.ToLower();

                switch (respuesta)
                {
                    case "n":
                        SeleccionarAndCompararAlumnoSecundario();
                        break;
                    case "s":
                        MensajeSubMenuPrincipalConSeleccion();
                        break;
                }
            } while (respuesta != "s");
        }

        public static void MensajeSubMenuPrincipalConSeleccion()
        {
            //Menu principal que solo muesra informacion de la seleccion
            // del estudiante
            Console.Clear();
            //Puedo poner el menu aqui del segundo menu principal
            if (alumnos.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nAgraciado, has sido seleccionado\n" +
                "para participar en la clase de hoy en vivo, tu nombre es:");

                Console.WriteLine("------------------------------------------------------------\n");

                Console.Write($"El participante principal y a la vez secundario: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Funciones.alumnos[0]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nAlumnos, han sidos seleccionados de manera aleatoria\n" +
                "para participar en la clase de hoy en vivo, sus nombres son:");

                Console.WriteLine("------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"El participante principal.: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Funciones.alumPrincipal);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"El participante secundario: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Funciones.alumSecundario);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        public static void LeerArchivo()
        {

            /*Este metodo lee un archivo txt, lo almacena en un arreglo 
            y para usarlo en el programa principal*/

            alumnos = new List<String>();

            try
            {
                StreamReader archivo = new(@"G:\Git\SistemaAleatorio\listaEstudiantes.txt");

                string alumno = archivo.ReadLine()!;

                while (alumno != null)
                {

                    alumnos.Add(Regex.Replace(alumno, "[0-9]", "").Trim());
                    alumno = archivo.ReadLine()!;
                }

                archivo.Close();

                countAlumn = alumnos.Count;

                if (countAlumn == 0)
                {
                    Console.WriteLine("Sistema trabajando...... vuelva mas tarde.");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Sistema ocupado intentelo mas tarde.");
                Environment.Exit(0);
            }
        }
    }
}