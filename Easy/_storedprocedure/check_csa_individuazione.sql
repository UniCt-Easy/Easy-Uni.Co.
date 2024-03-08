
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_individuazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_individuazione]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  PROCEDURE [check_csa_individuazione]
(
	@idcsa_import int,
	@ayear		  int  
)
AS BEGIN
 
/*
setuser 'amm'
setuser 'amministrazione'
exec [check_csa_individuazione] 2,2018  
*/
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
--'4) Regola generale o specifica non determinato in righe riepiloghi'
 if exists (
  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND idcsa_contractkind is null
) 
begin
	INSERT INTO #errors VALUES('Regola generale o specifica non determinata in righe versamenti', 4,'S')
end

--5) Recupero, Ritenuta o Contributo senza imputazione
 if exists (
  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
  AND idcsa_contracttax is null AND idcsa_incomesetup is null 
  and idcsa_contractkinddata is null and idfin_cost is null and idexp_cost is null
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
DECLARE @flagdirectcsaclawback CHAR(1)
SELECT 
	@flagdirectcsaclawback = flagdirectcsaclawback
FROM config
WHERE ayear = @ayear

--7) Recupero Senza Capitolo di Entrata Lordi idfin_income o idfin_incomeclawback a seconda dei casi
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
 AND ISNULL(flagclawback,'N') = 'S' 
AND (
	(ISNULL(flagdirectcsaclawback,ISNULL(@flagdirectcsaclawback,'N'))= 'N' AND idfin_income IS NULL) OR  --partita di giro
	(ISNULL(flagdirectcsaclawback,ISNULL(@flagdirectcsaclawback,'N'))= 'S' AND idfin_incomeclawback IS NULL)  --recupero diretto
	)
) 
begin
	INSERT INTO #errors VALUES('Recupero diretto o su partita di giro Senza Capitolo di Entrata (Lordi)', 7,'S')
end

--8) Recupero su partita di giro : idfin_expense --> idfin_income e viceversa
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
 AND ISNULL(flagclawback,'N') = 'S' and ISNULL(flagdirectcsaclawback,ISNULL(@flagdirectcsaclawback,'N'))= 'N' AND
  ((idfin_expense IS NULL AND idfin_income IS NOT NULL) OR 
   (idfin_expense IS NOT NULL AND idfin_income IS NULL))
) 
begin
	INSERT INTO #errors VALUES('Recupero su partita di giro senza capitolo di spesa o entrata (Versamenti)', 8,'S')
end

--9) Recupero diretto : idfin_cost  is null, capitolo spesa non valorizzato per le righe negative
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
 AND ISNULL(flagclawback,'N') = 'S' and ISNULL(flagdirectcsaclawback, ISNULL(@flagdirectcsaclawback,'N'))= 'S' AND
 (idfin_cost IS NULL)  and ISNULL(importo,0)< 0
) 
begin
	INSERT INTO #errors VALUES('Recupero diretto senza il capitolo di spesa (costo) valorizzato' , 9,'S')
end

--10) Recupero su partita di giro : idfin_incomeclawback per movimento di entrata post- versamento 
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
 AND ISNULL(flagclawback,'N') = 'S' and ISNULL(flagdirectcsaclawback, ISNULL(flagdirectcsaclawback,ISNULL(@flagdirectcsaclawback,'N')))= 'N' AND
 (idfin_incomeclawback IS NULL)  
) 
begin
	INSERT INTO #errors VALUES('Recupero su partita di giro : capitolo di entrata interno mancante per movimento di entrata post- versamento' , 10,'S')
end

--11) Contributi senza Capitolo di Costo o di Spesa per il Versamento o Contributi Figurativi,  si tratta di errore
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
 AND ISNULL(flagclawback,'N') = 'N' and
       (((idcsa_contractkinddata is not null) or (idcsa_contracttax is not null)) and
        (idfin_cost is null) and (idexp_cost is null) and (idfin_expense is null))
         AND NOT EXISTS(select * from csa_contracttaxexpense CE where  
                            CE.idcsa_contract = csa_importver.idcsa_contract and
                                    CE.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CE.ayear = @ayear
                        )   
		   AND NOT EXISTS(select * from csa_contracttax_partition CP where  
                            CP.idcsa_contract = csa_importver.idcsa_contract and
                                    CP.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CP.ayear = @ayear
                        )                             
) 
begin
	INSERT INTO #errors VALUES('Contributi senza Capitolo di Costo o di Spesa per il Versamento o Contributi Figurativi' , 11,'S' )
end

                                    
--12)  Ritenuta o Contributo: idfin_expense --> idfin_income
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
  AND ISNULL(flagclawback,'N') = 'N' and idfin_income is  null 
  and idfin_expense is NOT null
) 
begin
	INSERT INTO #errors VALUES( 'Ritenute o Contributi senza Cap. Entrata e con Cap. Spesa relativo al Versamento' , 12,'S')
end


--13)  Ritenuta o Contributo: idfin_income --> idfin_expense
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
  AND ISNULL(flagclawback,'N') = 'N' and idfin_income is not null 
  and idfin_expense is  null
) 
begin
	INSERT INTO #errors VALUES( 'Ritenute o Contributi con Cap. Entrata e senza Cap. Spesa relativo al Versamento' , 13,'S')
end



--14)   Errata configurazione ripartizione delle regole specifiche CSA
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Contratto', C.ncontract as Numero, sum(CE.quota)  
                     from csa_contractexpense CE  
                       join csa_contract C on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear 
                       where C.ayear = @ayear  and C.active = 'S' 
					   and not exists (SELECT *
									   FROM   csa_contract_partition CP  
									   WHERE  C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear )
                      group by  C.ycontract,C.ncontract, C.idcsa_contract  , C.active
                      having abs(sum(CE.quota)-1) > 0.000001 
) 
 

begin
	INSERT INTO #errors VALUES( 'Errata configurazione ripartizione delle regole specifiche CSA (quote)' , 14,'S')
end


--15)   Errata configurazione ripartizione dei contributi
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.description as 'Descrizione', sum(quota) as Quota  
                from csa_contracttaxexpense CTE  
                join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear 
                     join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S' 
					 and not exists (SELECT *
									   FROM   csa_contracttax_partition CTP  
									   WHERE  CT.idcsa_contracttax = CTP.idcsa_contracttax and
											  CT.idcsa_contract=CTP.idcsa_contract and 
											  CT.ayear=CTP.ayear)
                     group by C.idcsa_contract,  C.ycontract,C.ncontract ,vocecsa, C.description , C.active
                     having abs(sum(quota)-1) > 0.000001  
) 
begin
INSERT INTO #errors VALUES('Errata configurazione della ripartizione  dei contributi (quote)', 15,'S')
end


--16)   Verifica upb non presente sulle righe di riepilogo
 if exists (   SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  and idupb is null and idexp is null  AND NOT EXISTS (SELECT * FROM csa_importriep_expense
	  WHERE csa_importriep.idcsa_import = csa_importriep_expense.idcsa_import
			AND csa_importriep.idriep = csa_importriep_expense.idriep
		 AND NOT EXISTS (SELECT * FROM csa_contract_partition
	   WHERE csa_importriep.idcsa_contract = csa_contract_partition.idcsa_contract
			AND csa_importriep.ayear = csa_contract_partition.ayear))
) 
begin
INSERT INTO #errors VALUES(' Verifica upb non presente sulle righe di riepilogo, controllare  la configurazione della scheda della regola generale o specifica CSA', 16,'S')
end



 --17)   Verifica upb non presente sulle righe di versamento per recuperi non figurativi
 if exists (   SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S' 
  AND idcsa_contracttax is  null and idcsa_contractkinddata is   null  and idcsa_incomesetup is not null 
  AND idupb is null
) 
begin
INSERT INTO #errors VALUES('Verifica upb  non presente sulle righe di versamento per recuperi non figurativi, 
			 controllare  la configurazione incassi della scheda VOCE CSA', 17,'S')

end

 --18)   Verifica upb non presente sulle righe di versamento per contributi non figurativi
 if exists (   SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null) and idcsa_incomesetup is not null 
  AND idupb is null and idexp_cost is null 
	  AND NOT EXISTS (SELECT * FROM csa_contracttaxexpense
	  WHERE csa_importver.idcsa_contract = csa_contracttaxexpense.idcsa_contract
			AND csa_importver.idcsa_contracttax = csa_contracttaxexpense.idcsa_contracttax
			AND csa_importver.ayear = csa_contracttaxexpense.ayear)

	    AND NOT EXISTS (SELECT * FROM csa_contracttax_partition
	  WHERE csa_importver.idcsa_contract = csa_contracttax_partition.idcsa_contract
			AND csa_importver.idcsa_contracttax = csa_contracttax_partition.idcsa_contracttax
			AND csa_importver.ayear = csa_contracttax_partition.ayear)
) 
begin
INSERT INTO #errors VALUES( 'Verifica upb non presente sulle righe di versamento per contributi non figurativi, controllare  la configurazione della scheda 
contributo della regola generale o specifica CSA', 18,'S')
end

-- --19)  Verifica upb non presente sulle righe di versamento per RITENUTE
-- if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
--  ISNULL(csa_importver.flagclawback,'N') = 'N' 
--  AND (idcsa_contracttax is    null and  idcsa_contractkinddata is null) and idcsa_incomesetup is not null 
--  AND idupb is null)
--begin
--INSERT INTO #errors VALUES( 'Verifica upb non presente sulle righe di versamento per RITENUTE, controllare la configurazione della scheda  del contratto o tipo contratto', 19)
--end

 --20) Elenco contributi con importo negativo
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idfin_cost is  not   null or  idexp_cost is not null) and isnull(importo,0) <0)
begin
	INSERT INTO #errors VALUES( 'Contributi con importo negativo (non è un errore)', 20,'N')
end

 --21) Righe Versamenti Associate a Config. Contributi e non a Incassi
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contractkinddata is  not   null or  idcsa_contracttax is not null) and idcsa_incomesetup is null)
begin
	INSERT INTO #errors VALUES( 'Righe Versamenti Associate a Config. Contributi e non a Configurazione della Voce CSA', 21,'N')
end
    

 --22) Righe Versamenti non configurate correttamente nè come Contributi, nè come Ritenute, nè Recuperi
 if exists (  SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND idcsa_contractkinddata is   null and  idcsa_contracttax is null  and idfin_income is   null 
  and idfin_expense is  null)
begin
	INSERT INTO #errors VALUES( ' Righe Versamenti non configurate correttamente nè come Contributi, nè come Ritenute, nè come Recuperi', 22,'S')
end
         
--23) Recuperi negativi su partita di giro e diretti: idfin_cost per movimento di spesa  di costo
-- if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import 
-- AND ISNULL(flagclawback,'N') = 'S'  AND
-- (idfin_cost IS NULL)  and (importo < 0)
--) 
--begin
--	INSERT INTO #errors VALUES('Recuperi: assente il capitolo di costo per movimento di spesa in caso di righe negative' , 23,'S')
--end   
 
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
exec exp_csa_expense_available @ayear, @idcsa_import --,@kind

IF ((SELECT COUNT(*) FROM #output) > 0) 
--25) Movimenti padre con disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Movimenti padre con disponibile insufficiente' , 25,'N')
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



--27) Bilancio e movimento finanziario non determinati in righe riepiloghi 
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  and idcsa_contractkind is not null and idfin is null and idexp is null
    AND NOT EXISTS(SELECT * FROM csa_contractexpense C where C.ayear=csa_importriep.ayear 
                                 and C.idcsa_contract = csa_importriep.idcsa_contract)
	AND NOT EXISTS(SELECT * FROM csa_contract_partition CP where CP.ayear=csa_importriep.ayear 
                                 and CP.idcsa_contract = csa_importriep.idcsa_contract)
) 
begin
	INSERT INTO #errors VALUES('Voce di Bilancio e Movimento finanziario non determinati in righe riepiloghi', 27,'S')
end

--27) Ente CSA associato ad anagrafiche non attive in righe versamenti 
 if exists (
 SELECT * FROM csa_importver 
	join csa_agency on csa_importver.idcsa_agency = csa_agency.idcsa_agency
	join registry on registry.idreg = csa_agency.idreg 
 WHERE idcsa_import = @idcsa_import AND ISNULL(registry.active,'S') = 'N'
) 
begin
	INSERT INTO #errors VALUES('Ente CSA associato ad anagrafiche non attive in righe versamenti', 28,'S')
end



--28)  Ripartizione dei contratti in presenza di un movimento di spesa principale
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.idexp_main as '#idexp_main'  
                     from csa_contract C 
                       where C.ayear = @ayear  and C.active = 'S' and C.idexp_main IS NOT NULL
						and exists (select * from csa_contractexpense CE where 
							 C.idcsa_contract=CE.idcsa_contract and  
							 C.ayear = CE.ayear)
						and not exists (select * from csa_contract_partition CP where 
							 C.idcsa_contract=CP.idcsa_contract and  
							 C.ayear = CP.ayear)
) 
begin
	INSERT INTO #errors VALUES( 'Ripartizione costo lordo regole specifiche CSA in presenza di un movimento di spesa principale' , 29,'S')
end

--29)   Ripartizione dei contributi in presenza di un movimento di spesa 
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, 
			  C.description as 'Descrizione' , CT.vocecsa
                from csa_contracttax CT
				join csa_contract C on C.idcsa_contract=CT.idcsa_contract and CT.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S'  AND CT.idexp is not null
					 and exists (select * from csa_contracttaxexpense CTE where 
					 CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear)
					 and not exists (select * from csa_contracttax_partition CTP where 
					 CTP.idcsa_contract=CT.idcsa_contract and  
					 CTP.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTP.ayear = CT.ayear)
					 
					 )
                   
begin
INSERT INTO #errors VALUES('Ripartizione del costo contributi in presenza anche di un movimento di spesa ', 30,'S')
end

--30)  Righe di riepilogo con ripartizione del costo del lordo  in presenza di un movimento di spesa principale 
 if exists (    SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
				and idcsa_contract is not null and idexp is not null
				AND EXISTS(SELECT * FROM csa_importriep_expense C where
                                 C.idcsa_import = csa_importriep.idcsa_import
								 and C.idriep = csa_importriep.idriep
								 ) 

			    AND NOT EXISTS(SELECT * FROM csa_contract_partition C where C.ayear=csa_importriep.ayear 
                                 and C.idcsa_contract = csa_importriep.idcsa_contract) 
) 
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale ' , 31,'S')
end

--31)  Righe di versamento Contributi con ripartizione del costo dei contributi   in presenza anche di un movimento di spesa 
 if exists ( SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			 AND ISNULL(flagclawback,'N') = 'N'  and -- no recupero
				 (idcsa_contracttax is not null) and -- contributo
			     (idexp_cost is not null)  
			 AND EXISTS(select * from csa_importver_expense CE where  
                              CE.idcsa_import = csa_importver.idcsa_import
								 and CE.idver = csa_importver.idver
                       )    
			 AND NOT EXISTS(select * from csa_contracttax_partition CE where  
                            CE.idcsa_contract = csa_importver.idcsa_contract and
                                    CE.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CE.ayear = csa_importver.ayear
                       )    
)
                   
begin
INSERT INTO #errors VALUES('Righe di versamento Contributi con ripartizione del costo, in presenza anche di un movimento di spesa', 32,'S')
end

--32)  Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget
 if exists (    SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
				and idcsa_contract is not null and idepexp is not null
				AND EXISTS(SELECT * FROM csa_importriep_epexp C where C.idcsa_import=csa_importriep.idcsa_import 
                                 and C.idriep = csa_importriep.idriep) 
				AND NOT EXISTS(SELECT * FROM csa_contract_partition C where C.ayear=csa_importriep.ayear 
                                 and C.idcsa_contract = csa_importriep.idcsa_contract) 

	)
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con ripartizione tra impegni di budget nella configurazione della regola specifica CSA in presenza di un impegno di budget ' , 33,'S')
end

--33)  Righe di versamento Contributi con ripartizione tra impegni di budget nella configurazione dei contributi in presenza anche di un impegno di budget principale
 if exists ( SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			 AND ISNULL(flagclawback,'N') = 'N'  and -- no recupero
				 (idcsa_contracttax is not null) and -- contributo
			     (idepexp is not null)  
			 AND EXISTS(select * from csa_importver_epexp CE where  
                            CE.idcsa_import = csa_importver.idcsa_import and
                                    CE.idver = csa_importver.idver
                       )    
			 AND NOT EXISTS(select * from csa_contracttax_partition CE where  
                            CE.idcsa_contract = csa_importver.idcsa_contract and
                                    CE.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CE.ayear = @ayear
                       )    
)
                   
begin
INSERT INTO #errors VALUES('Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale', 34,'S')
end


--34)  Ripartizione dei contratti in impegni di budget  in presenza di un impegno di budget nella scheda principale
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.idepexp_main as '#idepexp_main'  
                     from csa_contract C 
                       where C.ayear = @ayear  and C.active = 'S' and C.idepexp_main IS NOT NULL
						and exists (select * from csa_contractepexp CE where 
							 C.idcsa_contract=CE.idcsa_contract and  
							 C.ayear = CE.ayear)
						and not exists (select * from csa_contract_partition CE where 
							 C.idcsa_contract=CE.idcsa_contract and  
							 C.ayear = CE.ayear)
 
 
) 
begin
	INSERT INTO #errors VALUES( 'Ripartizione costo lordo regole specifiche CSA in impegni di budget  in presenza di un impegno di budget' , 35,'S')
end

--36)   Nella configurazione del contratto, ripartizione dei contributi in impegni di budget in presenza di un impegno di budget
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Contratto', C.ncontract as Numero, 
			  C.description as 'Descrizione' , CT.vocecsa
                from csa_contracttax CT
				join csa_contract C on C.idcsa_contract=CT.idcsa_contract and CT.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S'  AND CT.idepexp is not null
					 and exists (select * from csa_contracttaxepexp CTE where 
					 CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear)
					 and exists (select * from csa_contracttax_partition CTE where 
					 CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear)
					 )
                   
begin
INSERT INTO #errors VALUES('Nella configurazione della regola specifica CSA, ripartizione del costo contributi in impegni di budget  in presenza anche di un impegno di budget principale', 36,'S')
end


--37) Contributi su partita di giro senza Capitolo di Costo o Movimento di Spesa configurato,  si tratta di errore bloccante
 if exists (SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
 AND ISNULL(flagclawback,'N') = 'N' and
       (((idcsa_contractkinddata is not null) or (idcsa_contracttax is not null)) and
        (idfin_cost is null) and (idexp_cost is null) and (idfin_income is not null) and (idfin_expense is not null))
         AND NOT EXISTS(select * from csa_contracttaxexpense CE where  
                            CE.idcsa_contract = csa_importver.idcsa_contract and
                                    CE.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CE.ayear = @ayear
                        )     
		  AND NOT EXISTS(select * from csa_contracttax_partition CE where  
                            CE.idcsa_contract = csa_importver.idcsa_contract and
                                    CE.idcsa_contracttax = csa_importver.idcsa_contracttax  and
                                    CE.ayear = @ayear
                        )                           
) 
begin
	INSERT INTO #errors VALUES('Contributi su partita di giro senza Capitolo di Costo o Movimento di Spesa configurato' , 37,'S' )
end




--38)    Importo mal ripartito nelle righe di riepilogo (ripartizione finanziaria)
 if exists (   SELECT  C.idriep as 'N.riepilogo', C.importo,
						(select sum(CE.amount)  from  csa_importriep_expense CE  
								where C.idcsa_import=CE.idcsa_import and C.idriep=CE.idriep) as somma
                     from CSA_importriep C 
						where  C.idcsa_import = @idcsa_import
							and exists(select * from  csa_importriep_expense CE  where C.idcsa_import=CE.idcsa_import and C.idriep=CE.idriep)	
							and not exists(select * from  csa_importriep_partition CP  where C.idcsa_import=CP.idcsa_import and C.idriep=CP.idriep)							
							and (select sum(CE.amount)  from  csa_importriep_expense CE  
								where C.idcsa_import=CE.idcsa_import and C.idriep=CE.idriep)<> C.importo

) 
begin
	INSERT INTO #errors VALUES( 'Verifica ripartizione finanziaria delle regole specifiche CSA (righe di riepilogo)' , 38,'S')
end




--39)   Verifica ripartizione dei contributi (versamenti)
 if exists (   SELECT  C.idver as 'N.versamento', C.importo,
						(select sum(CE.amount)  from  csa_importver_expense CE  
								where C.idcsa_import=CE.idcsa_import and C.idver=CE.idver) as somma
                     from CSA_importver C 
						where  C.idcsa_import = @idcsa_import
							and exists(select * from  csa_importver_expense CE  where C.idcsa_import=CE.idcsa_import and C.idver=CE.idver)		
							and not exists(select * from  csa_importver_partition CP  where C.idcsa_import=CP.idcsa_import and C.idver=CP.idver)					
							and (select sum(CE.amount)  from  csa_importver_expense CE  
								where C.idcsa_import=CE.idcsa_import and C.idver=CE.idver)<> C.importo

) 
begin
	INSERT INTO #errors VALUES( 'Verifica ripartizione finanziaria dei contributi(righe di versamento)' , 39,'S')
end


--40)   Verifica quote ripartizione EP del lordo (riepiloghi)
 if exists (  select CE.idriep as 'N.riepilogo' , sum(CE.quota) as Quota  
                from csa_importriep_epexp CE  
                where  CE.idcsa_import = @idcsa_import
				and not exists (select * from csa_importriep_partition CP where  CP.idcsa_import = @idcsa_import)
                     group by CE.idriep
                     having abs(sum(quota)-1) > 0.000001  
) 
begin
INSERT INTO #errors VALUES('Verifica quote ripartizione EP del lordo (righe di riepilogo)', 40,'S')
end


--41)   Verifica quote ripartizione EP dei contributi (versamenti)
 if exists (  select CE.idver as 'N.versamento' ,   sum(CE.quota) as Quota  
                from csa_importver_epexp CE  
                where  CE.idcsa_import = @idcsa_import
					and not exists (select * from csa_importver_partition CP where  CP.idcsa_import = @idcsa_import)
                     group by CE.idver
                     having abs(sum(CE.quota)-1) > 0.000001  
) 
begin
INSERT INTO #errors VALUES('Verifica ripartizione EP dei contributi(righe di versamento)', 41,'S')
end



--42)  Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale 
 if exists (    SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
				and idcsa_contract is not null and idexp is not null
				AND EXISTS(SELECT * FROM csa_importriep_expense C where C.idriep=csa_importriep.idriep
                                 and C.idcsa_import = csa_importriep.idcsa_import) 
				AND NOT EXISTS(SELECT * FROM csa_importriep_partition C where C.idriep=csa_importriep.idriep
                                 and C.idcsa_import = csa_importriep.idcsa_import) 
) 
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale ' , 42,'S')
end

--43)  Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa 
 if exists ( SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			 AND ISNULL(flagclawback,'N') = 'N'  and -- no recupero
				 (idcsa_contracttax is not null) and -- contributo
			     (idexp_cost is not null)  
			 AND EXISTS(select * from csa_importver_expense CE where  
                            CE.idcsa_import = csa_importver.idcsa_import and
                                    CE.idver = csa_importver.idver 
                       )    
			 AND NOT EXISTS(select * from csa_importver_partition CE where  
                            CE.idcsa_import = csa_importver.idcsa_import and
                                    CE.idver = csa_importver.idver 
                       ) 
)
                   
begin
INSERT INTO #errors VALUES('Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa principale', 43,'S')
end

--44)  Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget
 if exists (    SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
				and idcsa_contract is not null and idepexp is not null
				AND EXISTS(SELECT * FROM csa_importriep_epexp C where C.idriep=csa_importriep.idriep 
                                 and C.idcsa_import = csa_importriep.idcsa_import) 
				AND NOT EXISTS(SELECT * FROM csa_importriep_partition C where C.idriep=csa_importriep.idriep 
                                 and C.idcsa_import = csa_importriep.idcsa_import) 
	)
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget principale' , 44,'S')
end

--45)  Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
 if exists ( SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import  
			 AND ISNULL(flagclawback,'N') = 'N'  and -- no recupero
				 (idcsa_contracttax is not null) and -- contributo
			     (idepexp is not null)  
			 AND EXISTS(select * from csa_importver_epexp CE where  
                            CE.idcsa_import = csa_importver.idcsa_import and
                                    CE.idver = csa_importver.idver  
                       )  
			 AND NOT EXISTS(select * from csa_importver_partition CE where  
                            CE.idcsa_import = csa_importver.idcsa_import and
                                    CE.idver = csa_importver.idver  
                       )   
)
                   
begin
INSERT INTO #errors VALUES('Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale', 45,'S')
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

IF (@flagepexp = 'S')
BEGIN
	 -- 47) Ripartizione in impegni di budget  (csa_contractepexp )senza una corrispondente ripartizione  nel finanziario  (csa_contractexpense) 
	 if exists (
	select  ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
	from  csa_contractepexpview RipEP 
	where  ayear = @ayear  and not exists ( 
	select * from  csa_contractexpenseview RipFin 
		where RipEP.idcsa_contract = Ripfin.idcsa_contract 
		and  RipEP.ndetail = Ripfin.ndetail
		and  RipEP.ayear = Ripfin.ayear
		and  RipEP.idupb = Ripfin.idupb
		and  RipEP.quota = Ripfin.quota
	)

	 and not exists ( 
	select * from  csa_contract_partitionview Rip 
		where RipEP.idcsa_contract = Rip.idcsa_contract 
		and  RipEP.ayear = Rip.ayear
	)


	  ) 
	begin
		INSERT INTO #errors VALUES('Ripartizione in impegni di budget dei contratti (csa_contractexpense)  ' +
		' senza una corrispondente ripartizione finanziaria (csa_contractepexp) con stesso upb e quota ', 47,'N')
	end

	 -- 48) Ripartizione in impegni di budget   dei contributi (csa_contracttaxtepexp) senza una corrispondente  ripartizione finanziaria (csa_contracttaxexpense) 
	 if exists (
	select  ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
	from csa_contracttaxepexpview RipTaxEP
	where ayear = @ayear and  not exists ( 
	select * from csa_contracttaxexpenseview RipTaxfin 
		where RipTaxEP.idcsa_contract = RipTaxfin.idcsa_contract 
		and   RipTaxEP.idcsa_contracttax = RipTaxfin.idcsa_contracttax 
		and   RipTaxEP.ndetail = RipTaxfin.ndetail
		and   RipTaxEP.ayear = RipTaxfin.ayear
		and   RipTaxEP.idupb = RipTaxfin.idupb
		and   RipTaxEP.quota = RipTaxfin.quota
	)
	 and  not exists ( 
	select * from csa_contracttax_partitionview RipTax 
		where RipTaxEP.idcsa_contract = RipTax.idcsa_contract 
		and   RipTaxEP.idcsa_contracttax = RipTax.idcsa_contracttax 
		and   RipTaxEP.ayear = RipTax.ayear
	)

	  ) 
	begin
		INSERT INTO #errors VALUES('Ripartizione  in impegni di budget   dei contributi (csa_contracttaxtepexp)  senza una corrispondente ' +
								   'ripartizione finanziaria (csa_contracttaxexpense) con stesso upb e quota ', 48,'N')
	end


 	-- 58) Ripartizione finanziaria dei contratti  (csa_contractexpense )senza una corrispondente ripartizione  nel finanziario  (csa_contractepexp) 
	 if exists (
	select  ayear, contractkindcode, contractkind, ycontract,ncontract, phase, ymov, nmov, quota, codeupb,upb
	from  csa_contractexpenseview   Ripfin
	where  ayear = @ayear  and not exists ( 
	select * from  csa_contractepexpview RipEP 
		where RipEP.idcsa_contract = Ripfin.idcsa_contract 
		and  RipEP.ndetail = Ripfin.ndetail
		and  RipEP.ayear = Ripfin.ayear
		and  RipEP.idupb = Ripfin.idupb
		and  RipEP.quota = Ripfin.quota
	)

	and not exists ( 
	select * from  csa_contract_partitionview Rip  
		where Ripfin.idcsa_contract = Rip.idcsa_contract 
		and  Ripfin.ayear = Rip.ayear
	)

	  ) 
	begin
		INSERT INTO #errors VALUES('Ripartizione finanziaria delle regole specifiche CSA (csa_contractexpense)  ' +
		' senza una corrispondente ripartizione in impegni di budget  (csa_contractepexp) con stesso upb e quota ', 58,'N')
	end

	-- 59) Ripartizione finanziaria  dei contributi (csa_contracttaxtexpense) senza una corrispondente  ripartizione finanziaria (csa_contracttaxepexp) 
	 if exists (
	select  ayear, contractkindcode, contractkind, ycontract,ncontract, phase, ymov, nmov, quota, codeupb,upb
	from csa_contracttaxexpenseview RipTaxfin  
	where ayear = @ayear and  not exists ( 
	select * from csa_contracttaxepexpview RipTaxEP
		where RipTaxEP.idcsa_contract = RipTaxfin.idcsa_contract 
		and   RipTaxEP.idcsa_contracttax = RipTaxfin.idcsa_contracttax 
		and   RipTaxEP.ndetail = RipTaxfin.ndetail
		and   RipTaxEP.ayear = RipTaxfin.ayear
		and   RipTaxEP.idupb = RipTaxfin.idupb
		and   RipTaxEP.quota = RipTaxfin.quota
	)
	and  not exists ( 
	select * from csa_contracttax_partitionview RipTax 
		where RipTaxfin.idcsa_contract = RipTax.idcsa_contract 
		and   RipTaxfin.idcsa_contracttax = RipTax.idcsa_contracttax 
		and   RipTaxfin.ayear = RipTax.ayear
	)

	  ) 
	begin
		INSERT INTO #errors VALUES('Ripartizione  finanziaria   dei contributi (csa_contracttaxtepexp)  senza una corrispondente ' +
								   'ripartizione in impegni di budget (csa_contracttaxexpense) con stesso upb e quota ', 59,'N')
	end
END

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

-- 50) Righe di riepilogo con movimento di spesa senza imputazione nell''esercizio corrente
 if exists (
  SELECT * FROM csa_importriep R WHERE idcsa_import = @idcsa_import and idexp is not null
  and not exists (select * from expenseyear EY where 
										EY.idexp = R.idexp AND
							            R.ayear = EY.ayear)
) 
begin
	INSERT INTO #errors VALUES('Righe di riepilogo con movimento di spesa senza imputazione nell''esercizio corrente', 50,'S')
end
 
 
-- 51) Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente
 if exists (
  SELECT * FROM csa_importver R WHERE idcsa_import = @idcsa_import and idexp_cost  is not null
  and not exists (select * from expenseyear EY where 
										EY.idexp = R.idexp_cost AND
							            R.ayear = EY.ayear)
) 
begin
	INSERT INTO #errors VALUES('Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente', 51,'S')
end

--52)   Movimento di spesa principale impostato nei contratti senza imputazione nell'esercizio corrente
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.idexp_main as '#idexp_main'  
                     from csa_contract C 
                       where C.ayear = @ayear  and C.active = 'S' and C.idexp_main IS NOT NULL
						and not exists (select * from expenseyear EY where 
										EY.idexp = C.idexp_main AND
							            C.ayear = EY.ayear)
						and exists (select * from csa_importriep R where idcsa_import = @idcsa_import and idcsa_contract=C.idcsa_contract )				

) 
begin
	INSERT INTO #errors VALUES( 'Regole specifiche CSA con movimento di spesa principale senza imputazione nell''esercizio corrente' , 52,'S')
end


--53)    Movimento di spesa principale impostato nei contributi contratti senza imputazione nell'esercizio corrente
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, 
			  C.description as 'Descrizione' , CT.vocecsa
                from csa_contracttax CT
				join csa_contract C on C.idcsa_contract=CT.idcsa_contract and CT.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S'  AND CT.idexp is not null
					and not exists (select * from expenseyear EY where 
										EY.idexp = CT.idexp AND
							            C.ayear = EY.ayear)
					and exists (select * from csa_importriep R where idcsa_import = @idcsa_import and idcsa_contract=C.idcsa_contract )				
)
                   
begin
	INSERT INTO #errors VALUES('Movimento di spesa principale impostato nei contributi CSA - Regole specifiche, senza imputazione nell''esercizio corrente ', 53,'S')
end



--54)    Movimento di spesa principale impostato nella ripartizione dei contributi senza imputazione nell'esercizio corrente
 if exists (  select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, C.description as 'Descrizione', CT.vocecsa,
				CTE.idcsa_contracttax as '#idcsa_contracttax'
                from csa_contracttaxexpense CTE  
                join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and  
					 CTE.idcsa_contracttax = CT.idcsa_contracttax and  
                     CTE.ayear = CT.ayear 
                     join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear 
                     where  C.ayear = @ayear  and C.active = 'S' 
					 and not exists (select * from expenseyear EY where 
										EY.idexp = CTE.idexp AND
							            C.ayear = EY.ayear)
					 and not exists (select * from csa_contracttax_partition CTP where 
										CTP.idcsa_contract=CT.idcsa_contract and  
										CTP.idcsa_contracttax = CT.idcsa_contracttax and  
										CTP.ayear = CT.ayear 
										)
)
  
begin
	INSERT INTO #errors VALUES('Movimento di spesa principale impostato nella ripartizione dei contributi senza imputazione nell''esercizio corrente', 54,'S')
end



--55)   Movimento di spesa principale impostato nella ripartizione dei contratti senza imputazione nell'esercizio corrente
 if exists (   SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, 	CE.idcsa_contract as '#idcsa_contract'
                     from csa_contractexpense CE  
                       join csa_contract C on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear 
                       where C.ayear = @ayear  and C.active = 'S' 
					   and not exists (select * from expenseyear EY where 
										EY.idexp = CE.idexp AND
							            C.ayear = EY.ayear)
					   and not exists (select * from csa_contract_partition CP where 
										C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear 
										)
                
                
) 
begin
	INSERT INTO #errors VALUES( 'Movimento di spesa principale impostato nella ripartizione delle Regole Specifiche senza imputazione nell''esercizio corrente' , 55,'S')
end


-- 56) Righe di riepilogo con UPB incoerente tra movimento di spesa singolo ed impegno di budget singolo collegato
 if exists (
  SELECT * FROM csa_importriep R 
  	left outer join expenseyear EY  ON EY.idexp = R.idexp  AND R.ayear = EY.ayear
	left outer join epexpyear   EPY  ON EPY.idepexp = R.idepexp  AND R.ayear = EPY.ayear
  WHERE R.idcsa_import = @idcsa_import and (R.idexp is not null AND R.idepexp is not null) AND isnull(EY.idupb, '0001') <> isnull(EPY.idupb, '0001')
) 
begin
	INSERT INTO #errors VALUES('Righe di riepilogo con UPB incoerente tra impegno finanziario e impegno di budget singolo', 56,'S')
end
 
 
-- 57) Righe di versamento con UPB incoerente tra movimento di spesa singolo ed impegno di budget singolo collegato
 if exists (
  SELECT * FROM csa_importver R 
		left outer join expenseyear EY  ON EY.idexp = R.idexp_cost AND R.ayear = EY.ayear
		left outer join epexpyear   EPY  ON EPY.idepexp = R.idepexp AND R.ayear = EPY.ayear
  WHERE R.idcsa_import = @idcsa_import and (R.idexp_cost  is not null AND R.idepexp IS NOT NULL)  AND isnull(EY.idupb, '0001') <> isnull(EPY.idupb, '0001')
) 
begin
	INSERT INTO #errors VALUES('Righe di versamento con UPB incoerente tra impegno finanziario e impegno di budget singolo ', 57,'S')
end

--65)Ripartizione EP incoerente con la ripartizione finanziaria
CREATE TABLE #output_3
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
            
insert into #output_3
exec check_csa_partition_inconsistent @ayear 

IF ((SELECT COUNT(*) FROM #output_3) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria nella configurazione', 65,'S')
END  

/*
--66)Ripartizione EP incoerente con la ripartizione finanziaria in righe di riepilogo
CREATE TABLE #output_riep
(
	descr_err  varchar(400),
	idcsa_import int,
	eserc_import int,
	numero_import int,
	regola_generale varchar(400),
	eserc int,
	numero int,
	idcsa_contract int,
	idcsa_contracttax int,
	riga int,
	quota_ripfin float,
	quota_ripep float
)
            
insert into #output_riep
exec check_csa_partition_inconsistent_riep @ayear  , @idcsa_import

IF ((SELECT COUNT(*) FROM #output_riep) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria in righe di riepilogo', 66,'S')
END  

--67)Ripartizione EP incoerente con la ripartizione finanziaria in righe di versamento
CREATE TABLE #output_ver
(
	descr_err  varchar(400),
	idcsa_import int,
	eserc_import int,
	numero_import int,
	regola_generale varchar(400),
	eserc int,
	numero int,
	idcsa_contract int,
	idver  int,
	vocecsa varchar(400),
	riga int,
	amount_ripfin decimal(19,2),
	amount_ripep decimal(19,2)
)
            
insert into #output_ver
exec check_csa_partition_inconsistent_ver @ayear , @idcsa_import

IF ((SELECT COUNT(*) FROM #output_ver) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione EP incoerente con la ripartizione finanziaria in righe di versamento', 67,'S')
END  
*/

DROP TABLE #output   
DROP TABLE #output_1       
DROP TABLE #output_3   
--DROP TABLE #output_ver
--DROP TABLE #output_riep
SELECT * FROM #errors

END

 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
