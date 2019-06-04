[![Build Status](https://travis-ci.org/alisonjonck/reactnetcore.svg?branch=master)](https://travis-ci.org/alisonjonck/reactnetcore)

## Exemplo .net core + React

## Download última versão .NET Core SDK

* [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/windows)

### Inicie a aplicação

- Instale as dependências antes para rodar através da CLI:

```
dotnet restore reactnetcore.sln
dotnet build reactnetcore.sln
```

```
cd App && dotnet publish && dotnet run
```

### Rode os testes dos componentes React

```
cd App/ClientApp && npm test
```

### Rode os testes unitários 

```
dotnet test App.Tests/
```

### Rode os testes da camada de Serviços de Integração
```
dotnet test App.Integrations.Tests/
```
