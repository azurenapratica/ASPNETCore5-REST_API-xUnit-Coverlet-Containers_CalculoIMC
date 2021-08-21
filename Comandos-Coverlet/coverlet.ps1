# Instalar o ReportGenerator para a geração do relatório HMTL de cobertura de código
dotnet tool install --global dotnet-reportgenerator-globaltool --version 4.8.12

# Executar os testes gerando o arquivo com a cobertura do código
dotnet test --verbosity minimal --collect:"XPlat Code Coverage"

# Navegar até o diretório em que se encontra o arquivo coverage.cobertura
# (dentro de TestResults - exemplo \TestResults\bea73917-ed0e-43bc-b462-104f6c902a3f),
# executando em seguindo o comando a seguir para a geração do site estático
# com informações da cobertura de código
reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html

# O conteúdo gerado ficará no diretório \coveragereport