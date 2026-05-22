using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("--- EJEMPLO LIST --- \n");

        CasoList manejadorList = new CasoList();

        Alumno alumno1 = new Alumno(1, "Juan Perez", 8.5);
        Alumno alumno2 = new Alumno(2, "Maria Lopez", 9.2);
        Alumno alumno3 = new Alumno(3, "Carlos Gomez", 6.8);

        manejadorList.AgregarAlumno(alumno1);
        manejadorList.AgregarAlumno(alumno2);
        manejadorList.AgregarAlumno(alumno3);

        Listar(manejadorList.ObtenerLista());

        Console.WriteLine("\n-> Buscar a 'Maria Lopez'");
        Alumno alumnoEncontrado = manejadorList.BuscarPorNombre("Maria Lopez");
        Mostrar(alumnoEncontrado);

        Console.WriteLine("\n-> Buscar a 'Ana Torres'");
        Alumno alumnoNoExiste = manejadorList.BuscarPorNombre("Ana Torres");
        Mostrar(alumnoNoExiste);

        Console.WriteLine("\n-> Eliminar al alumno 'Carlos Gomez'");
        manejadorList.EliminarAlumno(alumno3);
        Listar(manejadorList.ObtenerLista());

        Console.WriteLine("\n-> Eliminar el primer elemento de la lista ");
        manejadorList.EliminarEnPosicion(0);
        Listar(manejadorList.ObtenerLista());
    }

    private static void Mostrar(Alumno alumno)
    {
        if (alumno != null)
        {
            Console.WriteLine($"Alumno: {alumno}");
        }
        else
        {
            Console.WriteLine("No hay ningun Alumno con ese nombre");
        }
    }

    private static void Listar(List<Alumno> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("La lista quedó vacía.");
        }
        else
        {
            foreach (var alumno in lista)
            {
                Console.WriteLine(alumno);
            }
        }
    }


    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {

    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {

    }
}
