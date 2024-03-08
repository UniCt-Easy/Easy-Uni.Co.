
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[f_compute_csa_versamenti_posticipati]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function [f_compute_csa_versamenti_posticipati]
GO
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- setuser 'amministrazione'
---- select * from csa_import where yimport = 2018
---- select * from [f_compute_csa_versamenti_posticipati](2018,51)
CREATE  FUNCTION [f_compute_csa_versamenti_posticipati]
(
 	@ayear	      int,
	@idcsa_import int
)
RETURNS @result TABLE (	idcsa_import int,idriep int,  idver int, ndetail int, kind varchar(20), movkind int , parentidinc int, parentidexp int , 	parent_phase int,
idman int,  idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200))  
 
AS BEGIN

  --   + movkind 4 mov. spesa contributi/ritenute (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
  --   - movkind 10 mov. entrata di ricavo contributi (negativi) ( VERSAMENTI se liquidazione diretta)
  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)
  
        
DECLARE @csa_flaggroupby_income char(1)
DECLARE @csa_flaggroupby_expense char(1)
DECLARE @flagbalance_csa char(1)
DECLARE @csa_flaglinktoexp char(1)

DECLARE @residualphase_exp INT 
SET @residualphase_exp= (select max(nphase) from expensephase) -1

DECLARE @residualphase_inc INT 
SET @residualphase_inc =( select max(nphase) from incomephase) -1

--print @residualphase_exp
--print @residualphase_inc

SELECT 
	@csa_flaggroupby_income	 = csa_flaggroupby_income,
	@csa_flaggroupby_expense = csa_flaggroupby_expense,
	@flagbalance_csa = flagbalance_csa,				--COMPENSA INCASSI CON PAGAMENTI
	@csa_flaglinktoexp = csa_flaglinktoexp
FROM config
WHERE ayear = @ayear

--DECLARE @yimportstr varchar(10)
--DECLARE @nimportstr varchar(10)
--DECLARE @description varchar(150)
--SELECT  @yimportstr = CONVERT(varchar(10),yimport),@nimportstr = convert(varchar(10),nimport),@description = description  FROM  csa_import WHERE idcsa_import = @idcsa_import

	
DECLARE  @automov AS TABLE
(	idcsa_import int,
	kind char(1),
	idriep int,
	idver int,
	ndetail int,
	parentidexp int, 
	parentidinc int, 
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
	idcsa_agency int,
	idcsa_agencypaymethod int,
	idacc varchar(36),
	idunderwriting int,
	vocecsa	varchar(200)
)



--------------------------------------------------------------------
------------I VERSAMENTI CONTRIBUTI RITENUTE E RECUPERI-------------
--------------------------------------------------------------------
--   + movkind 4 mov. spesa contributi/ritenute/recuperi (fase VERSAMENTI)  (anche versamento contributi su liq. diretta)
--   generazione dei movimenti finanziari di spesa per il versamento di 
--   CONTRIBUTI E RITENUTE con transito da partite di giro
		-- generazione dei movimenti finanziari di spesa per il versamento di CONTRIBUTI   positivi
		-- A LIQUIDAZIONE DIRETTA	movkind 4		(la liq. è sempre diretta)
		INSERT INTO @automov
		(	idcsa_import,kind, idver,ndetail, parentidexp, 	idreg,	idfin, idsor_siope,	idupb,
			amount,	movkind,	description,
			idacc,	idcsa_agency,	idcsa_agencypaymethod,
			idcsa_contractkind,idcsa_contract,	idunderwriting,		vocecsa
		)
		SELECT P.idcsa_import,'S',P.idver,P.ndetail,expense.idexp,
			idreg_agency,  -- modalità pagamento configurata per l'ente CSA di versamento
			expenseyear.idfin,	P.idsor_siope,
			expenseyear.idupb, -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			expensetotal.available,			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamenti Contributi(pos.)'+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Versamenti Contributi(pos.)' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
			idacc_expense, -- debito verso erario lo riattualizzo alla fine  nell'esercizio corrente
			csa_agency.idcsa_agency,	idcsa_agencypaymethod,idcsa_contractkind,	idcsa_contract,	idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N') WHEN  'S' THEN vocecsa  ELSE  null END
		FROM csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			join csa_importver_partition_expense PE  on PE.idcsa_import=P.idcsa_import and PE.idver=P.idver
			JOIN expense   ON PE.idexp = expense.idexp  
			JOIN expenseyear ON expense.idexp = expenseyear.idexp AND expenseyear.ayear =  @ayear +1
			JOIN expensetotal ON expenseyear.idexp = expensetotal.idexp AND expenseyear.ayear =  expensetotal.ayear
		WHERE   
			csa_import.yimport = @ayear  AND
		   ((ISNULL(csa_agency.flag,0) & 1) <> 0)
	 
			AND P.amount > 0 AND expensetotal.available > 0
			AND	ISNULL(flagclawback,'N') <> 'S'		--non recuperi
			AND (idcsa_contractkinddata IS NOT NULL OR idcsa_contracttax IS NOT NULL )
			AND expense.autokind in (20,21,30,31)
			AND PE.movkind = 4
			AND expense.nphase  =  @residualphase_exp

		-- CONTRIBUTI A LIQUIDAZIONE DIRETTA IN CUI E' STATO SCELTO UN MOVIMENTO FINANZIARIO COSTO DI FASE PARI ALLA PENULTIMA
		INSERT INTO @automov
		(	idcsa_import,kind, idver,ndetail, parentidexp, 	idreg,	idfin, idsor_siope,	idupb,
			amount,	movkind,	description,
			idacc,	idcsa_agency,	idcsa_agencypaymethod,
			idcsa_contractkind,idcsa_contract,	idunderwriting,		vocecsa
		)
		SELECT P.idcsa_import,'S',P.idver,P.ndetail,expense.idexp,
			idreg_agency,  -- modalità pagamento configurata per l'ente CSA di versamento
			expenseyear.idfin,	P.idsor_siope,
			expenseyear.idupb, -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			expensetotal.available,			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamenti Contributi(pos.)'+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Versamenti Contributi(pos.)' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
			idacc_expense, -- debito verso erario lo riattualizzo alla fine  nell'esercizio corrente
			csa_agency.idcsa_agency,	idcsa_agencypaymethod,idcsa_contractkind,	idcsa_contract,	idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N') WHEN  'S' THEN vocecsa  ELSE  null END
		FROM csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			JOIN expense   ON csa_importver.idexp_cost = expense.idexp  
			JOIN expenseyear ON expense.idexp = expenseyear.idexp AND expenseyear.ayear =  @ayear +1
			JOIN expensetotal ON expenseyear.idexp = expensetotal.idexp AND expenseyear.ayear =  expensetotal.ayear
		WHERE   
			csa_import.yimport = @ayear  AND
		   ((ISNULL(csa_agency.flag,0) & 1) <> 0)
	 
			AND P.amount > 0 AND expensetotal.available > 0
			AND	ISNULL(flagclawback,'N') <> 'S'		--non recuperi
			AND (idcsa_contractkinddata IS NOT NULL OR idcsa_contracttax IS NOT NULL )
			AND expense.autokind is null
			AND expense.nphase  =  @residualphase_exp

		-- generazione dei movimenti finanziari di spesa per il versamento di RITENUTE   positive
		-- movkind 4	 
	INSERT INTO @automov
		(idcsa_import,kind, idver,ndetail, parentidexp,idreg,idfin,idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_agencypaymethod,idcsa_contractkind,idcsa_contract,vocecsa)
		SELECT P.idcsa_import,'S',P.idver,P.ndetail,expense.idexp,
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			expenseyear.idfin,	idsor_siope_expense,
			expenseyear.idupb, -- '0001', --SEMPRE PER PARTITE DI GIRO
			expensetotal.available,		4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamenti Ritenute(pos.)'+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Versamenti Ritenute(pos.)' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
			idacc_expense, -- debito verso erario lo riattualizzo poi nell'esercizio corrente
			csa_agency.idcsa_agency,idcsa_agencypaymethod,	idcsa_contractkind,	idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
		FROM 	csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver 
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			join csa_importver_partition_expense PE  on PE.idcsa_import=P.idcsa_import and PE.idver=P.idver
			JOIN expense   ON PE.idexp = expense.idexp  
			JOIN expenseyear ON expense.idexp = expenseyear.idexp AND expenseyear.ayear =  @ayear +1
			JOIN expensetotal ON expenseyear.idexp = expensetotal.idexp AND expenseyear.ayear =  expensetotal.ayear
		WHERE   
			csa_import.yimport = @ayear  AND ((ISNULL(csa_agency.flag,0) & 1) <> 0)
			AND P.amount > 0 AND expensetotal.available > 0
			AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS  NULL )
			AND ISNULL(csa_importver.flagclawback,'N') = 'N'  -- solo le ritenute
				AND expense.autokind in (20,21,30,31)
			AND PE.movkind = 4
			AND expense.nphase  =  @residualphase_exp
		

		-- FASE Id) fase  generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI negativi  movkind 10
		INSERT INTO @automov
		(	idcsa_import,kind, idver,ndetail, parentidinc, idreg,	idfin,	idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_contractkind,	idcsa_contract,	vocecsa	)
		SELECT	P.idcsa_import,'E',P.idver,P.ndetail,income.idinc,
			idreg_agency,  --anagrafica Erario
			incomeyear.idfin, 	idsor_siope_incomeclawback,
			incomeyear.idupb, 	incometotal.available ,			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Contributo(neg.)'+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Contributo(neg.)' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,

			idacc_agency_credit, --credito verso erario lo riattualizzo alla fine  nell'esercizio corrente
 			csa_agency.idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')WHEN  'S' THEN vocecsa  	ELSE  null	END
		FROM csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			join csa_importver_partition_income PE  on PE.idcsa_import=P.idcsa_import and PE.idver=P.idver
			JOIN  income   ON PE.idinc = income.idinc  
			JOIN  incomeyear ON income.idinc = incomeyear.idinc AND incomeyear.ayear =  @ayear +1
			JOIN  incometotal ON incomeyear.idinc = incometotal.idinc AND incomeyear.ayear =  incometotal.ayear
		WHERE  
		csa_import.yimport = @ayear  AND ((ISNULL(csa_agency.flag,0) & 1) <> 0)
	
			AND (idcsa_contractkinddata IS NOT NULL OR idcsa_contracttax IS NOT NULL )
			AND ( P.amount < 0) AND 	incometotal.available > 0
			AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi
			AND income.autokind in (20,21,30,31)
			AND PE.movkind = 10
			AND income.nphase  =  @residualphase_inc
		-- Generazione dei movimenti finanziari di entrata per l'INCASSO di RITENUTE  (negative)  movkind 9
INSERT INTO @automov
(	idcsa_import,kind,idver,ndetail,parentidinc,idreg,idfin,idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_contractkind,idcsa_contract,vocecsa )
SELECT P.idcsa_import,'E',P.idver,P.ndetail,income.idinc,
	idreg_agency,  --anagrafica Ente CSA
	incomeyear.idfin, idsor_siope_income,
	incomeyear.idupb,	incometotal.available ,	9,
 
	CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ritenute(neg.)'+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Ritenute(neg.)' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
	idacc_agency_credit, --credito verso erario lo riattualizzo alla fine  nell'esercizio corrente
 	csa_agency.idcsa_agency,	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N') WHEN  'S' THEN vocecsa  ELSE  null	END
FROM  csa_importver_partition P 
	  join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
	  join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
	  join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
	  join csa_importver_partition_income PE  on PE.idcsa_import=P.idcsa_import and PE.idver=P.idver
	  JOIN  income   ON PE.idinc = income.idinc  
	  JOIN  incomeyear ON income.idinc = incomeyear.idinc AND incomeyear.ayear =  @ayear +1
	  JOIN  incometotal ON incomeyear.idinc = incometotal.idinc AND incomeyear.ayear =  incometotal.ayear
WHERE  
	 csa_import.yimport = @ayear AND ((ISNULL(csa_agency.flag,0) & 1) <> 0)
 
	AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS NULL )
	AND P.amount < 0
	AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi
	AND income.autokind in (20,21,30,31)
	AND PE.movkind = 9
	AND income.nphase  =  @residualphase_inc  
 
  INSERT INTO @result	 
SELECT 
	T.idcsa_import,
	T.idriep,
	T.idver,
	T.ndetail,
	CASE 
	     WHEN T.movkind = 4 THEN 'Spesa'
	     WHEN T.movkind IN (10,9) THEN 'Entrata' 
	END as kind,
	T.movkind,
	T.parentidinc as parentidinc,
	T.parentidexp as parentidexp,
	E.nphase as parent_phase,
	T.idman,
	T.idreg,
	R.title AS registry,
	idcsa_agency,
	idcsa_agencypaymethod,
	T.idfin,
	F.codefin,
	T.idsor_siope as idsor,
	S.sortcode,
	S2.idsor as parentidsor,
	S2.sortcode as parentsortcode,
	ISNULL(T.idupb,'0001') as idupb,
	U.codeupb, 
	T.description,
	AL.newidacc,
	ANEW.codeacc,
	ISNULL(amount,0) as amount,
	T.idcsa_contractkind,
	T.idcsa_contract,
	T.idunderwriting,
	UN.codeunderwriting,
	T.vocecsa
FROM @automov  T
LEFT OUTER JOIN registry R 	ON R.idreg = T.idreg
LEFT OUTER JOIN expense E 	ON E.idexp = T.parentidexp
LEFT OUTER JOIN fin F		ON F.idfin = T.idfin
LEFT OUTER JOIN upb U		ON U.idupb = T.idupb
LEFT OUTER JOIN account A	ON A.idacc = T.idacc
LEFT OUTER JOIN sorting S	ON S.idsor = idsor_siope
left outer join sortingkind SK 	on S.idsorkind=SK.idsorkind
left outer join sorting S2		on S2.sortcode=S.sortcode and S2.idsorkind=SK.idparentkind
LEFT OUTER JOIN underwriting UN	ON UN.idunderwriting = T.idunderwriting
JOIN accountlookup AL on A.idacc=AL.oldidacc
JOIN account ANEW on ANEW.idacc=AL.newidacc
ORDER BY  R.title,F.codefin, U.codeupb, A.idacc

RETURN
END


GO


