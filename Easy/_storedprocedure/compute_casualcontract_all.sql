if exists (select * from dbo.sysobjects where id = object_id(N'[compute_casualcontract_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_casualcontract_all]
GO
--setuser 'amm'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE PROCEDURE [compute_casualcontract_all]
	@ayear int, 
	@idreg int
AS BEGIN
--[compute_casualcontract_all] 2011, 150
CREATE TABLE #annualpayedrefund_all
(
	payed_lastyear_F decimal(19,2),
	payed_lastyear_P decimal(19,2),
	payed_total_F decimal(19,2),
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

CREATE TABLE #casualcontract
(
	ycon int,
	ncon int
)

DECLARE @ayearstr varchar(4)
SET @ayearstr = CONVERT(varchar(4), @ayear)


DECLARE @idregstr varchar(10)
SET @idregstr = CONVERT(varchar(10), @idreg)


declare @ycon int
declare @ncon int
declare @iddbdepartment varchar(50)

declare @crsdepartment cursor
set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
where   (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
open 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
	declare @s varchar(300)
	declare @sql_contracts nvarchar(4000)
	
	SET @sql_contracts = N'SELECT  C.ycon,C.ncon' +
 				     ' FROM [' + @iddbdepartment + '].casualcontractyear CY' +
				     ' JOIN [' + @iddbdepartment + '].casualcontract C' +
				     ' ON C.ycon = CY.ycon AND C.ncon = CY.ncon ' +
				     ' WHERE C.idreg = ' + @idregstr +
				     ' AND CY.ayear = ' + @ayearstr
	
	--print @sql_contracts

	INSERT INTO #casualcontract(ycon,ncon)
	EXEC SP_EXECUTESQL @sql_contracts
	
	
	set @s = @iddbdepartment + '.compute_casualcontract' 
	
	declare @crscontract cursor
	-- estrazione dei contratti di ogni dipartimento aventi un residuo da contabilizzare 
	-- nell'anno corrente o creati nell'anno corrente
	set @crscontract = cursor for 
		select  ycon, ncon from #casualcontract
	open 	@crscontract
	fetch next from @crscontract into @ycon,@ncon
	while @@fetch_status=0 
	begin
		insert into #annualpayedrefund_all (		
			payed_lastyear_F,
			payed_lastyear_P,
			payed_total_F,
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
		exec @s @ayear,@ycon,@ncon
		fetch next from @crscontract into @ycon, @ncon
	end

	DELETE FROM #casualcontract
	fetch next from @crsdepartment into @iddbdepartment
end

--select * from #annualpayedrefund_all

SELECT 
	ISNULL(SUM(payed_lastyear_F),0) 		AS payed_lastyear_F, 	--(pagato nell'ultimo anno)
	ISNULL(SUM(payed_lastyear_P),0) 		AS payed_lastyear_P, 	--(pagato nell'ultimo anno)
	ISNULL(SUM(payed_total_F),0) 		AS payed_total_F, 	--(totale pagato)
	ISNULL(SUM(payed_total_P),0) 		AS payed_total_P, 	--(totale pagato)
	ISNULL(SUM(F_refund_lastyear),0) 	AS F_refund_lastyear,   --(spese fiscali pagate nell'ultimo anno)
	ISNULL(SUM(P_refund_lastyear),0) 	AS P_refund_lastyear, 	--(spese previdenziali pagate nell'ultimo anno)
	ISNULL(SUM(F_refund_total),0) 		AS F_refund_total,	--(spese fiscali complessive pagate)
	ISNULL(SUM(P_refund_total),0) 		AS P_refund_total,	--(spese previdenziali complessive pagate)
	ISNULL(SUM(F_refund_residual),0) 	AS F_refund_residual,	--(residuo spese fiscali da pagare)
	ISNULL(SUM(P_refund_residual),0) 	AS P_refund_residual,	--(residuo spese previdenziali da pagare)
	ISNULL(SUM(exemptionquota_applied),0)  	AS exemptionquota_applied --(quota esente applicata)
FROM   #annualpayedrefund_all

END




--exec compute_casualcontract_all 2010, 520174

GO
