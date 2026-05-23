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
        Console.WriteLine("--- EJEMPLO DICTIONARY --- \n");

        CasoDictionary manejadorDiccionario = new CasoDictionary();

        Alumno alumno1 = new Alumno(101, "Esteban lopez", 7.5);
        Alumno alumno2 = new Alumno(102, "Jose Gallo", 8.9);
        Alumno alumno3 = new Alumno(103, "Andres Berra", 6.2);

        manejadorDiccionario.AgregarAlumno(alumno1);
        manejadorDiccionario.AgregarAlumno(alumno2);
        manejadorDiccionario.AgregarAlumno(alumno3);
        
        Console.WriteLine("\n--- Lista de Alumnos ---");
        Listar(manejadorDiccionario.ObtenerDiccionario().Values.ToList());

        Console.WriteLine("\n Buscar alumno con legajo 102");
        Mostrar(manejadorDiccionario.BuscarPorClave(102));

        Console.WriteLine("\n-> Buscar alumno con legajo 999...");
        Mostrar(manejadorDiccionario.BuscarPorClave(999));

        
        Console.WriteLine("\n-> Eliminando al alumno con legajo 103...");
        manejadorDiccionario.EliminarPorClave(103);
        Listar(manejadorDiccionario.ObtenerDiccionario().Values.ToList());
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("--- EJEMPLO LINQ --- \n");

        List<Libro> todosLosLibros = Libro.CrearLista();
        CasoLinq consultaLinq = new CasoLinq(todosLosLibros);

        var primero = consultaLinq.GetPrimero();
        Console.WriteLine($"1. Primer libro: {primero.Titulo} (ID: {primero.Id})");

        var ultimo = consultaLinq.GetUltimo();
        Console.WriteLine($"2. Último libro: {ultimo.Titulo} (ID: {ultimo.Id})");

        Console.WriteLine($"3. Suma total de precios: {consultaLinq.GetTotalPrecios():C}");

        decimal promedio = consultaLinq.GetPromedioPrecios();
        Console.WriteLine($"4. Promedio de precios: {promedio:C}");

        Console.WriteLine("\n5. Libros con ID mayor a 15 (Primeros 5 resultados):");
        var listaIdMayor15 = consultaLinq.GetListById();
        ImprimirMuestraLibros(listaIdMayor15, 5);

        Console.WriteLine("\n6. Lista en formato Título - Moneda (Primeros 5 resultados):");
        var listaCadenas = consultaLinq.GetLibros();
        for (int i = 0; i < Math.Min(5, listaCadenas.Count); i++)
        {
            Console.WriteLine($"   * {listaCadenas[i]}");
        }

        var masCaro = consultaLinq.GetMayorPrecio();
        Console.WriteLine($"\n7. Libro más caro: {masCaro.Titulo} ({masCaro.Precio:C})");

        var masBarato = consultaLinq.GetMenorPrecio();
        Console.WriteLine($"8. Libro más barato: {masBarato.Titulo} ({masBarato.Precio:C})");

        Console.WriteLine($"\n9. Libros con precio mayor al promedio ({promedio:C}) (Primeros 5 resultados):");
        var listaMayorPromedio = consultaLinq.GetMayorPromedio();
        ImprimirMuestraLibros(listaMayorPromedio, 5);

        Console.WriteLine("\n10. Libros ordenados por Título Z-A (Primeros 5 resultados):");
        var listaOrdenada = consultaLinq.GetLibrosOrdenadosPorTituloDesc();
        ImprimirMuestraLibros(listaOrdenada, 5);
    }

    private static void ImprimirMuestraLibros(List<Libro> libros, int cantidad)
    {
        int limite = Math.Min(cantidad, libros.Count);
        for (int i = 0; i < limite; i++)
        {
            Console.WriteLine($"   [{libros[i].Id}] {libros[i].Titulo} - {libros[i].Precio:C}");
        }
        if (libros.Count > cantidad)
        {
            Console.WriteLine($"   ... y {libros.Count - cantidad} libros más.");
        }
    }
}
