dotnet ef migrations add InitialCreate // generate migrations
dotnet ef database update // mandar migrations to o banco
dotnet ef database update 0 // reverter migrations
dotnet ef migrations remove // remover migrations
dotnet new classlib -o Manager.core // criar projeto library

dotnet new webapi -o Manager.webapi // criar projeto webapi

dotnet package update // atualizar pacotes

dotnet add Manager.Infra.csproj reference '..\Manager.Domain\Manager.Domain.csproj' // adicionar referencia

dotnet sln ..\..\Manager.sln add Manager.Core.csproj // adicionar projeto ao projeto principal

dotnet tool install --global dotnet-ef // instalar dotnet-ef

