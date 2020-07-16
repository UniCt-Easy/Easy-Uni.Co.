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

﻿-- Aggiornamento tabella SERVICE e tabelle dipendenti
-- Passo 0. Cancellazione delle righe presenti in MOTIVE770SERVICE dove tali righe violano il vincolo di chiave esterna con SERVICE
DELETE FROM motive770service WHERE NOT EXISTS(SELECT idser FROM service WHERE service.idser = motive770service.idser)
GO

DELETE FROM servicesorting WHERE NOT EXISTS(SELECT idser FROM service WHERE service.idser = servicesorting.idser)
GO

DELETE FROM servicetax WHERE NOT EXISTS(SELECT idser FROM service WHERE service.idser = servicetax.idser)
GO

DELETE FROM roleservice WHERE NOT EXISTS(SELECT idser FROM service WHERE service.idser = roleservice.idser)
GO

INSERT INTO service (idser, active, description, ct, cu, lt, lu, flagonlyfiscalabatement, module)
SELECT DISTINCT idser, 'N', idser, GETDATE(), 'SA', GETDATE(), '''SA''', 'N', 'COCOCO'
FROM parasubcontract
WHERE NOT EXISTS(SELECT * FROM service WHERE service.idser = parasubcontract.idser)
GO

INSERT INTO service (idser, active, description, ct, cu, lt, lu, flagonlyfiscalabatement, itinerationvisible)
SELECT DISTINCT idser, 'N', idser, GETDATE(), 'SA', GETDATE(), '''SA''', 'N', 'S'
FROM itineration
WHERE NOT EXISTS(SELECT * FROM service WHERE service.idser = itineration.idser)
GO

INSERT INTO service (idser, active, description, ct, cu, lt, lu, flagonlyfiscalabatement, module)
SELECT DISTINCT idser, 'N', idser, GETDATE(), 'SA', GETDATE(), '''SA''', 'N', 'DIPENDENTE'
FROM wageaddition
WHERE NOT EXISTS(SELECT * FROM service WHERE service.idser = wageaddition.idser)
GO

INSERT INTO service (idser, active, description, ct, cu, lt, lu, flagonlyfiscalabatement, module)
SELECT DISTINCT idser, 'N', idser, GETDATE(), 'SA', GETDATE(), '''SA''', 'N', 'OCCASIONALE'
FROM casualcontract
WHERE NOT EXISTS(SELECT * FROM service WHERE service.idser = casualcontract.idser)
GO

INSERT INTO service (idser, active, description, ct, cu, lt, lu, flagonlyfiscalabatement, module)
SELECT DISTINCT idser, 'N', idser, GETDATE(), 'SA', GETDATE(), '''SA''', 'N', 'PROFESSIONALE'
FROM profservice
WHERE NOT EXISTS(SELECT * FROM service WHERE service.idser = profservice.idser)
GO

-- Le tabelle dipendenti sono:
-- admpay_expense, casualcontract, expense, itineration, motive770service, parasubcontract, profservice, roleservice,
-- servicesorting, servicetax, taxsortingsetup, wageaddition

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [service] ADD idserint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'codeser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [service] ADD codeser varchar(20) NULL
END
ELSE
BEGIN
	ALTER TABLE [service] ALTER COLUMN codeser varchar(20) NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expense] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_expense] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [casualcontract] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN idserint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'motive770service' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [motive770service] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [motive770service] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [parasubcontract] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'roleservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [roleservice] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [roleservice] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [servicesorting] ALTER COLUMN idserint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [servicetax] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idserint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idserint int NULL
END
ELSE
BEGIN
	ALTER TABLE [wageaddition] ALTER COLUMN idserint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'codeser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE service SET codeser = idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_expense SET idserint = service.idserint
	FROM service
	WHERE admpay_expense.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontract SET idserint = service.idserint
	FROM service
	WHERE casualcontract.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idserint = service.idserint
	FROM service
	WHERE expense.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET idserint = service.idserint
	FROM service
	WHERE itineration.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'motive770service' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE motive770service SET idserint = service.idserint
	FROM service
	WHERE motive770service.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontract SET idserint = service.idserint
	FROM service
	WHERE parasubcontract.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idserint = service.idserint
	FROM service
	WHERE profservice.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'roleservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE roleservice SET idserint = service.idserint
	FROM service
	WHERE roleservice.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicesorting SET idserint = service.idserint
	FROM service
	WHERE servicesorting.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicetax SET idserint = service.idserint
	FROM service
	WHERE servicetax.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idserint = service.idserint
	FROM service
	WHERE taxsortingsetup.idser = service.idser
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageaddition SET idserint = service.idserint
	FROM service
	WHERE wageaddition.idser = service.idser
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono service, servicesorting, motive770service, roleservice, servicetax, taxsortingsetup

IF exists(SELECT * FROM sysconstraints where id=object_id('service') and constid=object_id('xpkservice'))
BEGIN
	ALTER TABLE [service] drop constraint xpkservice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('service') and constid=object_id('PK_service'))
BEGIN
	ALTER TABLE [service] drop constraint PK_service
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('servicesorting') and constid=object_id('xpkservicesorting'))
BEGIN
	ALTER TABLE [servicesorting] drop constraint xpkservicesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('servicesorting') and constid=object_id('PK_servicesorting'))
BEGIN
	ALTER TABLE [servicesorting] drop constraint PK_servicesorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('motive770service') and constid=object_id('xpkmotive770service'))
BEGIN
	ALTER TABLE [motive770service] drop constraint xpkmotive770service
END

IF exists(SELECT * FROM sysconstraints where id=object_id('motive770service') and constid=object_id('PK_motive770service'))
BEGIN
	ALTER TABLE [motive770service] drop constraint PK_motive770service
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('roleservice') and constid=object_id('xpkroleservice'))
BEGIN
	ALTER TABLE [roleservice] drop constraint xpkroleservice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('roleservice') and constid=object_id('PK_roleservice'))
BEGIN
	ALTER TABLE [roleservice] drop constraint PK_roleservice
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

-- Passo 4.2: Indici
-- Tabelle interessate sono expense, itineration

IF EXISTS (SELECT * FROM sysindexes where name='xi11expense' and id=object_id('expense'))
	drop index expense.xi11expense

IF EXISTS (SELECT * FROM sysindexes where name='xi2itineration' and id=object_id('itineration'))
	drop index itineration.xi2itineration
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'service'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [service] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'service' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expense'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expense] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'admpay_expense' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'casualcontract' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'itineration' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'motive770service'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [motive770service] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'motive770service' AND field = 'idser'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'parasubcontract' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'roleservice'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [roleservice] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'roleservice' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'servicesorting' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicetax'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicetax] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'servicetax' AND field = 'idser'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idser'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name ='idser'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idser
	DELETE FROM columntypes WHERE tablename = 'wageaddition' AND field = 'idser'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [service] ADD idser int NULL 
END
ELSE
	ALTER TABLE [service] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expense' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expense] ADD idser int NULL 
END
ELSE
	ALTER TABLE [admpay_expense] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idser int NULL 
END
ELSE
	ALTER TABLE [casualcontract] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idser int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idser int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idser int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'motive770service' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [motive770service] ADD idser int NULL 
END
ELSE
	ALTER TABLE [motive770service] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idser int NULL 
END
ELSE
	ALTER TABLE [parasubcontract] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idser int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'roleservice' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [roleservice] ADD idser int NULL 
END
ELSE
	ALTER TABLE [roleservice] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idser int NULL 
END
ELSE
	ALTER TABLE [servicesorting] ALTER COLUMN idser int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ADD idser int NULL 
END
ELSE
	ALTER TABLE [servicetax] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idser int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idser int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idser int NULL 
END
ELSE
	ALTER TABLE [wageaddition] ALTER COLUMN idser int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE service SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_expense SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontract SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'motive770service' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE motive770service SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontract SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'roleservice' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE roleservice SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicesorting SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicetax SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idser = idserint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idserint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageaddition SET idser = idserint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [service] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'motive770service' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [motive770service] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'roleservice' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [roleservice] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicetax' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicetax] ALTER COLUMN idser int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'service' and C.name = 'codeser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [service] ALTER COLUMN codeser varchar(20) NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ALTER COLUMN idser int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ALTER COLUMN idser int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('service') and constid=object_id('xpkservice'))
BEGIN
	ALTER TABLE [service] ADD CONSTRAINT xpkservice PRIMARY KEY (idser)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('service') and constid=object_id('ukservice'))
BEGIN
	ALTER TABLE [service] ADD CONSTRAINT ukservice UNIQUE (codeser)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('servicesorting') and constid=object_id('xpkservicesorting'))
BEGIN
	ALTER TABLE [servicesorting] ADD CONSTRAINT xpkservicesorting PRIMARY KEY (idser, idsorkind, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('motive770service') and constid=object_id('xpkmotive770service'))
BEGIN
	ALTER TABLE [motive770service] ADD CONSTRAINT xpkmotive770service PRIMARY KEY (idser, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('roleservice') and constid=object_id('xpkroleservice'))
BEGIN
	ALTER TABLE [roleservice] ADD CONSTRAINT xpkroleservice PRIMARY KEY (idrole, idser)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('servicetax') and constid=object_id('xpkservicetax'))
BEGIN
	ALTER TABLE [servicetax] ADD CONSTRAINT xpkservicetax PRIMARY KEY (idser, taxcode)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi11expense' and id=object_id('expense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi11expense ON expense (idser)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi11expense
	ON expense (idser)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itineration' and id=object_id('itineration'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2itineration ON itineration (idser)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2itineration
	ON itineration (idser)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_expense' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-06-11 11:51:51.657'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-06-11 11:51:51.657'} WHERE tablename = 'admpay_expense' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_expense','idser','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-06-11 11:51:51.657'},'''NINO''','NINO',{ts '2007-06-11 11:51:51.657'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontract' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-02-08 10:59:56.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:56.733'} WHERE tablename = 'casualcontract' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('casualcontract','idser','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-02-08 10:59:56.733'},'''NINO''','NINO',{ts '2006-02-08 10:59:56.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.437'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:56.733'} WHERE tablename = 'expense' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idser','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:33.437'},'''SA''','NINO',{ts '2006-02-08 10:59:56.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-10 10:45:21.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-05-10 10:45:21.267'} WHERE tablename = 'itineration' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('itineration','idser','N','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-10 10:45:21.267'},'''NINO''','NINO',{ts '2007-05-10 10:45:21.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'motive770service' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.593'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-05-10 10:45:21.267'} WHERE tablename = 'motive770service' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('motive770service','idser','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.593'},'''NINO''','SA',{ts '2007-05-10 10:45:21.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontract' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-02-08 10:59:48.127'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'parasubcontract' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('parasubcontract','idser','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-02-08 10:59:48.127'},'''NINO''','NINO',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-09 10:48:47.110'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'profservice' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('profservice','idser','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-09 10:48:47.110'},'''SARA''','NINO',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'roleservice' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:04.437'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'roleservice' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('roleservice','idser','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:04.437'},'''NINO''','SA',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'service' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:59.610'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'service' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('service','idser','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:59.610'},'''NINO''','SA',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'service' AND field = 'codeser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = '',col_scale = '',systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:59.610'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'service' AND field = 'codeser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('service','codeser','N','varchar','20','','','System.String','varchar(20)','N','','','S',{ts '2006-10-12 10:21:59.610'},'''NINO''','SA',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'servicesorting' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-01-17 11:15:11.030'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'servicesorting' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('servicesorting','idser','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-01-17 11:15:11.030'},'''SARA''','SA',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'servicetax' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:55.640'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'servicetax' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('servicetax','idser','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:55.640'},'''NINO''','SA',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:45.780'},lastmoduser = '''SARA''',createuser = 'PINO',createtimestamp = {ts '2006-02-08 10:59:48.127'} WHERE tablename = 'taxsortingsetup' AND field = 'idser'
ELSE
INSERT INTO [columntypes]
(tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxsortingsetup','idser','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-09 10:48:45.780'},'''SARA''','PINO',{ts '2006-02-08 10:59:48.127'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageaddition' AND field = 'idser')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-02-08 10:59:49.110'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:49.110'} WHERE tablename = 'wageaddition' AND field = 'idser'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('wageaddition','idser','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-02-08 10:59:49.110'},'''NINO''','NINO',{ts '2006-02-08 10:59:49.110'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'service'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [service] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expense'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expense] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'motive770service'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [motive770service] DROP COLUMN idserint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'roleservice'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [roleservice] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicetax'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicetax] DROP COLUMN idserint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idserint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name ='idserint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idserint
END
GO
	