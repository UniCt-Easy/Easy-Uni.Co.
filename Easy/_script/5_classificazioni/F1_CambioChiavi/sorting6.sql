
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


-- Passo 8. Inserimento chiavi e indici su nuovi campi chiave
-- Passo 8.1: Chiavi
IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountsorting') and constid=object_id('xpkaccountsorting'))
BEGIN
	ALTER TABLE [accountsorting] ADD CONSTRAINT xpkaccountsorting PRIMARY KEY (idsor,idacc)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountvardetail') and constid=object_id('xpkaccountvardetail'))
BEGIN
	ALTER TABLE [accountvardetail] ADD CONSTRAINT xpkaccountvardetail PRIMARY KEY (yvar,nvar,idacc,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('accountyear') and constid=object_id('xpkaccountyear'))
BEGIN
	ALTER TABLE [accountyear] ADD CONSTRAINT xpkaccountyear PRIMARY KEY (idacc, idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_expensesorted') and constid=object_id('xpkadmpay_expensesorted'))
BEGIN
	ALTER TABLE [admpay_expensesorted] ADD CONSTRAINT xpkadmpay_expensesorted PRIMARY KEY (yadmpay,nadmpay,nexpense,idsor,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('admpay_incomesorted') and constid=object_id('xpkadmpay_incomesorted'))
BEGIN
	ALTER TABLE [admpay_incomesorted] ADD CONSTRAINT xpkadmpay_incomesorted PRIMARY KEY (yadmpay,nadmpay,nincome,idsor,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('banktransactionsorting') and constid=object_id('xpkbanktransactionsorting'))
BEGIN
	ALTER TABLE [banktransactionsorting] ADD CONSTRAINT xpkbanktransactionsorting PRIMARY KEY (yban,nban,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('casualcontractsorting') and constid=object_id('xpkcasualcontractsorting'))
BEGIN
	ALTER TABLE [casualcontractsorting] ADD CONSTRAINT xpkcasualcontractsorting PRIMARY KEY (ycon, ncon, idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('clawbacksorting') and constid=object_id('xpkclawbacksorting'))
BEGIN
	ALTER TABLE [clawbacksorting] ADD CONSTRAINT xpkclawbacksorting PRIMARY KEY (idclawback,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('divisionsorting') and constid=object_id('xpkdivisionsorting'))
BEGIN
	ALTER TABLE [divisionsorting] ADD CONSTRAINT xpkdivisionsorting PRIMARY KEY (iddivision, idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('epexpsorting') and constid=object_id('xpkepexpsorting'))
BEGIN
	ALTER TABLE [epexpsorting] ADD CONSTRAINT xpkepexpsorting PRIMARY KEY (yepexp,nepexp,idsor,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('estimatesorting') and constid=object_id('xpkestimatesorting'))
BEGIN
	ALTER TABLE [estimatesorting] ADD CONSTRAINT xpkestimatesorting PRIMARY KEY (idestimkind,yestim,nestim, idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('expensesorted') and constid=object_id('xpkexpensesorted'))
BEGIN
	ALTER TABLE [expensesorted] ADD CONSTRAINT xpkexpensesorted PRIMARY KEY (idsor,idexp,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('finsorting') and constid=object_id('xpkfinsorting'))
BEGIN
	ALTER TABLE [finsorting] ADD CONSTRAINT xpkfinsorting PRIMARY KEY (idfin,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('flowchartsorting') and constid=object_id('xpkflowchartsorting'))
BEGIN
	ALTER TABLE [flowchartsorting] ADD CONSTRAINT xpkflowchartsorting PRIMARY KEY (idsor,idflowchart)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('incomesorted') and constid=object_id('xpkincomesorted'))
BEGIN
	ALTER TABLE [incomesorted] ADD CONSTRAINT xpkincomesorted PRIMARY KEY (idsor,idinc,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('inventorytreesorting') and constid=object_id('xpkinventorytreesorting'))
BEGIN
	ALTER TABLE [inventorytreesorting] ADD CONSTRAINT xpkinventorytreesorting PRIMARY KEY (idsor,idinv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('invoicesorting') and constid=object_id('xpkinvoicesorting'))
BEGIN
	ALTER TABLE [invoicesorting] ADD CONSTRAINT xpkinvoicesorting PRIMARY KEY (idsor,idinvkind,yinv,ninv)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('itinerationsorting') and constid=object_id('xpkitinerationsorting'))
BEGIN
	ALTER TABLE [itinerationsorting] ADD CONSTRAINT xpkitinerationsorting PRIMARY KEY (yitineration,nitineration, idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('locationsorting') and constid=object_id('xpklocationsorting'))
BEGIN
	ALTER TABLE [locationsorting] ADD CONSTRAINT xpklocationsorting PRIMARY KEY (idsor,idlocation)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('managersorting') and constid=object_id('xpkmanagersorting'))
BEGIN
	ALTER TABLE [managersorting] ADD CONSTRAINT xpkmanagersorting PRIMARY KEY (idman,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('mandatesorting') and constid=object_id('xpkmandatesorting'))
BEGIN
	ALTER TABLE [mandatesorting] ADD CONSTRAINT xpkmandatesorting PRIMARY KEY (idsor,idmankind,yman,nman)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('parasubcontractsorting') and constid=object_id('xpkparasubcontractsorting'))
BEGIN
	ALTER TABLE [parasubcontractsorting] ADD CONSTRAINT xpkparasubcontractsorting PRIMARY KEY (idsor,idcon)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('pettycashoperationsorted') and constid=object_id('xpkpettycashoperationsorted'))
BEGIN
	ALTER TABLE [pettycashoperationsorted] ADD CONSTRAINT xpkpettycashoperationsorted PRIMARY KEY (idpettycash,yoperation,noperation,idsor,idsubclass)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('profservicesorting') and constid=object_id('xpkprofservicesorting'))
BEGIN
	ALTER TABLE [profservicesorting] ADD CONSTRAINT xpkprofservicesorting PRIMARY KEY (ycon,idsor,ncon)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('registrysorting') and constid=object_id('xpkregistrysorting'))
BEGIN
	ALTER TABLE [registrysorting] ADD CONSTRAINT xpkregistrysorting PRIMARY KEY (idsor,idreg)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('servicesorting') and constid=object_id('xpkservicesorting'))
BEGIN
	ALTER TABLE [servicesorting] ADD CONSTRAINT xpkservicesorting PRIMARY KEY (idser,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortedmovementtotal') and constid=object_id('xpksortedmovementtotal'))
BEGIN
	ALTER TABLE [sortedmovementtotal] ADD CONSTRAINT xpksortedmovementtotal PRIMARY KEY (idsor,ayear)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sorting') and constid=object_id('xpksorting'))
BEGIN
	ALTER TABLE [sorting] ADD CONSTRAINT xpksorting PRIMARY KEY (idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingprev') and constid=object_id('xpksortingprev'))
BEGIN
	ALTER TABLE [sortingprev] ADD CONSTRAINT xpksortingprev PRIMARY KEY (idsor,ayear)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingtotal') and constid=object_id('xpksortingtotal'))
BEGIN
	ALTER TABLE [sortingtotal] ADD CONSTRAINT xpksortingtotal PRIMARY KEY (idacc,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('sortingtranslation') and constid=object_id('xpksortingtranslation'))
BEGIN
	ALTER TABLE [sortingtranslation] ADD CONSTRAINT xpksortingtranslation PRIMARY KEY (idsortingchild,idsortingmaster)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('taxsorting') and constid=object_id('xpktaxsorting'))
BEGIN
	ALTER TABLE [taxsorting] ADD CONSTRAINT xpktaxsorting PRIMARY KEY (taxcode,idsor)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('upbsorting') and constid=object_id('xpkupbsorting'))
BEGIN
	ALTER TABLE [upbsorting] ADD CONSTRAINT xpkupbsorting PRIMARY KEY (idsor,idupb)
END
GO

IF NOT exists(SELECT * FROM sysconstraints where id=object_id('wageadditionsorting') and constid=object_id('xpkwageadditionsorting'))
BEGIN
	ALTER TABLE [wageadditionsorting] ADD CONSTRAINT xpkwageadditionsorting PRIMARY KEY (ycon,idsor,ncon)
END
GO

-- Passo 8.2: Indici
IF EXISTS (SELECT * FROM sysindexes where name='xi2sorting' and id=object_id('sorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2sorting ON sorting(paridsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2sorting
	ON sorting (paridsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1divisionsorting' and id=object_id('divisionsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1divisionsorting ON divisionsorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1divisionsorting
	ON divisionsorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesorted' and id=object_id('expensesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesorted ON expensesorted(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expensesorted
	ON expensesorted (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1finsorting' and id=object_id('finsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1finsorting ON finsorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1finsorting
	ON finsorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1incomesorted' and id=object_id('incomesorted'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomesorted ON incomesorted(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomesorted
	ON incomesorted (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytreesorting ON inventorytreesorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1inventorytreesorting
	ON inventorytreesorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1locationsorting' and id=object_id('locationsorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1locationsorting ON locationsorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1locationsorting
	ON locationsorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1managersorting' and id=object_id('managersorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1managersorting ON managersorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1managersorting
	ON managersorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1registrysorting' and id=object_id('registrysorting'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrysorting ON registrysorting(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1registrysorting
	ON registrysorting (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortedmovementtotal' and id=object_id('sortedmovementtotal'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortedmovementtotal ON sortedmovementtotal(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortedmovementtotal
	ON sortedmovementtotal (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprev' and id=object_id('sortingprev'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprev ON sortingprev(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprev
	ON sortingprev (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevexpensevar' and id=object_id('sortingprevexpensevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar ON sortingprevexpensevar(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar
	ON sortingprevexpensevar (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevincomevar' and id=object_id('sortingprevincomevar'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevincomevar ON sortingprevincomevar(idsor)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1sortingprevincomevar
	ON sortingprevincomevar (idsor)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- Passo 9. Scrittura in COLUMNTYPES
IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:21.327'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:21.327'} WHERE tablename = 'accountsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:21.327'},'''NINO''','NINO',{ts '2007-11-23 20:11:21.327'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountvardetail' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:31.657'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:31.657'} WHERE tablename = 'accountvardetail' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountvardetail','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:31.657'},'''NINO''','NINO',{ts '2007-11-23 20:11:31.657'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'accountyear' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:33.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:33.250'} WHERE tablename = 'accountyear' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('accountyear','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:33.250'},'''NINO''','NINO',{ts '2007-11-23 20:11:33.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_expensesorted' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:32.267'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.267'} WHERE tablename = 'admpay_expensesorted' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('admpay_expensesorted','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:32.267'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.267'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'admpay_incomesorted' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:29.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:29.530'} WHERE tablename = 'admpay_incomesorted' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('admpay_incomesorted','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:29.530'},'''NINO''','NINO',{ts '2007-11-23 20:11:29.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:22.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.170'} WHERE tablename = 'assetacquire' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:22.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:22.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.170'} WHERE tablename = 'assetacquire' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:22.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'assetacquire' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:22.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.170'} WHERE tablename = 'assetacquire' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('assetacquire','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:22.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:30.703'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:30.703'} WHERE tablename = 'autoexpensesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoexpensesorting','idsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:30.703'},'''NINO''','NINO',{ts '2007-11-23 20:11:30.703'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoexpensesorting' AND field = 'idsorreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:30.717'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:30.717'} WHERE tablename = 'autoexpensesorting' AND field = 'idsorreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoexpensesorting','idsorreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:30.717'},'''NINO''','NINO',{ts '2007-11-23 20:11:30.717'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:31.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:31.157'} WHERE tablename = 'autoincomesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoincomesorting','idsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:31.157'},'''NINO''','NINO',{ts '2007-11-23 20:11:31.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'autoincomesorting' AND field = 'idsorreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:31.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:31.170'} WHERE tablename = 'autoincomesorting' AND field = 'idsorreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('autoincomesorting','idsorreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:31.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:31.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'banktransactionsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:26.593'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:26.593'} WHERE tablename = 'banktransactionsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('banktransactionsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:26.593'},'''NINO''','NINO',{ts '2007-11-23 20:11:26.593'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontract' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.407'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.407'} WHERE tablename = 'casualcontract' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('casualcontract','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.407'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.407'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontract' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.407'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.407'} WHERE tablename = 'casualcontract' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('casualcontract','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.407'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.407'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontract' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.407'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.407'} WHERE tablename = 'casualcontract' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('casualcontract','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.407'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.407'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'casualcontractsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:34.233'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:34.233'} WHERE tablename = 'casualcontractsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('casualcontractsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:34.233'},'''NINO''','NINO',{ts '2007-11-23 20:11:34.233'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'clawbacksorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:14.670'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.670'} WHERE tablename = 'clawbacksorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('clawbacksorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:14.670'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.670'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'divisionsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:15.750'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.750'} WHERE tablename = 'divisionsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('divisionsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:15.750'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.750'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'entrydetail' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:16.343'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:16.343'} WHERE tablename = 'entrydetail' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('entrydetail','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:16.343'},'''NINO''','NINO',{ts '2007-11-23 20:11:16.343'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'entrydetail' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:16.343'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:16.343'} WHERE tablename = 'entrydetail' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('entrydetail','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:16.343'},'''NINO''','NINO',{ts '2007-11-23 20:11:16.343'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'entrydetail' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:16.343'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:16.343'} WHERE tablename = 'entrydetail' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('entrydetail','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:16.343'},'''NINO''','NINO',{ts '2007-11-23 20:11:16.343'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'epexpsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:18.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:18.030'} WHERE tablename = 'epexpsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('epexpsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:18.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:18.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.157'} WHERE tablename = 'estimatedetail' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatedetail','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.157'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.157'} WHERE tablename = 'estimatedetail' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatedetail','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.157'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatedetail' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.157'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.157'} WHERE tablename = 'estimatedetail' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatedetail','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.157'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.157'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'estimatesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:22.530'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.530'} WHERE tablename = 'estimatesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('estimatesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:22.530'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.530'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesorted' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:21.670'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:21.670'} WHERE tablename = 'expensesorted' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensesorted','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:21.670'},'''NINO''','NINO',{ts '2007-11-23 20:11:21.670'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensesorted' AND field = 'paridsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:22.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.170'} WHERE tablename = 'expensesorted' AND field = 'paridsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensesorted','paridsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:22.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:29.313'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:29.313'} WHERE tablename = 'finsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('finsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:29.313'},'''NINO''','NINO',{ts '2007-11-23 20:11:29.313'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'flowchartsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:19.297'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:19.297'} WHERE tablename = 'flowchartsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('flowchartsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:19.297'},'''NINO''','NINO',{ts '2007-11-23 20:11:19.297'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesorted' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:34.093'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:34.093'} WHERE tablename = 'incomesorted' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomesorted','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:34.093'},'''NINO''','NINO',{ts '2007-11-23 20:11:34.093'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomesorted' AND field = 'paridsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:22.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.170'} WHERE tablename = 'incomesorted' AND field = 'paridsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomesorted','paridsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:22.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorytreesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:36.563'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:36.563'} WHERE tablename = 'inventorytreesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorytreesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:36.563'},'''NINO''','NINO',{ts '2007-11-23 20:11:36.563'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.483'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.483'} WHERE tablename = 'invoicedetail' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedetail','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.483'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.483'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.483'} WHERE tablename = 'invoicedetail' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedetail','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.483'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicedetail' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:14.483'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.483'} WHERE tablename = 'invoicedetail' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicedetail','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:14.483'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.483'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'invoicesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:15.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.030'} WHERE tablename = 'invoicesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('invoicesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:15.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:15.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.577'} WHERE tablename = 'itineration' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:15.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:15.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.577'} WHERE tablename = 'itineration' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:15.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itineration' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:15.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.577'} WHERE tablename = 'itineration' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itineration','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:15.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'itinerationsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:16.593'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:16.593'} WHERE tablename = 'itinerationsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('itinerationsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:16.593'},'''NINO''','NINO',{ts '2007-11-23 20:11:16.593'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:22.670'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.670'} WHERE tablename = 'locationsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:22.670'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.670'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'managersorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:24.250'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:24.250'} WHERE tablename = 'managersorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('managersorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:24.250'},'''NINO''','NINO',{ts '2007-11-23 20:11:24.250'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:23.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:23.967'} WHERE tablename = 'mandatedetail' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:23.967'},'''NINO''','NINO',{ts '2007-11-23 20:11:23.967'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:23.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:23.967'} WHERE tablename = 'mandatedetail' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:23.967'},'''NINO''','NINO',{ts '2007-11-23 20:11:23.967'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:23.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:23.967'} WHERE tablename = 'mandatedetail' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:23.967'},'''NINO''','NINO',{ts '2007-11-23 20:11:23.967'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:22.843'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:22.843'} WHERE tablename = 'mandatesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:22.843'},'''NINO''','NINO',{ts '2007-11-23 20:11:22.843'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontract' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:28.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:28.577'} WHERE tablename = 'parasubcontract' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('parasubcontract','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:28.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:28.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontract' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:28.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:28.577'} WHERE tablename = 'parasubcontract' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('parasubcontract','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:28.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:28.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontract' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:28.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:28.577'} WHERE tablename = 'parasubcontract' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('parasubcontract','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:28.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:28.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'parasubcontractsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:30.047'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:30.047'} WHERE tablename = 'parasubcontractsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('parasubcontractsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:30.047'},'''NINO''','NINO',{ts '2007-11-23 20:11:30.047'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.577'} WHERE tablename = 'pettycashoperation' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperation','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.577'} WHERE tablename = 'pettycashoperation' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperation','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperation' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:32.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.577'} WHERE tablename = 'pettycashoperation' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperation','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:32.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationsorted' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:26.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:26.170'} WHERE tablename = 'pettycashoperationsorted' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperationsorted','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:26.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:26.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:13.857'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:13.857'} WHERE tablename = 'profservice' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservice','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:13.857'},'''NINO''','NINO',{ts '2007-11-23 20:11:13.857'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:13.857'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:13.857'} WHERE tablename = 'profservice' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservice','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:13.857'},'''NINO''','NINO',{ts '2007-11-23 20:11:13.857'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservice' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:13.857'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:13.857'} WHERE tablename = 'profservice' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservice','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:13.857'},'''NINO''','NINO',{ts '2007-11-23 20:11:13.857'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'profservicesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:14.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:14.953'} WHERE tablename = 'profservicesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('profservicesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:14.953'},'''NINO''','NINO',{ts '2007-11-23 20:11:14.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'registrysorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:15.953'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.953'} WHERE tablename = 'registrysorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('registrysorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:15.953'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.953'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'servicesorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:15.093'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.093'} WHERE tablename = 'servicesorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('servicesorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:15.093'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.093'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortedmovementtotal' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:17.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:17.170'} WHERE tablename = 'sortedmovementtotal' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortedmovementtotal','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:17.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:17.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:17.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:17.420'} WHERE tablename = 'sorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:17.420'},'''NINO''','NINO',{ts '2007-11-23 20:11:17.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sorting' AND field = 'idsorkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:17.420'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:17.420'} WHERE tablename = 'sorting' AND field = 'idsorkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sorting','idsorkind','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:17.420'},'''NINO''','NINO',{ts '2007-11-23 20:11:17.420'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:18.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:18.170'} WHERE tablename = 'sortingexpensefilter' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingexpensefilter','idsor','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:18.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:18.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingexpensefilter' AND field = 'idsorreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:18.170'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:18.170'} WHERE tablename = 'sortingexpensefilter' AND field = 'idsorreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingexpensefilter','idsorreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:18.170'},'''NINO''','NINO',{ts '2007-11-23 20:11:18.170'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:18.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:18.577'} WHERE tablename = 'sortingincomefilter' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingincomefilter','idsor','N','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:18.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:18.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingincomefilter' AND field = 'idsorreg')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:18.577'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:18.577'} WHERE tablename = 'sortingincomefilter' AND field = 'idsorreg'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingincomefilter','idsorreg','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:18.577'},'''NINO''','NINO',{ts '2007-11-23 20:11:18.577'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprev' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:19.607'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:19.607'} WHERE tablename = 'sortingprev' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprev','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:19.607'},'''NINO''','NINO',{ts '2007-11-23 20:11:19.607'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprevexpensevar' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:19.920'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:19.920'} WHERE tablename = 'sortingprevexpensevar' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprevexpensevar','idsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:19.920'},'''NINO''','NINO',{ts '2007-11-23 20:11:19.920'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingprevincomevar' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:20.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:20.217'} WHERE tablename = 'sortingprevincomevar' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingprevincomevar','idsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:20.217'},'''NINO''','NINO',{ts '2007-11-23 20:11:20.217'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtotal' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:32.797'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:32.797'} WHERE tablename = 'sortingtotal' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtotal','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:32.797'},'''NINO''','NINO',{ts '2007-11-23 20:11:32.797'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtranslation' AND field = 'idsortingchild')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:20.623'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:20.623'} WHERE tablename = 'sortingtranslation' AND field = 'idsortingchild'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtranslation','idsortingchild','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:20.623'},'''NINO''','NINO',{ts '2007-11-23 20:11:20.623'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sortingtranslation' AND field = 'idsortingmaster')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:20.640'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:20.640'} WHERE tablename = 'sortingtranslation' AND field = 'idsortingmaster'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sortingtranslation','idsortingmaster','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:20.640'},'''NINO''','NINO',{ts '2007-11-23 20:11:20.640'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:15.687'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:15.687'} WHERE tablename = 'taxsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:15.687'},'''NINO''','NINO',{ts '2007-11-23 20:11:15.687'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminpay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsortingsetup','idsor_adminpay','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminproc')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'taxsortingsetup' AND field = 'idsor_adminproc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsortingsetup','idsor_adminproc','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idsor_employproc')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'taxsortingsetup' AND field = 'idsor_employproc'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsortingsetup','idsor_employproc','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'taxsortingsetup' AND field = 'idsor_taxpay')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:27.030'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:27.030'} WHERE tablename = 'taxsortingsetup' AND field = 'idsor_taxpay'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('taxsortingsetup','idsor_taxpay','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:27.030'},'''NINO''','NINO',{ts '2007-11-23 20:11:27.030'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'upbsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:35.107'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:35.107'} WHERE tablename = 'upbsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('upbsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:35.107'},'''NINO''','NINO',{ts '2007-11-23 20:11:35.107'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageaddition' AND field = 'idsor1')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:29.767'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:29.767'} WHERE tablename = 'wageaddition' AND field = 'idsor1'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageaddition','idsor1','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:29.767'},'''NINO''','NINO',{ts '2007-11-23 20:11:29.767'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageaddition' AND field = 'idsor2')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:29.767'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:29.767'} WHERE tablename = 'wageaddition' AND field = 'idsor2'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageaddition','idsor2','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:29.767'},'''NINO''','NINO',{ts '2007-11-23 20:11:29.767'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageaddition' AND field = 'idsor3')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-23 20:11:29.767'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:29.767'} WHERE tablename = 'wageaddition' AND field = 'idsor3'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageaddition','idsor3','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-23 20:11:29.767'},'''NINO''','NINO',{ts '2007-11-23 20:11:29.767'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'wageadditionsorting' AND field = 'idsor')
UPDATE [columntypes] SET iskey = 'S',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-23 20:11:30.357'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-23 20:11:30.357'} WHERE tablename = 'wageadditionsorting' AND field = 'idsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('wageadditionsorting','idsor','S','int','4',null,null,'System.Int32','int','N','',null,'S',{ts '2007-11-23 20:11:30.357'},'''NINO''','NINO',{ts '2007-11-23 20:11:30.357'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'sorting' AND field = 'paridsor')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'int',col_len = '4',col_precision = null,col_scale = null,systemtype = 'System.Int32',sqldeclaration = 'int',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-11-26 09:56:47.687'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-26 09:56:47.687'} WHERE tablename = 'sorting' AND field = 'paridsor'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('sorting','paridsor','N','int','4',null,null,'System.Int32','int','S','',null,'N',{ts '2007-11-26 09:56:47.687'},'''NINO''','NINO',{ts '2007-11-26 09:56:47.687'})
GO

-- Passo 10. Cancellazione dei campi d'appoggio da tutte le tabelle
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountvardetail'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountvardetail] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'accountyear'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [accountyear] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_expensesorted'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_expensesorted] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'admpay_incomesorted'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [admpay_incomesorted] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'assetacquire'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [assetacquire] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoexpensesorting'
		and C.name = 'idsorregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoexpensesorting] DROP COLUMN idsorregint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'autoincomesorting'
		and C.name = 'idsorregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [autoincomesorting] DROP COLUMN idsorregint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'banktransactionsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [banktransactionsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontract'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontract] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'casualcontractsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [casualcontractsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'clawbacksorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [clawbacksorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'divisionsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [divisionsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'entrydetail'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [entrydetail] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'epexpsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [epexpsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatedetail'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatedetail] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'estimatesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [estimatesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensesorted'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensesorted] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'flowchartsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [flowchartsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomesorted'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomesorted] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'inventorytreesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [inventorytreesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicedetail'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicedetail] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'invoicesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [invoicesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itineration'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itineration] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'itinerationsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [itinerationsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'locationsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [locationsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'managersorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [managersorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatedetail'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatedetail] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'mandatesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [mandatesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontract'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontract] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'parasubcontractsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [parasubcontractsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperation'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperation] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationsorted'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationsorted] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservice'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservice] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'profservicesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [profservicesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrysorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrysorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'servicesorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [servicesorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortedmovementtotal'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortedmovementtotal] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sorting'
		and C.name = 'paridsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sorting] DROP COLUMN paridsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingexpensefilter'
		and C.name = 'idsorregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingexpensefilter] DROP COLUMN idsorregint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingincomefilter'
		and C.name = 'idsorregint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingincomefilter] DROP COLUMN idsorregint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprev'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprev] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevexpensevar'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevexpensevar] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingprevincomevar'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingprevincomevar] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtotal'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtotal] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'idsortingchildint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN idsortingchildint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'sortingtranslation'
		and C.name = 'idsortingmasterint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [sortingtranslation] DROP COLUMN idsortingmasterint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_adminpayint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_adminpayint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_adminprocint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_adminprocint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_employprocint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_employprocint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'taxsortingsetup'
		and C.name = 'idsor_taxpayint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [taxsortingsetup] DROP COLUMN idsor_taxpayint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'upbsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [upbsorting] DROP COLUMN idsorint
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor1int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor1int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor2int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor2int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageaddition'
		and C.name = 'idsor3int'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageaddition] DROP COLUMN idsor3int
END
GO 

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'wageadditionsorting'
		and C.name = 'idsorint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [wageadditionsorting] DROP COLUMN idsorint
END
GO 

