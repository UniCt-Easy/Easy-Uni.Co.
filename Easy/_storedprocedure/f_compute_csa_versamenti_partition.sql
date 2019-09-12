if exists (select * from dbo.sysobjects where id = object_id(N'[f_compute_csa_versamenti_partition]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function [f_compute_csa_versamenti_partition]
GO
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 --setuser 'amministrazione'
 
if not exists (select * from systypes where name = 'int_list') begin 
	CREATE TYPE dbo.int_list AS TABLE      ( n int)  
end
GO

CREATE  FUNCTION [f_compute_csa_versamenti_partition]
(
 	@ayear	      int,
	@idcsa_import int,
	@lista_idcsa_import dbo.int_list  READONLY, -- @idcsa_import int,
	@lista_idreg_agency dbo.int_list  READONLY   --@idcsa_agency int
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
		SELECT P.idcsa_import,'S',P.idver,P.ndetail,P.idexp,
			idreg_agency,  -- modalità pagamento configurata per l'ente CSA di versamento
			P.idfin,	P.idsor_siope,
			P.idupb, -- CONFIGURATO NELLA SCHEDA CONTRIBUTI DEL CONTRATTO O NEL TIPO CONTRATTO
			P.amount,			4,
 
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Contributi '+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Versamento Contributi ' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
			idacc_expense, -- debito verso erario
			csa_agency.idcsa_agency,	idcsa_agencypaymethod,idcsa_contractkind,	idcsa_contract,	idunderwriting,
			CASE ISNULL(@csa_flaggroupby_expense,'N') WHEN  'S' THEN vocecsa  ELSE  null END
		FROM csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			LEFT OUTER JOIN @lista_idreg_agency on csa_agency.idreg = [@lista_idreg_agency].n
			LEFT OUTER JOIN @lista_idcsa_import on csa_import.idcsa_import = [@lista_idcsa_import].n
		WHERE   
			((P.idcsa_import = @idcsa_import AND @idcsa_import is not null AND (ISNULL(csa_agency.flag,0) & 1) = 0 AND [@lista_idcsa_import].n IS NULL)
			  OR
			 (csa_import.yimport = @ayear AND @idcsa_import is null AND [@lista_idcsa_import].n IS NOT NULL AND [@lista_idreg_agency].n IS NOT NULL)
			 ) 
			AND P.amount > 0
			AND	ISNULL(flagclawback,'N') <> 'S'		--non recuperi
			AND (idcsa_contractkinddata IS NOT NULL OR idcsa_contracttax IS NOT NULL )
				

		-- generazione dei movimenti finanziari di spesa per il versamento di RITENUTE   positive
		--  movkind 4	 
	INSERT INTO @automov
		(idcsa_import,kind, idver,ndetail, idreg,idfin,idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_agencypaymethod,idcsa_contractkind,idcsa_contract,vocecsa)
		SELECT P.idcsa_import,'S',P.idver,P.ndetail,
			idreg_agency,  -- prenderò la modalità di pagamento configurata per l'ente CSA di versamento
			idfin_expense,	idsor_siope_expense,
			'0001', --SEMPRE PER PARTITE DI GIRO
			P.amount,		4,
			CASE ISNULL(@csa_flaggroupby_expense,'N')
				WHEN 'S' THEN SUBSTRING('Versamento Ritenute '+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Versamento Ritenute ' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
			idacc_expense, -- debito verso erario
			csa_agency.idcsa_agency,idcsa_agencypaymethod,	idcsa_contractkind,	idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_expense,'N')	WHEN  'S' THEN vocecsa  ELSE  null	END
		FROM 	csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver 
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			LEFT OUTER JOIN @lista_idreg_agency on csa_agency.idreg = [@lista_idreg_agency].n
			LEFT OUTER JOIN @lista_idcsa_import on csa_import.idcsa_import = [@lista_idcsa_import].n

		WHERE   
			((P.idcsa_import = @idcsa_import AND @idcsa_import is not null AND (ISNULL(csa_agency.flag,0) & 1) = 0 AND [@lista_idcsa_import].n IS NULL)
			  OR
			 (csa_import.yimport = @ayear AND @idcsa_import is null AND [@lista_idcsa_import].n IS NOT NULL AND [@lista_idreg_agency].n IS NOT NULL ) 
			 ) 
			AND P.amount > 0
			AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS  NULL )
			AND ISNULL(csa_importver.flagclawback,'N') = 'N'  -- solo le ritenute

		-- FASE Id) fase  generazione dei movimenti finanziari di entrata per l'incasso di CONTRIBUTI negativi  movkind 10
		INSERT INTO @automov
		(	idcsa_import,kind, idver,ndetail, idreg,	idfin,	idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_contractkind,	idcsa_contract,	vocecsa	)
		SELECT	P.idcsa_import,'E',P.idver,P.ndetail,
			idreg_agency,  --anagrafica Erario
			idfin_incomeclawback, 	idsor_siope_incomeclawback,
			P.idupb, 		-P.amount,			10,
			CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Contributo negativo '+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Contributo negativo ' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,

			idacc_agency_credit, --credito verso erario
 			csa_agency.idcsa_agency,
 			idcsa_contractkind,
			idcsa_contract,
			CASE ISNULL(@csa_flaggroupby_income,'N')WHEN  'S' THEN vocecsa  	ELSE  null	END
		FROM csa_importver_partition P 
			join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
			join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
			join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
			LEFT OUTER JOIN @lista_idreg_agency on csa_agency.idreg = [@lista_idreg_agency].n
			LEFT OUTER JOIN @lista_idcsa_import on csa_import.idcsa_import = [@lista_idcsa_import].n
		WHERE  
			((P.idcsa_import = @idcsa_import AND @idcsa_import is not null AND (ISNULL(csa_agency.flag,0) & 1) = 0 AND [@lista_idcsa_import].n IS NULL)
			  OR
			 (csa_import.yimport = @ayear AND @idcsa_import is null AND [@lista_idcsa_import].n IS NOT NULL AND [@lista_idreg_agency].n IS NOT NULL)
			 ) 
			AND (idcsa_contractkinddata IS NOT NULL OR idcsa_contracttax IS NOT NULL )
			AND ( P.amount < 0)	
			AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

		-- Generazione dei movimenti finanziari di entrata per l'INCASSO di RITENUTE  (negative)  movkind 9
INSERT INTO @automov
(	idcsa_import,kind,idver,ndetail,idreg,idfin,idsor_siope,idupb,amount,movkind,description,idacc,idcsa_agency,idcsa_contractkind,idcsa_contract,vocecsa )
SELECT P.idcsa_import,'E',P.idver,P.ndetail,
	idreg_agency,  --anagrafica Ente CSA
	idfin_income, idsor_siope_income,
	'0001',	-P.amount,	9,
 
	CASE ISNULL(@csa_flaggroupby_income,'N')
				WHEN 'S' THEN SUBSTRING('Ritenute negative '+ vocecsa +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport) + '/' + 
										CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
				ELSE SUBSTRING('Ritenute negative ' +   ' Import. Stipendi  n° ' + CONVERT(varchar(10),csa_import.nimport)  + '/' + 
					 CONVERT(varchar(10),csa_import.yimport)+ '.'+csa_import.description,1,150)
			END,
	idacc_agency_credit, --credito verso erario
 	csa_agency.idcsa_agency,	idcsa_contractkind,	idcsa_contract,
	CASE ISNULL(@csa_flaggroupby_income,'N') WHEN  'S' THEN vocecsa  ELSE  null	END
FROM  csa_importver_partition P 
	  join csa_importver on csa_importver.idcsa_import=P.idcsa_import and csa_importver.idver=P.idver
	  join csa_import ON csa_importver.idcsa_import = csa_import.idcsa_import
	  join csa_agency ON csa_agency.idcsa_agency = csa_importver.idcsa_agency 
	  LEFT OUTER JOIN @lista_idreg_agency on csa_agency.idreg = [@lista_idreg_agency].n
	  LEFT OUTER JOIN @lista_idcsa_import on csa_import.idcsa_import = [@lista_idcsa_import].n
WHERE  
	((P.idcsa_import = @idcsa_import AND @idcsa_import is not null AND (ISNULL(csa_agency.flag,0) & 1) = 0 AND [@lista_idcsa_import].n IS NULL)
	  OR
	  (csa_import.yimport = @ayear AND @idcsa_import is null AND [@lista_idcsa_import].n IS NOT NULL AND [@lista_idreg_agency].n IS NOT NULL)
	) 
	AND (idcsa_contractkinddata IS NULL AND idcsa_contracttax IS NULL )
	AND P.amount < 0
	AND (ISNULL(flagclawback,'N') <> 'S') -- no recuperi

 
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
	null as parentidinc,
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
	T.idacc,
	A.codeacc,
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
ORDER BY  R.title,F.codefin, U.codeupb, A.idacc

RETURN
END


GO


