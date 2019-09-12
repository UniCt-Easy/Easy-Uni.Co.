-- Aggiornamento tabella SORTINGKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- accountsorting, accountvardetail, accountyear, admpay_expensesorted, admpay_incomesorted, autoexpensesorting, autoincomesorting,
-- banktransactionsorting, casualcontractsorting, clawbacksorting, divisionsorting, epexpsorting, estimatesorting, expensesorted, miursetup, 
-- finsorting, flowchartsorting, incomesorted, inventorytreesorting, invoicesorting, itinerationsorting, locationsorting, managersorting,
-- mandatesorting, parasubcontractsorting, pettycashoperationsorted, profservicesorting, registrysorting, servicesorting, sortedmovementtotal,
-- sorting, sortingapplicability, sortingexpensefilter, sortingincomefilter, sortinglevel, sortingprev, sortingprevexpensevar,
-- sortingprevincomevar, sortingtotal, taxsorting, taxsortingsetup, upbsorting, wageadditionsorting, wageimportsetup, sortingtranslation, config

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM miursetup
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = miursetup.sortcode)

DELETE FROM accountsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = accountsorting.idsorkind)

DELETE FROM accountvardetail
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = accountvardetail.idsorkind)

DELETE FROM accountyear
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = accountyear.idsorkind)

DELETE FROM admpay_expensesorted
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = admpay_expensesorted.idsorkind)

DELETE FROM admpay_incomesorted
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = admpay_incomesorted.idsorkind)
GO

DELETE FROM autoexpensesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = autoexpensesorting.idsorkind)

DELETE FROM autoexpensesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = autoexpensesorting.idsorkindreg)
AND idsorkindreg IS NOT NULL

DELETE FROM autoincomesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = autoincomesorting.idsorkind)

DELETE FROM autoincomesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = autoincomesorting.idsorkindreg)
AND idsorkindreg IS NOT NULL
GO

DELETE FROM banktransactionsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = banktransactionsorting.idsorkind)

DELETE FROM casualcontractsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = casualcontractsorting.idsorkind)

DELETE FROM clawbacksorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = clawbacksorting.idsorkind)

DELETE FROM divisionsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = divisionsorting.idsorkind)

DELETE FROM epexpsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = epexpsorting.idsorkind)

DELETE FROM estimatesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = estimatesorting.idsorkind)

DELETE FROM expensesorted
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = expensesorted.idsorkind)
GO

DELETE FROM finsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = finsorting.idsorkind)

DELETE FROM flowchartsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = flowchartsorting.idsorkind)

DELETE FROM inventorytreesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = inventorytreesorting.idsorkind)

DELETE FROM invoicesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = invoicesorting.idsorkind)
GO

DELETE FROM incomesorted
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = incomesorted.idsorkind)

DELETE FROM itinerationsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = itinerationsorting.idsorkind)

DELETE FROM locationsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = locationsorting.idsorkind)

DELETE FROM managersorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = managersorting.idsorkind)
GO

DELETE FROM mandatesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = mandatesorting.idsorkind)

DELETE FROM parasubcontractsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = parasubcontractsorting.idsorkind)

DELETE FROM pettycashoperationsorted
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = pettycashoperationsorted.idsorkind)

DELETE FROM profservicesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = profservicesorting.idsorkind)
GO

DELETE FROM registrysorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = registrysorting.idsorkind)

DELETE FROM servicesorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = servicesorting.idsorkind)

DELETE FROM sortedmovementtotal
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortedmovementtotal.idsorkind)

DELETE FROM sortingapplicability
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingapplicability.idsorkind)
GO

INSERT INTO sortingkind (idsorkind, description, active, flagcheckavailability, flagforced, flagmultiple, ct, cu, lt, lu)
SELECT DISTINCT idsorkind, idsorkind, 'N', 'N', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM sorting e
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = e.idsorkind)

DELETE FROM sortinglevel
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortinglevel.idsorkind)

DELETE FROM sortingexpensefilter
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingexpensefilter.idsorkind)

DELETE FROM sortingexpensefilter
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingexpensefilter.idsorkindreg)
AND idsorkindreg IS NOT NULL
GO

DELETE FROM sortingprev
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingprev.idsorkind)

DELETE FROM sortingincomefilter
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingincomefilter.idsorkind)

DELETE FROM sortingincomefilter
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingincomefilter.idsorkindreg)
AND idsorkindreg IS NOT NULL
GO

DELETE FROM sortingprevexpensevar
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingprevexpensevar.idsorkind)
AND idsorkind IS NOT NULL

DELETE FROM sortingprevincomevar
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingprevincomevar.idsorkind)
AND idsorkind IS NOT NULL

DELETE FROM sortingtotal
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingtotal.idsorkind)

DELETE FROM taxsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = taxsorting.idsorkind)

DELETE FROM taxsortingsetup
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = taxsortingsetup.idsorkind)
AND idsorkind IS NOT NULL
GO

DELETE FROM upbsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = upbsorting.idsorkind)

DELETE FROM wageadditionsorting
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = wageadditionsorting.idsorkind)

DELETE FROM sortingtranslation
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingtranslation.sortingkindchild)

DELETE FROM sortingtranslation
WHERE NOT EXISTS(SELECT * FROM sortingkind k WHERE k.idsorkind = sortingtranslation.sortingkindmaster)
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
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD idsorkindint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'codesorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD codesorkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN codesorkind varchar(20) NULL
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'miursetup' and C.name = 'sortcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [miursetup] ADD sortcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [miursetup] ALTER COLUMN sortcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountvardetail] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountvardetail] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountyear] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [accountyear] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_expensesorted] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_incomesorted] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorkindregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorkindregint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorkindregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorkindregint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [banktransactionsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontractsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [clawbacksorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [divisionsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [epexpsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [epexpsorting] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD paridsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN paridsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [finsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [flowchartsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD paridsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN paridsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [locationsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [managersorting] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontractsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservicesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrysorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [registrysorting] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [servicesorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortedmovementtotal] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingapplicability' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingapplicability] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingapplicability] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorkindregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorkindregint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorkindregint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorkindregint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglevel] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortinglevel] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprev] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprev] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevexpensevar] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprevexpensevar] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevincomevar] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingprevincomevar] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtotal] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtotal] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsorting] ALTER COLUMN idsorkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upbsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD idsorkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageadditionsorting] ALTER COLUMN idsorkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindchildint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD sortingkindchildint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindchildint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindmasterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD sortingkindmasterint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindmasterint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN idsortingkind1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN idsortingkind2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [config] ALTER COLUMN idsortingkind3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_clawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_clawbackint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_clawbackint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_finint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_finint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_finint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_registryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_registryint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_registryint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_serviceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_serviceint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_serviceint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_taxint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_taxint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_taxint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_upbint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_upbint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_upbint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild4int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild4int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild4int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild5int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild5int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild5int int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster1int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster1int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster2int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster2int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster3int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster3int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster4int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster4int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster4int int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster5int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster5int int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster5int int NULL
END
GO
