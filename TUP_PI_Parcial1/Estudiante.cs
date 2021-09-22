using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUP_PI_Parcial1
{
    class Estudiante
    {
        private int legajo;
        private string nombre;
        private int edad;
        private bool sexo;      //false->Femenino  - true->Masculino
        private double promedio;

        public Estudiante()
        {
            this.legajo = 0;
            this.nombre = "";
            this.edad = 0;
            this.sexo = false;
            this.promedio = 0;
        }

        public int pLegajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int pEdad
        {
            get { return edad; }
            set { edad = value; }
        }
        public bool pSexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public double pPromedio
        {
            get { return promedio; }
            set { promedio = value; }
        }
        public string MostrarEstudiante()
        {
            string aux = "Estudiante: ";
            aux += "| Legajo: " + legajo + "| Nombre: " + nombre + "| Edad: " + edad;
            if (sexo)
                aux += "| Sexo: Masculino";
            else
                aux += "| Sexo: Femenino";
            aux += " Promedio: " + promedio;
            return aux;
        }
    }
}
