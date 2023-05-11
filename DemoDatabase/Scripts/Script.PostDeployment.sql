/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT Produit ON
INSERT INTO Produit (Id, Nom, Prix) VALUES
    (1, 'Test', .50)
,   (2, 'Test 2', 1.5)
,   (3, 'Test 3', 2.5)
,   (4, 'Test 4', 3.5)
,   (5, 'Test 5', 4.5)
SET IDENTITY_INSERT Produit OFF