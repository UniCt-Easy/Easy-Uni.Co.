
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


-- CREAZIONE PROCEDURE [dbo].[sp_import_contratticsa]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[sp_import_contratticsa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_import_contratticsa]
GO
CREATE procedure [dbo].[sp_import_contratticsa]
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
		DECLARE @i int = (SELECT isnull(MAX(idcontratto),0) FROM dbo.contratto);

		SET @Sql = N'INSERT INTO dbo.contratto (idcontratto,ct,cu,estremibando,idcontrattokind,idinquadramento,idreg,lt,lu,parttime,scatto,start,stop,tempdef,tempindet)' + @CRLF +
		N'SELECT row_number() over(order by registry.idreg) +' + convert(nvarchar, @i) + ', GETDATE(), ''sp_import_contratticsa'', null,' + @CRLF +
		N'CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idcontrattokind,
		CASE 
			WHEN exists(select top 1 idinquadramento from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idinquadramento from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idinquadramento from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idinquadramento from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idinquadramento,' + @CRLF +
		N'registry.idreg, GETDATE(), ''sp_import_contratticsa'', null, null, 
		CONVERT(date,temp.datainizio ,103),
		ltrim(rtrim(CASE WHEN temp.datafine = '''' THEN NULL ELSE CONVERT(date,temp.datafine ,103) END)) as datafine,' + @CRLF +
		N'CASE      
			WHEN exists(select top 1 isnull(tempdef,''N'') from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)      
			THEN (select top 1 isnull(tempdef,''N'') from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)     
			WHEN exists(select top 1 idinquadramento from stipendio where stipendio.siglaimportazione =  temp.inquadramento)      
			THEN (select top 1 isnull(tempdef,''N'') from stipendio inner join inquadramento i on i.idinquadramento = stipendio.idinquadramento where stipendio.siglaimportazione =  temp.inquadramento) 
			ELSE ''N''  END as tempdef, ''S''' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT matricola, ruolo, inquadramento, datainizio, datafine' + @CRLF 
		SET @Sql = @Sql +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		WHERE CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end is not null
		and not exists (select top 1 c.idcontratto from contratto c where  c.idreg = registry.idreg  
			and YEAR(c.start) = YEAR(CONVERT(date,temp.datainizio ,103))
			and MONTH(c.start) = MONTH(CONVERT(date,temp.datainizio ,103)) 
			and DAY(c.start) = DAY(CONVERT(date,temp.datainizio ,103)) 
			and c.idcontrattokind = CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
			END)' + @CRLF + N';';

		/*select @@RowCount*/

		--aggiungere le select delle righe non importate perchè 
		--1 idcontrattokind è null
		--2 è un doppione
		DECLARE @SqlErrorRows NVARCHAR(MAX) = 'select temp.*, 
		CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idcontratto' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT matricola, ruolo, inquadramento, datainizio, datafine' + @CRLF 
		SET @SqlErrorRows = @SqlErrorRows +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ') as temp' + @CRLF +
		N'left outer JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		WHERE 
		--check presenza anagrafica--
		registry.extmatricula IS NULL OR
		--check tipologia contratto--
		CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end is null OR
		--check presenza contratto--
		 exists (select top 1 c.idcontratto from contratto c where  c.idreg = registry.idreg  
			and YEAR(c.start) = YEAR(CONVERT(date,temp.datainizio ,103))
			and MONTH(c.start) = MONTH(CONVERT(date,temp.datainizio ,103)) 
			and DAY(c.start) = DAY(CONVERT(date,temp.datainizio ,103)) 
			and c.idcontrattokind = CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
			END)
		
		) tbl1';


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

--exec [dbo].[sp_import_contratticsa] '1', '_temp1637323744064'

--CHECK DUPLICATI
--select --idreg,start, idcontrattokind, idinquadramento, cu , 
--* from contratto  
--where idreg in (select idreg from (select count(idreg) as cc, idreg,start from contratto group by idreg,start) tbl1 where cc>1)
--and idreg in (select idreg from contratto where cu = 'sp_import_contratticsa')
--order by idreg, start

GO

