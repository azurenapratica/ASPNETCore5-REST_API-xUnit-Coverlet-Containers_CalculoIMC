using System;

namespace Calculos.Common
{
    public static class IndiceMassaCorporea
    {
        public const string MAGREZA = "Magreza";
        public const string NORMAL = "Normal";
        public const string SOBREPESO = "Sobrepeso";
        public const string OBESIDADE = "Obesidade";
        public const string OBESIDADE_GRAVE = "Obesidade Grave";

        public static double? Calcular(double peso, double altura)
        {
            if (peso <= 0 || altura <= 0)
                return null;

            return peso / (altura * altura); // FIXME: Simulação de falha
            //return Math.Round(peso / (altura * altura), 1);
        }

        public static string ObterClassificacao(double imc)
        {
            if (imc <= 0)
                return null;
            else if (imc <= 18.5)
                return MAGREZA;
            else if (imc <= 25.0)
                return NORMAL;
            else if (imc <= 29.9)
                return SOBREPESO;
            else if (imc <= 40.0)
                return OBESIDADE;
            else
                return OBESIDADE_GRAVE;
        }
    }
}