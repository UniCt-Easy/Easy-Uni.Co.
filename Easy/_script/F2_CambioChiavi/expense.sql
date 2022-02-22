
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella EXPENSE e tabelle dipendenti
-- Le tabelle dipendenti sono:
-- admpay_appropriation, assetloadexpense, banktransaction, expensecasualcontract, expenseclawback, expenseinvoice, expenseitineration,
-- expensemandate, expensepayroll, expenseprofservice, expensesorted, expensetax, expensetotal, expensevar, expensewageaddition, expenseyear,
-- income, invoicedetail, ivapayexpense, mandatedetail, pettycashexpense, pettycashoperation, taxpayexpense

-- Passo 0: Cancellazione di righe che violano l'integrità referenziale
DELETE FROM expensevar WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensevar.idexp)
GO

DELETE FROM expenseclawback WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expenseclawback.idexp)
GO

DELETE FROM expensetax WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensetax.idexp)
GO

DELETE FROM assetloadexpense WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = assetloadexpense.idexp)
GO

DELETE FROM expensecasualcontract WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensecasualcontract.idexp)
GO

DELETE FROM expenseinvoice WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expenseinvoice.idexp)
GO

DELETE FROM expenseitineration WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expenseitineration.idexp)
GO

DELETE FROM expensemandate WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensemandate.idexp)
GO

DELETE FROM expensepayroll WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensepayroll.idexp)
GO

DELETE FROM expenseprofservice WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expenseprofservice.idexp)
GO

DELETE FROM expensetotal WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensetotal.idexp)
GO

DELETE FROM expensewageaddition WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensewageaddition.idexp)
GO

DELETE FROM ivapayexpense WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = ivapayexpense.idexp)
GO

DELETE FROM pettycashexpense WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = pettycashexpense.idexp)
GO

DELETE FROM taxpayexpense WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = taxpayexpense.idexp)
GO

DELETE FROM expensesorted WHERE NOT EXISTS(SELECT * FROM expense WHERE expense.idexp = expensesorted.idexp)
GO

-- Passo 0.bis: Rimozione dei Trigger
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensesorted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expensevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expensevar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenseyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenseyear]
GO

-- Passo 1. (aggiunta colonna ad autoincremento)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idexpint int NOT NULL IDENTITY(1,1)
END
GO

-- Passo 2. (aggiunta delle colonne nelle tabelle referenziate)
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'parentidexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD parentidexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN parentidexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idpaymentint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idpaymentint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idformerexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idformerexpenseint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idformerexpenseint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_appropriation] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [admpay_appropriation] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [assetloadexpense] ALTER COLUMN idexpint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [banktransaction] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensecasualcontract' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensecasualcontract] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensecasualcontract] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseclawback] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseinvoice] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseitineration] ALTER COLUMN idexpint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensemandate] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensemandate] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensepayroll' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensepayroll] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensepayroll] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseprofservice] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseprofservice] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensetax] ALTER COLUMN idexpint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetotal] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensetotal] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idpaymentint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN idpaymentint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensewageaddition' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensewageaddition] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expensewageaddition] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseyear] ALTER COLUMN idexpint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idpaymentint int NULL
END
ELSE
BEGIN
	ALTER TABLE [income] ALTER COLUMN idpaymentint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idexp_taxableint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idexp_taxableint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idexp_ivaint int NULL
END
ELSE
BEGIN
	ALTER TABLE [invoicedetail] ALTER COLUMN idexp_ivaint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayexpense] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [ivapayexpense] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idexp_taxableint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idexp_taxableint int NULL
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idexp_ivaint int NULL
END
ELSE
BEGIN
	ALTER TABLE [mandatedetail] ALTER COLUMN idexp_ivaint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashexpense] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperation] ALTER COLUMN idexpint int NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ADD idexpint int NULL
END
ELSE
BEGIN
	ALTER TABLE [taxpayexpense] ALTER COLUMN idexpint int NULL
END
GO

-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'parentidexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET parentidexpint =
		(SELECT idexpint FROM expense e2 WHERE e2.idexp = expense.parentidexp)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idformerexpenseint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idformerexpenseint =
		(SELECT idexpint FROM expense e2 WHERE e2.idexp = expense.idformerexpense)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idpaymentint =
		(SELECT idexpint FROM expense e2 WHERE e2.idexp = expense.idpayment)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_appropriation SET idexpint = expense.idexpint
	FROM expense
	WHERE admpay_appropriation.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadexpense SET idexpint = expense.idexpint
	FROM expense
	WHERE assetloadexpense.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET idexpint = expense.idexpint
	FROM expense
	WHERE banktransaction.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensecasualcontract' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensecasualcontract SET idexpint = expense.idexpint
	FROM expense
	WHERE expensecasualcontract.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseclawback SET idexpint = expense.idexpint
	FROM expense
	WHERE expenseclawback.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseinvoice SET idexpint = expense.idexpint
	FROM expense
	WHERE expenseinvoice.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseitineration SET idexpint = expense.idexpint
	FROM expense
	WHERE expenseitineration.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensemandate SET idexpint = expense.idexpint
	FROM expense
	WHERE expensemandate.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensepayroll' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensepayroll SET idexpint = expense.idexpint
	FROM expense
	WHERE expensepayroll.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseprofservice SET idexpint = expense.idexpint
	FROM expense
	WHERE expenseprofservice.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET idexpint = expense.idexpint
	FROM expense
	WHERE expensesorted.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetax SET idexpint = expense.idexpint
	FROM expense
	WHERE expensetax.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetotal SET idexpint = expense.idexpint
	FROM expense
	WHERE expensetotal.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET idexpint = expense.idexpint
	FROM expense
	WHERE expensevar.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET idpaymentint = expense.idexpint
	FROM expense
	WHERE expensevar.idpayment = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensewageaddition' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensewageaddition SET idexpint = expense.idexpint
	FROM expense
	WHERE expensewageaddition.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET idexpint = expense.idexpint
	FROM expense
	WHERE expenseyear.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET idpaymentint = expense.idexpint
	FROM expense
	WHERE income.idpayment = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idexp_taxableint = expense.idexpint
	FROM expense
	WHERE invoicedetail.idexp_taxable = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idexp_ivaint = expense.idexpint
	FROM expense
	WHERE invoicedetail.idexp_iva = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapayexpense SET idexpint = expense.idexpint
	FROM expense
	WHERE ivapayexpense.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idexp_taxableint = expense.idexpint
	FROM expense
	WHERE mandatedetail.idexp_taxable = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_ivaint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idexp_ivaint = expense.idexpint
	FROM expense
	WHERE mandatedetail.idexp_iva = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashexpense SET idexpint = expense.idexpint
	FROM expense
	WHERE pettycashexpense.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idexpint = expense.idexpint
	FROM expense
	WHERE pettycashoperation.idexp = expense.idexp
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpayexpense SET idexpint = expense.idexpint
	FROM expense
	WHERE taxpayexpense.idexp = expense.idexp
END
GO

-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono expense, assetloadexpense, expensecasualcontract, expenseclawback, expenseinvoice, expenseitineration, expensemandate,
-- expensepayroll, expenseprofservice, expensesorted, expensetax, expensetotal, expensevar, expensewageaddition, expenseyear, ivapayexpense, 
-- pettycashexpense, taxpayexpense
IF exists(SELECT * FROM sysconstraints where id=object_id('expense') and constid=object_id('xpkexpense'))
BEGIN
	ALTER TABLE [expense] drop constraint xpkexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expense') and constid=object_id('PK_expense'))
BEGIN
	ALTER TABLE [expense] drop constraint PK_expense
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('xpkassetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] drop constraint xpkassetloadexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('PK_assetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] drop constraint PK_assetloadexpense
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensecasualcontract') and constid=object_id('xpkexpensecasualcontract'))
BEGIN
	ALTER TABLE [expensecasualcontract] drop constraint xpkexpensecasualcontract
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensecasualcontract') and constid=object_id('PK_expensecasualcontract'))
BEGIN
	ALTER TABLE [expensecasualcontract] drop constraint PK_expensecasualcontract
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('xpkexpenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] drop constraint xpkexpenseclawback
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('PK_expenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] drop constraint PK_expenseclawback
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

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('xpkexpenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] drop constraint xpkexpenseitineration
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('PK_expenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] drop constraint PK_expenseitineration
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensemandate') and constid=object_id('xpkexpensemandate'))
BEGIN
	ALTER TABLE [expensemandate] drop constraint xpkexpensemandate
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensemandate') and constid=object_id('PK_expensemandate'))
BEGIN
	ALTER TABLE [expensemandate] drop constraint PK_expensemandate
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensepayroll') and constid=object_id('xpkexpensepayroll'))
BEGIN
	ALTER TABLE [expensepayroll] drop constraint xpkexpensepayroll
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensepayroll') and constid=object_id('PK_expensepayroll'))
BEGIN
	ALTER TABLE [expensepayroll] drop constraint PK_expensepayroll
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseprofservice') and constid=object_id('xpkexpenseprofservice'))
BEGIN
	ALTER TABLE [expenseprofservice] drop constraint xpkexpenseprofservice
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseprofservice') and constid=object_id('PK_expenseprofservice'))
BEGIN
	ALTER TABLE [expenseprofservice] drop constraint PK_expenseprofservice
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensesorted') and constid=object_id('xpkexpensesorted'))
BEGIN
	ALTER TABLE [expensesorted] drop constraint xpkexpensesorted
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensesorted') and constid=object_id('PK_expensesorted'))
BEGIN
	ALTER TABLE [expensesorted] drop constraint PK_expensesorted
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

IF exists(SELECT * FROM sysconstraints where id=object_id('expensetotal') and constid=object_id('xpkexpensetotal'))
BEGIN
	ALTER TABLE [expensetotal] drop constraint xpkexpensetotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensetotal') and constid=object_id('PK_expensetotal'))
BEGIN
	ALTER TABLE [expensetotal] drop constraint PK_expensetotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensevar') and constid=object_id('xpkexpensevar'))
BEGIN
	ALTER TABLE [expensevar] drop constraint xpkexpensevar
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensevar') and constid=object_id('PK_expensevar'))
BEGIN
	ALTER TABLE [expensevar] drop constraint PK_expensevar
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expensewageaddition') and constid=object_id('xpkexpensewageaddition'))
BEGIN
	ALTER TABLE [expensewageaddition] drop constraint xpkexpensewageaddition
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expensewageaddition') and constid=object_id('PK_expensewageaddition'))
BEGIN
	ALTER TABLE [expensewageaddition] drop constraint PK_expensewageaddition
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseyear') and constid=object_id('xpkexpenseyear'))
BEGIN
	ALTER TABLE [expenseyear] drop constraint xpkexpenseyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('expenseyear') and constid=object_id('PK_expenseyear'))
BEGIN
	ALTER TABLE [expenseyear] drop constraint PK_expenseyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayexpense') and constid=object_id('xpkivapayexpense'))
BEGIN
	ALTER TABLE [ivapayexpense] drop constraint xpkivapayexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('ivapayexpense') and constid=object_id('PK_ivapayexpense'))
BEGIN
	ALTER TABLE [ivapayexpense] drop constraint PK_ivapayexpense
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

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('xpktaxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] drop constraint xpktaxpayexpense
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('PK_taxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] drop constraint PK_taxpayexpense
END
GO

-- Passo 4.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi12expense' and id=object_id('expense'))
	drop index expense.xi12expense

IF EXISTS (SELECT * FROM sysindexes where name='xi8expense' and id=object_id('expense'))
	drop index expense.xi8expense

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseclawback' and id=object_id('expenseclawback'))
	drop index expenseclawback.xi1expenseclawback

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseinvoice' and id=object_id('expenseinvoice'))
	drop index expenseinvoice.xi2expenseinvoice

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseitineration' and id=object_id('expenseitineration'))
	drop index expenseitineration.xi2expenseitineration
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensemandate' and id=object_id('expensemandate'))
	drop index expensemandate.xi2expensemandate

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensesorted' and id=object_id('expensesorted'))
	drop index expensesorted.xi2expensesorted

IF EXISTS (SELECT * FROM sysindexes where name='xi3expensesorted' and id=object_id('expensesorted'))
	drop index expensesorted.xi3expensesorted

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetax' and id=object_id('expensetax'))
	drop index expensetax.xi1expensetax

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetotal' and id=object_id('expensetotal'))
	drop index expensetotal.xi1expensetotal
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensevar' and id=object_id('expensevar'))
	drop index expensevar.xi1expensevar

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseyear' and id=object_id('expenseyear'))
	drop index expenseyear.xi1expenseyear

IF EXISTS (SELECT * FROM sysindexes where name='xi9income' and id=object_id('income'))
	drop index income.xi9income

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayexpense' and id=object_id('ivapayexpense'))
	drop index ivapayexpense.xi2ivapayexpense

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashexpense' and id=object_id('pettycashexpense'))
	drop index pettycashexpense.xi1pettycashexpense
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6pettycashoperation' and id=object_id('pettycashoperation'))
	drop index pettycashoperation.xi6pettycashoperation

IF EXISTS (SELECT * FROM sysindexes where name='xi2taxpayexpense' and id=object_id('taxpayexpense'))
	drop index taxpayexpense.xi2taxpayexpense
GO

-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='parentidexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN parentidexp
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'parentidexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idformerexpense'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idformerexpense
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idformerexpense'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idpayment'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idpayment
	DELETE FROM columntypes WHERE tablename = 'expense' AND field = 'idpayment'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_appropriation'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_appropriation] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'admpay_appropriation' AND field = 'idexp'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'assetloadexpense' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'banktransaction' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensecasualcontract'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensecasualcontract] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensecasualcontract' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseclawback'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseclawback] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expenseclawback' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expenseinvoice' AND field = 'idexp'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expenseitineration' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensemandate'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensemandate] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensemandate' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensepayroll'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensepayroll] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensepayroll' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseprofservice'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseprofservice] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expenseprofservice' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensesorted' AND field = 'idexp'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetax'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetax] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensetax' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetotal'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetotal] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensetotal' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensevar' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idpayment'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idpayment
	DELETE FROM columntypes WHERE tablename = 'expensevar' AND field = 'idpayment'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensewageaddition'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensewageaddition] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expensewageaddition' AND field = 'idexp'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'expenseyear' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idpayment'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idpayment
	DELETE FROM columntypes WHERE tablename = 'income' AND field = 'idpayment'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idexp_taxable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idexp_taxable
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idexp_taxable'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idexp_iva'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idexp_iva
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idexp_iva'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayexpense'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayexpense] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'ivapayexpense' AND field = 'idexp'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idexp_taxable'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idexp_taxable
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idexp_taxable'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idexp_iva'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idexp_iva
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idexp_iva'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashexpense'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashexpense] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'pettycashexpense' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idexp'
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpayexpense'
		and C.name ='idexp'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpayexpense] DROP COLUMN idexp
	DELETE FROM columntypes WHERE tablename = 'taxpayexpense' AND field = 'idexp'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate expense e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'parentidexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD parentidexp int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN parentidexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idpayment int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idformerexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idformerexpense int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idformerexpense int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_appropriation] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [admpay_appropriation] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [assetloadexpense] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransaction] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [banktransaction] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensecasualcontract' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensecasualcontract] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensecasualcontract] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expenseclawback] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expenseinvoice] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expenseitineration] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensemandate] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensemandate] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensepayroll' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensepayroll] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensepayroll] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseprofservice] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expenseprofservice] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensesorted] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensetax] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetotal] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensetotal] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensevar] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [expensevar] ALTER COLUMN idpayment int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensewageaddition' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensewageaddition] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expensewageaddition] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [expenseyear] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idpayment int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_taxable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idexp_taxable int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idexp_taxable int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idexp_iva int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idexp_iva int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayexpense] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [ivapayexpense] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_taxable' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idexp_taxable int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idexp_taxable int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idexp_iva int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idexp_iva int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [pettycashexpense] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idexp int NULL

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [taxpayexpense] ALTER COLUMN idexp int NULL
GO

-- Passo 6. Valorizzazione nuovo campo

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expense SET idexp = idexpint, parentidexp = parentidexpint, idformerexpense = idformerexpenseint, idpayment = idpaymentint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_appropriation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_appropriation SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetloadexpense SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransaction' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransaction SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensecasualcontract' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensecasualcontract SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseclawback SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseinvoice SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseitineration SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensemandate SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensepayroll' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensepayroll SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseprofservice SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetax SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensetotal SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensevar SET idexp = idexpint, idpayment = idpaymentint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensewageaddition' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensewageaddition SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expenseyear SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idpaymentint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE income SET idpayment = idpaymentint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idexp_taxable = idexp_taxableint, idexp_iva = idexp_ivaint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE ivapayexpense SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idexp_taxableint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idexp_taxable = idexp_taxableint, idexp_iva = idexp_ivaint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashexpense SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idexp = idexpint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'idexpint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxpayexpense SET idexp = idexpint
END
GO

-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetloadexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetloadexpense] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensecasualcontract' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensecasualcontract] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseclawback' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseclawback] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ALTER COLUMN idexp int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensemandate] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensepayroll' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensepayroll] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseprofservice] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetax' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetax] ALTER COLUMN idexp int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetotal] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensewageaddition' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensewageaddition] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseyear' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseyear] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'ivapayexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [ivapayexpense] ALTER COLUMN idexp int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashexpense] ALTER COLUMN idexp int NOT NULL
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxpayexpense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxpayexpense] ALTER COLUMN idexp int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave (NON CI SONO CAMPI NON CHIAVE A NOT NULL)

-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expense') and constid=object_id('xpkexpense'))
BEGIN
	ALTER TABLE [expense] ADD CONSTRAINT xpkexpense PRIMARY KEY (idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('assetloadexpense') and constid=object_id('xpkassetloadexpense'))
BEGIN
	ALTER TABLE [assetloadexpense] ADD CONSTRAINT xpkassetloadexpense PRIMARY KEY (idassetloadkind, yassetload, nassetload, idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensecasualcontract') and constid=object_id('xpkexpensecasualcontract'))
BEGIN
	ALTER TABLE [expensecasualcontract] ADD CONSTRAINT xpkexpensecasualcontract PRIMARY KEY (idexp, ycon, ncon)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseclawback') and constid=object_id('xpkexpenseclawback'))
BEGIN
	ALTER TABLE [expenseclawback] ADD CONSTRAINT xpkexpenseclawback PRIMARY KEY (idexp, idclawback)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseinvoice') and constid=object_id('xpkexpenseinvoice'))
BEGIN
	ALTER TABLE [expenseinvoice] ADD CONSTRAINT xpkexpenseinvoice PRIMARY KEY (idexp, idinvkind, yinv, ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseitineration') and constid=object_id('xpkexpenseitineration'))
BEGIN
	ALTER TABLE [expenseitineration] ADD CONSTRAINT xpkexpenseitineration PRIMARY KEY (idexp, yitineration, nitineration)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensemandate') and constid=object_id('xpkexpensemandate'))
BEGIN
	ALTER TABLE [expensemandate] ADD CONSTRAINT xpkexpensemandate PRIMARY KEY (idexp, idmankind, yman, nman)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensepayroll') and constid=object_id('xpkexpensepayroll'))
BEGIN
	ALTER TABLE [expensepayroll] ADD CONSTRAINT xpkexpensepayroll PRIMARY KEY (idexp, idpayroll)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseprofservice') and constid=object_id('xpkexpenseprofservice'))
BEGIN
	ALTER TABLE [expenseprofservice] ADD CONSTRAINT xpkexpenseprofservice PRIMARY KEY (idexp, ycon, ncon)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensesorted') and constid=object_id('xpkexpensesorted'))
BEGIN
	ALTER TABLE [expensesorted] ADD CONSTRAINT xpkexpensesorted PRIMARY KEY (idsorkind, idsor, idexp, idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensetax') and constid=object_id('xpkexpensetax'))
BEGIN
	ALTER TABLE [expensetax] ADD CONSTRAINT xpkexpensetax PRIMARY KEY (idexp, taxcode, nbracket)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensetotal') and constid=object_id('xpkexpensetotal'))
BEGIN
	ALTER TABLE [expensetotal] ADD CONSTRAINT xpkexpensetotal PRIMARY KEY (idexp, ayear)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensevar') and constid=object_id('xpkexpensevar'))
BEGIN
	ALTER TABLE [expensevar] ADD CONSTRAINT xpkexpensevar PRIMARY KEY (idexp, nvar)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensewageaddition') and constid=object_id('xpkexpensewageaddition'))
BEGIN
	ALTER TABLE [expensewageaddition] ADD CONSTRAINT xpkexpensewageaddition PRIMARY KEY (idexp, ycon, ncon)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expenseyear') and constid=object_id('xpkexpenseyear'))
BEGIN
	ALTER TABLE [expenseyear] ADD CONSTRAINT xpkexpenseyear PRIMARY KEY (idexp, ayear)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('ivapayexpense') and constid=object_id('xpkivapayexpense'))
BEGIN
	ALTER TABLE [ivapayexpense] ADD CONSTRAINT xpkivapayexpense PRIMARY KEY (yivapay, nivapay, idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashexpense') and constid=object_id('xpkpettycashexpense'))
BEGIN
	ALTER TABLE [pettycashexpense] ADD CONSTRAINT xpkpettycashexpense PRIMARY KEY (idpettycash, yoperation, noperation, idexp)
END

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxpayexpense') and constid=object_id('xpktaxpayexpense'))
BEGIN
	ALTER TABLE [taxpayexpense] ADD CONSTRAINT xpktaxpayexpense PRIMARY KEY (taxcode, ytaxpay, ntaxpay, idexp)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi12expense' and id=object_id('expense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi12expense ON expense (parentidexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi12expense
	ON expense (parentidexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8expense' and id=object_id('expense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi8expense ON expense (idpayment)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi8expense
	ON expense (idpayment)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseclawback' and id=object_id('expenseclawback'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseclawback ON expenseclawback (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseclawback
	ON expenseclawback (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseinvoice' and id=object_id('expenseinvoice'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseinvoice ON expenseinvoice (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseinvoice
	ON expenseinvoice (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseitineration' and id=object_id('expenseitineration'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseitineration ON expenseitineration (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenseitineration
	ON expenseitineration (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensemandate' and id=object_id('expensemandate'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensemandate ON expensemandate (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensemandate
	ON expensemandate (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensesorted' and id=object_id('expensesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensesorted ON expensesorted (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expensesorted
	ON expensesorted (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expensesorted' and id=object_id('expensesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3expensesorted ON expensesorted (idexp, ayear)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3expensesorted
	ON expensesorted (idexp, ayear)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetax' and id=object_id('expensetax'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensetax ON expensetax (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensetax
	ON expensetax (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetotal' and id=object_id('expensetotal'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensetotal ON expensetotal (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensetotal
	ON expensetotal (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensevar' and id=object_id('expensevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensevar ON expensevar (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensevar
	ON expensevar (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseyear' and id=object_id('expenseyear'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseyear ON expenseyear (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenseyear
	ON expenseyear (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9income' and id=object_id('income'))
BEGIN
	CREATE NONCLUSTERED INDEX xi9income ON income (idpayment)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi9income
	ON income (idpayment)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayexpense' and id=object_id('ivapayexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapayexpense ON ivapayexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2ivapayexpense
	ON ivapayexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashexpense ON pettycashexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1pettycashexpense
	ON pettycashexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
	CREATE NONCLUSTERED INDEX xi6pettycashoperation ON pettycashoperation (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi6pettycashoperation
	ON pettycashoperation (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2taxpayexpense' and id=object_id('taxpayexpense'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2taxpayexpense ON taxpayexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2taxpayexpense
	ON taxpayexpense (idexp)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_appropriation' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:45.420'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'admpay_appropriation' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('admpay_appropriation','idexp','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-09 10:48:45.420'},'''SARA''','NINO',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetloadexpense' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:12.703'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'assetloadexpense' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('assetloadexpense','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:12.703'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransaction' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-09 10:48:43.343'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'banktransaction' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('banktransaction','idexp','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-09 10:48:43.343'},'''SARA''','SARA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-05-12 11:53:33.343'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expense' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-05-12 11:53:33.343'},'''SA''','NINO',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idformerexpense')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.360'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expense' AND field = 'idformerexpense'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idformerexpense','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:33.360'},'''SA''','NINO',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expense' AND field = 'idpayment')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-05-12 11:53:33.390'},lastmoduser = '''SA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expense' AND field = 'idpayment'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expense','idpayment','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-05-12 11:53:33.390'},'''SA''','NINO',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensecasualcontract' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:09.860'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensecasualcontract' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensecasualcontract','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:09.860'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseclawback' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:07.797'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expenseclawback' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseclawback','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:07.797'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseinvoice' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.860'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expenseinvoice' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseinvoice','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.860'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseitineration' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:18.843'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expenseitineration' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseitineration','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:18.843'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensemandate' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:10.920'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensemandate' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensemandate','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:10.920'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensepayroll' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:17.670'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensepayroll' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensepayroll','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:17.670'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseprofservice' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:00.267'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expenseprofservice' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseprofservice','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:00.267'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesorted' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-16 14:01:07.547'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensesorted' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensesorted','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-16 14:01:07.547'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensetax' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:11.717'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensetax' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensetax','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:11.717'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensetotal' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:14.250'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensetotal' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensetotal','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:14.250'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensevar' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2007-04-20 14:36:29.467'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensevar' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensevar','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2007-04-20 14:36:29.467'},'''SARA''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensevar' AND field = 'idpayment')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-04-20 14:36:29.483'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensevar' AND field = 'idpayment'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensevar','idpayment','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-04-20 14:36:29.483'},'''SARA''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensewageaddition' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:06.610'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expensewageaddition' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expensewageaddition','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:06.610'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseyear' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:02.030'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'expenseyear' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('expenseyear','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:02.030'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'income' AND field = 'idpayment')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-10-12 10:22:08.187'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'income' AND field = 'idpayment'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('income','idpayment','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-10-12 10:22:08.187'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idexp_iva')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.530'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'invoicedetail' AND field = 'idexp_iva'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicedetail','idexp_iva','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.530'},'''SARA''','SARA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idexp_taxable')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.547'},lastmoduser = '''SARA''',createuser = 'SARA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'invoicedetail' AND field = 'idexp_taxable'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('invoicedetail','idexp_taxable','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.547'},'''SARA''','SARA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'ivapayexpense' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:04.017'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'ivapayexpense' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('ivapayexpense','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:04.017'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idexp_iva')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.827'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'mandatedetail' AND field = 'idexp_iva'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('mandatedetail','idexp_iva','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.827'},'''SARA''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idexp_taxable')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2006-12-13 09:32:14.843'},lastmoduser = '''SARA''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'mandatedetail' AND field = 'idexp_taxable'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('mandatedetail','idexp_taxable','N','int','4','','','System.Int32','int','S','','','N',{ts '2006-12-13 09:32:14.843'},'''SARA''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashexpense' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:03.657'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'pettycashexpense' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashexpense','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:03.657'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = '',denynull = 'N',lastmodtimestamp = {ts '2007-07-04 12:14:35.017'},lastmoduser = '''SARA''',createuser = 'NINO',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'pettycashoperation' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('pettycashoperation','idexp','N','int','4','','','System.Int32','int','S','','','N',{ts '2007-07-04 12:14:35.017'},'''SARA''','NINO',{ts '2006-10-09 10:48:45.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxpayexpense' AND field = 'idexp')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = '',col_scale = '',systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = '',denynull = 'S',lastmodtimestamp = {ts '2006-10-12 10:22:15.110'},lastmoduser = '''NINO''',createuser = 'SA',createtimestamp = {ts '2006-10-09 10:48:45.420'} WHERE tablename = 'taxpayexpense' AND field = 'idexp'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp)
VALUES ('taxpayexpense','idexp','S','int','4','','','System.Int32','int','N','','','S',{ts '2006-10-12 10:22:15.110'},'''NINO''','SA',{ts '2006-10-09 10:48:45.420'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='parentidexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN parentidexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idpaymentint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idpaymentint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expense'
		and C.name ='idformerexpenseint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expense] DROP COLUMN idformerexpenseint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_appropriation'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_appropriation] DROP COLUMN idexpint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetloadexpense'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetloadexpense] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransaction'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransaction] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensecasualcontract'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensecasualcontract] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseclawback'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseclawback] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN idexpint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensemandate'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensemandate] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensepayroll'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensepayroll] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseprofservice'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseprofservice] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idexpint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetax'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetax] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetotal'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetotal] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='idpaymentint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN idpaymentint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensewageaddition'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensewageaddition] DROP COLUMN idexpint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'income'
		and C.name ='idpaymentint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [income] DROP COLUMN idpaymentint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idexp_taxableint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idexp_taxableint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name ='idexp_ivaint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idexp_ivaint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'ivapayexpense'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [ivapayexpense] DROP COLUMN idexpint
END
GO
 
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idexp_taxableint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idexp_taxableint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name ='idexp_ivaint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idexp_ivaint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashexpense'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashexpense] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idexpint
END

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxpayexpense'
		and C.name ='idexpint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxpayexpense] DROP COLUMN idexpint
END
GO
