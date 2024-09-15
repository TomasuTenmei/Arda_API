# ARDA API

Bienvenue dans le projet **ARDA API** (Lord of the Rings API), une API RESTful construite avec ASP.NET Core qui permet de gérer les objets et les personnages du Seigneur des Anneaux. Ce projet utilise l'authentification JWT et la gestion des rôles pour sécuriser l'accès aux ressources.

## Table des matières

- [Aperçu du Projet](#aperçu-du-projet)
- [Prérequis](#prérequis)
- [Installation](#installation)
- [Configuration](#configuration)
- [Exécution en Local](#exécution-en-local)
- [Déploiement sur Azure](#déploiement-sur-azure)
- [Utilisation de l'API](#utilisation-de-lapi)
- [Documentation de l'API avec Swagger](#documentation-de-lapi-avec-swagger)

## Aperçu du Projet

L'API ARDA permet de :

- Gérer les objets, personnages, et lieux du monde du Seigneur des Anneaux.
- Utiliser l'authentification et l'autorisation via JWT pour sécuriser les accès aux points de terminaison.
- Fournir une documentation interactive avec Swagger pour faciliter l'intégration et les tests des développeurs.

## Prérequis

Avant de commencer, assurez-vous d'avoir les éléments suivants installés sur votre machine :

- [.NET SDK 6.0 ou supérieur](https://dotnet.microsoft.com/download)
- [Visual Studio 2022 ou supérieur](https://visualstudio.microsoft.com/) avec les outils de développement .NET Core
- [SQL Server](https://www.microsoft.com/sql-server) ou SQL Server Express pour la base de données locale
- [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli) pour le déploiement sur Azure (facultatif)

## Installation

1. Clonez le référentiel :

   ```bash
   git clone https://github.com/votre-utilisateur/lotr-api.git
   cd lotr-api
   ```

2. Restaurez les packages NuGet :

    ```bash
    dotnet restore
    ```

3. Appliquez les migrations pour créer la base de données :

    ```bash
    dotnet ef database update
    ```

## Configuration

Avant de lancer l'application, configurez les paramètres dans le fichier `appsettings.json` :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LotrDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "VotreCléSecrèteJWT",
    "Issuer": "https://localhost:5000",
    "Audience": "https://localhost:5000"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

- **DefaultConnection** : Mettez à jour la chaîne de connexion avec vos informations de base de données.
- **Jwt** : Remplacez par une clé secrète pour signer vos tokens JWT.

## Exécution en Local

1. Lancez l'application en mode de développement :

    ```bash
    dotnet run
    ```

2. Accédez à l'API via votre navigateur ou un outil comme Postman :

    ```postman
    http://localhost:5000/
    ```

3. Pour accéder à la documentation interactive de l'API via Swagger, visitez :

    <http://localhost:5000/swagger>

## Déploiement sur Azure

Pour déployer l'API sur Azure App Service :

1. Connectez-vous à votre compte Azure :

    ```bash
    az login
    ```

2. Créez un App Service :

    ```bash
    az webapp create --resource-group <ResourceGroupName> --plan <AppServicePlanName> --name <YourAppName> --runtime "DOTNETCORE|6.0"
    ```

3. Déployez l'application sur Azure :

    ```bash
    az webapp deploy --resource-group <ResourceGroupName> --name <YourAppName> --src-path bin/Release/net6.0/publish
    ```

4. Configurez les paramètres d'application dans le portail Azure pour inclure vos valeurs JWT et les chaînes de connexion de la base de données.

## Utilisation de l'API

### Authentification

Login : Utilisez le point de terminaison `/api/account/login` pour obtenir un token JWT.

Requête : POST `/api/account/login`

Exemple de corps de requête :

```json
{
    "username": "admin@lotr.com",
    "password": "Admin@123"
}
```

Utilisez le token JWT dans les en-têtes de vos requêtes pour accéder aux points de terminaison sécurisés :

```json
authorization: Bearer <votre_token>
```

### Points de Terminaison

- GET /api/rings : Récupère la liste des anneaux.
- POST /api/rings : Ajoute un nouvel anneau (nécessite le rôle Admin).

Pour plus de détails sur les points de terminaison disponibles, consultez Swagger.

## Documentation de l'API avec Swagger

Swagger est activé par défaut. Accédez à Swagger UI pour tester et explorer l'API : <http://localhost:5000/swagger>
