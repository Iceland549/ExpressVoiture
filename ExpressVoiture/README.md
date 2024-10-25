
# Projet Express Voiture

## Description
**Express Voiture** est une application de gestion d'un inventaire de voitures d'occasion. Le projet permet aux administrateurs d'ajouter, modifier et supprimer des v�hicules dans l'inventaire, tandis que les utilisateurs peuvent consulter la liste des voitures � vendre.

## Fonctionnalit�s Principales
1. **Authentification et Autorisation**
   - Utilise ASP.NET Core Identity pour la gestion des utilisateurs.
   - Seuls les administrateurs peuvent ajouter, modifier ou supprimer des v�hicules.

2. **Gestion de l'Inventaire**
   - Affichage de l'inventaire complet des voitures.
   - Ajout, modification et suppression de voitures par l'admin.
   - Visualisation des informations de chaque voiture incluant le prix, l'ann�e, le mod�le, etc.

3. **Mod�le de Donn�es**
   - `Voiture` : Repr�sente chaque v�hicule avec des informations d�taill�es comme le `CodeVIN`, `Marque`, `Mod�le`, etc.
   - `Utilisateur` : Mod�le d'utilisateur h�rit� d'`IdentityUser` avec un r�le (`User` ou `Admin`).

## Installation
1. **Cloner le d�p�t** :
   
   git clone <https://github.com/Iceland549/ExpressVoiture>
   cd ExpressVoiture
   

2. **Configurer la base de donn�es** :
   - Utiliser Entity Framework Core pour appliquer les migrations :
   
   dotnet ef database update
   

3. **Ex�cuter le projet** :
   
   dotnet run
   

## Seed Data
- Le fichier `SeedData.cs` initialise les donn�es, incluant un compte admin par d�faut (email : `admin@example.com`, mot de passe : `AdminPassword123!`).

## Mod�le de Donn�es
- La base de donn�es est compos�e des entit�s `Utilisateur` et `Voiture`.
- `Utilisateur` est bas� sur `IdentityUser` et inclut les r�les pour la gestion des autorisations.
- `Voiture` contient les informations d'inventaire de chaque v�hicule.

## Auteur
Projet r�alis� par CHAU Denis.
