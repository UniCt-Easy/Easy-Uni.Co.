if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_individuazione_ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_individuazione_ep]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amm'
--setuser 'amministrazione'
--exec [check_csa_individuazione_ep] 28,2018  
CREATE  PROCEDURE [check_csa_individuazione_ep]
(
	@idcsa_import int,
	@ayear		  int 
)
AS BEGIN
CREATE TABLE  #errors (errordescr varchar(400), errorcode int, blockingerror char(1))
--1) LORDI POSITIVI: Conto di costo (idacc_cost) non valorizzato riepiloghi positivi
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  AND idacc  is null and importo > 0
) 
begin
	INSERT INTO #errors VALUES('Conto di costo (idacc) non valorizzato su alcune righe positive del file riepiloghi', 1,'S')
end

DECLARE @idacc_revenue_gross_csa   varchar(38)
SELECT  @idacc_revenue_gross_csa =  idacc_revenue_gross_csa from config where ayear = @ayear
--2) LORDI NEGATIVI: Conto di ricavo lordi (idacc_revenue_gross_csa) non valorizzato riepiloghi negativi (in config)
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  AND @idacc_revenue_gross_csa  is null and importo < 0
) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo lordi non valorizzato riepiloghi negativi (idacc_revenue_gross_csa in configurazione annuale) ', 2,'S')
end

--3)CONTRIBUTI con importo POSITIVO: Conto di costo non configurato per contributi positivi
-- Costo a debito con idacc_cost ove COSTO = idacc_cost DEBITO = ISNULL(_debit , _expense )
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  AND idacc_cost is null and importo > 0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo non valorizzato in righe versamento di contributi positivi  (idacc_cost di csa_importver) ', 3,'S')
end


--4) CONTRIBUTI CON IMPORTO POSITIVO: Conto di debito conto erario  e conto di debito verso erario entrambi non configurati per contributi positivi
-- _debit per i contributi con transito dalle partite di giro
-- _expense per i contributi a liquidazione diretta
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  and idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_debit is null AND idacc_expense is null and importo>0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di debito conto erario e conto di debito verso erario entrambi ' +
								'non valorizzati in righe versamento di contributi positivi (idacc_debit e idacc_expense in csa_importver)', 4,'S')
end

--5) VERSAMENTO RECUPERI: Viene generata una scrittura di COSTO   A  debito vs percipiente
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S'  
  AND idacc_cost is null   and importo<0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo non valorizzato in righe versamento di recuperi negativi (idacc_cost di csa_importver) ', 5,'S')
end

--6) CONTRIBUTI NEGATIVI: credito vs erario A  RICAVO 
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  AND idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_revenue is null and importo<0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo  non valorizzato in righe versamento di contributi negativi (idacc_revenue di csa_importver)', 6,'S')
end



--7) RECUPERI POSITIVI: credito vs erario A  RICAVO 
--Versamento recuperi   credito vs percipiente A  RICAVO 
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S'  
  AND idacc_revenue is null and importo>0
) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo non valorizzato in righe versamento di recuperi positivi (idacc_revenue di csa_importver)', 7,'S')
end
-- 8) RITENUTE POSITIVE: credito vs percipiente       A debito vs erario  ("ente csa")      (diversi     A idacc_expense )
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N'  
  AND (idcsa_contracttax is    null)  
  AND (idcsa_contractkinddata is null)
  AND (idcsa_incomesetup is NOT null)
  AND idacc_expense is null and importo>0
) 
begin
	INSERT INTO #errors VALUES('Conto di debito verso erario  non valorizzato in righe versamento di ritenute positive (idacc_expense di csa_importver)', 8,'S')
end

--9) RITENUTE NEGATIVE   credito vs erario ("ente csa") A debito vs percipiente ("diversi")  (idacc_agency_credit  A   diversi)
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N'  
  AND (idcsa_contracttax is    null)  
  AND (idcsa_contractkinddata is null)
  AND (idcsa_incomesetup is NOT null)
  AND idacc_agency_credit is null and importo<0
) 
begin
	INSERT INTO #errors VALUES('Conto di credito verso erario non valorizzato in righe versamento di ritenute negative  (idacc_agency_credit di csa_importver) ', 9,'S')
end

 

--10)CONTRIBUTI NEGATIVI   credito vs erario A  RICAVO 

 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  AND idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_agency_credit is null and importo<0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di credito verso erario  non valorizzato in righe versamento di contributi negativi (idacc_agency_credit di csa_importver)', 10,'S')
end

--------------------------------------------------------------------------------------------
------------------------- CONTROLLI RELATIVI ALLA CONFIGURAZIONE CSA -----------------------
--------------------------------------------------------------------------------------------

-- 11) Conto di costo per il lordo (idacc_main) non valorizzato in righe Contratti CSA
-- bloccante, obbligatorio per i riepiloghi
 if exists (
 SELECT * FROM csa_contract where ayear = @ayear AND idacc_main is null AND isnull(csa_contract.active, 'N')='S'
 AND NOT EXISTS (SELECT * FROM csa_contract_partition WHERE 
													  csa_contract.idcsa_contract = csa_contract_partition.idcsa_contract AND
													  csa_contract_partition.ayear = @ayear)
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo per il lordo  non valorizzato in righe Contratti CSA (idacc_main di csa_contract)', 11,'S')
end

-- 12) Conto di costo per contributi di contratto (idacc) non valorizzato in righe Contributi di Contratti CSA
-- non bloccante 
 if exists (
 SELECT * FROM csa_contracttax 
   JOIN csa_contract 
     ON csa_contracttax.idcsa_contract =  csa_contract.idcsa_contract
	 AND csa_contracttax.ayear =  csa_contract.ayear
    where csa_contracttax.ayear = @ayear AND csa_contracttax.idacc is null   AND isnull(csa_contract.active, 'N')='S'
	 AND NOT EXISTS (SELECT * FROM csa_contracttax_partition WHERE 
					 csa_contracttax.idcsa_contract = csa_contracttax_partition.idcsa_contract AND
					 csa_contracttax.idcsa_contracttax = csa_contracttax_partition.idcsa_contracttax AND
					 csa_contracttax_partition.ayear = @ayear)
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo per  contributi  non valorizzato in righe Contributi - Regole specifiche CSA  (idacc di csa_contracttax)', 12,'N')
end


-- 13) Conto di costo per   il lordo (idacc_main) non valorizzato in righe Tipi di Contratti CSA attivi
-- non bloccante, dipende dalle situazioni, se ci sono contratti prevale la configurazione dei contratti
 if exists (
 SELECT * FROM csa_contractkindyear 
   JOIN csa_contractkind 
     ON csa_contractkindyear.idcsa_contractkind =  csa_contractkind.idcsa_contractkind
 where csa_contractkindyear.ayear = @ayear AND csa_contractkindyear.idacc_main is null AND isnull(csa_contractkind.active, 'N')='S'
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo per  lordo non valorizzato in righe Regole generali CSA (idacc_main di csa_contractkindyear)', 13,'N')
end



-- 14) Conto di costo per contributi di tipo contratto (idacc) non valorizzato in righe Contributi di Tipi Contratti CSA
-- non bloccante, dipende dalle situazioni
 if exists (
 SELECT * FROM csa_contractkinddata 
  JOIN csa_contractkind 
     ON csa_contractkinddata.idcsa_contractkind =  csa_contractkind.idcsa_contractkind

 where csa_contractkinddata.ayear = @ayear AND csa_contractkinddata.idacc is null AND isnull(csa_contractkind.active, 'N')='S'
  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo per  contributi  non valorizzato in righe Contributi CSA - Regole generali (idacc di csa_contractkinddata)', 14,'N')
end

-- 15) Ripartizione in Impegni di Budget dei contratti  (csa_contractepexp) senza una corrispondente ripartizione nel finanziario (csa_contractexpense) con stesso upb e quota 
 if exists (
select  RipEP.ayear, contractkindcode, contractkind, RipEP.ycontract,RipEP.ncontract, phase, yepexp, nepexp, quota, codeupb,upb
from csa_contractepexpview RipEP
join csa_contract C on C.idcsa_contract =RipEP.idcsa_contract
where  RipEP.ayear = @ayear   and C.active='S'
	and not exists ( 
			select * from csa_contractexpenseview Ripfin 
				where RipEP.idcsa_contract = Ripfin.idcsa_contract 
				and  RipEP.ndetail = Ripfin.ndetail 
				and  RipEP.ayear = Ripfin.ayear
				and  RipEP.idupb = Ripfin.idupb
				and  RipEP.quota = Ripfin.quota
			)
	and not exists ( 
			select * from csa_contract_partition Rip 
				where RipEP.idcsa_contract = Rip.idcsa_contract 
				and  RipEP.ayear = Rip.ayear
			)
  ) 
begin
	INSERT INTO #errors VALUES('Ripartizione in Impegni di Budget delle regole specifiche CSA (tabella csa_contractepexp) ' +
	' senza una corrispondente ripartizione nel finanziario con stesso upb e quota (tabella csa_contractexpense)  ', 15,'S')
end

-- 16) Ripartizione in Impegni di Budget dei contributi (tabella csa_contracttaxtepexp) senza una corrispondente ripartizione nel finanziario (csa_contractexpense) con stesso upb e quota 
 if exists (
select  RipEP.ayear, vocecsa, contractkindcode, contractkind, RipEP.ycontract,RipEP.ncontract, phase, yepexp, nepexp, quota, codeupb,upb
from csa_contracttaxepexpview RipEP
join csa_contract C on C.idcsa_contract =RipEP.idcsa_contract
where  RipEP.ayear = @ayear   and C.active='S' 
	and not exists ( 
			select * from csa_contracttaxexpenseview Ripfin 
				where RipEP.idcsa_contract = Ripfin.idcsa_contract 
				and  RipEP.idcsa_contracttax = Ripfin.idcsa_contracttax
				and  RipEP.ndetail = Ripfin.ndetail 
				and  RipEP.ayear = Ripfin.ayear
				and  RipEP.idupb = Ripfin.idupb
				and  RipEP.quota = Ripfin.quota
				
			)
	and not exists ( 
			select * from csa_contracttax_partition Rip  
				where RipEP.idcsa_contract = Rip.idcsa_contract 
				and  RipEP.idcsa_contracttax = Rip.idcsa_contracttax
				and  RipEP.ayear = Rip.ayear
			)

  ) 
begin
	INSERT INTO #errors VALUES('Ripartizione in Impegni di Budget dei contributi (tabella csa_contracttaxepexp)' +
	' senza una corrispondente ripartizione nel finanziario con stesso upb e quota (tabella csa_contracttaxexpense) ', 16,'S')
end


--17) CONFIGURAZIONE CONTRIBUTI POSITIVI E NEGATIVI a liquidazione diretta: Conto di debito verso ente o Conto EP di Credito Verso Ente o Conto di Ricavo non configurati nella scheda Voce CSA
--  _expense per i contributi a liquidazione diretta 
--  _agency_credit (Conto EP di Credito Verso Ente (Contributi e Ritenute negativi) )
--  _revenue (Conto EP di Ricavo (Contributi e Ritenute negativi) )
 if exists (
 SELECT * FROM csa_incomesetup WHERE ayear =  @ayear AND
  (EXISTS (select * from csa_contracttax WHERE csa_contracttax.vocecsa = csa_incomesetup.vocecsa and csa_contracttax.ayear = csa_incomesetup.ayear )
  OR
  EXISTS (select * from csa_contractkinddata WHERE csa_contractkinddata.vocecsa = csa_incomesetup.vocecsa and csa_contractkinddata.ayear = csa_incomesetup.ayear )
  )
  AND  (idacc_agency_credit is null OR idacc_expense is null OR idacc_revenue is null) 
  AND  idfin_income is null
  ) 
begin
	INSERT INTO #errors VALUES('Conto di Credito verso ente,  Conto di Debito verso ente o conto di ricavo ' +
								' non configurati nella scheda Voce CSA del contributo a liquidazione diretta (idacc_expense, idacc_agency_credit, idacc_revenue in csa_incomesetup)', 17,'S')
end

--18) CONFIGURAZIONE CONTRIBUTI POSITIVI E NEGATIVI su partita di giro: Conto di debito conto ente o Conto EP di Credito Verso Ente non configurati nella scheda Voce CSA
--  _expense  
--  _agency_credit (Conto EP di Credito Verso Ente (Contributi e Ritenute negativi) )
--  _debit (Conto EP di Debito C/Ente (Contributi e Ritenute negativi) )
--  _revenue (Conto EP di Ricavo)
 if exists (
 SELECT * FROM csa_incomesetup WHERE ayear =  @ayear AND
  (EXISTS (select * from csa_contracttax WHERE csa_contracttax.vocecsa = csa_incomesetup.vocecsa and csa_contracttax.ayear = csa_incomesetup.ayear )
  OR
  EXISTS (select * from csa_contractkinddata WHERE csa_contractkinddata.vocecsa = csa_incomesetup.vocecsa and csa_contractkinddata.ayear = csa_incomesetup.ayear )
  )
  AND  (idacc_agency_credit is null OR idacc_expense is null OR idacc_debit is null or idacc_revenue is null) 
  AND  (idfin_income is not null OR idfin_expense is not null) 
  ) 
begin
	INSERT INTO #errors VALUES('Conto di Credito verso ente,  Conto di Debito verso ente, conto di Debito conto Ente o Conto di Ricavo ' +
								' non configurati nella scheda Voce CSA del contributo su partite di giro (idacc_agency_credit, idacc_expense, idacc_debit, idacc_revenue in csa_incomesetup)', 18,'S')
end


--19)Ripartizione EP incoerente con la ripartizione finanziaria
CREATE TABLE #output
(
	descr_err  varchar(400),
	regola_generale varchar(400),
	regola_specifica varchar(400),
	eserc int,
	numero int,
	idcsa_contract int,
	idcsa_contracttax int,
	vocecsa varchar(400),
	riga int,
	quota_ripfin float,
	quota_ripep float
)
            
insert into #output
exec check_csa_partition_inconsistent @ayear 

IF ((SELECT COUNT(*) FROM #output) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria nella configurazione', 19,'S')
END  

----20)Ripartizione EP incoerente con la ripartizione finanziaria in righe di riepilogo
--CREATE TABLE #output_riep
--(
--	descr_err  varchar(400),
--	idcsa_import int,
--	eserc_import int,
--	numero_import int,
--	regola_generale varchar(400),
--	eserc int,
--	numero int,
--	idcsa_contract int,
--	idcsa_contracttax int,
--	riga int,
--	quota_ripfin float,
--	quota_ripep float
--)
            
--insert into #output_riep
--exec check_csa_partition_inconsistent_riep @ayear  , @idcsa_import

--IF ((SELECT COUNT(*) FROM #output_riep) > 0) 
--BEGIN
--	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria in righe di riepilogo', 20,'S')
--END  


----21)Ripartizione EP incoerente con la ripartizione finanziaria in righe di versamento
--CREATE TABLE #output_ver
--(
--	descr_err  varchar(400),
--	idcsa_import int,
--	eserc_import int,
--	numero_import int,
--	regola_generale varchar(400),
--	eserc int,
--	numero int,
--	idcsa_contract int,
--	idver  int,
--	vocecsa varchar(400),
--	riga int,
--	amount_ripfin decimal(19,2),
--	amount_ripep decimal(19,2)
--)
            
--insert into #output_ver
--exec check_csa_partition_inconsistent_ver @ayear , @idcsa_import

--IF ((SELECT COUNT(*) FROM #output_ver) > 0) 
--BEGIN
--	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria in righe di versamento', 21,'S')
--END  

SELECT * FROM #errors

 
DROP TABLE #output   
--DROP TABLE #output_ver
--DROP TABLE #output_riep 

END

 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 --[check_csa_individuazione_ep] 41,2016
 