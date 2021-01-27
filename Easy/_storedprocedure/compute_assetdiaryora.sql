
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


IF exists (select * from dbo.sysobjects where id = object_id(N'[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure compute_assetdiaryora
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE compute_assetdiaryora
(
	@ayear int, 
	@mese int
)
as begin 
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int)
	--sommeore : indica quante ore è stato usato il bene nel mese indicato @mese
	insert into #oremesicespite(sommeore, mese, idasset, idpiece )
	select	sum(DATEDIFF(hour, ADETT.start, ADETT.stop)) as SommaOreDx,
			month(ADETT.start),
			AD.idasset, 
			AD.idpiece--, AD.idprogetto
	 from assetdiary AD 
	join  assetdiaryora ADETT 
		on AD.idassetdiary = ADETT.idassetdiary
	join asset A 
		on AD.idasset = A.idasset and AD.idpiece = A.idpiece
	where month(ADETT.start) = @mese 
		and year (ADETT.start) = @ayear		
		-- Vanno considerati solo i cespiti che hanno una class. inventariale associata ad un Tipo costo
		and exists (select * from  assetacquire	
				JOIN inventorytree 		ON inventorytree.idinv = assetacquire.idinv
				join inventorytreelink  on  inventorytreelink.idchild = assetacquire.idinv
				join progettotipocostoinventorytree on progettotipocostoinventorytree.idinv = inventorytreelink.idparent
				where assetacquire.nassetacquire = A.nassetacquire
			)
	group by month(ADETT.start), AD.idasset, AD.idpiece--, AD.idprogetto
	
	-- Per ogni cespite che calcola l'ammortamento annuo e poi farà diviso 12
	DECLARE @dec_31 datetime
	SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
	declare @assetvalue_to_date decimal(19,2)
	declare @actualvalue_to_date decimal(19,2)

	DECLARE @idasset int
	DECLARE @idpiece int
	create table #ammortamenti(importo decimal(19,2), idasset int, idpiece int)
	
	DECLARE amt_crs1 INSENSITIVE CURSOR FOR
	SELECT 
		idasset, idpiece
	FROM #oremesicespite
	FOR READ ONLY
	OPEN amt_crs1
	
	FETCH NEXT FROM amt_crs1 INTO @idasset, @idpiece
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		if (@assetvalue_to_date>0)
		begin
			-- in questa tebella metterà tutti i valori dell'Ammortamento, così dopo potrà fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
			insert into #ammortamenti(importo, idasset, idpiece)
			values(@actualvalue_to_date, @idasset, @idpiece) 
		end
	
		FETCH NEXT FROM amt_crs1 INTO  @idasset, @idpiece
		END

	DEALLOCATE amt_crs1
	
	--Calcola il valore da scrivere  in amount di assetdiaryora come:
	-- (ore dell'i-esima riga di assetdiaryora / Somma delle ore di quell'asset) * Ammortamento cespite
	select case when isnull(AMM.importo,0)>0
			then CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
									* ( isnull(AMM.importo,1)/12) 
			else  CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
			end	as amount ,
	ADETT.idassetdiary, ADETT.idassetdiaryora
	from assetdiary A 
	join  assetdiaryora ADETT 
		on A.idassetdiary = ADETT.idassetdiary
	join #oremesicespite O
		on A.idasset = O.idasset and A.idpiece = O.idpiece
	LEFT OUTER join #ammortamenti AMM
		on AMM.idasset = O.idasset and AMM.idpiece = O.idpiece
	where O.sommeore<>0 and O.mese = month(ADETT.start)
	order by ADETT.idassetdiary, ADETT.idassetdiaryora

	drop table #oremesicespite

END 

 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- exec compute_assetdiaryora 2020,7

