
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_journal_doubleentry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_journal_doubleentry]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE rpt_journal_doubleentry
(
	@ayear int,
	@start datetime,
	@end datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@officialentry char(1), --- Considera solo scritture ufficiali
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@raggruppa char(1)
)
-- exec rpt_journal_doubleentry 2016, {ts '2016-01-01 00:00:00'}, {ts '2016-12-31 00:00:00'}, '%', 'N','N',null,null,null,null,null,'S'

AS BEGIN
	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S') 
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	DECLARE @codeupb	varchar(50)
	DECLARE @title		varchar(150)
	 
	SELECT	@codeupb = codeupb,
			@title = title
	FROM	upb 
	WHERE	idupb = @idupboriginal

if(@raggruppa ='S')
Begin
	;with SCRITTURE(yentry,nentry)
	as (select distinct yentry,nentry
	FROM entrydetailview
	JOIN config
		ON config.ayear = entrydetailview.yentry
	WHERE entrydetailview.adate BETWEEN @start AND @end	
		AND (entrydetailview.idupb like @idupb OR  @idupboriginal ='%')
		AND (@idsor01 IS NULL OR entrydetailview.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR entrydetailview.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR entrydetailview.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR entrydetailview.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR entrydetailview.idsor05 = @idsor05)	
		AND ((ISNULL(entrydetailview.official,'S') = 'S' AND ISNULL(@officialentry,'N') = 'S') -- consideriamo solo le scritture ufficiali
		OR ISNULL(@officialentry,'N') = 'N') )

	SELECT 
	@idupboriginal as idupb,
	@codeupb as codeupb,
	@title as upb,
	adate,
	E.nentry,
	ISNULL(E.description,'') AS entrydescription,
	ISNULL(doc,'')  AS doc,
	docdate as docdate,
	codeacc,
	account AS accountdescr,
	sum(give) as give,
	sum(have) as have,
	registry,
		Case 
		when idrelated like 'cascon%' then 'Contratto occasionale'
		when idrelated like 'wageadd%' then 'Compenso a dipendente'
		when idrelated like 'itineration%' then 'Missione'
		when idrelated like 'ivapay%' then	'Liquidazione IVA'
		when idrelated like 'mainivapay%'then 'Liquidazione Iva consolidata'
		when idrelated like 'paytrans%' then 'Elenco di trasmissione Mandati'
		when idrelated like 'protrans%' then 'Elenco di trasmissione Reversali'
		when idrelated like 'inv%' then 'Fattura'
		when idrelated like 'man%' then 'Contratto Passivo'
		when idrelated like 'estim%' then 'Contratto Attivo'
		when idrelated like 'payroll%'then 'Cedolino parasubordinati'
		when idrelated like 'assetunload%' then 'Buono di scarico'
		when idrelated like 'assetload%'then 'Buono di carico'
		when idrelated like 'storeunloaddetail%' then 'Scarico magazzino'
		when idrelated like 'csa_import%'then 'Import Stipendi da CSA'
		when idrelated like 'pettycashoperation%'then 'Operazione Fondo Economale'
	end as 'dockind'
	FROM entrydetailview E
	JOIN SCRITTURE S
		on E.yentry = S.yentry and E.nentry = S.nentry
	GROUP BY adate,	E.nentry, ISNULL(E.description,''),	ISNULL(doc,''), docdate,
	codeacc, account, registry,idrelated 
	ORDER BY adate, E.nentry, registry, codeacc 
End

ELSE
Begin
	;with SCRITTURE(yentry,nentry)
	as (select distinct yentry,nentry
		FROM entrydetailview
		JOIN config
			ON config.ayear = entrydetailview.yentry
		WHERE entrydetailview.adate BETWEEN @start AND @end	
			AND (entrydetailview.idupb like @idupb OR  @idupboriginal ='%')
			AND (@idsor01 IS NULL OR entrydetailview.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR entrydetailview.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR entrydetailview.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR entrydetailview.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR entrydetailview.idsor05 = @idsor05)	
			AND ((ISNULL(entrydetailview.official,'S') = 'S' AND ISNULL(@officialentry,'N') = 'S') -- consideriamo solo le scritture ufficiali
			OR ISNULL(@officialentry,'N') = 'N') )

		SELECT 
		@idupboriginal as idupb,
		@codeupb as codeupb,
		@title as upb,
		adate,
		E.nentry,
		ISNULL(E.description,'') AS entrydescription,
		ISNULL(doc,'')  AS doc,
		docdate as docdate,
		codeacc,
		account AS accountdescr,
		give,
		have,
		registry,
			Case 
			when idrelated like 'cascon%' then 'Contratto occasionale'
			when idrelated like 'wageadd%' then 'Compenso a dipendente'
			when idrelated like 'itineration%' then 'Missione'
			when idrelated like 'ivapay%' then	'Liquidazione IVA'
			when idrelated like 'mainivapay%'then 'Liquidazione Iva consolidata'
			when idrelated like 'paytrans%' then 'Elenco di trasmissione Mandati'
			when idrelated like 'protrans%' then 'Elenco di trasmissione Reversali'
			when idrelated like 'inv%' then 'Fattura'
			when idrelated like 'man%' then 'Contratto Passivo'
			when idrelated like 'estim%' then 'Contratto Attivo'
			when idrelated like 'payroll%'then 'Cedolino parasubordinati'
			when idrelated like 'assetunload%' then 'Buono di scarico'
			when idrelated like 'assetload%'then 'Buono di carico'
			when idrelated like 'storeunloaddetail%' then 'Scarico magazzino'
			when idrelated like 'csa_import%'then 'Import Stipendi da CSA'
			when idrelated like 'pettycashoperation%'then 'Operazione Fondo Economale'
		end as 'dockind'
		FROM entrydetailview E
		JOIN SCRITTURE S
			on E.yentry = S.yentry and E.nentry = S.nentry
		ORDER BY adate, E.nentry, registry, codeacc 
	End

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
