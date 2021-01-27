
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice_blacklistunified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoice_blacklistunified]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_invoice_blacklistunified]
(
	@anno int,
	@start smalldatetime,
	@stop smalldatetime,
	@unified char(1)
)
AS
BEGIN

IF(@unified<>'S')
Begin
	EXEC exp_invoice_blacklist @anno, @start, @stop
	RETURN
End

--[exp_invoice_blacklistunified] 2011,{d '2011-01-01'},{d '2011-12-31'},'S'

CREATE TABLE #unifiedinvoice (
	iddbdepartment varchar(50),
	invoicekind varchar(50),
	yinv int,
	ninv int,
	adate smalldatetime,
	description varchar(150),
	doc varchar(35),
	docdate smalldatetime,
	idreg int,
	registry varchar(100),
	blnation varchar(100),
	blcode char(3)
)

CREATE TABLE #unifiedinvoiceApp (
	invoicekind varchar(50),
	yinv int,
	ninv int,
	adate smalldatetime,
	description varchar(150),
	doc varchar(35),
	docdate smalldatetime,
	idreg int,
	registry varchar(100),
	blnation varchar(100),
	blcode char(3)
)
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
					 where (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.exp_invoice_blacklist'

		INSERT INTO #unifiedinvoiceApp (
				invoicekind,
				yinv,
				ninv,
				adate,
				description,
				doc,
				docdate,
				idreg,
				registry,
				blnation,
				blcode
		)
        EXEC @dip_nomesp @anno, @start, @stop

		INSERT INTO #unifiedinvoice (
				iddbdepartment,
				invoicekind,
				yinv,
				ninv,
				adate,
				description,
				doc,
				docdate,
				idreg,
				registry,
				blnation,
				blcode
		)
		SELECT @iddbdepartment,
				invoicekind,
				yinv,
				ninv,
				adate,
				description,
				doc,
				docdate,
				idreg,
				registry,
				blnation,
				blcode
		FROM #unifiedinvoiceApp

		DELETE FROM #unifiedinvoiceApp

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end
DEALLOCATE @crsdepartment

SELECT 
	dbdepartment.description as 'Dipartimento',
	invoicekind as 'Tipo Documento',
	yinv as 'Esercizio',
	ninv as 'Numero',
	adate as 'Data registrazione',
	#unifiedinvoice.description as 'Descrizione',
	doc as 'Doc. collegato',
	docdate as 'Data Doc. collegato',
	idreg as 'Codice Anagrafica',
	registry as 'Anagrafica',
	blnation as 'Nazione',
	blcode as 'Codice Nazione Blacklist'
FROM #unifiedinvoice
JOIN dbdepartment
	ON #unifiedinvoice.iddbdepartment = dbdepartment.iddbdepartment
ORDER BY  dbdepartment.description, MONTH(adate), invoicekind, yinv, ninv


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

