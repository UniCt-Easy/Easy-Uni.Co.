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

﻿-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountsorting') and constid=object_id('xpkaccountsorting'))
BEGIN
	ALTER TABLE [accountsorting] ADD CONSTRAINT xpkaccountsorting PRIMARY KEY (idsorkind,idsor,idacc)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountvardetail') and constid=object_id('xpkaccountvardetail'))
BEGIN
	ALTER TABLE [accountvardetail] ADD CONSTRAINT xpkaccountvardetail PRIMARY KEY (yvar,nvar,idacc,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountyear') and constid=object_id('xpkaccountyear'))
BEGIN
	ALTER TABLE [accountyear] ADD CONSTRAINT xpkaccountyear PRIMARY KEY (idacc,idsor,idsorkind)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_expensesorted') and constid=object_id('xpkadmpay_expensesorted'))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD CONSTRAINT xpkadmpay_expensesorted PRIMARY KEY (yadmpay,nadmpay,nexpense,idsorkind,idsor,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_incomesorted') and constid=object_id('xpkadmpay_incomesorted'))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD CONSTRAINT xpkadmpay_incomesorted PRIMARY KEY (yadmpay,nadmpay,nincome,idsorkind,idsor,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('xpkbanktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD CONSTRAINT xpkbanktransactionsorting PRIMARY KEY (yban,nban,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('casualcontractsorting') and constid=object_id('xpkcasualcontractsorting'))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD CONSTRAINT xpkcasualcontractsorting PRIMARY KEY (idsorkind,ycon,idsor,ncon)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('xpkclawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] ADD CONSTRAINT xpkclawbacksorting PRIMARY KEY (idclawback,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('xpkdivisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] ADD CONSTRAINT xpkdivisionsorting PRIMARY KEY (idsorkind,idsor,iddivision)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('epexpsorting') and constid=object_id('xpkepexpsorting'))
BEGIN
	ALTER TABLE [epexpsorting] ADD CONSTRAINT xpkepexpsorting PRIMARY KEY (yepexp,nepexp,idsorkind,idsor,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('estimatesorting') and constid=object_id('xpkestimatesorting'))
BEGIN
	ALTER TABLE [estimatesorting] ADD CONSTRAINT xpkestimatesorting PRIMARY KEY (idsorkind,idsor,idestimkind,yestim,nestim)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensesorted') and constid=object_id('xpkexpensesorted'))
BEGIN
	ALTER TABLE [expensesorted] ADD CONSTRAINT xpkexpensesorted PRIMARY KEY (idsorkind,idsor,idexp,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('xpkfinsorting'))
BEGIN
	ALTER TABLE [finsorting] ADD CONSTRAINT xpkfinsorting PRIMARY KEY (idfin,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('flowchartsorting') and constid=object_id('xpkflowchartsorting'))
BEGIN
	ALTER TABLE [flowchartsorting] ADD CONSTRAINT xpkflowchartsorting PRIMARY KEY (idsorkind,idsor,idflowchart)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomesorted') and constid=object_id('xpkincomesorted'))
BEGIN
	ALTER TABLE [incomesorted] ADD CONSTRAINT xpkincomesorted PRIMARY KEY (idsorkind,idsor,idinc,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('xpkinventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD CONSTRAINT xpkinventorytreesorting PRIMARY KEY (idsorkind,idsor,idinv)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('xpkinvoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] ADD CONSTRAINT xpkinvoicesorting PRIMARY KEY (idsorkind,idsor,idinvkind,yinv,ninv)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationsorting') and constid=object_id('xpkitinerationsorting'))
BEGIN
	ALTER TABLE [itinerationsorting] ADD CONSTRAINT xpkitinerationsorting PRIMARY KEY (idsorkind,yitineration,idsor,nitineration)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('xpklocationsorting'))
BEGIN
	ALTER TABLE [locationsorting] ADD CONSTRAINT xpklocationsorting PRIMARY KEY (idsorkind,idsor,idlocation)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('managersorting') and constid=object_id('xpkmanagersorting'))
BEGIN
	ALTER TABLE [managersorting] ADD CONSTRAINT xpkmanagersorting PRIMARY KEY (idman,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('mandatesorting') and constid=object_id('xpkmandatesorting'))
BEGIN
	ALTER TABLE [mandatesorting] ADD CONSTRAINT xpkmandatesorting PRIMARY KEY (idsorkind,idsor,idmankind,yman,nman)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('parasubcontractsorting') and constid=object_id('xpkparasubcontractsorting'))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD CONSTRAINT xpkparasubcontractsorting PRIMARY KEY (idsorkind,idsor,idcon)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationsorted') and constid=object_id('xpkpettycashoperationsorted'))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD CONSTRAINT xpkpettycashoperationsorted PRIMARY KEY (idpettycash,yoperation,noperation,idsorkind,idsor,idsubclass)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('profservicesorting') and constid=object_id('xpkprofservicesorting'))
BEGIN
	ALTER TABLE [profservicesorting] ADD CONSTRAINT xpkprofservicesorting PRIMARY KEY (idsorkind,ycon,idsor,ncon)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('registrysorting') and constid=object_id('xpkregistrysorting'))
BEGIN
	ALTER TABLE [registrysorting] ADD CONSTRAINT xpkregistrysorting PRIMARY KEY (idsorkind,idsor,idreg)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('servicesorting') and constid=object_id('xpkservicesorting'))
BEGIN
	ALTER TABLE [servicesorting] ADD CONSTRAINT xpkservicesorting PRIMARY KEY (idser,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortedmovementtotal') and constid=object_id('xpksortedmovementtotal'))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD CONSTRAINT xpksortedmovementtotal PRIMARY KEY (idsorkind,idsor,ayear)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sorting') and constid=object_id('xpksorting'))
BEGIN
	ALTER TABLE [sorting] ADD CONSTRAINT xpksorting PRIMARY KEY (idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingapplicability') and constid=object_id('xpksortingapplicability'))
BEGIN
	ALTER TABLE [sortingapplicability] ADD CONSTRAINT xpksortingapplicability PRIMARY KEY (idsorkind,tablename)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingkind') and constid=object_id('xpksortingkind'))
BEGIN
	ALTER TABLE [sortingkind] ADD CONSTRAINT xpksortingkind PRIMARY KEY (idsorkind)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortinglevel') and constid=object_id('xpksortinglevel'))
BEGIN
	ALTER TABLE [sortinglevel] ADD CONSTRAINT xpksortinglevel PRIMARY KEY (nlevel,idsorkind)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingprev') and constid=object_id('xpksortingprev'))
BEGIN
	ALTER TABLE [sortingprev] ADD CONSTRAINT xpksortingprev PRIMARY KEY (idsorkind,idsor,ayear)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingtotal') and constid=object_id('xpksortingtotal'))
BEGIN
	ALTER TABLE [sortingtotal] ADD CONSTRAINT xpksortingtotal PRIMARY KEY (idacc,idsor,idsorkind)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingtranslation') and constid=object_id('xpksortingtranslation'))
BEGIN
	ALTER TABLE [sortingtranslation] ADD CONSTRAINT xpksortingtranslation PRIMARY KEY (sortingkindmaster,sortingkindchild,idsortingchild,idsortingmaster)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('xpktaxsorting'))
BEGIN
	ALTER TABLE [taxsorting] ADD CONSTRAINT xpktaxsorting PRIMARY KEY (taxcode,idsorkind,idsor)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbsorting') and constid=object_id('xpkupbsorting'))
BEGIN
	ALTER TABLE [upbsorting] ADD CONSTRAINT xpkupbsorting PRIMARY KEY (idsorkind,idsor,idupb)
END
GO


IF NOT exists(SELECT * FROM sysconstraints where id=object_id('wageadditionsorting') and constid=object_id('xpkwageadditionsorting'))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD CONSTRAINT xpkwageadditionsorting PRIMARY KEY (idsorkind,ycon,idsor,ncon)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingkind') and constid=object_id('uksortingkind'))
BEGIN
	ALTER TABLE [sortingkind] ADD CONSTRAINT uksortingkind UNIQUE (codesorkind)
END
GO

IF exists(SELECT * FROM sysconstraints where id=object_id('sorting') and constid=object_id('UQ_1_sorting'))
BEGIN
	ALTER TABLE [sorting] ADD CONSTRAINT UQ_1_sorting UNIQUE (idsorkind, sortcode)
END
GO


IF exists(SELECT * FROM sysconstraints where id=object_id('sortinglevel') and constid=object_id('UQ_1_sortinglevel'))
BEGIN
	ALTER TABLE [sortinglevel] ADD CONSTRAINT UQ_1_sortinglevel UNIQUE (description, idsorkind)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi3sortingkind' and id=object_id('sortingkind'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3sortingkind ON sortingkind (codesorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3sortingkind
	ON sortingkind (codesorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysindexes where name='xi1divisionsorting' and id=object_id('divisionsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1divisionsorting ON divisionsorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1divisionsorting
	ON divisionsorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesorted' and id=object_id('expensesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesorted ON expensesorted(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesorted
	ON expensesorted (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finsorting' and id=object_id('finsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1finsorting ON finsorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1finsorting
	ON finsorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1incomesorted' and id=object_id('incomesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomesorted ON incomesorted(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomesorted
	ON incomesorted (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytreesorting ON inventorytreesorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytreesorting
	ON inventorytreesorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3inventorytreesorting ON inventorytreesorting(idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3inventorytreesorting
	ON inventorytreesorting (idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1locationsorting' and id=object_id('locationsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1locationsorting ON locationsorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1locationsorting
	ON locationsorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi3locationsorting' and id=object_id('locationsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3locationsorting ON locationsorting(idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3locationsorting
	ON locationsorting (idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1managersorting' and id=object_id('managersorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1managersorting ON managersorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1managersorting
	ON managersorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1registrysorting' and id=object_id('registrysorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrysorting ON registrysorting(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrysorting
	ON registrysorting (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortedmovementtotal' and id=object_id('sortedmovementtotal'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortedmovementtotal ON sortedmovementtotal(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortedmovementtotal
	ON sortedmovementtotal (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sorting' and id=object_id('sorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sorting ON sorting(idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sorting
	ON sorting (idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi2sorting' and id=object_id('sorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2sorting ON sorting(idsorkind,paridsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2sorting
	ON sorting (idsorkind,paridsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi3sorting' and id=object_id('sorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi3sorting ON sorting(nlevel,idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi3sorting
	ON sorting (nlevel,idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortinglevel' and id=object_id('sortinglevel'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortinglevel ON sortinglevel(idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortinglevel
	ON sortinglevel (idsorkind)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprev' and id=object_id('sortingprev'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprev ON sortingprev(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprev
	ON sortingprev (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevexpensevar' and id=object_id('sortingprevexpensevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar ON sortingprevexpensevar(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar
	ON sortingprevexpensevar (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevincomevar' and id=object_id('sortingprevincomevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevincomevar ON sortingprevincomevar(idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevincomevar
	ON sortingprevincomevar (idsorkind,idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'miursetup' AND field = 'sortcode')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:02.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.920'} WHERE tablename = 'miursetup' AND field = 'sortcode'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('miursetup','sortcode','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:02.920'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:56.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:56.420'} WHERE tablename = 'accountsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:56.420'},'''NINO''','NINO',{ts '2007-11-23 13:56:56.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountvardetail' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:03.607'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:03.607'} WHERE tablename = 'accountvardetail' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountvardetail','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:03.607'},'''NINO''','NINO',{ts '2007-11-23 13:57:03.607'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountyear' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:04.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:04.797'} WHERE tablename = 'accountyear' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountyear','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:04.797'},'''NINO''','NINO',{ts '2007-11-23 13:57:04.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_expensesorted' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:04.077'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:04.077'} WHERE tablename = 'admpay_expensesorted' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('admpay_expensesorted','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:04.077'},'''NINO''','NINO',{ts '2007-11-23 13:57:04.077'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_incomesorted' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:02.000'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.000'} WHERE tablename = 'admpay_incomesorted' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('admpay_incomesorted','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:02.000'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.000'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:02.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.920'} WHERE tablename = 'autoexpensesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoexpensesorting','idsorkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:02.920'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idsorkindreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:57:02.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.920'} WHERE tablename = 'autoexpensesorting' AND field = 'idsorkindreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoexpensesorting','idsorkindreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:57:02.920'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:03.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:03.233'} WHERE tablename = 'autoincomesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoincomesorting','idsorkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:03.233'},'''NINO''','NINO',{ts '2007-11-23 13:57:03.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idsorkindreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:57:03.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:03.233'} WHERE tablename = 'autoincomesorting' AND field = 'idsorkindreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoincomesorting','idsorkindreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:57:03.233'},'''NINO''','NINO',{ts '2007-11-23 13:57:03.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransactionsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:59.687'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:59.687'} WHERE tablename = 'banktransactionsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('banktransactionsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:59.687'},'''NINO''','NINO',{ts '2007-11-23 13:56:59.687'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontractsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:05.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:05.500'} WHERE tablename = 'casualcontractsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('casualcontractsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:05.500'},'''NINO''','NINO',{ts '2007-11-23 13:57:05.500'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawbacksorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:50.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.530'} WHERE tablename = 'clawbacksorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('clawbacksorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:50.530'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'divisionsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:51.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:51.420'} WHERE tablename = 'divisionsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('divisionsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:51.420'},'''NINO''','NINO',{ts '2007-11-23 13:56:51.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'epexpsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:53.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.420'} WHERE tablename = 'epexpsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('epexpsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:53.420'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:57.373'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:57.373'} WHERE tablename = 'estimatesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:57.373'},'''NINO''','NINO',{ts '2007-11-23 13:56:57.373'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesorted' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:56.733'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:56.733'} WHERE tablename = 'expensesorted' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensesorted','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:56.733'},'''NINO''','NINO',{ts '2007-11-23 13:56:56.733'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesorted' AND field = 'paridsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'expensesorted' AND field = 'paridsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensesorted','paridsorkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:01.843'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:01.843'} WHERE tablename = 'finsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('finsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:01.843'},'''NINO''','NINO',{ts '2007-11-23 13:57:01.843'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'flowchartsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:54.607'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:54.607'} WHERE tablename = 'flowchartsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('flowchartsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:54.607'},'''NINO''','NINO',{ts '2007-11-23 13:56:54.607'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesorted' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:05.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:05.420'} WHERE tablename = 'incomesorted' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomesorted','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:05.420'},'''NINO''','NINO',{ts '2007-11-23 13:57:05.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesorted' AND field = 'paridsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'incomesorted' AND field = 'paridsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomesorted','paridsorkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytreesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:07.453'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:07.453'} WHERE tablename = 'inventorytreesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytreesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:07.453'},'''NINO''','NINO',{ts '2007-11-23 13:57:07.453'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:50.873'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.873'} WHERE tablename = 'invoicesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:50.873'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.873'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:52.063'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:52.063'} WHERE tablename = 'itinerationsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:52.063'},'''NINO''','NINO',{ts '2007-11-23 13:56:52.063'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:57.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:57.530'} WHERE tablename = 'locationsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:57.530'},'''NINO''','NINO',{ts '2007-11-23 13:56:57.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'managersorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:58.813'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:58.813'} WHERE tablename = 'managersorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('managersorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:58.813'},'''NINO''','NINO',{ts '2007-11-23 13:56:58.813'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:57.703'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:57.703'} WHERE tablename = 'mandatesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:57.703'},'''NINO''','NINO',{ts '2007-11-23 13:56:57.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontractsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:02.390'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.390'} WHERE tablename = 'parasubcontractsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('parasubcontractsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:02.390'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.390'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationsorted' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:59.357'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:59.357'} WHERE tablename = 'pettycashoperationsorted' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperationsorted','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:59.357'},'''NINO''','NINO',{ts '2007-11-23 13:56:59.357'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservicesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:50.813'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.813'} WHERE tablename = 'profservicesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservicesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:50.813'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.813'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrysorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:51.623'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:51.623'} WHERE tablename = 'registrysorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrysorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:51.623'},'''NINO''','NINO',{ts '2007-11-23 13:56:51.623'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'servicesorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:50.937'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.937'} WHERE tablename = 'servicesorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('servicesorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:50.937'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.937'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortedmovementtotal' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:52.607'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:52.607'} WHERE tablename = 'sortedmovementtotal' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortedmovementtotal','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:52.607'},'''NINO''','NINO',{ts '2007-11-23 13:56:52.607'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:52.827'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:52.827'} WHERE tablename = 'sorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:52.827'},'''NINO''','NINO',{ts '2007-11-23 13:56:52.827'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingapplicability' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:53.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.047'} WHERE tablename = 'sortingapplicability' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingapplicability','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:53.047'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.047'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:53.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.530'} WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingexpensefilter','idsorkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:53.530'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkindreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:53.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.530'} WHERE tablename = 'sortingexpensefilter' AND field = 'idsorkindreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingexpensefilter','idsorkindreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:53.530'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:53.873'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.873'} WHERE tablename = 'sortingincomefilter' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingincomefilter','idsorkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:53.873'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.873'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idsorkindreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:53.873'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:53.873'} WHERE tablename = 'sortingincomefilter' AND field = 'idsorkindreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingincomefilter','idsorkindreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:53.873'},'''NINO''','NINO',{ts '2007-11-23 13:56:53.873'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingkind' AND field = 'codesorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'varchar',col_len = '20',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'varchar(20)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:54.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:54.217'} WHERE tablename = 'sortingkind' AND field = 'codesorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingkind','codesorkind','N','varchar','20',null,null,'System.String','varchar(20)','N','',null,'S',{ts '2007-11-23 13:56:54.217'},'''NINO''','NINO',{ts '2007-11-23 13:56:54.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingkind' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:54.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:54.217'} WHERE tablename = 'sortingkind' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingkind','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:54.217'},'''NINO''','NINO',{ts '2007-11-23 13:56:54.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortinglevel' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:54.687'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:54.687'} WHERE tablename = 'sortinglevel' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortinglevel','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:54.687'},'''NINO''','NINO',{ts '2007-11-23 13:56:54.687'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprev' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:55.017'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:55.017'} WHERE tablename = 'sortingprev' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprev','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:55.017'},'''NINO''','NINO',{ts '2007-11-23 13:56:55.017'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprevexpensevar' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:55.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:55.217'} WHERE tablename = 'sortingprevexpensevar' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprevexpensevar','idsorkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:55.217'},'''NINO''','NINO',{ts '2007-11-23 13:56:55.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprevincomevar' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:55.500'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:55.500'} WHERE tablename = 'sortingprevincomevar' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprevincomevar','idsorkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:55.500'},'''NINO''','NINO',{ts '2007-11-23 13:56:55.500'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtotal' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:04.343'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:04.343'} WHERE tablename = 'sortingtotal' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtotal','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:04.343'},'''NINO''','NINO',{ts '2007-11-23 13:57:04.343'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtranslation' AND field = 'sortingkindchild')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:55.827'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:55.827'} WHERE tablename = 'sortingtranslation' AND field = 'sortingkindchild'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtranslation','sortingkindchild','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:55.827'},'''NINO''','NINO',{ts '2007-11-23 13:56:55.827'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtranslation' AND field = 'sortingkindmaster')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:55.827'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:55.827'} WHERE tablename = 'sortingtranslation' AND field = 'sortingkindmaster'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtranslation','sortingkindmaster','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:55.827'},'''NINO''','NINO',{ts '2007-11-23 13:56:55.827'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:56:51.343'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:51.343'} WHERE tablename = 'taxsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:56:51.343'},'''NINO''','NINO',{ts '2007-11-23 13:56:51.343'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:57:00.140'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:00.140'} WHERE tablename = 'taxsortingsetup' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsortingsetup','idsorkind','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:57:00.140'},'''NINO''','NINO',{ts '2007-11-23 13:57:00.140'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:06.093'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:06.093'} WHERE tablename = 'upbsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('upbsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:06.093'},'''NINO''','NINO',{ts '2007-11-23 13:57:06.093'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageadditionsorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 13:57:02.670'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:57:02.670'} WHERE tablename = 'wageadditionsorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageadditionsorting','idsorkind','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 13:57:02.670'},'''NINO''','NINO',{ts '2007-11-23 13:57:02.670'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_clawback')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.267'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_clawback'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_clawback','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.267'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_fin')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.267'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_fin'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_fin','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.267'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_registry')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.267'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_registry'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_registry','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.267'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_service')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.267'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_service'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_service','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.267'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.267'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingchild1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.267'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingchild2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingchild3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild4')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild4'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingchild4','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild5')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingchild5'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingchild5','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingmaster1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingmaster2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingmaster3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster4')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.280'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.280'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster4'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingmaster4','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.280'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.280'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster5')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.297'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_sortingmaster5'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_sortingmaster5','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.297'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.297'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_tax')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.297'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_tax'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_tax','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.297'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.297'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_upb')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 13:56:50.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 13:56:50.297'} WHERE tablename = 'wageimportsetup' AND field = 'idsorkind_upb'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageimportsetup','idsorkind_upb','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 13:56:50.297'},'''NINO''','NINO',{ts '2007-11-23 13:56:50.297'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'idsortingkind1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 16:15:31.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 16:15:31.577'} WHERE tablename = 'config' AND field = 'idsortingkind1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','idsortingkind1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 16:15:31.577'},'''NINO''','NINO',{ts '2007-11-23 16:15:31.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'idsortingkind2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 16:15:31.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 16:15:31.577'} WHERE tablename = 'config' AND field = 'idsortingkind2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','idsortingkind2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 16:15:31.577'},'''NINO''','NINO',{ts '2007-11-23 16:15:31.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'config' AND field = 'idsortingkind3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 16:15:31.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 16:15:31.577'} WHERE tablename = 'config' AND field = 'idsortingkind3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('config','idsortingkind3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 16:15:31.577'},'''NINO''','NINO',{ts '2007-11-23 16:15:31.577'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountvardetail'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountvardetail] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountyear'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountyear] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expensesorted'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expensesorted] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_incomesorted'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_incomesorted] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorkindregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorkindregint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorkindregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorkindregint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransactionsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransactionsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontractsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontractsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'epexpsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [epexpsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontractsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontractsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrysorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrysorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortedmovementtotal'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortedmovementtotal] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingapplicability'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingapplicability] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorkindregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorkindregint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorkindregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorkindregint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingkind'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingkind] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortinglevel'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortinglevel] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprev'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprev] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevexpensevar'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevexpensevar] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevincomevar'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevincomevar] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtotal'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtotal] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'sortingkindchildint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN sortingkindchildint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'sortingkindmasterint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN sortingkindmasterint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditionsorting'
		and C.name = 'idsorkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditionsorting] DROP COLUMN idsorkindint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_clawbackint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_clawbackint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_finint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_finint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_registryint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_registryint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_serviceint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_serviceint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild1int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild2int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild3int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild4int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild4int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingchild5int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingchild5int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster1int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster2int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster3int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster4int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster4int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_sortingmaster5int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_sortingmaster5int
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_taxint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_taxint
END
GO 


IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageimportsetup'
		and C.name = 'idsorkind_upbint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageimportsetup] DROP COLUMN idsorkind_upbint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'config'
		and C.name = 'idsortingkind3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [config] DROP COLUMN idsortingkind3int
END
GO 
	