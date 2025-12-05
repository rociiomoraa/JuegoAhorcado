using System;
using System.Collections.Generic;
using System.Linq;
using JuegoAhorcado.Modelos;

namespace JuegoAhorcado.Motor
{
    public class MotorAhorcado
    {
        public EntradaPalabra PalabraOriginal { get; }
        public string PalabraOculta { get; private set; }

        public HashSet<char> LetrasProbadas { get; }
        public HashSet<char> LetrasFalladas { get; }

        public int Aciertos { get; private set; }
        public int Errores { get; private set; }

        public bool PartidaFinalizada { get; private set; }
        public bool PalabraAcertada => !PalabraOculta.Contains('_');

        // Permitimos hasta 10 errores porque tienes 10 partes en el dibujo
        public const int MaxErrores = 10;


        public MotorAhorcado(EntradaPalabra palabra)
        {
            PalabraOriginal = palabra;
            LetrasProbadas = new HashSet<char>();
            LetrasFalladas = new HashSet<char>();
            Aciertos = 0;
            Errores = 0;

            PalabraOculta = GenerarOculta(palabra.Palabra);
        }


        private string GenerarOculta(string palabra)
        {
            // Genera "_ _ _ _" respetando espacios entre palabras
            return string.Join(" ", palabra.ToUpper().Select(c => c == ' ' ? ' ' : '_'));
        }


        // Intento de introducir una letra por parte del usuario
        public bool ProbarLetra(char letra)
        {
            letra = char.ToUpper(letra);

            if (PartidaFinalizada)
                return false;

            if (LetrasProbadas.Contains(letra))
                return false;

            LetrasProbadas.Add(letra);

            string palabra = PalabraOriginal.Palabra.ToUpper();

            if (palabra.Contains(letra))
            {
                Aciertos++;
                RevelarLetra(letra);

                if (PalabraAcertada)
                    Finalizar();

                return true;
            }
            else
            {
                Errores++;
                LetrasFalladas.Add(letra);

                if (Errores >= MaxErrores)
                    Finalizar();

                return false;
            }
        }


        private void RevelarLetra(char letra)
        {
            string original = PalabraOriginal.Palabra.ToUpper();
            string sinEspacios = PalabraOculta.Replace(" ", "");

            char[] actual = sinEspacios.ToCharArray();
            char[] originalChars = original.ToCharArray();

            int indexOculta = 0;

            for (int i = 0; i < originalChars.Length; i++)
            {
                if (originalChars[i] == ' ')
                {
                    continue;
                }

                if (originalChars[i] == letra)
                    actual[indexOculta] = letra;

                indexOculta++;
            }

            PalabraOculta = string.Join(" ", actual);
        }

        private void Finalizar()
        {
            PartidaFinalizada = true;
        }


        // Permite terminar manualmente una partida
        public void ForzarFinalizacionManual()
        {
            PartidaFinalizada = true;
        }


        // Útil para el diseño del formulario (multilínea si hay espacios)
        public string ObtenerPalabraOcultaMultilinea()
        {
            string sinEspacios = PalabraOculta.Replace(" ", "");
            return string.Join(Environment.NewLine, sinEspacios.ToCharArray());
        }

        public int ObtenerPuntuacion()
        {
            int puntos = 0;

            if (PalabraAcertada)
                puntos += 10;
            else
                puntos -= 5;

            puntos += Aciertos * 2;
            puntos -= Errores * 1;

            return puntos;
        }

    }
}
