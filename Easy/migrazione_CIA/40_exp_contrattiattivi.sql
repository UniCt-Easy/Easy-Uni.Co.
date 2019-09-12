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




if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contrattiattivi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contrattiattivi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_contrattiattivi]
(
	@bilancio varchar(120) 
)

AS BEGIN
SELECT 
	LKA.idreg as 'idreg',
	'N' as 'anagrafica_dettaglio',
	O.BILANCIO+DBO.NSTRFILTER(O.NUMERO_CONTRATTO,'0123456789') as 'codice_cattivo', 
	O.ESERCIZIO as 'anno_contratto',
	DBO.STRFILTER(O.NUMERO_CONTRATTO,'0123456789') as 'numero_contratto',
	O.DATA_REGISTRAZIONE as 'datacont',
	null as indcons,
	null as datacons,
	isnull(O.DESCRIZIONE,'.') as 'descrizione',
 	AUTORIZZAZIONE_CONSIGLIO_AMM as 'doc',
	DATA_AUTORIZZAZIONE as 'datadoc',
	substring(O.note,1,500) as 'note_contratto', -- Le note arrivano fino a 686 caratteri: IMPORTANTE
	null as 'codexpirationkind', -- lunghezza    1 Tipo:      Codificato Codifica:1|2|3|4|5 Descrizione:  Tipo Scadenza1-DataContabile2-Data Documento3-Fine mese Data Documento4-Fine Mese Data Contabile5-Pagamento Immediato
	null as 'scadenza',--lunghezza    4 Tipo:  Intero Descrizione: scadenza pagamento
	'EUR' as 'valuta_cont',
	(select cambio from valuta_straniera  where codice_valuta='EUR') as 'tassocambio_cont',
	case when isnull(O.INTRA_UE,'N')='Y' then 'S' else isnull(O.INTRA_UE,'N') end as 'flagintracom', -- Codificato Codifica:S|X|N Descrizione: Intracom (S)/ExtraUE (X)/Italia(N)
	null as 'riferimento',
	null as 'resp',

	CASE when len(ltrim(rtrim(cig)))<=10 then rtrim(ltrim(O.CIG)) -- Aggiungiamo i CIG > 10 nelle note
		else NULL
	END as 'cigcode',
	null as 'riferimento',
	CASE 
		/*	-- 22 + 50 = 72, restano 328	. Le note_ordine hanno lunghezza 500, mentre O.note arriva a 686, quindi max 186 verranno scritti qui. 	*/
		when  len(O.note)>500 then 'Note:' + substring(O.NOTE, 501, len(O.NOTE)-500) 
		else null
	END as noterich ,-- lunghezza  400 Tipo:         Stringa Descrizione: Note richiedente
	null as 'resp', 
	null as 'codtipoclass01',null as 'codclass01',
	null as 'codtipoclass02',null as 'codclass02',
	null as 'codtipoclass03',null as 'codclass03',
	null as 'codtipoclass04',null as 'codclass04',
	null as 'codtipoclass05',null as 'codclass05',
	-- task 7960 : "Utilizzabile per la contabilizzazione" deve valere S se flag dello STATO_CONTABILE della tabella ORDINE di CIA = N
	case when O.STATO_CONTABILE='N' then 'S' 	
		else 'N' 
	END as 'attivo',
	null as causalecrebito,
	D.numero_rata as 'nriga_cattivo',
	substring(D.DESCRIZIONE,1,150) as 'descrdett',-- IMPORTANTE : la max len è 250, la parte restante verrà scritta in 'annotation del detail'
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN isnull(D.IMPORTO_TOTALE_IT,0) ELSE ROUND(isnull(D.IMPORTO_TOTALE_IT,0) /1936.27,2) END) AS 'impon',
	laq.codice_easy as 'codtipoiva',
	case when CodIva.PERCENTUALE >0 then CodIva.PERCENTUALE/100
		 else CodIva.PERCENTUALE
	end  as 'aliquota',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN D.importo_iva ELSE ROUND(D.importo_iva/1936.27,2) END) 	AS 'iva',
	1 as 'quantita',-- non c'è il campo q.tà
	null as 'scontoperc',
	case when D.STATO_AMMINISTRATIVO='N' then 'N' 	else 'S' 	END as 'toinvoice',
	U.codeupb as 'codiceupb',
	'1' as 'nfaseentrata',
    null as 'esercmoventratacontimpon',
    null as 'nummoventratacontimpon',
    null as 'esercmoventratacontiva',
    null as 'nummoventratacontiva',
	d.DATA_INIZIO as compstart,
	d.DATA_FINE as compstop,
	CASE when (len(D.DESCRIZIONE)>150 and I.ymov is not null)
		then 'Mov.eserc.' + convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov) + '.'+' Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE, 151, len(D.DESCRIZIONE)-150) 
		when len(D.DESCRIZIONE)>150 then  'Descr.Bene (2°parte): '+	substring(D.DESCRIZIONE, 151, len(D.DESCRIZIONE)-150)
		when I.ymov is not null then 'Mov.eserc.' + convert(varchar(4), I.ymov) + ' N.'+ convert(varchar(20),I.nmov)+ '.'
		else null
	END as 'annotations', --> lunghezza 400
	null as 'causalericavo',
	null as 'rifesterno',
	null as 'codclassanal1',null as 'codclassanal2',null as 'codclassanal3'

FROM CONTRATTO_ATTIVO O 
  join CONTRATTO_ATTIVO_RATA D				on O.esercizio = d.esercizio and O.bilancio = d.bilancio and O.NUMERO_CONTRATTO = d.NUMERO_CONTRATTO  
left outer join codice_iva CodIva			on CodIva.codice = D.CODICE_IVA
left outer join lookup_aliquote laq			on laq.bilancio=d.BILANCIO and laq.codice_cia = CodIva.CODICE and laq.percentuale= CodIva.PERCENTUALE
JOIN lookup_anagrafica LKA					ON LKA.codice = O.CODICE_CLIENTE
LEFT OUTER JOIN lookup_movfin I				ON D.bilancio = I.bilancio 	and D.chiave_accertamento = I.CHIAVE_COMPLETA_DOCUMENTO 
												and D.esercizio = I.esercizio 	and I.kind = 'E'	and I.nphase = 1 
LEFT OUTER JOIN lookup_upb U				on D.UNITA_ORGANIZZATIVA = U.CHIAVE_COMPLETA
WHERE  LKA.tipo ='A'
	and O.bilancio = @bilancio
order by O.BILANCIO, O.ESERCIZIO,O.NUMERO_CONTRATTO
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

	---exec exp_contrattiattivi 'A.DIMSA'
	--exec exp_contrattiattivi 'A.AMCEN'
------------------------------------------------------------------------------------------------------------------------------------------------------------
