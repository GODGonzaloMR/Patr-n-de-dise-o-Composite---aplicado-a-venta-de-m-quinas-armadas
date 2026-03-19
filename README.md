# Patrón de Diseño: Composite
## Nombre del alumno: Gonzalo Cortez Huerta
## No.Control: 22210761
## Materia: Patrones de diseño
## Docente: Maribel Guerrero Luis
### Sistema de Tienda de Computadoras en C#

# ¿Qué es el patrón de diseño Composite?

El patrón de diseño Composite es un **patrón estructural** que permite componer objetos en estructuras de árbol para representar relaciones 

Su principal ventaja es que permite tratar **objetos individuales** y **grupos de objetos** de la misma manera.

Su principal desventaja es que puede hacer más complejo el diseño del sistema.

---

##  1. Componente.cs (LA BASE)

>  Este es el corazón del patrón
>  Aquí defines lo que TODOS van a tener

```csharp
using System.Collections.Generic;

namespace composite
{
    public abstract class Componente
    {
        string _nombre;

        public Componente(string nombre)
        {
            _nombre = nombre;
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public abstract void AgregarHijo(Componente c);
        public abstract IList<Componente> ObtenerHijos();
        public abstract double ObtenerPrecio { get; }
    }
}
```

---

##  2. Directorio.cs (COMPOSITE = COMPUTADORA)

>  Este es el que contiene otros componentes
>  Aquí va el foreach importante

```csharp
using System.Collections.Generic;

namespace composite
{
    public class Directorio : Componente
    {
        private List<Componente> _hijos;

        public Directorio(string nombre) : base(nombre)
        {
            _hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos.ToArray();
        }

        public override double ObtenerPrecio
        {
            get
            {
                double total = 0;

                foreach (var item in _hijos)
                {
                    total += item.ObtenerPrecio;
                }

                return total;
            }
        }
    }
}
```

---

##  3. Archivo.cs (LEAF = PRODUCTO)

>  Aquí van los componentes individuales
> (RAM, GPU, disco, gabinete, etc.)

```csharp
using System;
using System.Collections.Generic;

namespace composite
{
    public class Archivo : Componente
    {
        double _precio;
        string _marca;
        string _descripcion;
        string _color;

        public Archivo(string nombre, string marca, string color, string descripcion, double precio)
            : base(nombre)
        {
            _marca = marca;
            _descripcion = descripcion;
            _color = color;
            _precio = precio;
        }

        public override void AgregarHijo(Componente c)
        {
        }

        public override IList<Componente> ObtenerHijos()
        {
            return null;
        }

        public override double ObtenerPrecio
        {
            get { return _precio; }
        }

        public void Mostrar()
        {
            Console.WriteLine($"{Nombre} - {_marca} - {_descripcion} - {_color} - ${_precio}");
        }
    }
}
```

---

##  4. Program.cs (AQUÍ ARMAS TODO)

>  Aquí creas:
> - PCs
> - Productos
> - Raíz (tienda)

```csharp
using System;

namespace composite
{
    class Program
    {
        static void MostrarComponentes(Componente comp)
        {
            Console.WriteLine("\nComponentes:");

            var hijos = comp.ObtenerHijos();

            if (hijos != null)
            {
                foreach (var item in hijos)
                {
                    Console.WriteLine("- " + item.Nombre + " ($" + item.ObtenerPrecio + ")");
                }
            }
        }

        static void Main(string[] args)
        {
            //  PC LUJOSA
            Componente pcLujosa = new Directorio("PC Lujosa");

            pcLujosa.AgregarHijo(new Archivo("RAM 32GB", "Corsair", "RGB", "DDR5", 3000));
            pcLujosa.AgregarHijo(new Archivo("RAM 32GB", "Corsair", "RGB", "DDR5", 3000));
            pcLujosa.AgregarHijo(new Archivo("GPU RTX 4090", "NVIDIA", "Negro", "Alta gama", 25000));
            pcLujosa.AgregarHijo(new Archivo("Gabinete RGB", "NZXT", "Blanco", "Con luces", 2500));

            //  PC MEDIA
            Componente pcMedia = new Directorio("PC Media");

            pcMedia.AgregarHijo(new Archivo("RAM 16GB", "Kingston", "Negro", "DDR4", 1200));
            pcMedia.AgregarHijo(new Archivo("GPU RTX 3060", "NVIDIA", "Negro", "Gama media", 8000));

            // PC BÁSICA
            Componente pcBasica = new Directorio("PC Básica");

            pcBasica.AgregarHijo(new Archivo("RAM 8GB", "Kingston", "Negro", "DDR4", 500));
            pcBasica.AgregarHijo(new Archivo("Disco 1TB", "WD", "Negro", "HDD", 600));

            int opcion;

            do
            {
                Console.WriteLine("\n===== MENÚ =====");
                Console.WriteLine("1. Ver PC Lujosa");
                Console.WriteLine("2. Ver PC Media");
                Console.WriteLine("3. Ver PC Básica");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n--- PC LUJOSA ---");
                        MostrarComponentes(pcLujosa);
                        Console.WriteLine("Total: $" + pcLujosa.ObtenerPrecio);
                        break;

                    case 2:
                        Console.WriteLine("\n--- PC MEDIA ---");
                        MostrarComponentes(pcMedia);
                        Console.WriteLine("Total: $" + pcMedia.ObtenerPrecio);
                        break;

                    case 3:
                        Console.WriteLine("\n--- PC BÁSICA ---");
                        MostrarComponentes(pcBasica);
                        Console.WriteLine("Total: $" + pcBasica.ObtenerPrecio);
                        break;

                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

            } while (opcion != 4);

            Console.ReadLine();
        }
    }
}
```

<img width="305" height="172" alt="image" src="https://github.com/user-attachments/assets/9fce5556-d206-46e3-bbb8-286a64c8dcc3" />

## Ejecución

![image.avif](https://user5014.na.imgto.link/public/20260319/image.avif)

![image.avif](https://user5014.na.imgto.link/public/20260319/image-2.avif)


## Diagrama UML

[![image.png](https://i.postimg.cc/fb5grrKR/image.png)](https://postimg.cc/8FJHFw92)

---

## 6. CONCLUSIÓN (PROPIA)

El patrón Composite facilita la organización de sistemas complejos como el armado de computadoras, ya que permite tratar tanto componentes individuales como conjuntos de componentes de manera uniforme. En este proyecto se logró representar una estructura jerárquica donde cada computadora puede contener diferentes piezas, y mediante el uso de un recorrido con `foreach` se obtiene el precio total de forma automática. Esto hace que el sistema sea flexible, escalable y fácil de mantener.

---

##  7. REFERENCIAS (APA 7)

- Refactoring Guru. (2024). Composite en C#. https://refactoring.guru/es/design-patterns/composite/csharp/example
- Refactoring Guru. (2024). Composite. https://refactoring.guru/es/design-patterns/composite
