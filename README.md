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

## Installation

### Running the Project
```
dotnet run
```

The API will be accessible at `https://localhost:5220`.
Swagger UI interface: `http://localhost:5220/swagger`.
OpenAPI specification (JSON): `http://localhost:5220/swagger/v1/swagger.json` (or .yaml).

## Endpoints

- `POST /api/accounts/create` - Create an account
- `GET /api/accounts/{id}` - Get account details
- `POST /api/accounts/{id}/deposit` - Deposit funds
- `POST /api/accounts/{id}/withdraw` - Withdraw funds

## API Documentation

In development mode, the OpenAPI documentation is available at `/openapi/v1.json`.



