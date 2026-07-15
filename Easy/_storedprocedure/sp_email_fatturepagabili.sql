/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[sp_email_fatturepagabili]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_email_fatturepagabili]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec sp_email_fatturepagabili 
-- setuser 'amministrazione'
CREATE    PROCEDURE [sp_email_fatturepagabili]
AS BEGIN

	CREATE TABLE #fatturepagabili
	(
		idinvkind int,
		invoicekind varchar(max),
		yinv int,
		ninv int,
		description varchar(max),
		registry varchar(max),
		idivaregisterkind int,
		ivaregisterkind varchar(max),
		emails varchar(max),
		adate date
	)
	
	;WITH fatture AS (
		SELECT 
			i.idinvkind,
			i.yinv,
			i.ninv,
			ik.description as invoicekind_desc,
			i.description as inv_description,
			r.title as registry_title,
			ir.idivaregisterkind,
			irk.description as irk_description,
			isnull(irk.emails, '') as emails,
			irk.registerclass,
			a.ct,
			-- Priorità: prima quelli con registerclass <> 'P', poi gli altri
			ROW_NUMBER() OVER (
				PARTITION BY i.idinvkind, i.yinv, i.ninv 
				ORDER BY CASE WHEN irk.registerclass <> 'P' THEN 1 ELSE 2 END
			) as rn
		FROM invoice i
		JOIN invoicekind ik ON i.idinvkind = ik.idinvkind
		JOIN ivaregister ir ON i.idinvkind = ir.idinvkind 
			AND i.yinv = ir.yinv 
			AND i.ninv = ir.ninv
		JOIN ivaregisterkind irk ON ir.idivaregisterkind = irk.idivaregisterkind
		JOIN invoiceattachment a ON i.idinvkind = a.idinvkind 
			AND i.yinv = a.yinv 
			AND i.ninv = a.ninv
		JOIN registry r ON r.idreg = i.idreg
		WHERE i.active = 'S' 
			AND a.idattachmentkind = 4 
			AND NOT EXISTS (
				SELECT 1 
				FROM expenseinvoice e 
				WHERE i.idinvkind = e.idinvkind 
					AND i.yinv = e.yinv 
					AND i.ninv = e.ninv
			)
	)
	INSERT INTO #fatturepagabili (
		idinvkind,
		invoicekind,
		yinv,
		ninv,
		description,
		registry,
		idivaregisterkind,
		ivaregisterkind,
		emails,
		adate
	)
	SELECT 
		idinvkind,
		invoicekind_desc,
		yinv,
		ninv,
		inv_description,
		registry_title,
		idivaregisterkind,
		irk_description,
		emails,
		ct
	FROM fatture
	WHERE rn = 1; 


	--select * from #fatturepagabili


	DECLARE @idivaregisterkind int
	--DECLARE @ivaregisterkind varchar(max)
	DECLARE @emails varchar(max)

	DECLARE registroiva_cursor CURSOR FOR
	select distinct idivaregisterkind,
		--ivaregisterkind,
		emails
	from #fatturepagabili

	OPEN registroiva_cursor;
	fetch next from registroiva_cursor into @idivaregisterkind, 
	--@ivaregisterkind, 
	@emails;

	WHILE @@FETCH_STATUS = 0
    BEGIN

		--select @idivaregisterkind, @emails
		
		DECLARE @Recipients NVARCHAR(MAX) = '';
    
		SET @Recipients = REPLACE(REPLACE(REPLACE(REPLACE(
			@emails,
			CHAR(13) + CHAR(10), ';'),  -- Nuova riga Windows
			CHAR(13), ';'),             -- Carriage Return
			CHAR(10), ';'),             -- Line Feed
			',', ';');                  -- Punto e virgola
    
		-- Rimuovi spazi extra e duplicati
		WHILE CHARINDEX(' ;', @Recipients) > 0
			SET @Recipients = REPLACE(@Recipients, ' ;', ';');
    
		WHILE CHARINDEX(';;', @Recipients) > 0
			SET @Recipients = REPLACE(@Recipients, ';;', ';');
    
		-- Rimuovi virgole all'inizio/fine
		IF LEFT(@Recipients, 1) = ';'
			SET @Recipients = RIGHT(@Recipients, LEN(@Recipients) - 1);
    
		IF RIGHT(@Recipients, 1) = ';'
			SET @Recipients = LEFT(@Recipients, LEN(@Recipients) - 1);

		declare @message_subject  NVARCHAR(MAX)
		set @message_subject = 'Fatture di Acquisto Pagabili'

		DECLARE @html NVARCHAR(MAX) = '';
		DECLARE @tableRows NVARCHAR(MAX) = '';
		DECLARE @rowCount INT = 0;

		--select @idivaregisterkind

		-- Creazione delle righe della tabella con colori alternati
		SELECT @tableRows = COALESCE(@tableRows + '', '') +
			CAST(
				CASE WHEN @rowCount % 2 = 0 
					 THEN '<tr style="background-color: #ffffff;">' 
					 ELSE '<tr style="background-color: #007bff30;">' 
				END +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + ISNULL(invoicekind, '') + '</td>' +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + CAST(ISNULL(yinv, '') AS VARCHAR(10)) + '</td>' +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + CAST(ISNULL(ninv, '') AS VARCHAR(10)) + '</td>' +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + ISNULL(description, '') + '</td>' +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + ISNULL(registry, '') + '</td>' +
				'<td style="padding: 8px; border: 1px solid #ddd;">' + CONVERT(VARCHAR(10), adate, 103) + '</td>' +
				'</tr>'
			AS NVARCHAR(MAX)),
			@rowCount = @rowCount + 1
		FROM #fatturepagabili
		WHERE idivaregisterkind = @idivaregisterkind
		ORDER BY adate desc, idinvkind, yinv, ninv;

		-- Costruzione dell'HTML completo
		SET @html = 
		N'<!DOCTYPE html>
		<html>
		<head>
			<style>
				table {
					border-collapse: collapse;
					width: 100%;
					font-family: Arial, sans-serif;
					font-size: 12px;
				}
				th {
					background-color: #20538b; 
					color: white;
					font-weight: bold;
				}
				td {
					max-width: 450px;
				}
				td, th {
					padding: 8px;
					border: 1px solid #ddd;
					text-align: left;
				}
				.container {
					margin: 20px;
				}
			</style>
		</head>
		<body>
			<div class="container">
				<h3>Fatture Pagabili</h3>
				<table>
					<tr>
						<th>Tipo Fattura</th>
						<th>Anno</th>
						<th>Numero</th>
						<th>Descrizione</th>
						<th>Fornitore</th>
						<th>Pagabile Dal</th>
					</tr>' 
					+ ISNULL(@tableRows, '<tr><td colspan="5" style="text-align: center;">Nessun dato disponibile</td></tr>') +
				'</table>
			</div>
		</body>
		</html>';

		
		--SELECT @html AS HTMLPreview;

		DECLARE 
			  @rc           int,
			  @mailitem_id  int,
			  @status       nvarchar(20),
			  @logmsg       nvarchar(4000);


		if @Recipients <> ''
		begin
			EXEC @rc = msdb.dbo.sp_send_dbmail
				@profile_name                = 'your-email@example.com',
				@recipients                  = @Recipients,
				@subject                     = @message_subject,
				@body                        = @html,   
				@body_format                 = 'HTML',
				--@query                       = @query_csv,
				--@execute_query_database      = 'amministrazione',
				--@attach_query_result_as_file = 1,
				--@query_attachment_filename   = @attachment_filename,
				--@query_result_separator      = '',
				--@query_result_no_padding     = 1,
				--@query_result_header         = 0,
				@query_result_width          = 32767,
				@query_no_truncate           = 1,
				@exclude_query_output        = 1,
				@mailitem_id                 = @mailitem_id OUTPUT;
		end
					
		fetch next from registroiva_cursor into @idivaregisterkind, 
		--@ivaregisterkind, 
		@emails;
	END;
    
    CLOSE registroiva_cursor;
    DEALLOCATE registroiva_cursor;

	drop table #fatturepagabili

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO