using System;

namespace APICalculoIMC.Models
{
    public class ClassificacaoPessoa
    {
        public double Peso { get; init; }
        public double Altura { get; init; }
        public double IMC { get; init; }
        public string Situacao { get; init; }
    }
}