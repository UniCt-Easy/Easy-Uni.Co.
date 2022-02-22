
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


-- CREAZIONE TABELLA naturagiur --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[naturagiur]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[naturagiur] (
idnaturagiur int NOT NULL,
active char(1) NOT NULL,
flagforeign char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title nvarchar(200) NOT NULL,
 CONSTRAINT xpknaturagiur PRIMARY KEY (idnaturagiur
)
)
END
GO

-- VERIFICA STRUTTURA naturagiur --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'idnaturagiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD idnaturagiur int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'idnaturagiur' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'flagforeign' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD flagforeign char(1) NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN flagforeign char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD title nvarchar(200) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN title nvarchar(200) NOT NULL
GO

-- VERIFICA DI naturagiur IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'naturagiur'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiur','int','assistenza','idnaturagiur','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiur','char(1)','assistenza','active','1','S','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiur','char(1)','assistenza','flagforeign','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiur','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','naturagiur','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiur','int','assistenza','sortcode','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','naturagiur','nvarchar(200)','assistenza','title','200','S','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI naturagiur IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'naturagiur')
UPDATE customobject set isreal = 'S' where objectname = 'naturagiur'
ELSE
INSERT INTO customobject (objectname, isreal) values('naturagiur', 'S')
GO

-- GENERAZIONE DATI PER naturagiur --
IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '1')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Associazioni fra artisti e professionisti' WHERE idnaturagiur = '1'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('1','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Associazioni fra artisti e professionisti')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '2')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Associazioni non riconosciute e comitati' WHERE idnaturagiur = '2'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('2','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Associazioni non riconosciute e comitati')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '3')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Associazioni riconosciute' WHERE idnaturagiur = '3'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('3','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Associazioni riconosciute')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '4')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Aziende autonome di cura, soggiorno e turismo' WHERE idnaturagiur = '4'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('4','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Aziende autonome di cura, soggiorno e turismo')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '5')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '5',title = 'Aziende coniugali' WHERE idnaturagiur = '5'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('5','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Aziende coniugali')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '6')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '6',title = 'Aziende regionali, provinciali, comunali e loro consorzi' WHERE idnaturagiur = '6'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('6','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Aziende regionali, provinciali, comunali e loro consorzi')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '7')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '7',title = 'Casse mutue e fondi di previdenza, assistenza, pensioni o simili con o senza personalità giuridica' WHERE idnaturagiur = '7'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('7','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Casse mutue e fondi di previdenza, assistenza, pensioni o simili con o senza personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '8')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '8',title = 'Consorzi con personalità giuridica' WHERE idnaturagiur = '8'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('8','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','8','Consorzi con personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '9')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '9',title = 'Consorzi senza personalità giuridica' WHERE idnaturagiur = '9'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('9','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','9','Consorzi senza personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '10')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '10',title = 'Enti ed istituti di previdenza e di assistenza sociale' WHERE idnaturagiur = '10'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('10','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','10','Enti ed istituti di previdenza e di assistenza sociale')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '11')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '11',title = 'Enti ospedalieri' WHERE idnaturagiur = '11'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('11','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','11','Enti ospedalieri')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '12')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '12',title = 'Enti pubblici economici' WHERE idnaturagiur = '12'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('12','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','12','Enti pubblici economici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '13')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '13',title = 'Enti pubblici non economici' WHERE idnaturagiur = '13'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('13','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','13','Enti pubblici non economici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '14')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '14',title = 'Fondazioni' WHERE idnaturagiur = '14'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('14','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','14','Fondazioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '15')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '15',title = 'GEIE' WHERE idnaturagiur = '15'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('15','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','15','GEIE')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '16')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '16',title = 'Mutue assicuratrici' WHERE idnaturagiur = '16'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('16','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','16','Mutue assicuratrici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '17')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '17',title = 'Opere pie e società di mutuo soccorso' WHERE idnaturagiur = '17'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('17','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','17','Opere pie e società di mutuo soccorso')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '18')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '18',title = 'Società a responsabilità limitata' WHERE idnaturagiur = '18'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('18','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','18','Società a responsabilità limitata')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '19')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '19',title = 'Società cooperative e loro consorzi iscritti nei registri prefettizi o nello schedario generale della cooperazione' WHERE idnaturagiur = '19'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('19','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','19','Società cooperative e loro consorzi iscritti nei registri prefettizi o nello schedario generale della cooperazione')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '20')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '20',title = 'Società di armamento' WHERE idnaturagiur = '20'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('20','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','20','Società di armamento')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '21')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '21',title = 'Società in accomandita per azioni' WHERE idnaturagiur = '21'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('21','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','21','Società in accomandita per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '22')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '22',title = 'Società in accomandita semplice' WHERE idnaturagiur = '22'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('22','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','22','Società in accomandita semplice')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '23')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '23',title = 'Società in nome collettivo ed equiparate' WHERE idnaturagiur = '23'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('23','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','23','Società in nome collettivo ed equiparate')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '24')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '24',title = 'Società per azioni' WHERE idnaturagiur = '24'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('24','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','24','Società per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '25')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '25',title = 'Società per azioni, aziende speciali e consorzi di cui agli artt. 23, 25 e 60 della legge 8 giugno 1990, n. 142' WHERE idnaturagiur = '25'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('25','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','25','Società per azioni, aziende speciali e consorzi di cui agli artt. 23, 25 e 60 della legge 8 giugno 1990, n. 142')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '26')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '26',title = 'Società semplici ed equiparate ai sensi dell''art. 5, comma 3, lett. b, del Tuir' WHERE idnaturagiur = '26'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('26','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','26','Società semplici ed equiparate ai sensi dell''art. 5, comma 3, lett. b, del Tuir')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '27')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '27',title = 'Società, organizzazioni ed enti costituiti all''estero non altrimenti classificabili con sede dell''amministrazione od oggetto principale in Italia' WHERE idnaturagiur = '27'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('27','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','27','Società, organizzazioni ed enti costituiti all''estero non altrimenti classificabili con sede dell''amministrazione od oggetto principale in Italia')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '28')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '28',title = 'Altre organizzazioni di persone o di beni senza personalità giuridica (escluse le comunioni)' WHERE idnaturagiur = '28'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('28','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','28','Altre organizzazioni di persone o di beni senza personalità giuridica (escluse le comunioni)')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '29')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '29',title = 'Altre società cooperative' WHERE idnaturagiur = '29'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('29','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','29','Altre società cooperative')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '30')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '30',title = 'Altri enti ed istituti con personalità giuridica' WHERE idnaturagiur = '30'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('30','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','30','Altri enti ed istituti con personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '31')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Associazioni fra professionisti' WHERE idnaturagiur = '31'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('31','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Associazioni fra professionisti')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '32')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Associazioni riconosciute, non riconosciute e di fatto' WHERE idnaturagiur = '32'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('32','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Associazioni riconosciute, non riconosciute e di fatto')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '33')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Consorzi' WHERE idnaturagiur = '33'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('33','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Consorzi')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '34')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Fondazioni' WHERE idnaturagiur = '34'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('34','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Fondazioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '35')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '5',title = 'Opere pie e società di mutuo soccorso' WHERE idnaturagiur = '35'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('35','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Opere pie e società di mutuo soccorso')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '36')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '6',title = 'Società a responsabilità limitata' WHERE idnaturagiur = '36'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('36','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Società a responsabilità limitata')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '37')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '7',title = 'Società di armamento' WHERE idnaturagiur = '37'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('37','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Società di armamento')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '38')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '8',title = 'Società in accomandita per azioni' WHERE idnaturagiur = '38'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('38','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','8','Società in accomandita per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '39')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '9',title = 'Società in accomandita semplice' WHERE idnaturagiur = '39'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('39','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','9','Società in accomandita semplice')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '40')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '10',title = 'Società in nome collettivo' WHERE idnaturagiur = '40'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('40','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','10','Società in nome collettivo')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '41')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '11',title = 'Società per azioni' WHERE idnaturagiur = '41'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('41','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','11','Società per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '42')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '12',title = 'Società semplici irregolari e di fatto' WHERE idnaturagiur = '42'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('42','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','12','Società semplici irregolari e di fatto')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '43')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '13',title = 'Altre organizzazioni di persone e di beni' WHERE idnaturagiur = '43'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('43','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','13','Altre organizzazioni di persone e di beni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '44')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '14',title = 'Altri enti ed istituti' WHERE idnaturagiur = '44'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('44','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','14','Altri enti ed istituti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'naturagiur')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle nature giuridiche',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-17 17:36:47.457'},lu = 'assistenza',title = 'VOCABOLARIO delle nature giuridiche' WHERE tablename = 'naturagiur'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('naturagiur','VOCABOLARIO delle nature giuridiche','2','S',{ts '2018-07-17 17:36:47.457'},'assistenza','VOCABOLARIO delle nature giuridiche')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-26 17:02:39.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','naturagiur','1',null,null,null,'S',{ts '2021-08-26 17:02:39.907'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagforeign' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:36:50.227'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagforeign' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagforeign','naturagiur','1',null,null,null,'S',{ts '2018-07-17 17:36:50.227'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnaturagiur' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:36:50.227'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnaturagiur' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnaturagiur','naturagiur','4',null,null,null,'S',{ts '2018-07-17 17:36:50.227'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-26 17:02:39.903'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','naturagiur','8',null,null,null,'S',{ts '2021-08-26 17:02:39.903'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-26 17:02:39.903'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','naturagiur','64',null,null,null,'S',{ts '2021-08-26 17:02:39.903'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:36:50.227'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','naturagiur','4',null,null,null,'S',{ts '2018-07-17 17:36:50.227'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'naturagiur')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:36:50.227'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(200)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'naturagiur'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','naturagiur','200',null,null,null,'S',{ts '2018-07-17 17:36:50.227'},'assistenza','N','nvarchar(200)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

