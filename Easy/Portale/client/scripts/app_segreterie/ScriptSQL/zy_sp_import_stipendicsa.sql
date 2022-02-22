
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


-- CREAZIONE PROCEDURE [dbo].[sp_import_stipendicsa]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[sp_import_stipendicsa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_import_stipendicsa]
GO
CREATE procedure [dbo].[sp_import_stipendicsa]
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

		DECLARE @idparent nvarchar(255);
		SET @idparent = (select top 1 items from dbo.split(@idparents, ','));

		DECLARE @Sql NVARCHAR(MAX);
		DECLARE @CRLF nchar(2) = NCHAR(13) + NCHAR(10);
		DECLARE @i int = (SELECT isnull(MAX(idstipendioannuo),0) FROM dbo.stipendioannuo);

		SET @Sql = N'INSERT INTO dbo.stipendioannuo (idreg, idstipendioannuo, year,lordo,caricoente,irap,totale,ct,lt,cu,lu,idcontratto)' + @CRLF +
		N'SELECT registry.idreg, row_number() over(order by registry.idreg) +' + convert(nvarchar, @i) + ', temp.anno, temp.lordo, temp.oneri, temp.lordo * 0.085 as irap, (temp.lordo + temp.oneri +  (temp.lordo * 0.085)) as totale, GETDATE(), GETDATE(), ''sp_import_stipendicsa'', ''sp_import_stipendicsa'',
		(select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc) as idcontratto' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT anno, matricola, sum(cast(lordo as decimal(18,2))) as lordo, sum(cast(oneri as decimal(18,2))) as oneri, sum(cast(totale as decimal(18,2))) as totale' + @CRLF +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + @CRLF +
		N'GROUP BY matricola, anno' + @CRLF + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		where exists (select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc)' + @CRLF + N';';

		 --aggiungere l'export delle righe in errore perchè non risulta un contratto attivo per l'anno dello stipendio indicato
		 DECLARE @SqlErrorRows NVARCHAR(MAX) = 'select temp.* from 
		 (SELECT anno, matricola, sum(cast(lordo as decimal(18,2))) as lordo, sum(cast(oneri as decimal(18,2))) as oneri, sum(cast(totale as decimal(18,2))) as totale' + @CRLF +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + @CRLF +
		N'GROUP BY matricola, anno' + @CRLF + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		 where not exists (select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc)'


		--select @Sql
		--select @SqlErrorRows
		exec (@Sql)

		exec (@SqlDrop)
		
		SET @outmsg = 'Operation Successful';
		select @outmsg;

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

--exec [dbo].[sp_import_stipendicsa] '1', '_temp1637247421803'

GO

