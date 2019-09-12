 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fatture_vendita]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fatture_vendita]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_fatture_vendita]
(
	@bilancio varchar(120) 
)
AS BEGIN

-- exp_fatture_vendita 'a.ammce'
--DECLARE @lastday datetime
--SET 	@lastday = CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)


/*
CREATE TABLE #ACCERTAMENTI (
	EsercAccertamento int, 
	NumAccertamento int, 
	bilancio varchar(10), 
	NUMERO_FATTURA varchar(10), 
	esercizio int, 
	NUMERO_DETTAGLIO int
)

INSERT INTO #ACCERTAMENTI (EsercAccertamento, NumAccertamento, bilancio, NUMERO_FATTURA, esercizio, NUMERO_DETTAGLIO)
select 
		CONVERT(int,substring(D.chiave,1,4)),
		convert(int,substring(D.chiave,6, len(D.chiave)-5 )), 
		O.bilancio,
		O.NUMERO_FATTURA, 
		O.esercizio, 
		O.NUMERO_DETTAGLIO
from curr_documento_contabile D
join fattura_att_dettaglio O
	on D.bilancio = o.bilancio and d.ESERCIZIO = O.ESERCIZIO and D.CHIAVE_COMPLETA_DOCUMENTO = o.chiave_accertamento
where D.bilancio = @bilancio
*/	
 ;with FATTURA_MADRE(Tipo_fattura_madre, bilancio, Anno_fattura_madre, Num_fattura_madre, RICHIESTA_FATTURAZIONE)
as (select distinct 
case when F.RICHIESTA_FATTURAZIONE='Y' then  F.TIPO_FATTURA + '_RICHFATT'
	else F.TIPO_FATTURA + '_NORICHFATT'
	End,
	D.bilancio,
	D.esercizio_f_collegata,
	D.numero_fattura_collegata,
	D.RICHIESTA_FATTURAZIONE
from fattura_Att F
join fattura_att_dettaglio D
	on F.bilancio = D.bilancio 
	and F.numero_fattura = D.numero_fattura
	and F.esercizio = D.esercizio
	and F.RICHIESTA_FATTURAZIONE = D.RICHIESTA_FATTURAZIONE
where nota_credito_debito <>'F' )


select 
	LKA.idreg as 'idreg',
	case 
		when F.RICHIESTA_FATTURAZIONE='Y'  and D.numero_fattura_collegata is null	then  F.TIPO_FATTURA + '_RICHFATT'
		when F.RICHIESTA_FATTURAZIONE='Y'  and D.numero_fattura_collegata is not null then 'ND-'+ F.TIPO_FATTURA + '_RICHFATT'
		when F.RICHIESTA_FATTURAZIONE='N'  and D.numero_fattura_collegata is null		then  F.TIPO_FATTURA +  '_NORICHFATT'
		when F.RICHIESTA_FATTURAZIONE='N'  and D.numero_fattura_collegata is not null then  'ND-'+F.TIPO_FATTURA +  '_NORICHFATT'
	End as 'codtipofattura',		
	'V' as acquistovendita,
	F.esercizio as 'annofattura',
	convert(int,replace(F.numero_fattura, F.tipo_fattura,'')) as 'numfattura',
	case when F.nota_credito_debito ='F' then 'N'
		else 'S'
	end as 'notacredito',
--	NC.Tipo_fattura_madre as 'codtipofatturaprinc',
	case 
		when F.RICHIESTA_FATTURAZIONE='Y'  and D.numero_fattura_collegata is not null then  F.TIPO_FATTURA + '_RICHFATT'
		when F.RICHIESTA_FATTURAZIONE='N'  and D.numero_fattura_collegata is not null then  F.TIPO_FATTURA +  '_NORICHFATT'
		else null
	End as 'codtipofatturaprinc',
	NC.esercizio as 'annofatturaprinc',
	convert(int,replace(NC.numero_fattura, F.tipo_fattura,''))  as 'numfatturaprinc',
	isnull(F.descrizione ,'.')as 'descrfattura', 
	null as 'codexpirationkind', 
	null as 'paymentexpiring',
	null as 'datadoctrasporto',
	null as 'numdoctrasporto' ,   
	null as 'codicecass',
    F.codice_valuta as 'valuta_fatt',
    V.cambio as 'tassocambio_fatt',
    F.numero_fattura as 'doc',
	isnull(F.DATA_registrazione,CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), F.esercizio), 105)) as 'datadoc',
    isnull(F.DATA_fattura,isnull(F.DATA_registrazione,CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), F.esercizio), 105)) ) as 'datafatt',
    case when isnull(F.liquidazione_differita,'N')='N'then 'N'     
	else 'S' 
	end as 'ivadifferita',
   --   CASE when isnull(F.CANCELLATO,'N')='N' then 'S'
	--	else 'N'
	--END as 'attivo',
	CASE F.stato
		WHEN 'L'  THEN 'S'    -- nuovo (non contabilizzato)
		WHEN 'Q' THEN 'S'     -- contabilizzato parzialmente
		WHEN 'T' THEN 'N'     -- contabilizzato totalmente  
		WHEN 'P' THEN 'N'     -- reversale estinto  active = 'N'
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
    D.numero_dettaglio as 'nriga_fatt',
	substring(D.descrizione,1,150) as 'descrdettaglio',
	CASE when (len(D.descrizione)>150 and A.ymov is not null)
		then 'Mov.eserc.'+ convert(varchar(4), A.ymov) + ' N.'+ convert(varchar(20),A.nmov) + '.'+' Descr.Bene (2°parte): '+	substring(D.descrizione, 151, len(D.descrizione)-150) 
		when len(D.descrizione)>150 then  'Descr.Bene (2°parte): '+	substring(D.descrizione, 151, len(D.descrizione)-150)
		when A.ymov is not null then 'Mov.eserc.'+ convert(varchar(4), A.ymov) + ' N.'+ convert(varchar(20),A.nmov) + '.'
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
    D.PERCENTUALE_SCONTO as 'scontoperc',
	null as 'codclassanal1',
	null as 'codclassanal2',
	null as 'codclassanal3',             
	null as 'nfasespesa',
    null as 'esercmovspesacontimpon',
    null as 'nummovspesacontimpon',
    null as 'esercmovspesacontiva',
    null as 'nummovspesacontiva',
    '1' as 'nfaseentrata',
	null as 'esercmoventratacontimpon',
	null as 'nummoventratacontimpon',
	null as 'esercmoventratacontiva',
	null as 'nummoventratacontiva',
	U.codeupb as 'codiceupb',
	null as 'codice_cpassivo',
	null as 'anno_cpassivo',
	null as 'numero_cpassivo',
	null as 'nriga_cpassivo',
	null as 'idgroup'
FROM FATTURA_att F 
join fattura_att_dettaglio d
	on F.bilancio = D.bilancio 
	and F.numero_fattura = D.numero_fattura
	and F.esercizio = D.esercizio
	and F.RICHIESTA_FATTURAZIONE = D.RICHIESTA_FATTURAZIONE
left outer join lookup_aliquote laq
	on laq.bilancio=d.BILANCIO and laq.codice_cia=d.CODICE_IVA and laq.percentuale=d.PERCENTUALE_IVA
left outer JOIN lookup_anagrafica LKA
	ON LKA.codice = F.codice_cliente
left outer join fattura_att_dettaglio NC
	on D.bilancio = NC.bilancio 
	and D.numero_fattura_collegata = NC.numero_fattura 
	and D.esercizio_f_collegata = NC.esercizio
	and D.RICHIESTA_FATTURAZIONE = NC.RICHIESTA_FATTURAZIONE
	and D.numero_dettaglio = NC.numero_dettaglio
LEFT OUTER JOIN valuta_straniera V
	ON V.codice_valuta = F.codice_valuta
	AND F.DATA_VALUTA >= V.DATA_VALUTA
	AND ISNULL(V.DATA_FINE,F.DATA_VALUTA) >= F.DATA_VALUTA
LEFT OUTER JOIN lookup_movfin A
	ON D.bilancio = A.bilancio 
	and D.chiave_accertamento = A.CHIAVE_COMPLETA_DOCUMENTO 
	and D.esercizio = A.esercizio 
	and A.nphase = 1 
	and A.kind='E'
LEFT OUTER JOIN lookup_upb U
	on D.UNITA_ORGANIZZATIVA = U.CHIAVE_COMPLETA
where F.bilancio = @bilancio

order by  F.esercizio, F.numero_fattura
	
End

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

 -- exec exp_fatture_vendita 'A.AMCEN'--'A.DIMSA'
 -- amministrazione;27;exec [giove2-pc\cp1,1435].[TEST].[dbo].exp_fatture_vendita 'A.AMMCE'
------------------------------------------------------------------------------------------------------------------------------------------------------------
