DROP PROCEDURE exp_varbilancio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE exp_varbilancio
( @bilancio varchar(50)  
)
AS
BEGIN
/*		exp_varbilancio 'A.AMMCEN'

			"anno;Anno;Intero;4",
            "tipovar;Tipo variazione: 1 Normale - 2 Ripartizione - 3 Assestamento - 4 Storno;Codificato;1;1|2|3|4",
            "numprog;Numero progressivo (non ufficiale);Intero;6",
            "numuff;Numero ufficiale;Intero;6",
            "descrvar;Descrizione Variazione;Stringa;150",
            "numprovv;Numero provvedimento;Stringa;15",
            "provv;Descrizione Provvedimento;Stringa;150",
            "dataprovv;Data Provvedimento;Data;8",
            "datavar;Data Variazione;Data;8",
            "prevprinc;Variazione della prev. principale (S/N);Codificato;1;S|N",
            "prevsec;Variazione della prev. secondaria (S/N);Codificato;1;S|N",
            "codicebil;Codice bilancio;Stringa;50",
            "partebil;Parte Bilancio (E/S);Codificato;1;E|S",
            "codiceupb;Codice UPB;Stringa;50",
            "importo;Importo variazione;Numero;22",
            "descr_dett;Descrizione dettaglio variazione;Stringa;150",
            "cod_tipoclass;Cdice tipo classificazione;Stringa;20",
            "descr_tipoclass;Descrizione Tipo classificazione;Stringa;150"
            
            
            
*/            
	select	PP.esercizio as anno,
			1 as tipovar,
			DENSE_RANK() OVER(PARTITION BY PP.esercizio
						ORDER BY PP.esercizio, isnull(convert(date,PR.data_delibera),convert(date,PR.DACR)) ) as numprog,
			isnull(substring(COALESCE(PR.annotazioni_delibera,PR.motivazione_delibera,'.'),1,150),'.') as descrvar,
			substring(PR.delibera,1,15) as nummprovv,
			substring(PR.motivazione_delibera,1,150) as  provv,
			convert(date,PR.data_delibera) as dataprovv,
			isnull(convert(date,PR.data_delibera),convert(date,PR.DACR)) as datavar,		
			'S' as prevprinc,
			'N' as prevsec,	
			LB.codefin as codicebil, 
			LB.finpart as partebil, 
		    LU.codeupb as codiceupb, 
			convert(decimal(19,2), case when PP.esercizio>=2002 then isnull(PR.ammontare,0)-isnull(PR_PREC.ammontare,0) 
					else ROUND((isnull(PR.ammontare,0)-isnull(PR_PREC.ammontare,0))/1936.27,2) end) as importo,
			substring(PR.annotazioni,1,150) as descr_dett
		from preventivo_ripartizione PR 
			join piano_preventivi PP  on PP.chiave=PR.chiave_piano and PP.bilancio=PR.bilancio
			left outer join lookup_bilancio LB on PR.chiave_completa = LB.chiave_completa			
			LEFT OUTER JOIN   lookup_upb LU  ON  LU.chiave_completa = PR.UNITA_ORGANIZZATIVA
			left outer join preventivo_ripartizione PR_prec ON
						PR_PREC.unita_organizzativa	 = PR.unita_organizzativa 
						AND PR_PREC.chiave_piano	 = PR.chiave_piano 
						AND PR_PREC.bilancio	 = PR.bilancio 
						AND PR_PREC.chiave_completa	 = PR.chiave_completa 
						AND PR_PREC.chiave_versione	 = PR.chiave_versione-1 

		where
				(
					PR.chiave_versione>0 
					OR 
					(PR.chiave_versione=0  AND
						not exists(select * from preventivo P2
								where P2.chiave_piano=PR.chiave_piano and P2.bilancio=PR.bilancio 
								AND P2.chiave_versione=0  
								AND P2.chiave_completa=PR.chiave_completa 
								AND  convert(date,P2.dacr)=convert(date,PR.dacr)
								)
					)
				)
				AND isnull(PR_PREC.ammontare,0)<>isnull(PR.ammontare,0)
				AND PR.bilancio=@bilancio
				AND PP.stato_piano='D'
				AND PP.data_approvazione is not null
	order by PP.esercizio, isnull(convert(date,PR.data_delibera),convert(date,PR.DACR)) 				
				
END

GO

--exp_varbilancio 'A.AMCEN'