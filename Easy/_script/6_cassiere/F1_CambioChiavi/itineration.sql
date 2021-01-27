
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


-- Aggiornamento tabella ITINERATION e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- expenseitineration, itinerationlap, itinerationrefund, itinerationsorting, itinerationtax, pettycashoperationitineration

-- Passo 0: Cancellazione o Inserimento delle righe che violano l'integrità referenziale
DELETE FROM expenseitineration WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = expenseitineration.yitineration
		AND k.nitineration = expenseitineration.nitineration)
GO

DELETE FROM itinerationlap WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = itinerationlap.yitineration
		AND k.nitineration = itinerationlap.nitineration)
GO

DELETE FROM itinerationrefund WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = itinerationrefund.yitineration
		AND k.nitineration = itinerationrefund.nitineration)
GO

DELETE FROM itinerationsorting WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = itinerationsorting.yitineration
		AND k.nitineration = itinerationsorting.nitineration)
GO

DELETE FROM itinerationtax WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = itinerationtax.yitineration
		AND k.nitineration = itinerationtax.nitineration)
GO

DELETE FROM pettycashoperationitineration WHERE NOT EXISTS
	(SELECT * FROM itineration k
	WHERE k.yitineration = pettycashoperationitineration.yitineration
		AND k.nitineration = pettycashoperationitineration.nitineration)
GO

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER

-- Passo 1. (aggiunta colonna ad autoincremento) e Passo 2. (aggiunta delle colonne nelle tabelle referenziate)

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditinerationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iditinerationint int NOT NULL IDENTITY(1,1)
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationlap] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationtax] ADD iditineration int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD iditineration int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditinerationint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET iditineration = iditinerationint
	FROM itineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseitineration SET iditineration = itineration.iditineration
	FROM itineration
	WHERE expenseitineration.yitineration = itineration.yitineration AND expenseitineration.nitineration = itineration.nitineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationlap SET iditineration = itineration.iditineration
	FROM itineration
	WHERE itinerationlap.yitineration = itineration.yitineration AND itinerationlap.nitineration = itineration.nitineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationrefund SET iditineration = itineration.iditineration
	FROM itineration
	WHERE itinerationrefund.yitineration = itineration.yitineration AND itinerationrefund.nitineration = itineration.nitineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsorting SET iditineration = itineration.iditineration
	FROM itineration
	WHERE itinerationsorting.yitineration = itineration.yitineration AND itinerationsorting.nitineration = itineration.nitineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationtax SET iditineration = itineration.iditineration
	FROM itineration
	WHERE itinerationtax.yitineration = itineration.yitineration AND itinerationtax.nitineration = itineration.nitineration
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationitineration SET iditineration = itineration.iditineration
	FROM itineration
	WHERE pettycashoperationitineration.yitineration = itineration.yitineration AND pettycashoperationitineration.nitineration = itineration.nitineration
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono assetloadkind, assetload, assetloadexpense

IF exists(SELECT * FROM sysconstraints where id=object_id('itineration') and constid=object_id('xpkitineration'))
BEGIN
	ALTER TABLE [itineration] drop constraint xpkitineration
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itineration') and constid=object_id('PK_itineration'))
BEGIN
	ALTER TABLE [itineration] drop constraint PK_itineration
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('xpkexpenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] drop constraint xpkexpenseitineration
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('PK_expenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] drop constraint PK_expenseitineration
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationlap') and constid=object_id('xpkitinerationlap'))
BEGIN
	ALTER TABLE [itinerationlap] drop constraint xpkitinerationlap
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationlap') and constid=object_id('PK_itinerationlap'))
BEGIN
	ALTER TABLE [itinerationlap] drop constraint PK_itinerationlap
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefund') and constid=object_id('xpkitinerationrefund'))
BEGIN
	ALTER TABLE [itinerationrefund] drop constraint xpkitinerationrefund
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefund') and constid=object_id('PK_itinerationrefund'))
BEGIN
	ALTER TABLE [itinerationrefund] drop constraint PK_itinerationrefund
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationsorting') and constid=object_id('xpkitinerationsorting'))
BEGIN
	ALTER TABLE [itinerationsorting] drop constraint xpkitinerationsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('itinerationsorting') and constid=object_id('PK_itinerationsorting'))
BEGIN
	ALTER TABLE [itinerationsorting] drop constraint PK_itinerationsorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('xpkpettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] drop constraint xpkpettycashoperationitineration
END

IF exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('PK_pettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] drop constraint PK_pettycashoperationitineration
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono expenseitineration, itinerationlap, itinerationtax
IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseitineration' and id=object_id('expenseitineration'))
	drop index expenseitineration.xi1expenseitineration
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationlap' and id=object_id('itinerationlap'))
	drop index itinerationlap.xi1itinerationlap
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationtax' and id=object_id('itinerationtax'))
	drop index itinerationtax.xi1itinerationtax
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'expenseitineration' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'expenseitineration' AND field = 'nitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationlap'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationlap] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationlap' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationlap'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationlap] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationlap' AND field = 'nitineration'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationrefund' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationrefund'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationrefund] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationrefund' AND field = 'nitineration'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationsorting' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationsorting' AND field = 'nitineration'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationtax'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationtax] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationtax' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationtax'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationtax] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'itinerationtax' AND field = 'nitineration'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='yitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN yitineration
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationitineration' AND field = 'yitineration'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='nitineration'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN nitineration
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationitineration' AND field = 'nitineration'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso) - NON SERVE
-- Tabelle interessate -

-- Passo 6. Valorizzazione nuovo campo - Gia fatto a priori

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationlap' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationlap] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationrefund' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationrefund] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationtax' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationtax] ALTER COLUMN iditineration int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ALTER COLUMN iditineration int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itineration') and constid=object_id('xpkitineration'))
BEGIN
	ALTER TABLE [itineration] ADD CONSTRAINT xpkitineration PRIMARY KEY (iditineration)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itineration') and constid=object_id('ukitineration'))
BEGIN
	ALTER TABLE [itineration] ADD CONSTRAINT ukitineration UNIQUE (yitineration, nitineration)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('xpkexpenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] ADD CONSTRAINT xpkexpenseitineration PRIMARY KEY (idexp, iditineration)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationlap') and constid=object_id('xpkitinerationlap'))
BEGIN
	ALTER TABLE [itinerationlap] ADD CONSTRAINT xpkitinerationlap PRIMARY KEY (iditineration, lapnumber)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationrefund') and constid=object_id('xpkitinerationrefund'))
BEGIN
	ALTER TABLE [itinerationrefund] ADD CONSTRAINT xpkitinerationrefund PRIMARY KEY (iditineration, nrefund)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationsorting') and constid=object_id('xpkitinerationsorting'))
BEGIN
	ALTER TABLE [itinerationsorting] ADD CONSTRAINT xpkitinerationsorting PRIMARY KEY (iditineration, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationtax') and constid=object_id('xpkitinerationtax'))
BEGIN
	ALTER TABLE [itinerationtax] ADD CONSTRAINT xpkitinerationtax PRIMARY KEY (iditineration, taxcode)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationitineration') and constid=object_id('xpkpettycashoperationitineration'))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD CONSTRAINT xpkpettycashoperationitineration PRIMARY KEY (idpettycash, yoperation, noperation, iditineration)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi3itineration' and id=object_id('itineration'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3itineration ON itineration (yitineration, nitineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3itineration
	ON itineration (yitineration, nitineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseitineration' and id=object_id('expenseitineration'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseitineration ON expenseitineration (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseitineration
	ON expenseitineration (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationlap' and id=object_id('itinerationlap'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationlap ON itinerationlap (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationlap
	ON itinerationlap (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationrefund ON itinerationrefund (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2itinerationrefund
	ON itinerationrefund (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationsorting' and id=object_id('itinerationsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationsorting ON itinerationsorting (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationsorting
	ON itinerationsorting (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationtax' and id=object_id('itinerationtax'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationtax ON itinerationtax (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1itinerationtax
	ON itinerationtax (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashoperationitineration' and id=object_id('pettycashoperationitineration'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashoperationitineration ON pettycashoperationitineration (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashoperationitineration
	ON pettycashoperationitineration (iditineration)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseitineration' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:55.293'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:55.293'} WHERE tablename = 'expenseitineration' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenseitineration','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:55.293'},'''NINO''','NINO',{ts '2007-12-03 11:26:55.293'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:52.013'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:52.013'} WHERE tablename = 'itineration' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:52.013'},'''NINO''','NINO',{ts '2007-12-03 11:26:52.013'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'nitineration')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:51.980'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:51.980'} WHERE tablename = 'itineration' AND field = 'nitineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','nitineration','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:51.980'},'''NINO''','NINO',{ts '2007-12-03 11:26:51.980'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'yitineration')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:51.980'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:51.980'} WHERE tablename = 'itineration' AND field = 'yitineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','yitineration','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 11:26:51.980'},'''NINO''','NINO',{ts '2007-12-03 11:26:51.980'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationlap' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:53.870'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:53.870'} WHERE tablename = 'itinerationlap' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationlap','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:53.870'},'''NINO''','NINO',{ts '2007-12-03 11:26:53.870'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationrefund' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:53.513'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:53.513'} WHERE tablename = 'itinerationrefund' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationrefund','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:53.513'},'''NINO''','NINO',{ts '2007-12-03 11:26:53.513'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationsorting' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:52.857'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:52.857'} WHERE tablename = 'itinerationsorting' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationsorting','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:52.857'},'''NINO''','NINO',{ts '2007-12-03 11:26:52.857'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationtax' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:53.060'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:53.060'} WHERE tablename = 'itinerationtax' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationtax','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:53.060'},'''NINO''','NINO',{ts '2007-12-03 11:26:53.060'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationitineration' AND field = 'iditineration')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 11:26:52.480'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 11:26:52.480'} WHERE tablename = 'pettycashoperationitineration' AND field = 'iditineration'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperationitineration','iditineration','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-12-03 11:26:52.480'},'''NINO''','NINO',{ts '2007-12-03 11:26:52.480'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name ='iditinerationint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN iditinerationint
END
GO

