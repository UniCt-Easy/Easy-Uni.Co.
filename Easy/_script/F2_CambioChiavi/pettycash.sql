
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella PETTYCASH e tabelle dipendenti
-- Passo 0. Inserimento delle righe in PETTYCASH ove non esista una riga nella tabella ma ci siano righe nelle tab dipendenti
INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashsetup
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = pettycashsetup.idpettycash)

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashoperation
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = pettycashoperation.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashoperationcasualcontract PCC
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = PCC.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashoperationinvoice PCI
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = PCI.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashoperationitineration PCIT
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = PCIT.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashoperationprofservice PCPS
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = PCPS.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashincome
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = pettycashincome.idpettycash)
GO

INSERT INTO pettycash
(
	idpettycash,
	description,
	flagopening,
	ct, cu, lt, lu
)
SELECT DISTINCT idpettycash, idpettycash, 'S', GETDATE(), 'SA', GETDATE(), '''SA'''
FROM pettycashexpense
WHERE NOT EXISTS(SELECT idpettycash FROM pettycash WHERE pettycash.idpettycash = pettycashexpense.idpettycash)
GO

DELETE FROM pettycashoperationsorted WHERE NOT EXISTS(SELECT * FROM pettycash WHERE pettycash.idpettycash = pettycashoperationsorted.idpettycash)
GO

-- Le tabelle dipendenti sono:
-- pettycashexpense, pettycashincome, pettycashoperation, pettycashoperationcasualcontract, pettycashoperationinvoice, pettycashoperationitineration,
-- pettycashoperationprofservice, pettycashoperationsorted, pettycashsetup

-- Passo 0bis: Rimozione dei Trigger (non ci sono trigger)

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycash] ADD idpettycashint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'pettycode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycash] ADD pettycode varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycash] ALTER COLUMN pettycode varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashexpense] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashincome] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationcasualcontract' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] ALTER COLUMN idpettycashint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationitineration] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationprofservice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationprofservice] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idpettycashint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idpettycashint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashsetup] ALTER COLUMN idpettycashint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'pettycode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycash SET pettycode = idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashexpense SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashexpense.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashincome SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashincome.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperation.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationcasualcontract' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationcasualcontract SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperationcasualcontract.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationinvoice SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperationinvoice.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationitineration SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperationitineration.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationprofservice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationprofservice SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperationprofservice.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationsorted SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashoperationsorted.idpettycash = pettycash.idpettycash
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashsetup SET idpettycashint = pettycash.idpettycashint
	FROM pettycash
	WHERE pettycashsetup.idpettycash = pettycash.idpettycash
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono pettycash, admpay_clawback, clawbacksetup, clawbacksorting, expenseclawback
IF exists(SELECT * FROM sysconstraints where id=object_id('pettycash') and constid=object_id('xpkpettycash'))
BEGIN
	ALTER TABLE [pettycash] drop constraint xpkpettycash
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycash') and constid=object_id('PK_pettycash'))
BEGIN
	ALTER TABLE [pettycash] drop constraint PK_pettycash
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashexpense') and constid=object_id('xpkpettycashexpense'))
BEGIN
	ALTER TABLE [pettycashexpense] drop constraint xpkpettycashexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashexpense') and constid=object_id('PK_pettycashexpense'))
BEGIN
	ALTER TABLE [pettycashexpense] drop constraint PK_pettycashexpense
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashincome') and constid=object_id('xpkpettycashincome'))
BEGIN
	ALTER TABLE [pettycashincome] drop constraint xpkpettycashincome
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashincome') and constid=object_id('PK_pettycashincome'))
BEGIN
	ALTER TABLE [pettycashincome] drop constraint PK_pettycashincome
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperation') and constid=object_id('xpkpettycashoperation'))
BEGIN
	ALTER TABLE [pettycashoperation] drop constraint xpkpettycashoperation
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperation') and constid=object_id('PK_pettycashoperation'))
BEGIN
	ALTER TABLE [pettycashoperation] drop constraint PK_pettycashoperation
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationcasualcontract') and constid=object_id('xpkpettycashoperationcasualcontract'))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] drop constraint xpkpettycashoperationcasualcontract
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationcasualcontract') and constid=object_id('PK_pettycashoperationcasualcontract'))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] drop constraint PK_pettycashoperationcasualcontract
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

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('xpkpettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] drop constraint xpkpettycashoperationitineration
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('PK_pettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] drop constraint PK_pettycashoperationitineration
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationprofservice') and constid=object_id('xpkpettycashoperationprofservice'))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] drop constraint xpkpettycashoperationprofservice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationprofservice') and constid=object_id('PK_pettycashoperationprofservice'))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] drop constraint PK_pettycashoperationprofservice
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationsorted') and constid=object_id('xpkpettycashoperationsorted'))
BEGIN
	ALTER TABLE [pettycashoperationsorted] drop constraint xpkpettycashoperationsorted
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationsorted') and constid=object_id('PK_pettycashoperationsorted'))
BEGIN
	ALTER TABLE [pettycashoperationsorted] drop constraint PK_pettycashoperationsorted
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashsetup') and constid=object_id('xpkpettycashsetup'))
BEGIN
	ALTER TABLE [pettycashsetup] drop constraint xpkpettycashsetup
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashsetup') and constid=object_id('PK_pettycashsetup'))
BEGIN
	ALTER TABLE [pettycashsetup] drop constraint PK_pettycashsetup
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono pettycashexpense, pettycashincome, pettycashoperation, pettycashsetup

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashexpense' and id=object_id('pettycashexpense'))
	drop index pettycashexpense.xi2pettycashexpense

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashexpense' and id=object_id('pettycashexpense'))
	drop index pettycashexpense.xi3pettycashexpense

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashincome' and id=object_id('pettycashincome'))
	drop index pettycashincome.xi2pettycashincome

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashincome' and id=object_id('pettycashincome'))
	drop index pettycashincome.xi3pettycashincome

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashoperation' and id=object_id('pettycashoperation'))
	drop index pettycashoperation.xi1pettycashoperation

IF EXISTS (SELECT * FROM sysindexes where name='xi5pettycashoperation' and id=object_id('pettycashoperation'))
	drop index pettycashoperation.xi5pettycashoperation

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashsetup' and id=object_id('pettycashsetup'))
	drop index pettycashsetup.xi1pettycashsetup
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycash'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycash] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycash' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashexpense'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashexpense] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashexpense' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashincome'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashincome] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashincome' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationcasualcontract'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationcasualcontract' AND field = 'idpettycash'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationinvoice'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationinvoice] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationinvoice' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationitineration' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationprofservice'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationprofservice] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationprofservice' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationsorted' AND field = 'idpettycash'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idpettycash'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idpettycash
	DELETE FROM columntypes WHERE tablename = 'pettycashsetup' AND field = 'idpettycash'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate clawback e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycash] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycash] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashexpense] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashincome] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationcasualcontract' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationcasualcontract] ALTER COLUMN idpettycash int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationitineration] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationprofservice' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationprofservice] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idpettycash int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [pettycashsetup] ALTER COLUMN idpettycash int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycash SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashexpense SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashincome SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationcasualcontract' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationcasualcontract SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationinvoice SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationitineration SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationprofservice' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationprofservice SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationsorted SET idpettycash = idpettycashint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idpettycashint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashsetup SET idpettycash = idpettycashint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycash' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycash] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationcasualcontract' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] ALTER COLUMN idpettycash int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationinvoice' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationprofservice' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idpettycash int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashsetup' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashsetup] ALTER COLUMN idpettycash int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CE NE SONO)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycash') and constid=object_id('xpkpettycash'))
BEGIN
	ALTER TABLE [pettycash] ADD CONSTRAINT xpkpettycash PRIMARY KEY (idpettycash)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycash') and constid=object_id('ukpettycash'))
BEGIN
	ALTER TABLE [pettycash] ADD CONSTRAINT ukpettycash UNIQUE (pettycode)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashexpense') and constid=object_id('xpkpettycashexpense'))
BEGIN
	ALTER TABLE [pettycashexpense] ADD CONSTRAINT xpkpettycashexpense PRIMARY KEY (idpettycash, yoperation, noperation, idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashincome') and constid=object_id('xpkpettycashincome'))
BEGIN
	ALTER TABLE [pettycashincome] ADD CONSTRAINT xpkpettycashincome PRIMARY KEY (idpettycash, yoperation, noperation, idinc)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperation') and constid=object_id('xpkpettycashoperation'))
BEGIN
	ALTER TABLE [pettycashoperation] ADD CONSTRAINT xpkpettycashoperation PRIMARY KEY (idpettycash, yoperation, noperation)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationcasualcontract') and constid=object_id('xpkpettycashoperationcasualcontract'))
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] ADD CONSTRAINT xpkpettycashoperationcasualcontract PRIMARY KEY (idpettycash, yoperation, noperation, ycon, ncon)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationinvoice') and constid=object_id('xpkpettycashoperationinvoice'))
BEGIN
	ALTER TABLE [pettycashoperationinvoice] ADD CONSTRAINT xpkpettycashoperationinvoice PRIMARY KEY (idpettycash, yoperation, noperation, idinvkind, yinv, ninv)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('xpkpettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD CONSTRAINT xpkpettycashoperationitineration PRIMARY KEY (idpettycash, yoperation, noperation, yitineration, nitineration)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationprofservice') and constid=object_id('xpkpettycashoperationprofservice'))
BEGIN
	ALTER TABLE [pettycashoperationprofservice] ADD CONSTRAINT xpkpettycashoperationprofservice PRIMARY KEY (idpettycash, yoperation, noperation, ycon, ncon)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationsorted') and constid=object_id('xpkpettycashoperationsorted'))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD CONSTRAINT xpkpettycashoperationsorted PRIMARY KEY (idpettycash, yoperation, noperation, idsorkind, idsor, idsubclass)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashsetup') and constid=object_id('xpkpettycashsetup'))
BEGIN
	ALTER TABLE [pettycashsetup] ADD CONSTRAINT xpkpettycashsetup PRIMARY KEY (idpettycash, ayear)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashexpense ON pettycashexpense (idpettycash, yoperation, noperation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashexpense
	ON pettycashexpense (idpettycash, yoperation, noperation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashexpense ON pettycashexpense (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashexpense
	ON pettycashexpense (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashincome' and id=object_id('pettycashincome'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashincome ON pettycashincome (idpettycash, yoperation, noperation)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2pettycashincome
	ON pettycashincome (idpettycash, yoperation, noperation)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashincome' and id=object_id('pettycashincome'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashincome ON pettycashincome (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3pettycashincome
	ON pettycashincome (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashoperation ON pettycashoperation (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashoperation
	ON pettycashoperation (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5pettycashoperation ON pettycashoperation (idpettycash, yrestore, nrestore)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5pettycashoperation
	ON pettycashoperation (idpettycash, yrestore, nrestore)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashsetup ON pettycashsetup (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashsetup
	ON pettycashsetup (idpettycash)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycash' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.703'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycash' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycash','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.703'},'''NINO''','SA',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycash' AND field = 'pettycode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = '',col_scale = '',systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.703'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycash' AND field = 'pettycode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycash','pettycode','N','varchar','20','','','System.String','varchar(20)','N','','','S',{ts '2006-10-12 10:22:06.703'},'''NINO''','SA',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashexpense' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.670'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashexpense' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashexpense','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.670'},'''NINO''','SA',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashincome' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:57.983'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashincome' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashincome','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:57.983'},'''NINO''','SA',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-04 12:14:35.047'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperation' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperation','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-04 12:14:35.047'},'''SARA''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationcasualcontract' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:18.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperationcasualcontract' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperationcasualcontract','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:18.920'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationinvoice' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:00.860'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperationinvoice' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperationinvoice','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:00.860'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationitineration' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:57.327'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperationitineration' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperationitineration','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:57.327'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationprofservice' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:56.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperationprofservice' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperationprofservice','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:56.250'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationsorted' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-16 14:01:05.110'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashoperationsorted' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperationsorted','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-16 14:01:05.110'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashsetup' AND field = 'idpettycash')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:54.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-12 10:22:06.703'} WHERE tablename = 'pettycashsetup' AND field = 'idpettycash'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashsetup','idpettycash','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:54.063'},'''NINO''','NINO',{ts '2006-10-12 10:22:06.703'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycash'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycash] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashexpense'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashexpense] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashincome'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashincome] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationcasualcontract'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationcasualcontract] DROP COLUMN idpettycashint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationinvoice'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationinvoice] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationprofservice'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationprofservice] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idpettycashint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashsetup'
		and C.name ='idpettycashint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashsetup] DROP COLUMN idpettycashint
END
GO

-- Aggiornamento degli idrelated della tabella ENTRY
UPDATE entry
SET idrelated = SUBSTRING(idrelated, 1, LEN('pettycashoperation§')) +
CONVERT(varchar(10),idpettycash) +
SUBSTRING(idrelated, LEN('pettycashoperation§') +
	CHARINDEX('§', SUBSTRING(idrelated, len('pettycashoperation§')+1, LEN(idrelated))) , LEN(idrelated)
)
FROM pettycash
WHERE idrelated LIKE 'pettycashoperation§%'
AND SUBSTRING(idrelated, LEN('pettycashoperation§') + 1,
CHARINDEX('§', SUBSTRING(idrelated, LEN('pettycashoperation§') + 1, LEN(idrelated))) - 1)
= pettycash.pettycode
GO
