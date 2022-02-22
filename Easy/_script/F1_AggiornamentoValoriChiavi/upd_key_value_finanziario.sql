
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


IF NOT EXISTS(SELECT * FROM clawback WHERE idclawback IN ('07_ITINE','07_PETTY','07_VARIE'))
BEGIN
	-- Parte 2. Tabelle CLAWBACK, ADMPAY_CLAWBACK, CLAWBACKSETUP, CLAWBACKSORTING, EXPENSE, EXPENSECLAWBACK, ITINERATIONSETUP,
	-- INCOME
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)
	
	INSERT INTO #temp VALUES('ANTIMISS', '07_ITINE')
	INSERT INTO #temp VALUES('ANTIPISPE', '07_PETTY')
	INSERT INTO #temp VALUES('ANTIVARI', '07_VARIE')
	
	UPDATE clawback
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE admpay_clawback
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE clawbacksetup
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE clawbacksorting
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE expense
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE expenseclawback
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE itinerationsetup
	SET idclawback = #temp.newvalue
	FROM #temp WHERE idclawback = #temp.oldvalue
	
	UPDATE income
	SET autocode = #temp.newvalue
	FROM #temp WHERE autocode = #temp.oldvalue
	AND income.autokind = 'RECUP'
	
	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM service WHERE idser IN ('07_BRS_CVZ', '07_BRS_STN', '07_BRS_GEN', '07_BRS_ESE',
'07_CMP_STNCVZ', '07_CMP_STN', '07_RCR_TERZI', '07_DAT_M', '07_DAT_N', '07_DAT_I', '07_DAT_P', '07_DAT_U35',
'07_MSS_ASS', '07_MSS_DIP', '07_MSS_OUT', '07_MSS_RIC', '07_OCC_M', '07_OCC_N', '07_OCC_P', '07_PRF', '07_GENERICA'))
BEGIN
	-- Parte 3. Tabelle SERVICE, ADMPAY_EXPENSE, CASUALCONTRACT, EXPENSE, ITINERATION, MOTIVE770SERVICE,
	-- PARASUBCONTRACT, PROFSERVICE, ROLESERVICE, SERVICESORTING, SERVICETAX, TAXSORTINGSETUP, WAGEADDITION
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('BORSESTCON', '07_BRS_CVZ')
	INSERT INTO #temp VALUES('BORSESTRA', '07_BRS_STN')
	INSERT INTO #temp VALUES('BORSISTI', '07_BRS_GEN')
	INSERT INTO #temp VALUES('BORSISTIES', '07_BRS_ESE')
	INSERT INTO #temp VALUES('COMPSTCON', '07_CMP_STNCVZ')
	INSERT INTO #temp VALUES('COMPSTRA', '07_CMP_STN')
	INSERT INTO #temp VALUES('CTERZIRICE', '07_RCR_TERZI')
	INSERT INTO #temp VALUES('DIRAUMUTU', '07_DAT_M')
	INSERT INTO #temp VALUES('DIRAUNNMUT', '07_DAT_N')
	INSERT INTO #temp VALUES('DIRAUP.IVA', '07_DAT_I')
	INSERT INTO #temp VALUES('DIRAUPENSI', '07_DAT_P')
	INSERT INTO #temp VALUES('DIRAUTUND35', '07_DAT_U35')
	INSERT INTO #temp VALUES('MISSASS', '07_MSS_ASS')
	INSERT INTO #temp VALUES('MISSDIP', '07_MSS_DIP')
	INSERT INTO #temp VALUES('MISSESTRANEI', '07_MSS_OUT')
	INSERT INTO #temp VALUES('MISSRICEST', '07_MSS_RIC')
	INSERT INTO #temp VALUES('OCCIRAMUTU', '07_OCC_M')
	INSERT INTO #temp VALUES('OCCIRANMUT', '07_OCC_N')
	INSERT INTO #temp VALUES('OCCIRAPENS', '07_OCC_P')
	INSERT INTO #temp VALUES('PRESTPROF', '07_PRF')
	INSERT INTO #temp VALUES('GENERICA', '07_GENERICA')

	UPDATE service
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE admpay_expense
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE casualcontract
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE expense
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE itineration
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE motive770service
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE parasubcontract
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE profservice
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE roleservice
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE servicesorting
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE servicetax
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE taxsortingsetup
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	UPDATE wageaddition
	SET idser = #temp.newvalue
	FROM #temp WHERE idser = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM tax WHERE taxcode IN ('07_ACC_DAT_40', '07_ACC_DAT', '07_ACC_FISC', '07_ADDCOMCAF',
'07_ADDREGCAF', '07_FDOCRE', '07_INPDAP_CAMM', '07_INPDAP_CDIP', '07_INPS_M', '07_INPS_N', '07_INPS_P', '07_IRAP',
'07_IRAP_CO', '07_IRPEF_GEN', '07_IRPEF_ASS', '07_IRPEF_CAF', '07_IRPEF_R1', '07_IRPEF_R2', '07_IRPEF_FC',
'07_IRPEF_FO', '07_TASSASEP', '07_IRPEF_BRS'))
BEGIN
	-- Parte 3. Tabelle TAX (2 campi), ABATEMENT, ADMPAY_ADMINTAX, ADMPAY_EMPLOYTAX, CASUALCONTRACTTAX, CASUALCONTRACTTAXBRACKET,
	-- EXPENSETAX, ITINERATIONTAX, PAYROLLABATEMENT, PAYROLLTAX, PROFSERVICETAX, SERVICETAX, TAXSORTINGSETUP, WAGEADDITIONTAX,
	-- TAXPAY, TAXPAYEXPENSE, TAXPAYMENTPARTSETUP, TAXRATEBRACKET, TAXRATECITYBRACKET, TAXRATECITYSTART,
	-- TAXRATEREGIONCITYBRACKET, TAXRATEREGIONCITYSTART, TAXREGIONSTART, TAXRATESTART, TAXREGIONSETUP, TAXSETUP, TAXSORTING
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ACC.AUT.40%', '07_ACC_DAT_40')
	INSERT INTO #temp VALUES('ACC.DIRAUT', '07_ACC_DAT')
	INSERT INTO #temp VALUES('ACCONTO', '07_ACC_FISC')
	INSERT INTO #temp VALUES('ADDCOMCAF', '07_ADDCOMCAF')
	INSERT INTO #temp VALUES('ADDREGCAF', '07_ADDREGCAF')
	INSERT INTO #temp VALUES('FONDOCRED', '07_FDOCRE')
	INSERT INTO #temp VALUES('INPDAPAMM', '07_INPDAP_CAMM')
	INSERT INTO #temp VALUES('INPDAPDIP', '07_INPDAP_CDIP')
	INSERT INTO #temp VALUES('INPSAUT', '07_INPS_M')
	INSERT INTO #temp VALUES('INPSNONMUT', '07_INPS_N')
	INSERT INTO #temp VALUES('INPSPENDIR', '07_INPS_P')
	INSERT INTO #temp VALUES('IRAP', '07_IRAP')
	INSERT INTO #temp VALUES('IRAPCOORD', '07_IRAP_CO')
	INSERT INTO #temp VALUES('IRPEF', '07_IRPEF_GEN')
	INSERT INTO #temp VALUES('IRPEFASSIM', '07_IRPEF_ASS')
	INSERT INTO #temp VALUES('IRPEFCAF', '07_IRPEF_CAF')
	INSERT INTO #temp VALUES('IRPEFRATA1', '07_IRPEF_R1')
	INSERT INTO #temp VALUES('IRPEFRATA2', '07_IRPEF_R2')
	INSERT INTO #temp VALUES('IRPEFSTCON', '07_IRPEF_FC')
	INSERT INTO #temp VALUES('IRPEFSTRA', '07_IRPEF_FO')
	INSERT INTO #temp VALUES('TASSASEP', '07_TASSASEP')
	INSERT INTO #temp VALUES('IRPEFBORS', '07_IRPEF_BRS')

	UPDATE tax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE tax
	SET maintaxcode = #temp.newvalue
	FROM #temp WHERE maintaxcode = #temp.oldvalue

	UPDATE abatement
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE admpay_admintax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE admpay_employtax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE casualcontracttax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE casualcontracttaxbracket
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE expensetax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE itinerationtax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE payrollabatement
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE payrolltax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE profservicetax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE servicetax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxsortingsetup
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE wageadditiontax
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxpay
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxpayexpense
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxpaymentpartsetup
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxratebracket
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxratestart
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxratecitybracket
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxratecitystart
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxrateregioncitybracket
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxrateregioncitystart
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxrateregionstart
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxrateregionbracket
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxregionsetup
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxsetup
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE taxsorting
	SET taxcode = #temp.newvalue
	FROM #temp WHERE taxcode = #temp.oldvalue

	UPDATE expense
	SET autocode = #temp.newvalue
	FROM #temp WHERE autocode = #temp.oldvalue
	AND autokind IN ('RITEN','LIQRT')

	UPDATE income
	SET autocode = #temp.newvalue
	FROM #temp WHERE autocode = #temp.oldvalue
	AND autokind IN ('RITEN','LIQRT')

	UPDATE expensevar
	SET autocode = #temp.newvalue
	FROM #temp WHERE autocode = #temp.oldvalue
	AND autokind = 'RITEN'

	DROP TABLE #temp
END
GO
