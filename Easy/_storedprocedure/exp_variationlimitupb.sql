if exists (select * from dbo.sysobjects where id = object_id(N'[exp_variationlimitupb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_variationlimitupb]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_variationlimitupb]
(
	@yvar smallint,
	@nvar int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS
BEGIN

declare @approvata char(1)
if ((select idfinvarstatus from finvar where yvar = @yvar and nvar = @nvar) = '5')
begin
	set @approvata = 'S'
end	
else
begin
	set @approvata = 'N'
end

DECLARE @DETTAGLIO_VARIAZIONE TABLE (
	idupb varchar(36),	
	idfin int, 
	previsionvariation decimal(19,2),
	secondaryvariation decimal(19,2),
	creditvariation decimal(19,2),
	proceedsvariation decimal(19,2)
	)  

INSERT INTO @DETTAGLIO_VARIAZIONE( idupb, idfin,previsionvariation)
select D.idupb, D.idfin, 
		sum( case when V.flagprevision='S'  then amount else 0 end )
from finvar V
join finvardetail D
	on V.yvar = D.yvar and V.nvar= D.nvar
join upb U
	on U.idupb = D.idupb	
where V.yvar = @yvar and V.nvar = @nvar
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by D.idupb, D.idfin
--having sum( case when V.flagprevision='S'  then amount else 0 end ) > 0


DECLARE @LIMITI TABLE (
	idupb varchar(36),	
	idfin int, 
	limit decimal(19,2),
	totalprev decimal(19,2),
	variations decimal(19,2)	
	)  
insert into @limiti (idupb,idfin,limit,totalprev) 
select UC.idupb,UC.idfin,fy.limit,UC.totprev 	
	from upbconstotal UC
	join finyear fy on UC.idfin=fy.idfin and UC.idupb=fy.idupb
	where	fy.limit is not null and
			 exists(select * from @DETTAGLIO_VARIAZIONE D where D.idfin=UC.idfin and D.idupb like UC.idupb+'%')

if(@approvata = 'N')
BEGIN
update @LIMITI set variations= (select sum(previsionvariation) 
		from @DETTAGLIO_VARIAZIONE D
			where D.idfin=[@limiti].idfin and D.idupb like [@limiti].idupb+'%')
END

--select * from @LIMITI

if(@approvata = 'S')
Begin
		select   
			CASE
				when (( F1.flag & 1)=0) then 'E'
				when (( F1.flag & 1)=1) then 'S'
			End as 'E/S',
			FVD.amount as 'Importo variazione',
			U2.codeupb as 'UPB dettaglio',
			F1.codefin as 'Bilancio',			
			U1.codeupb as 'UPB Limite',
			L.totalprev		as 'Previsione consolidata',
			L.limit		as 'Limite sulla previsione'
			from @LIMITI L
			join fin F1			on F1.idfin = L.idfin
			join upb U1			on U1.idupb = L.idupb
			join finvardetail fvd on fvd.idfin=L.idfin  and fvd.idupb like L.idupb+'%'
			join upb U2			on U2.idupb = fvd.idupb
			where fvd.yvar = @yvar and fvd.nvar = @nvar
		order by  U1.codeupb,F1.codefin
End

if(@approvata = 'N')
Begin
		select   
			CASE
				when (( F1.flag & 1)=0) then 'E'
				when (( F1.flag & 1)=1) then 'S'
			End as 'E/S',
			F1.codefin as 'Bilancio',
			FVD.amount as 'Importo variazione',
			U2.codeupb as 'UPB dettaglio',
			U1.codeupb as 'UPB Limite',
			L.totalprev		as 'Previsione consolidata',
			L.variations	as 'Variazioni',
			isnull(L.totalprev,0)+isnull(L.variations,0) as 'Nuova previsione',
			L.limit		as 'Limite sulla previsione'

			from @LIMITI L
			join fin F1			on F1.idfin = L.idfin
			join upb U1			on U1.idupb = L.idupb
			join finvardetail fvd on fvd.idfin=L.idfin  and fvd.idupb like L.idupb+'%'
			join upb U2			on U2.idupb = fvd.idupb
			where fvd.yvar = @yvar and fvd.nvar = @nvar
				
		order by  U1.codeupb,F1.codefin
End

END

GO




SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--exec exp_variationlimitupb 2014, 72,null,null,null,null,null

