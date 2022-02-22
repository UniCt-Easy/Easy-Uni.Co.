
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


/* 
IMPORTANTE!!!!
update  CARICO_SCARICO_INVENT_DETT
set ubicazione = replace(ubicazione,'?','°' )
where ubicazione like '%?%'
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cespiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cespiti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_cespiti]
( @bilancio varchar(50)  = null 
)
AS BEGIN


SELECT  
CASE WHEN CAR.PROGRESSIVO=0 THEN 'C' ELSE  'A' END as tipocespite,
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
CAR.PROGRESSIVO+1 AS 'nprogr', --> Numero progressivo. 1 per i cespiti, 2 o più per gli accessori

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
COALESCE(
	CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), CAR.ANNO_FABBRICAZIONE), 105),
	C.DATA_DOCUMENTO,
	CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), CAR.esercizio), 105) 
	) as 'inizioesist',--> Inizio esistenza		
isnull(CAR.CATEGORIA,'') + isnull('.'+ CAR.GRUPPO,'') + isnull('.'+CAR.SOTTO_GRUPPO,'') AS 'codiceclass',		--> Codice classificazione inventariale
SUBSTRING(CAR.DESCRIZIONE_BENE,1,150) as  descr,							--> Descrizione Cespite
CONVERT(decimal(19,2),CASE WHEN CAR.esercizio>=2002 THEN isnull(CAR.VALORE_UNITARIO ,0)
	ELSE ROUND(isnull(CAR.VALORE_UNITARIO ,0)/1936.27,2) END) 
-
CONVERT(decimal(19,2),CASE WHEN CAR.esercizio>=2002 THEN isnull(CAR.importo_iva ,0)
ELSE ROUND(isnull(CAR.importo_iva ,0)/1936.27,2) END) 
 AS 'impon',					--> Imponibile
CONVERT(decimal(19,2),CASE WHEN CAR.esercizio>=2002 THEN isnull(CAR.importo_iva ,0)
ELSE ROUND(isnull(CAR.importo_iva ,0)/1936.27,2) END) 
	AS 'iva',
													--> Iva
NULL AS 'ivadetr',														-->Iva Detraibile
case when isnull(CAR.ALIQUOTA_IVA,0)>0 then CAR.ALIQUOTA_IVA/100
		else 0
		end as 'ivaperc',												--> Aliquota Iva
NULL AS 'scontoperc',													--> Percentuale Sconto
NULL AS 'valorestorico',
C.tipo_carico_scarico  as 'codicecausalecar',							
substring(T.descrizione,1,30)  'descrcausalecar',					
LKA.idreg as 'codicecedente',											--> Codice Cedente (di anagrafica)
case when C.DATA_DOCUMENTO is null then  CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), CAR.esercizio), 105) 
else C.DATA_DOCUMENTO end as 'datacar',											--> Data di Carico
'N' as 'posseduto',
case when isnull(CAR.NUMERO_DOCUMENTO,0) <> 0 then 'S' else 'N' End as 'includibuonocar',
case when isnull(CAR.NUMERO_DOCUMENTO,0) <> 0 then I.codiceinventario else null end AS 'codicetipobuonocar',				
case when isnull(CAR.NUMERO_DOCUMENTO,0) <> 0 then CAR.ESERCIZIO  else null End AS 'annobuonocar', 
case when isnull(CAR.NUMERO_DOCUMENTO,0) <> 0 then CAR.NUMERO_DOCUMENTO else null end as 'numbuonocar', 

SUBSTRING(CAR.RESPONSABILE,1,150) AS 'resp',						-->Responsabile
--rtrim(ltrim(CAR.UBICAZIONE)) AS 'codeubic_cancellato',										-->Codice ubicazione
rtrim(ltrim(U.chiave_ubicazione)) AS 'codeubic',										-->Codice ubicazione

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
LEFT OUTER JOIN CARICO_SCARICO_INVENT_DETT SCAR
	ON SCAR.ID_INVENTARIO = CAR.ID_INVENTARIO 
	and SCAR.N_INVENTARIO_DA = CAR.N_INVENTARIO_DA 
	and SCAR.PROGRESSIVO = CAR.PROGRESSIVO
	AND SCAR.TIPO_DOCUMENTO = 'S'
	AND isnull(SCAR.scarico_effettivo,0)= isnull(CAR.VALORE_UNITARIO * CAR.QUANTITA,0)  --non associa gli scarichi PARZIALI
LEFT OUTER JOIN UBICAZIONE U
	ON U.chiave_ubicazione = CAR.UBICAZIONE
LEFT OUTER JOIN lookup_anagrafica LKA
	ON LKA.codice = CAR.codice_fornitore
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

--EXEC exp_cespiti NULL --'A.AMMCE'		--'A.DIPEG'
-- setuser 'amm'
--	amministrazione;10;exec [GIOVE2-PC\SQL2008,1435].[TEST].[DBO].exp_cespiti null
------------------------------------------------------------------------------------------------------------------------------------------------------------