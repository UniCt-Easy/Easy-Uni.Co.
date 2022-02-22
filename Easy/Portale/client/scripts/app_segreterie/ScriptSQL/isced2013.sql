
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
-- CREAZIONE TABELLA isced2013 --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[isced2013]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[isced2013] (
idisced2013 int NOT NULL,
active varchar(64) NULL,
broadfield varchar(64) NULL,
detailedfield varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
narrowfield varchar(64) NULL,
sortcode varchar(64) NULL,
 CONSTRAINT xpkisced2013 PRIMARY KEY (idisced2013
)
)
END
GO

-- VERIFICA STRUTTURA isced2013 --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'idisced2013' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD idisced2013 int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('isced2013') and col.name = 'idisced2013' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [isced2013] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD active varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN active varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'broadfield' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD broadfield varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN broadfield varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'detailedfield' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD detailedfield varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN detailedfield varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'narrowfield' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD narrowfield varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN narrowfield varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'isced2013' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [isced2013] ADD sortcode varchar(64) NULL 
END
ELSE
	ALTER TABLE [isced2013] ALTER COLUMN sortcode varchar(64) NULL
GO

-- VERIFICA DI isced2013 IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'isced2013'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','isced2013','int','ASSISTENZA','idisced2013','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','active','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','broadfield','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','detailedfield','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','narrowfield','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','isced2013','varchar(64)','ASSISTENZA','sortcode','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI isced2013 IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'isced2013')
UPDATE customobject set isreal = 'S' where objectname = 'isced2013'
ELSE
INSERT INTO customobject (objectname, isreal) values('isced2013', 'S')
GO

-- GENERAZIONE DATI PER isced2013 --
IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '1')
UPDATE [isced2013] SET active = 'S',broadfield = '00 Generic programmes and qualifications',detailedfield = '0011 Basic programmes and qualifications',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '001 Basic programmes and qualifications',sortcode = '1' WHERE idisced2013 = '1'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('1','S','00 Generic programmes and qualifications','0011 Basic programmes and qualifications',{ts '2018-06-11 11:35:00.653'},'ferdinando','001 Basic programmes and qualifications','1')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '2')
UPDATE [isced2013] SET active = 'S',broadfield = '00 Generic programmes and qualifications',detailedfield = '0021 Literacy and numeracy ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '002 Literacy and numeracy',sortcode = '2' WHERE idisced2013 = '2'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('2','S','00 Generic programmes and qualifications','0021 Literacy and numeracy ',{ts '2018-06-11 11:35:00.653'},'ferdinando','002 Literacy and numeracy','2')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '3')
UPDATE [isced2013] SET active = 'S',broadfield = '00 Generic programmes and qualifications',detailedfield = '0031 Personal skills and development',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '003 Personal skills and development',sortcode = '3' WHERE idisced2013 = '3'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('3','S','00 Generic programmes and qualifications','0031 Personal skills and development',{ts '2018-06-11 11:35:00.653'},'ferdinando','003 Personal skills and development','3')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '4')
UPDATE [isced2013] SET active = 'S',broadfield = '01 Education',detailedfield = '0112 Training for pre-school teachers',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '011 Education',sortcode = '4' WHERE idisced2013 = '4'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('4','S','01 Education','0112 Training for pre-school teachers',{ts '2018-06-11 11:35:00.653'},'ferdinando','011 Education','4')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '5')
UPDATE [isced2013] SET active = 'S',broadfield = '01 Education',detailedfield = '0113 Teacher training without subject specialisation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '011 Education',sortcode = '5' WHERE idisced2013 = '5'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('5','S','01 Education','0113 Teacher training without subject specialisation',{ts '2018-06-11 11:35:00.653'},'ferdinando','011 Education','5')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '6')
UPDATE [isced2013] SET active = 'S',broadfield = '01 Education',detailedfield = '0114 Teacher training with subject specialisation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '011 Education',sortcode = '6' WHERE idisced2013 = '6'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('6','S','01 Education','0114 Teacher training with subject specialisation',{ts '2018-06-11 11:35:00.653'},'ferdinando','011 Education','6')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '7')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0211 Audio-visual techniques and media production',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '021 Arts ',sortcode = '7' WHERE idisced2013 = '7'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('7','S','02 Arts and humanities','0211 Audio-visual techniques and media production',{ts '2018-06-11 11:35:00.653'},'ferdinando','021 Arts ','7')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '8')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0212 Fashion, interior and industrial design',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '021 Arts ',sortcode = '8' WHERE idisced2013 = '8'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('8','S','02 Arts and humanities','0212 Fashion, interior and industrial design',{ts '2018-06-11 11:35:00.653'},'ferdinando','021 Arts ','8')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '9')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0213 Fine arts',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '021 Arts ',sortcode = '9' WHERE idisced2013 = '9'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('9','S','02 Arts and humanities','0213 Fine arts',{ts '2018-06-11 11:35:00.653'},'ferdinando','021 Arts ','9')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '10')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0214 Handicrafts',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '021 Arts ',sortcode = '10' WHERE idisced2013 = '10'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('10','S','02 Arts and humanities','0214 Handicrafts',{ts '2018-06-11 11:35:00.653'},'ferdinando','021 Arts ','10')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '11')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0215 Music and performing arts',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '021 Arts ',sortcode = '11' WHERE idisced2013 = '11'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('11','S','02 Arts and humanities','0215 Music and performing arts',{ts '2018-06-11 11:35:00.653'},'ferdinando','021 Arts ','11')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '12')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0221 Religion and theology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '022 Humanities (except languages) ',sortcode = '12' WHERE idisced2013 = '12'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('12','S','02 Arts and humanities','0221 Religion and theology',{ts '2018-06-11 11:35:00.653'},'ferdinando','022 Humanities (except languages) ','12')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '13')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0222 History and archaeology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '022 Humanities (except languages) ',sortcode = '13' WHERE idisced2013 = '13'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('13','S','02 Arts and humanities','0222 History and archaeology',{ts '2018-06-11 11:35:00.653'},'ferdinando','022 Humanities (except languages) ','13')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '14')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0223 Philosophy and ethics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '022 Humanities (except languages) ',sortcode = '14' WHERE idisced2013 = '14'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('14','S','02 Arts and humanities','0223 Philosophy and ethics',{ts '2018-06-11 11:35:00.653'},'ferdinando','022 Humanities (except languages) ','14')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '15')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0231 Language acquisition',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '023 Languages ',sortcode = '15' WHERE idisced2013 = '15'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('15','S','02 Arts and humanities','0231 Language acquisition',{ts '2018-06-11 11:35:00.653'},'ferdinando','023 Languages ','15')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '16')
UPDATE [isced2013] SET active = 'S',broadfield = '02 Arts and humanities',detailedfield = '0232 Literature and linguistics ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '023 Languages ',sortcode = '16' WHERE idisced2013 = '16'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('16','S','02 Arts and humanities','0232 Literature and linguistics ',{ts '2018-06-11 11:35:00.653'},'ferdinando','023 Languages ','16')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '17')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0311 Economics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '031 Social and behavioural sciences ',sortcode = '17' WHERE idisced2013 = '17'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('17','S','03 Social sciences, journalism and information','0311 Economics',{ts '2018-06-11 11:35:00.653'},'ferdinando','031 Social and behavioural sciences ','17')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '18')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0312 Political sciences and civics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '031 Social and behavioural sciences ',sortcode = '18' WHERE idisced2013 = '18'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('18','S','03 Social sciences, journalism and information','0312 Political sciences and civics',{ts '2018-06-11 11:35:00.653'},'ferdinando','031 Social and behavioural sciences ','18')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '19')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0313 Psychology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '031 Social and behavioural sciences ',sortcode = '19' WHERE idisced2013 = '19'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('19','S','03 Social sciences, journalism and information','0313 Psychology',{ts '2018-06-11 11:35:00.653'},'ferdinando','031 Social and behavioural sciences ','19')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '20')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0314 Sociology and cultural studies',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '031 Social and behavioural sciences ',sortcode = '20' WHERE idisced2013 = '20'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('20','S','03 Social sciences, journalism and information','0314 Sociology and cultural studies',{ts '2018-06-11 11:35:00.653'},'ferdinando','031 Social and behavioural sciences ','20')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '21')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0321 Journalism and reporting',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '032 Journalism and information ',sortcode = '21' WHERE idisced2013 = '21'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('21','S','03 Social sciences, journalism and information','0321 Journalism and reporting',{ts '2018-06-11 11:35:00.653'},'ferdinando','032 Journalism and information ','21')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '22')
UPDATE [isced2013] SET active = 'S',broadfield = '03 Social sciences, journalism and information',detailedfield = '0322 Library, information and archival studies',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '032 Journalism and information ',sortcode = '22' WHERE idisced2013 = '22'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('22','S','03 Social sciences, journalism and information','0322 Library, information and archival studies',{ts '2018-06-11 11:35:00.653'},'ferdinando','032 Journalism and information ','22')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '23')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0411 Accounting and taxation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '23' WHERE idisced2013 = '23'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('23','S','04 Business, administration and law','0411 Accounting and taxation',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','23')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '24')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0412 Finance, banking and insurance',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '24' WHERE idisced2013 = '24'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('24','S','04 Business, administration and law','0412 Finance, banking and insurance',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','24')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '25')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0413 Management and administration',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '25' WHERE idisced2013 = '25'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('25','S','04 Business, administration and law','0413 Management and administration',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','25')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '26')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0414 Marketing and advertising',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '26' WHERE idisced2013 = '26'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('26','S','04 Business, administration and law','0414 Marketing and advertising',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','26')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '27')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0415 Secretarial and office work',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '27' WHERE idisced2013 = '27'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('27','S','04 Business, administration and law','0415 Secretarial and office work',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','27')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '28')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0416 Wholesale and retail sales',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '28' WHERE idisced2013 = '28'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('28','S','04 Business, administration and law','0416 Wholesale and retail sales',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','28')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '29')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0417 Work skills',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '041 Business and administration ',sortcode = '29' WHERE idisced2013 = '29'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('29','S','04 Business, administration and law','0417 Work skills',{ts '2018-06-11 11:35:00.653'},'ferdinando','041 Business and administration ','29')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '30')
UPDATE [isced2013] SET active = 'S',broadfield = '04 Business, administration and law',detailedfield = '0421 Law',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '042 Law ',sortcode = '30' WHERE idisced2013 = '30'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('30','S','04 Business, administration and law','0421 Law',{ts '2018-06-11 11:35:00.653'},'ferdinando','042 Law ','30')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '31')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0511 Biology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '051 Biological and related sciences ',sortcode = '31' WHERE idisced2013 = '31'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('31','S','05 Natural sciences, mathematics and statistics','0511 Biology',{ts '2018-06-11 11:35:00.653'},'ferdinando','051 Biological and related sciences ','31')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '32')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0512 Biochemistry',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '051 Biological and related sciences ',sortcode = '32' WHERE idisced2013 = '32'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('32','S','05 Natural sciences, mathematics and statistics','0512 Biochemistry',{ts '2018-06-11 11:35:00.653'},'ferdinando','051 Biological and related sciences ','32')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '33')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0521 Environmental sciences',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '052 Environment ',sortcode = '33' WHERE idisced2013 = '33'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('33','S','05 Natural sciences, mathematics and statistics','0521 Environmental sciences',{ts '2018-06-11 11:35:00.653'},'ferdinando','052 Environment ','33')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '34')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0522 Natural environments and wildlife',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '052 Environment ',sortcode = '34' WHERE idisced2013 = '34'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('34','S','05 Natural sciences, mathematics and statistics','0522 Natural environments and wildlife',{ts '2018-06-11 11:35:00.653'},'ferdinando','052 Environment ','34')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '35')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0531 Chemistry',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '053 Physical sciences ',sortcode = '35' WHERE idisced2013 = '35'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('35','S','05 Natural sciences, mathematics and statistics','0531 Chemistry',{ts '2018-06-11 11:35:00.653'},'ferdinando','053 Physical sciences ','35')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '36')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0532 Earth sciences',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '053 Physical sciences ',sortcode = '36' WHERE idisced2013 = '36'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('36','S','05 Natural sciences, mathematics and statistics','0532 Earth sciences',{ts '2018-06-11 11:35:00.653'},'ferdinando','053 Physical sciences ','36')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '37')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0533 Physics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '053 Physical sciences ',sortcode = '37' WHERE idisced2013 = '37'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('37','S','05 Natural sciences, mathematics and statistics','0533 Physics',{ts '2018-06-11 11:35:00.653'},'ferdinando','053 Physical sciences ','37')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '38')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0541 Mathematics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '054 Mathematics and statistics ',sortcode = '38' WHERE idisced2013 = '38'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('38','S','05 Natural sciences, mathematics and statistics','0541 Mathematics',{ts '2018-06-11 11:35:00.653'},'ferdinando','054 Mathematics and statistics ','38')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '39')
UPDATE [isced2013] SET active = 'S',broadfield = '05 Natural sciences, mathematics and statistics',detailedfield = '0542 Statistics',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '054 Mathematics and statistics ',sortcode = '39' WHERE idisced2013 = '39'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('39','S','05 Natural sciences, mathematics and statistics','0542 Statistics',{ts '2018-06-11 11:35:00.653'},'ferdinando','054 Mathematics and statistics ','39')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '40')
UPDATE [isced2013] SET active = 'S',broadfield = '06 Information and Communication Technologies (ICTs)',detailedfield = '0611 Computer use',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '061 Information and Communication Technologies (ICTs)',sortcode = '40' WHERE idisced2013 = '40'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('40','S','06 Information and Communication Technologies (ICTs)','0611 Computer use',{ts '2018-06-11 11:35:00.653'},'ferdinando','061 Information and Communication Technologies (ICTs)','40')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '41')
UPDATE [isced2013] SET active = 'S',broadfield = '06 Information and Communication Technologies (ICTs)',detailedfield = '0612 Database and network design and administration',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '061 Information and Communication Technologies (ICTs)',sortcode = '41' WHERE idisced2013 = '41'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('41','S','06 Information and Communication Technologies (ICTs)','0612 Database and network design and administration',{ts '2018-06-11 11:35:00.653'},'ferdinando','061 Information and Communication Technologies (ICTs)','41')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '42')
UPDATE [isced2013] SET active = 'S',broadfield = '06 Information and Communication Technologies (ICTs)',detailedfield = '0613 Software and applications development and analysis',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '061 Information and Communication Technologies (ICTs)',sortcode = '42' WHERE idisced2013 = '42'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('42','S','06 Information and Communication Technologies (ICTs)','0613 Software and applications development and analysis',{ts '2018-06-11 11:35:00.653'},'ferdinando','061 Information and Communication Technologies (ICTs)','42')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '43')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0711 Chemical engineering and processes',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '43' WHERE idisced2013 = '43'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('43','S','07 Engineering, manufacturing and construction','0711 Chemical engineering and processes',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','43')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '44')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0712 Environmental protection technology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '44' WHERE idisced2013 = '44'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('44','S','07 Engineering, manufacturing and construction','0712 Environmental protection technology',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','44')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '45')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0713 Electricity and energy',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '45' WHERE idisced2013 = '45'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('45','S','07 Engineering, manufacturing and construction','0713 Electricity and energy',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','45')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '46')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0714 Electronics and automation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '46' WHERE idisced2013 = '46'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('46','S','07 Engineering, manufacturing and construction','0714 Electronics and automation',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','46')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '47')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0715 Mechanics and metal trades',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '47' WHERE idisced2013 = '47'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('47','S','07 Engineering, manufacturing and construction','0715 Mechanics and metal trades',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','47')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '48')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0716 Motor vehicles, ships and aircraft',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '071 Engineering and engineering trades',sortcode = '48' WHERE idisced2013 = '48'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('48','S','07 Engineering, manufacturing and construction','0716 Motor vehicles, ships and aircraft',{ts '2018-06-11 11:35:00.653'},'ferdinando','071 Engineering and engineering trades','48')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '49')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0721 Food processing',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '072 Manufacturing and processing ',sortcode = '49' WHERE idisced2013 = '49'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('49','S','07 Engineering, manufacturing and construction','0721 Food processing',{ts '2018-06-11 11:35:00.653'},'ferdinando','072 Manufacturing and processing ','49')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '50')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0722 Materials (glass, paper, plastic and wood)',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '072 Manufacturing and processing ',sortcode = '50' WHERE idisced2013 = '50'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('50','S','07 Engineering, manufacturing and construction','0722 Materials (glass, paper, plastic and wood)',{ts '2018-06-11 11:35:00.653'},'ferdinando','072 Manufacturing and processing ','50')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '51')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0723 Textiles (clothes, footwear and leather)',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '072 Manufacturing and processing ',sortcode = '51' WHERE idisced2013 = '51'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('51','S','07 Engineering, manufacturing and construction','0723 Textiles (clothes, footwear and leather)',{ts '2018-06-11 11:35:00.653'},'ferdinando','072 Manufacturing and processing ','51')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '52')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0724 Mining and extraction',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '072 Manufacturing and processing ',sortcode = '52' WHERE idisced2013 = '52'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('52','S','07 Engineering, manufacturing and construction','0724 Mining and extraction',{ts '2018-06-11 11:35:00.653'},'ferdinando','072 Manufacturing and processing ','52')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '53')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0731 Architecture and town planning',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '073 Architecture and construction ',sortcode = '53' WHERE idisced2013 = '53'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('53','S','07 Engineering, manufacturing and construction','0731 Architecture and town planning',{ts '2018-06-11 11:35:00.653'},'ferdinando','073 Architecture and construction ','53')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '54')
UPDATE [isced2013] SET active = 'S',broadfield = '07 Engineering, manufacturing and construction',detailedfield = '0732 Building and civil engineering',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '073 Architecture and construction ',sortcode = '54' WHERE idisced2013 = '54'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('54','S','07 Engineering, manufacturing and construction','0732 Building and civil engineering',{ts '2018-06-11 11:35:00.653'},'ferdinando','073 Architecture and construction ','54')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '55')
UPDATE [isced2013] SET active = 'S',broadfield = '08 Agriculture, forestry, fisheries and veterinary',detailedfield = '0811 Crop and livestock production',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '081 Agriculture ',sortcode = '55' WHERE idisced2013 = '55'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('55','S','08 Agriculture, forestry, fisheries and veterinary','0811 Crop and livestock production',{ts '2018-06-11 11:35:00.653'},'ferdinando','081 Agriculture ','55')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '56')
UPDATE [isced2013] SET active = 'S',broadfield = '08 Agriculture, forestry, fisheries and veterinary',detailedfield = '0812 Horticulture',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '081 Agriculture ',sortcode = '56' WHERE idisced2013 = '56'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('56','S','08 Agriculture, forestry, fisheries and veterinary','0812 Horticulture',{ts '2018-06-11 11:35:00.653'},'ferdinando','081 Agriculture ','56')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '57')
UPDATE [isced2013] SET active = 'S',broadfield = '08 Agriculture, forestry, fisheries and veterinary',detailedfield = '0821 Forestry',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '082 Forestry ',sortcode = '57' WHERE idisced2013 = '57'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('57','S','08 Agriculture, forestry, fisheries and veterinary','0821 Forestry',{ts '2018-06-11 11:35:00.653'},'ferdinando','082 Forestry ','57')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '58')
UPDATE [isced2013] SET active = 'S',broadfield = '08 Agriculture, forestry, fisheries and veterinary',detailedfield = '0831 Fisheries',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '083 Fisheries ',sortcode = '58' WHERE idisced2013 = '58'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('58','S','08 Agriculture, forestry, fisheries and veterinary','0831 Fisheries',{ts '2018-06-11 11:35:00.653'},'ferdinando','083 Fisheries ','58')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '59')
UPDATE [isced2013] SET active = 'S',broadfield = '08 Agriculture, forestry, fisheries and veterinary',detailedfield = '0841 Veterinary',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '084 Veterinary ',sortcode = '59' WHERE idisced2013 = '59'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('59','S','08 Agriculture, forestry, fisheries and veterinary','0841 Veterinary',{ts '2018-06-11 11:35:00.653'},'ferdinando','084 Veterinary ','59')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '60')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0912 Medicine',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '60' WHERE idisced2013 = '60'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('60','S','09 Health and welfare','0912 Medicine',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','60')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '61')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0913 Nursing and midwifery',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '61' WHERE idisced2013 = '61'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('61','S','09 Health and welfare','0913 Nursing and midwifery',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','61')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '62')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0914 Medical diagnostic and treatment technology',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '62' WHERE idisced2013 = '62'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('62','S','09 Health and welfare','0914 Medical diagnostic and treatment technology',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','62')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '63')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0915 Therapy and rehabilitation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '63' WHERE idisced2013 = '63'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('63','S','09 Health and welfare','0915 Therapy and rehabilitation',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','63')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '64')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0916 Pharmacy',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '64' WHERE idisced2013 = '64'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('64','S','09 Health and welfare','0916 Pharmacy',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','64')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '65')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0917 Traditional and complementary medicine and therapy',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '091 Health',sortcode = '65' WHERE idisced2013 = '65'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('65','S','09 Health and welfare','0917 Traditional and complementary medicine and therapy',{ts '2018-06-11 11:35:00.653'},'ferdinando','091 Health','65')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '66')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0921 Care of the elderly and of disabled adults',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '092 Welfare ',sortcode = '66' WHERE idisced2013 = '66'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('66','S','09 Health and welfare','0921 Care of the elderly and of disabled adults',{ts '2018-06-11 11:35:00.653'},'ferdinando','092 Welfare ','66')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '67')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0922 Child care and youth services',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '092 Welfare ',sortcode = '67' WHERE idisced2013 = '67'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('67','S','09 Health and welfare','0922 Child care and youth services',{ts '2018-06-11 11:35:00.653'},'ferdinando','092 Welfare ','67')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '68')
UPDATE [isced2013] SET active = 'S',broadfield = '09 Health and welfare',detailedfield = '0923 Social work and counselling',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '092 Welfare ',sortcode = '68' WHERE idisced2013 = '68'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('68','S','09 Health and welfare','0923 Social work and counselling',{ts '2018-06-11 11:35:00.653'},'ferdinando','092 Welfare ','68')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '69')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1011 Domestic services',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '101 Personal services ',sortcode = '69' WHERE idisced2013 = '69'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('69','S','10 Services','1011 Domestic services',{ts '2018-06-11 11:35:00.653'},'ferdinando','101 Personal services ','69')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '70')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1012 Hair and beauty services',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '101 Personal services ',sortcode = '70' WHERE idisced2013 = '70'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('70','S','10 Services','1012 Hair and beauty services',{ts '2018-06-11 11:35:00.653'},'ferdinando','101 Personal services ','70')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '71')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1013 Hotel, restaurants and catering',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '101 Personal services ',sortcode = '71' WHERE idisced2013 = '71'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('71','S','10 Services','1013 Hotel, restaurants and catering',{ts '2018-06-11 11:35:00.653'},'ferdinando','101 Personal services ','71')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '72')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1014 Sports',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '101 Personal services ',sortcode = '72' WHERE idisced2013 = '72'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('72','S','10 Services','1014 Sports',{ts '2018-06-11 11:35:00.653'},'ferdinando','101 Personal services ','72')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '73')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1015 Travel, tourism and leisure',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '101 Personal services ',sortcode = '73' WHERE idisced2013 = '73'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('73','S','10 Services','1015 Travel, tourism and leisure',{ts '2018-06-11 11:35:00.653'},'ferdinando','101 Personal services ','73')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '74')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1021 Community sanitation',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '102 Hygiene and occupational health services',sortcode = '74' WHERE idisced2013 = '74'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('74','S','10 Services','1021 Community sanitation',{ts '2018-06-11 11:35:00.653'},'ferdinando','102 Hygiene and occupational health services','74')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '75')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1022 Occupational health and safety',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '102 Hygiene and occupational health services',sortcode = '75' WHERE idisced2013 = '75'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('75','S','10 Services','1022 Occupational health and safety',{ts '2018-06-11 11:35:00.653'},'ferdinando','102 Hygiene and occupational health services','75')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '76')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1031 Military and defence',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '103 Security services ',sortcode = '76' WHERE idisced2013 = '76'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('76','S','10 Services','1031 Military and defence',{ts '2018-06-11 11:35:00.653'},'ferdinando','103 Security services ','76')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '77')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1032 Protection of persons and property',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '103 Security services ',sortcode = '77' WHERE idisced2013 = '77'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('77','S','10 Services','1032 Protection of persons and property',{ts '2018-06-11 11:35:00.653'},'ferdinando','103 Security services ','77')
GO

IF exists(SELECT * FROM [isced2013] WHERE idisced2013 = '78')
UPDATE [isced2013] SET active = 'S',broadfield = '10 Services',detailedfield = '1041 Transport services',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',narrowfield = '104 Transport services ',sortcode = '78' WHERE idisced2013 = '78'
ELSE
INSERT INTO [isced2013] (idisced2013,active,broadfield,detailedfield,lt,lu,narrowfield,sortcode) VALUES ('78','S','10 Services','1041 Transport services',{ts '2018-06-11 11:35:00.653'},'ferdinando','104 Transport services ','78')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'isced2013')
UPDATE [tabledescr] SET description = 'VOCABOLARIO International Standard Classification of Education (ISCED)',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:18:03.007'},lu = 'assistenza',title = 'International Standard Classification of Education (ISCED)' WHERE tablename = 'isced2013'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('isced2013','VOCABOLARIO International Standard Classification of Education (ISCED)',null,'N',{ts '2018-07-20 16:18:03.007'},'assistenza','International Standard Classification of Education (ISCED)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:18:07.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','isced2013','64',null,null,null,'S',{ts '2018-07-20 16:18:07.717'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'broadfield' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Broad field',kind = 'S',lt = {ts '2020-09-07 10:02:49.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'broadfield' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('broadfield','isced2013','64',null,null,'Broad field','S',{ts '2020-09-07 10:02:49.953'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'detailedfield' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Detail field',kind = 'S',lt = {ts '2020-09-07 10:04:16.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'detailedfield' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('detailedfield','isced2013','64',null,null,'Detail field','S',{ts '2020-09-07 10:04:16.253'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idisced2013' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:18:07.720'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idisced2013' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idisced2013','isced2013','4',null,null,null,'S',{ts '2018-07-20 16:18:07.720'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:18:07.720'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','isced2013','8',null,null,null,'S',{ts '2018-07-20 16:18:07.720'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:18:07.720'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','isced2013','64',null,null,null,'S',{ts '2018-07-20 16:18:07.720'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'narrowfield' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Narrow field',kind = 'S',lt = {ts '2020-09-07 10:04:16.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'narrowfield' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('narrowfield','isced2013','64',null,null,'Narrow field','S',{ts '2020-09-07 10:04:16.253'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'isced2013')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Ordinamento',kind = 'S',lt = {ts '2020-09-07 10:05:49.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sortcode' AND tablename = 'isced2013'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','isced2013','64',null,null,'Ordinamento','S',{ts '2020-09-07 10:05:49.813'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

