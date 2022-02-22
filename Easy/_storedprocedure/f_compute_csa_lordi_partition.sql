
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


if exists (select * from dbo.sysobjects where id = object_id(N'[f_compute_csa_lordi_partition]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function f_compute_csa_lordi_partition
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm'
--setuser'amministrazione'
CREATE  FUNCTION  [f_compute_csa_lordi_partition] (	@ayear	      int,
	@idcsa_import int)
   RETURNS @result TABLE (idcsa_import int,idriep int , idver int ,ndetail int, kind varchar(20), movkind int , parentidinc int, parentidexp int , 	parent_phase int,
 idman int, idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)) AS
 
      --   + movkind 1 mov. entrata ritenute	 (fase LORDI)
      --   - movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)      
      
      --   + movkind 3 mov. spesa costo  lordi (fase LORDI)
      --   - movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)
      
      --   - movkind 15 mov. entrata recuperi diretti (fase LORDI)  
      --   - movkind 16 mov. spesa recuperi diretti (negativi) (fase LOR

   BEGIN
 
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


DECLARE @idacc_supplier varchar(38)
DEClARE @idacc_customer varchar(38)
SELECT 
	@idreg_csa = idreg_csa,
	@idregauto = idregauto,
	@idfinincome_gross_csa = idfinincome_gross_csa ,
	--@flagdirectcsaclawback = flagdirectcsaclawback
	@csa_flaggroupby_income	 = csa_flaggroupby_income,
	@csa_flaggroupby_expense = csa_flaggroupby_expense,
	@idsiopeincome_csa = idsiopeincome_csa,
	@flagbalance_csa = flagbalance_csa,
	@csa_flaglinktoexp = csa_flaglinktoexp,
	@idacc_supplier=idacc_supplier,		--x debito
	@idacc_customer=idacc_customer		--x credito
FROM config
WHERE ayear = @ayear
 


DECLARE  @automov TABLE
(
	kind char(1), --E/S
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

-- FASE Ia) generazione dei movimenti finanziari di SPESA per il COSTO dei LORDI (righe positive)

-- imputazione UPB/Voce di bilancio   movkind 3
INSERT INTO @automov
(	kind,idriep,ndetail, idreg,idfin,parentidexp,idsor_siope,idupb,amount,movkind,description,idcsa_contractkind ,idcsa_contract,idunderwriting,idacc )
SELECT
	'S', P.idriep,P.ndetail,
	ISNULL(csa_importriep.idreg, @idreg_csa),  -- prenderò la modalità di pagamento predefinita per tale anagrafica
	P.idfin, P.idexp,	P.idsor_siope,	P.idupb,
	P.amount,
	3,
	substring('Lordi (pos.)' + 'Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150),
	csa_importriep.idcsa_contractkind ,	csa_importriep.idcsa_contract,	csa_importriep.idunderwriting,
	isnull(AD.idacc, @idacc_supplier)		--debito
FROM 	csa_importriep_partition P
	join csa_importriep on csa_importriep.idcsa_import=P.idcsa_import and csa_importriep.idriep=P.idriep
	JOIN	csa_import 		on csa_import.idcsa_import = P.idcsa_import
	left outer  JOIN registry R on R.idreg=ISNULL(csa_importriep.idreg, @idreg_csa)
	left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivedebit and AD.ayear= @ayear	--debito
WHERE    	P.idcsa_import = @idcsa_import	AND P.amount > 0  

-- FASE Ib) generazione dei movimenti finanziari di entrata  di RICAVO per i LORDI (righe negative e imputazione normale)  movkind 7
INSERT INTO @automov
(	kind, idriep,ndetail, idreg,	idfin,	idsor_siope,	idupb,	amount,	movkind,	description,	idcsa_contractkind,	idcsa_contract ,idacc)
SELECT  'E', P.idriep,P.ndetail, 	ISNULL(csa_importriep.idreg, @idreg_csa),	@idfinincome_gross_csa,	@idsiopeincome_csa,
	 P.idupb,
	- P.amount,	7,
	substring('Lordo (neg.) ' + ' Import. Stipendi   n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150),
	idcsa_contractkind,	idcsa_contract,
	isnull(AD.idacc, @idacc_customer)		--credito
FROM csa_importriep_partition P 
		join csa_importriep on csa_importriep.idcsa_import=P.idcsa_import and csa_importriep.idriep=P.idriep
		left outer  JOIN registry R on R.idreg=ISNULL(csa_importriep.idreg, @idreg_csa)
		left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivecredit and AD.ayear= @ayear		--credito
WHERE    	P.idcsa_import = @idcsa_import
			AND	P.amount < 0	




if (@csa_flaggroupby_expense='S')  -- valorizzo la descr. con il contratto o, in alternativa, il tipo contratto
BEGIN

UPDATE 	@automov 
SET 	[@automov].description = SUBSTRING([@automov].description + ' Contr. ' + csa_contract.description,1,150)
FROM 	csa_contract 
WHERE   movkind = 3  and kind='S'
		AND csa_contract.idcsa_contract = [@automov].idcsa_contract
		AND csa_contract.idcsa_contract is not null 	AND csa_contract.ayear = @ayear

UPDATE 	@automov 
SET 	[@automov].description = SUBSTRING([@automov].description + ' Tipo contr. ' + csa_contractkind.description,1,150)
FROM  	csa_contractkindyear
JOIN  	csa_contractkind 
	ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
WHERE  movkind = 3   and kind='S'
	AND csa_contractkindyear.idcsa_contractkind = [@automov].idcsa_contractkind 
	AND [@automov].idcsa_contract is  null  
	AND [@automov].idcsa_contractkind is  not null	AND csa_contractkindyear.ayear = @ayear
END

------------------------------------------------------------------------------- 

if (@csa_flaggroupby_income='S')  -- valorizzo la descr. con il contratto o, in alternativa, il tipo contratto
BEGIN

	UPDATE 	@automov 
	SET 	[@automov].description = SUBSTRING([@automov].description +    ' Contr. ' + csa_contract.description,1,150)
	FROM 	csa_contract 
	WHERE   movkind = 7  and kind='E'
		AND csa_contract.idcsa_contract = [@automov].idcsa_contract
		AND csa_contract.idcsa_contract is not null		AND csa_contract.ayear = @ayear

	UPDATE 	@automov 
	SET 	[@automov].description = SUBSTRING([@automov].description + ' Tipo contr. ' + csa_contractkind.description,1,150)
	FROM  	csa_contractkindyear
	JOIN  	csa_contractkind 	ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
	WHERE   movkind = 7  and kind='E'
		AND csa_contractkindyear.idcsa_contractkind = [@automov].idcsa_contractkind 
		AND [@automov].idcsa_contract is  null  
		AND [@automov].idcsa_contractkind is  not null		AND csa_contractkindyear.ayear = @ayear

END



----------------------------------------------------------- 
------------ IV -RECUPERI ---------------------------------
----------------------------------------------------------- 

	-- Generazione dei movimenti finanziari di entrata per RECUPERI POSITIVI  movkind 15  (tutti i recuperi sono diretti)
	INSERT INTO @automov
		(kind,P.idver,P.ndetail,idreg,	idfin,idsor_siope,	idupb,amount,movkind,description,
			idacc,	idcsa_agency,
			idcsa_contractkind,idcsa_contract,	vocecsa )
	SELECT	'E',P.idver,P.ndetail, ISNULL(csa_importver.idreg, @idreg_csa),	idfin_incomeclawback,	idsor_siope_incomeclawback,
	P.idupb,  P.amount,	15,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Recuperi (pos.)'  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Recuperi (pos.)' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	isnull(AD.idacc, @idacc_customer),		--credito
	null,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')		WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P -- RECUPERI ENTE INTERNO
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
		left outer  JOIN registry R on R.idreg=ISNULL(csa_importver.idreg, @idreg_csa)
		left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivecredit and AD.ayear= @ayear		--credito
WHERE   P.idcsa_import = @idcsa_import and  P.amount> 0	
		AND	ISNULL(flagclawback,'N') = 'S'
	
-- Generazione dei movimenti finanziari di SPESA per COSTO RECUPERI  NEGATIVI  movkind 16 (tutti i recuperi sono diretti)
	INSERT INTO @automov
	(kind,idver, ndetail, idreg,	idfin,parentidexp,idsor_siope,idupb,amount,movkind,	description,
		idacc,idcsa_agency,
		idcsa_contractkind,idcsa_contract,	vocecsa )
SELECT 'S', P.idver,P.ndetail,ISNULL(csa_importver.idreg, @idreg_csa),P.idfin,P.idexp,	P.idsor_siope,
	P.idupb,  -P.amount,	16,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Recuperi(neg.)' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Rimborso Recuperi(neg.)' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
		isnull(AD.idacc, @idacc_supplier),		--debito
		null,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P -- RECUPERI ENTE INTERNO
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
		left outer  JOIN registry R on R.idreg=ISNULL(csa_importver.idreg, @idreg_csa)
		left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivedebit and AD.ayear= @ayear	--debito
WHERE   P.idcsa_import = @idcsa_import  AND P.amount < 0
		AND	ISNULL(flagclawback,'N') = 'S' 	 


-------------------------------------------------------------------- 
------------ V --RITENUTE POSITIVE ---------------------------------
-------------------------------------------------------------------- 
-- Generazione dei movimenti finanziari di ENTRATA per RITENUTE 
-- Movimenti su anagrafica @idreg_csa IMPORTI POSITIVI   movkind 1
 
INSERT INTO @automov
		(kind, idver,ndetail,idreg,	idfin,idsor_siope,idupb,amount,movkind,description,
		idacc,
		idcsa_agency,
		idcsa_contractkind,	idcsa_contract,	vocecsa )
SELECT 'E',P.idver,P.ndetail,
	ISNULL(csa_importver.idreg, @idreg_csa),  --applicazione ritenute
	idfin_income,	idsor_siope_income,
	'0001',	P.amount,	1,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Ritenuta(pos.)' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Ritenuta(pos.)' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	isnull(AD.idacc, @idacc_customer),		--credito		ERA: idacc_expense,  -- debito VS erario	
	idcsa_agency,
	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P 
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
		left outer  JOIN registry R on R.idreg=ISNULL(csa_importver.idreg, @idreg_csa)
		left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivecredit and AD.ayear= @ayear		--credito
		WHERE   P.idcsa_import = @idcsa_import AND	ISNULL(flagclawback,'N') <> 'S'
		AND P.amount > 0	AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS NULL )


----------------------------------------------------------- 
------------ VI --RITENUTE  NEGATIVE ------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di spesa per 
-- RITENUTE Movimenti su anagrafica @idreg_csa ad IMPORTI NEGATIVI	movkind 8

INSERT INTO @automov
(kind, idver,ndetail, 	idreg,	idfin,	idsor_siope,	idupb,	amount,	movkind,	description,	
	idacc,	
	idcsa_agency,
	idcsa_contractkind,	idcsa_contract,	vocecsa
)
SELECT 'S', P.idver,P.ndetail,
	ISNULL(csa_importver.idreg, @idreg_csa), --applicazione ritenute
	idfin_expense, idsor_siope_expense,	'0001',	-P.amount,	8,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Ritenute(neg.) ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
		ELSE substring('Ritenute(neg.)' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+@description,1,150)
	END,
	isnull(AD.idacc, @idacc_supplier),		--debito		--ERA idacc_agency_credit,  -- credito VS erario, 
	idcsa_agency,	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
FROM 	csa_importver_partition P 
		join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
		left outer  JOIN registry R on R.idreg=ISNULL(csa_importver.idreg, @idreg_csa)
		left outer join accmotivedetail AD on AD.idaccmotive = R.idaccmotivedebit and AD.ayear= @ayear	--debito
WHERE    P.idcsa_import = @idcsa_import AND P.amount < 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS NULL )


 
 
  INSERT INTO @result

SELECT 
	@idcsa_import as 'idcsa_import',
	T.idriep,
	T.idver,
	T.ndetail,
  CASE 
	     WHEN T.movkind IN (3,2,12,14,16,8) THEN 'Spesa'
	     WHEN T.movkind IN (7,10,1,5,15) THEN 'Entrata' 
	END as kind,
	T.movkind,
	null as 'parentidinc',
	T.parentidexp,
	E.nphase as parent_phase,
	T.idman,
	T.idreg,
	R.title AS registry,
	idcsa_agency as idcsa_agency,
	null as idcsa_agencypaymethod,
	T.idfin,
	F.codefin,
	T.idsor_siope as idsor,
	S.sortcode,
	S2.idsor as parentidsor,
	S2.sortcode as parentsortcode,
	T.idupb as idupb,
	U.codeupb, 
	T.description,
	T.idacc,
	A.codeacc,
	ISNULL(T.amount,0) - ISNULL(T.opposite_amount,0) as amount,
    T.idcsa_contractkind,
    T.idcsa_contract,
    T.idunderwriting,
	UN.codeunderwriting,
	T.vocecsa
FROM @automov  T
LEFT OUTER JOIN registry R 	ON R.idreg = T.idreg
LEFT OUTER JOIN expense E 	ON E.idexp = T.parentidexp
LEFT OUTER JOIN fin F 	ON F.idfin = T.idfin
LEFT OUTER JOIN upb U 	ON U.idupb = T.idupb
LEFT OUTER JOIN account A 	ON A.idacc = T.idacc
LEFT OUTER JOIN sorting S 	ON S.idsor = T.idsor_siope
left outer join sortingkind SK  	on S.idsorkind=SK.idsorkind
left outer join sorting S2  	on S2.sortcode=S.sortcode and S2.idsorkind=SK.idparentkind
LEFT OUTER JOIN underwriting UN ON UN.idunderwriting = T.idunderwriting

ORDER BY  R.title,F.codefin, U.codeupb, A.idacc

return
END
 
    
 

