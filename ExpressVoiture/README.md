
# Projet Express Voiture

## Description
**Express Voiture** est une application de gestion d'un inventaire de voitures d'occasion. Le projet permet aux administrateurs d'ajouter, modifier et supprimer des véhicules dans l'inventaire, tandis que les utilisateurs peuvent consulter la liste des voitures à vendre.

## Fonctionnalités Principales
1. **Authentification et Autorisation**
   - Utilise ASP.NET Core Identity pour la gestion des utilisateurs.
   - Seuls les administrateurs peuvent ajouter, modifier ou supprimer des véhicules.

2. **Gestion de l'Inventaire**
   - Affichage de l'inventaire complet des voitures.
   - Ajout, modification et suppression de voitures par l'admin.
   - Visualisation des informations de chaque voiture incluant le prix, l'année, le modèle, etc.

3. **Modèle de Données**
   - `Voiture` : Représente chaque véhicule avec des informations détaillées comme le `CodeVIN`, `Marque`, `Modèle`, etc.
   - `Utilisateur` : Modèle d'utilisateur hérité d'`IdentityUser` avec un rôle (`User` ou `Admin`).

## Installation
1. **Cloner le dépôt** :
   
   git clone <https://github.com/Iceland549/ExpressVoiture>
   cd ExpressVoiture
   

2. **Configurer la base de données** :
   - Utiliser Entity Framework Core pour appliquer les migrations :
   
   dotnet ef database update
   

3. **Exécuter le projet** :
   
   dotnet run
   

## Seed Data
- Le fichier `SeedData.cs` initialise les données, incluant un compte admin par défaut (email : `admin@example.com`, mot de passe : `AdminPassword123!`).

## Modèle de Données
- La base de données est composée des entités `Utilisateur` et `Voiture`.
- `Utilisateur` est basé sur `IdentityUser` et inclut les rôles pour la gestion des autorisations.
- `Voiture` contient les informations d'inventaire de chaque véhicule.

## Auteur
Projet réalisé par CHAU Denis.
