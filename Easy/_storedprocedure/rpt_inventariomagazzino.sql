
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_inventariomagazzino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_inventariomagazzino]
GO

--  Per ogni ubicazione (stanza - scaffale - ripiano), l'articolo e la quantità in giacenza.

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE rpt_inventariomagazzino(
	@idstore int,
	@adate datetime
)

AS BEGIN
--	 exec rpt_inventariomagazzino null, { ts '2011-06-13 00:00:00'}

CREATE TABLE #INVENTARIO(
	intcode varchar(50), -- codice articolo
	list varchar(150), --- descrizione  articolo
	unit varchar(50), -- unita di carico/scarico
	store varchar(50),
	idstocklocation int,
	code1 varchar(50),
	code2 varchar(50),
	code3 varchar(50),
	stocklocation1 varchar(150),
	stocklocation2 varchar(150),
	stocklocation3 varchar(150),
	costounitario decimal(19,2),
	costoconfezione decimal(19,2),
	unitsforpackage int,
	Giacenza decimal(19,2)
)
INSERT INTO #INVENTARIO(
	intcode ,
	list ,
	unit ,
	store ,
	idstocklocation ,
	code1,	stocklocation1,
	code2,	stocklocation2,
	code3,	stocklocation3,
	costounitario ,
	costoconfezione,
	unitsforpackage ,
	Giacenza 
)

SELECT
	L.intcode, -- codice articolo
	L.description, --- descrizione  articolo
	U.description, -- unita di carico/scarico
	M.description,
	S.idstocklocation,
	ST1.stocklocationcode, ST1.description,
	ST2.stocklocationcode, ST2.description, 
	ST3.stocklocationcode, ST3.description,
	round(S.amount/S.number,5),-- 'costounitario',
	ROUND((S.amount/S.number)*L.unitsforpackage,2),-- 'costoconfezione',
	L.unitsforpackage,
	S.number - (SELECT ISNULL(SUM(storeunloaddetail.number),0) 
                       FROM storeunloaddetail 
					   JOIN storeunload
							ON storeunload.idstoreunload = storeunloaddetail.idstoreunload
					  WHERE storeunloaddetail.idstock = S.idstock and storeunload.adate <= @adate) -- 'Giacenza'
FROM list L
JOIN stock S
	ON L.idlist = S.idlist
JOIN unit U
	ON U.idunit = L.idunit
JOIN store M
	ON M.idstore = S.idstore	
LEFT OUTER JOIN stocklocation ST3
	ON ST3.idstocklocation = S.idstocklocation
LEFT OUTER JOIN stocklocation ST2
	ON ST2.idstocklocation = ST3.paridstocklocation
LEFT OUTER JOIN stocklocation ST1
	ON ST1.idstocklocation = ST2.paridstocklocation
WHERE ( M.idstore = @idstore OR @idstore IS NULL )
ORDER BY ST1.stocklocationcode, ST2.stocklocationcode, ST3.stocklocationcode, L.intcode

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = codelen FROM stocklocationlevel WHERE nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1

DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = codelen FROM stocklocationlevel WHERE nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1

DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = codelen FROM stocklocationlevel WHERE nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2


UPDATE #INVENTARIO SET code1 = code2, code2 = code3 WHERE code1 IS NULL
UPDATE #INVENTARIO SET code1 = code2, code2 = code3 WHERE code1 IS NULL


UPDATE #INVENTARIO SET code1 = SUBSTRING(code1, @startpos1, @lencod_lev1)
UPDATE #INVENTARIO SET code2 = SUBSTRING(code2, @startpos2, @lencod_lev2)
UPDATE #INVENTARIO SET code3 = SUBSTRING(code3, @startpos3, @lencod_lev3)


SELECT 
	intcode ,
	list ,
	unit ,
	store ,
	idstocklocation ,
	code1,	stocklocation1,
	code2,	stocklocation2,
	code3,	stocklocation3,
	costounitario ,
	costoconfezione,
	unitsforpackage ,
	Giacenza 
FROM #INVENTARIO

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

