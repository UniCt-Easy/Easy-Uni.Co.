if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_individuazione_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_individuazione_partition]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  PROCEDURE [check_csa_individuazione_partition]
(
	@idcsa_import int,
	@ayear		  int
)
AS BEGIN

/*
setuser 'amm'
setuser 'amministrazione'
exec [check_csa_individuazione_partition] 29,2018 
*/
--- deve partire da 58
--SET      @res = 0	
CREATE TABLE #errors (errordescr varchar(255), errorcode int, blockingerror char(1))

--1) Esercizio non valorizzato riepiloghi
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  AND ayear  is null
) 
begin
	INSERT INTO #errors VALUES('Esercizio non valorizzato su alcune righe del file riepiloghi', 1,'S')
end

--2) Esercizio non valorizzato versamenti
 if exists (
  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND ayear is null
) 
begin
	INSERT INTO #errors VALUES('Esercizio non valorizzato su alcune righe del file versamenti', 2,'S')
end
--3) Regola generale o specifica non determinato
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  and idcsa_contractkind is null
) 
begin
	INSERT INTO #errors VALUES('Regola generale o specifica non determinata in righe riepiloghi', 3,'S')
end
--'4) Regola generale o specifica non determinato in righe versamenti'
 if exists (
  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND idcsa_contractkind is null
) 
begin
	INSERT INTO #errors VALUES('Regola generale o specifica non determinato in righe versamenti', 4,'S')
end

--5) Recupero, Ritenuta o Contributo senza imputazione
 if exists (
  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND idcsa_contracttax is null AND idcsa_incomesetup is null 
  and idcsa_contractkinddata is null
)
begin
	INSERT INTO #errors VALUES('Recupero, Ritenuta o Contributo senza imputazione', 5,'S')
 end

--6) Versamenti con Ente o Anagrafica Ente non valorizzati
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND (idcsa_agency is null OR idreg_agency is null or idreg_agency = 0)
) 
begin
	INSERT INTO #errors VALUES('Versamenti con Ente o Anagrafica Ente non valorizzati', 6,'S')
end

--- I Recuperi saranno tutti diretti con la nuiva gestione, sono state eliminate
--- le partite di giro
--  7) Recupero Senza Capitolo di Entrata Lordi  idfin_incomeclawback 
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
AND ISNULL(flagclawback,'N') = 'S' 
AND (idfin_incomeclawback IS NULL)  --recupero diretto
) 
begin
	INSERT INTO #errors VALUES('Recupero senza Capitolo di Entrata (Lordi)', 7,'S')
end


--9) Recupero, capitolo spesa non valorizzato per le righe negative
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
 AND ISNULL(flagclawback,'N') = 'S'  AND ISNULL(importo,0)< 0 
 AND
 ( not exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver 
                        )  OR
    exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver and
                              (CP.idfin is null  or CP.idupb is null)
                        ) 
						)    
) 
begin
	INSERT INTO #errors VALUES('Recupero senza il capitolo di spesa o UPB (Costo) valorizzato' , 9,'S')
end

--11) Contributi senza Capitolo di Costo  ,   
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			AND ISNULL(flagclawback,'N') = 'N' and
			((idcsa_contractkinddata is not null) or (idcsa_contracttax is not null))
		  AND
			( not exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver 
                        )  OR
    exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver and
                            (CP.idfin is null  or CP.idupb is null)
                        ) 
						)                        
) 
begin
	INSERT INTO #errors VALUES('Contributi senza  Capitolo di Costo o UPB nella ripartizione' ,11,'S' )
end


--12)  Ritenuta : idfin_expense --> idfin_income
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
  AND ISNULL(flagclawback,'N') = 'N' and
  (idcsa_contractkinddata is null) and 
  (idcsa_contracttax is not null)
  and idfin_income is  null 
  and idfin_expense is NOT null
) 
begin
	INSERT INTO #errors VALUES( 'Ritenute senza Cap. Entrata e con Cap. Spesa relativo al Versamento' , 12,'S')
end


--13)  Ritenuta: idfin_income --> idfin_expense
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
   AND ISNULL(flagclawback,'N') = 'N' and
  (idcsa_contractkinddata is null) and 
  (idcsa_contracttax is not null)
  and idfin_income is  not null 
  and idfin_expense is null
) 
begin
	INSERT INTO #errors VALUES( 'Ritenute con Cap. Entrata e senza Cap. Spesa relativo al Versamento' , 13,'S')
end


--14) Errata configurazione ripartizione unica delle regole specifiche CSA
 if exists (SELECT C.idcsa_contract , C.ycontract as 'Eserc. Contratto', C.ncontract as Numero, sum(CP.quota)  
                     from csa_contract_partition CP  
                     join csa_contract C on C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear 
                     where C.ayear = @ayear  and C.active = 'S' 
                     group by  C.ycontract,C.ncontract, C.idcsa_contract  , C.active
                     having abs(sum(CP.quota)-1) > 0.000001 
) 
begin
	INSERT INTO #errors VALUES( 'Errata configurazione della ripartizione unica delle regole specifiche CSA (quote)', 14,'S')
end


--15) Errata configurazione ripartizione unica dei contributi
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc. Regola specifica CSA', C.ncontract as Numero, 
				C.description as 'Descrizione', sum(quota) as Quota  
                from csa_contracttax_partition CTP  
                join csa_contracttax CT on CTP.idcsa_contract=CT.idcsa_contract and  
					 CTP.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTP.ayear = CT.ayear 
                     join csa_contract C on C.idcsa_contract=CTP.idcsa_contract and CTP.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S' 
                     group by C.idcsa_contract,  C.ycontract,C.ncontract ,vocecsa, C.description , C.active
                     having abs(sum(CTP.quota)-1) > 0.000001  
) 
begin
	INSERT INTO #errors VALUES('Errata configurazione della ripartizione  unica dei contributi (quote)', 15,'S')
end
  
--16) Riepiloghi senza UPB ,   
 if exists (SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import  			
  AND
   ( not exists (select * from csa_importriep_partition CP where  
                            CP.idcsa_import= csa_importriep.idcsa_import and
							CP.idriep= csa_importriep.idriep 
                        )  OR
    exists (select * from csa_importriep_partition CP where  
                            CP.idcsa_import= csa_importriep.idcsa_import and
							CP.idriep= csa_importriep.idriep and
                            CP.idupb is null  
                        ) 
						)
                           
) 
begin
	INSERT INTO #errors VALUES('Riepiloghi senza UPB nella ripartizione' ,16,'S' )
end


 --17) Upb non presente sulle righe di versamento per recuperi non figurativi
 if exists (   SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S' 
  AND idcsa_contracttax is  null and idcsa_contractkinddata is   null  and idcsa_incomesetup is not null 
  AND
   ( not exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver
                        )  OR
    exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import= csa_importver.idcsa_import and
							CP.idver= csa_importver.idver and
                            CP.idupb is null  
                        ) 
						)

) 
begin
INSERT INTO #errors VALUES('Verifica upb  non presente sulle righe di versamento per recuperi non figurativi, 
			 controllare  la configurazione incassi della scheda VOCE CSA', 17,'S')

end

 --20) Elenco contributi con importo negativo
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contractkinddata is  not   null or  idcsa_contracttax is not null) and isnull(importo,0) <0)
begin
	INSERT INTO #errors VALUES( 'Contributi con importo negativo (non è un errore)', 20,'N')
end

 --21) Righe Versamenti Associate a Config. Contributi e non a Incassi
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contractkinddata is  not   null or  idcsa_contracttax is not null) and idcsa_incomesetup is null)
begin
	INSERT INTO #errors VALUES( 'Righe Versamenti Associate a Config. Contributi e non a Incassi', 21,'N')
end

 --22) Righe Versamenti non configurate correttamente nè come Contributi, nè come Ritenute, nè Recuperi
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND idcsa_contractkinddata is   null and  idcsa_contracttax is null  and idfin_income is   null)
begin
	INSERT INTO #errors VALUES( ' Righe Versamenti non configurate correttamente nè come Contributi, nè come Ritenute, nè come Recuperi', 22,'S')
end
        

--24) Righe versamento con voce CSA ai fini del raggruppamento aventi configurazione non omogenea  
 if   exists
(
select * from csa_importver T  
 where   idcsa_import = @idcsa_import  and  T.vocecsaunified is not null and
 (select count(*) from csa_importver T2 where
  ISNULL(T2.vocecsaunified, vocecsa)= T.vocecsaunified AND
		 T2.idcsa_import= T.idcsa_import AND 
 (
		isnull(T.ente,'') <>isnull(T2.ente,'') OR
		isnull(T.flagcr,'') <>isnull(T2.flagcr,'') OR
		isnull(T.ayear,0) <>isnull(T2.ayear,0) OR
	 	isnull(T.idcsa_agency,0) <>isnull(T2.idcsa_agency,0) OR
		isnull(T.idfin_income,0) <>isnull(T2.idfin_income,0) OR
		isnull(T.idacc_debit,'') <>isnull(T2.idacc_debit,'') OR
		isnull(T.idfin_expense,0) <>isnull(T2.idfin_expense,0) OR
		isnull(T.idacc_expense,'') <>isnull(T2.idacc_expense,'') OR
		isnull(T.idfin_incomeclawback,0) <>isnull(T2.idfin_incomeclawback,0) OR
		isnull(T.idacc_internalcredit,0) <>isnull(T2.idacc_internalcredit,0) OR
		isnull(T.idreg_agency,0) <>isnull(T2.idreg_agency,0) OR
		isnull(T.idcsa_agencypaymethod,0) <>isnull(T2.idcsa_agencypaymethod,0) OR
		isnull(T.idexp_cost,0) <>isnull(T2.idexp_cost,0) OR
		isnull(T.idfin_cost,0) <>isnull(T2.idfin_cost,0) OR
		isnull(T.idacc_cost,'') <>isnull(T2.idacc_cost,'') OR
		isnull(T.flagclawback,'') <>isnull(T2.flagclawback,'') OR
		isnull(T.idreg,0) <>isnull(T2.idreg,0) OR
		isnull(T.idupb,'') <>isnull(T2.idupb,'') OR
		isnull(T.idacc_revenue,'') <>isnull(T2.idacc_revenue,'') OR
		isnull(T.competency,'') <>isnull(T2.competency,'') OR
		isnull(T.idacc_agency_credit,'') <>isnull(T2.idacc_agency_credit,'') OR
		isnull(T.flagdirectcsaclawback,'') <>isnull(T2.flagdirectcsaclawback,'') OR
		isnull(T.idsor_siope_income,0) <>isnull(T2.idsor_siope_income,0) OR
		isnull(T.idsor_siope_expense,0) <>isnull(T2.idsor_siope_expense,0) OR
		isnull(T.idsor_siope_cost,0) <>isnull(T2.idsor_siope_cost,0) OR
		isnull(T.idunderwriting,0) <>isnull(T2.idunderwriting,0) 
  )) > 0)
 
begin
	INSERT INTO #errors VALUES('Righe versamento con Voce CSA di raggruppamento, ma configurazione non omogenea' , 24,'S')
end       

CREATE TABLE #output
(
	phase  varchar(400),
	finance varchar(400),
	upb varchar(400),
	registry varchar(200),
	curramount decimal(19,2),
	available_1  decimal(19,2),
	available_2  decimal(19,2),
	available_3  decimal(19,2),		
	available_4  decimal(19,2),
	flagcr char(1),
	idexp int
)
            
insert into #output
exec exp_csa_expense_available_partition @ayear, @idcsa_import --,@kind

IF ((SELECT COUNT(*) FROM #output) > 0) 
--25) Movimenti padre con disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Movimenti padre con disponibile insufficiente' , 25,'S')
END  



DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

CREATE TABLE #output_1
(
	idfin int,
	idupb varchar(36),
	phase  varchar(400),
	codefin varchar(50),
	fin varchar(400),
	codeupb varchar(50),
	upb varchar(400),
	available_1  decimal(19,2),
	available_2  decimal(19,2),
	available_3  decimal(19,2),		
	available_4  decimal(19,2),
	available_5  decimal(19,2),
	available_6  decimal(19,2),
	available_7  decimal(19,2),
	available_8  decimal(19,2)  
)
CREATE TABLE #output_2
(
	idfin int,
	idupb varchar(36),
	phase  varchar(400),
	codefin varchar(50),
	fin varchar(400),
	codeupb varchar(50),
	upb varchar(400),
	available_1  decimal(19,2),
	available_2  decimal(19,2),
	available_3  decimal(19,2),		
	available_4  decimal(19,2)
)
if (@fin_kind=3) begin
insert into #output_1	exec exp_csa_fin_upb_available @ayear, @idcsa_import 
IF ((SELECT COUNT(*) FROM #output_1) > 0) 
--26) Coppie Bilancio - UPB con previsione disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Coppie Bilancio - UPB con previsione disponibile insufficiente' , 26,'N')
END 
end
else begin

insert into #output_2	exec exp_csa_fin_upb_available @ayear, @idcsa_import 
IF ((SELECT COUNT(*) FROM #output_2) > 0) 
--26) Coppie Bilancio - UPB con previsione disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Coppie Bilancio - UPB con previsione disponibile insufficiente' , 26,'N')
END 

end

--28) Ente CSA associato ad anagrafiche non attive in righe versamenti 
 if exists (
 SELECT * FROM csa_importver 
	join csa_agency on csa_importver.idcsa_agency = csa_agency.idcsa_agency
	join registry on registry.idreg = csa_agency.idreg 
 WHERE idcsa_import = @idcsa_import AND ISNULL(registry.active,'S') = 'N'
) 
begin
	INSERT INTO #errors VALUES('Ente CSA associato ad anagrafiche non attive in righe versamenti', 28,'S')
end

--38)   Importo mal ripartito nelle righe di riepilogo
if exists (   SELECT  C.idriep as 'N.riepilogo', C.importo,
						(select sum(CE.amount)  from  csa_importriep_partition CE  
								where C.idcsa_import=CE.idcsa_import and C.idriep=CE.idriep) as somma
                     from CSA_importriep C 
						where  C.idcsa_import = @idcsa_import					
							and (select sum(CE.amount)  from  csa_importriep_partition CE  
								where C.idcsa_import=CE.idcsa_import and C.idriep=CE.idriep)<> C.importo
) 
begin
	INSERT INTO #errors VALUES( 'Importo mal ripartito nelle righe di riepilogo' , 38,'S')
end


--39)  Importo mal ripartito nelle righe dei contributi (versamenti)
 if exists (   SELECT  C.idver as 'N.versamento', C.importo,
						(select sum(CE.amount)  from  csa_importver_partition CE  
								where C.idcsa_import=CE.idcsa_import and C.idver=CE.idver) as somma
                     from CSA_importver C 
						where  C.idcsa_import = @idcsa_import				
							and (select sum(CE.amount)  from  csa_importver_partition CE  
								where C.idcsa_import=CE.idcsa_import and C.idver=CE.idver)<> C.importo
) 
begin
	INSERT INTO #errors VALUES( 'Importo mal ripartito nelle righe dei versamenti' , 39,'S')
end

--46) Ritenute  con importo negativo senza  il Conto di Credito verso Ente
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND idfin_cost is   null 
  AND idexp_cost is null 
  AND idfin_income is not  null 
  AND idfin_expense is not  null 
  AND idacc_agency_credit is null 
  AND isnull(importo,0) <0)
begin
	INSERT INTO #errors VALUES( 'Ritenute negative senza indicazione del Conto di Credito verso Ente (verrano generate non correttamente le scritture)', 46,'S')
end




DECLARE @flagepexp char(1)  -- configurazione gestione impegni di budget

SELECT 
		@flagepexp = ISNULL(flagepexp,'N') 
FROM config
WHERE ayear = @ayear




 -- 49)'Esistono movimenti finanziari mal ripartiti su finanziamenti'
if exists (select *
	 from expensecreditproceedsview E1 
	join expenselink EL on EL.idparent=E1.idexp
		where curramount <> 
	(select sum(E2.appropriation) from expensecreditproceedsview E2 where E1.idexp=E2.idexp and E1.ayear=E2.ayear)
	and E1.ayear=@ayear  and
	 (EL.idchild in (select idexp from csa_importriep where idcsa_import=@idcsa_import) OR	
	  EL.idchild in (select idexp_cost from csa_importver where idcsa_import=@idcsa_import) OR
	  EL.idchild in (select idexp from csa_importriep_expense where idcsa_import=@idcsa_import) OR
	  EL.idchild in (select idexp from csa_importriep_partition where idcsa_import=@idcsa_import) OR
	  EL.idchild in (select idexp from csa_importver_expense where idcsa_import=@idcsa_import) OR
	  EL.idchild in (select idexp from csa_importver_partition where idcsa_import=@idcsa_import) 
	)
	)
begin
	INSERT INTO #errors VALUES('Esistono movimenti finanziari mal ripartiti su finanziamenti', 49,'S')
end

 
--50)    Righe di riepilogo con movimento di spesa senza imputazione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importriep R
					  JOIN csa_importriep_partition RP  
						ON R.idcsa_import = RP.idcsa_import
						AND  R.idriep = RP.idriep
						AND  RP.idexp IS NOT NULL
                        WHERE R.ayear = @ayear 
						AND R.idcsa_import = @idcsa_import  
					    AND NOT EXISTS  (SELECT * FROM  expenseyear EY WHERE 
										EY.idexp = RP.idexp AND
							            R.ayear = EY.ayear)                
) 
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con movimento di spesa senza imputazione nell''esercizio corrente' , 50,'S')
end

--51)  Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importver V
					  JOIN csa_importver_partition VP  
						ON V.idcsa_import = VP.idcsa_import
						AND  V.idver = VP.idver
						AND  VP.idexp IS NOT NULL
                       WHERE V.ayear = @ayear   
					   AND V.idcsa_import = @idcsa_import  
					   AND NOT EXISTS (SELECT * FROM  expenseyear EY WHERE 
										EY.idexp = VP.idexp AND
							            V.ayear = EY.ayear)                
) 
begin
	INSERT INTO #errors VALUES( 'Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente' , 51,'S')
end

--52)   Movimento di spesa impostato nella ripartizione dei contratti senza imputazione nell'esercizio corrente
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, 	CE.idcsa_contract as '#idcsa_contract'
                     from csa_contract_partition CE  
                       join csa_contract C on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear 
                       where CE.idexp is not null AND C.ayear = @ayear  and C.active = 'S' 
					   and not exists (select * from expenseyear EY where 
										EY.idexp = CE.idexp AND
							            C.ayear = EY.ayear)                
) 
begin
	INSERT INTO #errors VALUES( 'Movimento di spesa impostato nella ripartizione delle Regole Specifiche senza imputazione nell''esercizio corrente' , 52,'S')
end

--53)    Movimento di spesa  impostato nella ripartizione dei contributi senza imputazione nell'esercizio corrente
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.description as 'Descrizione', CT.vocecsa,
				CTE.idcsa_contracttax as '#idcsa_contracttax'
                from csa_contracttax_partition CTE  
                join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear 
                     join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear 
                     where CTE.idexp is not null AND C.ayear = @ayear  and C.active = 'S' 
					 and not exists (select * from expenseyear EY where 
										EY.idexp = CTE.idexp AND
							            C.ayear = EY.ayear)
)
begin
	INSERT INTO #errors VALUES('Movimento di spesa impostato nella ripartizione dei contributi senza imputazione nell''esercizio corrente', 53,'S')
end

-----------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------

-- 60) Righe di versamento  non ripartite,  deve sempre essere presente almeno una riga
-- sia che si tratti di contributi, di recuperi o di ritenute 
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			and  not exists (select * from csa_importver_partition CP where  
                            CP.idcsa_import = csa_importver.idcsa_import and
                            CP.idver = csa_importver.idver
                        )                             
) 
begin
	INSERT INTO #errors VALUES('Righe di versamento non ripartite' ,60,'S' )
end


-- 61) Righe di riepilogo  non ripartite,  deve sempre essere presente almeno una riga
 if exists (SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import  
			and  not exists (select * from csa_importriep_partition CP where  
                            CP.idcsa_import = csa_importriep.idcsa_import and
                            CP.idriep = csa_importriep.idriep
                        )                             
) 
begin
	INSERT INTO #errors VALUES('Righe di riepilogo non ripartite' ,61,'S' )
end

-- 62) Sospeso uscita per elaborazione dei lordi non valorizzato
 if exists (SELECT * FROM csa_import WHERE idcsa_import = @idcsa_import  
			and ybill_netti is null                            
)                         
begin
	INSERT INTO #errors VALUES('Nell''importazione manca il sospeso uscita da collegare ai pagamenti netti per l''elaborazione dei lordi' ,62,'N' )
end

-- 63) Sospeso uscita per elaborazione dei versamenti non valorizzato - esercizio corrente
 if exists (SELECT * FROM csa_import WHERE idcsa_import = @idcsa_import  
			and (ybill_versamenti is null  or ybill_versamenti <> @ayear)    
			and exists (select * from csa_agency join csa_importver on csa_importver.idcsa_agency =csa_agency.idcsa_agency  where csa_import.idcsa_import =csa_importver.idcsa_import and  (ISNULL(csa_agency.flag,0)&2) =0 )  
			--and month(adate) < 12                        
)  
begin
	INSERT INTO #errors VALUES('Nell''importazione manca il sospeso uscita emesso nell''esercizio corrente da collegare ai versamenti' ,63,'N' )
end


---- 64)Sospeso uscita per elaborazione dei versamenti di dicembre non valorizzato - esercizio successivo
-- if exists (SELECT * FROM csa_import WHERE idcsa_import = @idcsa_import  
--			and (ybill_versamenti is null   or ybill_versamenti <> @ayear + 1)
--			and exists (select * from csa_agency join csa_importver on csa_importver.idcsa_agency =csa_agency.idcsa_agency  where csa_import.idcsa_import =csa_importver.idcsa_import and  (ISNULL(csa_agency.flag,0) &2) =0 )  
--			and month(adate) = 12                         
--) 
--begin
--	INSERT INTO #errors VALUES('Nell''importazione di dicembre manca il sospeso uscita emesso nell''esercizio successivo da collegare ai versamenti' ,64,'S' )
--end


-- 65) CONFIGURAZIONE REGOLE SPECIFICHE E CONTRIBUTI: PARTIZIONE UNICA NON CREATA PER INCOERENZA NELLE RIPARTIZIONI ORIGINALI
CREATE TABLE #output_3
(
	descr_err  varchar(400),
	regola_generale varchar(400),
	regola_specifica varchar(400),
	eserc int,
	numero int,
	idcsa_contract int,
	idcsa_contracttax int,
	vocecsa varchar(400)
)
            
insert into #output_3
exec check_csa_partition_not_created @ayear 

IF ((SELECT COUNT(*) FROM #output_3) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione unica non creata per ripartizioni di partenza errate', 65,'S')
END  

---- 68) ANAGRAFICHE RIEPILOGHI PRIVE DI MODALITA' DI PAGAMENTO STANDARD  (NON SERVE, IL NETTO  A PAGARE DEVE ESSERE A REGOLARIZZAZIONE)
-- if exists (
--  SELECT * FROM csa_importriep WHERE 
--  idcsa_import = @idcsa_import 
--  AND idreg is not null
--  AND (SELECT count(*) 
--	   FROM registrypaymethod 
--	   WHERE flagstandard = 'S' 
--	   AND  idreg = csa_importriep.idreg ) = 0
--) 
--BEGIN
--	INSERT INTO #errors VALUES('Anagrafiche riepiloghi prive di modalità di pagamento standard', 68,'S')
--END  

-- 69) ANAGRAFICHE ENTI VERSAMENTO CSA PRIVE DI MODALITA' DI PAGAMENTO STANDARD
if exists (
  SELECT * FROM csa_importver WHERE 
  idcsa_import = @idcsa_import 
  AND idreg_agency is not null
  AND (SELECT count(*) 
	   FROM registrypaymethod 
	   WHERE flagstandard = 'S' 
	   AND  idreg = csa_importver.idreg_agency ) = 0
    AND (SELECT count(*) 
	   FROM csa_agency 
	   WHERE (ISNULL(csa_agency.flag,0) &2) <>0
	   AND  idcsa_agency = csa_importver.idcsa_agency ) <> 0
) 
BEGIN
	INSERT INTO #errors VALUES('Anagrafiche Enti Versamento CSA prive di modalità di pagamento standard', 69,'S')
END 


---- 70) ANAGRAFICHE RIEPILOGHI INCOERENTI CON QUELLE DEI MOVIMENTI FINANZIARIDELLA RIPARTIZIONE
 if exists (
   SELECT * 
	  FROM csa_importriep_partition 
	  JOIN csa_importriep
	  ON  csa_importriep_partition.idcsa_import = csa_importriep.idcsa_import 
	  AND csa_importriep_partition.idriep = csa_importriep.idriep
	  WHERE 
	  csa_importriep.idcsa_import = @idcsa_import 
	  AND csa_importriep.idreg is not null  AND csa_importriep_partition.idexp is not null
	  AND (SELECT count(*) 
		   FROM expense 
		   WHERE expense.idexp = csa_importriep_partition.idexp
		   AND  expense.idreg IS NOT NULL AND ISNULL(expense.idreg,0) <>  ISNULL(csa_importriep.idreg,0) ) > 0
) 
BEGIN
	INSERT INTO #errors VALUES('Anagrafiche riepiloghi incoerenti con quelle dei movimenti finanziari della ripartizione', 70,'S')
END  
  
-- 71) ANAGRAFICHE VERSAMENTO CSA INCOERENTI CON QUELLE DEI MOVIMENTI FINANZIARI DELLA RIPARTIZIONE
if exists (
  SELECT * 
  FROM csa_importver_partition 
  JOIN csa_importver 
  ON  csa_importver_partition.idcsa_import = csa_importver.idcsa_import 
  AND csa_importver_partition.idver = csa_importver.idver

  WHERE 
  csa_importver.idcsa_import = @idcsa_import 
  AND csa_importver.idreg is not null  AND csa_importver_partition.idexp is not null
  AND (SELECT count(*) 
	   FROM expense 
	   WHERE expense.idexp = csa_importver_partition.idexp 
	   AND expense.idreg IS NOT NULL AND  ISNULL(expense.idreg,0) <>  ISNULL(csa_importver.idreg,0) ) > 0
) 
BEGIN
	INSERT INTO #errors VALUES('Anagrafiche versamenti incoerenti con quelle dei movimenti finanziari della ripartizione', 71,'S')
END 


--74)    Ritenuta con capitolo  costo valorizzato
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
  AND ISNULL(flagclawback,'N') = 'N' and
  (idcsa_contractkinddata is null) and 
  (idcsa_contracttax is null)
  and idfin_income is not null 
  and idfin_cost is not null
) 
begin
	INSERT INTO #errors VALUES( 'Ritenute con Cap. di Costo  o movimento spesa costo, valorizzato , riservato, invece, ai Recuperi' , 74,'S')
end

--75) Ripartizione  Ritenuta con capitolo  costo valorizzato
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
  AND ISNULL(flagclawback,'N') = 'N' and
  (idcsa_contractkinddata is null) and 
  (idcsa_contracttax is null)
  and idfin_income is not null 
  and exists (select * from csa_importver_partition where csa_importver.idcsa_import =csa_importver_partition.idcsa_import and csa_importver.idver =csa_importver_partition.idver  and csa_importver_partition.idfin is not null)
) 
begin
	INSERT INTO #errors VALUES( 'Ripartizioni Ritenute con Cap. di Costo o movimento spesa costo valorizzato, riservato, invece, ai Recuperi' , 75,'S')
end

--76) Contributi negativi  senza capitolo di entrata   valorizzato o senza classificazione Siope Entrata
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contractkinddata is  not   null or  idcsa_contracttax is not null) and (isnull(importo,0) <0)
  AND 	(idfin_incomeclawback is null
  OR 	idsor_siope_incomeclawback IS NULL)
) 
begin
	INSERT INTO #errors VALUES( 'Contributi con importo negativo senza capitolo di entrata o classificazione Siope entrata configurati' , 76,'S')
end

--DROP TABLE #output   
--DROP TABLE #output_1       
SELECT * FROM #errors

END

 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 