                 
La funzione estrai_valore_token non è nativa di SQL ma viene derivata da una dll presente in EASY: Sqlfunctions.dll.

Qualora questa funzione non sia stata defita nel database corrente occorre procedere come segue:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------
1. Registrare la DLL Sqlfunctions.dll su server di database: 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	- Aprire SQL Managment Studio e selezionare il database di lavoro
	- Nella sezione  Programmability -> Assemblies click con pulsante destro del mouse e selezionare "New Item"
	- Nella form che apparirà indicare il percorso dell'assembly (Path to assembly) selezionando il percorso della DLL
	  (Generalmente C:\Program Files (x86)\Tempo Srl\Easy\bin\Sqlfunctions.dll)
	- Confermare l'operazione con il pulsante OK

------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2. Lanciare lo script di creazione della funzione
------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	CREATE FUNCTION [dbo].[estrai_valore_token](@template [nvarchar](max), @S [nvarchar](max), @token [nvarchar](max))
	RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
	AS 
	EXTERNAL NAME [Sqlfunctions].[SqlFun].[estrai_valore_token]
	GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------------
3. Abilitare l'esecuzione del codice clr di .NET Framework con lo script 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	EXEC sp_configure 'clr enabled', 1
	go
	RECONFIGURE
	go
	EXEC sp_configure 'clr enabled'
	go
