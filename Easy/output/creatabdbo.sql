
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


-- CREAZIONE TABELLA abatement --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[abatement]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[abatement] (
idabatement int NOT NULL,
appliance char(1) NULL,
calculationkind char(1) NOT NULL,
description varchar(50) NOT NULL,
evaluatesp varchar(50) NOT NULL,
evaluationorder int NULL,
flagabatableexpense char(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
taxcode int NOT NULL,
validitystart datetime NULL,
validitystop datetime NULL,
 CONSTRAINT xpkabatement PRIMARY KEY (idabatement
)
)
END
GO

-- CREAZIONE TABELLA abatementcode --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[abatementcode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[abatementcode] (
ayear int NOT NULL,
idabatement int NOT NULL,
code varchar(20) NULL,
description varchar(110) NULL,
exemption decimal(19,2) NULL,
longdescription text NULL,
maximal decimal(19,2) NULL,
rate decimal(19,6) NULL,
 CONSTRAINT xpkabatementcode PRIMARY KEY (ayear,
idabatement
)
)
END
GO

-- CREAZIONE TABELLA accmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accmotive] (
idaccmotive varchar(36) NOT NULL,
active char(1) NULL,
codemotive varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flagamm char(1) NULL,
flagdep char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridaccmotive varchar(36) NULL,
title varchar(150) NOT NULL,
 CONSTRAINT xpkaccmotive PRIMARY KEY (idaccmotive
)
)
END
GO

-- CREAZIONE TABELLA accmotivedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotivedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accmotivedetail] (
ayear smallint NOT NULL,
idacc varchar(38) NOT NULL,
idaccmotive varchar(36) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccmotivedetail PRIMARY KEY (ayear,
idacc,
idaccmotive
)
)
END
GO

-- CREAZIONE TABELLA accmotiveepoperation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotiveepoperation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accmotiveepoperation] (
idaccmotive varchar(36) NOT NULL,
idepoperation varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccmotiveepoperation PRIMARY KEY (idaccmotive,
idepoperation
)
)
END
GO

-- CREAZIONE TABELLA account --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[account]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[account] (
idacc varchar(38) NOT NULL,
ayear smallint NOT NULL,
codeacc varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag int NULL,
flagcompetency char(1) NULL,
flagloss char(1) NULL,
flagprofit char(1) NULL,
flagregistry char(1) NULL,
flagtransitory char(1) NULL,
flagupb char(1) NULL,
idaccountkind varchar(20) NULL,
idpatrimony varchar(31) NULL,
idplaccount varchar(31) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel char(1) NOT NULL,
paridacc varchar(38) NULL,
patrimony_sign char(1) NULL,
placcount_sign char(1) NULL,
printingorder varchar(50) NOT NULL,
rtf image NULL,
title varchar(150) NOT NULL,
txt text NULL,
 CONSTRAINT xpkaccount PRIMARY KEY (idacc
)
)
END
GO

-- CREAZIONE TABELLA accountkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accountkind] (
idaccountkind varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagda char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccountkind PRIMARY KEY (idaccountkind
)
)
END
GO

-- CREAZIONE TABELLA accountlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accountlevel] (
ayear smallint NOT NULL,
nlevel char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagusable char(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccountlevel PRIMARY KEY (ayear,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA accountlookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountlookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accountlookup] (
oldidacc varchar(38) NOT NULL,
newidacc varchar(38) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkaccountlookup PRIMARY KEY (oldidacc,
newidacc
)
)
END
GO

-- CREAZIONE TABELLA acquirekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[acquirekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[acquirekind] (
idacquirekind varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkacquirekind PRIMARY KEY (idacquirekind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA add2007 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[add2007]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[add2007] (
ALIQUOTA nvarchar NULL,
annotations varchar(400) NULL,
CODICE_CATASTALE nvarchar NULL,
COMUNE nvarchar NULL,
DATA_DELIBERA smalldatetime NULL,
DATA_PUBBLICAZIONE smalldatetime NULL,
idcity int NULL,
idtaxratecitystart int NULL,
NOTE nvarchar NULL,
NUMERO_DELIBERA nvarchar NULL,
PR nvarchar NULL,
rate decimal(19,6) NULL,
start smalldatetime NULL,
toinsert char(1) NULL)
END
GO

-- CREAZIONE TABELLA add2008 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[add2008]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[add2008] (
ALIQUOTA nvarchar NULL,
annotations varchar(400) NULL,
CODICE_CATASTALE nvarchar NULL,
COMUNE nvarchar NULL,
DATA_DELIBERA smalldatetime NULL,
DATA_PUBBLICAZIONE smalldatetime NULL,
idcity int NULL,
idtaxratecitystart int NULL,
minamount decimal(18,0) NULL,
NOTE nvarchar NULL,
NUMERO_DELIBERA nvarchar NULL,
PR nvarchar NULL,
rate decimal(19,6) NULL,
start smalldatetime NULL,
toinsert char(1) NULL)
END
GO

-- CREAZIONE TABELLA add2008b --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[add2008b]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[add2008b] (
aliquota varchar(8000) NULL,
annotations varchar(400) NULL,
codice_catastale varchar(8000) NULL,
comune varchar(8000) NULL,
data_delibera varchar(8000) NULL,
data_pubblicazione varchar(8000) NULL,
idcity int NULL,
idtaxratecitystart int NULL,
minamount decimal(19,2) NULL,
note varchar(8000) NULL,
numero_delibera varchar(8000) NULL,
provincia varchar(8000) NULL,
rate decimal(19,6) NULL,
start smalldatetime NULL,
toinsert char(1) NULL)
END
GO

-- CREAZIONE TABELLA address --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[address]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[address] (
idaddress int NOT NULL,
active char(1) NULL,
codeaddress varchar(20) NOT NULL,
description varchar(60) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkaddress PRIMARY KEY (idaddress
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukaddress' and id=object_id('address'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address
     (
     codeaddress     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address
     (
     codeaddress     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1address' and id=object_id('address'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address
     (
     codeaddress     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address
     (
     codeaddress     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA adminoperation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[adminoperation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[adminoperation] (
opname varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkadminoperation PRIMARY KEY (opname
)
)
END
GO

-- CREAZIONE TABELLA advice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[advice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[advice] (
codeadvice varchar(30) NOT NULL,
adate datetime NOT NULL,
description text NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(150) NOT NULL,
 CONSTRAINT xpkadvice PRIMARY KEY (codeadvice
)
)
END
GO

-- CREAZIONE TABELLA affinity --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affinity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affinity] (
idaffinity char(1) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkaffinity PRIMARY KEY (idaffinity
)
)
END
GO

-- CREAZIONE TABELLA allowancerule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allowancerule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[allowancerule] (
idallowancerule int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpkallowancerule PRIMARY KEY (idallowancerule
)
)
END
GO

-- CREAZIONE TABELLA allowanceruledetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allowanceruledetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[allowanceruledetail] (
idallowancerule int NOT NULL,
iddetail int NOT NULL,
advancepercentage decimal(19,6) NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idposition int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxincomeclass int NOT NULL,
minincomeclass int NOT NULL,
 CONSTRAINT xpkallowanceruledetail PRIMARY KEY (idallowancerule,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA apactivitykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[apactivitykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[apactivitykind] (
idapactivitykind varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkapactivitykind PRIMARY KEY (idapactivitykind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA apcontractkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[apcontractkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[apcontractkind] (
idapcontractkind varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkapcontractkind PRIMARY KEY (idapcontractkind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA apmanager --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[apmanager]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[apmanager] (
idapmanager varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkapmanager PRIMARY KEY (idapmanager,
ayear
)
)
END
GO

-- CREAZIONE TABELLA apregistrykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[apregistrykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[apregistrykind] (
idapregistrykind varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkapregistrykind PRIMARY KEY (idapregistrykind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA assetusagekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetusagekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[assetusagekind] (
idassetusagekind int NOT NULL,
active char(1) NULL,
codeassetusagekind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkassetusagekind PRIMARY KEY (idassetusagekind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetusagekind' and id=object_id('assetusagekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetusagekind
     ON assetusagekind
     (
     codeassetusagekind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetusagekind
     ON assetusagekind
     (
     codeassetusagekind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_assetusagekind' and id=object_id('assetusagekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetusagekind
     ON assetusagekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetusagekind
     ON assetusagekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetusagekind' and id=object_id('assetusagekind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetusagekind
     ON assetusagekind
     (
     codeassetusagekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetusagekind
     ON assetusagekind
     (
     codeassetusagekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA authstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[authstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[authstatus] (
idauthstatus int NOT NULL,
description varchar(50) NOT NULL,
explanation varchar(800) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkauthstatus PRIMARY KEY (idauthstatus
)
)
END
GO

-- CREAZIONE TABELLA autokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[autokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[autokind] (
idautokind tinyint NOT NULL,
code varchar(10) NOT NULL,
title varchar(100) NOT NULL,
 CONSTRAINT xpkautokind PRIMARY KEY (idautokind
)
)
END
GO

-- CREAZIONE TABELLA bank --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bank] (
idbank varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flagusable char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkbank PRIMARY KEY (idbank
)
)
END
GO

-- CREAZIONE TABELLA blacklist --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[blacklist]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[blacklist] (
idblacklist int NOT NULL,
blcode char(3) NULL,
description varchar(100) NULL,
idnation int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smalldatetime NOT NULL,
stop smalldatetime NULL,
 CONSTRAINT xpkblacklist PRIMARY KEY (idblacklist
)
)
END
GO

-- CREAZIONE TABELLA buildcf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[buildcf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[buildcf] (
letter char(1) NOT NULL,
evenposition smallint NOT NULL,
kind char(1) NOT NULL,
oddposition smallint NOT NULL,
 CONSTRAINT xpkbuildcf PRIMARY KEY (letter
)
)
END
GO

-- CREAZIONE TABELLA c_colname --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[c_colname]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[c_colname] (
autoincremento char(1) NULL,
espressione varchar(1000) NULL,
lookuptable varchar(30) NULL,
lookuptype varchar(10) NULL,
newcol varchar(50) NOT NULL,
oldcol varchar(500) NOT NULL,
oldtable varchar(50) NOT NULL)
END
GO

-- CREAZIONE TABELLA c_tablename --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[c_tablename]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[c_tablename] (
cfg varchar(50) NULL,
chk varchar(50) NULL,
dbo varchar(10) NULL,
newtable varchar(50) NOT NULL,
oldtable varchar(50) NOT NULL,
tipocopia varchar(50) NULL,
xtype varchar(10) NULL)
END
GO

-- CREAZIONE TABELLA cab --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cab]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cab] (
idbank varchar(20) NOT NULL,
idcab varchar(20) NOT NULL,
address varchar(100) NULL,
cap varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagusable char(1) NULL,
idcity int NULL,
location varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcab PRIMARY KEY (idbank,
idcab
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1cab' and id=object_id('cab'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1cab
     ON cab
     (
     idbank     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1cab
     ON cab
     (
     idbank     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA casualcontractexemption --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[casualcontractexemption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[casualcontractexemption] (
startvalidity datetime NOT NULL,
active char(1) NULL,
exemptionquota decimal(19,2) NULL,
 CONSTRAINT xpkcasualcontractexemption PRIMARY KEY (startvalidity
)
)
END
GO

-- CREAZIONE TABELLA casualdeduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[casualdeduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[casualdeduction] (
iddeduction int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxablecode varchar(20) NOT NULL,
 CONSTRAINT xpkcasualdeduction PRIMARY KEY (iddeduction
)
)
END
GO

-- CREAZIONE TABELLA category --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[category] (
idcategory varchar(2) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcategory PRIMARY KEY (idcategory
)
)
END
GO

-- CREAZIONE TABELLA cbimotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cbimotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cbimotive] (
idcbimotive int NOT NULL,
codemotive varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcbimotive PRIMARY KEY (idcbimotive
)
)
END
GO

-- CREAZIONE TABELLA centralizedcategory --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[centralizedcategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[centralizedcategory] (
idcentralizedcategory varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcentralizedcategory PRIMARY KEY (idcentralizedcategory
)
)
END
GO

-- CREAZIONE TABELLA certificationmodel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[certificationmodel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[certificationmodel] (
idcertificationmodel char(1) NOT NULL,
description varchar(60) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcertificationmodel PRIMARY KEY (idcertificationmodel
)
)
END
GO

-- CREAZIONE TABELLA checkup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[checkup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[checkup] (
idcheckup int NOT NULL,
checkerrors text NULL,
code varchar(60) NOT NULL,
consequence text NULL,
corrige text NULL,
description varchar(400) NULL,
edittype varchar(50) NULL,
groupnumber varchar(50) NULL,
listerrors text NULL,
listtype varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motive text NULL,
rtf image NULL,
tablename varchar(50) NOT NULL,
txt text NULL,
 CONSTRAINT xpkcheckup PRIMARY KEY (idcheckup
)
)
END
GO

-- CREAZIONE TABELLA commonconfig --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[commonconfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[commonconfig] (
ayear smallint NOT NULL,
flagsepivapay char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
unifiedfinlevel smallint NOT NULL,
 CONSTRAINT xpkcommonconfig PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA configsmtp --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[configsmtp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[configsmtp] (
dummykey int NOT NULL,
flagsend char(1) NULL,
login varchar(200) NOT NULL,
password varchar(200) NOT NULL,
port int NOT NULL,
server varchar(200) NOT NULL,
 CONSTRAINT xpkconfigsmtp PRIMARY KEY (dummykey
)
)
END
GO

-- CREAZIONE TABELLA connector --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[connector]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[connector] (
idconnector int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
name varchar(20) NOT NULL,
 CONSTRAINT xpkconnector PRIMARY KEY (idconnector
)
)
END
GO

-- CREAZIONE TABELLA consipkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[consipkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[consipkind] (
idconsipkind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(600) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkconsipkind PRIMARY KEY (idconsipkind
)
)
END
GO

-- CREAZIONE TABELLA consultingkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[consultingkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[consultingkind] (
idconsultingkind varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkconsultingkind PRIMARY KEY (idconsultingkind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA contractlength --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contractlength]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contractlength] (
idcontractlength varchar(5) NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcontractlength PRIMARY KEY (idcontractlength,
ayear
)
)
END
GO

-- CREAZIONE TABELLA csa_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csa_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csa_agency] (
idcsa_agency int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NOT NULL,
ente varchar(200) NOT NULL,
idreg int NOT NULL,
isinternal char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcsa_agency PRIMARY KEY (idcsa_agency
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_agency' and id=object_id('csa_agency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_agency
     ON csa_agency
     (
     ente     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_agency
     ON csa_agency
     (
     ente     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_agencypaymethod --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csa_agencypaymethod]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csa_agencypaymethod] (
idcsa_agency int NOT NULL,
idcsa_agencypaymethod int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idreg int NULL,
idregistrypaymethod int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
vocecsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_agencypaymethod PRIMARY KEY (idcsa_agency,
idcsa_agencypaymethod
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_agencypaymethod' and id=object_id('csa_agencypaymethod'))
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_agencypaymethod
     ON csa_agencypaymethod
     (
     idcsa_agency, vocecsa     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_agencypaymethod
     ON csa_agencypaymethod
     (
     idcsa_agency, vocecsa     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_contractkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csa_contractkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csa_contractkind] (
idcsa_contractkind int NOT NULL,
active char(1) NULL,
contractkindcode varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagcr char(1) NOT NULL,
flagkeepalive char(1) NULL,
idunderwriting int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcsa_contractkind PRIMARY KEY (idcsa_contractkind
)
)
END
GO

-- CREAZIONE TABELLA csa_contractkindrules --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csa_contractkindrules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csa_contractkindrules] (
idcsa_contractkind int NOT NULL,
idcsa_rule int NOT NULL,
ayear smallint NOT NULL,
capitoloCSA varchar(200) NULL,
ct datetime NOT NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
ruoloCSA varchar(200) NULL,
 CONSTRAINT xpkcsa_contractkindrules PRIMARY KEY (idcsa_contractkind,
idcsa_rule,
ayear
)
)
END
GO

-- CREAZIONE TABELLA csa_role --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csa_role]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csa_role] (
ruoloCSA varchar(200) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idaccmotivecredit varchar(38) NULL,
idaccmotivedebit varchar(38) NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcsa_role PRIMARY KEY (ruoloCSA
)
)
END
GO

-- CREAZIONE TABELLA csapaymethodlookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csapaymethodlookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csapaymethodlookup] (
idcsapaymethod int NOT NULL,
csa_description varchar(40) NULL,
csa_kind char(2) NOT NULL,
idpaymethod int NULL,
 CONSTRAINT xpkcsapaymethodlookup PRIMARY KEY (idcsapaymethod
)
)
END
GO

-- CREAZIONE TABELLA csapositionlookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[csapositionlookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[csapositionlookup] (
idcsaposition int NOT NULL,
csa_class varchar(200) NULL,
csa_compartment char(1) NULL,
csa_description varchar(200) NULL,
csa_role varchar(4) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idposition int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
supposedtaxable decimal(19,2) NULL,
 CONSTRAINT xpkcsapositionlookup PRIMARY KEY (idcsaposition
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1' and id=object_id('csapositionlookup'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX xi1
     ON csapositionlookup
     (
     csa_class, csa_role     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX xi1
     ON csapositionlookup
     (
     csa_class, csa_role     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA currency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[currency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[currency] (
idcurrency int NOT NULL,
codecurrency varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcurrency PRIMARY KEY (idcurrency
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukcurrency' and id=object_id('currency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukcurrency
     ON currency
     (
     codecurrency     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukcurrency
     ON currency
     (
     codecurrency     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_currency' and id=object_id('currency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_currency
     ON currency
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_currency
     ON currency
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1currency' and id=object_id('currency'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1currency
     ON currency
     (
     codecurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1currency
     ON currency
     (
     codecurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA customdirectrel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customdirectrel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customdirectrel] (
idcustomdirectrel int NOT NULL,
description varchar(50) NOT NULL,
edittype varchar(50) NOT NULL,
filter varchar(200) NULL,
flag int NOT NULL,
fromtable varchar(50) NOT NULL,
insertfilterparent varchar(300) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
listtype varchar(50) NULL,
navigationfilterparent varchar(300) NULL,
totable varchar(50) NOT NULL,
totableview varchar(50) NULL,
 CONSTRAINT xpkcustomdirectrel PRIMARY KEY (idcustomdirectrel
)
)
END
GO

-- CREAZIONE TABELLA customdirectrelcol --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customdirectrelcol]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customdirectrelcol] (
fromfield varchar(50) NOT NULL,
idcustomdirectrel int NOT NULL,
tofield varchar(50) NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
 CONSTRAINT xpkcustomdirectrelcol PRIMARY KEY (fromfield,
idcustomdirectrel,
tofield
)
)
END
GO

-- CREAZIONE TABELLA customedit --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customedit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customedit] (
edittype varchar(50) NOT NULL,
objectname varchar(50) NOT NULL,
caption varchar(80) NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
defaultlisttype varchar(80) NULL,
dllname varchar(80) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
list char(1) NULL,
searchenabled char(1) NULL,
startempty char(1) NULL,
tree char(1) NULL,
 CONSTRAINT xpkcustomedit PRIMARY KEY (edittype,
objectname
)
)
END
GO

-- CREAZIONE TABELLA customgroup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customgroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customgroup] (
idcustomgroup varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(200) NULL,
groupname varchar(80) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcustomgroup PRIMARY KEY (idcustomgroup
)
)
END
GO

-- CREAZIONE TABELLA customgroupoperation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customgroupoperation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customgroupoperation] (
idgroup varchar(50) NOT NULL,
operation char(1) NOT NULL,
tablename varchar(50) NOT NULL,
allowcondition text NULL,
ct datetime NULL,
cu varchar(64) NULL,
defaultisdeny char(1) NOT NULL,
denycondition text NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcustomgroupoperation PRIMARY KEY (idgroup,
operation,
tablename
)
)
END
GO

-- CREAZIONE TABELLA customindirectrel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customindirectrel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customindirectrel] (
idcustomindirectrel int NOT NULL,
description varchar(50) NOT NULL,
edittype varchar(50) NOT NULL,
filtermiddle varchar(150) NULL,
filterparenttable2 varchar(150) NULL,
flag int NOT NULL,
insertfilterparenttable1 varchar(300) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
listtype varchar(50) NULL,
middletable varchar(50) NULL,
navigationfilterparenttable1 varchar(300) NULL,
parenttable1 varchar(50) NOT NULL,
parenttable2 varchar(50) NOT NULL,
parenttable2view varchar(50) NULL,
 CONSTRAINT xpkcustomindirectrel PRIMARY KEY (idcustomindirectrel
)
)
END
GO

-- CREAZIONE TABELLA customindirectrelcol --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customindirectrelcol]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customindirectrelcol] (
idcustomindirectrel int NOT NULL,
parentfield varchar(50) NOT NULL,
parentnumber int NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
middlefield varchar(50) NOT NULL,
 CONSTRAINT xpkcustomindirectrelcol PRIMARY KEY (idcustomindirectrel,
parentfield,
parentnumber
)
)
END
GO

-- CREAZIONE TABELLA customoperator --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customoperator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customoperator] (
idoperator int NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
name varchar(20) NOT NULL,
 CONSTRAINT xpkcustomoperator PRIMARY KEY (idoperator
)
)
END
GO

-- CREAZIONE TABELLA customselection --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customselection]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customselection] (
selectioncode varchar(50) NOT NULL,
editlisttype varchar(50) NULL,
extraparameter varchar(150) NULL,
fieldname varchar(80) NULL,
filter varchar(150) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
relationfield varchar(80) NULL,
selectionname varchar(80) NULL,
selectiontype char(1) NULL,
tablename varchar(80) NULL,
 CONSTRAINT xpkcustomselection PRIMARY KEY (selectioncode
)
)
END
GO

-- CREAZIONE TABELLA customuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customuser] (
idcustomuser varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
username varchar(50) NOT NULL,
 CONSTRAINT xpkcustomuser PRIMARY KEY (idcustomuser
)
)
END
GO

-- CREAZIONE TABELLA customusergroup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customusergroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customusergroup] (
idcustomgroup varchar(50) NOT NULL,
idcustomuser varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcustomusergroup PRIMARY KEY (idcustomgroup,
idcustomuser
)
)
END
GO

-- CREAZIONE TABELLA dbaccess --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbaccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbaccess] (
alpha1 varchar(66) NULL,
iddbdepartment varchar(50) NOT NULL,
login varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL)
END
GO

-- CREAZIONE TABELLA dbdepartment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbdepartment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbdepartment] (
description varchar(150) NULL,
iddbdepartment varchar(50) NOT NULL,
iddep smallint NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smallint NULL,
stop smallint NULL)
END
GO

-- CREAZIONE TABELLA dbuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbuser] (
forename varchar(50) NULL,
initpwd varchar(50) NULL,
login varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start datetime NULL,
stop datetime NULL,
surname varchar(50) NULL)
END
GO

-- CREAZIONE TABELLA dbuseradvice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbuseradvice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbuseradvice] (
codeadvice varchar(30) NOT NULL,
login varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkdbuseradvice PRIMARY KEY (codeadvice,
login
)
)
END
GO

-- CREAZIONE TABELLA ddt_in_motive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ddt_in_motive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ddt_in_motive] (
idddt_in_motive int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
idstoreload_motive int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkddt_in_motive PRIMARY KEY (idddt_in_motive
)
)
END
GO

-- CREAZIONE TABELLA ddt_out_motive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ddt_out_motive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ddt_out_motive] (
idddt_out_motive int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkddt_out_motive PRIMARY KEY (idddt_out_motive
)
)
END
GO

-- CREAZIONE TABELLA deduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[deduction] (
iddeduction int NOT NULL,
calculationkind char(1) NOT NULL,
description varchar(200) NOT NULL,
evaluatesp varchar(50) NOT NULL,
evaluationorder int NULL,
flagdeductibleexpense char(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
taxablecode varchar(20) NOT NULL,
validitystart datetime NULL,
validitystop datetime NULL,
 CONSTRAINT xpkdeduction PRIMARY KEY (iddeduction
)
)
END
GO

-- CREAZIONE TABELLA deductioncode --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deductioncode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[deductioncode] (
ayear int NOT NULL,
iddeduction int NOT NULL,
code varchar(20) NULL,
description varchar(200) NULL,
exemption decimal(19,2) NULL,
longdescription text NULL,
lt datetime NULL,
lu varchar(64) NULL,
maximal decimal(19,2) NULL,
rate decimal(19,6) NULL,
 CONSTRAINT xpkdeductioncode PRIMARY KEY (ayear,
iddeduction
)
)
END
GO

-- CREAZIONE TABELLA department --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[department]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[department] (
iddepartment int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
db varchar(50) NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
server varchar(50) NULL,
userdep varchar(50) NULL,
 CONSTRAINT xpkdepartment PRIMARY KEY (iddepartment
)
)
END
GO

-- CREAZIONE TABELLA dtproperties --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dtproperties]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dtproperties] (
id int NOT NULL,
property varchar(64) NOT NULL,
lvalue image NULL,
objectid int NULL,
uvalue nvarchar NULL,
value varchar(255) NULL,
version int NOT NULL,
 CONSTRAINT xpkdtproperties PRIMARY KEY (id,
property
)
)
END
GO

-- CREAZIONE TABELLA durckind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[durckind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[durckind] (
iddurckind smallint NOT NULL,
description varchar(50) NOT NULL,
 CONSTRAINT xpkdurckind PRIMARY KEY (iddurckind
)
)
END
GO

-- CREAZIONE TABELLA eleco2008 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[eleco2008]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[eleco2008] (
ALIQUOTA float NULL,
CODICE_CATASTALE nvarchar NULL,
COMUNE nvarchar NULL,
DATA_DELIBERA smalldatetime NULL,
idcity int NULL,
NUMERO_DELIBERA int NULL,
PROVINCIA nvarchar NULL,
rate decimal(19,6) NULL)
END
GO

-- CREAZIONE TABELLA ElencoGenerale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ElencoGenerale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ElencoGenerale] (
aliquota decimal(19,6) NULL,
CODICE_CATASTALE nvarchar NULL,
COMUNE nvarchar NULL,
DATA_DELIBERA smalldatetime NULL,
DATA_PUBBLICAZIONE smalldatetime NULL,
NOTE nvarchar NULL,
NUMERO_DELIBERA nvarchar NULL,
PR nvarchar NULL,
vecchia nvarchar NULL)
END
GO

-- CREAZIONE TABELLA emenscontractkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[emenscontractkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[emenscontractkind] (
idemenscontractkind varchar(2) NOT NULL,
ayear int NOT NULL,
active char(1) NULL,
annotations varchar(400) NULL,
description varchar(200) NULL,
flagactivityrequested char(1) NULL,
module varchar(20) NULL,
 CONSTRAINT xpkemenscontractkind PRIMARY KEY (idemenscontractkind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA epcontext --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[epcontext]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[epcontext] (
idepcontext varchar(20) NOT NULL,
kind char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkepcontext PRIMARY KEY (idepcontext
)
)
END
GO

-- CREAZIONE TABELLA epoperation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[epoperation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[epoperation] (
idepoperation varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpkepoperation PRIMARY KEY (idepoperation
)
)
END
GO

-- CREAZIONE TABELLA ese2008 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ese2008]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ese2008] (
aliquota nvarchar NULL,
applicazione nvarchar NULL,
codice_catastale nvarchar NULL,
COMUNE nvarchar NULL,
esenzione float NULL,
idcity int NULL,
provincia nvarchar NULL,
rate decimal(19,6) NULL)
END
GO

-- CREAZIONE TABELLA ese2008b --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ese2008b]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ese2008b] (
aliquota varchar(8000) NULL,
applicazione varchar(8000) NULL,
codice_catastale varchar(8000) NULL,
comune varchar(8000) NULL,
esenzione varchar(8000) NULL,
idcity int NULL,
limit decimal(19,2) NULL,
provincia varchar(8000) NULL,
rate decimal(19,6) NULL)
END
GO

-- CREAZIONE TABELLA evenposition_cf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[evenposition_cf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[evenposition_cf] (
position int NOT NULL,
 CONSTRAINT xpkevenposition_cf PRIMARY KEY (position
)
)
END
GO

-- CREAZIONE TABELLA expirationkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[expirationkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[expirationkind] (
idexpirationkind smallint NOT NULL,
active char(1) NULL,
description varchar(40) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
shorttitle varchar(50) NULL,
 CONSTRAINT xpkexpirationkind PRIMARY KEY (idexpirationkind
)
)
END
GO

-- CREAZIONE TABELLA f24epsanctionkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[f24epsanctionkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[f24epsanctionkind] (
idsanction int NOT NULL,
ayear smallint NOT NULL,
description varchar(100) NOT NULL,
fiscaltaxcode char(4) NOT NULL,
flagagency char(1) NOT NULL,
 CONSTRAINT xpkf24epsanctionkind PRIMARY KEY (idsanction
)
)
END
GO

-- CREAZIONE TABELLA filetype --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[filetype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[filetype] (
idfiletype varchar(20) NOT NULL,
connectionstring varchar(500) NULL,
ext varchar(5) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
querystring varchar(500) NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkfiletype PRIMARY KEY (idfiletype
)
)
END
GO

-- CREAZIONE TABELLA financialactivity --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[financialactivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[financialactivity] (
idfinancialactivity varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinancialactivity PRIMARY KEY (idfinancialactivity,
ayear
)
)
END
GO

-- CREAZIONE TABELLA fiscaltaxregion --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fiscaltaxregion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[fiscaltaxregion] (
idfiscaltaxregion varchar(5) NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcountry int NULL,
idregion int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkfiscaltaxregion PRIMARY KEY (idfiscaltaxregion
)
)
END
GO

-- CREAZIONE TABELLA foreignallowancerule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreignallowancerule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreignallowancerule] (
idforeignallowancerule int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idforeigncountry int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpkforeignallowancerule PRIMARY KEY (idforeignallowancerule
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1foreignallowancerule' and id=object_id('foreignallowancerule'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1foreignallowancerule
     ON foreignallowancerule
     (
     idforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1foreignallowancerule
     ON foreignallowancerule
     (
     idforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA foreignallowanceruledetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreignallowanceruledetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreignallowanceruledetail] (
idforeignallowancerule int NOT NULL,
iddetail int NOT NULL,
advancepercentage decimal(19,6) NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxforeigngroupnumber smallint NOT NULL,
minforeigngroupnumber smallint NOT NULL,
 CONSTRAINT xpkforeignallowanceruledetail PRIMARY KEY (idforeignallowancerule,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA foreigncountry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreigncountry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreigncountry] (
idforeigncountry int NOT NULL,
codeforeigncountry varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag_ue char(1) NULL,
idmacroarea int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkforeigncountry PRIMARY KEY (idforeigncountry
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukforeigncountry' and id=object_id('foreigncountry'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukforeigncountry
     ON foreigncountry
     (
     codeforeigncountry     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukforeigncountry
     ON foreigncountry
     (
     codeforeigncountry     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_foreigncountry' and id=object_id('foreigncountry'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_foreigncountry
     ON foreigncountry
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_foreigncountry
     ON foreigncountry
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1foreigncountry' and id=object_id('foreigncountry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1foreigncountry
     ON foreigncountry
     (
     codeforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1foreigncountry
     ON foreigncountry
     (
     codeforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA foreigngroup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreigngroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreigngroup] (
start smalldatetime NOT NULL,
foreigngroupnumber smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkforeigngroup PRIMARY KEY (start,
foreigngroupnumber
)
)
END
GO

-- CREAZIONE TABELLA foreigngrouprule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreigngrouprule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreigngrouprule] (
idforeigngrouprule int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpkforeigngrouprule PRIMARY KEY (idforeigngrouprule
)
)
END
GO

-- CREAZIONE TABELLA foreigngroupruledetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreigngroupruledetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[foreigngroupruledetail] (
idforeigngrouprule int NOT NULL,
iddetail int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
foreigngroupnumber smallint NOT NULL,
idposition int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxincomeclass int NOT NULL,
minincomeclass int NOT NULL,
 CONSTRAINT xpkforeigngroupruledetail PRIMARY KEY (idforeigngrouprule,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA geo_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_agency] (
idagency int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(50) NULL,
website varchar(60) NULL,
 CONSTRAINT xpkgeo_agency PRIMARY KEY (idagency
)
)
END
GO

-- CREAZIONE TABELLA geo_cap --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_cap]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_cap] (
cap varchar(20) NOT NULL,
idcity int NOT NULL,
 CONSTRAINT xpkgeo_cap PRIMARY KEY (cap
)
)
END
GO

-- CREAZIONE TABELLA geo_cf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_cf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_cf] (
citycode varchar(50) NOT NULL,
idcity int NULL,
 CONSTRAINT xpkgeo_cf PRIMARY KEY (citycode
)
)
END
GO

-- CREAZIONE TABELLA geo_city --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_city]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_city] (
idcity int NOT NULL,
idcountry int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newcity int NULL,
oldcity int NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
title varchar(65) NULL,
 CONSTRAINT xpkgeo_city PRIMARY KEY (idcity
)
)
END
GO

-- CREAZIONE TABELLA geo_city_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_city_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_city_agency] (
idcode int NOT NULL,
idcity int NOT NULL,
idagency int NOT NULL,
version int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
value varchar(20) NULL,
 CONSTRAINT xpkgeo_city_agency PRIMARY KEY (idcode,
idcity,
idagency,
version
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1_geo_city_agency' and id=object_id('geo_city_agency'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1_geo_city_agency
     ON geo_city_agency
     (
     idagency, idcity, idcode     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1_geo_city_agency
     ON geo_city_agency
     (
     idagency, idcity, idcode     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1geo_city_agency' and id=object_id('geo_city_agency'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1geo_city_agency
     ON geo_city_agency
     (
     value, idcode     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1geo_city_agency
     ON geo_city_agency
     (
     value, idcode     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA geo_code --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_code]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_code] (
idcode int NOT NULL,
idagency int NOT NULL,
codename varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkgeo_code PRIMARY KEY (idcode,
idagency
)
)
END
GO

-- CREAZIONE TABELLA geo_country --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_country]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_country] (
idcountry int NOT NULL,
idregion int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newcountry int NULL,
oldcountry int NULL,
province char(2) NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
title varchar(50) NULL,
 CONSTRAINT xpkgeo_country PRIMARY KEY (idcountry
)
)
END
GO

-- CREAZIONE TABELLA geo_country_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_country_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_country_agency] (
idcode int NOT NULL,
idagency int NOT NULL,
idcountry int NOT NULL,
version int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
value varchar(20) NULL,
 CONSTRAINT xpkgeo_country_agency PRIMARY KEY (idcode,
idagency,
idcountry,
version
)
)
END
GO

-- CREAZIONE TABELLA geo_nation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_nation] (
idnation int NOT NULL,
idcontinent int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newnation int NULL,
oldnation int NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
title varchar(65) NULL,
 CONSTRAINT xpkgeo_nation PRIMARY KEY (idnation
)
)
END
GO

-- CREAZIONE TABELLA geo_nation_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nation_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_nation_agency] (
idcode int NOT NULL,
idagency int NOT NULL,
idnation int NOT NULL,
version int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
value varchar(20) NULL,
 CONSTRAINT xpkgeo_nation_agency PRIMARY KEY (idcode,
idagency,
idnation,
version
)
)
END
GO

-- CREAZIONE TABELLA geo_region --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_region]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_region] (
idregion int NOT NULL,
idnation int NULL,
lt datetime NULL,
lu varchar(64) NULL,
newregion int NULL,
oldregion int NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
title varchar(50) NULL,
 CONSTRAINT xpkgeo_region PRIMARY KEY (idregion
)
)
END
GO

-- CREAZIONE TABELLA geo_region_agency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_region_agency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_region_agency] (
idcode int NOT NULL,
idagency int NOT NULL,
idregion int NOT NULL,
version int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
value varchar(20) NULL,
 CONSTRAINT xpkgeo_region_agency PRIMARY KEY (idcode,
idagency,
idregion,
version
)
)
END
GO

-- CREAZIONE TABELLA inpsactivity --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inpsactivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inpsactivity] (
activitycode varchar(20) NOT NULL,
ayear int NOT NULL,
description varchar(150) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkinpsactivity PRIMARY KEY (activitycode,
ayear
)
)
END
GO

-- CREAZIONE TABELLA inpscenter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inpscenter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inpscenter] (
idinpscenter varchar(6) NOT NULL,
ccp varchar(14) NULL,
othercentercode varchar(4) NULL,
title varchar(50) NULL,
 CONSTRAINT xpkinpscenter PRIMARY KEY (idinpscenter
)
)
END
GO

-- CREAZIONE TABELLA intrastatcode --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatcode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatcode] (
idintrastatcode int NOT NULL,
ayear smallint NOT NULL,
code varchar(8) NOT NULL,
description varchar(1000) NOT NULL,
idintrastatmeasure int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkintrastatcode PRIMARY KEY (idintrastatcode
)
)
END
GO

-- CREAZIONE TABELLA intrastatkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatkind] (
idintrastatkind varchar(2) NOT NULL,
description varchar(200) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkintrastatkind PRIMARY KEY (idintrastatkind
)
)
END
GO

-- CREAZIONE TABELLA intrastatmeasure --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatmeasure]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatmeasure] (
idintrastatmeasure int NOT NULL,
code varchar(10) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkintrastatmeasure PRIMARY KEY (idintrastatmeasure
)
)
END
GO

-- CREAZIONE TABELLA intrastatnation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatnation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatnation] (
idintrastatnation varchar(2) NOT NULL,
description varchar(100) NULL,
flague char(1) NULL,
idcurrency int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkintrastatnation PRIMARY KEY (idintrastatnation
)
)
END
GO

-- CREAZIONE TABELLA intrastatpaymethod --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatpaymethod]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatpaymethod] (
idintrastatpaymethod int NOT NULL,
code varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkintrastatpaymethod PRIMARY KEY (idintrastatpaymethod
)
)
END
GO

-- CREAZIONE TABELLA intrastatservice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatservice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatservice] (
idintrastatservice int NOT NULL,
ayear smallint NOT NULL,
code varchar(100) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(400) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkintrastatservice PRIMARY KEY (idintrastatservice
)
)
END
GO

-- CREAZIONE TABELLA intrastatsupplymethod --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[intrastatsupplymethod]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[intrastatsupplymethod] (
idintrastatsupplymethod int NOT NULL,
code varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkintrastatsupplymethod PRIMARY KEY (idintrastatsupplymethod
)
)
END
GO

-- CREAZIONE TABELLA inventorysortinglevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorysortinglevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inventorysortinglevel] (
nlevel tinyint NOT NULL,
codelen tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinventorysortinglevel PRIMARY KEY (nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventorysortinglevel' and id=object_id('inventorysortinglevel'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorysortinglevel
     ON inventorysortinglevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorysortinglevel
     ON inventorysortinglevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventorytree --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytree]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inventorytree] (
idinv int NOT NULL,
codeinv varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idaccmotiveload varchar(36) NULL,
idaccmotiveunload varchar(36) NULL,
lookupcode varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel tinyint NOT NULL,
paridinv int NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkinventorytree PRIMARY KEY (idinv
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorytree
     ON inventorytree
     (
     codeinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorytree
     ON inventorytree
     (
     codeinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytree
     ON inventorytree
     (
     paridinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytree
     ON inventorytree
     (
     paridinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytree
     ON inventorytree
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytree
     ON inventorytree
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventorytreelink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreelink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inventorytreelink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkinventorytreelink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA inventorytreemultifieldkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytreemultifieldkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inventorytreemultifieldkind] (
idinv int NOT NULL,
idmultifieldkind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkinventorytreemultifieldkind PRIMARY KEY (idinv,
idmultifieldkind
)
)
END
GO

-- CREAZIONE TABELLA itinerationparameter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationparameter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationparameter] (
start smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
foreignexemption decimal(19,6) NULL,
italianexemption decimal(19,6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationparameter PRIMARY KEY (start
)
)
END
GO

-- CREAZIONE TABELLA itinerationrefundkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationrefundkind] (
iditinerationrefundkind int NOT NULL,
active char(1) NULL,
codeitinerationrefundkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flagadvance char(1) NULL,
flagbalance char(1) NULL,
flagmedia tinyint NULL,
idaccmotive varchar(36) NULL,
iditinerationrefundkindgroup int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationrefundkind PRIMARY KEY (iditinerationrefundkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukitinerationrefundkind' and id=object_id('itinerationrefundkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitinerationrefundkind
     ON itinerationrefundkind
     (
     codeitinerationrefundkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitinerationrefundkind
     ON itinerationrefundkind
     (
     codeitinerationrefundkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_itinerationrefundkind' and id=object_id('itinerationrefundkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_itinerationrefundkind
     ON itinerationrefundkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_itinerationrefundkind
     ON itinerationrefundkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationrefundkind' and id=object_id('itinerationrefundkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationrefundkind
     ON itinerationrefundkind
     (
     codeitinerationrefundkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationrefundkind
     ON itinerationrefundkind
     (
     codeitinerationrefundkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA itinerationrefundkindgroup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundkindgroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationrefundkindgroup] (
iditinerationrefundkindgroup int NOT NULL,
allowalways char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationrefundkindgroup PRIMARY KEY (iditinerationrefundkindgroup
)
)
END
GO

-- CREAZIONE TABELLA itinerationrefundkindgroupreduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundkindgroupreduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationrefundkindgroupreduction] (
iditinerationrefundkindgroup int NOT NULL,
idreduction varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationrefundkindgroupreduction PRIMARY KEY (iditinerationrefundkindgroup,
idreduction
)
)
END
GO

-- CREAZIONE TABELLA itinerationrefundrule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundrule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationrefundrule] (
iditinerationrefundrule int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpkitinerationrefundrule PRIMARY KEY (iditinerationrefundrule
)
)
END
GO

-- CREAZIONE TABELLA itinerationrefundruledetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationrefundruledetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationrefundruledetail] (
iditinerationrefundrule int NOT NULL,
iddetail int NOT NULL,
advancepercentage decimal(19,6) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag_eu char(1) NOT NULL,
flag_extraeu char(1) NOT NULL,
flag_italy char(1) NOT NULL,
iditinerationrefundkindgroup int NOT NULL,
idposition int NOT NULL,
limit decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxincomeclass int NOT NULL,
minincomeclass int NOT NULL,
nhour_max int NULL,
nhour_min int NULL,
 CONSTRAINT xpkitinerationrefundruledetail PRIMARY KEY (iditinerationrefundrule,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA itinerationstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[itinerationstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[itinerationstatus] (
iditinerationstatus smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
listingorder smallint NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationstatus PRIMARY KEY (iditinerationstatus
)
)
END
GO

-- CREAZIONE TABELLA ivapayperiodicity --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ivapayperiodicity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ivapayperiodicity] (
idivapayperiodicity int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
periodicday int NOT NULL,
periodicity int NOT NULL,
periodicmonth int NOT NULL,
 CONSTRAINT xpkivapayperiodicity PRIMARY KEY (idivapayperiodicity
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_ivapayperiodicity' and id=object_id('ivapayperiodicity'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivapayperiodicity
     ON ivapayperiodicity
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivapayperiodicity
     ON ivapayperiodicity
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA journal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[journal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[journal] (
fieldname varchar(50) NOT NULL,
operationdatetime datetime NOT NULL,
opkind char(1) NOT NULL,
primarykey varchar(255) NOT NULL,
tablename varchar(150) NOT NULL,
iddbdepartment varchar(50) NOT NULL,
computername varchar(128) NULL,
computeruser varchar(128) NULL,
dbuser varchar(50) NULL,
idflowchart varchar(34) NULL,
notes text NULL,
oldvalue varchar(255) NULL,
olenotes image NULL,
value varchar(255) NULL,
 CONSTRAINT xpkjournal PRIMARY KEY (fieldname,
operationdatetime,
opkind,
primarykey,
tablename,
iddbdepartment
)
)
END
GO

-- CREAZIONE TABELLA journaltablesetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[journaltablesetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[journaltablesetup] (
tablename varchar(150) NOT NULL,
opkind char(1) NOT NULL,
 CONSTRAINT xpkjournaltablesetup PRIMARY KEY (tablename,
opkind
)
)
END
GO

-- CREAZIONE TABELLA linkedserveraccess --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[linkedserveraccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[linkedserveraccess] (
dbservername varchar(200) NULL,
istance varchar(200) NULL,
linkedservername varchar(200) NULL)
END
GO

-- CREAZIONE TABELLA list --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[list]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[list] (
idlist int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
extbarcode varchar(50) NULL,
extcode varchar(50) NULL,
has_expiry char(1) NOT NULL,
idlistclass varchar(36) NOT NULL,
idpackage int NULL,
idunit int NULL,
intbarcode varchar(50) NULL,
intcode varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmaxorder decimal(19,2) NULL,
nmin decimal(19,2) NULL,
ntoreorder decimal(19,2) NULL,
pic image NULL,
picext varchar(10) NULL,
timesupply int NULL,
tounload char(1) NULL,
unitsforpackage int NULL,
validitystop datetime NULL,
 CONSTRAINT xpklist PRIMARY KEY (idlist
)
)
END
GO

-- CREAZIONE TABELLA listclass --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[listclass]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[listclass] (
idlistclass varchar(36) NOT NULL,
active char(1) NOT NULL,
assetkind char(1) NULL,
authrequired char(1) NULL,
codelistclass varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag int NULL,
idaccmotive varchar(36) NULL,
idintrastatsupplymethod int NULL,
idinv int NULL,
intra12operationkind char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridlistclass varchar(36) NULL,
printingorder varchar(50) NOT NULL,
rtf image NULL,
title varchar(150) NOT NULL,
txt text NULL,
va3type char(1) NULL,
 CONSTRAINT xpklistclass PRIMARY KEY (idlistclass
)
)
END
GO

-- CREAZIONE TABELLA lookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[lookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[lookup] (
tablename varchar(50) NOT NULL,
newcol varchar(50) NOT NULL,
created char(1) NULL,
lookuptable varchar(50) NULL,
 CONSTRAINT xpklookup PRIMARY KEY (tablename,
newcol
)
)
END
GO

-- CREAZIONE TABELLA macroarea --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[macroarea]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[macroarea] (
idmacroarea int NOT NULL,
amount_1 decimal(19,2) NULL,
amount_2 decimal(19,2) NULL,
codemacroarea varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
stop datetime NULL,
 CONSTRAINT xpkmacroarea PRIMARY KEY (idmacroarea
)
)
END
GO

-- CREAZIONE TABELLA macroareaboard --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[macroareaboard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[macroareaboard] (
idmacroareaboard int NOT NULL,
amount_1 decimal(19,2) NULL,
amount_2 decimal(19,2) NULL,
codemacroareaboard varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
stop datetime NULL,
 CONSTRAINT xpkmacroareaboard PRIMARY KEY (idmacroareaboard
)
)
END
GO

-- CREAZIONE TABELLA mainaccountingyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[mainaccountingyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[mainaccountingyear] (
ayear int NOT NULL,
completed char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmainaccountingyear PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA maintenancekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[maintenancekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[maintenancekind] (
idmaintenancekind int NOT NULL,
active char(1) NULL,
codemaintenancekind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmaintenancekind PRIMARY KEY (idmaintenancekind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukmaintenancekind' and id=object_id('maintenancekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukmaintenancekind
     ON maintenancekind
     (
     codemaintenancekind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukmaintenancekind
     ON maintenancekind
     (
     codemaintenancekind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_maintenancekind' and id=object_id('maintenancekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_maintenancekind
     ON maintenancekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_maintenancekind
     ON maintenancekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1maintenancekind' and id=object_id('maintenancekind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1maintenancekind
     ON maintenancekind
     (
     codemaintenancekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1maintenancekind
     ON maintenancekind
     (
     codemaintenancekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA maritalstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[maritalstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[maritalstatus] (
idmaritalstatus varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmaritalstatus PRIMARY KEY (idmaritalstatus
)
)
END
GO

-- CREAZIONE TABELLA mod770_details --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[mod770_details]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[mod770_details] (
ayear int NOT NULL,
frame varchar(5) NOT NULL,
colnumber varchar(3) NOT NULL,
admittedvalues varchar(150) NULL,
blockingcontrols varchar(470) NULL,
colorder int NULL,
correspondence varchar(340) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(255) NULL,
fieldlen int NULL,
format varchar(4) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
position int NULL,
row varchar(3) NULL,
section varchar(140) NULL,
 CONSTRAINT xpkmod770_details PRIMARY KEY (ayear,
frame,
colnumber
)
)
END
GO

-- CREAZIONE TABELLA monthname --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[monthname]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[monthname] (
code int NOT NULL,
cfvalue char(1) NULL,
title varchar(20) NULL,
 CONSTRAINT xpkmonthname PRIMARY KEY (code
)
)
END
GO

-- CREAZIONE TABELLA motive770 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[motive770]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[motive770] (
idmot varchar(20) NOT NULL,
ayear smallint NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkmotive770 PRIMARY KEY (idmot,
ayear
)
)
END
GO

-- CREAZIONE TABELLA motive770service --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[motive770service]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[motive770service] (
idser int NOT NULL,
ayear smallint NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idmot varchar(20) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkmotive770service PRIMARY KEY (idser,
ayear
)
)
END
GO

-- CREAZIONE TABELLA multifieldkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[multifieldkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[multifieldkind] (
idmultifieldkind int NOT NULL,
allownull char(1) NOT NULL,
fieldcode varchar(20) NOT NULL,
fieldname varchar(50) NOT NULL,
len int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ordernumber smallint NULL,
systype varchar(50) NOT NULL,
tabname varchar(50) NULL,
tag varchar(30) NULL,
 CONSTRAINT xpkmultifieldkind PRIMARY KEY (idmultifieldkind
)
)
END
GO

-- CREAZIONE TABELLA oddposition_cf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[oddposition_cf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[oddposition_cf] (
position int NOT NULL,
 CONSTRAINT xpkoddposition_cf PRIMARY KEY (position
)
)
END
GO

-- CREAZIONE TABELLA otherinsurance --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[otherinsurance]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[otherinsurance] (
idotherinsurance varchar(20) NOT NULL,
ayear int NOT NULL,
description varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkotherinsurance PRIMARY KEY (idotherinsurance,
ayear
)
)
END
GO

-- CREAZIONE TABELLA package --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[package]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[package] (
idpackage int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpackage PRIMARY KEY (idpackage
)
)
END
GO

-- CREAZIONE TABELLA parasubcontractlist --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[parasubcontractlist]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[parasubcontractlist] (
ayear int NOT NULL,
idcon varchar(8) NOT NULL,
iddbdepartment varchar(50) NOT NULL,
balanced char(1) NOT NULL,
idreg int NOT NULL,
linked char(1) NOT NULL,
 CONSTRAINT xpkparasubcontractlist PRIMARY KEY (ayear,
idcon,
iddbdepartment
)
)
END
GO

-- CREAZIONE TABELLA patrimony --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[patrimony]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[patrimony] (
idpatrimony varchar(31) NOT NULL,
active char(1) NULL,
ayear smallint NOT NULL,
codepatrimony varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel char(1) NOT NULL,
paridpatrimony varchar(31) NOT NULL,
patpart char(1) NOT NULL,
printingorder varchar(50) NOT NULL,
rtf image NULL,
title varchar(200) NOT NULL,
txt text NULL,
 CONSTRAINT xpkpatrimony PRIMARY KEY (idpatrimony
)
)
END
GO

-- CREAZIONE TABELLA patrimonylevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[patrimonylevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[patrimonylevel] (
ayear smallint NOT NULL,
nlevel char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpatrimonylevel PRIMARY KEY (ayear,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA patrimonylookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[patrimonylookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[patrimonylookup] (
oldidpatrimony varchar(31) NOT NULL,
newidpatrimony varchar(31) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkpatrimonylookup PRIMARY KEY (oldidpatrimony,
newidpatrimony
)
)
END
GO

-- CREAZIONE TABELLA paymethod --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[paymethod]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[paymethod] (
idpaymethod int NOT NULL,
active char(1) NULL,
allowdeputy char(1) NULL,
committeeamount decimal(19,2) NULL,
committeecode varchar(5) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag int NOT NULL,
footerpaymentadvice varchar(600) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxamount decimal(19,2) NULL,
methodbankcode varchar(20) NULL,
minamount decimal(19,2) NULL,
 CONSTRAINT xpkpaymethod PRIMARY KEY (idpaymethod
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_paymethod' and id=object_id('paymethod'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_paymethod
     ON paymethod
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_paymethod
     ON paymethod
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA placcount --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[placcount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[placcount] (
idplaccount varchar(31) NOT NULL,
active char(1) NOT NULL,
ayear smallint NOT NULL,
codeplaccount varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel char(1) NOT NULL,
paridplaccount varchar(31) NOT NULL,
placcpart char(1) NOT NULL,
printingorder varchar(50) NOT NULL,
rtf image NULL,
title varchar(200) NOT NULL,
txt text NULL,
 CONSTRAINT xpkplaccount PRIMARY KEY (idplaccount
)
)
END
GO

-- CREAZIONE TABELLA placcountlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[placcountlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[placcountlevel] (
ayear smallint NOT NULL,
nlevel char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkplaccountlevel PRIMARY KEY (ayear,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA placcountlookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[placcountlookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[placcountlookup] (
oldidplaccount varchar(31) NOT NULL,
newidplaccount varchar(31) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkplaccountlookup PRIMARY KEY (oldidplaccount,
newidplaccount
)
)
END
GO

-- CREAZIONE TABELLA position --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[position]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[position] (
idposition int NOT NULL,
active char(1) NULL,
codeposition varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
foreignclass char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxincomeclass smallint NULL,
 CONSTRAINT xpkposition PRIMARY KEY (idposition
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukposition' and id=object_id('position'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukposition
     ON position
     (
     codeposition     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukposition
     ON position
     (
     codeposition     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_position' and id=object_id('position'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_position
     ON position
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_position
     ON position
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1position' and id=object_id('position'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1position
     ON position
     (
     codeposition     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1position
     ON position
     (
     codeposition     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA positionworkcontract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[positionworkcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[positionworkcontract] (
idposition varchar(5) NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
flagforcedlength char(1) NOT NULL,
flagforcedtime char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpositionworkcontract PRIMARY KEY (idposition,
ayear
)
)
END
GO

-- CREAZIONE TABELLA reduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[reduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[reduction] (
idreduction varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkreduction PRIMARY KEY (idreduction
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_reduction' and id=object_id('reduction'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_reduction
     ON reduction
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_reduction
     ON reduction
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA reductionrule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[reductionrule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[reductionrule] (
idreductionrule int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpkreductionrule PRIMARY KEY (idreductionrule
)
)
END
GO

-- CREAZIONE TABELLA reductionruledetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[reductionruledetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[reductionruledetail] (
idreductionrule int NOT NULL,
iddetail int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idreduction varchar(20) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
reductionpercentage decimal(19,6) NOT NULL,
 CONSTRAINT xpkreductionruledetail PRIMARY KEY (idreductionrule,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA registry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry] (
idreg int NOT NULL,
active char(1) NOT NULL,
annotation varchar(400) NULL,
authorization_free char(1) NULL,
badgecode varchar(20) NULL,
birthdate smalldatetime NULL,
ccp varchar(12) NULL,
cf varchar(16) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
extmatricula varchar(40) NULL,
flagbankitaliaproceeds char(1) NULL,
foreigncf varchar(40) NULL,
forename varchar(50) NULL,
gender char(1) NULL,
idaccmotivecredit varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idcategory varchar(2) NULL,
idcentralizedcategory varchar(20) NULL,
idcity int NULL,
idexternal int NULL,
idmaritalstatus varchar(20) NULL,
idnation int NULL,
idregistryclass varchar(2) NULL,
idregistrykind int NULL,
idtitle varchar(20) NULL,
location varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maritalsurname varchar(50) NULL,
multi_cf char(1) NULL,
p_iva varchar(15) NULL,
residence int NOT NULL,
rtf image NULL,
surname varchar(50) NULL,
title varchar(100) NOT NULL,
toredirect int NULL,
txt text NULL,
 CONSTRAINT xpkregistry PRIMARY KEY (idreg
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry
     (
     idregistrykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry
     (
     idregistrykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA registryaddress --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddress]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryaddress] (
idreg int NOT NULL,
start smalldatetime NOT NULL,
idaddresskind int NOT NULL,
active char(1) NULL,
address varchar(100) NULL,
annotations varchar(400) NULL,
cap varchar(20) NULL,
ct datetime NULL,
cu varchar(64) NULL,
flagforeign char(1) NULL,
idcity int NULL,
idnation int NULL,
location varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
officename varchar(50) NULL,
recipientagency varchar(50) NULL,
stop smalldatetime NULL,
 CONSTRAINT xpkregistryaddress PRIMARY KEY (idreg,
start,
idaddresskind
)
)
END
GO

-- CREAZIONE TABELLA registrycf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrycf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrycf] (
idreg int NOT NULL,
idregistrycf int NOT NULL,
cf varchar(16) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NULL,
stop datetime NOT NULL,
 CONSTRAINT xpkregistrycf PRIMARY KEY (idreg,
idregistrycf
)
)
END
GO

-- CREAZIONE TABELLA registryclass --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryclass]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryclass] (
idregistryclass varchar(2) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flagbadgecode char(1) NOT NULL,
flagbadgecode_forced char(1) NOT NULL,
flagCF char(1) NOT NULL,
flagcf_forced char(1) NOT NULL,
flagcfbutton char(1) NULL,
flagextmatricula char(1) NOT NULL,
flagextmatricula_forced char(1) NOT NULL,
flagfiscalresidence char(1) NOT NULL,
flagfiscalresidence_forced char(1) NOT NULL,
flagforeigncf char(1) NOT NULL,
flagforeigncf_forced char(1) NOT NULL,
flaghuman char(1) NULL,
flaginfofromcfbutton char(1) NULL,
flagmaritalstatus char(1) NOT NULL,
flagmaritalstatus_forced char(1) NOT NULL,
flagmaritalsurname char(1) NOT NULL,
flagmaritalsurname_forced char(1) NOT NULL,
flagothers char(1) NOT NULL,
flagothers_forced char(1) NOT NULL,
flagp_iva char(1) NOT NULL,
flagp_iva_forced char(1) NOT NULL,
flagqualification char(1) NOT NULL,
flagqualification_forced char(1) NOT NULL,
flagresidence char(1) NOT NULL,
flagresidence_forced char(1) NOT NULL,
flagtitle char(1) NOT NULL,
flagtitle_forced char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkregistryclass PRIMARY KEY (idregistryclass
)
)
END
GO

-- CREAZIONE TABELLA registrycvattachment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrycvattachment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrycvattachment] (
idreg int NOT NULL,
idregistrycvattachment int NOT NULL,
attachment image NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
filename varchar(200) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
referencedate datetime NULL,
 CONSTRAINT xpkregistrycvattachment PRIMARY KEY (idreg,
idregistrycvattachment
)
)
END
GO

-- CREAZIONE TABELLA registrydurc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydurc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrydurc] (
idregistrydurc int NOT NULL,
idreg int NOT NULL,
adate datetime NULL,
buildingcode varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
doc varchar(35) NULL,
docdate datetime NULL,
durccertification image NULL,
iddurckind smallint NULL,
inailcode varchar(50) NULL,
inpscode varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(50) NOT NULL,
otherinsurancecode varchar(50) NULL,
rtf image NULL,
selfcertification image NULL,
start datetime NULL,
stop datetime NULL,
txt text NULL,
 CONSTRAINT xpkregistrydurc PRIMARY KEY (idregistrydurc,
idreg
)
)
END
GO

-- CREAZIONE TABELLA registrykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrykind] (
idregistrykind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode varchar(20) NOT NULL,
 CONSTRAINT xpkregistrykind PRIMARY KEY (idregistrykind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukregistrykind' and id=object_id('registrykind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukregistrykind
     ON registrykind
     (
     sortcode     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukregistrykind
     ON registrykind
     (
     sortcode     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_registrykind' and id=object_id('registrykind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_registrykind
     ON registrykind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_registrykind
     ON registrykind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registrykind' and id=object_id('registrykind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrykind
     ON registrykind
     (
     sortcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrykind
     ON registrykind
     (
     sortcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA registrylegalstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrylegalstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrylegalstatus] (
idreg int NOT NULL,
idregistrylegalstatus int NOT NULL,
active char(1) NULL,
csa_class varchar(20) NULL,
csa_compartment char(1) NULL,
csa_role varchar(4) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idposition int NULL,
incomeclass smallint NULL,
incomeclassvalidity smalldatetime NULL,
lt datetime NULL,
lu varchar(64) NULL,
rtf image NULL,
start smalldatetime NOT NULL,
stop smalldatetime NULL,
txt text NULL,
 CONSTRAINT xpkregistrylegalstatus PRIMARY KEY (idreg,
idregistrylegalstatus
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registrylegalstatus' and id=object_id('registrylegalstatus'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrylegalstatus
     ON registrylegalstatus
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrylegalstatus
     ON registrylegalstatus
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3registrylegalstatus' and id=object_id('registrylegalstatus'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3registrylegalstatus
     ON registrylegalstatus
     (
     idposition     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3registrylegalstatus
     ON registrylegalstatus
     (
     idposition     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA registrypaymethod --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrypaymethod]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrypaymethod] (
idreg int NOT NULL,
idregistrypaymethod int NOT NULL,
active char(1) NULL,
biccode varchar(20) NULL,
cc varchar(30) NULL,
cin varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
extracode varchar(10) NULL,
flagstandard char(1) NULL,
iban varchar(50) NULL,
idbank varchar(20) NULL,
idcab varchar(20) NULL,
idcurrency int NULL,
iddeputy int NULL,
idexpirationkind smallint NULL,
idpaymethod int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paymentdescr varchar(150) NULL,
paymentexpiring smallint NULL,
refexternaldoc varchar(5) NULL,
regmodcode varchar(50) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkregistrypaymethod PRIMARY KEY (idreg,
idregistrypaymethod
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registrypaymethod' and id=object_id('registrypaymethod'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrypaymethod
     ON registrypaymethod
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrypaymethod
     ON registrypaymethod
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2registrypaymethod' and id=object_id('registrypaymethod'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2registrypaymethod
     ON registrypaymethod
     (
     idpaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2registrypaymethod
     ON registrypaymethod
     (
     idpaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3registrypaymethod' and id=object_id('registrypaymethod'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3registrypaymethod
     ON registrypaymethod
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3registrypaymethod
     ON registrypaymethod
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA registrypiva --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrypiva]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrypiva] (
idreg int NOT NULL,
idregistrypiva int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
p_iva varchar(15) NOT NULL,
start datetime NULL,
stop datetime NULL,
 CONSTRAINT xpkregistrypiva PRIMARY KEY (idreg,
idregistrypiva
)
)
END
GO

-- CREAZIONE TABELLA registryreference --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryreference]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryreference] (
idreg int NOT NULL,
idregistryreference int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
faxnumber varchar(50) NULL,
flagdefault char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mobilenumber varchar(20) NULL,
msnnumber varchar(50) NULL,
passwordweb varchar(40) NULL,
phonenumber varchar(50) NULL,
referencename varchar(50) NOT NULL,
registryreferencerole varchar(50) NULL,
rtf image NULL,
skypenumber varchar(50) NULL,
txt text NULL,
userweb varchar(40) NULL,
 CONSTRAINT xpkregistryreference PRIMARY KEY (idreg,
idregistryreference
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registryreference' and id=object_id('registryreference'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registryreference
     ON registryreference
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registryreference
     ON registryreference
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA registryrole --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryrole]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryrole] (
idreg int NOT NULL,
idrole varchar(5) NOT NULL,
start smalldatetime NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
stop smalldatetime NULL,
txt text NULL,
 CONSTRAINT xpkregistryrole PRIMARY KEY (idreg,
idrole,
start
)
)
END
GO

-- CREAZIONE TABELLA registrytaxablestatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrytaxablestatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrytaxablestatus] (
start smalldatetime NOT NULL,
idreg int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
supposedincome decimal(19,2) NULL,
txt text NULL,
 CONSTRAINT xpkregistrytaxablestatus PRIMARY KEY (start,
idreg
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registrytaxablestatus' and id=object_id('registrytaxablestatus'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrytaxablestatus
     ON registrytaxablestatus
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrytaxablestatus
     ON registrytaxablestatus
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA residence --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[residence]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[residence] (
idresidence int NOT NULL,
active char(1) NULL,
coderesidence varchar(10) NOT NULL,
description varchar(60) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkresidence PRIMARY KEY (idresidence
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukresidence' and id=object_id('residence'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukresidence
     ON residence
     (
     coderesidence     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukresidence
     ON residence
     (
     coderesidence     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1residence' and id=object_id('residence'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1residence
     ON residence
     (
     coderesidence     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1residence
     ON residence
     (
     coderesidence     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA restrictedfunction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[restrictedfunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[restrictedfunction] (
idrestrictedfunction int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
variablename varchar(50) NOT NULL,
 CONSTRAINT xpkrestrictedfunction PRIMARY KEY (idrestrictedfunction
)
)
END
GO

-- CREAZIONE TABELLA role --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[role]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[role] (
idrole varchar(5) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idregistryclass varchar(2) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkrole PRIMARY KEY (idrole
)
)
END
GO

-- CREAZIONE TABELLA roleservice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[roleservice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[roleservice] (
idrole varchar(5) NOT NULL,
idser int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
txt text NULL,
 CONSTRAINT xpkroleservice PRIMARY KEY (idrole,
idser
)
)
END
GO

-- CREAZIONE TABELLA securitycondition --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[securitycondition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[securitycondition] (
idrestrictedfunction int NOT NULL,
idsecuritycondition int NOT NULL,
allowcondition text NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
defaultisdeny char(1) NOT NULL,
denycondition text NULL,
idcustomgroup varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
operation char(1) NOT NULL,
tablename varchar(50) NOT NULL,
 CONSTRAINT xpksecuritycondition PRIMARY KEY (idrestrictedfunction,
idsecuritycondition
)
)
END
GO

-- CREAZIONE TABELLA securitycondition2 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[securitycondition2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[securitycondition2] (
idrestrictedfunction int NOT NULL,
idsecuritycondition int NOT NULL,
allowcondition text NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
defaultisdeny char(1) NOT NULL,
denycondition text NULL,
idcustomgroup varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
operation char(1) NOT NULL,
tablename varchar(50) NOT NULL,
 CONSTRAINT xpksecuritycondition2 PRIMARY KEY (idrestrictedfunction,
idsecuritycondition
)
)
END
GO

-- CREAZIONE TABELLA securitycondition3 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[securitycondition3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[securitycondition3] (
idrestrictedfunction int NOT NULL,
idsecuritycondition int NOT NULL,
allowcondition text NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
defaultisdeny char(1) NOT NULL,
denycondition text NULL,
idcustomgroup varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
operation char(1) NOT NULL,
tablename varchar(50) NOT NULL,
 CONSTRAINT xpksecuritycondition3 PRIMARY KEY (idrestrictedfunction,
idsecuritycondition
)
)
END
GO

-- CREAZIONE TABELLA securityvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[securityvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[securityvar] (
idsecurityvar int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NOT NULL,
kind char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
value text NULL,
variablename varchar(50) NOT NULL,
 CONSTRAINT xpksecurityvar PRIMARY KEY (idsecurityvar
)
)
END
GO

-- CREAZIONE TABELLA service --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[service]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[service] (
idser int NOT NULL,
active char(1) NULL,
allowedit char(1) NULL,
certificatekind char(1) NULL,
codeser varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagalwaysinfiscalmodels char(1) NULL,
flagapplyabatements char(1) NULL,
flagdistraint char(1) NULL,
flagforeign char(1) NULL,
flagneedbalance char(1) NULL,
flagonlyfiscalabatement char(1) NOT NULL,
idmotive int NULL,
itinerationvisible char(1) NULL,
ivaamount varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
module varchar(15) NULL,
rec770kind varchar(50) NULL,
voce8000 varchar(10) NULL,
webdefault char(1) NULL,
 CONSTRAINT xpkservice PRIMARY KEY (idser
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukservice' and id=object_id('service'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukservice
     ON service
     (
     codeser     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukservice
     ON service
     (
     codeser     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_service' and id=object_id('service'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_service
     ON service
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_service
     ON service
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA servicetax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[servicetax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[servicetax] (
idser int NOT NULL,
taxcode int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkservicetax PRIMARY KEY (idser,
taxcode
)
)
END
GO

-- CREAZIONE TABELLA sortabletable --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sortabletable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sortabletable] (
tablename varchar(150) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpksortabletable PRIMARY KEY (tablename
)
)
END
GO

-- CREAZIONE TABELLA stamphandling --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stamphandling]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stamphandling] (
idstamphandling int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag int NULL,
flagdefault char(1) NOT NULL,
handlingbankcode varchar(20) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkstamphandling PRIMARY KEY (idstamphandling
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_stamphandling' and id=object_id('stamphandling'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stamphandling
     ON stamphandling
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stamphandling
     ON stamphandling
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA storeload_motive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[storeload_motive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[storeload_motive] (
idstoreload_motive int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NULL,
flag_invoicedefault char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkstoreload_motive PRIMARY KEY (idstoreload_motive
)
)
END
GO

-- CREAZIONE TABELLA storeunload_motive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[storeunload_motive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[storeunload_motive] (
idstoreunload_motive int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkstoreunload_motive PRIMARY KEY (idstoreunload_motive
)
)
END
GO

-- CREAZIONE TABELLA sysdiagrams --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sysdiagrams]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sysdiagrams] (
diagram_id int NOT NULL,
definition varbinary NULL,
name sysname NOT NULL,
principal_id int NOT NULL,
version int NULL,
 CONSTRAINT xpksysdiagrams PRIMARY KEY (diagram_id
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UK_principal_name' and id=object_id('sysdiagrams'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UK_principal_name
     ON sysdiagrams
     (
     principal_id, name     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UK_principal_name
     ON sysdiagrams
     (
     principal_id, name     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA tablename_noview --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tablename_noview]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tablename_noview] (
oldtable varchar(50) NOT NULL,
cfg varchar(50) NULL,
chk varchar(50) NULL,
dbo varchar(10) NULL,
newtable varchar(50) NOT NULL,
tipocopia varchar(50) NULL,
xtype varchar(10) NULL,
 CONSTRAINT xpktablename_noview PRIMARY KEY (oldtable
)
)
END
GO

-- CREAZIONE TABELLA tax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tax] (
taxcode int NOT NULL,
active char(1) NULL,
appliancebasis char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
fiscaltaxcode varchar(20) NULL,
flagunabatable char(1) NULL,
geoappliance char(1) NULL,
idaccmotive_cost varchar(36) NULL,
idaccmotive_debit varchar(36) NULL,
idaccmotive_pay varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maintaxcode int NULL,
taxablecode varchar(20) NULL,
taxkind smallint NOT NULL,
taxref varchar(20) NOT NULL,
 CONSTRAINT xpktax PRIMARY KEY (taxcode
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uktax' and id=object_id('tax'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktax
     ON tax
     (
     taxref     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktax
     ON tax
     (
     taxref     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA tax2 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tax2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tax2] (
taxcode int NOT NULL,
taxref varchar(20) NOT NULL,
 CONSTRAINT xpktax2 PRIMARY KEY (taxcode
)
)
END
GO

-- CREAZIONE TABELLA taxablekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxablekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxablekind] (
taxablecode varchar(20) NOT NULL,
ayear int NOT NULL,
active char(1) NOT NULL,
description varchar(50) NOT NULL,
evaluationorder int NOT NULL,
idtaxablekind varchar(20) NULL,
lt datetime NULL,
lu varchar(64) NULL,
roundingkind char(1) NULL,
spcalcannualtaxable varchar(50) NOT NULL,
spcalcrefertaxable varchar(50) NOT NULL,
 CONSTRAINT xpktaxablekind PRIMARY KEY (taxablecode,
ayear
)
)
END
GO

-- CREAZIONE TABELLA taxableminmax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxableminmax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxableminmax] (
taxablecode varchar(20) NOT NULL,
ayear int NOT NULL,
startmonth int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
maximal decimal(19,2) NULL,
minimum decimal(19,2) NULL,
stopmonth int NOT NULL,
 CONSTRAINT xpktaxableminmax PRIMARY KEY (taxablecode,
ayear,
startmonth
)
)
END
GO

-- CREAZIONE TABELLA taxratebracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratebracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxratebracket] (
taxcode int NOT NULL,
idtaxratestart int NOT NULL,
nbracket smallint NOT NULL,
admindenominator decimal(19,8) NOT NULL,
adminnumerator decimal(19,8) NOT NULL,
adminrate decimal(19,8) NOT NULL,
employdenominator decimal(19,8) NOT NULL,
employnumerator decimal(19,8) NOT NULL,
employrate decimal(19,8) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxamount decimal(19,2) NULL,
minamount decimal(19,2) NULL,
 CONSTRAINT xpktaxratebracket PRIMARY KEY (taxcode,
idtaxratestart,
nbracket
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x1taxratebracket' and id=object_id('taxratebracket'))
BEGIN
     CREATE NONCLUSTERED INDEX x1taxratebracket
     ON taxratebracket
     (
     taxcode, idtaxratestart, minamount     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x1taxratebracket
     ON taxratebracket
     (
     taxcode, idtaxratestart, minamount     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA taxratecitybracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratecitybracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxratecitybracket] (
idcity int NOT NULL,
taxcode int NOT NULL,
idtaxratecitystart int NOT NULL,
nbracket int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
maxamount decimal(19,8) NULL,
minamount decimal(19,8) NULL,
rate decimal(19,6) NOT NULL,
 CONSTRAINT xpktaxratecitybracket PRIMARY KEY (idcity,
taxcode,
idtaxratecitystart,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA taxratecitystart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratecitystart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxratecitystart] (
idcity int NOT NULL,
taxcode int NOT NULL,
idtaxratecitystart int NOT NULL,
annotations varchar(400) NULL,
enforcement char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpktaxratecitystart PRIMARY KEY (idcity,
taxcode,
idtaxratecitystart
)
)
END
GO

-- CREAZIONE TABELLA taxrateregionbracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregionbracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxrateregionbracket] (
idregion int NOT NULL,
taxcode int NOT NULL,
idtaxrateregionstart int NOT NULL,
nbracket smallint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxamount decimal(19,2) NULL,
minamount decimal(19,2) NULL,
rate decimal(19,8) NOT NULL,
 CONSTRAINT xpktaxrateregionbracket PRIMARY KEY (idregion,
taxcode,
idtaxrateregionstart,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA taxrateregioncitybracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregioncitybracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxrateregioncitybracket] (
idcity int NOT NULL,
taxcode int NOT NULL,
idtaxrateregioncitystart int NOT NULL,
nbracket int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxamount decimal(19,2) NULL,
minamount decimal(19,2) NULL,
rate decimal(19,8) NULL,
 CONSTRAINT xpktaxrateregioncitybracket PRIMARY KEY (idcity,
taxcode,
idtaxrateregioncitystart,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA taxrateregioncitystart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregioncitystart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxrateregioncitystart] (
idcity int NOT NULL,
taxcode int NOT NULL,
idtaxrateregioncitystart int NOT NULL,
enforcement char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpktaxrateregioncitystart PRIMARY KEY (idcity,
taxcode,
idtaxrateregioncitystart
)
)
END
GO

-- CREAZIONE TABELLA taxrateregionstart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregionstart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxrateregionstart] (
idregion int NOT NULL,
taxcode int NOT NULL,
idtaxrateregionstart int NOT NULL,
enforcement char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
 CONSTRAINT xpktaxrateregionstart PRIMARY KEY (idregion,
taxcode,
idtaxrateregionstart
)
)
END
GO

-- CREAZIONE TABELLA taxratestart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxratestart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[taxratestart] (
taxcode int NOT NULL,
idtaxratestart int NOT NULL,
enforcement char(1) NULL,
lt datetime NOT NULL,
lu varchar(30) NOT NULL,
start datetime NOT NULL,
taxabledenominator decimal(19,8) NULL,
taxablenumerator decimal(19,8) NULL,
 CONSTRAINT xpktaxratestart PRIMARY KEY (taxcode,
idtaxratestart
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x1taxratestart' and id=object_id('taxratestart'))
BEGIN
     CREATE NONCLUSTERED INDEX x1taxratestart
     ON taxratestart
     (
     taxcode, start     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x1taxratestart
     ON taxratestart
     (
     taxcode, start     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA title --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[title]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[title] (
idtitle varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktitle PRIMARY KEY (idtitle
)
)
END
GO

-- CREAZIONE TABELLA unifiedf24ep --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedf24ep]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedf24ep] (
idunifiedf24ep int NOT NULL,
adate smalldatetime NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmonth int NOT NULL,
paymentdate smalldatetime NOT NULL,
 CONSTRAINT xpkunifiedf24ep PRIMARY KEY (idunifiedf24ep
)
)
END
GO

-- CREAZIONE TABELLA unifiedf24epsanction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedf24epsanction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedf24epsanction] (
idsanctionf24 int NOT NULL,
idunifiedf24ep int NOT NULL,
amount decimal(19,2) NULL,
ayear smallint NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
idsanction int NOT NULL,
 CONSTRAINT xpkunifiedf24epsanction PRIMARY KEY (idsanctionf24,
idunifiedf24ep
)
)
END
GO

-- CREAZIONE TABELLA unifiedivaregister --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedivaregister]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedivaregister] (
yinv smallint NOT NULL,
idivaregisterkind varchar(20) NOT NULL,
unifiedninv int NOT NULL,
iddbdepartment varchar(50) NULL,
idinvkind int NULL,
ninv int NULL,
 CONSTRAINT xpkunifiedivaregister PRIMARY KEY (yinv,
idivaregisterkind,
unifiedninv
)
)
END
GO

-- CREAZIONE TABELLA unifiedivaregisterkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedivaregisterkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedivaregisterkind] (
idivaregisterkind varchar(20) NOT NULL,
description varchar(50) NULL,
 CONSTRAINT xpkunifiedivaregisterkind PRIMARY KEY (idivaregisterkind
)
)
END
GO

-- CREAZIONE TABELLA unifiedtax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedtax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedtax] (
idunifiedtax int NOT NULL,
abatements decimal(19,2) NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ayear smallint NULL,
competencydate datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
exemptionquota decimal(19,2) NULL,
idcity int NULL,
iddbdepartment varchar(50) NULL,
idexp int NULL,
idfiscaltaxregion varchar(5) NULL,
idreg int NULL,
idunifiedf24ep int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbracket int NULL,
nmonth smallint NULL,
nmov int NULL,
npay int NULL,
servicestart datetime NULL,
servicestop datetime NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
taxcode int NOT NULL,
ymov smallint NULL,
 CONSTRAINT xpkunifiedtax PRIMARY KEY (idunifiedtax
)
)
END
GO

-- CREAZIONE TABELLA unifiedtaxcorrige --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unifiedtaxcorrige]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unifiedtaxcorrige] (
idunifiedtaxcorrige int NOT NULL,
adate datetime NULL,
adminamount decimal(19,2) NULL,
ayear smallint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employamount decimal(19,2) NULL,
idcity int NULL,
iddbdepartment varchar(50) NULL,
idexp int NULL,
idexpensetaxcorrige int NOT NULL,
idfiscaltaxregion varchar(5) NULL,
idreg int NULL,
idunifiedf24ep int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmonth smallint NULL,
nmov int NULL,
npay int NULL,
servicestart datetime NULL,
servicestop datetime NULL,
taxcode int NOT NULL,
ymov smallint NULL,
 CONSTRAINT xpkunifiedtaxcorrige PRIMARY KEY (idunifiedtaxcorrige
)
)
END
GO

-- CREAZIONE TABELLA unit --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[unit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[unit] (
idunit int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkunit PRIMARY KEY (idunit
)
)
END
GO

-- CREAZIONE TABELLA variationkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[variationkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[variationkind] (
idvariationkind tinyint NOT NULL,
description varchar(50) NOT NULL,
 CONSTRAINT xpkvariationkind PRIMARY KEY (idvariationkind
)
)
END
GO

-- CREAZIONE TABELLA voce8000 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[voce8000]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[voce8000] (
voce varchar(4) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
kind char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkvoce8000 PRIMARY KEY (voce
)
)
END
GO

-- CREAZIONE TABELLA voce8000lookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[voce8000lookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[voce8000lookup] (
idvoce int NOT NULL,
conto char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
servicekind varchar(50) NULL,
taxref varchar(20) NULL,
voce varchar(4) NULL,
 CONSTRAINT xpkvoce8000lookup PRIMARY KEY (idvoce
)
)
END
GO

-- CREAZIONE TABELLA web_config --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[web_config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[web_config] (
dummykey int NOT NULL,
askitinerationclause char(1) NULL,
itinerationclause varchar(1000) NULL,
menuitinerationinsert char(1) NULL,
menuitinerationlist char(1) NULL,
showinerationep char(1) NULL,
 CONSTRAINT xpkweb_config PRIMARY KEY (dummykey
)
)
END
GO

-- CREAZIONE TABELLA web_edittype --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[web_edittype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[web_edittype] (
tablename varchar(50) NOT NULL,
edittype varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
page_url varchar(200) NOT NULL,
 CONSTRAINT xpkweb_edittype PRIMARY KEY (tablename,
edittype
)
)
END
GO

-- CREAZIONE TABELLA web_listredir --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[web_listredir]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[web_listredir] (
tablename varchar(50) NOT NULL,
listtype varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
newlisttype varchar(50) NOT NULL,
newtablename varchar(50) NOT NULL,
 CONSTRAINT xpkweb_listredir PRIMARY KEY (tablename,
listtype
)
)
END
GO

-- CREAZIONE TABELLA workingtime --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workingtime]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[workingtime] (
idworkingtime varchar(5) NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkworkingtime PRIMARY KEY (idworkingtime,
ayear
)
)
END
GO

