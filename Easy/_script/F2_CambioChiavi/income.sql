
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


-- Aggiornamento tabella INCOME e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- admpay_assessment, assetunloadincome, banktransaction, creditpart, estimatedetail, income, incomeestimate,
-- incomeinvoice, incomesorted, incometotal, incomevar, incomeyear, invoicedetail, ivapayincome, pettycashincome, proceedspart

-- Passo 0: Cancellazione di righe che violano l'integrità referenziale
DELETE FROM incomevar WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = incomevar.idinc)
GO

DELETE FROM assetunloadincome WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = assetunloadincome.idinc)
GO

DELETE FROM creditpart WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = creditpart.idinc)
GO

DELETE FROM proceedspart WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = proceedspart.idinc)
GO

DELETE FROM incomesorted WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = incomesorted.idinc)
GO

DELETE FROM incomeyear WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = incomeyear.idinc)
GO

DELETE FROM ivapayincome WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = ivapayincome.idinc)
GO

DELETE FROM pettycashincome WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = pettycashincome.idinc)
GO

DELETE FROM incometotal WHERE NOT EXISTS(SELECT * FROM income WHERE income.idinc = incometotal.idinc)
GO

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_creditpart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_creditpart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensesorted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomevar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomeyear]
GO

-- Passo 0.ter: Cancellazione del campo idprooceds dalle tabelle ove non deve più esistere
-- Tabelle interessate: income, expense
IF EXISTS (SELECT * FROM sysindexes where name='xi8income' and id=object_id('income'))
	drop index income.xi8income
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idproceeds'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idproceeds
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'idproceeds'
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7expense' and id=object_id('expense'))
	drop index expense.xi7expense
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idproceeds'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idproceeds
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idproceeds'
END
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idincint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'parentidincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD parentidincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [income] ALTER COLUMN parentidincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_assessment] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_assessment] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetunloadincome] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [banktransaction] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [creditpart] ALTER COLUMN idincint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idinc_taxableint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idinc_taxableint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idinc_ivaint int NULL
END
ELSE
BEGIN
	ALTER TABLE [estimatedetail] ALTER COLUMN idinc_ivaint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeestimate] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeestimate] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeinvoice] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN idincint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incometotal] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incometotal] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomevar] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeyear] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinc_taxableint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idinc_taxableint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinc_ivaint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idinc_ivaint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayincome] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [ivapayincome] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashincome] ALTER COLUMN idincint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ADD idincint int NULL
END
ELSE
BEGIN
	ALTER TABLE [proceedspart] ALTER COLUMN idincint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'parentidincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET parentidincint =
		(SELECT idincint FROM income i2 WHERE i2.idinc = income.parentidinc)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_assessment SET idincint = income.idincint
	FROM income
	WHERE admpay_assessment.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadincome SET idincint = income.idincint
	FROM income
	WHERE assetunloadincome.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET idincint = income.idincint
	FROM income
	WHERE banktransaction.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE creditpart SET idincint = income.idincint
	FROM income
	WHERE creditpart.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idinc_taxableint = income.idincint
	FROM income
	WHERE estimatedetail.idinc_taxable = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idinc_ivaint = income.idincint
	FROM income
	WHERE estimatedetail.idinc_iva = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeestimate SET idincint = income.idincint
	FROM income
	WHERE incomeestimate.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeinvoice SET idincint = income.idincint
	FROM income
	WHERE incomeinvoice.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET idincint = income.idincint
	FROM income
	WHERE incomesorted.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incometotal SET idincint = income.idincint
	FROM income
	WHERE incometotal.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomevar SET idincint = income.idincint
	FROM income
	WHERE incomevar.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET idincint = income.idincint
	FROM income
	WHERE incomeyear.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idinc_taxableint = income.idincint
	FROM income
	WHERE invoicedetail.idinc_taxable = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idinc_ivaint = income.idincint
	FROM income
	WHERE invoicedetail.idinc_iva = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapayincome SET idincint = income.idincint
	FROM income
	WHERE ivapayincome.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashincome SET idincint = income.idincint
	FROM income
	WHERE pettycashincome.idinc = income.idinc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedspart SET idincint = income.idincint
	FROM income
	WHERE proceedspart.idinc = income.idinc
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono income, assetunloadincome, creditpart, incomeestimate,
-- incomeinvoice, incomesorted, incometotal, incomevar, incomeyear, ivapayincome, pettycashincome, proceedspart

IF exists(SELECT * FROM sysconstraints where id=object_id('income') and constid=object_id('xpkincome'))
BEGIN
	ALTER TABLE [income] drop constraint xpkincome
END

IF exists(SELECT * FROM sysconstraints where id=object_id('income') and constid=object_id('PK_income'))
BEGIN
	ALTER TABLE [income] drop constraint PK_income
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('xpkassetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] drop constraint xpkassetunloadincome
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('PK_assetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] drop constraint PK_assetunloadincome
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('creditpart') and constid=object_id('xpkcreditpart'))
BEGIN
	ALTER TABLE [creditpart] drop constraint xpkcreditpart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('creditpart') and constid=object_id('PK_creditpart'))
BEGIN
	ALTER TABLE [creditpart] drop constraint PK_creditpart
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeestimate') and constid=object_id('xpkincomeestimate'))
BEGIN
	ALTER TABLE [incomeestimate] drop constraint xpkincomeestimate
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeestimate') and constid=object_id('PK_incomeestimate'))
BEGIN
	ALTER TABLE [incomeestimate] drop constraint PK_incomeestimate
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

IF exists(SELECT * FROM sysconstraints where id=object_id('incomesorted') and constid=object_id('xpkincomesorted'))
BEGIN
	ALTER TABLE [incomesorted] drop constraint xpkincomesorted
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomesorted') and constid=object_id('PK_incomesorted'))
BEGIN
	ALTER TABLE [incomesorted] drop constraint PK_incomesorted
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('incometotal') and constid=object_id('xpkincometotal'))
BEGIN
	ALTER TABLE [incometotal] drop constraint xpkincometotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incometotal') and constid=object_id('PK_incometotal'))
BEGIN
	ALTER TABLE [incometotal] drop constraint PK_incometotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('incomevar') and constid=object_id('xpkincomevar'))
BEGIN
	ALTER TABLE [incomevar] drop constraint xpkincomevar
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomevar') and constid=object_id('PK_incomevar'))
BEGIN
	ALTER TABLE [incomevar] drop constraint PK_incomevar
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeyear') and constid=object_id('xpkincomeyear'))
BEGIN
	ALTER TABLE [incomeyear] drop constraint xpkincomeyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('incomeyear') and constid=object_id('PK_incomeyear'))
BEGIN
	ALTER TABLE [incomeyear] drop constraint PK_incomeyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayincome') and constid=object_id('xpkivapayincome'))
BEGIN
	ALTER TABLE [ivapayincome] drop constraint xpkivapayincome
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayincome') and constid=object_id('PK_ivapayincome'))
BEGIN
	ALTER TABLE [ivapayincome] drop constraint PK_ivapayincome
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

IF exists(SELECT * FROM sysconstraints where id=object_id('proceedspart') and constid=object_id('xpkproceedspart'))
BEGIN
	ALTER TABLE [proceedspart] drop constraint xpkproceedspart
END

IF exists(SELECT * FROM sysconstraints where id=object_id('proceedspart') and constid=object_id('PK_proceedspart'))
BEGIN
	ALTER TABLE [proceedspart] drop constraint PK_proceedspart
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2income' and id=object_id('income'))
	drop index income.xi2income

IF EXISTS (SELECT * FROM sysindexes where name='xi1creditpart' and id=object_id('creditpart'))
	drop index creditpart.xi1creditpart

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeinvoice' and id=object_id('incomeinvoice'))
	drop index incomeinvoice.xi2incomeinvoice

IF EXISTS (SELECT * FROM sysindexes where name='xi1incometotal' and id=object_id('incometotal'))
	drop index incometotal.xi1incometotal
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomesorted' and id=object_id('incomesorted'))
	drop index incomesorted.xi2incomesorted

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomesorted' and id=object_id('incomesorted'))
	drop index incomesorted.xi3incomesorted

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomevar' and id=object_id('incomevar'))
	drop index incomevar.xi1incomevar

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeyear' and id=object_id('incomeyear'))
	drop index incomeyear.xi1incomeyear
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayincome' and id=object_id('ivapayincome'))
	drop index ivapayincome.xi2ivapayincome

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashincome' and id=object_id('pettycashincome'))
	drop index pettycashincome.xi1pettycashincome

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedspart' and id=object_id('proceedspart'))
	drop index proceedspart.xi1proceedspart
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='parentidinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN parentidinc
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'parentidinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_assessment'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_assessment] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'admpay_assessment' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'assetunloadincome' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'idinc'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'creditpart'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [creditpart] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'creditpart' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idinc_taxable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idinc_taxable
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idinc_taxable'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idinc_iva'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idinc_iva
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idinc_iva'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeestimate'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeestimate] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incomeestimate' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incomeinvoice' AND field = 'idinc'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incomesorted' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incometotal'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incometotal] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incometotal' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incomevar' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'incomeyear' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinc_taxable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinc_taxable
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idinc_taxable'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinc_iva'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinc_iva
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idinc_iva'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayincome'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayincome] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'ivapayincome' AND field = 'idinc'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashincome'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashincome] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'pettycashincome' AND field = 'idinc'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedspart'
		and C.name ='idinc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedspart] DROP COLUMN idinc
	DELETE FROM columntypes WHERE tablename = 'proceedspart' AND field = 'idinc'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate expense e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'parentidinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD parentidinc int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN parentidinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_assessment] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [admpay_assessment] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [assetunloadincome] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [banktransaction] ALTER COLUMN idinc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [creditpart] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_taxable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idinc_taxable int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idinc_taxable int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idinc_iva int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idinc_iva int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeestimate] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incomeestimate] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incomeinvoice] ALTER COLUMN idinc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incomesorted] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incometotal] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incometotal] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incomevar] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [incomeyear] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_taxable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinc_taxable int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idinc_taxable int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idinc_iva int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idinc_iva int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayincome] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [ivapayincome] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [pettycashincome] ALTER COLUMN idinc int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ADD idinc int NULL 
END
ELSE
	ALTER TABLE [proceedspart] ALTER COLUMN idinc int NULL
GO

-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET idinc = idincint, parentidinc = parentidincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_assessment' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_assessment SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetunloadincome SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE creditpart SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idinc_taxable = idinc_taxableint, idinc_iva = idinc_iva
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeestimate SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeinvoice SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incometotal SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomevar SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomeyear SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idinc_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idinc_taxable = idinc_taxableint, idinc_iva = idinc_iva
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapayincome SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashincome SET idinc = idincint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idincint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE proceedspart SET idinc = idincint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetunloadincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetunloadincome] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'creditpart' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [creditpart] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeestimate] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN idinc int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incometotal] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeyear' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeyear] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayincome] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashincome' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashincome] ALTER COLUMN idinc int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceedspart' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceedspart] ALTER COLUMN idinc int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE A NOT NULL)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('income') and constid=object_id('xpkincome'))
BEGIN
	ALTER TABLE [income] ADD CONSTRAINT xpkincome PRIMARY KEY (idinc)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetunloadincome') and constid=object_id('xpkassetunloadincome'))
BEGIN
	ALTER TABLE [assetunloadincome] ADD CONSTRAINT xpkassetunloadincome PRIMARY KEY (idassetunloadkind, yassetunload, nassetunload, idinc)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('creditpart') and constid=object_id('xpkcreditpart'))
BEGIN
	ALTER TABLE [creditpart] ADD CONSTRAINT xpkcreditpart PRIMARY KEY (idinc, ncreditpart)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomeestimate') and constid=object_id('xpkincomeestimate'))
BEGIN
	ALTER TABLE [incomeestimate] ADD CONSTRAINT xpkincomeestimate PRIMARY KEY (idinc, idestimkind, yestim, nestim)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomeinvoice') and constid=object_id('xpkincomeinvoice'))
BEGIN
	ALTER TABLE [incomeinvoice] ADD CONSTRAINT xpkincomeinvoice PRIMARY KEY (idinc, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomesorted') and constid=object_id('xpkincomesorted'))
BEGIN
	ALTER TABLE [incomesorted] ADD CONSTRAINT xpkincomesorted PRIMARY KEY (idsorkind, idsor, idinc, idsubclass)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incometotal') and constid=object_id('xpkincometotal'))
BEGIN
	ALTER TABLE [incometotal] ADD CONSTRAINT xpkincometotal PRIMARY KEY (idinc, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomevar') and constid=object_id('xpkincomevar'))
BEGIN
	ALTER TABLE [incomevar] ADD CONSTRAINT xpkincomevar PRIMARY KEY (idinc, nvar)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomeyear') and constid=object_id('xpkincomeyear'))
BEGIN
	ALTER TABLE [incomeyear] ADD CONSTRAINT xpkincomeyear PRIMARY KEY (idinc, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivapayincome') and constid=object_id('xpkivapayincome'))
BEGIN
	ALTER TABLE [ivapayincome] ADD CONSTRAINT xpkivapayincome PRIMARY KEY (yivapay, nivapay, idinc)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashincome') and constid=object_id('xpkpettycashincome'))
BEGIN
	ALTER TABLE [pettycashincome] ADD CONSTRAINT xpkpettycashincome PRIMARY KEY (idpettycash, yoperation, noperation, idinc)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('proceedspart') and constid=object_id('xpkproceedspart'))
BEGIN
	ALTER TABLE [proceedspart] ADD CONSTRAINT xpkproceedspart PRIMARY KEY (idinc, nproceedspart)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2income' and id=object_id('income'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2income ON income (parentidinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2income
	ON income (parentidinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1creditpart' and id=object_id('creditpart'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1creditpart ON creditpart (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1creditpart
	ON creditpart (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeinvoice' and id=object_id('incomeinvoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomeinvoice ON incomeinvoice (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomeinvoice
	ON incomeinvoice (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incometotal' and id=object_id('incometotal'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incometotal ON incometotal (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incometotal
	ON incometotal (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomesorted' and id=object_id('incomesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomesorted ON incomesorted (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomesorted
	ON incomesorted (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomesorted' and id=object_id('incomesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3incomesorted ON incomesorted (idinc, ayear)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3incomesorted
	ON incomesorted (idinc, ayear)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomevar' and id=object_id('incomevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomevar ON incomevar (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomevar
	ON incomevar (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeyear' and id=object_id('incomeyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomeyear ON incomeyear (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomeyear
	ON incomeyear (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayincome' and id=object_id('ivapayincome'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapayincome ON ivapayincome (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapayincome
	ON ivapayincome (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashincome' and id=object_id('pettycashincome'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashincome ON pettycashincome (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashincome
	ON pettycashincome (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedspart' and id=object_id('proceedspart'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceedspart ON proceedspart (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1proceedspart
	ON proceedspart (idinc)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_assessment' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-06-11 11:51:52.627'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'admpay_assessment' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_assessment','idinc','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-06-11 11:51:52.627'},'''NINO''','NINO',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetunloadincome' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:10.420'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'assetunloadincome' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('assetunloadincome','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:10.420'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransaction' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:43.360'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'banktransaction' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('banktransaction','idinc','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-09 10:48:43.360'},'''SARA''','SARA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'creditpart' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:13.733'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'creditpart' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('creditpart','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:13.733'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idinc_iva')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-07-10 11:47:14.250'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'estimatedetail' AND field = 'idinc_iva'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('estimatedetail','idinc_iva','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-07-10 11:47:14.250'},'''SARA''','SARA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idinc_taxable')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-07-10 11:47:14.250'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'estimatedetail' AND field = 'idinc_taxable'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('estimatedetail','idinc_taxable','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-07-10 11:47:14.250'},'''SARA''','SARA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:08.170'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'income' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:08.170'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'parentidinc')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:08.280'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'income' AND field = 'parentidinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','parentidinc','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:08.280'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeestimate' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:52.937'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incomeestimate' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomeestimate','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:52.937'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeinvoice' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:55.750'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incomeinvoice' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomeinvoice','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:55.750'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesorted' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-16 14:01:04.157'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incomesorted' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomesorted','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-16 14:01:04.157'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incometotal' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.983'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incometotal' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incometotal','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.983'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomevar' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-04-20 14:36:20.420'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incomevar' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomevar','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-04-20 14:36:20.420'},'''SARA''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeyear' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:07.670'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'incomeyear' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('incomeyear','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:07.670'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idinc_iva')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.563'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'invoicedetail' AND field = 'idinc_iva'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicedetail','idinc_iva','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.563'},'''SARA''','SARA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idinc_taxable')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.563'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'invoicedetail' AND field = 'idinc_taxable'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicedetail','idinc_taxable','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.563'},'''SARA''','SARA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivapayincome' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:12.517'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'ivapayincome' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('ivapayincome','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:12.517'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashincome' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:57.967'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'pettycashincome' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashincome','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:57.967'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'proceedspart' AND field = 'idinc')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:21:57.593'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2007-06-11 11:51:52.627'} WHERE tablename = 'proceedspart' AND field = 'idinc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('proceedspart','idinc','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:21:57.593'},'''NINO''','SA',{ts '2007-06-11 11:51:52.627'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='parentidincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN parentidincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_assessment'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_assessment] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetunloadincome'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetunloadincome] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN idincint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'creditpart'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [creditpart] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idinc_taxableint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idinc_taxableint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name ='idinc_ivaint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idinc_ivaint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeestimate'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeestimate] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN idincint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incometotal'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incometotal] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinc_taxableint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinc_taxableint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idinc_ivaint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idinc_ivaint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayincome'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayincome] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashincome'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashincome] DROP COLUMN idincint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'proceedspart'
		and C.name ='idincint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [proceedspart] DROP COLUMN idincint
END
GO

