-- Aggiornamento tabella INVOICEKIND e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- expenseinvoice, expensevar, incomeinvoice, incomevar, invoice, invoicedeferred, invoicedetail, invoicekindregisterkind, invoicekindyear,
-- invoicesorting, ivaregister, pettycashoperationinvoice, profservice, unifiedivaregister

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM expenseinvoice e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'S', GETDATE(), 'SA', GETDATE(), 'SA'
FROM expensevar e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
AND idinvkind IS NOT NULL
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'V', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM incomeinvoice e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'V', 'N', 'S', GETDATE(), 'SA', GETDATE(), 'SA'
FROM incomevar e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
AND idinvkind IS NOT NULL
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoice e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicedeferred e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicedetail e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicekindregisterkind e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicekindyear e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM invoicesorting e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM ivaregister e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM pettycashoperationinvoice e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM profservice e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
AND e.idinvkind IS NOT NULL
GO

INSERT INTO invoicekind (idinvkind, description, flagbuysell, flagmixed, flagvariation, ct, cu, lt, lu)
SELECT DISTINCT idinvkind, idinvkind, 'A', 'N', 'N', GETDATE(), 'SA', GETDATE(), 'SA'
FROM unifiedivaregister e
WHERE NOT EXISTS(SELECT * FROM invoicekind k WHERE k.idinvkind = e.idinvkind)
AND e.idinvkind IS NOT NULL
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensevar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomevar]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ADD idinvkindint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'codeinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ADD codeinvkind varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicekind] ALTER COLUMN codeinvkind varchar(20) NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseinvoice] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeinvoice] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomevar] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoice] ALTER COLUMN idinvkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedeferred' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedeferred] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedeferred] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindyear' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindyear] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicekindyear] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idinvkindint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [ivaregister] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idinvkindint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'unifiedivaregister' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [unifiedivaregister] ADD idinvkindint int NULL
END
ELSE
BEGIN
	ALTER TABLE [unifiedivaregister] ALTER COLUMN idinvkindint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'codeinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekind SET codeinvkind = idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseinvoice SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = expenseinvoice.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = expensevar.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeinvoice SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = incomeinvoice.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomevar SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = incomevar.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoice.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedeferred' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedeferred SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoicedeferred.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoicedetail.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindregisterkind SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoicekindregisterkind.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindyear' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindyear SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoicekindyear.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesorting SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = invoicesorting.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregister SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = ivaregister.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationinvoice SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = pettycashoperationinvoice.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = profservice.idinvkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'unifiedivaregister' and C.name = 'idinvkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE unifiedivaregister SET idinvkindint = invoicekind.idinvkindint
	FROM invoicekind
	WHERE invoicekind.idinvkind = unifiedivaregister.idinvkind
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono foreigncountry
IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekind') and constid=object_id('xpkinvoicekind'))
BEGIN
	ALTER TABLE [invoicekind] drop constraint xpkinvoicekind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekind') and constid=object_id('PK_invoicekind'))
BEGIN
	ALTER TABLE [invoicekind] drop constraint PK_invoicekind
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseinvoice') and constid=object_id('xpkexpenseinvoice'))
BEGIN
	ALTER TABLE [expenseinvoice] drop constraint xpkexpenseinvoice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseinvoice') and constid=object_id('PK_expenseinvoice'))
BEGIN
	ALTER TABLE [expenseinvoice] drop constraint PK_expenseinvoice
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeinvoice') and constid=object_id('xpkincomeinvoice'))
BEGIN
	ALTER TABLE [incomeinvoice] drop constraint xpkincomeinvoice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeinvoice') and constid=object_id('PK_incomeinvoice'))
BEGIN
	ALTER TABLE [incomeinvoice] drop constraint PK_incomeinvoice
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoice') and constid=object_id('xpkinvoice'))
BEGIN
	ALTER TABLE [invoice] drop constraint xpkinvoice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoice') and constid=object_id('PK_invoice'))
BEGIN
	ALTER TABLE [invoice] drop constraint PK_invoice
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicedeferred') and constid=object_id('xpkinvoicedeferred'))
BEGIN
	ALTER TABLE [invoicedeferred] drop constraint xpkinvoicedeferred
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicedeferred') and constid=object_id('PK_invoicedeferred'))
BEGIN
	ALTER TABLE [invoicedeferred] drop constraint PK_invoicedeferred
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicedetail') and constid=object_id('xpkinvoicedetail'))
BEGIN
	ALTER TABLE [invoicedetail] drop constraint xpkinvoicedetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicedetail') and constid=object_id('PK_invoicedetail'))
BEGIN
	ALTER TABLE [invoicedetail] drop constraint PK_invoicedetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('xpkinvoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] drop constraint xpkinvoicekindregisterkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('PK_invoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] drop constraint PK_invoicekindregisterkind
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindyear') and constid=object_id('xpkinvoicekindyear'))
BEGIN
	ALTER TABLE [invoicekindyear] drop constraint xpkinvoicekindyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicekindyear') and constid=object_id('PK_invoicekindyear'))
BEGIN
	ALTER TABLE [invoicekindyear] drop constraint PK_invoicekindyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('xpkinvoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] drop constraint xpkinvoicesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('PK_invoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] drop constraint PK_invoicesorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationinvoice') and constid=object_id('xpkpettycashoperationinvoice'))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] drop constraint xpkpettycashoperationinvoice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationinvoice') and constid=object_id('PK_pettycashoperationinvoice'))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] drop constraint PK_pettycashoperationinvoice
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicekind, expenseinvoice, incomeinvoice, invoice, invoicedetail, ivaregister, 
IF EXISTS (SELECT * FROM sysindexes where name='xi1invoicekind' and id=object_id('invoicekind'))
	drop index invoicekind.xi1invoicekind
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseinvoice' and id=object_id('expenseinvoice'))
	drop index expenseinvoice.xi1expenseinvoice
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeinvoice' and id=object_id('incomeinvoice'))
	drop index incomeinvoice.xi1incomeinvoice
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoice' and id=object_id('invoice'))
	drop index invoice.xi1invoice
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoicedetail' and id=object_id('invoicedetail'))
	drop index invoicedetail.xi1invoicedetail
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivaregister' and id=object_id('ivaregister'))
	drop index ivaregister.xi2ivaregister
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekind'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekind] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicekind' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'expenseinvoice' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'expensevar' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'incomeinvoice' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'incomevar' AND field = 'idinvkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoice' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedeferred'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedeferred] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicedeferred' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindregisterkind'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindregisterkind] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicekindregisterkind' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindyear'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindyear] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicekindyear' AND field = 'idinvkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'invoicesorting' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregister'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregister] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'ivaregister' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationinvoice'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationinvoice] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationinvoice' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idinvkind'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'unifiedivaregister'
		and C.name ='idinvkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [unifiedivaregister] DROP COLUMN idinvkind
	DELETE FROM columntypes WHERE tablename = 'unifiedivaregister' AND field = 'idinvkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicekind] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [expenseinvoice] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [expensevar] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [incomeinvoice] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [incomevar] ALTER COLUMN idinvkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoice] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedeferred' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedeferred] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicedeferred] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindyear' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindyear] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicekindyear] ALTER COLUMN idinvkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [invoicesorting] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [ivaregister] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idinvkind int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'unifiedivaregister' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [unifiedivaregister] ADD idinvkind int NULL 
END
ELSE
	ALTER TABLE [unifiedivaregister] ALTER COLUMN idinvkind int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekind SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseinvoice SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeinvoice SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomevar SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoice SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedeferred' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedeferred SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindregisterkind SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindyear' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicekindyear SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesorting SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivaregister SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationinvoice SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idinvkind = idinvkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'unifiedivaregister' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE unifiedivaregister SET idinvkind = idinvkindint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoice] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedeferred' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedeferred] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindregisterkind' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekindyear' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekindyear] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idinvkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idinvkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicekind' and C.name = 'codeinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicekind] ALTER COLUMN codeinvkind varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivaregister' and C.name = 'idinvkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivaregister] ALTER COLUMN idinvkind int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicekind') and constid=object_id('xpkinvoicekind'))
BEGIN
	ALTER TABLE [invoicekind] ADD CONSTRAINT xpkinvoicekind PRIMARY KEY (idinvkind)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicekind') and constid=object_id('ukinvoicekind'))
BEGIN
	ALTER TABLE [invoicekind] ADD CONSTRAINT ukinvoicekind UNIQUE (codeinvkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseinvoice') and constid=object_id('xpkexpenseinvoice'))
BEGIN
	ALTER TABLE [expenseinvoice] ADD CONSTRAINT xpkexpenseinvoice PRIMARY KEY (idexp, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomeinvoice') and constid=object_id('xpkincomeinvoice'))
BEGIN
	ALTER TABLE [incomeinvoice] ADD CONSTRAINT xpkincomeinvoice PRIMARY KEY (idinc, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoice') and constid=object_id('xpkinvoice'))
BEGIN
	ALTER TABLE [invoice] ADD CONSTRAINT xpkinvoice PRIMARY KEY (idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicedeferred') and constid=object_id('xpkinvoicedeferred'))
BEGIN
	ALTER TABLE [invoicedeferred] ADD CONSTRAINT xpkinvoicedeferred PRIMARY KEY (yivapay, nivapay, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicedetail') and constid=object_id('xpkinvoicedetail'))
BEGIN
	ALTER TABLE [invoicedetail] ADD CONSTRAINT xpkinvoicedetail PRIMARY KEY (idinvkind, yinv, ninv, rownum)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicekindregisterkind') and constid=object_id('xpkinvoicekindregisterkind'))
BEGIN
	ALTER TABLE [invoicekindregisterkind] ADD CONSTRAINT xpkinvoicekindregisterkind PRIMARY KEY (idinvkind, idivaregisterkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicekindyear') and constid=object_id('xpkinvoicekindyear'))
BEGIN
	ALTER TABLE [invoicekindyear] ADD CONSTRAINT xpkinvoicekindyear PRIMARY KEY (ayear, idinvkind)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('xpkinvoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] ADD CONSTRAINT xpkinvoicesorting PRIMARY KEY (idsorkind, idsor, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationinvoice') and constid=object_id('xpkpettycashoperationinvoice'))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD CONSTRAINT xpkpettycashoperationinvoice PRIMARY KEY (idpettycash, yoperation, noperation, idinvkind, yinv, ninv)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('unifiedivaregister') and constid=object_id('xpkunifiedivaregister'))
BEGIN
	ALTER TABLE [unifiedivaregister] ADD CONSTRAINT xpkunifiedivaregister PRIMARY KEY (iddbdepartment, idinvkind, yinv, ninv)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2invoicekind' and id=object_id('invoicekind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2invoicekind ON invoicekind (codeinvkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2invoicekind
	ON invoicekind (codeinvkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseinvoice' and id=object_id('expenseinvoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseinvoice ON expenseinvoice (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseinvoice
	ON expenseinvoice (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeinvoice' and id=object_id('incomeinvoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomeinvoice ON incomeinvoice (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomeinvoice
	ON incomeinvoice (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoice' and id=object_id('invoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1invoice ON invoice (idinvkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1invoice
	ON invoice (idinvkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoicedetail' and id=object_id('invoicedetail'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1invoicedetail ON invoicedetail (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1invoicedetail
	ON invoicedetail (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivaregister' and id=object_id('ivaregister'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivaregister ON ivaregister (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivaregister
	ON ivaregister (idinvkind, yinv, ninv)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseinvoice' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:59.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:59.000'} WHERE tablename = 'expenseinvoice' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenseinvoice','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:59.000'},'''NINO''','NINO',{ts '2007-11-19 15:52:59.000'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensevar' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 15:53:02.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:02.233'} WHERE tablename = 'expensevar' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensevar','idinvkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 15:53:02.233'},'''NINO''','NINO',{ts '2007-11-19 15:53:02.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeinvoice' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:53:07.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:07.280'} WHERE tablename = 'incomeinvoice' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomeinvoice','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:53:07.280'},'''NINO''','NINO',{ts '2007-11-19 15:53:07.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomevar' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 15:53:01.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:01.530'} WHERE tablename = 'incomevar' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomevar','idinvkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 15:53:01.530'},'''NINO''','NINO',{ts '2007-11-19 15:53:01.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoice' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:53:10.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:10.953'} WHERE tablename = 'invoice' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoice','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:53:10.953'},'''NINO''','NINO',{ts '2007-11-19 15:53:10.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedeferred' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:53:11.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:11.170'} WHERE tablename = 'invoicedeferred' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedeferred','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:53:11.170'},'''NINO''','NINO',{ts '2007-11-19 15:53:11.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.467'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.467'} WHERE tablename = 'invoicedetail' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedetail','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:56.467'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.467'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekind' AND field = 'codeinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.030'} WHERE tablename = 'invoicekind' AND field = 'codeinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekind','codeinvkind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-19 15:52:56.030'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekind' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.030'} WHERE tablename = 'invoicekind' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekind','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:56.030'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekindregisterkind' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:53:11.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:11.313'} WHERE tablename = 'invoicekindregisterkind' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekindregisterkind','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:53:11.313'},'''NINO''','NINO',{ts '2007-11-19 15:53:11.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicekindyear' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.233'} WHERE tablename = 'invoicekindyear' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicekindyear','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:56.233'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicesorting' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:56.827'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:56.827'} WHERE tablename = 'invoicesorting' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicesorting','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:56.827'},'''NINO''','NINO',{ts '2007-11-19 15:52:56.827'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivaregister' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:52:59.627'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:59.627'} WHERE tablename = 'ivaregister' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('ivaregister','idinvkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:52:59.627'},'''NINO''','NINO',{ts '2007-11-19 15:52:59.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationinvoice' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-19 15:53:08.610'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:08.610'} WHERE tablename = 'pettycashoperationinvoice' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperationinvoice','idinvkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-19 15:53:08.610'},'''NINO''','NINO',{ts '2007-11-19 15:53:08.610'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 15:52:55.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:52:55.920'} WHERE tablename = 'profservice' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservice','idinvkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 15:52:55.920'},'''NINO''','NINO',{ts '2007-11-19 15:52:55.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'unifiedivaregister' AND field = 'idinvkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-19 15:53:08.327'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-19 15:53:08.327'} WHERE tablename = 'unifiedivaregister' AND field = 'idinvkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('unifiedivaregister','idinvkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-19 15:53:08.327'},'''NINO''','NINO',{ts '2007-11-19 15:53:08.327'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekind'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekind] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN idinvkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoice'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoice] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedeferred'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedeferred] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindregisterkind'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindregisterkind] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicekindyear'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicekindyear] DROP COLUMN idinvkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivaregister'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivaregister] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationinvoice'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationinvoice] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idinvkindint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'unifiedivaregister'
		and C.name ='idinvkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [unifiedivaregister] DROP COLUMN idinvkindint
END
GO
