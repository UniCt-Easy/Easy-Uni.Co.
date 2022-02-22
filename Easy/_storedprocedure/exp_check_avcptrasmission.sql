
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_avcptrasmission]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_avcptrasmission]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE exp_check_avcptrasmission
(
	@ayear int
)
AS BEGIN
		--exp_check_avcptrasmission 2021
		CREATE TABLE #avcperror (message varchar(400))

		INSERT INTO #avcperror (message)
		select 'Contratto Passivo: '+ K.description + ' n.' + CONVERT(varchar(6),M.nman) +' Eserc.' + CONVERT(varchar(6),M.yman) + ' senza lotti'
		 from mandate M
		join mandatekind K
			on M.idmankind = K.idmankind
		where M.yman = @ayear
			and (K.flag&1)=0
			and (select count(*) from mandatecig G
				where M.idmankind=G.idmankind and M.yman = G.yman and M.nman = G.nman)=0

		order by K.description, M.nman, M.yman

		INSERT INTO #avcperror (message)
		select 'Contratto Passivo: '+ K.description + ' n.' + CONVERT(varchar(6),M.nman) +' Eserc.' + CONVERT(varchar(6),M.yman) + ' senza Partecipanti'
		from mandate M
		join mandatekind K
			on M.idmankind = K.idmankind
		where M.yman = @ayear
			and(K.flag&1)=0
			and (select count(*) from mandateavcp G
				where M.idmankind=G.idmankind and M.yman = G.yman and M.nman = G.nman)=0
		order by K.description, M.nman, M.yman


		INSERT INTO #avcperror (message)
		select 'Contratto Passivo: '+ K.description + ' n.' + CONVERT(varchar(6),rManCig.nman) + ' Eserc.' + CONVERT(varchar(6), rManCig.yman) 
		+ ' lotto ' + CONVERT(varchar(6),rManCig.cigcode)+ ' senza partecipanti.'
		from mandatecig rManCig  --lotto G
		join mandatekind K
			on rManCig.idmankind = K.idmankind
		left outer join mandateavcp A   --partecipante A
			on  A.idmankind=rManCig.idmankind and A.yman = rManCig.yman and A.nman = rManCig.nman 
		where rManCig.yman = @ayear
			and (K.flag&1)=0
			and A.idmankind is null
								 
		order by K.description, rManCig.nman, rManCig.yman


		-- Errore nei dati, partecipante di id " + idavcp.ToString() + " non associato al lotto " + rManCig["cigcode"].ToString());
		INSERT INTO #avcperror (message)
		select 'Contratto Passivo: '+ K.description + ' n.' + CONVERT(varchar(6),rManCig.nman) + ' Eserc.' + CONVERT(varchar(6), rManCig.yman) 
		+ ' partecipante di id ' + CONVERT(varchar(6),A.idavcp) + ' non associato al lotto ' + CONVERT(varchar(10),rManCig.cigcode)
		from mandatecig rManCig  --lotto G
		join mandatekind K
			on rManCig.idmankind = K.idmankind
		join mandateavcp A   --partecipante A
			on  A.idmankind=rManCig.idmankind and A.yman = rManCig.yman and A.nman = rManCig.nman 
		where rManCig.yman = @ayear
			and (K.flag&1)=0
			and not exists (select * from mandateavcpdetail d where
								 a.idmankind=d.idmankind and a.yman=d.yman and a.nman=d.nman and a.idavcp=d.idavcp 
								 and rManCig.cigcode = d.cigcode)
								 
		order by K.description, rManCig.nman, rManCig.yman


		-- Errore nei dati, partecipante di id " + idavcp.ToString() + " non associato al lotto " + rManCig["cigcode"].ToString());
		INSERT INTO #avcperror (message)
		select 'Contratto Passivo: '+ K.description + ' n.' + CONVERT(varchar(6),rManCig.nman) + ' Eserc.' + CONVERT(varchar(6), rManCig.yman) 
		 + ' CF/Piva con spazi ' + CONVERT(varchar(10),rManCig.cigcode)
		from mandatecig rManCig  --lotto G
		join mandatekind K
			on rManCig.idmankind = K.idmankind
		join mandateavcp A   
			on  A.idmankind=rManCig.idmankind and A.yman = rManCig.yman and A.nman = rManCig.nman 
		where rManCig.yman = @ayear
		and   (cf is not null and PATINDEX('% %', cf)>0)
								 
		order by K.description, rManCig.nman, rManCig.yman


		select * from #avcperror

		drop table #avcperror

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
