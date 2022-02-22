
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


--[DBO]--
-- CREAZIONE PROCEDURE [dbo].[GenerateDidProgCurricula]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[GenerateDidProgCurricula]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GenerateDidProgCurricula]
GO
CREATE PROCEDURE [dbo].[GenerateDidProgCurricula]
	@iddidprog int,
	@user varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	--declare @iddidprog int = 4;
	--declare @user varchar(60) = 'ferdinando';


	declare @idcorsostudio int = (SELECT idcorsostudio FROM didprog WHERE iddidprog = @iddidprog);
	declare @iddidprogsuddannokind int = (SELECT iddidprogsuddannokind FROM didprog WHERE iddidprog = @iddidprog);
	declare @aa varchar(9) = (SELECT aa FROM didprog WHERE iddidprog = @iddidprog);
	
	declare @durata int = (SELECT durata FROM corsostudio WHERE idcorsostudio = @idcorsostudio);
	declare @idduratakind int = (SELECT idduratakind FROM corsostudio WHERE idcorsostudio = @idcorsostudio);

	--CURRICULUM
	IF(@iddidprogsuddannokind is not null and @durata is not null and  @idduratakind is not null)
	BEGIN
		IF(NOT EXISTS(SELECT * FROM didprogcurr WHERE iddidprog = @iddidprog))
		BEGIN
			
			INSERT INTO [dbo].[didprogcurr]
					   ([iddidprogcurr]
					   ,[iddidprog]
					   ,[title]
					   ,[codice]
					   ,[codicemiur]
					   ,[ct]
					   ,[cu]
					   ,[lt]
					   ,[lu]
					   ,[idcorsostudio])
				 VALUES
					   ((SELECT isnull(MAX(iddidprogcurr),0) FROM didprogcurr) + 1
					   ,@iddidprog
					   ,'Curriculum unico'
					   ,''
					   ,''
					   ,GETDATE()
					   ,@user
					   ,GETDATE()
					   ,@user
					   ,@idcorsostudio);
		END
		DECLARE @iddidprogcurr int = (SELECT TOP 1 iddidprogcurr FROM didprogcurr WHERE iddidprog = @iddidprog);

		--ORIENTAMENTO
		IF(NOT EXISTS(SELECT * FROM didprogori WHERE iddidprog = @iddidprog))
		BEGIN
			INSERT INTO [dbo].[didprogori]
					   ([iddidprogori]
					   ,[iddidprogcurr]
					   ,[iddidprog]
					   ,[title]
					   ,[codice]
					   ,[ct]
					   ,[cu]
					   ,[lt]
					   ,[lu]
					   ,[idcorsostudio])
				 VALUES
					   ((SELECT isnull(MAX(iddidprogori),0) FROM didprogori) + 1 
					   ,@iddidprogcurr
					   ,@iddidprog
					   ,'Orientamento unico'
					   ,''
					   ,GETDATE()
					   ,@user
					   ,GETDATE()
					   ,@user
					   ,@idcorsostudio);
		END
		DECLARE @iddidprogori int = (SELECT TOP 1 iddidprogori FROM didprogori WHERE iddidprog = @iddidprog AND iddidprogcurr = @iddidprogcurr);

		--SUDDIVISIONE DEL CORSO  
		IF(@idduratakind = 1) --ANNI
		BEGIN
			DECLARE @numsuddivisioni INT = 1;
			IF(@iddidprogsuddannokind = 1) SET @numsuddivisioni = 12; --MENSILI
			IF(@iddidprogsuddannokind = 2) SET @numsuddivisioni = 6; --BIMESTRI
			IF(@iddidprogsuddannokind = 3) SET @numsuddivisioni = 4; --TRIMESTRI
			IF(@iddidprogsuddannokind = 4) SET @numsuddivisioni = 3; --QUADRIMESTRI
			IF(@iddidprogsuddannokind = 5) SET @numsuddivisioni = 2; --SEMESTRI
			IF(@iddidprogsuddannokind = 6) SET @numsuddivisioni = 1; --ANNUALE

			DECLARE @aacurr varchar(9) = @aa;
			DECLARE @cnt INT = 0;
			WHILE @cnt < @durata
			BEGIN

				DECLARE @iddidproganno int = (SELECT isnull(MAX(iddidproganno),0) FROM didproganno) + 1;
				INSERT INTO [dbo].[didproganno]
						   ([iddidproganno]
						   ,[iddidprogori]
						   ,[iddidprogcurr]
						   ,[iddidprog]
						   ,[anno]
						   ,[aa]
						   ,[cf]
						   ,[ct]
						   ,[cu]
						   ,[lt]
						   ,[lu]
						   ,[idcorsostudio]
						   ,[title])
					 VALUES
						   (@iddidproganno
						   ,@iddidprogori
						   ,@iddidprogcurr
						   ,@iddidprog
						   ,@cnt + 1
						   ,@aacurr
						   ,60
						   ,GETDATE()
						   ,@user
						   ,GETDATE()
						   ,@user
						   ,@idcorsostudio
						   ,CAST(@cnt + 1 as nvarchar(2)) + ' anno');
				--SUDDIVISIONE TEMPORALE
				DECLARE @cntsudd INT = 0;
				WHILE @cntsudd < @numsuddivisioni
				BEGIN
					INSERT INTO [dbo].[didprogporzanno]
							   ([iddidprogporzanno]
							   ,[iddidproganno]
							   ,[iddidprogori]
							   ,[iddidprogcurr]
							   ,[iddidprog]
							   ,[indice]
							   ,[iddidprogporzannokind]
							   ,[start]
							   ,[stop]
							   ,[ct]
							   ,[cu]
							   ,[lt]
							   ,[lu]
							   ,[idcorsostudio]
							   ,[aa]
							   ,[title])
						 VALUES

							   ((SELECT isnull(MAX(iddidprogporzanno),0) FROM didprogporzanno) + 1
							   ,@iddidproganno
							   ,@iddidprogori
							   ,@iddidprogcurr
							   ,@iddidprog
							   ,@cntsudd +1
							   ,@iddidprogsuddannokind
							   ,NULL
							   ,NULL
							   ,GETDATE()
							   ,@user
							   ,GETDATE()
							   ,@user
							   ,@idcorsostudio
							   ,@aacurr
							   ,CAST(@cntsudd +1 as nvarchar(2)) + CASE
							   WHEN @iddidprogsuddannokind = 1 THEN ' mese'
							   WHEN @iddidprogsuddannokind = 2 THEN ' bimestre'
							   WHEN @iddidprogsuddannokind = 3 THEN ' trimestre'
							   WHEN @iddidprogsuddannokind = 4 THEN ' quadrimestre'
							   WHEN @iddidprogsuddannokind = 5 THEN ' semestre'
							   WHEN @iddidprogsuddannokind = 6 THEN ' annualitÃ '
							   END)
					SET @cntsudd = @cntsudd + 1;
				END
				SET @cnt = @cnt + 1;
				SET @aacurr = CAST( (CAST(LEFT(@aa,4) AS int) + @cnt + 1) AS varchar(4))  + '/' + CAST( (CAST(RIGHT(@aa,4) AS int) + @cnt + 1) AS varchar(4));
			END
		END
	END
END
GO 
