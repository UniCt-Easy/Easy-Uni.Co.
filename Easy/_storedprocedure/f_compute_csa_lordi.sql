
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[f_compute_csa_lordi]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function f_compute_csa_lordi
GO

 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE  FUNCTION  [f_compute_csa_lordi] (	@ayear	      int,
	@idcsa_import int)
   RETURNS @result TABLE (kind varchar(20), movkind int , parentidinc int , parentidexp int , idman int, idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)) AS
 
   -- Check if a table name has been passed
 
   
   
        --   + movkind 1 mov. entrata ritenute/contributi su partite di giro (fase LORDI)
      --   - movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)
      --   - movkind 12 mov. spesa contributi (negativi) con transito p. di giro (fase LORDI)

      --   + movkind 2 mov. spesa costo contributi  (fase LORDI)
      --   - movkind 10 mov. entrata ricavo contributi (negativi) (fase LORDI se su partita di giro  oppure VERSAMENTI se liquidazione diretta)
      
      --   + movkind 3 mov. spesa costo  lordi (fase LORDI)
      --   - movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)

      --   + movkind 5 mov. entrata recuperi su partite di giro (fase LORDI)
      --   - movkind 14 mov. spesa recuperi su partita di giro (negativi) (fase LORDI)
      --   - movkind 15 mov. entrata recuperi diretti (fase LORDI)  
      --   - movkind 16 mov. spesa recuperi diretti (negativi) (fase LORDI)

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

SELECT @yimportstr = CONVERT(varchar(10),yimport),@nimportstr = convert(varchar(10),nimport) FROM  csa_import WHERE idcsa_import = @idcsa_import

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

DECLARE  @csa_importver_balanced TABLE
(
	
	idcsa_import	int,
	idver	int,
	ruolocsa	varchar(200),
	capitolocsa	varchar(200),
	competenza	varchar(10),
	matricola	varchar(10),
	ente	varchar(200),
	vocecsa	varchar(200),
	importo	decimal(19,2),
	flagcr	char(1),
	ayear	smallint,
	idcsa_contractkind	int,
	idcsa_contract	int,
	idcsa_agency	int,
	idfin_income	int,
	idacc_debit	varchar(38),
	idfin_expense	int,
	idacc_expense	varchar(38),
	idfin_incomeclawback	int,
	idacc_internalcredit	varchar(38),
	idreg_agency	int,
	idcsa_agencypaymethod	int,
	idexp_cost	int,
	idfin_cost	int,
	idacc_cost	varchar(38),
	flagclawback	char(1),
	idreg	int,
	idcsa_contracttax	int,
	idcsa_contractkinddata	int,
	idcsa_incomesetup	int,
	lu	varchar(64),
	lt	datetime,
	idupb	varchar(36),
	idacc_revenue	varchar(38),
	competency	int,
	idacc_agency_credit	varchar(38),
	flagdirectcsaclawback	char(1),
	idsor_siope_income	int,
	idsor_siope_expense	int,
	idsor_siope_incomeclawback	int,
	idsor_siope_cost	int,
	idunderwriting	int,
	toignore char(1),
	opposite_amount decimal(19,2) 
)


INSERT INTO  @csa_importver_balanced
(
	idcsa_import,idver,
	ruolocsa,
	capitolocsa,
	competenza,
	matricola,
	ente,
	vocecsa,
	importo,
	flagcr,
	ayear,
	idcsa_contractkind,
	idcsa_contract,
	idcsa_agency,
	idfin_income,
	idacc_debit,
	idfin_expense,
	idacc_expense,
	idfin_incomeclawback,
	idacc_internalcredit,
	idreg_agency,
	idcsa_agencypaymethod,
	idexp_cost,
	idfin_cost,
	idacc_cost,
	flagclawback,
	idreg,
	idcsa_contracttax,
	idcsa_contractkinddata,
	idcsa_incomesetup,
	lu,
	lt,
	idupb,
	idacc_revenue,
	competency,
	idacc_agency_credit,
	flagdirectcsaclawback,
	idsor_siope_income,
	idsor_siope_expense,
	idsor_siope_incomeclawback,
	idsor_siope_cost,
	idunderwriting 
)
SELECT
	idcsa_import,idver,
	null,--ruolocsa,
	null,--capitolocsa,
	null,--competenza,
	null, --matricola,
	ente,
	isnull(vocecsaunified,vocecsa),
	sum(importo),
	flagcr,
	ayear,
	idcsa_contractkind,
	idcsa_contract,
	idcsa_agency,
	idfin_income,
	idacc_debit,
	idfin_expense,
	idacc_expense,
	idfin_incomeclawback,
	idacc_internalcredit,
	idreg_agency,
	idcsa_agencypaymethod,
	idexp_cost,
	idfin_cost,
	idacc_cost,
	flagclawback,
	idreg,
	CASE
	WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contracttax
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contractkinddata
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_incomesetup
	END,
	'assistenza',
	GetDate(),
	idupb,
	idacc_revenue,
	competency,
	idacc_agency_credit,
	flagdirectcsaclawback,
	idsor_siope_income,
	idsor_siope_expense,
	idsor_siope_incomeclawback,
	idsor_siope_cost,
	idunderwriting 
	FROM csa_importver  --- CONTRIBUTI
	WHERE idcsa_import = @idcsa_import 
								AND ISNULL(flagclawback,'N') <> 'S' 
								AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL  
										OR EXISTS 	(SELECT *  FROM csa_importver_expense
														WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
															AND csa_importver.idver = csa_importver_expense.idver
													)
									)	
	GROUP BY	
	idcsa_import, idver, ente,
	isnull(vocecsaunified,vocecsa),flagcr, ayear, idcsa_contractkind, idcsa_contract, idcsa_agency,
	idfin_income, idacc_debit, idfin_expense,idacc_expense,idfin_incomeclawback,
	idacc_internalcredit,idreg_agency,idcsa_agencypaymethod,idexp_cost,idfin_cost,
	idacc_cost,flagclawback,idreg, 	
	CASE
	WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contracttax
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contractkinddata
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_incomesetup
	END,
	idupb,idacc_revenue,competency,idacc_agency_credit,
	flagdirectcsaclawback, idsor_siope_income,idsor_siope_expense,
	idsor_siope_incomeclawback,idsor_siope_cost,idunderwriting 
 
INSERT INTO  @csa_importver_balanced
(
	idcsa_import,idver,
	ruolocsa,
	capitolocsa,
	competenza,
	matricola,
	ente,
	vocecsa,
	importo,
	flagcr,
	ayear,
	idcsa_contractkind,
	idcsa_contract,
	idcsa_agency,
	idfin_income,
	idacc_debit,
	idfin_expense,
	idacc_expense,
	idfin_incomeclawback,
	idacc_internalcredit,
	idreg_agency,
	idcsa_agencypaymethod,
	idexp_cost,
	idfin_cost,
	idacc_cost,
	flagclawback,
	idreg,
	idcsa_contracttax,
	idcsa_contractkinddata,
	idcsa_incomesetup,
	lu,
	lt,
	idupb,
	idacc_revenue,
	competency,
	idacc_agency_credit,
	flagdirectcsaclawback,
	idsor_siope_income,
	idsor_siope_expense,
	idsor_siope_incomeclawback,
	idsor_siope_cost,
	idunderwriting 
)
SELECT
	idcsa_import,idver,
	null,--ruolocsa,
	null,--capitolocsa,
	null,--competenza,
	null,--matricola
	ente,
	isnull(vocecsaunified,vocecsa),
	sum(importo),
	flagcr,
	ayear,
	idcsa_contractkind,
	idcsa_contract,
	idcsa_agency,
	idfin_income,
	idacc_debit,
	idfin_expense,
	idacc_expense,
	idfin_incomeclawback,
	idacc_internalcredit,
	idreg_agency,
	idcsa_agencypaymethod,
	idexp_cost,
	idfin_cost,
	idacc_cost,
	flagclawback,
	idreg,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contracttax
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contractkinddata
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_incomesetup
	END,
	'assistenza',
	GetDate(),
	idupb,
	idacc_revenue,
	competency,
	idacc_agency_credit,
	flagdirectcsaclawback,
	idsor_siope_income,
	idsor_siope_expense,
	idsor_siope_incomeclawback,
	idsor_siope_cost,
	idunderwriting 
	FROM csa_importver -- RECUPERI ENTE INTERNO
	WHERE  idcsa_import = @idcsa_import AND ISNULL(flagclawback,'N')  = 'S' 
	GROUP 	BY
	idcsa_import, idver, ente,
	isnull(vocecsaunified,vocecsa),flagcr, ayear, idcsa_contractkind, idcsa_contract, idcsa_agency,
	idfin_income, idacc_debit, idfin_expense,idacc_expense,idfin_incomeclawback,
	idacc_internalcredit,idreg_agency,idcsa_agencypaymethod,idexp_cost,idfin_cost,
	idacc_cost,flagclawback,idreg, 	CASE
	WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contracttax
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_contractkinddata
	END,
	CASE
		WHEN vocecsaunified IS NOT NULL THEN NULL
		ELSE idcsa_incomesetup
	END,
	idupb,idacc_revenue,competency,idacc_agency_credit,
	flagdirectcsaclawback, idsor_siope_income,idsor_siope_expense,
	idsor_siope_incomeclawback,idsor_siope_cost,idunderwriting 
	

DECLARE  @automov_exp_ungrouped TABLE
(
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
	vocecsa varchar(200)
	)

DECLARE  @automov_inc_ungrouped TABLE
(
	idreg int,
	idfin int,
	idsor_siope int,
	idupb varchar(36),
	amount decimal(19,2),
	movkind int,
	description varchar(200),
	idacc varchar(36),
	idcsa_contractkind int,
	idcsa_contract int,
	idcsa_agency int,
	idunderwriting int,
	vocecsa varchar(200)
)

-----------------------------------------------
------------I LORDI COSTI E RICAVI ------------
-----------------------------------------------

-- FASE Ia) generazione dei movimenti finanziari di spesa per il COSTO dei LORDI (righe positive e imputazione normale)

-- imputazione UPB/Voce di bilancio
INSERT INTO @automov_exp_ungrouped
(	parentidexp, 
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idcsa_contractkind ,
	idcsa_contract,
	idunderwriting 
)
SELECT
	NULL,
	@idreg_csa,  -- prenderò la modalità di pagamento predefinita per tale anagrafica
	csa_importriep.idfin,
	csa_importriep.idsor_siope,
	csa_importriep.idupb,
	csa_importriep.importo,
	3,
	substring('Lordi ' + 'Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+csa_import.description,1,150),
	csa_importriep.idcsa_contractkind ,
	csa_importriep.idcsa_contract,
	csa_importriep.idunderwriting 
FROM 	csa_importriep
	JOIN csa_import 
		on csa_import.idcsa_import = csa_importriep.idcsa_import
WHERE   
 	csa_importriep.idcsa_import = @idcsa_import
AND csa_importriep.importo > 0
AND (csa_importriep.idfin IS NOT NULL ) 

-- FASE Ib) generazione dei movimenti finanziari di entrata  di RICAVO per i LORDI (righe negative e imputazione normale)
INSERT INTO @automov_inc_ungrouped
(	
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idcsa_contractkind,
	idcsa_contract 
)
SELECT
	@idreg_csa,
	@idfinincome_gross_csa,
	@idsiopeincome_csa,
	'0001', -- sempre '0001'
	- importo,
	7,
	'Ricavo Lordi ' + ' Import. Stipendi   n° ' + @nimportstr + '/' + @yimportstr,
	idcsa_contractkind,
	idcsa_contract
FROM csa_importriep
WHERE   
 	idcsa_import = @idcsa_import
AND @idfinincome_gross_csa IS NOT NULL
AND	csa_importriep.importo < 0
AND (csa_importriep.idfin IS NOT NULL ) 


-- FASE Ic) generazione dei movimenti finanziari di spesa per il COSTO dei LORDI (righe positive e imputazione con  movimento di spesa da collegare)
INSERT INTO @automov_exp_ungrouped
(	parentidexp, idman, idreg,idfin,idsor_siope,idupb,amount,movkind,description,	idcsa_contractkind,
	idcsa_contract,	idunderwriting
)
SELECT
	E.idexp, E.idman,ISNULL(E.idreg,@idreg_csa),	ISNULL(EY.idfin, csa_importriep.idfin), 
	csa_importriep.idsor_siope,
	ISNULL(EY.idupb, csa_importriep.idupb),
	--csa_importriep.importo	
	case when UA.appropriation is null then csa_importriep.importo else isnull(UA.appropriation/UA.curramount,0)* csa_importriep.importo end,	
	3,
	substring('Lordi ' + 'Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+csa_import.description,1,150),
	csa_importriep.idcsa_contractkind ,	csa_importriep.idcsa_contract,	
	isnull(UA.idunderwriting,csa_importriep.idunderwriting)
FROM csa_importriep 
JOIN csa_import 	on csa_import.idcsa_import = csa_importriep.idcsa_import
JOIN expense E		ON csa_importriep.idexp = E.idexp
JOIN expenseyear EY	ON EY.idexp = csa_importriep.idexp
JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

WHERE  	
	csa_importriep.idcsa_import = @idcsa_import
	AND csa_importriep.importo > 0
	AND csa_importriep.idexp IS NOT NULL
	AND EY.ayear = @ayear

-- FASE Id) generazione dei movimenti finanziari di entrata  di RICAVO per i LORDI (righe negative e imputazione con movimento di spesa da agganciare)
INSERT INTO @automov_inc_ungrouped
(	
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idcsa_contractkind,
	idcsa_contract 
)
SELECT
	@idreg_csa,
	@idfinincome_gross_csa,
	@idsiopeincome_csa,
	'0001', -- sempre '0001'
	- importo,
	7,
	'Ricavo Lordi ' + ' Import. Stipendi   n° ' + @nimportstr + '/' + @yimportstr,
	idcsa_contractkind,
	idcsa_contract
FROM csa_importriep
JOIN expense E
	ON csa_importriep.idexp = E.idexp
WHERE   
 	idcsa_import = @idcsa_import
AND @idfinincome_gross_csa IS NOT NULL
AND	csa_importriep.importo < 0
AND csa_importriep.idexp IS NOT NULL


-- FASE Ie) generazione dei movimenti finanziari di spesa ove presente tabella di ripartizione in csa_contractexpense
INSERT INTO @automov_exp_ungrouped
(	parentidexp,idman, idreg,idfin,idsor_siope,	idupb,	amount,	movkind,	description,
	idcsa_contractkind,	idcsa_contract,	idunderwriting
)
SELECT
	E.idexp, E.idman,
	ISNULL(E.idreg,@idreg_csa),
	ISNULL(EY.idfin, csa_importriep.idfin), 
	csa_importriep.idsor_siope,
	ISNULL(EY.idupb, csa_importriep.idupb),
	--ROUND(csa_importriep.importo*csa_contractexpense.quota,2),
	case when UA.appropriation is null then csa_importriep_expense.amount else isnull(UA.appropriation/UA.curramount,0)* csa_importriep_expense.amount end,	

	3,
	substring('Lordi ' + 'Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr+'.'+csa_import.description,1,150),
	csa_importriep.idcsa_contractkind ,
	csa_importriep.idcsa_contract,
	isnull(UA.idunderwriting,csa_importriep.idunderwriting)
FROM csa_importriep 
JOIN csa_import				on csa_import.idcsa_import = csa_importriep.idcsa_import
JOIN csa_importriep_expense 		ON csa_importriep.idcsa_import=csa_importriep_expense.idcsa_import
									AND csa_importriep.idriep=csa_importriep_expense.idriep
JOIN expense E			ON csa_importriep_expense.idexp = E.idexp
JOIN expenseyear EY		ON EY.idexp = E.idexp
JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

WHERE  	
	csa_importriep.idcsa_import = @idcsa_import
	AND csa_importriep.importo > 0
	AND EY.ayear = @ayear
	AND (csa_importriep.idfin IS NULL ) AND  csa_importriep.idexp IS NULL

-- FASE If) generazione dei movimenti finanziari di entrata  per il RICAVO dei LORDI (righe negative)ove presente tabella di ripartizione in csa_contractexpense
INSERT INTO @automov_inc_ungrouped
(	
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idcsa_contractkind,
	idcsa_contract 
)
SELECT
	@idreg_csa,
	@idfinincome_gross_csa,
	@idsiopeincome_csa,
	'0001', -- sempre '0001'
	- importo,
	7,
	'Ricavo Lordi ' + ' Import. Stipendi   n° ' + @nimportstr + '/' + @yimportstr,
	csa_importriep.idcsa_contractkind,
	csa_importriep.idcsa_contract
FROM csa_importriep
WHERE   
 	idcsa_import = @idcsa_import
AND @idfinincome_gross_csa IS NOT NULL
AND	csa_importriep.importo < 0
AND (csa_importriep.idfin IS NULL AND  csa_importriep.idexp IS NULL)
AND EXISTS (SELECT * FROM csa_importriep_expense 
				WHERE csa_importriep.idcsa_import=csa_importriep_expense.idcsa_import
				AND csa_importriep.idriep=csa_importriep_expense.idriep)


--if (@csa_flaggroupby_expense='S') 
--BEGIN
---- valorizzo la descr. con il contratto o, in alternativa, il tipo contratto
--	UPDATE 	@automov_exp_ungrouped 
--	SET 	description = SUBSTRING(description + 
--		' Contr. ' + csa_contract.description,1,150)
--	FROM 	csa_contract 
--	WHERE   movkind = 3 
--	AND idcsa_contract= csa_contract.idcsa_contract 
--	AND csa_contract.idcsa_contract is not null
--	AND csa_contract.ayear = @ayear

--	UPDATE 	@automov_exp_ungrouped 
--	SET 	description = SUBSTRING(description + 
--		' Tipo contr. ' + csa_contractkind.description,1,150)
--	FROM  	csa_contractkindyear
--	JOIN  	csa_contractkind 
--		ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
--	WHERE  movkind = 3 
--	AND csa_contractkindyear.idcsa_contractkind = idcsa_contractkind 
--	AND idcsa_contract is  null  
--	AND idcsa_contractkind is  not null
--	AND csa_contractkindyear.ayear = @ayear
--END

------------------------------------------------------------------------------- 

--if (@csa_flaggroupby_income='S') 
--BEGIN

--UPDATE 	@automov_inc_ungrouped 
--SET 	 description = SUBSTRING( description + 
--	    ' Contr. ' + csa_contract.description,1,150)
--FROM 	csa_contract 
--WHERE   movkind = 7 
--AND csa_contract.idcsa_contract = @automov_inc_ungrouped.idcsa_contract
--AND csa_contract.idcsa_contract is not null
--AND csa_contract.ayear = @ayear

--UPDATE 	@automov_inc_ungrouped 
--SET 	 description = SUBSTRING(description + 
--	' Tipo contr. ' + csa_contractkind.description,1,150)
--FROM  	csa_contractkindyear
--JOIN  	csa_contractkind 
--	ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
--WHERE  @automov_inc_ungrouped.movkind = 7 
--AND csa_contractkindyear.idcsa_contractkind = @automov_inc_ungrouped.idcsa_contractkind 
--AND @automov_inc_ungrouped.idcsa_contract is  null  
--AND @automov_inc_ungrouped.idcsa_contractkind is  not null
--AND csa_contractkindyear.ayear = @ayear

--END

--------------------------------------------------------------------------
------------ II CONTRIBUTI SU PARTITE DI GIRO COSTI E RICAVI -------------
--------------------------------------------------------------------------
--- IN CASO DI COMPENSAZIONE TRA RIGHE DI CONTRIBUTI POSITIVE E NEGATIVE 
--  SI ESEGUE QUESTO RAMO, LEGGENDO I DATI DALLA TABELLA TEMPORANEA 
--  BILANCIATA
IF ISNULL(@flagbalance_csa,'N') = 'S' 
BEGIN
-- Generazione dei movimenti finanziari di spesa per i CONTRIBUTI
-- in caso di applicazione del contributo con transito su partite di giro no versamento diretto
-- imputazione normale
		INSERT INTO @automov_exp_ungrouped
		(	parentidexp, 
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			NULL,
			@idregauto,  -- modalità pagamento predefinita per essa
			idfin_cost,
			idsor_siope_cost,
			idupb,
			importo,
			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_debit, --debito conto erario
			null,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced
		WHERE   
 			idcsa_import = @idcsa_import
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NOT NULL  AND idfin_income is not null) 

		-- movimento di entrata di ricavo per i contributi su partita di giro per i CONTRIBUTI
		-- in caso di applicazione del contributo con transito su partite di giro no versamento diretto
		-- imputazione normale su capitolo di entrata configurato in config
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  -- modalità pagamento predefinita per essa
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			idupb, 
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi '  + vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi '   +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, -- credito verso erario
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo < 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL  AND idfin_income is not null) 

		 
		-- Generazione dei movimenti finanziari di spesa per il COSTO dei CONTRIBUTI in caso di applicazione 
		-- del contributo con transito  SU PARTITE DI GIRO imputazione tramite movimento di spesa da collegare
		INSERT INTO @automov_exp_ungrouped
		(	parentidexp,idman,	idreg,	idfin,	idsor_siope,idupb,	amount,	movkind,description,idacc,	
			idcsa_agency,		idcsa_contractkind,	idcsa_contract,	idunderwriting,	vocecsa
		)
		SELECT
			E.idexp, E.idman,			ISNULL(E.idreg, @idregauto), -- modalità pagamento predefinita per essa
			ISNULL(EY.idfin, T.idfin_cost), 
			T.idsor_siope_cost,
			ISNULL(EY.idupb, T.idupb),
			--importo,
					case when UA.appropriation is null then importo else isnull(UA.appropriation/UA.curramount,0)* importo end,	
			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_debit,--debito conto erario
			null,			idcsa_contractkind,			idcsa_contract,
			isnull(UA.idunderwriting,T.idunderwriting),
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced T
		JOIN expense E				ON T.idexp_cost = E.idexp
		JOIN expenseyear EY			ON EY.idexp = E.idexp
		JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
		LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

		WHERE  	
			idcsa_import = @idcsa_import
			AND importo > 0  AND EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NOT NULL AND idfin_income is not null) 

		-- Generazione dei movimenti finanziari di entrata per il RICAVO dei CONTRIBUTI in caso di applicazione 
		-- del contributo con transito  SU PARTITE DI GIRO imputazione tramite movimento di spesa da collegare
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			ISNULL(EY.idupb, T.idupb),
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi ' + vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi '  +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,-- credito interno
			idcsa_contractkind,
			idcsa_contract,
				CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced T
		JOIN expense E
			ON T.idexp_cost = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		WHERE  	
			idcsa_import = @idcsa_import
			AND importo < 0 AND  EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NOT NULL AND idfin_income is not null) 

		-- Generazione dei movimenti finanziari di spesa per i CONTRIBUTI
		-- in caso di applicazione del contributo con transito  SU PARTITE DI GIRO  no versamento diretto
		-- imputazione tramite tabella di ripartizione

		INSERT INTO @automov_exp_ungrouped
		(	parentidexp, 
			idman,
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, @idregauto), -- modalità pagamento predefinita per essa
			ISNULL(EY.idfin, T.idfin_cost), 
			T.idsor_siope_cost,
			ISNULL(EY.idupb, T.idupb),
			--csa_importver_expense.amount,
			case when UA.appropriation is null then csa_importver_expense.amount else isnull(UA.appropriation/UA.curramount,0)* csa_importver_expense.amount end,	

			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			T.idacc_debit, --debito conto erario
			null,
			T.idcsa_contractkind,
			T.idcsa_contract,
			isnull(UA.idunderwriting,T.idunderwriting),
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced T
		JOIN csa_importver_expense	ON T.idcsa_import = csa_importver_expense.idcsa_import
										AND T.idver = csa_importver_expense.idver
		JOIN expense E				ON csa_importver_expense.idexp = E.idexp
		JOIN expenseyear EY			ON EY.idexp = E.idexp
		JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
		LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

		WHERE  	
			T.idcsa_import = @idcsa_import
			AND importo > 0 AND EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NULL AND idfin_income is not null) 
 
		-- Generazione dei movimenti finanziari di entrata per i CONTRIBUTI in caso RIGHE NEGATIVE 
		-- contributo con transito  SU PARTITE DI GIRO  no versamento diretto imputazione tramite tabella di ripartizione
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  -- modalità pagamento predefinita per essa
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi '+ vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi ' +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,-- credito  interno
			T.idcsa_contractkind,
			T.idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced T
		WHERE  	
			idcsa_import = @idcsa_import
			AND importo < 0  
			AND	ISNULL(T.flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NULL AND idfin_income is not null) 
			AND EXISTS (SELECT * FROM  csa_importver_expense
						WHERE T.idcsa_import = csa_importver_expense.idcsa_import
					    AND T.idver = csa_importver_expense.idver	 )
END
ELSE 
BEGIN
--- NEL CASO IN CUI NON SI DEBBANO EFFETTUARE COMPENSAZIONI ESEGUE QUESTO RAMO
--  LEGGENDO I DATI DA CSA_IMPORTVER, TABELLA FISICA

-- Generazione dei movimenti finanziari di spesa per i CONTRIBUTI
-- in caso di applicazione del contributo con transito su partite di giro no versamento diretto
-- imputazione normale
		INSERT INTO @automov_exp_ungrouped
		(	parentidexp, 
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			NULL,
			@idregauto,  -- modalità pagamento predefinita per essa
			idfin_cost,
			idsor_siope_cost,
			idupb,
			importo,
			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_debit, --debito conto erario
			null,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		WHERE   
 			idcsa_import = @idcsa_import
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NOT NULL  AND idfin_income is not null) 

		-- Movimento di entrata di ricavo per i contributi su partita di giro per i CONTRIBUTI
		-- in caso di applicazione del contributo con transito su partite di giro no versamento diretto
		-- imputazione normale su capitolo di entrata configurato in config
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  -- modalità pagamento predefinita per essa
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			idupb, 
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi '  + vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi '   +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, -- credito verso erario
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo < 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL  AND idfin_income is not null) 

		 
		-- Generazione dei movimenti finanziari di spesa per il COSTO dei CONTRIBUTI in caso di applicazione 
		-- del contributo con transito  SU PARTITE DI GIRO imputazione tramite movimento di spesa da collegare
		INSERT INTO @automov_exp_ungrouped
		(	parentidexp, 
			idman,
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, @idregauto), -- modalità pagamento predefinita per essa
			ISNULL(EY.idfin, csa_importver.idfin_cost), 
			csa_importver.idsor_siope_cost,
			ISNULL(EY.idupb, csa_importver.idupb),
			importo,
			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_debit,--debito conto erario
			null,
			idcsa_contractkind,
			idcsa_contract,
			csa_importver.idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		JOIN expense E
			ON csa_importver.idexp_cost = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		WHERE  	
			csa_importver.idcsa_import = @idcsa_import
			AND importo > 0  AND EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NOT NULL AND idfin_income is not null) 

		-- Generazione dei movimenti finanziari di entrata per il RICAVO dei CONTRIBUTI in caso di applicazione 
		-- del contributo con transito  SU PARTITE DI GIRO imputazione tramite movimento di spesa da collegare
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			ISNULL(EY.idupb, csa_importver.idupb),
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi ' + vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi '  +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,-- credito interno
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		JOIN expense E
			ON csa_importver.idexp_cost = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		WHERE  	
			idcsa_import = @idcsa_import
			AND importo < 0 AND  EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NOT NULL AND idfin_income is not null) 

		-- Generazione dei movimenti finanziari di spesa per i CONTRIBUTI
		-- in caso di applicazione del contributo con transito  SU PARTITE DI GIRO  no versamento diretto
		-- imputazione tramite tabella di ripartizione

		INSERT INTO @automov_exp_ungrouped
		(	parentidexp, 
			idman,
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, @idregauto), -- modalità pagamento predefinita per essa
			ISNULL(EY.idfin, csa_importver.idfin_cost), 
			csa_importver.idsor_siope_cost,
			ISNULL(EY.idupb, csa_importver.idupb),
			csa_importver_expense.amount,
			2,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			csa_importver.idacc_debit, --debito conto erario
			null,
			csa_importver.idcsa_contractkind,
			csa_importver.idcsa_contract,
			csa_importver.idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		JOIN csa_importver_expense
				ON csa_importver.idcsa_import = csa_importver_expense.idcsa_import
					AND csa_importver.idver = csa_importver_expense.idver
		JOIN expense E			ON csa_importver_expense.idexp = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		WHERE  	
			csa_importver.idcsa_import = @idcsa_import
			AND importo > 0 AND EY.ayear = @ayear
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NULL AND idfin_income is not null) 


		-- Generazione dei movimenti finanziari di entrata per i CONTRIBUTI in caso RIGHE NEGATIVE 
		-- contributo con transito  SU PARTITE DI GIRO  no versamento diretto imputazione tramite tabella di ripartizione
		INSERT INTO @automov_inc_ungrouped
		(	idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa 
		)
		SELECT
			@idregauto,  -- modalità pagamento predefinita per essa
			@idfinincome_gross_csa,
			@idsiopeincome_csa,
			csa_importver.idupb,
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ricavo Contributi '+ vocecsa +  ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ricavo Contributi ' +   ' Import. Stipendi n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,-- credito  interno
			csa_importver.idcsa_contractkind,
			csa_importver.idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		WHERE  	
			idcsa_import = @idcsa_import
			AND importo < 0  
			AND	ISNULL(csa_importver.flagclawback,'N') <> 'S'
			AND (idfin_cost IS NULL AND idexp_cost IS NULL AND idfin_income is not null) 
			AND EXISTS (SELECT * FROM csa_importver_expense
						WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
						AND csa_importver.idver = csa_importver_expense.idver)
END
--------------------------------------------------------------------------
------------ III CONTRIBUTI - PARTITE DI GIRO ----------------------------
--------------------------------------------------------------------------

--- IN CASO DI COMPENSAZIONE TRA RIGHE DI CONTRIBUTI POSITIVE E NEGATIVE 
--  SI ESEGUE QUESTO RAMO, LEGGENDO I DATI DALLA TABELLA TEMPORANEA 
--  BILANCIATA
IF ISNULL(@flagbalance_csa,'N') = 'S' 
BEGIN

		-- Generazione dei movimenti finanziari di entrata per  CONTRIBUTI  SU PARTITE DI GIRO 
		-- Movimenti su anagrafica @idregauto 
		INSERT INTO @automov_inc_ungrouped
		(
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			@idregauto,  -- applicazione contributi con transito da partita di giro
			idfin_income,
			idsor_siope_income,
			'0001',
			importo,
			1,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ritenute/Contributi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Ritenute/Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense,  -- debito VS erario
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced T
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL OR  EXISTS 
		(SELECT *  FROM csa_importver_expense
			WHERE T.idcsa_import = csa_importver_expense.idcsa_import
				AND T.idver = csa_importver_expense.idver		))
		AND (idfin_income IS NOT NULL) 


		-- Generazione dei movimenti finanziari di spesa per  CONTRIBUTI  SU PARTITE DI GIRO . RIGHE NEGATIVE
		-- Movimenti su anagrafica @idregauto 
		INSERT INTO @automov_exp_ungrouped
		(
			idreg,
			idfin,
			idsor_siope,
			idupb,
			amount,
			movkind,
			description,
			idacc,
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			@idregauto,  -- applicazione contributi con transito da partita di giro
			idfin_expense,
			idsor_siope_expense,
			'0001',
			-importo,
			12,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Contributi negativi' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Contributi negativi' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, -- credito verso erario
			idcsa_agency,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced T
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo < 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL OR  EXISTS 
				(SELECT *  FROM csa_importver_expense
					WHERE T.idcsa_import = csa_importver_expense.idcsa_import
					AND T.idver = csa_importver_expense.idver
				))
		AND (idfin_income IS NOT NULL) 
		END
ELSE
BEGIN
-- IN CASO DI NON COMPENSAZIONE LEGGE I DATI DALLA TABELLA CSA_IMPORTVER FISICA
		-- Generazione dei movimenti finanziari di entrata per  CONTRIBUTI  SU PARTITE DI GIRO 
		-- Movimenti su anagrafica @idregauto 
			INSERT INTO @automov_inc_ungrouped
			(
				idreg,
				idfin,
				idsor_siope,
				idupb,
				amount,
				movkind,
				description,
				idacc,
				idcsa_agency,
				idcsa_contractkind,
				idcsa_contract,
				vocecsa
			)
			SELECT
				@idregauto,  -- applicazione contributi con transito da partita di giro
				idfin_income,
				idsor_siope_income,
				'0001',
				importo,
				1,
				CASE ISNULL(@csa_flaggroupby_income,'N')
					WHEN 'S' THEN SUBSTRING('Ritenute/Contributi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
					ELSE 'Ritenute/Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
				END,
				idacc_expense,  -- debito VS erario
				idcsa_agency,
				idcsa_contractkind,
				idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
			FROM 	csa_importver
			WHERE   idcsa_import = @idcsa_import
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL 
					OR  EXISTS 		(SELECT *  FROM csa_importver_expense
					WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
						AND csa_importver.idver = csa_importver_expense.idver ))
			AND (idfin_income IS NOT NULL) 


			-- Generazione dei movimenti finanziari di spesa per  CONTRIBUTI  SU PARTITE DI GIRO . RIGHE NEGATIVE
			-- Movimenti su anagrafica @idregauto 
			INSERT INTO @automov_exp_ungrouped
			(
				idreg,
				idfin,
				idsor_siope,
				idupb,
				amount,
				movkind,
				description,
				idacc,
				idcsa_agency,
				idcsa_contractkind,
				idcsa_contract,
				vocecsa
			)
			SELECT
				@idregauto,  -- applicazione contributi con transito da partita di giro
				idfin_expense,
				idsor_siope_expense,
				'0001',
				-importo,
				12,
				CASE ISNULL(@csa_flaggroupby_expense,'N')
					WHEN 'S' THEN SUBSTRING('Contributi negativi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
					ELSE 'Contributi negativi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
				END,
				idacc_agency_credit, -- credito verso erario
				idcsa_agency,
				idcsa_contractkind,
				idcsa_contract,
				CASE ISNULL(@csa_flaggroupby_expense,'N')
					WHEN  'S' THEN vocecsa  
				ELSE  null
			END
			FROM 	csa_importver
			WHERE   
 				idcsa_import = @idcsa_import
			AND importo < 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL 
				OR  EXISTS 		(SELECT *  FROM csa_importver_expense
					WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
						AND csa_importver.idver = csa_importver_expense.idver ))	
			AND (idfin_income IS NOT NULL) 
		END
		

----------------------------------------------------------- 
------------ IV -RECUPERI ---------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di entrata per RECUPERI transito da partita di giro
--- IN CASO DI COMPENSAZIONE TRA RIGHE DI CONTRIBUTI POSITIVE E NEGATIVE 
--  SI ESEGUE QUESTO RAMO, LEGGENDO I DATI DALLA TABELLA TEMPORANEA 
--  BILANCIATA
IF ISNULL(@flagbalance_csa,'N') = 'S' 
BEGIN
	INSERT INTO @automov_inc_ungrouped
	(	
		idreg,
		idfin,
		idsor_siope,
		idupb,
		amount,
		movkind,
		description,
		idacc,
		idcsa_agency,
		idcsa_contractkind,
		idcsa_contract,
		vocecsa
	)
	SELECT
		@idreg_csa,
		idfin_income,
		idsor_siope_income,
		'0001',  -- per i movimenti su partita di giro sempre '0001'
		importo,
		5,
		CASE ISNULL(@csa_flaggroupby_income,'N')
			WHEN 'S' THEN SUBSTRING('Incasso Recuperi '  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
			ELSE 'Incasso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
		END,
		null,
		null,
		idcsa_contractkind,
		idcsa_contract,
		CASE ISNULL(@csa_flaggroupby_income,'N')
			WHEN  'S' THEN vocecsa  
		ELSE  null
		END
	FROM 	@csa_importver_balanced
	WHERE   
 		idcsa_import = @idcsa_import
	AND importo > 0
	AND	ISNULL(flagclawback,'N') = 'S'
	AND ISNULL(flagdirectcsaclawback,'N')= 'N' AND idfin_income IS NOT NULL 

	-- Generazione dei movimenti finanziari di SPESA per  RECUPERI SU PARTITA DI GIRO
	-- RIGHE NEGATIVE
	INSERT INTO @automov_exp_ungrouped
	(
		idreg,
		idfin,
		idsor_siope,
		idupb,
		amount,
		movkind,
		description,
		idacc,
		idcsa_agency,
		idcsa_contractkind,
		idcsa_contract,
		vocecsa
	)
	SELECT
		@idreg_csa,
		idfin_expense,
		idsor_siope_expense,
		'0001',  -- per i movimenti su partita di giro sempre '0001'
		-importo,
		14,
		CASE ISNULL(@csa_flaggroupby_expense,'N')
			WHEN 'S' THEN SUBSTRING('Rimborso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
			ELSE 'Rimborso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
		END,
		null,
		null,
		idcsa_contractkind,
		idcsa_contract,
		CASE ISNULL(@csa_flaggroupby_expense,'N')
			WHEN  'S' THEN vocecsa  
		ELSE  null
		END
	FROM 	@csa_importver_balanced
	WHERE   
 		idcsa_import = @idcsa_import
	AND importo < 0
	AND	ISNULL(flagclawback,'N') = 'S'
	AND ISNULL(flagdirectcsaclawback,'N')= 'N' AND idfin_expense IS NOT NULL


	-- Generazione dei movimenti finanziari di entrata per RECUPERI DIRETTI
	INSERT INTO @automov_inc_ungrouped
	(	
		idreg,
		idfin,
		idsor_siope,
		idupb,
		amount,
		movkind,
		description,
		idacc,
		idcsa_agency,
		idcsa_contractkind,
		idcsa_contract,
		vocecsa
	)
	SELECT
		@idreg_csa,
		idfin_incomeclawback,
		idsor_siope_incomeclawback,
		idupb,  -- per i movimenti su partita di giro sempre '0001'
		importo,
		15,
		CASE ISNULL(@csa_flaggroupby_income,'N')
			WHEN 'S' THEN SUBSTRING('Incasso Recuperi '  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
			ELSE 'Incasso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
		END,
		null,
		null,
		idcsa_contractkind,
		idcsa_contract,
		CASE ISNULL(@csa_flaggroupby_income,'N')
			WHEN  'S' THEN vocecsa  
		ELSE  null
		END
	FROM 	@csa_importver_balanced
	WHERE   
 		idcsa_import = @idcsa_import
	AND importo > 0
	AND	ISNULL(flagclawback,'N') = 'S'
	AND (
		(ISNULL(flagdirectcsaclawback,'N')= 'S' AND idfin_incomeclawback IS NOT NULL) 
		)
		
	-- Generazione dei movimenti finanziari di SPESA per COSTO RECUPERI DIRETTI
	INSERT INTO @automov_exp_ungrouped
	(
		idreg,
		idfin,
		idsor_siope,
		idupb,
		amount,
		movkind,
		description,
		idacc,
		idcsa_agency,
		idcsa_contractkind,
		idcsa_contract,
		vocecsa
	)
	SELECT
		@idreg_csa,
		idfin_cost,
		idsor_siope_cost,
		idupb,  -- per i movimenti su partita di giro sempre '0001'
		-importo,
		16,
		CASE ISNULL(@csa_flaggroupby_expense,'N')
			WHEN 'S' THEN SUBSTRING('Rimborso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
			ELSE 'Rimborso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
		END,
		null,
		null,
		idcsa_contractkind,
		idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
			WHEN  'S' THEN vocecsa  
		ELSE  null
		END
	FROM 	@csa_importver_balanced
	WHERE   
 		idcsa_import = @idcsa_import
	AND importo < 0
	AND	ISNULL(flagclawback,'N') = 'S'
	AND ISNULL(flagdirectcsaclawback,'N')= 'S' AND idfin_cost IS NOT NULL
END
ELSE
BEGIN
INSERT INTO @automov_inc_ungrouped
(	
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa,
	idfin_income,
	idsor_siope_income,
	'0001',  -- per i movimenti su partita di giro sempre '0001'
	importo,
	5,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Incasso Recuperi '  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Incasso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	null,
	null,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE   
 	idcsa_import = @idcsa_import
AND importo > 0
AND	ISNULL(flagclawback,'N') = 'S'
AND ISNULL(flagdirectcsaclawback,'N')= 'N' AND idfin_income IS NOT NULL 

-- Generazione dei movimenti finanziari di SPESA per  RECUPERI SU PARTITA DI GIRO
-- RIGHE NEGATIVE
INSERT INTO @automov_exp_ungrouped
(
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa,
	idfin_expense,
	idsor_siope_expense,
	'0001',  -- per i movimenti su partita di giro sempre '0001'
	-importo,
	14,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Rimborso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	null,
	null,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE   
 	idcsa_import = @idcsa_import
AND importo < 0
AND	ISNULL(flagclawback,'N') = 'S'
AND ISNULL(flagdirectcsaclawback,'N')= 'N' AND idfin_expense IS NOT NULL


-- Generazione dei movimenti finanziari di entrata per RECUPERI DIRETTI
INSERT INTO @automov_inc_ungrouped
(	
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa,
	idfin_incomeclawback,
	idsor_siope_incomeclawback,
	idupb,  -- per i movimenti su partita di giro sempre '0001'
	importo,
	15,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Incasso Recuperi '  + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Incasso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	null,
	null,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE   
 	idcsa_import = @idcsa_import
AND importo > 0
AND	ISNULL(flagclawback,'N') = 'S'
AND (
	(ISNULL(flagdirectcsaclawback,'N')= 'S' AND idfin_incomeclawback IS NOT NULL) 
	)
	
-- Generazione dei movimenti finanziari di SPESA per COSTO RECUPERI DIRETTI
INSERT INTO @automov_exp_ungrouped
(
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa,
	idfin_cost,
	idsor_siope_cost,
	idupb,  -- per i movimenti su partita di giro sempre '0001'
	-importo,
	16,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Rimborso Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	null,
	null,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE   
 	idcsa_import = @idcsa_import
AND importo < 0
AND	ISNULL(flagclawback,'N') = 'S'  
AND ISNULL(flagdirectcsaclawback,'N')= 'S' AND idfin_cost IS NOT NULL
END

----------------------------------------------------------- 
------------ V --RITENUTE ---------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di entrata per RITENUTE 
-- Movimenti su anagrafica @idreg_csa IMPORTI POSITIVI
 
INSERT INTO @automov_inc_ungrouped
(
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa,  --applicazione ritenute
	idfin_income,
	idsor_siope_income,
	'0001',
	importo,
	1,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Ritenute/Contributi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Ritenute/Contributi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	idacc_expense,  -- debito VS erario
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE  	idcsa_import = @idcsa_import
AND	ISNULL(flagclawback,'N') <> 'S'
AND importo > 0
AND idfin_cost IS NULL AND idexp_cost IS NULL 
AND NOT EXISTS (SELECT * FROM  csa_importver_expense
						WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
					    AND csa_importver.idver = csa_importver_expense.idver )
AND (idfin_income IS NOT NULL) 


----------------------------------------------------------- 
------------ VI --RITENUTE   ------------------------------
----------------------------------------------------------- 
-- Generazione dei movimenti finanziari di spesa per 
-- RITENUTE Movimenti su anagrafica @idreg_csa ad IMPORTI NEGATIVI

INSERT INTO @automov_exp_ungrouped
(
	idreg,
	idfin,
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	vocecsa
)
SELECT
	@idreg_csa, --applicazione ritenute
	idfin_expense,
	idsor_siope_expense,
	'0001',
	-importo,
	8,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN 'S' THEN SUBSTRING('Rimborso Ritenute ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Rimborso Ritenute ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	idacc_agency_credit,  -- credito VS erario, 
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_expense,'N')
		WHEN  'S' THEN vocecsa  
	ELSE  null
	END
FROM 	csa_importver
WHERE   
 	idcsa_import = @idcsa_import
AND importo < 0
AND	ISNULL(flagclawback,'N') <> 'S'
AND (idfin_cost IS NULL AND idexp_cost IS NULL 
AND NOT EXISTS 	(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver	)
			 )  -- non è un contributo ma una ritenuta
AND (idfin_income IS NOT NULL OR idfin_incomeclawback IS NOT NULL) 

DECLARE  @automov TABLE
(
	parentidexp int, 
	idman int,
	idreg int,
	idfin int, 
	idsor_siope int,
	idupb varchar(36),
	amount decimal(19,2),
	opposite_amount decimal(19,2),
	movkind int,
	description varchar(200),
	idacc varchar(36),
	idcsa_agency int,
	idcsa_contractkind int,
	idcsa_contract int,
	idunderwriting int,
	toignore char(1),
	vocecsa varchar(200)
)


INSERT INTO @automov 
(
	parentidexp, 
	idman,
	idreg,
	idfin, 
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	idunderwriting,
	vocecsa
)
	
SELECT parentidexp, idman,idreg, idfin, idsor_siope, idupb, SUM(amount), movkind, description,idacc, 
idcsa_agency,idcsa_contractkind,idcsa_contract,idunderwriting,vocecsa
FROM   @automov_exp_ungrouped
GROUP BY parentidexp,idman, idreg, idfin, idsor_siope, idupb, description, movkind,idacc, idcsa_agency,
idcsa_contractkind,idcsa_contract, idunderwriting,vocecsa

INSERT INTO @automov 
(
	idreg,
	idfin, 
	idsor_siope,
	idupb,
	amount,
	movkind,
	description,
	idacc,
	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	idunderwriting,
	vocecsa
)
SELECT idreg, idfin, idsor_siope, idupb, SUM(amount), movkind, description,
idacc, idcsa_agency, idcsa_contractkind,idcsa_contract,idunderwriting,vocecsa
FROM   @automov_inc_ungrouped
GROUP BY movkind, idreg, idfin, idsor_siope, idupb, description,idacc, idcsa_agency,idcsa_contractkind,idcsa_contract,idunderwriting,vocecsa



IF ISNULL(@flagbalance_csa,'N') = 'S'
BEGIN
	--------------------------------------------------
	---- INIZIO GESTIONE COMPENSAZIONE LORDI----------
	--------------------------------------------------
	----  COMPENSA COSTI E RICAVI PER LORDI ----------
	-------------------------------------------------- 
	UPDATE @automov  SET opposite_amount =(SELECT SUM(T.amount) FROM   @automov_inc_ungrouped T
	WHERE T.movkind = 7 and [@automov].idcsa_contractkind = T.idcsa_contractkind
	AND   [@automov].idcsa_contract = T.idcsa_contract)
	WHERE [@automov].movkind = 3 

	UPDATE @automov  SET opposite_amount =(SELECT SUM(T.amount) FROM   @automov_exp_ungrouped T
	WHERE T.movkind = 3 and [@automov].idcsa_contractkind = T.idcsa_contractkind
	AND  [@automov].idcsa_contract = T.idcsa_contract)
	WHERE [@automov].movkind = 7   


	UPDATE   @automov  SET toignore = 'S' WHERE movkind = 3 AND 
	ISNULL(amount,0) - ISNULL(opposite_amount,0) <= 0

	UPDATE  @automov  SET toignore = 'S' WHERE movkind = 7 AND  
	ISNULL(amount,0) - ISNULL(opposite_amount,0) <= 0
	--------------------------------------------------
	------- FINE GESTIONE COMPENSAZIONE LORDI---------
	--------------------------------------------------
	
END
  INSERT INTO @result
SELECT 
	CASE 
	     WHEN T.movkind IN (3,2,12,14,16,8) THEN 'Spesa'
	     WHEN T.movkind IN (7,10,1,5,15) THEN 'Entrata' 
	END as kind,
	T.movkind,
	null as parentidinc,
	T.parentidexp,
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
LEFT OUTER JOIN registry R
	ON R.idreg = T.idreg
LEFT OUTER JOIN fin F
	ON F.idfin = T.idfin
LEFT OUTER JOIN upb U
	ON U.idupb = T.idupb
LEFT OUTER JOIN account A
	ON A.idacc = T.idacc
LEFT OUTER JOIN sorting S
	ON S.idsor = T.idsor_siope
left outer join sortingkind SK 
	on S.idsorkind=SK.idsorkind
left outer join sorting S2 
	on S2.sortcode=S.sortcode and S2.idsorkind=SK.idparentkind
LEFT OUTER JOIN underwriting UN
	ON UN.idunderwriting = T.idunderwriting
WHERE ISNULL(toignore,'N') <> 'S' 
ORDER BY  R.title,F.codefin, U.codeupb, A.idacc

return
END
 
    
 

