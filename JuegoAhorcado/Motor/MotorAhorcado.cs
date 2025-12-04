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
            char[] actual = PalabraOculta.Replace(" ", "").ToCharArray();
            char[] original = PalabraOriginal.Palabra.ToUpper().ToCharArray();

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == letra)
                {
                    actual[i] = letra;
                }
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


        // Devuelve la palabra desenmascarada (útil al perder)
        public string ObtenerPalabraRevelada()
        {
            return PalabraOriginal.Palabra.ToUpper();
        }


        // Útil para el diseño del formulario (multilínea si hay espacios)
        public string ObtenerPalabraOcultaMultilinea()
        {
            string sinEspacios = PalabraOculta.Replace(" ", "");
            return string.Join("\n", sinEspacios.ToCharArray());
        }


        // Punto único para obtener puntuación base
        public int ObtenerPuntuacion()
        {
            if (!PalabraAcertada)
                return 0;

            int puntosBase = PalabraOriginal.Palabra.Length * 10;
            int penalizacion = Errores * 3;

            return Math.Max(0, puntosBase - penalizacion);
        }


        // Saber si la letra ya ha sido usada
        public bool LetraYaIntentada(char letra)
        {
            letra = char.ToUpper(letra);
            return LetrasProbadas.Contains(letra) || LetrasFalladas.Contains(letra);
        }
    }
}
