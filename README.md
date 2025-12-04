# 🤖 OpenAPI Spectral LLM

> **Bridging the gap between deterministic API linting and Generative AI.**

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Spectral](https://img.shields.io/badge/linter-Spectral-8A2BE2)](https://stoplight.io/open-source/spectral)

**OpenAPI Spectral LLM** is a tool designed to simplify API governance. It leverages Large Language Models (LLMs) to help developers write better Spectral rules, understand validation errors, and automatically fix OpenAPI specifications.

## ✨ Key Features

* **Natural Language to Ruleset:** Describe your governance policy (e.g., "All operation IDs must be verb-noun-resource") and let the LLM generate the correct Spectral YAML and JSONPath.
* **Smart Error Explanation:** Don't just get an error code. Get a contextual explanation of *why* your API definition failed the linter.
* **AI-Powered Auto-Fix:** Automatically suggest or apply fixes to your `openapi.yaml` based on Spectral violations.
* **Model Agnostic:** Configurable to work with OpenAI (GPT-4), Anthropic (Claude), or local models via Ollama.

## Prerequisites

- .NET 10.0 SDK
- Node.js et npm (pour Spectral - optionnel en local)

## Installation

```bash
dotnet restore
```

## Exécution

```bash
dotnet run
```

The API will be accessible at `https://localhost:5220`.
Swagger UI interface: `http://localhost:5220/swagger`.
OpenAPI specification (JSON): `http://localhost:5220/swagger/v1/swagger.json` (or .yaml).

## Endpoints

- `POST /api/accounts/create` - Créer un compte bancaire
- `GET /api/accounts/{id}` - Obtenir les détails d'un compte
- `POST /api/accounts/{id}/deposit` - Déposer de l'argent
- `POST /api/accounts/{id}/withdraw` - Retirer de l'argent

## Génération de la documentation OpenAPI

Pour générer le fichier OpenAPI :

```bash
dotnet run --project scripts/OpenApiGenerator/OpenApiGenerator.csproj
```

Le fichier `openapi.json` sera généré dans le dossier `scripts/`.

## Validation avec Spectral

### Installation locale (optionnel)

```bash
npm install -g @stoplight/spectral-cli
```

### Validation

```bash
spectral lint scripts/openapi.json
```

### Configuration

Les règles Spectral sont définies dans `.spectral.yml`. Le fichier étend les règles OpenAPI par défaut et ajoute des règles personnalisées pour :
- Vérifier la présence de descriptions sur les opérations
- Valider les codes de réponse
- Exiger des tags et operationId
- Vérifier la qualité des schémas

## Structure du projet

```
Bank/
├── Application/          # Couche Application
│   ├── Dtos/            # Data Transfer Objects
│   ├── Interfaces/      # Interfaces de dépôts
│   └── UseCases/        # Cas d'usage métier
├── Domain/              # Couche Domain
│   ├── Entities/        # Entités métier
│   └── ValueObjects/   # Value Objects (Money, etc.)
├── Infrastructure/      # Couche Infrastructure
│   └── Repositories/    # Implémentations des dépôts
├── Controllers/         # Contrôleurs API
└── scripts/
    └── OpenApiGenerator/ # Générateur OpenAPI
```

## CI/CD

Le projet inclut un workflow GitHub Actions qui :
- Build le projet
- Génère la documentation OpenAPI
- Valide avec Spectral
- Upload les rapports de validation comme artefacts
- Exécute les tests

## Technologies

- **.NET 10.0** : Framework principal
- **Swashbuckle.AspNetCore** : Génération OpenAPI et Swagger UI
- **Spectral** : Validation de la spécification OpenAPI
- **Clean Architecture** : Architecture en couches
- **DDD** : Domain-Driven Design avec Value Objects

## Documentation

- [Documentation Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Documentation Spectral](https://meta.stoplight.io/docs/spectral/docs/getting-started/introduction.md)
- [OpenAPI Specification](https://swagger.io/specification/)
