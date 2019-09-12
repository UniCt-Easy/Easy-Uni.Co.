if exists (select * from dbo.sysobjects where id = object_id(N'[compute_csa_lordi_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_csa_lordi_partition]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- select * from csa_import
-- compute_csa_lordi_partition 2015,1
CREATE  PROCEDURE [compute_csa_lordi_partition]
(
	@ayear	      int,
	@idcsa_import int
)
AS BEGIN
      --   + movkind 1 mov. entrata ritenute	 (fase LORDI)
      --   - movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)      
      
      --   + movkind 3 mov. spesa costo  lordi (fase LORDI)
      --   - movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)
      
      --   - movkind 15 mov. entrata recuperi diretti (fase LORDI)  
      --   - movkind 16 mov. spesa recuperi diretti (negativi) (fase LORDI)

   
SELECT * FROM f_compute_csa_lordi_partition (@ayear, @idcsa_import)
 return

 /*
DECLARE @idreg_csa  int
DECLARE @idregauto  int
DECLARE @idfinincome_gross_csa int
DECLARE @idsiopeincome_csa int

DECLARE @csa_flaggroupby_income char(1)
DECLARE @csa_flaggroupby_expense char(1)

DECLARE @flagbalance_csa char(1)
DECLARE @csa_flaglinktoexp char(1)

DECLARE @yimportstr varchar(10)
DECLARE @nimportstr varchar(10)

DECLARE @description varchar(150)

SELECT @yimportstr = CONVERT(varchar(10),yimport),@nimportstr = convert(varchar(10),nimport) 
,@description = description 
FROM  csa_import WHERE idcsa_import = @idcsa_import

SELECT 
	@idreg_csa = idreg_csa,
	@idregauto = idregauto,
	@idfinincome_gross_csa = idfinincome_gross_csa ,
	--@flagdirectcsaclawback = flagdirectcsaclawback
	@csa_flaggroupby_income	 = csa_flaggroupby_income,
	@csa_flaggroupby_expense = csa_flaggroupby_expense,
	@idsiopeincome_csa = idsiopeincome_csa,
	@flagbalance_csa = flagbalance_csa,
	@csa_flaglinktoexp = csa_flaglinktoexp
FROM config
WHERE ayear = @ayear
 
------------------------------------------------------
-- COMPENSAZIONE DELLE VOCI CSA NEL FILE VERSAMENTI --
------------------------------------------------------


CREATE TABLE #automov
(	kind char(1), --E/S
	idriep int,
	idver int,
	ndetail int,
	parentidexp int, 
	idman int,
	idreg int,
	idfin int,
	idsor_siope int,
	idupb varchar(36),
	amount decimal(19,2),
	movkind	int,
	description varchar(200),
	idcsa_contractkind int,
	idcsa_contract int,
	idacc varchar(36),
	idcsa_agency int,
	idunderwriting int,
	vocecsa varchar(200),
	opposite_amount decimal(19,2),
	toignore char(1)
	)


-----------------------------------------------
------------I LORDI COSTI E RICAVI ------------
-----------------------------------------------

-- FASE Ia) generazione dei movimenti finanziari di spesa per il COSTO dei LORDI (righe positive)

-- imputazione UPB/Voce di bilancio   movkind 3
INSERT INTO #automov
(	kind,idriep,ndetail, idreg,idfin,parentidexp,idsor_siope,idupb,amount,movkind,description,idcsa_contractkind ,idcsa_contract,idunderwriting )
SELECT
	'S', P.idriep,P.ndetail,
	ISNULL(csa_importriep.idreg, @idreg_csa),  -- prenderò la modalità di pagamento predefinita per tale anagrafica
	P.idfin, P.idexp,	csa_importriep.idsor_siope,	P.idupb,
	P.amount,
	3,
	substring('Lordi ' + 'Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150),
	csa_importriep.idcsa_contractkind ,	csa_importriep.idcsa_contract,	csa_importriep.idunderwriting 
FROM 	csa_importriep_partition P
	join csa_importriep on csa_importriep.idcsa_import=P.idcsa_import and csa_importriep.idriep=P.idriep
	JOIN	csa_import 		on csa_import.idcsa_import = P.idcsa_import
WHERE    	P.idcsa_import = @idcsa_import	AND P.amount > 0  AND (P.idfin IS NOT NULL ) 

-- FASE Ib) generazione dei movimenti finanziari di entrata  di RICAVO per i LORDI (righe negative e imputazione normale)  movkind 7
INSERT INTO #automov
(	kind, idriep,ndetail, idreg,	idfin,	idsor_siope,	idupb,	amount,	movkind,	description,	idcsa_contractkind,	idcsa_contract )
SELECT  'E', P.idriep,P.ndetail, 	ISNULL(csa_importriep.idreg, @idreg_csa),	@idfinincome_gross_csa,	@idsiopeincome_csa,
	P.idupb,
	- P.amount,	7,
	substring('Ricavo Lordi ' + ' Import. Stipendi   n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150),
	idcsa_contractkind,	idcsa_contract
FROM csa_importriep_partition P 
		join csa_importriep on csa_importriep.idcsa_import=P.idcsa_import and csa_importriep.idriep=P.idriep
WHERE    	P.idcsa_import = @idcsa_import
			AND @idfinincome_gross_csa IS NOT NULL	AND	P.amount < 0	AND (P.idfin IS NOT NULL )	--

if (@csa_flaggroupby_expense='S')  -- valorizzo la descr. con il contratto o, in alternativa, il tipo contratto
BEGIN

UPDATE 	#automov 
SET 	#automov.description = SUBSTRING(#automov.description + ' Contr. ' + csa_contract.description,1,150)
FROM 	csa_contract 
WHERE   #automov.movkind = 3  and #automov.kind='S'
		AND csa_contract.idcsa_contract = #automov.idcsa_contract
		AND csa_contract.idcsa_contract is not null 	AND csa_contract.ayear = @ayear

UPDATE 	#automov 
SET 	#automov.description = SUBSTRING(#automov.description + ' Tipo contr. ' + csa_contractkind.description,1,150)
FROM  	csa_contractkindyear
JOIN  	csa_contractkind 
	ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
WHERE  #automov.movkind = 3   and #automov.kind='S'
	AND csa_contractkindyear.idcsa_contractkind = #automov.idcsa_contractkind 
	AND #automov.idcsa_contract is  null  
	AND #automov.idcsa_contractkind is  not null	AND csa_contractkindyear.ayear = @ayear
END

------------------------------------------------------------------------------- 

if (@csa_flaggroupby_income='S')  -- valorizzo la descr. con il contratto o, in alternativa, il tipo contratto
BEGIN

UPDATE 	#automov 
SET 	#automov.description = SUBSTRING(#automov.description +    ' Contr. ' + csa_contract.description,1,150)
FROM 	csa_contract 
WHERE   #automov.movkind = 7  and #automov.kind='E'
	AND csa_contract.idcsa_contract = #automov.idcsa_contract
	AND csa_contract.idcsa_contract is not null		AND csa_contract.ayear = @ayear

UPDATE 	#automov 
SET 	#automov.description = SUBSTRING(#automov.description + ' Tipo contr. ' + csa_contractkind.description,1,150)
FROM  	csa_contractkindyear
JOIN  	csa_contractkind 	ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
WHERE  #automov.movkind = 7  and #automov.kind='E'
	AND csa_contractkindyear.idcsa_contractkind = #automov.idcsa_contractkind 
	AND #automov.idcsa_contract is  null  
	AND #automov.idcsa_contractkind is  not null		AND csa_contractkindyear.ayear = @ayear

END

----------------------------------------------------------- 
------------ IV -RECUPERI ---------------------------------
----------------------------------------------------------- 

	-- Generazione dei movimenti finanziari di entrata per RECUPERI POSITIVI  movkind 15  (tutti i recuperi sono diretti)
	INSERT INTO #automov
		(kind,P.idver,P.ndetail,idreg,	idfin,idsor_siope,	idupb,amount,movkind,description,
			idacc,	idcsa_agency,
			idcsa_contractkind,idcsa_contract,	vocecsa )
	SELECT	'E',P.idver,P.ndetail, ISNULL(csa_importver.idreg, @idreg_csa),	idfin_incomeclawback,	idsor_siope_incomeclawback,
	P.idupb,  P.amount,	15,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Incasso Recuperi '  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Incasso Recuperi' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	null,	null,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')		WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P -- RECUPERI ENTE INTERNO
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
WHERE   P.idcsa_import = @idcsa_import and  P.amount> 0	
		AND	ISNULL(flagclawback,'N') = 'S'
		AND (	 idfin_incomeclawback IS NOT NULL 	)	--(ISNULL(flagdirectcsaclawback,'N')= 'S' AND )
	
-- Generazione dei movimenti finanziari di SPESA per COSTO RECUPERI  NEGATIVI  movkind 16 (tutti i recuperi sono diretti)
	INSERT INTO #automov
	(kind,idver, ndetail, idreg,	idfin,parentidexp,idsor_siope,idupb,amount,movkind,	description,
		idacc,idcsa_agency,
		idcsa_contractkind,idcsa_contract,	vocecsa )
SELECT 'S', P.idver,P.ndetail,ISNULL(csa_importver.idreg, @idreg_csa),P.idfin,P.idexp,	idsor_siope_cost,
	P.idupb,  -P.amount,	16,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Rimborso Recuperi' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	null,	null,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P -- RECUPERI ENTE INTERNO
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
WHERE   P.idcsa_import = @idcsa_import  AND P.amount < 0
		AND	ISNULL(flagclawback,'N') = 'S' 
		 AND P.idfin IS NOT NULL			--AND ISNULL(flagdirectcsaclawback,'N')= 'S' (tutti i recuperi sono diretti)


----------------------------------------------------------- 
------------ V --RITENUTE POSITIVE ---------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di entrata per RITENUTE 
-- Movimenti su anagrafica @idreg_csa IMPORTI POSITIVI   movkind 1
 
INSERT INTO #automov
(kind, idver,ndetail,idreg,	idfin,idsor_siope,idupb,amount,movkind,description,
		idacc,idcsa_agency,
		idcsa_contractkind,	idcsa_contract,	vocecsa )
SELECT 'E',P.idver,P.ndetail,
	ISNULL(csa_importver.idreg, @idreg_csa),  --applicazione ritenute
	idfin_income,	idsor_siope_income,
	'0001',	P.amount,	1,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Ritenute/Contributi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Ritenute/Contributi' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	idacc_expense,  -- debito VS erario
	idcsa_agency,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P 
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
WHERE   P.idcsa_import = @idcsa_import AND	ISNULL(flagclawback,'N') <> 'S'
		AND P.amount > 0	AND P.idfin IS NULL 	
		--AND (idfin_income IS NOT NULL) 


----------------------------------------------------------- 
------------ VI --RITENUTE  NEGATIVE ------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di spesa per 
-- RITENUTE Movimenti su anagrafica @idreg_csa ad IMPORTI NEGATIVI	movkind 8

INSERT INTO #automov
(kind, idver,ndetail, 	idreg,	idfin,	idsor_siope,	idupb,	amount,	movkind,	description,	
	idacc,	idcsa_agency,
	idcsa_contractkind,	idcsa_contract,	vocecsa
)
SELECT 'S', P.idver,P.ndetail,
	ISNULL(csa_importver.idreg, @idreg_csa), --applicazione ritenute
	idfin_expense, idsor_siope_expense,	'0001',	-P.amount,	8,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Ritenute ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Rimborso Ritenute' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	idacc_agency_credit,  -- credito VS erario, 
	idcsa_agency,	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P 
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
WHERE    P.idcsa_import = @idcsa_import AND P.amount < 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (P.idfin IS NULL )  -- non è un contributo ma una ritenuta
			--AND (idfin_income IS NOT NULL OR idfin_incomeclawback IS NOT NULL) 


--IF ISNULL(@flagbalance_csa,'N') = 'S'
--BEGIN
--	--------------------------------------------------
--	---- INIZIO GESTIONE COMPENSAZIONE LORDI----------
--	--------------------------------------------------
--	----  COMPENSA COSTI E RICAVI PER LORDI ----------
--	-------------------------------------------------- 
--	UPDATE #automov SET opposite_amount =(SELECT SUM(amount) FROM   #automov
--	WHERE movkind = 7 and kind='E' and #automov.idcsa_contractkind = #automov.idcsa_contractkind
--	AND  #automov.idcsa_contract = #automov.idcsa_contract)
--	WHERE movkind = 3 

--	UPDATE #automov SET opposite_amount =(SELECT SUM(amount) FROM   #automov
--	WHERE movkind = 3 and kind='S' and #automov.idcsa_contractkind = #automov.idcsa_contractkind
--	AND  #automov.idcsa_contract = #automov.idcsa_contract)
--	WHERE movkind = 7   


--	UPDATE   #automov SET toignore = 'S' WHERE movkind = 3 AND 	ISNULL(amount,0) - ISNULL(opposite_amount,0) <= 0

--	UPDATE  #automov SET toignore = 'S' WHERE movkind = 7 AND  	ISNULL(amount,0) - ISNULL(opposite_amount,0) <= 0
--	--------------------------------------------------
--	------- FINE GESTIONE COMPENSAZIONE LORDI---------
--	--------------------------------------------------
	
--END

SELECT 
	#automov.idriep,
	#automov.idver,
	#automov.ndetail,
	CASE 
	     WHEN #automov.movkind IN (3,8,16) THEN 'Spesa'
	     WHEN #automov.movkind IN (1,7,15) THEN 'Entrata' 
	END as kind,
	#automov.movkind,
	#automov.parentidexp,
	#automov.idman,
	#automov.idreg,
	R.title AS registry,
	idcsa_agency as idcsa_agency,
	null as idcsa_agencypaymethod,
	#automov.idfin,
	F.codefin,
	#automov.idsor_siope as idsor,
	S.sortcode,
	S2.idsor as parentidsor,
	S2.sortcode as parentsortcode,
	#automov.idupb as idupb,
	U.codeupb, 
	#automov.description,
	#automov.idacc,
	A.codeacc,
	ISNULL(#automov.amount,0) - ISNULL(#automov.opposite_amount,0) as amount,
    #automov.idcsa_contractkind,
    #automov.idcsa_contract,
    #automov.idunderwriting,
	UN.codeunderwriting,
	#automov.vocecsa
FROM #automov 
LEFT OUTER JOIN registry R 	ON R.idreg = #automov.idreg
LEFT OUTER JOIN fin F 	ON F.idfin = #automov.idfin
LEFT OUTER JOIN upb U 	ON U.idupb = #automov.idupb
LEFT OUTER JOIN account A 	ON A.idacc = #automov.idacc
LEFT OUTER JOIN sorting S 	ON S.idsor = #automov.idsor_siope
left outer join sortingkind SK  	on S.idsorkind=SK.idsorkind
left outer join sorting S2  	on S2.sortcode=S.sortcode and S2.idsorkind=SK.idparentkind
LEFT OUTER JOIN underwriting UN ON UN.idunderwriting = #automov.idunderwriting

ORDER BY  R.title,F.codefin, U.codeupb, A.idacc
*/
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO 


 