
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prevision_request_aggregated]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prevision_request_aggregated]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_prevision_request_aggregated]
(
	@ayear int,--> anno del bilancio di previsione
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@suppressifblank char(1),
	@officialvar  char(1),
	@filtervarstatus char(1), -- I --> inserite e approvate, T --> Inserite richieste e approvate, A-->Approvate
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS BEGIN

/*
1	Bozza
2	Richiesta
3	Da correggere
4	Inserita
5	Approvata
6	Annullata
*/ 
--- setuser 'amm'
--  exp_prevision_request_aggregated 2011,'31-12-2011','S',3,'S','%','S','N','N','T',null,null,null,null,null

DECLARE @ayearPrec int
SET @ayearPrec = @ayear - 1

DECLARE @idman int
DECLARE @manager varchar(150)

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear
declare @previsionkind char(1)
IF( @fin_kind = 2)
  SET @previsionkind = 'S' 
 else SET @previsionkind = 'C' 

 DECLARE @data TABLE 
(
	idfin int,
	idupb varchar(36),
	initialprevision decimal(19,2),
	variation decimal(19,2),
	idfinvarstatus int,
	newprevision decimal(19,2),
	showincomesurplus char(1),
	rownum int	--> Serve solo per poter visualizzare l'avanzo di amministrazione come prima riga nell'output
)

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_prec decimal(19,2)
DECLARE @aa_prec decimal(19,2)

DECLARE @floatfund_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_01_jan_used decimal(19,2) 
DECLARE @aa_01_jan_used decimal(19,2) 
DECLARE @supposed_ff_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_prec_used decimal(19,2) 
DECLARE @aa_prec_used decimal(19,2) 
DECLARE @ff_prec_used decimal(19,2) 

IF @finpart = 'E'
BEGIN
	SELECT
		@supposed_ff_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0),
		@supposed_aa_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0) +
			ISNULL(supposedpreviousrevenue, 0) +
			ISNULL(supposedcurrentrevenue , 0) -
			ISNULL(supposedpreviousexpenditure, 0) -
			ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

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

	-- Bilancio di Previsione 2014 --
	
	-- Fondo cassa al 01/01/2013
	SELECT 	@ff_prec = ISNULL(startfloatfund, 0) 
	FROM surplus
	WHERE ayear = @ayear - 1

	-- Avanzo di amministrazione al 01/01/2013 = AA al 31/12/2012 = fondo cassa 31/12/2012 + Residui Attivi 2012 - Residui Passivi 2012 = fondo cassa 01/01/2013 + RA 2012 - RP 2012
	SELECT	
		@aa_prec = 	(SELECT ISNULL(startfloatfund, 0) FROM surplus	WHERE ayear = @ayear - 1)
			+	
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 2
 -- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	

	SELECT @supposed_aa_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_aa_prec'

	SELECT @aa_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='aa_prec'

	SELECT @ff_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='ff_prec'
END

DECLARE @labelAvanzo varchar(200)
IF (@previsionkind = 'S') SET @labelAvanzo = 'Fondo iniziale di cassa presunto'
IF (@previsionkind = 'C') SET @labelAvanzo = 'Avanzo di amministrazione presunto'
  
DECLARE @AvanzoIniziale decimal(19,2)
IF (@previsionkind = 'S' ) SET @AvanzoIniziale = @ff_prec
IF (@previsionkind = 'C' ) SET @AvanzoIniziale = @aa_prec

DECLARE @AvanzoTotale decimal(19,2)
 IF (@previsionkind = 'S') SET @AvanzoTotale = @supposed_ff_jan01
 IF (@previsionkind = 'C') SET @AvanzoTotale = @supposed_aa_jan01


DECLARE @AvanzoAumento decimal(19,2)
if (@AvanzoTotale - @AvanzoIniziale)> 0 
begin
	SET @AvanzoAumento = @AvanzoTotale - @AvanzoIniziale
end
else
begin	
	SET @AvanzoAumento = 0
end

DECLARE @AvanzoDiminuzione decimal(19,2)
IF ((@AvanzoIniziale - @AvanzoTotale) > 0)
begin
	 SET @AvanzoDiminuzione = @AvanzoIniziale - @AvanzoTotale
end
else
begin	 
	SET @AvanzoDiminuzione = 0
end
 
-- Serve per visualizzare l'Avanzo come prima riga
IF (@finpart='E')
Begin
	INSERT INTO @data(rownum, idfin,idupb)
	VALUES (null,null,null)
End

  

DECLARE @minoplevel tinyint
SELECT  @minoplevel = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minoplevel)
BEGIN
	SET @levelusable = @minoplevel
END

-- Calcolo della previsione iniziale dell'anno preecdente
insert into @data (
	rownum,
	idfin,
	idupb,
	initialprevision
)
select '',
		ISNULL(FLK.idparent,finlookup.newidfin),--finlookup.newidfin,	--> new
		isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0)
from finyear 
	join fin f5 
		on finyear.idfin = f5.idfin
	JOIN upb U
		ON finyear.idupb = U.idupb
	join finlookup 
        ON f5.idfin = finlookup.oldidfin
	JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
	LEFT OUTER JOIN finlink FLK		--> new
		ON  FLK.idchild = finlookup.newidfin AND FLK.nlevel = @levelusable_original	--> new
where f5.ayear = @ayearPrec
		AND (finyear.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit) 
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )
		
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
-- group by finlookup.newidfin,isnull(@fixedidupb,finyear.idupb)
	group by ISNULL(FLK.idparent,finlookup.newidfin),isnull(@fixedidupb,finyear.idupb)	--> new


-- Calcolo della var. di previsione dell'anno precedente, ai fini del calcolo della previsione definitiva. Escludiamo le var. di tipo 'Iniziale'
INSERT INTO @data
(
	rownum,
	idfin,
	idupb,
	idfinvarstatus,
	variation
)
SELECT
	'',
	ISNULL(FLK.idparent,finlookup.newidfin),
	isnull(@fixedidupb,FVD.idupb),
	FV.idfinvarstatus,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
join finlookup 
      ON F.idfin = finlookup.oldidfin
LEFT OUTER JOIN finlink FLK
	ON  FLK.idchild = finlookup.newidfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayearPrec
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	--AND FV.idfinvarstatus = 5 
	AND (
	(ISNULL(@filtervarstatus,'A') = 'A' AND idfinvarstatus = 5)
	OR
	(ISNULL(@filtervarstatus,'A') = 'I' AND idfinvarstatus in(4,5))
	OR
	(ISNULL(@filtervarstatus,'A') = 'T' AND idfinvarstatus in(2,4,5))
	)
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') 
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) 
	AND F.ayear = @ayearPrec
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb), ISNULL(FLK.idparent,finlookup.newidfin),FV.idfinvarstatus 

--select '1', * from @data

-- Previsione dell'anno del bilancio di previsione = Variazioni tipo Iniziale
INSERT INTO @data
(
	rownum,
	idfin,
	idupb,
	idfinvarstatus,
	newprevision
)
SELECT
	'',
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	FV.idfinvarstatus,
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
join upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.flagprevision = 'S'
	--AND FV.idfinvarstatus = 5
	AND (
	(ISNULL(@filtervarstatus,'A') = 'A' AND idfinvarstatus = 5)
	OR
	(ISNULL(@filtervarstatus,'A') = 'I' AND idfinvarstatus in(4,5))
	OR
	(ISNULL(@filtervarstatus,'A') = 'T' AND idfinvarstatus in(2,4,5))
)
	AND FV.variationkind = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) 
	AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),FV.idfinvarstatus


--select '2', * from @data

IF( @suppressifblank = 'S' )
BEGIN
	DELETE FROM @data
	WHERE ISNULL(initialprevision,0)= 0
		AND ISNULL(variation,0)= 0
		AND ISNULL(newprevision,0)= 0
END
else
BEGIN
	INSERT INTO @data (idupb, idfin,rownum)
	SELECT U.idupb, F.idfin,''
	FROM upb U
	CROSS JOIN fin F
	JOIN finlevel fl
		ON F.nlevel = fl.nlevel
	WHERE F.ayear = @ayear 
				AND ((F.flag & 1)= @finpart_bit) 
				AND (F.nlevel = @levelusable_original 
					OR (F.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = F.idfin)
						AND (fl.flag&2)<>0
					   )
					 )
		  and u.idupb like @idupb
		  and not exists(select * from @data where [@data].idupb = U.idupb and [@data].idfin = f.idfin)
		  		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
END

declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)
/*
Prev.principale alla data di input	: prev attuale alla data (1)	
var. aumento: 2  -  1 > 0		
var diminuzione: 2 - 1 < 0
Prev. nuova  : var.iniziali 2013 (2)
*/

if(@finpart ='E')
Begin
	IF (@showupb ='S')
			BEGIN
			SELECT	
				'' as 'E/S',
				@labelAvanzo as'Cod.UPB',
				'' as  'UPB',
				'' as 'Liv.Bilancio',
				'' as'Cod.Bilancio',
				'' as 'Bilancio',
				'' as 'Responsabile',
				@AvanzoIniziale AS 'Prev.Principale alla data',
				@AvanzoAumento as 'Var.Aumento'	,
				@AvanzoDiminuzione as 'Var.Diminuzione'	,
				@AvanzoTotale as 'Previsione',
				rownum as '-'	 
				FROM @data where idfin is null
			UNION

			SELECT 
				@finpart as 'E/S',
				upb.codeupb as'Cod.UPB',
				upb.title as  'UPB',
				fl.nlevel as 'Liv.Bilancio',
				f.codefin as'Cod.Bilancio',
				f.title as 'Bilancio',
				M.title as 'Responsabile',
				(ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) AS 'Prev.Principale alla data',
				case 
					when isnull(SUM(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))>0
					then isnull(SUM(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))
					else 0
				End as 'Var. Aumento'	,
				case 
					when isnull(SUM(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))<0
					then (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) - isnull(SUM(newprevision),0)
					else 0
				End as 'Var. Diminuzione'	,
				isnull(SUM(newprevision),0) as 'Previsione',
				[@data].rownum as '-' 
			FROM @data
			join fin f
				on [@data].idfin = f.idfin
			JOIN finlevel fl
					ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
			join upb
				on [@data].idupb = upb.idupb		
			left outer join finlast 
				on finlast.idfin= F.idfin
			left outer join  manager M 
				on  M.idman = isnull(finlast.idman,upb.idman)
			where 	f.ayear = @ayear 
					AND ((f.flag & 1)= @finpart_bit) 
					AND (f.nlevel = @levelusable_original 
						OR (f.nlevel < @levelusable_original
							AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
							AND (fl.flag&2)<>0
						   )
						 )
				  and upb.idupb like @idupb
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
				  
			GROUP BY upb.printingorder, upb.idupb, upb.title, upb.codeupb, fl.nlevel ,f.codefin, f.title,[@data].rownum, M.title
			ORDER BY [@data].rownum
			END

			IF (@showupb ='N')
			BEGIN
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
					SET  @idman =
						(SELECT TOP 1 idman
						FROM upb	
						WHERE idupb = @idupboriginal)
				end

			SELECT	
				'' as 'E/S',
				@labelAvanzo as'Cod.UPB',
				'' as  'UPB',
				'' as 'Liv.Bilancio',
				'' as'Cod.Bilancio',
				'' as 'Bilancio',
				'' as 'Responsabile',
				@AvanzoIniziale AS 'Prev.Principale alla data',
				@AvanzoAumento as 'Var.Aumento'	,
				@AvanzoDiminuzione as 'Var.Diminuzione'	,
				@AvanzoTotale as 'Previsione',
				rownum as '-'	 
				FROM @data where idfin is null
			UNION

			SELECT 
				@finpart as 'E/S',
				@codeupb  as'Cod.UPB', --DA RIVEDERE
				@upb as 'UPB',
				fl.nlevel as 'Liv.Bilancio',
				f.codefin as'Cod.Bilancio',
				f.title as 'Bilancio',
				M.title as 'Responsabile',
				(ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) AS 'Prev.Principale alla data',
				case 
					when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))>0
					then isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))
					else 0
				End as 'Var. Aumento'	,
				case 
					when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))<0
					then (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) - isnull(sum(newprevision),0)
					else 0
				End as 'Var. Diminuzione'	,
				isnull(sum(newprevision),0) as 'Previsione',
				[@data].rownum as '-'  
				FROM @data
				join fin f
					on [@data].idfin = f.idfin
				JOIN finlevel fl
						ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
				left outer join finlast 
					on finlast.idfin= F.idfin
				left outer join manager M
						ON M.idman = isnull (finlast.idman,@idman)
			where f.ayear=@ayear 
					AND ((f.flag & 1)= @finpart_bit) 
					AND (f.nlevel = @levelusable_original 
						OR (f.nlevel < @levelusable_original
							AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
							AND (fl.flag&2)<>0
						   )
						 )
			GROUP BY [@data].rownum,fl.nlevel,f.codefin,f.title,M.title
			ORDER BY [@data].rownum
			END
End
ELSE
BEGIN -- @finpart = S
			IF (@showupb ='S')
			BEGIN
				SELECT 
					@finpart as 'E/S',
					upb.codeupb as'Cod.UPB',
					upb.title as  'UPB',
					fl.nlevel as 'Liv.Bilancio',
					f.codefin as'Cod.Bilancio',
					f.title as 'Bilancio',
					M.title as 'Responsabile',
					(ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) AS 'Prev.Principale alla data',
					case 
						when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))>0
						then isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))
						else 0
					End as 'Var.Aumento'	,
					case 
						when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))<0
						then (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) - isnull(sum(newprevision),0)
						else 0
					End as 'Var.Diminuzione'	,
					isnull(sum(newprevision),0) as 'Previsione'  
				FROM @data
				join fin f
					on [@data].idfin = f.idfin
				JOIN finlevel fl
						ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
				join upb
					on [@data].idupb = upb.idupb		
				left outer join finlast
					on finlast.idfin= F.idfin
				left outer join manager M
					on M.idman = isnull(finlast.idman, upb.idman)
				where  f.ayear = @ayear 
						AND ((f.flag & 1) = @finpart_bit) 
						AND (f.nlevel = @levelusable_original 
							OR (f.nlevel < @levelusable_original
								AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
								AND (fl.flag&2)<>0
							   )
							 )
					  and upb.idupb like @idupb
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
				GROUP BY upb.printingorder, upb.idupb, upb.title, upb.codeupb, f.codefin, fl.nlevel,f.title, M.title
				ORDER BY upb.printingorder ASC
			END

			IF (@showupb ='N')
			BEGIN
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
					SET @idman = 
						(SELECT TOP 1 idman
						FROM upb	
						WHERE idupb = @idupboriginal)
				end

				SELECT 
					@finpart as 'E/S',
					@codeupb  as'Cod.UPB', --DA RIVEDERE
					@upb as 'UPB',
					fl.nlevel as 'Liv.Bilancio',
					f.codefin as'Cod.Bilancio',
					f.title as 'Bilancio',
					M.title as 'Responsabile',
					(ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) AS 'Prev.Principale alla data',
					case 
						when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))>0
						then isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))
						else 0
					End as 'Var.Aumento'	,
					case 
						when isnull(sum(newprevision),0) - (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0))<0
						then (ISNULL(SUM(initialprevision),0) + ISNULL(SUM(variation),0)) - isnull(sum(newprevision),0)
						else 0
					End as 'Var.Diminuzione'	,
					isnull(sum(newprevision),0) as 'Previsione' 
				FROM @data
				join fin f
					on [@data].idfin = f.idfin
				JOIN finlevel fl
						ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
				left outer join finlast
						ON finlast.idfin=F.idfin
				left outer join manager M
						ON M.idman= isnull(finlast.idman,@idman)
				where 	f.ayear=@ayear 
						AND ((f.flag & 1)= @finpart_bit) 
						AND (f.nlevel = @levelusable_original 
							OR (f.nlevel < @levelusable_original
								AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
								AND (fl.flag&2)<>0
							   )
							 )
				GROUP BY f.codefin,f.printingorder,fl.nlevel,f.title, M.title
				ORDER BY f.printingorder
			END

END

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
