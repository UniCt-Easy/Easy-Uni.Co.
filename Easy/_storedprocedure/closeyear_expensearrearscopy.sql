if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_expensearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_expensearrearscopy]
GO
--setuser 'amm'

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--  setuser 'amministrazione'
--  closeyear_expensearrearscopy 2016

CREATE    PROCEDURE [closeyear_expensearrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idexp int
DECLARE @idfin  int
DECLARE @idupb varchar(36)
DECLARE @nphase tinyint
DECLARE @nlevel tinyint
DECLARE @curramount decimal(19,2)
DECLARE @available decimal(19,2)
DECLARE @payed decimal(19,2)
DECLARE @newidfin int
DECLARE @nextayear int

SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
DECLARE @maxexpensephase int
SELECT @maxexpensephase =  MAX(nphase) FROM expensephase

if (@maxexpensephase>2)begin
insert into expenseyear (idexp, ayear, idfin, idupb, amount,  cu, ct, lu, lt)
select E.idexp,@nextayear, FL.newidfin,EY.idupb,
 ET.curramount- isnull((SELECT SUM(curramount)
		FROM expensetotal
		JOIN expenselast			ON     expenselast.idexp = expensetotal.idexp
		JOIN   expenselink			ON     expenselink.idchild = expenselast.idexp
		WHERE  expensetotal.ayear = @ayear		AND expenselink.idparent = E.idexp and nlevel = E.nphase ),0),
			'ArrearsCopy', GETDATE(), 'ArrearsCopy', GETDATE()
 FROM expensetotal	ET
 JOIN expense E	 	ON E.idexp = ET.idexp
 join expenseyear EY ON EY.idexp = ET.idexp and EY.ayear= ET.ayear
 join finlookup FL on FL.oldidfin= EY.idfin
 left outer join expenseyear ey2 on ey2.idexp=ET.idexp and ey2.ayear=@nextayear
WHERE ET.ayear = @ayear	AND E.nphase < @maxexpensephase-1  AND EY2.idexp is null
	and ET.curramount > isnull((SELECT SUM(curramount)
		FROM expensetotal
		JOIN expenselast			ON     expenselast.idexp = expensetotal.idexp
		JOIN   expenselink			ON     expenselink.idchild = expenselast.idexp
		WHERE  expensetotal.ayear = @ayear		AND expenselink.idparent = E.idexp and nlevel = E.nphase ),0)

end


if (@maxexpensephase>1) begin
insert into expenseyear (idexp, ayear, idfin, idupb, amount,  cu, ct, lu, lt)
select E.idexp,@nextayear, FL.newidfin,EY.idupb,
	ET.available, 'ArrearsCopy', GETDATE(), 'ArrearsCopy', GETDATE()
 FROM expensetotal	ET
 JOIN expense E	 	ON E.idexp = ET.idexp
 join expenseyear EY ON EY.idexp = ET.idexp and EY.ayear= ET.ayear
 join finlookup FL on FL.oldidfin= EY.idfin
 left outer join expenseyear ey2 on ey2.idexp=ET.idexp and ey2.ayear=@nextayear
WHERE ET.ayear = @ayear	AND E.nphase = @maxexpensephase-1  AND EY2.idexp is null
	and ET.available>0
end

		
EXEC rebuild_expensetotal @nextayear

EXEC rebuild_upbexpensetotal @nextayear

EXEC rebuild_treasurercashtotal @nextayear

EXEC closeyear_casualcontract @ayear
EXEC closeyear_wageaddition @ayear

EXEC closeyear_epexparrearscopy @ayear

delete from csa_contractexpense where ayear=@nextayear
		and idexp not in (select idexp from expenseyear where ayear=@nextayear)

delete from csa_contracttaxexpense where ayear=@nextayear
		and idexp not in (select idexp from expenseyear where ayear=@nextayear)

update csa_contract set idexp_main=null where ayear=@nextayear
		and idexp_main not in (select idexp from expenseyear where ayear=@nextayear)

update csa_contract_partition set idexp =null where ayear=@nextayear
		and idexp not in (select idexp from expenseyear where ayear=@nextayear)

update csa_contracttax_partition set idexp =null where ayear=@nextayear
		and idexp not in (select idexp from expenseyear where ayear=@nextayear)

delete from csa_contractepexp where ayear=@nextayear
		and idepexp not in (select idepexp from epexpyear where ayear=@nextayear)

delete from csa_contracttaxepexp where ayear=@nextayear
				and idepexp not in (select idepexp from epexpyear where ayear=@nextayear)

update csa_contract set idepexp_main=null where ayear=@nextayear
		and idepexp_main not in (select idepexp from epexpyear where ayear=@nextayear)

update csa_contract_partition set idepexp =null where ayear=@nextayear
				and idepexp not in (select idepexp from epexpyear where ayear=@nextayear)

update csa_contracttax_partition set idepexp =null where ayear=@nextayear
			and idepexp not in (select idepexp from epexpyear where ayear=@nextayear)


CREATE TABLE #info (msg varchar(800))
INSERT INTO #info
VALUES('I residui passivi sono stati trasferiti all''esercizio ' + @nextayearstr)

INSERT INTO #info
VALUES('Gli impegni di budget, per la quota non pagata, sono stati trasferiti all''esercizio ' + @nextayearstr)

	
-- azzero i bit da 0 a 3 e imposto il valore 5 nell'esercizio corrente. 
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x05 WHERE ayear = @ayear

-- azzero i bit da 0 a 3 e imposto il valore 0 nel nuovo esercizio.
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @nextayear
	
SELECT * FROM #info
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

