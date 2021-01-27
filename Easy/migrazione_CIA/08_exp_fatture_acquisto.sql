
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fatture_acquisto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fatture_acquisto]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--[exp_fatture_acquisto] 'A.00000'


CREATE      PROCEDURE [exp_fatture_acquisto]
(
	@bilancio varchar(120) 
)
AS BEGIN
select 
	LKA.idreg as 'idreg',
	/*case when numero_fattura_collegata is null then  LKF.codtipofatturaeasy
		 when numero_fattura_collegata is not null then  LKNC.codtipofatturaeasy
	End as 'codtipofattura',		*/ -- Vedi task 7677
	
	case when F.NOTA_CREDITO_DEBITO ='F' then  LKF.codtipofatturaeasy
		 when F.NOTA_CREDITO_DEBITO<>'F' then  LKNC.codtipofatturaeasy
	End as 'codtipofattura',

	'A' as acquistovendita,
	F.esercizio as 'annofattura',
	substring(F.numero_fattura,2,5) as 'numfattura',
	case when F.nota_credito_debito ='F' then 'N'
		else 'S'
	end as 'notacredito',
	(  select codtipofatturaeasy  from lookup_fattura 
	where codtipofatturacia = NC.tipo_fattura + substring(NC.numero_fattura,7,4) and isnull(notadicredito,'N') = 'N')
	as 'codtipofatturaprinc',
	--NC.codtipofattura 'codtipofatturaprinc',
	NC.esercizio as 'annofatturaprinc',
	substring(NC.numero_fattura,2,5) as 'numfatturaprinc',
	isnull(F.descrizione,'.') as 'descrfattura', 
	null as 'codexpirationkind', 
	null as 'paymentexpiring',
	null as 'datadoctrasporto',
	null as 'numdoctrasporto' ,   
	null as 'codicecass',
    F.codice_valuta as 'valuta_fatt',
    V.cambio as 'tassocambio_fatt',
    F.NUMERO_FATTURA_FORNITORE as 'doc', --F.numero_fattura as 'doc',
	isnull(F.DATA_registrazione, F.DATA_fattura) as 'datafatt',
    F.DATA_fattura as 'datadoc',
    case when isnull(F.liquidazione_differita,'N')='N'then 'N'     
	else 'S' 
	end as 'ivadifferita',
     --   CASE when isnull(F.CANCELLATO,'N')='N' then 'S'
	--	else 'N'
	--END as 'attivo',
	CASE F.stato
		WHEN 'L'   THEN 'S'   -- nuovo (non contabilizzato)
		WHEN 'Q' THEN 'S'     -- contabilizzato parzialmente
		WHEN 'M' THEN 'N'     -- contabilizzato totalmente  
		WHEN 'P' THEN 'N'     -- mandato estinto   
		WHEN 'I' THEN 'N'     -- fatture collegate a prestazioni
		WHEN 'S' THEN 'N'     -- trasmesse a cassiere
		ELSE 'S'
	END as 'attivo',
	case when isnull(F.intraue,'N')='Y' then 'S'
	else 'N' 
	end as 'flagintracom',
	null as 'codtipoclass01',
	null as 'codclass01',
	null as 'codtipoclass02',
	null as 'codclass02',
	null as 'codtipoclass03',
	null as 'codclass03',
	null as 'codtipoclass04',
	null as 'codclass04',
	null as 'codtipoclass05',
	null as 'codclass05',
    case 
		when F.data_scadenza is not null then 'Scadenza: ' + LEFT(CONVERT(VARCHAR, F.data_scadenza, 105), 10)
		else null
	end as 'note_fatt',
    D.numero_dettaglio_f as 'nriga_fatt',
	substring(D.DESCRIZIONE_BENE,1,150) as 'descrdettaglio',
	CASE when (len(D.DESCRIZIONE_BENE)>150 and I.ymov is not null)
		then 'Mov.eserc.'+convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov)+ '.'+' Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE_BENE, 151, len(D.DESCRIZIONE_BENE)-150) 
		when len(D.DESCRIZIONE_BENE)>150 then  'Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE_BENE, 151, len(D.DESCRIZIONE_BENE)-150)
		when I.ymov is not null then 'Mov.eserc.' + convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov) + '.'
		else null
	END as 'annotazioni',
    laq.codice_easy as 'codtipoiva',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN D.importo_iva 
	ELSE ROUND(D.importo_iva/1936.27,2) END) 
	AS 'iva',
    null as 'ivaindetr',
    isnull(D.quantita,1) as 'quantita',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN D.prezzo_unitario 
	ELSE ROUND(D.prezzo_unitario/1936.27,2) END) 
	AS 'impon',
	case
		when ( isnull(D.IMPORTO_SCONTO,0) >0 and isnull(D.prezzo_unitario,0)>0 ) then (D.importo_sconto/D.prezzo_unitario ) 
		else null 
	end  as 'scontoperc',
	null as 'codclassanal1',
	null as 'codclassanal2',
	null as 'codclassanal3',             
	'1' as 'nfasespesa',
    null as 'esercmovspesacontimpon',
    null as 'nummovspesacontimpon',
    null as 'esercmovspesacontiva',
    null as 'nummovspesacontiva',
    null as 'nfaseentrata',
	null as 'esercmoventratacontimpon',
	null as 'nummoventratacontimpon',
	null as 'esercmoventratacontiva',
	null as 'nummoventratacontiva',
	U.codeupb as 'codiceupb',
	O.BILANCIO+DBO.NSTRFILTER(O.NUMERO_ORDINE,'0123456789') as 'codice_cpassivo', 
	O.esercizio as 'anno_cpassivo',
	DBO.STRFILTER(O.NUMERO_ORDINE,'0123456789') as 'numero_cpassivo',
	O.numero_dettaglio_o as 'nriga_cpassivo',
	null as 'idgroup',
	F.prog_registro_unico as 'prog_registro_unico',  
	F.numero_protocollo_entrata as 'numero_protocollo_entrata', 
	F.data_protocollo_entrata as 'dataricezione', 
	CASE when len(ltrim(rtrim(F.cig)))<=10 then rtrim(ltrim(F.cig)) 
	else NULL
	END as 'cigcode',
	CASE when len(ltrim(rtrim(F.cup)))<=15 then rtrim(ltrim(F.cup)) 
	else NULL
	END as 'cupcode',
		(select top 1 natura_spesa
		from  estrazione_pcc_fatture PCC 
		where  PCC.numero_fattura = F.numero_fattura
		and PCC.esercizio = F.esercizio
		and PCC.bilancio = F.bilancio
		and natura_spesa is not null) as 'natura_spesa',
		(select top 1 stato_debito
		from  estrazione_pcc_fatture PCC 
		where  PCC.numero_fattura = F.numero_fattura
		and PCC.esercizio = F.esercizio
		and PCC.bilancio = F.bilancio
		and stato_debito is not null) as 'stato_debito',
	isnull(F.split_payment,'N') as split_payment
FROM FATTURA F 
join fattura_dettaglio D
	on F.bilancio = D.bilancio 
	and F.numero_fattura = D.numero_fattura
	and F.esercizio = D.esercizio
join lookup_fattura LKF
	on LKF.codtipofatturacia = F.tipo_fattura + substring(F.numero_fattura,7,4) and isnull(LKF.notadicredito,'N') = 'N'
left outer join lookup_fattura LKNC
	on LKNC.codtipofatturacia = F.tipo_fattura + substring(F.numero_fattura,7,4) and isnull(LKNC.notadicredito,'N') = 'S'
left outer join lookup_aliquote laq
	on laq.bilancio = d.BILANCIO 
	and laq.codice_cia = d.CODICE_IVA 
	and laq.percentuale = d.PERCENTUALE_IVA
LEFT OUTER JOIN lookup_anagrafica LKA
	ON LKA.codice = F.CODICE_FORNITORE
left outer join FATTURA NC
	on D.numero_fattura_collegata = NC.numero_fattura
	and D.esercizio_f_collegata = NC.esercizio
	and D.bilancio = NC.bilancio
LEFT OUTER JOIN valuta_straniera V
	ON V.codice_valuta = F.codice_valuta
	AND F.DATA_VALUTA >= V.DATA_VALUTA
	AND ISNULL(V.DATA_FINE,F.DATA_VALUTA) >= F.DATA_VALUTA
LEFT OUTER JOIN lookup_movfin I
	ON D.bilancio = I.bilancio 
	and D.CHIAVE_IMPEGNO = I.CHIAVE_COMPLETA_DOCUMENTO 
	and D.esercizio = I.esercizio 
	and I.nphase = 1 
	and I.kind='S'
LEFT OUTER JOIN lookup_upb U
	on D.UNITA_ORGANIZZATIVA = U.CHIAVE_COMPLETA
LEFT OUTER JOIN ordine_dettaglio O
	on D.numero_ordine = O.numero_ordine
	and D.esercizio_ordine = O.esercizio
	and D.numero_dettaglio_o = O.numero_dettaglio_o
	and D.bilancio = O.bilancio
where F.bilancio = @bilancio
order by F.TIPO_FATTURA,F.esercizio,LKF.codtipofatturaeasy,substring(F.numero_fattura,2,5) 
--and (D.numero_fattura_collegata='I00342AACE' or F.numero_fattura='I00342AACE')
End


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

 --	exec exp_fatture_acquisto 'A.AMCEN'
 -- amministrazione;27;exec [SERVER\cp1,1435].[TEST].[dbo].exp_fatture_acquisto 'A.AMMCE'
------------------------------------------------------------------------------------------------------------------------------------------------------------