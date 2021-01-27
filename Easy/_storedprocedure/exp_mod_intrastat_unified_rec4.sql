
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


-- setuser'amministrazione'

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intrastat_unified_rec4]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intrastat_unified_rec4]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
-- EXEC exp_mod_intrastat_unified_rec4 2013, {d '2013-01-01'},{d '2013-12-31'},'C','N'
CREATE  PROCEDURE [exp_mod_intrastat_unified_rec4] (
	@anno int,
	@start datetime,
	@stop datetime,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni
	@unified char(1) -- Consente di consolidare o meno i dati
)
AS
BEGIN

CREATE TABLE #RecordDettaglio3_SERVIZI
(
	ninv smallint,
	yinv int ,
	invoicekind varchar(50),
	annorif int,
	segno_variazione char(1),

	TipoRecord char(1),							-- Tipo Record 0 = frontespizio, 1 = righe dettaglio sezione 1, 3 = righe dettaglio sezione 3
	codiceIVA varchar(14),				--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										--	l’operazione intracomunitaria
	ammontareinEuro int,				-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta int,				-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura varchar(15),			-- Numero Fattura
	datafattura varchar(6),				-- Data fattura formato (ggmmaa)
	codServizio varchar(6),				-- numerico -- Codice del Servizio
	modErogazione char(1),				-- Modalità di erogazione
	modErogazioneDescr varchar(50),
	modpagamento char(1),				-- Modalità pagamento/incasso 
	modpagamentoDescr varchar(50),
	codPaesePagamento char(2)			-- Codice del paese di Pagamento
)

-- AmmontareinEuro = va riportato l’importo in euro della merce oggetto dell’operazione intracomunitaria + eventuali spese accessorie direttamente imputabili e 
-- 		opportunamente ripartite (trasporto, imballaggio, assicurazioni, etc.). L’importo va arrotondato all’unità secondo le regole dell’euro (per difetto se frazione 
-- 		inferiore a 0,5€; per eccesso se frazione superiore o uguale a 0,5€).
-- AmmontareinValuta = va indicato l’importo in valuta del paese con il quale è stata effettuata l’operazione intracomunitaria applicando il tasso di cambio alla 
-- 		data di fattura; è obbligatorio per operazioni con paesi che non hanno aderito all’euro. L’importo va arrotondato all’unità secondo le regole matematiche 
-- 		(per difetto se frazione inferiore o uguale a 0,5€; per eccesso se frazione superiore a 0,5€).
-- Valore Statistico in Euro = il valore statistico è costituito dal valore della merce più le spese di consegna (trasporto, assicurazione, etc.) fino al confine 
--		italiano (valore franco confine italiano). Per calcolare il valore statistico è necessario tenere conto delle condizioni di consegna concordate in base alle 
--		clausole “incoterms”.

-- Codice della natura dela transazione = Natura della transazione (colonna 5 cessioni; colonna 6 acquisti): va indicato un codice tra quelli riportati nella tabella 
-- relativa del decreto 27 ottobre 2000. In presenza di operazione triangolare comunitaria in cui l’operatore italiano assume la veste di acquirente/cedente, come natura 
-- della transazione va utilizzato il codice alfabetico. In tutti gli altri casi va utilizzato il codice numerico=> USIAMO SOLO QUELLO NUMERICO 

DECLARE @s varchar(300)
IF(@unified<>'S')
Begin
	set @s = 'exp_mod_intrastat_rec4'
	INSERT INTO #RecordDettaglio3_SERVIZI
		(
			ninv,
			yinv,
			invoicekind,
			annorif ,
			segno_variazione ,
			codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
			ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
			ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
			numerofattura ,				-- Numero Fattura
			datafattura ,				-- Data fattura formato (ggmmaa)
			codServizio ,				-- numerico -- Codice del Servizio
			modErogazione ,				-- Modalità di erogazione
			modErogazioneDescr,
			modpagamento ,				-- Modalità pagamento/incasso 
			modpagamentoDescr,
			codPaesePagamento 			-- Codice del paese di Pagamento
		)
		
	exec @s @anno,@start, @stop,@tipoRiepilogo, 'S'
End

Else
Begin
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor


SET 	@crsdepartment = cursor for 
						 select iddbdepartment from dbdepartment
						 where  (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @s = @iddbdepartment + '.exp_mod_intrastat_rec4'
			
		INSERT INTO #RecordDettaglio3_SERVIZI(
			yinv,
			ninv,
			invoicekind,
			annorif ,
			--segno_variazione ,
			codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
			ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
			ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
			numerofattura,				-- Numero Fattura
			datafattura ,				-- Data fattura formato (ggmmaa)
			codServizio ,				-- numerico -- Codice del Servizio
			modErogazione ,				-- Modalità di erogazione
			modErogazioneDescr,
			modpagamento ,				-- Modalità pagamento/incasso 
			modpagamentoDescr,
			codPaesePagamento 			-- Codice del paese di Pagamento
		)
		exec @s @anno,@start, @stop,@tipoRiepilogo, 'S'


		fetch next from @crsdepartment into @iddbdepartment
end
End

UPDATE #RecordDettaglio3_SERVIZI SET  TipoRecord = '4' WHERE segno_variazione ='-'


IF (@tipoRiepilogo ='C')
BEGIN
	SELECT 
		invoicekind as 'Tipo',
		yinv as 'Num.Fattura',
		ninv as 'Eserc.Fattura',
		codiceIVA  as'Codice IVA', 
		ammontareinEuro as 'Ammontare Euro',
		numerofattura  as 'Num.Protocollo', 
		datafattura as 'Data Fattura', 
		codServizio ,
		modErogazioneDescr as 'Mod.Erogazione', 
		modpagamentoDescr as 'Mod.Pagamento',
		codPaesePagamento
	FROM #RecordDettaglio3_SERVIZI where TipoRecord='4'
END


--12  sezione 3  SERVIZI  RICEVUTI 
IF (@tipoRiepilogo ='A' )
BEGIN
	SELECT 
	 	yinv,
		ninv,
		invoicekind,
		codiceIVA  , 
		ammontareinEuro as 'Ammontare Euro',
		ammontareinValuta as 'Ammontare Valuta',
		numerofattura  as 'Num.Protocollo', 
		datafattura as 'Data Fattura', 
		codServizio ,
		modErogazioneDescr as 'Mod.Erogazione', 
		modpagamentoDescr as 'Mod.Pagamento',
		codPaesePagamento
	FROM #RecordDettaglio3_SERVIZI where TipoRecord='4'
END



DROP TABLE #RecordDettaglio3_SERVIZI
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




