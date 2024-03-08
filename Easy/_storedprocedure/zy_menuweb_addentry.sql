
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


/****** Object:  StoredProcedure [dbo].[menuweb_addentry]    Script Date: 25/09/2020 18:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ferdinando Caprilli
-- Create date: 30/11/2018
-- Description:	per aggiungere voci al menù
-- =============================================
ALTER PROCEDURE [dbo].[menuweb_addentry]
			@idmenuwebparent int = NULL
           ,@idx int = NULL
           ,@tableName nvarchar(60)
           ,@editType nvarchar(60)
           ,@label nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF(@idx IS NULL)
	BEGIN
		SET @idx = (SELECT isnull(MAX([idmenuweb]),0) + 1 FROM [dbo].[menuweb]);
	END

--INSERIMENTO NEL MENU WEB --------------BEGIN
    IF NOT EXISTS (
		SELECT [idmenuweb]
		FROM [dbo].[menuweb]
		WHERE isnull(idmenuwebparent,0) = isnull(@idmenuwebparent,0) AND
				(
				(tableName = @tableName AND editType = @editType)
				OR
				(tableName is null and @tableName is null and editType is null and @editType is null and [label] = @label)
				)
				)
	BEGIN
		INSERT INTO [dbo].[menuweb]
			   ([idmenuweb]
			   ,[idmenuwebparent]
			   ,[tableName]
			   ,[editType]
			   ,[label])
		 VALUES
			   (@idx
			   ,@idmenuwebparent
			   ,@tableName
			   ,@editType
			   ,@label );
	END
	ELSE
	BEGIN
		SET @idx = (SELECT [idmenuweb]
		FROM [dbo].[menuweb]
		WHERE isnull(idmenuwebparent,'') = isnull(@idmenuwebparent,'') AND
				(
				(tableName = @tableName AND editType = @editType)
				OR
				(tableName is null and @tableName is null and editType is null and @editType is null and [label] = @label)
				)
		)
	END
--INSERIMENTO NEL MENU WEB --------------END

--INSERIMENTO NELLE VARIABILI D'AMBIENTE --------------BEGIN
    BEGIN

        DECLARE  @varnamer varchar(50) = CONCAT('mr_', @idx);
        DECLARE  @descritpion varchar(100) = CONCAT('Menu Portale: ',  @label );
        DECLARE  @descritpionr varchar(100) = CONCAT('Menu Portale: ',  @label + ' - Lettura');
        DECLARE  @varnamew varchar(50) = CONCAT('mw_', @idx);
        DECLARE  @descritpionw varchar(100) = CONCAT('Menu Portale: ',  @label + ' - Scrittura');

		IF (@tableName IS NOT NULL)

		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SU TABELLA --------------BEGIN
		BEGIN

			--INSERIMENTO su tabella restrictedfunction --------------BEGIN
            IF NOT EXISTS (
        		SELECT [idrestrictedfunction]
        		FROM [dbo].[restrictedfunction]
        		WHERE variablename = @varnamer AND
        			 description = @descritpionr)
            BEGIN
                DECLARE @idxRestrictedFunctionr int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);
                INSERT INTO [dbo].restrictedfunction
                               ([idrestrictedfunction]
                               ,[variablename]
                               ,[description],
							   [ct],[cu],[lt],[lu])
                         VALUES
                               (@idxRestrictedFunctionr
                               ,@varnamer
                               ,@descritpionr
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END

            IF NOT EXISTS (
        		SELECT [idrestrictedfunction]
        		FROM [dbo].[restrictedfunction]
        		WHERE variablename = @varnamew AND
        			 description = @descritpionw)
            BEGIN
                DECLARE @idxRestrictedFunctionw int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);
                INSERT INTO [dbo].restrictedfunction
                               ([idrestrictedfunction]
                               ,[variablename]
                               ,[description],
							   [ct],[cu],[lt],[lu])
                         VALUES
                               (@idxRestrictedFunctionw
                               ,@varnamew
                               ,@descritpionw
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END
			--INSERIMENTO su tabella [restrictedfunction] --------------END

			--INSERIMENTO su tabella [securityvar] --------------BEGIN
            IF NOT EXISTS (
                SELECT [idsecurityvar]
                FROM [dbo].[securityvar]
                WHERE  variablename = @varnamer AND
                        description = @descritpionr)
            BEGIN
                DECLARE @idxSecurityvarr int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

                INSERT INTO [dbo].securityvar
                               ([idsecurityvar]
                               ,[variablename]
                               ,[description]
                               ,[value]
							   ,[kind]
							   ,[ct],[cu],[lt],[lu])
                         VALUES
                               (@idxSecurityvarr
                               ,@varnamer
                               ,@descritpionr
                               ,'compute_set'
							   ,'S'
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END

            IF NOT EXISTS (
                SELECT [idsecurityvar]
                FROM [dbo].[securityvar]
                WHERE  variablename = @varnamew AND
                        description = @descritpionw)
            BEGIN
                DECLARE @idxSecurityvarw int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

                INSERT INTO [dbo].securityvar
                               ([idsecurityvar]
                               ,[variablename]
                               ,[description]
                               ,[value]
							   ,[kind]
							   ,[ct],[cu],[lt],[lu])
                         VALUES
                               (@idxSecurityvarw
                               ,@varnamew
                               ,@descritpionw
                               ,'compute_set'
							   ,'S'
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END
			--INSERIMENTO su tabella [securityvar] --------------END

			--INSERIMENTO su tabella [customgroupoperation] --------------BEGN
			
			IF NOT EXISTS (
					SELECT *
					FROM [dbo].[customgroupoperation]
					WHERE  [idgroup] = 'ORGANIGRAMMA' 
					AND tablename = @tableName)
			BEGIN

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'I'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'U'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'D'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')
			END
			--INSERIMENTO su tabella [customgroupoperation] --------------END

		END
		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SU TABELLA --------------END

		ELSE

		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SEMPLICE--------------BEGIN
		BEGIN

			--INSERIMENTO su tabella restrictedfunction  --------------BEGIN
			IF NOT EXISTS (
        			SELECT [idrestrictedfunction]
        			FROM [dbo].[restrictedfunction]
        			WHERE variablename = @varnamer AND
        				 description = @descritpion)
			BEGIN

				DECLARE @idxRestrictedFunction int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);

				INSERT INTO [dbo].restrictedfunction
								   ([idrestrictedfunction]
								   ,[variablename]
								   ,[description],
								   [ct],[cu],[lt],[lu])
							 VALUES
								   (@idxRestrictedFunction
								   ,@varnamer
								   ,@descritpion
								   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
			END
			--INSERIMENTO su tabella [restrictedfunction] --------------END

			--INSERIMENTO su tabella [securityvar] --------------BEGIN
			IF NOT EXISTS (
					SELECT [idsecurityvar]
					FROM [dbo].[securityvar]
					WHERE  variablename = @varnamer AND
							description = @descritpion)
			BEGIN

				DECLARE @idxSecurityvar int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

				INSERT INTO [dbo].securityvar
								   ([idsecurityvar]
								   ,[variablename]
								   ,[description]
								   ,[value]
								   ,[kind]
								   ,[ct],[cu],[lt],[lu])
				VALUES
								   (@idxSecurityvar
								   ,@varnamer
								   ,@descritpion
								   ,'compute_set'
								   ,'S'
								   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
			END
			--INSERIMENTO su tabella [securityvar] --------------BEGIN

		END
		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SEMPLICE--------------END

    END
    --INSERIMENTO NELLE VARIABILI D'AMBIENTE --------------END


	RETURN @idx;

END
GO

