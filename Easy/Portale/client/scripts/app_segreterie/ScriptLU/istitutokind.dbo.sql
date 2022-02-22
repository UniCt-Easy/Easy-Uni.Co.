
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


-- CREAZIONE TABELLA istitutokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istitutokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[istitutokind] (
idistitutokind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
tipoistituto varchar(256) NOT NULL,
tipoistitutoen varchar(256) NOT NULL,
tipoistitutosigla varchar(50) NOT NULL,
 CONSTRAINT xpkistitutokind PRIMARY KEY (idistitutokind
)
)
END
GO

-- VERIFICA STRUTTURA istitutokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'idistitutokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD idistitutokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'idistitutokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistituto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistituto varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistituto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistituto varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistitutoen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistitutoen varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistitutoen' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistitutoen varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistitutosigla' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistitutosigla varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistitutosigla' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistitutosigla varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER istitutokind --
IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '1')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia di Belle Arti',tipoistitutoen = 'Academy of Fine Arts',tipoistitutosigla = 'ABA' WHERE idistitutokind = '1'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('1',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia di Belle Arti','Academy of Fine Arts','ABA')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '2')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia Nazionale di Arte Drammatica',tipoistitutoen = 'National Academy of Dramatic Art',tipoistitutosigla = 'ANAD' WHERE idistitutokind = '2'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('2',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia Nazionale di Arte Drammatica','National Academy of Dramatic Art','ANAD')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '3')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Accademia Nazionale di Danza',tipoistitutoen = 'National Academy of Dance',tipoistitutosigla = 'AND' WHERE idistitutokind = '3'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('3',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Accademia Nazionale di Danza','National Academy of Dance','AND')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '4')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Conservatorio di Musica',tipoistitutoen = 'Music Conservatory',tipoistitutosigla = 'CON' WHERE idistitutokind = '4'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('4',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Conservatorio di Musica','Music Conservatory','CON')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '5')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Istituto Musicale Pareggiato',tipoistitutoen = 'higher music schools',tipoistitutosigla = 'IMP' WHERE idistitutokind = '5'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('5',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Istituto Musicale Pareggiato','higher music schools','IMP')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '6')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Istituto superiore per le Industrie Artistiche',tipoistitutoen = 'Higher Institute for Artistic Industries',tipoistitutosigla = 'ISIA' WHERE idistitutokind = '6'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('6',{ts '2018-06-11 11:23:41.090'},'ferdinando','Istituto superiore per le Industrie Artistiche','Higher Institute for Artistic Industries','ISIA')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '7')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia Legalmente Riconosciuta',tipoistitutoen = 'Academy Legally Recognized',tipoistitutosigla = 'ALR' WHERE idistitutokind = '7'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('7',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia Legalmente Riconosciuta','Academy Legally Recognized','ALR')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '8')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Istituzioni autorizzate a rilasciare titoli AFAM (art.11 DPR 8.7.2005 n.212)',tipoistitutoen = 'Institutions authorized to issue AFAM diplomas (art.11 DPR 8.7.2005 n.212)',tipoistitutosigla = 'Altr' WHERE idistitutokind = '8'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('8',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Istituzioni autorizzate a rilasciare titoli AFAM (art.11 DPR 8.7.2005 n.212)','Institutions authorized to issue AFAM diplomas (art.11 DPR 8.7.2005 n.212)','Altr')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '9')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Università statale',tipoistitutoen = 'State University',tipoistitutosigla = 'US' WHERE idistitutokind = '9'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('9',{ts '2018-06-11 11:23:41.090'},'ferdinando','Università statale','State University','US')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '10')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Università non statale',tipoistitutoen = 'Non-state University',tipoistitutosigla = 'UNS' WHERE idistitutokind = '10'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('10',{ts '2018-06-11 11:23:41.090'},'ferdinando','Università non statale','Non-state University','UNS')
GO

