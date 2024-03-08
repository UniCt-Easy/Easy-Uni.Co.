
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_inquadranagrafiche_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_inquadranagrafiche_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [compute_inquadranagrafiche_csa](
	@matricolastart varchar(40),
	@matricolastop varchar(40),
	@disattivariga char(1) -- Ho aggiunto questo paramentro per prudenza. Il form chimaerà la sp con parametro S, ma da sql si potrà decidere se disattivare le righe o visualizzarle e basta.
)
AS BEGIN

	return; -- Questa sp è chiamata dall'importazione CSA. Per il momento non la facciamo agire perchè è' in corso una bonifica dei dati, inoltre va appurato se questa sp debba agire o meno.

		CREATE TABLE #anagrafiche(
			matricola varchar(40),
			idreg int,
			idregistrylegalstatus int,
			start datetime,	
			stop datetime, 
			idposition int,
			active char(1)
			--classestipendiale int,			-- classe stipendiale
			--livello int,
			--ruolo	varchar(4),				-- valore che arriva da CSA
			--inquadramento varchar(20)		-- valore che arriva da CSA
		)


		-- Inserisce la riga più recente a parità di Qualifica
		insert into #anagrafiche(matricola,idreg, idregistrylegalstatus, idposition, start, stop ,active)

		SELECT r.extmatricula, t1.idreg, t1.idregistrylegalstatus, t1.idposition, t1.start, t1.stop, R.active
		FROM registry R
		join registrylegalstatus AS t1
			on R.idreg = t1.idreg
		LEFT OUTER JOIN registrylegalstatus AS t2 
			ON t1.idreg= t2.idreg
			and t1.idposition = t2.idposition
			and t1.start < t2.start  
		where t2.start IS NULL
		and R.active='S' -- Vi sono casi di duplicazione anagrafica, e quindi due idreg diversi ma con matricola uguale.
		and (select count(*) from registrylegalstatus t3
				where t3.idreg = t1.idreg ) >1	
		and t1.active = 'S'
		and r.extmatricula is not null
		and (
			( @matricolastart is null and  @matricolastop is not null and r.extmatricula <=  @matricolastop )
			or
			( @matricolastart is not null and  @matricolastop is null and r.extmatricula >=@matricolastop )
			or
			( @matricolastart is not null and  @matricolastop is not null and  r.extmatricula between @matricolastart and @matricolastop )
			or
			 (@matricolastart is null and  @matricolastop is null)
			 )
		order by t1.idreg desc


		-- Se vi sono più righe attive con qualifiche diverse
		-- e una qualifica termina prima dell'inizio dell'altra, la disattiva
		-- cioè se A.stop è <= B.start, disattiva la riga A

		update #anagrafiche set active = 'N'
		where  exists (select * from #anagrafiche A
							where A.idreg = #anagrafiche.idreg
								and A.idregistrylegalstatus <> #anagrafiche.idregistrylegalstatus
								and A.start >=#anagrafiche.stop
								)

	if(@disattivariga ='S')
	Begin
	-- Valorizza il flag a S o N in base a come ha deciso prima
		update registrylegalstatus 
			set active = R2.active ,-- S o N
			 lu='computecsaS'
		FROM registrylegalstatus
		join #anagrafiche R2
			on registrylegalstatus.idreg = R2.idreg
			and registrylegalstatus.idregistrylegalstatus = R2.idregistrylegalstatus

	  -- Pone a N le altre righe che stanno sul db, in realtà questo codice non dovrebbe servire dopo 
	  -- aver eseguito lo script che Attiva e disattiva il pregresso in modo massivo.

		update registrylegalstatus 
			set active = 'N' ,
			 lu='computecsaN'
		FROM registrylegalstatus
		join #anagrafiche R2
			on registrylegalstatus.idreg = R2.idreg
		where  registrylegalstatus.idregistrylegalstatus 
			NOT IN (select a1.idregistrylegalstatus
						from #anagrafiche a1
						where a1.idreg = registrylegalstatus.idreg)

	
	End
	Else
	Begin 
		select * from #anagrafiche
		order by idreg, start desc, stop
	End

	drop table #anagrafiche
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



