
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_rendicontomagazzino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_rendicontomagazzino]
GO

--  Rendiconto di fine esercizio che riporti per ogni articolo la consistenza iniziale, i carichi, gli scarichi e la consistenza finale.

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE rpt_rendicontomagazzino(
	@idstore int,
	@idlist int,
	@start datetime,
	@stop datetime
)

AS BEGIN
-- exec rpt_rendicontomagazzino NULL, 646, {ts '2015-06-15 00:00:00'}, {ts '2015-06-20 00:00:00'}
--exec rpt_rendicontomagazzino NULL, 72, {ts '2011-06-15 00:00:00'}, {ts '2011-06-20 00:00:00'}
CREATE TABLE #INVENTARIO(
	idlist int,
	idstore int,
	consistenzainiziale decimal(19,2),
	carico decimal(19,2),
	scarico decimal(19,2),
	data datetime,
	descScarico varchar(150),
	idmankind varchar(20),
	nman int,
	yman int,
	man_idgroup int,
	idman int,
	sorting1 varchar(200),
	mandateregistry varchar(100),
	invoincedoc varchar(35),
	invoincedocdate smalldatetime,
	yinv smallint,
	ninv int,
	invoicekind varchar(50)
)

--  Rendiconto di fine esercizio che riporti per ogni articolo la consistenza iniziale, i carichi, gli scarichi e la consistenza finale.

-- La CONSISTENZA INIZIALE è data da tutti i carichi fatti alla data Inizio meno tutti gli scarichi fatti alla data Inizio
INSERT INTO #INVENTARIO(
	idlist,
	idstore ,
	consistenzainiziale
)

SELECT
	L.idlist,
	S.idstore,
	SUM( ISNULL(S.number,0)) 
FROM list L
JOIN stock S				ON L.idlist = S.idlist
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
	AND S.adate < @start
GROUP BY S.idstore, L.idlist


update #INVENTARIO set consistenzainiziale = consistenzainiziale - 
	(SELECT SUM(ISNULL(storeunloaddetail.number,0)) 
			FROM list L
			JOIN stock S						ON L.idlist = S.idlist
			JOIN storeunloaddetail		    	ON  storeunloaddetail.idstock = S.idstock
			JOIN storeunload	ON storeunload.idstoreunload = storeunloaddetail.idstoreunload 
			WHERE ( S.idstore = #INVENTARIO.idstore )
				AND ( L.idlist = #INVENTARIO.idlist)
				AND  storeunload.adate < @start
	)



-- Inseriamo i Carichi
INSERT INTO #INVENTARIO(
	idlist ,
	idstore ,
	carico, 
	data,
	idmankind,
	nman,
	yman,
	man_idgroup,
	mandateregistry,
	invoincedoc,invoincedocdate,yinv, ninv,invoicekind
)
SELECT
	L.idlist, -- codice articolo
	S.idstore,
	S.number,
	S.adate,
	S.idmankind,
	S.nman,
	S.yman,
	S.man_idgroup,
	R.title,
	I.doc,I.docdate,I.yinv, I.ninv,IK.description
FROM list L
JOIN stock S
	ON L.idlist = S.idlist
LEFT OUTER JOIN mandate M
	on M.idmankind = S.idmankind and M.yman = S.yman and M.nman = S.nman
LEFT OUTER JOIN registry R
	on M.idreg = R.idreg
LEFT OUTER JOIN invoice I
	on I.idinvkind = S.idinvkind and I.yinv = S.yinv and I.ninv = S.ninv
LEFT OUTER JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
	AND S.adate between @start AND @stop


declare @idsortingkind1 int
select  @idsortingkind1 = idsortingkind1 from config where ayear = year(@start)
-- Inseriamo gli scarichi
INSERT INTO #INVENTARIO(
	idlist ,
	idstore ,
	scarico, 
	data,
	descScarico,
	idman,
	sorting1
)
SELECT
	L.idlist, -- codice articolo
	S.idstore,
	SUM(UD.number),
	U.adate,
	U.description,
	UD.idman,
	S1.description
FROM list L
JOIN stock S					ON L.idlist = S.idlist
jOIN storeunloaddetail UD		ON UD.idstock = S.idstock 
JOIN storeunload U				ON U.idstoreunload = UD.idstoreunload
LEFT OUTER JOIN sorting S1		on S1.idsor = UD.idsor1 and S1.idsorkind = @idsortingkind1
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
	AND U.adate between @start AND @stop
GROUP BY S.idstore, L.idlist,U.adate, U.description,UD.idman,S1.description


SELECT
	L.intcode, -- codice articolo
	L.description as 'list', --- descrizione  articolo
	U.description as 'unit', -- unita di carico/scarico
	M.description as 'store',
	ISNULL(I.consistenzainiziale,0) as 'consistenzainiziale',
	ISNULL(I.carico,0) as 'carico',
	ISNULL(I.scarico,0) as 'scarico',
	I.data ,	-- Data Arrivo / Data Scarico
	I.descScarico,
	MK.description as 'mandatekind',
	I.nman,
	I.yman,
	mandateregistry,
	manager.title as 'manager',
	I.man_idgroup,
	sorting1 as 'strutturascarico',
	invoincedoc,
	invoincedocdate,
	yinv,
	ninv,
	invoicekind 
FROM #INVENTARIO I
JOIN list L						ON L.idlist =  I.idlist
JOIN store M					ON I.idstore = M.idstore
JOIN unit U						ON U.idunit = L.idunit
LEFT OUTER JOIN mandatekind MK	ON MK.idmankind = I.idmankind	
LEFT OUTER JOIN manager			ON manager.idman = I.idman

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






