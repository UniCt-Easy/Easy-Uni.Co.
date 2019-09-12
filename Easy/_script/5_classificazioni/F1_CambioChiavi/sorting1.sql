-- Aggiornamento tabella SORTING e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- accountsorting, accountvardetail, accountyear, admpay_expensesorted, admpay_incomesorted, assetacquire, autoexpensesorting, autoincomesorting'
-- banktransactionsorting, casualcontract, casualcontractsorting, clawbacksorting, divisionsorting, entrydetail, epexpsorting, estimatedetail'
-- estimatesorting, expensesorted, finsorting, flowchartsorting,incomesorted, ,inventorytreesorting, invoicedetail, invoicesorting, itineration'
-- itinerationsorting, locationsorting, managersorting, mandatedetail, mandatesorting, parasubcontract, parasubcontractsorting, pettycashoperation'
-- pettycashoperationsorted, profservice, profservicesorting, registrysorting, servicesorting, sortedmovementtotal, sortingexpensefilter'
-- sortingincomefilter, sortingprev, sortingprevexpensevar, sortingprevincomevar, sortingtotal, sortingtranslation, taxsorting'
-- taxsortingsetup, upbsorting, wageaddition, wageadditionsorting'

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM accountsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = accountsorting.idsorkind AND k.idsor = accountsorting.idsor)
GO

DELETE FROM accountvardetail WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = accountvardetail.idsorkind AND k.idsor = accountvardetail.idsor)
GO

DELETE FROM accountyear WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = accountyear.idsorkind AND k.idsor = accountyear.idsor)
GO

DELETE FROM admpay_expensesorted WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = admpay_expensesorted.idsorkind AND k.idsor = admpay_expensesorted.idsor)
GO

DELETE FROM admpay_incomesorted WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = admpay_incomesorted.idsorkind AND k.idsor = admpay_incomesorted.idsor)
GO

DELETE FROM autoexpensesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = autoexpensesorting.idsorkind AND k.idsor = autoexpensesorting.idsor)
AND autoexpensesorting.idsorkind IS NOT NULL AND autoexpensesorting.idsor IS NOT NULL
GO

DELETE FROM autoexpensesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = autoexpensesorting.idsorkindreg AND k.idsor = autoexpensesorting.idsorreg)
AND autoexpensesorting.idsorkindreg IS NOT NULL AND autoexpensesorting.idsorreg IS NOT NULL
GO

DELETE FROM autoincomesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = autoincomesorting.idsorkind AND k.idsor = autoincomesorting.idsor)
AND autoincomesorting.idsorkind IS NOT NULL AND autoincomesorting.idsor IS NOT NULL
GO

DELETE FROM autoincomesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = autoincomesorting.idsorkindreg AND k.idsor = autoincomesorting.idsorreg)
AND autoincomesorting.idsorkindreg IS NOT NULL AND autoincomesorting.idsorreg IS NOT NULL
GO

DELETE FROM banktransactionsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = banktransactionsorting.idsorkind AND k.idsor = banktransactionsorting.idsor)
GO

DELETE FROM casualcontractsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = casualcontractsorting.idsorkind AND k.idsor = casualcontractsorting.idsor)
GO

DELETE FROM clawbacksorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = clawbacksorting.idsorkind AND k.idsor = clawbacksorting.idsor)
GO

DELETE FROM divisionsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = divisionsorting.idsorkind AND k.idsor = divisionsorting.idsor)
GO

DELETE FROM epexpsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = epexpsorting.idsorkind AND k.idsor = epexpsorting.idsor)
GO

DELETE FROM estimatesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = estimatesorting.idsorkind AND k.idsor = estimatesorting.idsor)
GO

DELETE FROM expensesorted WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = expensesorted.idsorkind AND k.idsor = expensesorted.idsor)
GO

DELETE FROM finsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = finsorting.idsorkind AND k.idsor = finsorting.idsor)
GO

DELETE FROM flowchartsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = flowchartsorting.idsorkind AND k.idsor = flowchartsorting.idsor)
GO

DELETE FROM incomesorted WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = incomesorted.idsorkind AND k.idsor = incomesorted.idsor)
GO

DELETE FROM inventorytreesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = inventorytreesorting.idsorkind AND k.idsor = inventorytreesorting.idsor)
GO

DELETE FROM invoicesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = invoicesorting.idsorkind AND k.idsor = invoicesorting.idsor)
GO

DELETE FROM itinerationsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = itinerationsorting.idsorkind AND k.idsor = itinerationsorting.idsor)
GO

DELETE FROM locationsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = locationsorting.idsorkind AND k.idsor = locationsorting.idsor)
GO

DELETE FROM managersorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = managersorting.idsorkind AND k.idsor = managersorting.idsor)
GO

DELETE FROM mandatesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = mandatesorting.idsorkind AND k.idsor = mandatesorting.idsor)
GO

DELETE FROM parasubcontractsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = parasubcontractsorting.idsorkind AND k.idsor = parasubcontractsorting.idsor)
GO

DELETE FROM pettycashoperationsorted WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = pettycashoperationsorted.idsorkind AND k.idsor = pettycashoperationsorted.idsor)
GO

DELETE FROM profservicesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = profservicesorting.idsorkind AND k.idsor = profservicesorting.idsor)
GO

DELETE FROM registrysorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = registrysorting.idsorkind AND k.idsor = registrysorting.idsor)
GO

DELETE FROM servicesorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = servicesorting.idsorkind AND k.idsor = servicesorting.idsor)
GO

DELETE FROM sortedmovementtotal WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortedmovementtotal.idsorkind AND k.idsor = sortedmovementtotal.idsor)
GO

DELETE FROM sortingexpensefilter WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingexpensefilter.idsorkind AND k.idsor = sortingexpensefilter.idsor)
AND sortingexpensefilter.idsorkind IS NOT NULL AND sortingexpensefilter.idsor IS NOT NULL
GO

DELETE FROM sortingexpensefilter WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingexpensefilter.idsorkindreg AND k.idsor = sortingexpensefilter.idsorreg)
AND sortingexpensefilter.idsorkindreg IS NOT NULL AND sortingexpensefilter.idsorreg IS NOT NULL
GO

DELETE FROM sortingincomefilter WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingincomefilter.idsorkind AND k.idsor = sortingincomefilter.idsor)
AND sortingincomefilter.idsorkind IS NOT NULL AND sortingincomefilter.idsor IS NOT NULL
GO

DELETE FROM sortingincomefilter WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingincomefilter.idsorkindreg AND k.idsor = sortingincomefilter.idsorreg)
AND sortingincomefilter.idsorkindreg IS NOT NULL AND sortingincomefilter.idsorreg IS NOT NULL
GO

DELETE FROM sortingprev WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingprev.idsorkind AND k.idsor = sortingprev.idsor)
GO

DELETE FROM sortingprevexpensevar WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingprevexpensevar.idsorkind AND k.idsor = sortingprevexpensevar.idsor)
AND idsorkind IS NOT NULL AND idsor IS NOT NULL
GO

DELETE FROM sortingprevincomevar WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingprevincomevar.idsorkind AND k.idsor = sortingprevincomevar.idsor)
AND idsorkind IS NOT NULL AND idsor IS NOT NULL
GO

DELETE FROM sortingtotal WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingtotal.idsorkind AND k.idsor = sortingtotal.idsor)
AND idsorkind IS NOT NULL AND idsor IS NOT NULL
GO

DELETE FROM sortingtranslation WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingtranslation.sortingkindchild AND k.idsor = sortingtranslation.idsortingchild)
AND sortingkindchild IS NOT NULL AND idsortingchild IS NOT NULL
GO

DELETE FROM sortingtranslation WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = sortingtranslation.sortingkindmaster AND k.idsor = sortingtranslation.idsortingmaster)
AND sortingkindmaster IS NOT NULL AND idsortingmaster IS NOT NULL
GO

DELETE FROM taxsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = taxsorting.idsorkind AND k.idsor = taxsorting.idsor)
GO

DELETE FROM upbsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = upbsorting.idsorkind AND k.idsor = upbsorting.idsor)
GO

DELETE FROM wageadditionsorting WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = wageadditionsorting.idsorkind AND k.idsor = wageadditionsorting.idsor)
GO

DELETE FROM taxsortingsetup WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = taxsortingsetup.idsorkind AND k.idsor = taxsortingsetup.idsor_adminpay)
AND idsorkind IS NOT NULL AND idsor_adminpay IS NOT NULL
GO

DELETE FROM taxsortingsetup WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = taxsortingsetup.idsorkind AND k.idsor = taxsortingsetup.idsor_adminproc)
AND idsorkind IS NOT NULL AND idsor_adminproc IS NOT NULL
GO

DELETE FROM taxsortingsetup WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = taxsortingsetup.idsorkind AND k.idsor = taxsortingsetup.idsor_employproc)
AND idsorkind IS NOT NULL AND idsor_employproc IS NOT NULL
GO

DELETE FROM taxsortingsetup WHERE NOT EXISTS(SELECT * FROM sorting k WHERE k.idsorkind = taxsortingsetup.idsorkind AND k.idsor = taxsortingsetup.idsor_taxpay)
AND idsorkind IS NOT NULL AND idsor_taxpay IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger 
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_accountvardetail]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_accountvardetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_accountyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_accountyear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_epexpsorting]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_epexpsorting]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensesorted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomesorted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_sortingprevexpensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_sortingprevexpensevar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_sortingprevincomevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_sortingprevincomevar]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD idsorint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD paridsorint int NULL
END
GO
-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountvardetail] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountvardetail] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountyear] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountyear] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_expensesorted] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_incomesorted] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetacquire] ALTER COLUMN idsor3int int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorregint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorregint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [banktransactionsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontract] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontract] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontract] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontractsorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [clawbacksorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [divisionsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [entrydetail] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [entrydetail] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [entrydetail] ALTER COLUMN idsor3int int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [epexpsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [epexpsorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatesorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD paridsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN paridsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [flowchartsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD paridsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN paridsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [locationsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [managersorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatesorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontractsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservicesorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrysorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registrysorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [servicesorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortedmovementtotal] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorregint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorregint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprev] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprev] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevexpensevar] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprevexpensevar] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevincomevar] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprevincomevar] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtotal] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtotal] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsorting] ALTER COLUMN idsorint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_adminpayint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_adminpayint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminprocint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_adminprocint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_adminprocint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_employprocint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_employprocint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_employprocint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_taxpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_taxpayint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_taxpayint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upbsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageaddition] ALTER COLUMN idsor1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageaddition] ALTER COLUMN idsor2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageaddition] ALTER COLUMN idsor3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD idsorint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageadditionsorting] ALTER COLUMN idsorint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingchildint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD idsortingchildint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN idsortingchildint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingmasterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD idsortingmasterint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN idsortingmasterint int NULL
END
GO
