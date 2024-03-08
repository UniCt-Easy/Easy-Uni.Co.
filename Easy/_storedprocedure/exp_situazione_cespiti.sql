
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazione_cespiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazione_cespiti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [exp_situazione_cespiti]

(
	@idinventory int,
	@startinv int,
	@lastinv int,
	@ayear int
)

AS BEGIN

IF @startinv IS NULL 
	IF @idinventory IS NOT NULL
		SELECT @startinv = MIN(startnumber) FROM assetacquire WHERE idinventory = @idinventory
	ELSE
		SELECT @startinv = min(startnumber) FROM assetacquire

IF @lastinv is null 
	IF @idinventory IS not null
		SELECT @lastinv = MAX(startnumber) FROM assetacquire WHERE idinventory = @idinventory
	ELSE
		SELECT @lastinv = MAX(startnumber) FROM assetacquire

DECLARE @idasset int 
DECLARE	@idpiece int
DECLARE	@nassetacquire int
DECLARE	@ninventory  int
DECLARE	@yassetload int
DECLARE @flagiva varchar (1)
DECLARE @flagdiscount int

CREATE TABLE #assettotal 
( 
	idasset int, 
	idpiece int, 
	nassetacquire int,
	description varchar(150),	
	ninventory int,
	startnumber int, 
	idinventory int, 
	yassetload int,
	idupb varchar(36)
)

INSERT INTO #assettotal
(
	idasset, 
	idpiece, 
	nassetacquire, 	
	description,
	ninventory, 
	startnumber,
	idinventory, 
	yassetload,
	idupb
)
SELECT A.idasset,A.idpiece,A.nassetacquire,AC.description,A.ninventory,AC.startnumber,AC.idinventory,AL.yassetload, AC.idupb
FROM asset A 
	JOIN assetacquire AC
		ON A.nassetacquire = AC.nassetacquire
	LEFT OUTER JOIN assetload AL
		ON AC.idassetload = AL.idassetload
		AND AL.yassetload = @ayear	-- mi valorizza solo gli esercizio appartenenti al parametro esercizio, qualora esso sia valorizzato
WHERE AC.startnumber between @startinv AND @lastinv
AND ( AC.idinventory = @idinventory OR  @idinventory IS NULL)

-- filtra i dati da elaborare in base alla configurazione dei parametri

DELETE FROM #assettotal WHERE #assettotal.idpiece >1
	AND #assettotal.idasset NOT IN (SELECT idasset from #assettotal ATL where idpiece = 1)

IF @ayear IS NOT NULL
	DELETE FROM #assettotal WHERE yassetload IS NULL
IF @idinventory IS NOT NULL
	DELETE FROM #assettotal WHERE idinventory != @idinventory

SELECT  #assettotal.idasset AS 'Num. Cespite', 
	CASE #assettotal.idpiece WHEN 1 THEN 'Cespite Principale' ELSE 'Accessorio n.' + convert(varchar(3),#assettotal.idpiece - 1) END AS 'Modalità Cespite' , 
	#assettotal.idpiece,
	#assettotal.nassetacquire AS 'Numero Carico',
	#assettotal.description AS 'Descrizione',	
	CASE #assettotal.idpiece WHEN 1 THEN ninventory ELSE #assettotal.startnumber END AS 'Numero Inventario',
	#assettotal.startnumber AS 'Num. Invent. Iniziale', 
	inventory.description AS 'Tipo Inventario', 
	ISNULL(assetview_current.start,0) AS 'Valore Iniziale',
	ISNULL(revals,0) AS 'Ammortamenti e rival. ufficiali',
	ISNULL(subtractions,0) AS 'Scarichi di accessori posseduti',
	ISNULL(currentvalue,0) AS 'Valore Attuale' ,
	upb.codeupb as 'UPB'
	FROM #assettotal
	JOIN inventory
		ON #assettotal.idinventory = inventory.idinventory
	JOIN assetview_current 
		ON assetview_current.idasset = #assettotal.idasset
		AND assetview_current.idpiece = #assettotal.idpiece
	LEFT OUTER JOIN upb 
		ON #assettotal.idupb = upb.idupb
		
ORDER BY
	#assettotal.idinventory, #assettotal.idasset, #assettotal.idpiece

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
