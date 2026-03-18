using System;

namespace composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // PC LUJOSA
            Componente pcLujosa = new Directorio("PC Lujosa");

            pcLujosa.AgregarHijo(new Archivo("RAM", "Corsair", "RGB", "32GB", 3000));
            pcLujosa.AgregarHijo(new Archivo("RAM", "Corsair", "RGB", "32GB", 3000));
            pcLujosa.AgregarHijo(new Archivo("GPU", "NVIDIA", "Negro", "RTX 4090", 25000));
            pcLujosa.AgregarHijo(new Archivo("Gabinete", "NZXT", "Blanco", "Con RGB", 2500));

            // PC MEDIA
            Componente pcMedia = new Directorio("PC Media");

            pcMedia.AgregarHijo(new Archivo("RAM", "Kingston", "Negro", "16GB", 1200));
            pcMedia.AgregarHijo(new Archivo("GPU", "NVIDIA", "Negro", "RTX 3060", 8000));
            pcMedia.AgregarHijo(new Archivo("Gabinete", "Genérico", "Negro", "Normal", 700));

            // PC BÁSICA
            Componente pcBasica = new Directorio("PC Básica");

            pcBasica.AgregarHijo(new Archivo("RAM", "Kingston", "Negro", "8GB", 500));
            pcBasica.AgregarHijo(new Archivo("Disco", "WD", "Negro", "1TB", 600));
            pcBasica.AgregarHijo(new Archivo("Gabinete", "Genérico", "Negro", "Simple", 400));

            // RAÍZ
            Componente tienda = new Directorio("Tienda");

            tienda.AgregarHijo(pcLujosa);
            tienda.AgregarHijo(pcMedia);
            tienda.AgregarHijo(pcBasica);

            Console.WriteLine("Precio total tienda: $" + tienda.ObtenerPrecio);
            Console.WriteLine("PC Lujosa: $" + pcLujosa.ObtenerPrecio);
            Console.WriteLine("PC Media: $" + pcMedia.ObtenerPrecio);
            Console.WriteLine("PC Básica: $" + pcBasica.ObtenerPrecio);

            Console.ReadLine();
        }
    }
}