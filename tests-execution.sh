cd ./Calculos.Common.Tests
ls

# Configurar uso de Global Tools do .NET
export PATH="$PATH:/root/.dotnet/tools"

# Execução dos testes para geração do arquivo .trx
dotnet test Calculos.Common.Tests.csproj --no-restore --verbosity minimal --logger:"trx;LogFileName=resultado-testes.trx"
statusTests=$?

# Nova execução para geração de HTML + XML de Indicadores de Cobertura (sem exibir resultado)
dotnet test Calculos.Common.Tests.csproj --no-restore --verbosity minimal --logger:"html;LogFileName=resultado-testes.html" --collect:"XPlat Code Coverage" > /dev/null 2>&1

# Acessar diretório com resultado dos testes
cd TestResults

# Listar arquivos do diretório TestResults
echo "*** Diretório ***"
pwd
echo "*****************"
ls

# Acessar diretório gerado com o XML de Cobertura de código e listar conteúdo
cd $(ls -d */|head -n 1)
echo "*** Diretório ***"
pwd
echo "*****************"
ls

# Gerar XML com dados do Coverlet
reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:./coveragereport" -reporttypes:Cobertura

# Acessar diretório gerado com o XML com dados do Coverlet e listar conteúdo
cd ./coveragereport
echo "*** Diretório ***"
pwd
echo "*****************"
ls

# Retornar o status de sucesso ou não na execução dos testes
[ $statusTests -eq 0 ]  || exit 1