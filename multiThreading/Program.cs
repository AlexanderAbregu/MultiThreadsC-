using System;
using System.Threading;

namespace MultithreadingApplication
{
    // Contiene la funcion a ejecutar por los Threads y los datos
    public class claseCaja
    {
        int[] clientes;
        int numeroCaja;

        // El constructor
        public claseCaja()
        {
            clientes = new int[0];
            numeroCaja = 0;
        }
        public claseCaja(int[] listaClientes, int numeroC)
        {
            clientes = listaClientes;
            numeroCaja = numeroC;
        }

        // Esta es la funcion que ejecutan los Threads
        public void Caja()
        {
            // Se repite una vez por cada elemento en la lista de clientes
            for (int i = 0; i < clientes.Length; i++)
            {
                // Solo para que se visualize mejor
                if (numeroCaja == 2) Console.Write("\t\t\t\t");
                Console.WriteLine(" - Cajera {0} comienza con el cliente {1}.", numeroCaja, (i + 1));

                // Antes de terminar esta "vuelta" y de mostrar el texto que esta mas abajo va a esperar el tiempo que le diga el elemento actual en el Array ( En milisegundos ).
                Thread.Sleep(clientes[i] * 1000);

                if (numeroCaja == 2)Console.Write("\t\t\t\t");
                Console.WriteLine(" - Cajera {0} termino con el cliente {1}, le llevo {2} segundos.\n", numeroCaja, (i + 1), (clientes[i]));
            }
        }

    }

    class ThreadCreationProgram
    {
        static void Main(string[] args)
        {
            // Creo dos arrays numericos que representan la cantidad de clientes y cada numero la cantidad de productos que llevan.
            int[] listaClientes1 = {1,5,3};
            int[] listaClientes2 = {2,1,1,3};

            // Se crean los dos objetos y se le pasa por parametro al constructor la lista de clientes y el numero de caja
            // Dentro de este objeto, se encuentra la funcion que manejaran los Threads
            claseCaja cajera1 = new claseCaja(listaClientes1, 1);
            claseCaja cajera2 = new claseCaja(listaClientes2, 2);

            // Creo las funciones "hijo" de los Threads y le paso por parametro la funcion que tienen que ejecutar
            ThreadStart threadChild1 = new ThreadStart(cajera1.Caja);
            ThreadStart threadChild2 = new ThreadStart(cajera2.Caja);

            // Se crean los Threads y se les asignan los hijos
            Thread childThread1 = new Thread(threadChild1);
            Thread childThread2 = new Thread(threadChild2);

            // Comienza la ejecucion de los dos Threads
            childThread1.Start();
            childThread2.Start();

            Console.ReadKey();
        }

    }
}