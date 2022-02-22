
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
-- CREAZIONE TABELLA dichiaraltrekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiaraltrekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dichiaraltrekind] (
iddichiaraltrekind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(2048) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(256) NOT NULL,
 CONSTRAINT xpkdichiaraltrekind PRIMARY KEY (iddichiaraltrekind
)
)
END
GO

-- VERIFICA STRUTTURA dichiaraltrekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'iddichiaraltrekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD iddichiaraltrekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'iddichiaraltrekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD description varchar(2048) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN description varchar(2048) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dichiaraltrekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dichiaraltrekind] ADD title varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dichiaraltrekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dichiaraltrekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dichiaraltrekind] ALTER COLUMN title varchar(256) NOT NULL
GO

-- VERIFICA DI dichiaraltrekind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiaraltrekind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','int','ASSISTENZA','iddichiaraltrekind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','varchar(2048)','ASSISTENZA','description','2048','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiaraltrekind','varchar(256)','ASSISTENZA','title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiaraltrekind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiaraltrekind')
UPDATE customobject set isreal = 'S' where objectname = 'dichiaraltrekind'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiaraltrekind', 'S')
GO

-- GENERAZIONE DATI PER dichiaraltrekind --
IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '1')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Parenti disabili al 100%' WHERE iddichiaraltrekind = '1'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Parenti disabili al 100%')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '2')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Familiari iscritti' WHERE iddichiaraltrekind = '2'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Familiari iscritti')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '3')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Apolide' WHERE iddichiaraltrekind = '3'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Apolide')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '4')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Rifugiato politico' WHERE iddichiaraltrekind = '4'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Rifugiato politico')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '5')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Orfano per motivi di mafia' WHERE iddichiaraltrekind = '5'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Orfano per motivi di mafia')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '6')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Vittima dell''usura o figlio di vittima dell’usura' WHERE iddichiaraltrekind = '6'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Vittima dell''usura o figlio di vittima dell’usura')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '7')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = '',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Studente orfano ospitato da strutture d''accoglienza pubbliche o private' WHERE iddichiaraltrekind = '7'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','',{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Studente orfano ospitato da strutture d''accoglienza pubbliche o private')
GO

IF exists(SELECT * FROM [dichiaraltrekind] WHERE iddichiaraltrekind = '8')
UPDATE [dichiaraltrekind] SET active = 'S',ct = {ts '2020-09-21 17:49:57.573'},cu = 'riccardotest{ADMSEG1}',description = 'test_e2e_nmFcCrTyTIDhSBXXJttTNaDwWriYssViWjkuuSjlkrSDyJfYBecDLsTgZJSzCIQruxxLkwOeTyujuHtfdllmLdAOurHkCoGmgXZLjutZXCTNgkTMiLYBmokQJonHgoLnofIeLOjytDFCgeoryaXVJZEJhLwBIERZHOPWHZuWOcrekIQOogaLYAqNWWmQzpoYcpqaMeXSnqcGqhYTUxsuywEtGzdfwEuTqtXgNyDaPdzPDgAKlUToGqlgVgKZTmGqongaczkRRnRLWCwkVWDtRnTlHdBisothFLJkBlCXGKUUlWHDlvKaJUqdwqnYkrlqqHScYfJAIpaAMKDcCJcqSZpXhGEKaUsqCSGOwNaxSenfYtJpgeMnDfghIwciZoQeNJikYojRiWIRXmmdAzSExVCcyBsqSPQhqGlkILZReqwhEZVrHiibJUFkvYuwWbpIEashPtbNnVugiuGXndTAyzmfeEHXhAeUKEOCkMhXvlzZkiNVzKpxvDDEZukwqXLcjVLqWDYlwkMHZjcZZlgVdhEIYyErCOOYDugdieDkdJpWkZzXEjhashOApvHaOTtvWDtoJzaawXDbGlCqDKeKssGGobgORHWRwqBipNFBtKgkLfhpHlTvLgjwAnPytCKlOTKzPGHIUqjcMPqEpHllHHsWpQzxqCzRuMNqGnozdaIChjUeTyGZMNzWADwrdhNTRjUFXVOnmBWeJwTbEfpdptLKLdjsgBTpaKuYNqtXwSDiLUIvGlJYpcgYWKWrIQEpjGaIJWUKmVQEDWvNVOYhGNoORWhRIAiDmXvNOuODtANOxnaYBLvtKtuYUHburVMlMDGdahuFaRzqKZAwikDLPvFdpocKbEJdUxyDchfhDXnmqjvLbwbWVjXIHnkXVBUzdnfzSwrVEpQDzISzIKtLtyCjVCyanbzqNOKKvasYGPhrfdWHyPcvHdcIGuWPAWsOlmKwmFYPBkzReTlDLBhVKocWoECITzYTKHQlYnrskVrNIQrMuXBHKDX',lt = {ts '2020-09-21 17:49:57.573'},lu = 'riccardotest{ADMSEG1}',sortcode = '1',title = 'test_e2e_hRZFbVpesiByFqwmjJSfzRtXwkthJpcDIMfyOOXycWdCUnPtPBpSjHPrTztlnjKaXyNvhfUeYsYGWkjIcAdRhKOEubMnedCIsFZlqdxrknUVEAddcawZPoJXCxoseEMakpxvkIOoBXGgWjxtXHvSelIxXDwonLMIAvAlSRTZUspiJSYcEEkpbVlfTtyGNwEruCBcXssvxqsiVXKgltcATpWiJochTteYiXUMvIfgPPLnGeGcrjnLeSv' WHERE iddichiaraltrekind = '8'
ELSE
INSERT INTO [dichiaraltrekind] (iddichiaraltrekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2020-09-21 17:49:57.573'},'riccardotest{ADMSEG1}','test_e2e_nmFcCrTyTIDhSBXXJttTNaDwWriYssViWjkuuSjlkrSDyJfYBecDLsTgZJSzCIQruxxLkwOeTyujuHtfdllmLdAOurHkCoGmgXZLjutZXCTNgkTMiLYBmokQJonHgoLnofIeLOjytDFCgeoryaXVJZEJhLwBIERZHOPWHZuWOcrekIQOogaLYAqNWWmQzpoYcpqaMeXSnqcGqhYTUxsuywEtGzdfwEuTqtXgNyDaPdzPDgAKlUToGqlgVgKZTmGqongaczkRRnRLWCwkVWDtRnTlHdBisothFLJkBlCXGKUUlWHDlvKaJUqdwqnYkrlqqHScYfJAIpaAMKDcCJcqSZpXhGEKaUsqCSGOwNaxSenfYtJpgeMnDfghIwciZoQeNJikYojRiWIRXmmdAzSExVCcyBsqSPQhqGlkILZReqwhEZVrHiibJUFkvYuwWbpIEashPtbNnVugiuGXndTAyzmfeEHXhAeUKEOCkMhXvlzZkiNVzKpxvDDEZukwqXLcjVLqWDYlwkMHZjcZZlgVdhEIYyErCOOYDugdieDkdJpWkZzXEjhashOApvHaOTtvWDtoJzaawXDbGlCqDKeKssGGobgORHWRwqBipNFBtKgkLfhpHlTvLgjwAnPytCKlOTKzPGHIUqjcMPqEpHllHHsWpQzxqCzRuMNqGnozdaIChjUeTyGZMNzWADwrdhNTRjUFXVOnmBWeJwTbEfpdptLKLdjsgBTpaKuYNqtXwSDiLUIvGlJYpcgYWKWrIQEpjGaIJWUKmVQEDWvNVOYhGNoORWhRIAiDmXvNOuODtANOxnaYBLvtKtuYUHburVMlMDGdahuFaRzqKZAwikDLPvFdpocKbEJdUxyDchfhDXnmqjvLbwbWVjXIHnkXVBUzdnfzSwrVEpQDzISzIKtLtyCjVCyanbzqNOKKvasYGPhrfdWHyPcvHdcIGuWPAWsOlmKwmFYPBkzReTlDLBhVKocWoECITzYTKHQlYnrskVrNIQrMuXBHKDX',{ts '2020-09-21 17:49:57.573'},'riccardotest{ADMSEG1}','1','test_e2e_hRZFbVpesiByFqwmjJSfzRtXwkthJpcDIMfyOOXycWdCUnPtPBpSjHPrTztlnjKaXyNvhfUeYsYGWkjIcAdRhKOEubMnedCIsFZlqdxrknUVEAddcawZPoJXCxoseEMakpxvkIOoBXGgWjxtXHvSelIxXDwonLMIAvAlSRTZUspiJSYcEEkpbVlfTtyGNwEruCBcXssvxqsiVXKgltcATpWiJochTteYiXUMvIfgPPLnGeGcrjnLeSv')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'dichiaraltrekind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile dagli uten: i tipologia delle altre dichiarazioni',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 16:00:11.140'},lu = 'assistenza',title = 'tipologia delle altre dichiarazioni' WHERE tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('dichiaraltrekind','VOCABOLARIO modificabile dagli uten: i tipologia delle altre dichiarazioni',null,'N',{ts '2018-07-17 16:00:11.140'},'assistenza','tipologia delle altre dichiarazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','dichiaraltrekind','1',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','dichiaraltrekind','8',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','dichiaraltrekind','64',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','dichiaraltrekind','256',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiaraltrekind' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiaraltrekind' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiaraltrekind','dichiaraltrekind','4',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','dichiaraltrekind','8',null,null,null,'S',{ts '2018-07-17 16:00:14.427'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.430'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','dichiaraltrekind','64',null,null,null,'S',{ts '2018-07-17 16:00:14.430'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.430'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','dichiaraltrekind','4',null,null,null,'S',{ts '2018-07-17 16:00:14.430'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'dichiaraltrekind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:00:14.430'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','dichiaraltrekind','50',null,null,null,'S',{ts '2018-07-17 16:00:14.430'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3198')
UPDATE [relation] SET childtable = 'dichiaraltrekind',description = 'tabella con le altre dichiarazioni degli studenti',lt = {ts '2018-07-17 16:00:45.757'},lu = 'assistenza',parenttable = 'dichiaraltre',title = null WHERE idrelation = '3198'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3198','dichiaraltrekind','tabella con le altre dichiarazioni degli studenti',{ts '2018-07-17 16:00:45.757'},'assistenza','dichiaraltre',null)
GO

-- FINE GENERAZIONE SCRIPT --

