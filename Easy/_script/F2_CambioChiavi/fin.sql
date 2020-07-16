/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿-- Passo -1: Riempimento di FINLOOKUP che da facoltativa, diverrà obbligatoria
CREATE TABLE #finlookup (oldidfin varchar(31), newidfin varchar(31))

DECLARE @min int
DECLARE @max int

SELECT @min = MIN(ayear), @max = MAX(ayear) FROM accountingyear

DECLARE @curr int
SET @curr = @min
WHILE(@curr < @max)
BEGIN
	INSERT INTO #finlookup (oldidfin, newidfin)
	EXEC closeyear_fillconvbilancio @curr
	SET @curr = @curr + 1
END

INSERT INTO finlookup (oldidfin, newidfin, ct, cu, lt, lu)
SELECT oldidfin, newidfin, GETDATE(), 'AUTOMATICO', GETDATE(), '''AUTOMATICO'''
FROM #finlookup T
WHERE NOT EXISTS(SELECT oldidfin FROM finlookup f WHERE f.oldidfin = T.oldidfin)

DROP TABLE #finlookup
GO

-- Aggiornamento tabella FIN e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- admpay_appropriation, admpay_assessment, autoexpensesorting, autoincomesorting, clawbacksetup, creditpart,
-- expenseyear, finbalancedetail, finlookup, finsorting, finvardetail, finyear, flowchartfin,
-- incomeyear, invoicesetup, itinerationsetup, partincomesetup, payment, pettycashoperation, 
-- pettycashsetup, prevfindetail, proceeds, proceedspart, sortingexpensefilter, sortingincomefilter, taxsetup, 
-- upbexpensetotal, upbincometotal, upbtotal

-- Passo 0: Cancellazione righe che violano l'integrità referenziale
DELETE FROM creditpart WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = creditpart.idfin)
GO

DELETE FROM finbalancedetail WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finbalancedetail.idfin)
GO

DELETE FROM finlookup WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finlookup.oldidfin)
GO

DELETE FROM finlookup WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finlookup.newidfin)
GO

DELETE FROM finsorting WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finsorting.idfin)
GO

DELETE FROM finvardetail WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finvardetail.idfin)
GO

DELETE FROM finyear WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = finyear.idfin)
GO

DELETE FROM flowchartfin WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = flowchartfin.idfin)
GO

DELETE FROM partincomesetup WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = partincomesetup.idfinincome)
GO

DELETE FROM partincomesetup WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = partincomesetup.idfinexpense)
GO

DELETE FROM prevfindetail WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = prevfindetail.idfin)
GO

DELETE FROM proceedspart WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = proceedspart.idfin)
GO

DELETE FROM upbexpensetotal WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = upbexpensetotal.idfin)
GO

DELETE FROM upbincometotal WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = upbincometotal.idfin)
GO

DELETE FROM upbtotal WHERE NOT EXISTS(SELECT * FROM fin WHERE fin.idfin = upbtotal.idfin)
GO

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_creditpart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_creditpart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenseyear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finvardetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finyear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomeyear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_proceeds]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_proceeds]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_proceedspart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_proceedspart]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD idfinint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'paridfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD paridfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [fin] ALTER COLUMN paridfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_appropriation] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_appropriation] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_assessment] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_assessment] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idfinint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'clawbackfinanceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksetup] ADD clawbackfinanceint int NULL
END
ELSE
BEGIN
	ALTER TABLE [clawbacksetup] ALTER COLUMN clawbackfinanceint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [creditpart] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseyear] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finbalancedetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finbalancedetail] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finbalancedetail] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'oldidfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ADD oldidfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finlookup] ALTER COLUMN oldidfinint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'newidfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ADD newidfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finlookup] ALTER COLUMN newidfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finsorting] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvardetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finvardetail] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finvardetail] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finyear] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finyear] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartfin' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartfin] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [flowchartfin] ALTER COLUMN idfinint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeyear] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivapaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesetup] ADD idfinivapaymentint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicesetup] ALTER COLUMN idfinivapaymentint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivarefundint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesetup] ADD idfinivarefundint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicesetup] ALTER COLUMN idfinivarefundint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsetup] ADD idfinexpenseint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationsetup] ALTER COLUMN idfinexpenseint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ADD idfinexpenseint int NULL
END
ELSE
BEGIN
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinexpenseint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ADD idfinincomeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinincomeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payment] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idfinexpenseint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashsetup] ALTER COLUMN idfinexpenseint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idfinincomeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashsetup] ALTER COLUMN idfinincomeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'prevfindetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [prevfindetail] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [prevfindetail] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceeds] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceedspart] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idfinint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinadmintaxint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinadmintaxint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN idfinadmintaxint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinexpensecontraint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinexpensecontraint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN idfinexpensecontraint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinincomecontraint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinincomecontraint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN idfinincomecontraint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upbexpensetotal] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upbincometotal] ALTER COLUMN idfinint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbtotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbtotal] ADD idfinint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upbtotal] ALTER COLUMN idfinint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'paridfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET paridfinint =
		(SELECT idfinint FROM fin f2 WHERE f2.idfin = fin.paridfin)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_appropriation SET idfinint = fin.idfinint
	FROM fin
	WHERE admpay_appropriation.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_assessment SET idfinint = fin.idfinint
	FROM fin
	WHERE admpay_assessment.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idfinint = fin.idfinint
	FROM fin
	WHERE autoexpensesorting.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idfinint = fin.idfinint
	FROM fin
	WHERE autoincomesorting.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'clawbackfinanceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksetup SET clawbackfinanceint = fin.idfinint
	FROM fin
	WHERE clawbacksetup.clawbackfinance = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE creditpart SET idfinint = fin.idfinint
	FROM fin
	WHERE creditpart.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET idfinint = fin.idfinint
	FROM fin
	WHERE expenseyear.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finbalancedetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finbalancedetail SET idfinint = fin.idfinint
	FROM fin
	WHERE finbalancedetail.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'oldidfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finlookup SET oldidfinint = fin.idfinint
	FROM fin
	WHERE finlookup.oldidfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'newidfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finlookup SET newidfinint = fin.idfinint
	FROM fin
	WHERE finlookup.newidfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsorting SET idfinint = fin.idfinint
	FROM fin
	WHERE finsorting.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvardetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finvardetail SET idfinint = fin.idfinint
	FROM fin
	WHERE finvardetail.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finyear SET idfinint = fin.idfinint
	FROM fin
	WHERE finyear.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartfin' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartfin SET idfinint = fin.idfinint
	FROM fin
	WHERE flowchartfin.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET idfinint = fin.idfinint
	FROM fin
	WHERE incomeyear.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivapaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesetup SET idfinivapaymentint = fin.idfinint
	FROM fin
	WHERE invoicesetup.idfinivapayment = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivarefundint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesetup SET idfinivarefundint = fin.idfinint
	FROM fin
	WHERE invoicesetup.idfinivarefund = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsetup SET idfinexpenseint = fin.idfinint
	FROM fin
	WHERE itinerationsetup.idfinexpense = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE partincomesetup SET idfinexpenseint = fin.idfinint
	FROM fin
	WHERE partincomesetup.idfinexpense = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE partincomesetup SET idfinincomeint = fin.idfinint
	FROM fin
	WHERE partincomesetup.idfinincome = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idfinint = fin.idfinint
	FROM fin
	WHERE payment.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idfinint = fin.idfinint
	FROM fin
	WHERE pettycashoperation.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashsetup SET idfinexpenseint = fin.idfinint
	FROM fin
	WHERE pettycashsetup.idfinexpense = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinincomeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashsetup SET idfinincomeint = fin.idfinint
	FROM fin
	WHERE pettycashsetup.idfinincome = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'prevfindetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE prevfindetail SET idfinint = fin.idfinint
	FROM fin
	WHERE prevfindetail.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idfinint = fin.idfinint
	FROM fin
	WHERE proceeds.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedspart SET idfinint = fin.idfinint
	FROM fin
	WHERE proceedspart.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idfinint = fin.idfinint
	FROM fin
	WHERE sortingexpensefilter.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idfinint = fin.idfinint
	FROM fin
	WHERE sortingincomefilter.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinadmintaxint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET idfinadmintaxint = fin.idfinint
	FROM fin
	WHERE taxsetup.idfinadmintax = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinexpensecontraint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET idfinexpensecontraint = fin.idfinint
	FROM fin
	WHERE taxsetup.idfinexpensecontra = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinincomecontraint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET idfinincomecontraint = fin.idfinint
	FROM fin
	WHERE taxsetup.idfinincomecontra = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbexpensetotal SET idfinint = fin.idfinint
	FROM fin
	WHERE upbexpensetotal.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbincometotal SET idfinint = fin.idfinint
	FROM fin
	WHERE upbincometotal.idfin = fin.idfin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbtotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbtotal SET idfinint = fin.idfinint
	FROM fin
	WHERE upbtotal.idfin = fin.idfin
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono fin, finbalancedetail, finlookup, finsorting, finvardetail, finyear, flowchartfin,
-- partincomesetup, prevfindetail, upbexpensetotal, upbincometotal, upbtotal

IF exists(SELECT * FROM sysconstraints where id=object_id('fin') and constid=object_id('xpkfin'))
BEGIN
	ALTER TABLE [fin] drop constraint xpkfin
END

IF exists(SELECT * FROM sysconstraints where id=object_id('fin') and constid=object_id('PK_fin'))
BEGIN
	ALTER TABLE [fin] drop constraint PK_fin
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('finbalancedetail') and constid=object_id('xpkfinbalancedetail'))
BEGIN
	ALTER TABLE [finbalancedetail] drop constraint xpkfinbalancedetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finbalancedetail') and constid=object_id('PK_finbalancedetail'))
BEGIN
	ALTER TABLE [finbalancedetail] drop constraint PK_finbalancedetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('finlookup') and constid=object_id('xpkfinlookup'))
BEGIN
	ALTER TABLE [finlookup] drop constraint xpkfinlookup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finlookup') and constid=object_id('PK_finlookup'))
BEGIN
	ALTER TABLE [finlookup] drop constraint PK_finlookup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('xpkfinsorting'))
BEGIN
	ALTER TABLE [finsorting] drop constraint xpkfinsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('PK_finsorting'))
BEGIN
	ALTER TABLE [finsorting] drop constraint PK_finsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('finvardetail') and constid=object_id('xpkfinvardetail'))
BEGIN
	ALTER TABLE [finvardetail] drop constraint xpkfinvardetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finvardetail') and constid=object_id('PK_finvardetail'))
BEGIN
	ALTER TABLE [finvardetail] drop constraint PK_finvardetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('finyear') and constid=object_id('xpkfinyear'))
BEGIN
	ALTER TABLE [finyear] drop constraint xpkfinyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finyear') and constid=object_id('PK_finyear'))
BEGIN
	ALTER TABLE [finyear] drop constraint PK_finyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartfin') and constid=object_id('xpkflowchartfin'))
BEGIN
	ALTER TABLE [flowchartfin] drop constraint xpkflowchartfin
END

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartfin') and constid=object_id('PK_flowchartfin'))
BEGIN
	ALTER TABLE [flowchartfin] drop constraint PK_flowchartfin
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('partincomesetup') and constid=object_id('xpkpartincomesetup'))
BEGIN
	ALTER TABLE [partincomesetup] drop constraint xpkpartincomesetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('partincomesetup') and constid=object_id('PK_incomevar'))
BEGIN
	ALTER TABLE [partincomesetup] drop constraint PK_partincomesetup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('prevfindetail') and constid=object_id('xpkprevfindetail'))
BEGIN
	ALTER TABLE [prevfindetail] drop constraint xpkprevfindetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('prevfindetail') and constid=object_id('PK_prevfindetail'))
BEGIN
	ALTER TABLE [prevfindetail] drop constraint PK_prevfindetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('xpkupbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] drop constraint xpkupbexpensetotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('PK_upbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] drop constraint PK_upbexpensetotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('xpkupbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] drop constraint xpkupbincometotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('PK_upbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] drop constraint PK_upbincometotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbtotal') and constid=object_id('xpkupbtotal'))
BEGIN
	ALTER TABLE [upbtotal] drop constraint xpkupbtotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbtotal') and constid=object_id('PK_upbtotal'))
BEGIN
	ALTER TABLE [upbtotal] drop constraint PK_upbtotal
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1fin' and id=object_id('fin'))
	drop index fin.xi1fin

IF EXISTS (SELECT * FROM sysindexes where name='xi2clawbacksetup' and id=object_id('clawbacksetup'))
	drop index clawbacksetup.xi2clawbacksetup

IF EXISTS (SELECT * FROM sysindexes where name='xi2creditpart' and id=object_id('creditpart'))
	drop index creditpart.xi2creditpart

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseyear' and id=object_id('expenseyear'))
	drop index expenseyear.xi2expenseyear
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expenseyear' and id=object_id('expenseyear'))
	drop index expenseyear.xi3expenseyear

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlookup' and id=object_id('finlookup'))
	drop index finlookup.xi1finlookup

IF EXISTS (SELECT * FROM sysindexes where name='xi2finlookup' and id=object_id('finlookup'))
	drop index finlookup.xi2finlookup

IF EXISTS (SELECT * FROM sysindexes where name='xi2finsorting' and id=object_id('finsorting'))
	drop index finsorting.xi2finsorting
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finvardetail' and id=object_id('finvardetail'))
	drop index finvardetail.xi2finvardetail

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeyear' and id=object_id('incomeyear'))
	drop index incomeyear.xi2incomeyear

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomeyear' and id=object_id('incomeyear'))
	drop index incomeyear.xi3incomeyear

IF EXISTS (SELECT * FROM sysindexes where name='xi5invoicesetup' and id=object_id('invoicesetup'))
	drop index invoicesetup.xi5invoicesetup

IF EXISTS (SELECT * FROM sysindexes where name='xi7invoicesetup' and id=object_id('invoicesetup'))
	drop index invoicesetup.xi7invoicesetup
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationsetup' and id=object_id('itinerationsetup'))
	drop index itinerationsetup.xi1itinerationsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi1partincomesetup' and id=object_id('partincomesetup'))
	drop index partincomesetup.xi1partincomesetup

IF EXISTS (SELECT * FROM sysindexes where name='xi2partincomesetup' and id=object_id('partincomesetup'))
	drop index partincomesetup.xi2partincomesetup

IF EXISTS (SELECT * FROM sysindexes where name='xi4payment' and id=object_id('payment'))
	drop index payment.xi4payment

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashoperation' and id=object_id('pettycashoperation'))
	drop index pettycashoperation.xi2pettycashoperation
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashsetup' and id=object_id('pettycashsetup'))
	drop index pettycashsetup.xi2pettycashsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashsetup' and id=object_id('pettycashsetup'))
	drop index pettycashsetup.xi3pettycashsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi4proceeds' and id=object_id('proceeds'))
	drop index proceeds.xi4proceeds

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedspart' and id=object_id('proceedspart'))
	drop index proceedspart.xi2proceedspart

IF EXISTS (SELECT * FROM sysindexes where name='xi3taxsetup' and id=object_id('taxsetup'))
	drop index taxsetup.xi3taxsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi4taxsetup' and id=object_id('taxsetup'))
	drop index taxsetup.xi4taxsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi5taxsetup' and id=object_id('taxsetup'))
	drop index taxsetup.xi5taxsetup
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='paridfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN paridfin
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'paridfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_appropriation'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_appropriation] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'admpay_appropriation' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_assessment'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_assessment] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'admpay_assessment' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idfin'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksetup'
		and C.name ='clawbackfinance'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksetup] DROP COLUMN clawbackfinance
	DELETE FROM columntypes WHERE tablename = 'clawbacksetup' AND field = 'clawbackfinance'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'creditpart'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [creditpart] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'creditpart' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'expenseyear' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finbalancedetail'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finbalancedetail] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'finbalancedetail' AND field = 'idfin'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlookup'
		and C.name ='oldidfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlookup] DROP COLUMN oldidfin
	DELETE FROM columntypes WHERE tablename = 'finlookup' AND field = 'oldidfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlookup'
		and C.name ='newidfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlookup] DROP COLUMN newidfin
	DELETE FROM columntypes WHERE tablename = 'finlookup' AND field = 'newidfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'finsorting' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finvardetail'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finvardetail] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'finvardetail' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finyear'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finyear] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'finyear' AND field = 'idfin'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartfin'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartfin] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'flowchartfin' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'incomeyear' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesetup'
		and C.name ='idfinivarefund'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesetup] DROP COLUMN idfinivarefund
	DELETE FROM columntypes WHERE tablename = 'invoicesetup' AND field = 'idfinivarefund'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesetup'
		and C.name ='idfinivapayment'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN 
	ALTER TABLE [invoicesetup] DROP COLUMN idfinivapayment
	DELETE FROM columntypes WHERE tablename = 'invoicesetup' AND field = 'idfinivapayment'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsetup'
		and C.name ='idfinexpense'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsetup] DROP COLUMN idfinexpense
	DELETE FROM columntypes WHERE tablename = 'itinerationsetup' AND field = 'idfinexpense'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'partincomesetup'
		and C.name ='idfinexpense'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [partincomesetup] DROP COLUMN idfinexpense
	DELETE FROM columntypes WHERE tablename = 'partincomesetup' AND field = 'idfinexpense'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'partincomesetup'
		and C.name ='idfinincome'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [partincomesetup] DROP COLUMN idfinincome
	DELETE FROM columntypes WHERE tablename = 'partincomesetup' AND field = 'idfinincome'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idfinexpense'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idfinexpense
	DELETE FROM columntypes WHERE tablename = 'pettycashsetup' AND field = 'idfinexpense'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idfinincome'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idfinincome
	DELETE FROM columntypes WHERE tablename = 'pettycashsetup' AND field = 'idfinincome'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'prevfindetail'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [prevfindetail] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'prevfindetail' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedspart'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedspart] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'proceedspart' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idfin'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinadmintax'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinadmintax
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'idfinadmintax'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinexpensecontra'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinexpensecontra
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'idfinexpensecontra'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinincomecontra'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinincomecontra
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'idfinincomecontra'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbexpensetotal'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbexpensetotal] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'upbexpensetotal' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbincometotal'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbincometotal] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'upbincometotal' AND field = 'idfin'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbtotal'
		and C.name ='idfin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbtotal] DROP COLUMN idfin
	DELETE FROM columntypes WHERE tablename = 'upbtotal' AND field = 'idfin'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate fin e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [fin] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'paridfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD paridfin int NULL 
END
ELSE
	ALTER TABLE [fin] ALTER COLUMN paridfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_appropriation] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [admpay_appropriation] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_assessment] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [admpay_assessment] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'clawbackfinance' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksetup] ADD clawbackfinance int NULL 
END
ELSE
	ALTER TABLE [clawbacksetup] ALTER COLUMN clawbackfinance int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [creditpart] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [expenseyear] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finbalancedetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finbalancedetail] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [finbalancedetail] ALTER COLUMN idfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'oldidfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ADD oldidfin int NULL 
END
ELSE
	ALTER TABLE [finlookup] ALTER COLUMN oldidfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'newidfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ADD newidfin int NULL 
END
ELSE
	ALTER TABLE [finlookup] ALTER COLUMN newidfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [finsorting] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvardetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finvardetail] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [finvardetail] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finyear' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finyear] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [finyear] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartfin' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartfin] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [flowchartfin] ALTER COLUMN idfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [incomeyear] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivapayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesetup] ADD idfinivapayment int NULL 
END
ELSE
	ALTER TABLE [invoicesetup] ALTER COLUMN idfinivapayment int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivarefund' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesetup] ADD idfinivarefund int NULL 
END
ELSE
	ALTER TABLE [invoicesetup] ALTER COLUMN idfinivarefund int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idfinexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsetup] ADD idfinexpense int NULL 
END
ELSE
	ALTER TABLE [itinerationsetup] ALTER COLUMN idfinexpense int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ADD idfinexpense int NULL 
END
ELSE
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinexpense int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinincome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ADD idfinincome int NULL 
END
ELSE
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinincome int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [payment] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idfinexpense int NULL 
END
ELSE
	ALTER TABLE [pettycashsetup] ALTER COLUMN idfinexpense int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinincome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idfinincome int NULL 
END
ELSE
	ALTER TABLE [pettycashsetup] ALTER COLUMN idfinincome int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'prevfindetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [prevfindetail] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [prevfindetail] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [proceeds] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [proceedspart] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinadmintax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinadmintax int NULL 
END
ELSE
	ALTER TABLE [taxsetup] ALTER COLUMN idfinadmintax int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinexpensecontra' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinexpensecontra int NULL 
END
ELSE
	ALTER TABLE [taxsetup] ALTER COLUMN idfinexpensecontra int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinincomecontra' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD idfinincomecontra int NULL 
END
ELSE
	ALTER TABLE [taxsetup] ALTER COLUMN idfinincomecontra int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [upbexpensetotal] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [upbincometotal] ALTER COLUMN idfin int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbtotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbtotal] ADD idfin int NULL 
END
ELSE
	ALTER TABLE [upbtotal] ALTER COLUMN idfin int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET idfin = idfinint, paridfin = paridfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_appropriation SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_assessment SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksetup' and C.name = 'clawbackfinanceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksetup SET clawbackfinance = clawbackfinanceint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE creditpart SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finbalancedetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finbalancedetail SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'oldidfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finlookup SET oldidfin = oldidfinint, newidfin = newidfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsorting SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvardetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finvardetail SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finyear SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartfin' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartfin SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesetup' and C.name = 'idfinivapaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesetup SET idfinivapayment = idfinivapaymentint, idfinivarefund = idfinivarefundint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsetup SET idfinexpense = idfinexpenseint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE partincomesetup SET idfinexpense = idfinexpenseint, idfinincome = idfinincomeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idfinexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashsetup SET idfinexpense = idfinexpenseint, idfinincome = idfinincomeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'prevfindetail' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE prevfindetail SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedspart SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'idfinadmintaxint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET idfinadmintax = idfinadmintaxint, idfinexpensecontra = idfinexpensecontraint, idfinincomecontra = idfinincomecontraint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbexpensetotal SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbincometotal SET idfin = idfinint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbtotal' and C.name = 'idfinint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbtotal SET idfin = idfinint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finbalancedetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finbalancedetail] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'oldidfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ALTER COLUMN oldidfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlookup' and C.name = 'newidfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlookup] ALTER COLUMN newidfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvardetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finvardetail] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finyear' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finyear] ALTER COLUMN idfin int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartfin' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartfin] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinexpense int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partincomesetup' and C.name = 'idfinincome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partincomesetup] ALTER COLUMN idfinincome int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'prevfindetail' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [prevfindetail] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbexpensetotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbexpensetotal] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbincometotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbincometotal] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbtotal' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbtotal] ALTER COLUMN idfin int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE A NOT NULL)
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ALTER COLUMN idfin int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ALTER COLUMN idfin int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('fin') and constid=object_id('xpkfin'))
BEGIN
	ALTER TABLE [fin] ADD CONSTRAINT xpkfin PRIMARY KEY (idfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finbalancedetail') and constid=object_id('xpkfinbalancedetail'))
BEGIN
	ALTER TABLE [finbalancedetail] ADD CONSTRAINT xpkfinbalancedetail PRIMARY KEY (ayear, idfin, nfinbalance, idupb)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finlookup') and constid=object_id('xpkfinlookup'))
BEGIN
	ALTER TABLE [finlookup] ADD CONSTRAINT xpkfinlookup PRIMARY KEY (oldidfin, newidfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('xpkfinsorting'))
BEGIN
	ALTER TABLE [finsorting] ADD CONSTRAINT xpkfinsorting PRIMARY KEY (idfin, idsorkind, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finvardetail') and constid=object_id('xpkfinvardetail'))
BEGIN
	ALTER TABLE [finvardetail] ADD CONSTRAINT xpkfinvardetail PRIMARY KEY (yvar, nvar, idupb, idfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finyear') and constid=object_id('xpkfinyear'))
BEGIN
	ALTER TABLE [finyear] ADD CONSTRAINT xpkfinyear PRIMARY KEY (idupb, idfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('flowchartfin') and constid=object_id('xpkflowchartfin'))
BEGIN
	ALTER TABLE [flowchartfin] ADD CONSTRAINT xpkflowchartfin PRIMARY KEY (idflowchart, idfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('partincomesetup') and constid=object_id('xpkpartincomesetup'))
BEGIN
	ALTER TABLE [partincomesetup] ADD CONSTRAINT xpkpartincomesetup PRIMARY KEY (idfinincome, idfinexpense)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('prevfindetail') and constid=object_id('xpkprevfindetail'))
BEGIN
	ALTER TABLE [prevfindetail] ADD CONSTRAINT xpkprevfindetail PRIMARY KEY (ayear, nprevfin, idupb, idfin)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbexpensetotal') and constid=object_id('xpkupbexpensetotal'))
BEGIN
	ALTER TABLE [upbexpensetotal] ADD CONSTRAINT xpkupbexpensetotal PRIMARY KEY (idupb, idfin, nphase)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbincometotal') and constid=object_id('xpkupbincometotal'))
BEGIN
	ALTER TABLE [upbincometotal] ADD CONSTRAINT xpkupbincometotal PRIMARY KEY (idupb, idfin, nphase)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbtotal') and constid=object_id('xpkupbtotal'))
BEGIN
	ALTER TABLE [upbtotal] ADD CONSTRAINT xpkupbtotal PRIMARY KEY (idupb, idfin)
END

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi1fin' and id=object_id('fin'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1fin ON fin (paridfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1fin
	ON fin (paridfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2clawbacksetup' and id=object_id('clawbacksetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2clawbacksetup ON clawbacksetup (clawbackfinance)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2clawbacksetup
	ON clawbacksetup (clawbackfinance)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2creditpart' and id=object_id('creditpart'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2creditpart ON creditpart (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2creditpart
	ON creditpart (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseyear' and id=object_id('expenseyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseyear ON expenseyear (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseyear
	ON expenseyear (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finsorting' and id=object_id('finsorting'))
	drop index finsorting.xi2finsorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi3expenseyear' and id=object_id('expenseyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3expenseyear ON expenseyear (idfin, idupb)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3expenseyear
	ON expenseyear (idfin, idupb)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlookup' and id=object_id('finlookup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlookup ON finlookup (oldidfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlookup
	ON finlookup (oldidfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finlookup' and id=object_id('finlookup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2finlookup ON finlookup (newidfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2finlookup
	ON finlookup (newidfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finvardetail' and id=object_id('finvardetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2finvardetail ON finvardetail (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2finvardetail
	ON finvardetail (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeyear' and id=object_id('incomeyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomeyear ON incomeyear (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomeyear
	ON incomeyear (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomeyear' and id=object_id('incomeyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3incomeyear ON incomeyear (idfin, idupb)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3incomeyear
	ON incomeyear (idfin, idupb)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5invoicesetup' and id=object_id('invoicesetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5invoicesetup ON invoicesetup (idfinivarefund)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5invoicesetup
	ON invoicesetup (idfinivarefund)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7invoicesetup' and id=object_id('invoicesetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi7invoicesetup ON invoicesetup (idfinivapayment)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi7invoicesetup
	ON invoicesetup (idfinivapayment)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationsetup' and id=object_id('itinerationsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationsetup ON itinerationsetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationsetup
	ON itinerationsetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1partincomesetup' and id=object_id('partincomesetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1partincomesetup ON partincomesetup (idfinincome)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1partincomesetup
	ON partincomesetup (idfinincome)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2partincomesetup' and id=object_id('partincomesetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2partincomesetup ON partincomesetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2partincomesetup
	ON partincomesetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4payment ON payment (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4payment
	ON payment (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashoperation ON pettycashoperation (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashoperation
	ON pettycashoperation (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashsetup ON pettycashsetup (idfinincome)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashsetup
	ON pettycashsetup (idfinincome)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashsetup ON pettycashsetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashsetup
	ON pettycashsetup (idfinexpense)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4proceeds' and id=object_id('proceeds'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4proceeds ON proceeds (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4proceeds
	ON proceeds (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedspart' and id=object_id('proceedspart'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceedspart ON proceedspart (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2proceedspart
	ON proceedspart (idfin)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3taxsetup' and id=object_id('taxsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3taxsetup ON taxsetup (idfinexpensecontra)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3taxsetup
	ON taxsetup (idfinexpensecontra)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4taxsetup' and id=object_id('taxsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4taxsetup ON taxsetup (idfinincomecontra)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4taxsetup
	ON taxsetup (idfinincomecontra)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5taxsetup' and id=object_id('taxsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5taxsetup ON taxsetup (idfinadmintax)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5taxsetup
	ON taxsetup (idfinadmintax)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_appropriation' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:45.437'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'admpay_appropriation' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_appropriation','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-09 10:48:45.437'},'''SARA''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_assessment' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-06-11 11:51:52.610'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'admpay_assessment' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_assessment','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-06-11 11:51:52.610'},'''NINO''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:57.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'autoexpensesorting' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('autoexpensesorting','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:57.313'},'''NINO''','NINO',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:58.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:58.750'} WHERE tablename = 'autoincomesorting' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('autoincomesorting','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:58.750'},'''NINO''','NINO',{ts '2006-10-11 13:16:58.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawbacksetup' AND field = 'clawbackfinance')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:55.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'clawbacksetup' AND field = 'clawbackfinance'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('clawbacksetup','clawbackfinance','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:55.313'},'''NINO''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'creditpart' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:13.717'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'creditpart' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('creditpart','idfin','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:13.717'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseyear' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:02.047'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'expenseyear' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseyear','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:02.047'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'fin' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.983'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'fin' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('fin','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.983'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finbalancedetail' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:07.017'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finbalancedetail' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finbalancedetail','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:07.017'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finlookup' AND field = 'newidfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.530'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finlookup' AND field = 'newidfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finlookup','newidfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.530'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finlookup' AND field = 'oldidfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.530'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finlookup' AND field = 'oldidfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finlookup','oldidfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.530'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finsorting' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-16 14:01:09.467'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finsorting' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finsorting','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-16 14:01:09.467'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finvardetail' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:13.967'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finvardetail' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finvardetail','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:13.967'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finyear' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:18.703'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'finyear' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('finyear','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:18.703'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'flowchartfin' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-09 15:06:58.420'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'flowchartfin' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('flowchartfin','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-09 15:06:58.420'},'''SARA''','SARA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeyear' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:07.657'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'incomeyear' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomeyear','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:07.657'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicesetup' AND field = 'idfinivapayment')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:15.717'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'invoicesetup' AND field = 'idfinivapayment'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicesetup','idfinivapayment','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:15.717'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicesetup' AND field = 'idfinivarefund')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:15.733'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'invoicesetup' AND field = 'idfinivarefund'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicesetup','idfinivarefund','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:15.733'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationsetup' AND field = 'idfinexpense')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:30.907'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'itinerationsetup' AND field = 'idfinexpense'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('itinerationsetup','idfinexpense','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:30.907'},'''SA''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'partincomesetup' AND field = 'idfinexpense')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:10.483'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'partincomesetup' AND field = 'idfinexpense'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('partincomesetup','idfinexpense','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:10.483'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'partincomesetup' AND field = 'idfinincome')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:10.500'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'partincomesetup' AND field = 'idfinincome'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('partincomesetup','idfinincome','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:10.500'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:01.377'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'payment' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('payment','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:01.377'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-07-04 12:14:35.030'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'pettycashoperation' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperation','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-07-04 12:14:35.030'},'''SARA''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashsetup' AND field = 'idfinexpense')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:54.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'pettycashsetup' AND field = 'idfinexpense'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashsetup','idfinexpense','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:54.047'},'''NINO''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashsetup' AND field = 'idfinincome')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:54.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'pettycashsetup' AND field = 'idfinincome'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashsetup','idfinincome','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:54.047'},'''NINO''','NINO',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'prevfindetail' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:01.140'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'prevfindetail' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('prevfindetail','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:01.140'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:54.717'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'proceeds' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('proceeds','idfin','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:54.717'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedspart' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:57.577'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'proceedspart' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('proceedspart','idfin','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:57.577'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:23.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:23.077'} WHERE tablename = 'sortingexpensefilter' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingexpensefilter','idfin','N','int','4','','','System.Int32','int','S','',null,'N',{ts '2006-10-11 13:16:23.077'},'''NINO''','NINO',{ts '2006-10-11 13:16:23.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:24.483'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:24.483'} WHERE tablename = 'sortingincomefilter' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingincomefilter','idfin','N','int','4','','','System.Int32','int','S','',null,'N',{ts '2006-10-11 13:16:24.483'},'''NINO''','NINO',{ts '2006-10-11 13:16:24.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsetup' AND field = 'idfinadmintax')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:00.000'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'taxsetup' AND field = 'idfinadmintax'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsetup','idfinadmintax','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:00.000'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsetup' AND field = 'idfinexpensecontra')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:00.000'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'taxsetup' AND field = 'idfinexpensecontra'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsetup','idfinexpensecontra','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:00.000'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbexpensetotal' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.860'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'upbexpensetotal' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upbexpensetotal','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.860'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbincometotal' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:09.000'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'upbincometotal' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upbincometotal','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:09.000'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbtotal' AND field = 'idfin')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:09.813'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.437'} WHERE tablename = 'upbtotal' AND field = 'idfin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upbtotal','idfin','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:09.813'},'''NINO''','SA',{ts '2006-10-09 10:48:45.437'})
GO
-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='paridfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN paridfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_appropriation'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_appropriation] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_assessment'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_assessment] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idfinint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksetup'
		and C.name ='clawbackfinanceint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksetup] DROP COLUMN clawbackfinanceint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'creditpart'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [creditpart] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finbalancedetail'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finbalancedetail] DROP COLUMN idfinint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlookup'
		and C.name ='oldidfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlookup] DROP COLUMN oldidfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finlookup'
		and C.name ='newidfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finlookup] DROP COLUMN newidfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finvardetail'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finvardetail] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finyear'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finyear] DROP COLUMN idfinint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartfin'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartfin] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesetup'
		and C.name ='idfinivapaymentint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesetup] DROP COLUMN idfinivapaymentint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesetup'
		and C.name ='idfinivarefundint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesetup] DROP COLUMN idfinivarefundint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsetup'
		and C.name ='idfinexpenseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsetup] DROP COLUMN idfinexpenseint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'partincomesetup'
		and C.name ='idfinexpenseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [partincomesetup] DROP COLUMN idfinexpenseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'partincomesetup'
		and C.name ='idfinincomeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [partincomesetup] DROP COLUMN idfinincomeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idfinexpenseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idfinexpenseint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idfinincomeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idfinincomeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'prevfindetail'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [prevfindetail] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedspart'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedspart] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idfinint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinadmintaxint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinadmintaxint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinexpensecontraint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinexpensecontraint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='idfinincomecontraint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN idfinincomecontraint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbexpensetotal'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbexpensetotal] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbincometotal'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbincometotal] DROP COLUMN idfinint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbtotal'
		and C.name ='idfinint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbtotal] DROP COLUMN idfinint
END
GO
	