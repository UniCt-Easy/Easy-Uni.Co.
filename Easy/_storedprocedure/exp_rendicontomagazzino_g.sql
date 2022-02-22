
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_rendicontomagazzino_g]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_rendicontomagazzino_g]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [exp_rendicontomagazzino_g](
	@idstore int,
	@idlist int,
	@start datetime,
	@stop datetime,
	@class_merc varchar(36),
	@carico_scarico varchar
)

AS BEGIN
/*MODIFICATA DA GIANNI PER BARI A PARTIRE DALLA STAMPA DEL RENDICONTO DEL MAGAZZINO*/

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
	sorting2 varchar(200),
	mandateregistry varchar(100),
	invoincedoc varchar(35),
	invoincedocdate smalldatetime,
	yinv smallint,
	ninv int,
	invoicekind varchar(50),
	giacenza decimal(19,2)
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
	SUM( ISNULL(S.number,0) - ISNULL(storeunloaddetail.number,0)) 
FROM list L
JOIN stock S
	ON L.idlist = S.idlist
LEFT OUTER JOIN storeunloaddetail
	ON  storeunloaddetail.idstock = S.idstock
LEFT OUTER JOIN storeunload
	ON storeunload.idstoreunload = storeunloaddetail.idstoreunload AND storeunload.adate < @start
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
	AND S.adate < @start
GROUP BY S.idstore, L.idlist

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
	invoincedoc,invoincedocdate,yinv, ninv,invoicekind,
	giacenza
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
	I.doc,I.docdate,I.yinv, I.ninv,IK.description,
	S.number - (SELECT ISNULL(SUM(storeunloaddetail.number),0) 
                    FROM storeunloaddetail 
					JOIN storeunload
						ON storeunload.idstoreunload = storeunloaddetail.idstoreunload
					WHERE storeunloaddetail.idstock = S.idstock and storeunload.adate <= S.adate) -- 'Giacenza'
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


declare @idsortingkind2 int
select  @idsortingkind2 = idsortingkind2 from config where ayear = year(@start)
-- Inseriamo gli scarichi
INSERT INTO #INVENTARIO(
	idlist ,
	idstore ,
	scarico, 
	data,
	descScarico,
	idman,
	sorting2,
	giacenza
)
SELECT
	L.idlist, -- codice articolo
	S.idstore,
	SUM(UD.number),
	U.adate,
	U.description,
	UD.idman,
	S1.description,
	S.number - (SELECT ISNULL(SUM(storeunloaddetail.number),0) 
                    FROM storeunloaddetail 
					JOIN storeunload
						ON storeunload.idstoreunload = storeunloaddetail.idstoreunload
					WHERE storeunloaddetail.idstock = S.idstock and storeunload.adate <= U.adate) -- 'Giacenza'
FROM list L
JOIN stock S
	ON L.idlist = S.idlist
jOIN storeunloaddetail UD
	ON UD.idstock = S.idstock 
JOIN storeunload U
	ON U.idstoreunload = UD.idstoreunload
LEFT OUTER JOIN sorting S1
	on S1.idsor = UD.idsor2 and S1.idsorkind = @idsortingkind2
WHERE ( S.idstore = @idstore OR @idstore IS NULL )
	AND ( L.idlist = @idlist OR @idlist IS NULL )
	AND S.number >0
	AND U.adate between @start AND @stop
GROUP BY S.idstore, L.idlist,U.adate, U.description,UD.idman,S1.description,S.number,S.idstock

IF(@carico_scarico not in ('U','I') or @carico_scarico is null)   /*ESPORTA SIA LE ENTRATE CHE LE USCITE*/
	BEGIN
		SELECT
			CASE
				when I.carico is null then 'Uscita'
				when I.scarico is null then 'Ingresso'
			End [Tipologia],		
			L.intcode [Codice], -- codice articolo
			L.description as [Articolo], --- descrizione  articolo
			LV.listclass [Class. Merceologica],
			CASE
				when I.carico is null then isnull(sorting2,'DA INDICARE') -- Struttura
				when I.scarico is null then mandateregistry --Fornitore 
			End [Struttura/Fornitore],
			CASE
				when I.carico is null then isnull(CAST(I.scarico as INT), 0)
				when I.scarico is null then isnull(CAST(I.carico as INT), 0) 
			End [Quantità],
			I.data [Data],	-- Data Arrivo / Data Scarico
			I.descScarico [Richiesta],
			isnull(CAST(I.giacenza as INT), 0) [Giacenza],
			MK.description + '/'+ CAST(I.yman as varchar) + '/' + CAST(I.nman as varchar) + '/'+ CAST(I.man_idgroup as varchar) [Ordine],
			--manager.title [Responsabile],
			invoincedoc [Fatt. fornitore],
			invoincedocdate [Data fatt.],
			invoicekind + '/' + cast(yinv as varchar) + '/' + cast(ninv as varchar) [Reg. Fattura Easy]
		FROM #INVENTARIO I
		JOIN list L
			ON L.idlist =  I.idlist
		JOIN listview LV
			ON LV.idlist =  L.idlist
		JOIN store M
			ON I.idstore = M.idstore
		JOIN unit U
			ON U.idunit = L.idunit
		LEFT OUTER JOIN mandatekind MK
			ON MK.idmankind = I.idmankind	
		LEFT OUTER JOIN manager 
			ON manager.idman = I.idman
		WHERE ((LV.idlistclass = @class_merc) OR (@class_merc is null))
		AND ( I.carico > 0 OR  I.scarico > 0 )
		Order by [Data], [Richiesta]	
	END

ELSE IF(@carico_scarico = 'U')   /*ESPORTA SOLO LE USCITE*/
	BEGIN
	
			SELECT
			CASE
				when I.carico is null then 'Uscita'
				when I.scarico is null then 'Ingresso'
			End [Tipologia],		
			L.intcode [Codice], -- codice articolo
			L.description as [Articolo], --- descrizione  articolo
			LV.listclass [Class. Merceologica],
			CASE
				when I.carico is null then isnull(sorting2,'DA INDICARE') -- Struttura
				when I.scarico is null then mandateregistry --Fornitore 
			End [Struttura],
			CASE
				when I.carico is null then isnull(CAST(I.scarico as INT), 0)
				when I.scarico is null then isnull(CAST(I.carico as INT), 0) 
			End [Quantità],
			I.data [Data],	-- Data Arrivo / Data Scarico
			I.descScarico [Richiesta],
			isnull(CAST(I.giacenza as INT), 0) [Giacenza]
			--MK.description + '/'+ CAST(I.yman as varchar) + '/' + CAST(I.nman as varchar) + '/'+ CAST(I.man_idgroup as varchar) [Ordine],
			--manager.title [Responsabile],
			--invoincedoc [Fatt. fornitore],
			--invoincedocdate [Data fatt.],
			--invoicekind + '/' + cast(yinv as varchar) + '/' + cast(ninv as varchar) [Reg. Fattura Easy]
		FROM #INVENTARIO I
		JOIN list L
			ON L.idlist =  I.idlist
		JOIN listview LV
			ON LV.idlist =  L.idlist
		JOIN store M
			ON I.idstore = M.idstore
		JOIN unit U
			ON U.idunit = L.idunit
		LEFT OUTER JOIN mandatekind MK
			ON MK.idmankind = I.idmankind	
		LEFT OUTER JOIN manager 
			ON manager.idman = I.idman
		WHERE ((LV.idlistclass = @class_merc) OR (@class_merc is null))
		AND I.carico is null
		AND I.scarico > 0
		Order by [Data], [Richiesta]	
	END

ELSE IF(@carico_scarico = 'I')   /*ESPORTA SOLO I CARICHI*/
	BEGIN
	
				SELECT
			CASE
				when I.carico is null then 'Uscita'
				when I.scarico is null then 'Ingresso'
			End [Tipologia],		
			L.intcode [Codice], -- codice articolo
			L.description as [Articolo], --- descrizione  articolo
			LV.listclass [Class. Merceologica],
			CASE
				when I.carico is null then isnull(sorting2,'DA INDICARE') -- Struttura
				when I.scarico is null then mandateregistry --Fornitore 
			End [Fornitore],
			CASE
				when I.carico is null then isnull(CAST(I.scarico as INT), 0)
				when I.scarico is null then isnull(CAST(I.carico as INT), 0) 
			End [Quantità],
			I.data [Data],	-- Data Arrivo / Data Scarico
			--I.descScarico [Richiesta],
			MK.description + '/'+ CAST(I.yman as varchar) + '/' + CAST(I.nman as varchar) + '/'+ CAST(I.man_idgroup as varchar) [Ordine],
			--manager.title [Responsabile],
			invoincedoc [Fatt. fornitore],
			invoincedocdate [Data fatt.],
			invoicekind + '/' + cast(yinv as varchar) + '/' + cast(ninv as varchar) [Reg. Fattura Easy]
		FROM #INVENTARIO I
		JOIN list L
			ON L.idlist =  I.idlist
		JOIN listview LV
			ON LV.idlist =  L.idlist
		JOIN store M
			ON I.idstore = M.idstore
		JOIN unit U
			ON U.idunit = L.idunit
		LEFT OUTER JOIN mandatekind MK
			ON MK.idmankind = I.idmankind	
		LEFT OUTER JOIN manager 
			ON manager.idman = I.idman
		WHERE ((LV.idlistclass = @class_merc) OR (@class_merc is null))
		AND I.scarico is null 
		AND I.carico > 0
		Order by [Data]	
	END

END



GO
