using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca
{
    abstract class Persona
    {
        protected string nombre;

        protected int edad;

        protected bool sexo;

        protected double peso;

        protected double altura;


        //métodos constructores

        public Persona()

        {

            nombre = "";

            edad = 0;

            sexo = true; //"";

            peso = 0;

            altura = 0.0;

        }

        public Persona(string nombre, int edad, bool sexo, double peso, double altura)

        {

            this.nombre = nombre;

            this.edad = edad;

            this.sexo = sexo;

            this.peso = peso;

            this.altura = altura;

        }

        public Persona(string nom)

        {

            nombre = nom;

        }


        //Propiedades

        public string pNombre

        {

            set { nombre = value; }

            get { return nombre; }

        }

        public int pEdad

        {

            set { edad = value; }

            get { return edad; }

        }

        public bool pSexo

        {

            set { sexo = value; }

            get { return sexo; }

        }

        public double pPeso

        {

            set { peso = value; }

            get { return peso; }

        }

        public double pAltura

        {

            set { altura = value; }

            get { return altura; }

        }


        //métodos de control o comportamiento

        public virtual bool esMayorDeEdad()

        {

            bool mayor = false;


            if (edad >= 21)

                mayor = true;

            else

                mayor = false;

            return mayor;

        }

        public int calcularIMC()

        {

            const int pesoMin = 20;

            const int pesoMax = 25;

            double imc = 0;

            imc = peso / (altura * altura);

            if (imc < pesoMin)

                return -1;

            else

                if (imc > pesoMax)

                return 1;

            else

                return 0;

        }


        //método toString

        public string toString()

        {
            string aux = "";
            if (sexo is true)
            {
                aux = "Hombre";
            }
            else
            {
                aux = "Mujer";
            }


            return "Nombre: " + this.nombre + " |Edad: " + edad + " |Sexo: " + aux + " |Peso: " + peso + " |Altura: " + altura

                   + " |IMC: " + this.calcularIMC() + " |Mayor: " + esMayorDeEdad();

        }

        public abstract string MostrarPersona();

    }
}
