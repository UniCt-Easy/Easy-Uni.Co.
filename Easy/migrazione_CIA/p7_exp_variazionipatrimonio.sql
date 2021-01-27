
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_variazionipatrimonio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_variazionipatrimonio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_variazionipatrimonio]
( @bilancio varchar(50)  = null 
)
AS BEGIN

DECLARE @DATI TABLE(
	esercizio int,
	classinv varchar(10),
	id_inventario varchar(10),
	importo decimal(19,2)
)




INSERT INTO @DATI(	esercizio, classinv, id_inventario, importo)
	SELECT  
		S.esercizio ,
		S.CHIAVE_COMPLETA_CATEGORIA,
		S.id_inventario,
	CONVERT(decimal(19,2),
			CASE WHEN S.esercizio>=2002 THEN isnull(sum(S.valore_iniziale),0)
 				 ELSE ROUND(sum(S.valore_iniziale/1936.27),2) 
			END) 
	FROM  CARICO_SCARICO_INVENT_VIEW S			
	GROUP BY S.id_inventario,S.CHIAVE_COMPLETA_CATEGORIA,S.esercizio

	


--select * from @dati where id_inventario='I001' and  ESERCIZIO =2007 and classinv  like '02%'


SELECT 
    'C' as 'tipo',
    D.ESERCIZIO as 'annovar',
	+
	DENSE_RANK() OVER(PARTITION BY   D.ESERCIZIO
     order by D.ESERCIZIO,I.codiceente,I.codiceinventario
	 ) as 'numvar',
    NULL AS 'provv',
    NULL AS 'dataprovv',
    NULL AS 'numprovv',
    'Variazione consistenza iniziale' as 'descr',
	CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), D.esercizio), 105) as 'data',
	I.codiceente as codeinvagency,--> Codice Ente Inventariale
	substring(I.descrizioneente,1,150) as descrinvagency ,--> Descrizione Ente Inventariale
	I.codiceinventario as 'codeinv',--> Codice Inventario
	substring(rtrim(ltrim(I.descrizioneinventario)),1,50) as 'descrinv',--Descrizione Inventario
	I.tipo_LIB_ORD  as codeinvkind,				--> Codice Tipo Inventario
	CASE WHEN	I.tipo_LIB_ORD ='LIB' then 'Materiale bibliografico'
		WHEN	I.tipo_LIB_ORD ='ORD' then 'Inventario Ordinario'
		else 'ALTRO'
	end as descrinvkind, --> Descr. Tipo Inventario
     D.classinv as 'codeclass',
     '.' as 'descrdet',
     isnull(sum(D.importo),0) as 'importo',
     null as 'codicecausalecar',
     null as 'descrcausalecar'
 FROM @DATI D 
 JOIN lookup_inventario I 
		ON D.ID_INVENTARIO = I.id_inventario

GROUP BY D.ESERCIZIO, classinv, 
	I.codiceente,substring(I.descrizioneente,1,150),
	I.codiceinventario,	substring(rtrim(ltrim(I.descrizioneinventario)),1,50),
	I.tipo_LIB_ORD
	
order by D.esercizio, I.codiceinventario

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

-- EXEC exp_variazionipatrimonio null --'A.AMMCE'		--'A.DIPEG'
-- SELECT min(esercizio) from SITUAZIONE_PATRIMONIALE_INI
------------------------------------------------------------------------------------------------------------------------------------------------------------
/*

SELECT 
		'C' as opkind,
		D.esercizio,
		AV.idpiece,
		D.progressivo,
		isnull(D.CATEGORIA,'') + isnull('.'+ D.GRUPPO,'') + isnull('.'+D.SOTTO_GRUPPO,''),
		D.ID_INVENTARIO,
		CONVERT(decimal(19,2),
		CASE WHEN D.ESERCIZIO>=2002 THEN isnull(D.VALORE_UNITARIO * D.QUANTITA,0)
 				ELSE ROUND(D.VALORE_UNITARIO * D.QUANTITA/1936.27,2) 
		END) +
		CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN isnull(D.importo_iva ,0)
					ELSE ROUND(isnull(D.importo_iva ,0)/1936.27,2) END) as 'cia',
		AV.cost as 'easy'
			

		FROM CARICO_SCARICO_INVENT_DETT D

		join Unina2_Easy.amministrazione.assetview AV
			on AV.codeinventory='I001' and AV.ninventory= D.N_INVENTARIO_DA
			and AV.idpiece=D.PROGRESSIVO
	WHERE	D.esercizio < 2007
			AND D.TIPO_DOCUMENTO ='C'
			AND ID_INVENTARIO='I001'
			AND D.CATEGORIA='02'
		and D.VALORE_UNITARIO * D.QUANTITA + D.importo_iva <> AV.cost 
	

	select * from CARICO_SCARICO_INVENT_DETT D where D.PROGRESSIVO>0
		AND D.TIPO_DOCUMENTO ='C'
			AND ID_INVENTARIO='I001'
			AND D.CATEGORIA='02'
			AND D.esercizio=2006


	
SELECT  AV.ninventory,
		AV.idpiece,
		CONVERT(decimal(19,2),
		CASE WHEN D.ESERCIZIO>=2002 THEN isnull(D.VALORE_UNITARIO * D.QUANTITA,0)
 				ELSE ROUND(D.VALORE_UNITARIO * D.QUANTITA/1936.27,2) 
		END) +
		CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN isnull(D.importo_iva ,0)
					ELSE ROUND(isnull(D.importo_iva ,0)/1936.27,2) END) as 'cia',
		AV.cost as 'easy',
		AV.yassetload

		FROM   CARICO_SCARICO_INVENT_DETT D

		left outer join Unina2_Easy.amministrazione.assetview AV 
			on AV.codeinventory='I001' and AV.ninventory= D.N_INVENTARIO_DA
			and AV.idpiece=D.PROGRESSIVO+1
			AND AV.codeinv='02.01.01'
	WHERE	D.esercizio < 2007
			AND D.TIPO_DOCUMENTO ='C'
			AND ID_INVENTARIO='I001'
			AND D.CATEGORIA='02' AND D.GRUPPO='01' and d.SOTTO_GRUPPO='01'


			
SELECT 
		AV.idpiece,AV.yassetload, AV.yassetunload,
		CONVERT(decimal(19,2),
		CASE WHEN D.ESERCIZIO>=2002 THEN isnull(D.VALORE_UNITARIO * D.QUANTITA,0)
 				ELSE ROUND(D.VALORE_UNITARIO * D.QUANTITA/1936.27,2) 
		END) +
		CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN isnull(D.importo_iva ,0)
					ELSE ROUND(isnull(D.importo_iva ,0)/1936.27,2) END) as 'cia',
		AV.cost as 'easy'
			

		FROM  Unina2_Easy.amministrazione.assetview AV 

		left outer join CARICO_SCARICO_INVENT_DETT D
			on AV.codeinventory='I001' and AV.ninventory= D.N_INVENTARIO_DA
			and AV.idpiece=D.PROGRESSIVO+1
	WHERE	D.esercizio  is null and AV.codeinventory='I001'


select sum(AV.cost) from  Unina2_Easy.amministrazione.assetview AV   -- in easy + 173750.91, sembra manchi qualcosa (1152.00) rispetto a CIA
where AV.yassetload=2006 and AV.codeinv='02.01.01' and AV.codeinventory='I001'  --  = 173750.91

select sum(VALORE_UNITARIO) from CARICO_SCARICO_INVENT_DETT D
		where 	D.esercizio < 2007
				AND D.TIPO_DOCUMENTO ='C'
				AND ID_INVENTARIO='I001'
				AND D.CATEGORIA='02' AND D.GRUPPO='01' and d.SOTTO_GRUPPO='01'  --= 174902.91


				
select count(* ) from CARICO_SCARICO_INVENT_DETT D
		where 	D.esercizio < 2007
				AND D.TIPO_DOCUMENTO ='C'
				AND ID_INVENTARIO='I001'
				AND D.CATEGORIA='02' AND D.GRUPPO='01' and d.SOTTO_GRUPPO='01' and D.NUMERO_DOCUMENTO<>0

select count(*) from  Unina2_Easy.amministrazione.assetview AV   -- in easy + 173750.91, sembra manchi qualcosa (1152.00) rispetto a CIA
where AV.yassetload<2007 and AV.codeinv='02.01.01' and AV.codeinventory='I001'  --  = 173750.91


cespite n. 8608, idpiece 1 , valore cia = 1152, valore easy=1152, in easy non risulta caricato (yassetload=null)

select * from Unina2_Easy.amministrazione.assetview where ninventory=8608 and codeinventory='I001'

*/
