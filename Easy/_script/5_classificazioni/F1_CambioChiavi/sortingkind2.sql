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

﻿-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingkind' and C.name = 'codesorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingkind SET codesorkind = idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'miursetup' and C.name = 'sortcodeint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE miursetup SET sortcodeint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = miursetup.sortcode
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = accountsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountvardetail SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = accountvardetail.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountyear SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = accountyear.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_expensesorted SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = admpay_expensesorted.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_incomesorted SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = admpay_incomesorted.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = autoexpensesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorkindregint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = autoexpensesorting.idsorkindreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = autoincomesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorkindregint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = autoincomesorting.idsorkindreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransactionsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = banktransactionsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontractsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = casualcontractsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = clawbacksorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE divisionsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = divisionsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE epexpsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = epexpsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = estimatesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = expensesorted.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET paridsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = expensesorted.paridsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = finsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = flowchartsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = incomesorted.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET paridsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = incomesorted.paridsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytreesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = inventorytreesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = invoicesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = itinerationsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = locationsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE managersorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = managersorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = mandatesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontractsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = parasubcontractsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationsorted SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = pettycashoperationsorted.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservicesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = profservicesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrysorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = registrysorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicesorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = servicesorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortedmovementtotal SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortedmovementtotal.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingapplicability' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingapplicability SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingapplicability.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingexpensefilter.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorkindregint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingexpensefilter.idsorkindreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingincomefilter.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorkindregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorkindregint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingincomefilter.idsorkindreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglevel' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortinglevel SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortinglevel.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprev SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingprev.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevexpensevar SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingprevexpensevar.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevincomevar SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingprevincomevar.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtotal SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingtotal.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = taxsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = taxsortingsetup.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = upbsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageadditionsorting SET idsorkindint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageadditionsorting.idsorkind
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE config SET idsortingkind1int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = config.idsortingkind1
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE config SET idsortingkind2int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = config.idsortingkind2
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'config' and C.name = 'idsortingkind3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE config SET idsortingkind3int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = config.idsortingkind3
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindchildint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET sortingkindchildint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingtranslation.sortingkindchild
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'sortingkindmasterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET sortingkindmasterint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = sortingtranslation.sortingkindmaster
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_clawbackint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_clawbackint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_clawback
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_finint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_finint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_fin
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_registryint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_registryint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_registry
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_serviceint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_serviceint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_service
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_taxint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_taxint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_tax
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_upbint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_upbint = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_upb
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild1int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingchild1
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild2int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingchild2
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild3int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingchild3
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild4int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild4int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingchild4
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingchild5int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingchild5int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingchild5
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster1int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingmaster1
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster2int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingmaster2
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster3int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingmaster3
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster4int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster4int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingmaster4
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageimportsetup' and C.name = 'idsorkind_sortingmaster5int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageimportsetup SET idsorkind_sortingmaster5int = sortingkind.idsorkindint
	FROM sortingkind
	WHERE sortingkind.idsorkind = wageimportsetup.idsorkind_sortingmaster5
END
GO
	