
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


if exists (select * from dbo.sysobjects where id = object_id(N'[CHARINDEX_BIN]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
    DROP FUNCTION CHARINDEX_BIN;
GO

-- Is similar to the built-in function Transact-SQL charindex, but regardless of collation settings,  
-- executes case-sensitive search  
-- Author:  Igor Nikiforov,  Montreal,  EMail: udfs@sympatico.ca   
CREATE function CHARINDEX_BIN(@expression1 nvarchar(4000), @expression2  nvarchar(4000), @start_location  smallint = 1)
returns nvarchar(4000)
as
    begin
       return charindex( cast(@expression1 as nvarchar(4000)) COLLATE Latin1_General_BIN, cast(@expression2  as nvarchar(4000)) COLLATE Latin1_General_BIN, @start_location )
    end
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[STRFILTER]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
    DROP FUNCTION STRFILTER;
GO

CREATE function STRFILTER  (@cExpressionSearched nvarchar(4000),   @cSearchExpression nvarchar(4000))
returns  nvarchar(4000)
as
    begin
      declare @len smallint,  @i  smallint, @StrFiltred  nvarchar(4000)
      select  @StrFiltred = N'', @i = 1,  @len =  datalength(@cExpressionSearched)/(case SQL_VARIANT_PROPERTY(@cExpressionSearched,'BaseType') when 'nvarchar' then 2  else 1 end) -- for unicode

      while  @i  <=  @len
        begin
          if dbo.CHARINDEX_BIN(substring(@cExpressionSearched, @i, 1), @cSearchExpression, default) > 0
               select  @StrFiltred = @StrFiltred + substring(@cExpressionSearched, @i, 1)
          select  @i  =   @i  + 1
        end

     return  @StrFiltred
    end
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[NSTRFILTER]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
    DROP FUNCTION NSTRFILTER;
GO

CREATE function NSTRFILTER  (@cExpressionSearched nvarchar(4000),   @cSearchExpression nvarchar(4000))
returns  nvarchar(4000)
as
    begin
      declare @len smallint,  @i  smallint, @StrFiltred  nvarchar(4000)
      select  @StrFiltred = N'', @i = 1,  @len =  datalength(@cExpressionSearched)/(case SQL_VARIANT_PROPERTY(@cExpressionSearched,'BaseType') when 'nvarchar' then 2  else 1 end) -- for unicode

      while  @i  <=  @len
        begin
          if dbo.CHARINDEX_BIN(substring(@cExpressionSearched, @i, 1), @cSearchExpression, default) <= 0
               select  @StrFiltred = @StrFiltred + substring(@cExpressionSearched, @i, 1)
          select  @i  =   @i  + 1
        end

     return  @StrFiltred
    end
GO





if exists (select * from dbo.sysobjects where id = object_id(N'[exp_ordini]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_ordini]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_ordini]
(
	@bilancio varchar(120) 
)

AS BEGIN
/*	
		[exp_ordini] 'a.sper'
		;with impegni (EsercImpegno, NumImpegno, bilancio, NUMERO_ORDINE, esercizio, NUMERO_DETTAGLIO_O)
	as (select 
			substring(D.chiave,1,4),
			substring(D.chiave,6, len(D.chiave)-5 ), 
			O.bilancio,
			O.NUMERO_ORDINE, 
			O.esercizio, 
			O.NUMERO_DETTAGLIO_O 
	from documento_contabile D
	join ordine_dettaglio O
		on D.bilancio = o.bilancio and d.ESERCIZIO=O.ESERCIZIO and D.CHIAVE_COMPLETA_DOCUMENTO = o.CHIAVE_IMPEGNO
	where D.bilancio = @bilancio
		and not exists (select * from documento_contabile D2 where
		   D2.chiave_completa_documento = D.chiave_completa_documento
		   and D2.bilancio = D.bilancio
		   and D2.esercizio = D.esercizio
		   and D2.numero_versione > D.numero_versione)
	)
*/

SELECT 
	LKA.idreg as 'idreg',
	'N' as 'anagrafica_dettaglio',
	O.BILANCIO+DBO.NSTRFILTER(O.NUMERO_ORDINE,'0123456789') as 'codice_cpassivo', 
	O.ESERCIZIO as 'anno_cpassivo',
	DBO.STRFILTER(O.NUMERO_ORDINE,'0123456789') as 'numero_cpassivo',
	O.DATA_EMISSIONE as 'datacont',
	O.INDIRIZZO_CONSEGNA as 'indcons',
	CASE when  len(O.MODALITA_CONSEGNA)<=50  then O.MODALITA_CONSEGNA --> max len è 100, quindi 50 qua, 50 nelle note
		when  len(O.MODALITA_CONSEGNA)>50  then  substring(O.MODALITA_CONSEGNA,1,50)
		Else null
	END as 'datacons',
	isnull(O.DESCRIZIONE,'.') as 'descrizione',
 	null as 'doc',
	null as 'datadoc',
	substring(O.note,1,500) as 'note_ordine', -- Le note arrivano fino a 686 caratteri: IMPORTANTE
	null as 'codexpirationkind', -- lunghezza    1 Tipo:      Codificato Codifica:1|2|3|4|5 Descrizione:  Tipo Scadenza1-DataContabile2-Data Documento3-Fine mese Data Documento4-Fine Mese Data Contabile5-Pagamento Immediato
	null as 'scadenzapag',--lunghezza    4 Tipo:  Intero Descrizione: scadenza pagamento
	O.CODICE_VALUTA as 'valuta_ord',
	V.cambio as 'tassocambio_ord',
	isnull(O.INTRA,'N') as 'flagintracom', -- Codificato Codifica:S|X|N Descrizione: Intracom (S)/ExtraUE (X)/Italia(N)
	CASE when len(ltrim(rtrim(cig)))<=10 then rtrim(ltrim(O.CIG)) -- Aggiungiamo i CIG > 10 nelle note
		else NULL
	END as 'cigcode',
	O.NUMERO_PREVENTIVO_FORNITORE as 'riferimento',
	CASE 
		/*	-- 22 + 50 = 72, restano 328	. Le note_ordine hanno lunghezza 500, mentre O.note arriva a 686, quindi max 186 verranno scritti qui. 	*/
		when  (len(O.MODALITA_CONSEGNA)>50 and len(O.note)>500 ) 
		then 'Mod.Consegna(2°p.):' + substring(O.MODALITA_CONSEGNA, 51, len(O.MODALITA_CONSEGNA)-50) + '. '+ 'Note(2°p.):' + substring(O.NOTE,501,len(O.NOTE)-500) 
		when  len(O.MODALITA_CONSEGNA)>50  then 'Mod.Consegna(2°parte):' + substring(O.MODALITA_CONSEGNA, 51, len(O.MODALITA_CONSEGNA)-50) 
		when  len(O.note)>500 then 'Note(2°p.):' + substring(O.NOTE, 501, len(O.NOTE)-500) 
		else null
	END as noterich ,-- lunghezza  400 Tipo:         Stringa Descrizione: Note richiedente
	null as 'resp', 
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

	'N' as 'flagdanger',
	null as 'codclassanal1',
	null as 'codclassanal2',
	null as 'codclassanal3',
	/*CASE when isnull(O.CANCELLATO,'N')='N' then 'S'
		else 'N'
	END as 'attivo',*/
	/*CASE WHEN 	EXISTS (SELECT * FROM ordine_dettaglio D1
						WHERE O.esercizio = D1.esercizio and O.bilancio = D1.bilancio and O.numero_ordine = D1.numero_ordine  
						AND (D1.CHIAVE_IMPEGNO IS NOT NULL OR isnull(stato_contabile,'S')<>'N'))  then 'N'
	ELSE 'S'
	END as 'attivo',*/
	-- task 7960 : "Utilizzabile per la contabilizzazione" deve valere S se flag dello STATO_CONTABILIZZAZIONE della tabella ORDINE di CIA = N
	case when STATO_CONTABILIZZAZIONE='N' then 'S' 	
		else 'N' 
	END as 'attivo',
	D.numero_dettaglio_o as 'nriga_cpassivo',
	substring(D.descrizione_bene,1,150) as 'descrdett',-- IMPORTANTE : la max len è 250, la parte restante verrà scritta in 'annotation del detail'
	null as 'promiscuo',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN D.prezzo_unitario 
	ELSE ROUND(D.prezzo_unitario/1936.27,2) END) 
	AS 'impon',
	laq.codice_easy as 'codtipoiva',
	case when D.PERCENTUALE_IVA >0 then D.PERCENTUALE_IVA/100
		 else D.PERCENTUALE_IVA
	end  as 'aliquota',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN D.importo_iva 
	ELSE ROUND(D.importo_iva/1936.27,2) END) 
	AS 'iva',
	null as 'ivaindetr',
	D.quantita as 'quantita',
	D.sconto as 'scontoperc',
	'O' as 'tipobene',-- Inventariabile(A),Aumento di valore(P),Servizi(S),Magazzino(M),Altro(O) 
	case when D.stato='N' then 'N' 	
		else 'S' 
	END as 'toinvoice',
				---S|N Descrizione: Proponi per inserimento in fatture Non c'è un'info a riguardo, c'è solo il tipo fatturazione, 
				--ma è un concetto diverso:Il campo ‘Tipo fatturazione’ serve per indicare
				/* al sistema se la pratica amministrativa afferisce
				all’attività istituzionale dell’unità organizzativa oppure all’attività commerciale: in base alla
				scelta effettuata, il sistema saprà quali aliquote Iva proporre all’utente durante la registrazione del
				documento.*/
	CASE 	when o.tipo_fatturazione = 'I' then '1'
			when o.tipo_fatturazione = 'C' then '2'
	else '4'
	END as 'tipoattivita',
	U.codeupb as 'codiceupb',
	'1' as 'nfasespesa',--> in documento_contabile  D.S.00.1.2001/125 si evince che l'impegno è la fase 1
    null as 'esercmovspesacontimpon',
    null as 'nummovspesacontimpon',
    null as 'esercmovspesacontiva',
    null as 'nummovspesacontiva',
	null as 'va3type',
	null as 'codiceinv',
	D.inizio as 'compstart',
	D.fine as 'compstop',
	CASE when (len(D.DESCRIZIONE_BENE)>150 and I.ymov is not null)
		then 'Mov.eserc.' + convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov) + '.'+' Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE_BENE, 151, len(D.DESCRIZIONE_BENE)-150) 
		when len(D.DESCRIZIONE_BENE)>150 then  'Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE_BENE, 151, len(D.DESCRIZIONE_BENE)-150)
		when I.ymov is not null then 'Mov.eserc.' + convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov)+ '.'
		else null
	END as 'annotations', --> lunghezza 400
	null as 'ivanotes',
	O.cup as 'cupcodedett',
	null as 'cigcodedett',
	null as 'scaricoimm'
FROM ordine O 
  join ordine_dettaglio D				on O.esercizio = d.esercizio and O.bilancio = d.bilancio and O.numero_ordine = d.numero_ordine  
left outer join lookup_aliquote laq		on laq.bilancio=d.BILANCIO and laq.codice_cia=d.CODICE_IVA and laq.percentuale=d.PERCENTUALE_IVA
JOIN lookup_anagrafica LKA				ON LKA.codice = O.codice_fornitore
LEFT OUTER JOIN valuta_straniera V		ON V.codice_valuta = O.codice_valuta	AND O.DATA_VALUTA >= V.DATA_VALUTA	
												AND ISNULL(V.DATA_FINE,O.DATA_VALUTA) >= O.DATA_VALUTA
LEFT OUTER JOIN lookup_movfin I			ON D.bilancio = I.bilancio 	and D.chiave_impegno = I.CHIAVE_COMPLETA_DOCUMENTO 
												and D.esercizio = I.esercizio 	and I.kind = 'S' and I.nphase = 1 
LEFT OUTER JOIN lookup_upb U			on D.UNITA_ORGANIZZATIVA = U.CHIAVE_COMPLETA
WHERE  LKA.tipo ='A'	
	and O.bilancio = @bilancio
order by O.BILANCIO, O.ESERCIZIO,O.NUMERO_ORDINE
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

	---exec exp_ordini 'A.DIMSA'

------------------------------------------------------------------------------------------------------------------------------------------------------------
