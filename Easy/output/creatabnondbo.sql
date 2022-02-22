
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


-- CREAZIONE TABELLA abatableexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[abatableexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [abatableexpense] (
ayear int NOT NULL,
idcon varchar(8) NOT NULL,
idabatement int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
totalamount decimal(19,2) NULL,
 CONSTRAINT xpkabatableexpense PRIMARY KEY (ayear,
idcon,
idabatement
)
)
END
GO

-- CREAZIONE TABELLA accmotivesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accmotivesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accmotivesorting] (
idaccmotive varchar(36) NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccmotivesorting PRIMARY KEY (idaccmotive,
idsor
)
)
END
GO

-- CREAZIONE TABELLA accountingyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accountingyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accountingyear] (
ayear smallint NOT NULL,
flag tinyint NOT NULL,
 CONSTRAINT xpkaccountingyear PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA accountsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accountsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accountsorting] (
idsor int NOT NULL,
idacc varchar(38) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkaccountsorting PRIMARY KEY (idsor,
idacc
)
)
END
GO

-- CREAZIONE TABELLA accountvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accountvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accountvar] (
yvar int NOT NULL,
nvar int NOT NULL,
adate datetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
enactment varchar(150) NULL,
enactmentdate datetime NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nenactment varchar(15) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkaccountvar PRIMARY KEY (yvar,
nvar
)
)
END
GO

-- CREAZIONE TABELLA accountvardetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accountvardetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accountvardetail] (
yvar int NOT NULL,
nvar int NOT NULL,
idacc varchar(38) NOT NULL,
idsor int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkaccountvardetail PRIMARY KEY (yvar,
nvar,
idacc,
idsor
)
)
END
GO

-- CREAZIONE TABELLA accountyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[accountyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [accountyear] (
idacc varchar(38) NOT NULL,
idsor int NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
previousprevision decimal(19,2) NULL,
prevision decimal(19,2) NULL,
 CONSTRAINT xpkaccountyear PRIMARY KEY (idacc,
idsor
)
)
END
GO

-- CREAZIONE TABELLA administrativeblock --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[administrativeblock]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [administrativeblock] (
idadministrativeblock int NOT NULL,
cf varchar(16) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
enactmentstart varchar(150) NULL,
enactmentstop varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
p_iva varchar(15) NULL,
start datetime NOT NULL,
stop datetime NULL,
title varchar(100) NULL,
 CONSTRAINT xpkadministrativeblock PRIMARY KEY (idadministrativeblock
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='cfindex' and id=object_id('administrativeblock'))
BEGIN
     CREATE NONCLUSTERED INDEX cfindex
     ON administrativeblock
     (
     cf     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX cfindex
     ON administrativeblock
     (
     cf     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='pivaindex' and id=object_id('administrativeblock'))
BEGIN
     CREATE NONCLUSTERED INDEX pivaindex
     ON administrativeblock
     (
     p_iva     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX pivaindex
     ON administrativeblock
     (
     p_iva     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA admpay --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
adate datetime NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
processed char(1) NULL,
 CONSTRAINT xpkadmpay PRIMARY KEY (yadmpay,
nadmpay
)
)
END
GO

-- CREAZIONE TABELLA admpay_admintax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_admintax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_admintax] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nexpense int NOT NULL,
taxcode int NOT NULL,
nbracket int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nappropriation int NOT NULL,
 CONSTRAINT xpkadmpay_admintax PRIMARY KEY (yadmpay,
nadmpay,
nexpense,
taxcode,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA admpay_appropriation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_appropriation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_appropriation] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nappropriation int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idexp int NULL,
idfin int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkadmpay_appropriation PRIMARY KEY (yadmpay,
nadmpay,
nappropriation
)
)
END
GO

-- CREAZIONE TABELLA admpay_assessment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_assessment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_assessment] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nassessment int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(68) NOT NULL,
description varchar(150) NOT NULL,
idfin int NULL,
idinc int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(68) NOT NULL,
 CONSTRAINT xpkadmpay_assessment PRIMARY KEY (yadmpay,
nadmpay,
nassessment
)
)
END
GO

-- CREAZIONE TABELLA admpay_clawback --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_clawback]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_clawback] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nexpense int NOT NULL,
idclawback int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkadmpay_clawback PRIMARY KEY (yadmpay,
nadmpay,
nexpense,
idclawback
)
)
END
GO

-- CREAZIONE TABELLA admpay_employtax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_employtax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_employtax] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nexpense int NOT NULL,
taxcode int NOT NULL,
nbracket int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkadmpay_employtax PRIMARY KEY (yadmpay,
nadmpay,
nexpense,
taxcode,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA admpay_expense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_expense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_expense] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nexpense int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idreg int NOT NULL,
idser int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nappropriation int NOT NULL,
start datetime NULL,
stop datetime NULL,
 CONSTRAINT xpkadmpay_expense PRIMARY KEY (yadmpay,
nadmpay,
nexpense
)
)
END
GO

-- CREAZIONE TABELLA admpay_expensesorted --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_expensesorted]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_expensesorted] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nexpense int NOT NULL,
idsor int NOT NULL,
idsubclass int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkadmpay_expensesorted PRIMARY KEY (yadmpay,
nadmpay,
nexpense,
idsor,
idsubclass
)
)
END
GO

-- CREAZIONE TABELLA admpay_income --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_income]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_income] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nincome int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(68) NOT NULL,
description varchar(150) NOT NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(68) NOT NULL,
nassessment int NOT NULL,
 CONSTRAINT xpkadmpay_income PRIMARY KEY (yadmpay,
nadmpay,
nincome
)
)
END
GO

-- CREAZIONE TABELLA admpay_incomesorted --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[admpay_incomesorted]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [admpay_incomesorted] (
yadmpay int NOT NULL,
nadmpay int NOT NULL,
nincome int NOT NULL,
idsor int NOT NULL,
idsubclass int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(50) NOT NULL,
 CONSTRAINT xpkadmpay_incomesorted PRIMARY KEY (yadmpay,
nadmpay,
nincome,
idsor,
idsubclass
)
)
END
GO

-- CREAZIONE TABELLA alert --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[alert]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [alert] (
idalert int NOT NULL,
alertcode varchar(20) NULL,
alertdetail varchar(300) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(100) NOT NULL,
edittype varchar(50) NULL,
listtype varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
query varchar(1500) NULL,
tablename varchar(50) NULL,
 CONSTRAINT xpkalert PRIMARY KEY (idalert
)
)
END
GO

-- CREAZIONE TABELLA apfinancialactivity --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[apfinancialactivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [apfinancialactivity] (
idapfinancialactivity int NOT NULL,
active char(1) NOT NULL,
apfinancialactivitycode varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(400) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel tinyint NOT NULL,
paridapfinancialactivity int NULL,
 CONSTRAINT xpkapfinancialactivity PRIMARY KEY (idapfinancialactivity
)
)
END
GO

-- CREAZIONE TABELLA apfinancialactivitylevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[apfinancialactivitylevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [apfinancialactivitylevel] (
nlevel tinyint NOT NULL,
codelen tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkapfinancialactivitylevel PRIMARY KEY (nlevel
)
)
END
GO

-- CREAZIONE TABELLA apfinancialactivitylink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[apfinancialactivitylink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [apfinancialactivitylink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkapfinancialactivitylink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA asset --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[asset]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [asset] (
idasset int NOT NULL,
idpiece int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idasset_prev int NULL,
idassetunload int NULL,
idpiece_prev int NULL,
lifestart datetime NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
multifield varchar(4000) NULL,
nassetacquire int NULL,
ninventory int NULL,
rtf image NULL,
transmitted char(1) NULL,
txt text NULL,
 CONSTRAINT xpkasset PRIMARY KEY (idasset,
idpiece
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1_asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1_asset
     ON asset
     (
     ninventory, idpiece     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1_asset
     ON asset
     (
     ninventory, idpiece     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4asset
     ON asset
     (
     idassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4asset
     ON asset
     (
     idassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5asset
     ON asset
     (
     nassetacquire     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5asset
     ON asset
     (
     nassetacquire     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6asset' and id=object_id('asset'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6asset
     ON asset
     (
     idasset_prev, idpiece_prev     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6asset
     ON asset
     (
     idasset_prev, idpiece_prev     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetacquire --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetacquire]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetacquire] (
nassetacquire int NOT NULL,
abatable decimal(19,2) NULL,
adate smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
discount float NULL,
flag tinyint NOT NULL,
historicalvalue decimal(19,2) NULL,
idassetload int NULL,
idinv int NOT NULL,
idinventory int NOT NULL,
idmankind varchar(20) NULL,
idmot int NOT NULL,
idreg int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nman int NULL,
number int NOT NULL,
rownum int NULL,
rtf image NULL,
startnumber int NULL,
tax decimal(19,2) NULL,
taxable decimal(19,2) NULL,
taxrate float NULL,
transmitted char(1) NULL,
txt text NULL,
yman smallint NULL,
 CONSTRAINT xpkassetacquire PRIMARY KEY (nassetacquire
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetacquire
     ON assetacquire
     (
     yman, nman, rownum     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetacquire
     ON assetacquire
     (
     yman, nman, rownum     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetacquire
     ON assetacquire
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetacquire
     ON assetacquire
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetacquire
     ON assetacquire
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetacquire
     ON assetacquire
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetacquire
     ON assetacquire
     (
     idassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetacquire
     ON assetacquire
     (
     idassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetacquire
     ON assetacquire
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetacquire
     ON assetacquire
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6assetacquire
     ON assetacquire
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6assetacquire
     ON assetacquire
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7assetacquire
     ON assetacquire
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7assetacquire
     ON assetacquire
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8assetacquire' and id=object_id('assetacquire'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8assetacquire
     ON assetacquire
     (
     idinventory, startnumber     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8assetacquire
     ON assetacquire
     (
     idinventory, startnumber     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetamortization --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetamortization]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetamortization] (
namortization int NOT NULL,
adate smalldatetime NOT NULL,
amortizationquota float NULL,
assetvalue decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flag tinyint NOT NULL,
idasset int NOT NULL,
idassetload int NULL,
idassetunload int NULL,
idinventoryamortization int NOT NULL,
idpiece int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
transmitted char(1) NULL,
txt text NULL,
 CONSTRAINT xpkassetamortization PRIMARY KEY (namortization
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetamortization' and id=object_id('assetamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetamortization
     ON assetamortization
     (
     idasset, idpiece     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetamortization
     ON assetamortization
     (
     idasset, idpiece     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetamortization' and id=object_id('assetamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetamortization
     ON assetamortization
     (
     idinventoryamortization     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetamortization
     ON assetamortization
     (
     idinventoryamortization     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetamortization' and id=object_id('assetamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetamortization
     ON assetamortization
     (
     idassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetamortization
     ON assetamortization
     (
     idassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetamortization' and id=object_id('assetamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetamortization
     ON assetamortization
     (
     flag, adate     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetamortization
     ON assetamortization
     (
     flag, adate     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetamortization' and id=object_id('assetamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetamortization
     ON assetamortization
     (
     idassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetamortization
     ON assetamortization
     (
     idassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetconsignee --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetconsignee]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetconsignee] (
idinventoryagency int NOT NULL,
start smalldatetime NOT NULL,
active char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
qualification varchar(50) NULL,
title varchar(150) NULL,
 CONSTRAINT xpkassetconsignee PRIMARY KEY (idinventoryagency,
start
)
)
END
GO

-- CREAZIONE TABELLA assetload --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetload]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetload] (
idassetload int NOT NULL,
adate smalldatetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
enactment varchar(150) NULL,
enactmentdate smalldatetime NULL,
idassetloadkind int NOT NULL,
idmot int NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nassetload int NOT NULL,
printdate smalldatetime NULL,
ratificationdate smalldatetime NULL,
rtf image NULL,
transmitted char(1) NULL,
txt text NULL,
yassetload smallint NOT NULL,
 CONSTRAINT xpkassetload PRIMARY KEY (idassetload
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetload' and id=object_id('assetload'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetload
     ON assetload
     (
     idassetloadkind, yassetload, nassetload     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetload
     ON assetload
     (
     idassetloadkind, yassetload, nassetload     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetload' and id=object_id('assetload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetload
     ON assetload
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetload
     ON assetload
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetload' and id=object_id('assetload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetload
     ON assetload
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetload
     ON assetload
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetload' and id=object_id('assetload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetload
     ON assetload
     (
     idassetloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetload
     ON assetload
     (
     idassetloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetload' and id=object_id('assetload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetload
     ON assetload
     (
     idassetloadkind, yassetload, nassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetload
     ON assetload
     (
     idassetloadkind, yassetload, nassetload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetloadexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetloadexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetloadexpense] (
idassetload int NOT NULL,
idexp int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkassetloadexpense PRIMARY KEY (idassetload,
idexp
)
)
END
GO

-- CREAZIONE TABELLA assetloadkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetloadkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetloadkind] (
idassetloadkind int NOT NULL,
active char(1) NULL,
codeassetloadkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
idinventory int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
startnumber int NULL,
 CONSTRAINT xpkassetloadkind PRIMARY KEY (idassetloadkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetloadkind' and id=object_id('assetloadkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetloadkind
     ON assetloadkind
     (
     codeassetloadkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetloadkind
     ON assetloadkind
     (
     codeassetloadkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_assetloadkind' and id=object_id('assetloadkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetloadkind
     ON assetloadkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetloadkind
     ON assetloadkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetloadkind' and id=object_id('assetloadkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetloadkind
     ON assetloadkind
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetloadkind
     ON assetloadkind
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetloadkind' and id=object_id('assetloadkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetloadkind
     ON assetloadkind
     (
     codeassetloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetloadkind
     ON assetloadkind
     (
     codeassetloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetloadmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetloadmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetloadmotive] (
idmot int NOT NULL,
active char(1) NULL,
codemot varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
idaccmotive varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkassetloadmotive PRIMARY KEY (idmot
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetloadmotive' and id=object_id('assetloadmotive'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetloadmotive
     ON assetloadmotive
     (
     codemot     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetloadmotive
     ON assetloadmotive
     (
     codemot     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_assetloadmotive' and id=object_id('assetloadmotive'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetloadmotive
     ON assetloadmotive
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetloadmotive
     ON assetloadmotive
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetloadmotive' and id=object_id('assetloadmotive'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetloadmotive
     ON assetloadmotive
     (
     codemot     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetloadmotive
     ON assetloadmotive
     (
     codemot     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetlocation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetlocation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetlocation] (
idasset int NOT NULL,
idassetlocation int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idlocation int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start smalldatetime NULL,
 CONSTRAINT xpkassetlocation PRIMARY KEY (idasset,
idassetlocation
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetlocation' and id=object_id('assetlocation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetlocation
     ON assetlocation
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetlocation
     ON assetlocation
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetlocation' and id=object_id('assetlocation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetlocation
     ON assetlocation
     (
     idlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetlocation
     ON assetlocation
     (
     idlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetlocation' and id=object_id('assetlocation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetlocation
     ON assetlocation
     (
     idasset, start     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetlocation
     ON assetlocation
     (
     idasset, start     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetmanager --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetmanager]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetmanager] (
idasset int NOT NULL,
idassetmanager int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idman int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start smalldatetime NULL,
 CONSTRAINT xpkassetmanager PRIMARY KEY (idasset,
idassetmanager
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetmanager' and id=object_id('assetmanager'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetmanager
     ON assetmanager
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetmanager
     ON assetmanager
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetmanager' and id=object_id('assetmanager'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetmanager
     ON assetmanager
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetmanager
     ON assetmanager
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetmanager' and id=object_id('assetmanager'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetmanager
     ON assetmanager
     (
     idasset, start     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetmanager
     ON assetmanager
     (
     idasset, start     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assettolink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assettolink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assettolink] (
idasset int NOT NULL,
idpiece int NOT NULL,
kind char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idinventory_tolink int NULL,
idpiece_tolink int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninventory_tolink int NULL,
 CONSTRAINT xpkassettolink PRIMARY KEY (idasset,
idpiece,
kind
)
)
END
GO

-- CREAZIONE TABELLA assetunload --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetunload]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetunload] (
idassetunload int NOT NULL,
adate smalldatetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
enactment varchar(150) NULL,
enactmentdate smalldatetime NULL,
idassetunloadkind int NOT NULL,
idmot int NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nassetunload int NOT NULL,
printdate smalldatetime NULL,
ratificationdate smalldatetime NULL,
rtf image NULL,
transmitted char(1) NULL,
txt text NULL,
yassetunload smallint NOT NULL,
 CONSTRAINT xpkassetunload PRIMARY KEY (idassetunload
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetunload' and id=object_id('assetunload'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunload
     ON assetunload
     (
     idassetunloadkind, yassetunload, nassetunload     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunload
     ON assetunload
     (
     idassetunloadkind, yassetunload, nassetunload     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunload' and id=object_id('assetunload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunload
     ON assetunload
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunload
     ON assetunload
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetunload' and id=object_id('assetunload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetunload
     ON assetunload
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetunload
     ON assetunload
     (
     idmot     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4assetunload' and id=object_id('assetunload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetunload
     ON assetunload
     (
     idassetunloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4assetunload
     ON assetunload
     (
     idassetunloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5assetunload' and id=object_id('assetunload'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetunload
     ON assetunload
     (
     idassetunloadkind, yassetunload, nassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5assetunload
     ON assetunload
     (
     idassetunloadkind, yassetunload, nassetunload     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetunloadincome --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetunloadincome]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetunloadincome] (
idassetunload int NOT NULL,
idinc int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkassetunloadincome PRIMARY KEY (idassetunload,
idinc
)
)
END
GO

-- CREAZIONE TABELLA assetunloadkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetunloadkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetunloadkind] (
idassetunloadkind int NOT NULL,
active char(1) NULL,
codeassetunloadkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
idinventory int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
startnumber int NULL,
 CONSTRAINT xpkassetunloadkind PRIMARY KEY (idassetunloadkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetunloadkind' and id=object_id('assetunloadkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunloadkind
     ON assetunloadkind
     (
     codeassetunloadkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunloadkind
     ON assetunloadkind
     (
     codeassetunloadkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_assetunloadkind' and id=object_id('assetunloadkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetunloadkind
     ON assetunloadkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetunloadkind
     ON assetunloadkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunloadkind' and id=object_id('assetunloadkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunloadkind
     ON assetunloadkind
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunloadkind
     ON assetunloadkind
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetunloadkind' and id=object_id('assetunloadkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetunloadkind
     ON assetunloadkind
     (
     codeassetunloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetunloadkind
     ON assetunloadkind
     (
     codeassetunloadkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetunloadmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetunloadmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetunloadmotive] (
idmot int NOT NULL,
active char(1) NULL,
codemot varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkassetunloadmotive PRIMARY KEY (idmot
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetunloadmotive' and id=object_id('assetunloadmotive'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunloadmotive
     ON assetunloadmotive
     (
     codemot     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetunloadmotive
     ON assetunloadmotive
     (
     codemot     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_assetdivestmotive' and id=object_id('assetunloadmotive'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetdivestmotive
     ON assetunloadmotive
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_assetdivestmotive
     ON assetunloadmotive
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetunloadmotive' and id=object_id('assetunloadmotive'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunloadmotive
     ON assetunloadmotive
     (
     codemot     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetunloadmotive
     ON assetunloadmotive
     (
     codemot     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetusage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetusage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetusage] (
nassetacquire int NOT NULL,
idassetusagekind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
transmitted char(1) NULL,
usagequota decimal(19,8) NULL,
 CONSTRAINT xpkassetusage PRIMARY KEY (nassetacquire,
idassetusagekind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetusage' and id=object_id('assetusage'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetusage
     ON assetusage
     (
     nassetacquire     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetusage
     ON assetusage
     (
     nassetacquire     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetusage' and id=object_id('assetusage'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetusage
     ON assetusage
     (
     idassetusagekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetusage
     ON assetusage
     (
     idassetusagekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetvar] (
idassetvar int NOT NULL,
adate smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
enactment varchar(150) NULL,
enactmentdate smalldatetime NULL,
flag tinyint NOT NULL,
idinventoryagency int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nenactment varchar(15) NULL,
nvar int NOT NULL,
rtf image NULL,
txt text NULL,
yvar smallint NOT NULL,
 CONSTRAINT xpkassetvar PRIMARY KEY (idassetvar
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukassetvar' and id=object_id('assetvar'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetvar
     ON assetvar
     (
     yvar, nvar     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukassetvar
     ON assetvar
     (
     yvar, nvar     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvar' and id=object_id('assetvar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetvar
     ON assetvar
     (
     idinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetvar
     ON assetvar
     (
     idinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetvar' and id=object_id('assetvar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetvar
     ON assetvar
     (
     yvar, nvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetvar
     ON assetvar
     (
     yvar, nvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA assetvardetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetvardetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetvardetail] (
idassetvar int NOT NULL,
idassetvardetail int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
idinv int NOT NULL,
idinventory int NULL,
idmot int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkassetvardetail PRIMARY KEY (idassetvar,
idassetvardetail
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1assetvardetail' and id=object_id('assetvardetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetvardetail
     ON assetvardetail
     (
     idassetvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1assetvardetail
     ON assetvardetail
     (
     idassetvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2assetvardetail' and id=object_id('assetvardetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetvardetail
     ON assetvardetail
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2assetvardetail
     ON assetvardetail
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3assetvardetail' and id=object_id('assetvardetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetvardetail
     ON assetvardetail
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3assetvardetail
     ON assetvardetail
     (
     idinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA audit --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [audit] (
idaudit varchar(30) NOT NULL,
consequence text NULL,
flagsystem char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
severity char(1) NOT NULL,
title varchar(128) NOT NULL,
 CONSTRAINT xpkaudit PRIMARY KEY (idaudit
)
)
END
GO

-- CREAZIONE TABELLA auditcheck --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[auditcheck]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [auditcheck] (
tablename varchar(150) NOT NULL,
opkind char(1) NOT NULL,
idaudit varchar(30) NOT NULL,
idcheck smallint NOT NULL,
flag_both char(1) NULL,
flag_cash char(1) NULL,
flag_comp char(1) NULL,
flag_credit char(1) NULL,
flag_proceeds char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
message varchar(1000) NULL,
precheck char(1) NULL,
sqlcmd varchar(6000) NULL,
 CONSTRAINT xpkauditcheck PRIMARY KEY (tablename,
opkind,
idaudit,
idcheck
)
)
END
GO

-- CREAZIONE TABELLA auditparameter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[auditparameter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [auditparameter] (
tablename varchar(150) NOT NULL,
opkind char(1) NOT NULL,
isprecheck char(1) NOT NULL,
parameterid smallint NOT NULL,
flagoldvalue char(1) NULL,
paramcolumn varchar(150) NULL,
paramtable varchar(150) NULL,
 CONSTRAINT xpkauditparameter PRIMARY KEY (tablename,
opkind,
isprecheck,
parameterid
)
)
END
GO

-- CREAZIONE TABELLA authagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authagency] (
idauthagency int NOT NULL,
description varchar(150) NULL,
email varchar(1000) NULL,
ismanager char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
priority int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkauthagency PRIMARY KEY (idauthagency
)
)
END
GO

-- CREAZIONE TABELLA authmodel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authmodel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authmodel] (
idauthmodel int NOT NULL,
authfinrequired char(1) NOT NULL,
description varchar(150) NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxamount decimal(19,2) NULL,
maxlen int NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkauthmodel PRIMARY KEY (idauthmodel
)
)
END
GO

-- CREAZIONE TABELLA authmodelauthagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authmodelauthagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authmodelauthagency] (
idauthmodel int NOT NULL,
idauthagency int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkauthmodelauthagency PRIMARY KEY (idauthmodel,
idauthagency
)
)
END
GO

-- CREAZIONE TABELLA authmodelitinerationrefundkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authmodelitinerationrefundkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authmodelitinerationrefundkind] (
idauthmodel int NOT NULL,
iditinerationrefundkind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkauthmodelitinerationrefundkind PRIMARY KEY (idauthmodel,
iditinerationrefundkind
)
)
END
GO

-- CREAZIONE TABELLA authpayment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authpayment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authpayment] (
idauthpayment int NOT NULL,
attach_amount decimal(19,2) NULL,
authorize_date datetime NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(200) NULL,
doc varchar(35) NULL,
docdate datetime NULL,
idauthstatus int NOT NULL,
idreg int NULL,
lt datetime NULL,
lu varchar(64) NULL,
nauthpayment smallint NULL,
sent_date datetime NULL,
yauthpayment int NULL,
 CONSTRAINT xpkauthpayment PRIMARY KEY (idauthpayment
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1authpayment' and id=object_id('authpayment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1authpayment
     ON authpayment
     (
     idauthstatus, authorize_date     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1authpayment
     ON authpayment
     (
     idauthstatus, authorize_date     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2authpayment' and id=object_id('authpayment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2authpayment
     ON authpayment
     (
     idreg     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2authpayment
     ON authpayment
     (
     idreg     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA authpaymentexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[authpaymentexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [authpaymentexpense] (
idauthpayment int NOT NULL,
idexp int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkauthpaymentexpense PRIMARY KEY (idauthpayment,
idexp
)
)
END
GO

-- CREAZIONE TABELLA autoclawbacksorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[autoclawbacksorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [autoclawbacksorting] (
ayear smallint NOT NULL,
idautosort int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idclawback int NOT NULL,
idsor int NOT NULL,
idsorkind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkautoclawbacksorting PRIMARY KEY (ayear,
idautosort
)
)
END
GO

-- CREAZIONE TABELLA autoexpensesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[autoexpensesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [autoexpensesorting] (
ayear int NOT NULL,
idautosort int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
defaultn1 varchar(20) NULL,
defaultn2 varchar(20) NULL,
defaultn3 varchar(20) NULL,
defaultn4 varchar(20) NULL,
defaultn5 varchar(20) NULL,
defaults1 varchar(20) NULL,
defaults2 varchar(20) NULL,
defaults3 varchar(20) NULL,
defaults4 varchar(20) NULL,
defaults5 varchar(20) NULL,
defaultv1 varchar(20) NULL,
defaultv2 varchar(20) NULL,
defaultv3 varchar(20) NULL,
defaultv4 varchar(20) NULL,
defaultv5 varchar(20) NULL,
denominator int NULL,
flagnodate char(1) NULL,
idfin int NULL,
idman int NULL,
idsor int NULL,
idsorkind int NOT NULL,
idsorkindreg int NULL,
idsorreg int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NULL,
numerator int NULL,
 CONSTRAINT xpkautoexpensesorting PRIMARY KEY (ayear,
idautosort
)
)
END
GO

-- CREAZIONE TABELLA autoincomesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[autoincomesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [autoincomesorting] (
ayear int NOT NULL,
idautosort int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
defaultn1 varchar(20) NULL,
defaultn2 varchar(20) NULL,
defaultn3 varchar(20) NULL,
defaultn4 varchar(20) NULL,
defaultn5 varchar(20) NULL,
defaults1 varchar(20) NULL,
defaults2 varchar(20) NULL,
defaults3 varchar(20) NULL,
defaults4 varchar(20) NULL,
defaults5 varchar(20) NULL,
defaultv1 varchar(20) NULL,
defaultv2 varchar(20) NULL,
defaultv3 varchar(20) NULL,
defaultv4 varchar(20) NULL,
defaultv5 varchar(20) NULL,
denominator int NULL,
flagnodate char(1) NULL,
idfin int NULL,
idman int NULL,
idsor int NULL,
idsorkind int NOT NULL,
idsorkindreg int NULL,
idsorreg int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NULL,
numerator int NULL,
 CONSTRAINT xpkautoincomesorting PRIMARY KEY (ayear,
idautosort
)
)
END
GO

-- CREAZIONE TABELLA banktransaction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[banktransaction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [banktransaction] (
yban smallint NOT NULL,
nban int NOT NULL,
amount decimal(19,2) NULL,
bankreference varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idexp int NULL,
idinc int NULL,
idpay int NULL,
idpro int NULL,
kind char(1) NOT NULL,
kpay int NULL,
kpro int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
transactiondate smalldatetime NULL,
valuedate smalldatetime NULL,
 CONSTRAINT xpkbanktransaction PRIMARY KEY (yban,
nban
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1banktransaction' and id=object_id('banktransaction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1banktransaction
     ON banktransaction
     (
     transactiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1banktransaction
     ON banktransaction
     (
     transactiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2banktransaction' and id=object_id('banktransaction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2banktransaction
     ON banktransaction
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2banktransaction
     ON banktransaction
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3banktransaction' and id=object_id('banktransaction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3banktransaction
     ON banktransaction
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3banktransaction
     ON banktransaction
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4banktransaction' and id=object_id('banktransaction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4banktransaction
     ON banktransaction
     (
     idexp     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4banktransaction
     ON banktransaction
     (
     idexp     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5banktransaction' and id=object_id('banktransaction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5banktransaction
     ON banktransaction
     (
     idinc     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5banktransaction
     ON banktransaction
     (
     idinc     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA banktransactionsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[banktransactionsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [banktransactionsorting] (
yban smallint NOT NULL,
nban int NOT NULL,
idsor int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkbanktransactionsorting PRIMARY KEY (yban,
nban,
idsor
)
)
END
GO

-- CREAZIONE TABELLA bill --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[bill]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [bill] (
ybill smallint NOT NULL,
nbill int NOT NULL,
billkind char(1) NOT NULL,
active char(1) NULL,
adate datetime NULL,
covered decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idtreasurer int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motive varchar(150) NULL,
reduction decimal(19,2) NULL,
registry varchar(150) NULL,
regularizationnote varchar(400) NULL,
total decimal(19,2) NULL,
 CONSTRAINT xpkbill PRIMARY KEY (ybill,
nbill,
billkind
)
)
END
GO

-- CREAZIONE TABELLA booking --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[booking]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [booking] (
idbooking int NOT NULL,
cf varchar(50) NULL,
ct datetime NULL,
cu varchar(64) NULL,
email varchar(200) NULL,
forename varchar(50) NULL,
idcustomuser varchar(30) NULL,
idlcard int NULL,
idman int NULL,
lt datetime NULL,
lu varchar(64) NULL,
nbooking int NULL,
surname varchar(50) NULL,
ybooking smallint NOT NULL,
 CONSTRAINT xpkbooking PRIMARY KEY (idbooking
)
)
END
GO

-- CREAZIONE TABELLA bookingdetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[bookingdetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [bookingdetail] (
idbooking int NOT NULL,
idlist int NOT NULL,
idstore int NOT NULL,
authorized char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idstock int NULL,
lt datetime NULL,
lu varchar(64) NULL,
number decimal(19,2) NOT NULL,
price decimal(19,2) NULL,
 CONSTRAINT xpkbookingdetail PRIMARY KEY (idbooking,
idlist,
idstore
)
)
END
GO

-- CREAZIONE TABELLA booktotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[booktotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [booktotal] (
idstore int NOT NULL,
idlist int NOT NULL,
idbooking int NOT NULL,
allocated decimal(19,2) NULL,
lastmail decimal(19,2) NULL,
number decimal(19,2) NULL,
 CONSTRAINT xpkbooktotal PRIMARY KEY (idstore,
idlist,
idbooking
)
)
END
GO

-- CREAZIONE TABELLA budgetprevision --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[budgetprevision]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [budgetprevision] (
ayear int NOT NULL,
idsor int NOT NULL,
idupb varchar(36) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
previousprevision decimal(19,2) NULL,
prevision decimal(19,2) NULL,
prevision2 decimal(19,2) NULL,
prevision3 decimal(19,2) NULL,
prevision4 decimal(19,2) NULL,
prevision5 decimal(19,2) NULL,
 CONSTRAINT xpkbudgetprevision PRIMARY KEY (ayear,
idsor,
idupb
)
)
END
GO

-- CREAZIONE TABELLA budgetvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[budgetvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [budgetvar] (
ybudgetvar int NOT NULL,
nbudgetvar int NOT NULL,
adate datetime NULL,
annotation varchar(400) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(150) NULL,
idbudgetvarstatus int NULL,
idman int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsorkind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
nofficial int NULL,
nvar int NULL,
official char(1) NULL,
reason varchar(400) NULL,
rtf image NULL,
txt text NULL,
yvar smallint NULL,
 CONSTRAINT xpkbudgetvar PRIMARY KEY (ybudgetvar,
nbudgetvar
)
)
END
GO

-- CREAZIONE TABELLA budgetvarattachment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[budgetvarattachment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [budgetvarattachment] (
ybudgetvar int NOT NULL,
nbudgetvar int NOT NULL,
idattachment int NOT NULL,
attachment image NULL,
ct datetime NULL,
cu varchar(64) NULL,
filename varchar(200) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkbudgetvarattachment PRIMARY KEY (ybudgetvar,
nbudgetvar,
idattachment
)
)
END
GO

-- CREAZIONE TABELLA budgetvardetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[budgetvardetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [budgetvardetail] (
ybudgetvar int NOT NULL,
nbudgetvar int NOT NULL,
rownum int NOT NULL,
amount decimal(19,6) NULL,
annotation varchar(400) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(150) NULL,
idsor int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkbudgetvardetail PRIMARY KEY (ybudgetvar,
nbudgetvar,
rownum
)
)
END
GO

-- CREAZIONE TABELLA budgetvarstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[budgetvarstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [budgetvarstatus] (
idbudgetvarstatus int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(50) NULL,
listingorder int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkbudgetvarstatus PRIMARY KEY (idbudgetvarstatus
)
)
END
GO

-- CREAZIONE TABELLA cafdocument --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[cafdocument]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [cafdocument] (
idcafdocument int NOT NULL,
idcon varchar(8) NOT NULL,
ayear int NOT NULL,
cafdocumentkind char(1) NOT NULL,
citytaxaccount decimal(19,2) NULL,
citytaxaccounthusband decimal(19,2) NULL,
citytaxtorefund decimal(19,2) NULL,
citytaxtorefundhusband decimal(19,2) NULL,
citytaxtoretain decimal(19,2) NULL,
citytaxtoretainhusband decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
docdate datetime NOT NULL,
firstrateadvance decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
idregion int NULL,
irpeftorefund decimal(19,2) NULL,
irpeftoretain decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
monthfirstinstalment int NULL,
monthsecondinstalment int NULL,
nquotafirstinstalment int NULL,
nquotasecondinstalment int NULL,
ratequantity int NULL,
regionaltaxtorefund decimal(19,2) NULL,
regionaltaxtorefundhusband decimal(19,2) NULL,
regionaltaxtoretain decimal(19,2) NULL,
regionaltaxtoretainhusband decimal(19,2) NULL,
secondrateadvance decimal(19,2) NULL,
separatedincome decimal(19,2) NULL,
separatedincomehusband decimal(19,2) NULL,
startmonth int NULL,
 CONSTRAINT xpkcafdocument PRIMARY KEY (idcafdocument,
idcon
)
)
END
GO

-- CREAZIONE TABELLA casualcontract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontract] (
ycon int NOT NULL,
ncon int NOT NULL,
adate datetime NOT NULL,
authdoc varchar(35) NULL,
authdocdate smalldatetime NULL,
authneeded char(1) NULL,
completed char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(150) NULL,
feegross decimal(19,2) NOT NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idreg int NOT NULL,
idser int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NULL,
ndays int NOT NULL,
noauthreason varchar(1000) NULL,
rtf image NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
txt text NULL,
 CONSTRAINT xpkcasualcontract PRIMARY KEY (ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA casualcontractdeduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontractdeduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontractdeduction] (
ycon int NOT NULL,
iddeduction int NOT NULL,
ncon int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcasualcontractdeduction PRIMARY KEY (ycon,
iddeduction,
ncon
)
)
END
GO

-- CREAZIONE TABELLA casualcontractrefund --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontractrefund]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontractrefund] (
ycon int NOT NULL,
ncon int NOT NULL,
nrefund int NOT NULL,
amount decimal(19,2) NULL,
ayear int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idlinkedrefund varchar(20) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcasualcontractrefund PRIMARY KEY (ycon,
ncon,
nrefund
)
)
END
GO

-- CREAZIONE TABELLA casualcontractsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontractsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontractsorting] (
ycon int NOT NULL,
ncon int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkcasualcontractsorting PRIMARY KEY (ycon,
ncon,
idsor
)
)
END
GO

-- CREAZIONE TABELLA casualcontracttax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontracttax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontracttax] (
ycon int NOT NULL,
ncon int NOT NULL,
taxcode int NOT NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deduction decimal(19,2) NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
employtaxgross decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
 CONSTRAINT xpkcasualcontracttax PRIMARY KEY (ycon,
ncon,
taxcode
)
)
END
GO

-- CREAZIONE TABELLA casualcontracttaxbracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontracttaxbracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontracttaxbracket] (
ycon int NOT NULL,
ncon int NOT NULL,
taxcode int NOT NULL,
nbracket int NOT NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,6) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxable decimal(19,2) NULL,
 CONSTRAINT xpkcasualcontracttaxbracket PRIMARY KEY (ycon,
ncon,
taxcode,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA casualcontractyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualcontractyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualcontractyear] (
ycon int NOT NULL,
ayear int NOT NULL,
ncon int NOT NULL,
activitycode varchar(20) NULL,
amount decimal(19,2) NULL,
flaghigherrate char(1) NULL,
higherrate decimal(19,6) NULL,
idemenscontractkind varchar(2) NULL,
idotherinsurance varchar(20) NULL,
taxableotheragency decimal(19,2) NULL,
 CONSTRAINT xpkcasualcontractyear PRIMARY KEY (ycon,
ayear,
ncon
)
)
END
GO

-- CREAZIONE TABELLA casualrefund --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[casualrefund]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [casualrefund] (
idlinkedrefund varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deduction char(1) NULL,
description varchar(50) NULL,
idaccmotive varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcasualrefund PRIMARY KEY (idlinkedrefund
)
)
END
GO

-- CREAZIONE TABELLA checkprevision --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[checkprevision]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [checkprevision] (
lastdate datetime NOT NULL,
 CONSTRAINT xpkcheckprevision PRIMARY KEY (lastdate
)
)
END
GO

-- CREAZIONE TABELLA clawback --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[clawback]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [clawback] (
idclawback int NOT NULL,
active char(1) NULL,
clawbackref varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkclawback PRIMARY KEY (idclawback
)
)
END
GO

-- CREAZIONE TABELLA clawbacksetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[clawbacksetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [clawbacksetup] (
idclawback int NOT NULL,
ayear smallint NOT NULL,
clawbackfinance int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idaccmotive varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkclawbacksetup PRIMARY KEY (idclawback,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1clawbacksetup' and id=object_id('clawbacksetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1clawbacksetup
     ON clawbacksetup
     (
     idclawback     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1clawbacksetup
     ON clawbacksetup
     (
     idclawback     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2clawbacksetup' and id=object_id('clawbacksetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2clawbacksetup
     ON clawbacksetup
     (
     clawbackfinance     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2clawbacksetup
     ON clawbacksetup
     (
     clawbackfinance     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA clawbacksorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[clawbacksorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [clawbacksorting] (
idclawback int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpkclawbacksorting PRIMARY KEY (idclawback,
idsor
)
)
END
GO

-- CREAZIONE TABELLA columntypes --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[columntypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [columntypes] (
tablename varchar(80) NOT NULL,
field varchar(80) NOT NULL,
iskey char(1) NOT NULL,
sqltype varchar(60) NOT NULL,
col_len int NULL,
col_precision int NULL,
col_scale int NULL,
systemtype varchar(80) NULL,
sqldeclaration varchar(80) NOT NULL,
allownull char(1) NOT NULL,
defaultvalue varchar(80) NULL,
format varchar(80) NULL,
denynull char(1) NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
createuser varchar(30) NULL,
createtimestamp datetime NULL,
 CONSTRAINT xpkcolumntypes PRIMARY KEY (tablename,
field
)
)
END
GO

-- CREAZIONE TABELLA config --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [config] (
ayear smallint NOT NULL,
agencycode varchar(20) NULL,
appname varchar(255) NULL,
appropriationphasecode tinyint NULL,
assessmentphasecode tinyint NULL,
asset_flagnumbering char(1) NULL,
asset_flagrestart char(1) NULL,
assetload_flag tinyint NULL,
automanagekind int NULL,
balancekind tinyint NULL,
booking_on_invoice char(1) NULL,
boxpartitiontitle varchar(50) NULL,
cashvaliditykind tinyint NULL,
casualcontract_flagrestart char(1) NULL,
csa_flaggroupby_expense char(1) NULL,
csa_flaggroupby_income char(1) NULL,
csa_flaglinktoexp char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cudactivitycode varchar(10) NULL,
currpartitiontitle varchar(20) NULL,
default_idfinvarstatus smallint NULL,
deferredexpensephase char(1) NULL,
deferredincomephase char(1) NULL,
electronicimport char(1) NULL,
electronictrasmission char(1) NULL,
email varchar(200) NULL,
email_f24 varchar(200) NULL,
expense_expiringdays smallint NULL,
expensephase tinyint NULL,
fin_kind tinyint NULL,
finvar_warnmail varchar(400) NULL,
finvarofficial_default char(1) NULL,
flag_autodocnumbering int NULL,
flag_paymentamount tinyint NULL,
flagautopayment char(1) NULL,
flagautoproceeds char(1) NULL,
flagbank_grouping int NULL,
flagcredit char(1) NULL,
flagdirectcsaclawback char(1) NULL,
flagepexp char(1) NULL,
flagfruitful char(1) NULL,
flagivapaybyrow char(1) NULL,
flagivaregphase char(1) NULL,
flagpayment char(1) NULL,
flagpayment12 char(1) NULL,
flagpcashautopayment char(1) NULL,
flagpcashautoproceeds char(1) NULL,
flagproceeds char(1) NULL,
flagrefund char(1) NULL,
flagrefund12 char(1) NULL,
flagva3 char(1) NULL,
foreignhours int NULL,
iban_f24 varchar(50) NULL,
idacc_accruedcost varchar(38) NULL,
idacc_accruedrevenue varchar(38) NULL,
idacc_customer varchar(38) NULL,
idacc_deferredcost varchar(38) NULL,
idacc_deferredcredit varchar(38) NULL,
idacc_deferreddebit varchar(38) NULL,
idacc_deferredrevenue varchar(38) NULL,
idacc_invoicetoemit varchar(38) NULL,
idacc_invoicetoreceive varchar(38) NULL,
idacc_ivapayment varchar(38) NULL,
idacc_ivapayment12 varchar(38) NULL,
idacc_ivarefund varchar(38) NULL,
idacc_ivarefund12 varchar(38) NULL,
idacc_mainivapayment varchar(38) NULL,
idacc_mainivapayment_internal varchar(38) NULL,
idacc_mainivapayment_internal12 varchar(38) NULL,
idacc_mainivapayment12 varchar(38) NULL,
idacc_mainivarefund varchar(38) NULL,
idacc_mainivarefund_internal varchar(38) NULL,
idacc_mainivarefund_internal12 varchar(38) NULL,
idacc_mainivarefund12 varchar(38) NULL,
idacc_patrimony varchar(38) NULL,
idacc_pl varchar(38) NULL,
idacc_revenue_gross_csa varchar(38) NULL,
idacc_supplier varchar(38) NULL,
idacc_unabatable varchar(38) NULL,
idacc_unabatable_refund varchar(38) NULL,
idaccmotive_admincar varchar(36) NULL,
idaccmotive_foot varchar(36) NULL,
idaccmotive_owncar varchar(36) NULL,
idclawback int NULL,
idfin_store int NULL,
idfinexpense int NULL,
idfinexpensesurplus int NULL,
idfinincome_gross_csa int NULL,
idfinincomesurplus int NULL,
idfinivapayment int NULL,
idfinivapayment12 int NULL,
idfinivarefund int NULL,
idfinivarefund12 int NULL,
idinpscenter varchar(6) NULL,
idivapayperiodicity int NULL,
idivapayperiodicity_instit int NULL,
idpaymethodabi int NULL,
idpaymethodnoabi int NULL,
idreg_csa int NULL,
idregauto int NULL,
idsiopeincome_csa int NULL,
idsor1_stock int NULL,
idsor2_stock int NULL,
idsor3_stock int NULL,
idsortingkind1 int NULL,
idsortingkind2 int NULL,
idsortingkind3 int NULL,
importappname varchar(255) NULL,
income_expiringdays smallint NULL,
incomephase tinyint NULL,
invoice_flagregister char(1) NULL,
itineration_directauth char(1) NULL,
lcard char(1) NULL,
linktoinvoice char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mainflagivaregphase char(1) NULL,
mainflagpayment char(1) NULL,
mainflagpayment12 char(1) NULL,
mainflagrefund char(1) NULL,
mainflagrefund12 char(1) NULL,
mainidacc_unabatable varchar(38) NULL,
mainidacc_unabatable_refund varchar(38) NULL,
mainidfinivapayment int NULL,
mainidfinivapayment12 int NULL,
mainidfinivarefund int NULL,
mainidfinivarefund12 int NULL,
mainminpayment decimal(19,2) NULL,
mainminpayment12 decimal(19,2) NULL,
mainminrefund decimal(19,2) NULL,
mainminrefund12 decimal(19,2) NULL,
mainpaymentagency int NULL,
mainpaymentagency12 int NULL,
mainrefundagency int NULL,
mainrefundagency12 int NULL,
mainstartivabalance decimal(19,2) NULL,
mainstartivabalance12 decimal(19,2) NULL,
minpayment decimal(19,2) NULL,
minpayment12 decimal(19,2) NULL,
minrefund decimal(19,2) NULL,
minrefund12 decimal(19,2) NULL,
motivelen smallint NULL,
motiveprefix varchar(20) NULL,
motiveseparator char(1) NULL,
payment_finlevel tinyint NULL,
payment_flag tinyint NULL,
payment_flagautoprintdate char(1) NULL,
paymentagency int NULL,
paymentagency12 int NULL,
prevpartitiontitle varchar(50) NULL,
proceeds_finlevel tinyint NULL,
proceeds_flag tinyint NULL,
proceeds_flagautoprintdate char(1) NULL,
profservice_flagrestart char(1) NULL,
refundagency int NULL,
refundagency12 int NULL,
startivabalance decimal(19,2) NULL,
startivabalance12 decimal(19,2) NULL,
taxvaliditykind tinyint NULL,
wageaddition_flagrestart char(1) NULL,
wageimportappname varchar(50) NULL,
 CONSTRAINT xpkconfig PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA creditpart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[creditpart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [creditpart] (
idinc int NOT NULL,
ncreditpart int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idfin int NOT NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
ycreditpart smallint NOT NULL,
 CONSTRAINT xpkcreditpart PRIMARY KEY (idinc,
ncreditpart
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1creditpart' and id=object_id('creditpart'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1creditpart
     ON creditpart
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1creditpart
     ON creditpart
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2creditpart' and id=object_id('creditpart'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2creditpart
     ON creditpart
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2creditpart
     ON creditpart
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_contract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contract] (
idcsa_contract int NOT NULL,
ayear smallint NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
flagkeepalive char(1) NOT NULL,
flagrecreate char(1) NULL,
idacc_main varchar(38) NULL,
idcsa_contractkind int NOT NULL,
idexp_main int NULL,
idfin_main int NULL,
idsor_siope_main int NULL,
idunderwriting int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ncontract int NOT NULL,
title varchar(50) NOT NULL,
ycontract smallint NOT NULL,
 CONSTRAINT xpkcsa_contract PRIMARY KEY (idcsa_contract,
ayear
)
)
END
GO

-- CREAZIONE TABELLA csa_contractexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contractexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contractexpense] (
idcsa_contract int NOT NULL,
ayear smallint NOT NULL,
ndetail int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idexp int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpkcsa_contractexpense PRIMARY KEY (idcsa_contract,
ayear,
ndetail
)
)
END
GO

-- CREAZIONE TABELLA csa_contractkinddata --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkinddata]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contractkinddata] (
idcsa_contractkind int NOT NULL,
idcsa_contractkinddata int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idacc varchar(38) NULL,
idacc_revenue varchar(36) NULL,
idfin int NULL,
idsor_siope int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
vocecsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_contractkinddata PRIMARY KEY (idcsa_contractkind,
idcsa_contractkinddata,
ayear
)
)
END
GO

-- CREAZIONE TABELLA csa_contractkindyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkindyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contractkindyear] (
idcsa_contractkind int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idacc_main varchar(38) NULL,
idfin_main int NULL,
idsor_siope_main int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcsa_contractkindyear PRIMARY KEY (idcsa_contractkind,
ayear
)
)
END
GO

-- CREAZIONE TABELLA csa_contractregistry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contractregistry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contractregistry] (
idcsa_contract int NOT NULL,
idcsa_registry int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
extmatricula varchar(40) NOT NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcsa_contractregistry PRIMARY KEY (idcsa_contract,
idcsa_registry,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_contractregistry' and id=object_id('csa_contractregistry'))
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_contractregistry
     ON csa_contractregistry
     (
     idcsa_contract, ayear, extmatricula     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_contractregistry
     ON csa_contractregistry
     (
     idcsa_contract, ayear, extmatricula     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_contracttax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contracttax] (
idcsa_contract int NOT NULL,
idcsa_contracttax int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idacc varchar(38) NULL,
idexp int NULL,
idfin int NULL,
idsor_siope int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
vocecsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_contracttax PRIMARY KEY (idcsa_contract,
idcsa_contracttax,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_contracttax' and id=object_id('csa_contracttax'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_contracttax
     ON csa_contracttax
     (
     idcsa_contract, ayear, vocecsa     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_contracttax
     ON csa_contracttax
     (
     idcsa_contract, ayear, vocecsa     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_contracttaxexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_contracttaxexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_contracttaxexpense] (
idcsa_contract int NOT NULL,
idcsa_contracttax int NOT NULL,
ayear smallint NOT NULL,
ndetail int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idexp int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NOT NULL,
 CONSTRAINT xpkcsa_contracttaxexpense PRIMARY KEY (idcsa_contract,
idcsa_contracttax,
ayear,
ndetail
)
)
END
GO

-- CREAZIONE TABELLA csa_import --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_import]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_import] (
idcsa_import int NOT NULL,
adate datetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nimport int NOT NULL,
yimport smallint NOT NULL,
 CONSTRAINT xpkcsa_import PRIMARY KEY (idcsa_import
)
)
END
GO

-- CREAZIONE TABELLA csa_import_expense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_import_expense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_import_expense] (
idexp int NOT NULL,
idcsa_import int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind int NOT NULL,
 CONSTRAINT xpkcsa_import_expense PRIMARY KEY (idexp,
idcsa_import
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_import_expense' and id=object_id('csa_import_expense'))
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_import_expense
     ON csa_import_expense
     (
     ct     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX IX_csa_import_expense
     ON csa_import_expense
     (
     ct     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA csa_import_income --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_import_income]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_import_income] (
idinc int NOT NULL,
idcsa_import int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind int NOT NULL,
 CONSTRAINT xpkcsa_import_income PRIMARY KEY (idinc,
idcsa_import
)
)
END
GO

-- CREAZIONE TABELLA csa_importriep --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_importriep]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_importriep] (
idcsa_import int NOT NULL,
idriep int NOT NULL,
ayear smallint NULL,
capitolocsa varchar(200) NOT NULL,
competency int NULL,
competenza varchar(10) NOT NULL,
flagcr char(1) NULL,
idacc varchar(38) NULL,
idcsa_contract int NULL,
idcsa_contractkind int NULL,
idexp int NULL,
idfin int NULL,
idreg int NULL,
idsor_siope int NULL,
idunderwriting int NULL,
idupb varchar(36) NULL,
importo decimal(19,2) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
matricola varchar(10) NOT NULL,
ruolocsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_importriep PRIMARY KEY (idcsa_import,
idriep
)
)
END
GO

-- CREAZIONE TABELLA csa_importver --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_importver]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_importver] (
idcsa_import int NOT NULL,
idver int NOT NULL,
ayear smallint NULL,
capitolocsa varchar(200) NOT NULL,
competency int NULL,
competenza varchar(10) NOT NULL,
ente varchar(200) NOT NULL,
flagclawback char(1) NULL,
flagcr char(1) NULL,
flagdirectcsaclawback char(1) NULL,
idacc_agency_credit varchar(38) NULL,
idacc_cost varchar(38) NULL,
idacc_debit varchar(38) NULL,
idacc_expense varchar(38) NULL,
idacc_internalcredit varchar(36) NULL,
idacc_revenue varchar(36) NULL,
idcsa_agency int NULL,
idcsa_agencypaymethod int NULL,
idcsa_contract int NULL,
idcsa_contractkind int NULL,
idcsa_contractkinddata int NULL,
idcsa_contracttax int NULL,
idcsa_incomesetup int NULL,
idexp_cost int NULL,
idfin_cost int NULL,
idfin_expense int NULL,
idfin_income int NULL,
idfin_incomeclawback int NULL,
idreg int NULL,
idreg_agency int NULL,
idsor_siope_cost int NULL,
idsor_siope_expense int NULL,
idsor_siope_income int NULL,
idsor_siope_incomeclawback int NULL,
idunderwriting int NULL,
idupb varchar(36) NULL,
importo decimal(19,2) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
matricola varchar(10) NOT NULL,
ruolocsa varchar(200) NOT NULL,
vocecsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_importver PRIMARY KEY (idcsa_import,
idver
)
)
END
GO

-- CREAZIONE TABELLA csa_incomesetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[csa_incomesetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [csa_incomesetup] (
idcsa_incomesetup int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flagdirectcsaclawback char(1) NULL,
idacc_agency_credit varchar(38) NULL,
idacc_debit varchar(38) NULL,
idacc_expense varchar(38) NULL,
idacc_internalcredit varchar(38) NULL,
idacc_revenue varchar(38) NULL,
idfin_expense int NULL,
idfin_income int NULL,
idfin_incomeclawback int NULL,
idsor_siope_expense int NULL,
idsor_siope_income int NULL,
idsor_siope_incomeclawback int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
vocecsa varchar(200) NOT NULL,
 CONSTRAINT xpkcsa_incomesetup PRIMARY KEY (idcsa_incomesetup,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='IX_csa_incomesetup' and id=object_id('csa_incomesetup'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_incomesetup
     ON csa_incomesetup
     (
     ayear, vocecsa     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX IX_csa_incomesetup
     ON csa_incomesetup
     (
     ayear, vocecsa     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA currentcashtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[currentcashtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [currentcashtotal] (
ayear int NOT NULL,
currentfloatfund decimal(19,2) NULL,
 CONSTRAINT xpkcurrentcashtotal PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA customobject --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customobject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customobject] (
objectname varchar(50) NOT NULL,
description varchar(80) NULL,
isreal char(1) NOT NULL,
realtable varchar(50) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
 CONSTRAINT xpkcustomobject PRIMARY KEY (objectname
)
)
END
GO

-- CREAZIONE TABELLA customprocedure --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customprocedure]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customprocedure] (
officialname varchar(255) NOT NULL,
customname varchar(255) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcustomprocedure PRIMARY KEY (officialname
)
)
END
GO

-- CREAZIONE TABELLA customredirect --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customredirect]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customredirect] (
objectname varchar(50) NOT NULL,
viewname varchar(35) NOT NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
objecttarget varchar(50) NULL,
viewtarget varchar(35) NULL,
 CONSTRAINT xpkcustomredirect PRIMARY KEY (objectname,
viewname
)
)
END
GO

-- CREAZIONE TABELLA customtablestructure --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customtablestructure]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customtablestructure] (
objectname varchar(50) NOT NULL,
colname varchar(50) NOT NULL,
autoincrement char(1) NOT NULL,
step int NULL,
prefixfieldname varchar(50) NULL,
middleconst varchar(50) NULL,
length int NOT NULL,
linear char(1) NOT NULL,
selector char(1) NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
 CONSTRAINT xpkcustomtablestructure PRIMARY KEY (objectname,
colname
)
)
END
GO

-- CREAZIONE TABELLA customview --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customview]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customview] (
objectname varchar(50) NOT NULL,
viewname varchar(35) NOT NULL,
bottommargin float NULL,
colheading smallint NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
fittopage smallint NULL,
footer varchar(255) NULL,
gridlines smallint NULL,
hcenter smallint NULL,
header varchar(255) NULL,
hpages smallint NULL,
isreal char(1) NULL,
issystem char(1) NULL,
landscape smallint NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
leftmargin float NULL,
lefttoright smallint NULL,
rightmargin float NULL,
rowheading smallint NULL,
scale smallint NULL,
staticfilter varchar(1000) NULL,
topmargin float NULL,
vcenter smallint NULL,
vpages smallint NULL,
 CONSTRAINT xpkcustomview PRIMARY KEY (objectname,
viewname
)
)
END
GO

-- CREAZIONE TABELLA customviewcolumn --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customviewcolumn]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customviewcolumn] (
objectname varchar(50) NOT NULL,
viewname varchar(35) NOT NULL,
colnumber smallint NOT NULL,
bold smallint NULL,
colname varchar(50) NULL,
color int NULL,
colwidth int NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
expression varchar(100) NULL,
fontname varchar(255) NULL,
fontsize smallint NULL,
format varchar(80) NULL,
heading varchar(255) NULL,
isreal char(1) NULL,
italic smallint NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
listcolpos smallint NULL,
strikeout smallint NULL,
systemtype varchar(80) NULL,
underline smallint NULL,
visible smallint NULL,
 CONSTRAINT xpkcustomviewcolumn PRIMARY KEY (objectname,
viewname,
colnumber
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1customviewcolumn' and id=object_id('customviewcolumn'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1customviewcolumn
     ON customviewcolumn
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1customviewcolumn
     ON customviewcolumn
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA customvieworderby --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customvieworderby]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customvieworderby] (
objectname varchar(50) NOT NULL,
viewname varchar(35) NOT NULL,
periodnumber smallint NOT NULL,
columnname varchar(255) NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
direction int NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
 CONSTRAINT xpkcustomvieworderby PRIMARY KEY (objectname,
viewname,
periodnumber
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1customvieworderby' and id=object_id('customvieworderby'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1customvieworderby
     ON customvieworderby
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1customvieworderby
     ON customvieworderby
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA customviewwhere --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customviewwhere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customviewwhere] (
objectname varchar(50) NOT NULL,
viewname varchar(35) NOT NULL,
periodnumber smallint NOT NULL,
columnname varchar(255) NULL,
connector int NULL,
createtimestamp datetime NULL,
createuser varchar(30) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
operator int NULL,
runtime int NULL,
value varchar(255) NULL,
 CONSTRAINT xpkcustomviewwhere PRIMARY KEY (objectname,
viewname,
periodnumber
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1customviewwhere' and id=object_id('customviewwhere'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1customviewwhere
     ON customviewwhere
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1customviewwhere
     ON customviewwhere
     (
     objectname, viewname     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA dbuseralert --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbuseralert]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbuseralert] (
idalert int NOT NULL,
login varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkdbuseralert PRIMARY KEY (idalert,
login
)
)
END
GO

-- CREAZIONE TABELLA ddt_in --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ddt_in]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ddt_in] (
idddt_in int NOT NULL,
adate smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idddt_in_motive int NULL,
idreg int NOT NULL,
idstore int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nddt_in varchar(10) NOT NULL,
rtf image NULL,
terms text NULL,
txt text NULL,
yddt_in smallint NOT NULL,
 CONSTRAINT xpkddt_in PRIMARY KEY (idddt_in
)
)
END
GO

-- CREAZIONE TABELLA ddt_out --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ddt_out]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ddt_out] (
idddt_out int NOT NULL,
idddt_out_motive int NULL,
idstore int NULL,
nddt_out int NOT NULL,
terms text NULL,
yddt_out smallint NOT NULL,
 CONSTRAINT xpkddt_out PRIMARY KEY (idddt_out
)
)
END
GO

-- CREAZIONE TABELLA deductibleexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[deductibleexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [deductibleexpense] (
ayear int NOT NULL,
idcon varchar(8) NOT NULL,
iddeduction int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
totalamount decimal(19,2) NOT NULL,
 CONSTRAINT xpkdeductibleexpense PRIMARY KEY (ayear,
idcon,
iddeduction
)
)
END
GO

-- CREAZIONE TABELLA division --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[division]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [division] (
iddivision int NOT NULL,
address varchar(100) NULL,
cap varchar(20) NULL,
city varchar(50) NULL,
codedivision varchar(20) NOT NULL,
country varchar(2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
faxnumber varchar(50) NULL,
faxprefix varchar(20) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
phonenumber varchar(30) NULL,
phoneprefix varchar(20) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkdivision PRIMARY KEY (iddivision
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukdivision' and id=object_id('division'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukdivision
     ON division
     (
     codedivision     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukdivision
     ON division
     (
     codedivision     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_division' and id=object_id('division'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_division
     ON division
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_division
     ON division
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1division' and id=object_id('division'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1division
     ON division
     (
     codedivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1division
     ON division
     (
     codedivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA divisionsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[divisionsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [divisionsorting] (
iddivision int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkdivisionsorting PRIMARY KEY (iddivision,
idsor
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1divisionsorting' and id=object_id('divisionsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1divisionsorting
     ON divisionsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1divisionsorting
     ON divisionsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2divisionsorting' and id=object_id('divisionsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2divisionsorting
     ON divisionsorting
     (
     iddivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2divisionsorting
     ON divisionsorting
     (
     iddivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA emens --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[emens]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [emens] (
idemens int NOT NULL,
adate datetime NULL,
cfhumansender varchar(16) NULL,
cfsender varchar(16) NULL,
cfsoftwarehouse varchar(16) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
inpscenter varchar(6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
sendercompanyname varchar(50) NULL,
startmonth int NULL,
stopmonth int NULL,
yearnumber int NULL,
 CONSTRAINT xpkemens PRIMARY KEY (idemens
)
)
END
GO

-- CREAZIONE TABELLA enactment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[enactment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [enactment] (
idenactment int NOT NULL,
adate smalldatetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idenactmentstatus smallint NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
nenactment int NOT NULL,
nofficial varchar(15) NULL,
rtf image NULL,
txt text NULL,
yenactment smallint NOT NULL,
 CONSTRAINT xpkenactment PRIMARY KEY (idenactment
)
)
END
GO

-- CREAZIONE TABELLA entry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[entry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [entry] (
yentry smallint NOT NULL,
nentry int NOT NULL,
adate datetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate datetime NULL,
identrykind int NULL,
idrelated varchar(50) NULL,
locked char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkentry PRIMARY KEY (yentry,
nentry
)
)
END
GO

-- CREAZIONE TABELLA entrydetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[entrydetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [entrydetail] (
yentry smallint NOT NULL,
nentry int NOT NULL,
ndetail int NOT NULL,
amount decimal(19,2) NOT NULL,
competencystart datetime NULL,
competencystop datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idacc varchar(38) NOT NULL,
idaccmotive varchar(36) NULL,
idreg int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkentrydetail PRIMARY KEY (yentry,
nentry,
ndetail
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1entrydetail' and id=object_id('entrydetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1entrydetail
     ON entrydetail
     (
     idacc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1entrydetail
     ON entrydetail
     (
     idacc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2entrydetail' and id=object_id('entrydetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2entrydetail
     ON entrydetail
     (
     idacc, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2entrydetail
     ON entrydetail
     (
     idacc, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA entrydetailaccrual --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[entrydetailaccrual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [entrydetailaccrual] (
yentry smallint NOT NULL,
nentry int NOT NULL,
ndetail int NOT NULL,
idaccrual int NOT NULL,
amount decimal(19,2) NULL,
ndetaillinked int NULL,
nentrylinked int NULL,
yentrylinked smallint NULL,
 CONSTRAINT xpkentrydetailaccrual PRIMARY KEY (yentry,
nentry,
ndetail,
idaccrual
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1_accrual' and id=object_id('entrydetailaccrual'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1_accrual
     ON entrydetailaccrual
     (
     yentrylinked, nentrylinked, ndetaillinked     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1_accrual
     ON entrydetailaccrual
     (
     yentrylinked, nentrylinked, ndetaillinked     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA entrykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[entrykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [entrykind] (
identrykind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkentrykind PRIMARY KEY (identrykind
)
)
END
GO

-- CREAZIONE TABELLA epexp --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[epexp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [epexp] (
yepexp smallint NOT NULL,
nepexp int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate datetime NULL,
idacc varchar(38) NOT NULL,
idreg int NOT NULL,
idrelated varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
start smalldatetime NULL,
stop smalldatetime NULL,
txt text NULL,
 CONSTRAINT xpkepexp PRIMARY KEY (yepexp,
nepexp
)
)
END
GO

-- CREAZIONE TABELLA epexpsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[epexpsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [epexpsorting] (
yepexp smallint NOT NULL,
nepexp int NOT NULL,
idsor int NOT NULL,
idsubclass int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
idacc varchar(38) NOT NULL,
kind char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkepexpsorting PRIMARY KEY (yepexp,
nepexp,
idsor,
idsubclass
)
)
END
GO

-- CREAZIONE TABELLA epexptotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[epexptotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [epexptotal] (
yepexp int NOT NULL,
nepexp int NOT NULL,
amount decimal(19,2) NULL,
curramount decimal(19,2) NULL,
 CONSTRAINT xpkepexptotal PRIMARY KEY (yepexp,
nepexp
)
)
END
GO

-- CREAZIONE TABELLA epexpvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[epexpvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [epexpvar] (
nepvar int NOT NULL,
yepvar smallint NOT NULL,
nepexp int NOT NULL,
yepexp smallint NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description char(100) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkepexpvar PRIMARY KEY (nepvar,
yepvar,
nepexp,
yepexp
)
)
END
GO

-- CREAZIONE TABELLA estimate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[estimate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [estimate] (
idestimkind varchar(20) NOT NULL,
yestim smallint NOT NULL,
nestim int NOT NULL,
active char(1) NULL,
adate smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deliveryaddress varchar(150) NULL,
deliveryexpiration varchar(50) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
exchangerate float NULL,
flagintracom char(1) NULL,
idaccmotivecredit varchar(36) NULL,
idaccmotivecredit_crg varchar(36) NULL,
idaccmotivecredit_datacrg datetime NULL,
idcurrency int NULL,
idexpirationkind smallint NULL,
idman int NULL,
idreg int NULL,
idsor_underwriter int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idunderwriting int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
officiallyprinted char(1) NOT NULL,
paymentexpiring smallint NULL,
registryreference varchar(150) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkestimate PRIMARY KEY (idestimkind,
yestim,
nestim
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1estimate' and id=object_id('estimate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1estimate
     ON estimate
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1estimate
     ON estimate
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA estimatedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[estimatedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [estimatedetail] (
idestimkind varchar(20) NOT NULL,
yestim smallint NOT NULL,
nestim int NOT NULL,
rownum int NOT NULL,
annotations varchar(400) NULL,
competencystart datetime NULL,
competencystop datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
detaildescription varchar(150) NULL,
discount float NULL,
epkind char(1) NULL,
idaccmotive varchar(36) NULL,
idaccmotiveannulment varchar(36) NULL,
idgroup int NULL,
idinc_iva int NULL,
idinc_taxable int NULL,
idivakind int NULL,
idreg int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninvoiced decimal(19,2) NULL,
number decimal(19,2) NULL,
start datetime NULL,
stop datetime NULL,
tax decimal(19,2) NULL,
taxable decimal(19,5) NULL,
taxrate float NULL,
toinvoice char(1) NULL,
 CONSTRAINT xpkestimatedetail PRIMARY KEY (idestimkind,
yestim,
nestim,
rownum
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1estimatedetail' and id=object_id('estimatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1estimatedetail
     ON estimatedetail
     (
     idestimkind, yestim, nestim, idgroup     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1estimatedetail
     ON estimatedetail
     (
     idestimkind, yestim, nestim, idgroup     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2estimatedetail' and id=object_id('estimatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2estimatedetail
     ON estimatedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2estimatedetail
     ON estimatedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3estimatedetail' and id=object_id('estimatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3estimatedetail
     ON estimatedetail
     (
     idinc_taxable     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3estimatedetail
     ON estimatedetail
     (
     idinc_taxable     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4estimatedetail' and id=object_id('estimatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4estimatedetail
     ON estimatedetail
     (
     idinc_iva     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4estimatedetail
     ON estimatedetail
     (
     idinc_iva     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA estimatekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[estimatekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [estimatekind] (
idestimkind varchar(20) NOT NULL,
active char(1) NULL,
address varchar(150) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deltaamount decimal(19,2) NULL,
deltapercentage decimal(19,6) NULL,
description varchar(150) NOT NULL,
email varchar(200) NULL,
faxnumber varchar(50) NULL,
flag_autodocnumbering char(1) NULL,
header varchar(150) NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idupb varchar(36) NULL,
linktoinvoice char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
multireg char(1) NULL,
office varchar(150) NULL,
phonenumber varchar(30) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkestimatekind PRIMARY KEY (idestimkind
)
)
END
GO

-- CREAZIONE TABELLA estimatesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[estimatesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [estimatesorting] (
idestimkind varchar(20) NOT NULL,
yestim smallint NOT NULL,
nestim int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkestimatesorting PRIMARY KEY (idestimkind,
yestim,
nestim,
idsor
)
)
END
GO

-- CREAZIONE TABELLA exhibitedcud --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[exhibitedcud]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [exhibitedcud] (
idexhibitedcud int NOT NULL,
idcon varchar(8) NOT NULL,
cfotherdeputy varchar(16) NULL,
citytax_account decimal(19,2) NULL,
citytaxapplied decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
fiscalyear int NOT NULL,
flagignoreprevcud char(1) NOT NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
idlinkedcon varchar(8) NULL,
idlinkeddbdepartment varchar(50) NULL,
inpsowed decimal(19,2) NULL,
inpsretained decimal(19,2) NULL,
irpefapplied decimal(19,2) NULL,
irpefsuspended decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
ndays int NULL,
nmonths int NOT NULL,
regionaltaxapplied decimal(19,2) NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
suspendedcitytax decimal(19,2) NULL,
suspendedregionaltax decimal(19,2) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablepension decimal(19,2) NOT NULL,
transfermotive varchar(20) NULL,
 CONSTRAINT xpkexhibitedcud PRIMARY KEY (idexhibitedcud,
idcon
)
)
END
GO

-- CREAZIONE TABELLA exhibitedcudabatement --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[exhibitedcudabatement]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [exhibitedcudabatement] (
idexhibitedcud int NOT NULL,
idcon varchar(8) NOT NULL,
idabatement int NOT NULL,
amount decimal(19,2) NULL,
 CONSTRAINT xpkexhibitedcudabatement PRIMARY KEY (idexhibitedcud,
idcon,
idabatement
)
)
END
GO

-- CREAZIONE TABELLA exhibitedcuddeduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[exhibitedcuddeduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [exhibitedcuddeduction] (
idexhibitedcud int NOT NULL,
idcon varchar(8) NOT NULL,
iddeduction int NOT NULL,
amount decimal(19,2) NULL,
 CONSTRAINT xpkexhibitedcuddeduction PRIMARY KEY (idexhibitedcud,
idcon,
iddeduction
)
)
END
GO

-- CREAZIONE TABELLA expense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expense] (
idexp int NOT NULL,
adate smalldatetime NOT NULL,
autocode int NULL,
autokind tinyint NULL,
cigcode varchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
expiration smalldatetime NULL,
idclawback int NULL,
idformerexpense int NULL,
idman int NULL,
idpayment int NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmov int NOT NULL,
nphase tinyint NOT NULL,
parentidexp int NULL,
rtf image NULL,
txt text NULL,
ymov smallint NOT NULL,
 CONSTRAINT xpkexpense PRIMARY KEY (idexp
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq1expense' and id=object_id('expense'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense
     (
     nphase, ymov, nmov     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense
     (
     nphase, ymov, nmov     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi12expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense
     (
     parentidexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense
     (
     parentidexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense
     (
     nphase     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense
     (
     nphase     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense
     (
     idpayment     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense
     (
     idpayment     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense
     (
     idformerexpense     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense
     (
     idformerexpense     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensecasualcontract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensecasualcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensecasualcontract] (
idexp int NOT NULL,
ycon int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkexpensecasualcontract PRIMARY KEY (idexp,
ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA expenseclawback --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenseclawback]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenseclawback] (
idexp int NOT NULL,
idclawback int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkexpenseclawback PRIMARY KEY (idexp,
idclawback
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseclawback' and id=object_id('expenseclawback'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseclawback
     ON expenseclawback
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseclawback
     ON expenseclawback
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseclawback' and id=object_id('expenseclawback'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseclawback
     ON expenseclawback
     (
     idclawback     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseclawback
     ON expenseclawback
     (
     idclawback     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expenseinvoice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenseinvoice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenseinvoice] (
idexp int NOT NULL,
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkexpenseinvoice PRIMARY KEY (idexp,
idinvkind,
yinv,
ninv
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseinvoice' and id=object_id('expenseinvoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseinvoice
     ON expenseinvoice
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseinvoice
     ON expenseinvoice
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseinvoice' and id=object_id('expenseinvoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseinvoice
     ON expenseinvoice
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseinvoice
     ON expenseinvoice
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expenseitineration --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenseitineration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenseitineration] (
idexp int NOT NULL,
iditineration int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkexpenseitineration PRIMARY KEY (idexp,
iditineration
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseitineration' and id=object_id('expenseitineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseitineration
     ON expenseitineration
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseitineration
     ON expenseitineration
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseitineration' and id=object_id('expenseitineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseitineration
     ON expenseitineration
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseitineration
     ON expenseitineration
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expenselast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenselast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenselast] (
idexp int NOT NULL,
biccode varchar(20) NULL,
cc varchar(30) NULL,
cin varchar(2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
extracode varchar(10) NULL,
flag tinyint NOT NULL,
iban varchar(50) NULL,
idaccdebit varchar(38) NULL,
idbank varchar(20) NULL,
idcab varchar(20) NULL,
iddeputy int NULL,
idpay int NULL,
idpaymethod int NULL,
idregistrypaymethod int NULL,
idser int NULL,
ivaamount decimal(19,2) NULL,
kpay int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
paymentdescr varchar(150) NULL,
paymethod_allowdeputy char(1) NULL,
paymethod_flag int NULL,
refexternaldoc varchar(50) NULL,
servicestart datetime NULL,
servicestop datetime NULL,
 CONSTRAINT xpkexpenselast PRIMARY KEY (idexp
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenselast
     ON expenselast
     (
     kpay, idpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenselast
     ON expenselast
     (
     kpay, idpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenselast
     ON expenselast
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenselast
     ON expenselast
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3expenselast
     ON expenselast
     (
     idser     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3expenselast
     ON expenselast
     (
     idser     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4expenselast
     ON expenselast
     (
     idregistrypaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4expenselast
     ON expenselast
     (
     idregistrypaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6expenselast
     ON expenselast
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6expenselast
     ON expenselast
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7expenselast' and id=object_id('expenselast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7expenselast
     ON expenselast
     (
     idpaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7expenselast
     ON expenselast
     (
     idpaymethod     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expenselink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenselink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenselink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkexpenselink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselink' and id=object_id('expenselink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenselink
     ON expenselink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenselink
     ON expenselink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenselink' and id=object_id('expenselink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenselink
     ON expenselink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenselink
     ON expenselink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensemandate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensemandate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensemandate] (
idexp int NOT NULL,
idmankind varchar(20) NOT NULL,
yman smallint NOT NULL,
nman int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkexpensemandate PRIMARY KEY (idexp,
idmankind,
yman,
nman
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensemandate' and id=object_id('expensemandate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensemandate
     ON expensemandate
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensemandate
     ON expensemandate
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensemandate' and id=object_id('expensemandate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensemandate
     ON expensemandate
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensemandate
     ON expensemandate
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensepayroll --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensepayroll]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensepayroll] (
idexp int NOT NULL,
idpayroll int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkexpensepayroll PRIMARY KEY (idexp,
idpayroll
)
)
END
GO

-- CREAZIONE TABELLA expensephase --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensephase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensephase] (
nphase tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkexpensephase PRIMARY KEY (nphase
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_expensephase' and id=object_id('expensephase'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_expensephase
     ON expensephase
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_expensephase
     ON expensephase
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expenseprofservice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenseprofservice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenseprofservice] (
idexp int NOT NULL,
ycon int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkexpenseprofservice PRIMARY KEY (idexp,
ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA expensesorted --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensesorted]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensesorted] (
idsor int NOT NULL,
idexp int NOT NULL,
idsubclass smallint NOT NULL,
amount decimal(19,2) NULL,
ayear smallint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
flagnodate char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridsor int NULL,
paridsubclass smallint NULL,
rtf image NULL,
start datetime NULL,
stop datetime NULL,
tobecontinued char(1) NULL,
txt text NULL,
valuen1 decimal(23,6) NULL,
valuen2 decimal(23,6) NULL,
valuen3 decimal(23,6) NULL,
valuen4 decimal(23,6) NULL,
valuen5 decimal(23,6) NULL,
values1 varchar(20) NULL,
values2 varchar(20) NULL,
values3 varchar(20) NULL,
values4 varchar(20) NULL,
values5 varchar(20) NULL,
valuev1 decimal(23,6) NULL,
valuev2 decimal(23,6) NULL,
valuev3 decimal(23,6) NULL,
valuev4 decimal(23,6) NULL,
valuev5 decimal(23,6) NULL,
 CONSTRAINT xpkexpensesorted PRIMARY KEY (idsor,
idexp,
idsubclass
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensesorted' and id=object_id('expensesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensesorted
     ON expensesorted
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensesorted
     ON expensesorted
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensesorted' and id=object_id('expensesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensesorted
     ON expensesorted
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensesorted
     ON expensesorted
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expensesorted' and id=object_id('expensesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3expensesorted
     ON expensesorted
     (
     idexp, ayear     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3expensesorted
     ON expensesorted
     (
     idexp, ayear     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensetax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensetax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensetax] (
idexp int NOT NULL,
taxcode int NOT NULL,
nbracket int NOT NULL,
abatements decimal(19,2) NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ayear smallint NULL,
competencydate smalldatetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
exemptionquota decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
idinc int NULL,
idunifiedtax int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ntaxpay int NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
ytaxpay smallint NULL,
 CONSTRAINT xpkexpensetax PRIMARY KEY (idexp,
taxcode,
nbracket
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetax' and id=object_id('expensetax'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensetax
     ON expensetax
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensetax
     ON expensetax
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expensetax' and id=object_id('expensetax'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensetax
     ON expensetax
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expensetax
     ON expensetax
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensetaxcorrige --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensetaxcorrige]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensetaxcorrige] (
idexp int NOT NULL,
idexpensetaxcorrige int NOT NULL,
adate datetime NULL,
adminamount decimal(19,2) NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employamount decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
idunifiedtaxcorrige int NULL,
linkedidexp int NULL,
linkedidinc int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ntaxpay int NULL,
taxcode int NOT NULL,
ytaxpay smallint NULL,
 CONSTRAINT xpkexpensetaxcorrige PRIMARY KEY (idexp,
idexpensetaxcorrige
)
)
END
GO

-- CREAZIONE TABELLA expensetaxofficial --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensetaxofficial]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensetaxofficial] (
idexp int NOT NULL,
idexpensetaxofficial int NOT NULL,
abatements decimal(19,2) NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
exemptionquota decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbracket int NOT NULL,
start datetime NULL,
stop datetime NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
taxcode int NOT NULL,
 CONSTRAINT xpkexpensetaxofficial PRIMARY KEY (idexp,
idexpensetaxofficial
)
)
END
GO

-- CREAZIONE TABELLA expensetotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensetotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensetotal] (
idexp int NOT NULL,
ayear smallint NOT NULL,
available decimal(19,2) NULL,
curramount decimal(19,2) NULL,
flag tinyint NULL,
 CONSTRAINT xpkexpensetotal PRIMARY KEY (idexp,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensetotal' and id=object_id('expensetotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensetotal
     ON expensetotal
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensetotal
     ON expensetotal
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensevar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensevar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensevar] (
idexp int NOT NULL,
nvar int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
autocode int NULL,
autokind tinyint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
idinvkind int NULL,
idpayment int NULL,
idunderwriting int NULL,
kpaymenttransmission int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NULL,
ninv int NULL,
rtf image NULL,
transferkind char(1) NULL,
txt text NULL,
yinv smallint NULL,
yvar smallint NOT NULL,
 CONSTRAINT xpkexpensevar PRIMARY KEY (idexp,
nvar
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expensevar' and id=object_id('expensevar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensevar
     ON expensevar
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expensevar
     ON expensevar
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA expensewageaddition --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expensewageaddition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expensewageaddition] (
idexp int NOT NULL,
ycon int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkexpensewageaddition PRIMARY KEY (idexp,
ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA expenseyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenseyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenseyear] (
idexp int NOT NULL,
ayear smallint NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idfin int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkexpenseyear PRIMARY KEY (idexp,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenseyear' and id=object_id('expenseyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseyear
     ON expenseyear
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expenseyear
     ON expenseyear
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenseyear' and id=object_id('expenseyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseyear
     ON expenseyear
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expenseyear
     ON expenseyear
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expenseyear' and id=object_id('expenseyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3expenseyear
     ON expenseyear
     (
     idfin, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3expenseyear
     ON expenseyear
     (
     idfin, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6expenseyear' and id=object_id('expenseyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6expenseyear
     ON expenseyear
     (
     idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6expenseyear
     ON expenseyear
     (
     idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA exportfunction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[exportfunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [exportfunction] (
procedurename varchar(255) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(50) NOT NULL,
fileextension varchar(10) NULL,
fileformat char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
modulename varchar(80) NOT NULL,
timeout int NULL,
webvisible char(1) NULL,
 CONSTRAINT xpkexportfunction PRIMARY KEY (procedurename
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1exportfunction' and id=object_id('exportfunction'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1exportfunction
     ON exportfunction
     (
     procedurename     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1exportfunction
     ON exportfunction
     (
     procedurename     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA exportfunctionparam --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[exportfunctionparam]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [exportfunctionparam] (
procedurename varchar(255) NOT NULL,
paramname varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
datasource varchar(50) NULL,
description varchar(50) NOT NULL,
displaymember varchar(50) NULL,
filter varchar(150) NULL,
help text NULL,
hint varchar(400) NULL,
hintkind varchar(30) NULL,
iscombobox char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
noselectionforall char(1) NULL,
number smallint NOT NULL,
selectioncode varchar(512) NULL,
systype varchar(100) NULL,
tag varchar(100) NULL,
valuemember varchar(50) NULL,
 CONSTRAINT xpkexportfunctionparam PRIMARY KEY (procedurename,
paramname
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1exportfunctionparam' and id=object_id('exportfunctionparam'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1exportfunctionparam
     ON exportfunctionparam
     (
     procedurename     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1exportfunctionparam
     ON exportfunctionparam
     (
     procedurename     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA f24ep --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[f24ep]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [f24ep] (
idf24ep int NOT NULL,
adate smalldatetime NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmonth int NOT NULL,
paymentdate smalldatetime NOT NULL,
taxpay_start smalldatetime NOT NULL,
taxpay_stop smalldatetime NOT NULL,
 CONSTRAINT xpkf24ep PRIMARY KEY (idf24ep
)
)
END
GO

-- CREAZIONE TABELLA f24epsanction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[f24epsanction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [f24epsanction] (
amount decimal(19,2) NULL,
ayear smallint NULL,
idcity int NULL,
idf24ep int NOT NULL,
idfiscaltaxregion varchar(5) NULL,
idsanction int NOT NULL,
idsanctionf24 int NOT NULL)
END
GO

-- CREAZIONE TABELLA fin --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[fin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [fin] (
idfin int NOT NULL,
ayear smallint NOT NULL,
codefin varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel tinyint NOT NULL,
paridfin int NULL,
printingorder varchar(50) NOT NULL,
rtf image NULL,
title varchar(150) NOT NULL,
txt text NULL,
 CONSTRAINT xpkfin PRIMARY KEY (idfin
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq2fin' and id=object_id('fin'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq2fin
     ON fin
     (
     ayear, flag, printingorder     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq2fin
     ON fin
     (
     ayear, flag, printingorder     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1fin' and id=object_id('fin'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1fin
     ON fin
     (
     paridfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1fin
     ON fin
     (
     paridfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2fin' and id=object_id('fin'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2fin
     ON fin
     (
     ayear, nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2fin
     ON fin
     (
     ayear, nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finbalance --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finbalance]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finbalance] (
ayear int NOT NULL,
nfinbalance int NOT NULL,
balancedate datetime NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
official char(1) NULL,
 CONSTRAINT xpkfinbalance PRIMARY KEY (ayear,
nfinbalance
)
)
END
GO

-- CREAZIONE TABELLA finbalancedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finbalancedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finbalancedetail] (
ayear int NOT NULL,
idfin int NOT NULL,
nfinbalance int NOT NULL,
idupb varchar(36) NOT NULL,
actualavailableprev decimal(19,2) NULL,
actualcashsurplus decimal(19,2) NULL,
actualcreditsurplus decimal(19,2) NULL,
actualprev decimal(19,2) NULL,
assignedcash decimal(19,2) NULL,
cashvariation decimal(19,2) NULL,
codefin varchar(50) NULL,
creditvariation decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
expenditure decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
payment decimal(19,2) NULL,
previsionvariation decimal(19,2) NULL,
proceeds decimal(19,2) NULL,
revenue decimal(19,2) NULL,
secondaryprevvariation decimal(19,2) NULL,
supposedavailableprev decimal(19,2) NULL,
supposedcash decimal(19,2) NULL,
supposedcredits decimal(19,2) NULL,
supposedexpenditure decimal(19,2) NULL,
supposedrevenue decimal(19,2) NULL,
 CONSTRAINT xpkfinbalancedetail PRIMARY KEY (ayear,
idfin,
nfinbalance,
idupb
)
)
END
GO

-- CREAZIONE TABELLA finlast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlast] (
idfin int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
expiration datetime NULL,
idman int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinlast PRIMARY KEY (idfin
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlast' and id=object_id('finlast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlast
     ON finlast
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlast
     ON finlast
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlevel] (
ayear smallint NOT NULL,
nlevel tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag smallint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinlevel PRIMARY KEY (ayear,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_finlevel' and id=object_id('finlevel'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_finlevel
     ON finlevel
     (
     ayear, description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_finlevel
     ON finlevel
     (
     ayear, description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finlink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkfinlink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlink' and id=object_id('finlink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlink
     ON finlink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlink
     ON finlink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finlink' and id=object_id('finlink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2finlink
     ON finlink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2finlink
     ON finlink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finlookup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlookup] (
oldidfin int NOT NULL,
newidfin int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinlookup PRIMARY KEY (oldidfin,
newidfin
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlookup' and id=object_id('finlookup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlookup
     ON finlookup
     (
     oldidfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finlookup
     ON finlookup
     (
     oldidfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finlookup' and id=object_id('finlookup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2finlookup
     ON finlookup
     (
     newidfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2finlookup
     ON finlookup
     (
     newidfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finsorting] (
idfin int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkfinsorting PRIMARY KEY (idfin,
idsor
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finsorting' and id=object_id('finsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finsorting
     ON finsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finsorting
     ON finsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finvar] (
yvar smallint NOT NULL,
nvar int NOT NULL,
adate smalldatetime NOT NULL,
annotation varchar(400) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
enactment varchar(150) NULL,
enactmentdate smalldatetime NULL,
flagcredit char(1) NOT NULL,
flagprevision char(1) NOT NULL,
flagproceeds char(1) NOT NULL,
flagsecondaryprev char(1) NOT NULL,
idenactment int NULL,
idfinvarkind int NULL,
idfinvarstatus smallint NULL,
idman int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
limit decimal(18,0) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
moneytransfer char(1) NULL,
nenactment varchar(15) NULL,
nofficial int NULL,
official char(1) NULL,
reason varchar(400) NULL,
rtf image NULL,
txt text NULL,
variationkind tinyint NOT NULL,
 CONSTRAINT xpkfinvar PRIMARY KEY (yvar,
nvar
)
)
END
GO

-- CREAZIONE TABELLA finvarattachment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finvarattachment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finvarattachment] (
yvar smallint NOT NULL,
nvar int NOT NULL,
idattachment int NOT NULL,
attachment image NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
filename varchar(200) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinvarattachment PRIMARY KEY (yvar,
nvar,
idattachment
)
)
END
GO

-- CREAZIONE TABELLA finvardetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finvardetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finvardetail] (
yvar smallint NOT NULL,
nvar int NOT NULL,
rownum int NOT NULL,
amount decimal(19,2) NULL,
annotation varchar(400) NULL,
createexpense char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
idexp int NULL,
idfin int NOT NULL,
idlcard int NULL,
idunderwriting int NULL,
idupb varchar(36) NOT NULL,
limit decimal(18,0) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
prevision2 decimal(19,2) NULL,
prevision3 decimal(19,2) NULL,
 CONSTRAINT xpkfinvardetail PRIMARY KEY (yvar,
nvar,
rownum
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finvardetail' and id=object_id('finvardetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finvardetail
     ON finvardetail
     (
     yvar, nvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finvardetail
     ON finvardetail
     (
     yvar, nvar     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finvardetail' and id=object_id('finvardetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2finvardetail
     ON finvardetail
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2finvardetail
     ON finvardetail
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA finvarkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finvarkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finvarkind] (
idfinvarkind int NOT NULL,
codevarkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinvarkind PRIMARY KEY (idfinvarkind
)
)
END
GO

-- CREAZIONE TABELLA finvarstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finvarstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finvarstatus] (
idfinvarstatus smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
listingorder int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkfinvarstatus PRIMARY KEY (idfinvarstatus
)
)
END
GO

-- CREAZIONE TABELLA finyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finyear] (
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
currentarrears decimal(19,2) NULL,
limit decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
previousarrears decimal(19,2) NULL,
previousprevision decimal(19,2) NULL,
previoussecondaryprev decimal(19,2) NULL,
prevision decimal(19,2) NULL,
prevision2 decimal(19,2) NULL,
prevision3 decimal(19,2) NULL,
prevision4 decimal(19,2) NULL,
prevision5 decimal(19,2) NULL,
secondaryprev decimal(19,2) NULL,
 CONSTRAINT xpkfinyear PRIMARY KEY (idupb,
idfin
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finyear' and id=object_id('finyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1finyear
     ON finyear
     (
     idfin     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1finyear
     ON finyear
     (
     idfin     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA flowchart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchart] (
idflowchart varchar(34) NOT NULL,
address varchar(100) NULL,
ayear int NULL,
cap varchar(20) NULL,
codeflowchart varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
fax varchar(75) NULL,
idcity int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
location varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel int NOT NULL,
paridflowchart varchar(34) NOT NULL,
phone varchar(55) NULL,
printingorder varchar(50) NOT NULL,
title varchar(150) NOT NULL,
 CONSTRAINT xpkflowchart PRIMARY KEY (idflowchart
)
)
END
GO

-- CREAZIONE TABELLA flowchartauthagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartauthagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartauthagency] (
idflowchart varchar(34) NOT NULL,
idauthagency int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartauthagency PRIMARY KEY (idflowchart,
idauthagency
)
)
END
GO

-- CREAZIONE TABELLA flowchartauthmodel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartauthmodel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartauthmodel] (
idflowchart varchar(34) NOT NULL,
idauthmodel int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartauthmodel PRIMARY KEY (idflowchart,
idauthmodel
)
)
END
GO

-- CREAZIONE TABELLA flowchartestimatekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartestimatekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartestimatekind] (
idflowchart varchar(34) NOT NULL,
idestimkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartestimatekind PRIMARY KEY (idflowchart,
idestimkind
)
)
END
GO

-- CREAZIONE TABELLA flowchartexportmodule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartexportmodule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartexportmodule] (
idflowchart varchar(34) NOT NULL,
modulename varchar(80) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkflowchartexportmodule PRIMARY KEY (idflowchart,
modulename
)
)
END
GO

-- CREAZIONE TABELLA flowchartfin --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartfin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartfin] (
idflowchart varchar(34) NOT NULL,
idfin int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartfin PRIMARY KEY (idflowchart,
idfin
)
)
END
GO

-- CREAZIONE TABELLA flowchartinvoicekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartinvoicekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartinvoicekind] (
idflowchart varchar(34) NOT NULL,
idinvkind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartinvoicekind PRIMARY KEY (idflowchart,
idinvkind
)
)
END
GO

-- CREAZIONE TABELLA flowchartlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartlevel] (
ayear int NOT NULL,
nlevel int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagusable char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartlevel PRIMARY KEY (ayear,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA flowchartmanager --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartmanager]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartmanager] (
idflowchart varchar(34) NOT NULL,
idman int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartmanager PRIMARY KEY (idflowchart,
idman
)
)
END
GO

-- CREAZIONE TABELLA flowchartmandatekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartmandatekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartmandatekind] (
idflowchart varchar(34) NOT NULL,
idmankind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartmandatekind PRIMARY KEY (idflowchart,
idmankind
)
)
END
GO

-- CREAZIONE TABELLA flowchartmodulegroup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartmodulegroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartmodulegroup] (
idflowchart varchar(34) NOT NULL,
modulename varchar(80) NOT NULL,
groupname varchar(80) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkflowchartmodulegroup PRIMARY KEY (idflowchart,
modulename,
groupname
)
)
END
GO

-- CREAZIONE TABELLA flowchartpettycash --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartpettycash]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartpettycash] (
idflowchart varchar(34) NOT NULL,
idpettycash int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartpettycash PRIMARY KEY (idflowchart,
idpettycash
)
)
END
GO

-- CREAZIONE TABELLA flowchartrestrictedfunction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartrestrictedfunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartrestrictedfunction] (
idflowchart varchar(34) NOT NULL,
idrestrictedfunction int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartrestrictedfunction PRIMARY KEY (idflowchart,
idrestrictedfunction
)
)
END
GO

-- CREAZIONE TABELLA flowchartsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartsorting] (
idsor int NOT NULL,
idflowchart varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpkflowchartsorting PRIMARY KEY (idsor,
idflowchart
)
)
END
GO

-- CREAZIONE TABELLA flowchartupb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartupb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartupb] (
idflowchart varchar(34) NOT NULL,
idupb varchar(36) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartupb PRIMARY KEY (idflowchart,
idupb
)
)
END
GO

-- CREAZIONE TABELLA flowchartuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartuser] (
idflowchart varchar(34) NOT NULL,
ndetail int NOT NULL,
idcustomuser varchar(50) NOT NULL,
all_sorkind01 char(1) NULL,
all_sorkind02 char(1) NULL,
all_sorkind03 char(1) NULL,
all_sorkind04 char(1) NULL,
all_sorkind05 char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flagdefault char(1) NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sorkind01_withchilds char(1) NULL,
sorkind02_withchilds char(1) NULL,
sorkind03_withchilds char(1) NULL,
sorkind04_withchilds char(1) NULL,
sorkind05_withchilds char(1) NULL,
start datetime NULL,
stop datetime NULL,
title varchar(150) NULL,
 CONSTRAINT xpkflowchartuser PRIMARY KEY (idflowchart,
ndetail,
idcustomuser
)
)
END
GO

-- CREAZIONE TABELLA generalreportparameter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[generalreportparameter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [generalreportparameter] (
idparam varchar(50) NOT NULL,
start datetime NOT NULL,
description varchar(240) NULL,
lt datetime NULL,
lu varchar(64) NULL,
paramvalue varchar(200) NULL,
stop datetime NULL,
 CONSTRAINT xpkgeneralreportparameter PRIMARY KEY (idparam,
start
)
)
END
GO

-- CREAZIONE TABELLA income --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[income]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [income] (
idinc int NOT NULL,
adate smalldatetime NOT NULL,
autocode int NULL,
autokind tinyint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
expiration smalldatetime NULL,
idman int NULL,
idpayment int NULL,
idreg int NULL,
idunderwriting int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmov int NOT NULL,
nphase tinyint NOT NULL,
parentidinc int NULL,
rtf image NULL,
txt text NULL,
ymov smallint NOT NULL,
 CONSTRAINT xpkincome PRIMARY KEY (idinc
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq1income' and id=object_id('income'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1income
     ON income
     (
     nphase, ymov, nmov     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1income
     ON income
     (
     nphase, ymov, nmov     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1income
     ON income
     (
     nphase     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1income
     ON income
     (
     nphase     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2income
     ON income
     (
     parentidinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2income
     ON income
     (
     parentidinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3income
     ON income
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3income
     ON income
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5income
     ON income
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5income
     ON income
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9income
     ON income
     (
     idpayment     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9income
     ON income
     (
     idpayment     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomeestimate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomeestimate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomeestimate] (
idinc int NOT NULL,
idestimkind varchar(20) NOT NULL,
yestim smallint NOT NULL,
nestim int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkincomeestimate PRIMARY KEY (idinc,
idestimkind,
yestim,
nestim
)
)
END
GO

-- CREAZIONE TABELLA incomeinvoice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomeinvoice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomeinvoice] (
idinc int NOT NULL,
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkincomeinvoice PRIMARY KEY (idinc,
idinvkind,
yinv,
ninv
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeinvoice' and id=object_id('incomeinvoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomeinvoice
     ON incomeinvoice
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomeinvoice
     ON incomeinvoice
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeinvoice' and id=object_id('incomeinvoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomeinvoice
     ON incomeinvoice
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomeinvoice
     ON incomeinvoice
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomelast --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomelast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomelast] (
idinc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idacccredit varchar(38) NULL,
idpro int NULL,
kpro int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
 CONSTRAINT xpkincomelast PRIMARY KEY (idinc
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelast' and id=object_id('incomelast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomelast
     ON incomelast
     (
     kpro, idpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomelast
     ON incomelast
     (
     kpro, idpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelast' and id=object_id('incomelast'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomelast
     ON incomelast
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomelast
     ON incomelast
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomelink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomelink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomelink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkincomelink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelink' and id=object_id('incomelink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomelink
     ON incomelink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomelink
     ON incomelink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelink' and id=object_id('incomelink'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomelink
     ON incomelink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomelink
     ON incomelink
     (
     idparent, idchild     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomephase --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomephase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomephase] (
nphase tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkincomephase PRIMARY KEY (nphase
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_incomephase' and id=object_id('incomephase'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_incomephase
     ON incomephase
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_incomephase
     ON incomephase
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomesorted --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomesorted]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomesorted] (
idsor int NOT NULL,
idinc int NOT NULL,
idsubclass smallint NOT NULL,
amount decimal(19,2) NULL,
ayear smallint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
flagnodate char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridsor int NULL,
paridsubclass smallint NULL,
rtf image NULL,
start datetime NULL,
stop datetime NULL,
tobecontinued char(1) NULL,
txt text NULL,
valuen1 decimal(23,6) NULL,
valuen2 decimal(23,6) NULL,
valuen3 decimal(23,6) NULL,
valuen4 decimal(23,6) NULL,
valuen5 decimal(23,6) NULL,
values1 varchar(20) NULL,
values2 varchar(20) NULL,
values3 varchar(20) NULL,
values4 varchar(20) NULL,
values5 varchar(20) NULL,
valuev1 decimal(23,6) NULL,
valuev2 decimal(23,6) NULL,
valuev3 decimal(23,6) NULL,
valuev4 decimal(23,6) NULL,
valuev5 decimal(23,6) NULL,
 CONSTRAINT xpkincomesorted PRIMARY KEY (idsor,
idinc,
idsubclass
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomesorted' and id=object_id('incomesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomesorted
     ON incomesorted
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomesorted
     ON incomesorted
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomesorted' and id=object_id('incomesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomesorted
     ON incomesorted
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomesorted
     ON incomesorted
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomesorted' and id=object_id('incomesorted'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3incomesorted
     ON incomesorted
     (
     idinc, ayear     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3incomesorted
     ON incomesorted
     (
     idinc, ayear     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incometotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incometotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incometotal] (
idinc int NOT NULL,
ayear smallint NOT NULL,
available decimal(19,2) NULL,
curramount decimal(19,2) NULL,
flag tinyint NOT NULL,
partitioned decimal(19,2) NULL,
 CONSTRAINT xpkincometotal PRIMARY KEY (idinc,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incometotal' and id=object_id('incometotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incometotal
     ON incometotal
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incometotal
     ON incometotal
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomevar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomevar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomevar] (
idinc int NOT NULL,
nvar int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
autokind tinyint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
idinvkind int NULL,
kproceedstransmission int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NULL,
ninv int NULL,
rtf image NULL,
transferkind char(1) NULL,
txt text NULL,
yinv smallint NULL,
yvar smallint NOT NULL,
 CONSTRAINT xpkincomevar PRIMARY KEY (idinc,
nvar
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomevar' and id=object_id('incomevar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomevar
     ON incomevar
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomevar
     ON incomevar
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA incomeyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomeyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomeyear] (
idinc int NOT NULL,
ayear smallint NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idfin int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkincomeyear PRIMARY KEY (idinc,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomeyear' and id=object_id('incomeyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomeyear
     ON incomeyear
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1incomeyear
     ON incomeyear
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomeyear' and id=object_id('incomeyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomeyear
     ON incomeyear
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2incomeyear
     ON incomeyear
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3incomeyear' and id=object_id('incomeyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3incomeyear
     ON incomeyear
     (
     idfin, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3incomeyear
     ON incomeyear
     (
     idfin, idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6incomeyear' and id=object_id('incomeyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6incomeyear
     ON incomeyear
     (
     idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6incomeyear
     ON incomeyear
     (
     idupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA intrastattrasmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[intrastattrasmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [intrastattrasmission] (
idintrastattrasmission int NOT NULL,
 CONSTRAINT xpkintrastattrasmission PRIMARY KEY (idintrastattrasmission
)
)
END
GO

-- CREAZIONE TABELLA inventory --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventory] (
idinventory int NOT NULL,
active char(1) NULL,
codeinventory varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
idinventoryagency int NOT NULL,
idinventorykind int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
startnumber int NULL,
 CONSTRAINT xpkinventory PRIMARY KEY (idinventory
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukinventory' and id=object_id('inventory'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventory
     ON inventory
     (
     codeinventory     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventory
     ON inventory
     (
     codeinventory     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventory' and id=object_id('inventory'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventory
     ON inventory
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventory
     ON inventory
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventory' and id=object_id('inventory'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventory
     ON inventory
     (
     idinventorykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventory
     ON inventory
     (
     idinventorykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventory' and id=object_id('inventory'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventory
     ON inventory
     (
     idinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventory
     ON inventory
     (
     idinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3inventory' and id=object_id('inventory'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3inventory
     ON inventory
     (
     codeinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3inventory
     ON inventory
     (
     codeinventory     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventoryagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventoryagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventoryagency] (
idinventoryagency int NOT NULL,
active char(1) NULL,
agencycode varchar(20) NULL,
codeinventoryagency varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinventoryagency PRIMARY KEY (idinventoryagency
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukinventoryagency' and id=object_id('inventoryagency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventoryagency
     ON inventoryagency
     (
     codeinventoryagency     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventoryagency
     ON inventoryagency
     (
     codeinventoryagency     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventoryagency' and id=object_id('inventoryagency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventoryagency
     ON inventoryagency
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventoryagency
     ON inventoryagency
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventoryagency' and id=object_id('inventoryagency'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventoryagency
     ON inventoryagency
     (
     codeinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventoryagency
     ON inventoryagency
     (
     codeinventoryagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventoryamortization --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventoryamortization]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventoryamortization] (
idinventoryamortization int NOT NULL,
active char(1) NULL,
age int NULL,
agemax int NULL,
codeinventoryamortization varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
valuemax decimal(19,2) NULL,
valuemin decimal(19,2) NULL,
 CONSTRAINT xpkinventoryamortization PRIMARY KEY (idinventoryamortization
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukinventoryamortization' and id=object_id('inventoryamortization'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventoryamortization
     ON inventoryamortization
     (
     codeinventoryamortization     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventoryamortization
     ON inventoryamortization
     (
     codeinventoryamortization     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventoryamortization' and id=object_id('inventoryamortization'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventoryamortization
     ON inventoryamortization
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventoryamortization
     ON inventoryamortization
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventoryamortization' and id=object_id('inventoryamortization'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventoryamortization
     ON inventoryamortization
     (
     codeinventoryamortization     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventoryamortization
     ON inventoryamortization
     (
     codeinventoryamortization     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventorykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventorykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventorykind] (
idinventorykind int NOT NULL,
active char(1) NULL,
codeinventorykind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
idinv_allow int NULL,
idinv_deny int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinventorykind PRIMARY KEY (idinventorykind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukinventorykind' and id=object_id('inventorykind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventorykind
     ON inventorykind
     (
     codeinventorykind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinventorykind
     ON inventorykind
     (
     codeinventorykind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventorykind' and id=object_id('inventorykind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorykind
     ON inventorykind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorykind
     ON inventorykind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorykind' and id=object_id('inventorykind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorykind
     ON inventorykind
     (
     codeinventorykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorykind
     ON inventorykind
     (
     codeinventorykind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventorysortingamortizationyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventorysortingamortizationyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventorysortingamortizationyear] (
ayear int NOT NULL,
idinv int NOT NULL,
idinventoryamortization int NOT NULL,
amortizationquota float NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idaccmotive varchar(36) NULL,
idaccmotiveunload varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinventorysortingamortizationyear PRIMARY KEY (ayear,
idinv,
idinventoryamortization
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorysortingamortizationyear' and id=object_id('inventorysortingamortizationyear'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorysortingamortizationyear
     ON inventorysortingamortizationyear
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorysortingamortizationyear
     ON inventorysortingamortizationyear
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA inventorytreesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[inventorytreesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [inventorytreesorting] (
idsor int NOT NULL,
idinv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinventorytreesorting PRIMARY KEY (idsor,
idinv
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytreesorting
     ON inventorytreesorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytreesorting
     ON inventorytreesorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytreesorting' and id=object_id('inventorytreesorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytreesorting
     ON inventorytreesorting
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytreesorting
     ON inventorytreesorting
     (
     idinv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA invoice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoice] (
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
active char(1) NULL,
adate smalldatetime NOT NULL,
autoinvoice char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
exchangerate float NULL,
flag int NULL,
flag_ddt char(1) NULL,
flagdeferred char(1) NULL,
flagintracom char(1) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idblacklist int NULL,
idcountry_destination int NULL,
idcountry_origin int NULL,
idcurrency int NULL,
idexpirationkind smallint NULL,
idintrastatkind varchar(2) NULL,
idintrastatpaymethod int NULL,
idinvkind_real int NULL,
idreg int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idtreasurer int NULL,
iso_destination varchar(2) NULL,
iso_origin varchar(2) NULL,
iso_payment varchar(2) NULL,
iso_provenance varchar(2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninv_real int NULL,
officiallyprinted char(1) NOT NULL,
packinglistdate smalldatetime NULL,
packinglistnum varchar(25) NULL,
paymentexpiring smallint NULL,
registryreference varchar(150) NULL,
rtf image NULL,
txt text NULL,
yinv_real smallint NULL,
 CONSTRAINT xpkinvoice PRIMARY KEY (idinvkind,
yinv,
ninv
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoice' and id=object_id('invoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1invoice
     ON invoice
     (
     idinvkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1invoice
     ON invoice
     (
     idinvkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2invoice' and id=object_id('invoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoice
     ON invoice
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoice
     ON invoice
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7invoice' and id=object_id('invoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7invoice
     ON invoice
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7invoice
     ON invoice
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8' and id=object_id('invoice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8
     ON invoice
     (
     idinvkind_real, yinv_real, ninv_real     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8
     ON invoice
     (
     idinvkind_real, yinv_real, ninv_real     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA invoicedeferred --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicedeferred]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicedeferred] (
yivapay int NOT NULL,
nivapay int NOT NULL,
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
ivatotalpayed decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
totalpayed decimal(19,2) NULL,
 CONSTRAINT xpkinvoicedeferred PRIMARY KEY (yivapay,
nivapay,
idinvkind,
yinv,
ninv
)
)
END
GO

-- CREAZIONE TABELLA invoicedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicedetail] (
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
rownum int NOT NULL,
annotations varchar(400) NULL,
competencystart datetime NULL,
competencystop datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
detaildescription varchar(150) NULL,
discount float NULL,
estimrownum int NULL,
exception12 char(1) NULL,
flag int NULL,
idaccmotive varchar(36) NULL,
idestimkind varchar(20) NULL,
idexp_iva int NULL,
idexp_taxable int NULL,
idgroup int NULL,
idinc_iva int NULL,
idinc_taxable int NULL,
idintrastatcode int NULL,
idintrastatmeasure int NULL,
idintrastatservice int NULL,
idintrastatsupplymethod int NULL,
idinvkind_main int NULL,
idivakind int NOT NULL,
idlist int NULL,
idmankind varchar(20) NULL,
idpackage int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idunit int NULL,
idupb varchar(36) NULL,
idupb_iva varchar(36) NULL,
intra12operationkind char(1) NULL,
intrastatoperationkind char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
manrownum int NULL,
move12 char(1) NULL,
nestim int NULL,
ninv_main int NULL,
nman int NULL,
npackage decimal(19,2) NULL,
number decimal(19,2) NULL,
paymentcompetency datetime NULL,
tax decimal(19,2) NULL,
taxable decimal(19,5) NULL,
unabatable decimal(19,2) NULL,
unitsforpackage int NULL,
va3type char(1) NULL,
weight decimal(19,2) NULL,
yestim smallint NULL,
yinv_main smallint NULL,
yman smallint NULL,
 CONSTRAINT xpkinvoicedetail PRIMARY KEY (idinvkind,
yinv,
ninv,
rownum
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1invoicedetail
     ON invoicedetail
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1invoicedetail
     ON invoicedetail
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoicedetail
     ON invoicedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoicedetail
     ON invoicedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3invoicedetail
     ON invoicedetail
     (
     idexp_taxable     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3invoicedetail
     ON invoicedetail
     (
     idexp_taxable     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4invoicedetail
     ON invoicedetail
     (
     idexp_iva     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4invoicedetail
     ON invoicedetail
     (
     idexp_iva     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5invoicedetail
     ON invoicedetail
     (
     idinc_taxable     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5invoicedetail
     ON invoicedetail
     (
     idinc_taxable     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6invoicedetail' and id=object_id('invoicedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6invoicedetail
     ON invoicedetail
     (
     idinc_iva     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6invoicedetail
     ON invoicedetail
     (
     idinc_iva     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA invoicekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicekind] (
idinvkind int NOT NULL,
active char(1) NULL,
address varchar(150) NULL,
codeinvkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
flag_autodocnumbering char(1) NULL,
formatstring varchar(50) NULL,
header varchar(150) NULL,
idinvkind_auto int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
notes1 text NULL,
notes2 text NULL,
notes3 text NULL,
printingcode varchar(20) NULL,
 CONSTRAINT xpkinvoicekind PRIMARY KEY (idinvkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukinvoicekind' and id=object_id('invoicekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinvoicekind
     ON invoicekind
     (
     codeinvkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukinvoicekind
     ON invoicekind
     (
     codeinvkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_invoicekind' and id=object_id('invoicekind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_invoicekind
     ON invoicekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_invoicekind
     ON invoicekind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2invoicekind' and id=object_id('invoicekind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoicekind
     ON invoicekind
     (
     codeinvkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2invoicekind
     ON invoicekind
     (
     codeinvkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA invoicekindregisterkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicekindregisterkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicekindregisterkind] (
idinvkind int NOT NULL,
idivaregisterkind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinvoicekindregisterkind PRIMARY KEY (idinvkind,
idivaregisterkind
)
)
END
GO

-- CREAZIONE TABELLA invoicekindyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicekindyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicekindyear] (
ayear smallint NOT NULL,
idinvkind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idacc varchar(38) NULL,
idacc_deferred varchar(38) NULL,
idacc_deferred_intra varchar(38) NULL,
idacc_discount varchar(38) NULL,
idacc_intra varchar(38) NULL,
idacc_unabatable varchar(38) NULL,
idacc_unabatable_intra varchar(38) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkinvoicekindyear PRIMARY KEY (ayear,
idinvkind
)
)
END
GO

-- CREAZIONE TABELLA invoicesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[invoicesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [invoicesorting] (
idsor int NOT NULL,
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NOT NULL,
 CONSTRAINT xpkinvoicesorting PRIMARY KEY (idsor,
idinvkind,
yinv,
ninv
)
)
END
GO

-- CREAZIONE TABELLA itineration --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itineration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itineration] (
iditineration int NOT NULL,
active char(1) NULL,
adate smalldatetime NOT NULL,
admincarkm float NULL,
admincarkmcost decimal(19,6) NULL,
applierannotations varchar(800) NULL,
authdoc varchar(35) NULL,
authdocdate smalldatetime NULL,
authneeded char(1) NULL,
authorizationdate smalldatetime NOT NULL,
cancelreason varchar(400) NULL,
clause_accepted char(1) NULL,
completed char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flagweb char(1) NULL,
footkm float NULL,
footkmcost decimal(19,6) NULL,
grossfactor float NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idauthmodel int NULL,
iditinerationstatus int NULL,
idman int NULL,
idreg int NOT NULL,
idregistrylegalstatus int NULL,
idser int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
location varchar(65) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
netfee decimal(19,2) NULL,
nitineration int NOT NULL,
noauthreason varchar(1000) NULL,
owncarkm float NULL,
owncarkmcost decimal(19,6) NULL,
rtf image NULL,
start smalldatetime NOT NULL,
stop smalldatetime NOT NULL,
totadvance decimal(19,2) NULL,
total decimal(19,2) NULL,
totalgross decimal(19,2) NULL,
txt text NULL,
vehicle_info varchar(200) NULL,
vehicle_motive varchar(2000) NULL,
webwarn varchar(400) NULL,
yitineration smallint NOT NULL,
 CONSTRAINT xpkitineration PRIMARY KEY (iditineration
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukitineration' and id=object_id('itineration'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitineration
     ON itineration
     (
     yitineration, nitineration     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitineration
     ON itineration
     (
     yitineration, nitineration     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itineration
     ON itineration
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itineration
     ON itineration
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2itineration
     ON itineration
     (
     idser     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2itineration
     ON itineration
     (
     idser     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3itineration
     ON itineration
     (
     yitineration, nitineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3itineration
     ON itineration
     (
     yitineration, nitineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA itinerationattachment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationattachment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationattachment] (
iditineration int NOT NULL,
idattachment int NOT NULL,
attachment image NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
filename varchar(200) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationattachment PRIMARY KEY (iditineration,
idattachment
)
)
END
GO

-- CREAZIONE TABELLA itinerationauthagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationauthagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationauthagency] (
iditineration int NOT NULL,
idauthagency int NOT NULL,
flagstatus char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkitinerationauthagency PRIMARY KEY (iditineration,
idauthagency
)
)
END
GO

-- CREAZIONE TABELLA itinerationlap --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationlap]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationlap] (
iditineration int NOT NULL,
lapnumber smallint NOT NULL,
advancepercentage decimal(19,8) NULL,
allowance decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
days float NOT NULL,
description varchar(150) NOT NULL,
flagitalian char(1) NOT NULL,
hours float NOT NULL,
idforeigncountry int NULL,
idreduction varchar(20) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
reductionpercentage decimal(19,8) NULL,
starttime smalldatetime NULL,
stoptime smalldatetime NULL,
 CONSTRAINT xpkitinerationlap PRIMARY KEY (iditineration,
lapnumber
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationlap' and id=object_id('itinerationlap'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationlap
     ON itinerationlap
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationlap
     ON itinerationlap
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationlap' and id=object_id('itinerationlap'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationlap
     ON itinerationlap
     (
     idforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationlap
     ON itinerationlap
     (
     idforeigncountry     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4itinerationlap' and id=object_id('itinerationlap'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4itinerationlap
     ON itinerationlap
     (
     idreduction     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4itinerationlap
     ON itinerationlap
     (
     idreduction     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA itinerationrefund --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationrefund]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationrefund] (
iditineration int NOT NULL,
nrefund smallint NOT NULL,
advancepercentage decimal(19,8) NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
doc varchar(35) NULL,
docamount decimal(19,2) NULL,
docdate smalldatetime NULL,
exchangerate float NULL,
extraallowance decimal(19,2) NULL,
flag_geo char(1) NULL,
flagadvancebalance char(1) NULL,
flagitalian char(1) NULL,
idcurrency int NULL,
idforeigncountry int NULL,
iditinerationrefundkind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
requiredamount decimal(19,2) NULL,
starttime datetime NULL,
stoptime datetime NULL,
webwarn varchar(1000) NULL,
 CONSTRAINT xpkitinerationrefund PRIMARY KEY (iditineration,
nrefund
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationrefund
     ON itinerationrefund
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationrefund
     ON itinerationrefund
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3itinerationrefund
     ON itinerationrefund
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3itinerationrefund
     ON itinerationrefund
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4itinerationrefund' and id=object_id('itinerationrefund'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4itinerationrefund
     ON itinerationrefund
     (
     iditinerationrefundkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4itinerationrefund
     ON itinerationrefund
     (
     iditinerationrefundkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA itinerationsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationsorting] (
iditineration int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,2) NULL,
 CONSTRAINT xpkitinerationsorting PRIMARY KEY (iditineration,
idsor
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationsorting' and id=object_id('itinerationsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationsorting
     ON itinerationsorting
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationsorting
     ON itinerationsorting
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA itinerationtax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itinerationtax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itinerationtax] (
iditineration int NOT NULL,
taxcode int NOT NULL,
admindenominator decimal(19,8) NULL,
adminnumerator decimal(19,8) NULL,
adminrate decimal(19,8) NULL,
admintax decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,8) NULL,
employrate decimal(19,8) NULL,
employtax decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxable decimal(19,2) NULL,
taxabledenominator decimal(19,8) NULL,
taxablenumerator decimal(19,8) NULL,
 CONSTRAINT xpkitinerationtax PRIMARY KEY (iditineration,
taxcode
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itinerationtax' and id=object_id('itinerationtax'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationtax
     ON itinerationtax
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itinerationtax
     ON itinerationtax
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itinerationtax' and id=object_id('itinerationtax'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationtax
     ON itinerationtax
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2itinerationtax
     ON itinerationtax
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA iva_mixed --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[iva_mixed]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [iva_mixed] (
nmixed int NOT NULL,
ayear int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
mixed decimal(19,6) NULL,
 CONSTRAINT xpkiva_mixed PRIMARY KEY (nmixed
)
)
END
GO

-- CREAZIONE TABELLA iva_prorata --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[iva_prorata]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [iva_prorata] (
nprorata int NOT NULL,
ayear int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
prorata decimal(19,6) NULL,
 CONSTRAINT xpkiva_prorata PRIMARY KEY (nprorata
)
)
END
GO

-- CREAZIONE TABELLA ivakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivakind] (
idivakind int NOT NULL,
active char(1) NULL,
annotations varchar(1000) NULL,
codeivakind varchar(20) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag int NULL,
idivataxablekind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rate decimal(19,6) NOT NULL,
unabatabilitypercentage decimal(19,6) NOT NULL,
 CONSTRAINT xpkivakind PRIMARY KEY (idivakind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukivakind' and id=object_id('ivakind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukivakind
     ON ivakind
     (
     codeivakind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukivakind
     ON ivakind
     (
     codeivakind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_ivakind' and id=object_id('ivakind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivakind
     ON ivakind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivakind
     ON ivakind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivakind' and id=object_id('ivakind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivakind
     ON ivakind
     (
     codeivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivakind
     ON ivakind
     (
     codeivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivapay --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivapay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivapay] (
yivapay int NOT NULL,
nivapay int NOT NULL,
assesmentdate smalldatetime NULL,
creditamount decimal(19,2) NULL,
creditamount12 decimal(19,2) NULL,
creditamountdeferred decimal(19,2) NULL,
creditamountdeferred12 decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
dateivapay smalldatetime NOT NULL,
debitamount decimal(19,2) NULL,
debitamount12 decimal(19,2) NULL,
debitamountdeferred decimal(19,2) NULL,
debitamountdeferred12 decimal(19,2) NULL,
flag tinyint NULL,
ivaintrastat12 decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
paymentamount decimal(19,2) NULL,
paymentamount12 decimal(19,2) NULL,
paymentdetails varchar(150) NULL,
paymentkind char(1) NOT NULL,
prorata decimal(19,6) NULL,
refundamount decimal(19,2) NULL,
refundamount12 decimal(19,2) NULL,
start smalldatetime NOT NULL,
stop smalldatetime NOT NULL,
taxableintrastat12 decimal(19,2) NULL,
totalcredit decimal(19,2) NULL,
totalcredit12 decimal(19,2) NULL,
totaldebit decimal(19,2) NULL,
totaldebit12 decimal(19,2) NULL,
 CONSTRAINT xpkivapay PRIMARY KEY (yivapay,
nivapay
)
)
END
GO

-- CREAZIONE TABELLA ivapaydetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivapaydetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivapaydetail] (
yivapay int NOT NULL,
nivapay int NOT NULL,
idivaregisterkind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iva decimal(19,2) NULL,
ivadeferred decimal(19,2) NULL,
ivanet decimal(19,2) NULL,
ivanetdeferred decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
prorata decimal(19,6) NULL,
taxable12 decimal(19,2) NULL,
taxabledeferred12 decimal(19,2) NULL,
unabatable decimal(19,2) NULL,
unabatabledeferred decimal(19,2) NULL,
 CONSTRAINT xpkivapaydetail PRIMARY KEY (yivapay,
nivapay,
idivaregisterkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivapaydetail' and id=object_id('ivapaydetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapaydetail
     ON ivapaydetail
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapaydetail
     ON ivapaydetail
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapaydetail' and id=object_id('ivapaydetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapaydetail
     ON ivapaydetail
     (
     idivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapaydetail
     ON ivapaydetail
     (
     idivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivapayexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivapayexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivapayexpense] (
yivapay int NOT NULL,
nivapay int NOT NULL,
idexp int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkivapayexpense PRIMARY KEY (yivapay,
nivapay,
idexp
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivapayexpense' and id=object_id('ivapayexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapayexpense
     ON ivapayexpense
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapayexpense
     ON ivapayexpense
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayexpense' and id=object_id('ivapayexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapayexpense
     ON ivapayexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapayexpense
     ON ivapayexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivapayincome --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivapayincome]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivapayincome] (
yivapay int NOT NULL,
nivapay int NOT NULL,
idinc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkivapayincome PRIMARY KEY (yivapay,
nivapay,
idinc
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivapayincome' and id=object_id('ivapayincome'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapayincome
     ON ivapayincome
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivapayincome
     ON ivapayincome
     (
     yivapay, nivapay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivapayincome' and id=object_id('ivapayincome'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapayincome
     ON ivapayincome
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivapayincome
     ON ivapayincome
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivaregister --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivaregister]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivaregister] (
idivaregisterkind int NOT NULL,
yivaregister smallint NOT NULL,
nivaregister int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idinvkind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninv int NOT NULL,
protocolnum int NULL,
yinv smallint NOT NULL,
 CONSTRAINT xpkivaregister PRIMARY KEY (idivaregisterkind,
yivaregister,
nivaregister
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivaregister' and id=object_id('ivaregister'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivaregister
     ON ivaregister
     (
     idivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivaregister
     ON ivaregister
     (
     idivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2ivaregister' and id=object_id('ivaregister'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivaregister
     ON ivaregister
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2ivaregister
     ON ivaregister
     (
     idinvkind, yinv, ninv     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivaregisterkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivaregisterkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivaregisterkind] (
idivaregisterkind int NOT NULL,
codeivaregisterkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flagactivity smallint NULL,
idivaregisterkindunified varchar(20) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
registerclass char(1) NOT NULL,
 CONSTRAINT xpkivaregisterkind PRIMARY KEY (idivaregisterkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukivaregisterkind' and id=object_id('ivaregisterkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukivaregisterkind
     ON ivaregisterkind
     (
     codeivaregisterkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukivaregisterkind
     ON ivaregisterkind
     (
     codeivaregisterkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_ivaregisterkind' and id=object_id('ivaregisterkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivaregisterkind
     ON ivaregisterkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_ivaregisterkind
     ON ivaregisterkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1ivaregisterkind' and id=object_id('ivaregisterkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivaregisterkind
     ON ivaregisterkind
     (
     codeivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1ivaregisterkind
     ON ivaregisterkind
     (
     codeivaregisterkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA ivataxablekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ivataxablekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ivataxablekind] (
idivataxablekind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkivataxablekind PRIMARY KEY (idivataxablekind
)
)
END
GO

-- CREAZIONE TABELLA journalfieldsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[journalfieldsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [journalfieldsetup] (
tablename varchar(150) NOT NULL,
opkind char(1) NOT NULL,
dbfield varchar(50) NOT NULL,
 CONSTRAINT xpkjournalfieldsetup PRIMARY KEY (tablename,
opkind,
dbfield
)
)
END
GO

-- CREAZIONE TABELLA lcard --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[lcard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [lcard] (
idlcard int NOT NULL,
active char(1) NOT NULL,
description varchar(400) NULL,
extcode varchar(50) NULL,
idman int NOT NULL,
idstore int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
title varchar(50) NOT NULL,
ystart smallint NULL,
ystop smallint NULL,
 CONSTRAINT xpklcard PRIMARY KEY (idlcard
)
)
END
GO

-- CREAZIONE TABELLA lcardcf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[lcardcf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [lcardcf] (
idlcard int NOT NULL,
cf varchar(16) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpklcardcf PRIMARY KEY (idlcard,
cf
)
)
END
GO

-- CREAZIONE TABELLA lcardtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[lcardtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [lcardtotal] (
idlcard int NOT NULL,
amount decimal(19,2) NOT NULL,
 CONSTRAINT xpklcardtotal PRIMARY KEY (idlcard
)
)
END
GO

-- CREAZIONE TABELLA lcardvar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[lcardvar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [lcardvar] (
idlcardvar int NOT NULL,
adate datetime NOT NULL,
amount decimal(19,2) NOT NULL,
description varchar(150) NULL,
email varchar(200) NULL,
idfin int NOT NULL,
idlcard int NOT NULL,
idupb varchar(36) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlvar int NOT NULL,
nvar int NULL,
ylvar smallint NOT NULL,
yvar smallint NULL,
 CONSTRAINT xpklcardvar PRIMARY KEY (idlcardvar
)
)
END
GO

-- CREAZIONE TABELLA license --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[license]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [license] (
dummykey char(1) NOT NULL,
address1 varchar(50) NULL,
address2 varchar(50) NULL,
agency varchar(150) NULL,
agencycode varchar(20) NULL,
agencyname varchar(150) NULL,
annotations varchar(200) NULL,
cap char(5) NULL,
cf varchar(11) NULL,
checkbackup1 varchar(50) NULL,
checkbackup2 varchar(50) NULL,
checkflag varchar(50) NULL,
checklic varchar(50) NULL,
checkman varchar(50) NULL,
country char(2) NULL,
dbname varchar(50) NULL,
department varchar(150) NULL,
departmentcode varchar(20) NULL,
departmentname varchar(150) NULL,
email varchar(200) NULL,
expiringlic datetime NULL,
expiringman datetime NULL,
fax varchar(150) NULL,
idcity int NULL,
iddb int NULL,
idreg int NULL,
lickind char(1) NULL,
licstatus char(1) NULL,
location varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
mankind char(1) NULL,
manstatus char(1) NULL,
nmsgs int NULL,
p_iva varchar(11) NULL,
phonenumber varchar(30) NULL,
referent varchar(200) NULL,
sent char(1) NULL,
serverbackup1 varchar(50) NULL,
serverbackup2 varchar(50) NULL,
servername varchar(50) NULL,
swmorecode varchar(50) NULL,
swmoreflag int NULL,
 CONSTRAINT xpklicense PRIMARY KEY (dummykey
)
)
END
GO

-- CREAZIONE TABELLA listclassyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[listclassyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [listclassyear] (
idlistclass varchar(36) NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idintrastatcode int NULL,
idintrastatservice int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpklistclassyear PRIMARY KEY (idlistclass,
ayear
)
)
END
GO

-- CREAZIONE TABELLA location --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[location]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [location] (
idlocation int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idman int NULL,
locationcode varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
newlocationcode varchar(50) NULL,
nlevel tinyint NOT NULL,
paridlocation int NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpklocation PRIMARY KEY (idlocation
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_location' and id=object_id('location'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_location
     ON location
     (
     locationcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_location
     ON location
     (
     locationcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1location
     ON location
     (
     paridlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1location
     ON location
     (
     paridlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2location
     ON location
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2location
     ON location
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3location' and id=object_id('location'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3location
     ON location
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3location
     ON location
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA locationlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[locationlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [locationlevel] (
nlevel tinyint NOT NULL,
codelen tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpklocationlevel PRIMARY KEY (nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_locationlevel' and id=object_id('locationlevel'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_locationlevel
     ON locationlevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_locationlevel
     ON locationlevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA locationlink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[locationlink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [locationlink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpklocationlink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA locationsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[locationsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [locationsorting] (
idsor int NOT NULL,
idlocation int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpklocationsorting PRIMARY KEY (idsor,
idlocation
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1locationsorting' and id=object_id('locationsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1locationsorting
     ON locationsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1locationsorting
     ON locationsorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2locationsorting' and id=object_id('locationsorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2locationsorting
     ON locationsorting
     (
     idlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2locationsorting
     ON locationsorting
     (
     idlocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA logo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[logo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [logo] (
idlogo varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
logo image NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpklogo PRIMARY KEY (idlogo
)
)
END
GO

-- CREAZIONE TABELLA mainivapay --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mainivapay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mainivapay] (
ymainivapay int NOT NULL,
nmainivapay int NOT NULL,
assesmentdate smalldatetime NULL,
creditamount decimal(19,2) NULL,
creditamount12 decimal(19,2) NULL,
creditamountdeferred decimal(19,2) NULL,
creditamountdeferred12 decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datemainivapay smalldatetime NOT NULL,
debitamount decimal(19,2) NULL,
debitamount12 decimal(19,2) NULL,
debitamountdeferred decimal(19,2) NULL,
debitamountdeferred12 decimal(19,2) NULL,
flag tinyint NULL,
ivaintrastat12 decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
nmonth int NULL,
paymentamount decimal(19,2) NULL,
paymentamount12 decimal(19,2) NULL,
paymentdetails varchar(150) NULL,
paymentkind char(1) NOT NULL,
prorata decimal(19,6) NULL,
referenceyear int NULL,
refundamount decimal(19,2) NULL,
refundamount12 decimal(19,2) NULL,
taxableintrastat12 decimal(19,2) NULL,
totalcredit decimal(19,2) NULL,
totalcredit12 decimal(19,2) NULL,
totaldebit decimal(19,2) NULL,
totaldebit12 decimal(19,2) NULL,
 CONSTRAINT xpkmainivapay PRIMARY KEY (ymainivapay,
nmainivapay
)
)
END
GO

-- CREAZIONE TABELLA mainivapaydetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mainivapaydetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mainivapaydetail] (
nmainivapay int NOT NULL,
ymainivapay int NOT NULL,
idivaregisterkind int NOT NULL,
iddbdepartment varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iva decimal(19,2) NULL,
ivadeferred decimal(19,2) NULL,
ivanet decimal(19,2) NULL,
ivanetdeferred decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
prorata decimal(19,6) NULL,
taxable12 decimal(19,2) NULL,
taxabledeferred12 decimal(19,2) NULL,
unabatable decimal(19,2) NULL,
unabatabledeferred decimal(19,2) NULL,
 CONSTRAINT xpkmainivapaydetail PRIMARY KEY (nmainivapay,
ymainivapay,
idivaregisterkind,
iddbdepartment
)
)
END
GO

-- CREAZIONE TABELLA mainivapayexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mainivapayexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mainivapayexpense] (
ymainivapay int NOT NULL,
nmainivapay int NOT NULL,
idexp int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmainivapayexpense PRIMARY KEY (ymainivapay,
nmainivapay,
idexp
)
)
END
GO

-- CREAZIONE TABELLA mainivapayincome --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mainivapayincome]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mainivapayincome] (
ymainivapay int NOT NULL,
nmainivapay int NOT NULL,
idinc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmainivapayincome PRIMARY KEY (ymainivapay,
nmainivapay,
idinc
)
)
END
GO

-- CREAZIONE TABELLA maintenance --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[maintenance]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [maintenance] (
nmaintenance int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idasset int NOT NULL,
idmaintenancekind int NOT NULL,
idpiece int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkmaintenance PRIMARY KEY (nmaintenance
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1maintenance' and id=object_id('maintenance'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1maintenance
     ON maintenance
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1maintenance
     ON maintenance
     (
     idasset     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2maintenance' and id=object_id('maintenance'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2maintenance
     ON maintenance
     (
     idmaintenancekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2maintenance
     ON maintenance
     (
     idmaintenancekind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA manager --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[manager]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [manager] (
idman int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
financeactive char(1) NULL,
iddivision int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
newidman int NULL,
passwordweb varchar(40) NULL,
phonenumber varchar(30) NULL,
rtf image NULL,
title varchar(150) NOT NULL,
txt text NULL,
userweb varchar(40) NULL,
wantswarn char(1) NULL,
 CONSTRAINT xpkmanager PRIMARY KEY (idman
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_manager' and id=object_id('manager'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_manager
     ON manager
     (
     title     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_manager
     ON manager
     (
     title     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1manager' and id=object_id('manager'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1manager
     ON manager
     (
     iddivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1manager
     ON manager
     (
     iddivision     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA managersorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[managersorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [managersorting] (
idman int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkmanagersorting PRIMARY KEY (idman,
idsor
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1managersorting' and id=object_id('managersorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1managersorting
     ON managersorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1managersorting
     ON managersorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2managersorting' and id=object_id('managersorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2managersorting
     ON managersorting
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2managersorting
     ON managersorting
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA mandate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandate] (
idmankind varchar(20) NOT NULL,
yman smallint NOT NULL,
nman int NOT NULL,
active char(1) NULL,
adate smalldatetime NOT NULL,
applierannotations varchar(400) NULL,
cigcode varchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deliveryaddress varchar(150) NULL,
deliveryexpiration varchar(50) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
exchangerate float NULL,
flagdanger char(1) NULL,
flagintracom char(1) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idconsipkind int NULL,
idcurrency int NULL,
idexpirationkind smallint NULL,
idman int NULL,
idmandatestatus smallint NULL,
idreg int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idstore int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
officiallyprinted char(1) NOT NULL,
paymentexpiring smallint NULL,
registryreference varchar(150) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkmandate PRIMARY KEY (idmankind,
yman,
nman
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1mandate' and id=object_id('mandate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1mandate
     ON mandate
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1mandate
     ON mandate
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2mandate' and id=object_id('mandate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2mandate
     ON mandate
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2mandate
     ON mandate
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3mandate' and id=object_id('mandate'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3mandate
     ON mandate
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3mandate
     ON mandate
     (
     idcurrency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA mandateattachment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandateattachment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandateattachment] (
idmankind varchar(20) NOT NULL,
yman smallint NOT NULL,
nman int NOT NULL,
idattachment int NOT NULL,
attachment image NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
filename varchar(200) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmandateattachment PRIMARY KEY (idmankind,
yman,
nman,
idattachment
)
)
END
GO

-- CREAZIONE TABELLA mandatedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandatedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandatedetail] (
idmankind varchar(20) NOT NULL,
yman smallint NOT NULL,
nman int NOT NULL,
rownum int NOT NULL,
annotations varchar(400) NULL,
applierannotations text NULL,
assetkind char(1) NOT NULL,
cigcode varchar(10) NULL,
competencystart datetime NULL,
competencystop datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
detaildescription varchar(150) NULL,
discount float NULL,
epkind char(1) NULL,
flagactivity smallint NULL,
flagmixed char(1) NULL,
flagto_unload char(1) NULL,
idaccmotive varchar(36) NULL,
idaccmotiveannulment varchar(36) NULL,
idexp_iva int NULL,
idexp_taxable int NULL,
idgroup int NULL,
idinv int NULL,
idivakind int NULL,
idlist int NULL,
idpackage int NULL,
idreg int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idunit int NULL,
idupb varchar(36) NULL,
ivanotes varchar(400) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ninvoiced decimal(19,2) NULL,
npackage decimal(19,2) NULL,
number decimal(19,2) NULL,
start datetime NULL,
stop datetime NULL,
tax decimal(19,2) NULL,
taxable decimal(19,5) NULL,
taxrate float NULL,
toinvoice char(1) NULL,
unabatable decimal(19,2) NULL,
unitsforpackage int NULL,
va3type char(1) NULL,
 CONSTRAINT xpkmandatedetail PRIMARY KEY (idmankind,
yman,
nman,
rownum
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1mandatedetail' and id=object_id('mandatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1mandatedetail
     ON mandatedetail
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1mandatedetail
     ON mandatedetail
     (
     yman, nman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2mandatedetail' and id=object_id('mandatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2mandatedetail
     ON mandatedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2mandatedetail
     ON mandatedetail
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3mandatedetail' and id=object_id('mandatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3mandatedetail
     ON mandatedetail
     (
     idexp_taxable     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3mandatedetail
     ON mandatedetail
     (
     idexp_taxable     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4mandatedetail' and id=object_id('mandatedetail'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4mandatedetail
     ON mandatedetail
     (
     idexp_iva     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4mandatedetail
     ON mandatedetail
     (
     idexp_iva     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA mandatekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandatekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandatekind] (
idmankind varchar(20) NOT NULL,
active char(1) NULL,
address varchar(150) NULL,
assetkind tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
dangermail varchar(200) NULL,
deltaamount decimal(19,2) NULL,
deltapercentage decimal(19,2) NULL,
description varchar(150) NOT NULL,
email varchar(200) NULL,
faxnumber varchar(50) NULL,
flag_autodocnumbering char(1) NULL,
flagactivity smallint NULL,
header varchar(150) NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idupb varchar(36) NULL,
isrequest char(1) NULL,
linktoasset char(1) NULL,
linktoinvoice char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
multireg char(1) NULL,
name_c varchar(200) NULL,
name_l varchar(200) NULL,
name_r varchar(200) NULL,
notes1 text NULL,
notes2 text NULL,
notes3 text NULL,
office varchar(150) NULL,
phonenumber varchar(30) NULL,
rtf image NULL,
title_c varchar(200) NULL,
title_l varchar(200) NULL,
title_r varchar(200) NULL,
txt text NULL,
warnmail varchar(400) NULL,
 CONSTRAINT xpkmandatekind PRIMARY KEY (idmankind
)
)
END
GO

-- CREAZIONE TABELLA mandatesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandatesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandatesorting] (
idsor int NOT NULL,
idmankind varchar(20) NOT NULL,
yman smallint NOT NULL,
nman int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkmandatesorting PRIMARY KEY (idsor,
idmankind,
yman,
nman
)
)
END
GO

-- CREAZIONE TABELLA mandatestatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[mandatestatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [mandatestatus] (
idmandatestatus smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
listingorder smallint NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkmandatestatus PRIMARY KEY (idmandatestatus
)
)
END
GO

-- CREAZIONE TABELLA matriculabook --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[matriculabook]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [matriculabook] (
idmatriculabook varchar(5) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(200) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkmatriculabook PRIMARY KEY (idmatriculabook
)
)
END
GO

-- CREAZIONE TABELLA menu --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[menu]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [menu] (
idmenu int NOT NULL,
edittype varchar(60) NULL,
lt datetime NULL,
lu varchar(64) NULL,
menucode varchar(80) NULL,
metadata varchar(60) NULL,
modal char(1) NULL,
ordernumber int NULL,
parameter varchar(80) NULL,
paridmenu int NULL,
title varchar(80) NOT NULL,
userid varchar(80) NULL,
 CONSTRAINT xpkmenu PRIMARY KEY (idmenu
)
)
END
GO

-- CREAZIONE TABELLA miursetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[miursetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [miursetup] (
internalcode varchar(20) NOT NULL,
sortcode int NOT NULL,
 CONSTRAINT xpkmiursetup PRIMARY KEY (internalcode
)
)
END
GO

-- CREAZIONE TABELLA moneytransfer --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[moneytransfer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [moneytransfer] (
ytransfer smallint NOT NULL,
ntransfer int NOT NULL,
adate datetime NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
idtreasurerdest int NOT NULL,
idtreasurersource int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nproceedspart int NULL,
nvar int NULL,
rownum int NULL,
yproceedspart smallint NULL,
yvar smallint NULL,
 CONSTRAINT xpkmoneytransfer PRIMARY KEY (ytransfer,
ntransfer
)
)
END
GO

-- CREAZIONE TABELLA ondemand --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[ondemand]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [ondemand] (
code varchar(20) NOT NULL,
dbversion varchar(20) NULL,
description varchar(2000) NULL,
downloaddate smalldatetime NULL,
filelist varchar(2000) NULL,
flagkind char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
publishingdate smalldatetime NULL,
shortdescription varchar(500) NULL,
 CONSTRAINT xpkondemand PRIMARY KEY (code
)
)
END
GO

-- CREAZIONE TABELLA otherinail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[otherinail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [otherinail] (
idotherinail int NOT NULL,
idcon varchar(8) NOT NULL,
nmonths int NULL,
start datetime NULL,
stop datetime NULL,
taxable decimal(19,2) NULL,
 CONSTRAINT xpkotherinail PRIMARY KEY (idotherinail,
idcon
)
)
END
GO

-- CREAZIONE TABELLA parasubcontract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[parasubcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [parasubcontract] (
idcon varchar(8) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
duty varchar(150) NULL,
employed char(1) NOT NULL,
flagroundedmonths char(1) NULL,
grossamount decimal(19,6) NOT NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idmatriculabook varchar(5) NULL,
idpat int NULL,
idpayrollkind varchar(20) NULL,
idreg int NOT NULL,
idregistrylegalstatus int NULL,
idser int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(64) NULL,
matricula int NULL,
monthlen int NOT NULL,
ncon varchar(20) NOT NULL,
payrollccinfo char(1) NOT NULL,
rtf image NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
txt text NULL,
ycon int NOT NULL,
 CONSTRAINT xpkparasubcontract PRIMARY KEY (idcon
)
)
END
GO

-- CREAZIONE TABELLA parasubcontractfamily --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractfamily]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [parasubcontractfamily] (
ayear int NOT NULL,
idcon varchar(8) NOT NULL,
idfamily int NOT NULL,
amount decimal(19,2) NULL,
appliancepercentage decimal(19,6) NULL,
birthdate datetime NULL,
cf varchar(16) NULL,
childasparent char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
flagdependent char(1) NOT NULL,
flagforeign char(1) NULL,
foreignresident char(1) NOT NULL,
forename varchar(50) NULL,
gender char(1) NULL,
idaffinity char(1) NOT NULL,
idcitybirth int NULL,
idnation int NULL,
lt datetime NULL,
lu varchar(64) NULL,
startapplication datetime NULL,
starthandicap datetime NULL,
stopapplication datetime NULL,
surname varchar(50) NULL,
 CONSTRAINT xpkparasubcontractfamily PRIMARY KEY (ayear,
idcon,
idfamily
)
)
END
GO

-- CREAZIONE TABELLA parasubcontractsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [parasubcontractsorting] (
idsor int NOT NULL,
idcon varchar(8) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkparasubcontractsorting PRIMARY KEY (idsor,
idcon
)
)
END
GO

-- CREAZIONE TABELLA parasubcontractyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [parasubcontractyear] (
ayear int NOT NULL,
idcon varchar(8) NOT NULL,
activitycode varchar(20) NULL,
annualincome decimal(19,2) NULL,
applybrackets char(1) NULL,
citytax decimal(19,2) NULL,
citytax_account decimal(19,2) NULL,
competencymonths decimal(19,6) NULL,
countrytax decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
cuddays smallint NULL,
fiscaldeduction decimal(19,2) NULL,
highertax decimal(19,2) NULL,
idemenscontractkind varchar(2) NULL,
idotherinsurance varchar(20) NULL,
idresidence int NULL,
lt datetime NULL,
lu varchar(64) NULL,
ndays int NULL,
notaxappliance char(1) NULL,
notaxdeduction decimal(19,2) NULL,
ratequantity int NULL,
ratequantity_account int NULL,
regionaltax decimal(19,2) NULL,
startcompetency datetime NULL,
startmonth int NULL,
startmonth_account int NULL,
stopcompetency datetime NULL,
suspendedcitytax decimal(19,2) NULL,
suspendedcountrytax decimal(19,2) NULL,
suspendedregionaltax decimal(19,2) NULL,
taxablecontract decimal(19,2) NULL,
taxablecud decimal(19,2) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablepension decimal(19,2) NULL,
 CONSTRAINT xpkparasubcontractyear PRIMARY KEY (ayear,
idcon
)
)
END
GO

-- CREAZIONE TABELLA partincomesetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[partincomesetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [partincomesetup] (
idfinincome int NOT NULL,
idfinexpense int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentage decimal(19,8) NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkpartincomesetup PRIMARY KEY (idfinincome,
idfinexpense
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1partincomesetup' and id=object_id('partincomesetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1partincomesetup
     ON partincomesetup
     (
     idfinincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1partincomesetup
     ON partincomesetup
     (
     idfinincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2partincomesetup' and id=object_id('partincomesetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2partincomesetup
     ON partincomesetup
     (
     idfinexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2partincomesetup
     ON partincomesetup
     (
     idfinexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pat --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pat] (
idpat int NOT NULL,
active char(1) NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(50) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
lt datetime NULL,
lu varchar(64) NULL,
patcode varchar(20) NOT NULL,
taxabledenominator decimal(19,6) NULL,
taxablenumerator decimal(19,6) NULL,
validitystart datetime NULL,
validitystop datetime NULL,
 CONSTRAINT xpkpat PRIMARY KEY (idpat
)
)
END
GO

-- CREAZIONE TABELLA paydisposition --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[paydisposition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [paydisposition] (
idpaydisposition int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NULL,
idcbimotive int NULL,
kpay int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motive varchar(80) NULL,
 CONSTRAINT xpkpaydisposition PRIMARY KEY (idpaydisposition
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1paydisposition' and id=object_id('paydisposition'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1paydisposition
     ON paydisposition
     (
     kpay     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1paydisposition
     ON paydisposition
     (
     kpay     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA paydispositiondetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[paydispositiondetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [paydispositiondetail] (
idpaydisposition int NOT NULL,
iddetail int NOT NULL,
abi varchar(5) NULL,
address varchar(30) NULL,
amount decimal(19,2) NULL,
birthdate datetime NULL,
cab varchar(5) NULL,
cap varchar(5) NULL,
cc varchar(30) NULL,
cf varchar(16) NULL,
cin varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
flaghuman char(1) NULL,
forename varchar(30) NULL,
gender char(1) NULL,
iban varchar(50) NULL,
idcbimotive int NULL,
idcity int NULL,
idnation int NULL,
location varchar(25) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motive varchar(80) NULL,
p_iva varchar(15) NULL,
paymentcode varchar(10) NULL,
paymethodcode int NULL,
province varchar(2) NULL,
surname varchar(30) NULL,
title varchar(100) NULL,
 CONSTRAINT xpkpaydispositiondetail PRIMARY KEY (idpaydisposition,
iddetail
)
)
END
GO

-- CREAZIONE TABELLA payment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payment] (
kpay int NOT NULL,
adate smalldatetime NULL,
annulmentdate datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idfin int NULL,
idman int NULL,
idreg int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idstamphandling int NULL,
idtreasurer int NULL,
kpaymenttransmission int NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
npay int NOT NULL,
printdate smalldatetime NULL,
rtf image NULL,
txt text NULL,
ypay smallint NOT NULL,
 CONSTRAINT xpkpayment PRIMARY KEY (kpay
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukpayment' and id=object_id('payment'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpayment
     ON payment
     (
     ypay, npay     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpayment
     ON payment
     (
     ypay, npay     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment
     ON payment
     (
     kpaymenttransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment
     ON payment
     (
     kpaymenttransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2payment
     ON payment
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2payment
     ON payment
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3payment
     ON payment
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3payment
     ON payment
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4payment
     ON payment
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4payment
     ON payment
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5payment
     ON payment
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5payment
     ON payment
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6payment
     ON payment
     (
     idstamphandling     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6payment
     ON payment
     (
     idstamphandling     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7payment' and id=object_id('payment'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7payment
     ON payment
     (
     ypay, npay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7payment
     ON payment
     (
     ypay, npay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA payment_bank --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payment_bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payment_bank] (
kpay int NOT NULL,
idpay int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
 CONSTRAINT xpkpayment_bank PRIMARY KEY (kpay,
idpay
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment_bank' and id=object_id('payment_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA paymenttransmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[paymenttransmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [paymenttransmission] (
kpaymenttransmission int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flagmailsent char(1) NULL,
idman int NULL,
idtreasurer int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
npaymenttransmission int NOT NULL,
transmissiondate smalldatetime NULL,
transmissionkind char(1) NULL,
ypaymenttransmission smallint NOT NULL,
 CONSTRAINT xpkpaymenttransmission PRIMARY KEY (kpaymenttransmission
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukpaymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpaymenttransmission
     ON paymenttransmission
     (
     ypaymenttransmission, npaymenttransmission     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpaymenttransmission
     ON paymenttransmission
     (
     ypaymenttransmission, npaymenttransmission     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1paymenttransmission
     ON paymenttransmission
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1paymenttransmission
     ON paymenttransmission
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2paymenttransmission
     ON paymenttransmission
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2paymenttransmission
     ON paymenttransmission
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3paymenttransmission
     ON paymenttransmission
     (
     transmissiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3paymenttransmission
     ON paymenttransmission
     (
     transmissiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4paymenttransmission' and id=object_id('paymenttransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4paymenttransmission
     ON paymenttransmission
     (
     ypaymenttransmission, npaymenttransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4paymenttransmission
     ON paymenttransmission
     (
     ypaymenttransmission, npaymenttransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA payroll --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payroll]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payroll] (
idpayroll int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
currentrounding decimal(19,2) NOT NULL,
disbursementdate datetime NULL,
enabletaxrelief char(1) NOT NULL,
feegross decimal(19,2) NOT NULL,
fiscalyear int NOT NULL,
flagbalance char(1) NULL,
flagcomputed char(1) NOT NULL,
idcon varchar(8) NOT NULL,
idresidence int NULL,
lt datetime NULL,
lu varchar(64) NULL,
netfee decimal(19,2) NULL,
npayroll int NOT NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
workingdays smallint NOT NULL,
 CONSTRAINT xpkpayroll PRIMARY KEY (idpayroll
)
)
END
GO

-- CREAZIONE TABELLA payrollabatement --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrollabatement]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrollabatement] (
idpayroll int NOT NULL,
idabatement int NOT NULL,
annualamount decimal(19,2) NULL,
curramount decimal(19,2) NULL,
taxcode int NULL,
 CONSTRAINT xpkpayrollabatement PRIMARY KEY (idpayroll,
idabatement
)
)
END
GO

-- CREAZIONE TABELLA payrolldeduction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrolldeduction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrolldeduction] (
idpayroll int NOT NULL,
iddeduction int NOT NULL,
annualamount decimal(19,2) NULL,
curramount decimal(19,2) NULL,
taxablecode varchar(20) NULL,
 CONSTRAINT xpkpayrolldeduction PRIMARY KEY (idpayroll,
iddeduction
)
)
END
GO

-- CREAZIONE TABELLA payrollkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrollkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrollkind] (
idpayrollkind varchar(20) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(150) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkpayrollkind PRIMARY KEY (idpayrollkind
)
)
END
GO

-- CREAZIONE TABELLA payrolltax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrolltax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrolltax] (
idpayroll int NOT NULL,
idpayrolltax int NOT NULL,
abatements decimal(19,2) NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
annualpayedemploytax decimal(19,2) NULL,
annualtaxabletotal decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
deduction decimal(19,2) NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
employtaxgross decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
lt datetime NULL,
lu varchar(64) NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
taxcode int NULL,
 CONSTRAINT xpkpayrolltax PRIMARY KEY (idpayroll,
idpayrolltax
)
)
END
GO

-- CREAZIONE TABELLA payrolltaxbracket --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrolltaxbracket]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrolltaxbracket] (
idpayroll int NOT NULL,
idpayrolltax int NOT NULL,
nbracket smallint NOT NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
taxable decimal(19,2) NULL,
 CONSTRAINT xpkpayrolltaxbracket PRIMARY KEY (idpayroll,
idpayrolltax,
nbracket
)
)
END
GO

-- CREAZIONE TABELLA payrolltaxcorrige --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payrolltaxcorrige]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payrolltaxcorrige] (
idpayroll int NOT NULL,
idpayrolltaxcorrige int NOT NULL,
adminamount decimal(19,2) NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employamount decimal(19,2) NULL,
idcity int NULL,
idfiscaltaxregion varchar(5) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxcode int NOT NULL,
 CONSTRAINT xpkpayrolltaxcorrige PRIMARY KEY (idpayroll,
idpayrolltaxcorrige
)
)
END
GO

-- CREAZIONE TABELLA pettycash --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycash]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycash] (
idpettycash int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
pettycode varchar(20) NULL,
 CONSTRAINT xpkpettycash PRIMARY KEY (idpettycash
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukpettycash' and id=object_id('pettycash'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpettycash
     ON pettycash
     (
     pettycode     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukpettycash
     ON pettycash
     (
     pettycode     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ___pettycash' and id=object_id('pettycash'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ___pettycash
     ON pettycash
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ___pettycash
     ON pettycash
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pettycashexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashexpense] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
idexp int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashexpense PRIMARY KEY (idpettycash,
yoperation,
noperation,
idexp
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashexpense
     ON pettycashexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashexpense
     ON pettycashexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashexpense
     ON pettycashexpense
     (
     idpettycash, yoperation, noperation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashexpense
     ON pettycashexpense
     (
     idpettycash, yoperation, noperation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashexpense' and id=object_id('pettycashexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashexpense
     ON pettycashexpense
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashexpense
     ON pettycashexpense
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pettycashincome --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashincome]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashincome] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
idinc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashincome PRIMARY KEY (idpettycash,
yoperation,
noperation,
idinc
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashincome' and id=object_id('pettycashincome'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashincome
     ON pettycashincome
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashincome
     ON pettycashincome
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashincome' and id=object_id('pettycashincome'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashincome
     ON pettycashincome
     (
     idpettycash, yoperation, noperation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashincome
     ON pettycashincome
     (
     idpettycash, yoperation, noperation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashincome' and id=object_id('pettycashincome'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashincome
     ON pettycashincome
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashincome
     ON pettycashincome
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pettycashoperation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperation] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
flag tinyint NOT NULL,
idaccmotive_cost varchar(36) NULL,
idaccmotive_debit varchar(36) NULL,
idexp int NULL,
idfin int NULL,
idman int NULL,
idreg int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
nlist int NULL,
nrestore int NULL,
rtf image NULL,
start datetime NULL,
stop datetime NULL,
txt text NULL,
yrestore smallint NULL,
 CONSTRAINT xpkpettycashoperation PRIMARY KEY (idpettycash,
yoperation,
noperation
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashoperation
     ON pettycashoperation
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashoperation
     ON pettycashoperation
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashoperation
     ON pettycashoperation
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashoperation
     ON pettycashoperation
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5pettycashoperation
     ON pettycashoperation
     (
     idpettycash, yrestore, nrestore     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5pettycashoperation
     ON pettycashoperation
     (
     idpettycash, yrestore, nrestore     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6pettycashoperation' and id=object_id('pettycashoperation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6pettycashoperation
     ON pettycashoperation
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6pettycashoperation
     ON pettycashoperation
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pettycashoperationcasualcontract --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationcasualcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationcasualcontract] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
ycon int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashoperationcasualcontract PRIMARY KEY (idpettycash,
yoperation,
noperation,
ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA pettycashoperationinvoice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationinvoice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationinvoice] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
idinvkind int NOT NULL,
yinv smallint NOT NULL,
ninv int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashoperationinvoice PRIMARY KEY (idpettycash,
yoperation,
noperation,
idinvkind,
yinv,
ninv
)
)
END
GO

-- CREAZIONE TABELLA pettycashoperationitineration --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationitineration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationitineration] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
iditineration int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind smallint NOT NULL,
 CONSTRAINT xpkpettycashoperationitineration PRIMARY KEY (idpettycash,
yoperation,
noperation,
iditineration
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashoperationitineration' and id=object_id('pettycashoperationitineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashoperationitineration
     ON pettycashoperationitineration
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashoperationitineration
     ON pettycashoperationitineration
     (
     iditineration     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pettycashoperationprofservice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationprofservice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationprofservice] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
ycon int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashoperationprofservice PRIMARY KEY (idpettycash,
yoperation,
noperation,
ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA pettycashoperationsorted --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationsorted]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationsorted] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
idsor int NOT NULL,
idsubclass int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
flagnodate char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
start datetime NULL,
stop datetime NULL,
tobecontinued char(1) NULL,
txt text NULL,
valuen1 decimal(23,6) NULL,
valuen2 decimal(23,6) NULL,
valuen3 decimal(23,6) NULL,
valuen4 decimal(23,6) NULL,
valuen5 decimal(23,6) NULL,
values1 varchar(20) NULL,
values2 varchar(20) NULL,
values3 varchar(20) NULL,
values4 varchar(20) NULL,
values5 varchar(20) NULL,
valuev1 decimal(23,6) NULL,
valuev2 decimal(23,6) NULL,
valuev3 decimal(23,6) NULL,
valuev4 decimal(23,6) NULL,
valuev5 decimal(23,6) NULL,
 CONSTRAINT xpkpettycashoperationsorted PRIMARY KEY (idpettycash,
yoperation,
noperation,
idsor,
idsubclass
)
)
END
GO

-- CREAZIONE TABELLA pettycashoperationunderwriting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashoperationunderwriting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashoperationunderwriting] (
idpettycash int NOT NULL,
yoperation smallint NOT NULL,
noperation int NOT NULL,
idunderwriting int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpettycashoperationunderwriting PRIMARY KEY (idpettycash,
yoperation,
noperation,
idunderwriting
)
)
END
GO

-- CREAZIONE TABELLA pettycashsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pettycashsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pettycashsetup] (
idpettycash int NOT NULL,
ayear smallint NOT NULL,
amount decimal(19,2) NULL,
autoclassify char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flag int NULL,
idacc varchar(38) NULL,
idfinexpense int NULL,
idfinincome int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
registrymanager int NULL,
 CONSTRAINT xpkpettycashsetup PRIMARY KEY (idpettycash,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashsetup
     ON pettycashsetup
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1pettycashsetup
     ON pettycashsetup
     (
     idpettycash     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashsetup
     ON pettycashsetup
     (
     idfinincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2pettycashsetup
     ON pettycashsetup
     (
     idfinincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashsetup
     ON pettycashsetup
     (
     idfinexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3pettycashsetup
     ON pettycashsetup
     (
     idfinexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4pettycashsetup' and id=object_id('pettycashsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4pettycashsetup
     ON pettycashsetup
     (
     registrymanager     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4pettycashsetup
     ON pettycashsetup
     (
     registrymanager     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA pinoaddizionali --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[pinoaddizionali]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [pinoaddizionali] (
aliquota decimal(19,6) NULL,
CODICE_CATASTALE nvarchar NULL,
COMUNE nvarchar NULL,
DATA_DELIBERA smalldatetime NULL,
DATA_PUBBLICAZIONE smalldatetime NULL,
idcity int NOT NULL,
NOTE nvarchar NULL,
NUMERO_DELIBERA nvarchar NULL,
PR nvarchar NULL,
rate decimal(19,6) NULL,
vecchia nvarchar NULL)
END
GO

-- CREAZIONE TABELLA prevfin --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[prevfin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [prevfin] (
ayear smallint NOT NULL,
nprevfin int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
official char(1) NULL,
previsiondate datetime NULL,
 CONSTRAINT xpkprevfin PRIMARY KEY (ayear,
nprevfin
)
)
END
GO

-- CREAZIONE TABELLA prevfindetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[prevfindetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [prevfindetail] (
ayear smallint NOT NULL,
nprevfin int NOT NULL,
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
availableprevision decimal(19,2) NULL,
cash decimal(19,2) NULL,
codefin varchar(50) NULL,
competency decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
floatfund decimal(19,2) NULL,
incometopartitioncash decimal(19,2) NULL,
incometopartitioncompetency decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
previousarrears decimal(19,2) NULL,
previousprevision decimal(19,2) NULL,
previoussecondaryprev decimal(19,2) NULL,
prevision2 decimal(19,2) NULL,
prevision3 decimal(19,2) NULL,
prevision4 decimal(19,2) NULL,
prevision5 decimal(19,2) NULL,
supposedcreditsurplus decimal(19,2) NULL,
supposedexpenditure decimal(19,2) NULL,
supposedfloatfund decimal(19,2) NULL,
supposedpayments decimal(19,2) NULL,
supposedproceeds decimal(19,2) NULL,
supposedrevenue decimal(19,2) NULL,
 CONSTRAINT xpkprevfindetail PRIMARY KEY (ayear,
nprevfin,
idupb,
idfin
)
)
END
GO

-- CREAZIONE TABELLA proceeds --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[proceeds]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [proceeds] (
kpro int NOT NULL,
adate smalldatetime NOT NULL,
annulmentdate datetime NULL,
ct datetime NULL,
cu varchar(64) NOT NULL,
flag tinyint NOT NULL,
idfin int NULL,
idman int NULL,
idreg int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idstamphandling int NULL,
idtreasurer int NULL,
kproceedstransmission int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
npro int NOT NULL,
printdate smalldatetime NULL,
rtf image NULL,
txt text NULL,
ypro smallint NOT NULL,
 CONSTRAINT xpkproceeds PRIMARY KEY (kpro
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukproceeds' and id=object_id('proceeds'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukproceeds
     ON proceeds
     (
     ypro, npro     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukproceeds
     ON proceeds
     (
     ypro, npro     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds
     ON proceeds
     (
     kproceedstransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds
     ON proceeds
     (
     kproceedstransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceeds
     ON proceeds
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceeds
     ON proceeds
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3proceeds
     ON proceeds
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3proceeds
     ON proceeds
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4proceeds
     ON proceeds
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4proceeds
     ON proceeds
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5proceeds
     ON proceeds
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5proceeds
     ON proceeds
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6proceeds' and id=object_id('proceeds'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6proceeds
     ON proceeds
     (
     ypro, npro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6proceeds
     ON proceeds
     (
     ypro, npro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA proceeds_bank --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[proceeds_bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [proceeds_bank] (
kpro int NOT NULL,
idpro int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
 CONSTRAINT xpkproceeds_bank PRIMARY KEY (kpro,
idpro
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds_bank' and id=object_id('proceeds_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA proceedspart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[proceedspart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [proceedspart] (
idinc int NOT NULL,
nproceedspart int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idfin int NOT NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
yproceedspart smallint NOT NULL,
 CONSTRAINT xpkproceedspart PRIMARY KEY (idinc,
nproceedspart
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedspart' and id=object_id('proceedspart'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceedspart
     ON proceedspart
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceedspart
     ON proceedspart
     (
     idinc     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedspart' and id=object_id('proceedspart'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceedspart
     ON proceedspart
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceedspart
     ON proceedspart
     (
     idfin     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA proceedstransmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[proceedstransmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [proceedstransmission] (
kproceedstransmission int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idman int NULL,
idtreasurer int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nproceedstransmission int NOT NULL,
transmissiondate smalldatetime NULL,
transmissionkind char(1) NULL,
yproceedstransmission smallint NOT NULL,
 CONSTRAINT xpkproceedstransmission PRIMARY KEY (kproceedstransmission
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukproceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukproceedstransmission
     ON proceedstransmission
     (
     yproceedstransmission, nproceedstransmission     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukproceedstransmission
     ON proceedstransmission
     (
     yproceedstransmission, nproceedstransmission     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceedstransmission
     ON proceedstransmission
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceedstransmission
     ON proceedstransmission
     (
     idman     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceedstransmission
     ON proceedstransmission
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2proceedstransmission
     ON proceedstransmission
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3proceedstransmission
     ON proceedstransmission
     (
     transmissiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3proceedstransmission
     ON proceedstransmission
     (
     transmissiondate     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4proceedstransmission' and id=object_id('proceedstransmission'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4proceedstransmission
     ON proceedstransmission
     (
     yproceedstransmission, nproceedstransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4proceedstransmission
     ON proceedstransmission
     (
     yproceedstransmission, nproceedstransmission     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA profrefund --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[profrefund]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [profrefund] (
idlinkedrefund varchar(20) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NULL,
flagfiscaldeduction char(1) NULL,
flagivadeduction char(1) NULL,
flagsecuritydeduction char(1) NULL,
idaccmotive varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprofrefund PRIMARY KEY (idlinkedrefund
)
)
END
GO

-- CREAZIONE TABELLA profservice --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[profservice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [profservice] (
ycon int NOT NULL,
ncon int NOT NULL,
adate datetime NOT NULL,
authdoc varchar(35) NULL,
authdocdate smalldatetime NULL,
authneeded char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
doc varchar(35) NULL,
docdate datetime NULL,
feegross decimal(19,2) NOT NULL,
flaginvoiced char(1) NULL,
flagmixed char(1) NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idinvkind int NULL,
idivakind int NULL,
idreg int NOT NULL,
idser int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
ivaamount decimal(19,2) NULL,
ivafieldnumber int NULL,
ivarate decimal(19,6) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ndays int NOT NULL,
ninv int NULL,
noauthreason varchar(1000) NULL,
pensioncontributionrate decimal(19,6) NULL,
rtf image NULL,
socialsecurityrate decimal(19,6) NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
totalcost decimal(19,2) NULL,
totalgross decimal(19,2) NULL,
txt text NULL,
yinv smallint NULL,
 CONSTRAINT xpkprofservice PRIMARY KEY (ycon,
ncon
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1profservice' and id=object_id('profservice'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1profservice
     ON profservice
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1profservice
     ON profservice
     (
     idivakind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA profservicerefund --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[profservicerefund]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [profservicerefund] (
ycon int NOT NULL,
ncon int NOT NULL,
nrefund int NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idlinkedrefund varchar(20) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprofservicerefund PRIMARY KEY (ycon,
ncon,
nrefund
)
)
END
GO

-- CREAZIONE TABELLA profservicesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[profservicesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [profservicesorting] (
ycon int NOT NULL,
idsor int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkprofservicesorting PRIMARY KEY (ycon,
idsor,
ncon
)
)
END
GO

-- CREAZIONE TABELLA profservicetax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[profservicetax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [profservicetax] (
ycon int NOT NULL,
ncon int NOT NULL,
taxcode int NOT NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deduction decimal(19,2) NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
employtaxgross decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxabledenominator decimal(19,6) NULL,
taxablegross decimal(19,2) NULL,
taxablenet decimal(19,2) NULL,
taxablenumerator decimal(19,6) NULL,
 CONSTRAINT xpkprofservicetax PRIMARY KEY (ycon,
ncon,
taxcode
)
)
END
GO

-- CREAZIONE TABELLA referencerule --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[referencerule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [referencerule] (
idreferencerule varchar(20) NOT NULL,
active char(1) NOT NULL,
ayear int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(100) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkreferencerule PRIMARY KEY (idreferencerule
)
)
END
GO

-- CREAZIONE TABELLA registrysorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[registrysorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [registrysorting] (
idsor int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkregistrysorting PRIMARY KEY (idsor,
idreg
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registrysorting' and id=object_id('registrysorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrysorting
     ON registrysorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registrysorting
     ON registrysorting
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2registrysorting' and id=object_id('registrysorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2registrysorting
     ON registrysorting
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2registrysorting
     ON registrysorting
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA report --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[report]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [report] (
reportname varchar(50) NOT NULL,
active char(1) NULL,
description varchar(80) NOT NULL,
filename varchar(100) NOT NULL,
flag_both char(1) NULL,
flag_cash char(1) NULL,
flag_comp char(1) NULL,
flag_credit char(1) NULL,
flag_proceeds char(1) NULL,
groupname varchar(80) NULL,
modulename varchar(80) NOT NULL,
orientation char(1) NOT NULL,
papersize varchar(20) NULL,
sp_doupdate varchar(255) NULL,
timeout int NULL,
webvisible char(1) NULL,
 CONSTRAINT xpkreport PRIMARY KEY (reportname
)
)
END
GO

-- CREAZIONE TABELLA reportadditionalparam --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[reportadditionalparam]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [reportadditionalparam] (
reportname varchar(50) NOT NULL,
paramname varchar(50) NOT NULL,
start datetime NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
paramvalue text NULL,
stop datetime NULL,
title varchar(240) NULL,
 CONSTRAINT xpkreportadditionalparam PRIMARY KEY (reportname,
paramname,
start
)
)
END
GO

-- CREAZIONE TABELLA reportparameter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[reportparameter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [reportparameter] (
reportname varchar(50) NOT NULL,
paramname varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
datasource varchar(50) NULL,
description varchar(50) NOT NULL,
displaymember varchar(50) NULL,
filter varchar(150) NULL,
help text NULL,
help2 text NULL,
hint varchar(400) NULL,
hintkind varchar(30) NULL,
iscombobox char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
noselectionforall char(1) NULL,
number smallint NOT NULL,
selectioncode varchar(512) NULL,
systype varchar(100) NULL,
tag varchar(100) NULL,
valuemember varchar(50) NULL,
 CONSTRAINT xpkreportparameter PRIMARY KEY (reportname,
paramname
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1reportparameter' and id=object_id('reportparameter'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1reportparameter
     ON reportparameter
     (
     reportname     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1reportparameter
     ON reportparameter
     (
     reportname     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA serviceagency --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[serviceagency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [serviceagency] (
pa_code varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
pa_cf varchar(16) NOT NULL,
pa_title varchar(80) NOT NULL,
 CONSTRAINT xpkserviceagency PRIMARY KEY (pa_code
)
)
END
GO

-- CREAZIONE TABELLA servicemotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[servicemotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [servicemotive] (
idmotive int NOT NULL,
active char(1) NULL,
ayear smallint NOT NULL,
description varchar(512) NOT NULL,
idmot varchar(20) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkservicemotive PRIMARY KEY (idmotive
)
)
END
GO

-- CREAZIONE TABELLA servicepayment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[servicepayment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [servicepayment] (
yservreg int NOT NULL,
nservreg int NOT NULL,
ypay int NOT NULL,
semesterpay int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
is_blocked char(1) NULL,
is_changed char(1) NULL,
is_delivered char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
payedamount decimal(19,2) NULL,
 CONSTRAINT xpkservicepayment PRIMARY KEY (yservreg,
nservreg,
ypay,
semesterpay
)
)
END
GO

-- CREAZIONE TABELLA serviceregistry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[serviceregistry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [serviceregistry] (
yservreg int NOT NULL,
nservreg int NOT NULL,
actreference varchar(200) NULL,
annotation varchar(500) NULL,
announcementlink varchar(200) NULL,
article varchar(50) NULL,
articlenumber varchar(50) NULL,
authorizationdate datetime NULL,
authorizinglink varchar(200) NULL,
authorizingstructure varchar(200) NULL,
birthdate datetime NULL,
cf varchar(16) NULL,
codcity varchar(20) NULL,
componentsvariable varchar(200) NULL,
conferring_birthdate datetime NULL,
conferring_codcity varchar(20) NULL,
conferring_flagforeign char(1) NULL,
conferring_forename varchar(60) NULL,
conferring_gender char(1) NULL,
conferring_idcity int NULL,
conferring_piva varchar(15) NULL,
conferring_surname varchar(60) NULL,
conferringstructure varchar(200) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
employkind char(1) NULL,
expectationsdate datetime NULL,
expectedamount decimal(19,2) NOT NULL,
flagforeign char(1) NULL,
flaghuman char(1) NULL,
forename varchar(60) NULL,
gender char(1) NULL,
id_service varchar(50) NULL,
idacquirekind varchar(20) NULL,
idapactivitykind varchar(20) NULL,
idapcontractkind varchar(20) NULL,
idapfinancialactivity int NULL,
idapmanager varchar(20) NULL,
idapregistrykind varchar(20) NULL,
idcity int NULL,
idconferring int NULL,
idconsultingkind varchar(20) NULL,
iddepartment int NULL,
idfinancialactivity varchar(20) NULL,
idreferencerule varchar(20) NULL,
idreg int NULL,
idrelated varchar(50) NULL,
idserviceregistrykind int NULL,
is_annulled char(1) NULL,
is_blocked char(1) NULL,
is_changed char(1) NULL,
is_delivered char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
officeduty char(1) NULL,
ordinancelink varchar(200) NULL,
otherservice varchar(200) NULL,
p_iva varchar(15) NULL,
pa_cf varchar(16) NULL,
pa_code varchar(50) NULL,
pa_title varchar(80) NULL,
paragraph varchar(50) NULL,
payment char(1) NULL,
professionalservice varchar(200) NULL,
referencedate datetime NULL,
referencerule varchar(500) NULL,
referencesemester int NULL,
regulation char(1) NULL,
rtf image NULL,
rulespecifics char(1) NULL,
senderreporting varchar(20) NULL,
servicevariation varchar(200) NULL,
start datetime NULL,
stop datetime NULL,
surname varchar(60) NULL,
title varchar(150) NULL,
txt text NULL,
ypay int NULL,
 CONSTRAINT xpkserviceregistry PRIMARY KEY (yservreg,
nservreg
)
)
END
GO

-- CREAZIONE TABELLA serviceregistrykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[serviceregistrykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [serviceregistrykind] (
idserviceregistrykind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
employkind char(1) NULL,
flagactreference smallint NULL,
flagannouncementlink smallint NULL,
flagauthorizinglink smallint NULL,
flagauthorizingstructure smallint NULL,
flagcomponentsvariable smallint NULL,
flagconferringstructure smallint NULL,
flagcvattachment smallint NULL,
flagordinancelink smallint NULL,
flagotherservice smallint NULL,
flagprofessionalservice smallint NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
topublish char(1) NOT NULL,
totransmit char(1) NOT NULL,
 CONSTRAINT xpkserviceregistrykind PRIMARY KEY (idserviceregistrykind
)
)
END
GO

-- CREAZIONE TABELLA servicesorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[servicesorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [servicesorting] (
idser int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpkservicesorting PRIMARY KEY (idser,
idsor
)
)
END
GO

-- CREAZIONE TABELLA servicetrasmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[servicetrasmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [servicetrasmission] (
idtrasmission int NOT NULL,
adate datetime NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
 CONSTRAINT xpkservicetrasmission PRIMARY KEY (idtrasmission
)
)
END
GO

-- CREAZIONE TABELLA showcase --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[showcase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [showcase] (
idshowcase int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(400) NOT NULL,
idstore int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkshowcase PRIMARY KEY (idshowcase
)
)
END
GO

-- CREAZIONE TABELLA showcasedetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[showcasedetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [showcasedetail] (
idshowcase int NOT NULL,
idlist int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkshowcasedetail PRIMARY KEY (idshowcase,
idlist
)
)
END
GO

-- CREAZIONE TABELLA sortedmovementtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortedmovementtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortedmovementtotal] (
idsor int NOT NULL,
ayear smallint NOT NULL,
totalcost decimal(19,2) NULL,
totalincome decimal(19,2) NULL,
totalmakings decimal(19,2) NULL,
totexpense decimal(19,2) NULL,
totexpensevariation decimal(19,2) NULL,
totincomevariation decimal(19,2) NULL,
 CONSTRAINT xpksortedmovementtotal PRIMARY KEY (idsor,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortedmovementtotal' and id=object_id('sortedmovementtotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortedmovementtotal
     ON sortedmovementtotal
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortedmovementtotal
     ON sortedmovementtotal
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sorting] (
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
defaultN1 decimal(23,6) NULL,
defaultN2 decimal(23,6) NULL,
defaultN3 decimal(23,6) NULL,
defaultN4 decimal(23,6) NULL,
defaultN5 decimal(23,6) NULL,
defaultS1 varchar(20) NULL,
defaultS2 varchar(20) NULL,
defaultS3 varchar(20) NULL,
defaultS4 varchar(20) NULL,
defaultS5 varchar(20) NULL,
defaultv1 decimal(23,6) NULL,
defaultv2 decimal(23,6) NULL,
defaultv3 decimal(23,6) NULL,
defaultv4 decimal(23,6) NULL,
defaultv5 decimal(23,6) NULL,
description varchar(200) NOT NULL,
email varchar(100) NULL,
flagnodate char(1) NULL,
idsorkind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
movkind char(1) NULL,
nlevel tinyint NOT NULL,
paridsor int NULL,
printingorder varchar(50) NULL,
rtf image NULL,
sortcode varchar(50) NOT NULL,
start smallint NULL,
stop smallint NULL,
txt text NULL,
 CONSTRAINT xpksorting PRIMARY KEY (idsor
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sorting' and id=object_id('sorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sorting
     ON sorting
     (
     idsorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sorting
     ON sorting
     (
     idsorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2sorting' and id=object_id('sorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2sorting
     ON sorting
     (
     paridsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2sorting
     ON sorting
     (
     paridsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3sorting' and id=object_id('sorting'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3sorting
     ON sorting
     (
     idsorkind, nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3sorting
     ON sorting
     (
     idsorkind, nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortingapplicability --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingapplicability]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingapplicability] (
idsorkind int NOT NULL,
tablename varchar(150) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpksortingapplicability PRIMARY KEY (idsorkind,
tablename
)
)
END
GO

-- CREAZIONE TABELLA sortingexpensefilter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingexpensefilter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingexpensefilter] (
ayear int NOT NULL,
idautosort int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idfin int NULL,
idman int NULL,
idsor int NOT NULL,
idsorkind int NOT NULL,
idsorkindreg int NULL,
idsorreg int NULL,
idupb varchar(36) NULL,
jointolessspecifics char(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpksortingexpensefilter PRIMARY KEY (ayear,
idautosort
)
)
END
GO

-- CREAZIONE TABELLA sortingexpensetotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingexpensetotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingexpensetotal] (
idsor int NOT NULL,
idacc varchar(38) NOT NULL,
total decimal(19,2) NULL,
 CONSTRAINT xpksortingexpensetotal PRIMARY KEY (idsor,
idacc
)
)
END
GO

-- CREAZIONE TABELLA sortingincomefilter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingincomefilter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingincomefilter] (
ayear int NOT NULL,
idautosort int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
idfin int NULL,
idman int NULL,
idsor int NOT NULL,
idsorkind int NOT NULL,
idsorkindreg int NULL,
idsorreg int NULL,
idupb varchar(36) NULL,
jointolessspecifics char(1) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpksortingincomefilter PRIMARY KEY (ayear,
idautosort
)
)
END
GO

-- CREAZIONE TABELLA sortingkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingkind] (
idsorkind int NOT NULL,
active char(1) NULL,
codesorkind varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
flagdate char(1) NULL,
forcedN1 char(1) NULL,
forcedN2 char(1) NULL,
forcedN3 char(1) NULL,
forcedN4 char(1) NULL,
forcedN5 char(1) NULL,
forcedS1 char(1) NULL,
forcedS2 char(1) NULL,
forcedS3 char(1) NULL,
forcedS4 char(1) NULL,
forcedS5 char(1) NULL,
forcedv1 char(1) NULL,
forcedv2 char(1) NULL,
forcedv3 char(1) NULL,
forcedv4 char(1) NULL,
forcedv5 char(1) NULL,
idparentkind int NULL,
labelfordate varchar(50) NULL,
labeln1 varchar(50) NULL,
labeln2 varchar(50) NULL,
labeln3 varchar(50) NULL,
labeln4 varchar(50) NULL,
labeln5 varchar(50) NULL,
labels1 varchar(50) NULL,
labels2 varchar(50) NULL,
labels3 varchar(50) NULL,
labels4 varchar(50) NULL,
labels5 varchar(50) NULL,
labelv1 varchar(50) NULL,
labelv2 varchar(50) NULL,
labelv3 varchar(50) NULL,
labelv4 varchar(50) NULL,
labelv5 varchar(50) NULL,
lockedN1 char(1) NULL,
lockedN2 char(1) NULL,
lockedN3 char(1) NULL,
lockedN4 char(1) NULL,
lockedN5 char(1) NULL,
lockedS1 char(1) NULL,
lockedS2 char(1) NULL,
lockedS3 char(1) NULL,
lockedS4 char(1) NULL,
lockedS5 char(1) NULL,
lockedv1 char(1) NULL,
lockedv2 char(1) NULL,
lockedv3 char(1) NULL,
lockedv4 char(1) NULL,
lockedv5 char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nodatelabel varchar(50) NULL,
nphaseexpense tinyint NULL,
nphaseincome tinyint NULL,
start smallint NULL,
stop smallint NULL,
totalexpression varchar(200) NULL,
 CONSTRAINT xpksortingkind PRIMARY KEY (idsorkind
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uksortingkind' and id=object_id('sortingkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uksortingkind
     ON sortingkind
     (
     codesorkind     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uksortingkind
     ON sortingkind
     (
     codesorkind     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_sortingkind' and id=object_id('sortingkind'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_sortingkind
     ON sortingkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_sortingkind
     ON sortingkind
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingkind' and id=object_id('sortingkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingkind
     ON sortingkind
     (
     nphaseincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingkind
     ON sortingkind
     (
     nphaseincome     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2sortingkind' and id=object_id('sortingkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2sortingkind
     ON sortingkind
     (
     nphaseexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2sortingkind
     ON sortingkind
     (
     nphaseexpense     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3sortingkind' and id=object_id('sortingkind'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3sortingkind
     ON sortingkind
     (
     codesorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3sortingkind
     ON sortingkind
     (
     codesorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortinglevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortinglevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortinglevel] (
idsorkind int NOT NULL,
nlevel tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag smallint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpksortinglevel PRIMARY KEY (idsorkind,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortinglevel' and id=object_id('sortinglevel'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortinglevel
     ON sortinglevel
     (
     idsorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortinglevel
     ON sortinglevel
     (
     idsorkind     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortinglink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortinglink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortinglink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpksortinglink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x2sortinglink' and id=object_id('sortinglink'))
BEGIN
     CREATE NONCLUSTERED INDEX x2sortinglink
     ON sortinglink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x2sortinglink
     ON sortinglink
     (
     idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x3sortinglink' and id=object_id('sortinglink'))
BEGIN
     CREATE NONCLUSTERED INDEX x3sortinglink
     ON sortinglink
     (
     idchild, idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x3sortinglink
     ON sortinglink
     (
     idchild, idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortingprev --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingprev]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingprev] (
idsor int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
expenseprevision decimal(19,2) NULL,
incomeprevision decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpksortingprev PRIMARY KEY (idsor,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprev' and id=object_id('sortingprev'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprev
     ON sortingprev
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprev
     ON sortingprev
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortingprevexpensevar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingprevexpensevar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingprevexpensevar] (
yvar smallint NOT NULL,
nvar int NOT NULL,
adate smalldatetime NULL,
amount decimal(19,2) NULL,
ayear smallint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
idsor int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpksortingprevexpensevar PRIMARY KEY (yvar,
nvar
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevexpensevar' and id=object_id('sortingprevexpensevar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar
     ON sortingprevexpensevar
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprevexpensevar
     ON sortingprevexpensevar
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortingprevincomevar --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingprevincomevar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingprevincomevar] (
yvar smallint NOT NULL,
nvar int NOT NULL,
adate smalldatetime NULL,
amount decimal(19,2) NULL,
ayear smallint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
idsor int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpksortingprevincomevar PRIMARY KEY (yvar,
nvar
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1sortingprevincomevar' and id=object_id('sortingprevincomevar'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprevincomevar
     ON sortingprevincomevar
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1sortingprevincomevar
     ON sortingprevincomevar
     (
     idsor     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA sortingtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingtotal] (
idacc varchar(38) NOT NULL,
idsor int NOT NULL,
currentprev decimal(19,2) NULL,
previousprev decimal(19,2) NULL,
previsionvariation decimal(19,2) NULL,
 CONSTRAINT xpksortingtotal PRIMARY KEY (idacc,
idsor
)
)
END
GO

-- CREAZIONE TABELLA sortingtranslation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortingtranslation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortingtranslation] (
idsortingchild int NOT NULL,
idsortingmaster int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
defaultN1 varchar(20) NULL,
defaultN2 varchar(20) NULL,
defaultN3 varchar(20) NULL,
defaultN4 varchar(20) NULL,
defaultN5 varchar(20) NULL,
defaultS1 varchar(20) NULL,
defaultS2 varchar(20) NULL,
defaultS3 varchar(20) NULL,
defaultS4 varchar(20) NULL,
defaultS5 varchar(20) NULL,
defaultv1 varchar(20) NULL,
defaultv2 varchar(20) NULL,
defaultv3 varchar(20) NULL,
defaultv4 varchar(20) NULL,
defaultv5 varchar(20) NULL,
denominator int NULL,
flagnodate char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numerator int NULL,
percentage decimal(23,6) NULL,
 CONSTRAINT xpksortingtranslation PRIMARY KEY (idsortingchild,
idsortingmaster
)
)
END
GO

-- CREAZIONE TABELLA sptocompile --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sptocompile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sptocompile] (
opkind char(1) NOT NULL,
tablename varchar(150) NOT NULL,
lt datetime NULL,
 CONSTRAINT xpksptocompile PRIMARY KEY (opkind,
tablename
)
)
END
GO

-- CREAZIONE TABELLA stock --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[stock]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [stock] (
idstock int NOT NULL,
adate datetime NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
expiry datetime NULL,
flagto_unload char(1) NULL,
idddt_in int NULL,
idinvkind int NULL,
idlist int NOT NULL,
idmankind varchar(20) NULL,
idstocklocation int NULL,
idstore int NOT NULL,
idstoreload_motive int NULL,
inv_idgroup int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
man_idgroup int NULL,
ninv int NULL,
nman int NULL,
number decimal(19,2) NOT NULL,
yinv smallint NULL,
yman smallint NULL,
 CONSTRAINT xpkstock PRIMARY KEY (idstock
)
)
END
GO

-- CREAZIONE TABELLA stocklocation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[stocklocation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [stocklocation] (
idstocklocation int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel tinyint NOT NULL,
paridstocklocation int NULL,
rtf image NULL,
stocklocationcode varchar(50) NOT NULL,
txt text NULL,
 CONSTRAINT xpkstocklocation PRIMARY KEY (idstocklocation
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_stocklocation' and id=object_id('stocklocation'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stocklocation
     ON stocklocation
     (
     stocklocationcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stocklocation
     ON stocklocation
     (
     stocklocationcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1stocklocation' and id=object_id('stocklocation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1stocklocation
     ON stocklocation
     (
     paridstocklocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1stocklocation
     ON stocklocation
     (
     paridstocklocation     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2stocklocation' and id=object_id('stocklocation'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2stocklocation
     ON stocklocation
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2stocklocation
     ON stocklocation
     (
     nlevel     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA stocklocationlevel --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[stocklocationlevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [stocklocationlevel] (
nlevel tinyint NOT NULL,
codelen tinyint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
flag tinyint NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkstocklocationlevel PRIMARY KEY (nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_stocklocationlevel' and id=object_id('stocklocationlevel'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stocklocationlevel
     ON stocklocationlevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_stocklocationlevel
     ON stocklocationlevel
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA stocklocationlink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[stocklocationlink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [stocklocationlink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkstocklocationlink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

-- CREAZIONE TABELLA stocktotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[stocktotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [stocktotal] (
idstore int NOT NULL,
idlist int NOT NULL,
booked decimal(19,2) NULL,
number decimal(19,2) NULL,
ordered decimal(19,2) NULL,
 CONSTRAINT xpkstocktotal PRIMARY KEY (idstore,
idlist
)
)
END
GO

-- CREAZIONE TABELLA store --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[store]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [store] (
idstore int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
deliveryaddress varchar(150) NOT NULL,
description varchar(50) NOT NULL,
email varchar(200) NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkstore PRIMARY KEY (idstore
)
)
END
GO

-- CREAZIONE TABELLA storeunload --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[storeunload]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [storeunload] (
idstoreunload int NOT NULL,
adate smalldatetime NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idddt_out int NULL,
idreg int NULL,
idstore int NULL,
idstoreunload_motive int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nstoreunload int NOT NULL,
rtf image NULL,
txt text NULL,
ystoreunload smallint NOT NULL,
 CONSTRAINT xpkstoreunload PRIMARY KEY (idstoreunload
)
)
END
GO

-- CREAZIONE TABELLA storeunloaddetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[storeunloaddetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [storeunloaddetail] (
idstoreunload int NOT NULL,
idstoreunloaddetail int NOT NULL,
ct datetime NULL,
cu varchar(64) NOT NULL,
idbooking int NULL,
idinvkind int NULL,
idman int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idstock int NOT NULL,
lt datetime NULL,
lu varchar(64) NOT NULL,
ninv int NULL,
number decimal(19,2) NOT NULL,
rownum int NULL,
yinv smallint NULL,
 CONSTRAINT xpkstoreunloaddetail PRIMARY KEY (idstoreunload,
idstoreunloaddetail
)
)
END
GO

-- CREAZIONE TABELLA surplus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[surplus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [surplus] (
ayear smallint NOT NULL,
competencypayments decimal(19,2) NULL,
competencyproceeds decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
currentexpenditure decimal(19,2) NULL,
currentrevenue decimal(19,2) NULL,
locked char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paymentstilldate decimal(19,2) NULL,
paymentstoendofyear decimal(19,2) NULL,
previousexpenditure decimal(19,2) NULL,
previousrevenue decimal(19,2) NULL,
previsiondate smalldatetime NULL,
proceedstilldate decimal(19,2) NULL,
proceedstoendofyear decimal(19,2) NULL,
residualpayments decimal(19,2) NULL,
residualproceeds decimal(19,2) NULL,
startfloatfund decimal(19,2) NULL,
supposedcurrentexpenditure decimal(19,2) NULL,
supposedcurrentrevenue decimal(19,2) NULL,
supposedpreviousexpenditure decimal(19,2) NULL,
supposedpreviousrevenue decimal(19,2) NULL,
 CONSTRAINT xpksurplus PRIMARY KEY (ayear
)
)
END
GO

-- CREAZIONE TABELLA taxpay --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxpay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxpay] (
taxcode int NOT NULL,
ytaxpay smallint NOT NULL,
ntaxpay int NOT NULL,
adate smalldatetime NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idf24ep int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
rtf image NULL,
start smalldatetime NOT NULL,
stop smalldatetime NOT NULL,
txt text NULL,
 CONSTRAINT xpktaxpay PRIMARY KEY (taxcode,
ytaxpay,
ntaxpay
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpay' and id=object_id('taxpay'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpay
     ON taxpay
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpay
     ON taxpay
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA taxpayexpense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxpayexpense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxpayexpense] (
taxcode int NOT NULL,
ytaxpay smallint NOT NULL,
ntaxpay int NOT NULL,
idexp int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktaxpayexpense PRIMARY KEY (taxcode,
ytaxpay,
ntaxpay,
idexp
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpayexpense' and id=object_id('taxpayexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpayexpense
     ON taxpayexpense
     (
     taxcode, ytaxpay, ntaxpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpayexpense
     ON taxpayexpense
     (
     taxcode, ytaxpay, ntaxpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2taxpayexpense' and id=object_id('taxpayexpense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxpayexpense
     ON taxpayexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxpayexpense
     ON taxpayexpense
     (
     idexp     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA taxpaymentpartsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxpaymentpartsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxpaymentpartsetup] (
ayear smallint NOT NULL,
taxcode int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentage decimal(19,8) NULL,
 CONSTRAINT xpktaxpaymentpartsetup PRIMARY KEY (ayear,
taxcode,
idreg
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxpaymentpartsetup' and id=object_id('taxpaymentpartsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpaymentpartsetup
     ON taxpaymentpartsetup
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxpaymentpartsetup
     ON taxpaymentpartsetup
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2taxpaymentpartsetup' and id=object_id('taxpaymentpartsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxpaymentpartsetup
     ON taxpaymentpartsetup
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxpaymentpartsetup
     ON taxpaymentpartsetup
     (
     idreg     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA taxratecitybracket2 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxratecitybracket2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxratecitybracket2] (
idcity int NOT NULL,
idtaxratecitystart int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NULL,
maxamount decimal(19,8) NULL,
minamount decimal(19,8) NULL,
nbracket int NOT NULL,
rate decimal(19,6) NOT NULL,
taxcode varchar(20) NOT NULL)
END
GO

-- CREAZIONE TABELLA taxratecitystart2 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxratecitystart2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxratecitystart2] (
annotations varchar(400) NULL,
enforcement char(1) NULL,
idcity int NOT NULL,
idtaxratecitystart int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NOT NULL,
taxcode varchar(20) NOT NULL)
END
GO

-- CREAZIONE TABELLA taxregionsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxregionsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxregionsetup] (
ayear smallint NOT NULL,
taxcode int NOT NULL,
autoid int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idplace int NULL,
kind char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
regionalagency int NULL,
 CONSTRAINT xpktaxregionsetup PRIMARY KEY (ayear,
taxcode,
autoid
)
)
END
GO

-- CREAZIONE TABELLA taxsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxsetup] (
taxcode int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
expiringday smallint NULL,
flag tinyint NOT NULL,
flagadminfinance char(1) NOT NULL,
idexpirationkind smallint NULL,
idfinadmintax int NULL,
idfinexpensecontra int NULL,
idfinexpenseemploy int NULL,
idfinincomecontra int NULL,
idfinincomeemploy int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paymentagency int NULL,
rtf image NULL,
taxpaykind char(1) NULL,
txt text NULL,
 CONSTRAINT xpktaxsetup PRIMARY KEY (taxcode,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1taxsetup' and id=object_id('taxsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxsetup
     ON taxsetup
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1taxsetup
     ON taxsetup
     (
     taxcode     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2taxsetup' and id=object_id('taxsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxsetup
     ON taxsetup
     (
     paymentagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2taxsetup
     ON taxsetup
     (
     paymentagency     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3taxsetup' and id=object_id('taxsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3taxsetup
     ON taxsetup
     (
     idfinexpensecontra     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3taxsetup
     ON taxsetup
     (
     idfinexpensecontra     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4taxsetup' and id=object_id('taxsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4taxsetup
     ON taxsetup
     (
     idfinincomecontra     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4taxsetup
     ON taxsetup
     (
     idfinincomecontra     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5taxsetup' and id=object_id('taxsetup'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5taxsetup
     ON taxsetup
     (
     idfinadmintax     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5taxsetup
     ON taxsetup
     (
     idfinadmintax     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA taxsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxsorting] (
taxcode int NOT NULL,
idsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpktaxsorting PRIMARY KEY (taxcode,
idsor
)
)
END
GO

-- CREAZIONE TABELLA taxsortingsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[taxsortingsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [taxsortingsetup] (
ayear smallint NOT NULL,
idautotaxsor int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
flaginherit char(1) NULL,
idser int NULL,
idsor_adminpay int NULL,
idsor_adminproc int NULL,
idsor_employproc int NULL,
idsor_taxpay int NULL,
idsorkind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxcode int NOT NULL,
 CONSTRAINT xpktaxsortingsetup PRIMARY KEY (ayear,
idautotaxsor
)
)
END
GO

-- CREAZIONE TABELLA trasmissiondocument --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[trasmissiondocument]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [trasmissiondocument] (
idtrasmissiondocument varchar(20) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktrasmissiondocument PRIMARY KEY (idtrasmissiondocument
)
)
END
GO

-- CREAZIONE TABELLA trasmissionmanager --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[trasmissionmanager]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [trasmissionmanager] (
idtrasmissiondocument varchar(20) NOT NULL,
ayear int NOT NULL,
annotations varchar(400) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(60) NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktrasmissionmanager PRIMARY KEY (idtrasmissiondocument,
ayear
)
)
END
GO

-- CREAZIONE TABELLA treasurer --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[treasurer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [treasurer] (
idtreasurer int NOT NULL,
active char(1) NULL,
address varchar(100) NULL,
agencycodefortransmission varchar(20) NULL,
annotations varchar(1000) NULL,
bic varchar(15) NULL,
billcode varchar(50) NULL,
cabcodefortransmission varchar(20) NULL,
cap varchar(20) NULL,
cc varchar(30) NULL,
cccbi varchar(30) NULL,
cin varchar(20) NULL,
cincbi varchar(20) NULL,
city varchar(50) NULL,
codetreasurer varchar(20) NOT NULL,
country varchar(2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
depcodefortransmission varchar(20) NULL,
description varchar(150) NULL,
faxnumber varchar(50) NULL,
faxprefix varchar(20) NULL,
fileextension varchar(10) NULL,
flag int NULL,
flagbank_grouping int NULL,
flagdefault char(1) NOT NULL,
flagedisp char(1) NULL,
flagfruitful char(1) NULL,
flagmultiexp char(1) NULL,
iban varchar(50) NULL,
ibancbi varchar(50) NULL,
idaccmotive_payment varchar(36) NULL,
idaccmotive_proceeds varchar(36) NULL,
idbank varchar(20) NULL,
idbankcbi varchar(20) NULL,
idcab varchar(20) NULL,
idcabcbi varchar(20) NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motivelen smallint NULL,
motiveprefix varchar(20) NULL,
motiveseparator char(1) NULL,
phonenumber varchar(30) NULL,
phoneprefix varchar(20) NULL,
reccbikind varchar(2) NULL,
siacodecbi varchar(5) NULL,
spexportexp varchar(50) NULL,
spexportinc varchar(50) NULL,
trasmcode varchar(7) NULL,
 CONSTRAINT xpktreasurer PRIMARY KEY (idtreasurer
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='uktreasurer' and id=object_id('treasurer'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktreasurer
     ON treasurer
     (
     codetreasurer     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uktreasurer
     ON treasurer
     (
     codetreasurer     
)
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1treasurer' and id=object_id('treasurer'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1treasurer
     ON treasurer
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1treasurer
     ON treasurer
     (
     idbank, idcab     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2treasurer' and id=object_id('treasurer'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2treasurer
     ON treasurer
     (
     codetreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2treasurer
     ON treasurer
     (
     codetreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA treasurercashtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[treasurercashtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [treasurercashtotal] (
ayear int NOT NULL,
idtreasurer int NOT NULL,
currentfloatfund decimal(19,2) NULL,
 CONSTRAINT xpktreasurercashtotal PRIMARY KEY (ayear,
idtreasurer
)
)
END
GO

-- CREAZIONE TABELLA treasurerstart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[treasurerstart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [treasurerstart] (
idtreasurer int NOT NULL,
ayear smallint NOT NULL,
amount decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpktreasurerstart PRIMARY KEY (idtreasurer,
ayear
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1treasurerstart' and id=object_id('treasurerstart'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1treasurerstart
     ON treasurerstart
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1treasurerstart
     ON treasurerstart
     (
     idtreasurer     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA underwriter --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwriter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwriter] (
idunderwriter int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(50) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkunderwriter PRIMARY KEY (idunderwriter
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_underwriter' and id=object_id('underwriter'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_underwriter
     ON underwriter
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_underwriter
     ON underwriter
     (
     description     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA underwriting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwriting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwriting] (
idunderwriting int NOT NULL,
active char(1) NULL,
codeunderwriting varchar(50) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
doc varchar(35) NULL,
docdate smalldatetime NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idunderwriter int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(150) NOT NULL,
 CONSTRAINT xpkunderwriting PRIMARY KEY (idunderwriting
)
)
END
GO

-- CREAZIONE TABELLA underwritingappropriation --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwritingappropriation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwritingappropriation] (
idunderwriting int NOT NULL,
idexp int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkunderwritingappropriation PRIMARY KEY (idunderwriting,
idexp
)
)
END
GO

-- CREAZIONE TABELLA underwritingexpensetotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwritingexpensetotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwritingexpensetotal] (
idunderwriting int NOT NULL,
nphase tinyint NOT NULL,
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
totalarrears decimal(19,2) NULL,
totalcompetency decimal(19,2) NULL,
 CONSTRAINT xpkunderwritingexpensetotal PRIMARY KEY (idunderwriting,
nphase,
idupb,
idfin
)
)
END
GO

-- CREAZIONE TABELLA underwritingincometotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwritingincometotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwritingincometotal] (
idunderwriting int NOT NULL,
nphase tinyint NOT NULL,
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
totalarrears decimal(19,2) NULL,
totalcompetency decimal(19,2) NULL,
 CONSTRAINT xpkunderwritingincometotal PRIMARY KEY (idunderwriting,
nphase,
idupb,
idfin
)
)
END
GO

-- CREAZIONE TABELLA underwritingpayment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwritingpayment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwritingpayment] (
idunderwriting int NOT NULL,
idexp int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkunderwritingpayment PRIMARY KEY (idunderwriting,
idexp
)
)
END
GO

-- CREAZIONE TABELLA underwritingyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[underwritingyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [underwritingyear] (
idunderwriting int NOT NULL,
ayear smallint NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
prevision decimal(19,2) NULL,
prevision2 decimal(19,2) NULL,
prevision3 decimal(19,2) NULL,
prevision4 decimal(19,2) NULL,
prevision5 decimal(19,2) NULL,
 CONSTRAINT xpkunderwritingyear PRIMARY KEY (idunderwriting,
ayear
)
)
END
GO

-- CREAZIONE TABELLA uniconfig --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[uniconfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [uniconfig] (
dummykey int NOT NULL,
expensefinphase tinyint NULL,
expenseregphase tinyint NULL,
flag int NULL,
flagresearchagency char(1) NOT NULL,
idsorkind01 int NULL,
idsorkind02 int NULL,
idsorkind03 int NULL,
idsorkind04 int NULL,
idsorkind05 int NULL,
incomefinphase tinyint NULL,
incomeregphase tinyint NULL,
sorkind01asfilter char(1) NULL,
sorkind02asfilter char(1) NULL,
sorkind03asfilter char(1) NULL,
sorkind04asfilter char(1) NULL,
sorkind05asfilter char(1) NULL,
tree_upb_withdescr char(1) NULL,
 CONSTRAINT xpkuniconfig PRIMARY KEY (dummykey
)
)
END
GO

-- CREAZIONE TABELLA unifiedivapay --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[unifiedivapay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [unifiedivapay] (
yunifiedivapay int NOT NULL,
nunifiedivapay int NOT NULL,
iddepartment int NOT NULL,
assesmentdate datetime NULL,
creditamount decimal(19,2) NULL,
creditamountdeferred decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
dateivapay datetime NULL,
debitamount decimal(19,2) NULL,
debitamountdeferred decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
paymentamount decimal(19,2) NULL,
paymentdetails varchar(150) NULL,
paymentkind char(1) NOT NULL,
prorata decimal(19,6) NULL,
refundamount decimal(19,2) NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
 CONSTRAINT xpkunifiedivapay PRIMARY KEY (yunifiedivapay,
nunifiedivapay,
iddepartment
)
)
END
GO

-- CREAZIONE TABELLA unifiedivapaydetail --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[unifiedivapaydetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [unifiedivapaydetail] (
yunifiedivapay int NOT NULL,
nunifiedivapay int NOT NULL,
idivaregisterkindunified varchar(20) NOT NULL,
iddepartment int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iva decimal(19,2) NULL,
ivadeferred decimal(19,2) NULL,
ivanet decimal(19,2) NULL,
ivanetdeferred decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mixed decimal(19,6) NULL,
prorata decimal(19,6) NULL,
unabatable decimal(19,2) NULL,
unabatabledeferred decimal(19,2) NULL,
 CONSTRAINT xpkunifiedivapaydetail PRIMARY KEY (yunifiedivapay,
nunifiedivapay,
idivaregisterkindunified,
iddepartment
)
)
END
GO

-- CREAZIONE TABELLA upb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upb] (
idupb varchar(36) NOT NULL,
active char(1) NULL,
assured char(1) NULL,
codeupb varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
expiration datetime NULL,
flagactivity smallint NULL,
flagkind tinyint NULL,
granted decimal(19,2) NULL,
idman int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idtreasurer int NULL,
idunderwriter int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
newcodeupb varchar(50) NULL,
paridupb varchar(36) NULL,
previousappropriation decimal(19,2) NULL,
previousassessment decimal(19,2) NULL,
printingorder varchar(50) NOT NULL,
requested decimal(19,2) NULL,
rtf image NULL,
title varchar(150) NOT NULL,
txt text NULL,
 CONSTRAINT xpkupb PRIMARY KEY (idupb
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1upb' and id=object_id('upb'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1upb
     ON upb
     (
     paridupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1upb
     ON upb
     (
     paridupb     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA upbexpensetotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upbexpensetotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upbexpensetotal] (
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
nphase tinyint NOT NULL,
totalarrears decimal(19,2) NULL,
totalcompetency decimal(19,2) NULL,
 CONSTRAINT xpkupbexpensetotal PRIMARY KEY (idupb,
idfin,
nphase
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1upbexpensetotal' and id=object_id('upbexpensetotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbexpensetotal
     ON upbexpensetotal
     (
     idfin, nphase     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbexpensetotal
     ON upbexpensetotal
     (
     idfin, nphase     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA upbincometotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upbincometotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upbincometotal] (
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
nphase tinyint NOT NULL,
totalarrears decimal(19,2) NULL,
totalcompetency decimal(19,2) NULL,
 CONSTRAINT xpkupbincometotal PRIMARY KEY (idupb,
idfin,
nphase
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1upbincometotal' and id=object_id('upbincometotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbincometotal
     ON upbincometotal
     (
     idfin, nphase     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbincometotal
     ON upbincometotal
     (
     idfin, nphase     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA upbsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upbsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upbsorting] (
idsor int NOT NULL,
idupb varchar(36) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota decimal(19,6) NULL,
 CONSTRAINT xpkupbsorting PRIMARY KEY (idsor,
idupb
)
)
END
GO

-- CREAZIONE TABELLA upbtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upbtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upbtotal] (
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
creditvariation decimal(19,2) NULL,
currentarrears decimal(19,2) NULL,
currentprev decimal(19,2) NULL,
currentsecondaryprev decimal(19,2) NULL,
previousarrears decimal(19,2) NULL,
previousprev decimal(19,2) NULL,
previoussecondaryprev decimal(19,2) NULL,
previsionvariation decimal(19,2) NULL,
proceedsvariation decimal(19,2) NULL,
secondaryvariation decimal(19,2) NULL,
totcreditpart decimal(19,2) NULL,
totproceedspart decimal(19,2) NULL,
 CONSTRAINT xpkupbtotal PRIMARY KEY (idupb,
idfin
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1upbtotal' and id=object_id('upbtotal'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbtotal
     ON upbtotal
     (
     idfin     
)
 WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1upbtotal
     ON upbtotal
     (
     idfin     
)
ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA upbunderwritingtotal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[upbunderwritingtotal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [upbunderwritingtotal] (
idupb varchar(36) NOT NULL,
idfin int NOT NULL,
idunderwriting int NOT NULL,
creditvariation decimal(19,2) NULL,
currentprev decimal(19,2) NULL,
currentsecondaryprev decimal(19,2) NULL,
previsionvariation decimal(19,2) NULL,
proceedsvariation decimal(19,2) NULL,
secondaryvariation decimal(19,2) NULL,
totcreditpart decimal(19,2) NULL,
totproceedspart decimal(19,2) NULL,
 CONSTRAINT xpkupbunderwritingtotal PRIMARY KEY (idupb,
idfin,
idunderwriting
)
)
END
GO

-- CREAZIONE TABELLA updatedbmenu --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[updatedbmenu]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [updatedbmenu] (
versionname varchar(20) NOT NULL,
 CONSTRAINT xpkupdatedbmenu PRIMARY KEY (versionname
)
)
END
GO

-- CREAZIONE TABELLA updatedbscript --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[updatedbscript]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [updatedbscript] (
scriptname varchar(50) NOT NULL,
versionname varchar(10) NOT NULL,
result varchar(1000) NULL,
sql text NULL,
 CONSTRAINT xpkupdatedbscript PRIMARY KEY (scriptname,
versionname
)
)
END
GO

-- CREAZIONE TABELLA updatedbversion --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[updatedbversion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [updatedbversion] (
versionname varchar(10) NOT NULL,
description varchar(1000) NULL,
flagadmin char(1) NULL,
flagerror char(1) NULL,
scriptlist varchar(300) NULL,
swversion varchar(10) NULL,
 CONSTRAINT xpkupdatedbversion PRIMARY KEY (versionname
)
)
END
GO

-- CREAZIONE TABELLA userenvironment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[userenvironment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [userenvironment] (
idcustomuser varchar(50) NOT NULL,
variablename varchar(50) NOT NULL,
flagadmin char(1) NULL,
kind char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
value text NULL,
 CONSTRAINT xpkuserenvironment PRIMARY KEY (idcustomuser,
variablename
)
)
END
GO

-- CREAZIONE TABELLA viewcolumn --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[viewcolumn]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [viewcolumn] (
colname varchar(80) NOT NULL,
objectname varchar(80) NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
realcolumn varchar(80) NOT NULL,
realtable varchar(80) NOT NULL,
 CONSTRAINT xpkviewcolumn PRIMARY KEY (colname,
objectname
)
)
END
GO

-- CREAZIONE TABELLA wageaddition --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[wageaddition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [wageaddition] (
ycon int NOT NULL,
ncon int NOT NULL,
adate datetime NOT NULL,
authdoc varchar(35) NULL,
authdocdate smalldatetime NULL,
authneeded char(1) NULL,
completed char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
feegross decimal(19,2) NOT NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg datetime NULL,
idreg int NOT NULL,
idreg_distrained int NULL,
idregistrylegalstatus int NULL,
idser int NOT NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ndays int NOT NULL,
noauthreason varchar(1000) NULL,
rtf image NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
txt text NULL,
 CONSTRAINT xpkwageaddition PRIMARY KEY (ycon,
ncon
)
)
END
GO

-- CREAZIONE TABELLA wageadditionsorting --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[wageadditionsorting]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [wageadditionsorting] (
ycon int NOT NULL,
idsor int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
quota float NULL,
 CONSTRAINT xpkwageadditionsorting PRIMARY KEY (ycon,
idsor,
ncon
)
)
END
GO

-- CREAZIONE TABELLA wageadditiontax --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[wageadditiontax]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [wageadditiontax] (
ycon int NOT NULL,
ncon int NOT NULL,
taxcode int NOT NULL,
admindenominator decimal(19,6) NULL,
adminnumerator decimal(19,6) NULL,
adminrate decimal(19,6) NULL,
admintax decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
employdenominator decimal(19,6) NULL,
employnumerator decimal(19,6) NULL,
employrate decimal(19,6) NULL,
employtax decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
taxable decimal(19,2) NULL,
taxabledenominator decimal(19,6) NULL,
taxablenumerator decimal(19,6) NULL,
 CONSTRAINT xpkwageadditiontax PRIMARY KEY (ycon,
ncon,
taxcode
)
)
END
GO

-- CREAZIONE TABELLA wageadditionyear --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[wageadditionyear]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [wageadditionyear] (
ycon int NOT NULL,
ayear int NOT NULL,
ncon int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcontractlength varchar(5) NULL,
idposition varchar(5) NULL,
idworkingtime varchar(5) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkwageadditionyear PRIMARY KEY (ycon,
ayear,
ncon
)
)
END
GO

-- CREAZIONE TABELLA wageimportsetup --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[wageimportsetup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [wageimportsetup] (
idwageimportsetup int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsorkind_accmotivegroup1 int NULL,
idsorkind_accmotivegroup2 int NULL,
idsorkind_clawback int NULL,
idsorkind_fin int NULL,
idsorkind_registry int NULL,
idsorkind_service int NULL,
idsorkind_sortingchild1 int NULL,
idsorkind_sortingchild2 int NULL,
idsorkind_sortingchild3 int NULL,
idsorkind_sortingchild4 int NULL,
idsorkind_sortingchild5 int NULL,
idsorkind_sortingmaster1 int NULL,
idsorkind_sortingmaster2 int NULL,
idsorkind_sortingmaster3 int NULL,
idsorkind_sortingmaster4 int NULL,
idsorkind_sortingmaster5 int NULL,
idsorkind_tax int NULL,
idsorkind_upb int NULL,
kind char(1) NULL,
listfield varchar(300) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkwageimportsetup PRIMARY KEY (idwageimportsetup
)
)
END
GO

