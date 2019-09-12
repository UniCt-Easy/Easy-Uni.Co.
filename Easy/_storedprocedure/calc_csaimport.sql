if exists (select * from dbo.sysobjects where id = object_id(N'[calc_csaimport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [calc_csaimport]
GO
 -- setuser'amministrazione'
 ---setuser'amm'
 --- calc_csaimport 29,2018
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE    PROCEDURE calc_csaimport
(
	@idcsa_import int,
	@ayear smallint
)
AS 
BEGIN

declare @nuovagestione char(1)
set @nuovagestione='N'
declare @mandatinominativi char(1)
set @mandatinominativi='S'

--di base se esistono nuove configurazioni le prossime importazioni sono nuovo tipo
if exists(select * from csa_contracttax_partition where ayear=@ayear) set @nuovagestione='S'
if exists(select * from csa_contract_partition where ayear=@ayear) set @nuovagestione='S'

if exists(select * from csa_importver where ayear=@ayear and idcsa_contractkind is not null and idcsa_import=@idcsa_import)
	or exists(select * from csa_importriep where ayear=@ayear and idcsa_contractkind is not null and idcsa_import=@idcsa_import)
	 begin
   --ci sono righe già elaborate, ossia siamo nel pregresso, allora ci accertiamo di non cambiare elaborazioni vecchie
   if not exists(select * from csa_importver_partition where idcsa_import=@idcsa_import) AND
		not exists(select * from csa_importriep_partition where idcsa_import=@idcsa_import) 
	SET @nuovagestione='N'	
end
 
if (@nuovagestione='S') begin
	--cancelliamo le nuove ripartizioni presenti nell'importazione
	delete from csa_importver_partition where  idcsa_import=@idcsa_import
	delete from csa_importriep_partition where idcsa_import=@idcsa_import
	select @mandatinominativi = isnull(csa_nominativo,'N') from config where ayear=@ayear

	update csa_importver set		idcsa_contract = null,idcsa_contractkind=null,
								idreg= null, idcsa_contractkinddata=null, idcsa_contracttax=null,  idcsa_incomesetup=null
			where idcsa_import=@idcsa_import

	update csa_importriep set		idcsa_contract = null,idcsa_contractkind=null,
								idreg= null
			where idcsa_import=@idcsa_import


end



if (@nuovagestione='N') begin
	--cancelliamo le vecchie ripartizioni presenti nell'importazione
	delete from csa_importriep_expense where  idcsa_import=@idcsa_import
	delete from csa_importriep_epexp where idcsa_import=@idcsa_import
	delete from csa_importver_expense where  idcsa_import=@idcsa_import
	delete from csa_importver_epexp where idcsa_import=@idcsa_import
end

 print @nuovagestione 
----------------------------------------------------------------
------- ELABORAZIONE VERSAMENTI,  TABELLA CSA_IMPORTVER --------
----------------------------------------------------------------

if (@nuovagestione='S') begin
	update  csa_importver set ayear= @ayear,  competency=  convert(int,competenza), 
				idcsa_contractkind=null,idcsa_contract=null, idreg=null,
					idcsa_agency=null,flagclawback=null, idreg_agency=null,
						idcsa_agencypaymethod=null,idunderwriting=null,
						idupb=null,flagdirectcsaclawback=null
	where idcsa_import=@idcsa_import
end

if (@nuovagestione='N') begin
	update  csa_importver set ayear= @ayear,  competency=  convert(int,competenza) 				
	where idcsa_import=@idcsa_import
end



update csa_importver set flagcr= 'C' where competency= @ayear  and idcsa_import=@idcsa_import	--and flagcr is null
update csa_importver set flagcr= 'R' where competency< @ayear and idcsa_import=@idcsa_import		--and flagcr is null 

begin --valorizza idcsa_contractkind 

--calcola idcsa_contractkind (caso tutti capitolocsa e  ruolocsa NOT NULL)
update csa_importver  set			idcsa_contractkind= csa_contractkind.idcsa_contractkind
	FROM csa_importver  
	JOIN csa_contractkindrules			ON  csa_importver.capitolocsa=  csa_contractkindrules.capitolocsa 
										AND csa_importver.ruolocsa=  csa_contractkindrules.ruolocsa
	JOIN csa_contractkind				ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
										AND csa_importver.flagcr = csa_contractkind.flagcr	 
	JOIN csa_contractkindyear			ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
	WHERE 	csa_importver.idcsa_contractkind is null
		AND csa_importver.idcsa_import = @idcsa_import
		AND csa_contractkindyear.ayear=@ayear
		AND csa_contractkindrules.ayear=@ayear
		AND isnull(csa_contractkind.active, 'N')='S'

--calcola idcsa_contractkind (caso capitolocsa null)
update csa_importver  set		 idcsa_contractkind= csa_contractkind.idcsa_contractkind
	FROM csa_importver  
	JOIN csa_contractkindrules			ON  csa_importver.ruolocsa=  csa_contractkindrules.ruolocsa
	JOIN csa_contractkind				ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
										AND csa_importver.flagcr = csa_contractkind.flagcr	
	JOIN csa_contractkindyear			ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
	WHERE   csa_importver.idcsa_contractkind is null
		AND csa_importver.idcsa_import = @idcsa_import
		AND csa_contractkindrules.capitolocsa is null
		AND csa_contractkindyear.ayear=@ayear
		AND csa_contractkindrules.ayear=@ayear
		AND isnull(csa_contractkind.active, 'N')='S'

--calcola idcsa_contractkind (caso ruolocsa null)
update csa_importver  set		idcsa_contractkind= csa_contractkind.idcsa_contractkind
	FROM csa_importver  
	JOIN csa_contractkindrules			ON  csa_importver.capitolocsa=  csa_contractkindrules.capitolocsa 
	JOIN csa_contractkind				ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
										AND csa_importver.flagcr = csa_contractkind.flagcr	
	JOIN csa_contractkindyear			ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
	WHERE 	csa_importver.idcsa_contractkind is null
		AND csa_importver.idcsa_import = @idcsa_import
		AND csa_contractkindrules.ruolocsa is null
		AND csa_contractkindyear.ayear=@ayear
		AND csa_contractkindrules.ayear=@ayear
		AND isnull(csa_contractkind.active, 'N')='S'

end		

begin --valorizza idcsa_contract

--calcola idcsa_contract ove trova un match con la matricola e tipo contratto e anno contratto->competenza
update csa_importver set		idcsa_contract = csa_contract.idcsa_contract,
								idreg= csa_contractregistry.idreg 
	FROM csa_importver
	JOIN csa_contract 
		ON   csa_contract.idcsa_contractkind = csa_importver.idcsa_contractkind		
					AND csa_contract.ycontract = csa_importver.competency
	JOIN csa_contractregistry			ON csa_contract.idcsa_contract= csa_contractregistry.idcsa_contract
										AND csa_contract.ayear= csa_contractregistry.ayear
	WHERE 	csa_importver.idcsa_contract is null
		AND csa_importver.idcsa_contractkind is not null
		AND csa_contract.ayear=@ayear
		AND csa_contractregistry.extmatricula=csa_importver.matricola		
		AND csa_importver.idcsa_import = @idcsa_import
		AND isnull(csa_contract.active, 'N')='S'

--calcola idcsa_contract ove trova un match con contratti senza matricole e tipo contratto e anno contratto->competenza
 update csa_importver set 		idcsa_contract = csa_contract.idcsa_contract
 FROM   csa_importver
 JOIN   csa_contract			ON   csa_contract.idcsa_contractkind = csa_importver.idcsa_contractkind		
 								AND csa_contract.ycontract = csa_importver.competency
   WHERE 	csa_importver.idcsa_contract is null
		AND csa_importver.idcsa_contractkind is not null
		AND csa_contract.ayear=@ayear
		AND csa_importver.idcsa_import = @idcsa_import
		AND (SELECT COUNT(*) from csa_contractregistry C where 
			 C.idcsa_contract=csa_contract.idcsa_contract)=0
		AND isnull(csa_contract.active, 'N')='S'


end


 --Calcolo enti (idcsa_agency)  in base a campo ENTE
 update csa_importver set	 idcsa_agency = csa_agency.idcsa_agency, 
							flagclawback=csa_agency.isinternal,
							idreg_agency= csa_agency.idreg
	FROM csa_importver 
	JOIN csa_agency 		ON csa_importver.ente= csa_agency.ente 
	WHERE csa_importver.idcsa_agency IS NULL
				AND csa_importver.idcsa_import = @idcsa_import


--Calcolo mod.pagamento (idcsa_agencymethod)  in base a campo ENTE e VOCE CSA
update csa_importver set		idcsa_agencypaymethod= csa_agencypaymethod.idcsa_agencypaymethod
	from csa_importver 
	JOIN csa_agencypaymethod 	ON csa_importver.idcsa_agency= csa_agencypaymethod.idcsa_agency
									AND csa_importver.vocecsa= csa_agencypaymethod.vocecsa
	WHERE csa_importver.idcsa_agency IS NOT NULL 
			AND  csa_importver.idcsa_agencypaymethod IS NULL
			AND csa_importver.idcsa_import = @idcsa_import


--ASSOCIA IL FINANZIAMENTO O DA CONTRATTO O DA TIPO CONTRATTO
update csa_importver set	idunderwriting = csa_contract.idunderwriting
from csa_importver 
JOIN csa_contract	  ON   csa_contract.idcsa_contractkind = csa_importver.idcsa_contractkind	
							AND  csa_contract.idcsa_contract  = csa_importver.idcsa_contract 	
							AND csa_contract.ycontract = csa_importver.competency
where  csa_importver.idunderwriting is null and csa_importver.idcsa_contract is not null
			AND csa_importver.idcsa_import = @idcsa_import

update csa_importver set	idunderwriting = csa_contractkind.idunderwriting
from csa_importver 
JOIN csa_contractkind	 ON   csa_contractkind.idcsa_contractkind = csa_importver.idcsa_contractkind	
	where  csa_importver.idunderwriting is null and csa_importver.idcsa_contractkind is not null
			AND csa_importver.idcsa_import = @idcsa_import


-- se non ha individuato l'ente assegno un default pari a N a flagclawback
UPDATE csa_importver SET flagclawback = 'N' where flagclawback is null 	AND idcsa_import = @idcsa_import


--NOTA: per i recuperi "DIRETTI" (ove manca cap. di spesa) questo passo potrebbe non trovare la modalità o trovarne una fittizia			  
if (@nuovagestione='N') begin
		--caso CONTRIBUTI/RECUPERI - A : valorizzo idfin_cost, idacc_cost, idexp_cost,idepexp da csa_contract se trovo corrispondenza con vocecsa e idcsa_contract e anno
		--vecchia gestione (da csa_contracttax)
		UPDATE csa_importver SET 
				idfin_cost = csa_contracttax.idfin ,
				idsor_siope_cost = csa_contracttax.idsor_siope,
				idacc_cost = csa_contracttax.idacc ,
				idexp_cost = csa_contracttax.idexp ,
				idupb      = csa_contracttax.idupb,
				idcsa_contracttax=csa_contracttax.idcsa_contracttax,
				idepexp=csa_contracttax.idepexp
			FROM csa_importver
			JOIN csa_contracttax 	ON csa_importver.idcsa_contract=csa_contracttax.idcsa_contract AND csa_importver.vocecsa= csa_contracttax.vocecsa
		WHERE  	csa_importver.idcsa_contracttax is null 
						AND	csa_contracttax.ayear =  @ayear
						AND csa_importver.idcsa_import = @idcsa_import
	

		--caso CONTRIBUTI/RECUPERI - B : valorizzo idfin_cost, idacc_cost  da csa_contractkind se trovo corrispondenza con vocecsa e idcsa_contractkind e anno
		--vecchia gestione (da csa_contractkinddata)
		UPDATE csa_importver SET 
				idfin_cost = csa_contractkinddata.idfin ,
				idsor_siope_cost = csa_contractkinddata.idsor_siope,
				idacc_cost = csa_contractkinddata.idacc, 
				idupb      = csa_contractkinddata.idupb,
				idcsa_contractkinddata=csa_contractkinddata.idcsa_contractkinddata
			FROM csa_importver
			JOIN csa_contractkinddata 
				ON csa_importver.idcsa_contractkind=csa_contractkinddata.idcsa_contractkind		
				AND csa_importver.vocecsa= csa_contractkinddata.vocecsa		
		WHERE  	
			idcsa_contracttax is null
			AND csa_contractkinddata.ayear = @ayear
			AND csa_importver.idcsa_import = @idcsa_import

END

if (@nuovagestione='S') begin
		insert into csa_importver_partition 
			(idcsa_import,idver,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idsor_siope,idepexp)
		select @idcsa_import,CV.idver, CTP.ndetail,T.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
						CTP.idexp,CTP.idupb,CTP.idacc,CTP.idfin,CTP.idsor_siope,CTP.idepexp
		from csa_importver CV
			JOIN csa_contracttax CT	ON CV.idcsa_contract=CT.idcsa_contract AND CV.vocecsa= CT.vocecsa
			JOIN csa_contracttax_partition CTP 	ON CTP.idcsa_contract=CT.idcsa_contract 
											and  CTP.idcsa_contracttax=CT.idcsa_contracttax 
											and  CTP.ayear=CT.ayear 
			CROSS APPLY f_calcola_quota_importverpartition(@idcsa_import,CTP.idcsa_contracttax,CV.idver,CTP.ndetail) as T
		WHERE  	CV.idcsa_contracttax is null 
						AND	CT.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
						AND  CV.flagclawback = 'N' 

		UPDATE csa_importver SET		--idsor_siope_cost = CT.idsor_siope,
										idcsa_contracttax=CT.idcsa_contracttax
			FROM csa_importver CV
			JOIN csa_contracttax CT	ON CV.idcsa_contract=CT.idcsa_contract AND CV.vocecsa= CT.vocecsa
			JOIN csa_contracttax_partition CTP 	ON CTP.idcsa_contract=CT.idcsa_contract 
											and  CTP.idcsa_contracttax=CT.idcsa_contracttax 
											and  CTP.ayear=CT.ayear 
			join csa_importver_partition IVP on IVP.idcsa_import=CV.idcsa_import 
											and IVP.idver = CV.idver
											and IVP.ndetail = CTP.ndetail
		WHERE  	CV.idcsa_contracttax is null 
						AND	CT.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
						AND  CV.flagclawback = 'N' 

		insert into csa_importver_partition 
			(idcsa_import,idver,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idsor_siope,idepexp)
		select @idcsa_import,CV.idver, 1,CV.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
						null,CKD.idupb,CKD.idacc,CKD.idfin,CKD.idsor_siope,null
		from csa_importver CV			
			JOIN csa_contractkinddata CKD 	
									ON CV.idcsa_contractkind=CKD.idcsa_contractkind		
									AND CV.vocecsa= CKD.vocecsa		
		WHERE  	CV.idcsa_contracttax is null 
						AND	CKD.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
						AND  CV.flagclawback = 'N' 

		UPDATE csa_importver SET 	--idsor_siope_cost = CKD.idsor_siope,
									idcsa_contractkinddata=CKD.idcsa_contractkinddata,
									idupb      = CKD.idupb				
			FROM csa_importver CV			
			JOIN csa_contractkinddata CKD
				ON CV.idcsa_contractkind=CKD.idcsa_contractkind		
				AND CV.vocecsa= CKD.vocecsa		
		WHERE  	
			CV.idcsa_contracttax is null
			AND CKD.ayear = @ayear
			AND CV.idcsa_import = @idcsa_import
				AND  CV.flagclawback = 'N' 

		
end


-- caso RITENUTE / CONTRIBUTI / RECUPERI
UPDATE csa_importver SET 		
	idfin_income  =  csa_incomesetup.idfin_income,
	idsor_siope_income  =  csa_incomesetup.idsor_siope_income,
	idacc_debit   =  csa_incomesetup.idacc_debit,	
	idfin_expense = csa_incomesetup.idfin_expense,
	idsor_siope_expense = csa_incomesetup.idsor_siope_expense,
	idacc_expense = csa_incomesetup.idacc_expense,
	idfin_incomeclawback = csa_incomesetup.idfin_incomeclawback,
	idsor_siope_incomeclawback = csa_incomesetup.idsor_siope_incomeclawback,
	idacc_internalcredit = csa_incomesetup.idacc_internalcredit,
	idacc_revenue =  csa_incomesetup.idacc_revenue,
	idacc_agency_credit = csa_incomesetup.idacc_agency_credit,
	idcsa_incomesetup = csa_incomesetup.idcsa_incomesetup,
	vocecsaunified = csa_incomesetup.vocecsaunified   -- Voce CSA per raggruppamento ai fini della Compensazione
	from csa_importver
	JOIN csa_incomesetup
		ON csa_importver.vocecsa=csa_incomesetup.vocecsa
		AND csa_importver.ayear=csa_incomesetup.ayear		
WHERE  	csa_importver.idcsa_incomesetup is null 
AND		csa_importver.idcsa_import = @idcsa_import

if (@nuovagestione='N') begin
		-- CASO RECUPERI VALORIZZO IL CAPITOLO DI COSTO
		UPDATE   csa_importver SET 	
			idfin_cost = csa_incomesetup.idfin_cost,
			idsor_siope_cost = csa_incomesetup.idsor_siope_cost,
			idacc_cost = csa_incomesetup.idacc_cost
			from csa_importver
			JOIN csa_incomesetup
				ON  csa_importver.idcsa_incomesetup  = csa_incomesetup.idcsa_incomesetup
				AND csa_importver.ayear=csa_incomesetup.ayear		
		WHERE  	csa_importver.flagclawback = 'S' 
				AND		csa_importver.idcsa_import = @idcsa_import
END

if (@nuovagestione='S') begin
		-- CASO RECUPERI VALORIZZO IL CAPITOLO DI COSTO
		
		insert into csa_importver_partition 
			(idcsa_import,idver,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idsor_siope,idepexp)
		select @idcsa_import,CV.idver, 1,CV.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
						null,csa_incomesetup.idupb,csa_incomesetup.idacc_cost,csa_incomesetup.idfin_cost,csa_incomesetup.idsor_siope_cost,null
		from csa_importver CV			
			JOIN csa_incomesetup
				ON  CV.idcsa_incomesetup  = csa_incomesetup.idcsa_incomesetup
				AND CV.ayear=csa_incomesetup.ayear		
		WHERE CV.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
						AND  CV.flagclawback = 'S' 		
		
END


 
-- RECUPERO, valorizzo il campo idupb, sulla base della scheda conf. incassi CSA individuata
-- Se si tratta di un recupero su partita di giro. L'upb sarà usato per il
-- movimento finanziario di entrata post-versamento
-- Se si tratta di un recupero diretto, allora sarà usato per l'incasso diretto (fase lordi)
DECLARE @flagdirectcsaclawback char(1)  -- configurazione gestione recupero CSA

-- IN PRIMA ISTANZA SI CONSIDERA IL FLAG SPECIFICO DI csa_incomesetup, SE NON è VALORIZZATO SI PRENDE
-- IL FLAG DI CONFIG, SE E' NULL SI CONSIDERA N
SELECT 
		@flagdirectcsaclawback = flagdirectcsaclawback
FROM config
WHERE ayear = @ayear

if (@nuovagestione='N') begin --se =S l'ha già fatto poco sopra
	UPDATE csa_importver SET 
		   idupb = csa_incomesetup.idupb
	FROM   csa_incomesetup
	WHERE  csa_importver.idcsa_incomesetup = csa_incomesetup.idcsa_incomesetup
	AND	   csa_importver.ayear = csa_incomesetup.ayear
	AND    csa_incomesetup.idupb IS NOT NULL 
	AND	   ISNULL(csa_importver.flagclawback,'N') = 'S'
	AND    csa_importver.idcsa_import = @idcsa_import
END

UPDATE csa_importver SET 
	   flagdirectcsaclawback = ISNULL(csa_incomesetup.flagdirectcsaclawback,ISNULL(@flagdirectcsaclawback,'N'))
FROM   csa_incomesetup
WHERE  csa_importver.idcsa_incomesetup = csa_incomesetup.idcsa_incomesetup
AND	   csa_importver.ayear = csa_incomesetup.ayear
AND	   ISNULL(csa_importver.flagclawback,'N') = 'S'
AND    csa_importver.idcsa_import = @idcsa_import

-- IN CASO DI CONTRIBUTI FIGURATIVI, EVENTUALMENTE ASSOCIATI A ENTE INTERNO  CONTROLLO idcsa_incomesetup, 
-- SE NON è VALORIZZATO LA RIGA NON DEVE ESSERE TRATTATA  COME RECUPERO IN QUANTO NON ESISTE 
-- LA RELATIVA SCHEDA CONFIGURAZIONE INCASSI
 
UPDATE csa_importver 
	SET csa_importver.flagclawback = 'N'
WHERE ISNULL(csa_importver.flagclawback,'N') = 'S'
AND idcsa_incomesetup IS NULL
	AND idcsa_import = @idcsa_import


-- caso CONTRIBUTI/RITENUTE  - C : valorizzo idupb  
-- da csa_contract (le voci principali del  contratto) , 
-- in mancanza dell'upb in una di scheda contributi più specifica 
if (@nuovagestione='N') begin 
		UPDATE csa_importver SET 
			idupb      = csa_contract.idupb
			FROM csa_importver
			JOIN csa_contract 		ON csa_importver.idcsa_contract=csa_contract.idcsa_contract	
		WHERE  	
			idcsa_contracttax IS NULL AND idcsa_contractkinddata IS NULL 
			AND	ISNULL(csa_importver.flagclawback,'N') = 'N'
			AND csa_importver.idupb IS NULL
			AND csa_importver.idcsa_import = @idcsa_import
			AND csa_contract.ayear=@ayear
END

 
 
if (@nuovagestione='N') begin 
	-- eredito la ripartizione finanziaria di riepiloghi e versamenti ed EP da regole specifiche e contributi 
	insert into csa_importver_expense 
			(idcsa_import,idver,ndetail,amount,ct,cu,lt,lu,idexp)
		select @idcsa_import,CV.idver, CTE.ndetail,T.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import', CTE.idexp
		from csa_importver CV	
		JOIN csa_contracttaxexpense  CTE 
			ON  CTE.idcsa_contract = CV.idcsa_contract 
			AND CTE.idcsa_contracttax= CV.idcsa_contracttax
			AND CTE.ayear= CV.ayear
		CROSS APPLY f_calcola_quota_importver_expense(@idcsa_import,CTE.idcsa_contracttax, CV.idver,CTE.ndetail) as T
		WHERE 		(CV.idcsa_contracttax IS NOT NULL)
			AND	ISNULL(CV.flagclawback,'N') = 'N'
		    AND CV.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
			AND CV.flagclawback = 'N' 

	insert into csa_importver_epexp
			(idcsa_import,idver,ndetail,quota,ct,cu,lt,lu,idepexp)
		select @idcsa_import,CV.idver, CTE.ndetail,CTE.quota, getdate(),'calc_csa_import',getdate(),'calc_csa_import', CTE.idepexp
		from csa_importver CV	
		JOIN csa_contracttaxepexp  CTE 
			ON  CTE.idcsa_contract = CV.idcsa_contract 
			AND CTE.idcsa_contracttax= CV.idcsa_contracttax
			AND CTE.ayear = CV.ayear	
		WHERE 		(CV.idcsa_contracttax IS NOT NULL)
			AND	ISNULL(CV.flagclawback,'N') = 'N'
		    AND CV.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
			AND CV.flagclawback = 'N' 
END



if (@nuovagestione='S') begin 
print  'ritenute'
-- per le ritenute l'UPB da movimentare è sempre quello di Ateneo
	insert into csa_importver_partition 
			(idcsa_import,idver,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idepexp)
		select @idcsa_import,CV.idver, 1,CV.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
						null,'0001',csa_incomesetup.idacc_cost,csa_incomesetup.idfin_cost,null
		from csa_importver CV	
			JOIN csa_incomesetup
				ON  CV.idcsa_incomesetup  = csa_incomesetup.idcsa_incomesetup
				AND CV.ayear=csa_incomesetup.ayear		
		WHERE 		CV.idcsa_contracttax IS NULL AND CV.idcsa_contractkinddata IS NULL 
			AND	ISNULL(CV.flagclawback,'N') = 'N'
		    AND CV.ayear =  @ayear	AND CV.idcsa_import = @idcsa_import
			AND CV.flagclawback = 'N' 
END


-- caso CONTRIBUTI/RITENUTE - D : valorizzo idupb  
-- da csa_contractkindyear (le voci principali del tipo contratto) , 
-- in mancanza dell'upb in una di scheda contributi più specifica 
if (@nuovagestione='N') begin 
		update csa_importver		SET 	idupb      = csa_contractkindyear.idupb
			from csa_importver
			JOIN csa_contractkindyear 
				ON csa_importver.idcsa_contractkind=csa_contractkindyear.idcsa_contractkind		
		WHERE  	
			idcsa_contracttax IS NULL  AND idcsa_contractkinddata IS NULL 
			AND csa_importver.idupb IS NULL 
			AND	ISNULL(csa_importver.flagclawback,'N') = 'N'
			AND csa_importver.idcsa_import = @idcsa_import
			AND csa_contractkindyear.ayear = @ayear
END 

if (@nuovagestione='S') begin 
		update csa_importver_partition SET 		idupb      = csa_contractkindyear.idupb
			from csa_importver_partition
			JOIN csa_importver		ON csa_importver_partition.idcsa_import=csa_importver.idcsa_import	
									AND  csa_importver_partition.idver=csa_importver.idver	
			JOIN csa_contractkindyear 
				ON csa_importver.idcsa_contractkind=csa_contractkindyear.idcsa_contractkind		
		WHERE  	
			csa_importver.idcsa_contracttax IS NULL  AND csa_importver.idcsa_contractkinddata IS NULL 
			AND csa_importver_partition.idupb IS NULL 
			AND	ISNULL(csa_importver.flagclawback,'N') = 'N'
			AND csa_importver.idcsa_import = @idcsa_import
			AND csa_contractkindyear.ayear = @ayear
END 


 --------------------------------------------------------
 ------- ELABORAZIONE LORDI , TABELLA CSA_IMPORTRIEP
 --------------------------------------------------------

 if (@nuovagestione='N') begin
		update csa_importriep set ayear=  @ayear,competency=  convert(int,competenza)
		where idcsa_import=@idcsa_import
end

if (@nuovagestione='S') begin
		update csa_importriep set ayear=  @ayear,competency=  convert(int,competenza),
								idcsa_contractkind=null,idcsa_contract=null,
								idunderwriting=null,idupb=null,idreg=null
		where idcsa_import=@idcsa_import
end


update csa_importriep set flagcr= 'C' where competency= @ayear  AND idcsa_import = @idcsa_import  --and flagcr is null
update csa_importriep set flagcr= 'R' where competency< @ayear  AND idcsa_import = @idcsa_import  --and flagcr is null

if (@nuovagestione='N') begin
		--calcola idcsa_contractkind (caso capitolocsa e ruolocsa not null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					idsor_siope = csa_contractkindyear.idsor_siope_main,
					idunderwriting = csa_contractkind.idunderwriting,
					idfin = csa_contractkindyear.idfin_main  ,
					idacc = csa_contractkindyear.idacc_main ,
					idupb = csa_contractkindyear.idupb 
			FROM csa_importriep  
			JOIN csa_contractkindrules		ON  csa_importriep.capitolocsa=  csa_contractkindrules.capitolocsa 
												AND csa_importriep.ruolocsa=  csa_contractkindrules.ruolocsa
			JOIN csa_contractkind			ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
												AND csa_importriep.flagcr = csa_contractkind.flagcr	 
			JOIN csa_contractkindyear		ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_contractkindrules.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contractkind (caso capitolocsa null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					idfin = csa_contractkindyear.idfin_main  ,
					idsor_siope = csa_contractkindyear.idsor_siope_main,
					idacc = csa_contractkindyear.idacc_main ,
					idupb = csa_contractkindyear.idupb ,
					idunderwriting = csa_contractkind.idunderwriting
			FROM csa_importriep  
			JOIN csa_contractkindrules	ON  csa_importriep.ruolocsa=  csa_contractkindrules.ruolocsa
			JOIN csa_contractkind		ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
											AND csa_importriep.flagcr = csa_contractkind.flagcr	
			JOIN csa_contractkindyear	ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractkindrules.capitolocsa is null
				AND csa_contractkindrules.ayear=@ayear
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contractkind (caso ruolocsa null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					idfin = csa_contractkindyear.idfin_main  ,
					idsor_siope = csa_contractkindyear.idsor_siope_main,
					idacc = csa_contractkindyear.idacc_main ,
					idupb = csa_contractkindyear.idupb ,
					idunderwriting = csa_contractkind.idunderwriting
			FROM csa_importriep  
			JOIN csa_contractkindrules		ON  csa_importriep.capitolocsa=  csa_contractkindrules.capitolocsa 
			JOIN csa_contractkind			ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
												AND csa_importriep.flagcr = csa_contractkind.flagcr	
			JOIN csa_contractkindyear		ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractkindrules.ruolocsa is null
				AND csa_contractkindrules.ayear=@ayear
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contract ove trova un match con la matricola
		update csa_importriep set idcsa_contract = csa_contract.idcsa_contract,
					idexp= csa_contract.idexp_main,
					idfin= csa_contract.idfin_main,
					idsor_siope = csa_contract.idsor_siope_main,
					idacc= csa_contract.idacc_main,
					idupb= csa_contract.idupb,
					idreg= csa_contractregistry.idreg,
					idunderwriting = csa_contract.idunderwriting,
					idepexp=csa_contract.idepexp_main
			FROM csa_importriep
			JOIN csa_contract				ON   csa_contract.idcsa_contractkind = csa_importriep.idcsa_contractkind		
												AND   csa_contract.ycontract = csa_importriep.competency	
			JOIN csa_contractregistry		ON csa_contract.idcsa_contract= csa_contractregistry.idcsa_contract
				AND csa_contract.ayear= csa_contractregistry.ayear
			WHERE 	csa_importriep.idcsa_contract is null
				AND csa_importriep.idcsa_contractkind is not null
				AND csa_contract.ayear=@ayear
				AND csa_contractregistry.extmatricula=csa_importriep.matricola		
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractregistry.ayear=@ayear
				AND isnull(csa_contract.active, 'N')='S'


		--calcola idcsa_contract ove trova un match con contratti senza matricole
		update csa_importriep set idcsa_contract = csa_contract.idcsa_contract,
					idexp= csa_contract.idexp_main,
					idfin= csa_contract.idfin_main,
					idsor_siope = csa_contract.idsor_siope_main,
					idacc= csa_contract.idacc_main,
					idupb= csa_contract.idupb ,
					idunderwriting = csa_contract.idunderwriting,
					idepexp=csa_contract.idepexp_main
					--,idreg= csa_contractregistry.idreg
			FROM csa_importriep
			JOIN csa_contract			ON   csa_contract.idcsa_contractkind = csa_importriep.idcsa_contractkind		
												AND   csa_contract.ycontract = csa_importriep.competency	
			WHERE 	csa_importriep.idcsa_contract is null
				AND csa_importriep.idcsa_contractkind is not null
				AND csa_contract.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND (SELECT COUNT(*) from csa_contractregistry C where C.idcsa_contract=csa_contract.idcsa_contract)=0
				AND isnull(csa_contract.active, 'N')='S'

END
 
 if (@nuovagestione='N') begin 
	-- eredito la ripartizione finanziaria di riepiloghi e versamenti ed EP da regole specifiche e contributi 
	insert into csa_importriep_expense 
			(idcsa_import,idriep,ndetail,amount,ct,cu,lt,lu,idexp)
		select @idcsa_import,CR.idriep, CTE.ndetail,T.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import', CTE.idexp
		from csa_importriep CR	
		JOIN csa_contractexpense  CTE 
			ON  CTE.idcsa_contract = CR.idcsa_contract 
			AND CTE.ayear= CR.ayear
		CROSS APPLY f_calcola_quota_importriep_expense(@idcsa_import,CR.idriep,CTE.ndetail) as T
		WHERE (CR.idcsa_contract IS NOT NULL)
		AND CR.ayear =  @ayear	AND CR.idcsa_import = @idcsa_import

	insert into csa_importriep_epexp
			(idcsa_import,idriep,ndetail,quota,ct,cu,lt,lu,idepexp)
		select @idcsa_import,CR.idriep, CTE.ndetail,CTE.quota, getdate(),'calc_csa_import',getdate(),'calc_csa_import',CTE.idepexp
		from csa_importriep CR
		JOIN csa_contractepexp  CTE 
			ON  CTE.idcsa_contract = CR.idcsa_contract 
			AND CTE.ayear = CR.ayear	
		WHERE (CR.idcsa_contract IS NOT NULL)
		    AND CR.ayear =  @ayear	AND CR.idcsa_import = @idcsa_import
END


if (@nuovagestione='S') begin
			
		--calcola idcsa_contractkind (caso capitolocsa e ruolocsa not null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					--idsor_siope = csa_contractkindyear.idsor_siope_main,
					idunderwriting = csa_contractkind.idunderwriting
					--idfin = csa_contractkindyear.idfin_main  ,
					--idacc = csa_contractkindyear.idacc_main ,
					--idupb = csa_contractkindyear.idupb ,
			FROM csa_importriep  
			JOIN csa_contractkindrules		ON  csa_importriep.capitolocsa=  csa_contractkindrules.capitolocsa 
												AND csa_importriep.ruolocsa=  csa_contractkindrules.ruolocsa
			JOIN csa_contractkind			ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
												AND csa_importriep.flagcr = csa_contractkind.flagcr	 
			JOIN csa_contractkindyear		ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_contractkindrules.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contractkind (caso capitolocsa null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					--idsor_siope = csa_contractkindyear.idsor_siope_main,
					idunderwriting = csa_contractkind.idunderwriting
					--idacc = csa_contractkindyear.idacc_main ,
					--idfin = csa_contractkindyear.idfin_main  ,
					--idupb = csa_contractkindyear.idupb ,
			FROM csa_importriep  
			JOIN csa_contractkindrules	ON  csa_importriep.ruolocsa=  csa_contractkindrules.ruolocsa
			JOIN csa_contractkind		ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
											AND csa_importriep.flagcr = csa_contractkind.flagcr	
			JOIN csa_contractkindyear	ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractkindrules.capitolocsa is null
				AND csa_contractkindrules.ayear=@ayear
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contractkind (caso ruolocsa null)
		update csa_importriep  set idcsa_contractkind= csa_contractkind.idcsa_contractkind,
					--idsor_siope = csa_contractkindyear.idsor_siope_main,
					idunderwriting = csa_contractkind.idunderwriting
					--idfin = csa_contractkindyear.idfin_main  ,
					--idacc = csa_contractkindyear.idacc_main ,
					--idupb = csa_contractkindyear.idupb ,
			FROM csa_importriep  
			JOIN csa_contractkindrules		ON  csa_importriep.capitolocsa=  csa_contractkindrules.capitolocsa 
			JOIN csa_contractkind			ON csa_contractkindrules.idcsa_contractkind=csa_contractkind.idcsa_contractkind
												AND csa_importriep.flagcr = csa_contractkind.flagcr	
			JOIN csa_contractkindyear		ON csa_contractkindyear.idcsa_contractkind=csa_contractkind.idcsa_contractkind
			WHERE csa_importriep.idcsa_contractkind is null
				AND csa_contractkindyear.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractkindrules.ruolocsa is null
				AND csa_contractkindrules.ayear=@ayear
				AND isnull(csa_contractkind.active, 'N')='S'

		--calcola idcsa_contract ove trova un match con la matricola
		update csa_importriep set idcsa_contract = csa_contract.idcsa_contract,
					--idsor_siope = csa_contract.idsor_siope_main,
					idunderwriting = csa_contract.idunderwriting,
					idreg= csa_contractregistry.idreg
					--idexp= csa_contract.idexp_main,
					--idfin= csa_contract.idfin_main,
					--idacc= csa_contract.idacc_main,
					--idupb= csa_contract.idupb,
					--idepexp=csa_contract.idepexp_main
			FROM csa_importriep
			JOIN csa_contract				ON   csa_contract.idcsa_contractkind = csa_importriep.idcsa_contractkind		
												AND   csa_contract.ycontract = csa_importriep.competency	
			JOIN csa_contractregistry		ON csa_contract.idcsa_contract= csa_contractregistry.idcsa_contract
												AND csa_contract.ayear= csa_contractregistry.ayear
			WHERE 	csa_importriep.idcsa_contract is null
				AND csa_importriep.idcsa_contractkind is not null
				AND csa_contract.ayear=@ayear
				AND csa_contractregistry.extmatricula=csa_importriep.matricola		
				AND csa_importriep.idcsa_import = @idcsa_import
				AND csa_contractregistry.ayear=@ayear
				AND isnull(csa_contract.active, 'N')='S'


		--calcola idcsa_contract ove trova un match con contratti senza matricole
		update csa_importriep set idcsa_contract = csa_contract.idcsa_contract,
					--idsor_siope = csa_contract.idsor_siope_main,
					idunderwriting = csa_contract.idunderwriting
					--idexp= csa_contract.idexp_main,
					--idfin= csa_contract.idfin_main,
					--idacc= csa_contract.idacc_main,
					--idupb= csa_contract.idupb ,
					--idepexp=csa_contract.idepexp_main
			FROM csa_importriep
			JOIN csa_contract			ON   csa_contract.idcsa_contractkind = csa_importriep.idcsa_contractkind		
												AND   csa_contract.ycontract = csa_importriep.competency	
			WHERE 	csa_importriep.idcsa_contract is null
				AND csa_importriep.idcsa_contractkind is not null
				AND csa_contract.ayear=@ayear
				AND csa_importriep.idcsa_import = @idcsa_import
				AND (SELECT COUNT(*) from csa_contractregistry C where C.idcsa_contract=csa_contract.idcsa_contract)=0
				AND isnull(csa_contract.active, 'N')='S'

		--- CREO LE PARTIZIONI A MENO CHE NON SIANO PRESENTI
	 
		--insert costi ove trova idcsa_contract
		insert into csa_importriep_partition 
					(idcsa_import,idriep,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idsor_siope,idepexp)
				select @idcsa_import,CV.idriep, CTP.ndetail,T.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
								CTP.idexp,CTP.idupb,CTP.idacc,CTP.idfin,CTP.idsor_siope,CTP.idepexp
				from csa_importriep CV
					JOIN csa_contract_partition CTP		ON CTP.idcsa_contract=CV.idcsa_contract and  CTP.ayear=CV.ayear 
					CROSS APPLY f_calcola_quota_importrieppartition(@idcsa_import,CV.idriep,CTP.ndetail) as T
				WHERE  	CV.idcsa_contract is NOT null 
								AND CV.idcsa_import = @idcsa_import  


				--insert costi ove NON trova idcsa_contract
			insert into csa_importriep_partition 
					(idcsa_import,idriep,ndetail,amount,ct,cu,lt,lu,idexp,idupb,idacc,idfin,idsor_siope,idepexp)
				select @idcsa_import,CV.idriep, 1,CV.importo, getdate(),'calc_csa_import',getdate(),'calc_csa_import',
								null,CY.idupb,CY.idacc_main,CY.idfin_main,CY.idsor_siope_main,null
				from csa_importriep CV
					JOIN csa_contractkindyear	CY	ON CY.idcsa_contractkind=CV.idcsa_contractkind
				WHERE  	CV.idcsa_contract is null 
								AND CV.idcsa_import = @idcsa_import AND CV.ayear=@ayear AND CY.ayear=@ayear 
		 
		

END

if (@mandatinominativi='S') begin
	update csa_importriep set	idreg = registry.idreg
	from csa_importriep
	join registry on SUBSTRING(registry.extmatricula, PATINDEX('%[^0]%', registry.extmatricula+'.'), 
											LEN(registry.extmatricula))= csa_importriep.matricola	
	where csa_importriep.idreg is null
			and csa_importriep.idcsa_import=@idcsa_import
	
	update csa_importver set	idreg = registry.idreg
	from csa_importver
	join registry on SUBSTRING(registry.extmatricula, PATINDEX('%[^0]%', registry.extmatricula+'.'), 
											LEN(registry.extmatricula))= csa_importver.matricola	
	where csa_importver.idreg is null
			and csa_importver.idcsa_import=@idcsa_import


end



END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 