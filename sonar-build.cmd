dotnet tool install --global dotnet-sonarscanner
dotnet sonarscanner begin /k:"ServiceBroker_API" /d:sonar.host.url="https://sonarqube-binasystem.azurewebsites.net"  /d:sonar.login="sqp_476f7d8f4e96c3cdb9ccd8f372ee0592de48e1ea"
dotnet build 
dotnet sonarscanner end /d:sonar.login="sqp_476f7d8f4e96c3cdb9ccd8f372ee0592de48e1ea"