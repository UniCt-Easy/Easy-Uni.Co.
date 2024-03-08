
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicepaymentindicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicepaymentindicator]
GO
 
CREATE  PROCEDURE [exp_invoicepaymentindicator](
	@year 			int,
	@idivaregisterkind 	int,
	@codeinvkind varchar(20), 	  
	@codeivaregisterkind  varchar(20) ,
	@start datetime,
	@stop datetime,	
	@unified  char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@mode char(1)-- M: Considera la data Mandato	T: Considera la data Trasmissione
) 
-- setuser 'amm'
-- EXEC exp_invoicepaymentindicator 2018, null, null, null,{ts '2018-01-01 00:00:00'}, {ts '2018-07-05 00:00:00'}, 'N', null, null, null, null, null,'M'
 
/*

Ultima modifica Gianni 31/01/2015

Modalità  di calcolo
L'indicatore di tempestività  dei pagamenti e calcolato come la somma, 
per ciascuna fattura emessa a titolo corrispettivo di una transazione commerciale, 
dei giorni effettivi intercorrenti tra la data di scadenza della fattura o richiesta equivalente di pagamento e 
la data di pagamento ai fornitori moltiplicata per lâ€™importo dovuto, 
rapportata alla somma degli importi pagati nel periodo di riferimento

Gianni 04/02/2015 TASK 6429

Il calcolo prevede infatti che:
- il numeratore contenga la somma, per le transazioni commerciali PAGATE nell'anno solare, dell'importo di
ciascuna fattura pagata moltiplicato per i giorni effettivi intercorrenti tra la data di scadenza della fattura
stessa e la data di pagamento ai fornitori;

- il denominatore contenga la somma degli importi PAGATI nell'anno solare. "
L'esportazione attuale considera tutte le fatture del periodo per cui si effettua l'esportazione e non quelle pagate in tale periodo. 
Ad esempio per il 2014 mancano le fatture registrate nel 2013 e pagate nel 2014 e ci sono in più le fatture registrate nel 2014 ma pagate nel 2015.
Inoltre poichè nei primi 6 mesi la data di scadenza non era prevista, 
fare in modo che se manca la data di scadenza sulla fattura prenda la data di protocollo e se manca il protocollo prenda la data di registrazione.


3/4/2015
task 6647
La norma prevede il seguente calolo:
- il numeratore contenga la somma, per le transazioni commerciali pagate nell'anno solare, dell'importo di ciascuna fattura pagata moltiplicato per i giorni effettivi intercorrenti tra la data di scadenza della fattura stessa e la data di pagamento ai fornitori;
- il denominatore contenga la somma degli importi pagati nell'anno solare.

Attualmente la procedura di esportazione prevede una colonna "Importo dovuto per GG. Pagamento = (A)*(B)/(C)" 
	che è sbagliato in quanto induce l'utente a sommare gli importi di questa colonna ottenendo un dato errato dell'indicatore. 
L'indicatore invece prevede un rapporto tra numeratore e denominatore, nello specifico:
numeratore = Sommatoria dei prodotti tra le seguenti colonne (GG.  Pagamento (A) e Importo Pagato (B)) 
denonimatore = costante data dal totale pagato nell'anno solare (C)

Si propone pertanto di effettuare una procedura di esportazione che dia in base ad un parametro in imput da scegliere da parte dell'utente, l'elenco delle fatture o alternativamente un valore numerico complessivo dell'indicatore.

1) Se si sceglie la modalità elenco, dall'attuale procedura di esportazione deve essere TOLTA la colonna "Importo dovuto per GG. Pagamento = (A)*(B)/(C)" e AGGIUNGERE una colonna che valorizzi il prodotto tra "GG.  Pagamento (A)" e "Importo Pagato (B)"

2) Se si sceglie la modalità diretta dell'indicatore il programma darà direttamente il risultato del rapporto tra sommatoria dei prodotti "GG.  Pagamento (A)" e "Importo Pagato (B)" per ogni singola fattura / Importo pagato nell'anno solare attualmente indicato nella procedura di esportazione dalla colonna "totale pagato nell'anno solare (C)"


*/

AS BEGIN
	
	

	IF (@unified ='S')
	BEGIN
			SET @idivaregisterkind = ISNULL((SELECT idivaregisterkind FROM ivaregisterkind WHERE idivaregisterkindunified = @idivaregisterkind)
										, (SELECT idivaregisterkind FROM ivaregisterkind WHERE codeivaregisterkind = @codeivaregisterkind))
	END
 
 
	
	
	CREATE TABLE #invoicecontab
	(	
		idinvkind int,
		yinv int,
		ninv int,
		ycon int,
		ncon int,
		adate datetime, 
		protocoldate datetime,
		transmissiondate datetime,
		paymentdate datetime,
		datapagamento datetime,
		curramount decimal(19,2),
		expiring datetime,
		dateconsidered datetime,
		paymentfromexpiring  int
	)
 	-- insert dei movimenti finanziari che contabilizzano le fatture

	declare @totalepagato decimal(19,2);

	INSERT INTO #invoicecontab
	(
		idinvkind,		yinv,		ninv,		
			adate,		protocoldate,		transmissiondate,paymentdate, datapagamento, dateconsidered,
		curramount
	 )
	SELECT 
		I.idinvkind,		I.yinv,		I.ninv,		
		I.adate,	I.protocoldate,		
		PT.transmissiondate, -- era isnull(PT.bankdate, PT.streamdate),
		P.adate, 
		case when @mode = 'T' then PT.transmissiondate
		else P.adate
		end,
		coalesce(I.expiring,I.protocoldate,I.adate),

		--escludo iva split dal calcolo secondo task 8647
		isnull((select sum(taxable_euro) from invoicedetailview where idexp_taxable =  EIV.idexp),0)+
		case when I.flag_enable_split_payment='N' then isnull((select sum(iva_euro) from invoicedetailview where idexp_iva  =  EIV.idexp),0)
					else 0
		end
	FROM 	expenseinvoiceview EIV
	JOIN 	invoiceview I 				ON	EIV.idinvkind = I.idinvkind	 AND	EIV.yinv = I.yinv	 AND	EIV.ninv = I.ninv  
	JOIN invoicekind  IK			ON I.idinvkind = IK.idinvkind
	JOIN    payment P				ON	P.kpay = EIV.kpay
	JOIN    paymenttransmission PT	  ON	P.kpaymenttransmission = PT.kpaymenttransmission
   WHERE 	NOT EXISTS (SELECT * FROM pettycashoperationinvoice PCOP 
		WHERE PCOP.idinvkind = I.idinvkind 	AND	PCOP.yinv = I.yinv	AND	PCOP.ninv = I.ninv )
		AND (@mode = 'T' and  PT.transmissiondate between @start and @stop
			or
			@mode = 'M' and  P.adate between @start and @stop)
		 AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND ((EXISTS (SELECT * FROM ivaregister IRG 
			      WHERE IRG.idinvkind = I.idinvkind AND IRG.yinv = I.yinv AND IRG.ninv = I.ninv AND IRG.idivaregisterkind = @idivaregisterkind
				AND @idivaregisterkind IS NOT NULL))  
		     OR (@idivaregisterkind is null))
		AND ISNULL(I.toincludeinpaymentindicator,'S') <> 'N'		
		AND (ISNULL(I.idsor01,IK.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (ISNULL(I.idsor02,IK.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (ISNULL(I.idsor03,IK.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (ISNULL(I.idsor04,IK.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (ISNULL(I.idsor05,IK.idsor05) = @idsor05 OR @idsor05 IS NULL)
		AND (IK.flag&1=0)
		and (I.flagbit & 1 =0 ) -- Esclude le bollette doganali



INSERT INTO #invoicecontab
	(
		idinvkind,		yinv,		ninv,	
			adate,		protocoldate,		transmissiondate,paymentdate, datapagamento, dateconsidered,
		curramount
	 )
	SELECT 
		I.idinvkind,		I.yinv,		I.ninv,		
		I.adate,	I.protocoldate,		
		PT.transmissiondate, -- era isnull(PT.bankdate, PT.streamdate),
		P.adate, 
		case when @mode = 'T' then PT.transmissiondate
		else P.adate
		end,
		coalesce(I.expiring,I.protocoldate,I.adate),
		ey.amount
	FROM 	expenseprofservice EP
	join profservice PS ON	EP.ycon = PS.ycon	 AND	EP.ncon = PS.ncon	 
	JOIN 	invoiceview I 			ON	PS.idinvkind = I.idinvkind	 AND	PS.ninv = I.ninv	 	 AND	PS.yinv = I.yinv	 
	JOIN invoicekind  IK			ON I.idinvkind = IK.idinvkind
	JOIN    expenselink EL on EL.idparent  = EP.idexp 
	JOIN    expenselast ELAST on ELAST.idexp= EL.idchild
	join    expenseyear ey on elast.idexp=ey.idexp
	JOIN    payment P				ON	P.kpay = ELAST.kpay
	JOIN    paymenttransmission PT	  ON	P.kpaymenttransmission = PT.kpaymenttransmission
   WHERE 	NOT EXISTS (SELECT * FROM pettycashoperationinvoice PCOP 
		WHERE PCOP.idinvkind = I.idinvkind 	AND	PCOP.yinv = I.yinv	AND	PCOP.ninv = I.ninv )
		AND (@mode = 'T' and  PT.transmissiondate between @start and @stop
			or
			@mode = 'M' and  P.adate between @start and @stop)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND ((EXISTS (SELECT * FROM ivaregister IRG 
			      WHERE IRG.idinvkind = I.idinvkind AND IRG.yinv = I.yinv AND IRG.ninv = I.ninv  AND IRG.idivaregisterkind = @idivaregisterkind
						AND @idivaregisterkind IS NOT NULL))  
		     OR (@idivaregisterkind is null))
		AND ISNULL(I.toincludeinpaymentindicator,'S') <> 'N'		
		AND (ISNULL(I.idsor01,IK.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (ISNULL(I.idsor02,IK.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (ISNULL(I.idsor03,IK.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (ISNULL(I.idsor04,IK.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (ISNULL(I.idsor05,IK.idsor05) = @idsor05 OR @idsor05 IS NULL)
		AND (IK.flag&1=0)
		and (I.flagbit & 1 =0 )-- Esclude le bollette doganali
		and I.docdate < {ts '2017-07-01 00:00:00'} 
		
		
INSERT INTO #invoicecontab
	(
		idinvkind,		yinv,		ninv,		
		adate,		protocoldate,		transmissiondate, paymentdate, datapagamento, dateconsidered,		
		curramount
	 )
	SELECT 
		PCOP.idinvkind,		PCOP.yinv,		PCOP.ninv,	
		I.adate,	I.protocoldate,			
		PCO.adate,	
		PCO.adate,	
		PCO.adate,	
		PCO.adate,	
		PCO.amount		
	FROM 	pettycashoperationinvoice PCOP 
		join pettycashoperation PCO on PCOP.idpettycash=PCO.idpettycash and PCOP.yoperation = PCO.yoperation and PCO.noperation=PCOP.noperation
	JOIN 	invoiceview I 				ON	PCOP.idinvkind = I.idinvkind	 AND	PCOP.yinv = I.yinv	 AND	PCOP.ninv = I.ninv  
	JOIN invoicekind  IK			ON I.idinvkind = IK.idinvkind
   WHERE 	PCO.adate between @start and @stop
   AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND ((EXISTS (SELECT * FROM ivaregister IRG 
			      WHERE IRG.idinvkind = I.idinvkind
				AND IRG.yinv = I.yinv
				AND IRG.ninv = I.ninv 
				AND IRG.idivaregisterkind = @idivaregisterkind
				AND @idivaregisterkind IS NOT NULL))  
		     OR (@idivaregisterkind is null))
		AND ISNULL(I.toincludeinpaymentindicator,'S') <> 'N'		
		AND (ISNULL(I.idsor01,IK.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (ISNULL(I.idsor02,IK.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (ISNULL(I.idsor03,IK.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (ISNULL(I.idsor04,IK.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (ISNULL(I.idsor05,IK.idsor05) = @idsor05 OR @idsor05 IS NULL)
		AND (IK.flag&1=0)
		and (I.flagbit & 1 =0 ) -- Esclude le bollette doganali


			


set @totalepagato = isnull( (select sum(curramount) from #invoicecontab),0);

print '@totalepagato'
print @totalepagato


UPDATE #invoicecontab 
-- TASK 6429 fare in modo che se manca la data di scadenza sulla fattura prenda la data di protocollo e se manca il protocollo prenda la data di registrazione.
SET paymentfromexpiring = DATEDIFF ( day , #invoicecontab.dateconsidered, #invoicecontab.datapagamento)

 
 
--SELECT * FROM #invoice
--SELECT * FROM #invoicecontab

IF (
	   (@idsor01 is not null) OR (@idsor02 is not null) OR (@idsor03 is not null) OR 
	   (@idsor04 is not null) OR (@idsor05 is not null)
    )
	SELECT 	 --  filtra  sugli attributi
	I.invoicekind AS 'Tipo', 
	I.yinv AS 'Esercizio', 
	I.ninv AS 'Numero', 	
	SDI.identificativo_sdi 'identificativo SDI',  --identificativo_sdi
	I.ycon AS 'Anno parcella',
	I.ncon AS 'N.parcella',
	I.doc AS  'Num. Doc. Coll.',
	convert(varchar,I.docdate,105) AS  'Data Doc. Coll.',
	I.registry AS 'Cliente/Fornitore',
	I.description AS 'Descrizione',
	convert(varchar,I.adate,105) AS 'Data Registrazione',
	convert(varchar,I.protocoldate,105) AS 'Data Protocollo',
	convert(varchar,I.expiring,105) as 'Data Scadenza', 	
	I.total AS 'Tot. fattura',
	I.iduniqueregister as 'Cod. Progr. Registro Unico',
	convert(varchar,IC.paymentdate,105) as 'Data mandato',
	convert(varchar,IC.transmissiondate,105) as 'Data trasmissione',
	convert(varchar,IC.datapagamento,105) as 'Data considerata per il pagamento',
	convert(varchar,IC.dateconsidered,105) as 'Data considerata per la scadenza',

	IC.paymentfromexpiring as 'GG.  Pagamento (A)',
	IC.curramount AS 'Importo Pagato (B)',
	IC.paymentfromexpiring * IC.curramount AS 'GG. Pagamento (A) X Importo Pagato (B)', 
	@totalepagato as 'totale pagato nel periodo(C)',
	convert(decimal(19,10), (IC.curramount * IC.paymentfromexpiring) / @totalepagato )  as 'Importo dovuto per GG. Pagamento = (A)*(B)/(C)'
	FROM invoiceview I 		
		JOIN #invoicecontab IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  	
		left outer join sdi_acquisto SDI on I.idsdi_acquisto=SDI.idsdi_acquisto
	where IC.transmissiondate is not null
	order by I.idinvkind, I.yinv, I.ninv
ELSE
	
	SELECT 	 --  filtra  sugli attributi
	I.invoicekind AS 'Tipo', 
	I.yinv AS 'Esercizio', 
	I.ninv AS 'Numero', 	
	SDI.identificativo_sdi 'identificativo SDI',
	I.ycon AS 'Anno parcella',
	I.ncon AS 'N.parcella',
	I.doc AS  'Num. Doc. Coll.',
	convert(varchar,I.docdate,105) AS  'Data Doc. Coll.',
	I.registry AS 'Cliente/Fornitore',
	I.description AS 'Descrizione',
	convert(varchar,I.adate,105) AS 'Data Registrazione',
	convert(varchar,I.protocoldate,105) AS 'Data Protocollo',
	convert(varchar,I.expiring,105) as 'Data Scadenza', 	
	I.total AS 'Tot. fattura',
	I.iduniqueregister as 'Cod. Progr. Registro Unico',
	convert(varchar,IC.paymentdate,105) as 'Data mandato',
	convert(varchar,IC.transmissiondate,105) as 'Data trasmissione',
	convert(varchar,IC.datapagamento,105) as 'Data considerata per il pagamento',
	convert(varchar,IC.dateconsidered,105) as 'Data considerata per la scadenza',


	IC.paymentfromexpiring as 'GG.  Pagamento (A)',
	IC.curramount AS 'Importo Pagato (B)',
	@totalepagato as 'totale pagato nel periodo (C)',
	IC.paymentfromexpiring * IC.curramount AS 'GG. Pagamento (A) X Importo Pagato (B)', 
	convert(decimal(19,10),  (IC.curramount * IC.paymentfromexpiring) / @totalepagato)  as 'Importo dovuto per GG. Pagamento = (A)*(B)/(C)'
	FROM invoiceview I 		
		JOIN #invoicecontab IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  
		left outer join sdi_acquisto SDI on I.idsdi_acquisto=SDI.idsdi_acquisto
	where IC.transmissiondate is not null
	order by I.idinvkind, I.yinv, I.ninv	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



