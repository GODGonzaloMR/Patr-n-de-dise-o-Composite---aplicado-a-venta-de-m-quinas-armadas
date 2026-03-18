using System;
using System.Collections.Generic;

namespace composite
{
    public class Archivo : Componente          // todo esto es el prducto
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
            // No hace nada (es hoja)
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