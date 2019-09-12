-- Aggiornamento tabella TAX e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- abatement, admpay_admintax, admpay_employtax, casualcontracttax, casualcontracttaxbracket, expensetax, 
-- itinerationtax, payrollabatement, payrolltax, profservicetax, servicetax, taxpay, taxpayexpense,
-- taxpaymentpartsetup, taxratestart, taxratebracket, taxratecitystart, taxratecitybracket,
-- taxrateregionstart, taxrateregionbracket, taxrateregioncitystart, taxrateregioncitybracket,
-- taxregionsetup, taxsetup, taxsorting, taxsortingsetup, wageadditiontax

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM abatement
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = abatement.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM admpay_admintax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = admpay_admintax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM admpay_employtax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = admpay_employtax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM casualcontracttax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = casualcontracttax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM casualcontracttaxbracket
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = casualcontracttaxbracket.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM expensetax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = expensetax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM itinerationtax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = itinerationtax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM payrolltax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = payrolltax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM profservicetax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = profservicetax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxpay
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxpay.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxpayexpense
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxpayexpense.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM wageadditiontax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = wageadditiontax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM wageadditiontax
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = wageadditiontax.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxratestart
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxratestart.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxratebracket
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxratebracket.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxratecitystart
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxratecitystart.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxratecitybracket
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxratecitybracket.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxrateregionstart
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxrateregionstart.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxrateregionbracket
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxrateregionbracket.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxrateregioncitystart
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxrateregioncitystart.taxcode)
GO

INSERT INTO tax (taxcode, description, ct, cu, lt, lu)
SELECT DISTINCT taxcode, taxcode, GETDATE(), 'SA', GETDATE(), '''SA'''
FROM taxrateregioncitybracket
WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxrateregioncitybracket.taxcode)
GO

DELETE FROM servicetax WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = servicetax.taxcode)
GO

DELETE FROM taxsorting WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxsorting.taxcode)
GO

DELETE FROM taxsortingsetup WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxsortingsetup.taxcode)
GO

DELETE FROM taxregionsetup WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxregionsetup.taxcode)
GO

DELETE FROM taxsetup WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxsetup.taxcode)
GO

DELETE FROM taxpaymentpartsetup WHERE NOT EXISTS(SELECT * FROM tax WHERE tax.taxcode = taxpaymentpartsetup.taxcode)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxcodeint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxref varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [tax] ALTER COLUMN taxref varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'maintaxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD maintaxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [tax] ALTER COLUMN maintaxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'abatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [abatement] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [abatement] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_admintax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_admintax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_admintax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_employtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_employtax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_employtax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontracttax] ALTER COLUMN taxcodeint int NULL
END
GO
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttaxbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontracttaxbracket] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensetax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationtax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itinerationtax] ALTER COLUMN taxcodeint int NULL
END
GO
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrollabatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payrollabatement] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payrollabatement] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrolltax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payrolltax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payrolltax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicetax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservicetax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [servicetax] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpay' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpay] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxpay] ALTER COLUMN taxcodeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxpayexpense] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpaymentpartsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxpaymentpartsetup] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratestart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratestart] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxratestart] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratebracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratebracket] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxratebracket] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitystart] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxratecitystart] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitybracket] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxratecitybracket] ALTER COLUMN taxcodeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionstart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionstart] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxrateregionstart] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionbracket] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxrateregionbracket] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitystart] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxrateregioncitystart] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxrateregioncitybracket] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxregionsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxregionsetup] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxregionsetup] ALTER COLUMN taxcodeint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsorting] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN taxcodeint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditiontax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditiontax] ADD taxcodeint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageadditiontax] ALTER COLUMN taxcodeint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE tax SET taxref = taxcode
END

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'maintaxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE tax
	SET maintaxcodeint = (SELECT taxcodeint FROM tax t1 WHERE t1.taxcode = tax.maintaxcode)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'abatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE abatement SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE abatement.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_admintax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_admintax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE admpay_admintax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_employtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_employtax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE admpay_employtax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontracttax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE casualcontracttax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttaxbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontracttaxbracket SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE casualcontracttaxbracket.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE expensetax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationtax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE itinerationtax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrollabatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payrollabatement SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE payrollabatement.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrolltax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payrolltax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE payrolltax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservicetax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE profservicetax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicetax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE servicetax.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpay' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpay SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxpay.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpayexpense SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxpayexpense.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpaymentpartsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpaymentpartsetup SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxpaymentpartsetup.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratestart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratestart SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxratestart.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratebracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratebracket SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxratebracket.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratecitystart SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxratecitystart.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratecitybracket SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxratecitybracket.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionstart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregionstart SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxrateregionstart.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregionbracket SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxrateregionbracket.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregioncitystart SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxrateregioncitystart.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregioncitybracket SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxrateregioncitybracket.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxregionsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxregionsetup SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxregionsetup.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxsetup.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsorting SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxsorting.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE taxsortingsetup.taxcode = tax.taxcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditiontax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageadditiontax SET taxcodeint = tax.taxcodeint
	FROM tax
	WHERE wageadditiontax.taxcode = tax.taxcode
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono tax, admpay_admintax, admpay_employtax, casualcontracttax, casualcontracttaxbracket,
-- expensetax, itinerationtax, profservicetax, servicetax, taxpay, taxpayexpense, taxpaymentpartsetup, taxratestart,
-- taxratebracket, taxratecitystart, taxratecitybracket, taxrateregionstart, taxrateregionbracket,
-- taxrateregioncitystart, taxrateregioncitybracket, taxregionsetup, taxsetup, taxsorting, wageadditiontax

IF exists(SELECT * FROM sysconstraints where id=object_id('tax') and constid=object_id('xpktax'))
BEGIN
	ALTER TABLE [tax] drop constraint xpktax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('tax') and constid=object_id('PK_tax'))
BEGIN
	ALTER TABLE [tax] drop constraint PK_tax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_admintax') and constid=object_id('xpkadmpay_admintax'))
BEGIN
	ALTER TABLE [admpay_admintax] drop constraint xpkadmpay_admintax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_admintax') and constid=object_id('PK_admpay_admintax'))
BEGIN
	ALTER TABLE [admpay_admintax] drop constraint PK_admpay_admintax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_employtax') and constid=object_id('xpkadmpay_employtax'))
BEGIN
	ALTER TABLE [admpay_employtax] drop constraint xpkadmpay_employtax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_employtax') and constid=object_id('PK_admpay_employtax'))
BEGIN
	ALTER TABLE [admpay_employtax] drop constraint PK_admpay_employtax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttax') and constid=object_id('xpkcasualcontracttax'))
BEGIN
	ALTER TABLE [casualcontracttax] drop constraint xpkcasualcontracttax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttax') and constid=object_id('PK_casualcontracttax'))
BEGIN
	ALTER TABLE [casualcontracttax] drop constraint PK_casualcontracttax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttaxbracket') and constid=object_id('xpkcasualcontracttaxbracket'))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] drop constraint xpkcasualcontracttaxbracket
END

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttaxbracket') and constid=object_id('PK_casualcontracttaxbracket'))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] drop constraint PK_casualcontracttaxbracket
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensetax') and constid=object_id('xpkexpensetax'))
BEGIN
	ALTER TABLE [expensetax] drop constraint xpkexpensetax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensetax') and constid=object_id('PK_expensetax'))
BEGIN
	ALTER TABLE [expensetax] drop constraint PK_expensetax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationtax') and constid=object_id('xpkitinerationtax'))
BEGIN
	ALTER TABLE [itinerationtax] drop constraint xpkitinerationtax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationtax') and constid=object_id('PK_itinerationtax'))
BEGIN
	ALTER TABLE [itinerationtax] drop constraint PK_itinerationtax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('profservicetax') and constid=object_id('xpkprofservicetax'))
BEGIN
	ALTER TABLE [profservicetax] drop constraint xpkprofservicetax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('profservicetax') and constid=object_id('PK_profservicetax'))
BEGIN
	ALTER TABLE [profservicetax] drop constraint PK_profservicetax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('servicetax') and constid=object_id('xpkservicetax'))
BEGIN
	ALTER TABLE [servicetax] drop constraint xpkservicetax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('servicetax') and constid=object_id('PK_servicetax'))
BEGIN
	ALTER TABLE [servicetax] drop constraint PK_servicetax
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpay') and constid=object_id('xpktaxpay'))
BEGIN
	ALTER TABLE [taxpay] drop constraint xpktaxpay
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpay') and constid=object_id('PK_taxpay'))
BEGIN
	ALTER TABLE [taxpay] drop constraint PK_taxpay
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('xpktaxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] drop constraint xpktaxpayexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('PK_taxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] drop constraint PK_taxpayexpense
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpaymentpartsetup') and constid=object_id('xpktaxpaymentpartsetup'))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] drop constraint xpktaxpaymentpartsetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpaymentpartsetup') and constid=object_id('PK_taxpaymentpartsetup'))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] drop constraint PK_taxpaymentpartsetup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratestart') and constid=object_id('xpktaxratestart'))
BEGIN
	ALTER TABLE [taxratestart] drop constraint xpktaxratestart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratestart') and constid=object_id('PK_taxratestart'))
BEGIN
	ALTER TABLE [taxratestart] drop constraint PK_taxratestart
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratebracket') and constid=object_id('xpktaxratebracket'))
BEGIN
	ALTER TABLE [taxratebracket] drop constraint xpktaxratebracket
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratebracket') and constid=object_id('PK_taxratebracket'))
BEGIN
	ALTER TABLE [taxratebracket] drop constraint PK_taxratebracket
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratecitystart') and constid=object_id('xpktaxratecitystart'))
BEGIN
	ALTER TABLE [taxratecitystart] drop constraint xpktaxratecitystart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratecitystart') and constid=object_id('PK_taxcitystart'))
BEGIN
	ALTER TABLE [taxratecitystart] drop constraint PK_taxcitystart
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratecitybracket') and constid=object_id('xpktaxratecitybracket'))
BEGIN
	ALTER TABLE [taxratecitybracket] drop constraint xpktaxratecitybracket
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxratecitybracket') and constid=object_id('PK_taxratecitybracket'))
BEGIN
	ALTER TABLE [taxratecitybracket] drop constraint PK_taxratecitybracket
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionstart') and constid=object_id('xpktaxrateregionstart'))
BEGIN
	ALTER TABLE [taxrateregionstart] drop constraint xpktaxrateregionstart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionstart') and constid=object_id('PK_taxregionstart'))
BEGIN
	ALTER TABLE [taxrateregionstart] drop constraint PK_taxregionstart
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionbracket') and constid=object_id('xpktaxrateregionbracket'))
BEGIN
	ALTER TABLE [taxrateregionbracket] drop constraint xpktaxrateregionbracket
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionbracket') and constid=object_id('PK_taxregionbracket'))
BEGIN
	ALTER TABLE [taxrateregionbracket] drop constraint PK_taxregionbracket
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitystart') and constid=object_id('xpktaxrateregioncitystart'))
BEGIN
	ALTER TABLE [taxrateregioncitystart] drop constraint xpktaxrateregioncitystart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitystart') and constid=object_id('PK_taxrateregioncitystart'))
BEGIN
	ALTER TABLE [taxrateregioncitystart] drop constraint PK_taxrateregioncitystart
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitybracket') and constid=object_id('xpktaxrateregioncitybracket'))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] drop constraint xpktaxrateregioncitybracket
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitybracket') and constid=object_id('PK_taxrateregioncitybracket'))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] drop constraint PK_taxrateregioncitybracket
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxregionsetup') and constid=object_id('xpktaxregionsetup'))
BEGIN
	ALTER TABLE [taxregionsetup] drop constraint xpktaxregionsetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxregionsetup') and constid=object_id('PK_taxregionsetup'))
BEGIN
	ALTER TABLE [taxregionsetup] drop constraint PK_taxregionsetup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsetup') and constid=object_id('xpktaxsetup'))
BEGIN
	ALTER TABLE [taxsetup] drop constraint xpktaxsetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsetup') and constid=object_id('PK_taxsetup'))
BEGIN
	ALTER TABLE [taxsetup] drop constraint PK_taxsetup
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('xpktaxsorting'))
BEGIN
	ALTER TABLE [taxsorting] drop constraint xpktaxsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('PK_taxsorting'))
BEGIN
	ALTER TABLE [taxsorting] drop constraint PK_taxsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('wageadditiontax') and constid=object_id('xpkwageadditiontax'))
BEGIN
	ALTER TABLE [wageadditiontax] drop constraint xpkwageadditiontax
END

IF exists(SELECT * FROM sysconstraints where id=object_id('wageadditiontax') and constid=object_id('PK_wageadditiontax'))
BEGIN
	ALTER TABLE [wageadditiontax] drop constraint PK_wageadditiontax
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono expensetax, itinerationtax, taxpay, taxpayexpense, taxpaymentpartsetup,
-- taxratestart, taxratebracket, taxsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensetax' and id=object_id('expensetax'))
	drop index expensetax.xi2expensetax

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationtax' and id=object_id('itinerationtax'))
	drop index itinerationtax.xi2itinerationtax

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpay' and id=object_id('taxpay'))
	drop index taxpay.xi1taxpay

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpayexpense' and id=object_id('taxpayexpense'))
	drop index taxpayexpense.xi1taxpayexpense

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpaymentpartsetup' and id=object_id('taxpaymentpartsetup'))
	drop index taxpaymentpartsetup.xi1taxpaymentpartsetup
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_taxratestart' and id=object_id('taxratestart'))
	drop index taxratestart.IX_taxratestart

IF EXISTS (SELECT * FROM sysindexes where name='IX_taxratebracket' and id=object_id('taxratebracket'))
	drop index taxratebracket.IX_taxratebracket

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxsetup' and id=object_id('taxsetup'))
	drop index taxsetup.xi1taxsetup
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'tax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='maintaxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN maintaxcode
	DELETE FROM columntypes WHERE tablename = 'tax' AND field = 'maintaxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'abatement'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [abatement] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'abatement' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_admintax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_admintax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'admpay_admintax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_employtax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_employtax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'admpay_employtax' AND field = 'taxcode'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontracttax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontracttax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'casualcontracttax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontracttaxbracket'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontracttaxbracket] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'casualcontracttaxbracket' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'expensetax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationtax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationtax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'itinerationtax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payrollabatement'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payrollabatement] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'payrollabatement' AND field = 'taxcode'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payrolltax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payrolltax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'payrolltax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicetax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicetax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'profservicetax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicetax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicetax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'servicetax' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpay'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpay] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxpay' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpayexpense'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpayexpense] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxpayexpense' AND field = 'taxcode'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpaymentpartsetup'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpaymentpartsetup] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxpaymentpartsetup' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratestart'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratestart] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxratestart' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratebracket'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratebracket] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxratebracket' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratecitystart'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratecitystart] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxratecitystart' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratecitybracket'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratecitybracket] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxratecitybracket' AND field = 'taxcode'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregionstart'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregionstart] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxrateregionstart' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregionbracket'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregionbracket] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxrateregionbracket' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregioncitystart'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregioncitystart] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxrateregioncitystart' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregioncitybracket'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregioncitybracket] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxrateregioncitybracket' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxregionsetup'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxregionsetup] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxregionsetup' AND field = 'taxcode'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxsetup' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxsorting' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'taxcode'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditiontax'
		and C.name ='taxcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditiontax] DROP COLUMN taxcode
	DELETE FROM columntypes WHERE tablename = 'wageadditiontax' AND field = 'taxcode'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'maintaxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ADD maintaxcode int NULL 
END
ELSE
	ALTER TABLE [tax] ALTER COLUMN maintaxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'abatement' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [abatement] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [abatement] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_admintax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_admintax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [admpay_admintax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_employtax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_employtax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [admpay_employtax] ALTER COLUMN taxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [casualcontracttax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttaxbracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [casualcontracttaxbracket] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [expensetax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationtax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [itinerationtax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrollabatement' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payrollabatement] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [payrollabatement] ALTER COLUMN taxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrolltax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payrolltax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [payrolltax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicetax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [profservicetax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [servicetax] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpay' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpay] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxpay] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxpayexpense] ALTER COLUMN taxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpaymentpartsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxpaymentpartsetup] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratestart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratestart] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxratestart] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratebracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratebracket] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxratebracket] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitystart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitystart] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxratecitystart] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitybracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitybracket] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxratecitybracket] ALTER COLUMN taxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionstart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionstart] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxrateregionstart] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionbracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionbracket] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxrateregionbracket] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitystart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitystart] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxrateregioncitystart] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitybracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxrateregioncitybracket] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxregionsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxregionsetup] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxregionsetup] ALTER COLUMN taxcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxsetup] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxsorting] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN taxcode int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditiontax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditiontax] ADD taxcode int NULL 
END
ELSE
	ALTER TABLE [wageadditiontax] ALTER COLUMN taxcode int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE tax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE tax SET maintaxcode = maintaxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'abatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE abatement SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_admintax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_admintax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_employtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_employtax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontracttax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttaxbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontracttaxbracket SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationtax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrollabatement' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payrollabatement SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payrolltax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payrolltax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservicetax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicetax SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpay' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpay SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpayexpense SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpaymentpartsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpaymentpartsetup SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratestart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratestart SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratebracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratebracket SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratecitystart SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxratecitybracket SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionstart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregionstart SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionbracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregionbracket SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitystart' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregioncitystart SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitybracket' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxrateregioncitybracket SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxregionsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxregionsetup SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsetup SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsorting SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET taxcode = taxcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditiontax' and C.name = 'taxcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageadditiontax SET taxcode = taxcodeint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_admintax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_admintax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_employtax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_employtax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontracttaxbracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] ALTER COLUMN taxcode int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationtax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicetax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpay' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpay] ALTER COLUMN taxcode int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpaymentpartsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratestart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratestart] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratebracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratebracket] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitystart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitystart] ALTER COLUMN taxcode int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxratecitybracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxratecitybracket] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionstart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionstart] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregionbracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregionbracket] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitystart' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitystart] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxrateregioncitybracket' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] ALTER COLUMN taxcode int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxregionsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxregionsetup] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsetup] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditiontax' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditiontax] ALTER COLUMN taxcode int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tax' and C.name = 'taxref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tax] ALTER COLUMN taxref varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'abatement' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [abatement] ALTER COLUMN taxcode int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'taxcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN taxcode int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('tax') and constid=object_id('xpktax'))
BEGIN
	ALTER TABLE [tax] ADD CONSTRAINT xpktax PRIMARY KEY (taxcode)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('tax') and constid=object_id('uktax'))
BEGIN
	ALTER TABLE [tax] ADD CONSTRAINT uktax UNIQUE (taxref)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_admintax') and constid=object_id('xpkadmpay_admintax'))
BEGIN
	ALTER TABLE [admpay_admintax] ADD CONSTRAINT xpkadmpay_admintax PRIMARY KEY (yadmpay, nadmpay, nexpense, taxcode, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_employtax') and constid=object_id('xpkadmpay_employtax'))
BEGIN
	ALTER TABLE [admpay_employtax] ADD CONSTRAINT xpkadmpay_employtax PRIMARY KEY (yadmpay, nadmpay, nexpense, taxcode, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttax') and constid=object_id('xpkcasualcontracttax'))
BEGIN
	ALTER TABLE [casualcontracttax] ADD CONSTRAINT xpkcasualcontracttax PRIMARY KEY (ycon, ncon, taxcode)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('casualcontracttaxbracket') and constid=object_id('xpkcasualcontracttaxbracket'))
BEGIN
	ALTER TABLE [casualcontracttaxbracket] ADD CONSTRAINT xpkcasualcontracttaxbracket PRIMARY KEY (ycon, ncon, taxcode, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensetax') and constid=object_id('xpkexpensetax'))
BEGIN
	ALTER TABLE [expensetax] ADD CONSTRAINT xpkexpensetax PRIMARY KEY (idexp, taxcode, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationtax') and constid=object_id('xpkitinerationtax'))
BEGIN
	ALTER TABLE [itinerationtax] ADD CONSTRAINT xpkitinerationtax PRIMARY KEY (yitineration, nitineration, taxcode)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('profservicetax') and constid=object_id('xpkprofservicetax'))
BEGIN
	ALTER TABLE [profservicetax] ADD CONSTRAINT xpkprofservicetax PRIMARY KEY (ycon, ncon, taxcode)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('servicetax') and constid=object_id('xpkservicetax'))
BEGIN
	ALTER TABLE [servicetax] ADD CONSTRAINT xpkservicetax PRIMARY KEY (idser, taxcode)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxpay') and constid=object_id('xpktaxpay'))
BEGIN
	ALTER TABLE [taxpay] ADD CONSTRAINT xpktaxpay PRIMARY KEY (taxcode, ytaxpay, ntaxpay)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('xpktaxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] ADD CONSTRAINT xpktaxpayexpense PRIMARY KEY (taxcode, ytaxpay, ntaxpay, idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxpaymentpartsetup') and constid=object_id('xpktaxpaymentpartsetup'))
BEGIN
	ALTER TABLE [taxpaymentpartsetup] ADD CONSTRAINT xpktaxpaymentpartsetup PRIMARY KEY (ayear, taxcode, idreg)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxratestart') and constid=object_id('xpktaxratestart'))
BEGIN
	ALTER TABLE [taxratestart] ADD CONSTRAINT xpktaxratestart PRIMARY KEY (taxcode, idtaxratestart)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxratebracket') and constid=object_id('xpktaxratebracket'))
BEGIN
	ALTER TABLE [taxratebracket] ADD CONSTRAINT xpktaxratebracket PRIMARY KEY (taxcode, idtaxratestart, nbracket)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxratecitystart') and constid=object_id('xpktaxratecitystart'))
BEGIN
	ALTER TABLE [taxratecitystart] ADD CONSTRAINT xpktaxratecitystart PRIMARY KEY (idcity, taxcode, idtaxratecitystart)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxratecitybracket') and constid=object_id('xpktaxratecitybracket'))
BEGIN
	ALTER TABLE [taxratecitybracket] ADD CONSTRAINT xpktaxratecitybracket PRIMARY KEY (idcity, taxcode, idtaxratecitystart, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionstart') and constid=object_id('xpktaxrateregionstart'))
BEGIN
	ALTER TABLE [taxrateregionstart] ADD CONSTRAINT xpktaxrateregionstart PRIMARY KEY (idregion, taxcode, idtaxrateregionstart)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxrateregionbracket') and constid=object_id('xpktaxrateregionbracket'))
BEGIN
	ALTER TABLE [taxrateregionbracket] ADD CONSTRAINT xpktaxrateregionbracket PRIMARY KEY (idregion, taxcode, idtaxrateregionstart, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitystart') and constid=object_id('xpktaxrateregioncitystart'))
BEGIN
	ALTER TABLE [taxrateregioncitystart] ADD CONSTRAINT xpktaxrateregioncitystart PRIMARY KEY (idcity, taxcode, idtaxrateregioncitystart)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxrateregioncitybracket') and constid=object_id('xpktaxrateregioncitybracket'))
BEGIN
	ALTER TABLE [taxrateregioncitybracket] ADD CONSTRAINT xpktaxrateregioncitybracket PRIMARY KEY (idcity, taxcode, idtaxrateregioncitystart, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxregionsetup') and constid=object_id('xpktaxregionsetup'))
BEGIN
	ALTER TABLE [taxregionsetup] ADD CONSTRAINT xpktaxregionsetup PRIMARY KEY (ayear, taxcode, autoid)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxsetup') and constid=object_id('xpktaxsetup'))
BEGIN
	ALTER TABLE [taxsetup] ADD CONSTRAINT xpktaxsetup PRIMARY KEY (taxcode, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('xpktaxsorting'))
BEGIN
	ALTER TABLE [taxsorting] ADD CONSTRAINT xpktaxsorting PRIMARY KEY (taxcode, idsorkind, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('wageadditiontax') and constid=object_id('xpkwageadditiontax'))
BEGIN
	ALTER TABLE [wageadditiontax] ADD CONSTRAINT xpkwageadditiontax PRIMARY KEY (ycon, ncon, taxcode)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2expensetax' and id=object_id('expensetax'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensetax ON expensetax (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensetax
	ON expensetax (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationtax' and id=object_id('itinerationtax'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationtax ON itinerationtax (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationtax
	ON itinerationtax (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpay' and id=object_id('taxpay'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpay ON taxpay (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpay
	ON taxpay (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpayexpense' and id=object_id('taxpayexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpayexpense ON taxpayexpense (taxcode, ytaxpay, ntaxpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpayexpense
	ON taxpayexpense (taxcode, ytaxpay, ntaxpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpayexpense' and id=object_id('taxpayexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpayexpense ON taxpayexpense (taxcode, ytaxpay, ntaxpay)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpayexpense
	ON taxpayexpense (taxcode, ytaxpay, ntaxpay)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpaymentpartsetup' and id=object_id('taxpaymentpartsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpaymentpartsetup ON taxpaymentpartsetup (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxpaymentpartsetup
	ON taxpaymentpartsetup (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x1taxratestart' and id=object_id('taxratestart'))
BEGIN
	CREATE NONCLUSTERED INDEX x1taxratestart ON taxratestart (taxcode, start)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX x1taxratestart
	ON taxratestart (taxcode, start)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x1taxratebracket' and id=object_id('taxratebracket'))
BEGIN
	CREATE NONCLUSTERED INDEX x1taxratebracket ON taxratebracket (taxcode, idtaxratestart, minamount)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX x1taxratebracket
	ON taxratebracket (taxcode, idtaxratestart, minamount)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxsetup' and id=object_id('taxsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxsetup ON taxsetup (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1taxsetup
	ON taxsetup (taxcode)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'abatement' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-02-08 11:00:07.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'abatement' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('abatement','taxcode','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-02-08 11:00:07.530'},'''NINO''','NINO',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_admintax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:16.813'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'admpay_admintax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_admintax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:16.813'},'''NINO''','NINO',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_employtax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:01.657'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'admpay_employtax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_employtax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:01.657'},'''NINO''','NINO',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontracttax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:00.483'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'casualcontracttax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('casualcontracttax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:00.483'},'''NINO''','SA',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontracttaxbracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.203'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'casualcontracttaxbracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('casualcontracttaxbracket','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.203'},'''NINO''','SA',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensetax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.767'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'expensetax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensetax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.767'},'''NINO''','SA',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationtax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:14.967'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 11:00:07.530'} WHERE tablename = 'itinerationtax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('itinerationtax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:14.967'},'''NINO''','SA',{ts '2006-02-08 11:00:07.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payrollabatement' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2006-02-08 10:59:57.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:57.530'} WHERE tablename = 'payrollabatement' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('payrollabatement','taxcode','N','int','4','','','System.Int32','int','S','',null,'N',{ts '2006-02-08 10:59:57.530'},'''NINO''','NINO',{ts '2006-02-08 10:59:57.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payrolltax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2006-02-08 10:59:58.890'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'payrolltax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('payrolltax','taxcode','N','int','4','','','System.Int32','int','S','',null,'N',{ts '2006-02-08 10:59:58.890'},'''NINO''','NINO',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservicetax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.267'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'profservicetax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('profservicetax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.267'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ratecitybracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-19 11:44:14.877'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-07-19 11:44:14.877'} WHERE tablename = 'ratecitybracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('ratecitybracket','taxcode','N','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-19 11:44:14.877'},'''SARA''','SARA',{ts '2007-07-19 11:44:14.877'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'servicetax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:55.657'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'servicetax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('servicetax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:55.657'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'tax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-04 12:14:35.327'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'tax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('tax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-04 12:14:35.327'},'''SARA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'tax' AND field = 'maintaxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-04 12:14:35.327'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'tax' AND field = 'maintaxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('tax','maintaxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-04 12:14:35.327'},'''SARA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'tax' AND field = 'taxref')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = '',col_scale = '',systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-04 12:14:35.327'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'tax' AND field = 'taxref'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('tax','taxref','N','varchar','20','','','System.String','varchar(20)','N','','','S',{ts '2007-07-04 12:14:35.327'},'''SARA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxpay' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.187'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxpay' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxpay','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.187'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxpayexpense' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:15.140'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxpayexpense' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxpayexpense','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:15.140'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxpaymentpartsetup' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.670'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxpaymentpartsetup' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxpaymentpartsetup','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.670'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxratebracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:36.047'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxratebracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxratebracket','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:36.047'},'''SA''','NINO',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxratecitybracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:33.030'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxratecitybracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxratecitybracket','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:33.030'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxratecitystart' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:30.813'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxratecitystart' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxratecitystart','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:30.813'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxrateregionbracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:32.967'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxrateregionbracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxrateregionbracket','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:32.967'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxrateregioncitybracket' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:36.170'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxrateregioncitybracket' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxrateregioncitybracket','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:36.170'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxrateregioncitystart' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:30.250'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxrateregioncitystart' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxrateregioncitystart','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:30.250'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxrateregionstart' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:30.187'},lastmoduser = '''SA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxrateregionstart' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxrateregionstart','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:30.187'},'''SA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxratestart' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:29.937'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxratestart' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxratestart','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:29.937'},'''SA''','NINO',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxregionsetup' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:12.827'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxregionsetup' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxregionsetup','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:12.827'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsetup' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:00.063'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxsetup' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsetup','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:00.063'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsorting' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-01-17 11:15:11.377'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxsorting' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsorting','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-01-17 11:15:11.377'},'''SARA''','SA',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-09 10:48:45.860'},lastmoduser = '''SARA''',createuser = 'PINO',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'taxsortingsetup' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsortingsetup','taxcode','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-09 10:48:45.860'},'''SARA''','PINO',{ts '2006-02-08 10:59:58.890'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageadditiontax' AND field = 'taxcode')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:07.110'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:58.890'} WHERE tablename = 'wageadditiontax' AND field = 'taxcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('wageadditiontax','taxcode','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:07.110'},'''NINO''','SA',{ts '2006-02-08 10:59:58.890'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'tax'
		and C.name ='maintaxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [tax] DROP COLUMN maintaxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'abatement'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [abatement] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_admintax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_admintax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_employtax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_employtax] DROP COLUMN taxcodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontracttax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontracttax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontracttaxbracket'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontracttaxbracket] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationtax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationtax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payrollabatement'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payrollabatement] DROP COLUMN taxcodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payrolltax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payrolltax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicetax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicetax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicetax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicetax] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpay'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpay] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpayexpense'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpayexpense] DROP COLUMN taxcodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpaymentpartsetup'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpaymentpartsetup] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratestart'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratestart] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratebracket'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratebracket] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratecitystart'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratecitystart] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxratecitybracket'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxratecitybracket] DROP COLUMN taxcodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregionstart'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregionstart] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregionbracket'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregionbracket] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregioncitystart'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregioncitystart] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxrateregioncitybracket'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxrateregioncitybracket] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxregionsetup'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxregionsetup] DROP COLUMN taxcodeint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsetup'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsetup] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN taxcodeint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditiontax'
		and C.name ='taxcodeint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditiontax] DROP COLUMN taxcodeint
END
GO
