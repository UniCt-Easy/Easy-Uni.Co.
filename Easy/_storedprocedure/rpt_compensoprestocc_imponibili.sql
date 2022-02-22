
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc_imponibili]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc_imponibili]
GO
 
--exec rpt_compensoprestocc_imponibili null,2008,204
--go
--exec rpt_compensoprestocc_imponibili 2009,2008,204
CREATE  PROCEDURE [rpt_compensoprestocc_imponibili]
	@ayear int,
	@ycon int,
	@ncon int
AS
BEGIN	

-- prendere in considerazione la situazione anno per anno
CREATE TABLE #payedrefund
 (
	ayear int,
	payed_lastyear decimal(19,2),
	payed_lastyear_P decimal(19,2),
	payed_total decimal(19,2),
	payed_total_P decimal(19,2),
	payed_prevyears decimal(19,2),
	F_refund_lastyear decimal(19,2),
	P_refund_lastyear decimal(19,2),
	F_refund_total decimal(19,2),
	P_refund_total decimal(19,2),
	F_refund_residual decimal(19,2),
	P_refund_residual decimal(19,2),
	exemptionquota_applied decimal(19,2),
	taxableotheragency decimal(19,2), 
	flaghigherrate char(1), 
	higherrate decimal(19,2),
	residual_to_pay  decimal(19,2),
	payed_lastyear_all decimal(19,2)
 )
 
CREATE TABLE #annualpayedrefund_single
(
	payed_lastyear decimal(19,2),
	payed_lastyear_P decimal(19,2),
	payed_total decimal(19,2),
	payed_total_P decimal(19,2),
	payed_prevyears decimal(19,2),
	F_refund_lastyear decimal(19,2),
	P_refund_lastyear decimal(19,2),
	F_refund_total decimal(19,2),
	P_refund_total decimal(19,2),
	F_refund_residual decimal(19,2),
	P_refund_residual decimal(19,2),
	exemptionquota_applied decimal(19,2)
)
 
CREATE TABLE #annualpayedrefund_total
(
	payed_lastyear decimal(19,2),
	payed_lastyear_P decimal(19,2),
	payed_total decimal(19,2),
	payed_total_P decimal(19,2),
	payed_prevyears decimal(19,2),
	F_refund_lastyear decimal(19,2),
	P_refund_lastyear decimal(19,2),
	F_refund_total decimal(19,2),
	P_refund_total decimal(19,2),
	F_refund_residual decimal(19,2),
	P_refund_residual decimal(19,2),
	exemptionquota_applied decimal(19,2)
)

 
 
DECLARE @idreg int
DECLARE @feegross decimal(19,2)
SELECT  @feegross = ISNULL(feegross,0),
 	@idreg    = idreg
FROM  	casualcontract 
WHERE  	casualcontract.ycon = @ycon
AND  	casualcontract.ncon = @ncon

DECLARE @exemptionquota decimal(19,2)
SET     @exemptionquota =  (SELECT TOP 1 exemptionquota
	       	FROM casualcontractexemption
	     	WHERE startvalidity <= 
			(SELECT adate 
			FROM casualcontract
			WHERE ycon = @ycon 
	              	AND ncon = @ncon)
	   	ORDER BY startvalidity desc)
	
-- inserisco nella tabella temporanea gli anni di esistenza del contratto 
INSERT INTO #payedrefund
(	ayear, 
	payed_lastyear,payed_lastyear_P,
	payed_total,payed_total_P,
	payed_prevyears, 
	F_refund_lastyear,P_refund_lastyear, 
	F_refund_total,P_refund_total,
	F_refund_residual, P_refund_residual,exemptionquota_applied,
	taxableotheragency, flaghigherrate, higherrate,payed_lastyear_all
)
SELECT  C.ayear, 0,0,0,0,0,0,0,0,0,0,0,0,
	ISNULL(C.taxableotheragency,0),ISNULL(C. flaghigherrate,'N'), ISNULL(C.higherrate,0),0
  FROM  casualcontractyear C 
 WHERE  C.ycon = @ycon
   AND  C.ncon = @ncon 

-- ciclo di calcolo degli imponibili in base agli anni di esistenza del contratto

DECLARE @existingayear int
SET 	@existingayear = @ycon -- anno di creazione del contratto 

DECLARE @cursore cursor
SET 	@cursore = CURSOR FOR
SELECT  ayear  FROM #payedrefund order by ayear

OPEN @cursore
FETCH NEXT FROM @cursore INTO @existingayear
WHILE (@@FETCH_STATUS = 0)
BEGIN
 
DECLARE @s nvarchar(300)
SET     @s = 'compute_casualcontract' 

INSERT INTO #annualpayedrefund_single (		
	payed_lastyear,
	payed_lastyear_P,
	payed_total,
	payed_total_P,
	payed_prevyears ,
	F_refund_lastyear,
	P_refund_lastyear,
	F_refund_total,
	P_refund_total,
	F_refund_residual,
	P_refund_residual,
	exemptionquota_applied 
	)
EXEC    @s @existingayear,@ycon,@ncon

UPDATE  #payedrefund
SET
	payed_lastyear 	= ISNULL(#annualpayedrefund_single.payed_lastyear,0),
	payed_total   	= ISNULL(#annualpayedrefund_single.payed_total,0),
	payed_prevyears = ISNULL(#annualpayedrefund_single.payed_prevyears,0),
	F_refund_lastyear = ISNULL(#annualpayedrefund_single.F_refund_lastyear,0),
	P_refund_lastyear = ISNULL(#annualpayedrefund_single.P_refund_lastyear,0),
	F_refund_total 	= ISNULL(#annualpayedrefund_single.F_refund_total,0),
	P_refund_total = ISNULL(#annualpayedrefund_single.P_refund_total,0),
	F_refund_residual = ISNULL(#annualpayedrefund_single.F_refund_residual,0),
	P_refund_residual = ISNULL(#annualpayedrefund_single.F_refund_residual,0),
	exemptionquota_applied =  ISNULL(#annualpayedrefund_single.exemptionquota_applied,0),
	residual_to_pay	 = ISNULL(@feegross,0) -  -- compenso lordo
			   (ISNULL(#annualpayedrefund_single.payed_lastyear,0) +  -- pagato dell'anno
			    ISNULL(#annualpayedrefund_single.payed_prevyears,0))  -- pagato anni precedenti
FROM   #annualpayedrefund_single
WHERE  ayear = @existingayear

DELETE FROM #annualpayedrefund_single
FETCH NEXT FROM @cursore INTO @existingayear
END

CLOSE @cursore 
 
-- lettura dei dati complessivi del percipiente
 
DECLARE @s_all nvarchar(300)
SET     @s_all = 'compute_casualcontract_all' 

OPEN @cursore
FETCH NEXT FROM @cursore INTO @existingayear
WHILE (@@FETCH_STATUS = 0)
BEGIN
 

INSERT INTO #annualpayedrefund_total (		
	payed_lastyear,
	payed_lastyear_P,
	payed_total,
	payed_total_P,
	payed_prevyears ,
	F_refund_lastyear,
	P_refund_lastyear,
	F_refund_total,
	P_refund_total,
	F_refund_residual,
	P_refund_residual,
	exemptionquota_applied 
	)
EXEC    @s @existingayear,@ycon,@ncon

UPDATE  #payedrefund
SET
	payed_lastyear_all 	= ISNULL(#annualpayedrefund_total.payed_lastyear,0) -- ,
	/*
	payed_total   	= ISNULL(#annualpayedrefund_total.payed_total,0),
	payed_prevyears = ISNULL(#annualpayedrefund_total.payed_prevyears,0),
	F_refund_lastyear = ISNULL(#annualpayedrefund_total.F_refund_lastyear,0),
	P_refund_lastyear = ISNULL(#annualpayedrefund_total.P_refund_lastyear,0),
	F_refund_total 	= ISNULL(#annualpayedrefund_total.F_refund_total,0),
	P_refund_total = ISNULL(#annualpayedrefund_total.P_refund_total,0),
	F_refund_residual = ISNULL(#annualpayedrefund_total.F_refund_residual,0),
	P_refund_residual = ISNULL(#annualpayedrefund_total.F_refund_residual,0),
	exemptionquota_applied =  ISNULL(#annualpayedrefund_total.exemptionquota_applied,0),
	residual_to_pay	 = ISNULL(@feegross,0) -  -- compenso lordo
			   (ISNULL(#annualpayedrefund_total.payed_lastyear,0) +  -- pagato dell'anno
			    ISNULL(#annualpayedrefund_total.payed_prevyears,0))  -- pagato anni precedenti
	*/
FROM   #annualpayedrefund_total
WHERE  ayear = @existingayear

DELETE FROM #annualpayedrefund_total
FETCH NEXT FROM @cursore INTO @existingayear
END

CLOSE @cursore 
DEALLOCATE @cursore 
-- se @ayear = null, la stampa deve visualizzare tutti gli anni
IF (@ayear IS NULL) 
BEGIN
	SELECT
		@ycon as 'ycon',
		@ncon as 'ncon',
		ayear,
		taxableotheragency,
		payed_lastyear_all,
		flaghigherrate,
		higherrate,
		@feegross as 'feegross',
		@exemptionquota	as 'exemption',
		payed_lastyear,
		payed_total,
		payed_prevyears ,
		F_refund_lastyear,
		P_refund_lastyear,
		F_refund_total,
		P_refund_total,
		F_refund_residual,
		P_refund_residual,
		exemptionquota_applied,
		residual_to_pay
	FROM  	#payedrefund
END	
ELSE
BEGIN
	-- se @ayear <> null, la stampa deve visualizzare un solo anno
	SELECT
		@ycon as 'ycon',
		@ncon as 'ncon',
		ayear,
		taxableotheragency,
		payed_lastyear_all,
		flaghigherrate,
		higherrate,
		@feegross as 'feegross',
		@exemptionquota	as 'exemption',
		payed_lastyear,
		payed_total,
		payed_prevyears ,
		F_refund_lastyear,
		P_refund_lastyear,
		F_refund_total,
		P_refund_total,
		F_refund_residual,
		P_refund_residual,
		exemptionquota_applied,
		residual_to_pay
	FROM  	#payedrefund
	WHERE   ayear = @ayear
END
END 
go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

