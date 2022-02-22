
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


-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'accountsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountvardetail'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountvardetail] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'accountvardetail' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountyear'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountyear] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'accountyear' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expensesorted'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expensesorted] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'admpay_expensesorted' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_incomesorted'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_incomesorted] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'admpay_incomesorted' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'assetacquire' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorreg
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idsorreg'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorreg
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idsorreg'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransactionsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransactionsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'banktransactionsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'casualcontract' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'casualcontract' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'casualcontract' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontractsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontractsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'casualcontractsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'clawbacksorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'divisionsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'entrydetail' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'entrydetail' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'entrydetail' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'epexpsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [epexpsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'epexpsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'estimatedetail' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'estimatesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'expensesorted' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'paridsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN paridsor
	DELETE FROM columntypes WHERE tablename = 'expensesorted' AND field = 'paridsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'finsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'flowchartsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'incomesorted' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'paridsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN paridsor
	DELETE FROM columntypes WHERE tablename = 'incomesorted' AND field = 'paridsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'inventorytreesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'invoicedetail' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'invoicesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'itineration' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'itineration' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'itineration' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'itinerationsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'locationsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'managersorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'mandatedetail' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'mandatesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'parasubcontract' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'parasubcontract' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'parasubcontract' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontractsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontractsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'parasubcontractsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'pettycashoperation' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationsorted' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'profservice' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'profservicesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrysorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrysorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'registrysorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'servicesorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortedmovementtotal'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortedmovementtotal] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortedmovementtotal' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sorting'
		and C.name = 'paridsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN paridsor
	DELETE FROM columntypes WHERE tablename = 'sorting' AND field = 'paridsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorreg
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idsorreg'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorreg
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idsorreg'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprev'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprev] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingprev' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevexpensevar'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevexpensevar] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingprevexpensevar' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevincomevar'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevincomevar] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingprevincomevar' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtotal'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtotal] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'sortingtotal' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'idsortingchild'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN idsortingchild
	DELETE FROM columntypes WHERE tablename = 'sortingtranslation' AND field = 'idsortingchild'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'idsortingmaster'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN idsortingmaster
	DELETE FROM columntypes WHERE tablename = 'sortingtranslation' AND field = 'idsortingmaster'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'taxsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_adminpay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_adminpay
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminpay'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_adminproc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_adminproc
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminproc'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_employproc'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_employproc
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idsor_employproc'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_taxpay'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_taxpay
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idsor_taxpay'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'upbsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor1
	DELETE FROM columntypes WHERE tablename = 'wageaddition' AND field = 'idsor1'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor2
	DELETE FROM columntypes WHERE tablename = 'wageaddition' AND field = 'idsor2'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor3
	DELETE FROM columntypes WHERE tablename = 'wageaddition' AND field = 'idsor3'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditionsorting'
		and C.name = 'idsor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditionsorting] DROP COLUMN idsor
	DELETE FROM columntypes WHERE tablename = 'wageadditionsorting' AND field = 'idsor'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'accountsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountvardetail'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountvardetail] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'accountvardetail' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountyear'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountyear] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'accountyear' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expensesorted'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expensesorted] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'admpay_expensesorted' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_incomesorted'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_incomesorted] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'admpay_incomesorted' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransactionsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransactionsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'banktransactionsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontractsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontractsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'casualcontractsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'clawbacksorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'divisionsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'epexpsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [epexpsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'epexpsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'estimatesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'expensesorted' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'paridsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN paridsorkind
	DELETE FROM columntypes WHERE tablename = 'expensesorted' AND field = 'paridsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'finsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'flowchartsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'incomesorted' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'paridsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN paridsorkind
	DELETE FROM columntypes WHERE tablename = 'incomesorted' AND field = 'paridsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'inventorytreesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'invoicesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'itinerationsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'locationsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'managersorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'mandatesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontractsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontractsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'parasubcontractsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationsorted' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'profservicesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrysorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrysorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'registrysorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'servicesorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortedmovementtotal'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortedmovementtotal] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortedmovementtotal' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprev'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprev] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingprev' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevexpensevar'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevexpensevar] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingprevexpensevar' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevincomevar'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevincomevar] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingprevincomevar' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtotal'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtotal] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingtotal' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'sortingkindchild'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN sortingkindchild
	DELETE FROM columntypes WHERE tablename = 'sortingtranslation' AND field = 'sortingkindchild'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'sortingkindmaster'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN sortingkindmaster
	DELETE FROM columntypes WHERE tablename = 'sortingtranslation' AND field = 'sortingkindmaster'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'taxsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'upbsorting' AND field = 'idsorkind'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditionsorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditionsorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'wageadditionsorting' AND field = 'idsorkind'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate foreigncountry e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [accountsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountvardetail] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [accountvardetail] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountyear] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [accountyear] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [admpay_expensesorted] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [admpay_incomesorted] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetacquire] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [assetacquire] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorreg int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorreg int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorreg int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorreg int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [banktransactionsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [casualcontract] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [casualcontract] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontract] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [casualcontract] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [casualcontractsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [clawbacksorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [divisionsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [entrydetail] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [entrydetail] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [entrydetail] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [entrydetail] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [epexpsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [epexpsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatedetail] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [estimatedetail] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [estimatesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [expensesorted] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD paridsor int NULL 
END
ELSE
	ALTER TABLE [expensesorted] ALTER COLUMN paridsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [finsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [flowchartsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [incomesorted] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD paridsor int NULL 
END
ELSE
	ALTER TABLE [incomesorted] ALTER COLUMN paridsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicedetail] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [invoicedetail] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [invoicesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [itinerationsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [locationsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [managersorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatedetail] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [mandatedetail] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [mandatesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontract] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [parasubcontract] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [parasubcontractsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperation] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [pettycashoperation] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservice] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [profservice] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [profservicesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrysorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [registrysorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [servicesorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortedmovementtotal] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'paridsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD paridsor int NULL 
END
ELSE
	ALTER TABLE [sorting] ALTER COLUMN paridsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorreg int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorreg int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorreg int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorreg int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprev] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingprev] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevexpensevar] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingprevexpensevar] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevincomevar] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingprevincomevar] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtotal] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [sortingtotal] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD idsortingchild int NULL 
END
ELSE
	ALTER TABLE [sortingtranslation] ALTER COLUMN idsortingchild int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingmaster' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD idsortingmaster int NULL 
END
ELSE
	ALTER TABLE [sortingtranslation] ALTER COLUMN idsortingmaster int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [taxsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_adminpay int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_adminpay int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminproc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_adminproc int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_adminproc int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_employproc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_employproc int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_employproc int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_taxpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsor_taxpay int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsor_taxpay int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [upbsorting] ALTER COLUMN idsor int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [wageaddition] ALTER COLUMN idsor1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [wageaddition] ALTER COLUMN idsor2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageaddition] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [wageaddition] ALTER COLUMN idsor3 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD idsor int NULL 
END
ELSE
	ALTER TABLE [wageadditionsorting] ALTER COLUMN idsor int NULL 
GO

