
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_blacklist_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_blacklist_unified
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE exp_blacklist_unified 
(
	-- A seconda della periodicità ossia T o M, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@periodicita char(1), -- M = dichiarazione Mensile, T = dichiarazione Trimestrale
	@unified char(1)
)
AS
BEGIN

IF(@unified<>'S')
Begin
	EXEC exp_blacklist @anno, @mese, @trimestre,@periodicita
	RETURN
End

-- [exp_blacklist] 2010,null, 1, 'T'
-- [exp_blacklist_unified] 2010,null, 1, 'T', 'S'
CREATE TABLE #Fatture
(
	dbdepartment varchar(150),
	idreg int,
	registry varchar(100),
	idinvkind int,
	invoicekind varchar(50),
	yinv int,
	ninv int,
	rownum int,
	idblacklist int,
	blcode char(3),
	blacklist varchar(100),
	flagbuysell char(1), -- A acquisto / V vendita 
	exchangerate float,
	adate smalldatetime,
	idinvkind_main int,
	yinv_main int,
	ninv_main int,
	-- sezione operazioni imponibili
	imponibileBeni decimal(19,2),
	ivaBeni decimal(19,2),
	imponibileServizi decimal(19,2),
	ivaServizi decimal(19,2),
	--sezione operazioni non imponibili
	nonImponibileBeni decimal(19,2),
	nonImponibileServizi decimal(19,2),
	--sezione operazioni esenti
	ammontareEsenti decimal(19,2),
	--sezione non soggette (Fuori Campo Iva)
	nonSoggetteBeni decimal(19,2),
	nonSoggetteServizi decimal(19,2)
)

DECLARE @meseinizio int
DECLARE @mesefine int

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7 
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9 
			when @trimestre = 4 then 12
			End
end

-- valorizzare opportunamente il numero dei moduli in base all'estrazione
-- dati per il record C

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
DECLARE @s varchar(300)

SET 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
		where (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @s = @iddbdepartment + '.exp_blacklist'
		
INSERT INTO #Fatture(
		dbdepartment,
		idreg,
		registry,
		invoicekind,
		flagbuysell,
		yinv,
		ninv,
		rownum,
		yinv_main,
		ninv_main,
		blcode,
		blacklist,
		adate,
		-- sezione operazioni imponibili 
		imponibileBeni,
		ivaBeni,
		imponibileServizi,
		ivaServizi,
		--sezione operazioni non imponibili
		nonImponibileBeni,
		nonImponibileServizi,
		--sezione operazioni esenti
		ammontareEsenti,
		--sezione non soggette (Fuori Campo Iva)
		nonSoggetteBeni,
		nonSoggetteServizi
	)
	EXEC @s @anno,@mese,@trimestre,@periodicita
	FETCH next FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment

SELECT 
dbdepartment as 'Dipartimento',
idreg as 'Cod. Anag',
registry as 'Anagrafica',
invoicekind as 'Tipo Doc. IVA',
flagbuysell as 'A/V',
yinv as 'Eserc.',
ninv as 'Num.',
rownum as 'Dettaglio',
yinv_main as 'Esercizio Fattura Princ.',
ninv_main as 'Numero Fattura Princ.',
blcode as 'Codice BL',
blacklist as 'Paese BL',
adate as 'Data Cont.',
-- sezione operazioni imponibili 
imponibileBeni as 'Imponibile Beni',
ivaBeni as 'Iva Beni',
imponibileServizi as 'Imponibile Servizi',
ivaServizi as 'Iva Servizi',
--sezione operazioni non imponibili
nonImponibileBeni as 'Non Impon. Beni',
nonImponibileServizi as 'Non Impon. Servizi',
--sezione operazioni esenti
ammontareEsenti as 'Esenti',
--sezione non soggette (Fuori Campo Iva)
nonSoggetteBeni as 'Fuori Campo Iva Beni',
nonSoggetteServizi as 'Fuori Campo Iva Servizi'
FROM #Fatture
ORDER BY registry,yinv_main,ninv_main, adate

DROP TABLE #Fatture
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

