
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emisti_crea_versamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emisti_crea_versamenti]
GO
 --SETUSER SETUSER 'AMMINISTRAZIONE'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  procedure [emisti_crea_versamenti]

@idemisti_import INT
as
begin

CREATE TABLE #Em_Versamenti( 
	[ENTE] [nvarchar](90) NULL,
	[ENTE_DESCR] [nvarchar](90) NULL,
	[VOCE] [nvarchar](90) NULL,
	[RUOLO] [nvarchar](4) NULL,
	[CAPITOLO] [nvarchar](90) NULL,
	[COMPETENZA] [nvarchar](4) NULL,
	[MATRICOLA] [varchar](8) NULL,
	[CF] [varchar](16) NULL,
	[NOME] [nvarchar](61) NOT NULL,
	[ALIQUOTA] [decimal](6, 3) NULL,
	[IMPONIBILE] [decimal](19, 2) NULL,
	[IMP_TOT] [float] NULL,
	importoriduzionept  [float] NULL,
	importoriduzionete [float] NULL,
	codicearretrato [nvarchar](90) NULL
)
 
INSERT INTO #Em_Versamenti
select  cast(R3.CodRitPrevAss as nvarchar)+ ' - ' + ISNULL(C1.DescrizioneCodice,'')  as ENTE,
NULL AS ENTE_DESCR,
cast(R3.CodRitPrevAss as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'')+' - Dip.' as VOCE,
R1.Qualifica  as RUOLO,
--cast(R3.CodiceAssegno as nvarchar) + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as CAPITOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R3.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(  ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1)  )) as NOME,
cast(R3.AliquotaLavoratore as decimal(6, 3)) as ALIQUOTA,
cast(R3.IMPONIBILE as float)/100 as IMPONIBILE,
cast(R3.ImportoRitenuta as float)/100 as IMP_TOT,
NULL as importoriduzionept ,
NULL as	importoriduzionete,
NULL as	codicearretrato
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_03] as R3 on R1.progressivo_rec_01 = R3.progressivo_rec_01 AND R1.idemisti_import = R3.idemisti_import
left join  [emisti_codici] as C ON C.codice = R3.CodiceAssegno and C.tiporecord = 'Record2'
left join  [emisti_codici] as C1 ON LTRIM(RTRIM(C1.codice)) =  LTRIM(RTRIM(R3.CodRitPrevAss))  and C1.tiporecord = 'Record3'
where cast(R3.ImportoRitenuta as float)/100 <> 0 AND cast(R3.IMPONIBILE as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import
 
insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf, NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select  cast(R3.CodRitPrevAss as nvarchar)+ ' - ' + ISNULL(C1.DescrizioneCodice,'') as ENTE 
,cast(R3.CodRitPrevAss as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') + ' - C/E'  as VOCE,
R1.Qualifica  as RUOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R3.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
cast(R3.AliquotaDatore as decimal(6, 3)) as ALIQUOTA,
cast(R3.IMPONIBILE as float)/100 as IMPONIBILE,
cast(R3.ImportoDatore as float)/100 as IMP_TOT
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_03] as R3 on R1.progressivo_rec_01 = R3.progressivo_rec_01 AND R1.idemisti_import = R3.idemisti_import
left join  [emisti_codici] as C ON C.codice = R3.CodiceAssegno and C.tiporecord = 'Record2'
left join  [emisti_codici] as C1 ON LTRIM(RTRIM(C1.codice)) =  LTRIM(RTRIM(R3.CodRitPrevAss))  and C1.tiporecord = 'Record3'
where cast(R3.ImportoDatore as float)/100 <> 0  AND cast(R3.IMPONIBILE as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import
 

 
insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf,NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select cast(R4.CodiceRitenuta as nvarchar)+ ' - ' + ISNULL(C.DescrizioneCodice,'') as ENTE
, cast(R4.CodiceRitenuta as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') + ' - Dip.' as VOCE,
R1.Qualifica  as RUOLO,
--(SELECT TOP 1 R2.CodiceAssegno FROM [Emisti_Rec_02] as R2 Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as CAPITOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - ' 	+ CONVERT(varchar(100), (SELECT TOP 1 cast(R2.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') 
			FROM [Emisti_Rec_02] as R2 
			left join  [emisti_codici] as C1 ON C1.codice =   R2.CodiceAssegno  and C1.tiporecord = 'Record2'
			Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) )  as  CAPITOLO
	
	
	,substring(R1.Rata, 1, 4) as COMPETENZA
	,R1.iscrizione as MATRICOLA, R1.CodiceFiscale 
	,concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME
	,0 as ALIQUOTA
	,(SELECT TOP 1 cast(R2.IMportoLordoRata as float)/100 FROM [Emisti_Rec_02] as R2 Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) as IMPONIBILE
	,cast(R4.ImportoRitenuta as float)/100 as IMP_TOT

from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_04] as R4 on R1.progressivo_rec_01 = R4.progressivo_rec_01 AND R1.idemisti_import = R4.idemisti_import
left join  [emisti_codici] as C ON C.codice =  R4.CodiceRitenuta  and C.tiporecord = 'Record4'
where cast(R4.ImportoRitenuta as float) <> 0 
AND R1.idemisti_import = @idemisti_import
AND R4.tiporitenuta <> 'C' -- Se tiporitenuta = 'C' questo significa "Fondo Integr. Pens. Datore lavoro" quindi lo gestiamo come un contributo
-- al momento della modifica di questa SP non è ancora chiaro come avverrà il successivo versamento di questi contributi, sicuramente non con F24

insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf,NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select cast(R4.CodiceRitenuta as nvarchar)+ ' - ' + ISNULL(C.DescrizioneCodice,'') as ENTE
, cast(R4.CodiceRitenuta as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') + ' - C/E' as VOCE,
R1.Qualifica  as RUOLO,
--(SELECT TOP 1 R2.CodiceAssegno FROM [Emisti_Rec_02] as R2 Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as CAPITOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - ' 	+ CONVERT(varchar(100), (SELECT TOP 1 cast(R2.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') 
			FROM [Emisti_Rec_02] as R2 
			left join  [emisti_codici] as C1 ON C1.codice =   R2.CodiceAssegno  and C1.tiporecord = 'Record2'
			Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) )  as  CAPITOLO
	
	
	,substring(R1.Rata, 1, 4) as COMPETENZA
	,R1.iscrizione as MATRICOLA, R1.CodiceFiscale 
	,concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME
	,0 as ALIQUOTA
	,(SELECT TOP 1 cast(R2.IMportoLordoRata as float)/100 FROM [Emisti_Rec_02] as R2 Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) as IMPONIBILE
	,cast(R4.ImportoRitenuta as float)/100 as IMP_TOT

from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_04] as R4 on R1.progressivo_rec_01 = R4.progressivo_rec_01 AND R1.idemisti_import = R4.idemisti_import
left join  [emisti_codici] as C ON C.codice =  R4.CodiceRitenuta  and C.tiporecord = 'Record4'
where cast(R4.ImportoRitenuta as float) <> 0 
AND R1.idemisti_import = @idemisti_import
AND R4.tiporitenuta = 'C' -- Se tiporitenuta = 'C' questo significa "Fondo Integr. Pens. Datore lavoro" quindi lo gestiamo come un contributo



insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA,cf,  NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select cast(R5.CodiceRitenutaCategoria as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as ENTE
, cast(R5.CodiceRitenutaCategoria as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') + ' - Dip.' as VOCE,
R1.Qualifica    as RUOLO
--cast(R5.CodiceAssegno as nvarchar) + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as CAPITOLO,
,CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - ' 	+ CONVERT(varchar(100), (SELECT TOP 1 cast(R2.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') 
			FROM [Emisti_Rec_02] as R2 
			left join  [emisti_codici] as C1 ON C1.codice =  R2.CodiceAssegno  and C1.tiporecord = 'Record2'
			Where R2.progressivo_rec_01 = R1.progressivo_rec_01 ORDER BY r2.importolordorata DESC) )  as  CAPITOLO
,substring(R1.Rata, 1, 4) as COMPETENZA
,R1.iscrizione as MATRICOLA, R1.CodiceFiscale 
,concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME
,case
	when R5.TipoRitCat = 0 then R5.PercApplRitCat
	else R5.PercRitCat
end as ALIQUOTA
,cast(R3.IMPONIBILE as float)/100 as IMPONIBILE
,cast(R5.ImportoRitenuta as float)/100 as IMP_TOT

from   [Emisti_Rec_01] as R1 
join  [Emisti_Rec_03] as R3 on R1.progressivo_rec_01 = R3.progressivo_rec_01 AND R1.idemisti_import = R3.idemisti_import
join  [Emisti_Rec_05] as R5 on R1.progressivo_rec_01 = R5.progressivo_rec_01 AND R1.idemisti_import = R5.idemisti_import
left join  [emisti_codici] as C ON C.codice =  R5.CodiceRitenutaCategoria  and C.tiporecord = 'Record5'
where cast(R5.ImportoRitenuta as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import



insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf,NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select  cast(R7.CodRitPrevAss as nvarchar)+ ' - ' + ISNULL(C1.DescrizioneCodice,'') as ENTE 
,cast(R7.CodRitPrevAss as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') + ' - C/E'  as VOCE,
R1.Qualifica  as RUOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R7.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
NULL as ALIQUOTA,
cast(R7.IMPONIBILE as float)/100 as IMPONIBILE,
CASE WHEN cast(R7.CodiceAssegno as nvarchar) = '800' THEN -cast(R7.ImportoRitDatore as float)/100 
	ELSE cast(R7.ImportoRitDatore as float)/100 
	END as IMP_TOT
-- cast(R7.ImportoRitDatore as float)/100 as IMP_TOT  -- SE codiceassegno = 800 cambiare di segno!!!
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_07] as R7 on R1.progressivo_rec_01 = R7.progressivo_rec_01 AND R1.idemisti_import = R7.idemisti_import
left join  [emisti_codici] as C ON C.codice = R7.CodiceAssegno and C.tiporecord = 'Record6'
left join  [emisti_codici] as C1 ON LTRIM(RTRIM(C1.codice)) =  LTRIM(RTRIM(R7.CodRitPrevAss))  and C1.tiporecord = 'Record3'
where cast(R7.ImportoritDatore as float)/100 <> 0  AND cast(R7.IMPONIBILE as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import
 
 

 
insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf, NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select  cast(R7.CodRitPrevAss as nvarchar)+ ' - ' + ISNULL(C1.DescrizioneCodice,'') as ENTE 
,cast(R7.CodRitPrevAss as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') + ' - Dip.'  as VOCE,
R1.Qualifica  as RUOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R7.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
NULL as ALIQUOTA,
cast(R7.IMPONIBILE as float)/100 as IMPONIBILE,
CASE WHEN cast(R7.CodiceAssegno as nvarchar) = '800' THEN -cast(R7.ImportoRitLavoratore as float)/100 
	ELSE cast(R7.ImportoRitLavoratore as float)/100 
	END as IMP_TOT  -- SE codiceassegno = 800 cambiare di segno!!!
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_07] as R7 on R1.progressivo_rec_01 = R7.progressivo_rec_01 AND R1.idemisti_import = R7.idemisti_import
left join  [emisti_codici] as C ON C.codice = R7.CodiceAssegno and C.tiporecord = 'Record6'
left join  [emisti_codici] as C1 ON LTRIM(RTRIM(C1.codice)) =  LTRIM(RTRIM(R7.CodRitPrevAss))  and C1.tiporecord = 'Record3'
where cast(R7.ImportoRitLavoratore as float)/100 <> 0  AND cast(R7.IMPONIBILE as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import

insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf, NOME, ALIQUOTA, IMPONIBILE, IMP_TOT, importoriduzionept ,importoriduzionete, codicearretrato )
select  
cast(R6.codicearretrato as nvarchar)+ ' - ' + ISNULL(C1.DescrizioneCodice,'') as ENTE 
,cast(R6.codicearretrato as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') + ' - Dip.'  as VOCE,
R1.Qualifica  as RUOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R6.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C1.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
NULL as ALIQUOTA,
cast(R6.ImportoLordoRata as float)/100 as IMPONIBILE,
cast(-R6.ImportoLordoRata as float)/100 as IMP_TOT,
importoriduzionept ,importoriduzionete, codicearretrato
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_06] as R6 on R1.progressivo_rec_01 = R6.progressivo_rec_01 AND R1.idemisti_import = R6.idemisti_import
--left join  [emisti_codici] as C ON C.codice = R6.codicearretrato and C.tiporecord = 'Record6'
left join  [emisti_codici] as C1 ON LTRIM(RTRIM(C1.codice)) =  LTRIM(RTRIM(R6.codicearretrato))  and C1.tiporecord = 'Record6'
where   cast(R6.ImportoLordoRata as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import
AND R6.codicearretrato  IN ('ERM','ERI','ERO','159','163', '267', 'A14', 'A15', 'A16', 'A17', 'CCC', 'CCG', 'G15', 'G18','G63','J63','267')  -- Questi li devo trattare come ritenute negative e non Lordi




insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf,NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select 'IRPEF' as ENTE, 'IRPEFTotaleNetta' as VOCE,
R1.Qualifica   as RUOLO
,CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - ' + '1'  + ' - ' + ISNULL(C.DescrizioneCodice,'') as CAPITOLO,
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
0 as ALIQUOTA,
0 as IMPONIBILE,
ISNULL(cast(IRPEFTotaleNetta as float)/100,0) + ISNULL(cast(importoirpef13ma as float)/100,0) as IMP_TOT
from  [Emisti_Rec_01] as R1 
left join  [emisti_codici] as C ON C.codice =  '1'  and C.tiporecord = 'Record2'
WHERE R1.idemisti_import = @idemisti_import
 

--SELECT * FROM  #Em_Versamenti	
 
insert into  #Em_Versamenti (ENTE, VOCE, RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, cf,NOME, ALIQUOTA, IMPONIBILE, IMP_TOT )
select 'IRPEF' as ENTE, 'CreditoIRPEF' as VOCE,
R1.Qualifica   as RUOLO
,CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - ' + '1'  + ' - ' + ISNULL(C.DescrizioneCodice,'') as CAPITOLO,
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA, R1.CodiceFiscale ,
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
0 as ALIQUOTA,
0 as IMPONIBILE,
-cast(creditoirpef as float)/100 as IMP_TOT
from  [Emisti_Rec_01] as R1 
left join  [emisti_codici] as C ON C.codice =  '1'  and C.tiporecord = 'Record2'
Where cast(creditoirpef as float)/100 <> 0
AND R1.idemisti_import = @idemisti_import
 
-- SELECT * FROM  #Em_Versamenti	 where capitolo like   '%4026 - 806 - %'
select * from  #Em_Versamenti
order by MATRICOLA, CAPITOLO, VOCE

END

GO


