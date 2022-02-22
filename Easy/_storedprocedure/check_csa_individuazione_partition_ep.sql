
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_individuazione_partition_ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_individuazione_partition_ep]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amm'
--setuser 'amministrazione'
--exec [check_csa_individuazione_partition_ep] 2,2018
CREATE  PROCEDURE [check_csa_individuazione_partition_ep]
(
	@idcsa_import int,
	@ayear		  int 
)
AS BEGIN
CREATE TABLE  #errors (errordescr varchar(400), errorcode int, blockingerror char(1))
--1) LORDI POSITIVI: Conto di costo (idacc_cost) non valorizzato riepiloghi positivi 
 if EXISTS (SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import   AND 
 importo > 0
			AND  
			(
				NOT EXISTS (SELECT * FROM csa_importriep_partition CP WHERE  
								CP.idcsa_import = csa_importriep.idcsa_import AND
								CP.idriep =  csa_importriep.idriep
							) 
				OR EXISTS (SELECT * FROM csa_importriep_partition CP where  
									CP.idcsa_import = csa_importriep.idcsa_import AND
									CP.idriep =  csa_importriep.idriep AND
									CP.idacc is null
							)        
			)                     
) 
begin
	INSERT INTO #errors VALUES('Righe positivo di riepilogo senza Conto EP nella ripartizione' ,1,'S' )
end

DECLARE @idacc_revenue_gross_csa   varchar(38)
SELECT  @idacc_revenue_gross_csa =  idacc_revenue_gross_csa from config where ayear = @ayear
--2) LORDI NEGATIVI: Conto di ricavo lordi (idacc_revenue_gross_csa) non valorizzato riepiloghi negativi (in config)
 if exists (
  SELECT * FROM csa_importriep WHERE idcsa_import = @idcsa_import 
  AND @idacc_revenue_gross_csa  is null and importo < 0
) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo lordi non valorizzato in presenza riepiloghi negativi. Verificare la configurazione annuale ', 2,'S')
end

--3)CONTRIBUTI con importo POSITIVO: Conto di costo non configurato per contributi positivi
-- Costo a debito con idacc_cost ove COSTO = idacc_cost DEBITO = ISNULL(_debit , _expense )
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  AND importo > 0 
  AND  
	(
		NOT EXISTS (SELECT * FROM csa_importver_partition CP WHERE  
						CP.idcsa_import = csa_importver.idcsa_import AND
						CP.idver =  csa_importver.idver 
					) 
		OR EXISTS (SELECT * FROM csa_importver_partition CP where  
							CP.idcsa_import = csa_importver.idcsa_import AND
							CP.idver =  csa_importver.idver AND
							CP.idacc is null 
					)        
	)    

  ) 
begin
	INSERT INTO #errors VALUES('Conto di costo non valorizzato nella ripartizione di righe versamento di contributi positivi', 3,'S')
end


--4) CONTRIBUTI CON IMPORTO POSITIVO: Conto di debito conto erario  e conto di debito verso erario entrambi non configurati per contributi positivi
-- _expense per i contributi a liquidazione diretta
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  --and idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_expense is null and importo>0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di debito verso erario ' +
								'non valorizzato in righe versamento di contributi positivi', 4,'S')
end

--5) VERSAMENTO RECUPERI: Viene generata una scrittura di COSTO   A  debito vs percipiente
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S'  
	 and importo<0
	 AND  
	(
		NOT EXISTS (SELECT * FROM csa_importver_partition CP WHERE  
						CP.idcsa_import = csa_importver.idcsa_import AND
						CP.idver =  csa_importver.idver 
					) 
		AND EXISTS (SELECT * FROM csa_importver_partition CP where  
							CP.idcsa_import = csa_importver.idcsa_import AND
							CP.idver =  csa_importver.idver AND
							CP.idacc is null 
					)        
	)  
) 
begin
	INSERT INTO #errors VALUES('Conto di costo non valorizzato nella ripartizione di righe versamento di recuperi negativi', 5,'S')
end

--6) CONTRIBUTI NEGATIVI: credito vs erario A  RICAVO 
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  --AND idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_revenue is null and importo<0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo non valorizzato in righe versamento di contributi negativi', 6,'S')
end



--7) RECUPERI POSITIVI: credito vs erario A  RICAVO 
--Versamento recuperi   credito vs percipiente A  RICAVO 
 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'S'  
  AND idacc_revenue is null and importo>0
) 
begin
	INSERT INTO #errors VALUES('Conto di ricavo non valorizzato in righe versamento di recuperi positivi', 7,'S')
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
	INSERT INTO #errors VALUES('Conto di debito verso erario  non valorizzato in righe versamento di ritenute positive ', 8,'S')
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
	INSERT INTO #errors VALUES('Conto di credito verso erario non valorizzato in righe versamento di ritenute negative', 9,'S')
end

 

--10)CONTRIBUTI NEGATIVI   credito vs erario A  RICAVO 

 if exists (
 SELECT * FROM csa_importver WHERE idcsa_import = @idcsa_import AND
  ISNULL(csa_importver.flagclawback,'N') = 'N' 
  AND (idcsa_contracttax is not  null or idcsa_contractkinddata is not null)
  --AND idcsa_incomesetup is not null --- non si tratta quindi di contributi figurativi
  AND idacc_agency_credit is null and importo<0
  ) 
begin
	INSERT INTO #errors VALUES('Conto di credito verso erario  non valorizzato in righe versamento di contributi negativi', 10,'S')
end

--------------------------------------------------------------------------------------------
------------------------- CONTROLLI RELATIVI ALLA CONFIGURAZIONE CSA -----------------------
--------------------------------------------------------------------------------------------

-- 11) Conto di costo per il lordo non valorizzato in ripartizione Contratti CSA
-- bloccante, obbligatorio per i riepiloghi
 if exists (
 SELECT * FROM csa_contract where ayear = @ayear AND isnull(csa_contract.active, 'N')='S'
 AND (NOT EXISTS (SELECT * FROM csa_contract_partition WHERE 
				  csa_contract.idcsa_contract = csa_contract_partition.idcsa_contract AND
				  csa_contract_partition.ayear = @ayear)

 OR EXISTS (SELECT * FROM csa_contract_partition WHERE 
													  csa_contract.idcsa_contract = csa_contract_partition.idcsa_contract AND
													  csa_contract_partition.ayear = @ayear and idacc IS NULL)
  )) 
begin
	INSERT INTO #errors VALUES('Conto di costo per il lordo  non valorizzato nella ripartizione delle Regole specifiche CSA', 11,'N')
end

-- 12) Conto di costo per contributi di contratto (idacc) non valorizzato in righe Contributi di Contratti CSA
-- non bloccante 
 if exists (
 SELECT * FROM csa_contracttax 
   JOIN csa_contract 
     ON csa_contracttax.idcsa_contract =  csa_contract.idcsa_contract
	 AND csa_contracttax.ayear =  csa_contract.ayear
    where csa_contracttax.ayear = @ayear AND isnull(csa_contract.active, 'N')='S'
	 AND (NOT EXISTS (SELECT * FROM csa_contracttax_partition WHERE 
				  csa_contracttax.idcsa_contract = csa_contracttax_partition.idcsa_contract AND
				  csa_contracttax.idcsa_contracttax = csa_contracttax_partition.idcsa_contracttax AND
				  csa_contracttax_partition.ayear = @ayear)
	 OR EXISTS (SELECT * FROM csa_contracttax_partition WHERE 
					 csa_contracttax.idcsa_contract = csa_contracttax_partition.idcsa_contract AND
					 csa_contracttax.idcsa_contracttax = csa_contracttax_partition.idcsa_contracttax AND
					 csa_contracttax_partition.ayear = @ayear and csa_contracttax_partition.idacc is null)
  ) )
begin
	INSERT INTO #errors VALUES('Conto di costo per  contributi  non valorizzato nella ripartizione dei Contributi - Regole specifiche CSA ', 12,'N')
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
	INSERT INTO #errors VALUES('Conto di costo per  lordo non valorizzato in Regole generali CSA', 13,'N')
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
	INSERT INTO #errors VALUES('Conto di costo per  contributi  non valorizzato nella ripartitione dei Contributi CSA - Regole generali', 14,'N')
end

--18) CONFIGURAZIONE CONTRIBUTI POSITIVI E NEGATIVI a liquidazione diretta: Conto di debito verso ente o Conto EP di Credito Verso Ente o Conto di Ricavo non configurati nella scheda Voce CSA
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
								' non configurati nella scheda Voce CSA del contributo', 18,'N')
end

--19) CONFIGURAZIONE REGOLE SPECIFICHE E CONTRIBUTI: PARTIZIONE UNICA NON CREATA PER INCOERENZA NELLE RIPARTIZIONI ORIGINALI
CREATE TABLE #output
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
            
insert into #output
exec check_csa_partition_not_created @ayear 

IF ((SELECT COUNT(*) FROM #output) > 0) 
BEGIN
	INSERT INTO #errors VALUES('Ripartizione unica non creata per ripartizioni di partenza errate', 19,'S')
END  

 

--22)  Righe di versamento con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importver V
					  JOIN csa_importver_partition VP  
						ON V.idcsa_import = VP.idcsa_import
						AND  V.idver = VP.idver
						AND  VP.idexp IS NOT NULL
                       WHERE V.ayear = @ayear   
					   AND V.idcsa_import = @idcsa_import  
					   AND EXISTS (SELECT * FROM  epexpyear EY WHERE 
										EY.idepexp = VP.idepexp AND
							            V.ayear = EY.ayear AND
										EY.idacc <> VP.idacc)                
) 
begin
	INSERT INTO #errors VALUES( 'Righe di versamento con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente' , 22,'S')
end

--23)  Righe di versamento con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importver V
					  JOIN csa_importver_partition VP  
						ON V.idcsa_import = VP.idcsa_import
						AND  V.idver = VP.idver
						AND  VP.idepexp IS NOT NULL
                       WHERE V.ayear = @ayear   
					   AND V.idcsa_import = @idcsa_import  
					   AND EXISTS (SELECT * FROM  epexpyear EY WHERE 
										EY.idepexp = VP.idepexp AND
							            V.ayear = EY.ayear AND
										EY.idupb <> VP.idupb)         
						
) 
begin
	INSERT INTO #errors VALUES( 'Righe di versamento con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente' , 23,'S')
end



--24)  Righe di riepilogo con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importriep R
					  JOIN csa_importriep_partition RP  
						ON R.idcsa_import = RP.idcsa_import
						AND  R.idriep = RP.idriep
						AND  RP.idepexp IS NOT NULL
                       WHERE R.ayear = @ayear   
					   AND R.idcsa_import = @idcsa_import  
					   AND EXISTS (SELECT * FROM  epexpyear EY WHERE 
										EY.idepexp = RP.idepexp AND
							            R.ayear = EY.ayear AND
										EY.idacc <> RP.idacc)                
) 
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente' , 24,'S')
end

--25)  Righe di riepilogo con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente
 if exists ( SELECT * FROM csa_importriep R
					  JOIN csa_importriep_partition RP  
						ON R.idcsa_import = RP.idcsa_import
						AND  R.idriep = RP.idriep AND  RP.idepexp IS NOT NULL
                       WHERE R.ayear = @ayear   
					   AND R.idcsa_import = @idcsa_import  
					   AND EXISTS (SELECT * FROM  epexpyear EY WHERE 
										EY.idepexp = RP.idepexp AND
							            R.ayear = EY.ayear AND
										EY.idupb <> RP.idupb)                
) 
begin
	INSERT INTO #errors VALUES( 'Righe di riepilogo con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente' , 25,'S')
end

--- controllo esistenza anagrafica se è configurata la generazione di movimenti finanziari nominativi
declare @mandatinominativi char(1)
set @mandatinominativi='S'
select @mandatinominativi = isnull(csa_nominativo,'N') from config where ayear=@ayear
if (@mandatinominativi='S') 
begin
--26) Riepiloghi con Anagrafica lavoratore non valorizzata
	 if exists (  SELECT * FROM csa_importriep 
					WHERE idcsa_import = @idcsa_import and ( idreg is null or idreg = 0)	) 
	begin
		INSERT INTO #errors VALUES('Riepiloghi con Anagrafica non valorizzata', 26,'S')
	end
--27) Riepiloghi con Anagrafica  valorizzata ma priva di causale  di debito o di credito
	 if exists (  SELECT * FROM csa_importriep 
					WHERE idcsa_import = @idcsa_import and  csa_importriep.idreg is not null 
					AND (
							 (SELECT COUNT(*) FROM registry WHERE registry.idreg = csa_importriep.idreg and registry.idaccmotivedebit is not null) = 0  OR
							 (SELECT COUNT(*) FROM registry WHERE registry.idreg = csa_importriep.idreg and registry.idaccmotivecredit is not null) = 0 	
						 ) 
				)
	begin
		INSERT INTO #errors VALUES('Riepiloghi con Anagrafica priva di causale di debito valorizzata nella scheda "Altri Dati"', 27,'N')
	end
end
 

SELECT * FROM #errors
END
 
 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

 --[check_csa_individuazione_ep] 41,2016
 
