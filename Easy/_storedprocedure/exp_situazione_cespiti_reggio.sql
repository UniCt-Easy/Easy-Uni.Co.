
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazione_cespiti_reggio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazione_cespiti_reggio]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [exp_situazione_cespiti_reggio](
	@idinventory int,
	@ayear int  -- Anno in cui deve essere effettuato il calcolo
)

AS BEGIN
DECLARE @N int

DECLARE @codelen1 int
DECLARE @codelen2 int
DECLARE @codelen3 int


SELECT @codelen1 = codelen FROM inventorysortinglevel WHERE nlevel = 1
SELECT @codelen2 = codelen FROM inventorysortinglevel WHERE nlevel = 2
SELECT @codelen3 = codelen FROM inventorysortinglevel WHERE nlevel = 3

DECLARE @idasset int 
DECLARE	@idpiece int
DECLARE	@nassetacquire int
DECLARE	@ninventory  int
DECLARE	@yassetload int
DECLARE @flagiva varchar (1)
DECLARE @flagdiscount int

SET @flagiva ='S'

DECLARE @flagivaapplying float
IF(@flagiva)='S'
BEGIN
	SET @flagivaapplying = 1
END
ELSE 
BEGIN
	SET @flagivaapplying = 0
END


CREATE TABLE #assettotal 
( 
	idasset int, 
	idpiece int, 
	nassetacquire int,
	description varchar(150),	
	ninventory int,
	idinventory int, 
	yassetload int,
	tipo_documento char(1),
	nassetload int,
	idinv int,
	lifestart datetime,
	idassetload int
)

INSERT INTO #assettotal
(
	idasset , 
	idpiece , 
	nassetacquire , 	
	description,
	ninventory , 
	idinventory , 
	tipo_documento,
	yassetload ,
	nassetload,
	idinv,
	lifestart,
	idassetload
)
SELECT A.idasset,A.idpiece,A.nassetacquire,AC.description,A.ninventory,AC.idinventory,
		CASE WHEN A.idpiece = 1 THEN 'C'
			 ELSE 'A'
		END,
	AL.yassetload,AL.nassetload,
	AC.idinv,
	a.lifestart,					
	AL.idassetload
FROM asset A 
	JOIN assetacquire AC
		ON A.nassetacquire = AC.nassetacquire
	LEFT OUTER JOIN assetload AL
		ON AC.idassetload = AL.idassetload	
	LEFT OUTER JOIN assetunload AU
		ON A.idassetunload = AU.idassetunload
WHERE 
	@idinventory is null or AC.idinventory= @idinventory 
	AND
		(	( (AC.flag & 1) = 0 and  datepart(year,AC.adate)<=@ayear )
			OR
			( (AC.flag & 1) <> 0 and  datepart(year,AL.ratificationdate)<=@ayear )	
		)
	AND 
		(  (A.flag & 1 <> 0) and (AU.ratificationdate IS NULL OR datepart(year,AU.ratificationdate)>@ayear ) ) -- non è scaricato

	
print 'A'
select @N = count(*)  from #assettotal
print @N
-- filtra i dati da elaborare in base alla configurazione dei parametri
--cancella gli accessori senza cespite principale (non dovrebbero esistere)
DELETE FROM #assettotal WHERE #assettotal.idpiece >1
	AND #assettotal.idasset NOT IN (SELECT ATL.idasset from #assettotal ATL where ATL.idpiece = 1)

print 'B'
select @N = count(*)  from #assettotal
print @N

SELECT  
	#assettotal.yassetload AS 'esercizio',
	inventory.codeinventory AS 'id_inventario',
	#assettotal.tipo_documento AS 'tipo documento',
	nassetload AS 'numero documento',
	#assettotal.ninventory AS 'n_inventario_da',
	#assettotal.ninventory AS 'n_inventario_a',
	fin.codefin as 'bilancio',
	upb.codeupb as 'unita_organizzativa',
	ISNULL(SUBSTRING(inventorytree.codeinv,1,@codelen1),'') as 'categoria',
	ISNULL(SUBSTRING(inventorytree.codeinv,@codelen1 + 1,@codelen2),'') as 'gruppo',
	ISNULL(SUBSTRING(inventorytree.codeinv,@codelen1 + @codelen2 + 1,@codelen3),'') as 'sotto_gruppo',
	#assettotal.description AS 'descrizione bene',
	1 AS 'quantità',
	ISNULL(AC.currentvalue,0) AS 'valore_unitario' ,
	ISNULL(AC.currentvalue,0) AS 'valore_totale' ,	
	ISNULL(AC.currentvalue,0) AS 'valore iniziale' ,
	0 AS 'delta_valore',
	'N' AS 'totalmente_scaricato',  
	datepart(yy,#assettotal.lifestart) AS 'anno_fabbricazione',
	'N' AS 'flag_bene_usato',
	'N' AS 'flag_interesse_storico'
	FROM #assettotal
		join assetview_current AC on #assettotal.idasset=AC.idasset and #assettotal.idpiece=AC.idpiece	
		JOIN inventory
			ON #assettotal.idinventory = inventory.idinventory
		JOIN inventorytree
			ON #assettotal.idinv = inventorytree.idinv
		LEFT OUTER JOIN assetloadexpense 
			ON #assettotal.idassetload = assetloadexpense.idassetload
		LEFT OUTER JOIN expenseyear 
			ON expenseyear.idexp = assetloadexpense.idexp
			and expenseyear.ayear = #assettotal.yassetload
		LEFT OUTER JOIN fin 
			ON expenseyear.idfin = fin.idfin
		LEFT OUTER JOIN upb 
			ON upb.idupb = expenseyear.idupb
	--WHERE #assettotal.currentvalue <> 0

ORDER BY #assettotal.ninventory
	
END

