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

﻿-- Passo 6. Valorizzazione nuovo campo
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'miursetup' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE miursetup SET sortcode = sortcodeint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountvardetail SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountyear SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_expensesorted SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_incomesorted SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorkindreg = idsorkindregint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorkindreg = idsorkindregint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransactionsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontractsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE divisionsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE epexpsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET idsorkind = idsorkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET paridsorkind = paridsorkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET idsorkind = idsorkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET paridsorkind = paridsorkindint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytreesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE managersorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontractsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationsorted SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservicesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrysorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicesorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortedmovementtotal SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingapplicability' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingapplicability SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorkindreg = idsorkindregint
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorkindreg = idsorkindregint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortinglevel SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprev SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevexpensevar SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevincomevar SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtotal SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET sortingkindchild = sortingkindchildint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindmaster' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET sortingkindmaster = sortingkindmasterint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageadditionsorting SET idsorkind = idsorkindint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_clawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_clawback = idsorkind_clawbackint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_fin = idsorkind_finint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_registry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_registry = idsorkind_registryint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_service' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_service = idsorkind_serviceint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild1 = idsorkind_sortingchild1int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild2 = idsorkind_sortingchild2int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild3 = idsorkind_sortingchild3int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild4' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild4 = idsorkind_sortingchild4int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild5' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild5 = idsorkind_sortingchild5int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster1 = idsorkind_sortingmaster1int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster2 = idsorkind_sortingmaster2int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster3 = idsorkind_sortingmaster3int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster4' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster4 = idsorkind_sortingmaster4int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster5' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster5 = idsorkind_sortingmaster5int
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_tax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_tax = idsorkind_taxint
END
GO


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_upb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_upb = idsorkind_upbint
END
GO


-- Passo 7. Impostazione campi che diventeranno chiave a NOT NULL e campi che in origine erano settati a NOT NULL
-- Passo 7.1: Campi Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountvardetail] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accountyear] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_expensesorted] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [admpay_incomesorted] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [banktransactionsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [casualcontractsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [clawbacksorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [divisionsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [epexpsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [estimatesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensesorted] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomesorted] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytreesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [invoicesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itinerationsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [managersorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [mandatesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [parasubcontractsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [profservicesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrysorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [servicesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortedmovementtotal] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingapplicability' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingapplicability] ALTER COLUMN idsorkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglevel] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingprev] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtotal] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindchild int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindmaster' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingtranslation] ALTER COLUMN sortingkindmaster int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [taxsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [upbsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [wageadditionsorting] ALTER COLUMN idsorkind int NOT NULL
END
GO

-- Passo 7.2: Campi non Chiave
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'codesorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingkind] ALTER COLUMN codesorkind varchar(20) NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoexpensesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [autoincomesorting] ALTER COLUMN idsorkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingexpensefilter] ALTER COLUMN idsorkind int NOT NULL
END
GO


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortingincomefilter] ALTER COLUMN idsorkind int NOT NULL
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'miursetup' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [miursetup] ALTER COLUMN sortcode int NOT NULL
END
GO



	