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

                foreach (var item in _hijos) // AQUÍ SUMAS TODO
                {
                    total += item.ObtenerPrecio;
                }

                return total;
            }
        }
    }
}