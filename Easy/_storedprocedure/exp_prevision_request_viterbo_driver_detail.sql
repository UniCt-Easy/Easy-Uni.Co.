if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prevision_request_viterbo_driver_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prevision_request_viterbo_driver_detail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [exp_prevision_request_viterbo_driver_detail]
(
	@ayear int,			--> anno del bilancio di previsione
	@date datetime,
	@finpart char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)

AS BEGIN
/*
exec exp_prevision_request_viterbo_driver_detail 2017, {ts '2017-12-31 00:00:00'} ,'E', '%','N', null,null, null, null,null
*/

DECLARE @idsortingkind01 varchar(20)
DECLARE @idsortingkind02 varchar(20)
DECLARE @idsortingkind03 varchar(20)
DECLARE @idsortingkind04 varchar(20)
DECLARE @idsortingkind05 varchar(20)

SELECT
	@idsortingkind01 = idsorkind01,
	@idsortingkind02 = idsorkind02,
	@idsortingkind03 = idsorkind03,
	@idsortingkind04 = idsorkind04,
	@idsortingkind05 = idsorkind05
FROM uniconfig 


DECLARE @sortingkind01 varchar(50)
SELECT @sortingkind01 = description FROM sortingkind WHERE idsorkind = @idsortingkind01

DECLARE @sortingkind02 varchar(50)
SELECT @sortingkind02 = description FROM sortingkind WHERE idsorkind = @idsortingkind02

DECLARE @sortingkind03 varchar(50)
SELECT @sortingkind03 = description FROM sortingkind WHERE idsorkind = @idsortingkind03

DECLARE @sortingkind04 varchar(50)
SELECT @sortingkind04 = description FROM sortingkind WHERE idsorkind = @idsortingkind04

DECLARE @sortingkind05 varchar(50)
SELECT @sortingkind05 = description FROM sortingkind WHERE idsorkind = @idsortingkind05


IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

SELECT  
	 yvar as [Eserc. variaz.]	
    ,nvar as [Num. variaz.]
	,rownum as [Num. Dett.]	
	,variationdescription as [Desc. variazione]
	,variationkinddescr as [Tipo var.]
	,manager as [Responsabile]
	,finvarstatus as [Stato]
	,ayear as [Eserc. bil.]
	,finpart as [Parte bil.]
	,codefin as [Voce bil.]
	,finance as [Denom. bil.]
	,v.description as [Descrizione]
	,v.codeupb as [Codice UPB]
	,upb as [Denom. UPB.]
	,annotation as [Annotazioni del dettaglio]
	,adate as [Data variazione]
	,v.amount*dc.rate as [Importo anno 1]
	,prevision2*dc.rate as [Importo anno 2]
	,prevision3*dc.rate as [Importo anno 3]
	,prevision4*dc.rate as [Importo anno 4]
	,prevision5*dc.rate as [Importo anno 5]
	,codeacc as [Codice Conto]
	,account as [Descr. Conto]
	,t.codeupb as [UPB del titolare]--idupb_procedureman 
	,t.title as [Desc. UPB del titolare]
	,v.start as [Inizio Competenza]
	,v.stop  as [Fine Competenza]
	,CASE ISNUMERIC(didattica) 
		WHEN 1 THEN CAST(didattica AS float) * dc.rate 
	 ELSE 0
	 END as [% Didattica]
	,CASE ISNUMERIC(ricerca)  
		WHEN 1 THEN CAST(ricerca AS float) * dc.rate 
	 ELSE 0
	 END as [% Ricerca]
	,CASE ISNUMERIC(servizi)  
		WHEN 1 THEN CAST(servizi AS float) * dc.rate 
	 ELSE 0
	 END as [% Servizi]
	,d.costpartitioncode as [Codice Driver]  --idcostpartition 
	,d.title  as [Descrizione Driver]
	,c.sortcode [Codice Centro di Costo] --idsor1 
	,c.description [Desc. Centro di Costo]
	,v.CU 
	,v.CT 
	,v.LU 
	,v.LT
	,s1.sortcode as [Codice Attr1]--idsor01
	,s2.sortcode as [Codice Attr2]--idsor02
	,s3.sortcode as [Codice Attr3]--idsor03
	,s4.sortcode as [Codice Attr4]--idsor04
FROM viterbo_finvardetailview v
LEFT OUTER JOIN costpartition d 	
	on v.idcostpartition = d.idcostpartition --Driver di ripartizione
LEFT OUTER JOIN costpartitiondetail dc 
	on dc.idcostpartition = d.idcostpartition 
LEFT OUTER JOIN sorting c 
	on c.idsor = dc.idsor1
LEFT OUTER JOIN upb t 
	on t.idupb = v.idupb_procedureman
LEFT OUTER JOIN sorting s1 
	on v.idsor01 = s1.idsor
LEFT OUTER JOIN sorting s2 
	on v.idsor02 = s2.idsor
LEFT OUTER JOIN sorting s3 
	on v.idsor03 = s3.idsor
LEFT OUTER JOIN sorting s4 
	on v.idsor04 = s4.idsor
WHERE v.yvar = @ayear
	AND v.adate <= @date
	AND (v.idupb LIKE @idupb)
	AND ((v.flag & 1 ) = @finpart_bit) 
	AND (@idsor01 is null or ISNULL(v.idsor01,0) = @idsor01)
	AND (@idsor02 is null or ISNULL(v.idsor02,0) = @idsor02)
	AND (@idsor03 is null or ISNULL(v.idsor03,0) = @idsor03)
	AND (@idsor04 is null or ISNULL(v.idsor04,0) = @idsor04)
	AND (@idsor05 is null or ISNULL(v.idsor05,0) = @idsor05)

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

	
