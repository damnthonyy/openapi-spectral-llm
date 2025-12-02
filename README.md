# Bank API

API REST pour la gestion de comptes bancaires, construite avec ASP.NET Core.

## Architecture

Le projet suit une architecture en couches (Clean Architecture) :

- **Domain** : Entités et interfaces métier
- **Application** : Cas d'usage et DTOs
- **Infrastructure** : Implémentations (repositories en mémoire)
- **API** : Contrôleurs et configuration

## Prérequis

- .NET 10.0 SDK

## Installation

### Exécution
```
dotnet run
```

L'API sera accessible sur `https://localhost:5220`.

## Endpoints

- `POST /api/accounts/create` - Créer un compte
- `GET /api/accounts/{id}` - Obtenir un compte
- `POST /api/accounts/{id}/deposit` - Déposer de l'argent
- `POST /api/accounts/{id}/withdraw` - Retirer de l'argent

## Documentation API

En mode développement, la documentation OpenAPI est disponible via `/openapi/v1.json`.



