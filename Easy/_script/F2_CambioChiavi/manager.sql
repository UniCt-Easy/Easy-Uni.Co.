
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


-- Aggiornamento tabella MANAGER e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- asset, assetmanager, autoexpensesorting, autoincomesorting, estimate, expense, fin, flowchartmanager,
-- income, location, managersorting, mandate, payment, paymenttransmission, pettycashoperation, proceeds,
-- proceedstransmission, sortingexpensefilter, sortingincomefilter, upb

-- Passo 0: Cancellazione di righe che violano l'integrità referenziale
DELETE FROM assetmanager WHERE NOT EXISTS(SELECT * FROM manager WHERE manager.idman = assetmanager.idman)
GO

DELETE FROM flowchartmanager WHERE NOT EXISTS(SELECT * FROM manager WHERE manager.idman = flowchartmanager.idman)
GO

DELETE FROM managersorting WHERE NOT EXISTS(SELECT * FROM manager WHERE manager.idman = managersorting.idman)
GO

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_fin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ADD idmanint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [asset] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetmanager] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimate] ALTER COLUMN idmanint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [fin] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartmanager] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [flowchartmanager] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [income] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [location] ALTER COLUMN idmanint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [managersorting] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandate] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [payment] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [paymenttransmission] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idmanint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceeds] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceedstransmission] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idmanint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idmanint int NULL
END
ELSE
BEGIN
	ALTER TABLE [upb] ALTER COLUMN idmanint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idmanint = manager.idmanint
	FROM manager
	WHERE asset.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetmanager SET idmanint = manager.idmanint
	FROM manager
	WHERE assetmanager.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idmanint = manager.idmanint
	FROM manager
	WHERE autoexpensesorting.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idmanint = manager.idmanint
	FROM manager
	WHERE autoincomesorting.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idmanint = manager.idmanint
	FROM manager
	WHERE estimate.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idmanint = manager.idmanint
	FROM manager
	WHERE expense.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET idmanint = manager.idmanint
	FROM manager
	WHERE fin.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartmanager SET idmanint = manager.idmanint
	FROM manager
	WHERE flowchartmanager.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET idmanint = manager.idmanint
	FROM manager
	WHERE income.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET idmanint = manager.idmanint
	FROM manager
	WHERE location.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE managersorting SET idmanint = manager.idmanint
	FROM manager
	WHERE managersorting.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idmanint = manager.idmanint
	FROM manager
	WHERE mandate.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idmanint = manager.idmanint
	FROM manager
	WHERE payment.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymenttransmission SET idmanint = manager.idmanint
	FROM manager
	WHERE paymenttransmission.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idmanint = manager.idmanint
	FROM manager
	WHERE pettycashoperation.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idmanint = manager.idmanint
	FROM manager
	WHERE payment.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idmanint = manager.idmanint
	FROM manager
	WHERE proceeds.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedstransmission SET idmanint = manager.idmanint
	FROM manager
	WHERE proceedstransmission.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idmanint = manager.idmanint
	FROM manager
	WHERE sortingexpensefilter.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idmanint = manager.idmanint
	FROM manager
	WHERE sortingincomefilter.idman = manager.idman
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upb SET idmanint = manager.idmanint
	FROM manager
	WHERE upb.idman = manager.idman
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono manager, managersorting, flowchartmanager
IF exists(SELECT * FROM sysconstraints where id=object_id('manager') and constid=object_id('xpkmanager'))
BEGIN
	ALTER TABLE [manager] drop constraint xpkmanager
END

IF exists(SELECT * FROM sysconstraints where id=object_id('manager') and constid=object_id('PK_manager'))
BEGIN
	ALTER TABLE [manager] drop constraint PK_manager
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('managersorting') and constid=object_id('xpkmanagersorting'))
BEGIN
	ALTER TABLE [managersorting] drop constraint xpkmanagersorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('managersorting') and constid=object_id('PK_managersorting'))
BEGIN
	ALTER TABLE [managersorting] drop constraint PK_managersorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartmanager') and constid=object_id('xpkflowchartmanager'))
BEGIN
	ALTER TABLE [flowchartmanager] drop constraint xpkflowchartmanager
END

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartmanager') and constid=object_id('PK_flowchartmanager'))
BEGIN
	ALTER TABLE [flowchartmanager] drop constraint PK_flowchartmanager
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi3asset' and id=object_id('asset'))
	drop index asset.xi3asset

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetmanager' and id=object_id('assetmanager'))
	drop index assetmanager.xi2assetmanager

IF EXISTS (SELECT * FROM sysindexes where name='xi4expense' and id=object_id('expense'))
	drop index expense.xi4expense

IF EXISTS (SELECT * FROM sysindexes where name='xi6fin' and id=object_id('fin'))
	drop index fin.xi6fin

IF EXISTS (SELECT * FROM sysindexes where name='xi5income' and id=object_id('income'))
	drop index income.xi5income
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3location' and id=object_id('location'))
	drop index location.xi3location

IF EXISTS (SELECT * FROM sysindexes where name='xi2managersorting' and id=object_id('managersorting'))
	drop index managersorting.xi2managersorting

IF EXISTS (SELECT * FROM sysindexes where name='xi2mandate' and id=object_id('mandate'))
	drop index mandate.xi2mandate

IF EXISTS (SELECT * FROM sysindexes where name='xi5payment' and id=object_id('payment'))
	drop index payment.xi5payment

IF EXISTS (SELECT * FROM sysindexes where name='xi1paymenttransmission' and id=object_id('paymenttransmission'))
	drop index paymenttransmission.xi1paymenttransmission
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5proceeds' and id=object_id('proceeds'))
	drop index proceeds.xi5proceeds

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedstransmission' and id=object_id('proceedstransmission'))
	drop index proceedstransmission.xi1proceedstransmission
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'manager'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [manager] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'manager' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'asset' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetmanager'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetmanager] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'assetmanager' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'estimate' AND field = 'idman'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'fin' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartmanager'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartmanager] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'flowchartmanager' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'location' AND field = 'idman'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'managersorting' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'mandate' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'payment' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymenttransmission'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymenttransmission] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'paymenttransmission' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idman'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'proceeds' AND field = 'idman'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedstransmission'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedstransmission] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'proceedstransmission' AND field = 'idman'
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idman'
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idman'
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upb'
		and C.name ='idman'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upb] DROP COLUMN idman
	DELETE FROM columntypes WHERE tablename = 'upb' AND field = 'idman'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate manager e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ADD idman int NULL 
END
ELSE
	ALTER TABLE [manager] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [asset] ADD idman int NULL 
END
ELSE
	ALTER TABLE [asset] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ADD idman int NULL 
END
ELSE
	ALTER TABLE [assetmanager] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idman int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idman int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimate] ADD idman int NULL 
END
ELSE
	ALTER TABLE [estimate] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idman int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fin] ADD idman int NULL 
END
ELSE
	ALTER TABLE [fin] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartmanager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartmanager] ADD idman int NULL 
END
ELSE
	ALTER TABLE [flowchartmanager] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idman int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [location] ADD idman int NULL 
END
ELSE
	ALTER TABLE [location] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idman int NULL 
END
ELSE
	ALTER TABLE [managersorting] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandate] ADD idman int NULL 
END
ELSE
	ALTER TABLE [mandate] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment] ADD idman int NULL 
END
ELSE
	ALTER TABLE [payment] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [paymenttransmission] ADD idman int NULL 
END
ELSE
	ALTER TABLE [paymenttransmission] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idman int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds] ADD idman int NULL 
END
ELSE
	ALTER TABLE [proceeds] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedstransmission] ADD idman int NULL 
END
ELSE
	ALTER TABLE [proceedstransmission] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idman int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idman int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idman int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upb] ADD idman int NULL 
END
ELSE
	ALTER TABLE [upb] ALTER COLUMN idman int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE manager SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'asset' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE asset SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetmanager SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimate SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fin' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE fin SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartmanager' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartmanager SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'location' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE location SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE managersorting SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandate' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandate SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'paymenttransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE paymenttransmission SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE payment SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceeds SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedstransmission' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedstransmission SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idman = idmanint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upb' and C.name = 'idmanint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upb SET idman = idmanint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'manager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [manager] ALTER COLUMN idman int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartmanager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartmanager] ALTER COLUMN idman int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ALTER COLUMN idman int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetmanager' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetmanager] ALTER COLUMN idman int NOT NULL
END
GO

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('manager') and constid=object_id('xpkmanager'))
BEGIN
	ALTER TABLE [manager] ADD CONSTRAINT xpkmanager PRIMARY KEY (idman)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('managersorting') and constid=object_id('xpkmanagersorting'))
BEGIN
	ALTER TABLE [managersorting] ADD CONSTRAINT xpkmanagersorting PRIMARY KEY (idman, idsorkind, idsor)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('flowchartmanager') and constid=object_id('xpkflowchartmanager'))
BEGIN
	ALTER TABLE [flowchartmanager] ADD CONSTRAINT xpkflowchartmanager PRIMARY KEY (idflowchart, idman)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi3asset' and id=object_id('asset'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3asset ON asset (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3asset
	ON asset (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetmanager' and id=object_id('assetmanager'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetmanager ON assetmanager (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2assetmanager
	ON assetmanager (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expense' and id=object_id('expense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi4expense ON expense (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi4expense
	ON expense (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6fin' and id=object_id('fin'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6fin ON fin (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6fin
	ON fin (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5income' and id=object_id('income'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5income ON income (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5income
	ON income (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3location' and id=object_id('location'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3location ON location (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3location
	ON location (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2managersorting' and id=object_id('managersorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2managersorting ON managersorting (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2managersorting
	ON managersorting (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2mandate' and id=object_id('mandate'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2mandate ON mandate (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2mandate
	ON mandate (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5payment' and id=object_id('payment'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5payment ON payment (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5payment
	ON payment (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1paymenttransmission ON paymenttransmission (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1paymenttransmission
	ON paymenttransmission (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5proceeds' and id=object_id('proceeds'))
BEGIN
	CREATE NONCLUSTERED INDEX xi5proceeds ON proceeds (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi5proceeds
	ON proceeds (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceedstransmission ON proceedstransmission (idman)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceedstransmission
	ON proceedstransmission (idman)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'asset' AND field = 'idman')
UPDATE columntypes SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-06-04 15:46:50.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'asset' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('asset','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-06-04 15:46:50.157'},'''NINO''','NINO',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetmanager' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:52.877'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'assetmanager' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('assetmanager','idman','N','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:52.877'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:57.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'autoexpensesorting' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('autoexpensesorting','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:57.313'},'''NINO''','NINO',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:57.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'autoincomesorting' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('autoincomesorting','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:57.313'},'''NINO''','NINO',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimate' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-01-17 11:15:10.563'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'estimate' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('estimate','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-01-17 11:15:10.563'},'''SARA''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.377'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'expense' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:33.377'},'''SA''','NINO',{ts '2007-05-12 11:53:33.377'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'fin' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:11.983'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'fin' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('fin','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:11.983'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'flowchartmanager' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-07-09 15:06:57.593'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'flowchartmanager' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('flowchartmanager','idman','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-07-09 15:06:57.593'},'''SARA''','SARA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:08.187'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'income' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:08.187'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'location' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:58.500'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'location' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('location','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:58.500'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'manager' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:58.377'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'manager' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('manager','idman','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:58.377'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'managersorting' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-16 14:01:05.547'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'managersorting' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('managersorting','idman','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-16 14:01:05.547'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandate' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:15.937'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'mandate' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('mandate','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:15.937'},'''SARA''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'payment' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:01.377'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'payment' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('payment','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:01.377'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'paymenttransmission' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:14.593'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'paymenttransmission' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('paymenttransmission','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:14.593'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-07-04 12:14:35.030'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'pettycashoperation' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperation','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-07-04 12:14:35.030'},'''SARA''','NINO',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceeds' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:21:54.733'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'proceeds' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('proceeds','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:21:54.733'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedstransmission' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:09.593'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-11 13:16:57.313'} WHERE tablename = 'proceedstransmission' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('proceedstransmission','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:09.593'},'''NINO''','SA',{ts '2006-10-11 13:16:57.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:23.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:23.077'} WHERE tablename = 'sortingexpensefilter' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingexpensefilter','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:23.077'},'''NINO''','NINO',{ts '2006-10-11 13:16:23.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-11 13:16:23.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-10-11 13:16:23.077'} WHERE tablename = 'sortingincomefilter' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('sortingincomefilter','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-11 13:16:23.077'},'''NINO''','NINO',{ts '2006-10-11 13:16:23.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upb' AND field = 'idman')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-02-08 10:59:44.360'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2006-02-08 10:59:44.360'} WHERE tablename = 'upb' AND field = 'idman'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('upb','idman','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-02-08 10:59:44.360'},'''NINO''','NINO',{ts '2006-02-08 10:59:44.360'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'manager'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [manager] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'asset'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [asset] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetmanager'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetmanager] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimate'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimate] DROP COLUMN idmanint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'fin'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [fin] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartmanager'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartmanager] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'location'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [location] DROP COLUMN idmanint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandate'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandate] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'payment'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [payment] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'paymenttransmission'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [paymenttransmission] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idmanint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceeds'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceeds] DROP COLUMN idmanint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedstransmission'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedstransmission] DROP COLUMN idmanint
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idmanint
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idmanint
END


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upb'
		and C.name ='idmanint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upb] DROP COLUMN idmanint
END
GO
