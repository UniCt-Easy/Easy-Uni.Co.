
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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



-- Passo 4. Rimozione chiavi, indici, trigger e campo
-- Passo 4.1: Chiavi
-- Tabelle interessate sono ivakind
IF exists(SELECT * FROM sysconstraints where id=object_id('sortingkind') and constid=object_id('xpksortingkind'))
BEGIN
	ALTER TABLE [sortingkind] drop constraint xpksortingkind
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingkind') and constid=object_id('PK_sortingkind'))
BEGIN
	ALTER TABLE [sortingkind] drop constraint PK_sortingkind
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('accountsorting') and constid=object_id('xpkaccountsorting'))
BEGIN
	ALTER TABLE [accountsorting] drop constraint xpkaccountsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('accountsorting') and constid=object_id('PK_accountsorting'))
BEGIN
	ALTER TABLE [accountsorting] drop constraint PK_accountsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('accountvardetail') and constid=object_id('xpkaccountvardetail'))
BEGIN
	ALTER TABLE [accountvardetail] drop constraint xpkaccountvardetail
END

IF exists(SELECT * FROM sysconstraints where id=object_id('accountvardetail') and constid=object_id('PK_accountvardetail'))
BEGIN
	ALTER TABLE [accountvardetail] drop constraint PK_accountvardetail
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('accountyear') and constid=object_id('xpkaccountyear'))
BEGIN
	ALTER TABLE [accountyear] drop constraint xpkaccountyear
END

IF exists(SELECT * FROM sysconstraints where id=object_id('accountyear') and constid=object_id('PK_accountyear'))
BEGIN
	ALTER TABLE [accountyear] drop constraint PK_accountyear
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_expensesorted') and constid=object_id('xpkadmpay_expensesorted'))
BEGIN
	ALTER TABLE [admpay_expensesorted] drop constraint xpkadmpay_expensesorted
END

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_expensesorted') and constid=object_id('PK_admpay_expensesorted'))
BEGIN
	ALTER TABLE [admpay_expensesorted] drop constraint PK_admpay_expensesorted
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_incomesorted') and constid=object_id('xpkadmpay_incomesorted'))
BEGIN
	ALTER TABLE [admpay_incomesorted] drop constraint xpkadmpay_incomesorted
END

IF exists(SELECT * FROM sysconstraints where id=object_id('admpay_incomesorted') and constid=object_id('PK_admpay_incomesorted'))
BEGIN
	ALTER TABLE [admpay_incomesorted] drop constraint PK_admpay_incomesorted
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('xpkbanktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] drop constraint xpkbanktransactionsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('PK_banktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] drop constraint PK_banktransactionsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontractsorting') and constid=object_id('xpkcasualcontractsorting'))
BEGIN
	ALTER TABLE [casualcontractsorting] drop constraint xpkcasualcontractsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('casualcontractsorting') and constid=object_id('PK_casualcontractsorting'))
BEGIN
	ALTER TABLE [casualcontractsorting] drop constraint PK_casualcontractsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('xpkclawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] drop constraint xpkclawbacksorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('PK_clawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] drop constraint PK_clawbacksorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('xpkdivisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] drop constraint xpkdivisionsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('PK_divisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] drop constraint PK_divisionsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('epexpsorting') and constid=object_id('xpkepexpsorting'))
BEGIN
	ALTER TABLE [epexpsorting] drop constraint xpkepexpsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('epexpsorting') and constid=object_id('PK_epexpsorting'))
BEGIN
	ALTER TABLE [epexpsorting] drop constraint PK_epexpsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('estimatesorting') and constid=object_id('xpkestimatesorting'))
BEGIN
	ALTER TABLE [estimatesorting] drop constraint xpkestimatesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('estimatesorting') and constid=object_id('PK_estimatesorting'))
BEGIN
	ALTER TABLE [estimatesorting] drop constraint PK_estimatesorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('xpkfinsorting'))
BEGIN
	ALTER TABLE [finsorting] drop constraint xpkfinsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('PK_finsorting'))
BEGIN
	ALTER TABLE [finsorting] drop constraint PK_finsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartsorting') and constid=object_id('xpkflowchartsorting'))
BEGIN
	ALTER TABLE [flowchartsorting] drop constraint xpkflowchartsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('flowchartsorting') and constid=object_id('PK_flowchartsorting'))
BEGIN
	ALTER TABLE [flowchartsorting] drop constraint PK_flowchartsorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('xpkinventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] drop constraint xpkinventorytreesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('PK_inventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] drop constraint PK_inventorytreesorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('xpkinvoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] drop constraint xpkinvoicesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('PK_invoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] drop constraint PK_invoicesorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('xpklocationsorting'))
BEGIN
	ALTER TABLE [locationsorting] drop constraint xpklocationsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('PK_locationsorting'))
BEGIN
	ALTER TABLE [locationsorting] drop constraint PK_locationsorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('mandatesorting') and constid=object_id('xpkmandatesorting'))
BEGIN
	ALTER TABLE [mandatesorting] drop constraint xpkmandatesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('mandatesorting') and constid=object_id('PK_mandatesorting'))
BEGIN
	ALTER TABLE [mandatesorting] drop constraint PK_mandatesorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('parasubcontractsorting') and constid=object_id('xpkparasubcontractsorting'))
BEGIN
	ALTER TABLE [parasubcontractsorting] drop constraint xpkparasubcontractsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('parasubcontractsorting') and constid=object_id('PK_parasubcontractsorting'))
BEGIN
	ALTER TABLE [parasubcontractsorting] drop constraint PK_parasubcontractsorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('profservicesorting') and constid=object_id('xpkprofservicesorting'))
BEGIN
	ALTER TABLE [profservicesorting] drop constraint xpkprofservicesorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('profservicesorting') and constid=object_id('PK_profservicesorting'))
BEGIN
	ALTER TABLE [profservicesorting] drop constraint PK_profservicesorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('registrysorting') and constid=object_id('xpkregistrysorting'))
BEGIN
	ALTER TABLE [registrysorting] drop constraint xpkregistrysorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('registrysorting') and constid=object_id('PK_registrysorting'))
BEGIN
	ALTER TABLE [registrysorting] drop constraint PK_registrysorting
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

IF exists(SELECT * FROM sysconstraints where id=object_id('sortedmovementtotal') and constid=object_id('xpksortedmovementtotal'))
BEGIN
	ALTER TABLE [sortedmovementtotal] drop constraint xpksortedmovementtotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortedmovementtotal') and constid=object_id('PK_sortedmovementtotal'))
BEGIN
	ALTER TABLE [sortedmovementtotal] drop constraint PK_sortedmovementtotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sorting') and constid=object_id('xpksorting'))
BEGIN
	ALTER TABLE [sorting] drop constraint xpksorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sorting') and constid=object_id('PK_sorting'))
BEGIN
	ALTER TABLE [sorting] drop constraint PK_sorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingapplicability') and constid=object_id('xpksortingapplicability'))
BEGIN
	ALTER TABLE [sortingapplicability] drop constraint xpksortingapplicability
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingapplicability') and constid=object_id('PK_sortingapplicability'))
BEGIN
	ALTER TABLE [sortingapplicability] drop constraint PK_sortingapplicability
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingincometotal') and constid=object_id('xpksortingincometotal'))
BEGIN
	ALTER TABLE [sortingincometotal] drop constraint xpksortingincometotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingincometotal') and constid=object_id('PK_sortingincometotal'))
BEGIN
	ALTER TABLE [sortingincometotal] drop constraint PK_sortingincometotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortinglevel') and constid=object_id('xpksortinglevel'))
BEGIN
	ALTER TABLE [sortinglevel] drop constraint xpksortinglevel
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortinglevel') and constid=object_id('PK_sortinglevel'))
BEGIN
	ALTER TABLE [sortinglevel] drop constraint PK_sortinglevel
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingprev') and constid=object_id('xpksortingprev'))
BEGIN
	ALTER TABLE [sortingprev] drop constraint xpksortingprev
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingprev') and constid=object_id('PK_sortingprev'))
BEGIN
	ALTER TABLE [sortingprev] drop constraint PK_sortingprev
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingtotal') and constid=object_id('xpksortingtotal'))
BEGIN
	ALTER TABLE [sortingtotal] drop constraint xpksortingtotal
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingtotal') and constid=object_id('PK_sortingtotal'))
BEGIN
	ALTER TABLE [sortingtotal] drop constraint PK_sortingtotal
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('xpktaxsorting'))
BEGIN
	ALTER TABLE [taxsorting] drop constraint xpktaxsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('PK_taxsorting'))
BEGIN
	ALTER TABLE [taxsorting] drop constraint PK_taxsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('upbsorting') and constid=object_id('xpkupbsorting'))
BEGIN
	ALTER TABLE [upbsorting] drop constraint xpkupbsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('upbsorting') and constid=object_id('PK_upbsorting'))
BEGIN
	ALTER TABLE [upbsorting] drop constraint PK_upbsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('wageadditionsorting') and constid=object_id('xpkwageadditionsorting'))
BEGIN
	ALTER TABLE [wageadditionsorting] drop constraint xpkwageadditionsorting
END

IF exists(SELECT * FROM sysconstraints where id=object_id('wageadditionsorting') and constid=object_id('PK_wageadditionsorting'))
BEGIN
	ALTER TABLE [wageadditionsorting] drop constraint PK_wageadditionsorting
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingtranslation') and constid=object_id('xpksortingtranslation'))
BEGIN
	ALTER TABLE [sortingtranslation] drop constraint xpksortingtranslation
END

IF exists(SELECT * FROM sysconstraints where id=object_id('sortingtranslation') and constid=object_id('PK_sortingtranslation'))
BEGIN
	ALTER TABLE [sortingtranslation] drop constraint PK_sortingtranslation
END
GO

-- Passo 4.2: Indici
-- Tabelle interessate sono invoicedetail
IF EXISTS (SELECT * FROM sysindexes where name='xi1divisionsorting' and id=object_id('divisionsorting'))
	drop index divisionsorting.xi1divisionsorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesorted' and id=object_id('expensesorted'))
	drop index expensesorted.xi1expensesorted
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1finsorting' and id=object_id('finsorting'))
	drop index finsorting.xi1finsorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1incomesorted' and id=object_id('incomesorted'))
	drop index incomesorted.xi1incomesorted
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytreesorting' and id=object_id('inventorytreesorting'))
	drop index inventorytreesorting.xi1inventorytreesorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi3inventorytreesorting' and id=object_id('inventorytreesorting'))
	drop index inventorytreesorting.xi3inventorytreesorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1locationsorting' and id=object_id('locationsorting'))
	drop index locationsorting.xi1locationsorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi3locationsorting' and id=object_id('locationsorting'))
	drop index locationsorting.xi3locationsorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1managersorting' and id=object_id('managersorting'))
	drop index managersorting.xi1managersorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1registrysorting' and id=object_id('registrysorting'))
	drop index registrysorting.xi1registrysorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sortedmovementtotal' and id=object_id('sortedmovementtotal'))
	drop index sortedmovementtotal.xi1sortedmovementtotal
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sorting' and id=object_id('sorting'))
	drop index sorting.xi1sorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi2sorting' and id=object_id('sorting'))
	drop index sorting.xi2sorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi3sorting' and id=object_id('sorting'))
	drop index sorting.xi3sorting
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sortinglevel' and id=object_id('sortinglevel'))
	drop index sortinglevel.xi1sortinglevel
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprev' and id=object_id('sortingprev'))
	drop index sortingprev.xi1sortingprev
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevexpensevar' and id=object_id('sortingprevexpensevar'))
	drop index sortingprevexpensevar.xi1sortingprevexpensevar
GO
IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevincomevar' and id=object_id('sortingprevincomevar'))
	drop index sortingprevincomevar.xi1sortingprevincomevar
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_sorting' and id=object_id('sorting'))
	drop index sorting.UQ_1_sorting
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_sortinglevel' and id=object_id('sortinglevel'))
	drop index sortinglevel.UQ_1_sortinglevel
GO
