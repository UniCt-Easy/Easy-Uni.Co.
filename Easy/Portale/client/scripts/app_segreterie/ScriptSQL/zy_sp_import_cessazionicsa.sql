
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


-- CREAZIONE PROCEDURE [dbo].[sp_import_cessazionicsa]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[sp_import_cessazionicsa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_import_cessazionicsa]
GO
CREATE procedure [dbo].[sp_import_cessazionicsa]
(
	@idparents nvarchar(255),
	@nometabella nvarchar(255)
)
AS
BEGIN
	SET XACT_ABORT ON
	SET NoCount ON

	DECLARE @rollbackFlag bit;
	DECLARE @SqlDrop NVARCHAR(MAX);
	SET @SqlDrop = N'DROP TABLE ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + N';';

    BEGIN TRY

		BEGIN TRANSACTION;

		DECLARE @outmsg nvarchar(255);

		DECLARE @Sql NVARCHAR(MAX);
		DECLARE @SqlExport NVARCHAR(MAX);
		DECLARE @CRLF nchar(2) = NCHAR(13) + NCHAR(10);
		DECLARE @i int = (SELECT isnull(MAX(idpcscessazioni),0) FROM dbo.pcscessazioni);

		SET @Sql = N'UPDATE dbo.contratto
		SET contratto.stop = CONVERT(DATE, temp.datafinerapporto, 103)
		FROM
		contratto
		JOIN registry 
		ON contratto.idreg = registry.idreg
		JOIN ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ' temp
		ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		WHERE contratto.stop is null AND temp.datafinerapporto IS NOT NULL;';


		DECLARE @SqlErrorRows NVARCHAR(MAX) = N'SELECT registry.idreg, CONVERT(DATE, temp.assunz, 103) as start, CONVERT(DATE, temp.finerapp, 103) as stop FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ' temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula' + @CRLF +
		N'WHERE not registry.extmatricula like ''%[^0-9]%''' + @CRLF +
		N'AND NOT EXISTS (SELECT idreg, start, stop FROM dbo.contratto)' + N';';

		exec (@Sql)
		
		SET @outmsg = 'Operation Successful';
		select @outmsg;

		/*INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0;
		Database=\\Mac\Home\Desktop\pcscessazioni.xlsx;','SELECT * FROM [Foglio1$]')*/

		--exec (@SqlErrorRows)

		exec (@SqlDrop)


		COMMIT TRANSACTION
    END TRY
    BEGIN CATCH

			set @rollbackFlag = 1;

			SET @outmsg = ERROR_MESSAGE();
			select @outmsg;

			ROLLBACK TRANSACTION
			/*SELECT
				ERROR_NUMBER() AS ErrorNumber,
				ERROR_STATE() AS ErrorState,
				ERROR_SEVERITY() AS ErrorSeverity,
				ERROR_PROCEDURE() AS ErrorProcedure,
				ERROR_LINE() AS ErrorLine,
				ERROR_MESSAGE() AS ErrorMessage;*/
        
    END CATCH

	IF @rollbackFlag = 1
		BEGIN
			exec (@SqlDrop)
		END
END;

GO
