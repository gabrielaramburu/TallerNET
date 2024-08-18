using _01_02c_EjemploList;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
// See https://aka.ms/new-console-template for more information

primerCaso();
segundoCaso();
tercerCaso();
cuartoCaso();

quintoCaso();
sextoCaso();
casoSeptimo();


/*  Si no redefino el método equals de Tarea, esto no funciona
    ya que hay dos instancias que representan lo mismo (100, Tarea1)
    */
void primerCaso()
{
    List<Tarea> _tareas = new List<Tarea>();
    Console.WriteLine("(\"***********Primer caso");
    _tareas.Add(new Tarea(100, "Tarea1")); //esto es una instancia
    _tareas.Add(new Tarea(101, "Tarea2"));
    _tareas.Add(new Tarea(102, "Tarea3"));

    Console.WriteLine(String.Join("\n", _tareas));
  

    Console.WriteLine("Borro tarea 100");
    _tareas.Remove(new Tarea(100, "Tarea1")); //esto es otra instancia distinta

    Console.WriteLine(String.Join("\n", _tareas));
}

/* Esto si funciona ya que las instancias son las mismas.
 Sin embargo lo normal es que no tenga disponible en mi códgo las intancias
De hecho, tiene poco sentido realizar una búsqueda de una instancia que ya conozco*/
void segundoCaso()
{
    List<Tarea> _tareas = new List<Tarea>();
    Console.WriteLine("*********** Segundo caso");
    Tarea t1 = new Tarea(100, "Tarea1");
    Tarea t2 = new Tarea(101, "Tarea2");
    Tarea t3 = new Tarea(102, "Tarea3");
    _tareas.Add(t1);
    _tareas.Add(t2);
    _tareas.Add(t3);

    Console.WriteLine(String.Join("\n", _tareas));
   
    Console.WriteLine("Borro tarea 100");
    _tareas.Remove(t1);

    Console.WriteLine(String.Join("\n", _tareas));
}

/* Si bien en este caso también utilizo dos instancias distintas,
 * el remove determina la igualdad del objeto según lo que esté implementado 
 * en el método equals
 * Por lo tanto este caso funciona y es el más común*/
void tercerCaso()
{
    List<Tarea2> _tareas = new List<Tarea2>();
    Console.WriteLine("***********Tercer caso");
    _tareas.Add(new Tarea2(100, "Tarea1")); //esto es una instancia
    _tareas.Add(new Tarea2(101, "Tarea2"));
    _tareas.Add(new Tarea2(102, "Tarea3"));

    Console.WriteLine(String.Join("\n", _tareas));


    Console.WriteLine("Borro tarea 100");
    _tareas.Remove(new Tarea2(100, "Tarea1")); //esto es otra instancia distinta

    Console.WriteLine(String.Join("\n", _tareas));
}

/* Esto funciona, pero se hace una doble recorrida de la lista
 * Es muy ineficiente */
void cuartoCaso()
{
    List<Tarea> _tareas = new List<Tarea>();
    Console.WriteLine("***********Cuarto caso");
    _tareas.Add(new Tarea(100, "Tarea1")); 
    _tareas.Add(new Tarea(101, "Tarea2"));
    _tareas.Add(new Tarea(102, "Tarea3"));

    Console.WriteLine(String.Join("\n", _tareas));

    var tarea = _tareas.FirstOrDefault(t => t.Id == 100);

    Console.WriteLine("Borro tarea 100");
    _tareas.Remove(tarea); 

    Console.WriteLine(String.Join("\n", _tareas));
}


/* Busco dos veces
 * FirstOrDefault hace su búsqueda
 * y el Remove hace la propia
 */
void quintoCaso()
{
    Console.WriteLine("*** Inicio Caso quinto");
    List<Tarea> _tareas = _InicializarTareas();
    Stopwatch medidor = Stopwatch.StartNew();
    var tarea = _tareas.FirstOrDefault(t => t.Id == 9998);

    Console.WriteLine("Borro tarea 9998");
    _tareas.Remove(tarea);
    medidor.Stop();

    Console.WriteLine($"Tiempo: {medidor.Elapsed.TotalMilliseconds} ms");
}

/* Caso correcto, solo busco una vez
 Tener en cuenta que la primera vez que se ejecuta el ejemplo los tiempos
no puedan ser correctos (seguramente debido a las optimizaciones del JIT)
*/
void sextoCaso()
{
    Console.WriteLine("*** Inicio Caso sexto");
    List<Tarea2> _tareas = _InicializarTareas2();

    Stopwatch medidor = Stopwatch.StartNew();
    
    Console.WriteLine("Borro tarea 9998");
    _tareas.Remove(new Tarea2(9998,""));
    medidor.Stop();

    Console.WriteLine($"Tiempo: {medidor.Elapsed.TotalMilliseconds} ms");
}

/* Un Dictionario o Map, es una estructura que me permite almacenar valor
 y asociarlos a una clave.
Luego puedo acceder a dichos valores usando su clave
La complejidad del acceso a los valores es de O(1). 
(esto puede cambiar en caso de colisión de claves)

Las claves se almacenan en un array.
Para evitar tener arrays muy largos, previamente la clave se reduce y 
se calcula el valor hash de dicha reducción
Si dos claves generan el mismo hash, el elemento se agrega en una lista.
Un Map no permite claves duplicadas

Es una estructura muy usuada y muy eficiente.
*/
void casoSeptimo()
{
    Console.WriteLine("*** Inicio Caso septimo");
    Dictionary<int, Tarea> _tareas = new Dictionary<int, Tarea>();
    _tareas.Add(100, new Tarea(100,"Tarea100"));
    _tareas.Add(5000, new Tarea(5000, "Tarea5000"));
    _tareas.Add(6000, new Tarea(6000, "Tarea6000"));

    Console.WriteLine(_tareas[6000]);

    Console.WriteLine("Lista de claves");
    foreach (int key in _tareas.Keys)
    {
        Console.WriteLine(key);
    }
    Console.WriteLine("Lista de valores");
    foreach (Tarea tarea in _tareas.Values)
    {
        Console.WriteLine(tarea);
    }
}
List<Tarea> _InicializarTareas()
{
    List<Tarea> _tareas = new List<Tarea>();
    for(int i= 0; i<10000; i++)
    {
        _tareas.Add(new Tarea(i, "Tarea" + 1));
    }
    return _tareas;
}

List<Tarea2> _InicializarTareas2()
{
    List<Tarea2> _tareas = new List<Tarea2>();
    for (int i = 0; i < 10000; i++)
    {
        _tareas.Add(new Tarea2(i, "Tarea" + 1));
    }
    return _tareas;
}