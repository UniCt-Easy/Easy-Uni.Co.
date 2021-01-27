
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


/* 
IMPORTANTE!!!!
update  CARICO_SCARICO_INVENT_DETT
set ubicazione = replace(ubicazione,'?','°' )
where ubicazione like '%?%'
*/
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_scarico]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_scarico
END

CREATE TABLE lookup_scarico (
	esercizio int,
	id_inventario varchar(10) ,
	n_inventario  varchar(10) ,
	progressivo_cia int ,
	numero_documento varchar(10),
	tipo_documento varchar(10),
	importo decimal(19,2),
	unita_organizzativa varchar(60),
	progressivo_easy int
)
--select * from lookup_scarico

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cespiti_posseduti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cespiti_posseduti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_cespiti_posseduti]
( @bilancio varchar(50)  = null 
)
AS BEGIN

delete from lookup_scarico

insert into lookup_scarico (esercizio,id_inventario,n_inventario,progressivo_cia,numero_documento,tipo_documento,importo,unita_organizzativa)
select esercizio,id_inventario,n_inventario_da,progressivo,numero_documento,tipo_documento,
	CONVERT(decimal(19,2),CASE WHEN esercizio>=2002 THEN isnull(scarico_effettivo ,0)
	ELSE ROUND(isnull(scarico_effettivo,0)/1936.27,2) END) 
	,
	unita_organizzativa
from CARICO_SCARICO_INVENT_DETT 
where TIPO_DOCUMENTO = 'S'
		 AND isnull(scarico_effettivo,0)<> isnull(VALORE_UNITARIO * QUANTITA,0)

update 		lookup_scarico
		set progressivo_easy= progressivo_cia+ 1 +
				(select count(*) from lookup_scarico L where L.id_inventario= lookup_scarico.id_inventario and
								L.n_inventario=lookup_scarico.n_inventario  AND 
								L.progressivo_cia  = lookup_scarico.progressivo_cia 
								AND L.esercizio < lookup_scarico.esercizio)


SELECT  
'A' as tipocespite,
I.codiceinventario as 'codiceinv',--> Codice Inventario
substring(I.descrizioneinventario,1,50) as 'descrinv',--Descrizione Inventario

I.tipo_LIB_ORD  as codeinvkind,--> Codice Tipo Inventario
CASE WHEN	I.tipo_LIB_ORD ='LIB' then 'Materiale bibliografico'
	WHEN	I.tipo_LIB_ORD ='ORD' then 'Inventario Ordinario'
	else 'ALTRO'
end as descrinvkind, --> Descr. Tipo Inventario

I.codiceente as codeinvagency,--> Codice Ente Inventariale
substring(I.descrizioneente,1,150) as descrinvagency ,--> Descrizione Ente Inventariale

CAR.N_INVENTARIO_DA AS 'numinv', --> Numero di inventario
LSCAR.progressivo_easy+1 AS 'nprogr', --> Numero progressivo. 1 per i cespiti, 2 o più per gli accessori

NULL AS 'codiceinv_prec',
NULL AS 'descrinv_prec',
NULL AS 'codeinvkind_prec',
NULL AS 'descrinvkind_prec',
NULL AS 'codeinvagency_prec',
NULL AS 'descrinvagency_prec',
NULL AS 'numinv_prec',
NULL AS 'nprogr_prec',
NULL AS 'codiceinv_succ',
NULL AS 'descrinv_succ',
NULL AS 'codeinvkind_succ',
NULL AS 'descrinvkind_succ',
NULL AS 'codeinvagency_succ',
NULL AS 'descrinvagency_succ',
NULL AS 'numinv_succ',
NULL AS 'nprogr_succ',
case when C.DATA_DOCUMENTO is null then  CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), CAR.esercizio), 105) 
else C.DATA_DOCUMENTO end as 'inizioesist',--> Inizio esistenza
isnull(CAR.CATEGORIA,'') + isnull('.'+ CAR.GRUPPO,'') + isnull('.'+CAR.SOTTO_GRUPPO,'') AS 'codiceclass',		--> Codice classificazione inventariale
SUBSTRING(CAR.DESCRIZIONE_BENE,1,150) as  descr,							--> Descrizione Cespite
LSCAR.importo AS 'impon',					--> Imponibile
0 	AS 'iva',
													--> Iva
NULL AS 'ivadetr',														-->Iva Detraibile
0 as 'ivaperc',												--> Aliquota Iva
NULL AS 'scontoperc',													--> Percentuale Sconto
NULL AS 'valorestorico',
C.tipo_carico_scarico  as 'codicecausalecar',							
substring(T.descrizione,1,30)  'descrcausalecar',					
LKA.idreg as 'codicecedente',											--> Codice Cedente (di anagrafica)
case when C.DATA_DOCUMENTO is null then  CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), CAR.esercizio), 105) 
else C.DATA_DOCUMENTO end as 'datacar',											--> Data di Carico
'S' as 'posseduto',
'N' as 'includibuonocar',
null AS 'codicetipobuonocar',				
null AS 'annobuonocar', 
null as 'numbuonocar', 

NULL AS 'resp',						-->Responsabile
NULL AS 'codeubic',										-->Codice ubicazione

case when isnull(SCAR.NUMERO_DOCUMENTO,0) <> 0 then 'S' else 'N' End as 'includibuonoscar', 
case when isnull(SCAR.NUMERO_DOCUMENTO,0) <> 0 then  I.codiceinventario else null end	as 'codicetipobuonoscar',				
case when isnull(SCAR.NUMERO_DOCUMENTO,0) <> 0 then SCAR.ESERCIZIO else null end AS 'annobuonoscar', 
case when isnull(SCAR.NUMERO_DOCUMENTO,0) <> 0 then SCAR.NUMERO_DOCUMENTO else null end as 'numbuonoscar',

case 
	when  len(CAR.DESCRIZIONE_BENE)>150 then 'Descr.:' +substring(CAR.DESCRIZIONE_BENE,150,len(CAR.DESCRIZIONE_BENE))
	else null
end as 'note'

FROM CARICO_SCARICO_INVENT_DETT CAR
LEFT OUTER JOIN CARICO_SCARICO_INVENT C
	ON C.ESERCIZIO  = CAR.ESERCIZIO 
	AND C.TIPO_DOCUMENTO = CAR.TIPO_DOCUMENTO 
	AND C.NUMERO_DOCUMENTO = CAR.NUMERO_DOCUMENTO 
	AND C.ID_INVENTARIO = CAR.ID_INVENTARIO 
JOIN lookup_inventario I 
	ON CAR.ID_INVENTARIO = I.id_inventario
LEFT OUTER JOIN INVENTARIO_TIPO_CARICO_SCARICO T
	ON C.tipo_carico_scarico = T.codice

LEFT OUTER JOIN lookup_anagrafica LKA
	ON LKA.codice = CAR.codice_fornitore
JOIN lookup_scarico LSCAR 
	ON LSCAR.ID_INVENTARIO = CAR.ID_INVENTARIO
	AND LSCAR.n_inventario = CAR.N_INVENTARIO_DA
	AND LSCAR.progressivo_cia = CAR.PROGRESSIVO
JOIN CARICO_SCARICO_INVENT_DETT SCAR
	ON SCAR.ID_INVENTARIO = CAR.ID_INVENTARIO 
	and SCAR.N_INVENTARIO_DA = CAR.N_INVENTARIO_DA 
	and SCAR.PROGRESSIVO = CAR.PROGRESSIVO
	AND SCAR.TIPO_DOCUMENTO = 'S'
	AND LSCAR.numero_documento = SCAR.NUMERO_DOCUMENTO
	AND LSCAR.unita_organizzativa = SCAR.UNITA_ORGANIZZATIVA
	AND LSCAR.esercizio = SCAR.esercizio
WHERE CAR.TIPO_DOCUMENTO = 'C'
--WHERE C.bilancio = @bilancio
--AND CAR.N_INVENTARIO_DA= 551 AND CAR.ID_INVENTARIO='D69MOB'
ORDER BY CAR.PROGRESSIVO+1

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

--EXEC exp_cespiti_posseduti NULL 

--	amministrazione;10;exec [GIOVE2-PC\SQL2008,1435].[TEST].[DBO].exp_cespiti null
------------------------------------------------------------------------------------------------------------------------------------------------------------
