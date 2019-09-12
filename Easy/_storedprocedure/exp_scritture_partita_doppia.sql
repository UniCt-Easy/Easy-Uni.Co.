  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_scritture_partita_doppia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_scritture_partita_doppia]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--[exp_scritture_partita_doppia] 'A.AMCEN'


CREATE      PROCEDURE [exp_scritture_partita_doppia]
(
	@bilancio varchar(120) 
)
AS BEGIN
/*
	 "anno;Anno Scrittura;Intero;4", 
    "numero;Numero Scrittura;Intero;8", 
    "ndett;Numero Dettaglio Scrittura;Intero;8", 
	"doc;Documento Collegato;Stringa;35", 					
    "datadoc;Data documento collegato;Data;8", 					 
    "datacontabile;Data contabile;Data;8",	
    "descrizione;Descrizione;Stringa;150", 
    "tipo;Tipo Scrittura/1 Normale/2 Rateo/3 Risconto Rettifica/4 Accantonamento/5 Risconto Integrazione/6 Epilogo/7 Apertura/8 Rettifica progetti pluriennali;Codificato;1;1|2|3|4|5|6|7|8",
    "bloccata;Bloccata(S/N);Codificato;1;S|N",
    "codtipoclass01;Codice Tipo class. 01;Stringa;20",
    "codclass01;Codice class. 01;Stringa;50",
    "codtipoclass02;Codice Tipo class. 02;Stringa;20",
    "codclass02;Codice class. 02;Stringa;50",
    "codtipoclass03;Codice tipo class. 03;Stringa;20",
    "codclass03;Codice class. 03;Stringa;50",
    "codtipoclass04;Codice Tipo class. 04;Stringa;20",
    "codclass04;Codice class. 04;Stringa;50",
    "codtipoclass05;Codice Tipo class. 05;Stringa;20",
    "codclass05;Codice class. 05;Stringa;50",
    "idrelated;ID Documento Collegato;Stringa;50",
    "importo;Importo;Numero;22",	
    "compstart;Inizio competenza;Data;8",
    "compstop;Fine competenza;Data;8",
    "idreg;Codice anagrafica;Intero;10",
    "codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
    "codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
    "codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
    "codiceupb;Codice UPB;Stringa;50",
    "codiceconto;Codice Conto;Stringa;50",
    "descrdettaglio;Descrizione Dettaglio;Stringa;400", 
	"codimportazione;Codice Importazione;Stringa;200" ,
    "causale;Codice causale;Stringa;50"
};
*/
select 
	S.ESERCIZIO as  'anno',
	S.NUMERO_SCRITTURA as  'numero',
	SD.NUMERO_MOVIMENTO	as  'ndett',
	S.TIPO_DOCUMENTO_AMM + S.ESERCIZIO_DOCUMENTO_AMM + S.NUMERO_DOCUMENTO_AMM as  'doc',
	NULL as  'datadoc',
	SD.DATA_INIZIO_PERIODO	 as  'datacontabile',
	S.DESCRIZIONE	as  'descrizione',
	1 as  'tipo',
	'S'     as 'bloccata',
	NULL 	as  'codtipoclass01',
	NULL 	as  'codclass01',
	NULL 	as  'codtipoclass02',
	NULL 	as  'codclass02',
	NULL 	as  'codtipoclass02',
	NULL 	as  'codclass02',
	NULL 	as  'codtipoclass03',
	NULL 	as  'codclass03',
	NULL 	as  'codtipoclass04',
	NULL 	as  'codclass04',
	NULL 	as  'codtipoclass05',
	NULL 	as  'codclass05',
	NULL 	as  'idrelated',
 
	CASE SD.SEZIONE 
		WHEN 'D' THEN - SD.IMPORTO	
		ELSE SD.IMPORTO
	END as  'importo',
	SD.DATA_INIZIO_PERIODO	as  'compstart',
	SD.DATA_FINE_PERIODO	as  'compstop',
	LKA.idreg	as  'idreg',
	NULL 	as  'codclassanal1',
	NULL 	as  'codclassanal2',
	NULL 	as  'codclassanal3',
	U.codeupb	as  'codiceupb',
	LKEP.codeacc	as  'codiceconto',
	S.DESCRIZIONE	as  'descrdettaglio',
	NULL 	as  'codimportazione',
	NULL 	as  'causale' 
FROM SCRITTURA_PARTITA_DOPPIA S 
join MOVIMENTO_COGE SD 
	ON S.bilancio = SD.bilancio 
	and S.esercizio = SD.esercizio
	and S.numero_scrittura = SD.numero_scrittura
JOIN lookup_anagrafica LKA
	ON LKA.codice = S.codice_anagrafico
JOIN lookup_contoep LKEP
	ON LKEP.CHIAVE_COMPLETA= SD.CHIAVE_COMPLETA_CONTO
LEFT OUTER JOIN lookup_upb U
	ON S.UNITA_ORGANIZZATIVA = U.CHIAVE_COMPLETA
where S.bilancio = @bilancio
order by S.esercizio,S.numero_scrittura,SD.numero_movimento
End

 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

 --	exec exp_scritture_partita_doppia  'A.AMCEN'
 -- amministrazione;46;exec [giove2-pc\cp1,1435].[TEST].[dbo].exp_scritture_partita_doppia 'A.AMMCE'
------------------------------------------------------------------------------------------------------------------------------------------------------------
