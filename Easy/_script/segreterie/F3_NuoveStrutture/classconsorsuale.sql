
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


--[DBO]--
-- CREAZIONE TABELLA classconsorsuale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classconsorsuale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classconsorsuale] (
idclassconsorsuale int NOT NULL,
active char(1) NOT NULL,
ambitodisci varchar(50) NULL,
corr2592017 varchar(50) NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
normativa varchar(50) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkclassconsorsuale PRIMARY KEY (idclassconsorsuale
)
)
END
GO

-- VERIFICA STRUTTURA classconsorsuale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'idclassconsorsuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD idclassconsorsuale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classconsorsuale') and col.name = 'idclassconsorsuale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classconsorsuale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classconsorsuale') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classconsorsuale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'ambitodisci' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD ambitodisci varchar(50) NULL 
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN ambitodisci varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'corr2592017' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD corr2592017 varchar(50) NULL 
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN corr2592017 varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD description varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classconsorsuale') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classconsorsuale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN description varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'normativa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD normativa varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classconsorsuale') and col.name = 'normativa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classconsorsuale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN normativa varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classconsorsuale' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classconsorsuale] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classconsorsuale') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classconsorsuale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classconsorsuale] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI classconsorsuale IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'classconsorsuale'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classconsorsuale','int','ASSISTENZA','idclassconsorsuale','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classconsorsuale','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classconsorsuale','varchar(50)','ASSISTENZA','ambitodisci','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classconsorsuale','varchar(50)','ASSISTENZA','corr2592017','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classconsorsuale','varchar(512)','ASSISTENZA','description','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classconsorsuale','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classconsorsuale','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classconsorsuale','varchar(50)','ASSISTENZA','normativa','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classconsorsuale','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI classconsorsuale IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'classconsorsuale')
UPDATE customobject set isreal = 'S' where objectname = 'classconsorsuale'
ELSE
INSERT INTO customobject (objectname, isreal) values('classconsorsuale', 'S')
GO

-- GENERAZIONE DATI PER classconsorsuale --
IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '1')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Anatomia, fisiopatologia oculare e laboratorio di misure oftalmiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '2/A' WHERE idclassconsorsuale = '1'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('1','N',null,null,'Anatomia, fisiopatologia oculare e laboratorio di misure oftalmiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','2/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '2')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte del disegno animato',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '3/A' WHERE idclassconsorsuale = '2'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('2','N',null,null,'Arte del disegno animato',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','3/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '3')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-05',description = 'Arte del tessuto, della moda e del costume',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '4/A' WHERE idclassconsorsuale = '3'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('3','N',null,'A-05','Arte del tessuto, della moda e del costume',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','4/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '4')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte del vetro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '5/A' WHERE idclassconsorsuale = '4'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('4','N',null,null,'Arte del vetro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','5/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '5')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-03',description = 'Arte della ceramica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '6/A' WHERE idclassconsorsuale = '5'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('5','N',null,'A-03','Arte della ceramica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','6/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '6')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della fotografia e della grafica pubblicitaria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '7/A' WHERE idclassconsorsuale = '6'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('6','N',null,null,'Arte della fotografia e della grafica pubblicitaria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','7/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '7')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della grafica e della incisione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '8/A' WHERE idclassconsorsuale = '7'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('7','N',null,null,'Arte della grafica e della incisione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','8/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '8')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-04',description = 'Arte della stampa e del restauro del libro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '9/A' WHERE idclassconsorsuale = '8'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('8','N',null,'A-04','Arte della stampa e del restauro del libro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','9/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '9')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-02',description = 'Arte dei metalli e della oreficeria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '10/A' WHERE idclassconsorsuale = '9'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('9','N',null,'A-02','Arte dei metalli e della oreficeria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','10/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '10')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte mineraria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '11/A' WHERE idclassconsorsuale = '10'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('10','N',null,null,'Arte mineraria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','11/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '11')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Chimica agraria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '12/A' WHERE idclassconsorsuale = '11'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('11','N',null,null,'Chimica agraria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','12/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '12')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Chimica e tecnologie chimiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '13/A' WHERE idclassconsorsuale = '12'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('12','N',null,null,'Chimica e tecnologie chimiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','13/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '13')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Circolazione aerea, telecomunicazioni aeronautiche ed esercitazioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '14/A' WHERE idclassconsorsuale = '13'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('13','N',null,null,'Circolazione aerea, telecomunicazioni aeronautiche ed esercitazioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','14/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '14')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Costruzioni navali e teoria della nave',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '15/A' WHERE idclassconsorsuale = '14'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('14','N',null,null,'Costruzioni navali e teoria della nave',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','15/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '15')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Costruzioni, tecnologia delle costruzioni e disegno tecnico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '16/A' WHERE idclassconsorsuale = '15'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('15','N',null,null,'Costruzioni, tecnologia delle costruzioni e disegno tecnico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','16/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '16')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline economico-aziendali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '17/A' WHERE idclassconsorsuale = '16'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('16','N',null,null,'Discipline economico-aziendali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','17/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '17')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline geometriche, architettoniche, arredamento e scenotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '18/A' WHERE idclassconsorsuale = '17'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('17','N',null,null,'Discipline geometriche, architettoniche, arredamento e scenotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','18/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '18')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline giuridiche ed economiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '19/A' WHERE idclassconsorsuale = '18'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('18','N',null,null,'Discipline giuridiche ed economiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','19/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '19')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline meccaniche e tecnologia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '20/A' WHERE idclassconsorsuale = '19'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('19','N',null,null,'Discipline meccaniche e tecnologia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','20/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '20')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline pittoriche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '21/A' WHERE idclassconsorsuale = '20'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('20','N',null,null,'Discipline pittoriche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','21/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '21')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Discipline plastiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '22/A' WHERE idclassconsorsuale = '21'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('21','N',null,null,'Discipline plastiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','22/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '22')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Disegno e modellazione odontotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '23/A' WHERE idclassconsorsuale = '22'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('22','N',null,null,'Disegno e modellazione odontotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','23/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '23')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Disegno e storia del costume',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '24/A' WHERE idclassconsorsuale = '23'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('23','N',null,null,'Disegno e storia del costume',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','24/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '24')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '1',corr2592017 = null,description = 'Disegno e storia dell''arte',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '25/A' WHERE idclassconsorsuale = '24'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('24','N','1',null,'Disegno e storia dell''arte',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','25/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '25')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Disegno tecnico ed artistico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '27/A' WHERE idclassconsorsuale = '25'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('25','N',null,null,'Disegno tecnico ed artistico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','27/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '26')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-01',description = 'Educazione artistica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '28/A' WHERE idclassconsorsuale = '26'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('26','N',null,'A-01','Educazione artistica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','28/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '27')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '2',corr2592017 = null,description = 'Educazione fisica negli istituti e scuole di istruzione secondaria di secondo grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '29/A' WHERE idclassconsorsuale = '27'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('27','N','2',null,'Educazione fisica negli istituti e scuole di istruzione secondaria di secondo grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','29/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '28')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '2',corr2592017 = null,description = 'Educazione fisica nella scuola media',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '30/A' WHERE idclassconsorsuale = '28'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('28','N','2',null,'Educazione fisica nella scuola media',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','30/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '29')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '3',corr2592017 = null,description = 'Educazione musicale negli istituti e scuole di istruzione secondaria di secondo grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '31/A' WHERE idclassconsorsuale = '29'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('29','N','3',null,'Educazione musicale negli istituti e scuole di istruzione secondaria di secondo grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','31/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '30')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '3',corr2592017 = null,description = 'Educazione musicale nella scuola media',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '32/A' WHERE idclassconsorsuale = '30'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('30','N','3',null,'Educazione musicale nella scuola media',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','32/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '31')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Educazione tecnica nella scuola media',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '33/A' WHERE idclassconsorsuale = '31'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('31','N',null,null,'Educazione tecnica nella scuola media',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','33/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '32')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Elettronica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '34/A' WHERE idclassconsorsuale = '32'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('32','N',null,null,'Elettronica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','34/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '33')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Elettrotecnica ed applicazioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '35/A' WHERE idclassconsorsuale = '33'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('33','N',null,null,'Elettrotecnica ed applicazioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','35/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '34')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '7',corr2592017 = null,description = 'Filosofia, psicologia e scienze dell''educazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '36/A' WHERE idclassconsorsuale = '34'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('34','N','7',null,'Filosofia, psicologia e scienze dell''educazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','36/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '35')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '7',corr2592017 = null,description = 'Filosofia e storia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '37/A' WHERE idclassconsorsuale = '35'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('35','N','7',null,'Filosofia e storia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','37/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '36')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '8',corr2592017 = null,description = 'Fisica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '38/A' WHERE idclassconsorsuale = '36'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('36','N','8',null,'Fisica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','38/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '37')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Geografia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '39/A' WHERE idclassconsorsuale = '37'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('37','N',null,null,'Geografia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','39/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '38')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Igiene, anatomia, fisiologia, patologia generale e dell''apparato masticatorio',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '40/A' WHERE idclassconsorsuale = '38'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('38','N',null,null,'Igiene, anatomia, fisiologia, patologia generale e dell''apparato masticatorio',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','40/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '39')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Informatica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '42/A' WHERE idclassconsorsuale = '39'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('39','N',null,null,'Informatica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','42/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '40')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '4 9',corr2592017 = null,description = 'Italiano, storia ed educazione civica, geografia nella scuola media',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '43/A' WHERE idclassconsorsuale = '40'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('40','N','4 9',null,'Italiano, storia ed educazione civica, geografia nella scuola media',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','43/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '41')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Linguaggio per la cinematografia e la televisione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '44/A' WHERE idclassconsorsuale = '41'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('41','N',null,null,'Linguaggio per la cinematografia e la televisione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','44/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '42')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '5',corr2592017 = null,description = 'Lingua straniera',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '45/A' WHERE idclassconsorsuale = '42'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('42','N','5',null,'Lingua straniera',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','45/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '43')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '5',corr2592017 = null,description = 'Lingue e civiltà straniere',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '46/A' WHERE idclassconsorsuale = '43'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('43','N','5',null,'Lingue e civiltà straniere',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','46/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '44')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '8',corr2592017 = null,description = 'Matematica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '47/A' WHERE idclassconsorsuale = '44'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('44','N','8',null,'Matematica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','47/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '45')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Matematica applicata',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '48/A' WHERE idclassconsorsuale = '45'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('45','N',null,null,'Matematica applicata',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','48/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '46')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '8',corr2592017 = null,description = 'Matematica e fisica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '49/A' WHERE idclassconsorsuale = '46'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('46','N','8',null,'Matematica e fisica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','49/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '47')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '4 9',corr2592017 = null,description = 'Materie letterarie negli istituti di istruzione secondaria di secondo grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '50/A' WHERE idclassconsorsuale = '47'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('47','N','4 9',null,'Materie letterarie negli istituti di istruzione secondaria di secondo grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','50/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '48')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '9',corr2592017 = null,description = 'Materie letterarie e latino nei licei e nell''istituto magistrale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '51/A' WHERE idclassconsorsuale = '48'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('48','N','9',null,'Materie letterarie e latino nei licei e nell''istituto magistrale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','51/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '49')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '9',corr2592017 = null,description = 'Materie letterarie, latino e greco nel liceo classico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '52/A' WHERE idclassconsorsuale = '49'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('49','N','9',null,'Materie letterarie, latino e greco nel liceo classico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','52/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '50')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Meteorologia aeronautica ed esercitazioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '53/A' WHERE idclassconsorsuale = '50'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('50','N',null,null,'Meteorologia aeronautica ed esercitazioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','53/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '51')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Mineralogia e geologia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '54/A' WHERE idclassconsorsuale = '51'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('51','N',null,null,'Mineralogia e geologia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','54/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '52')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Navigazione aerea ed esercitazioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '55/A' WHERE idclassconsorsuale = '52'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('52','N',null,null,'Navigazione aerea ed esercitazioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','55/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '53')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Navigazione, arte navale ed elementi di costruzioni navali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '56/A' WHERE idclassconsorsuale = '53'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('53','N',null,null,'Navigazione, arte navale ed elementi di costruzioni navali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','56/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '54')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Scienza degli alimenti',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '57/A' WHERE idclassconsorsuale = '54'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('54','N',null,null,'Scienza degli alimenti',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','57/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '55')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Scienze e meccanica agraria e tecniche di gestione aziendale, fitopatologia ed entomologia agraria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '58/A' WHERE idclassconsorsuale = '55'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('55','N',null,null,'Scienze e meccanica agraria e tecniche di gestione aziendale, fitopatologia ed entomologia agraria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','58/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '56')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Scienze matematiche, chimiche, fisiche e naturali nella scuola media',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '59/A' WHERE idclassconsorsuale = '56'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('56','N',null,null,'Scienze matematiche, chimiche, fisiche e naturali nella scuola media',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','59/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '57')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Scienze naturali, chimica e geografia, microbiologia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '60/A' WHERE idclassconsorsuale = '57'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('57','N',null,null,'Scienze naturali, chimica e geografia, microbiologia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','60/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '58')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Storia dell''arte',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '61/A' WHERE idclassconsorsuale = '58'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('58','N',null,null,'Storia dell''arte',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','61/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '59')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnica della registrazione del suono',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '62/A' WHERE idclassconsorsuale = '59'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('59','N',null,null,'Tecnica della registrazione del suono',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','62/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '60')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnica della ripresa cinematografica e televisiva',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '63/A' WHERE idclassconsorsuale = '60'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('60','N',null,null,'Tecnica della ripresa cinematografica e televisiva',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','63/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '61')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnica e organizzazione della produzione cinematografica e televisiva',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '64/A' WHERE idclassconsorsuale = '61'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('61','N',null,null,'Tecnica e organizzazione della produzione cinematografica e televisiva',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','64/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '62')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnica fotografica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '65/A' WHERE idclassconsorsuale = '62'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('62','N',null,null,'Tecnica fotografica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','65/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '63')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologia ceramica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '66/A' WHERE idclassconsorsuale = '63'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('63','N',null,null,'Tecnologia ceramica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','66/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '64')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologia fotografica, cinematografica e televisiva',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '67/A' WHERE idclassconsorsuale = '64'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('64','N',null,null,'Tecnologia fotografica, cinematografica e televisiva',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','67/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '65')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologie dell''abbigliamento',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '68/A' WHERE idclassconsorsuale = '65'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('65','N',null,null,'Tecnologie dell''abbigliamento',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','68/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '66')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologie grafiche ed impianti grafici',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '69/A' WHERE idclassconsorsuale = '66'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('66','N',null,null,'Tecnologie grafiche ed impianti grafici',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','69/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '67')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologie tessili',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '70/A' WHERE idclassconsorsuale = '67'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('67','N',null,null,'Tecnologie tessili',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','70/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '68')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tecnologie e disegno tecnico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '71/A' WHERE idclassconsorsuale = '68'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('68','N',null,null,'Tecnologie e disegno tecnico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','71/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '69')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Topografia generale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '72/A' WHERE idclassconsorsuale = '69'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('69','N',null,null,'Topografia generale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','72/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '70')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Vita di relazione negli istituti professionali di Stato per non vedenti',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '73/A' WHERE idclassconsorsuale = '70'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('70','N',null,null,'Vita di relazione negli istituti professionali di Stato per non vedenti',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','73/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '71')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Zootecnica e scienza della produzione animale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '74/A' WHERE idclassconsorsuale = '71'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('71','N',null,null,'Zootecnica e scienza della produzione animale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','74/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '72')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '6',corr2592017 = null,description = 'Dattilografia e stenografia, trattamento testi e dati',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '75/A' WHERE idclassconsorsuale = '72'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('72','N','6',null,'Dattilografia e stenografia, trattamento testi e dati',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','75/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '73')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '6',corr2592017 = null,description = 'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '76/A' WHERE idclassconsorsuale = '73'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('73','N','6',null,'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','76/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '74')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Italiano nella scuola media con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '80/A' WHERE idclassconsorsuale = '74'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('74','N',null,null,'Italiano nella scuola media con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','80/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '75')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Lingua e lettere italiane negli istituti di istruzione secondaria di secondo grado con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '81/A' WHERE idclassconsorsuale = '75'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('75','N',null,null,'Lingua e lettere italiane negli istituti di istruzione secondaria di secondo grado con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','81/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '76')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie negli istituti di istruzione secondaria di secondo grado con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '82/A' WHERE idclassconsorsuale = '76'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('76','N',null,null,'Materie letterarie negli istituti di istruzione secondaria di secondo grado con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','82/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '77')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie e latino nei licei e nell''istituto magistrale con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '83/A' WHERE idclassconsorsuale = '77'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('77','N',null,null,'Materie letterarie e latino nei licei e nell''istituto magistrale con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','83/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '78')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie, latino e greco nel liceo classico con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '84/A' WHERE idclassconsorsuale = '78'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('78','N',null,null,'Materie letterarie, latino e greco nel liceo classico con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','84/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '79')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Sloveno, storia ed educazione civica, geografia nella scuola media con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '85/A' WHERE idclassconsorsuale = '79'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('79','N',null,null,'Sloveno, storia ed educazione civica, geografia nella scuola media con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','85/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '80')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Dattilografia e stenografia con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '86/A' WHERE idclassconsorsuale = '80'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('80','N',null,null,'Dattilografia e stenografia con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','86/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '81')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '87/A' WHERE idclassconsorsuale = '81'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('81','N',null,null,'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','87/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '82')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Cultura ladina',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '90/A' WHERE idclassconsorsuale = '82'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('82','N',null,null,'Cultura ladina',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','90/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '83')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Italiano (seconda lingua) nella scuola. media. in lingua tedesca.',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '91/A' WHERE idclassconsorsuale = '83'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('83','N',null,null,'Italiano (seconda lingua) nella scuola. media. in lingua tedesca.',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','91/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '84')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Lingua e lettere italiane (seconda lingua) negli istituti di istruzione secondaria di secondo grado in lingua tedesca',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '92/A' WHERE idclassconsorsuale = '84'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('84','N',null,null,'Lingua e lettere italiane (seconda lingua) negli istituti di istruzione secondaria di secondo grado in lingua tedesca',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','92/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '85')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie negli istituti di istruzione secondaria di secondo grado in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '93/A' WHERE idclassconsorsuale = '85'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('85','N',null,null,'Materie letterarie negli istituti di istruzione secondaria di secondo grado in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','93/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '86')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie e latino nei licei e nell''istituto magistrale in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '94/A' WHERE idclassconsorsuale = '86'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('86','N',null,null,'Materie letterarie e latino nei licei e nell''istituto magistrale in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','94/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '87')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Materie letterarie, latino e greco nel liceo classico in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '95/A' WHERE idclassconsorsuale = '87'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('87','N',null,null,'Materie letterarie, latino e greco nel liceo classico in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','95/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '88')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tedesco (seconda lingua) negli istituti di istruzione secondaria di secondo grado in lingua italiana della provincia di Bolzano',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '96/A' WHERE idclassconsorsuale = '88'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('88','N',null,null,'Tedesco (seconda lingua) negli istituti di istruzione secondaria di secondo grado in lingua italiana della provincia di Bolzano',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','96/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '89')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tedesco (seconda lingua) nella scuola media .in lingua italiana della provincia di Bolzano',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '97/A' WHERE idclassconsorsuale = '89'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('89','N',null,null,'Tedesco (seconda lingua) nella scuola media .in lingua italiana della provincia di Bolzano',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','97/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '90')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Tedesco, storia ed educazione civica, geografia nella scuola media in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '98/A' WHERE idclassconsorsuale = '90'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('90','N',null,null,'Tedesco, storia ed educazione civica, geografia nella scuola media in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','98/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '91')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Dattilografia, stenografia, trattamento testi e dati in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '99/A' WHERE idclassconsorsuale = '91'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('91','N',null,null,'Dattilografia, stenografia, trattamento testi e dati in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','99/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '92')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '100/A' WHERE idclassconsorsuale = '92'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('92','N',null,null,'Trattamento testi, calcolo, contabilità elettronica ed applicazioni gestionali in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','100/A')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '93')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Addetto all''ufficio tecnico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '1/C' WHERE idclassconsorsuale = '93'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('93','N',null,null,'Addetto all''ufficio tecnico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','1/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '94')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Attività pratiche speciali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '2/C' WHERE idclassconsorsuale = '94'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('94','N',null,null,'Attività pratiche speciali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','2/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '95')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Conversazione in lingua straniera',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '3/C' WHERE idclassconsorsuale = '95'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('95','N',null,null,'Conversazione in lingua straniera',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','3/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '96')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '10',corr2592017 = null,description = 'Esercitazioni aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '4/C' WHERE idclassconsorsuale = '96'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('96','N','10',null,'Esercitazioni aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','4/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '97')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '11',corr2592017 = null,description = 'Esercitazioni agrarie',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '5/C' WHERE idclassconsorsuale = '97'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('97','N','11',null,'Esercitazioni agrarie',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','5/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '98')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '12',corr2592017 = null,description = 'Esercitazioni ceramiche di decorazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '6/C' WHERE idclassconsorsuale = '98'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('98','N','12',null,'Esercitazioni ceramiche di decorazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','6/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '99')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '13',corr2592017 = null,description = 'Esercitazioni di abbigliamento e moda',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '7/C' WHERE idclassconsorsuale = '99'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('99','N','13',null,'Esercitazioni di abbigliamento e moda',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','7/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '100')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '10',corr2592017 = null,description = 'Esercitazioni di circolazione aerea',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '8/C' WHERE idclassconsorsuale = '100'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('100','N','10',null,'Esercitazioni di circolazione aerea',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','8/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '101')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni di comunicazioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '9/C' WHERE idclassconsorsuale = '101'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('101','N',null,null,'Esercitazioni di comunicazioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','9/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '102')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '13',corr2592017 = null,description = 'Esercitazioni di disegno artistico dei tessuti',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '10/C' WHERE idclassconsorsuale = '102'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('102','N','13',null,'Esercitazioni di disegno artistico dei tessuti',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','10/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '103')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni di economia domestica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '11/C' WHERE idclassconsorsuale = '103'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('103','N',null,null,'Esercitazioni di economia domestica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','11/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '104')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '12',corr2592017 = null,description = 'Esercitazioni di modellismo, formatura e plastica, foggiatura e rifinitura',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '12/C' WHERE idclassconsorsuale = '104'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('104','N','12',null,'Esercitazioni di modellismo, formatura e plastica, foggiatura e rifinitura',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','12/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '105')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni di odontotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '13/C' WHERE idclassconsorsuale = '105'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('105','N',null,null,'Esercitazioni di odontotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','13/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '106')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '11',corr2592017 = null,description = 'Esercitazioni di officina meccanica agricola e di macchine agricole',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '14/C' WHERE idclassconsorsuale = '106'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('106','N','11',null,'Esercitazioni di officina meccanica agricola e di macchine agricole',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','14/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '107')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni di portineria e pratica di agenzia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '15/C' WHERE idclassconsorsuale = '107'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('107','N',null,null,'Esercitazioni di portineria e pratica di agenzia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','15/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '108')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '12',corr2592017 = null,description = 'Esercitazioni di tecnologia ceramica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '16/C' WHERE idclassconsorsuale = '108'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('108','N','12',null,'Esercitazioni di tecnologia ceramica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','16/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '109')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '14',corr2592017 = null,description = 'Esercitazioni di teoria della nave e di costruzioni navali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '17/C' WHERE idclassconsorsuale = '109'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('109','N','14',null,'Esercitazioni di teoria della nave e di costruzioni navali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','17/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '110')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni nautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '18/C' WHERE idclassconsorsuale = '110'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('110','N',null,null,'Esercitazioni nautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','18/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '111')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni pratiche di centralinisti telefonici',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '19/C' WHERE idclassconsorsuale = '111'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('111','N',null,null,'Esercitazioni pratiche di centralinisti telefonici',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','19/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '112')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Esercitazioni pratiche di ottica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '20/C' WHERE idclassconsorsuale = '112'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('112','N',null,null,'Esercitazioni pratiche di ottica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','20/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '113')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Gabinetto fisioterapico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '21/C' WHERE idclassconsorsuale = '113'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('113','N',null,null,'Gabinetto fisioterapico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','21/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '114')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '13',corr2592017 = null,description = 'Laboratori di tecnologie tessili e dell''abbigliamento e reparti di lavorazioni tessili e dell''abbigliamento',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '22/C' WHERE idclassconsorsuale = '114'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('114','N','13',null,'Laboratori di tecnologie tessili e dell''abbigliamento e reparti di lavorazioni tessili e dell''abbigliamento',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','22/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '115')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '14',corr2592017 = null,description = 'Laboratorio di aerotecnica, costruzioni e tecnologie aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '23/C' WHERE idclassconsorsuale = '115'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('115','N','14',null,'Laboratorio di aerotecnica, costruzioni e tecnologie aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','23/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '116')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '15',corr2592017 = null,description = 'Laboratorio di chimica e chimica industriale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '24/C' WHERE idclassconsorsuale = '116'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('116','N','15',null,'Laboratorio di chimica e chimica industriale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','24/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '117')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di costruzioni, verniciatura e restauro di strumenti ad arco',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '25/C' WHERE idclassconsorsuale = '117'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('117','N',null,null,'Laboratorio di costruzioni, verniciatura e restauro di strumenti ad arco',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','25/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '118')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '16',corr2592017 = null,description = 'Laboratorio di elettronica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '26/C' WHERE idclassconsorsuale = '118'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('118','N','16',null,'Laboratorio di elettronica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','26/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '119')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '16',corr2592017 = null,description = 'Laboratorio di elettrotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '27/C' WHERE idclassconsorsuale = '119'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('119','N','16',null,'Laboratorio di elettrotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','27/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '120')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '17',corr2592017 = null,description = 'Laboratorio di fisica atomica e nucleare e strumentazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '28/C' WHERE idclassconsorsuale = '120'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('120','N','17',null,'Laboratorio di fisica atomica e nucleare e strumentazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','28/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '121')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '17',corr2592017 = null,description = 'Laboratorio di fisica e fisica applicata',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '29/C' WHERE idclassconsorsuale = '121'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('121','N','17',null,'Laboratorio di fisica e fisica applicata',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','29/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '122')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '18',corr2592017 = null,description = 'Laboratorio di informatica gestionale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '30/C' WHERE idclassconsorsuale = '122'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('122','N','18',null,'Laboratorio di informatica gestionale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','30/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '123')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '18',corr2592017 = null,description = 'Laboratorio di informatica industriale',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '31/C' WHERE idclassconsorsuale = '123'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('123','N','18',null,'Laboratorio di informatica industriale',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','31/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '124')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio meccanico-tecnologico',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '32/C' WHERE idclassconsorsuale = '124'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('124','N',null,null,'Laboratorio meccanico-tecnologico',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','32/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '125')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di oreficeria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '33/C' WHERE idclassconsorsuale = '125'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('125','N',null,null,'Laboratorio di oreficeria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','33/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '126')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '12',corr2592017 = null,description = 'Laboratorio di progettazione tecnica per la ceramica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '34/C' WHERE idclassconsorsuale = '126'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('126','N','12',null,'Laboratorio di progettazione tecnica per la ceramica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','34/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '127')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '15',corr2592017 = null,description = 'Laboratorio di tecnica microbiologica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '35/C' WHERE idclassconsorsuale = '127'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('127','N','15',null,'Laboratorio di tecnica microbiologica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','35/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '128')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di tecnologia cartaria ed esercitazioni di cartiera',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '36/C' WHERE idclassconsorsuale = '128'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('128','N',null,null,'Laboratorio di tecnologia cartaria ed esercitazioni di cartiera',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','36/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '129')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio e reparti di lavorazione del legno',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '37/C' WHERE idclassconsorsuale = '129'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('129','N',null,null,'Laboratorio e reparti di lavorazione del legno',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','37/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '130')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio e reparti di lavorazione per le arti grafiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '38/C' WHERE idclassconsorsuale = '130'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('130','N',null,null,'Laboratorio e reparti di lavorazione per le arti grafiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','38/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '131')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio e reparti di lavorazione per l''industria mineraria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '39/C' WHERE idclassconsorsuale = '131'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('131','N',null,null,'Laboratorio e reparti di lavorazione per l''industria mineraria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','39/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '132')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '12',corr2592017 = null,description = 'Laboratorio per le industrie ceramiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '40/C' WHERE idclassconsorsuale = '132'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('132','N','12',null,'Laboratorio per le industrie ceramiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','40/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '133')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '19',corr2592017 = null,description = 'Laboratorio tecnologico per il marmo - Reparti di architettura, macchine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '41/C' WHERE idclassconsorsuale = '133'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('133','N','19',null,'Laboratorio tecnologico per il marmo - Reparti di architettura, macchine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','41/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '134')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '19',corr2592017 = null,description = 'Laboratorio tecnologico per il marmo - Reparti scultura, smodellatura, decorazione e ornato',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '42/C' WHERE idclassconsorsuale = '134'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('134','N','19',null,'Laboratorio tecnologico per il marmo - Reparti scultura, smodellatura, decorazione e ornato',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','42/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '135')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Laboratorio per l''edilizia ed esercitazioni di topografia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '43/C' WHERE idclassconsorsuale = '135'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('135','N',null,null,'Laboratorio per l''edilizia ed esercitazioni di topografia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','43/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '136')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Massochinesiterapia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '44/C' WHERE idclassconsorsuale = '136'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('136','N',null,null,'Massochinesiterapia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','44/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '137')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Metodologie operative nei servizi sociali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '45/C' WHERE idclassconsorsuale = '137'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('137','N',null,null,'Metodologie operative nei servizi sociali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','45/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '138')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Reparti di lavorazione per il montaggio cinematografico e televisivo',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '46/C' WHERE idclassconsorsuale = '138'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('138','N',null,null,'Reparti di lavorazione per il montaggio cinematografico e televisivo',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','46/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '139')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Reparti di lavorazione per la registrazione del suono',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '47/C' WHERE idclassconsorsuale = '139'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('139','N',null,null,'Reparti di lavorazione per la registrazione del suono',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','47/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '140')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Reparti di lavorazione per la ripresa cinematografica e televisiva',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '48/C' WHERE idclassconsorsuale = '140'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('140','N',null,null,'Reparti di lavorazione per la ripresa cinematografica e televisiva',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','48/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '141')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Reparti di lavorazione per le arti fotografiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '49/C' WHERE idclassconsorsuale = '141'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('141','N',null,null,'Reparti di lavorazione per le arti fotografiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','49/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '142')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '20',corr2592017 = null,description = 'Tecnica dei servizi ed esercitazioni pratiche di cucina',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '50/C' WHERE idclassconsorsuale = '142'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('142','N','20',null,'Tecnica dei servizi ed esercitazioni pratiche di cucina',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','50/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '143')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '20',corr2592017 = null,description = 'Tecnica dei servizi ed esercitazioni pratiche di sala e di bar',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '51/C' WHERE idclassconsorsuale = '143'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('143','N','20',null,'Tecnica dei servizi ed esercitazioni pratiche di sala e di bar',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','51/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '144')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = '20',corr2592017 = null,description = 'Tecnica dei servizi e pratica operativa',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '52/C' WHERE idclassconsorsuale = '144'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('144','N','20',null,'Tecnica dei servizi e pratica operativa',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','52/C')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '145')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-02',description = 'Arte della lavorazione dei metalli',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '1/D' WHERE idclassconsorsuale = '145'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('145','N',null,'A-02','Arte della lavorazione dei metalli',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','1/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '146')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-02',description = 'Arte dell''oreficeria, della lavorazione delle pietre dure e delle gemme',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '2/D' WHERE idclassconsorsuale = '146'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('146','N',null,'A-02','Arte dell''oreficeria, della lavorazione delle pietre dure e delle gemme',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','2/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '147')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte del disegno d''animazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '3/D' WHERE idclassconsorsuale = '147'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('147','N',null,null,'Arte del disegno d''animazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','3/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '148')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della ripresa e montaggio per il disegno animato',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '4/D' WHERE idclassconsorsuale = '148'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('148','N',null,null,'Arte della ripresa e montaggio per il disegno animato',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','4/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '149')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-05',description = 'Arte della tessitura e della decorazione dei tessuti',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '5/D' WHERE idclassconsorsuale = '149'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('149','N',null,'A-05','Arte della tessitura e della decorazione dei tessuti',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','5/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '150')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della lavorazione del vetro e della vetrata',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '6/D' WHERE idclassconsorsuale = '150'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('150','N',null,null,'Arte della lavorazione del vetro e della vetrata',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','6/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '151')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-03',description = 'Arte del restauro della ceramica e del vetro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '7/D' WHERE idclassconsorsuale = '151'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('151','N',null,'A-03','Arte del restauro della ceramica e del vetro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','7/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '152')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-03',description = 'Arte della decorazione e cottura dei prodotti ceramici',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '8/D' WHERE idclassconsorsuale = '152'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('152','N',null,'A-03','Arte della decorazione e cottura dei prodotti ceramici',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','8/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '153')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-03',description = 'Arte della formatura e foggiatura',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '9/D' WHERE idclassconsorsuale = '153'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('153','N',null,'A-03','Arte della formatura e foggiatura',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','9/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '154')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della fotografia e della cinematografia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '10/D' WHERE idclassconsorsuale = '154'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('154','N',null,null,'Arte della fotografia e della cinematografia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','10/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '155')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della xilografia, calcografia e litografia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '11/D' WHERE idclassconsorsuale = '155'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('155','N',null,null,'Arte della xilografia, calcografia e litografia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','11/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '156')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della serigrafia e della fotoincisione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '12/D' WHERE idclassconsorsuale = '156'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('156','N',null,null,'Arte della serigrafia e della fotoincisione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','12/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '157')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della tipografia e della grafica pubblicitaria',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '13/D' WHERE idclassconsorsuale = '157'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('157','N',null,null,'Arte della tipografia e della grafica pubblicitaria',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','13/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '158')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-05',description = 'Arte del taglio e confezione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '14/D' WHERE idclassconsorsuale = '158'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('158','N',null,'A-05','Arte del taglio e confezione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','14/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '159')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della decorazione pittorica e scenografica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '15/D' WHERE idclassconsorsuale = '159'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('159','N',null,null,'Arte della decorazione pittorica e scenografica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','15/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '160')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della modellistica, dell''arredamento e della scenotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '16/D' WHERE idclassconsorsuale = '160'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('160','N',null,null,'Arte della modellistica, dell''arredamento e della scenotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','16/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '161')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-04',description = 'Arte della legatoria e del restauro del libro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '17/D' WHERE idclassconsorsuale = '161'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('161','N',null,'A-04','Arte della legatoria e del restauro del libro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','17/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '162')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte dell''ebanisteria, dell''intaglio e dell''intarsio',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '18/D' WHERE idclassconsorsuale = '162'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('162','N',null,null,'Arte dell''ebanisteria, dell''intaglio e dell''intarsio',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','18/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '163')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte delle lacche, della doratura e del restauro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '19/D' WHERE idclassconsorsuale = '163'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('163','N',null,null,'Arte delle lacche, della doratura e del restauro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','19/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '164')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte del mosaico e del commesso',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '20/D' WHERE idclassconsorsuale = '164'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('164','N',null,null,'Arte del mosaico e del commesso',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','20/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '165')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Arte della lavorazione del marmo e della pietra',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '21/D' WHERE idclassconsorsuale = '165'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('165','N',null,null,'Arte della lavorazione del marmo e della pietra',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','21/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '166')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = 'A-03',description = 'Laboratorio tecnologico delle arti della ceramica, del vetro e del cristallo',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '22/D' WHERE idclassconsorsuale = '166'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('166','N',null,'A-03','Laboratorio tecnologico delle arti della ceramica, del vetro e del cristallo',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','22/D')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '167')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di tecnologie del marmo',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-27' WHERE idclassconsorsuale = '167'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('167','S',null,null,'Laboratorio di tecnologie del marmo',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-27')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '168')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di scienze e tecnologie delle costruzioni navali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-25' WHERE idclassconsorsuale = '168'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('168','S',null,null,'Laboratorio di scienze e tecnologie delle costruzioni navali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-25')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '169')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di scienze e tecnologie nautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-24' WHERE idclassconsorsuale = '169'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('169','S',null,null,'Laboratorio di scienze e tecnologie nautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-24')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '170')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori per i servizi socio–sanitari',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-23' WHERE idclassconsorsuale = '170'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('170','S',null,null,'Laboratori per i servizi socio–sanitari',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-23')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '171')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di servizi enogastronomici, settore cucina',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-20' WHERE idclassconsorsuale = '171'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('171','S',null,null,'Laboratori di servizi enogastronomici, settore cucina',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-20')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '172')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie tessili, dell''abbigliamento e della moda',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-18' WHERE idclassconsorsuale = '172'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('172','S',null,null,'Laboratori di scienze e tecnologie tessili, dell''abbigliamento e della moda',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-18')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '173')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie informatiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-16' WHERE idclassconsorsuale = '173'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('173','S',null,null,'Laboratori di scienze e tecnologie informatiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-16')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '174')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie delle costruzioni',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-14' WHERE idclassconsorsuale = '174'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('174','S',null,null,'Laboratori di scienze e tecnologie delle costruzioni',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-14')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '175')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie chimiche e microbiologiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-12' WHERE idclassconsorsuale = '175'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('175','S',null,null,'Laboratori di scienze e tecnologie chimiche e microbiologiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-12')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '176')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie delle costruzioni aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-10' WHERE idclassconsorsuale = '176'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('176','S',null,null,'Laboratori di scienze e tecnologie delle costruzioni aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-10')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '177')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratori di scienze e tecnologie aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-09' WHERE idclassconsorsuale = '177'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('177','S',null,null,'Laboratori di scienze e tecnologie aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-09')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '178')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Laboratorio di ottica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'B-07' WHERE idclassconsorsuale = '178'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('178','S',null,null,'Laboratorio di ottica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','B-07')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '179')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Trattamento testi, dati ed applicazioni, Informatica negli istituti professionali in lingua tedesca e con lingua di insegnamento tedesca',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-86' WHERE idclassconsorsuale = '179'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('179','S',null,null,'Trattamento testi, dati ed applicazioni, Informatica negli istituti professionali in lingua tedesca e con lingua di insegnamento tedesca',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-86')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '180')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tedesco storia ed educazione civica, geografia, nella scuola secondaria di I grado in lingua tedesca e con lingua di insegnamento tedesca',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-85' WHERE idclassconsorsuale = '180'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('180','S',null,null,'Tedesco storia ed educazione civica, geografia, nella scuola secondaria di I grado in lingua tedesca e con lingua di insegnamento tedesca',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-85')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '181')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tedesco (seconda lingua), storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento italiana della provincia di Bolzano',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-84' WHERE idclassconsorsuale = '181'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('181','S',null,null,'Tedesco (seconda lingua), storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento italiana della provincia di Bolzano',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-84')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '182')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie (tedesco seconda lingua) negli istituti di istruzione secondaria di II grado in lingua italiana della provincia di Bolzano',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-83' WHERE idclassconsorsuale = '182'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('182','S',null,null,'Discipline letterarie (tedesco seconda lingua) negli istituti di istruzione secondaria di II grado in lingua italiana della provincia di Bolzano',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-83')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '183')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie, latino e greco nel liceo classico in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-82' WHERE idclassconsorsuale = '183'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('183','S',null,null,'Discipline letterarie, latino e greco nel liceo classico in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-82')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '184')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie e latino nei licei in lingua tedesca e con lingua di insegnamento, tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-81' WHERE idclassconsorsuale = '184'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('184','S',null,null,'Discipline letterarie e latino nei licei in lingua tedesca e con lingua di insegnamento, tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-81')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '185')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie negli istituti di istruzione secondaria di II grado in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-80' WHERE idclassconsorsuale = '185'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('185','S',null,null,'Discipline letterarie negli istituti di istruzione secondaria di II grado in lingua tedesca e con lingua di insegnamento tedesca delle località ladine',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-80')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '186')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie (italiano seconda lingua) negli istituti di istruzione secondaria di II grado in lingua tedesca',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-79' WHERE idclassconsorsuale = '186'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('186','S',null,null,'Discipline letterarie (italiano seconda lingua) negli istituti di istruzione secondaria di II grado in lingua tedesca',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-79')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '187')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Italiano (seconda lingua), storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento tedesca',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-78' WHERE idclassconsorsuale = '187'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('187','S',null,null,'Italiano (seconda lingua), storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento tedesca',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-78')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '188')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Lingua e cultura ladina, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento ladina',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-77' WHERE idclassconsorsuale = '188'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('188','S',null,null,'Lingua e cultura ladina, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento ladina',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-77')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '189')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Trattamento testi, dati ed applicazioni, Informatica negli istituti professionali con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-76' WHERE idclassconsorsuale = '189'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('189','S',null,null,'Trattamento testi, dati ed applicazioni, Informatica negli istituti professionali con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-76')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '190')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie, latino e greco con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-75' WHERE idclassconsorsuale = '190'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('190','S',null,null,'Discipline letterarie, latino e greco con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-75')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '191')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie e latino con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-74' WHERE idclassconsorsuale = '191'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('191','S',null,null,'Discipline letterarie e latino con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-74')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '192')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie negli istituti di istruzione secondaria di II grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-73' WHERE idclassconsorsuale = '192'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('192','S',null,null,'Discipline letterarie negli istituti di istruzione secondaria di II grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-73')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '193')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie (Italiano seconda lingua) negli istituti di istruzione secondaria di II grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-72' WHERE idclassconsorsuale = '193'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('193','S',null,null,'Discipline letterarie (Italiano seconda lingua) negli istituti di istruzione secondaria di II grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-72')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '194')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Sloveno, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-71' WHERE idclassconsorsuale = '194'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('194','S',null,null,'Sloveno, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento slovena o bilingue del Friuli Venezia Giulia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-71')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '195')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Italiano, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento slovena',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-70' WHERE idclassconsorsuale = '195'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('195','S',null,null,'Italiano, storia ed educazione civica, geografia, nella scuola secondaria di I grado con lingua di insegnamento slovena',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-70')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '196')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Trattamento testi, dati ed applicazioni. Informatica (ad esaurimento)',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-66' WHERE idclassconsorsuale = '196'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('196','S',null,null,'Trattamento testi, dati ed applicazioni. Informatica (ad esaurimento)',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-66')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '197')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Teoria e tecnica della comunicazione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-65' WHERE idclassconsorsuale = '197'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('197','S',null,null,'Teoria e tecnica della comunicazione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-65')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '198')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Teoria, analisi e composizione',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-64' WHERE idclassconsorsuale = '198'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('198','S',null,null,'Teoria, analisi e composizione',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-64')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '199')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnologie musicali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-63' WHERE idclassconsorsuale = '199'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('199','S',null,null,'Tecnologie musicali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-63')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '200')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnologie e tecniche per la grafica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-62' WHERE idclassconsorsuale = '200'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('200','S',null,null,'Tecnologie e tecniche per la grafica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-62')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '201')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnologie e tecniche delle comunicazioni multimediali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-61' WHERE idclassconsorsuale = '201'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('201','S',null,null,'Tecnologie e tecniche delle comunicazioni multimediali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-61')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '202')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnologia nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-60' WHERE idclassconsorsuale = '202'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('202','S',null,null,'Tecnologia nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-60')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '203')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecniche di accompagnamento alla danza',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-59' WHERE idclassconsorsuale = '203'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('203','S',null,null,'Tecniche di accompagnamento alla danza',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-59')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '204')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnica della danza contemporanea',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-58' WHERE idclassconsorsuale = '204'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('204','S',null,null,'Tecnica della danza contemporanea',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-58')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '205')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Tecnica della danza classica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-57' WHERE idclassconsorsuale = '205'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('205','S',null,null,'Tecnica della danza classica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-57')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '206')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Strumento musicale nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-56' WHERE idclassconsorsuale = '206'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('206','S',null,null,'Strumento musicale nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-56')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '207')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Strumento musicale negli istituti di istruzione superiore di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-55' WHERE idclassconsorsuale = '207'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('207','S',null,null,'Strumento musicale negli istituti di istruzione superiore di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-55')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '208')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Storia dell''arte',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-54' WHERE idclassconsorsuale = '208'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('208','S',null,null,'Storia dell''arte',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-54')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '209')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Storia della musica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-53' WHERE idclassconsorsuale = '209'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('209','S',null,null,'Storia della musica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-53')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '210')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze, tecnologie e tecniche di produzioni animali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-52' WHERE idclassconsorsuale = '210'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('210','S',null,null,'Scienze, tecnologie e tecniche di produzioni animali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-52')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '211')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze, tecnologie e tecniche agrarie',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-51' WHERE idclassconsorsuale = '211'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('211','S',null,null,'Scienze, tecnologie e tecniche agrarie',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-51')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '212')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze naturali, chimiche e biologiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-50' WHERE idclassconsorsuale = '212'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('212','S',null,null,'Scienze naturali, chimiche e biologiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-50')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '213')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze motorie e sportive nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-49' WHERE idclassconsorsuale = '213'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('213','S',null,null,'Scienze motorie e sportive nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-49')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '214')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze motorie e sportive negli istituti di istruzione secondaria di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-48' WHERE idclassconsorsuale = '214'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('214','S',null,null,'Scienze motorie e sportive negli istituti di istruzione secondaria di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-48')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '215')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze matematiche applicate',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-47' WHERE idclassconsorsuale = '215'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('215','S',null,null,'Scienze matematiche applicate',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-47')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '216')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze giuridico -economiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-46' WHERE idclassconsorsuale = '216'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('216','S',null,null,'Scienze giuridico -economiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-46')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '217')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze economico-aziendali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-45' WHERE idclassconsorsuale = '217'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('217','S',null,null,'Scienze economico-aziendali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-45')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '218')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie tessili, dell''abbigliamento e della moda',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-44' WHERE idclassconsorsuale = '218'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('218','S',null,null,'Scienze e tecnologie tessili, dell''abbigliamento e della moda',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-44')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '219')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie nautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-43' WHERE idclassconsorsuale = '219'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('219','S',null,null,'Scienze e tecnologie nautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-43')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '220')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie meccaniche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-42' WHERE idclassconsorsuale = '220'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('220','S',null,null,'Scienze e tecnologie meccaniche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-42')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '221')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie informatiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-41' WHERE idclassconsorsuale = '221'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('221','S',null,null,'Scienze e tecnologie informatiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-41')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '222')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie elettriche ed elettroniche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-40' WHERE idclassconsorsuale = '222'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('222','S',null,null,'Scienze e tecnologie elettriche ed elettroniche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-40')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '223')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie delle costruzioni navali',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-39' WHERE idclassconsorsuale = '223'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('223','S',null,null,'Scienze e tecnologie delle costruzioni navali',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-39')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '224')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie delle costruzioni aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-38' WHERE idclassconsorsuale = '224'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('224','S',null,null,'Scienze e tecnologie delle costruzioni aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-38')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '225')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie delle costruzioni, tecnologie e tecniche di rappresentazione grafica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-37' WHERE idclassconsorsuale = '225'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('225','S',null,null,'Scienze e tecnologie delle costruzioni, tecnologie e tecniche di rappresentazione grafica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-37')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '226')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie della logistica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-36' WHERE idclassconsorsuale = '226'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('226','S',null,null,'Scienze e tecnologie della logistica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-36')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '227')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie della calzatura e della moda',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-35' WHERE idclassconsorsuale = '227'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('227','S',null,null,'Scienze e tecnologie della calzatura e della moda',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-35')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '228')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie chimiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-34' WHERE idclassconsorsuale = '228'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('228','S',null,null,'Scienze e tecnologie chimiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-34')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '229')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze e tecnologie aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-33' WHERE idclassconsorsuale = '229'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('229','S',null,null,'Scienze e tecnologie aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-33')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '230')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze della geologia e della mineralogia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-32' WHERE idclassconsorsuale = '230'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('230','S',null,null,'Scienze della geologia e della mineralogia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-32')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '231')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Scienze degli alimenti',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-31' WHERE idclassconsorsuale = '231'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('231','S',null,null,'Scienze degli alimenti',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-31')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '232')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Musica nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-30' WHERE idclassconsorsuale = '232'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('232','S',null,null,'Musica nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-30')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '233')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Musica negli istituti di istruzione secondaria di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-29' WHERE idclassconsorsuale = '233'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('233','S',null,null,'Musica negli istituti di istruzione secondaria di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-29')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '234')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Matematica e scienze',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-28' WHERE idclassconsorsuale = '234'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('234','S',null,null,'Matematica e scienze',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-28')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '235')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Matematica e Fisica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-27' WHERE idclassconsorsuale = '235'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('235','S',null,null,'Matematica e Fisica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-27')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '236')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Matematica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-26' WHERE idclassconsorsuale = '236'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('236','S',null,null,'Matematica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-26')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '237')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Lingua inglese e seconda lingua comunitaria nella scuola secondaria di primo grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-25' WHERE idclassconsorsuale = '237'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('237','S',null,null,'Lingua inglese e seconda lingua comunitaria nella scuola secondaria di primo grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-25')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '238')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Lingue e culture straniere negli istituti di istruzione secondaria di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-24' WHERE idclassconsorsuale = '238'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('238','S',null,null,'Lingue e culture straniere negli istituti di istruzione secondaria di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-24')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '239')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Lingua italiana per discenti di lingua straniera (alloglotti)',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-23' WHERE idclassconsorsuale = '239'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('239','S',null,null,'Lingua italiana per discenti di lingua straniera (alloglotti)',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-23')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '240')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Italiano, storia, geografia, nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-22' WHERE idclassconsorsuale = '240'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('240','S',null,null,'Italiano, storia, geografia, nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-22')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '241')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Geografia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-21' WHERE idclassconsorsuale = '241'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('241','S',null,null,'Geografia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-21')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '242')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Fisica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-20' WHERE idclassconsorsuale = '242'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('242','S',null,null,'Fisica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-20')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '243')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Filosofia e Storia',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-19' WHERE idclassconsorsuale = '243'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('243','S',null,null,'Filosofia e Storia',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-19')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '244')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Filosofia e Scienze umane',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-18' WHERE idclassconsorsuale = '244'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('244','S',null,null,'Filosofia e Scienze umane',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-18')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '245')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Disegno e storia dell''arte negli istituti di istruzione secondaria di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-17' WHERE idclassconsorsuale = '245'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('245','S',null,null,'Disegno e storia dell''arte negli istituti di istruzione secondaria di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-17')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '246')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Disegno artistico e modellazione odontotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-16' WHERE idclassconsorsuale = '246'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('246','S',null,null,'Disegno artistico e modellazione odontotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-16')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '247')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline sanitarie',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-15' WHERE idclassconsorsuale = '247'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('247','S',null,null,'Discipline sanitarie',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-15')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '248')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline plastiche, scultoree e scenoplastiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-14' WHERE idclassconsorsuale = '248'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('248','S',null,null,'Discipline plastiche, scultoree e scenoplastiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-14')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '249')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie, latino e greco',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-13' WHERE idclassconsorsuale = '249'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('249','S',null,null,'Discipline letterarie, latino e greco',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-13')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '250')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie negli istituti di istruzione secondaria di II grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-12' WHERE idclassconsorsuale = '250'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('250','S',null,null,'Discipline letterarie negli istituti di istruzione secondaria di II grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-12')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '251')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline letterarie e latino',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-11' WHERE idclassconsorsuale = '251'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('251','S',null,null,'Discipline letterarie e latino',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-11')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '252')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline grafico-pubblicitarie',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-10' WHERE idclassconsorsuale = '252'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('252','S',null,null,'Discipline grafico-pubblicitarie',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-10')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '253')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline grafiche, pittoriche e scenografiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-09' WHERE idclassconsorsuale = '253'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('253','S',null,null,'Discipline grafiche, pittoriche e scenografiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-09')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '254')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline geometriche, architettura, design d''arredamento e scenotecnica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-08' WHERE idclassconsorsuale = '254'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('254','S',null,null,'Discipline geometriche, architettura, design d''arredamento e scenotecnica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-08')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '255')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Discipline Audiovisive',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-07' WHERE idclassconsorsuale = '255'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('255','S',null,null,'Discipline Audiovisive',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-07')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '256')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Design del vetro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-06' WHERE idclassconsorsuale = '256'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('256','S',null,null,'Design del vetro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-06')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '257')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Design del tessuto e della moda',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-05' WHERE idclassconsorsuale = '257'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('257','S',null,null,'Design del tessuto e della moda',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-05')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '258')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Design del libro',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-04' WHERE idclassconsorsuale = '258'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('258','S',null,null,'Design del libro',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-04')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '259')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Design della ceramica',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-03' WHERE idclassconsorsuale = '259'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('259','S',null,null,'Design della ceramica',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-03')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '260')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Design dei metalli, dell''oreficeria, delle pietre dure e delle gemme',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-02' WHERE idclassconsorsuale = '260'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('260','S',null,null,'Design dei metalli, dell''oreficeria, delle pietre dure e delle gemme',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-02')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '261')
UPDATE [classconsorsuale] SET active = 'S',ambitodisci = null,corr2592017 = null,description = 'Arte e immagine nella scuola secondaria di I grado',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 259 2017',title = 'A-01' WHERE idclassconsorsuale = '261'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('261','S',null,null,'Arte e immagine nella scuola secondaria di I grado',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 259 2017','A-01')
GO

IF exists(SELECT * FROM [classconsorsuale] WHERE idclassconsorsuale = '262')
UPDATE [classconsorsuale] SET active = 'N',ambitodisci = null,corr2592017 = null,description = 'Aerotecnica e costruzioni aeronautiche',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',normativa = 'DM 39 1998',title = '1/A' WHERE idclassconsorsuale = '262'
ELSE
INSERT INTO [classconsorsuale] (idclassconsorsuale,active,ambitodisci,corr2592017,description,lt,lu,normativa,title) VALUES ('262','N',null,null,'Aerotecnica e costruzioni aeronautiche',{ts '2019-02-28 18:02:19.867'},'Ferdinando','DM 39 1998','1/A')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classconsorsuale')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle classi di concorso',idapplication = null,isdbo = 'N',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',title = 'Classi di concorso MIUR' WHERE tablename = 'classconsorsuale'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classconsorsuale','VOCABOLARIO MIUR delle classi di concorso',null,'N',{ts '2018-12-07 13:09:51.000'},'Ferdinando','Classi di concorso MIUR')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attiva',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','classconsorsuale','1',null,null,'Attiva','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ambitodisci' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ambito Disciplinare',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ambitodisci' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ambitodisci','classconsorsuale','50',null,null,'Ambito Disciplinare','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'corr2592017' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Corrispondenza',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'corr2592017' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('corr2592017','classconsorsuale','50',null,null,'Corrispondenza','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','classconsorsuale','512',null,null,'Descrizione','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','classconsorsuale','4',null,null,'Codice','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','classconsorsuale','8',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','classconsorsuale','64',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'normativa' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'normativa' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('normativa','classconsorsuale','50',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','classconsorsuale','50',null,null,'Denominazione','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3215')
UPDATE [relation] SET childtable = 'classconsorsuale',description = 'didattia prgrammata che abilita alla classe',lt = {ts '2018-07-17 17:31:28.650'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3215'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3215','classconsorsuale','didattia prgrammata che abilita alla classe',{ts '2018-07-17 17:31:28.650'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

