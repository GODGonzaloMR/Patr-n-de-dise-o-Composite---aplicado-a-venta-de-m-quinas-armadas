# Patrón de Diseño: Composite
## Nombre del alumno: Gonzalo Cortez Huerta
## No.Control: 22210761
## Materia: Patrones de diseño
## Docente: Maribel Guerrero Luis
### Sistema de Tienda de Computadoras en C#

# ¿Qué es el patrón de diseño Composite?

El patrón de diseño Composite es un **patrón estructural** que permite componer objetos en estructuras de árbol para representar relaciones de **"parte-todo"**.

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
        static void Main(string[] args)
        {
            Componente pcLujosa = new Directorio("PC Lujosa");

            pcLujosa.AgregarHijo(new Archivo("RAM", "Corsair", "RGB", "32GB", 3000));
            pcLujosa.AgregarHijo(new Archivo("RAM", "Corsair", "RGB", "32GB", 3000));
            pcLujosa.AgregarHijo(new Archivo("GPU", "NVIDIA", "Negro", "RTX 4090", 25000));
            pcLujosa.AgregarHijo(new Archivo("Gabinete", "NZXT", "Blanco", "Con RGB", 2500));

            Componente pcMedia = new Directorio("PC Media");

            pcMedia.AgregarHijo(new Archivo("RAM", "Kingston", "Negro", "16GB", 1200));
            pcMedia.AgregarHijo(new Archivo("GPU", "NVIDIA", "Negro", "RTX 3060", 8000));
            pcMedia.AgregarHijo(new Archivo("Gabinete", "Genérico", "Negro", "Normal", 700));

            Componente pcBasica = new Directorio("PC Básica");

            pcBasica.AgregarHijo(new Archivo("RAM", "Kingston", "Negro", "8GB", 500));
            pcBasica.AgregarHijo(new Archivo("Disco", "WD", "Negro", "1TB", 600));
            pcBasica.AgregarHijo(new Archivo("Gabinete", "Genérico", "Negro", "Simple", 400));

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
```

<img width="305" height="172" alt="image" src="https://github.com/user-attachments/assets/9fce5556-d206-46e3-bbb8-286a64c8dcc3" />

## Ejecución
[![image.png](https://i.postimg.cc/XYFzWgfv/image.png)](https://postimg.cc/mPLwNC6x)


## Diagrama UML

[![image.png](https://i.postimg.cc/fb5grrKR/image.png)](https://postimg.cc/8FJHFw92)

---

## 6. CONCLUSIÓN (PROPIA)

El patrón Composite facilita la organización de sistemas complejos como el armado de computadoras, ya que permite tratar tanto componentes individuales como conjuntos de componentes de manera uniforme. En este proyecto se logró representar una estructura jerárquica donde cada computadora puede contener diferentes piezas, y mediante el uso de un recorrido con `foreach` se obtiene el precio total de forma automática. Esto hace que el sistema sea flexible, escalable y fácil de mantener.

---

##  7. REFERENCIAS (APA 7)

- Refactoring Guru. (2024). Composite en C#. https://refactoring.guru/es/design-patterns/composite/csharp/example
- Refactoring Guru. (2024). Composite. https://refactoring.guru/es/design-patterns/composite
