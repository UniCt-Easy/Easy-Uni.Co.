
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


-- CREAZIONE TABELLA settoreerc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[settoreerc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[settoreerc] (
idsettoreerc int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(2048) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpksettoreerc PRIMARY KEY (idsettoreerc
)
)
END
GO

-- VERIFICA STRUTTURA settoreerc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'idsettoreerc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD idsettoreerc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('settoreerc') and col.name = 'idsettoreerc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [settoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD description nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN description nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI settoreerc IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'settoreerc'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreerc','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','nvarchar(2048)','ASSISTENZA','description','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI settoreerc IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'settoreerc')
UPDATE customobject set isreal = 'S' where objectname = 'settoreerc'
ELSE
INSERT INTO customobject (objectname, isreal) values('settoreerc', 'S')
GO

-- GENERAZIONE DATI PER settoreerc --
IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '1')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '1',title = 'SH - SOCIAL SCIENCES AND HUMANITIES' WHERE idsettoreerc = '1'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','1','SH - SOCIAL SCIENCES AND HUMANITIES')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '2')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '2',title = 'SH1 Markets, Individuals and Institutions: Economics, finance and management ' WHERE idsettoreerc = '2'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','2','SH1 Markets, Individuals and Institutions: Economics, finance and management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '3')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '3',title = 'SH1_1 Macroeconomics, development economics, economic growth ' WHERE idsettoreerc = '3'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','3','SH1_1 Macroeconomics, development economics, economic growth ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '4')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '4',title = 'SH1_2 International trade, international business, international management ' WHERE idsettoreerc = '4'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','4','SH1_2 International trade, international business, international management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '5')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '5',title = 'SH1_3 Financial economics, monetary economics ' WHERE idsettoreerc = '5'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','5','SH1_3 Financial economics, monetary economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '6')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '6',title = 'SH1_4 Banking, corporate finance, international finance, accounting, auditing, insurance ' WHERE idsettoreerc = '6'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','6','SH1_4 Banking, corporate finance, international finance, accounting, auditing, insurance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '7')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '7',title = 'SH1_5 Labour economics, human resource management ' WHERE idsettoreerc = '7'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','7','SH1_5 Labour economics, human resource management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '8')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '8',title = 'SH1_6 Econometrics, operations research ' WHERE idsettoreerc = '8'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','8','SH1_6 Econometrics, operations research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '9')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '9',title = 'SH1_7 Behavioural economics, experimental economics, neuro-economics ' WHERE idsettoreerc = '9'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','9','SH1_7 Behavioural economics, experimental economics, neuro-economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '10')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '10',title = 'SH1_8 Microeconomics, game theory ' WHERE idsettoreerc = '10'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','10','SH1_8 Microeconomics, game theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '11')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '11',title = 'SH1_9 Marketing ' WHERE idsettoreerc = '11'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','11','SH1_9 Marketing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '12')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '12',title = 'SH1_10 Management, organisational behaviour, operations management ' WHERE idsettoreerc = '12'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','12','SH1_10 Management, organisational behaviour, operations management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '13')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '13',title = 'SH1_11 Industrial organisation, strategy, entrepreneurship ' WHERE idsettoreerc = '13'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','13','SH1_11 Industrial organisation, strategy, entrepreneurship ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '14')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '14',title = 'SH1_12 Technological change, innovation, research & development ' WHERE idsettoreerc = '14'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','14','SH1_12 Technological change, innovation, research & development ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '15')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '15',title = 'SH1_13 Public economics, political economics, law and economics ' WHERE idsettoreerc = '15'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','15','SH1_13 Public economics, political economics, law and economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '16')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '16',title = 'SH1_14 History of economic thought, quantitative economic history, institutional economics, economic systems ' WHERE idsettoreerc = '16'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('16','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','16','SH1_14 History of economic thought, quantitative economic history, institutional economics, economic systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '17')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '17',title = 'SH2 The Social World, Diversity, Institutions and Values: Sociology, political science, law, communication, education ' WHERE idsettoreerc = '17'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('17','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','17','SH2 The Social World, Diversity, Institutions and Values: Sociology, political science, law, communication, education ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '18')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '18',title = 'SH2_1 Social structure, social mobility ' WHERE idsettoreerc = '18'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('18','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','18','SH2_1 Social structure, social mobility ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '19')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '19',title = 'SH2_2 Social inequalities, social exclusion, social integration ' WHERE idsettoreerc = '19'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('19','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','19','SH2_2 Social inequalities, social exclusion, social integration ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '20')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '20',title = 'SH2_3 Diversity and identities, gender, interethnic relations ' WHERE idsettoreerc = '20'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('20','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','20','SH2_3 Diversity and identities, gender, interethnic relations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '21')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '21',title = 'SH2_4 Social policies, educational policies, welfare ' WHERE idsettoreerc = '21'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('21','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','21','SH2_4 Social policies, educational policies, welfare ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '22')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '22',title = 'SH2_5 Democratisation, social movements ' WHERE idsettoreerc = '22'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('22','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','22','SH2_5 Democratisation, social movements ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '23')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '23',title = 'SH2_6 Political systems, governance ' WHERE idsettoreerc = '23'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('23','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','23','SH2_6 Political systems, governance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '24')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '24',title = 'SH2_7 Conflict and conflict resolution, violence ' WHERE idsettoreerc = '24'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('24','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','24','SH2_7 Conflict and conflict resolution, violence ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '25')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '25',title = 'SH2_8 Legal studies, constitutions, comparative law ' WHERE idsettoreerc = '25'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('25','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','25','SH2_8 Legal studies, constitutions, comparative law ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '26')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '26',title = 'SH2_9 Human rights ' WHERE idsettoreerc = '26'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('26','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','26','SH2_9 Human rights ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '27')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '27',title = 'SH2_10 International relations, global and transnational governance ' WHERE idsettoreerc = '27'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('27','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','27','SH2_10 International relations, global and transnational governance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '28')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '28',title = 'SH2_11 Communication and information, networks, media ' WHERE idsettoreerc = '28'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('28','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','28','SH2_11 Communication and information, networks, media ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '29')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '29',title = 'SH3 Environment, Space and Population: Sustainability science, demography, geography, regional studies and planning, science and technology studies ' WHERE idsettoreerc = '29'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('29','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','29','SH3 Environment, Space and Population: Sustainability science, demography, geography, regional studies and planning, science and technology studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '30')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '30',title = 'SH3_1 Sustainability sciences, environment and resources ' WHERE idsettoreerc = '30'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('30','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','30','SH3_1 Sustainability sciences, environment and resources ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '31')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '31',title = 'SH3_2 Environmental and climate change, societal impact ' WHERE idsettoreerc = '31'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('31','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','31','SH3_2 Environmental and climate change, societal impact ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '32')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '32',title = 'SH3_3 Environmental and climate policy ' WHERE idsettoreerc = '32'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('32','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','32','SH3_3 Environmental and climate policy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '33')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '33',title = 'SH3_4 Population dynamics, households, family and fertility ' WHERE idsettoreerc = '33'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('33','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','33','SH3_4 Population dynamics, households, family and fertility ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '34')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '34',title = 'SH3_5 Health, ageing and society ' WHERE idsettoreerc = '34'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('34','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','34','SH3_5 Health, ageing and society ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '35')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '35',title = 'SH3_6 Transportation and logistics, tourism ' WHERE idsettoreerc = '35'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('35','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','35','SH3_6 Transportation and logistics, tourism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '36')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '36',title = 'SH3_7 Spatial development, land use, regional planning ' WHERE idsettoreerc = '36'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('36','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','36','SH3_7 Spatial development, land use, regional planning ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '37')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '37',title = 'SH3_8 Urban, regional and rural studies ' WHERE idsettoreerc = '37'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('37','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','37','SH3_8 Urban, regional and rural studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '38')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '38',title = 'SH3_9 Human, social and economic geography ' WHERE idsettoreerc = '38'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('38','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','38','SH3_9 Human, social and economic geography ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '39')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '39',title = 'SH3_10 Geographic information systems, spatial data analysis ' WHERE idsettoreerc = '39'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('39','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','39','SH3_10 Geographic information systems, spatial data analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '40')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '40',title = 'SH3_11 Social studies of science and technology ' WHERE idsettoreerc = '40'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('40','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','40','SH3_11 Social studies of science and technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '41')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '41',title = 'SH4 The Human Mind and Its Complexity: Cognitive science, psychology, linguistics, philosophy of mind, education ' WHERE idsettoreerc = '41'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('41','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','41','SH4 The Human Mind and Its Complexity: Cognitive science, psychology, linguistics, philosophy of mind, education ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '42')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '42',title = 'SH4_1 Human development and its disorders, comparative cognition ' WHERE idsettoreerc = '42'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('42','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','42','SH4_1 Human development and its disorders, comparative cognition ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '43')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '43',title = 'SH4_2 Personality and social cognition, emotion ' WHERE idsettoreerc = '43'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('43','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','43','SH4_2 Personality and social cognition, emotion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '44')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '44',title = 'SH4_3 Clinical and health psychology ' WHERE idsettoreerc = '44'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('44','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','44','SH4_3 Clinical and health psychology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '45')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '45',title = 'SH4_4 Neuropsychology ' WHERE idsettoreerc = '45'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('45','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','45','SH4_4 Neuropsychology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '46')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '46',title = 'SH4_5 Attention, perception, action, consciousness ' WHERE idsettoreerc = '46'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('46','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','46','SH4_5 Attention, perception, action, consciousness ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '47')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '47',title = 'SH4_6 Learning, memory, ageing ' WHERE idsettoreerc = '47'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('47','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','47','SH4_6 Learning, memory, ageing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '48')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '48',title = 'SH4_7 Reasoning, decision-making, intelligence ' WHERE idsettoreerc = '48'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('48','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','48','SH4_7 Reasoning, decision-making, intelligence ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '49')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '49',title = 'SH4_8 Language learning and processing (first and second languages) ' WHERE idsettoreerc = '49'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('49','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','49','SH4_8 Language learning and processing (first and second languages) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '50')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '50',title = 'SH4_9 Theoretical linguistics, computational linguistics ' WHERE idsettoreerc = '50'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('50','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','50','SH4_9 Theoretical linguistics, computational linguistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '51')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '51',title = 'SH4_10 Language typology ' WHERE idsettoreerc = '51'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('51','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','51','SH4_10 Language typology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '52')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '52',title = 'SH4_11 Pragmatics, sociolinguistics, discourse analysis ' WHERE idsettoreerc = '52'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('52','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','52','SH4_11 Pragmatics, sociolinguistics, discourse analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '53')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '53',title = 'SH4_12 Philosophy of mind, philosophy of language ' WHERE idsettoreerc = '53'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('53','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','53','SH4_12 Philosophy of mind, philosophy of language ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '54')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '54',title = 'SH4_13 Philosophy of science, epistemology and logic ' WHERE idsettoreerc = '54'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('54','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','54','SH4_13 Philosophy of science, epistemology and logic ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '55')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '55',title = 'SH4_14 Teaching and learning ' WHERE idsettoreerc = '55'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('55','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','55','SH4_14 Teaching and learning ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '56')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '56',title = 'SH5 Cultures and Cultural Production: Literature, philology, cultural studies, anthropology, arts, philosophy ' WHERE idsettoreerc = '56'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('56','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','56','SH5 Cultures and Cultural Production: Literature, philology, cultural studies, anthropology, arts, philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '57')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '57',title = 'SH5_1 Classics, ancient literature and art ' WHERE idsettoreerc = '57'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('57','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','57','SH5_1 Classics, ancient literature and art ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '58')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '58',title = 'SH5_2 Theory and history of literature, comparative literature ' WHERE idsettoreerc = '58'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('58','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','58','SH5_2 Theory and history of literature, comparative literature ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '59')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '59',title = 'SH5_3 Philology and palaeography, historical linguistics ' WHERE idsettoreerc = '59'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('59','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','59','SH5_3 Philology and palaeography, historical linguistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '60')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '60',title = 'SH5_4 Visual and performing arts, design, arts-based research ' WHERE idsettoreerc = '60'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('60','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','60','SH5_4 Visual and performing arts, design, arts-based research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '61')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '61',title = 'SH5_5 Music and musicology, history of music ' WHERE idsettoreerc = '61'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('61','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','61','SH5_5 Music and musicology, history of music ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '62')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '62',title = 'SH5_6 History of art and architecture ' WHERE idsettoreerc = '62'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('62','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','62','SH5_6 History of art and architecture ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '63')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '63',title = 'SH5_7 Museums, exhibitions, conservation and restoration ' WHERE idsettoreerc = '63'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('63','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','63','SH5_7 Museums, exhibitions, conservation and restoration ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '64')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '64',title = 'SH5_8 Cultural studies, symbolic representation, religious studies ' WHERE idsettoreerc = '64'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('64','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','64','SH5_8 Cultural studies, symbolic representation, religious studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '65')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '65',title = 'SH5_9 Social anthropology, myth, ritual, kinship ' WHERE idsettoreerc = '65'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('65','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','65','SH5_9 Social anthropology, myth, ritual, kinship ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '66')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '66',title = 'SH5_10 Cultural heritage, cultural identities and memories ' WHERE idsettoreerc = '66'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('66','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','66','SH5_10 Cultural heritage, cultural identities and memories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '67')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '67',title = 'SH5_11 Metaphysics, philosophical anthropology, aesthetics ' WHERE idsettoreerc = '67'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('67','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','67','SH5_11 Metaphysics, philosophical anthropology, aesthetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '68')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '68',title = 'SH5_12 Ethics, social and political philosophy ' WHERE idsettoreerc = '68'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('68','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','68','SH5_12 Ethics, social and political philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '69')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '69',title = 'SH5_13 History of philosophy ' WHERE idsettoreerc = '69'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('69','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','69','SH5_13 History of philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '70')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '70',title = 'SH6 The Study of the Human Past: Archaeology and history ' WHERE idsettoreerc = '70'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('70','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','70','SH6 The Study of the Human Past: Archaeology and history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '71')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '71',title = 'SH6_1 Historiography, theory and methods of history ' WHERE idsettoreerc = '71'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('71','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','71','SH6_1 Historiography, theory and methods of history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '72')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '72',title = 'SH6_2 Archaeology, archaeometry, landscape archaeology ' WHERE idsettoreerc = '72'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('72','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','72','SH6_2 Archaeology, archaeometry, landscape archaeology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '73')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '73',title = 'SH6_3 Prehistory, palaeoanthropology, palaeodemography, protohistory ' WHERE idsettoreerc = '73'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('73','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','73','SH6_3 Prehistory, palaeoanthropology, palaeodemography, protohistory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '74')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '74',title = 'SH6_4 Ancient history ' WHERE idsettoreerc = '74'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('74','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','74','SH6_4 Ancient history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '75')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '75',title = 'SH6_5 Medieval history ' WHERE idsettoreerc = '75'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('75','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','75','SH6_5 Medieval history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '76')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '76',title = 'SH6_6 Early modern history ' WHERE idsettoreerc = '76'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('76','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','76','SH6_6 Early modern history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '77')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '77',title = 'SH6_7 Modern and contemporary history ' WHERE idsettoreerc = '77'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('77','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','77','SH6_7 Modern and contemporary history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '78')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '78',title = 'SH6_8 Colonial and post-colonial history ' WHERE idsettoreerc = '78'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('78','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','78','SH6_8 Colonial and post-colonial history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '79')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '79',title = 'SH6_9 Global history, transnational history, comparative history, entangled histories ' WHERE idsettoreerc = '79'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('79','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','79','SH6_9 Global history, transnational history, comparative history, entangled histories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '80')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '80',title = 'SH6_10 Social and economic history ' WHERE idsettoreerc = '80'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('80','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','80','SH6_10 Social and economic history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '81')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '81',title = 'SH6_11 Gender history ' WHERE idsettoreerc = '81'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('81','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','81','SH6_11 Gender history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '82')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '82',title = 'SH6_12 History of ideas, intellectual history, history of science and techniques ' WHERE idsettoreerc = '82'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('82','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','82','SH6_12 History of ideas, intellectual history, history of science and techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '83')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '83',title = 'SH6_13 Cultural history, history of collective identities and memories ' WHERE idsettoreerc = '83'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('83','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','83','SH6_13 Cultural history, history of collective identities and memories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '84')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '84',title = 'PE - PHYSICAL SCIENCES AND ENGINEERING ' WHERE idsettoreerc = '84'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('84','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','84','PE - PHYSICAL SCIENCES AND ENGINEERING ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '85')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '85',title = 'PE1 Mathematics: All areas of mathematics, pure and applied, plus mathematical foundations of computer science, mathematical physics and statistics ' WHERE idsettoreerc = '85'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('85','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','85','PE1 Mathematics: All areas of mathematics, pure and applied, plus mathematical foundations of computer science, mathematical physics and statistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '86')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '86',title = 'PE1_1 Logic and foundations ' WHERE idsettoreerc = '86'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('86','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','86','PE1_1 Logic and foundations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '87')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '87',title = 'PE1_2 Algebra ' WHERE idsettoreerc = '87'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('87','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','87','PE1_2 Algebra ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '88')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '88',title = 'PE1_3 Number theory ' WHERE idsettoreerc = '88'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('88','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','88','PE1_3 Number theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '89')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '89',title = 'PE1_4 Algebraic and complex geometry ' WHERE idsettoreerc = '89'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('89','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','89','PE1_4 Algebraic and complex geometry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '90')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '90',title = 'PE1_5 Geometry ' WHERE idsettoreerc = '90'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('90','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','90','PE1_5 Geometry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '91')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '91',title = 'PE1_6 Topology ' WHERE idsettoreerc = '91'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('91','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','91','PE1_6 Topology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '92')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '92',title = 'PE1_7 Lie groups, Lie algebras ' WHERE idsettoreerc = '92'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('92','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','92','PE1_7 Lie groups, Lie algebras ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '93')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '93',title = 'PE1_8 Analysis ' WHERE idsettoreerc = '93'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('93','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','93','PE1_8 Analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '94')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '94',title = 'PE1_9 Operator algebras and functional analysis ' WHERE idsettoreerc = '94'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('94','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','94','PE1_9 Operator algebras and functional analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '95')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '95',title = 'PE1_10 ODE and dynamical systems ' WHERE idsettoreerc = '95'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('95','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','95','PE1_10 ODE and dynamical systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '96')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '96',title = 'PE1_11 Theoretical aspects of partial differential equations ' WHERE idsettoreerc = '96'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('96','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','96','PE1_11 Theoretical aspects of partial differential equations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '97')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '97',title = 'PE1_12 Mathematical physics ' WHERE idsettoreerc = '97'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('97','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','97','PE1_12 Mathematical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '98')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '98',title = 'PE1_13 Probability ' WHERE idsettoreerc = '98'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('98','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','98','PE1_13 Probability ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '99')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '99',title = 'PE1_14 Statistics ' WHERE idsettoreerc = '99'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('99','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','99','PE1_14 Statistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '100')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '100',title = 'PE1_15 Discrete mathematics and combinatorics ' WHERE idsettoreerc = '100'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('100','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','100','PE1_15 Discrete mathematics and combinatorics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '101')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '101',title = 'PE1_16 Mathematical aspects of computer science ' WHERE idsettoreerc = '101'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('101','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','101','PE1_16 Mathematical aspects of computer science ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '102')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '102',title = 'PE1_17 Numerical analysis ' WHERE idsettoreerc = '102'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('102','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','102','PE1_17 Numerical analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '103')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '103',title = 'PE1_18 Scientific computing and data processing ' WHERE idsettoreerc = '103'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('103','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','103','PE1_18 Scientific computing and data processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '104')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '104',title = 'PE1_19 Control theory and optimisation ' WHERE idsettoreerc = '104'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('104','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','104','PE1_19 Control theory and optimisation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '105')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '105',title = 'PE1_20 Application of mathematics in sciences ' WHERE idsettoreerc = '105'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('105','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','105','PE1_20 Application of mathematics in sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '106')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '106',title = 'PE1_21 Application of mathematics in industry and society ' WHERE idsettoreerc = '106'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('106','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','106','PE1_21 Application of mathematics in industry and society ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '107')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '107',title = 'PE2 Fundamental Constituents of Matter: Particle, nuclear, plasma, atomic, molecular, gas, and optical physics ' WHERE idsettoreerc = '107'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('107','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','107','PE2 Fundamental Constituents of Matter: Particle, nuclear, plasma, atomic, molecular, gas, and optical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '108')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '108',title = 'PE2_1 Fundamental interactions and fields ' WHERE idsettoreerc = '108'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('108','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','108','PE2_1 Fundamental interactions and fields ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '109')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '109',title = 'PE2_2 Particle physics ' WHERE idsettoreerc = '109'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('109','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','109','PE2_2 Particle physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '110')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '110',title = 'PE2_3 Nuclear physics ' WHERE idsettoreerc = '110'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('110','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','110','PE2_3 Nuclear physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '111')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '111',title = 'PE2_4 Nuclear astrophysics ' WHERE idsettoreerc = '111'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('111','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','111','PE2_4 Nuclear astrophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '112')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '112',title = 'PE2_5 Gas and plasma physics ' WHERE idsettoreerc = '112'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('112','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','112','PE2_5 Gas and plasma physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '113')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '113',title = 'PE2_6 Electromagnetism ' WHERE idsettoreerc = '113'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('113','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','113','PE2_6 Electromagnetism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '114')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '114',title = 'PE2_7 Atomic, molecular physics ' WHERE idsettoreerc = '114'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('114','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','114','PE2_7 Atomic, molecular physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '115')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '115',title = 'PE2_8 Ultra-cold atoms and molecules ' WHERE idsettoreerc = '115'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('115','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','115','PE2_8 Ultra-cold atoms and molecules ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '116')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '116',title = 'PE2_9 Optics, non-linear optics and nano-optics ' WHERE idsettoreerc = '116'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('116','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','116','PE2_9 Optics, non-linear optics and nano-optics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '117')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '117',title = 'PE2_10 Quantum optics and quantum information ' WHERE idsettoreerc = '117'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('117','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','117','PE2_10 Quantum optics and quantum information ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '118')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '118',title = 'PE2_11 Lasers, ultra-short lasers and laser physics ' WHERE idsettoreerc = '118'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('118','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','118','PE2_11 Lasers, ultra-short lasers and laser physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '119')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '119',title = 'PE2_12 Acoustics ' WHERE idsettoreerc = '119'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('119','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','119','PE2_12 Acoustics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '120')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '120',title = 'PE2_13 Relativity ' WHERE idsettoreerc = '120'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('120','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','120','PE2_13 Relativity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '121')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '121',title = 'PE2_14 Thermodynamics ' WHERE idsettoreerc = '121'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('121','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','121','PE2_14 Thermodynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '122')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '122',title = 'PE2_15 Non-linear physics ' WHERE idsettoreerc = '122'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('122','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','122','PE2_15 Non-linear physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '123')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '123',title = 'PE2_16 General physics ' WHERE idsettoreerc = '123'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('123','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','123','PE2_16 General physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '124')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '124',title = 'PE2_17 Metrology and measurement ' WHERE idsettoreerc = '124'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('124','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','124','PE2_17 Metrology and measurement ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '125')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '125',title = 'PE2_18 Statistical physics (gases) ' WHERE idsettoreerc = '125'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('125','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','125','PE2_18 Statistical physics (gases) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '126')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '126',title = 'PE3 Condensed Matter Physics: Structure, electronic properties, fluids, nanosciences, biophysics ' WHERE idsettoreerc = '126'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('126','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','126','PE3 Condensed Matter Physics: Structure, electronic properties, fluids, nanosciences, biophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '127')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '127',title = 'PE3_1 Structure of solids and liquids ' WHERE idsettoreerc = '127'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('127','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','127','PE3_1 Structure of solids and liquids ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '128')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '128',title = 'PE3_2 Mechanical and acoustical properties of condensed matter, Lattice dynamics ' WHERE idsettoreerc = '128'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('128','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','128','PE3_2 Mechanical and acoustical properties of condensed matter, Lattice dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '129')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '129',title = 'PE3_3 Transport properties of condensed matter ' WHERE idsettoreerc = '129'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('129','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','129','PE3_3 Transport properties of condensed matter ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '130')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '130',title = 'PE3_4 Electronic properties of materials, surfaces, interfaces, nanostructures, etc. ' WHERE idsettoreerc = '130'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('130','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','130','PE3_4 Electronic properties of materials, surfaces, interfaces, nanostructures, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '131')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '131',title = 'PE3_5 Semiconductors and insulators: material growth, physical properties ' WHERE idsettoreerc = '131'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('131','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','131','PE3_5 Semiconductors and insulators: material growth, physical properties ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '132')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '132',title = 'PE3_6 Macroscopic quantum phenomena: superconductivity, superfluidity, etc. ' WHERE idsettoreerc = '132'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('132','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','132','PE3_6 Macroscopic quantum phenomena: superconductivity, superfluidity, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '133')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '133',title = 'PE3_7 Spintronics ' WHERE idsettoreerc = '133'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('133','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','133','PE3_7 Spintronics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '134')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '134',title = 'PE3_8 Magnetism and strongly correlated systems ' WHERE idsettoreerc = '134'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('134','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','134','PE3_8 Magnetism and strongly correlated systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '135')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '135',title = 'PE3_9 Condensed matter ñ beam interactions (photons, electrons, etc.) ' WHERE idsettoreerc = '135'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('135','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','135','PE3_9 Condensed matter ñ beam interactions (photons, electrons, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '136')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '136',title = 'PE3_10 Nanophysics: nanoelectronics, nanophotonics, nanomagnetism, nanoelectromechanics, etc. ' WHERE idsettoreerc = '136'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('136','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','136','PE3_10 Nanophysics: nanoelectronics, nanophotonics, nanomagnetism, nanoelectromechanics, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '137')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '137',title = 'PE3_11 Mesoscopic physics ' WHERE idsettoreerc = '137'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('137','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','137','PE3_11 Mesoscopic physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '138')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '138',title = 'PE3_12 Molecular electronics ' WHERE idsettoreerc = '138'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('138','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','138','PE3_12 Molecular electronics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '139')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '139',title = 'PE3_13 Structure and dynamics of disordered systems: soft matter (gels, colloids, liquid crystals, etc.), glasses, defects, etc. ' WHERE idsettoreerc = '139'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('139','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','139','PE3_13 Structure and dynamics of disordered systems: soft matter (gels, colloids, liquid crystals, etc.), glasses, defects, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '140')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '140',title = 'PE3_14 Fluid dynamics (physics) ' WHERE idsettoreerc = '140'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('140','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','140','PE3_14 Fluid dynamics (physics) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '141')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '141',title = 'PE3_15 Statistical physics: phase transitions, noise and fluctuations, models of complex systems, etc. ' WHERE idsettoreerc = '141'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('141','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','141','PE3_15 Statistical physics: phase transitions, noise and fluctuations, models of complex systems, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '142')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '142',title = 'PE3_16 Physics of biological systems ' WHERE idsettoreerc = '142'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('142','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','142','PE3_16 Physics of biological systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '143')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '143',title = 'PE4 Physical and Analytical Chemical Sciences: Analytical chemistry, chemical theory, physical chemistry/chemical physics ' WHERE idsettoreerc = '143'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('143','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','143','PE4 Physical and Analytical Chemical Sciences: Analytical chemistry, chemical theory, physical chemistry/chemical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '144')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '144',title = 'PE4_1 Physical chemistry ' WHERE idsettoreerc = '144'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('144','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','144','PE4_1 Physical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '145')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '145',title = 'PE4_2 Spectroscopic and spectrometric techniques ' WHERE idsettoreerc = '145'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('145','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','145','PE4_2 Spectroscopic and spectrometric techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '146')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '146',title = 'PE4_3 Molecular architecture and Structure ' WHERE idsettoreerc = '146'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('146','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','146','PE4_3 Molecular architecture and Structure ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '147')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '147',title = 'PE4_4 Surface science and nanostructures ' WHERE idsettoreerc = '147'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('147','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','147','PE4_4 Surface science and nanostructures ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '148')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '148',title = 'PE4_5 Analytical chemistry ' WHERE idsettoreerc = '148'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('148','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','148','PE4_5 Analytical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '149')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '149',title = 'PE4_6 Chemical physics ' WHERE idsettoreerc = '149'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('149','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','149','PE4_6 Chemical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '150')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '150',title = 'PE4_7 Chemical instrumentation ' WHERE idsettoreerc = '150'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('150','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','150','PE4_7 Chemical instrumentation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '151')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '151',title = 'PE4_8 Electrochemistry, electrodialysis, microfluidics, sensors ' WHERE idsettoreerc = '151'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('151','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','151','PE4_8 Electrochemistry, electrodialysis, microfluidics, sensors ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '152')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '152',title = 'PE4_9 Method development in chemistry ' WHERE idsettoreerc = '152'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('152','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','152','PE4_9 Method development in chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '153')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '153',title = 'PE4_10 Heterogeneous catalysis ' WHERE idsettoreerc = '153'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('153','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','153','PE4_10 Heterogeneous catalysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '154')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '154',title = 'PE4_11 Physical chemistry of biological systems ' WHERE idsettoreerc = '154'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('154','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','154','PE4_11 Physical chemistry of biological systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '155')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '155',title = 'PE4_12 Chemical reactions: mechanisms, dynamics, kinetics and catalytic reactions ' WHERE idsettoreerc = '155'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('155','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','155','PE4_12 Chemical reactions: mechanisms, dynamics, kinetics and catalytic reactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '156')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '156',title = 'PE4_13 Theoretical and computational chemistry ' WHERE idsettoreerc = '156'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('156','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','156','PE4_13 Theoretical and computational chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '157')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '157',title = 'PE4_14 Radiation and Nuclear chemistry ' WHERE idsettoreerc = '157'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('157','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','157','PE4_14 Radiation and Nuclear chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '158')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '158',title = 'PE4_15 Photochemistry ' WHERE idsettoreerc = '158'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('158','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','158','PE4_15 Photochemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '159')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '159',title = 'PE4_16 Corrosion ' WHERE idsettoreerc = '159'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('159','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','159','PE4_16 Corrosion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '160')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '160',title = 'PE4_17 Characterisation methods of materials ' WHERE idsettoreerc = '160'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('160','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','160','PE4_17 Characterisation methods of materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '161')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '161',title = 'PE4_18 Environment chemistry ' WHERE idsettoreerc = '161'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('161','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','161','PE4_18 Environment chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '162')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '162',title = 'PE5 Synthetic Chemistry and Materials: Materials synthesis, structureproperties relations, functional and advanced materials, molecular architecture, organic chemistry ' WHERE idsettoreerc = '162'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('162','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','162','PE5 Synthetic Chemistry and Materials: Materials synthesis, structureproperties relations, functional and advanced materials, molecular architecture, organic chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '163')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '163',title = 'PE5_1 Structural properties of materials ' WHERE idsettoreerc = '163'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('163','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','163','PE5_1 Structural properties of materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '164')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '164',title = 'PE5_2 Solid state materials ' WHERE idsettoreerc = '164'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('164','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','164','PE5_2 Solid state materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '165')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '165',title = 'PE5_3 Surface modification ' WHERE idsettoreerc = '165'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('165','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','165','PE5_3 Surface modification ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '166')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '166',title = 'PE5_4 Thin films ' WHERE idsettoreerc = '166'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('166','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','166','PE5_4 Thin films ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '167')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '167',title = 'PE5_5 Ionic liquids ' WHERE idsettoreerc = '167'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('167','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','167','PE5_5 Ionic liquids ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '168')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '168',title = 'PE5_6 New materials: oxides, alloys, composite, organic-inorganic hybrid, nanoparticles ' WHERE idsettoreerc = '168'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('168','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','168','PE5_6 New materials: oxides, alloys, composite, organic-inorganic hybrid, nanoparticles ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '169')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '169',title = 'PE5_7 Biomaterials, biomaterials synthesis ' WHERE idsettoreerc = '169'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('169','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','169','PE5_7 Biomaterials, biomaterials synthesis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '170')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '170',title = 'PE5_8 Intelligent materials ñ self assembled materials ' WHERE idsettoreerc = '170'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('170','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','170','PE5_8 Intelligent materials ñ self assembled materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '171')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '171',title = 'PE5_9 Coordination chemistry ' WHERE idsettoreerc = '171'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('171','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','171','PE5_9 Coordination chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '172')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '172',title = 'PE5_10 Colloid chemistry ' WHERE idsettoreerc = '172'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('172','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','172','PE5_10 Colloid chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '173')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '173',title = 'PE5_11 Biological chemistry ' WHERE idsettoreerc = '173'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('173','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','173','PE5_11 Biological chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '174')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '174',title = 'PE5_12 Chemistry of condensed matter ' WHERE idsettoreerc = '174'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('174','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','174','PE5_12 Chemistry of condensed matter ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '175')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '175',title = 'PE5_13 Homogeneous catalysis ' WHERE idsettoreerc = '175'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('175','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','175','PE5_13 Homogeneous catalysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '176')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '176',title = 'PE5_14 Macromolecular chemistry ' WHERE idsettoreerc = '176'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('176','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','176','PE5_14 Macromolecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '177')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '177',title = 'PE5_15 Polymer chemistry ' WHERE idsettoreerc = '177'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('177','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','177','PE5_15 Polymer chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '178')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '178',title = 'PE5_16 Supramolecular chemistry ' WHERE idsettoreerc = '178'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('178','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','178','PE5_16 Supramolecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '179')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '179',title = 'PE5_17 Organic chemistry ' WHERE idsettoreerc = '179'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('179','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','179','PE5_17 Organic chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '180')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '180',title = 'PE5_18 Molecular chemistry ' WHERE idsettoreerc = '180'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('180','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','180','PE5_18 Molecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '181')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '181',title = 'PE5_19 Combinatorial chemistry ' WHERE idsettoreerc = '181'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('181','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','181','PE5_19 Combinatorial chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '182')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '182',title = 'PE6 Computer Science and Informatics: Informatics and information systems, computer science, scientific computing, intelligent systems ' WHERE idsettoreerc = '182'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('182','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','182','PE6 Computer Science and Informatics: Informatics and information systems, computer science, scientific computing, intelligent systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '183')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '183',title = 'PE6_1 Computer architecture, pervasive computing, ubiquitous computing ' WHERE idsettoreerc = '183'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('183','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','183','PE6_1 Computer architecture, pervasive computing, ubiquitous computing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '184')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '184',title = 'PE6_2 Computer systems, parallel/distributed systems, sensor networks, embedded systems, cyber-physical systems ' WHERE idsettoreerc = '184'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('184','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','184','PE6_2 Computer systems, parallel/distributed systems, sensor networks, embedded systems, cyber-physical systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '185')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '185',title = 'PE6_3 Software engineering, operating systems, computer languages ' WHERE idsettoreerc = '185'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('185','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','185','PE6_3 Software engineering, operating systems, computer languages ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '186')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '186',title = 'PE6_4 Theoretical computer science, formal methods, and quantum computing ' WHERE idsettoreerc = '186'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('186','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','186','PE6_4 Theoretical computer science, formal methods, and quantum computing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '187')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '187',title = 'PE6_5 Cryptology, security, privacy, quantum crypto ' WHERE idsettoreerc = '187'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('187','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','187','PE6_5 Cryptology, security, privacy, quantum crypto ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '188')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '188',title = 'PE6_6 Algorithms, distributed, parallel and network algorithms, algorithmic game theory ' WHERE idsettoreerc = '188'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('188','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','188','PE6_6 Algorithms, distributed, parallel and network algorithms, algorithmic game theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '189')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '189',title = 'PE6_7 Artificial intelligence, intelligent systems, multi agent systems ' WHERE idsettoreerc = '189'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('189','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','189','PE6_7 Artificial intelligence, intelligent systems, multi agent systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '190')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '190',title = 'PE6_8 Computer graphics, computer vision, multi media, computer games ' WHERE idsettoreerc = '190'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('190','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','190','PE6_8 Computer graphics, computer vision, multi media, computer games ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '191')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '191',title = 'PE6_9 Human computer interaction and interface, visualisation and natural language processing ' WHERE idsettoreerc = '191'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('191','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','191','PE6_9 Human computer interaction and interface, visualisation and natural language processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '192')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '192',title = 'PE6_10 Web and information systems, database systems, information retrieval and digital libraries, data fusion ' WHERE idsettoreerc = '192'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('192','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','192','PE6_10 Web and information systems, database systems, information retrieval and digital libraries, data fusion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '193')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '193',title = 'PE6_11 Machine learning, statistical data processing and applications using signal processing (e.g. speech, image, video) ' WHERE idsettoreerc = '193'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('193','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','193','PE6_11 Machine learning, statistical data processing and applications using signal processing (e.g. speech, image, video) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '194')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '194',title = 'PE6_12 Scientific computing, simulation and modelling tools ' WHERE idsettoreerc = '194'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('194','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','194','PE6_12 Scientific computing, simulation and modelling tools ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '195')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '195',title = 'PE6_13 Bioinformatics, biocomputing, and DNA and molecular computation ' WHERE idsettoreerc = '195'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('195','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','195','PE6_13 Bioinformatics, biocomputing, and DNA and molecular computation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '196')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '196',title = 'PE7 Systems and Communication Engineering: Electrical, electronic, communication, optical and systems engineering ' WHERE idsettoreerc = '196'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('196','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','196','PE7 Systems and Communication Engineering: Electrical, electronic, communication, optical and systems engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '197')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '197',title = 'PE7_1 Control engineering ' WHERE idsettoreerc = '197'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('197','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','197','PE7_1 Control engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '198')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '198',title = 'PE7_2 Electrical engineering: power components and/or systems ' WHERE idsettoreerc = '198'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('198','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','198','PE7_2 Electrical engineering: power components and/or systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '199')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '199',title = 'PE7_3 Simulation engineering and modelling ' WHERE idsettoreerc = '199'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('199','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','199','PE7_3 Simulation engineering and modelling ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '200')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '200',title = 'PE7_4 (Micro and nano) systems engineering ' WHERE idsettoreerc = '200'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('200','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','200','PE7_4 (Micro and nano) systems engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '201')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '201',title = 'PE7_5 (Micro and nano) electronic, optoelectronic and photonic components ' WHERE idsettoreerc = '201'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('201','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','201','PE7_5 (Micro and nano) electronic, optoelectronic and photonic components ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '202')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '202',title = 'PE7_6 Communication technology, high-frequency technology ' WHERE idsettoreerc = '202'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('202','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','202','PE7_6 Communication technology, high-frequency technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '203')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '203',title = 'PE7_7 Signal processing ' WHERE idsettoreerc = '203'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('203','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','203','PE7_7 Signal processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '204')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '204',title = 'PE7_8 Networks (communication networks, sensor networks, networks of robots, etc.) ' WHERE idsettoreerc = '204'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('204','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','204','PE7_8 Networks (communication networks, sensor networks, networks of robots, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '205')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '205',title = 'PE7_9 Man-machine-interfaces ' WHERE idsettoreerc = '205'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('205','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','205','PE7_9 Man-machine-interfaces ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '206')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '206',title = 'PE7_10 Robotics ' WHERE idsettoreerc = '206'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('206','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','206','PE7_10 Robotics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '207')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '207',title = 'PE7_11 Components and systems for applications (in e.g. medicine, biology, environment) ' WHERE idsettoreerc = '207'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('207','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','207','PE7_11 Components and systems for applications (in e.g. medicine, biology, environment) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '208')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '208',title = 'PE7_12 Electrical energy production, distribution, application ' WHERE idsettoreerc = '208'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('208','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','208','PE7_12 Electrical energy production, distribution, application ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '209')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '209',title = 'PE8 Products and Processes Engineering: Product design, process design and control, construction methods, civil engineering, energy processes, material engineering ' WHERE idsettoreerc = '209'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('209','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','209','PE8 Products and Processes Engineering: Product design, process design and control, construction methods, civil engineering, energy processes, material engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '210')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '210',title = 'PE8_1 Aerospace engineering ' WHERE idsettoreerc = '210'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('210','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','210','PE8_1 Aerospace engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '211')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '211',title = 'PE8_2 Chemical engineering, technical chemistry ' WHERE idsettoreerc = '211'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('211','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','211','PE8_2 Chemical engineering, technical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '212')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '212',title = 'PE8_3 Civil engineering, architecture, maritime/hydraulic engineering, geotechnics, waste treatment ' WHERE idsettoreerc = '212'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('212','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','212','PE8_3 Civil engineering, architecture, maritime/hydraulic engineering, geotechnics, waste treatment ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '213')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '213',title = 'PE8_4 Computational engineering ' WHERE idsettoreerc = '213'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('213','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','213','PE8_4 Computational engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '214')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '214',title = 'PE8_5 Fluid mechanics, hydraulic-, turbo-, and piston engines ' WHERE idsettoreerc = '214'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('214','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','214','PE8_5 Fluid mechanics, hydraulic-, turbo-, and piston engines ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '215')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '215',title = 'PE8_6 Energy processes engineering ' WHERE idsettoreerc = '215'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('215','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','215','PE8_6 Energy processes engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '216')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '216',title = 'PE8_7 Mechanical and manufacturing engineering (shaping, mounting, joining, separation) ' WHERE idsettoreerc = '216'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('216','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','216','PE8_7 Mechanical and manufacturing engineering (shaping, mounting, joining, separation) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '217')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '217',title = 'PE8_8 Materials engineering (metals, ceramics, polymers, composites, etc.) ' WHERE idsettoreerc = '217'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('217','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','217','PE8_8 Materials engineering (metals, ceramics, polymers, composites, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '218')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '218',title = 'PE8_9 Production technology, process engineering ' WHERE idsettoreerc = '218'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('218','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','218','PE8_9 Production technology, process engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '219')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '219',title = 'PE8_10 Industrial design (product design, ergonomics, man-machine interfaces, etc.) ' WHERE idsettoreerc = '219'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('219','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','219','PE8_10 Industrial design (product design, ergonomics, man-machine interfaces, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '220')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '220',title = 'PE8_11 Sustainable design (for recycling, for environment, eco-design) ' WHERE idsettoreerc = '220'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('220','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','220','PE8_11 Sustainable design (for recycling, for environment, eco-design) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '221')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '221',title = 'PE8_12 Lightweight construction, textile technology ' WHERE idsettoreerc = '221'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('221','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','221','PE8_12 Lightweight construction, textile technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '222')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '222',title = 'PE8_13 Industrial bioengineering ' WHERE idsettoreerc = '222'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('222','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','222','PE8_13 Industrial bioengineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '223')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '223',title = 'PE9 Universe Sciences: Astro-physics/chemistry/biology, solar system, stellar, galactic and extragalactic astronomy, planetary systems, cosmology, space science, instrumentation ' WHERE idsettoreerc = '223'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('223','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','223','PE9 Universe Sciences: Astro-physics/chemistry/biology, solar system, stellar, galactic and extragalactic astronomy, planetary systems, cosmology, space science, instrumentation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '224')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '224',title = 'PE9_1 Solar and interplanetary physics ' WHERE idsettoreerc = '224'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('224','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','224','PE9_1 Solar and interplanetary physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '225')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '225',title = 'PE9_2 Planetary systems sciences ' WHERE idsettoreerc = '225'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('225','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','225','PE9_2 Planetary systems sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '226')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '226',title = 'PE9_3 Interstellar medium ' WHERE idsettoreerc = '226'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('226','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','226','PE9_3 Interstellar medium ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '227')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '227',title = 'PE9_4 Formation of stars and planets ' WHERE idsettoreerc = '227'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('227','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','227','PE9_4 Formation of stars and planets ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '228')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '228',title = 'PE9_5 Astrobiology ' WHERE idsettoreerc = '228'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('228','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','228','PE9_5 Astrobiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '229')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '229',title = 'PE9_6 Stars and stellar systems ' WHERE idsettoreerc = '229'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('229','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','229','PE9_6 Stars and stellar systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '230')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '230',title = 'PE9_7 The Galaxy ' WHERE idsettoreerc = '230'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('230','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','230','PE9_7 The Galaxy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '231')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '231',title = 'PE9_8 Formation and evolution of galaxies ' WHERE idsettoreerc = '231'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('231','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','231','PE9_8 Formation and evolution of galaxies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '232')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '232',title = 'PE9_9 Clusters of galaxies and large scale structures ' WHERE idsettoreerc = '232'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('232','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','232','PE9_9 Clusters of galaxies and large scale structures ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '233')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '233',title = 'PE9_10 High energy and particles astronomy ñ X-rays, cosmic rays, gamma rays, neutrinos ' WHERE idsettoreerc = '233'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('233','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','233','PE9_10 High energy and particles astronomy ñ X-rays, cosmic rays, gamma rays, neutrinos ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '234')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '234',title = 'PE9_11 Relativistic astrophysics ' WHERE idsettoreerc = '234'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('234','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','234','PE9_11 Relativistic astrophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '235')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '235',title = 'PE9_12 Dark matter, dark energy ' WHERE idsettoreerc = '235'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('235','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','235','PE9_12 Dark matter, dark energy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '236')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '236',title = 'PE9_13 Gravitational astronomy ' WHERE idsettoreerc = '236'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('236','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','236','PE9_13 Gravitational astronomy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '237')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '237',title = 'PE9_14 Cosmology ' WHERE idsettoreerc = '237'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('237','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','237','PE9_14 Cosmology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '238')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '238',title = 'PE9_15 Space Sciences ' WHERE idsettoreerc = '238'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('238','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','238','PE9_15 Space Sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '239')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '239',title = 'PE9_16 Very large data bases: archiving, handling and analysis ' WHERE idsettoreerc = '239'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('239','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','239','PE9_16 Very large data bases: archiving, handling and analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '240')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '240',title = 'PE9_17 Instrumentation - telescopes, detectors and techniques ' WHERE idsettoreerc = '240'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('240','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','240','PE9_17 Instrumentation - telescopes, detectors and techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '241')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '241',title = 'PE10 Earth System Science: Physical geography, geology, geophysics, atmospheric sciences, oceanography, climatology, cryology, ecology, global environmental change, biogeochemical cycles, natural resources management ' WHERE idsettoreerc = '241'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('241','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','241','PE10 Earth System Science: Physical geography, geology, geophysics, atmospheric sciences, oceanography, climatology, cryology, ecology, global environmental change, biogeochemical cycles, natural resources management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '242')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '242',title = 'PE10_1 Atmospheric chemistry, atmospheric composition, air pollution ' WHERE idsettoreerc = '242'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('242','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','242','PE10_1 Atmospheric chemistry, atmospheric composition, air pollution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '243')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '243',title = 'PE10_2 Meteorology, atmospheric physics and dynamics ' WHERE idsettoreerc = '243'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('243','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','243','PE10_2 Meteorology, atmospheric physics and dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '244')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '244',title = 'PE10_3 Climatology and climate change ' WHERE idsettoreerc = '244'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('244','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','244','PE10_3 Climatology and climate change ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '245')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '245',title = 'PE10_4 Terrestrial ecology, land cover change ' WHERE idsettoreerc = '245'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('245','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','245','PE10_4 Terrestrial ecology, land cover change ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '246')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '246',title = 'PE10_5 Geology, tectonics, volcanology ' WHERE idsettoreerc = '246'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('246','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','246','PE10_5 Geology, tectonics, volcanology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '247')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '247',title = 'PE10_6 Palaeoclimatology, palaeoecology ' WHERE idsettoreerc = '247'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('247','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','247','PE10_6 Palaeoclimatology, palaeoecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '248')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '248',title = 'PE10_7 Physics of earthís interior, seismology, volcanology ' WHERE idsettoreerc = '248'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('248','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','248','PE10_7 Physics of earthís interior, seismology, volcanology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '249')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '249',title = 'PE10_8 Oceanography (physical, chemical, biological, geological) ' WHERE idsettoreerc = '249'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('249','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','249','PE10_8 Oceanography (physical, chemical, biological, geological) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '250')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '250',title = 'PE10_9 Biogeochemistry, biogeochemical cycles, environmental chemistry ' WHERE idsettoreerc = '250'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('250','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','250','PE10_9 Biogeochemistry, biogeochemical cycles, environmental chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '251')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '251',title = 'PE10_10 Mineralogy, petrology, igneous petrology, metamorphic petrology ' WHERE idsettoreerc = '251'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('251','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','251','PE10_10 Mineralogy, petrology, igneous petrology, metamorphic petrology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '252')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '252',title = 'PE10_11 Geochemistry, crystal chemistry, isotope geochemistry, thermodynamics ' WHERE idsettoreerc = '252'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('252','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','252','PE10_11 Geochemistry, crystal chemistry, isotope geochemistry, thermodynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '253')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '253',title = 'PE10_12 Sedimentology, soil science, palaeontology, earth evolution ' WHERE idsettoreerc = '253'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('253','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','253','PE10_12 Sedimentology, soil science, palaeontology, earth evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '254')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '254',title = 'PE10_13 Physical geography ' WHERE idsettoreerc = '254'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('254','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','254','PE10_13 Physical geography ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '255')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '255',title = 'PE10_14 Earth observations from space/remote sensing ' WHERE idsettoreerc = '255'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('255','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','255','PE10_14 Earth observations from space/remote sensing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '256')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '256',title = 'PE10_15 Geomagnetism, palaeomagnetism ' WHERE idsettoreerc = '256'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('256','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','256','PE10_15 Geomagnetism, palaeomagnetism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '257')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '257',title = 'PE10_16 Ozone, upper atmosphere, ionosphere ' WHERE idsettoreerc = '257'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('257','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','257','PE10_16 Ozone, upper atmosphere, ionosphere ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '258')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '258',title = 'PE10_17 Hydrology, water and soil pollution ' WHERE idsettoreerc = '258'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('258','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','258','PE10_17 Hydrology, water and soil pollution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '259')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '259',title = 'PE10_18 Cryosphere, dynamics of snow and ice cover, sea ice, permafrosts and ice sheets ' WHERE idsettoreerc = '259'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('259','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','259','PE10_18 Cryosphere, dynamics of snow and ice cover, sea ice, permafrosts and ice sheets ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '260')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '260',title = 'LS - LIFE SCIENCES ' WHERE idsettoreerc = '260'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('260','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','260','LS - LIFE SCIENCES ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '261')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '261',title = 'LS1 Molecular and Structural Biology and Biochemistry: Molecular synthesis, modification and interaction, biochemistry, biophysics, structural biology, metabolism, signal transduction ' WHERE idsettoreerc = '261'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('261','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','261','LS1 Molecular and Structural Biology and Biochemistry: Molecular synthesis, modification and interaction, biochemistry, biophysics, structural biology, metabolism, signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '262')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '262',title = 'LS1_1 Molecular interactions ' WHERE idsettoreerc = '262'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('262','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','262','LS1_1 Molecular interactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '263')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '263',title = 'LS1_2 General biochemistry and metabolism ' WHERE idsettoreerc = '263'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('263','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','263','LS1_2 General biochemistry and metabolism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '264')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '264',title = 'LS1_3 DNA synthesis, modification, repair, recombination and degradation ' WHERE idsettoreerc = '264'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('264','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','264','LS1_3 DNA synthesis, modification, repair, recombination and degradation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '265')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '265',title = 'LS1_4 RNA synthesis, processing, modification and degradation ' WHERE idsettoreerc = '265'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('265','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','265','LS1_4 RNA synthesis, processing, modification and degradation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '266')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '266',title = 'LS1_5 Protein synthesis, modification and turnover ' WHERE idsettoreerc = '266'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('266','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','266','LS1_5 Protein synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '267')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '267',title = 'LS1_6 Lipid synthesis, modification and turnover ' WHERE idsettoreerc = '267'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('267','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','267','LS1_6 Lipid synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '268')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '268',title = 'LS1_7 Carbohydrate synthesis, modification and turnover ' WHERE idsettoreerc = '268'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('268','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','268','LS1_7 Carbohydrate synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '269')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '269',title = 'LS1_8 Biophysics (e.g. transport mechanisms, bioenergetics, fluorescence) ' WHERE idsettoreerc = '269'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('269','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','269','LS1_8 Biophysics (e.g. transport mechanisms, bioenergetics, fluorescence) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '270')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '270',title = 'LS1_9 Structural biology (crystallography and EM) ' WHERE idsettoreerc = '270'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('270','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','270','LS1_9 Structural biology (crystallography and EM) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '271')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '271',title = 'LS1_10 Structural biology (NMR) ' WHERE idsettoreerc = '271'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('271','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','271','LS1_10 Structural biology (NMR) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '272')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '272',title = 'LS1_11 Biochemistry and molecular mechanisms of signal transduction ' WHERE idsettoreerc = '272'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('272','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','272','LS1_11 Biochemistry and molecular mechanisms of signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '273')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '273',title = 'LS2 Genetics, Genomics, Bioinformatics and Systems Biology: Molecular and population genetics, genomics, transcriptomics, proteomics, metabolomics, bioinformatics, computational biology, biostatistics, biological modelling and simulation, systems biology, genetic epidemiology ' WHERE idsettoreerc = '273'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('273','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','273','LS2 Genetics, Genomics, Bioinformatics and Systems Biology: Molecular and population genetics, genomics, transcriptomics, proteomics, metabolomics, bioinformatics, computational biology, biostatistics, biological modelling and simulation, systems biology, genetic epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '274')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '274',title = 'LS2_1 Genomics, comparative genomics, functional genomics ' WHERE idsettoreerc = '274'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('274','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','274','LS2_1 Genomics, comparative genomics, functional genomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '275')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '275',title = 'LS2_2 Transcriptomics ' WHERE idsettoreerc = '275'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('275','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','275','LS2_2 Transcriptomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '276')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '276',title = 'LS2_3 Proteomics ' WHERE idsettoreerc = '276'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('276','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','276','LS2_3 Proteomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '277')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '277',title = 'LS2_4 Metabolomics ' WHERE idsettoreerc = '277'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('277','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','277','LS2_4 Metabolomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '278')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '278',title = 'LS2_5 Glycomics ' WHERE idsettoreerc = '278'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('278','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','278','LS2_5 Glycomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '279')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '279',title = 'LS2_6 Molecular genetics, reverse genetics and RNAi ' WHERE idsettoreerc = '279'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('279','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','279','LS2_6 Molecular genetics, reverse genetics and RNAi ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '280')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '280',title = 'LS2_7 Quantitative genetics ' WHERE idsettoreerc = '280'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('280','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','280','LS2_7 Quantitative genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '281')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '281',title = 'LS2_8 Epigenetics and gene regulation ' WHERE idsettoreerc = '281'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('281','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','281','LS2_8 Epigenetics and gene regulation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '282')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '282',title = 'LS2_9 Genetic epidemiology ' WHERE idsettoreerc = '282'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('282','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','282','LS2_9 Genetic epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '283')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '283',title = 'LS2_10 Bioinformatics ' WHERE idsettoreerc = '283'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('283','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','283','LS2_10 Bioinformatics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '284')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '284',title = 'LS2_11 Computational biology ' WHERE idsettoreerc = '284'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('284','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','284','LS2_11 Computational biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '285')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '285',title = 'LS2_12 Biostatistics ' WHERE idsettoreerc = '285'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('285','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','285','LS2_12 Biostatistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '286')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '286',title = 'LS2_13 Systems biology ' WHERE idsettoreerc = '286'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('286','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','286','LS2_13 Systems biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '287')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '287',title = 'LS2_14 Biological systems analysis, modelling and simulation ' WHERE idsettoreerc = '287'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('287','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','287','LS2_14 Biological systems analysis, modelling and simulation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '288')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '288',title = 'LS3 Cellular and Developmental Biology: Cell biology, cell physiology, signal transduction, organogenesis, developmental genetics, pattern formation in plants and animals, stem cell biology ' WHERE idsettoreerc = '288'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('288','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','288','LS3 Cellular and Developmental Biology: Cell biology, cell physiology, signal transduction, organogenesis, developmental genetics, pattern formation in plants and animals, stem cell biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '289')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '289',title = 'LS3_1 Morphology and functional imaging of cells ' WHERE idsettoreerc = '289'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('289','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','289','LS3_1 Morphology and functional imaging of cells ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '290')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '290',title = 'LS3_2 Cell biology and molecular transport mechanisms ' WHERE idsettoreerc = '290'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('290','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','290','LS3_2 Cell biology and molecular transport mechanisms ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '291')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '291',title = 'LS3_3 Cell cycle and division ' WHERE idsettoreerc = '291'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('291','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','291','LS3_3 Cell cycle and division ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '292')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '292',title = 'LS3_4 Apoptosis ' WHERE idsettoreerc = '292'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('292','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','292','LS3_4 Apoptosis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '293')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '293',title = 'LS3_5 Cell differentiation, physiology and dynamics ' WHERE idsettoreerc = '293'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('293','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','293','LS3_5 Cell differentiation, physiology and dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '294')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '294',title = 'LS3_6 Organelle biology ' WHERE idsettoreerc = '294'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('294','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','294','LS3_6 Organelle biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '295')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '295',title = 'LS3_7 Cell signalling and cellular interactions ' WHERE idsettoreerc = '295'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('295','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','295','LS3_7 Cell signalling and cellular interactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '296')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '296',title = 'LS3_8 Signal transduction ' WHERE idsettoreerc = '296'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('296','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','296','LS3_8 Signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '297')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '297',title = 'LS3_9 Development, developmental genetics, pattern formation and embryology in animals ' WHERE idsettoreerc = '297'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('297','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','297','LS3_9 Development, developmental genetics, pattern formation and embryology in animals ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '298')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '298',title = 'LS3_10 Development, developmental genetics, pattern formation and embryology in plants ' WHERE idsettoreerc = '298'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('298','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','298','LS3_10 Development, developmental genetics, pattern formation and embryology in plants ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '299')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '299',title = 'LS3_11 Cell genetics ' WHERE idsettoreerc = '299'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('299','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','299','LS3_11 Cell genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '300')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '300',title = 'LS3_12 Stem cell biology ' WHERE idsettoreerc = '300'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('300','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','300','LS3_12 Stem cell biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '301')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '301',title = 'LS4 Physiology, Pathophysiology and Endocrinology: Organ physiology, pathophysiology, endocrinology, metabolism, ageing, tumorigenesis, cardiovascular disease, metabolic syndrome ' WHERE idsettoreerc = '301'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('301','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','301','LS4 Physiology, Pathophysiology and Endocrinology: Organ physiology, pathophysiology, endocrinology, metabolism, ageing, tumorigenesis, cardiovascular disease, metabolic syndrome ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '302')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '302',title = 'LS4_1 Organ physiology and pathophysiology ' WHERE idsettoreerc = '302'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('302','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','302','LS4_1 Organ physiology and pathophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '303')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '303',title = 'LS4_2 Comparative physiology and pathophysiology ' WHERE idsettoreerc = '303'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('303','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','303','LS4_2 Comparative physiology and pathophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '304')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '304',title = 'LS4_3 Endocrinology ' WHERE idsettoreerc = '304'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('304','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','304','LS4_3 Endocrinology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '305')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '305',title = 'LS4_4 Ageing ' WHERE idsettoreerc = '305'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('305','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','305','LS4_4 Ageing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '306')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '306',title = 'LS4_5 Metabolism, biological basis of metabolism related disorders ' WHERE idsettoreerc = '306'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('306','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','306','LS4_5 Metabolism, biological basis of metabolism related disorders ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '307')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '307',title = 'LS4_6 Cancer and its biological basis ' WHERE idsettoreerc = '307'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('307','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','307','LS4_6 Cancer and its biological basis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '308')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '308',title = 'LS4_7 Cardiovascular diseases ' WHERE idsettoreerc = '308'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('308','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','308','LS4_7 Cardiovascular diseases ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '309')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '309',title = 'LS4_8 Non-communicable diseases (except for neural/psychiatric, immunityrelated, metabolism-related disorders, cancer and cardiovascular diseases) ' WHERE idsettoreerc = '309'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('309','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','309','LS4_8 Non-communicable diseases (except for neural/psychiatric, immunityrelated, metabolism-related disorders, cancer and cardiovascular diseases) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '310')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '310',title = 'LS5 Neurosciences and Neural Disorders: Neurobiology, neuroanatomy, neurophysiology, neurochemistry, neuropharmacology, neuroimaging, systems neuroscience, neurological and psychiatric disorders ' WHERE idsettoreerc = '310'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('310','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','310','LS5 Neurosciences and Neural Disorders: Neurobiology, neuroanatomy, neurophysiology, neurochemistry, neuropharmacology, neuroimaging, systems neuroscience, neurological and psychiatric disorders ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '311')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '311',title = 'LS5_1 Neuroanatomy and neurophysiology ' WHERE idsettoreerc = '311'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('311','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','311','LS5_1 Neuroanatomy and neurophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '312')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '312',title = 'LS5_2 Molecular and cellular neuroscience ' WHERE idsettoreerc = '312'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('312','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','312','LS5_2 Molecular and cellular neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '313')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '313',title = 'LS5_3 Neurochemistry and neuropharmacology ' WHERE idsettoreerc = '313'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('313','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','313','LS5_3 Neurochemistry and neuropharmacology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '314')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '314',title = 'LS5_4 Sensory systems (e.g. visual system, auditory system) ' WHERE idsettoreerc = '314'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('314','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','314','LS5_4 Sensory systems (e.g. visual system, auditory system) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '315')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '315',title = 'LS5_5 Mechanisms of pain ' WHERE idsettoreerc = '315'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('315','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','315','LS5_5 Mechanisms of pain ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '316')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '316',title = 'LS5_6 Developmental neurobiology ' WHERE idsettoreerc = '316'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('316','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','316','LS5_6 Developmental neurobiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '317')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '317',title = 'LS5_7 Cognition (e.g. learning, memory, emotions, speech) ' WHERE idsettoreerc = '317'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('317','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','317','LS5_7 Cognition (e.g. learning, memory, emotions, speech) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '318')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '318',title = 'LS5_8 Behavioural neuroscience (e.g. sleep, consciousness, handedness) ' WHERE idsettoreerc = '318'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('318','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','318','LS5_8 Behavioural neuroscience (e.g. sleep, consciousness, handedness) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '319')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '319',title = 'LS5_9 Systems neuroscience ' WHERE idsettoreerc = '319'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('319','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','319','LS5_9 Systems neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '320')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '320',title = 'LS5_10 Neuroimaging and computational neuroscience ' WHERE idsettoreerc = '320'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('320','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','320','LS5_10 Neuroimaging and computational neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '321')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '321',title = 'LS5_11 Neurological disorders (e.g. Alzheimerís disease, Huntingtonís disease, Parkinsonís disease) ' WHERE idsettoreerc = '321'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('321','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','321','LS5_11 Neurological disorders (e.g. Alzheimerís disease, Huntingtonís disease, Parkinsonís disease) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '322')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '322',title = 'LS5_12 Psychiatric disorders (e.g. schizophrenia, autism, Touretteís syndrome, obsessive compulsive disorder, depression, bipolar disorder, attention deficit hyperactivity disorder) ' WHERE idsettoreerc = '322'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('322','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','322','LS5_12 Psychiatric disorders (e.g. schizophrenia, autism, Touretteís syndrome, obsessive compulsive disorder, depression, bipolar disorder, attention deficit hyperactivity disorder) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '323')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '323',title = 'LS6 Immunity and Infection: The immune system and related disorders, infectious agents and diseases, prevention and treatment of infection ' WHERE idsettoreerc = '323'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('323','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','323','LS6 Immunity and Infection: The immune system and related disorders, infectious agents and diseases, prevention and treatment of infection ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '324')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '324',title = 'LS6_1 Innate immunity and inflammation ' WHERE idsettoreerc = '324'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('324','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','324','LS6_1 Innate immunity and inflammation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '325')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '325',title = 'LS6_2 Adaptive immunity ' WHERE idsettoreerc = '325'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('325','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','325','LS6_2 Adaptive immunity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '326')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '326',title = 'LS6_3 Phagocytosis and cellular immunity ' WHERE idsettoreerc = '326'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('326','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','326','LS6_3 Phagocytosis and cellular immunity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '327')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '327',title = 'LS6_4 Immunosignalling ' WHERE idsettoreerc = '327'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('327','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','327','LS6_4 Immunosignalling ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '328')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '328',title = 'LS6_5 Immunological memory and tolerance ' WHERE idsettoreerc = '328'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('328','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','328','LS6_5 Immunological memory and tolerance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '329')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '329',title = 'LS6_6 Immunogenetics ' WHERE idsettoreerc = '329'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('329','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','329','LS6_6 Immunogenetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '330')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '330',title = 'LS6_7 Microbiology ' WHERE idsettoreerc = '330'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('330','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','330','LS6_7 Microbiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '331')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '331',title = 'LS6_8 Virology ' WHERE idsettoreerc = '331'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('331','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','331','LS6_8 Virology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '332')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '332',title = 'LS6_9 Bacteriology ' WHERE idsettoreerc = '332'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('332','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','332','LS6_9 Bacteriology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '333')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '333',title = 'LS6_10 Parasitology ' WHERE idsettoreerc = '333'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('333','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','333','LS6_10 Parasitology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '334')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '334',title = 'LS6_11 Prevention and treatment of infection by pathogens (e.g. vaccination, antibiotics, fungicide) ' WHERE idsettoreerc = '334'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('334','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','334','LS6_11 Prevention and treatment of infection by pathogens (e.g. vaccination, antibiotics, fungicide) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '335')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '335',title = 'LS6_12 Biological basis of immunity related disorders (e.g. autoimmunity) ' WHERE idsettoreerc = '335'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('335','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','335','LS6_12 Biological basis of immunity related disorders (e.g. autoimmunity) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '336')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '336',title = 'LS6_13 Veterinary medicine and infectious diseases in animals ' WHERE idsettoreerc = '336'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('336','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','336','LS6_13 Veterinary medicine and infectious diseases in animals ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '337')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '337',title = 'LS7 Diagnostic Tools, Therapies and Public Health: Aetiology, diagnosis and treatment of disease, public health, epidemiology, pharmacology, clinical medicine, regenerative medicine, medical ethics ' WHERE idsettoreerc = '337'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('337','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','337','LS7 Diagnostic Tools, Therapies and Public Health: Aetiology, diagnosis and treatment of disease, public health, epidemiology, pharmacology, clinical medicine, regenerative medicine, medical ethics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '338')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '338',title = 'LS7_1 Medical engineering and technology ' WHERE idsettoreerc = '338'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('338','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','338','LS7_1 Medical engineering and technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '339')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '339',title = 'LS7_2 Diagnostic tools (e.g. genetic, imaging) ' WHERE idsettoreerc = '339'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('339','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','339','LS7_2 Diagnostic tools (e.g. genetic, imaging) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '340')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '340',title = 'LS7_3 Pharmacology, pharmacogenomics, drug discovery and design, drug therapy ' WHERE idsettoreerc = '340'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('340','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','340','LS7_3 Pharmacology, pharmacogenomics, drug discovery and design, drug therapy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '341')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '341',title = 'LS7_4 Analgesia and Surgery ' WHERE idsettoreerc = '341'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('341','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','341','LS7_4 Analgesia and Surgery ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '342')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '342',title = 'LS7_5 Toxicology ' WHERE idsettoreerc = '342'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('342','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','342','LS7_5 Toxicology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '343')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '343',title = 'LS7_6 Gene therapy, cell therapy, regenerative medicine ' WHERE idsettoreerc = '343'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('343','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','343','LS7_6 Gene therapy, cell therapy, regenerative medicine ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '344')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '344',title = 'LS7_7 Radiation therapy ' WHERE idsettoreerc = '344'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('344','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','344','LS7_7 Radiation therapy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '345')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '345',title = 'LS7_8 Health services, health care research ' WHERE idsettoreerc = '345'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('345','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','345','LS7_8 Health services, health care research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '346')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '346',title = 'LS7_9 Public health and epidemiology ' WHERE idsettoreerc = '346'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('346','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','346','LS7_9 Public health and epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '347')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '347',title = 'LS7_10 Environment and health risks, occupational medicine ' WHERE idsettoreerc = '347'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('347','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','347','LS7_10 Environment and health risks, occupational medicine ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '348')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '348',title = 'LS7_11 Medical ethics ' WHERE idsettoreerc = '348'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('348','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','348','LS7_11 Medical ethics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '349')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '349',title = 'LS8 Evolutionary, Population and Environmental Biology: Evolution, ecology, animal behaviour, population biology, biodiversity, biogeography, marine biology, ecotoxicology, microbial ecology ' WHERE idsettoreerc = '349'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('349','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','349','LS8 Evolutionary, Population and Environmental Biology: Evolution, ecology, animal behaviour, population biology, biodiversity, biogeography, marine biology, ecotoxicology, microbial ecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '350')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '350',title = 'LS8_1 Ecology (theoretical and experimental, population, species and community level) ' WHERE idsettoreerc = '350'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('350','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','350','LS8_1 Ecology (theoretical and experimental, population, species and community level) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '351')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '351',title = 'LS8_2 Population biology, population dynamics, population genetics ' WHERE idsettoreerc = '351'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('351','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','351','LS8_2 Population biology, population dynamics, population genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '352')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '352',title = 'LS8_3 Systems evolution, biological adaptation, phylogenetics, systematics, comparative biology ' WHERE idsettoreerc = '352'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('352','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','352','LS8_3 Systems evolution, biological adaptation, phylogenetics, systematics, comparative biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '353')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '353',title = 'LS8_4 Biodiversity, conservation biology, conservation genetics, invasion biology ' WHERE idsettoreerc = '353'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('353','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','353','LS8_4 Biodiversity, conservation biology, conservation genetics, invasion biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '354')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '354',title = 'LS8_5 Evolutionary biology: evolutionary ecology and genetics, co-evolution ' WHERE idsettoreerc = '354'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('354','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','354','LS8_5 Evolutionary biology: evolutionary ecology and genetics, co-evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '355')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '355',title = 'LS8_6 Biogeography, macro-ecology ' WHERE idsettoreerc = '355'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('355','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','355','LS8_6 Biogeography, macro-ecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '356')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '356',title = 'LS8_7 Animal behaviour ' WHERE idsettoreerc = '356'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('356','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','356','LS8_7 Animal behaviour ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '357')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '357',title = 'LS8_8 Environmental and marine biology ' WHERE idsettoreerc = '357'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('357','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','357','LS8_8 Environmental and marine biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '358')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '358',title = 'LS8_9 Environmental toxicology at the population and ecosystems level ' WHERE idsettoreerc = '358'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('358','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','358','LS8_9 Environmental toxicology at the population and ecosystems level ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '359')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '359',title = 'LS8_10 Microbial ecology and evolution ' WHERE idsettoreerc = '359'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('359','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','359','LS8_10 Microbial ecology and evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '360')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '360',title = 'LS8_11 Species interactions (e.g. food-webs, symbiosis, parasitism, mutualism) ' WHERE idsettoreerc = '360'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('360','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','360','LS8_11 Species interactions (e.g. food-webs, symbiosis, parasitism, mutualism) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '361')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '361',title = 'LS9 Applied Life Sciences and Non-Medical Biotechnology: Applied plant and animal sciences, food sciences, forestry, industrial, environmental and non-medical biotechnologies, bioengineering, synthetic and chemical biology, biomimetics, bioremediation ' WHERE idsettoreerc = '361'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('361','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','361','LS9 Applied Life Sciences and Non-Medical Biotechnology: Applied plant and animal sciences, food sciences, forestry, industrial, environmental and non-medical biotechnologies, bioengineering, synthetic and chemical biology, biomimetics, bioremediation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '362')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '362',title = 'LS9_1 Non-medical biotechnology and genetic engineering (including transgenic organisms, recombinant proteins, biosensors, bioreactors, microbiology) ' WHERE idsettoreerc = '362'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('362','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','362','LS9_1 Non-medical biotechnology and genetic engineering (including transgenic organisms, recombinant proteins, biosensors, bioreactors, microbiology) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '363')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '363',title = 'LS9_2 Synthetic biology, chemical biology and bio-engineering ' WHERE idsettoreerc = '363'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('363','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','363','LS9_2 Synthetic biology, chemical biology and bio-engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '364')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '364',title = 'LS9_3 Animal sciences (including animal husbandry, aquaculture, fisheries, animal welfare) ' WHERE idsettoreerc = '364'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('364','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','364','LS9_3 Animal sciences (including animal husbandry, aquaculture, fisheries, animal welfare) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '365')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '365',title = 'LS9_4 Plant sciences (including crop production, plant breeding, agroecology, soil biology) ' WHERE idsettoreerc = '365'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('365','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','365','LS9_4 Plant sciences (including crop production, plant breeding, agroecology, soil biology) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '366')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '366',title = 'LS9_5 Food sciences (including food technology, nutrition) ' WHERE idsettoreerc = '366'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('366','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','366','LS9_5 Food sciences (including food technology, nutrition) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '367')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '367',title = 'LS9_6 Forestry and biomass production (including biofuels) ' WHERE idsettoreerc = '367'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('367','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','367','LS9_6 Forestry and biomass production (including biofuels) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '368')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '368',title = 'LS9_7 Environmental biotechnology (including bioremediation, biodegradation) ' WHERE idsettoreerc = '368'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('368','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','368','LS9_7 Environmental biotechnology (including bioremediation, biodegradation) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '369')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '369',title = 'LS9_8 Biomimetics ' WHERE idsettoreerc = '369'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('369','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','369','LS9_8 Biomimetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '370')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '370',title = 'LS9_9 Biohazards (including biological containment, biosafety, biosecurity)' WHERE idsettoreerc = '370'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('370','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','370','LS9_9 Biohazards (including biological containment, biosafety, biosecurity)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'settoreerc')
UPDATE [tabledescr] SET description = '2.7.6 Settori ERC',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:35:09.647'},lu = 'assistenza',title = 'Settori ERC' WHERE tablename = 'settoreerc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('settoreerc','2.7.6 Settori ERC','3','S',{ts '2021-02-19 17:35:09.647'},'assistenza','Settori ERC')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','settoreerc','1',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsettoreerc','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

