FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY RO.DevTest.sln .
COPY RO.DevTest.Domain/*.csproj ./RO.DevTest.Domain/
COPY RO.DevTest.Application/*.csproj ./RO.DevTest.Application/
COPY RO.DevTest.Persistence/*.csproj ./RO.DevTest.Persistence/
COPY RO.DevTest.Infrastructure/*.csproj ./RO.DevTest.Infrastructure/
COPY RO.DevTest.WebApi/*.csproj ./RO.DevTest.WebApi/

RUN dotnet restore RO.DevTest.WebApi/RO.DevTest.WebApi.csproj

COPY . .

WORKDIR /src/RO.DevTest.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RO.DevTest.WebApi.dll"]