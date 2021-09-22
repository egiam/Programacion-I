using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    class Autor: Persona
    {
        private string alias;

        public string pAlias
        {
            get { return alias; }
            set { alias = value; }
        }

        public Autor() : base()
        {
            this.alias = "";

        }

        public Autor(string alias, string nombre, int edad, bool sexo, double peso, double altura) : base(nombre, edad, sexo, peso, altura)
        {
            this.alias = alias;
            //Se utilizo protected(usado para herencias)
            base.nombre = nombre;
            base.edad = edad;
            base.peso = peso;
            base.altura = altura;
            base.sexo = sexo;

        }

        public override string ToString()
        {
            return "Alias: " + alias + " | " + base.ToString();
        }

        public override bool esMayorDeEdad()
        {
            return base.esMayorDeEdad();
        }


    }
}
