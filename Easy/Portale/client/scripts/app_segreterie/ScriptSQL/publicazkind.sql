
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


-- CREAZIONE TABELLA publicazkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicazkind] (
idpublicazkind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
subtitle varchar(256) NULL,
title varchar(50) NULL,
 CONSTRAINT xpkpublicazkind PRIMARY KEY (idpublicazkind
)
)
END
GO

-- VERIFICA STRUTTURA publicazkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'idpublicazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD idpublicazkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'idpublicazkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'subtitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD subtitle varchar(256) NULL 
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN subtitle varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazkind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [publicazkind] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI publicazkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','int','ASSISTENZA','idpublicazkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazkind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkind','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkind','varchar(256)','ASSISTENZA','subtitle','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','publicazkind','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI publicazkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazkind')
UPDATE customobject set isreal = 'S' where objectname = 'publicazkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazkind', 'S')
GO

-- GENERAZIONE DATI PER publicazkind --
IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '1')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',subtitle = 'Altro (presentazioni, prefazioni o simili)',title = 'Libri' WHERE idpublicazkind = '1'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Altro (presentazioni, prefazioni o simili)','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '2')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',subtitle = 'Bibliografie, repertori, glossari',title = 'Libri' WHERE idpublicazkind = '2'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Bibliografie, repertori, glossari','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '3')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',subtitle = 'Cura editoriale di volume',title = 'Libri' WHERE idpublicazkind = '3'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Cura editoriale di volume','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '4')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',subtitle = 'Contributo in volume miscellaneo di carattere scientifico (scritti in onore di ecc.)',title = 'Libri' WHERE idpublicazkind = '4'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Contributo in volume miscellaneo di carattere scientifico (scritti in onore di ecc.)','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '5')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',subtitle = 'Contributo in volume miscellaneo di carattere didattico-divulgativo',title = 'Libri' WHERE idpublicazkind = '5'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Contributo in volume miscellaneo di carattere didattico-divulgativo','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '6')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',subtitle = 'Edizione critica di opera compiuta',title = 'Libri' WHERE idpublicazkind = '6'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Edizione critica di opera compiuta','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '7')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',subtitle = 'Edizione critica di parte di opera (massimo 3)',title = 'Libri' WHERE idpublicazkind = '7'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Edizione critica di parte di opera (massimo 3)','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '8')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',subtitle = 'Traduzione opera letteraria completa',title = 'Libri' WHERE idpublicazkind = '8'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','8','Traduzione opera letteraria completa','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '9')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',subtitle = 'Traduzione di parti di opera letteraria (massimo 3)',title = 'Libri' WHERE idpublicazkind = '9'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Traduzione di parti di opera letteraria (massimo 3)','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '10')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '10',subtitle = 'Manuale o commento didattico',title = 'Libri' WHERE idpublicazkind = '10'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('10','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','10','Manuale o commento didattico','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '11')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '11',subtitle = 'Monografia o trattato scientifico',title = 'Libri' WHERE idpublicazkind = '11'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('11','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','11','Monografia o trattato scientifico','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '12')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '12',subtitle = 'Commentari giuridici',title = 'Libri' WHERE idpublicazkind = '12'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('12','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','12','Commentari giuridici','Libri')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '13')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '13',subtitle = 'Articolo',title = 'Articolo su rivista o giornale' WHERE idpublicazkind = '13'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('13','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','13','Articolo','Articolo su rivista o giornale')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '14')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '14',subtitle = 'Editoriale',title = 'Articolo su rivista o giornale' WHERE idpublicazkind = '14'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('14','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','14','Editoriale','Articolo su rivista o giornale')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '15')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '15',subtitle = 'Recensione',title = 'Articolo su rivista o giornale' WHERE idpublicazkind = '15'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('15','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','15','Recensione','Articolo su rivista o giornale')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '16')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '16',subtitle = 'Rassegna critica e schede bibliografiche',title = 'Articolo su rivista o giornale' WHERE idpublicazkind = '16'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('16','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','16','Rassegna critica e schede bibliografiche','Articolo su rivista o giornale')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '17')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '17',subtitle = 'Altro (p.es. cura editoriale di atti di convegno)',title = 'Articolo su rivista o giornale' WHERE idpublicazkind = '17'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('17','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','17','Altro (p.es. cura editoriale di atti di convegno)','Articolo su rivista o giornale')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '18')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '18',subtitle = 'Relazione o contributo a convegno',title = 'Atti' WHERE idpublicazkind = '18'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('18','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','18','Relazione o contributo a convegno','Atti')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '19')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '19',subtitle = 'Sintesi di intervento o abstract',title = 'Atti' WHERE idpublicazkind = '19'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('19','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','19','Sintesi di intervento o abstract','Atti')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '20')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '20',subtitle = 'Altro (p.es. cura editoriale di atti di convegno)',title = 'Atti' WHERE idpublicazkind = '20'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('20','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','20','Altro (p.es. cura editoriale di atti di convegno)','Atti')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '21')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '21',subtitle = 'Editoria telematica',title = 'Altro' WHERE idpublicazkind = '21'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('21','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','21','Editoria telematica','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '22')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '22',subtitle = 'Repertorio',title = 'Altro' WHERE idpublicazkind = '22'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('22','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','22','Repertorio','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '23')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '23',subtitle = 'Scheda di catalogo',title = 'Altro' WHERE idpublicazkind = '23'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('23','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','23','Scheda di catalogo','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '24')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '24',subtitle = 'Voce di dizionario ed enciclopedia',title = 'Altro' WHERE idpublicazkind = '24'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('24','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','24','Voce di dizionario ed enciclopedia','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '25')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '25',subtitle = 'Working papers o technical report',title = 'Altro' WHERE idpublicazkind = '25'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('25','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','25','Working papers o technical report','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '26')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '26',subtitle = 'Brevetti',title = 'Altro' WHERE idpublicazkind = '26'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('26','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','26','Brevetti','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '27')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '27',subtitle = 'Protein data bank',title = 'Altro' WHERE idpublicazkind = '27'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('27','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','27','Protein data bank','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '28')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '28',subtitle = 'Nota sentenze',title = 'Altro' WHERE idpublicazkind = '28'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('28','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','28','Nota sentenze','Altro')
GO

IF exists(SELECT * FROM [publicazkind] WHERE idpublicazkind = '29')
UPDATE [publicazkind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '29',subtitle = 'Altro (p.es. quaderni di dipartimento)',title = 'Altro' WHERE idpublicazkind = '29'
ELSE
INSERT INTO [publicazkind] (idpublicazkind,active,ct,cu,lt,lu,sortcode,subtitle,title) VALUES ('29','S',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','29','Altro (p.es. quaderni di dipartimento)','Altro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicazkind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile dagli utenti delle tipologie di 2.4.27 pubblicazione ',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:55:51.463'},lu = 'assistenza',title = 'Tipologie di pubblicazione ' WHERE tablename = 'publicazkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicazkind','VOCABOLARIO modificabile dagli utenti delle tipologie di 2.4.27 pubblicazione ','3','S',{ts '2021-02-19 17:55:51.463'},'assistenza','Tipologie di pubblicazione ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','publicazkind','1',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicazkind','8',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicazkind','64',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicazkind' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicazkind' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicazkind','publicazkind','4',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicazkind','8',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicazkind','64',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','publicazkind','4',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'subtitle' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Sotto-tipologia',kind = 'S',lt = {ts '2019-02-28 19:18:22.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'subtitle' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('subtitle','publicazkind','50',null,null,'Sotto-tipologia','S',{ts '2019-02-28 19:18:22.440'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'publicazkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:09:45.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'publicazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','publicazkind','50',null,null,null,'S',{ts '2018-07-17 17:09:45.727'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

