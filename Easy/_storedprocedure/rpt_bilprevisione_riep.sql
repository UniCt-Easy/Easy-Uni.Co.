if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisione_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisione_riep]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
--	exec rpt_bilprevisione_riep 2013,'S',3,'%','S','S','S',null,null,null,null,null
--setuser 'amm'
CREATE    PROCEDURE [rpt_bilprevisione_riep]
(
	@ayear smallint,
	@finpart char(1)='S',
	@levelusable tinyint=3,
	@idupb varchar(36)='%',
	@showupb char(1)='N',
	@showchildupb char(1)='N',
	@suppressifblank char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'




IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear



DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0
	
DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable


IF(@levelusable < @minoplevel)-- se decidi di fare la stampa per categoria
begin
	SET @levelusable = @minoplevel
end

CREATE TABLE #data
(
	idfin int,
	idupb varchar(36),
	prevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	previousarrears decimal(19,2),
	tosuppress char(1)
)



DECLARE @infoadvance char(1)

SELECT @infoadvance = paramvalue
FROM generalreportparameter
WHERE idparam = 'MostraAvanzo'

	
	DECLARE @supposed_ff_prec	decimal(19,2)
	DECLARE @supposed_aa_prec	decimal(19,2)
	
	DECLARE @supposed_ff		decimal(19,2)
	DECLARE @supposed_aa		decimal(19,2)

	DECLARE @floatfund_01_jan_used decimal(19,2) 
	DECLARE @supposed_aa_01_jan_used decimal(19,2) 
	DECLARE @aa_01_jan_used decimal(19,2) 
	DECLARE @supposed_ff_01_jan_used decimal(19,2) 

	DECLARE @aa_prec_used decimal(19,2) 
	DECLARE @ff_prec_used decimal(19,2)


IF 	@finpart = 'E'
	BEGIN
		-- Bilancio di Previsione 2014 --
		-- Fondo cassa al 01/01/2013
		SELECT	@supposed_ff_prec = ISNULL(startfloatfund, 0) 
		FROM surplus
		WHERE ayear = @ayear - 1
		
		-- Avanzo di amministrazione al 01/01/2013 = AA al 31/12/2012 = fondo cassa 31/12/2012 + Residui Attivi 2012 - Residui Passivi 2012 = fondo cassa 01/01/2013 + RA 2012 - RP 2012
		SELECT @supposed_aa_prec = (SELECT ISNULL(startfloatfund, 0) FROM surplus	WHERE ayear = @ayear - 1)
			+	
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
		FROM surplus
		WHERE ayear = @ayear - 2
	-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	
		SELECT
		@supposed_ff =
			ISNULL(startfloatfund, 0.0) 	+ ISNULL(proceedstilldate, 0.0) -
			ISNULL(paymentstilldate, 0.0) 	+ ISNULL(proceedstoendofyear, 0.0) -
			ISNULL(paymentstoendofyear, 0.0),
		@supposed_aa =
			ISNULL(startfloatfund, 0.0) 	+ ISNULL(proceedstilldate, 0.0) -
			ISNULL(paymentstilldate, 0.0) 	+	ISNULL(proceedstoendofyear, 0.0) -
			ISNULL(paymentstoendofyear, 0.0) + ISNULL(supposedpreviousrevenue, 0.0) +				
			ISNULL(supposedcurrentrevenue , 0.0) - ISNULL(supposedpreviousexpenditure, 0.0) -
			ISNULL(supposedcurrentexpenditure, 0.0)
		FROM 	surplus
		WHERE 	ayear = @ayear - 1

		SELECT @floatfund_01_jan_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='ff_jan01'
		
		SELECT @aa_01_jan_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='aa_jan01'
	
		SELECT @supposed_ff_01_jan_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='supposed_ff_jan01'
		
		SELECT @supposed_aa_01_jan_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='supposed_aa_jan01'

		SELECT @aa_prec_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='aa_prec'

		SELECT @ff_prec_used = isnull(paramvalue,0) 
		FROM generalreportparameter 
		WHERE idparam='ff_prec'
	
	END
	



insert into #data (
	idfin,
	idupb,
	prevision,previousprevision,secondaryprevision,previoussecondaryprev,currentarrears,previousarrears
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0),ISNULL(SUM(finyear.previousprevision),0),
		ISNULL(SUM(finyear.secondaryprev),0),ISNULL(SUM(finyear.previoussecondaryprev),0),
		ISNULL(SUM(finyear.currentarrears),0),ISNULL(SUM(finyear.previousarrears),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
	ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0)) 
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)

UPDATE #data SET tosuppress = 'N'

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1

DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1


IF (@showupb ='S')
BEGIN
;with raggruppa_capitoli (
		idfin,
		idupb,
		prevision,
		previousprevision	,
		secondaryprevision	,
		previoussecondaryprev	,
		currentarrears		,
		previousarrears		
  )
 AS(
		SELECT 
			idfin,
			idupb,
			ISNULL(SUM(prevision),0),
			ISNULL(SUM(previousprevision),0),
			ISNULL(SUM(secondaryprevision),0),
			ISNULL(SUM(previoussecondaryprev),0),
			ISNULL(SUM(currentarrears),0),
			ISNULL(SUM(previousarrears),0)
		FROM #data
		group by idfin,idupb
)
			
SELECT 
		f.idfin,
		f.codefin  as code1,
		f.title as desc1,
		f.printingorder as printorder1,
		upb.codeupb,
		upb.idupb,
		upb.title as upb,
		upb.printingorder as upbprintingorder,
		ISNULL(SUM(prevision),0) as prevision,
		ISNULL(SUM(previousprevision),0) as previousprevision,
		ISNULL(SUM(secondaryprevision),0) as secondaryprevision,
		ISNULL(SUM(previoussecondaryprev),0) as previoussecondaryprev,
		ISNULL(SUM(currentarrears),0) as currentarrears,
		ISNULL(SUM(previousarrears),0) previousarrears,
		SUM (case when isnull(prevision,0)-isnull(previousprevision,0) > 0 then isnull(prevision,0)-isnull(previousprevision,0) else 0 end) as accretion_var,
		SUM (case when isnull(previousprevision,0)-isnull(prevision,0) > 0 then isnull(previousprevision,0)-isnull(prevision,0) else 0 end) as diminution_var,
		0 as sec_accretion_var	,
		0 as sec_diminution_var	,
		0 as rep_accretion_var	,
		0 as rep_diminution_var	,
	   	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
		null 			as 'display_aa',
		@supposed_ff 		as 'supposed_ff',
		@supposed_aa 		as 'supposed_aa',
		@supposed_ff_prec 	as 'supposed_ff_prec',
		@supposed_aa_prec 	as 'supposed_aa_prec',
		isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
		isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
		isnull(@aa_01_jan_used,0) as aa_01_jan_used,
		isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
		isnull(@aa_prec_used,0) as  aa_prec_used,
		isnull(@ff_prec_used,0) as ff_prec_used	
		FROM fin f				
		cross join  upb 
			left outer join finlink 
				on finlink.idparent=f.idfin 
			left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild and raggruppa_capitoli.idupb=upb.idupb
		where 
			( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (upb.idupb='0001' or raggruppa_capitoli.idfin is not null)) and
			f.ayear=@ayear 
			AND ((f.flag & 1)= @finpart_bit) 
			AND (f.nlevel = 1)
			and upb.idupb like @idupb
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
		group by f.idfin, f.codefin, f.title , f.printingorder,
			upb.codeupb,upb.idupb,upb.title ,upb.printingorder, 
			upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05

		ORDER BY upbprintingorder ASC, f.printingorder ASC			
			
END 



IF (@showupb ='N')
BEGIN
declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)

		if (@idupboriginal='%')
		begin
			set @codeupb= null
			set @upb= null
			set @upbprintingorder= null
			set @ext_idupb= null
		end
		else
		begin
			SET @upbprintingorder =
				(SELECT TOP 1 printingorder
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @upb =
				(SELECT TOP 1 title
				FROM upb
				WHERE idupb = @idupboriginal)
			SET  @ext_idupb =	@idupboriginal
			SET  @codeupb =
				(SELECT TOP 1 codeupb
				FROM upb	
				WHERE idupb = @idupboriginal)
		end




;with raggruppa_capitoli (
		idfin,
		idupb,
		prevision,
		previousprevision	,
		secondaryprevision	,
		previoussecondaryprev	,
		currentarrears		,
		previousarrears		
  )
 AS(
		SELECT 
			idfin,
			idupb,
			ISNULL(SUM(prevision),0),
			ISNULL(SUM(previousprevision),0),
			ISNULL(SUM(secondaryprevision),0),
			ISNULL(SUM(previoussecondaryprev),0),
			ISNULL(SUM(currentarrears),0),
			ISNULL(SUM(previousarrears),0)
		FROM #data
		group by idfin,idupb
)
			
SELECT 
		f.idfin,
		f.codefin  as code1,
		f.title as desc1,
		f.printingorder printorder1,
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,
		ISNULL(SUM(prevision),0) as prevision,
		ISNULL(SUM(previousprevision),0) as previousprevision,
		ISNULL(SUM(secondaryprevision),0) as secondaryprevision,
		ISNULL(SUM(previoussecondaryprev),0) as previoussecondaryprev,
		ISNULL(SUM(currentarrears),0) as currentarrears,
		ISNULL(SUM(previousarrears),0) previousarrears,
		SUM (case when isnull(prevision,0)-isnull(previousprevision,0) > 0 then isnull(prevision,0)-isnull(previousprevision,0) else 0 end) as accretion_var,
		SUM (case when isnull(previousprevision,0)-isnull(prevision,0) > 0 then isnull(previousprevision,0)-isnull(prevision,0) else 0 end) as diminution_var,
		0 as sec_accretion_var	,
		0 as sec_diminution_var	,
		0 as rep_accretion_var	,
		0 as rep_diminution_var	,
	   	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
		null 			as 'display_aa',
		@supposed_ff 		as 'supposed_ff',
		@supposed_aa 		as 'supposed_aa',
		@supposed_ff_prec 	as 'supposed_ff_prec',
		@supposed_aa_prec 	as 'supposed_aa_prec',
		isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
		isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
		isnull(@aa_01_jan_used,0) as aa_01_jan_used,
		isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
		isnull(@aa_prec_used,0) as  aa_prec_used,
		isnull(@ff_prec_used,0) as ff_prec_used	
		FROM fin f				
			left outer join finlink 
				on finlink.idparent=f.idfin 
			left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild 
				
		where 
			 ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (/*upb.idupb='0001' or */raggruppa_capitoli.idfin is not null)) and
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = 1)		
		 
		group by f.idfin,f.codefin, f.title , f.printingorder

END




END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




