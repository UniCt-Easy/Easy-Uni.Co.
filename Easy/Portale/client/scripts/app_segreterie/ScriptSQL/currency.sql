
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

-- VERIFICA STRUTTURA currency --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD idcurrency int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'idcurrency' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'codecurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD codecurrency varchar(20) NULL 
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN codecurrency varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD description varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN description varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'currency' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [currency] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('currency') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [currency] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [currency] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukcurrency' and id=object_id('currency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukcurrency
     ON currency (codecurrency )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukcurrency
     ON currency (codecurrency )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_currency' and id=object_id('currency'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_currency
     ON currency (description )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_currency
     ON currency (description )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1currency' and id=object_id('currency'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1currency
     ON currency (codecurrency )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1currency
     ON currency (codecurrency )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI currency IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'currency'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','int','NINO','idcurrency','4','S','int','System.Int32','','','''NINO''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','currency','varchar(20)','NINO','codecurrency','20','N','varchar','System.String','','','''NINO''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','datetime','SA','ct','8','S','datetime','System.DateTime','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','varchar(64)','SA','cu','64','S','varchar','System.String','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','varchar(50)','SA','description','50','S','varchar','System.String','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','datetime','SA','lt','8','S','datetime','System.DateTime','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','currency','varchar(64)','SA','lu','64','S','varchar','System.String','','','''SA''','','N')
GO

-- VERIFICA DI currency IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'currency')
UPDATE customobject set isreal = 'S' where objectname = 'currency'
ELSE
INSERT INTO customobject (objectname, isreal) values('currency', 'S')
GO

-- GENERAZIONE DATI PER currency --
IF exists(SELECT * FROM [currency] WHERE idcurrency = '1')
UPDATE [currency] SET codecurrency = 'DKK',ct = {ts '1999-06-13 19:50:26.710'},cu = 'Configurazione',description = 'Corona danese',lt = {ts '1999-06-13 19:50:26.710'},lu = 'Configurazione' WHERE idcurrency = '1'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('1','DKK',{ts '1999-06-13 19:50:26.710'},'Configurazione','Corona danese',{ts '1999-06-13 19:50:26.710'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '2')
UPDATE [currency] SET codecurrency = 'NOK',ct = {ts '1999-06-13 19:50:26.970'},cu = 'Configurazione',description = 'Corona norvegese',lt = {ts '1999-06-13 19:50:26.970'},lu = 'Configurazione' WHERE idcurrency = '2'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('2','NOK',{ts '1999-06-13 19:50:26.970'},'Configurazione','Corona norvegese',{ts '1999-06-13 19:50:26.970'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '3')
UPDATE [currency] SET codecurrency = 'SEK',ct = {ts '1999-06-13 19:50:27.040'},cu = 'Configurazione',description = 'Corona svedese',lt = {ts '1999-06-13 19:50:27.040'},lu = 'Configurazione' WHERE idcurrency = '3'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('3','SEK',{ts '1999-06-13 19:50:27.040'},'Configurazione','Corona svedese',{ts '1999-06-13 19:50:27.040'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '4')
UPDATE [currency] SET codecurrency = 'AUD',ct = {ts '1999-06-13 19:50:26.600'},cu = 'Configurazione',description = 'Dollaro australiano',lt = {ts '1999-06-13 19:50:26.600'},lu = 'Configurazione' WHERE idcurrency = '4'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('4','AUD',{ts '1999-06-13 19:50:26.600'},'Configurazione','Dollaro australiano',{ts '1999-06-13 19:50:26.600'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '5')
UPDATE [currency] SET codecurrency = 'CAD',ct = {ts '1999-06-13 19:50:26.650'},cu = 'Configurazione',description = 'Dollaro canadese',lt = {ts '1999-06-13 19:50:26.650'},lu = 'Configurazione' WHERE idcurrency = '5'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('5','CAD',{ts '1999-06-13 19:50:26.650'},'Configurazione','Dollaro canadese',{ts '1999-06-13 19:50:26.650'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '6')
UPDATE [currency] SET codecurrency = 'NZD',ct = {ts '1999-06-13 19:50:27.000'},cu = 'Configurazione',description = 'Dollaro neozelandese',lt = {ts '1999-06-13 19:50:27.000'},lu = 'Configurazione' WHERE idcurrency = '6'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('6','NZD',{ts '1999-06-13 19:50:27.000'},'Configurazione','Dollaro neozelandese',{ts '1999-06-13 19:50:27.000'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '7')
UPDATE [currency] SET codecurrency = 'USD',ct = {ts '1999-06-13 19:50:27.100'},cu = 'Configurazione',description = 'Dollaro statunitense',lt = {ts '1999-06-13 19:50:27.110'},lu = 'Configurazione' WHERE idcurrency = '7'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('7','USD',{ts '1999-06-13 19:50:27.100'},'Configurazione','Dollaro statunitense',{ts '1999-06-13 19:50:27.110'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '8')
UPDATE [currency] SET codecurrency = 'GRD',ct = {ts '1999-06-13 19:50:26.840'},cu = 'Configurazione',description = 'Dracma greca',lt = {ts '1999-06-13 19:50:26.840'},lu = 'Configurazione' WHERE idcurrency = '8'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('8','GRD',{ts '1999-06-13 19:50:26.840'},'Configurazione','Dracma greca',{ts '1999-06-13 19:50:26.840'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '9')
UPDATE [currency] SET codecurrency = 'EUR',ct = {ts '1999-06-13 19:50:26.740'},cu = 'Configurazione',description = 'Euro',lt = {ts '1999-06-13 19:50:26.750'},lu = 'Configurazione' WHERE idcurrency = '9'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('9','EUR',{ts '1999-06-13 19:50:26.740'},'Configurazione','Euro',{ts '1999-06-13 19:50:26.750'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '10')
UPDATE [currency] SET codecurrency = 'NLG',ct = {ts '1999-06-13 19:50:26.950'},cu = 'Configurazione',description = 'Fiorino olandese',lt = {ts '1999-06-13 19:50:26.950'},lu = 'Configurazione' WHERE idcurrency = '10'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('10','NLG',{ts '1999-06-13 19:50:26.950'},'Configurazione','Fiorino olandese',{ts '1999-06-13 19:50:26.950'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '11')
UPDATE [currency] SET codecurrency = 'BEF',ct = {ts '1999-06-13 19:50:26.620'},cu = 'Configurazione',description = 'Franco belga',lt = {ts '1999-06-13 19:50:26.630'},lu = 'Configurazione' WHERE idcurrency = '11'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('11','BEF',{ts '1999-06-13 19:50:26.620'},'Configurazione','Franco belga',{ts '1999-06-13 19:50:26.630'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '12')
UPDATE [currency] SET codecurrency = 'FRF',ct = {ts '1999-06-13 19:50:26.790'},cu = 'Configurazione',description = 'Franco francese',lt = {ts '1999-06-13 19:50:26.790'},lu = 'Configurazione' WHERE idcurrency = '12'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('12','FRF',{ts '1999-06-13 19:50:26.790'},'Configurazione','Franco francese',{ts '1999-06-13 19:50:26.790'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '13')
UPDATE [currency] SET codecurrency = 'LUF',ct = {ts '1999-06-13 19:50:26.930'},cu = 'Configurazione',description = 'Franco lussemburghese',lt = {ts '1999-06-13 19:50:26.930'},lu = 'Configurazione' WHERE idcurrency = '13'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('13','LUF',{ts '1999-06-13 19:50:26.930'},'Configurazione','Franco lussemburghese',{ts '1999-06-13 19:50:26.930'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '14')
UPDATE [currency] SET codecurrency = 'CHF',ct = {ts '1999-06-13 19:50:26.670'},cu = 'Configurazione',description = 'Franco svizzero',lt = {ts '1999-06-13 19:50:26.670'},lu = 'Configurazione' WHERE idcurrency = '14'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('14','CHF',{ts '1999-06-13 19:50:26.670'},'Configurazione','Franco svizzero',{ts '1999-06-13 19:50:26.670'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '15')
UPDATE [currency] SET codecurrency = 'IEP',ct = {ts '1999-06-13 19:50:26.860'},cu = 'Configurazione',description = 'Lira irlandese',lt = {ts '1999-06-13 19:50:26.860'},lu = 'Configurazione' WHERE idcurrency = '15'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('15','IEP',{ts '1999-06-13 19:50:26.860'},'Configurazione','Lira irlandese',{ts '1999-06-13 19:50:26.860'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '16')
UPDATE [currency] SET codecurrency = 'ITL',ct = {ts '1999-06-13 19:50:26.880'},cu = 'Configurazione',description = 'Lira italiana',lt = {ts '1999-06-13 19:50:26.890'},lu = 'Configurazione' WHERE idcurrency = '16'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('16','ITL',{ts '1999-06-13 19:50:26.880'},'Configurazione','Lira italiana',{ts '1999-06-13 19:50:26.890'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '17')
UPDATE [currency] SET codecurrency = 'TRL',ct = {ts '1999-06-13 19:50:27.080'},cu = 'Configurazione',description = 'Lira turca',lt = {ts '1999-06-13 19:50:27.080'},lu = 'Configurazione' WHERE idcurrency = '17'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('17','TRL',{ts '1999-06-13 19:50:27.080'},'Configurazione','Lira turca',{ts '1999-06-13 19:50:27.080'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '18')
UPDATE [currency] SET codecurrency = 'FIM',ct = {ts '1999-06-13 19:50:26.770'},cu = 'Configurazione',description = 'Marco finlandese',lt = {ts '1999-06-13 19:50:26.770'},lu = 'Configurazione' WHERE idcurrency = '18'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('18','FIM',{ts '1999-06-13 19:50:26.770'},'Configurazione','Marco finlandese',{ts '1999-06-13 19:50:26.770'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '19')
UPDATE [currency] SET codecurrency = 'DEM',ct = {ts '1999-06-13 19:50:26.690'},cu = 'Configurazione',description = 'Marco tedesco',lt = {ts '1999-06-13 19:50:26.690'},lu = 'Configurazione' WHERE idcurrency = '19'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('19','DEM',{ts '1999-06-13 19:50:26.690'},'Configurazione','Marco tedesco',{ts '1999-06-13 19:50:26.690'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '20')
UPDATE [currency] SET codecurrency = 'ESP',ct = {ts '1999-06-13 19:50:26.740'},cu = 'Configurazione',description = 'Peseta spagnola',lt = {ts '1999-06-13 19:50:26.740'},lu = 'Configurazione' WHERE idcurrency = '20'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('20','ESP',{ts '1999-06-13 19:50:26.740'},'Configurazione','Peseta spagnola',{ts '1999-06-13 19:50:26.740'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '21')
UPDATE [currency] SET codecurrency = 'SUR',ct = {ts '1999-06-13 19:50:27.060'},cu = 'Configurazione',description = 'Rublo russo',lt = {ts '1999-06-13 19:50:27.060'},lu = 'Configurazione' WHERE idcurrency = '21'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('21','SUR',{ts '1999-06-13 19:50:27.060'},'Configurazione','Rublo russo',{ts '1999-06-13 19:50:27.060'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '22')
UPDATE [currency] SET codecurrency = 'ATS',ct = {ts '1999-06-13 19:50:26.580'},cu = 'Configurazione',description = 'Scellino austriaco',lt = {ts '1999-06-13 19:50:26.580'},lu = 'Configurazione' WHERE idcurrency = '22'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('22','ATS',{ts '1999-06-13 19:50:26.580'},'Configurazione','Scellino austriaco',{ts '1999-06-13 19:50:26.580'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '23')
UPDATE [currency] SET codecurrency = 'PTE',ct = {ts '1999-06-13 19:50:27.020'},cu = 'Configurazione',description = 'Scudo portoghese',lt = {ts '1999-06-13 19:50:27.020'},lu = 'Configurazione' WHERE idcurrency = '23'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('23','PTE',{ts '1999-06-13 19:50:27.020'},'Configurazione','Scudo portoghese',{ts '1999-06-13 19:50:27.020'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '24')
UPDATE [currency] SET codecurrency = 'GBP',ct = {ts '1999-06-13 19:50:26.810'},cu = 'Configurazione',description = 'Sterlina inglese',lt = {ts '1999-06-13 19:50:26.820'},lu = 'Configurazione' WHERE idcurrency = '24'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('24','GBP',{ts '1999-06-13 19:50:26.810'},'Configurazione','Sterlina inglese',{ts '1999-06-13 19:50:26.820'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '25')
UPDATE [currency] SET codecurrency = 'JPY',ct = {ts '1999-06-13 19:50:26.910'},cu = 'Configurazione',description = 'Yen giapponese',lt = {ts '1999-06-13 19:50:26.910'},lu = 'Configurazione' WHERE idcurrency = '25'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('25','JPY',{ts '1999-06-13 19:50:26.910'},'Configurazione','Yen giapponese',{ts '1999-06-13 19:50:26.910'},'Configurazione')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '26')
UPDATE [currency] SET codecurrency = 'ARS',ct = {ts '2009-05-14 14:55:52.530'},cu = 'SARA',description = 'Peso Argentino',lt = {ts '2009-05-14 14:55:52.530'},lu = 'SARA' WHERE idcurrency = '26'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('26','ARS',{ts '2009-05-14 14:55:52.530'},'SARA','Peso Argentino',{ts '2009-05-14 14:55:52.530'},'SARA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '27')
UPDATE [currency] SET codecurrency = 'AED',ct = {ts '2009-09-03 14:31:13.407'},cu = 'SA',description = 'Dirahm degli Emirati Arabi Uniti',lt = {ts '2009-09-03 14:31:13.407'},lu = 'SA' WHERE idcurrency = '27'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('27','AED',{ts '2009-09-03 14:31:13.407'},'SA','Dirahm degli Emirati Arabi Uniti',{ts '2009-09-03 14:31:13.407'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '28')
UPDATE [currency] SET codecurrency = 'AFN',ct = {ts '2009-09-03 14:32:06.670'},cu = 'SA',description = 'Afghani afgano',lt = {ts '2009-09-03 14:32:22.030'},lu = 'SA' WHERE idcurrency = '28'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('28','AFN',{ts '2009-09-03 14:32:06.670'},'SA','Afghani afgano',{ts '2009-09-03 14:32:22.030'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '29')
UPDATE [currency] SET codecurrency = 'ALL',ct = {ts '2009-09-03 14:32:59.717'},cu = 'SA',description = 'Lek albanese',lt = {ts '2009-09-03 14:32:59.717'},lu = 'SA' WHERE idcurrency = '29'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('29','ALL',{ts '2009-09-03 14:32:59.717'},'SA','Lek albanese',{ts '2009-09-03 14:32:59.717'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '30')
UPDATE [currency] SET codecurrency = 'AMD',ct = {ts '2009-09-03 14:33:16.483'},cu = 'SA',description = 'Dram armeno',lt = {ts '2009-09-03 14:33:25.377'},lu = 'SA' WHERE idcurrency = '30'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('30','AMD',{ts '2009-09-03 14:33:16.483'},'SA','Dram armeno',{ts '2009-09-03 14:33:25.377'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '31')
UPDATE [currency] SET codecurrency = 'ANG',ct = {ts '2009-09-03 14:33:50.127'},cu = 'SA',description = 'Fiorino delle Antille olandesi',lt = {ts '2009-09-03 14:33:50.127'},lu = 'SA' WHERE idcurrency = '31'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('31','ANG',{ts '2009-09-03 14:33:50.127'},'SA','Fiorino delle Antille olandesi',{ts '2009-09-03 14:33:50.127'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '32')
UPDATE [currency] SET codecurrency = 'AOA',ct = {ts '2009-09-03 14:34:11.877'},cu = 'SA',description = 'Kwanza angolano',lt = {ts '2009-09-03 14:34:11.877'},lu = 'SA' WHERE idcurrency = '32'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('32','AOA',{ts '2009-09-03 14:34:11.877'},'SA','Kwanza angolano',{ts '2009-09-03 14:34:11.877'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '33')
UPDATE [currency] SET codecurrency = 'AWG',ct = {ts '2009-09-03 14:34:37.640'},cu = 'SA',description = 'Fiorino arubano',lt = {ts '2009-09-03 14:34:37.640'},lu = 'SA' WHERE idcurrency = '33'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('33','AWG',{ts '2009-09-03 14:34:37.640'},'SA','Fiorino arubano',{ts '2009-09-03 14:34:37.640'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '34')
UPDATE [currency] SET codecurrency = 'AZN',ct = {ts '2009-09-03 14:35:10.360'},cu = 'SA',description = 'Manat azero',lt = {ts '2009-09-03 14:35:10.360'},lu = 'SA' WHERE idcurrency = '34'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('34','AZN',{ts '2009-09-03 14:35:10.360'},'SA','Manat azero',{ts '2009-09-03 14:35:10.360'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '35')
UPDATE [currency] SET codecurrency = 'BAM',ct = {ts '2009-09-03 14:35:28.593'},cu = 'SA',description = 'Marco bosniaco',lt = {ts '2009-09-03 14:35:28.593'},lu = 'SA' WHERE idcurrency = '35'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('35','BAM',{ts '2009-09-03 14:35:28.593'},'SA','Marco bosniaco',{ts '2009-09-03 14:35:28.593'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '36')
UPDATE [currency] SET codecurrency = 'BBD',ct = {ts '2009-09-03 14:36:04.343'},cu = 'SA',description = 'Dollaro di Barbados',lt = {ts '2009-09-03 14:36:04.343'},lu = 'SA' WHERE idcurrency = '36'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('36','BBD',{ts '2009-09-03 14:36:04.343'},'SA','Dollaro di Barbados',{ts '2009-09-03 14:36:04.343'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '37')
UPDATE [currency] SET codecurrency = 'BDT',ct = {ts '2009-09-03 14:36:50.983'},cu = 'SA',description = 'Taka bengalese',lt = {ts '2009-09-03 14:36:50.983'},lu = 'SA' WHERE idcurrency = '37'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('37','BDT',{ts '2009-09-03 14:36:50.983'},'SA','Taka bengalese',{ts '2009-09-03 14:36:50.983'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '38')
UPDATE [currency] SET codecurrency = 'BGN',ct = {ts '2009-09-03 14:38:13.657'},cu = 'SA',description = 'Nuovo lev bulgaro',lt = {ts '2009-09-03 14:38:13.657'},lu = 'SA' WHERE idcurrency = '38'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('38','BGN',{ts '2009-09-03 14:38:13.657'},'SA','Nuovo lev bulgaro',{ts '2009-09-03 14:38:13.657'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '39')
UPDATE [currency] SET codecurrency = 'BHD',ct = {ts '2009-09-03 14:39:05.530'},cu = 'SA',description = 'Dinaro del Bahrain',lt = {ts '2009-09-03 14:39:05.530'},lu = 'SA' WHERE idcurrency = '39'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('39','BHD',{ts '2009-09-03 14:39:05.530'},'SA','Dinaro del Bahrain',{ts '2009-09-03 14:39:05.530'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '40')
UPDATE [currency] SET codecurrency = 'BIF',ct = {ts '2009-09-03 14:39:20.877'},cu = 'SA',description = 'Franco del Burundi',lt = {ts '2009-09-03 14:39:20.877'},lu = 'SA' WHERE idcurrency = '40'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('40','BIF',{ts '2009-09-03 14:39:20.877'},'SA','Franco del Burundi',{ts '2009-09-03 14:39:20.877'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '41')
UPDATE [currency] SET codecurrency = 'BMD',ct = {ts '2009-09-03 14:39:35.233'},cu = 'SA',description = 'Dollaro delle Bermuda',lt = {ts '2009-09-03 14:39:35.233'},lu = 'SA' WHERE idcurrency = '41'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('41','BMD',{ts '2009-09-03 14:39:35.233'},'SA','Dollaro delle Bermuda',{ts '2009-09-03 14:39:35.233'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '42')
UPDATE [currency] SET codecurrency = 'BND',ct = {ts '2009-09-03 14:39:47.813'},cu = 'SA',description = 'Dollaro del Brunei',lt = {ts '2009-09-03 14:39:47.813'},lu = 'SA' WHERE idcurrency = '42'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('42','BND',{ts '2009-09-03 14:39:47.813'},'SA','Dollaro del Brunei',{ts '2009-09-03 14:39:47.813'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '43')
UPDATE [currency] SET codecurrency = 'BOB',ct = {ts '2009-09-03 14:40:01.140'},cu = 'SA',description = 'Boliviano',lt = {ts '2009-09-03 14:40:01.140'},lu = 'SA' WHERE idcurrency = '43'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('43','BOB',{ts '2009-09-03 14:40:01.140'},'SA','Boliviano',{ts '2009-09-03 14:40:01.140'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '44')
UPDATE [currency] SET codecurrency = 'BRL',ct = {ts '2009-09-03 14:40:14.217'},cu = 'SA',description = 'Real brasiliano',lt = {ts '2009-09-03 14:40:14.217'},lu = 'SA' WHERE idcurrency = '44'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('44','BRL',{ts '2009-09-03 14:40:14.217'},'SA','Real brasiliano',{ts '2009-09-03 14:40:14.217'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '45')
UPDATE [currency] SET codecurrency = 'BSD',ct = {ts '2009-09-03 14:40:38.703'},cu = 'SA',description = 'Dollaro delle Bahamas',lt = {ts '2009-09-03 14:40:38.703'},lu = 'SA' WHERE idcurrency = '45'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('45','BSD',{ts '2009-09-03 14:40:38.703'},'SA','Dollaro delle Bahamas',{ts '2009-09-03 14:40:38.703'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '46')
UPDATE [currency] SET codecurrency = 'BTN',ct = {ts '2009-09-03 14:41:02.360'},cu = 'SA',description = 'Ngultrum del Bhutan',lt = {ts '2009-09-03 14:41:02.360'},lu = 'SA' WHERE idcurrency = '46'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('46','BTN',{ts '2009-09-03 14:41:02.360'},'SA','Ngultrum del Bhutan',{ts '2009-09-03 14:41:02.360'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '47')
UPDATE [currency] SET codecurrency = 'BWP',ct = {ts '2009-09-03 14:41:17.733'},cu = 'SA',description = 'Pula del Botswana',lt = {ts '2009-09-03 14:41:17.733'},lu = 'SA' WHERE idcurrency = '47'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('47','BWP',{ts '2009-09-03 14:41:17.733'},'SA','Pula del Botswana',{ts '2009-09-03 14:41:17.733'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '48')
UPDATE [currency] SET codecurrency = 'BYR',ct = {ts '2009-09-03 14:41:33.517'},cu = 'SA',description = 'Rublo bielorusso',lt = {ts '2009-09-03 14:41:33.517'},lu = 'SA' WHERE idcurrency = '48'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('48','BYR',{ts '2009-09-03 14:41:33.517'},'SA','Rublo bielorusso',{ts '2009-09-03 14:41:33.517'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '49')
UPDATE [currency] SET codecurrency = 'BZD',ct = {ts '2009-09-03 14:42:19.860'},cu = 'SA',description = 'Dollaro del Belize',lt = {ts '2009-09-03 14:42:19.860'},lu = 'SA' WHERE idcurrency = '49'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('49','BZD',{ts '2009-09-03 14:42:19.860'},'SA','Dollaro del Belize',{ts '2009-09-03 14:42:19.860'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '50')
UPDATE [currency] SET codecurrency = 'CDF',ct = {ts '2009-09-03 14:42:45.297'},cu = 'SA',description = 'Franco congolese',lt = {ts '2009-09-03 14:42:45.297'},lu = 'SA' WHERE idcurrency = '50'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('50','CDF',{ts '2009-09-03 14:42:45.297'},'SA','Franco congolese',{ts '2009-09-03 14:42:45.297'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '51')
UPDATE [currency] SET codecurrency = 'CLP',ct = {ts '2009-09-03 14:43:27.890'},cu = 'SA',description = 'Peso cileno',lt = {ts '2009-09-03 14:43:27.890'},lu = 'SA' WHERE idcurrency = '51'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('51','CLP',{ts '2009-09-03 14:43:27.890'},'SA','Peso cileno',{ts '2009-09-03 14:43:27.890'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '52')
UPDATE [currency] SET codecurrency = 'CNY',ct = {ts '2009-09-03 14:44:04.813'},cu = 'SA',description = 'Renminbi cinese (yuan)',lt = {ts '2009-09-03 14:44:04.813'},lu = 'SA' WHERE idcurrency = '52'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('52','CNY',{ts '2009-09-03 14:44:04.813'},'SA','Renminbi cinese (yuan)',{ts '2009-09-03 14:44:04.813'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '53')
UPDATE [currency] SET codecurrency = 'COP',ct = {ts '2009-09-03 14:44:18.467'},cu = 'SA',description = 'Peso colombiano',lt = {ts '2009-09-03 14:44:18.467'},lu = 'SA' WHERE idcurrency = '53'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('53','COP',{ts '2009-09-03 14:44:18.467'},'SA','Peso colombiano',{ts '2009-09-03 14:44:18.467'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '54')
UPDATE [currency] SET codecurrency = 'CRC',ct = {ts '2009-09-03 14:44:41.733'},cu = 'SA',description = 'Colòn constaricano',lt = {ts '2009-09-03 14:44:41.733'},lu = 'SA' WHERE idcurrency = '54'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('54','CRC',{ts '2009-09-03 14:44:41.733'},'SA','Colòn constaricano',{ts '2009-09-03 14:44:41.733'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '55')
UPDATE [currency] SET codecurrency = 'CUP',ct = {ts '2009-09-03 14:44:53.610'},cu = 'SA',description = 'Peso cubano',lt = {ts '2009-09-03 14:44:53.610'},lu = 'SA' WHERE idcurrency = '55'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('55','CUP',{ts '2009-09-03 14:44:53.610'},'SA','Peso cubano',{ts '2009-09-03 14:44:53.610'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '56')
UPDATE [currency] SET codecurrency = 'CVE',ct = {ts '2009-09-03 14:45:12.077'},cu = 'SA',description = 'Escudo di Capo Verde',lt = {ts '2009-09-03 14:45:12.077'},lu = 'SA' WHERE idcurrency = '56'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('56','CVE',{ts '2009-09-03 14:45:12.077'},'SA','Escudo di Capo Verde',{ts '2009-09-03 14:45:12.077'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '57')
UPDATE [currency] SET codecurrency = 'CZK',ct = {ts '2009-09-03 14:45:29.813'},cu = 'SA',description = 'Corona ceca',lt = {ts '2009-09-03 14:45:29.813'},lu = 'SA' WHERE idcurrency = '57'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('57','CZK',{ts '2009-09-03 14:45:29.813'},'SA','Corona ceca',{ts '2009-09-03 14:45:29.813'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '58')
UPDATE [currency] SET codecurrency = 'DJF',ct = {ts '2009-09-03 14:46:48.530'},cu = 'SA',description = 'Franco gibutiano',lt = {ts '2009-09-03 14:46:48.530'},lu = 'SA' WHERE idcurrency = '58'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('58','DJF',{ts '2009-09-03 14:46:48.530'},'SA','Franco gibutiano',{ts '2009-09-03 14:46:48.530'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '59')
UPDATE [currency] SET codecurrency = 'DOP',ct = {ts '2009-09-03 14:47:08.453'},cu = 'SA',description = 'Peso dominicano',lt = {ts '2009-09-03 14:47:08.453'},lu = 'SA' WHERE idcurrency = '59'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('59','DOP',{ts '2009-09-03 14:47:08.453'},'SA','Peso dominicano',{ts '2009-09-03 14:47:08.453'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '60')
UPDATE [currency] SET codecurrency = 'DZD',ct = {ts '2009-09-03 14:47:25.877'},cu = 'SA',description = 'Dinaro algerino',lt = {ts '2009-09-03 14:47:25.877'},lu = 'SA' WHERE idcurrency = '60'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('60','DZD',{ts '2009-09-03 14:47:25.877'},'SA','Dinaro algerino',{ts '2009-09-03 14:47:25.877'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '61')
UPDATE [currency] SET codecurrency = 'EEK',ct = {ts '2009-09-03 14:47:40.000'},cu = 'SA',description = 'Corona estone',lt = {ts '2009-09-03 14:47:40.000'},lu = 'SA' WHERE idcurrency = '61'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('61','EEK',{ts '2009-09-03 14:47:40.000'},'SA','Corona estone',{ts '2009-09-03 14:47:40.000'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '62')
UPDATE [currency] SET codecurrency = 'EGP',ct = {ts '2009-09-03 14:48:03.967'},cu = 'SA',description = 'Lira egiziana (o sterlina)',lt = {ts '2009-09-03 14:48:03.967'},lu = 'SA' WHERE idcurrency = '62'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('62','EGP',{ts '2009-09-03 14:48:03.967'},'SA','Lira egiziana (o sterlina)',{ts '2009-09-03 14:48:03.967'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '63')
UPDATE [currency] SET codecurrency = 'ERN',ct = {ts '2009-09-03 14:48:20.467'},cu = 'SA',description = 'Nafka eritreo',lt = {ts '2009-09-03 14:48:20.467'},lu = 'SA' WHERE idcurrency = '63'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('63','ERN',{ts '2009-09-03 14:48:20.467'},'SA','Nafka eritreo',{ts '2009-09-03 14:48:20.467'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '64')
UPDATE [currency] SET codecurrency = 'ETB',ct = {ts '2009-09-03 14:48:31.750'},cu = 'SA',description = 'Birr etiope',lt = {ts '2009-09-03 14:48:31.750'},lu = 'SA' WHERE idcurrency = '64'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('64','ETB',{ts '2009-09-03 14:48:31.750'},'SA','Birr etiope',{ts '2009-09-03 14:48:31.750'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '65')
UPDATE [currency] SET codecurrency = 'FJD',ct = {ts '2009-09-03 14:48:53.280'},cu = 'SA',description = 'Dollaro delle Figi',lt = {ts '2009-09-03 14:48:53.280'},lu = 'SA' WHERE idcurrency = '65'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('65','FJD',{ts '2009-09-03 14:48:53.280'},'SA','Dollaro delle Figi',{ts '2009-09-03 14:48:53.280'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '66')
UPDATE [currency] SET codecurrency = 'FKP',ct = {ts '2009-09-03 14:49:09.017'},cu = 'SA',description = 'Sterlina delle Falkland',lt = {ts '2009-09-03 14:49:09.017'},lu = 'SA' WHERE idcurrency = '66'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('66','FKP',{ts '2009-09-03 14:49:09.017'},'SA','Sterlina delle Falkland',{ts '2009-09-03 14:49:09.017'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '67')
UPDATE [currency] SET codecurrency = 'GEL',ct = {ts '2009-09-03 14:49:37.733'},cu = 'SA',description = 'Lari georgiano',lt = {ts '2009-09-03 14:49:37.733'},lu = 'SA' WHERE idcurrency = '67'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('67','GEL',{ts '2009-09-03 14:49:37.733'},'SA','Lari georgiano',{ts '2009-09-03 14:49:37.733'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '68')
UPDATE [currency] SET codecurrency = 'GHC',ct = {ts '2009-09-03 14:50:01.860'},cu = 'SA',description = 'Cedi ghanese',lt = {ts '2009-09-03 14:50:01.860'},lu = 'SA' WHERE idcurrency = '68'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('68','GHC',{ts '2009-09-03 14:50:01.860'},'SA','Cedi ghanese',{ts '2009-09-03 14:50:01.860'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '69')
UPDATE [currency] SET codecurrency = 'GIP',ct = {ts '2009-09-03 14:50:36.670'},cu = 'SA',description = 'Sterlina di Gibilterra',lt = {ts '2009-09-03 14:50:36.670'},lu = 'SA' WHERE idcurrency = '69'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('69','GIP',{ts '2009-09-03 14:50:36.670'},'SA','Sterlina di Gibilterra',{ts '2009-09-03 14:50:36.670'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '70')
UPDATE [currency] SET codecurrency = 'GMD',ct = {ts '2009-09-03 14:51:15.407'},cu = 'SA',description = 'Dalasi gambese',lt = {ts '2009-09-03 14:51:15.407'},lu = 'SA' WHERE idcurrency = '70'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('70','GMD',{ts '2009-09-03 14:51:15.407'},'SA','Dalasi gambese',{ts '2009-09-03 14:51:15.407'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '71')
UPDATE [currency] SET codecurrency = 'GNF',ct = {ts '2009-09-03 14:51:47.000'},cu = 'SA',description = 'Franco guineano',lt = {ts '2009-09-03 14:51:47.000'},lu = 'SA' WHERE idcurrency = '71'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('71','GNF',{ts '2009-09-03 14:51:47.000'},'SA','Franco guineano',{ts '2009-09-03 14:51:47.000'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '72')
UPDATE [currency] SET codecurrency = 'GTQ',ct = {ts '2009-09-03 14:52:06.967'},cu = 'SA',description = 'Quetzal guatemalteco',lt = {ts '2009-09-03 14:52:06.967'},lu = 'SA' WHERE idcurrency = '72'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('72','GTQ',{ts '2009-09-03 14:52:06.967'},'SA','Quetzal guatemalteco',{ts '2009-09-03 14:52:06.967'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '73')
UPDATE [currency] SET codecurrency = 'GYD',ct = {ts '2009-09-03 14:52:20.703'},cu = 'SA',description = 'Dollaro della Guyana',lt = {ts '2009-09-03 14:52:20.703'},lu = 'SA' WHERE idcurrency = '73'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('73','GYD',{ts '2009-09-03 14:52:20.703'},'SA','Dollaro della Guyana',{ts '2009-09-03 14:52:20.703'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '74')
UPDATE [currency] SET codecurrency = 'HKD',ct = {ts '2009-09-03 14:52:32.547'},cu = 'SA',description = 'Dollaro di Hong Kong',lt = {ts '2009-09-03 14:52:32.547'},lu = 'SA' WHERE idcurrency = '74'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('74','HKD',{ts '2009-09-03 14:52:32.547'},'SA','Dollaro di Hong Kong',{ts '2009-09-03 14:52:32.547'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '75')
UPDATE [currency] SET codecurrency = 'HNL',ct = {ts '2009-09-03 14:52:47.000'},cu = 'SA',description = 'Lempira honduregna',lt = {ts '2009-09-03 14:52:47.000'},lu = 'SA' WHERE idcurrency = '75'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('75','HNL',{ts '2009-09-03 14:52:47.000'},'SA','Lempira honduregna',{ts '2009-09-03 14:52:47.000'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '76')
UPDATE [currency] SET codecurrency = 'HRK',ct = {ts '2009-09-03 14:53:04.767'},cu = 'SA',description = 'Kuna croata',lt = {ts '2009-09-03 14:53:04.767'},lu = 'SA' WHERE idcurrency = '76'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('76','HRK',{ts '2009-09-03 14:53:04.767'},'SA','Kuna croata',{ts '2009-09-03 14:53:04.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '77')
UPDATE [currency] SET codecurrency = 'HTG',ct = {ts '2009-09-03 14:53:27.017'},cu = 'SA',description = 'Gourde haitiano',lt = {ts '2009-09-03 14:53:27.017'},lu = 'SA' WHERE idcurrency = '77'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('77','HTG',{ts '2009-09-03 14:53:27.017'},'SA','Gourde haitiano',{ts '2009-09-03 14:53:27.017'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '78')
UPDATE [currency] SET codecurrency = 'HUF',ct = {ts '2009-09-03 14:53:50.110'},cu = 'SA',description = 'Fiorino ungherese',lt = {ts '2009-09-03 14:53:50.110'},lu = 'SA' WHERE idcurrency = '78'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('78','HUF',{ts '2009-09-03 14:53:50.110'},'SA','Fiorino ungherese',{ts '2009-09-03 14:53:50.110'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '79')
UPDATE [currency] SET codecurrency = 'IDR',ct = {ts '2009-09-03 14:54:06.157'},cu = 'SA',description = 'Rupia indonesiana',lt = {ts '2009-09-03 14:54:06.157'},lu = 'SA' WHERE idcurrency = '79'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('79','IDR',{ts '2009-09-03 14:54:06.157'},'SA','Rupia indonesiana',{ts '2009-09-03 14:54:06.157'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '80')
UPDATE [currency] SET codecurrency = 'ILS',ct = {ts '2009-09-03 14:54:22.170'},cu = 'SA',description = 'Nuovo shekel israeliano',lt = {ts '2009-09-03 14:54:22.170'},lu = 'SA' WHERE idcurrency = '80'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('80','ILS',{ts '2009-09-03 14:54:22.170'},'SA','Nuovo shekel israeliano',{ts '2009-09-03 14:54:22.170'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '81')
UPDATE [currency] SET codecurrency = 'INR',ct = {ts '2009-09-03 14:54:44.077'},cu = 'SA',description = 'Rupia indiana',lt = {ts '2009-09-03 14:54:44.077'},lu = 'SA' WHERE idcurrency = '81'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('81','INR',{ts '2009-09-03 14:54:44.077'},'SA','Rupia indiana',{ts '2009-09-03 14:54:44.077'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '82')
UPDATE [currency] SET codecurrency = 'ISK',ct = {ts '2009-09-03 14:55:03.967'},cu = 'SA',description = 'Corona islandese',lt = {ts '2009-09-03 14:55:03.967'},lu = 'SA' WHERE idcurrency = '82'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('82','ISK',{ts '2009-09-03 14:55:03.967'},'SA','Corona islandese',{ts '2009-09-03 14:55:03.967'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '83')
UPDATE [currency] SET codecurrency = 'JMD',ct = {ts '2009-09-03 14:55:18.093'},cu = 'SA',description = 'Dollaro giamaicano',lt = {ts '2009-09-03 14:55:18.093'},lu = 'SA' WHERE idcurrency = '83'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('83','JMD',{ts '2009-09-03 14:55:18.093'},'SA','Dollaro giamaicano',{ts '2009-09-03 14:55:18.093'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '84')
UPDATE [currency] SET codecurrency = 'JOD',ct = {ts '2009-09-03 14:55:31.360'},cu = 'SA',description = 'Dinaro giordano',lt = {ts '2009-09-03 14:55:31.360'},lu = 'SA' WHERE idcurrency = '84'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('84','JOD',{ts '2009-09-03 14:55:31.360'},'SA','Dinaro giordano',{ts '2009-09-03 14:55:31.360'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '85')
UPDATE [currency] SET codecurrency = 'KES',ct = {ts '2009-09-03 14:55:51.517'},cu = 'SA',description = 'Scellino keniota',lt = {ts '2009-09-03 14:55:51.517'},lu = 'SA' WHERE idcurrency = '85'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('85','KES',{ts '2009-09-03 14:55:51.517'},'SA','Scellino keniota',{ts '2009-09-03 14:55:51.517'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '86')
UPDATE [currency] SET codecurrency = 'KGS',ct = {ts '2009-09-03 14:56:07.610'},cu = 'SA',description = 'Som kirghizo',lt = {ts '2009-09-03 14:56:07.610'},lu = 'SA' WHERE idcurrency = '86'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('86','KGS',{ts '2009-09-03 14:56:07.610'},'SA','Som kirghizo',{ts '2009-09-03 14:56:07.610'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '87')
UPDATE [currency] SET codecurrency = 'KHR',ct = {ts '2009-09-03 14:56:20.827'},cu = 'SA',description = 'Real cambogiano',lt = {ts '2009-09-03 14:56:20.827'},lu = 'SA' WHERE idcurrency = '87'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('87','KHR',{ts '2009-09-03 14:56:20.827'},'SA','Real cambogiano',{ts '2009-09-03 14:56:20.827'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '88')
UPDATE [currency] SET codecurrency = 'KMF',ct = {ts '2009-09-03 14:56:55.687'},cu = 'SA',description = 'Franco delle Comore',lt = {ts '2009-09-03 14:56:55.687'},lu = 'SA' WHERE idcurrency = '88'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('88','KMF',{ts '2009-09-03 14:56:55.687'},'SA','Franco delle Comore',{ts '2009-09-03 14:56:55.687'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '89')
UPDATE [currency] SET codecurrency = 'KPW',ct = {ts '2009-09-03 14:57:18.890'},cu = 'SA',description = 'Won nordcoreano',lt = {ts '2009-09-03 14:57:18.890'},lu = 'SA' WHERE idcurrency = '89'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('89','KPW',{ts '2009-09-03 14:57:18.890'},'SA','Won nordcoreano',{ts '2009-09-03 14:57:18.890'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '90')
UPDATE [currency] SET codecurrency = 'KRW',ct = {ts '2009-09-03 14:57:34.483'},cu = 'SA',description = 'Won sudcoreano',lt = {ts '2009-09-03 14:57:34.483'},lu = 'SA' WHERE idcurrency = '90'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('90','KRW',{ts '2009-09-03 14:57:34.483'},'SA','Won sudcoreano',{ts '2009-09-03 14:57:34.483'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '91')
UPDATE [currency] SET codecurrency = 'KWD',ct = {ts '2009-09-03 14:58:06.577'},cu = 'SA',description = 'Dinaro kuwaitiano',lt = {ts '2009-09-03 14:58:06.577'},lu = 'SA' WHERE idcurrency = '91'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('91','KWD',{ts '2009-09-03 14:58:06.577'},'SA','Dinaro kuwaitiano',{ts '2009-09-03 14:58:06.577'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '92')
UPDATE [currency] SET codecurrency = 'KYD',ct = {ts '2009-09-03 15:00:16.953'},cu = 'SA',description = 'Dollaro delle Cayman',lt = {ts '2009-09-03 15:00:16.953'},lu = 'SA' WHERE idcurrency = '92'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('92','KYD',{ts '2009-09-03 15:00:16.953'},'SA','Dollaro delle Cayman',{ts '2009-09-03 15:00:16.953'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '93')
UPDATE [currency] SET codecurrency = 'KZT',ct = {ts '2009-09-03 15:00:37.750'},cu = 'SA',description = 'Tenge kazako',lt = {ts '2009-09-03 15:00:37.750'},lu = 'SA' WHERE idcurrency = '93'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('93','KZT',{ts '2009-09-03 15:00:37.750'},'SA','Tenge kazako',{ts '2009-09-03 15:00:37.750'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '94')
UPDATE [currency] SET codecurrency = 'LAK',ct = {ts '2009-09-03 15:00:56.170'},cu = 'SA',description = 'Kip laotiano',lt = {ts '2009-09-03 15:00:56.170'},lu = 'SA' WHERE idcurrency = '94'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('94','LAK',{ts '2009-09-03 15:00:56.170'},'SA','Kip laotiano',{ts '2009-09-03 15:00:56.170'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '95')
UPDATE [currency] SET codecurrency = 'LBP',ct = {ts '2009-09-03 15:01:08.937'},cu = 'SA',description = 'Lira libanese',lt = {ts '2009-09-03 15:01:08.937'},lu = 'SA' WHERE idcurrency = '95'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('95','LBP',{ts '2009-09-03 15:01:08.937'},'SA','Lira libanese',{ts '2009-09-03 15:01:08.937'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '96')
UPDATE [currency] SET codecurrency = 'LKR',ct = {ts '2009-09-03 15:01:29.483'},cu = 'SA',description = 'Rupia singalese',lt = {ts '2009-09-03 15:01:29.483'},lu = 'SA' WHERE idcurrency = '96'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('96','LKR',{ts '2009-09-03 15:01:29.483'},'SA','Rupia singalese',{ts '2009-09-03 15:01:29.483'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '97')
UPDATE [currency] SET codecurrency = 'LRD',ct = {ts '2009-09-03 15:01:41.390'},cu = 'SA',description = 'Dollaro liberiano',lt = {ts '2009-09-03 15:01:41.390'},lu = 'SA' WHERE idcurrency = '97'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('97','LRD',{ts '2009-09-03 15:01:41.390'},'SA','Dollaro liberiano',{ts '2009-09-03 15:01:41.390'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '98')
UPDATE [currency] SET codecurrency = 'LSL',ct = {ts '2009-09-03 15:01:55.390'},cu = 'SA',description = 'Loti lesothiano',lt = {ts '2009-09-03 15:01:55.390'},lu = 'SA' WHERE idcurrency = '98'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('98','LSL',{ts '2009-09-03 15:01:55.390'},'SA','Loti lesothiano',{ts '2009-09-03 15:01:55.390'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '99')
UPDATE [currency] SET codecurrency = 'LTL',ct = {ts '2009-09-03 15:02:16.517'},cu = 'SA',description = 'Lita lituano',lt = {ts '2009-09-03 15:02:16.517'},lu = 'SA' WHERE idcurrency = '99'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('99','LTL',{ts '2009-09-03 15:02:16.517'},'SA','Lita lituano',{ts '2009-09-03 15:02:16.517'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '100')
UPDATE [currency] SET codecurrency = 'LVL',ct = {ts '2009-09-03 15:02:37.937'},cu = 'SA',description = 'Lats lettone',lt = {ts '2009-09-03 15:02:37.937'},lu = 'SA' WHERE idcurrency = '100'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('100','LVL',{ts '2009-09-03 15:02:37.937'},'SA','Lats lettone',{ts '2009-09-03 15:02:37.937'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '101')
UPDATE [currency] SET codecurrency = 'LYD',ct = {ts '2009-09-03 15:03:02.483'},cu = 'SA',description = 'Dinaro libico',lt = {ts '2009-09-03 15:03:02.483'},lu = 'SA' WHERE idcurrency = '101'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('101','LYD',{ts '2009-09-03 15:03:02.483'},'SA','Dinaro libico',{ts '2009-09-03 15:03:02.483'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '102')
UPDATE [currency] SET codecurrency = 'MAD',ct = {ts '2009-09-03 15:03:15.313'},cu = 'SA',description = 'Dirham marocchino',lt = {ts '2009-09-03 15:03:15.313'},lu = 'SA' WHERE idcurrency = '102'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('102','MAD',{ts '2009-09-03 15:03:15.313'},'SA','Dirham marocchino',{ts '2009-09-03 15:03:15.313'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '103')
UPDATE [currency] SET codecurrency = 'MDL',ct = {ts '2009-09-03 15:03:27.843'},cu = 'SA',description = 'Leu moldavo',lt = {ts '2009-09-03 15:03:27.843'},lu = 'SA' WHERE idcurrency = '103'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('103','MDL',{ts '2009-09-03 15:03:27.843'},'SA','Leu moldavo',{ts '2009-09-03 15:03:27.843'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '104')
UPDATE [currency] SET codecurrency = 'MGA',ct = {ts '2009-09-03 15:03:56.437'},cu = 'SA',description = 'Ariary malgascio',lt = {ts '2009-09-03 15:03:56.437'},lu = 'SA' WHERE idcurrency = '104'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('104','MGA',{ts '2009-09-03 15:03:56.437'},'SA','Ariary malgascio',{ts '2009-09-03 15:03:56.437'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '105')
UPDATE [currency] SET codecurrency = 'MKD',ct = {ts '2009-09-03 15:04:08.953'},cu = 'SA',description = 'Dinaro macedone',lt = {ts '2009-09-03 15:04:08.953'},lu = 'SA' WHERE idcurrency = '105'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('105','MKD',{ts '2009-09-03 15:04:08.953'},'SA','Dinaro macedone',{ts '2009-09-03 15:04:08.953'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '106')
UPDATE [currency] SET codecurrency = 'MMK',ct = {ts '2009-09-03 15:04:25.127'},cu = 'SA',description = 'Kyat birmano',lt = {ts '2009-09-03 15:04:25.127'},lu = 'SA' WHERE idcurrency = '106'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('106','MMK',{ts '2009-09-03 15:04:25.127'},'SA','Kyat birmano',{ts '2009-09-03 15:04:25.127'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '107')
UPDATE [currency] SET codecurrency = 'MNT',ct = {ts '2009-09-03 15:04:39.767'},cu = 'SA',description = 'Turik mongolo',lt = {ts '2009-09-03 15:04:39.767'},lu = 'SA' WHERE idcurrency = '107'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('107','MNT',{ts '2009-09-03 15:04:39.767'},'SA','Turik mongolo',{ts '2009-09-03 15:04:39.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '108')
UPDATE [currency] SET codecurrency = 'MOP',ct = {ts '2009-09-03 15:04:55.627'},cu = 'SA',description = 'Pataca di Macao',lt = {ts '2009-09-03 15:04:55.627'},lu = 'SA' WHERE idcurrency = '108'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('108','MOP',{ts '2009-09-03 15:04:55.627'},'SA','Pataca di Macao',{ts '2009-09-03 15:04:55.627'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '109')
UPDATE [currency] SET codecurrency = 'MRO',ct = {ts '2009-09-03 15:05:25.063'},cu = 'SA',description = 'Ouguiya mauritana',lt = {ts '2009-09-03 15:05:25.063'},lu = 'SA' WHERE idcurrency = '109'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('109','MRO',{ts '2009-09-03 15:05:25.063'},'SA','Ouguiya mauritana',{ts '2009-09-03 15:05:25.063'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '110')
UPDATE [currency] SET codecurrency = 'MUR',ct = {ts '2009-09-03 15:05:38.827'},cu = 'SA',description = 'Rupia mauriziana',lt = {ts '2009-09-03 15:05:38.827'},lu = 'SA' WHERE idcurrency = '110'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('110','MUR',{ts '2009-09-03 15:05:38.827'},'SA','Rupia mauriziana',{ts '2009-09-03 15:05:38.827'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '111')
UPDATE [currency] SET codecurrency = 'MVR',ct = {ts '2009-09-03 15:05:53.843'},cu = 'SA',description = 'Rufiyaa delle Maldive',lt = {ts '2009-09-03 15:05:53.843'},lu = 'SA' WHERE idcurrency = '111'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('111','MVR',{ts '2009-09-03 15:05:53.843'},'SA','Rufiyaa delle Maldive',{ts '2009-09-03 15:05:53.843'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '112')
UPDATE [currency] SET codecurrency = 'MWK',ct = {ts '2009-09-03 15:06:09.063'},cu = 'SA',description = 'Kwacha malawiano',lt = {ts '2009-09-03 15:06:09.063'},lu = 'SA' WHERE idcurrency = '112'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('112','MWK',{ts '2009-09-03 15:06:09.063'},'SA','Kwacha malawiano',{ts '2009-09-03 15:06:09.063'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '113')
UPDATE [currency] SET codecurrency = 'MXN',ct = {ts '2009-09-03 15:06:22.517'},cu = 'SA',description = 'Peso messicano',lt = {ts '2009-09-03 15:06:22.517'},lu = 'SA' WHERE idcurrency = '113'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('113','MXN',{ts '2009-09-03 15:06:22.517'},'SA','Peso messicano',{ts '2009-09-03 15:06:22.517'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '114')
UPDATE [currency] SET codecurrency = 'MYR',ct = {ts '2009-09-03 15:06:39.733'},cu = 'SA',description = 'Ringgit malese',lt = {ts '2009-09-03 15:06:39.733'},lu = 'SA' WHERE idcurrency = '114'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('114','MYR',{ts '2009-09-03 15:06:39.733'},'SA','Ringgit malese',{ts '2009-09-03 15:06:39.733'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '115')
UPDATE [currency] SET codecurrency = 'MZN',ct = {ts '2009-09-03 15:06:58.627'},cu = 'SA',description = 'Metical namibiano',lt = {ts '2009-09-03 15:06:58.627'},lu = 'SA' WHERE idcurrency = '115'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('115','MZN',{ts '2009-09-03 15:06:58.627'},'SA','Metical namibiano',{ts '2009-09-03 15:06:58.627'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '116')
UPDATE [currency] SET codecurrency = 'NGN',ct = {ts '2009-09-03 15:07:27.233'},cu = 'SA',description = 'Naira nigeriana',lt = {ts '2009-09-03 15:07:27.233'},lu = 'SA' WHERE idcurrency = '116'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('116','NGN',{ts '2009-09-03 15:07:27.233'},'SA','Naira nigeriana',{ts '2009-09-03 15:07:27.233'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '117')
UPDATE [currency] SET codecurrency = 'NAD',ct = {ts '2009-09-03 15:07:47.797'},cu = 'SA',description = 'Dollaro namibiano',lt = {ts '2009-09-03 15:07:47.797'},lu = 'SA' WHERE idcurrency = '117'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('117','NAD',{ts '2009-09-03 15:07:47.797'},'SA','Dollaro namibiano',{ts '2009-09-03 15:07:47.797'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '118')
UPDATE [currency] SET codecurrency = 'NIO',ct = {ts '2009-09-03 15:08:07.500'},cu = 'SA',description = 'Cordoba nicaraguense',lt = {ts '2009-09-03 15:08:07.500'},lu = 'SA' WHERE idcurrency = '118'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('118','NIO',{ts '2009-09-03 15:08:07.500'},'SA','Cordoba nicaraguense',{ts '2009-09-03 15:08:07.500'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '119')
UPDATE [currency] SET codecurrency = 'NPR',ct = {ts '2009-09-03 15:08:32.797'},cu = 'SA',description = 'Rupia nepalese',lt = {ts '2009-09-03 15:08:32.797'},lu = 'SA' WHERE idcurrency = '119'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('119','NPR',{ts '2009-09-03 15:08:32.797'},'SA','Rupia nepalese',{ts '2009-09-03 15:08:32.797'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '120')
UPDATE [currency] SET codecurrency = 'OMR',ct = {ts '2009-09-03 15:08:56.377'},cu = 'SA',description = 'Rial dell''Oman',lt = {ts '2009-09-03 15:08:56.377'},lu = 'SA' WHERE idcurrency = '120'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('120','OMR',{ts '2009-09-03 15:08:56.377'},'SA','Rial dell''Oman',{ts '2009-09-03 15:08:56.377'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '121')
UPDATE [currency] SET codecurrency = 'PAB',ct = {ts '2009-09-03 15:09:12.563'},cu = 'SA',description = 'Balboa panamense',lt = {ts '2009-09-03 15:09:12.563'},lu = 'SA' WHERE idcurrency = '121'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('121','PAB',{ts '2009-09-03 15:09:12.563'},'SA','Balboa panamense',{ts '2009-09-03 15:09:12.563'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '122')
UPDATE [currency] SET codecurrency = 'PEN',ct = {ts '2009-09-03 15:09:26.483'},cu = 'SA',description = 'Nuevo sol peruviano',lt = {ts '2009-09-03 15:09:26.483'},lu = 'SA' WHERE idcurrency = '122'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('122','PEN',{ts '2009-09-03 15:09:26.483'},'SA','Nuevo sol peruviano',{ts '2009-09-03 15:09:26.483'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '123')
UPDATE [currency] SET codecurrency = 'PGK',ct = {ts '2009-09-03 15:09:43.467'},cu = 'SA',description = 'Kina papuana',lt = {ts '2009-09-03 15:09:43.467'},lu = 'SA' WHERE idcurrency = '123'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('123','PGK',{ts '2009-09-03 15:09:43.467'},'SA','Kina papuana',{ts '2009-09-03 15:09:43.467'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '124')
UPDATE [currency] SET codecurrency = 'PHP',ct = {ts '2009-09-03 15:09:58.640'},cu = 'SA',description = 'Peso filippino',lt = {ts '2009-09-03 15:09:58.640'},lu = 'SA' WHERE idcurrency = '124'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('124','PHP',{ts '2009-09-03 15:09:58.640'},'SA','Peso filippino',{ts '2009-09-03 15:09:58.640'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '125')
UPDATE [currency] SET codecurrency = 'PKR',ct = {ts '2009-09-03 15:10:15.047'},cu = 'SA',description = 'Rupia pakistana',lt = {ts '2009-09-03 15:10:15.047'},lu = 'SA' WHERE idcurrency = '125'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('125','PKR',{ts '2009-09-03 15:10:15.047'},'SA','Rupia pakistana',{ts '2009-09-03 15:10:15.047'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '126')
UPDATE [currency] SET codecurrency = 'PLN',ct = {ts '2009-09-03 15:10:32.407'},cu = 'SA',description = 'Zloty polacco',lt = {ts '2009-09-03 15:10:36.377'},lu = 'SA' WHERE idcurrency = '126'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('126','PLN',{ts '2009-09-03 15:10:32.407'},'SA','Zloty polacco',{ts '2009-09-03 15:10:36.377'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '127')
UPDATE [currency] SET codecurrency = 'PYG',ct = {ts '2009-09-03 15:10:50.610'},cu = 'SA',description = 'Guarani paraguaiano',lt = {ts '2009-09-03 15:10:50.610'},lu = 'SA' WHERE idcurrency = '127'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('127','PYG',{ts '2009-09-03 15:10:50.610'},'SA','Guarani paraguaiano',{ts '2009-09-03 15:10:50.610'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '128')
UPDATE [currency] SET codecurrency = 'QAR',ct = {ts '2009-09-03 15:11:04.000'},cu = 'SA',description = 'Rial del Qatar',lt = {ts '2009-09-03 15:11:04.000'},lu = 'SA' WHERE idcurrency = '128'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('128','QAR',{ts '2009-09-03 15:11:04.000'},'SA','Rial del Qatar',{ts '2009-09-03 15:11:04.000'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '129')
UPDATE [currency] SET codecurrency = 'ROL',ct = {ts '2009-09-03 15:11:14.920'},cu = 'SA',description = 'Leu rumeno',lt = {ts '2009-09-03 15:11:14.920'},lu = 'SA' WHERE idcurrency = '129'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('129','ROL',{ts '2009-09-03 15:11:14.920'},'SA','Leu rumeno',{ts '2009-09-03 15:11:14.920'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '130')
UPDATE [currency] SET codecurrency = 'RON',ct = {ts '2009-09-03 15:11:29.767'},cu = 'SA',description = 'Nuovo leu rumeno',lt = {ts '2009-09-03 15:11:29.767'},lu = 'SA' WHERE idcurrency = '130'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('130','RON',{ts '2009-09-03 15:11:29.767'},'SA','Nuovo leu rumeno',{ts '2009-09-03 15:11:29.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '131')
UPDATE [currency] SET codecurrency = 'RSD',ct = {ts '2009-09-03 15:11:41.437'},cu = 'SA',description = 'Dinaro serbo',lt = {ts '2009-09-03 15:11:41.437'},lu = 'SA' WHERE idcurrency = '131'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('131','RSD',{ts '2009-09-03 15:11:41.437'},'SA','Dinaro serbo',{ts '2009-09-03 15:11:41.437'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '132')
UPDATE [currency] SET codecurrency = 'RWF',ct = {ts '2009-09-03 15:12:11.343'},cu = 'SA',description = 'Franco ruandese',lt = {ts '2009-09-03 15:12:11.343'},lu = 'SA' WHERE idcurrency = '132'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('132','RWF',{ts '2009-09-03 15:12:11.343'},'SA','Franco ruandese',{ts '2009-09-03 15:12:11.343'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '133')
UPDATE [currency] SET codecurrency = 'SAR',ct = {ts '2009-09-03 15:12:24.093'},cu = 'SA',description = 'Rial saudita',lt = {ts '2009-09-03 15:12:24.093'},lu = 'SA' WHERE idcurrency = '133'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('133','SAR',{ts '2009-09-03 15:12:24.093'},'SA','Rial saudita',{ts '2009-09-03 15:12:24.093'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '134')
UPDATE [currency] SET codecurrency = 'SBD',ct = {ts '2009-09-03 15:12:41.407'},cu = 'SA',description = 'Dollaro delle Salomone',lt = {ts '2009-09-03 15:12:41.407'},lu = 'SA' WHERE idcurrency = '134'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('134','SBD',{ts '2009-09-03 15:12:41.407'},'SA','Dollaro delle Salomone',{ts '2009-09-03 15:12:41.407'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '135')
UPDATE [currency] SET codecurrency = 'SCR',ct = {ts '2009-09-03 15:12:56.920'},cu = 'SA',description = 'Rupia delle Seychelles',lt = {ts '2009-09-03 15:12:56.920'},lu = 'SA' WHERE idcurrency = '135'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('135','SCR',{ts '2009-09-03 15:12:56.920'},'SA','Rupia delle Seychelles',{ts '2009-09-03 15:12:56.920'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '136')
UPDATE [currency] SET codecurrency = 'SDG',ct = {ts '2009-09-03 15:13:10.827'},cu = 'SA',description = 'Sterlina sudanese',lt = {ts '2009-09-03 15:13:10.827'},lu = 'SA' WHERE idcurrency = '136'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('136','SDG',{ts '2009-09-03 15:13:10.827'},'SA','Sterlina sudanese',{ts '2009-09-03 15:13:10.827'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '137')
UPDATE [currency] SET codecurrency = 'SHP',ct = {ts '2009-09-03 15:13:47.017'},cu = 'SA',description = 'Sterlina di Sant''Elena',lt = {ts '2009-09-03 15:13:47.017'},lu = 'SA' WHERE idcurrency = '137'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('137','SHP',{ts '2009-09-03 15:13:47.017'},'SA','Sterlina di Sant''Elena',{ts '2009-09-03 15:13:47.017'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '138')
UPDATE [currency] SET codecurrency = 'SGD',ct = {ts '2009-09-03 15:14:28.767'},cu = 'SA',description = 'Dollaro di Singapore',lt = {ts '2009-09-03 15:14:28.767'},lu = 'SA' WHERE idcurrency = '138'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('138','SGD',{ts '2009-09-03 15:14:28.767'},'SA','Dollaro di Singapore',{ts '2009-09-03 15:14:28.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '139')
UPDATE [currency] SET codecurrency = 'SLL',ct = {ts '2009-09-03 15:14:49.610'},cu = 'SA',description = 'Leone della Sierra Leone',lt = {ts '2009-09-03 15:14:49.610'},lu = 'SA' WHERE idcurrency = '139'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('139','SLL',{ts '2009-09-03 15:14:49.610'},'SA','Leone della Sierra Leone',{ts '2009-09-03 15:14:49.610'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '140')
UPDATE [currency] SET codecurrency = 'SOS',ct = {ts '2009-09-03 15:15:01.767'},cu = 'SA',description = 'Scellino somalo',lt = {ts '2009-09-03 15:15:01.767'},lu = 'SA' WHERE idcurrency = '140'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('140','SOS',{ts '2009-09-03 15:15:01.767'},'SA','Scellino somalo',{ts '2009-09-03 15:15:01.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '141')
UPDATE [currency] SET codecurrency = 'SRD',ct = {ts '2009-09-03 15:15:17.797'},cu = 'SA',description = 'Dollaro surinamese',lt = {ts '2009-09-03 15:15:17.797'},lu = 'SA' WHERE idcurrency = '141'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('141','SRD',{ts '2009-09-03 15:15:17.797'},'SA','Dollaro surinamese',{ts '2009-09-03 15:15:17.797'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '142')
UPDATE [currency] SET codecurrency = 'STD',ct = {ts '2009-09-03 15:15:37.670'},cu = 'SA',description = 'Dobra di Sao Tomè e Principe',lt = {ts '2009-09-03 15:15:37.670'},lu = 'SA' WHERE idcurrency = '142'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('142','STD',{ts '2009-09-03 15:15:37.670'},'SA','Dobra di Sao Tomè e Principe',{ts '2009-09-03 15:15:37.670'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '143')
UPDATE [currency] SET codecurrency = 'SYP',ct = {ts '2009-09-03 15:16:16.233'},cu = 'SA',description = 'Lira siriana (o sterlina)',lt = {ts '2009-09-03 15:16:16.233'},lu = 'SA' WHERE idcurrency = '143'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('143','SYP',{ts '2009-09-03 15:16:16.233'},'SA','Lira siriana (o sterlina)',{ts '2009-09-03 15:16:16.233'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '144')
UPDATE [currency] SET codecurrency = 'SZL',ct = {ts '2009-09-03 15:16:32.657'},cu = 'SA',description = 'Lilangeni dello Swaziland',lt = {ts '2009-09-03 15:16:32.657'},lu = 'SA' WHERE idcurrency = '144'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('144','SZL',{ts '2009-09-03 15:16:32.657'},'SA','Lilangeni dello Swaziland',{ts '2009-09-03 15:16:32.657'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '145')
UPDATE [currency] SET codecurrency = 'THB',ct = {ts '2009-09-03 15:16:54.733'},cu = 'SA',description = 'Baht thailandese',lt = {ts '2009-09-03 15:16:54.733'},lu = 'SA' WHERE idcurrency = '145'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('145','THB',{ts '2009-09-03 15:16:54.733'},'SA','Baht thailandese',{ts '2009-09-03 15:16:54.733'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '146')
UPDATE [currency] SET codecurrency = 'TJS',ct = {ts '2009-09-03 15:17:07.610'},cu = 'SA',description = 'Somoni tagico',lt = {ts '2009-09-03 15:17:07.610'},lu = 'SA' WHERE idcurrency = '146'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('146','TJS',{ts '2009-09-03 15:17:07.610'},'SA','Somoni tagico',{ts '2009-09-03 15:17:07.610'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '147')
UPDATE [currency] SET codecurrency = 'TMM',ct = {ts '2009-09-03 15:17:18.000'},cu = 'SA',description = 'Manat turkmeno',lt = {ts '2009-09-03 15:17:18.000'},lu = 'SA' WHERE idcurrency = '147'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('147','TMM',{ts '2009-09-03 15:17:18.000'},'SA','Manat turkmeno',{ts '2009-09-03 15:17:18.000'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '148')
UPDATE [currency] SET codecurrency = 'TND',ct = {ts '2009-09-03 15:17:31.093'},cu = 'SA',description = 'Dinaro tunisino',lt = {ts '2009-09-03 15:17:31.093'},lu = 'SA' WHERE idcurrency = '148'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('148','TND',{ts '2009-09-03 15:17:31.093'},'SA','Dinaro tunisino',{ts '2009-09-03 15:17:31.093'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '149')
UPDATE [currency] SET codecurrency = 'TOP',ct = {ts '2009-09-03 15:17:52.030'},cu = 'SA',description = 'Pa anga tongano',lt = {ts '2009-09-03 15:17:52.030'},lu = 'SA' WHERE idcurrency = '149'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('149','TOP',{ts '2009-09-03 15:17:52.030'},'SA','Pa anga tongano',{ts '2009-09-03 15:17:52.030'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '150')
UPDATE [currency] SET codecurrency = 'TRY',ct = {ts '2009-09-03 15:18:04.360'},cu = 'SA',description = 'Nuova lira turca',lt = {ts '2009-09-03 15:18:04.360'},lu = 'SA' WHERE idcurrency = '150'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('150','TRY',{ts '2009-09-03 15:18:04.360'},'SA','Nuova lira turca',{ts '2009-09-03 15:18:04.360'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '151')
UPDATE [currency] SET codecurrency = 'TTD',ct = {ts '2009-09-03 15:18:21.110'},cu = 'SA',description = 'Dollaro di Trinidad e Tobago',lt = {ts '2009-09-03 15:18:21.110'},lu = 'SA' WHERE idcurrency = '151'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('151','TTD',{ts '2009-09-03 15:18:21.110'},'SA','Dollaro di Trinidad e Tobago',{ts '2009-09-03 15:18:21.110'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '152')
UPDATE [currency] SET codecurrency = 'TZS',ct = {ts '2009-09-03 15:18:35.767'},cu = 'SA',description = 'Scellino tanzaniano',lt = {ts '2009-09-03 15:18:35.767'},lu = 'SA' WHERE idcurrency = '152'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('152','TZS',{ts '2009-09-03 15:18:35.767'},'SA','Scellino tanzaniano',{ts '2009-09-03 15:18:35.767'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '153')
UPDATE [currency] SET codecurrency = 'UAH',ct = {ts '2009-09-03 15:18:52.217'},cu = 'SA',description = 'Grivnia ucraina',lt = {ts '2009-09-03 15:18:52.217'},lu = 'SA' WHERE idcurrency = '153'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('153','UAH',{ts '2009-09-03 15:18:52.217'},'SA','Grivnia ucraina',{ts '2009-09-03 15:18:52.217'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '154')
UPDATE [currency] SET codecurrency = 'UGX',ct = {ts '2009-09-03 15:19:07.093'},cu = 'SA',description = 'Scellino ugandese',lt = {ts '2009-09-03 15:19:07.093'},lu = 'SA' WHERE idcurrency = '154'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('154','UGX',{ts '2009-09-03 15:19:07.093'},'SA','Scellino ugandese',{ts '2009-09-03 15:19:07.093'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '155')
UPDATE [currency] SET codecurrency = 'UYU',ct = {ts '2009-09-03 15:19:26.797'},cu = 'SA',description = 'Peso uruguaiano',lt = {ts '2009-09-03 15:19:26.797'},lu = 'SA' WHERE idcurrency = '155'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('155','UYU',{ts '2009-09-03 15:19:26.797'},'SA','Peso uruguaiano',{ts '2009-09-03 15:19:26.797'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '156')
UPDATE [currency] SET codecurrency = 'UZS',ct = {ts '2009-09-03 15:19:40.390'},cu = 'SA',description = 'Som uzbeco',lt = {ts '2009-09-03 15:19:40.390'},lu = 'SA' WHERE idcurrency = '156'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('156','UZS',{ts '2009-09-03 15:19:40.390'},'SA','Som uzbeco',{ts '2009-09-03 15:19:40.390'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '157')
UPDATE [currency] SET codecurrency = 'VEB',ct = {ts '2009-09-03 15:19:57.047'},cu = 'SA',description = 'Bolivar venezuelano',lt = {ts '2009-09-03 15:19:57.047'},lu = 'SA' WHERE idcurrency = '157'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('157','VEB',{ts '2009-09-03 15:19:57.047'},'SA','Bolivar venezuelano',{ts '2009-09-03 15:19:57.047'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '158')
UPDATE [currency] SET codecurrency = 'VND',ct = {ts '2009-09-03 15:20:09.360'},cu = 'SA',description = 'Dong vietnamita',lt = {ts '2009-09-03 15:20:09.360'},lu = 'SA' WHERE idcurrency = '158'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('158','VND',{ts '2009-09-03 15:20:09.360'},'SA','Dong vietnamita',{ts '2009-09-03 15:20:09.360'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '159')
UPDATE [currency] SET codecurrency = 'VUV',ct = {ts '2009-09-03 15:20:24.127'},cu = 'SA',description = 'Vatu di Vanuatu',lt = {ts '2009-09-03 15:20:24.127'},lu = 'SA' WHERE idcurrency = '159'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('159','VUV',{ts '2009-09-03 15:20:24.127'},'SA','Vatu di Vanuatu',{ts '2009-09-03 15:20:24.127'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '160')
UPDATE [currency] SET codecurrency = 'WST',ct = {ts '2009-09-03 15:20:40.250'},cu = 'SA',description = 'Tala samoano',lt = {ts '2009-09-03 15:20:40.250'},lu = 'SA' WHERE idcurrency = '160'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('160','WST',{ts '2009-09-03 15:20:40.250'},'SA','Tala samoano',{ts '2009-09-03 15:20:40.250'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '161')
UPDATE [currency] SET codecurrency = 'XAF',ct = {ts '2009-09-03 15:20:55.110'},cu = 'SA',description = 'Franco CFA BEAC',lt = {ts '2009-09-03 15:20:55.110'},lu = 'SA' WHERE idcurrency = '161'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('161','XAF',{ts '2009-09-03 15:20:55.110'},'SA','Franco CFA BEAC',{ts '2009-09-03 15:20:55.110'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '162')
UPDATE [currency] SET codecurrency = 'XCD',ct = {ts '2009-09-03 15:21:22.703'},cu = 'SA',description = 'Dollaro dei Caraibi orientali',lt = {ts '2009-09-03 15:21:22.703'},lu = 'SA' WHERE idcurrency = '162'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('162','XCD',{ts '2009-09-03 15:21:22.703'},'SA','Dollaro dei Caraibi orientali',{ts '2009-09-03 15:21:22.703'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '163')
UPDATE [currency] SET codecurrency = 'XOF',ct = {ts '2009-09-03 15:21:58.953'},cu = 'SA',description = 'Franco CFA BCEAO',lt = {ts '2009-09-03 15:21:58.953'},lu = 'SA' WHERE idcurrency = '163'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('163','XOF',{ts '2009-09-03 15:21:58.953'},'SA','Franco CFA BCEAO',{ts '2009-09-03 15:21:58.953'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '164')
UPDATE [currency] SET codecurrency = 'XPF',ct = {ts '2009-09-03 15:22:11.843'},cu = 'SA',description = 'Franco CFP',lt = {ts '2009-09-03 15:22:11.843'},lu = 'SA' WHERE idcurrency = '164'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('164','XPF',{ts '2009-09-03 15:22:11.843'},'SA','Franco CFP',{ts '2009-09-03 15:22:11.843'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '165')
UPDATE [currency] SET codecurrency = 'YER',ct = {ts '2009-09-03 15:22:23.390'},cu = 'SA',description = 'Rial yemenita',lt = {ts '2009-09-03 15:22:23.390'},lu = 'SA' WHERE idcurrency = '165'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('165','YER',{ts '2009-09-03 15:22:23.390'},'SA','Rial yemenita',{ts '2009-09-03 15:22:23.390'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '166')
UPDATE [currency] SET codecurrency = 'ZAR',ct = {ts '2009-09-03 15:22:35.017'},cu = 'SA',description = 'Rand sudafricano',lt = {ts '2009-09-03 15:22:35.017'},lu = 'SA' WHERE idcurrency = '166'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('166','ZAR',{ts '2009-09-03 15:22:35.017'},'SA','Rand sudafricano',{ts '2009-09-03 15:22:35.017'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '167')
UPDATE [currency] SET codecurrency = 'ZMK',ct = {ts '2009-09-03 15:22:49.467'},cu = 'SA',description = 'Kwacha zambiano',lt = {ts '2009-09-03 15:22:49.467'},lu = 'SA' WHERE idcurrency = '167'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('167','ZMK',{ts '2009-09-03 15:22:49.467'},'SA','Kwacha zambiano',{ts '2009-09-03 15:22:49.467'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '168')
UPDATE [currency] SET codecurrency = 'ZWL',ct = {ts '2009-09-03 15:23:05.920'},cu = 'SA',description = 'Dollaro zimbabwiano',lt = {ts '2009-09-03 15:23:05.920'},lu = 'SA' WHERE idcurrency = '168'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('168','ZWL',{ts '2009-09-03 15:23:05.920'},'SA','Dollaro zimbabwiano',{ts '2009-09-03 15:23:05.920'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '169')
UPDATE [currency] SET codecurrency = 'LIT',ct = {ts '2009-09-03 15:42:17.907'},cu = 'SA',description = 'LIT',lt = {ts '2009-09-03 15:42:17.907'},lu = 'SA' WHERE idcurrency = '169'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('169','LIT',{ts '2009-09-03 15:42:17.907'},'SA','LIT',{ts '2009-09-03 15:42:17.907'},'SA')
GO

IF exists(SELECT * FROM [currency] WHERE idcurrency = '170')
UPDATE [currency] SET codecurrency = 'TWN',ct = {ts '2018-12-13 09:49:59.353'},cu = 'assistenza14',description = 'Dollaro taiwan',lt = {ts '2018-12-13 09:49:59.353'},lu = 'assistenza14' WHERE idcurrency = '170'
ELSE
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('170','TWN',{ts '2018-12-13 09:49:59.353'},'assistenza14','Dollaro taiwan',{ts '2018-12-13 09:49:59.353'},'assistenza14')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'currency')
UPDATE [tabledescr] SET description = 'Valuta',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:48:16.280'},lu = 'assistenza',title = 'Valuta' WHERE tablename = 'currency'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('currency','Valuta','3','S',{ts '2021-02-19 17:48:16.280'},'assistenza','Valuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codecurrency' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice valuta (tabella currency)',kind = 'S',lt = {ts '1900-01-01 03:00:15.183'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codecurrency' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codecurrency','currency','20',null,null,'Codice valuta (tabella currency)','S',{ts '1900-01-01 03:00:15.183'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.793'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','currency','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.793'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.227'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','currency','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.227'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.693'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','currency','50',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.693'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Chiave valuta (tab. currency)',kind = 'S',lt = {ts '1900-01-01 03:00:12.207'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','currency','4',null,null,'Chiave valuta (tab. currency)','S',{ts '1900-01-01 03:00:12.207'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.350'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','currency','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.350'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','currency','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.380'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

