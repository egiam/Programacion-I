using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Parcial1
{
    class Viaje
    {
        private int numeroViaje;
        private string lugarDestino;
        private double costoUnitario;
        private int tipoTransporte;     //1-Aereo  - 2-Terrestre 
        private Estudiante[] viajeros;
        private int ultimo;

        public Viaje()
        {
            this.numeroViaje = 0;
            this.lugarDestino = "";
            this.costoUnitario = 0;
            this.tipoTransporte = 0;
            this.viajeros = new Estudiante[50];
            this.ultimo = 0;
        }
        public int pNumeroViaje
        {
            get { return numeroViaje; }
            set { numeroViaje = value; }
        }
        public string pLugarDestino
        {
            get { return lugarDestino; }
            set { lugarDestino = value; }
        }
        public double pCostoUnitario
        {
            get { return costoUnitario; }
            set { costoUnitario = value; }
        }
        public int pTipoTransporte
        {
            get { return tipoTransporte; }
            set { tipoTransporte = value; }
        }
        public Estudiante[] pViajeros
        {
            get { return viajeros; }
            set { viajeros = value; }
        }
        public string MostrarViaje()
        {
            string aux = "";
            aux+= "| Viaje Nº: " + numeroViaje + "| Destino: " + lugarDestino + "| Costo: $" + costoUnitario;
            if (tipoTransporte == 1)
                aux += "| Transporte: Aereo";
            else
                aux += "| Transporte: Terrestre";

            return aux;
        }


        public void RegistrarEstudiante(Estudiante oEstudiante)
        {
            if (ultimo < viajeros.Length)
            {
                viajeros[ultimo] = oEstudiante;
                ultimo++;

            }

        }

        public string MostrarPorsentaje()
        {
            int contador = 0;
            for (int i = 0; i < ultimo; i++)
            {
                if (viajeros[i] != null && viajeros[i].pPromedio >= 6)
                {
                    contador++;

                }
            }

            double porcentaje = (contador * 100) / ultimo;

            return porcentaje + "%";

        }

        public string CostoTotal()
        {
            //int contador = 0;

            //for(int i = 0; i < ultimo; i++)
            //{
            //    if (viajeros[i] != null)
            //    {
            //        contador++;

            //    }

            //}

            double costoTotal = ultimo * costoUnitario;

            return "$" + costoTotal;

        }

    }
}
