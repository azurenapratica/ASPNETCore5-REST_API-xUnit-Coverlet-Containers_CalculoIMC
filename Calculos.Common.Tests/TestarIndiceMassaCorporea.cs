using System;
using Xunit;
using FluentAssertions;

namespace Calculos.Common.Tests
{
    public class TestarIndiceMassaCorporea
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1.80)]
        [InlineData(0, -1.75)]
        [InlineData(-90.4, -1.67)]
        [InlineData(-90.5, 1.80)]
        [InlineData(-90.6, 0)]
        [InlineData(90, 0)]
        [InlineData(81.2, -1.72)]
        public void TestarIMCInvalido(double peso, double altura)
        {
            var imc = IndiceMassaCorporea.Calcular(peso, altura);
            imc.Should().BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-25.2)]
        public void TestarSituacaoInvalida(double imc)
        {
            var situacao = IndiceMassaCorporea.ObterClassificacao(imc);
            situacao.Should().BeNull();
        }

        [Theory]
        [InlineData(70.5, 2.05, 16.8, IndiceMassaCorporea.MAGREZA)]
        [InlineData(75.12, 1.81, 22.9, IndiceMassaCorporea.NORMAL)]
        [InlineData(130.0, 1.90, 36, IndiceMassaCorporea.OBESIDADE)]
        [InlineData(150.0, 1.60, 58.6, IndiceMassaCorporea.OBESIDADE_GRAVE)]
        [InlineData(70.98, 1.54, 29.9, IndiceMassaCorporea.SOBREPESO)]
        public void TestarIMCSituacaoPessoa(
            double peso, double altura, double imc, string situacao)
        {
            var resultadoIMC = IndiceMassaCorporea.Calcular(peso, altura);
            var resultadoSituacao =
                IndiceMassaCorporea.ObterClassificacao(resultadoIMC.Value);

            resultadoSituacao.Should().Be(situacao);
            resultadoIMC.Should().Be(imc);
        }
    }
}