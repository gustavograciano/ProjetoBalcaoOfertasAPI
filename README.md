# Balcão de Ofertas — API

API REST em .NET 7 simulando um **balcão de ofertas de moedas/ativos**: usuários criam ofertas de compra e venda a partir do saldo disponível em sua carteira, e o sistema valida lastro antes de registrar.

![.NET](https://img.shields.io/badge/.NET-7.0-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-7-512BD4?logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![Swagger](https://img.shields.io/badge/docs-Swagger-85EA2D?logo=swagger&logoColor=black)

## Stack

- **.NET 7** · ASP.NET Core Web API
- **Entity Framework Core 7** · SQL Server
- **Swagger / OpenAPI** (`Swashbuckle.AspNetCore`)
- Scripts SQL versionados em `ScriptsDB/`

## Domínio

| Entidade | Papel |
|---|---|
| `Usuario` | Participante do balcão |
| `Carteira` | Saldo do usuário por moeda |
| `Moeda` | Ativos negociáveis |
| `Oferta` | Ordem de compra ou venda, vinculada a usuário + carteira |

Ao criar uma oferta, a API valida que a carteira do usuário pertence a ele **e** possui saldo suficiente (`Preço × Quantidade`). Exclusão lógica via flag `Deletado`.

## Endpoints principais

```
GET    /api/ofertas        # lista ofertas ativas, ordenadas por data de criação (desc)
POST   /api/ofertas        # cria nova oferta (valida carteira + saldo)
```

Documentação completa via Swagger em `https://localhost:<porta>/swagger`.

## Como rodar

```bash
dotnet restore
dotnet ef database update       # cria/atualiza schema
dotnet run
```

Connection string em `appsettings.json`. Scripts de bootstrap do banco em `ScriptsDB/`.

## Status

Exercício de API REST com EF Core — domínio pequeno mas com validações de negócio não-triviais (lastro de carteira). Base para evoluir com autenticação JWT, tratamento global de exceção via middleware, paginação e testes automatizados.
