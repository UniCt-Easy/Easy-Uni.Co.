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
		--exp_check_avcptrasmission 2015
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
		+ ' partecipante di id ' + CONVERT(varchar(6),A.idavcp) + ' non associato al lotto ' + CONVERT(varchar(6),rManCig.cigcode)
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

		select * from #avcperror

		drop table #avcperror

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

