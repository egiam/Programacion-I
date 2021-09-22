using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Parcial2_Vinos
{
    class Vino
    {
        private int codigo;

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nombre;

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private double precio;

        public double pPrecio
        {
            get { return precio; }
            set { precio = value; }
        }
        private int bodega  ;


        public int pBodega
        {
            get { return bodega; }
            set { bodega = value; }
        }

        public Vino()
        {
            this.codigo = 0;
            this.nombre = "";
            this.precio = 0;
            this.bodega = 0;
        }

        public Vino(int codigo, string nombre, double precio, int bodega)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.bodega = bodega;
        }

        public override string ToString()
        {
            return codigo + " - " + nombre + " - " + precio;
        }
    }
}
