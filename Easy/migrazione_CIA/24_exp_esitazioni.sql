if exists (select * from dbo.sysobjects where id = object_id(N'[exp_esitazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_esitazioni]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- exp_esitazioni 'A.ammce'
CREATE PROCEDURE [exp_esitazioni] 
(
	@bilancio varchar(120) 
)
AS BEGIN
/*
		prende bilancio, upb da prima fase
		prende anagrafica da seconda fase
		prende importo da relazione 
		prende numero parent da lookup della prima fase
				
		
		 string[] tracciato_movban = new string[]{
            "tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
            "yban;Esercizio movimento bancario;Intero;4",
            "nban;Numero movimento bancario;Intero;8",
            "ydoc;Esercizio documento;Intero;4",
            "ndoc;Numero documento;Intero;8",
            "transactiondate;Data operazione;Data;8",
            "valuedate;Data valuta;Data;8",
            "nsub;N. subordinativo;Intero;6",
            "amount;Importo;Numero;22",
            "motive;Causale;Stringa;150"
        };
            */
            
SELECT
 case when d3.tipo='pagamento' then 'S' else 'E' end  as tipo,
  CONVERT(INT,SUBSTRING(d3.chiave, 1, 4)) as yban,
 CONVERT(INT,SUBSTRING(d3.chiave, 6, LEN(d3.chiave))) as nban,
  CONVERT(INT,SUBSTRING(d2.chiave, 1, 4)) as ydoc,
 CONVERT(INT,SUBSTRING(d2.chiave, 6, LEN(d2.chiave))) as ndoc,
 D3.data_contabilizzazione as transactiondate,
 D3.data_contabilizzazione as valuedate,
 lk.nsub as nsub,
 CONVERT(decimal(19,2),CASE WHEN RD3.esercizio>=2002 THEN RD3.ammontare_relazione ELSE ROUND(RD3.ammontare_relazione/1936.27,2) END) AS amount,
 D3.descrizione as motive
 from RELAZIONE_DCONT_DCONT_3 RD3
  join  CURR_DOCUMENTO_CONTABILE D3
	ON    RD3.CHIAVE_COMPLETA_DOC_livello3 = D3.CHIAVE_COMPLETA_DOCUMENTO
		and   RD3.esercizio = D3.esercizio
		AND	  RD3.BILANCIO = D3.BILANCIO
 join  CURR_DOCUMENTO_CONTABILE D2
	ON    RD3.CHIAVE_COMPLETA_DOC_livello2 = D2.CHIAVE_COMPLETA_DOCUMENTO
		and   RD3.esercizio = D2.esercizio
		AND	  RD3.BILANCIO = D2.BILANCIO
 JOIN lookup_movfin LK
		ON  RD3.CHIAVE_COMPLETA_DOC_livello2 = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RD3.CHIAVE_COMPLETA_DOC_livello1 =LK.CHIAVE_COMPLETA_PADRE
		AND RD3.BILANCIO = LK.BILANCIO
		AND RD3.ESERCIZIO = LK.ESERCIZIO 		
		AND LK.nphase = 3
 where rd3.bilancio=@bilancio
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 