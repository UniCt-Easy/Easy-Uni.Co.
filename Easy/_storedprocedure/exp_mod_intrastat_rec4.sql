
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


-- setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intrastat_rec4]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intrastat_rec4]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_intrastat_rec4] (
	@anno int,
	@start datetime,
	@stop datetime,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni
	@tipoRecord char(1)
)
AS
BEGIN

-- EXEC exp_mod_intrastat_rec4 2014, {d '2014-01-01'},{d '2014-12-31'},'A','B'
CREATE TABLE #Dettaglio3_SERVIZI
(	
	ninv smallint,
	yinv int ,
	invoicekind varchar(50),
	kind char(1),
	annorif int,
	flagvariation char(1),
	docdate datetime,
	segno_variazione char(1),
	is_variation char(1),
	flagpaired char(1),

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

DECLARE @idcurrency int
SELECT @idcurrency = idcurrency FROM currency WHERE codecurrency='EUR'

declare @flagAV char(1)
if (@tipoRiepilogo = 'C') --VENDITA
BEGIN
 SET @flagAV = 'V'
END
ELSE  -- ACQUISTO
BEGIN
 SET @flagAV = 'A'
END

INSERT INTO #Dettaglio3_SERVIZI(
	ninv,
	yinv,
	invoicekind,
	annorif ,
	kind,
	flagvariation,
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

SELECT 
	I.ninv,
	I.yinv,
	IK.description,
	ISNULL(YEAR(I_MAIN.docdate),YEAR(I.docdate)),
	CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,  --kind (A/V) ossia SPESA/ENTRATA
	CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END,  --flagvariation

	R.p_iva,
--	ammontareinEuro,	
	round(SUM(
			ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)
	),0),
--	ammontareinValuta,	
	CASE WHEN I.idcurrency <> @idcurrency
	THEN
	round(SUM(
			ROUND(InvDet.taxable * InvDet.npackage * (1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)
	),0)
	ELSE 0
	END,
	-- Numero Fattura
	I.doc,
	-- Data fattura formato (ggmmaa)
	I.docdate,
	--  Codice del Servizio
	S.code,
	E.code,					-- Modalità di erogazione
	E.description,
	P.code ,				-- Modalità pagamento/incasso 
	P.description,
	Pag.idintrastatnation 	-- Codice del paese di Pagamento
FROM  invoice as I 
JOIN  registry as R
	ON R.idreg = I.idreg
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN invoicedetail as InvDet 
	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
JOIN intrastatservice as S 
	ON S.idintrastatservice = InvDet.idintrastatservice
JOIN intrastatpaymethod as P 
	ON P.idintrastatpaymethod = I.idintrastatpaymethod
JOIN intrastatsupplymethod E 
	ON InvDet.idintrastatsupplymethod = E.idintrastatsupplymethod
JOIN intrastatnation as Pag	
	ON I.iso_payment = Pag.idintrastatnation
join  ivaregister IR
	ON IR.idinvkind=I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
join ivaregisterkind IR_MAIN
	ON IR.idivaregisterkind = IR_MAIN.idivaregisterkind
JOIN invoicekindregisterkind INV_REG	
	ON INV_REG.idinvkind= I.idinvkind
JOIN 	ivaregisterkind IRK
	ON IRK.idivaregisterkind= INV_REG.idivaregisterkind --AND IRK.registerclass='A'
LEFT OUTER JOIN invoice I_MAIN
	ON I_MAIN.idinvkind=InvDet.idinvkind_main and I_MAIN.yinv=InvDet.yinv_main and I_MAIN.ninv=InvDet.ninv_main
WHERE I.flagintracom = 'S'
	AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
	and (isnull(InvDet.flagbit,0) & 4) = 0
	AND InvDet.intrastatoperationkind = 'S'-- >>> Servizi
	AND I.docdate between @start and @stop 	
	AND I.idinvkind_real is null
	AND IR_MAIN.registerclass = @flagAV
	AND IRK.registerclass = @flagAV
	-- Se esportiamo le Cessioni dobbiamo escludere la scrittura nel registro Vendite, in caso di doppia registrazione
	and(@tipoRiepilogo = 'C' and not exists(select * from ivaregisterview 
				where registerclass = 'A'and ivaregisterview.idinvkind = I.idinvkind 
					and ivaregisterview.yinv = I.yinv and ivaregisterview.ninv = I.ninv					)
	or
	@tipoRiepilogo = 'A'
	)
group by R.p_iva,I.idinvkind, I.yinv, I.ninv, IK.description, IK.flag,I.idcurrency,I.doc, I.docdate, S.code, 
	S.idintrastatservice, E.idintrastatsupplymethod, E.code,E.description, P.code,P.description,InvDet.npackage,	Pag.idintrastatnation,
	I.docdate,I_MAIN.docdate,IK.flag



--calcola is_variation
update #Dettaglio3_SERVIZI set is_variation='N' where kind=@flagav AND flagvariation='N'
update #Dettaglio3_SERVIZI set is_variation='S' where kind<>@flagav OR flagvariation='S'
update #Dettaglio3_SERVIZI set is_variation='N' where kind<>@flagav AND flagvariation='S'

update #Dettaglio3_SERVIZI set flagpaired ='N'
update #Dettaglio3_SERVIZI set flagpaired ='S' WHERE  
		flagvariation='S' AND 	annorif = @anno and docdate  between @start and @stop 

--aggiusta i segni negli importi NOI GESTIAMO SOLO VARIAZIONI NEGATIVE E MAI POSITIVE
update #Dettaglio3_SERVIZI set segno_variazione='-' where flagvariation='S' and flagpaired='N'

update #Dettaglio3_SERVIZI set ammontareinEuro=-ammontareinEuro,ammontareinValuta=-ammontareinValuta
				 where flagvariation='S' and flagpaired='S'
 

--azzera annorif e meserif per tutte le righe tranne che per le variazioni non compensate
update #Dettaglio3_SERVIZI set annorif=null where flagvariation='N' or flagpaired='S'

--questo perché nella group by vanno raggruppate

IF(@tiporecord = 'S')
Begin
	SELECT 
	ninv,
	yinv,
	invoicekind,
	annorif ,
	segno_variazione,

	codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
	SUM(ammontareinEuro),			-- numerico Len.13 -- Ammontare delle operazioni in euro
	SUM(ammontareinValuta),			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura ,				-- Numero Fattura
	datafattura ,				-- Data fattura formato (ggmmaa)
	codServizio ,				-- numerico -- Codice del Servizio
	modErogazione ,				-- Modalità di erogazione
	modErogazioneDescr,
	modpagamento ,				-- Modalità pagamento/incasso 
	modpagamentoDescr,
	codPaesePagamento 			-- Codice del paese di Pagamento
 FROM #Dettaglio3_SERVIZI
	group by ninv,	yinv,	invoicekind,annorif,segno_variazione,codiceIVA,numerofattura,datafattura,codServizio,modErogazione,modErogazioneDescr,
		modpagamento,modpagamentoDescr,codPaesePagamento
	order by segno_variazione,annorif


End
	
DROP TABLE #Dettaglio3_SERVIZI

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


