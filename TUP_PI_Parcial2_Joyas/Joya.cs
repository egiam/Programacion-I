using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Parcial2_Joyas
{
    class Joya
    {
        private int codigo;
        private string nombre;
        private int tipo;
        private double precio;

        public Joya()
        {
            this.codigo = 0;
            this.nombre = "";
            this.tipo = 0;
            this.precio = 0;
        }

        public Joya(int codigo, string nombre, int tipo, double precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
        }

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int pTipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public double pPrecio
        {
            get { return precio; }
            set { precio = value; }
        }

        public override string ToString()
        {
            return codigo+" - "+nombre+" - "+precio;
        }
    }
}
