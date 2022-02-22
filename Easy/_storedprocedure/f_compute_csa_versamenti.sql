
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


if exists (select * from dbo.sysobjects where id = object_id(N'[f_compute_csa_versamenti]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function f_compute_csa_versamenti
GO
 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 --setuser 'amm'
 

CREATE  FUNCTION [f_compute_csa_versamenti]
(
 	@ayear	      int,
	@idcsa_import int
)
RETURNS @result TABLE (kind varchar(20), movkind int , parentidinc int , parentidexp int , idman int,  idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200))  
 
AS BEGIN

  --   + movkind 4 mov. spesa contributi/ritenute/recuperi (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)
  --   - movkind 10 mov. entrata di ricavo contributi (negativi) (fase LORDI se su partita di giro  oppure VERSAMENTI se liquidazione diretta)
  --   - movkind 11 mov. entrata incasso contributi su partita di giro da erario (negativi) (fase VERSAMENTI)  
  --   - movkind 17 mov. entrata (dall'erario) recuperi su p. di giro (negativi) (fase VERSAMENTI)
  
  --   + movkind 6 mov. entrata recuperi post versamento solo se su p. di giro (fase VERSAMENTI)
  --   - movkind 13 mov. spesa costo recuperi solo se su partita di giro (negativi) (fase VERSAMENTI)
      
DECLARE @csa_flaggroupby_income char(1)
DECLARE @csa_flaggroupby_expense char(1)
DECLARE @flagbalance_csa char(1)
DECLARE @csa_flaglinktoexp char(1)


SELECT 
	@csa_flaggroupby_income	 = csa_flaggroupby_income,
	@csa_flaggroupby_expense = csa_flaggroupby_expense,
	@flagbalance_csa = flagbalance_csa,
	@csa_flaglinktoexp = csa_flaglinktoexp
FROM config
WHERE ayear = @ayear

DECLARE @yimportstr varchar(10)
DECLARE @nimportstr varchar(10)

SELECT @yimportstr = CONVERT(varchar(10),yimport),@nimportstr = convert(varchar(10),nimport) FROM  csa_import WHERE idcsa_import = @idcsa_import

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
	FROM csa_importver  --- CONTRIBUTI
	WHERE  idcsa_import = @idcsa_import AND ISNULL(flagclawback,'N') <> 'S' 
	AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL  OR EXISTS 
	(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver))
	GROUP BY	
	idcsa_import, ente,
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
	idsor_siope_incomeclawback,idsor_siope_cost,idunderwriting ,idver


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
	idcsa_import, ente,
	isnull(vocecsaunified,vocecsa) ,flagcr, ayear, idcsa_contractkind, idcsa_contract, idcsa_agency,
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
	idsor_siope_incomeclawback,idsor_siope_cost,idunderwriting ,idver
	
	
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
	idcsa_agency int,
	idcsa_agencypaymethod int,
	idacc varchar(36),
	idunderwriting int,
	vocecsa	varchar(200)
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
	idcsa_agency int,
	idcsa_contractkind int,
	idcsa_contract int,
	idunderwriting int,
	vocecsa	varchar(200)
)

--------------------------------------------------------------------
------------I VERSAMENTI CONTRIBUTI RITENUTE E RECUPERI-------------
--------------------------------------------------------------------
--   + movkind 4 mov. spesa contributi/ritenute/recuperi (fase VERSAMENTI)  (anche versamento contributi su liq. diretta)
--   generazione dei movimenti finanziari di spesa per il versamento di 
--   CONTRIBUTI E RITENUTE con transito da partite di giro

--- IN CASO DI COMPENSAZIONE TRA RIGHE DI CONTRIBUTI POSITIVE E NEGATIVE 
--  SI ESEGUE QUESTO RAMO, LEGGENDO I DATI DALLA TABELLA TEMPORANEA DOVE GLI IMPORTI SONO SOMMATI PER VOCE CSA
--  
IF ISNULL(@flagbalance_csa,'N') = 'S' 
BEGIN
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,
			idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense, -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced T
		WHERE   
 			T.idcsa_import = @idcsa_import
		AND T.importo > 0
		AND (T.idfin_expense IS NOT NULL AND T.idfin_income IS NOT NULL) 
		-- si tratta di contributi
		AND (T.idfin_cost IS NOT  NULL OR T.idexp_cost IS NOT  NULL OR EXISTS 
		(SELECT *  FROM csa_importver_expense
		WHERE T.idcsa_import = csa_importver_expense.idcsa_import
			AND T.idver = csa_importver_expense.idver
			))
		AND ISNULL(flagclawback,'N') = 'N' -- escludo i recuperi


		-- generazione dei movimenti finanziari di spesa per il versamento 
		-- di RECUPERI con transito da partite di giro
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,
			idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	@csa_importver_balanced
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND idfin_expense IS NOT NULL AND idfin_income IS NOT NULL 
		--AND idacc_internalcredit IS NOT NULL 
		AND idfin_incomeclawback IS NOT NULL
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') -- recuperi


		-- movkind 17 mov. entrata (dall'erario) recuperi (negativi) (fase VERSAMENTI)
		--- Versamento recuperi righe negative
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
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_income,
			idsor_siope_income,
			'0001', --SEMPRE PER PARTITE DI GIRO
			-importo,
			17,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_cost, 
			idcsa_agency,
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
		AND idfin_expense IS NOT NULL AND idfin_income IS NOT NULL AND idfin_cost IS NOT NULL
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') -- recuperi

		-- generazione dei movimenti finanziari di spesa per il versamento di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e con IMPUTAZIONE NORMALE (BILANCIO - UPB)
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			NULL,
			idreg_agency,  -- modalità pagamento configurata per l'ente CSA di versamento
			idfin_cost,
			idsor_siope_cost,
			idupb, -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense, -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN vocecsa  
				ELSE null
			END
		FROM @csa_importver_balanced
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL AND idexp_cost IS NULL AND idfin_income is null) 

		-- FASE Id) fase  generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI A LIQUIDAZIONE 
		-- DIRETTA dall'Erario (negativi)
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced			
		WHERE idcsa_import = @idcsa_import
		AND (idfin_cost IS NOT NULL  AND idexp_cost IS NULL ) -- solo contributi a liquidazione diretta
		AND (idfin_incomeclawback IS NOT NULL AND idfin_income is null AND importo < 0)
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

		-- Generazione dei movimenti finanziari di spesa per il versamento di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE MOVIMENTO FINANZIARIO COSTO DA AGGANCIARE
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, idreg_agency), -- modalità pagamento configurata per l'ente CSA di versamento
			ISNULL(EY.idfin, idfin_cost), 
			idsor_siope_cost,
			ISNULL(EY.idupb, T.idupb), -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			--importo,
			case when UA.appropriation is null then importo else isnull(UA.appropriation/UA.curramount,0)* importo end,	
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense,  -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			isnull(UA.idunderwriting,T.idunderwriting),

			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced T
		JOIN expense E				ON idexp_cost = E.idexp
		JOIN expenseyear EY			ON EY.idexp = idexp_cost
		JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
		LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

		WHERE  	
			idcsa_import = @idcsa_import
			AND EY.ayear = @ayear
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS  NULL AND idexp_cost IS NOT NULL AND idfin_income is null) 
			
		-- Generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI DA ERARIO
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE MOVIMENTO FINANZIARIO COSTO DA AGGANCIARE
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced
		JOIN expense E
			ON  idexp_cost = E.idexp
		WHERE idcsa_import = @idcsa_import
		-- solo contributi a liquidazione diretta
		AND  importo < 0 
		AND (idfin_incomeclawback IS NOT NULL AND idfin_cost IS  NULL AND idexp_cost IS NOT NULL AND idfin_income is null) 
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

		-- Generazione dei movimenti finanziari di spesa per il VERSAMENTO di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE TABELLA DI RIPARTIZIONE) 
		-- ove presente tabella di ripartizione in csa_contracttaxexpense
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, idreg_agency), -- modalità pagamento configurata per l'ente CSA di versamento
			ISNULL(EY.idfin,  idfin_cost), 
			idsor_siope_cost,
			ISNULL(EY.idupb, T.idupb), -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
				--csa_importver_expense.amount,
			case when UA.appropriation is null then csa_importver_expense.amount else isnull(UA.appropriation/UA.curramount,0)* csa_importver_expense.amount end,	

			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			T.idacc_expense,  -- debito verso erario
			T.idcsa_agency,
		    T.idcsa_agencypaymethod,
			T.idcsa_contractkind,
			T.idcsa_contract,
		    			isnull(UA.idunderwriting,T.idunderwriting),
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced T
		JOIN csa_importver_expense					ON T.idcsa_import = csa_importver_expense.idcsa_import
														AND T.idver = csa_importver_expense.idver
		JOIN expense E							ON csa_importver_expense.idexp = E.idexp
		JOIN expenseyear EY						ON EY.idexp = E.idexp
		JOIN expenselink EL		ON EL.idchild  = EY.idexp and EL.nlevel=1		--fase crediti 
		LEFT OUTER JOIN expensecreditproceedsview UA on UA.idexp=EL.idparent and UA.ayear=@ayear

		WHERE  	
			T.idcsa_import = @idcsa_import
			AND EY.ayear = @ayear
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS  NULL AND idexp_cost IS NULL AND idfin_income is null) 

		-- Generazione dei movimenti finanziari di entrata per l'INCASSO di CONTRIBUTI DA ERARIO
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE TABELLA DI RIPARTIZIONE
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
			FROM @csa_importver_balanced T
		WHERE idcsa_import = @idcsa_import
		-- solo contributi a liquidazione diretta
		AND  importo < 0 
		AND (idfin_incomeclawback IS NOT NULL AND idfin_cost IS  NULL AND idexp_cost IS NULL AND idfin_income is null)  
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi
		AND EXISTS (SELECT * FROM csa_importver_expense WHERE 
					T.idcsa_import = csa_importver_expense.idcsa_import
				    AND T.idver = csa_importver_expense.idver
				    )
		END
ELSE
BEGIN
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,
			idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense, -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND (idfin_expense IS NOT NULL AND idfin_income IS NOT NULL)
		AND (idfin_cost IS NOT  NULL OR idexp_cost IS NOT  NULL OR EXISTS 
		(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver
			)) 
		AND ISNULL(csa_importver.flagclawback,'N') = 'N' -- escludo i recuperi
		
		-- Generazione dei movimenti finanziari di spesa per il versamento 
		-- di RECUPERI con transito da partite di giro
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,
			idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND idfin_expense IS NOT NULL AND idfin_income IS NOT NULL 
		--AND idacc_internalcredit IS NOT NULL 
		AND idfin_incomeclawback IS NOT NULL
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(csa_importver.flagclawback,'N') = 'S') -- recuperi


		-- movkind 17 mov. entrata (dall'erario) recuperi (negativi) (fase VERSAMENTI)
		--- Versamento recuperi righe negative
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
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_income,
			idsor_siope_income,
			'0001', --SEMPRE PER PARTITE DI GIRO
			-importo,
			17,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_cost, 
			idcsa_agency,
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
		AND idfin_expense IS NOT NULL AND idfin_income IS NOT NULL AND idfin_cost IS NOT NULL
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(csa_importver.flagclawback,'N') = 'S') -- recuperi

		-- generazione dei movimenti finanziari di spesa per il versamento di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e con IMPUTAZIONE NORMALE
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			NULL,
			idreg_agency,  -- modalità pagamento configurata per l'ente CSA di versamento
			idfin_cost,
			idsor_siope_cost,
			idupb, -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense, -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND	ISNULL(flagclawback,'N') <> 'S'
		AND (idfin_cost IS NOT NULL AND idexp_cost IS NULL AND idfin_income is null) 

		-- FASE Id) fase  generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI A LIQUIDAZIONE 
		-- DIRETTA dall'Erario (negativi)
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		WHERE idcsa_import = @idcsa_import
		AND (idfin_cost IS NOT NULL AND idexp_cost IS NULL) -- solo contributi a liquidazione diretta
		AND (idfin_incomeclawback IS NOT NULL AND idfin_income is null AND importo < 0)
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

		-- FASE Ie) generazione dei movimenti finanziari di spesa per il versamento di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE MOVIMENTO FINANZIARIO COSTO DA AGGANCIARE
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, idreg_agency), -- modalità pagamento configurata per l'ente CSA di versamento
			ISNULL(EY.idfin, csa_importver.idfin_cost), 
			csa_importver.idsor_siope_cost,
			ISNULL(EY.idupb, csa_importver.idupb), -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense,  -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			csa_importver.idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		JOIN expense E
			ON csa_importver.idexp_cost = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = csa_importver.idexp_cost
		WHERE  	
			idcsa_import = @idcsa_import
			AND EY.ayear = @ayear
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS  NULL AND idexp_cost IS NOT NULL AND idfin_income is null) 
			
		-- FASE If) generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI DA ERARIO
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE MOVIMENTO FINANZIARIO COSTO DA AGGANCIARE
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		JOIN expense E
			ON csa_importver.idexp_cost = E.idexp
		WHERE idcsa_import = @idcsa_import
		-- solo contributi a liquidazione diretta
		AND  importo < 0 
		AND (idfin_incomeclawback IS NOT NULL AND idfin_cost IS  NULL AND idexp_cost IS NOT NULL AND idfin_income is null) 
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

		-- FASE Ig) generazione dei movimenti finanziari di spesa per il VERSAMENTO di CONTRIBUTI 
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE TABELLA DI RIPARTIZIONE) 
		--ove presente tabella di ripartizione in csa_contracttaxexpense
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			E.idexp,
			E.idman,
			ISNULL(E.idreg, idreg_agency), -- modalità pagamento configurata per l'ente CSA di versamento
			ISNULL(EY.idfin, csa_importver.idfin_cost), 
			csa_importver.idsor_siope_cost,
			ISNULL(EY.idupb, csa_importver.idupb), -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			csa_importver_expense.amount,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			csa_importver.idacc_expense,  -- debito verso erario
			csa_importver.idcsa_agency,
			csa_importver.idcsa_agencypaymethod,
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
		JOIN expense E 			ON csa_importver_expense.idexp = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		WHERE  	
			csa_importver.idcsa_import = @idcsa_import
			AND EY.ayear = @ayear
			AND importo > 0
			AND	ISNULL(flagclawback,'N') <> 'S'
			AND (idfin_cost IS  NULL AND idexp_cost IS NULL AND idfin_income is null) 

		-- FASE Ih) generazione dei movimenti finanziari di entrata per l'INCASSO di CONTRIBUTI DA ERARIO
		-- A LIQUIDAZIONE DIRETTA e IMPUTAZIONE TRAMITE TABELLA DI RIPARTIZIONE
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
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			'0001',
			-importo,
			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			csa_importver.idcsa_contractkind,
			csa_importver.idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		WHERE idcsa_import = @idcsa_import
		-- solo contributi a liquidazione diretta
		AND  importo < 0 
		AND (idfin_incomeclawback IS NOT NULL AND idfin_cost IS  NULL AND idexp_cost IS NULL AND idfin_income is null)  
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi
		AND EXISTS (SELECT * FROM csa_importver_expense 
					WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
				    AND csa_importver.idver = csa_importver_expense.idver
				    )
END

-- Versamento Ritenute
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			vocecsa
		)
		SELECT
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,
			idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			importo,
			4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Imposte/Recuperi '+ vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Versamento Imposte/Recuperi ' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_expense, -- debito verso erario
			idcsa_agency,
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM 	csa_importver 
		WHERE   
 			idcsa_import = @idcsa_import
		AND importo > 0
		AND (idfin_expense IS NOT NULL AND idfin_income IS NOT NULL 
		AND (idfin_cost IS   NULL AND idexp_cost IS NULL  AND NOT  EXISTS 
		(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver
			))
		AND ISNULL(csa_importver.flagclawback,'N') = 'N') -- escludo i recuperi
		
-- Generazione dei movimenti finanziari di entrata per l'INCASSO di RITENUTE DA ERARIO (negativi) 
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
	idreg_agency,  --anagrafica Ente CSA
	idfin_income, 
	idsor_siope_income,
	'0001',
	-importo,
	9,
	CASE ISNULL(@csa_flaggroupby_income,'N')
		WHEN 'S' THEN SUBSTRING('Incasso Ritenute da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
		ELSE 'Incasso Ritenute da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
	END,
	idacc_agency_credit, --credito verso erario
 	idcsa_agency,
	idcsa_contractkind,
	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
	END
FROM csa_importver
WHERE idcsa_import = @idcsa_import
AND (idfin_cost IS NULL AND idexp_cost IS NULL AND NOT EXISTS 
	(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver
			)) -- no contributi
AND (idfin_income IS NOT NULL AND importo < 0)
AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

IF ISNULL(@flagbalance_csa,'N') = 'S' 
BEGIN
		-- Generazione dei movimenti finanziari di entrata per l'INCASSO di CONTRIBUTI DA ERARIO (negativi) 
		-- CHE TRANSITANO DALLE PARTITE DI GIRO
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
			idreg_agency,  --anagrafica Erario
			idfin_income, 
			idsor_siope_income,
			'0001',
			-importo,
			11,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM @csa_importver_balanced T
		WHERE idcsa_import = @idcsa_import
		AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL OR  EXISTS 
		(SELECT *  FROM csa_importver_expense
		WHERE T.idcsa_import = csa_importver_expense.idcsa_import
			AND T.idver = csa_importver_expense.idver
			)) -- contributi
		AND (idfin_income IS NOT NULL AND importo < 0 AND idfin_expense IS NOT NULL)
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi


		-- Generazione dei movimenti finanziari di entrata post-versamento di RECUPERI 
		-- CHE TRANSITANO DALLE PARTITE DI GIRO
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
			idreg_agency, 
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			idupb, -- configurato in csa_incomesetup specifico per i Recuperi
			importo,
			6,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Recuperi '  +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,
			idcsa_agency,
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
		AND (idfin_incomeclawback IS NOT NULL)
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') --recuperi


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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			idreg_agency, 
			idfin_cost, 
			idsor_siope_cost,
			idupb, -- configurato in csa_incomesetup specifico per i Recuperi
			importo,
			13,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Rimborso Ritenute/Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Rimborso Ritenute/Recuperi '  +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_cost, ---conto di costo letto da csa_incomesetup, ad uso esclusivo dei recuperi
			idcsa_agency,
			idcsa_agencypaymethod,
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
		AND (idfin_cost IS NOT NULL)
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') --recuperi
		END
ELSE
BEGIN
		-- Generazione dei movimenti finanziari di entrata per l'INCASSO di CONTRIBUTI DA ERARIO (negativi) 
		-- CHE TRANSITANO DALLE PARTITE DI GIRO
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
			idreg_agency,  --anagrafica Erario
			idfin_income, 
			idsor_siope_income,
			'0001',
			-importo,
			11,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Contributi da Erario ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Contributi da Erario' +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_agency_credit, --credito verso erario
 			idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN  'S' THEN vocecsa  
				ELSE  null
			END
		FROM csa_importver
		WHERE idcsa_import = @idcsa_import
		AND (idfin_cost IS NOT NULL OR idexp_cost IS NOT NULL OR  EXISTS 
		(SELECT *  FROM csa_importver_expense
		WHERE csa_importver.idcsa_import = csa_importver_expense.idcsa_import
			AND csa_importver.idver = csa_importver_expense.idver
			)) -- contributi
		AND (idfin_income IS NOT NULL AND importo < 0 AND idfin_expense IS NOT NULL)
		AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi


		-- Generazione dei movimenti finanziari di entrata post-versamento di RECUPERI 
		-- CHE TRANSITANO DALLE PARTITE DI GIRO
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
			idreg_agency, 
			idfin_incomeclawback, 
			idsor_siope_incomeclawback,
			idupb, -- configurato in csa_incomesetup specifico per i Recuperi
			importo,
			6,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Incasso Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Incasso Recuperi '  +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_internalcredit,
			idcsa_agency,
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
		AND (idfin_incomeclawback IS NOT NULL)
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') --recuperi

		-- Righe negative
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
			idcsa_agencypaymethod,
			idcsa_contractkind,
			idcsa_contract,
			idunderwriting,
			vocecsa
		)
		SELECT
			idreg_agency, 
			idfin_cost, 
			idsor_siope_cost,
			idupb, -- configurato in csa_incomesetup specifico per i Recuperi
			importo,
			13,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Rimborso Ritenute/Recuperi ' + vocecsa +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr,1,150)
				ELSE 'Rimborso Ritenute/Recuperi '  +   ' Import. Stipendi  n° ' + @nimportstr + '/' + @yimportstr
			END,
			idacc_cost, ---conto di costo letto da csa_incomesetup, ad uso esclusivo dei recuperi
			idcsa_agency,
			idcsa_agencypaymethod,
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
		AND (idfin_cost IS NOT NULL)
		AND ISNULL(flagdirectcsaclawback,'N') = 'N' -- recupero su partite di giro
		AND (ISNULL(flagclawback,'N') = 'S') --recuperi
END

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
	idcsa_agencypaymethod int,
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
	idcsa_agencypaymethod,
	idcsa_contractkind,
	idcsa_contract,
	idunderwriting,
	vocecsa
)
SELECT  parentidexp, idman, idreg, idfin, idsor_siope, idupb, SUM(amount), movkind, description, idacc, idcsa_agency,
	idcsa_agencypaymethod, idcsa_contractkind,idcsa_contract,idunderwriting,vocecsa
FROM   @automov_exp_ungrouped
GROUP BY idreg, idman, idfin, idsor_siope, idupb, description, movkind,idacc, idcsa_agency,
         idcsa_agencypaymethod, parentidexp, idcsa_contractkind,idcsa_contract,idunderwriting,vocecsa
 
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
SELECT idreg, idfin, idsor_siope, idupb, SUM(amount), movkind, description, idacc,idcsa_agency,idcsa_contractkind,
	idcsa_contract,idunderwriting,vocecsa
FROM   @automov_inc_ungrouped
GROUP BY movkind, idreg, idfin, idsor_siope, idupb, description, idacc, idcsa_agency,
		 idcsa_contractkind,idcsa_contract,idunderwriting, vocecsa

  INSERT INTO @result	 
SELECT 
	CASE 
	     WHEN T.movkind IN  (4,13) THEN 'Spesa'
	     WHEN  T.movkind IN (10,17,9,11,6) THEN 'Entrata' 
	END as kind,
	T.movkind,
	null as parentidinc,
	T.parentidexp as parentidexp,
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
	T.idacc,
	A.codeacc,
	ISNULL(amount,0) - ISNULL(opposite_amount,0) as amount,
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
	ON S.idsor = idsor_siope
left outer join sortingkind SK 
	on S.idsorkind=SK.idsorkind
left outer join sorting S2 
	on S2.sortcode=S.sortcode and S2.idsorkind=SK.idparentkind
LEFT OUTER JOIN underwriting UN
	ON UN.idunderwriting = T.idunderwriting
WHERE ISNULL(toignore,'N') <> 'S' 
ORDER BY  R.title,F.codefin, U.codeupb, A.idacc

RETURN
END


GO


