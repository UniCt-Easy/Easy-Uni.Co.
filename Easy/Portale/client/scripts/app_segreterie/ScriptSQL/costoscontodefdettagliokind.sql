
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
-- CREAZIONE TABELLA costoscontodefdettagliokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodefdettagliokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[costoscontodefdettagliokind] (
idcostoscontodefdettagliokind int NOT NULL,
codice varchar(50) NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkcostoscontodefdettagliokind PRIMARY KEY (idcostoscontodefdettagliokind
)
)
END
GO

-- VERIFICA STRUTTURA costoscontodefdettagliokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'idcostoscontodefdettagliokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD idcostoscontodefdettagliokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('costoscontodefdettagliokind') and col.name = 'idcostoscontodefdettagliokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [costoscontodefdettagliokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'costoscontodefdettagliokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [costoscontodefdettagliokind] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [costoscontodefdettagliokind] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI costoscontodefdettagliokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'costoscontodefdettagliokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefdettagliokind','int','ASSISTENZA','idcostoscontodefdettagliokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefdettagliokind','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI costoscontodefdettagliokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'costoscontodefdettagliokind')
UPDATE customobject set isreal = 'S' where objectname = 'costoscontodefdettagliokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('costoscontodefdettagliokind', 'S')
GO

-- GENERAZIONE DATI PER costoscontodefdettagliokind --
IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '2')
UPDATE [costoscontodefdettagliokind] SET codice = '04',ct = {ts '2020-01-07 11:05:42.103'},cu = 'riccardotest',lt = {ts '2020-01-08 18:41:06.220'},lu = 'riccardotest',title = 'Tassa regionale per il Diritto allo Studio (ESU Padova)' WHERE idcostoscontodefdettagliokind = '2'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('2','04',{ts '2020-01-07 11:05:42.103'},'riccardotest',{ts '2020-01-08 18:41:06.220'},'riccardotest','Tassa regionale per il Diritto allo Studio (ESU Padova)')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '3')
UPDATE [costoscontodefdettagliokind] SET codice = '02',ct = {ts '2020-01-07 19:25:12.730'},cu = 'riccardotest',lt = {ts '2020-01-08 18:54:47.887'},lu = 'riccardotest',title = 'Tassa di frequenza' WHERE idcostoscontodefdettagliokind = '3'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('3','02',{ts '2020-01-07 19:25:12.730'},'riccardotest',{ts '2020-01-08 18:54:47.887'},'riccardotest','Tassa di frequenza')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '4')
UPDATE [costoscontodefdettagliokind] SET codice = '03',ct = {ts '2020-01-07 19:25:39.897'},cu = 'riccardotest',lt = {ts '2020-01-08 18:40:39.100'},lu = 'riccardotest',title = 'Contributo onnicomprensivo (bollo virtuale, assicurazione e diritti di Segreteria)' WHERE idcostoscontodefdettagliokind = '4'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('4','03',{ts '2020-01-07 19:25:39.897'},'riccardotest',{ts '2020-01-08 18:40:39.100'},'riccardotest','Contributo onnicomprensivo (bollo virtuale, assicurazione e diritti di Segreteria)')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '6')
UPDATE [costoscontodefdettagliokind] SET codice = '01',ct = {ts '2020-01-08 18:28:41.347'},cu = 'riccardotest',lt = {ts '2020-01-08 18:54:20.703'},lu = 'riccardotest',title = 'Tassa di immatricolazione (solo gli studenti di nuova immatricolazione)' WHERE idcostoscontodefdettagliokind = '6'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('6','01',{ts '2020-01-08 18:28:41.347'},'riccardotest',{ts '2020-01-08 18:54:20.703'},'riccardotest','Tassa di immatricolazione (solo gli studenti di nuova immatricolazione)')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '7')
UPDATE [costoscontodefdettagliokind] SET codice = '05',ct = {ts '2020-01-08 18:53:13.143'},cu = 'riccardotest',lt = {ts '2020-01-08 18:56:13.857'},lu = 'riccardotest',title = 'Contributo di prima rata' WHERE idcostoscontodefdettagliokind = '7'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('7','05',{ts '2020-01-08 18:53:13.143'},'riccardotest',{ts '2020-01-08 18:56:13.857'},'riccardotest','Contributo di prima rata')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '8')
UPDATE [costoscontodefdettagliokind] SET codice = '06',ct = {ts '2020-01-08 18:56:29.227'},cu = 'riccardotest',lt = {ts '2020-01-08 18:56:29.227'},lu = 'riccardotest',title = 'Contributo di seconda rata' WHERE idcostoscontodefdettagliokind = '8'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('8','06',{ts '2020-01-08 18:56:29.227'},'riccardotest',{ts '2020-01-08 18:56:29.227'},'riccardotest','Contributo di seconda rata')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '9')
UPDATE [costoscontodefdettagliokind] SET codice = 'RIC',ct = {ts '2020-01-17 17:39:07.313'},cu = 'riccardotest',lt = {ts '2020-01-17 17:39:07.313'},lu = 'riccardotest',title = 'Contributo di ricognizione' WHERE idcostoscontodefdettagliokind = '9'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('9','RIC',{ts '2020-01-17 17:39:07.313'},'riccardotest',{ts '2020-01-17 17:39:07.313'},'riccardotest','Contributo di ricognizione')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '10')
UPDATE [costoscontodefdettagliokind] SET codice = 'amministrazione',ct = {ts '2020-01-17 17:39:36.790'},cu = 'riccardotest',lt = {ts '2020-01-17 17:39:36.790'},lu = 'riccardotest',title = 'Esame di ammissione' WHERE idcostoscontodefdettagliokind = '10'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('10','amministrazione',{ts '2020-01-17 17:39:36.790'},'riccardotest',{ts '2020-01-17 17:39:36.790'},'riccardotest','Esame di ammissione')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '11')
UPDATE [costoscontodefdettagliokind] SET codice = 'BAS',ct = {ts '2020-01-17 17:39:58.760'},cu = 'riccardotest',lt = {ts '2020-01-17 17:39:58.760'},lu = 'riccardotest',title = 'Corsi di Formazione musicale di base' WHERE idcostoscontodefdettagliokind = '11'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('11','BAS',{ts '2020-01-17 17:39:58.760'},'riccardotest',{ts '2020-01-17 17:39:58.760'},'riccardotest','Corsi di Formazione musicale di base')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '12')
UPDATE [costoscontodefdettagliokind] SET codice = 'AUD',ct = {ts '2020-01-17 17:40:19.067'},cu = 'riccardotest',lt = {ts '2020-01-17 17:40:19.067'},lu = 'riccardotest',title = 'Contributo per uditori (intero a.a.)' WHERE idcostoscontodefdettagliokind = '12'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('12','AUD',{ts '2020-01-17 17:40:19.067'},'riccardotest',{ts '2020-01-17 17:40:19.067'},'riccardotest','Contributo per uditori (intero a.a.)')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '13')
UPDATE [costoscontodefdettagliokind] SET codice = 'TIV',ct = {ts '2020-01-17 17:40:38.840'},cu = 'riccardotest',lt = {ts '2020-01-17 17:40:38.840'},lu = 'riccardotest',title = 'Tirocinio ai corsi tradizionali (Vecchio Ordinamento)' WHERE idcostoscontodefdettagliokind = '13'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('13','TIV',{ts '2020-01-17 17:40:38.840'},'riccardotest',{ts '2020-01-17 17:40:38.840'},'riccardotest','Tirocinio ai corsi tradizionali (Vecchio Ordinamento)')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '14')
UPDATE [costoscontodefdettagliokind] SET codice = 'MAS',ct = {ts '2020-01-17 17:40:56.573'},cu = 'riccardotest',lt = {ts '2020-01-17 17:40:56.573'},lu = 'riccardotest',title = 'Master di II livello' WHERE idcostoscontodefdettagliokind = '14'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('14','MAS',{ts '2020-01-17 17:40:56.573'},'riccardotest',{ts '2020-01-17 17:40:56.573'},'riccardotest','Master di II livello')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '15')
UPDATE [costoscontodefdettagliokind] SET codice = 'CON',ct = {ts '2020-01-17 17:41:51.907'},cu = 'riccardotest',lt = {ts '2020-01-17 17:41:51.907'},lu = 'riccardotest',title = 'Domanda di laurea/diploma' WHERE idcostoscontodefdettagliokind = '15'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('15','CON',{ts '2020-01-17 17:41:51.907'},'riccardotest',{ts '2020-01-17 17:41:51.907'},'riccardotest','Domanda di laurea/diploma')
GO

IF exists(SELECT * FROM [costoscontodefdettagliokind] WHERE idcostoscontodefdettagliokind = '16')
UPDATE [costoscontodefdettagliokind] SET codice = 'CON',ct = {ts '2020-01-17 17:46:09.707'},cu = 'riccardotest',lt = {ts '2020-01-17 17:46:09.707'},lu = 'riccardotest',title = 'Contributo' WHERE idcostoscontodefdettagliokind = '16'
ELSE
INSERT INTO [costoscontodefdettagliokind] (idcostoscontodefdettagliokind,codice,ct,cu,lt,lu,title) VALUES ('16','CON',{ts '2020-01-17 17:46:09.707'},'riccardotest',{ts '2020-01-17 17:46:09.707'},'riccardotest','Contributo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'costoscontodefdettagliokind')
UPDATE [tabledescr] SET description = 'Tipo del dettaglio di 2.3.11 Costi, 2.3.10 Sconti o 2.3.12 Indennit? / More
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:30:49.850'},lu = 'assistenza',title = 'Tipo del dettaglio di Costi, Sconti o Indennit? / More' WHERE tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('costoscontodefdettagliokind','Tipo del dettaglio di 2.3.11 Costi, 2.3.10 Sconti o 2.3.12 Indennit? / More
',null,'N',{ts '2018-07-27 17:30:49.850'},'assistenza','Tipo del dettaglio di Costi, Sconti o Indennit? / More')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','costoscontodefdettagliokind','50',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','costoscontodefdettagliokind','8',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','costoscontodefdettagliokind','64',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodefdettagliokind' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodefdettagliokind' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodefdettagliokind','costoscontodefdettagliokind','4',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','costoscontodefdettagliokind','8',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','costoscontodefdettagliokind','64',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'costoscontodefdettagliokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:30:56.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'costoscontodefdettagliokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','costoscontodefdettagliokind','50',null,null,null,'S',{ts '2018-07-27 17:30:56.067'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3410')
UPDATE [relation] SET childtable = 'costoscontodefdettagliokind',description = 'Dettaglio di Costi, Sconti o Indennit? / More che sta tipizzando',lt = {ts '2018-07-27 17:31:34.543'},lu = 'assistenza',parenttable = 'costoscontodefdettaglio',title = null WHERE idrelation = '3410'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3410','costoscontodefdettagliokind','Dettaglio di Costi, Sconti o Indennit? / More che sta tipizzando',{ts '2018-07-27 17:31:34.543'},'assistenza','costoscontodefdettaglio',null)
GO

-- FINE GENERAZIONE SCRIPT --

