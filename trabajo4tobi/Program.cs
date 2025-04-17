public class Participante
{
    public int NroParticipante { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public double Tiempo { get; set; }
    public int Altura { get; set; }
    public string Categoria { get; set; }


}
class Program
{
    static List<Participante> participantes = new List<Participante>();
    static void Main(string[] args)
    {

        Participante participante = new Participante();
        int nro = 9999;
        do
        {
            Console.WriteLine("ingrese un numero, si ingresa 0 se acaba la carga");
            nro = int.Parse(Console.ReadLine());
            if (nro != 0)
            {
                Console.WriteLine("Ingrese el numero del participante participante");
                participante.NroParticipante = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del participante");
                participante.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del participante");
                participante.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el tiempo que duro dentro de la carrera");
                participante.Tiempo = Double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la altura del participante");
                participante.Altura = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la categoria del participante");
                participante.Categoria = Console.ReadLine();
                participantes.Add(participante);
            }

        } while (nro != 0);




        Participante mejor = mejortiempo();
        if (mejor == null)
        {
            Console.WriteLine("no hay participante");
        }
        else
        {
            Console.WriteLine($"{mejor.Nombre}-{mejor.Tiempo}");
        }
        foreach (var c in obtenercategoria())
        {
            Console.WriteLine($"{mejor.Nombre}-{c}-{mejor.Tiempo}");
        }
        Console.ReadKey();
    }

    static Participante mejortiempo(string cat)
    {
        Participante mejor = null;
        double mejortiempo = double.MaxValue;
        foreach (var p in participantes)
        {
            if (p.Categoria == cat && p.Tiempo < mejortiempo)
            {
                mejor = p;
                mejortiempo = p.Tiempo;
            }
        }
        return mejor;

    }
    static List<string> obtenercategoria()
    {
        List<string> categorias = new();
        foreach (var p in participantes)
        {
            if (!categorias.Contains(p.Categoria))
            {
                categorias.Add(p.Categoria);
            }
        }
        return categorias;
    }
    static Participante mejortiempo()
    {
        if (participantes.Count != 0)
        {
            Participante mejor = null;
            double mejortiempo = double.MaxValue;
            foreach (var p in participantes)
            {
                if (p.Tiempo < mejortiempo)
                {
                    mejortiempo = p.Tiempo;
                    mejor = p;
                }
            }
            return mejor;
        }
        else
            return null;
    }
}