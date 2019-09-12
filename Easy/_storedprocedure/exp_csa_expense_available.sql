if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_expense_available]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO

-- exec [exp_csa_expense_available] 2015, 1 

CREATE PROCEDURE  [exp_csa_expense_available]
	(
		@ayear int,
		@idcsa_import int  -- ,
		--@kind CHAR(1) -- T deve essere eseguita sia la fase Lordi che la fase Versamenti, 
		--		  -- V deve essere eseguita solo la fase Versamenti, 
		--		  -- N movimenti finanziari già generati 
	)

AS BEGIN



DECLARE @kind CHAR(1)

IF
( 
	(SELECT
	 
		(SELECT  COUNT(*) FROM csa_import_expense  where idcsa_import = @idcsa_import AND movkind  in (3,2,12,14,16,8))
		+
		(SELECT  COUNT(*) FROM csa_import_income where idcsa_import = @idcsa_import AND movkind   in (7,1,5,15))
	)
	  > 0
    
	AND 
	(
	SELECT
	(
		(SELECT  COUNT(*) FROM csa_import_expense   where idcsa_import = @idcsa_import AND   movkind in (4,13))
		+
		(SELECT  COUNT(*) FROM csa_import_income  where idcsa_import = @idcsa_import AND movkind  in (17,9,11,6))
	 ) ) > 0
	 
)  SET @kind = 'N' 

ELSE
IF
(
	(SELECT
	(
		(SELECT  COUNT(*) FROM  csa_import_expense where idcsa_import = @idcsa_import AND movkind in (3,2,12,14,16,8))
		+
		(SELECT  COUNT(*) FROM csa_import_income  where idcsa_import = @idcsa_import AND movkind in (7,10,1,5,15))
	)) > 0
    
	AND 
	(
	SELECT
	(
		(SELECT  COUNT(*) FROM csa_import_expense   where idcsa_import = @idcsa_import AND movkind in (4,13))
		+
		(SELECT  COUNT(*) FROM csa_import_income where idcsa_import = @idcsa_import AND movkind in (17,9,11,6))
	 )) = 0
	 
)  SET @kind = 'V' 

ELSE  SET @kind = 'T' 
PRINT @kind
IF (@kind = 'N') 
	--select null as phase,
	--null as finance,
	--null as upb,
	--null as registry,
	--null as curramount,
	--null as available_1,
	--null as available_2,
	--null as available_3,		
	--null as available_4,
	--null as flagcr,
	--null as idexp  

RETURN

create table #output_lordi
(
kind varchar(20), movkind int , parentidinc int , parentidexp int , idman int ,idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)
) 

create table #output_versamenti
(
kind varchar(20), movkind int , parentidinc int , parentidexp int ,  idman int ,idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)
) 

 
IF (@kind = 'T')
BEGIN
	insert into #output_lordi
	select * from f_compute_csa_lordi (@ayear, @idcsa_import)

	insert into #output_versamenti
	select * from f_compute_csa_versamenti (@ayear, @idcsa_import)
END 
ELSE
BEGIN
	insert into #output_versamenti
	select * from f_compute_csa_versamenti (@ayear, @idcsa_import)
END

;with padri (idexp) as (
select distinct idexp from csa_importriep 
where idcsa_import = @idcsa_import
and idexp is not null

union 

select distinct idexp_cost from csa_importver
where idcsa_import = @idcsa_import
and idexp_cost is not null

union 

select distinct csa_importver_expense.idexp from   csa_importver
		JOIN csa_importver_expense
				ON csa_importver.idcsa_import = csa_importver_expense.idcsa_import
					AND csa_importver.idver = csa_importver_expense.idver
where csa_importver.idcsa_import =  @idcsa_import

union 

select distinct csa_importriep_expense.idexp from   csa_importriep
		JOIN csa_importriep_expense
				ON csa_importriep.idcsa_import = csa_importriep_expense.idcsa_import
					AND csa_importriep.idriep = csa_importriep_expense.idriep
where csa_importriep.idcsa_import =  @idcsa_import
)


  
select --   FASE LORDI E VERSAMENTI
	phase + ' n ' + convert(varchar(10),nmov) + '/' +
	convert(varchar(4),ymov) as 'Movimento',

	codefin + '-' + finance as 'Bilancio',

	 codeupb + '-' + upb as 'UPB',

	 registry as 'Anagrafica',

	 curramount  as 'Importo Corrente',
	 available as 'Importo Disponibile Attuale',
	 CASE WHEN (@kind = 'T')  
	 THEN  available
	 - isnull((SELECT SUM(amount) FROM #output_lordi
	 WHERE  #output_lordi.parentidexp = padri.idexp),0)
	 ELSE available
	 END
	  as 'Disponibile dopo elaborazione solo Lordi',
	 CASE WHEN  (@kind = 'V')
	 THEN available
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 ELSE  available - isnull((SELECT SUM(amount) FROM #output_lordi
	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 END 
	  as 'Disponibile dopo elaborazione  Versamenti',

	CASE WHEN @kind = 'T'  THEN
	 available - isnull((SELECT SUM(amount) FROM #output_lordi
	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 ELSE   available
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 END
	 as 'Disponibile dopo elaborazione Lordi e Versamenti',

	flagarrear as 'C/R' ,
	expenseview.idexp as 'idexp'
 from padri
 
join expenseview
	on expenseview.idexp = padri.idexp
	and expenseview.ayear = @ayear
	
	and ((( available - isnull((SELECT SUM(amount) FROM #output_lordi
	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0) <0) AND  @kind = 'T')
	 
	 OR ((available   - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)  <0) AND @kind = 'V')
	 )
END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 