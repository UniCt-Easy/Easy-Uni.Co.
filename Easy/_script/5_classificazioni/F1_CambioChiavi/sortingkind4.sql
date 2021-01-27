
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


-- Passo 4.4: Cancellazione dei campi dalle tabelle referenziate
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'miursetup'
		and C.name = 'sortcode'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [miursetup] DROP COLUMN sortcode
	DELETE FROM columntypes WHERE tablename = 'miursetup' AND field = 'sortcode'
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
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorkindreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorkindreg
	DELETE FROM columntypes WHERE tablename = 'autoexpensesorting' AND field = 'idsorkindreg'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorkindreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorkindreg
	DELETE FROM columntypes WHERE tablename = 'autoincomesorting' AND field = 'idsorkindreg'
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
		where t.name = 'sorting'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sorting' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingapplicability'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingapplicability] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingapplicability' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorkindreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorkindreg
	DELETE FROM columntypes WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkindreg'
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorkindreg'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorkindreg
	DELETE FROM columntypes WHERE tablename = 'sortingincomefilter' AND field = 'idsorkindreg'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortingkind' AND field = 'idsorkind'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'sortinglevel' AND field = 'idsorkind'
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
		where t.name = 'taxsortingsetup'
		and C.name = 'idsorkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsorkind
	DELETE FROM columntypes WHERE tablename = 'taxsortingsetup' AND field = 'idsorkind'
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


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_clawback'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_clawback
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_clawback'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_fin'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_fin
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_fin'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_registry'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_registry
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_registry'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_service'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_service
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_service'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild1
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild1'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild2
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild2'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild3
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild3'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild4'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild4
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild4'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild5'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild5
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild5'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster1
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster1'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster2
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster2'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster3
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster3'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster4'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster4
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster4'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster5'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster5
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster5'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_tax'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_tax
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_tax'
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_upb'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_upb
	DELETE FROM columntypes WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_upb'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind1'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind1
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'idsortingkind1'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind2'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind2
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'idsortingkind2'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind3'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind3
	DELETE FROM columntypes WHERE tablename = 'config' AND field = 'idsortingkind3'
END
GO

-- Passo 5. Creazione del nuovo campo (che avrà nome come il vecchio ma con tipo diverso)
-- Tabelle interessate sortingkind e tabelle collegate
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'miursetup' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [miursetup] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [miursetup] ALTER COLUMN sortcode int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [accountsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountvardetail] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [accountvardetail] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountyear] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [accountyear] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [admpay_expensesorted] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [admpay_incomesorted] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ADD idsorkindreg int NULL 
END
ELSE
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorkindreg int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ADD idsorkindreg int NULL 
END
ELSE
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorkindreg int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [banktransactionsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [casualcontractsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [clawbacksorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [divisionsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [epexpsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [epexpsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [estimatesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [expensesorted] ALTER COLUMN idsorkind int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ADD paridsorkind int NULL 
END
ELSE
	ALTER TABLE [expensesorted] ALTER COLUMN paridsorkind int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [finsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [flowchartsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [incomesorted] ALTER COLUMN idsorkind int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ADD paridsorkind int NULL 
END
ELSE
	ALTER TABLE [incomesorted] ALTER COLUMN paridsorkind int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [invoicesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [itinerationsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [locationsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [managersorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [mandatesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [parasubcontractsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [profservicesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrysorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [registrysorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [servicesorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortedmovementtotal] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingapplicability' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingapplicability] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingapplicability] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ADD idsorkindreg int NULL 
END
ELSE
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorkindreg int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ADD idsorkindreg int NULL 
END
ELSE
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorkindreg int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingkind] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglevel] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortinglevel] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprev] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingprev] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevexpensevar] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingprevexpensevar] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprevincomevar] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingprevincomevar] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtotal] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [sortingtotal] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD sortingkindchild int NULL 
END
ELSE
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindchild int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindmaster' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ADD sortingkindmaster int NULL 
END
ELSE
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindmaster int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [taxsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsortingsetup] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [taxsortingsetup] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [upbsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD idsorkind int NULL 
END
ELSE
	ALTER TABLE [wageadditionsorting] ALTER COLUMN idsorkind int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_clawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_clawback int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_clawback int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_fin int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_fin int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_registry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_registry int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_registry int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_service' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_service int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_service int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild1 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild1 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild2 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild2 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild3 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild3 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild4' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild4 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild4 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild5' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingchild5 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingchild5 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster1 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster1 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster2 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster2 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster3 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster3 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster4' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster4 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster4 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster5' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_sortingmaster5 int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_sortingmaster5 int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_tax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_tax int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_tax int NULL 
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_upb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageimportsetup] ADD idsorkind_upb int NULL 
END
ELSE
	ALTER TABLE [wageimportsetup] ALTER COLUMN idsorkind_upb int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind1 int NULL 
END
ELSE
	ALTER TABLE [config] ALTER COLUMN idsortingkind1 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind2 int NULL 
END
ELSE
	ALTER TABLE [config] ALTER COLUMN idsortingkind2 int NULL 
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [config] ADD idsortingkind3 int NULL 
END
ELSE
	ALTER TABLE [config] ALTER COLUMN idsortingkind3 int NULL 
GO
