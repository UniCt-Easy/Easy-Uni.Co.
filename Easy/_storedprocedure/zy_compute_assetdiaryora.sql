
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


--[DBO]--
-- CREAZIONE PROCEDURE [amministrazione].[compute_assetdiaryora]
IF EXISTS (select * from sysobjects where id = object_id(N'[amministrazione].[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [amministrazione].[compute_assetdiaryora]
GO
CREATE PROCEDURE [amministrazione].[compute_assetdiaryora] 
(
	@max_ayear int, 
	@max_mese int,
	@idprogetto int
)
as begin 
--185.56.8.51,5839
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int, ayear int)
	--sommeore : indica quante ore è stato usato il bene nel mese indicato @max_mese

	;WITH curr_asset (idassetdiary, idpiece) as
	(
	select idassetdiary, idpiece 
	from 	assetdiary
	where idprogetto = @idprogetto
	group by idassetdiary, idpiece 
	)
	insert into #oremesicespite(sommeore, idasset, idpiece , ayear, mese)
	select	sum(DATEDIFF(hour, ADETT.start, ADETT.stop)) as SommaOreDx,
			AD.idasset, 
			AD.idpiece, --, AD.idprogetto
			year(ADETT.start), month(ADETT.start)
	 from assetdiary AD 
	join  assetdiaryora ADETT 
		on AD.idassetdiary = ADETT.idassetdiary
	join asset A 
		on AD.idasset = A.idasset and AD.idpiece = A.idpiece
	join curr_asset CA
		on CA.idassetdiary = A.idasset and CA.idpiece = A.idpiece
		where month(ADETT.start) <= @max_mese 
		and year (ADETT.start) <= @max_ayear		
		-- Vanno considerati solo i cespiti che hanno una class. inventariale associata ad un Tipo costo
		and exists (select * from  assetacquire	
				JOIN inventorytree 		ON inventorytree.idinv = assetacquire.idinv
				join inventorytreelink  on  inventorytreelink.idchild = assetacquire.idinv
				join progettotipocostoinventorytree on progettotipocostoinventorytree.idinv = inventorytreelink.idparent
				where assetacquire.nassetacquire = A.nassetacquire
			)
	group by year(ADETT.start),month(ADETT.start), AD.idasset, AD.idpiece --, AD.idprogetto
	
	-- Per ogni cespite calcola l'ammortamento annuo e poi farà diviso 12
	DECLARE @dec_31 datetime
	declare @assetvalue_to_date decimal(19,2)
	declare @actualvalue_to_date decimal(19,2)

	DECLARE @idasset int
	DECLARE @idpiece int
	DECLARE @ayear int
	
	create table #ammortamenti(importo decimal(19,2), idasset int, idpiece int, ayear int)
	
	DECLARE amt_crs1 INSENSITIVE CURSOR FOR
	SELECT 
		idasset, idpiece, ayear
	FROM #oremesicespite
	FOR READ ONLY
	OPEN amt_crs1
	
	FETCH NEXT FROM amt_crs1 INTO @idasset, @idpiece, @ayear
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		if (@assetvalue_to_date>0)
		begin
			-- in questa tebella metterà tutti i valori dell'Ammortamento, così dopo potrà fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
			insert into #ammortamenti(importo, idasset, idpiece, ayear)
			values(@actualvalue_to_date, @idasset, @idpiece, @ayear) 
		end
	
		FETCH NEXT FROM amt_crs1 INTO  @idasset, @idpiece, @ayear
		END

	DEALLOCATE amt_crs1
	
	--Calcola il valore da scrivere in amount di assetdiaryora come:
	-- (ore dell'i-esima riga di assetdiaryora / Somma delle ore di quell'asset) * Ammortamento cespite
	select case when isnull(AMM.importo,0)>0
			then CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
									* ( isnull(AMM.importo,1)/12) 
			else  CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
			end	as amount ,
	ADETT.idassetdiary, ADETT.idassetdiaryora
	from assetdiary A 
	join  assetdiaryora ADETT 
		on A.idassetdiary = ADETT.idassetdiary and A.idprogetto = @idprogetto --> deve valorizzare solo le righe del progetto specificato.
	join #oremesicespite O
		on A.idasset = O.idasset and A.idpiece = O.idpiece
	LEFT OUTER join #ammortamenti AMM
		on AMM.idasset = O.idasset and AMM.idpiece = O.idpiece and AMM.ayear = O.ayear
	where O.sommeore<>0 and O.mese = month(ADETT.start) and O.ayear = year(ADETT.start)
	order by ADETT.idassetdiary, ADETT.idassetdiaryora

	drop table #oremesicespite

END
GO 
