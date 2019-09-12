if exists (select * from dbo.sysobjects where id = object_id(N'[exp_aliquoteiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_aliquoteiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [dbo].[exp_aliquoteiva]
(
	@bilancio varchar(120) 
)

AS BEGIN

/*            [exp_aliquoteiva] 'A.sper'
				select * from CODICE_IVA
				select * from fattura_att_dettaglio
				select * from ordine_dettaglio
				select * from fattura_att_dettaglio
               codtipoiva: Pos. 0	  lunghezza   20 Tipo:         Stringa Descrizione: Codice Tipo IVA
                  descrtipoind: Pos. 20 lunghezza   50 Tipo:         Stringa Descrizione: Descrizione Tipo IVA
                      aliquota: Pos. 70 lunghezza   22 Tipo:          Numero Descrizione: Aliquota iva
               tipoimposizione: Pos.   92 lunghezza    1 Tipo:      Codificato Codifica:1|2|3|45| 3
			   Descrizione: 1-Imponibile, 
				2-Non Imponibile,
				3-Esente,
				4-Non esposta in fattura,
				5,Fuori Campo.
	    perc_indetraibilita: Pos. 93 lunghezza   22 Tipo:          Numero Descrizione: Percentuale di indetraibilità
                   annotazioni: Pos.  115 lunghezza  400 Tipo:         Stringa Descrizione: Annotazioni
                        attivo: Pos.  515 lunghezza    1 Tipo:      Codificato Codifica:S|N Descrizione: Attivo
*/

	;with AliquoteUsate (codice_easy,CODICE_cia,descrizione,aliquota)
	as (select codice_easy, CODICE_cia, descrizione, percentuale
		from lookup_aliquote
		where bilancio = @bilancio
				)
SELECT 
	A.codice_easy as  'codtipoiva',
	CASE when len(A.descrizione)>50 then A.codice_easy + '-'+
								substring(A.descrizione, 1, 50-len(A.codice_easy)-1)
		else A.descrizione
	end	as 'descrtipoiva', 
	 isnull(C.percentuale,A.aliquota)/100	as 'aliquota',
	0 as perc_indetraibilita,
	C.descrizione as 'annotazioni',
	case when C.codice is not null then 'S'
		else 'N'
	end as 'attivo',
	case when isnull(G.imponibile, 'N')='Y' then '1'
		when isnull(G.non_imponibile, 'N')='Y' then '2'
		when isnull(G.esente, 'N')='Y' then '3'
		when isnull(G.IVA_NON_ESP_IN_FATT,'N') ='Y' then '4'
		else null
	end as 'tipoimposizione'
FROM AliquoteUsate A
LEFT OUTER JOIN  CODICE_IVA C	ON A.CODICE_cia = C.codice
LEFT OUTER JOIN GRUPPO_IVA G  	ON  G.codice  = C.gruppo_iva
 
order by C.codice

END


GO

