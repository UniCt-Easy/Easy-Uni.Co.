
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





-- CREAZIONE TABELLA classescuolakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolakind] (
idclassescuolakind nvarchar(50) NOT NULL,
idcorsostudiokind int NOT NULL,
idcorsostudiolivello int NULL,
title nvarchar(1024) NOT NULL,
 CONSTRAINT xpkclassescuolakind PRIMARY KEY (idclassescuolakind
)
)
END
GO

-- VERIFICA STRUTTURA classescuolakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolakind' and C.name = 'idclassescuolakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolakind] ADD idclassescuolakind nvarchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolakind') and col.name = 'idclassescuolakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolakind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolakind' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolakind] ADD idcorsostudiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolakind') and col.name = 'idcorsostudiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolakind] ALTER COLUMN idcorsostudiokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolakind' and C.name = 'idcorsostudiolivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolakind] ADD idcorsostudiolivello int NULL 
END
ELSE
	ALTER TABLE [classescuolakind] ALTER COLUMN idcorsostudiolivello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolakind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolakind] ADD title nvarchar(1024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolakind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolakind] ALTER COLUMN title nvarchar(1024) NOT NULL
GO


-- GENERAZIONE DATI PER classescuolakind --
IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = '24')
UPDATE [classescuolakind] SET idcorsostudiokind = '9',idcorsostudiolivello = null,title = 'Corsi da 24 CFU' WHERE idclassescuolakind = '24'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('24','9',null,'Corsi da 24 CFU')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'A1')
UPDATE [classescuolakind] SET idcorsostudiokind = '11',idcorsostudiolivello = '1',title = 'Diploma Accademico di Primo Livello' WHERE idclassescuolakind = 'A1'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('A1','11','1','Diploma Accademico di Primo Livello')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'A2')
UPDATE [classescuolakind] SET idcorsostudiokind = '11',idcorsostudiolivello = '2',title = 'Diploma Accademico di Secondo Livello' WHERE idclassescuolakind = 'A2'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('A2','11','2','Diploma Accademico di Secondo Livello')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'AP')
UPDATE [classescuolakind] SET idcorsostudiokind = '18',idcorsostudiolivello = null,title = 'Abilitazione Professionale' WHERE idclassescuolakind = 'AP'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('AP','18',null,'Abilitazione Professionale')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'CF')
UPDATE [classescuolakind] SET idcorsostudiokind = '16',idcorsostudiolivello = null,title = 'Corso di Formazione Professionale (monte ore massimo 200 ore)' WHERE idclassescuolakind = 'CF'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('CF','16',null,'Corso di Formazione Professionale (monte ore massimo 200 ore)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'CL')
UPDATE [classescuolakind] SET idcorsostudiokind = '3',idcorsostudiolivello = null,title = 'Perfezionamento insegnamento di disciplina non linguistica in lingua (CLIL)' WHERE idclassescuolakind = 'CL'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('CL','3',null,'Perfezionamento insegnamento di disciplina non linguistica in lingua (CLIL)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'CP')
UPDATE [classescuolakind] SET idcorsostudiokind = '3',idcorsostudiolivello = null,title = 'Corso di Perfezionamento/Alta Formazione (monte ore minimo 200 ore)' WHERE idclassescuolakind = 'CP'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('CP','3',null,'Corso di Perfezionamento/Alta Formazione (monte ore minimo 200 ore)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'CT')
UPDATE [classescuolakind] SET idcorsostudiokind = '6',idcorsostudiolivello = null,title = 'Corsi di Specializzazione per le attività di Sostegno didattico agli alunni con disabilità (CSS)' WHERE idclassescuolakind = 'CT'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('CT','6',null,'Corsi di Specializzazione per le attività di Sostegno didattico agli alunni con disabilità (CSS)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DA')
UPDATE [classescuolakind] SET idcorsostudiokind = '11',idcorsostudiolivello = '2',title = 'Diploma Accademico Quadriennale' WHERE idclassescuolakind = 'DA'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DA','11','2','Diploma Accademico Quadriennale')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DF')
UPDATE [classescuolakind] SET idcorsostudiokind = '19',idcorsostudiolivello = null,title = 'Diploma in Educazione Fisica' WHERE idclassescuolakind = 'DF'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DF','19',null,'Diploma in Educazione Fisica')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DL')
UPDATE [classescuolakind] SET idcorsostudiokind = '19',idcorsostudiolivello = null,title = 'Diploma Mediatore Linguistico' WHERE idclassescuolakind = 'DL'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DL','19',null,'Diploma Mediatore Linguistico')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DR')
UPDATE [classescuolakind] SET idcorsostudiokind = '4',idcorsostudiolivello = null,title = 'Dottorato di Ricerca' WHERE idclassescuolakind = 'DR'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DR','4',null,'Dottorato di Ricerca')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DS')
UPDATE [classescuolakind] SET idcorsostudiokind = '19',idcorsostudiolivello = null,title = 'Diploma di Scuola Superiore' WHERE idclassescuolakind = 'DS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DS','19',null,'Diploma di Scuola Superiore')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'DU')
UPDATE [classescuolakind] SET idcorsostudiokind = '19',idcorsostudiolivello = null,title = 'Diploma Universitario' WHERE idclassescuolakind = 'DU'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('DU','19',null,'Diploma Universitario')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'EE')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = null,title = 'Laurea Estera' WHERE idclassescuolakind = 'EE'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('EE','1',null,'Laurea Estera')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'LM')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '9',title = 'Laurea Magistrale Ciclo Unico (dm 270/04)' WHERE idclassescuolakind = 'LM'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('LM','1','9','Laurea Magistrale Ciclo Unico (dm 270/04)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'LS')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '8',title = 'Laurea Specialistica ' WHERE idclassescuolakind = 'LS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('LS','1','8','Laurea Specialistica ')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'LT')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '7',title = 'Laurea Triennale' WHERE idclassescuolakind = 'LT'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('LT','1','7','Laurea Triennale')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'LV')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '9',title = 'Laurea Vecchio Ordinamento' WHERE idclassescuolakind = 'LV'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('LV','1','9','Laurea Vecchio Ordinamento')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'M1')
UPDATE [classescuolakind] SET idcorsostudiokind = '2',idcorsostudiolivello = '3',title = 'Master di Primo Livello' WHERE idclassescuolakind = 'M1'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('M1','2','3','Master di Primo Livello')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'M2')
UPDATE [classescuolakind] SET idcorsostudiokind = '2',idcorsostudiolivello = '4',title = 'Master di Secondo Livello' WHERE idclassescuolakind = 'M2'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('M2','2','4','Master di Secondo Livello')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'MA')
UPDATE [classescuolakind] SET idcorsostudiokind = '2',idcorsostudiolivello = null,title = 'Altri Master' WHERE idclassescuolakind = 'MA'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('MA','2',null,'Altri Master')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'MS')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '8',title = 'Laurea Magistrale (dm 270/04)' WHERE idclassescuolakind = 'MS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('MS','1','8','Laurea Magistrale (dm 270/04)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'MT')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '7',title = 'Laurea (dm 270/04)' WHERE idclassescuolakind = 'MT'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('MT','1','7','Laurea (dm 270/04)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'PS')
UPDATE [classescuolakind] SET idcorsostudiokind = '7',idcorsostudiolivello = null,title = 'Percorsi Abilitanti Speciali (PAS)' WHERE idclassescuolakind = 'PS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('PS','7',null,'Percorsi Abilitanti Speciali (PAS)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'S9')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di specializzazione non definita' WHERE idclassescuolakind = 'S9'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('S9','5',null,'Scuola di specializzazione non definita')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SA')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Altre Scuole di Specializzazione non mediche Vecchio Ordinamento, Scuole di Giornalismo' WHERE idclassescuolakind = 'SA'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SA','5',null,'Altre Scuole di Specializzazione non mediche Vecchio Ordinamento, Scuole di Giornalismo')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SB')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Beni Culturali (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SB'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SB','5',null,'Scuola di Specializzazione Area Beni Culturali (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SC')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Sanitaria Chirurgica (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SC'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SC','5',null,'Scuola di Specializzazione Area Sanitaria Chirurgica (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SD')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Sanitaria Medica (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SD'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SD','5',null,'Scuola di Specializzazione Area Sanitaria Medica (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SF')
UPDATE [classescuolakind] SET idcorsostudiokind = '20',idcorsostudiolivello = null,title = 'Scuola Diretta Ai Fini Speciali' WHERE idclassescuolakind = 'SF'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SF','20',null,'Scuola Diretta Ai Fini Speciali')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SI')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione per Insegnanti (SISS)' WHERE idclassescuolakind = 'SI'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SI','5',null,'Scuola di Specializzazione per Insegnanti (SISS)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SL')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Professioni Legali' WHERE idclassescuolakind = 'SL'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SL','5',null,'Scuola di Specializzazione Professioni Legali')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SM')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Medica' WHERE idclassescuolakind = 'SM'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SM','5',null,'Scuola di Specializzazione Medica')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SP')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Psicologica (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SP'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SP','5',null,'Scuola di Specializzazione Area Psicologica (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SR')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Ricerca (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SR'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SR','5',null,'Scuola di Specializzazione Area Ricerca (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SS')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Sanitaria Servizi Clinici (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SS','5',null,'Scuola di Specializzazione Area Sanitaria Servizi Clinici (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'SV')
UPDATE [classescuolakind] SET idcorsostudiokind = '5',idcorsostudiolivello = null,title = 'Scuola di Specializzazione Area Veterinaria (Riordino Sc.Spec.)' WHERE idclassescuolakind = 'SV'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('SV','5',null,'Scuola di Specializzazione Area Veterinaria (Riordino Sc.Spec.)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'TF')
UPDATE [classescuolakind] SET idcorsostudiokind = '8',idcorsostudiolivello = null,title = 'Tirocinio Formativo Attivo (TFA)' WHERE idclassescuolakind = 'TF'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('TF','8',null,'Tirocinio Formativo Attivo (TFA)')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'TS')
UPDATE [classescuolakind] SET idcorsostudiokind = '17',idcorsostudiolivello = null,title = 'Titolo generico d''area medica/ospedaliera' WHERE idclassescuolakind = 'TS'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('TS','17',null,'Titolo generico d''area medica/ospedaliera')
GO

IF exists(SELECT * FROM [classescuolakind] WHERE idclassescuolakind = 'TU')
UPDATE [classescuolakind] SET idcorsostudiokind = '1',idcorsostudiolivello = '9',title = 'Laurea a Ciclo Unico' WHERE idclassescuolakind = 'TU'
ELSE
INSERT INTO [classescuolakind] (idclassescuolakind,idcorsostudiokind,idcorsostudiolivello,title) VALUES ('TU','1','9','Laurea a Ciclo Unico')
GO


-- CREAZIONE TABELLA appelloazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appelloazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appelloazionekind] (
idappelloazionekind int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(250) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkappelloazionekind PRIMARY KEY (idappelloazionekind
)
)
END
GO

-- VERIFICA STRUTTURA appelloazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'idappelloazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD idappelloazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'idappelloazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD description varchar(250) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN description varchar(250) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER appelloazionekind --
IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '1')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello normale',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Ordinario' WHERE idappelloazionekind = '1'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello normale',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Ordinario')
GO

IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '2')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello utilizzato per la modifica di un voto',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Correttivo' WHERE idappelloazionekind = '2'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello utilizzato per la modifica di un voto',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Correttivo')
GO

IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '3')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello utilizzato per aggiungere votazioni mancanti di studenti',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Integrativo' WHERE idappelloazionekind = '3'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello utilizzato per aggiungere votazioni mancanti di studenti',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Integrativo')
GO

-- CREAZIONE TABELLA appellokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appellokind] (
idappellokind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkappellokind PRIMARY KEY (idappellokind
)
)
END
GO

-- VERIFICA STRUTTURA appellokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'idappellokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD idappellokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'idappellokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appellokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appellokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appellokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appellokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appellokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER appellokind --
IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '1')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'esami' WHERE idappellokind = '1'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('1','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','esami')
GO

IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '2')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'conseguimento del titolo' WHERE idappellokind = '2'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('2','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','conseguimento del titolo')
GO

IF exists(SELECT * FROM [appellokind] WHERE idappellokind = '3')
UPDATE [appellokind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'esami di stato' WHERE idappellokind = '3'
ELSE
INSERT INTO [appellokind] (idappellokind,active,description,lt,lu,sortcode,title) VALUES ('3','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','esami di stato')
GO



-- CREAZIONE TABELLA sasdgruppo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdgruppo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sasdgruppo] (
idsasdgruppo int NOT NULL,
idtipoattform int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpksasdgruppo PRIMARY KEY (idsasdgruppo,
idtipoattform
)
)
END
GO

-- VERIFICA STRUTTURA sasdgruppo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD idsasdgruppo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'idsasdgruppo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD idtipoattform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'idtipoattform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdgruppo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdgruppo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdgruppo' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdgruppo] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [sasdgruppo] ALTER COLUMN title varchar(50) NULL
GO


-- GENERAZIONE DATI PER sasdgruppo --
IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '1' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A11' WHERE idsasdgruppo = '1' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('1','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A11')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '2' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A12' WHERE idsasdgruppo = '2' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('2','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A12')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '3' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A13' WHERE idsasdgruppo = '3' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('3','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A13')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '4' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A14' WHERE idsasdgruppo = '4' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('4','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A14')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '5' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A15' WHERE idsasdgruppo = '5' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('5','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A15')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '6' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A21' WHERE idsasdgruppo = '6' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('6','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A21')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '7' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A22' WHERE idsasdgruppo = '7' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('7','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A22')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '8' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A23' WHERE idsasdgruppo = '8' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('8','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A23')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '9' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A24' WHERE idsasdgruppo = '9' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('9','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '10' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A24' WHERE idsasdgruppo = '10' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('10','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '11' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A31' WHERE idsasdgruppo = '11' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('11','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A31')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '12' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A32' WHERE idsasdgruppo = '12' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('12','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A32')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '13' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A33' WHERE idsasdgruppo = '13' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('13','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A33')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '14' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A34' WHERE idsasdgruppo = '14' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('14','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A34')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '15' AND idtipoattform = '3')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A35' WHERE idsasdgruppo = '15' AND idtipoattform = '3'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('15','3',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','A35')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '16' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C11' WHERE idsasdgruppo = '16' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('16','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C11')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '17' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C12' WHERE idsasdgruppo = '17' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('17','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C12')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '18' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C13' WHERE idsasdgruppo = '18' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('18','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C13')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '19' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C14' WHERE idsasdgruppo = '19' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('19','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C14')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '20' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C15' WHERE idsasdgruppo = '20' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('20','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C15')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '21' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C21' WHERE idsasdgruppo = '21' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('21','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C21')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '22' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C22' WHERE idsasdgruppo = '22' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('22','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C22')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '23' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C23' WHERE idsasdgruppo = '23' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('23','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C23')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '24' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C24' WHERE idsasdgruppo = '24' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('24','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C24')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '25' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C25' WHERE idsasdgruppo = '25' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('25','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C25')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '26' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C31' WHERE idsasdgruppo = '26' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('26','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C31')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '27' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C32' WHERE idsasdgruppo = '27' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('27','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C32')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '28' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C33' WHERE idsasdgruppo = '28' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('28','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C33')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '29' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C34' WHERE idsasdgruppo = '29' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('29','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C34')
GO

IF exists(SELECT * FROM [sasdgruppo] WHERE idsasdgruppo = '30' AND idtipoattform = '2')
UPDATE [sasdgruppo] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C35' WHERE idsasdgruppo = '30' AND idtipoattform = '2'
ELSE
INSERT INTO [sasdgruppo] (idsasdgruppo,idtipoattform,ct,cu,lt,lu,title) VALUES ('30','2',{ts '2018-06-11 11:35:00.653'},'ferdinando',{ts '2018-06-11 11:35:00.653'},'ferdinando','C35')
GO

-- CREAZIONE TABELLA appello --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appello]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appello] (
idappello int NOT NULL,
aa varchar(9) NULL,
basevoto int NULL,
cftoend decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(1024) NULL,
esteroend date NULL,
esterostart date NULL,
idappelloazionekind int NULL,
idappellokind int NULL,
idsessione int NULL,
idstudprenotkind int NULL,
lavoratori char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
minanniiscr int NULL,
minvoto int NULL,
passaggio char(1) NULL,
penotend datetime NULL,
posti int NULL,
prenotstart datetime NULL,
prointermedia char(1) NULL,
publicato char(1) NULL,
surmanestop varchar(50) NULL,
surnamestart varchar(50) NULL,
 CONSTRAINT xpkappello PRIMARY KEY (idappello
)
)
END
GO

-- VERIFICA STRUTTURA appello --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappello int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'idappello' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'basevoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD basevoto int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN basevoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'cftoend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD cftoend decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN cftoend decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD description varchar(1024) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN description varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'esteroend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD esteroend date NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN esteroend date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'esterostart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD esterostart date NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN esterostart date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappelloazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappelloazionekind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idappelloazionekind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idappellokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idappellokind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idappellokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idsessione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idsessione int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idsessione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'idstudprenotkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD idstudprenotkind int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN idstudprenotkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lavoratori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lavoratori char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lavoratori char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appello') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'minanniiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD minanniiscr int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN minanniiscr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'minvoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD minvoto int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN minvoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'passaggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD passaggio char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN passaggio char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'penotend' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD penotend datetime NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN penotend datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'posti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD posti int NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN posti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'prenotstart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD prenotstart datetime NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN prenotstart datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'prointermedia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD prointermedia char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN prointermedia char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'publicato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD publicato char(1) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN publicato char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'surmanestop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD surmanestop varchar(50) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN surmanestop varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appello' and C.name = 'surnamestart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appello] ADD surnamestart varchar(50) NULL 
END
ELSE
	ALTER TABLE [appello] ALTER COLUMN surnamestart varchar(50) NULL
GO



-- CREAZIONE TABELLA stipendioannuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendioannuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendioannuo] (
idreg int NOT NULL,
idcontratto int NOT NULL,
idstipendioannuo int NOT NULL,
year int NOT NULL,
caricoente decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
irap decimal(19,2) NULL,
lordo decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
totale decimal(19,2) NULL,
 CONSTRAINT xpkstipendioannuo PRIMARY KEY (idreg,
idcontratto,
idstipendioannuo,
year
)
)
END
GO

-- VERIFICA STRUTTURA stipendioannuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idcontratto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'idcontratto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'idstipendioannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD idstipendioannuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'idstipendioannuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'caricoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD caricoente decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN caricoente decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD irap decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN irap decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lordo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lordo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendioannuo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendioannuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendioannuo' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendioannuo] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [stipendioannuo] ALTER COLUMN totale decimal(19,2) NULL
GO

-- CREAZIONE TABELLA contratto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contratto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contratto] (
idcontratto int NOT NULL,
idreg int NOT NULL,
classe int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datarivalutazione date NULL,
estremibando varchar(50) NULL,
idcontrattokind int NOT NULL,
idinquadramento int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
parttime decimal(5,2) NULL,
percentualesufondiateneo decimal(19,2) NULL,
scatto int NULL,
start date NOT NULL,
stop date NULL,
tempdef char(1) NOT NULL,
tempindet char(1) NOT NULL,
 CONSTRAINT xpkcontratto PRIMARY KEY (idcontratto,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA contratto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idcontratto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idcontratto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'classe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD classe int NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN classe int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'datarivalutazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD datarivalutazione date NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN datarivalutazione date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'estremibando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD estremibando varchar(50) NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN estremibando varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN idcontrattokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD idinquadramento int NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN idinquadramento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD parttime decimal(5,2) NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN parttime decimal(5,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'percentualesufondiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD percentualesufondiateneo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN percentualesufondiateneo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD start date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN start date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD tempdef char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'tempdef' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN tempdef char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contratto' and C.name = 'tempindet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contratto] ADD tempindet char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contratto') and col.name = 'tempindet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contratto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contratto] ALTER COLUMN tempindet char(1) NOT NULL
GO

-- CREAZIONE TABELLA analisiannuale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannuale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[analisiannuale] (
idanalisiannuale int NOT NULL,
costopt decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
ffo1 decimal(19,2) NULL,
ffo2 decimal(19,2) NULL,
ffo3 decimal(19,2) NULL,
incrementodocenti1 decimal(19,2) NULL,
incrementodocenti2 decimal(19,2) NULL,
incrementodocenti3 decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
programmazionetriennale1 decimal(19,2) NULL,
programmazionetriennale2 decimal(19,2) NULL,
programmazionetriennale3 decimal(19,2) NULL,
tasse1 decimal(19,2) NULL,
tasse2 decimal(19,2) NULL,
tasse3 decimal(19,2) NULL,
year int NOT NULL,
 CONSTRAINT xpkanalisiannuale PRIMARY KEY (idanalisiannuale
)
)
END
GO

-- VERIFICA STRUTTURA analisiannuale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'idanalisiannuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD idanalisiannuale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('analisiannuale') and col.name = 'idanalisiannuale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [analisiannuale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'costopt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD costopt decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN costopt decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'ffo1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD ffo1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN ffo1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'ffo2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD ffo2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN ffo2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'ffo3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD ffo3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN ffo3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'incrementodocenti1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD incrementodocenti1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN incrementodocenti1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'incrementodocenti2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD incrementodocenti2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN incrementodocenti2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'incrementodocenti3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD incrementodocenti3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN incrementodocenti3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'programmazionetriennale1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD programmazionetriennale1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN programmazionetriennale1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'programmazionetriennale2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD programmazionetriennale2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN programmazionetriennale2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'programmazionetriennale3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD programmazionetriennale3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN programmazionetriennale3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'tasse1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD tasse1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN tasse1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'tasse2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD tasse2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN tasse2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'tasse3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD tasse3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN tasse3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('analisiannuale') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [analisiannuale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN year int NOT NULL
GO

-- CREAZIONE TABELLA pcsassunzioni --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsassunzioni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsassunzioni] (
idpcsassunzioni int NOT NULL,
year int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
finanziamento varchar(150) NULL,
idcontrattokind int NULL,
idcontrattokind_start int NULL,
idsasd int NULL,
idstruttura int NULL,
legge varchar(250) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nominativo varchar(150) NULL,
numeropersoneassunzione decimal(19,2) NULL,
percentuale decimal(19,6) NULL,
stipendio decimal(19,2) NULL,
totale decimal(19,2) NULL,
totale1 decimal(19,2) NULL,
totale2 decimal(19,2) NULL,
totale3 decimal(19,2) NULL,
 CONSTRAINT xpkpcsassunzioni PRIMARY KEY (idpcsassunzioni,
year
)
)
END
GO

-- VERIFICA STRUTTURA pcsassunzioni --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idpcsassunzioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idpcsassunzioni int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'idpcsassunzioni' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD finanziamento varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN finanziamento varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idcontrattokind_start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idcontrattokind_start int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idcontrattokind_start int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'legge' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD legge varchar(250) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN legge varchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzioni') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'nominativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD nominativo varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN nominativo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'numeropersoneassunzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD numeropersoneassunzione decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN numeropersoneassunzione decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD percentuale decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN percentuale decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD stipendio decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN stipendio decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzioni' and C.name = 'totale3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzioni] ADD totale3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzioni] ALTER COLUMN totale3 decimal(19,2) NULL
GO

-- CREAZIONE TABELLA strutturaresponsabile --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaresponsabile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[strutturaresponsabile] (
idstrutturaresponsabile int NOT NULL,
idstruttura int NOT NULL,
idperfruolo varchar(50) NULL,
idreg int NULL,
start datetime NULL,
stop datetime NULL,
 CONSTRAINT xpkstrutturaresponsabile PRIMARY KEY (idstrutturaresponsabile,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA strutturaresponsabile --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstrutturaresponsabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstrutturaresponsabile int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstrutturaresponsabile' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idperfruolo varchar(50) NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idperfruolo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN start datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN stop datetime NULL
GO

-- CREAZIONE TABELLA stipendio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendio] (
idstipendio int NOT NULL,
idcontrattokind int NOT NULL,
idinquadramento int NOT NULL,
assegno decimal(18,2) NULL,
classe int NULL,
ct datetime NULL,
cu varchar(64) NULL,
iis decimal(18,2) NULL,
irap decimal(18,2) NULL,
lordo decimal(18,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
scatto int NULL,
siglaimportazione varchar(1024) NULL,
stipendio decimal(18,2) NULL,
totale decimal(18,2) NULL,
 CONSTRAINT xpkstipendio PRIMARY KEY (idstipendio,
idcontrattokind,
idinquadramento
)
)
END
GO

-- VERIFICA STRUTTURA stipendio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idstipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idstipendio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idstipendio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD idinquadramento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendio') and col.name = 'idinquadramento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'assegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD assegno decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN assegno decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'classe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD classe int NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN classe int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'iis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD iis decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN iis decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD irap decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN irap decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lordo decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lordo decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD stipendio decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN stipendio decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendio' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendio] ADD totale decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [stipendio] ALTER COLUMN totale decimal(18,2) NULL
GO

-- CREAZIONE TABELLA inquadramento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inquadramento] (
idinquadramento int NOT NULL,
idcontrattokind int NOT NULL,
costolordoannuo decimal(9,2) NULL,
costolordoannuooneri decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
siglaimportazione varchar(1024) NULL,
start datetime NULL,
stop datetime NULL,
tempdef char(1) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkinquadramento PRIMARY KEY (idinquadramento,
idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA inquadramento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idinquadramento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idinquadramento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'costolordoannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD costolordoannuo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN costolordoannuo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'costolordoannuooneri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD costolordoannuooneri decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN costolordoannuooneri decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN start datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN stop datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER inquadramento --
IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '1')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2020-07-15 10:15:12.097'},cu = 'riccardotest{0001}',lt = {ts '2020-07-15 10:16:15.640'},lu = 'riccardotest{0001}',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'I progetto economico - classe 0' WHERE idcontrattokind = '1' AND idinquadramento = '1'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','1',null,null,{ts '2020-07-15 10:15:12.097'},'riccardotest{0001}',{ts '2020-07-15 10:16:15.640'},'riccardotest{0001}',null,null,null,null,'I progetto economico - classe 0')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '2')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2020-07-15 10:16:15.543'},cu = 'riccardotest{0001}',lt = {ts '2021-07-01 17:43:21.487'},lu = 'ferdinando.giannetti{SEGPRG}',siglaimportazione = null,start = {d '2019-01-01'},stop = null,tempdef = 'N',title = 'Vecchio regime' WHERE idcontrattokind = '1' AND idinquadramento = '2'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','2',null,null,{ts '2020-07-15 10:16:15.543'},'riccardotest{0001}',{ts '2021-07-01 17:43:21.487'},'ferdinando.giannetti{SEGPRG}',null,{d '2019-01-01'},null,'N','Vecchio regime')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '12' AND idinquadramento = '4')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-07-01 16:41:19.890'},cu = 'ferdinando.giannetti{SEGPRG}',lt = {ts '2021-07-01 16:41:19.890'},lu = 'ferdinando.giannetti{SEGPRG}',siglaimportazione = null,start = {d '2019-01-01'},stop = null,tempdef = 'N',title = 'Vecchio regime' WHERE idcontrattokind = '12' AND idinquadramento = '4'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('12','4',null,null,{ts '2021-07-01 16:41:19.890'},'ferdinando.giannetti{SEGPRG}',{ts '2021-07-01 16:41:19.890'},'ferdinando.giannetti{SEGPRG}',null,{d '2019-01-01'},null,'N','Vecchio regime')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '16' AND idinquadramento = '5')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-09-15 12:21:57.487'},cu = 'seg_psuma{SEGADM}',lt = {ts '2021-09-15 12:21:57.487'},lu = 'seg_psuma{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Titolo1' WHERE idcontrattokind = '16' AND idinquadramento = '5'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('16','5',null,null,{ts '2021-09-15 12:21:57.487'},'seg_psuma{SEGADM}',{ts '2021-09-15 12:21:57.487'},'seg_psuma{SEGADM}',null,null,null,null,'Titolo1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '6')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:14:50.513'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:07:56.563'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Associato DPR 232/11 art.2' WHERE idcontrattokind = '2' AND idinquadramento = '6'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','6',null,null,{ts '2021-10-20 15:14:50.513'},'Ferdinando',{ts '2021-11-10 13:07:56.563'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Associato DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '7')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.867'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.867'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '2' AND idinquadramento = '7'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','7',null,null,{ts '2021-10-20 15:15:32.867'},'Ferdinando',{ts '2021-10-20 15:15:32.867'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '8')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.867'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:09:52.147'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Associato Legge 240/10' WHERE idcontrattokind = '2' AND idinquadramento = '8'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','8',null,null,{ts '2021-10-20 15:15:32.867'},'Ferdinando',{ts '2021-11-10 13:09:52.147'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Associato Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '9')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-11-10 13:15:41.417'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Prof.Ordinario DPR 232/11 art.2' WHERE idcontrattokind = '1' AND idinquadramento = '9'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','9',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-11-10 13:15:41.417'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Prof.Ordinario DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '10')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Legge 240/10' WHERE idcontrattokind = '1' AND idinquadramento = '10'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','10',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'N','Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '11')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '1' AND idinquadramento = '11'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('1','11',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '12')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '7' AND idinquadramento = '12'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','12',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'S','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '7' AND idinquadramento = '13')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:15:32.870'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:15:32.870'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'DPR 232/11 art.2' WHERE idcontrattokind = '7' AND idinquadramento = '13'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('7','13',null,null,{ts '2021-10-20 15:15:32.870'},'Ferdinando',{ts '2021-10-20 15:15:32.870'},'Ferdinando',null,null,null,'N','DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '2' AND idinquadramento = '14')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-10-20 15:38:22.327'},cu = 'Ferdinando',lt = {ts '2021-10-20 15:38:22.327'},lu = 'Ferdinando',siglaimportazione = null,start = null,stop = null,tempdef = 'S',title = 'Legge 240/10' WHERE idcontrattokind = '2' AND idinquadramento = '14'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('2','14',null,null,{ts '2021-10-20 15:38:22.327'},'Ferdinando',{ts '2021-10-20 15:38:22.327'},'Ferdinando',null,null,null,'S','Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '24' AND idinquadramento = '15')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'B ' WHERE idcontrattokind = '24' AND idinquadramento = '15'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('24','15',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'B ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '25' AND idinquadramento = '16')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'C ' WHERE idcontrattokind = '25' AND idinquadramento = '16'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('25','16',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'C ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '26' AND idinquadramento = '17')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'D ' WHERE idcontrattokind = '26' AND idinquadramento = '17'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('26','17',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'D ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '27' AND idinquadramento = '18')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Dir.' WHERE idcontrattokind = '27' AND idinquadramento = '18'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('27','18',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'Dir.')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '28' AND idinquadramento = '19')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'EP' WHERE idcontrattokind = '28' AND idinquadramento = '19'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('28','19',null,null,{ts '2021-11-08 16:13:16.503'},'davide',{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,'EP')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '21' AND idinquadramento = '20')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'DPR 232/11 art.2' WHERE idcontrattokind = '21' AND idinquadramento = '20'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('21','20',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '22' AND idinquadramento = '21')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'DPR 232/11 art.2' WHERE idcontrattokind = '22' AND idinquadramento = '21'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('22','21',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '23' AND idinquadramento = '22')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'DPR 232/11 art.2' WHERE idcontrattokind = '23' AND idinquadramento = '22'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('23','22',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'DPR 232/11 art.2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '23' AND idinquadramento = '23')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Legge 240/10' WHERE idcontrattokind = '23' AND idinquadramento = '23'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('23','23',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '22' AND idinquadramento = '24')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Legge 240/10' WHERE idcontrattokind = '22' AND idinquadramento = '24'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('22','24',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '21' AND idinquadramento = '25')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 18:53:28.693'},cu = 'davide',lt = {ts '2021-11-08 18:53:28.693'},lu = 'davide',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Legge 240/10' WHERE idcontrattokind = '21' AND idinquadramento = '25'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('21','25',null,null,{ts '2021-11-08 18:53:28.693'},'davide',{ts '2021-11-08 18:53:28.693'},'davide',null,null,null,null,'Legge 240/10')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '19' AND idinquadramento = '26')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-10 12:54:31.827'},cu = 'ferdinando.giannetti{SEGADM}',lt = {ts '2021-11-10 12:58:10.070'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = 'N',title = 'Inq. unico C' WHERE idcontrattokind = '19' AND idinquadramento = '26'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('19','26',null,null,{ts '2021-11-10 12:54:31.827'},'ferdinando.giannetti{SEGADM}',{ts '2021-11-10 12:58:10.070'},'ferdinando.giannetti{SEGADM}',null,null,null,'N','Inq. unico C')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '20' AND idinquadramento = '27')
UPDATE [inquadramento] SET costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-10 12:56:51.327'},cu = 'ferdinando.giannetti{SEGADM}',lt = {ts '2021-11-10 12:58:22.247'},lu = 'ferdinando.giannetti{SEGADM}',siglaimportazione = null,start = null,stop = null,tempdef = null,title = 'Inq. unico B' WHERE idcontrattokind = '20' AND idinquadramento = '27'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('20','27',null,null,{ts '2021-11-10 12:56:51.327'},'ferdinando.giannetti{SEGADM}',{ts '2021-11-10 12:58:22.247'},'ferdinando.giannetti{SEGADM}',null,null,null,null,'Inq. unico B')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '29' AND idinquadramento = '28')
UPDATE [inquadramento] SET costolordoannuo = '96186.11',costolordoannuooneri = '132290.28',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Prof.Associato DPR 232/11 art.2 - t.pieno ',start = null,stop = null,tempdef = 'N',title = 'Prof.Associato DPR 232/11 art.2 - t.pieno ' WHERE idcontrattokind = '29' AND idinquadramento = '28'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('29','28','96186.11','132290.28',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Prof.Associato DPR 232/11 art.2 - t.pieno ',null,null,'N','Prof.Associato DPR 232/11 art.2 - t.pieno ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '30' AND idinquadramento = '29')
UPDATE [inquadramento] SET costolordoannuo = '131674.55',costolordoannuooneri = '181146.74',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Prof.Ordinario DPR 232/11 art.2 - t.pieno ',start = null,stop = null,tempdef = 'N',title = 'Prof.Ordinario DPR 232/11 art.2 - t.pieno ' WHERE idcontrattokind = '30' AND idinquadramento = '29'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('30','29','131674.55','181146.74',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Prof.Ordinario DPR 232/11 art.2 - t.pieno ',null,null,'N','Prof.Ordinario DPR 232/11 art.2 - t.pieno ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '31' AND idinquadramento = '30')
UPDATE [inquadramento] SET costolordoannuo = '71261.36',costolordoannuooneri = '97978.01',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Ricercatore DPR 232/11 art.2 - t.pieno ',start = null,stop = null,tempdef = 'N',title = 'Ricercatore DPR 232/11 art.2 - t.pieno ' WHERE idcontrattokind = '31' AND idinquadramento = '30'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('31','30','71261.36','97978.01',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Ricercatore DPR 232/11 art.2 - t.pieno ',null,null,'N','Ricercatore DPR 232/11 art.2 - t.pieno ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '29' AND idinquadramento = '31')
UPDATE [inquadramento] SET costolordoannuo = '54410.91',costolordoannuooneri = '75039.2',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Prof.Associato DPR 232/11 art.2 - t.definito ',start = null,stop = null,tempdef = 'S',title = 'Prof.Associato DPR 232/11 art.2 - t.definito ' WHERE idcontrattokind = '29' AND idinquadramento = '31'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('29','31','54410.91','75039.2',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Prof.Associato DPR 232/11 art.2 - t.definito ',null,null,'S','Prof.Associato DPR 232/11 art.2 - t.definito ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '30' AND idinquadramento = '32')
UPDATE [inquadramento] SET costolordoannuo = '72311.41',costolordoannuooneri = '99796.38',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Prof.Ordinario DPR 232/11 art.2 - t.definito ',start = null,stop = null,tempdef = 'S',title = 'Prof.Ordinario DPR 232/11 art.2 - t.definito ' WHERE idcontrattokind = '30' AND idinquadramento = '32'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('30','32','72311.41','99796.38',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Prof.Ordinario DPR 232/11 art.2 - t.definito ',null,null,'S','Prof.Ordinario DPR 232/11 art.2 - t.definito ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '31' AND idinquadramento = '33')
UPDATE [inquadramento] SET costolordoannuo = '41896.9',costolordoannuooneri = '57731.43',ct = {ts '2021-11-15 17:16:22.713'},cu = 'import_stipendi',lt = {ts '2021-11-15 17:16:22.713'},lu = 'import_stipendi',siglaimportazione = 'Ricercatore DPR 232/11 art.2 - t.definito ',start = null,stop = null,tempdef = 'S',title = 'Ricercatore DPR 232/11 art.2 - t.definito ' WHERE idcontrattokind = '31' AND idinquadramento = '33'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('31','33','41896.9','57731.43',{ts '2021-11-15 17:16:22.713'},'import_stipendi',{ts '2021-11-15 17:16:22.713'},'import_stipendi','Ricercatore DPR 232/11 art.2 - t.definito ',null,null,'S','Ricercatore DPR 232/11 art.2 - t.definito ')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '34')
UPDATE [inquadramento] SET costolordoannuo = '20049',costolordoannuooneri = '27743.81',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B1',start = null,stop = null,tempdef = null,title = 'B1' WHERE idcontrattokind = '35' AND idinquadramento = '34'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','34','20049','27743.81',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B1',null,null,null,'B1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '35')
UPDATE [inquadramento] SET costolordoannuo = '21233.76',costolordoannuooneri = '29383.27',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B2',start = null,stop = null,tempdef = null,title = 'B2' WHERE idcontrattokind = '35' AND idinquadramento = '35'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','35','21233.76','29383.27',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B2',null,null,null,'B2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '36')
UPDATE [inquadramento] SET costolordoannuo = '22110.26',costolordoannuooneri = '30596.17',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B3',start = null,stop = null,tempdef = null,title = 'B3' WHERE idcontrattokind = '35' AND idinquadramento = '36'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','36','22110.26','30596.17',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B3',null,null,null,'B3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '37')
UPDATE [inquadramento] SET costolordoannuo = '23030.9',costolordoannuooneri = '31870.16',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B4',start = null,stop = null,tempdef = null,title = 'B4' WHERE idcontrattokind = '35' AND idinquadramento = '37'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','37','23030.9','31870.16',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B4',null,null,null,'B4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '38')
UPDATE [inquadramento] SET costolordoannuo = '23870.96',costolordoannuooneri = '33032.63',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B5',start = null,stop = null,tempdef = null,title = 'B5' WHERE idcontrattokind = '35' AND idinquadramento = '38'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','38','23870.96','33032.63',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B5',null,null,null,'B5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '39')
UPDATE [inquadramento] SET costolordoannuo = '24736.74',costolordoannuooneri = '34230.7',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B6',start = null,stop = null,tempdef = null,title = 'B6' WHERE idcontrattokind = '35' AND idinquadramento = '39'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','39','24736.74','34230.7',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B6',null,null,null,'B6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '35' AND idinquadramento = '40')
UPDATE [inquadramento] SET costolordoannuo = '25331.99',costolordoannuooneri = '35054.41',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'B7',start = null,stop = null,tempdef = null,title = 'B7' WHERE idcontrattokind = '35' AND idinquadramento = '40'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('35','40','25331.99','35054.41',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','B7',null,null,null,'B7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '41')
UPDATE [inquadramento] SET costolordoannuo = '23143.49',costolordoannuooneri = '32025.97',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C1',start = null,stop = null,tempdef = null,title = 'C1' WHERE idcontrattokind = '36' AND idinquadramento = '41'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','41','23143.49','32025.97',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C1',null,null,null,'C1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '42')
UPDATE [inquadramento] SET costolordoannuo = '23563.98',costolordoannuooneri = '32607.84',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C2',start = null,stop = null,tempdef = null,title = 'C2' WHERE idcontrattokind = '36' AND idinquadramento = '42'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','42','23563.98','32607.84',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C2',null,null,null,'C2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '43')
UPDATE [inquadramento] SET costolordoannuo = '24243.42',costolordoannuooneri = '33548.04',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C3',start = null,stop = null,tempdef = null,title = 'C3' WHERE idcontrattokind = '36' AND idinquadramento = '43'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','43','24243.42','33548.04',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C3',null,null,null,'C3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '44')
UPDATE [inquadramento] SET costolordoannuo = '25609.59',costolordoannuooneri = '35438.55',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C4',start = null,stop = null,tempdef = null,title = 'C4' WHERE idcontrattokind = '36' AND idinquadramento = '44'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','44','25609.59','35438.55',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C4',null,null,null,'C4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '45')
UPDATE [inquadramento] SET costolordoannuo = '26370.72',costolordoannuooneri = '36491.8',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C5',start = null,stop = null,tempdef = null,title = 'C5' WHERE idcontrattokind = '36' AND idinquadramento = '45'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','45','26370.72','36491.8',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C5',null,null,null,'C5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '46')
UPDATE [inquadramento] SET costolordoannuo = '27176.58',costolordoannuooneri = '37606.95',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C6',start = null,stop = null,tempdef = null,title = 'C6' WHERE idcontrattokind = '36' AND idinquadramento = '46'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','46','27176.58','37606.95',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C6',null,null,null,'C6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '47')
UPDATE [inquadramento] SET costolordoannuo = '28001.18',costolordoannuooneri = '38748.03',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C7',start = null,stop = null,tempdef = null,title = 'C7' WHERE idcontrattokind = '36' AND idinquadramento = '47'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','47','28001.18','38748.03',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C7',null,null,null,'C7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '36' AND idinquadramento = '48')
UPDATE [inquadramento] SET costolordoannuo = '28813.48',costolordoannuooneri = '39872.1',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'C8',start = null,stop = null,tempdef = null,title = 'C8' WHERE idcontrattokind = '36' AND idinquadramento = '48'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('36','48','28813.48','39872.1',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','C8',null,null,null,'C8')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '49')
UPDATE [inquadramento] SET costolordoannuo = '27333.41',costolordoannuooneri = '37823.98',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D1',start = null,stop = null,tempdef = null,title = 'D1' WHERE idcontrattokind = '37' AND idinquadramento = '49'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','49','27333.41','37823.98',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D1',null,null,null,'D1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '50')
UPDATE [inquadramento] SET costolordoannuo = '28323.53',costolordoannuooneri = '39194.11',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D2',start = null,stop = null,tempdef = null,title = 'D2' WHERE idcontrattokind = '37' AND idinquadramento = '50'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','50','28323.53','39194.11',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D2',null,null,null,'D2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '51')
UPDATE [inquadramento] SET costolordoannuo = '29411.64',costolordoannuooneri = '40699.83',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D3',start = null,stop = null,tempdef = null,title = 'D3' WHERE idcontrattokind = '37' AND idinquadramento = '51'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','51','29411.64','40699.83',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D3',null,null,null,'D3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '52')
UPDATE [inquadramento] SET costolordoannuo = '30856.85',costolordoannuooneri = '42699.71',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D4',start = null,stop = null,tempdef = null,title = 'D4' WHERE idcontrattokind = '37' AND idinquadramento = '52'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','52','30856.85','42699.71',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D4',null,null,null,'D4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '53')
UPDATE [inquadramento] SET costolordoannuo = '31897.36',costolordoannuooneri = '44139.56',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D5',start = null,stop = null,tempdef = null,title = 'D5' WHERE idcontrattokind = '37' AND idinquadramento = '53'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','53','31897.36','44139.56',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D5',null,null,null,'D5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '54')
UPDATE [inquadramento] SET costolordoannuo = '33002.91',costolordoannuooneri = '45669.43',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D6',start = null,stop = null,tempdef = null,title = 'D6' WHERE idcontrattokind = '37' AND idinquadramento = '54'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','54','33002.91','45669.43',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D6',null,null,null,'D6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '55')
UPDATE [inquadramento] SET costolordoannuo = '34154.77',costolordoannuooneri = '47263.36',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D7',start = null,stop = null,tempdef = null,title = 'D7' WHERE idcontrattokind = '37' AND idinquadramento = '55'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','55','34154.77','47263.36',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D7',null,null,null,'D7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '37' AND idinquadramento = '56')
UPDATE [inquadramento] SET costolordoannuo = '35136.01',costolordoannuooneri = '48621.2',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'D8',start = null,stop = null,tempdef = null,title = 'D8' WHERE idcontrattokind = '37' AND idinquadramento = '56'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('37','56','35136.01','48621.2',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','D8',null,null,null,'D8')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '57')
UPDATE [inquadramento] SET costolordoannuo = '30890.33',costolordoannuooneri = '42746.04',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP1',start = null,stop = null,tempdef = null,title = 'EP1' WHERE idcontrattokind = '38' AND idinquadramento = '57'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','57','30890.33','42746.04',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP1',null,null,null,'EP1')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '58')
UPDATE [inquadramento] SET costolordoannuo = '32747.55',costolordoannuooneri = '45316.06',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP2',start = null,stop = null,tempdef = null,title = 'EP2' WHERE idcontrattokind = '38' AND idinquadramento = '58'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','58','32747.55','45316.06',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP2',null,null,null,'EP2')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '59')
UPDATE [inquadramento] SET costolordoannuo = '34508.9',costolordoannuooneri = '47753.41',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP3',start = null,stop = null,tempdef = null,title = 'EP3' WHERE idcontrattokind = '38' AND idinquadramento = '59'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','59','34508.9','47753.41',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP3',null,null,null,'EP3')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '60')
UPDATE [inquadramento] SET costolordoannuo = '38020.5',costolordoannuooneri = '52612.76',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP4',start = null,stop = null,tempdef = null,title = 'EP4' WHERE idcontrattokind = '38' AND idinquadramento = '60'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','60','38020.5','52612.76',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP4',null,null,null,'EP4')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '61')
UPDATE [inquadramento] SET costolordoannuo = '39606.28',costolordoannuooneri = '54807.17',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP5',start = null,stop = null,tempdef = null,title = 'EP5' WHERE idcontrattokind = '38' AND idinquadramento = '61'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','61','39606.28','54807.17',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP5',null,null,null,'EP5')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '62')
UPDATE [inquadramento] SET costolordoannuo = '41080.19',costolordoannuooneri = '56846.77',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP6',start = null,stop = null,tempdef = null,title = 'EP6' WHERE idcontrattokind = '38' AND idinquadramento = '62'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','62','41080.19','56846.77',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP6',null,null,null,'EP6')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '63')
UPDATE [inquadramento] SET costolordoannuo = '42616.97',costolordoannuooneri = '58973.36',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP7',start = null,stop = null,tempdef = null,title = 'EP7' WHERE idcontrattokind = '38' AND idinquadramento = '63'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','63','42616.97','58973.36',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP7',null,null,null,'EP7')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '38' AND idinquadramento = '64')
UPDATE [inquadramento] SET costolordoannuo = '43816.32',costolordoannuooneri = '60633.02',ct = {ts '2021-11-17 12:23:34.197'},cu = 'import_stipendi_PTA',lt = {ts '2021-11-17 12:23:34.197'},lu = 'import_stipendi_PTA',siglaimportazione = 'EP8',start = null,stop = null,tempdef = null,title = 'EP8' WHERE idcontrattokind = '38' AND idinquadramento = '64'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,costolordoannuo,costolordoannuooneri,ct,cu,lt,lu,siglaimportazione,start,stop,tempdef,title) VALUES ('38','64','43816.32','60633.02',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA',{ts '2021-11-17 12:23:34.197'},'import_stipendi_PTA','EP8',null,null,null,'EP8')
GO

-- CREAZIONE TABELLA corsostudiostruttura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiostruttura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudiostruttura] (
idcorsostudio int NOT NULL,
idstruttura int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkcorsostudiostruttura PRIMARY KEY (idcorsostudio,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA corsostudiostruttura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiostruttura') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiostruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiostruttura') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiostruttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [corsostudiostruttura] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [corsostudiostruttura] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [corsostudiostruttura] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiostruttura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiostruttura] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [corsostudiostruttura] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA contrattokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contrattokind] (
idcontrattokind int NOT NULL,
active char(1) NOT NULL,
assegnoaggiuntivo char(1) NULL,
costolordoannuo decimal(9,2) NULL,
costolordoannuooneri decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
elementoperequativo char(1) NULL,
indennitadiateneo char(1) NULL,
indennitadiposizione char(1) NULL,
indvacancacontrattuale char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oremaxcompitididatempoparziale int NULL,
oremaxcompitididatempopieno int NULL,
oremaxdidatempoparziale int NULL,
oremaxdidatempopieno int NULL,
oremaxgg int NULL,
oremaxtempoparziale int NULL,
oremaxtempopieno int NULL,
oremincompitididatempoparziale int NULL,
oremincompitididatempopieno int NULL,
oremindidatempoparziale int NULL,
oremindidatempopieno int NULL,
oremintempoparziale int NULL,
oremintempopieno int NULL,
orestraordinariemax int NULL,
parttime char(1) NULL,
puntiorganico decimal(9,2) NULL,
scatto char(1) NULL,
siglaesportazione varchar(10) NULL,
siglaimportazione varchar(1024) NULL,
sortcode int NOT NULL,
tempdef char(1) NULL,
title varchar(50) NOT NULL,
totaletredicesima char(1) NULL,
tredicesimaindennitaintegrativaspeciale char(1) NULL,
 CONSTRAINT xpkcontrattokind PRIMARY KEY (idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA contrattokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'assegnoaggiuntivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD assegnoaggiuntivo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN assegnoaggiuntivo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuooneri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuooneri decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuooneri decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'elementoperequativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD elementoperequativo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN elementoperequativo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiateneo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiateneo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiposizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiposizione char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiposizione char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indvacancacontrattuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indvacancacontrattuale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indvacancacontrattuale char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxgg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxgg int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxgg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'orestraordinariemax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD orestraordinariemax int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN orestraordinariemax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD parttime char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN parttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'puntiorganico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD puntiorganico decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN puntiorganico decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD scatto char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN scatto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'siglaesportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD siglaesportazione varchar(10) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN siglaesportazione varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN title varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'totaletredicesima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD totaletredicesima char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN totaletredicesima char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tredicesimaindennitaintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tredicesimaindennitaintegrativaspeciale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tredicesimaindennitaintegrativaspeciale char(1) NULL
GO


-- GENERAZIONE DATI PER contrattokind --
IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '1')
UPDATE [contrattokind] SET active = 'N',assegnoaggiuntivo = null,costolordoannuo = '68371.12',costolordoannuooneri = '68371.12',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 13:14:30.117'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '8',oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1',scatto = null,siglaesportazione = 'PO',siglaimportazione = 'Professori Ordinari',sortcode = '1',tempdef = 'S',title = 'Professore di I fascia ordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '1'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('1','N',null,'68371.12','68371.12',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',null,null,null,null,{ts '2021-11-10 13:14:30.117'},'ferdinando.giannetti{SEGADM}',null,null,null,null,'8','1228','1720','250','350','90','120',null,null,null,'N','1',null,'PO','Professori Ordinari','1','S','Professore di I fascia ordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '2')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 13:04:36.273'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.7',scatto = null,siglaesportazione = 'PA',siglaimportazione = 'Professori Associati',sortcode = '4',tempdef = 'S',title = 'Professore di II fascia associato confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '2'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('2','S',null,'69','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2021-11-10 13:04:36.273'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','0.7',null,'PA','Professori Associati','4','S','Professore di II fascia associato confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '3')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:18.550'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '13',tempdef = 'N',title = 'Funzionario beni culturali',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '3'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('3','S',null,null,'40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',null,null,null,null,{ts '2020-04-29 18:44:18.550'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,null,null,null,'13','N','Funzionario beni culturali',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '4')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 17:35:00.653'},cu = 'ferdinando',description = 'Studioso o professionista di chiara fama',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:26.160'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '12',tempdef = 'N',title = 'Studioso o professionista di chiara fama',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '4'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('4','S',null,null,'40000',{ts '2018-06-11 17:35:00.653'},'ferdinando','Studioso o professionista di chiara fama',null,null,null,null,{ts '2020-04-29 18:44:26.160'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,null,null,null,'12','N','Studioso o professionista di chiara fama',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '7')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo indeterminato (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:35:34.217'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '200',oremaxdidatempopieno = '350',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '200',oremincompitididatempopieno = '300',oremindidatempoparziale = '60',oremindidatempopieno = '80',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = 'RU',sortcode = '5',tempdef = 'S',title = 'Ricercatore Universitario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '7'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('7','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo indeterminato (ruolo ad esaurimento)',null,null,null,null,{ts '2020-05-21 10:35:34.217'},'riccardotest{0001}','200','350','200','350',null,'1228','1720','200','300','60','80',null,null,null,'N','0.5',null,'RU','RU','5','S','Ricercatore Universitario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '8')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:44:02.570'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = null,oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = '60',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = null,sortcode = '7',tempdef = 'N',title = 'Ricercatore a tempo determinato 240/2010 lett. b ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '8'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('8','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',null,null,null,null,{ts '2020-05-21 10:44:02.570'},'riccardotest{0001}',null,'350',null,'120',null,null,'1720',null,null,null,'60',null,null,null,'N','0.5',null,'RU',null,'7','N','Ricercatore a tempo determinato 240/2010 lett. b ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '9')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:15:37.457'},cu = 'riccardotest',description = 'Assistenti universitari (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:15:37.457'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '9',tempdef = 'N',title = 'Assistenti universitari',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '9'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('9','S',null,null,'40000',{ts '2020-04-29 18:15:37.457'},'riccardotest','Assistenti universitari (ruolo ad esaurimento)',null,null,null,null,{ts '2020-04-29 18:15:37.457'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,null,null,null,'9','N','Assistenti universitari',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '10')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:20:27.437'},cu = 'riccardotest',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:43:04.853'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '80',oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = '20',oremindidatempopieno = '30',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = null,sortcode = '6',tempdef = 'S',title = 'Ricercatore a tempo determinato 240/2010 lett. a',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '10'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('10','S',null,'40','40000',{ts '2020-04-29 18:20:27.437'},'riccardotest','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',null,null,null,null,{ts '2020-05-21 10:43:04.853'},'riccardotest{0001}','200','350','80','120',null,'1228','1720',null,null,'20','30',null,null,null,'N','0.5',null,'RU',null,'6','S','Ricercatore a tempo determinato 240/2010 lett. a',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '12')
UPDATE [contrattokind] SET active = 'N',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:40:30.430'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:28:50.070'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1',scatto = null,siglaesportazione = 'PO',siglaimportazione = null,sortcode = '2',tempdef = 'S',title = 'Professore di I fascia straordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '12'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('12','N',null,null,'40000',{ts '2020-04-29 18:40:30.430'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',null,null,null,null,{ts '2020-05-21 10:28:50.070'},'riccardotest{0001}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','1',null,'PO',null,'2','S','Professore di I fascia straordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '13')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69000',costolordoannuooneri = '69000',ct = {ts '2020-04-29 18:42:56.617'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-07 11:39:45.057'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.7',scatto = null,siglaesportazione = 'PA',siglaimportazione = null,sortcode = '3',tempdef = 'S',title = 'Professore di II fascia associato non confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '13'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('13','S',null,'69000','69000',{ts '2020-04-29 18:42:56.617'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2020-10-07 11:39:45.057'},'riccardotest{ADMSEG1}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','0.7',null,'PA',null,'3','S','Professore di II fascia associato non confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '14')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40000',costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:32:07.807'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-21 15:27:32.890'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '9',oremaxtempoparziale = null,oremaxtempopieno = '1512',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = '250',parttime = 'S',puntiorganico = '0.65',scatto = null,siglaesportazione = 'Dir.',siglaimportazione = 'Dir.',sortcode = '20',tempdef = 'N',title = 'Personale tecnico amministrativo - Dir.',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '14'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('14','S',null,'40000','40000',{ts '2020-05-20 11:32:07.807'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-10-21 15:27:32.890'},'riccardotest{ADMSEG1}',null,null,null,null,'9',null,'1512',null,null,null,null,null,null,'250','S','0.65',null,'Dir.','Dir.','20','N','Personale tecnico amministrativo - Dir.',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '15')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:33:03.170'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:33:16.633'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '40',oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '11',tempdef = 'N',title = 'Dottorandi di ricerca',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '15'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('15','S',null,null,'40000',{ts '2020-05-20 11:33:03.170'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-05-21 10:33:16.633'},'riccardotest{0001}',null,'40',null,null,null,null,'1720',null,null,null,null,null,null,null,'N',null,null,null,null,'11','N','Dottorandi di ricerca',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '16')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2021-09-15 12:21:57.383'},cu = 'seg_psuma{SEGADM}',description = 'Ogni contratto individuale può avere una durata minima di un anno e massima di  tre anni. La durata complessiva dei rapporti come assegnista di ricerca del singolo soggetto non può comunque essere superiore a sei anni.',elementoperequativo = 'S',indennitadiateneo = 'S',indennitadiposizione = 'S',indvacancacontrattuale = 'S',lt = {ts '2021-09-15 12:21:57.383'},lu = 'seg_psuma{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = null,scatto = 'S',siglaesportazione = null,siglaimportazione = null,sortcode = '10',tempdef = 'N',title = 'Assegnista di ricerca',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = 'S' WHERE idcontrattokind = '16'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('16','S','S',null,'40000',{ts '2021-09-15 12:21:57.383'},'seg_psuma{SEGADM}','Ogni contratto individuale può avere una durata minima di un anno e massima di  tre anni. La durata complessiva dei rapporti come assegnista di ricerca del singolo soggetto non può comunque essere superiore a sei anni.','S','S','S','S',{ts '2021-09-15 12:21:57.383'},'seg_psuma{SEGADM}',null,null,null,null,null,null,'1720',null,null,null,null,null,null,null,'N',null,'S',null,null,'10','N','Assegnista di ricerca',null,'S')
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '17')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {d '2021-10-20'},lu = 'ferdinando',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = '0.4',scatto = null,siglaesportazione = 'EP',siglaimportazione = 'EP',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - EP',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '17'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('17','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'0.4',null,'EP','EP','20',null,'Personale tecnico amministrativo - EP',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '18')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {d '2021-10-20'},lu = 'ferdinando',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = '0.3',scatto = null,siglaesportazione = 'D',siglaimportazione = 'D',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - D',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '18'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('18','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'0.3',null,'D','D','20',null,'Personale tecnico amministrativo - D',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '19')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 12:54:31.967'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.25',scatto = null,siglaesportazione = 'C',siglaimportazione = 'C',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - C',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '19'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('19','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2021-11-10 12:54:31.967'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.25',null,'C','C','20',null,'Personale tecnico amministrativo - C',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '20')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 12:56:51.460'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.2',scatto = null,siglaesportazione = 'B',siglaimportazione = 'B',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - B',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '20'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('20','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2021-11-10 12:56:51.460'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.2',null,'B','B','20',null,'Personale tecnico amministrativo - B',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '21')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 15:43:16.380'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 15:43:16.380'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Professori Associati',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '21'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('21','S',null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Professori Associati',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '22')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 15:43:16.380'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 15:43:16.380'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Professori Ordinari',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '22'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('22','S',null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Professori Ordinari',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '23')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 15:43:16.380'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 15:43:16.380'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Ricercatori Universitari',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '23'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('23','S',null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,{ts '2021-11-08 15:43:16.380'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Ricercatori Universitari',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '24')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Personale Tecnico Amministrativo di tipo B ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '24'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('24','S',null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Personale Tecnico Amministrativo di tipo B ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '25')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Personale Tecnico Amministrativo di tipo C ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '25'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('25','S',null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Personale Tecnico Amministrativo di tipo C ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '26')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Personale Tecnico Amministrativo di tipo D ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '26'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('26','S',null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Personale Tecnico Amministrativo di tipo D ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '27')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Personale Tecnico Amministrativo di tipo Dir.',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '27'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('27','S',null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Personale Tecnico Amministrativo di tipo Dir.',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '28')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-08 16:13:16.503'},cu = 'davide',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-08 16:13:16.503'},lu = 'davide',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '20',tempdef = null,title = 'Personale Tecnico Amministrativo di tipo EP',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '28'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('28','S',null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,{ts '2021-11-08 16:13:16.503'},'davide',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'20',null,'Personale Tecnico Amministrativo di tipo EP',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '29')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Prof.Associato ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = '0.7',scatto = 'S',siglaesportazione = 'PA',siglaimportazione = 'Professori Associati',sortcode = '1',tempdef = null,title = 'Prof.Associato ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '29'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('29','S','N',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Prof.Associato ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S','0.7','S','PA','Professori Associati','1',null,'Prof.Associato ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '30')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Prof.Ordinario ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = '1',scatto = 'S',siglaesportazione = 'PO',siglaimportazione = 'Professori Ordinari',sortcode = '1',tempdef = null,title = 'Prof.Ordinario ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '30'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('30','S','N',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Prof.Ordinario ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S','1','S','PO','Professori Ordinari','1',null,'Prof.Ordinario ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '31')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Ricercatore ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = '0.5',scatto = 'S',siglaesportazione = 'RU',siglaimportazione = 'Ricercatori',sortcode = '1',tempdef = null,title = 'Ricercatore ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '31'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('31','S','N',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Ricercatore ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S','0.5','S','RU','Ricercatori','1',null,'Ricercatore ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '32')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Prof.Associato ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.7',scatto = 'S',siglaesportazione = 'PA',siglaimportazione = 'Professori Associati',sortcode = '1',tempdef = null,title = 'Prof.Associato ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '32'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('32','S','S',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Prof.Associato ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.7','S','PA','Professori Associati','1',null,'Prof.Associato ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '33')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Prof.Ordinario ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1',scatto = 'S',siglaesportazione = 'PO',siglaimportazione = 'Professori Ordinari',sortcode = '1',tempdef = null,title = 'Prof.Ordinario ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '33'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('33','S','S',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Prof.Ordinario ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','1','S','PO','Professori Ordinari','1',null,'Prof.Ordinario ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '34')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-15 17:15:03.970'},cu = 'import_stipendi',description = 'Ricercatore ',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-15 17:15:03.970'},lu = 'import_stipendi',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = 'S',siglaesportazione = 'RU',siglaimportazione = 'Ricercatori',sortcode = '1',tempdef = null,title = 'Ricercatore ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '34'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('34','S','S',null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi','Ricercatore ',null,null,null,null,{ts '2021-11-15 17:15:03.970'},'import_stipendi',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.5','S','RU','Ricercatori','1',null,'Ricercatore ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '35')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-17 12:23:34.190'},cu = 'import_stipendi_PTA',description = 'B',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-17 12:23:34.190'},lu = 'import_stipendi_PTA',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = 'N',siglaesportazione = null,siglaimportazione = null,sortcode = '1',tempdef = null,title = 'B',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '35'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('35','S',null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA','B',null,null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N',null,null,'1',null,'B',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '36')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-17 12:23:34.190'},cu = 'import_stipendi_PTA',description = 'C',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-17 12:23:34.190'},lu = 'import_stipendi_PTA',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = 'N',siglaesportazione = null,siglaimportazione = null,sortcode = '1',tempdef = null,title = 'C',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '36'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('36','S',null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA','C',null,null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N',null,null,'1',null,'C',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '37')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-17 12:23:34.190'},cu = 'import_stipendi_PTA',description = 'D',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-17 12:23:34.190'},lu = 'import_stipendi_PTA',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = 'N',siglaesportazione = null,siglaimportazione = null,sortcode = '1',tempdef = null,title = 'D',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '37'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('37','S',null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA','D',null,null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N',null,null,'1',null,'D',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '38')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2021-11-17 12:23:34.190'},cu = 'import_stipendi_PTA',description = 'EP',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-17 12:23:34.190'},lu = 'import_stipendi_PTA',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = null,puntiorganico = null,scatto = 'N',siglaesportazione = null,siglaimportazione = null,sortcode = '1',tempdef = null,title = 'EP',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '38'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('38','S',null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA','EP',null,null,null,null,{ts '2021-11-17 12:23:34.190'},'import_stipendi_PTA',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N',null,null,'1',null,'EP',null,null)
GO

-- CREAZIONE TABELLA commissregistry_docenti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[commissregistry_docenti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[commissregistry_docenti] (
idcommiss int NOT NULL,
idprova int NOT NULL,
idreg_docenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idappello int NULL,
idcorsostudio int NULL,
iddidprog int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcommissregistry_docenti PRIMARY KEY (idcommiss,
idprova,
idreg_docenti
)
)
END
GO

-- VERIFICA STRUTTURA commissregistry_docenti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'idcommiss' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD idcommiss int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'idcommiss' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'idprova' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD idprova int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'idprova' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD idappello int NULL 
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN idappello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commissregistry_docenti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commissregistry_docenti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commissregistry_docenti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commissregistry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commissregistry_docenti] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA commiss --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[commiss]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[commiss] (
idcommiss int NOT NULL,
idprova int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idappello int NULL,
idcorsostudio int NULL,
iddidprog int NULL,
idreg_docenti int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcommiss PRIMARY KEY (idcommiss,
idprova
)
)
END
GO

-- VERIFICA STRUTTURA commiss --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idcommiss' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idcommiss int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idcommiss' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idprova' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idprova int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idprova' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idappello int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idappello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idreg_docenti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA struttura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[struttura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[struttura] (
idstruttura int NOT NULL,
codice varchar(50) NULL,
codiceipa nchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
fax varchar(50) NULL,
idaoo int NULL,
idreg int NULL,
idsede int NOT NULL,
idstrutturakind int NOT NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridstruttura int NULL,
pesoindicatori decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoprogaltreuo decimal(19,2) NULL,
pesoproguo decimal(19,2) NULL,
telefono varchar(50) NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
 CONSTRAINT xpkstruttura PRIMARY KEY (idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA struttura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codiceipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codiceipa nchar(10) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codiceipa nchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD email varchar(200) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN email varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'fax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD fax varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN fax varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idaoo int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idaoo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idsede int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstrutturakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstrutturakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstrutturakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idstrutturakind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'paridstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD paridstruttura int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN paridstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoindicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoindicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoprogaltreuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoprogaltreuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoprogaltreuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoproguo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoproguo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoproguo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'telefono' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD telefono varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN telefono varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title_en varchar(1024) NULL
GO

-- CREAZIONE TABELLA insegnintegcaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegnintegcaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[insegnintegcaratteristica] (
idinsegn int NOT NULL,
idinsegninteg int NOT NULL,
idinsegnintegcaratteristica int NOT NULL,
cf decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idsasd int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkinsegnintegcaratteristica PRIMARY KEY (idinsegn,
idinsegninteg,
idinsegnintegcaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA insegnintegcaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegn int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegn' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegninteg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegninteg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegninteg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idinsegnintegcaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idinsegnintegcaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'idinsegnintegcaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'insegnintegcaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [insegnintegcaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('insegnintegcaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [insegnintegcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [insegnintegcaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- CREAZIONE TABELLA didproggruppcaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didproggruppcaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didproggruppcaratteristica] (
iddidproggruppcaratteristica int NOT NULL,
iddidproggrupp int NOT NULL,
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
cf decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idambitoareadisc int NULL,
idsasd int NULL,
idsasdgruppo int NULL,
idtipoattform int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkdidproggruppcaratteristica PRIMARY KEY (iddidproggruppcaratteristica,
iddidproggrupp,
iddidprog,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didproggruppcaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'iddidproggruppcaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD iddidproggruppcaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'iddidproggruppcaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'iddidproggrupp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD iddidproggrupp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'iddidproggrupp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'idambitoareadisc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD idambitoareadisc int NULL 
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN idambitoareadisc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD idsasdgruppo int NULL 
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN idsasdgruppo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD idtipoattform int NULL 
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN idtipoattform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didproggruppcaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didproggruppcaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didproggruppcaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didproggruppcaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didproggruppcaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- CREAZIONE TABELLA classescuolacaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolacaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolacaratteristica] (
idclassescuolacaratteristica int NOT NULL,
cf decimal(9,2) NULL,
cfmax decimal(9,2) NULL,
cfmin decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idambitoareadisc int NULL,
idclassescuola int NOT NULL,
idsasd int NULL,
idsasdgruppo int NULL,
idtipoattform int NULL,
idtipoattform_2 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obblig char(1) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkclassescuolacaratteristica PRIMARY KEY (idclassescuolacaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA classescuolacaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuolacaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuolacaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuolacaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmin decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmin decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idambitoareadisc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idambitoareadisc int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idambitoareadisc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuola int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuola' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idclassescuola int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasdgruppo int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasdgruppo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform_2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform_2 int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform_2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'obblig' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD obblig char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'obblig' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN obblig char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- CREAZIONE VISTA sasdgruppodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdgruppodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasdgruppodefaultview]
GO

CREATE VIEW [dbo].[sasdgruppodefaultview] AS 
SELECT  sasdgruppo.ct AS sasdgruppo_ct, sasdgruppo.cu AS sasdgruppo_cu, sasdgruppo.idsasdgruppo,
 [dbo].tipoattform.title AS tipoattform_title, [dbo].tipoattform.description AS tipoattform_description, sasdgruppo.idtipoattform, sasdgruppo.lt AS sasdgruppo_lt, sasdgruppo.lu AS sasdgruppo_lu, sasdgruppo.title,
 isnull('Gruppo: ' + sasdgruppo.title + '; ','') as dropdown_title
FROM [dbo].sasdgruppo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].tipoattform WITH (NOLOCK) ON sasdgruppo.idtipoattform = [dbo].tipoattform.idtipoattform
WHERE  sasdgruppo.idsasdgruppo IS NOT NULL  AND sasdgruppo.idtipoattform IS NOT NULL 
GO
-- CREAZIONE VISTA appellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellodefaultview]
GO

CREATE VIEW [dbo].[appellodefaultview] AS 
SELECT  appello.aa, appello.basevoto AS appello_basevoto, appello.cftoend AS appello_cftoend, appello.ct AS appello_ct, appello.cu AS appello_cu, appello.description, appello.esteroend AS appello_esteroend, appello.esterostart AS appello_esterostart, appello.idappello,
 [dbo].appelloazionekind.title AS appelloazionekind_title, appello.idappelloazionekind AS appello_idappelloazionekind,
 [dbo].appellokind.title AS appellokind_title, appello.idappellokind AS appello_idappellokind,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, appello.idsessione,
 [dbo].studprenotkind.title AS studprenotkind_title, appello.idstudprenotkind AS appello_idstudprenotkind,CASE WHEN appello.lavoratori = 'S' THEN 'Si' WHEN appello.lavoratori = 'N' THEN 'No' END AS appello_lavoratori, appello.lt AS appello_lt, appello.lu AS appello_lu, appello.minanniiscr AS appello_minanniiscr, appello.minvoto AS appello_minvoto,CASE WHEN appello.passaggio = 'S' THEN 'Si' WHEN appello.passaggio = 'N' THEN 'No' END AS appello_passaggio, appello.penotend AS appello_penotend, appello.posti AS appello_posti, appello.prenotstart AS appello_prenotstart,CASE WHEN appello.prointermedia = 'S' THEN 'Si' WHEN appello.prointermedia = 'N' THEN 'No' END AS appello_prointermedia,CASE WHEN appello.publicato = 'S' THEN 'Si' WHEN appello.publicato = 'N' THEN 'No' END AS appello_publicato, appello.surmanestop AS appello_surmanestop, appello.surnamestart AS appello_surnamestart,
 isnull('Descrizione: ' + appello.description + '; ','') + ' ' + isnull('Anno accademico: ' + appello.aa + '; ','') as dropdown_title
FROM [dbo].appello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appelloazionekind WITH (NOLOCK) ON appello.idappelloazionekind = [dbo].appelloazionekind.idappelloazionekind
LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON appello.idappellokind = [dbo].appellokind.idappellokind
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON appello.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].studprenotkind WITH (NOLOCK) ON appello.idstudprenotkind = [dbo].studprenotkind.idstudprenotkind
WHERE  appello.idappello IS NOT NULL 
GO

-- CREAZIONE VISTA classescuolakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[classescuolakinddefaultview]
GO

CREATE VIEW [dbo].[classescuolakinddefaultview] AS 
SELECT  classescuolakind.idclassescuolakind,
 [dbo].corsostudiokind.title AS corsostudiokind_title, classescuolakind.idcorsostudiokind AS classescuolakind_idcorsostudiokind,
 [dbo].corsostudiolivello.title AS corsostudiolivello_title, classescuolakind.idcorsostudiolivello, classescuolakind.title,
 isnull('Tipologia: ' + classescuolakind.title + '; ','') as dropdown_title
FROM [dbo].classescuolakind WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON classescuolakind.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].corsostudiolivello WITH (NOLOCK) ON classescuolakind.idcorsostudiolivello = [dbo].corsostudiolivello.idcorsostudiolivello
WHERE  classescuolakind.idclassescuolakind IS NOT NULL 
GO


-- GENERAZIONE DATI PER classescuolakinddefaultview --


-- CREAZIONE VISTA strutturaparentresponsabiliafferenzaview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentresponsabiliafferenzaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
GO




CREATE VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
AS
SELECT  v.idstruttura, v.title, s.idstruttura AS idstruttura_parent, s.title AS titlestrutturaparent, r.idreg, r.title AS registry_title,
sr.start as strutturaresponsabile_start, sr.stop as strutturaresponsabile_stop,  sr.idperfruolo, a.idreg as afferente_idreg, ra.title as afferente_title, a.start, a.stop
FROM  dbo.strutturaparentview AS v INNER JOIN
dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
dbo.strutturaresponsabile as sr on s.idstruttura = sr.idstruttura LEFT OUTER JOIN
dbo.registry AS r ON r.idreg = sr.idreg LEFT OUTER JOIN
dbo.afferenza as a on a.idstruttura = s.idstruttura LEFT OUTER JOIN
dbo.registry AS ra ON ra.idreg = a.idreg 



GO

-- CREAZIONE VISTA pcscessazioniview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcscessazioniview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pcscessazioniview]
GO


CREATE VIEW dbo.pcscessazioniview
AS
SELECT registry.title, dbo.contratto.stop AS data, ROW_NUMBER() OVER (order by idcontratto) AS idpcscessazioniview, dbo.analisiannuale.idanalisiannuale, dbo.contratto.ct, dbo.contratto.cu, dbo.contratto.lt, dbo.contratto.lu
FROM     dbo.contratto INNER JOIN
                  dbo.analisiannuale ON YEAR(dbo.contratto.stop) >= dbo.analisiannuale.year
inner join registry on registry.idreg = contratto.idreg



GO

-- CREAZIONE VISTA pcspuntiorganicoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcspuntiorganicoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pcspuntiorganicoview]
GO


CREATE VIEW [dbo].[pcspuntiorganicoview]
AS
SELECT *
FROM   (SELECT annoelab AS year,
               contrattokind_title,
               DATA,
               CONCAT(COLUMN_NAME,
					  CASE annorif WHEN annoelab THEN 0
								   WHEN annoelab+1 THEN 1
								   WHEN annoelab+2 THEN 2
								   WHEN annoelab+3 THEN 3
								   END
			   ) AS PIV_COL
        FROM   (
				------------------------assunzioni----------------------------		
SELECT  annoelab, 
				 annorif,
				 contrattokind_title,
				SUM(puntiorganico) AS puntipiu,
				 puntimeno,
				SUM(totale) AS importo
				from (
						----------------- annoelab = annorif----------------------
				
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +1 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale1
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale2
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale3
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				-----------------------------+1
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +1 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale1
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale2
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale3
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)				

				-------------------+2
						UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale2
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale3
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data)		
				---------------------+3

				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				contrattokind.title AS contrattokind_title,
				puntiorganico,
				NULL AS puntimeno,
				totale3
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ON contrattokind.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data)		

				) zz

				GROUP BY contrattokind_title, annoelab, annorif,puntimeno				---------------------------------------------
				UNION
				
				SELECT * from (
				
				---------------stipendioannuo ------------------------
						select
						annoelab ,
						annorif,
						title,
						puntipiu,
						 sum(puntimeno) as puntimeno,
						 sum(importo) as importo
						 from (
						select 
						sa.idstipendioannuo,
						aa.year as annoelab ,
						sa.year+1 as annorif,
						ck.title,
						0 as puntipiu,
						CASE WHEN YEAR(c.stop) = sa.year+1 THEN ck.puntiorganico ELSE 0 END as puntimeno,
						CASE WHEN YEAR(c.stop) > sa.year+1 THEN 
							CASE WHEN ck.tempdef = 'S' THEN sa.totale * ((aa.incrementodocenti1 + 100)/100) ELSE sa.totale END  
						ELSE 0 END as importo
						from analisiannuale aa
						inner join stipendioannuo sa on sa.year= aa.year 
						inner join contratto c on c.idcontratto = sa.idcontratto
						inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
						UNION
						select 
						sa.idstipendioannuo,
						aa.year as annoelab ,
						sa.year+2 as annorif,
						ck.title,
						0 as puntipiu,
						CASE WHEN YEAR(c.stop) = sa.year+2 THEN ck.puntiorganico ELSE 0 END as puntimeno,
						CASE WHEN YEAR(c.stop) > sa.year+2 THEN 
							CASE WHEN ck.tempdef = 'S' THEN sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100) ELSE sa.totale END  
						ELSE 0 END as importo
						from analisiannuale aa
						inner join stipendioannuo sa on sa.year= aa.year 
						inner join contratto c on c.idcontratto = sa.idcontratto
						inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
						UNION
						select 
						sa.idstipendioannuo,
						aa.year as annoelab ,
						sa.year+3 as annorif,
						ck.title,
						0 as puntipiu,
						CASE WHEN YEAR(c.stop) = sa.year+3 THEN ck.puntiorganico ELSE 0 END as puntimeno,
						CASE WHEN YEAR(c.stop) > sa.year+3 THEN 
							CASE WHEN ck.tempdef = 'S' THEN sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100) ELSE sa.totale END  
						ELSE 0 END as importo
						from analisiannuale aa
						inner join stipendioannuo sa on sa.year= aa.year 
						inner join contratto c on c.idcontratto = sa.idcontratto
						inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
						) ss

						group by annoelab ,
						annorif,
						title,
						puntipiu
				------------------------------------------------------
				
				) tbl1
				
	) AS GROUPED_VIEW
       CROSS APPLY (VALUES ('puntipiu',puntipiu),
						   ('puntimeno',puntimeno),
                           ('importo',importo)) CS(COLUMN_NAME, DATA)) A
       PIVOT (SUM(DATA)
             FOR PIV_COL IN([puntipiu0],
							[puntimeno0],
                            [importo0],
                            [puntipiu1],
							[puntimeno1],
                            [importo1],
                            [puntipiu2],
							[puntimeno2],
                            [importo2],
							[puntipiu3],
							[puntimeno3],
                            [importo3])) PV




GO-- CREAZIONE VISTA getcontrattikindview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindview]
GO


CREATE VIEW [dbo].[getcontrattikindview]
AS
SELECT        
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	ck.parttime, 
	ck.tempdef, 
	ck.costolordoannuo as costolordoannuo_ck,
	ck.costolordoannuo_inq,
	ck.costolordoannuo_stip,
	isnull(ck.costolordoannuo_stip,isnull(ck.costolordoannuo_inq,ck.costolordoannuo)) as costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((ck.costolordoannuo/isnull(oremaxtempopieno,1720))*isnull(oremaxgg,8)*30,2,1) as decimal(18,2)) costomese,
	oremaxtempoparziale, oremaxtempopieno,
	oremaxdidatempoparziale, oremaxdidatempopieno,
	oremindidatempoparziale, oremindidatempopieno
FROM (
	SELECT cckk.*, 
	(select max(costolordoannuo) from inquadramento i WHERE i.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_inq,
	(select max(totale) from stipendio s WHERE s.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_stip
	FROM dbo.contrattokind cckk
) ck 


GO

-- CREAZIONE VISTA perfprogettoobiettivouoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivouoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivouoview]
GO











CREATE VIEW dbo.perfprogettoobiettivouoview
AS
SELECT dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.perfprogetto.idstruttura, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura = dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year






GO

-- CREAZIONE VISTA perfprogettoobiettivopersonaleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivopersonaleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivopersonaleview]
GO




























CREATE VIEW [dbo].[perfprogettoobiettivopersonaleview]
AS
SELECT distinct dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.strutturakind.title as perfprogetto_strutturakind_title,  dbo.struttura.title perfprogetto_struttura_title, dbo.perfprogetto.idstruttura as idstruttura_perfprogetto, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo, dbo.perfvalutazioneuo.idstruttura
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto 
				  INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura <> dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year 
				  INNER JOIN
                  dbo.afferenza ON dbo.perfvalutazioneuo.idstruttura = dbo.afferenza.idstruttura AND dbo.perfvalutazioneuo.year >= YEAR(dbo.afferenza.start) AND dbo.perfvalutazioneuo.year <= YEAR(dbo.afferenza.stop) 
				  INNER JOIN
                  dbo.perfprogettouo ON dbo.perfprogetto.idperfprogetto = dbo.perfprogettouo.idperfprogetto 
				  INNER JOIN dbo.struttura ON dbo.perfprogetto.idstruttura = dbo.struttura.idstruttura
				  INNER JOIN dbo.strutturakind ON dbo.struttura.idstrutturakind = dbo.strutturakind.idstrutturakind
				  INNER JOIN
                  dbo.perfprogettouomembro ON dbo.perfprogettouo.idperfprogetto = dbo.perfprogettouomembro.idperfprogetto AND dbo.perfprogettouo.idperfprogettouo = dbo.perfprogettouomembro.idperfprogettouo AND 
                  dbo.afferenza.idreg = dbo.perfprogettouomembro.idreg














GO

-- CREAZIONE VISTA getcontrattikindviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindviewdefaultview]
GO

CREATE VIEW [dbo].[getcontrattikindviewdefaultview] AS 
SELECT  getcontrattikindview.costolordoannuo AS getcontrattikindview_costolordoannuo, getcontrattikindview.costolordoannuo_ck AS getcontrattikindview_costolordoannuo_ck, getcontrattikindview.costolordoannuo_inq AS getcontrattikindview_costolordoannuo_inq, getcontrattikindview.costolordoannuo_stip AS getcontrattikindview_costolordoannuo_stip, getcontrattikindview.costomese AS getcontrattikindview_costomese, getcontrattikindview.costoora AS getcontrattikindview_costoora,
 [dbo].contrattokind.title AS contrattokind_title, getcontrattikindview.idcontrattokind, getcontrattikindview.oremaxdidatempoparziale AS getcontrattikindview_oremaxdidatempoparziale, getcontrattikindview.oremaxdidatempopieno AS getcontrattikindview_oremaxdidatempopieno, getcontrattikindview.oremaxgg AS getcontrattikindview_oremaxgg, getcontrattikindview.oremaxtempoparziale AS getcontrattikindview_oremaxtempoparziale, getcontrattikindview.oremaxtempopieno AS getcontrattikindview_oremaxtempopieno, getcontrattikindview.oremindidatempoparziale AS getcontrattikindview_oremindidatempoparziale, getcontrattikindview.oremindidatempopieno AS getcontrattikindview_oremindidatempopieno,CASE WHEN getcontrattikindview.parttime = 'S' THEN 'Si' WHEN getcontrattikindview.parttime = 'N' THEN 'No' END AS getcontrattikindview_parttime,CASE WHEN getcontrattikindview.tempdef = 'S' THEN 'Si' WHEN getcontrattikindview.tempdef = 'N' THEN 'No' END AS getcontrattikindview_tempdef, getcontrattikindview.title,
 isnull('Tipologia: ' + getcontrattikindview.title + '; ','') as dropdown_title
FROM [dbo].getcontrattikindview WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON getcontrattikindview.idcontrattokind = [dbo].contrattokind.idcontrattokind
WHERE  getcontrattikindview.idcontrattokind IS NOT NULL 
GO

-- CREAZIONE VISTA perfvalutazioneuodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazioneuodefaultview]
GO

CREATE VIEW [dbo].[perfvalutazioneuodefaultview] AS 
SELECT  perfvalutazioneuo.completamentopsauo AS perfvalutazioneuo_completamentopsauo, perfvalutazioneuo.completamentopsuo AS perfvalutazioneuo_completamentopsuo, perfvalutazioneuo.ct AS perfvalutazioneuo_ct, perfvalutazioneuo.cu AS perfvalutazioneuo_cu,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazioneuo.idperfschedastatus AS perfvalutazioneuo_idperfschedastatus, perfvalutazioneuo.idperfvalutazioneuo,
 registryappr.title AS registryappr_title, perfvalutazioneuo.idreg_appr AS perfvalutazioneuo_idreg_appr,
 registryval.title AS registryval_title, perfvalutazioneuo.idreg_val AS perfvalutazioneuo_idreg_val,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, perfvalutazioneuo.idstruttura, perfvalutazioneuo.indicatori AS perfvalutazioneuo_indicatori, perfvalutazioneuo.lt AS perfvalutazioneuo_lt, perfvalutazioneuo.lu AS perfvalutazioneuo_lu, perfvalutazioneuo.obiettiviindividuali AS perfvalutazioneuo_obiettiviindividuali, perfvalutazioneuo.pesoindicatori AS perfvalutazioneuo_pesoindicatori, perfvalutazioneuo.pesoobiettivi AS perfvalutazioneuo_pesoobiettivi, perfvalutazioneuo.pesoprogaltreuo AS perfvalutazioneuo_pesoprogaltreuo, perfvalutazioneuo.pesoproguo AS perfvalutazioneuo_pesoproguo, perfvalutazioneuo.risultato AS perfvalutazioneuo_risultato,
 [dbo].year.year AS year_year, perfvalutazioneuo.year AS perfvalutazioneuo_year
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivouoview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivouoview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivouoview.title AS Titolo,isnull(CAST(perfprogettoobiettivouoview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivouoview
 WHERE perfprogettoobiettivouoview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivouoview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivouoview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivopersonaleview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivopersonaleview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivopersonaleview.title AS Titolo,isnull(CAST(perfprogettoobiettivopersonaleview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivopersonaleview
 WHERE perfprogettoobiettivopersonaleview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivopersonaleview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivopersonaleview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfindicatore x where x.idperfindicatore = perfvalutazioneuoindicatori.idperfindicatore) + '; ','') AS Indicatore,isnull(CAST(perfvalutazioneuoindicatori.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazioneuoindicatori
 WHERE perfvalutazioneuoindicatori.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfvalutazioneuoindicatori 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfobiettiviuo.title AS Titolo,isnull(CAST(perfobiettiviuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfobiettiviuo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfobiettiviuo
 WHERE perfobiettiviuo.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfobiettiviuo 
FROM [dbo].perfvalutazioneuo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazioneuo.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazioneuo.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazioneuo.idreg_val = registryval.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfvalutazioneuo.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfvalutazioneuo.year = [dbo].year.year
WHERE  perfvalutazioneuo.idperfvalutazioneuo IS NOT NULL  AND perfvalutazioneuo.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA perfvalutazionepersonaledefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaledefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazionepersonaledefaultview]
GO

CREATE VIEW [dbo].[perfvalutazionepersonaledefaultview] AS 
SELECT  perfvalutazionepersonale.ct AS perfvalutazionepersonale_ct, perfvalutazionepersonale.cu AS perfvalutazionepersonale_cu,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazionepersonale.idperfschedastatus AS perfvalutazionepersonale_idperfschedastatus, perfvalutazionepersonale.idperfvalutazionepersonale,
 [dbo].registry.title AS registry_title, perfvalutazionepersonale.idreg,
 registryappr.title AS registryappr_title, perfvalutazionepersonale.idreg_appr AS perfvalutazionepersonale_idreg_appr,
 registryval.title AS registryval_title, perfvalutazionepersonale.idreg_val AS perfvalutazionepersonale_idreg_val, perfvalutazionepersonale.lt AS perfvalutazionepersonale_lt, perfvalutazionepersonale.lu AS perfvalutazionepersonale_lu, perfvalutazionepersonale.perccomportamenti AS perfvalutazionepersonale_perccomportamenti, perfvalutazionepersonale.percobiettivi AS perfvalutazionepersonale_percobiettivi, perfvalutazionepersonale.percperfuo AS perfvalutazionepersonale_percperfuo, perfvalutazionepersonale.pesocomportamenti AS perfvalutazionepersonale_pesocomportamenti, perfvalutazionepersonale.pesoobiettivi AS perfvalutazionepersonale_pesoobiettivi, perfvalutazionepersonale.pesoperfuo AS perfvalutazionepersonale_pesoperfuo, perfvalutazionepersonale.risultato AS perfvalutazionepersonale_risultato,
 [dbo].year.year AS year_year, perfvalutazionepersonale.year AS perfvalutazionepersonale_year,
 isnull('Valutato: ' + [dbo].registry.title + '; ','') + ' ' + isnull((Select top 1 'Identificativo: ' +CAST( year AS NVARCHAR(64)) from year x where x.year = perfvalutazionepersonale.year) + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Tipo: ' +CAST( idstrutturakind AS NVARCHAR(64)) from struttura x where x.idstruttura = perfvalutazionepersonaleuo.idstruttura) + '; ','') AS Unità_organizzativa,isnull(CAST(perfvalutazionepersonaleuo.afferenza AS NVARCHAR(64)),'0.00') AS Tempo_di_afferenza,isnull(CAST(perfvalutazionepersonaleuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleuo.punteggio AS NVARCHAR(64)),'0.00') AS Punteggio,isnull(CAST(perfvalutazionepersonaleuo.punteggiopesato AS NVARCHAR(64)),'0.00') AS Punteggio_pesato FROM  dbo.perfvalutazionepersonaleuo
 WHERE perfvalutazionepersonaleuo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleuo 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfcomportamento x where x.idperfcomportamento = perfvalutazionepersonalecomportamento.idperfcomportamento) + '; ','') AS Comportamento,isnull(CAST(perfvalutazionepersonalecomportamento.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonalecomportamento.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonalecomportamento
 WHERE perfvalutazionepersonalecomportamento.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonalecomportamento 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfvalutazionepersonaleobiettivo.title AS Titolo,isnull(CAST(perfvalutazionepersonaleobiettivo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleobiettivo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonaleobiettivo
 WHERE perfvalutazionepersonaleobiettivo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleobiettivo 
FROM [dbo].perfvalutazionepersonale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazionepersonale.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON perfvalutazionepersonale.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazionepersonale.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazionepersonale.idreg_val = registryval.idreg
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfvalutazionepersonale.year = [dbo].year.year
WHERE  perfvalutazionepersonale.idperfvalutazionepersonale IS NOT NULL  AND perfvalutazionepersonale.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA attivformpropedview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformpropedview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformpropedview]
GO

CREATE VIEW [dbo].[attivformpropedview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr,
 [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA attivformgruppoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformgruppoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformgruppoview]
GO

CREATE VIEW [dbo].[attivformgruppoview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA attivformdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformdefaultview]
GO

CREATE VIEW [dbo].[attivformdefaultview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr,
 [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT canale.title AS Denominazione FROM  dbo.canale
 WHERE canale.aa = attivform.aa AND canale.idattivform = attivform.idattivform AND canale.idcorsostudio = attivform.idcorsostudio AND canale.iddidprog = attivform.iddidprog AND canale.iddidproganno = attivform.iddidproganno AND canale.iddidprogcurr = attivform.iddidprogcurr AND canale.iddidprogori = attivform.iddidprogori AND canale.iddidprogporzanno = attivform.iddidprogporzanno AND canale.idsede = attivform.idsede FOR XML path, root)))) AS XXcanale 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(attivformcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,attivformcaratteristica.json AS Caratteristiche,isnull((Select top 1 'Denominazione: ' +title from tipoattform x where x.idtipoattform = attivformcaratteristica.idtipoattform) + '; ','') AS Tipo_di_attività_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = attivformcaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Gruppo: ' +title from sasdgruppo x where x.idsasdgruppo = attivformcaratteristica.idsasdgruppo) + '; ','') AS Gruppo,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = attivformcaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN attivformcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.attivformcaratteristica
 WHERE attivformcaratteristica.aa = attivform.aa AND attivformcaratteristica.idattivform = attivform.idattivform AND attivformcaratteristica.idcorsostudio = attivform.idcorsostudio AND attivformcaratteristica.iddidprog = attivform.iddidprog AND attivformcaratteristica.iddidproganno = attivform.iddidproganno AND attivformcaratteristica.iddidprogcurr = attivform.iddidprogcurr AND attivformcaratteristica.iddidprogori = attivform.iddidprogori AND attivformcaratteristica.iddidprogporzanno = attivform.iddidprogporzanno FOR XML path, root)))) AS XXattivformcaratteristica 
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA contrattoammview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattoammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattoammview]
GO

CREATE VIEW [dbo].[contrattoammview] AS 
SELECT  contratto.classe AS contratto_classe, contratto.ct AS contratto_ct, contratto.cu AS contratto_cu, contratto.datarivalutazione AS contratto_datarivalutazione, contratto.estremibando AS contratto_estremibando, contratto.idcontratto,
 [dbo].contrattokind.title AS contrattokind_title, contratto.idcontrattokind,
 [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, contratto.idinquadramento AS contratto_idinquadramento, contratto.idreg, contratto.lt AS contratto_lt, contratto.lu AS contratto_lu, contratto.parttime AS contratto_parttime, contratto.percentualesufondiateneo AS contratto_percentualesufondiateneo, contratto.scatto AS contratto_scatto, contratto.start AS contratto_start, contratto.stop AS contratto_stop,CASE WHEN contratto.tempdef = 'S' THEN 'Si' WHEN contratto.tempdef = 'N' THEN 'No' END AS contratto_tempdef,CASE WHEN contratto.tempindet = 'S' THEN 'Si' WHEN contratto.tempindet = 'N' THEN 'No' END AS contratto_tempindet,
 isnull('Tipologia di contratto: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, contratto.start, 103),'') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Identificativo: ' +CAST( idcontrattokind AS NVARCHAR(64)) from inquadramento x where x.idinquadramento = contratto.idinquadramento) + '; ','') + ' ' + isnull('Inquadramento: ' + [dbo].inquadramento.title + '; ','') + ' ' + isnull('al ' + CONVERT(VARCHAR, contratto.stop, 103),'') as dropdown_title
FROM [dbo].contratto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON contratto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON contratto.idinquadramento = [dbo].inquadramento.idinquadramento
WHERE  contratto.idcontratto IS NOT NULL  AND contratto.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal,
 [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind,
 [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv,
 [dbo].classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale,
 [dbo].contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind,
 [dbo].fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg,
 registryistituti.title AS registryistituti_title, registry_docenti.idreg_istituti,
 [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, registry_docenti.idsasd,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = [dbo].classconsorsuale.idclassconsorsuale
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = [dbo].fonteindicebibliometrico.idfonteindicebibliometrico
LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg
LEFT OUTER JOIN [dbo].registry AS registryistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registryistituti.idreg
LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON registry_docenti.idsasd = [dbo].sasd.idsasd
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON registry_docenti.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registrydocenti_docenteview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocenti_docenteview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocenti_docenteview]
GO

CREATE VIEW [dbo].[registrydocenti_docenteview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal,
 [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind,
 [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv,
 [dbo].classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale,
 [dbo].contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind,
 [dbo].fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg,
 registryistituti.title AS registryistituti_title, registry_docenti.idreg_istituti,
 [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, registry_docenti.idsasd,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = [dbo].classconsorsuale.idclassconsorsuale
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = [dbo].fonteindicebibliometrico.idfonteindicebibliometrico
LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg
LEFT OUTER JOIN [dbo].registry AS registryistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registryistituti.idreg
LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON registry_docenti.idsasd = [dbo].sasd.idsasd
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON registry_docenti.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA contrattodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattodefaultview]
GO

CREATE VIEW [dbo].[contrattodefaultview] AS 
SELECT  contratto.classe AS contratto_classe, contratto.ct AS contratto_ct, contratto.cu AS contratto_cu, contratto.datarivalutazione AS contratto_datarivalutazione, contratto.estremibando AS contratto_estremibando, contratto.idcontratto,
 [dbo].contrattokind.title AS contrattokind_title, contratto.idcontrattokind,
 [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, contratto.idinquadramento AS contratto_idinquadramento, contratto.idreg, contratto.lt AS contratto_lt, contratto.lu AS contratto_lu, contratto.parttime AS contratto_parttime, contratto.percentualesufondiateneo AS contratto_percentualesufondiateneo, contratto.scatto AS contratto_scatto, contratto.start AS contratto_start, contratto.stop AS contratto_stop,CASE WHEN contratto.tempdef = 'S' THEN 'Si' WHEN contratto.tempdef = 'N' THEN 'No' END AS contratto_tempdef,CASE WHEN contratto.tempindet = 'S' THEN 'Si' WHEN contratto.tempindet = 'N' THEN 'No' END AS contratto_tempindet,
 isnull('Tipologia di contratto: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, contratto.start, 103),'') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Identificativo: ' +CAST( idcontrattokind AS NVARCHAR(64)) from inquadramento x where x.idinquadramento = contratto.idinquadramento) + '; ','') + ' ' + isnull('Inquadramento: ' + [dbo].inquadramento.title + '; ','') + ' ' + isnull('al ' + CONVERT(VARCHAR, contratto.stop, 103),'') as dropdown_title
FROM [dbo].contratto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON contratto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON contratto.idinquadramento = [dbo].inquadramento.idinquadramento
WHERE  contratto.idcontratto IS NOT NULL  AND contratto.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA analisiannualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[analisiannualedefaultview]
GO

CREATE VIEW [dbo].[analisiannualedefaultview] AS 
SELECT  analisiannuale.costopt AS analisiannuale_costopt, analisiannuale.ct AS analisiannuale_ct, analisiannuale.cu AS analisiannuale_cu, analisiannuale.ffo1 AS analisiannuale_ffo1, analisiannuale.ffo2 AS analisiannuale_ffo2, analisiannuale.ffo3 AS analisiannuale_ffo3, analisiannuale.idanalisiannuale, analisiannuale.incrementodocenti1 AS analisiannuale_incrementodocenti1, analisiannuale.incrementodocenti2 AS analisiannuale_incrementodocenti2, analisiannuale.incrementodocenti3 AS analisiannuale_incrementodocenti3, analisiannuale.lt AS analisiannuale_lt, analisiannuale.lu AS analisiannuale_lu, analisiannuale.programmazionetriennale1 AS analisiannuale_programmazionetriennale1, analisiannuale.programmazionetriennale2 AS analisiannuale_programmazionetriennale2, analisiannuale.programmazionetriennale3 AS analisiannuale_programmazionetriennale3, analisiannuale.tasse1 AS analisiannuale_tasse1, analisiannuale.tasse2 AS analisiannuale_tasse2, analisiannuale.tasse3 AS analisiannuale_tasse3,
 [dbo].year.year AS year_year, analisiannuale.year
FROM [dbo].analisiannuale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON analisiannuale.year = [dbo].year.year
WHERE  analisiannuale.idanalisiannuale IS NOT NULL  AND analisiannuale.year IS NOT NULL 
GO

-- CREAZIONE VISTA registryprogfinsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryprogfinsegview]
GO

CREATE VIEW [dbo].[registryprogfinsegview] AS 
SELECT  registryprogfin.code AS registryprogfin_code, registryprogfin.ct AS registryprogfin_ct, registryprogfin.cu AS registryprogfin_cu, registryprogfin.description AS registryprogfin_description, registryprogfin.idreg, registryprogfin.idregistryprogfin, registryprogfin.lt AS registryprogfin_lt, registryprogfin.lu AS registryprogfin_lu, registryprogfin.title,
 isnull('Titolo: ' + registryprogfin.title + '; ','') + ' ' + isnull('Codice identificativo: ' + registryprogfin.code + '; ','') as dropdown_title
FROM [dbo].registryprogfin WITH (NOLOCK) 
WHERE  registryprogfin.idreg IS NOT NULL  AND registryprogfin.idregistryprogfin IS NOT NULL 
GO

-- CREAZIONE VISTA registryprogfinbandosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinbandosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryprogfinbandosegview]
GO

CREATE VIEW [dbo].[registryprogfinbandosegview] AS 
SELECT  registryprogfinbando.ct AS registryprogfinbando_ct, registryprogfinbando.cu AS registryprogfinbando_cu, registryprogfinbando.description AS registryprogfinbando_description, registryprogfinbando.idreg, registryprogfinbando.idregistryprogfin, registryprogfinbando.idregistryprogfinbando, registryprogfinbando.lt AS registryprogfinbando_lt, registryprogfinbando.lu AS registryprogfinbando_lu, registryprogfinbando.number AS registryprogfinbando_number, registryprogfinbando.scadenza AS registryprogfinbando_scadenza, registryprogfinbando.title,
 isnull('Titolo: ' + registryprogfinbando.title + '; ','') + ' ' + isnull('Numero: ' + registryprogfinbando.number + '; ','') + ' ' + isnull('Deadline of submission ' + CONVERT(VARCHAR, registryprogfinbando.scadenza, 103),'') as dropdown_title
FROM [dbo].registryprogfinbando WITH (NOLOCK) 
WHERE  registryprogfinbando.idreg IS NOT NULL  AND registryprogfinbando.idregistryprogfin IS NOT NULL  AND registryprogfinbando.idregistryprogfinbando IS NOT NULL 
GO

-- CREAZIONE VISTA diderogdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[diderogdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[diderogdefaultview]
GO

CREATE VIEW [dbo].[diderogdefaultview] AS 
SELECT  diderog.aa,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, diderog.idcorsostudio,
 [dbo].sede.title AS sede_title, diderog.idsede,CASE WHEN diderog.inesaurimento = 'S' THEN 'Si' WHEN diderog.inesaurimento = 'N' THEN 'No' END AS diderog_inesaurimento,
 isnull('Corso di studio: ' + [dbo].corsostudio.title + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico di istituzione: ' +CAST( annoistituz AS NVARCHAR(64)) from corsostudio x where x.idcorsostudio = diderog.idcorsostudio) + '; ','') + ' ' + isnull('Anno Accademico: ' + diderog.aa + '; ','') + ' ' + isnull('Identificativo: ' + [dbo].sede.title + '; ','') as dropdown_title
FROM [dbo].diderog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON diderog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON diderog.idsede = [dbo].sede.idsede
WHERE  diderog.aa IS NOT NULL  AND diderog.idcorsostudio IS NOT NULL  AND diderog.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA canaleerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[canaleerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[canaleerogataview]
GO

CREATE VIEW [dbo].[canaleerogataview] AS 
SELECT  canale.aa, canale.ct AS canale_ct, canale.cu AS canale_cu, canale.CUIN AS canale_CUIN,
 [dbo].attivform.title AS attivform_title, canale.idattivform, canale.idcanale, canale.idcorsostudio, canale.iddidprog,
 [dbo].didproganno.title AS didproganno_title, canale.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, canale.iddidprogcurr,
 [dbo].didprogori.title AS didprogori_title, canale.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, canale.iddidprogporzanno, canale.idsede AS canale_idsede, canale.lt AS canale_lt, canale.lu AS canale_lu, canale.numerostud AS canale_numerostud, canale.sortcode AS canale_sortcode, canale.title,
 isnull('Denominazione: ' + canale.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT mutuazione.json AS Mutuazione FROM  dbo.mutuazione
 WHERE mutuazione.aa = canale.aa AND mutuazione.idattivform = canale.idattivform AND mutuazione.idcanale = canale.idcanale AND mutuazione.idcorsostudio = canale.idcorsostudio AND mutuazione.iddidprog = canale.iddidprog AND mutuazione.iddidproganno = canale.iddidproganno AND mutuazione.iddidprogcurr = canale.iddidprogcurr AND mutuazione.iddidprogori = canale.iddidprogori AND mutuazione.iddidprogporzanno = canale.iddidprogporzanno FOR XML path, root)))) AS XXmutuazione 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Denominazione: ' +title from registry_docenti x where x.idreg = affidamento.idreg_docenti) + '; ','') AS Docente,affidamento.json AS Affidamento,isnull((Select top 1 'Tipologia: ' +title from affidamentokind x where x.idaffidamentokind = affidamento.idaffidamentokind) + '; ','') AS Tipologia,isnull((Select top 1 'Tipologia: ' +title from erogazkind x where x.iderogazkind = affidamento.iderogazkind) + '; ','') AS Tipo_di_erogazione,isnull('' + CASE WHEN affidamento.freqobbl = 'S' THEN 'Frequenza obbligatoria' ELSE 'non Frequenza obbligatoria' END,'') AS Frequenza_obbligatoria,isnull('"dal " : "' + CONVERT(VARCHAR, affidamento.start, 103)+ '"','') AS dal_,isnull('"al " : "' + CONVERT(VARCHAR, affidamento.stop, 103)+ '"','') AS al_ FROM  dbo.affidamento
 WHERE affidamento.aa = canale.aa AND affidamento.idattivform = canale.idattivform AND affidamento.idcanale = canale.idcanale AND affidamento.idcorsostudio = canale.idcorsostudio AND affidamento.iddidprog = canale.iddidprog AND affidamento.iddidproganno = canale.iddidproganno AND affidamento.iddidprogcurr = canale.iddidprogcurr AND affidamento.iddidprogori = canale.iddidprogori AND affidamento.iddidprogporzanno = canale.iddidprogporzanno FOR XML path, root)))) AS XXaffidamento 
FROM [dbo].canale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON canale.idattivform = [dbo].attivform.idattivform
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON canale.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON canale.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON canale.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON canale.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
WHERE  canale.aa IS NOT NULL  AND canale.idattivform IS NOT NULL  AND canale.idcanale IS NOT NULL  AND canale.idcorsostudio IS NOT NULL  AND canale.iddidprog IS NOT NULL  AND canale.iddidproganno IS NOT NULL  AND canale.iddidprogcurr IS NOT NULL  AND canale.iddidprogori IS NOT NULL  AND canale.iddidprogporzanno IS NOT NULL 
GO

-- CREAZIONE VISTA attivformerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformerogataview]
GO

CREATE VIEW [dbo].[attivformerogataview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr,
 [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(attivformcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,attivformcaratteristica.json AS Caratteristiche,isnull((Select top 1 'Denominazione: ' +title from tipoattform x where x.idtipoattform = attivformcaratteristica.idtipoattform) + '; ','') AS Tipo_di_attività_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = attivformcaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Gruppo: ' +title from sasdgruppo x where x.idsasdgruppo = attivformcaratteristica.idsasdgruppo) + '; ','') AS Gruppo,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = attivformcaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN attivformcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.attivformcaratteristica
 WHERE attivformcaratteristica.aa = attivform.aa AND attivformcaratteristica.idattivform = attivform.idattivform AND attivformcaratteristica.idcorsostudio = attivform.idcorsostudio AND attivformcaratteristica.iddidprog = attivform.iddidprog AND attivformcaratteristica.iddidproganno = attivform.iddidproganno AND attivformcaratteristica.iddidprogcurr = attivform.iddidprogcurr AND attivformcaratteristica.iddidprogori = attivform.iddidprogori AND attivformcaratteristica.iddidprogporzanno = attivform.iddidprogporzanno FOR XML path, root)))) AS XXattivformcaratteristica 
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA affidamentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodefaultview]
GO

CREATE VIEW [dbo].[affidamentodefaultview] AS 
SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno,
 [dbo].erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind,
 registrydocenti.title AS registrydocenti_title, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title AS affidamento_title, affidamento.urlcorso AS affidamento_urlcorso,
 isnull('Affidamento: ' + affidamento.json + '; ','') + ' ' + isnull('Docente: ' + registrydocenti.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].affidamentokind.title + '; ','') + ' ' + isnull('Tipo di erogazione: ' + [dbo].erogazkind.title + '; ','') + ' ' + isnull('' + CASE WHEN affidamento.freqobbl = 'S' THEN 'Frequenza obbligatoria' ELSE 'non Frequenza obbligatoria' END,'') + ' ' + isnull('dal ' + CONVERT(VARCHAR, affidamento.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, affidamento.stop, 103),'') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(affidamentocaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Descrizione: ' +description from tipoattform x where x.idtipoattform = affidamentocaratteristica.idtipoattform) + '; ','') AS Tipo_di_attività_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = affidamentocaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = affidamentocaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN affidamentocaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.affidamentocaratteristica
 WHERE affidamentocaratteristica.aa = affidamento.aa AND affidamentocaratteristica.idaffidamento = affidamento.idaffidamento AND affidamentocaratteristica.idattivform = affidamento.idattivform AND affidamentocaratteristica.idcanale = affidamento.idcanale AND affidamentocaratteristica.idcorsostudio = affidamento.idcorsostudio AND affidamentocaratteristica.iddidprog = affidamento.iddidprog AND affidamentocaratteristica.iddidproganno = affidamento.iddidproganno AND affidamentocaratteristica.iddidprogcurr = affidamento.iddidprogcurr AND affidamentocaratteristica.iddidprogori = affidamento.iddidprogori AND affidamentocaratteristica.iddidprogporzanno = affidamento.iddidprogporzanno FOR XML path, root)))) AS XXaffidamentocaratteristica 
FROM [dbo].affidamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = [dbo].erogazkind.iderogazkind
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON affidamento.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrydocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registrydocenti.idreg
WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL 
GO

-- CREAZIONE VISTA didprogdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogdefaultview]
GO

CREATE VIEW [dbo].[didprogdefaultview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl,
 [dbo].areadidattica.title AS areadidattica_title, didprog.idareadidattica,
 [dbo].convenzione.title AS convenzione_title, didprog.idconvenzione,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, didprog.idcorsostudio, didprog.iddidprog,
 [dbo].didprognumchiusokind.title AS didprognumchiusokind_title, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind,
 [dbo].didprogsuddannokind.title AS didprogsuddannokind_title, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind,
 [dbo].erogazkind.title AS erogazkind_title, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria,
 geo_nationlang.lang AS geo_nationlang_lang, didprog.idnation_lang,
 geo_nationlang2.lang AS geo_nationlang2_lang, didprog.idnation_lang2,
 geo_nationlangvis.lang AS geo_nationlangvis_lang, didprog.idnation_langvis,
 registrydocenti.title AS registrydocenti_title, didprog.idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede AS didprog_idsede,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, didprog.idsessione,
 [dbo].titolokind.title AS titolokind_title, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') + ' ' + isnull('Sede: ' + [dbo].sede.title + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].areadidattica WITH (NOLOCK) ON didprog.idareadidattica = [dbo].areadidattica.idareadidattica
LEFT OUTER JOIN [dbo].convenzione WITH (NOLOCK) ON didprog.idconvenzione = [dbo].convenzione.idconvenzione
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON didprog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprognumchiusokind WITH (NOLOCK) ON didprog.iddidprognumchiusokind = [dbo].didprognumchiusokind.iddidprognumchiusokind
LEFT OUTER JOIN [dbo].didprogsuddannokind WITH (NOLOCK) ON didprog.iddidprogsuddannokind = [dbo].didprogsuddannokind.iddidprogsuddannokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON didprog.iderogazkind = [dbo].erogazkind.iderogazkind
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON didprog.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang2 WITH (NOLOCK) ON didprog.idnation_lang2 = geo_nationlang2.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlangvis WITH (NOLOCK) ON didprog.idnation_langvis = geo_nationlangvis.idnation
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON didprog.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrydocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registrydocenti.idreg
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON didprog.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].titolokind WITH (NOLOCK) ON didprog.idtitolokind = [dbo].titolokind.idtitolokind
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

-- CREAZIONE VISTA sasdintegrandiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdintegrandiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasdintegrandiview]
GO

CREATE VIEW [dbo].[sasdintegrandiview] AS 
SELECT  sasd.codice, sasd.codice_old AS sasd_codice_old,
 [dbo].areadidattica.title AS areadidattica_title, sasd.idareadidattica, sasd.idsasd, sasd.lt AS sasd_lt, sasd.lu AS sasd_lu, sasd.title AS sasd_title,
 isnull('Codice: ' + sasd.codice + '; ','') + ' ' + isnull('Denominazione: ' + sasd.title + '; ','') as dropdown_title
FROM [dbo].sasd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].areadidattica WITH (NOLOCK) ON sasd.idareadidattica = [dbo].areadidattica.idareadidattica
WHERE  sasd.idsasd IS NOT NULL 
GO


-- GENERAZIONE DATI PER sasdintegrandiview --
-- CREAZIONE VISTA sasddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasddefaultview]
GO

CREATE VIEW [dbo].[sasddefaultview] AS 
SELECT  sasd.codice, sasd.codice_old AS sasd_codice_old,
 [dbo].areadidattica.title AS areadidattica_title, sasd.idareadidattica, sasd.idsasd, sasd.lt AS sasd_lt, sasd.lu AS sasd_lu, sasd.title AS sasd_title,
 isnull('Codice: ' + sasd.codice + '; ','') + ' ' + isnull('Denominazione: ' + sasd.title + '; ','') as dropdown_title
FROM [dbo].sasd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].areadidattica WITH (NOLOCK) ON sasd.idareadidattica = [dbo].areadidattica.idareadidattica
WHERE  sasd.idsasd IS NOT NULL 
GO


-- GENERAZIONE DATI PER sasddefaultview --
-- CREAZIONE VISTA insegnintegdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegnintegdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[insegnintegdefaultview]
GO

CREATE VIEW [dbo].[insegnintegdefaultview] AS 
SELECT  insegninteg.codice AS insegninteg_codice, insegninteg.ct AS insegninteg_ct, insegninteg.cu AS insegninteg_cu, insegninteg.denominazione, insegninteg.denominazione_en AS insegninteg_denominazione_en, insegninteg.idinsegn, insegninteg.idinsegninteg, insegninteg.lt AS insegninteg_lt, insegninteg.lu AS insegninteg_lu,
 isnull('Denominazione: ' + insegninteg.denominazione + '; ','') + ' ' + isnull('Codice: ' + insegninteg.codice + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(insegnintegcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull(CAST( (Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = insegnintegcaratteristica.idsasd) AS NVARCHAR(1024)) + '; ','') AS SASD,isnull('' + CASE WHEN insegnintegcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.insegnintegcaratteristica
 WHERE insegnintegcaratteristica.idinsegn = insegninteg.idinsegn AND insegnintegcaratteristica.idinsegninteg = insegninteg.idinsegninteg FOR XML path, root)))) AS XXinsegnintegcaratteristica 
FROM [dbo].insegninteg WITH (NOLOCK) 
WHERE  insegninteg.idinsegn IS NOT NULL  AND insegninteg.idinsegninteg IS NOT NULL 
GO

-- CREAZIONE VISTA perfprogettodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettodefaultview]
GO

CREATE VIEW [dbo].[perfprogettodefaultview] AS 
SELECT  perfprogetto.benefici AS perfprogetto_benefici, perfprogetto.ct AS perfprogetto_ct, perfprogetto.cu AS perfprogetto_cu, perfprogetto.datafineeffettiva AS perfprogetto_datafineeffettiva, perfprogetto.datafineprevista AS perfprogetto_datafineprevista, perfprogetto.datainizioeffettiva AS perfprogetto_datainizioeffettiva, perfprogetto.datainizioprevista AS perfprogetto_datainizioprevista, perfprogetto.description AS perfprogetto_description,
 [dbo].didprogsuddannokind.title AS didprogsuddannokind_title, perfprogetto.iddidprogsuddannokind AS perfprogetto_iddidprogsuddannokind, perfprogetto.idperfprogetto,
 [dbo].perfprogettostatus.title AS perfprogettostatus_title, perfprogetto.idperfprogettostatus AS perfprogetto_idperfprogettostatus,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, perfprogetto.idstruttura, perfprogetto.lt AS perfprogetto_lt, perfprogetto.lu AS perfprogetto_lu, perfprogetto.note AS perfprogetto_note, perfprogetto.risultato AS perfprogetto_risultato, perfprogetto.title,
 isnull('Titolo: ' + perfprogetto.title + '; ','') as dropdown_title
FROM [dbo].perfprogetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didprogsuddannokind WITH (NOLOCK) ON perfprogetto.iddidprogsuddannokind = [dbo].didprogsuddannokind.iddidprogsuddannokind
LEFT OUTER JOIN [dbo].perfprogettostatus WITH (NOLOCK) ON perfprogetto.idperfprogettostatus = [dbo].perfprogettostatus.idperfprogettostatus
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfprogetto.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  perfprogetto.idperfprogetto IS NOT NULL 
GO

-- CREAZIONE VISTA perfprogettoobiettivouoviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivouoviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivouoviewdefaultview]
GO
-- CREAZIONE VISTA iscrizionestatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionestatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionestatoview]
GO

CREATE VIEW [dbo].[iscrizionestatoview] AS 
SELECT  iscrizione.aa, iscrizione.anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio, iscrizione.iddidprog, iscrizione.idiscrizione,
 [dbo].registry.title AS registry_title, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola AS iscrizione_matricola,
 isnull('Anno di corso: ' + CAST( iscrizione.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Matricola: ' + iscrizione.matricola + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico: ' +aa + '; ' + 'Sede: ' +CAST( idsede AS NVARCHAR(64)) from didprog x where x.iddidprog = iscrizione.iddidprog) + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizione.data, 103),'') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizione.idreg = [dbo].registry.idreg
WHERE  iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA iscrizionedotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionedotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionedotmasview]
GO

CREATE VIEW [dbo].[iscrizionedotmasview] AS 
SELECT  iscrizione.aa, iscrizione.anno AS iscrizione_anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio, iscrizione.iddidprog, iscrizione.idiscrizione,
 [dbo].registry.title AS registry_title, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola,
 isnull('Matricola: ' + iscrizione.matricola + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico: ' +aa + '; ' + 'Sede: ' +CAST( idsede AS NVARCHAR(64)) from didprog x where x.iddidprog = iscrizione.iddidprog) + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizione.data, 103),'') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizione.idreg = [dbo].registry.idreg
WHERE  iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA insegndefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[insegndefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[insegndefaultview]
GO

CREATE VIEW [dbo].[insegndefaultview] AS 
SELECT  insegn.codice AS insegn_codice, insegn.ct AS insegn_ct, insegn.cu AS insegn_cu, insegn.denominazione, insegn.denominazione_en AS insegn_denominazione_en,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, insegn.idcorsostudio,
 [dbo].corsostudiokind.title AS corsostudiokind_title, insegn.idcorsostudiokind AS insegn_idcorsostudiokind, insegn.idinsegn,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, insegn.idstruttura, insegn.lt AS insegn_lt, insegn.lu AS insegn_lu,
 isnull('Denominazione: ' + insegn.denominazione + '; ','') + ' ' + isnull('; Codice  : ' + insegn.codice + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(insegncaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = insegncaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN insegncaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.insegncaratteristica
 WHERE insegncaratteristica.idinsegn = insegn.idinsegn FOR XML path, root)))) AS XXinsegncaratteristica 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT insegninteg.denominazione AS Denominazione,insegninteg.codice AS Codice FROM  dbo.insegninteg
 WHERE insegninteg.idinsegn = insegn.idinsegn FOR XML path, root)))) AS XXinsegninteg 
FROM [dbo].insegn WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON insegn.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON insegn.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON insegn.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  insegn.idinsegn IS NOT NULL 
GO

-- CREAZIONE VISTA inquadramentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inquadramentodefaultview]
GO

CREATE VIEW [dbo].[inquadramentodefaultview] AS 
SELECT  inquadramento.costolordoannuo AS inquadramento_costolordoannuo, inquadramento.costolordoannuooneri AS inquadramento_costolordoannuooneri, inquadramento.ct AS inquadramento_ct, inquadramento.cu AS inquadramento_cu, inquadramento.idcontrattokind, inquadramento.idinquadramento, inquadramento.lt AS inquadramento_lt, inquadramento.lu AS inquadramento_lu, inquadramento.siglaimportazione AS inquadramento_siglaimportazione, inquadramento.start AS inquadramento_start, inquadramento.stop AS inquadramento_stop,CASE WHEN inquadramento.tempdef = 'S' THEN 'Si' WHEN inquadramento.tempdef = 'N' THEN 'No' END AS inquadramento_tempdef, inquadramento.title AS inquadramento_title,
 isnull((Select top 1 'Tipologia: ' +title from contrattokind x where x.idcontrattokind = inquadramento.idcontrattokind) + '; ','') + ' ' + isnull('Denominazione: ' + inquadramento.title + '; ','') as dropdown_title
FROM [dbo].inquadramento WITH (NOLOCK) 
WHERE  inquadramento.idcontrattokind IS NOT NULL  AND inquadramento.idinquadramento IS NOT NULL 
GO


-- GENERAZIONE DATI PER inquadramentodefaultview --
-- CREAZIONE VISTA didprogstatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogstatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogstatoview]
GO

CREATE VIEW [dbo].[didprogstatoview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl, didprog.idareadidattica AS didprog_idareadidattica, didprog.idconvenzione AS didprog_idconvenzione,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, didprog.idcorsostudio, didprog.iddidprog,
 [dbo].didprognumchiusokind.title AS didprognumchiusokind_title, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria, didprog.idnation_lang AS didprog_idnation_lang, didprog.idnation_lang2 AS didprog_idnation_lang2, didprog.idnation_langvis AS didprog_idnation_langvis, didprog.idreg_docenti AS didprog_idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, didprog.idsessione,
 [dbo].titolokind.title AS titolokind_title, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON didprog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprognumchiusokind WITH (NOLOCK) ON didprog.iddidprognumchiusokind = [dbo].didprognumchiusokind.iddidprognumchiusokind
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON didprog.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].titolokind WITH (NOLOCK) ON didprog.idtitolokind = [dbo].titolokind.idtitolokind
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

-- CREAZIONE VISTA didprogingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogingressoview]
GO

CREATE VIEW [dbo].[didprogingressoview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl, didprog.idareadidattica AS didprog_idareadidattica, didprog.idconvenzione AS didprog_idconvenzione,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, didprog.idcorsostudio, didprog.iddidprog,
 [dbo].didprognumchiusokind.title AS didprognumchiusokind_title, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria,
 geo_nationlang.lang AS geo_nationlang_lang, didprog.idnation_lang,
 geo_nationlang2.lang AS geo_nationlang2_lang, didprog.idnation_lang2,
 geo_nationlangvis.lang AS geo_nationlangvis_lang, didprog.idnation_langvis, didprog.idreg_docenti AS didprog_idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, didprog.idsessione,
 [dbo].titolokind.title AS titolokind_title, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON didprog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprognumchiusokind WITH (NOLOCK) ON didprog.iddidprognumchiusokind = [dbo].didprognumchiusokind.iddidprognumchiusokind
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON didprog.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang2 WITH (NOLOCK) ON didprog.idnation_lang2 = geo_nationlang2.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlangvis WITH (NOLOCK) ON didprog.idnation_langvis = geo_nationlangvis.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON didprog.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].titolokind WITH (NOLOCK) ON didprog.idtitolokind = [dbo].titolokind.idtitolokind
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

-- CREAZIONE VISTA didprogdotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogdotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogdotmasview]
GO

CREATE VIEW [dbo].[didprogdotmasview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl, didprog.idareadidattica AS didprog_idareadidattica, didprog.idconvenzione AS didprog_idconvenzione, didprog.idcorsostudio, didprog.iddidprog, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria,
 geo_nationlang.lang AS geo_nationlang_lang, didprog.idnation_lang, didprog.idnation_lang2 AS didprog_idnation_lang2,
 geo_nationlangvis.lang AS geo_nationlangvis_lang, didprog.idnation_langvis, didprog.idreg_docenti AS didprog_idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede, didprog.idsessione AS didprog_idsessione, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON didprog.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlangvis WITH (NOLOCK) ON didprog.idnation_langvis = geo_nationlangvis.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

-- CREAZIONE VISTA corsostudiostatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiostatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiostatoview]
GO

CREATE VIEW [dbo].[corsostudiostatoview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind, corsostudio.idcorsostudiolivello AS corsostudio_idcorsostudiolivello, corsostudio.idcorsostudionorma AS corsostudio_idcorsostudionorma, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,(select top 1 aa 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_aa,
						(select top 1 iddidprogsuddannokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprogsuddannokind,
						(select top 1 idsede 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsede,
						(select top 1 idsessione 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsessione,
						(select top 1 CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_immatoltreauth,
						(select top 1 startiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_startiscrizioni,
						(select top 1 stopiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_stopiscrizioni,
						(select top 1 title 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title,
						(select top 1 title_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title_en,
						(select top 1 utenzasost 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_utenzasost,
 isnull('Denominazione: ' + corsostudio.title + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind = 13
GO

-- CREAZIONE VISTA corsostudioingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudioingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudioingressoview]
GO

CREATE VIEW [dbo].[corsostudioingressoview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind, corsostudio.idcorsostudiolivello AS corsostudio_idcorsostudiolivello, corsostudio.idcorsostudionorma AS corsostudio_idcorsostudionorma, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,(select top 1 aa 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_aa,
						(select top 1 iddidprognumchiusokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprognumchiusokind,
						(select top 1 iddidprogsuddannokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprogsuddannokind,
						(select top 1 idgraduatoria 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idgraduatoria,
						(select top 1 idnation_lang 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang,
						(select top 1 idnation_lang2 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang2,
						(select top 1 idnation_langvis 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_langvis,
						(select top 1 idsede 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsede,
						(select top 1 idsessione 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsessione,
						(select top 1 idtitolokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_idtitolokind,
						(select top 1 CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_immatoltreauth,
						(select top 1 modaccesso 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso,
						(select top 1 modaccesso_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso_en,
						(select top 1 CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_preimmatoltreauth,
						(select top 1 progesamamm 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_progesamamm,
						(select top 1 provafinaledesc 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_provafinaledesc,
						(select top 1 regolamentotax 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotax,
						(select top 1 regolamentotaxurl 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotaxurl,
						(select top 1 startiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_startiscrizioni,
						(select top 1 stopiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_stopiscrizioni,
						(select top 1 title 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title,
						(select top 1 title_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title_en,
						(select top 1 utenzasost 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_utenzasost,
						(select top 1 website 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_website,
 isnull('Denominazione: ' + corsostudio.title + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind = 12
GO

-- CREAZIONE VISTA corsostudiodotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiodotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiodotmasview]
GO

CREATE VIEW [dbo].[corsostudiodotmasview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind, corsostudio.idcorsostudiolivello AS corsostudio_idcorsostudiolivello, corsostudio.idcorsostudionorma AS corsostudio_idcorsostudionorma, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,(select top 1 aa 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_aa,
						(select top 1 iddidprogsuddannokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprogsuddannokind,
						(select top 1 idgraduatoria 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idgraduatoria,
						(select top 1 idnation_lang 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang,
						(select top 1 idnation_langvis 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_langvis,
						(select top 1 idsede 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsede,
						(select top 1 CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_immatoltreauth,
						(select top 1 startiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_startiscrizioni,
						(select top 1 stopiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_stopiscrizioni,
						(select top 1 title 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title,
						(select top 1 title_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title_en,
						(select top 1 utenzasost 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_utenzasost,
						(select top 1 website 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_website,
 isnull('Denominazione: ' + corsostudio.title + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind = 2
GO

-- CREAZIONE VISTA aulaseg_childview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aulaseg_childview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[aulaseg_childview]
GO

CREATE VIEW [dbo].[aulaseg_childview] AS 
SELECT  aula.address AS aula_address, aula.cap AS aula_cap, aula.capienza AS aula_capienza, aula.capienzadis AS aula_capienzadis, aula.code AS aula_code, aula.ct AS aula_ct, aula.cu AS aula_cu, aula.dotazioni AS aula_dotazioni, aula.idaula,
 [dbo].aulakind.title AS aulakind_title, aula.idaulakind AS aula_idaulakind,
 [dbo].geo_city.title AS geo_city_title, aula.idcity, aula.idedificio,
 [dbo].geo_nation.title AS geo_nation_title, aula.idnation, aula.idsede,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, aula.idstruttura, aula.latitude AS aula_latitude, aula.location AS aula_location, aula.longitude AS aula_longitude, aula.lt AS aula_lt, aula.lu AS aula_lu, aula.title,
 isnull('Denominazione: ' + aula.title + '; ','') as dropdown_title
FROM [dbo].aula WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aulakind WITH (NOLOCK) ON aula.idaulakind = [dbo].aulakind.idaulakind
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON aula.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON aula.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON aula.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  aula.idaula IS NOT NULL  AND aula.idedificio IS NOT NULL  AND aula.idsede IS NOT NULL 
GO

-- CREAZIONE VISTA appellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellodefaultview]
GO

CREATE VIEW [dbo].[appellodefaultview] AS 
SELECT  appello.aa, appello.basevoto AS appello_basevoto, appello.cftoend AS appello_cftoend, appello.ct AS appello_ct, appello.cu AS appello_cu, appello.description, appello.esteroend AS appello_esteroend, appello.esterostart AS appello_esterostart, appello.idappello,
 [dbo].appelloazionekind.title AS appelloazionekind_title, appello.idappelloazionekind AS appello_idappelloazionekind,
 [dbo].appellokind.title AS appellokind_title, appello.idappellokind AS appello_idappellokind,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, appello.idsessione,
 [dbo].studprenotkind.title AS studprenotkind_title, appello.idstudprenotkind AS appello_idstudprenotkind,CASE WHEN appello.lavoratori = 'S' THEN 'Si' WHEN appello.lavoratori = 'N' THEN 'No' END AS appello_lavoratori, appello.lt AS appello_lt, appello.lu AS appello_lu, appello.minanniiscr AS appello_minanniiscr, appello.minvoto AS appello_minvoto,CASE WHEN appello.passaggio = 'S' THEN 'Si' WHEN appello.passaggio = 'N' THEN 'No' END AS appello_passaggio, appello.penotend AS appello_penotend, appello.posti AS appello_posti, appello.prenotstart AS appello_prenotstart,CASE WHEN appello.prointermedia = 'S' THEN 'Si' WHEN appello.prointermedia = 'N' THEN 'No' END AS appello_prointermedia,CASE WHEN appello.publicato = 'S' THEN 'Si' WHEN appello.publicato = 'N' THEN 'No' END AS appello_publicato, appello.surmanestop AS appello_surmanestop, appello.surnamestart AS appello_surnamestart,
 isnull('Descrizione: ' + appello.description + '; ','') + ' ' + isnull('Anno accademico: ' + appello.aa + '; ','') as dropdown_title
FROM [dbo].appello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appelloazionekind WITH (NOLOCK) ON appello.idappelloazionekind = [dbo].appelloazionekind.idappelloazionekind
LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON appello.idappellokind = [dbo].appellokind.idappellokind
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON appello.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON [dbo].sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].studprenotkind WITH (NOLOCK) ON appello.idstudprenotkind = [dbo].studprenotkind.idstudprenotkind
WHERE  appello.idappello IS NOT NULL 
GO

/****** Object:  View [dbo].[strutturaparentview]    Script Date: 10/11/2021 10:37:12 ******/
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentview]
GO

CREATE VIEW [dbo].[strutturaparentview]
AS
WITH cte_org AS (SELECT        ';' + CAST(ISNULL(idstruttura, 0) AS varchar(MAX)) + ';' AS ramo, idstruttura, title, paridstruttura
                                       FROM            dbo.struttura
                                       WHERE        (paridstruttura IS NULL)
                                       UNION ALL
                                       SELECT        ';' + CAST(ISNULL(e.idstruttura, 0) AS varchar(MAX)) + o.ramo AS ramo, e.idstruttura, e.title, e.paridstruttura
                                       FROM            dbo.struttura AS e INNER JOIN
                                                                cte_org AS o ON o.idstruttura = e.paridstruttura)
    SELECT        ramo, idstruttura, title, paridstruttura
     FROM            cte_org AS cte_org_1
GO


/****** Object:  View [dbo].[strutturaparentresponsabiliview]    Script Date: 10/11/2021 10:37:00 ******/
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentresponsabiliview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentresponsabiliview]
GO

CREATE VIEW [dbo].[strutturaparentresponsabiliview]
AS
SELECT        v.idstruttura, v.title, s.idstruttura AS strutturaparent, s.title AS titlestrutturaparent, s.idreg_resp, r.title AS responsabile, s.idreg_valut, va.title AS valutatore, s.idreg_appr, ap.title AS approvatore
FROM            dbo.strutturaparentview AS v INNER JOIN
                         dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
                         dbo.registry AS r ON r.idreg = s.idreg_resp LEFT OUTER JOIN
                         dbo.registry AS va ON va.idreg = s.idreg_valut LEFT OUTER JOIN
                         dbo.registry AS ap ON ap.idreg = s.idreg_appr
GO-- CREAZIONE VISTA [dbo].[getcontrattikindview]
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindview]
GO

CREATE VIEW [dbo].[getcontrattikindview]
AS
SELECT        
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	ck.parttime, 
	ck.tempdef, 
	ck.costolordoannuo as costolordoannuo_ck,
	ck.costolordoannuo_inq,
	ck.costolordoannuo_stip,
	isnull(ck.costolordoannuo_stip,isnull(ck.costolordoannuo_inq,ck.costolordoannuo)) as costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((ck.costolordoannuo/isnull(oremaxtempopieno,1720))*isnull(oremaxgg,8)*30,2,1) as decimal(18,2)) costomese,
	oremaxtempoparziale, oremaxtempopieno,
	oremaxdidatempoparziale, oremaxdidatempopieno,
	oremindidatempoparziale, oremindidatempopieno
FROM (
	SELECT cckk.*, 
	(select max(costolordoannuo) from inquadramento i WHERE i.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_inq,
	(select max(totale) from stipendio s WHERE s.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_stip
	FROM dbo.contrattokind cckk
) ck 

GO


-- CREAZIONE PROCEDURE [dbo].[sp_import_contratticsa]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[sp_import_contratticsa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_import_contratticsa]
GO
CREATE procedure [dbo].[sp_import_contratticsa]
(
	@idparents nvarchar(255),
	@nometabella nvarchar(255)
)
AS
BEGIN
	SET XACT_ABORT ON
	SET NoCount ON

    BEGIN TRY

		BEGIN TRANSACTION;

		DECLARE @outmsg nvarchar(255);

		DECLARE @idparent nvarchar(255);
		SET @idparent = (select top 1 items from dbo.split(@idparents, ','));

		DECLARE @Sql NVARCHAR(MAX);
		DECLARE @SqlDrop NVARCHAR(MAX);
		DECLARE @CRLF nchar(2) = NCHAR(13) + NCHAR(10);
		DECLARE @i int = (SELECT isnull(MAX(idcontratto),0) FROM dbo.contratto);

		SET @Sql = N'INSERT INTO dbo.contratto (idcontratto,ct,cu,estremibando,idcontrattokind,idinquadramento,idreg,lt,lu,parttime,scatto,start,stop,tempdef,tempindet)' + @CRLF +
		N'SELECT row_number() over(order by registry.idreg) +' + convert(nvarchar, @i) + ', GETDATE(), ''sp_import_contratticsa'', null,' + @CRLF +
		N'CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idcontrattokind,
		CASE 
			WHEN exists(select top 1 idinquadramento from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idinquadramento from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idinquadramento from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idinquadramento from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idinquadramento,' + @CRLF +
		N'registry.idreg, GETDATE(), ''sp_import_contratticsa'', null, null, 
		CONVERT(date,temp.datainizio ,103),
		ltrim(rtrim(CASE WHEN temp.datafine = '''' THEN NULL ELSE CONVERT(date,temp.datafine ,103) END)) as datafine,' + @CRLF +
		N'CASE      
			WHEN exists(select top 1 isnull(tempdef,''N'') from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)      
			THEN (select top 1 isnull(tempdef,''N'') from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)     
			WHEN exists(select top 1 idinquadramento from stipendio where stipendio.siglaimportazione =  temp.inquadramento)      
			THEN (select top 1 isnull(tempdef,''N'') from stipendio inner join inquadramento i on i.idinquadramento = stipendio.idinquadramento where stipendio.siglaimportazione =  temp.inquadramento) 
			ELSE ''N''  END as tempdef, ''S''' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT matricola, ruolo, inquadramento, datainizio, datafine' + @CRLF 
		SET @Sql = @Sql +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		WHERE CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end is not null
		and not exists (select top 1 c.idcontratto from contratto c where  c.idreg = registry.idreg  
			and YEAR(c.start) = YEAR(CONVERT(date,temp.datainizio ,103))
			and MONTH(c.start) = MONTH(CONVERT(date,temp.datainizio ,103)) 
			and DAY(c.start) = DAY(CONVERT(date,temp.datainizio ,103)) 
			and c.idcontrattokind = CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
			END)' + @CRLF + N';';

		/*select @@RowCount*/

		--aggiungere le select delle righe non importate perchè 
		--1 idcontrattokind è null
		--2 è un doppione
		DECLARE @SqlErrorRows NVARCHAR(MAX) = 'select temp.*, 
		CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end as idcontratto' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT matricola, ruolo, inquadramento, datainizio, datafine' + @CRLF 
		SET @SqlErrorRows = @SqlErrorRows +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		WHERE CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
		end is null
		OR exists (select top 1 c.idcontratto from contratto c where  c.idreg = registry.idreg  
			and YEAR(c.start) = YEAR(CONVERT(date,temp.datainizio ,103))
			and MONTH(c.start) = MONTH(CONVERT(date,temp.datainizio ,103)) 
			and DAY(c.start) = DAY(CONVERT(date,temp.datainizio ,103)) 
			and c.idcontrattokind = CASE 
			WHEN exists(select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo) 
			THEN (select top 1 idcontrattokind from contrattokind where siglaimportazione =  temp.ruolo)
			WHEN exists(select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento) 
			THEN (select top 1 idcontrattokind from inquadramento where inquadramento.siglaimportazione =  temp.inquadramento)
			WHEN exists(select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', '''')) 
			THEN (select top 1 idcontrattokind from stipendio where replace(stipendio.siglaimportazione, '' '', '''') =  replace(temp.inquadramento, '' '', ''''))
			END)' + @CRLF + N';';

		SET @SqlDrop = N'DROP TABLE ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + N';';

		--select @Sql
		--select @SqlErrorRows
		exec (@Sql)

		exec (@SqlDrop)
		
		SET @outmsg = 'Operation Successful';
		select @outmsg;

		COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        
			SET @outmsg = ERROR_MESSAGE();
			select @outmsg;

			ROLLBACK TRANSACTION
			/*SELECT
				ERROR_NUMBER() AS ErrorNumber,
				ERROR_STATE() AS ErrorState,
				ERROR_SEVERITY() AS ErrorSeverity,
				ERROR_PROCEDURE() AS ErrorProcedure,
				ERROR_LINE() AS ErrorLine,
				ERROR_MESSAGE() AS ErrorMessage;*/
        
    END CATCH
END;

GO
--exec [dbo].[sp_import_contratticsa] '1', '_temp1637323744064'

--CHECK DUPLICATI
--select --idreg,start, idcontrattokind, idinquadramento, cu , 
--* from contratto  
--where idreg in (select idreg from (select count(idreg) as cc, idreg,start from contratto group by idreg,start) tbl1 where cc>1)
--and idreg in (select idreg from contratto where cu = 'sp_import_contratticsa')
--order by idreg, start-- CREAZIONE PROCEDURE [dbo].[sp_import_stipendicsa]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[sp_import_stipendicsa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_import_stipendicsa]
GO

CREATE procedure [dbo].[sp_import_stipendicsa]
(
	@idparents nvarchar(255),
	@nometabella nvarchar(255)
)
AS
BEGIN
	SET XACT_ABORT ON
	SET NoCount ON

    BEGIN TRY

		BEGIN TRANSACTION;

		DECLARE @outmsg nvarchar(255);

		DECLARE @idparent nvarchar(255);
		SET @idparent = (select top 1 items from dbo.split(@idparents, ','));

		DECLARE @Sql NVARCHAR(MAX);
		DECLARE @SqlDrop NVARCHAR(MAX);
		DECLARE @CRLF nchar(2) = NCHAR(13) + NCHAR(10);
		DECLARE @i int = (SELECT isnull(MAX(idstipendioannuo),0) FROM dbo.stipendioannuo);

		SET @Sql = N'INSERT INTO dbo.stipendioannuo (idreg, idstipendioannuo, year,lordo,caricoente,irap,totale,ct,lt,cu,lu,idcontratto)' + @CRLF +
		N'SELECT registry.idreg, row_number() over(order by registry.idreg) +' + convert(nvarchar, @i) + ', temp.anno, temp.lordo, temp.oneri, temp.lordo * 0.085 as irap, (temp.lordo + temp.oneri +  (temp.lordo * 0.085)) as totale, GETDATE(), GETDATE(), ''sp_import_stipendicsa'', ''sp_import_stipendicsa'',
		(select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc) as idcontratto' + @CRLF +
		N'FROM' + @CRLF +
		N'(SELECT anno, matricola, sum(cast(lordo as decimal(18,2))) as lordo, sum(cast(oneri as decimal(18,2))) as oneri, sum(cast(totale as decimal(18,2))) as totale' + @CRLF +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + @CRLF +
		N'GROUP BY matricola, anno' + @CRLF + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		where exists (select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc)' + @CRLF + N';';

		 --aggiungere l'export delle righe in errore perchè non risulta un contratto attivo per l'anno dello stipendio indicato
		 DECLARE @SqlErrorRows NVARCHAR(MAX) = 'select temp.* from 
		 (SELECT anno, matricola, sum(cast(lordo as decimal(18,2))) as lordo, sum(cast(oneri as decimal(18,2))) as oneri, sum(cast(totale as decimal(18,2))) as totale' + @CRLF +
        N'FROM ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + @CRLF +
		N'GROUP BY matricola, anno' + @CRLF + ') as temp' + @CRLF +
		N'JOIN registry ON format(CAST(temp.matricola as int) ,''000000'') = registry.extmatricula
		 where not exists (select top 1 idcontratto from contratto c 
		 where isnull(c.stop, ''22221231'') >= temp.anno + ''0101'' and c.start<= temp.anno + ''1231'' and c.idreg = registry.idreg
		 order by c.start desc, c.stop desc)'

		SET @SqlDrop = N'DROP TABLE ' + QUOTENAME('amministrazione') + N'.' + QUOTENAME(@nometabella) + N';';

		--select @Sql
		--select @SqlErrorRows
		exec (@Sql)

		exec (@SqlDrop)
		
		SET @outmsg = 'Operation Successful';
		select @outmsg;

		COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        
			SET @outmsg = ERROR_MESSAGE();
			select @outmsg;

			ROLLBACK TRANSACTION
			/*SELECT
				ERROR_NUMBER() AS ErrorNumber,
				ERROR_STATE() AS ErrorState,
				ERROR_SEVERITY() AS ErrorSeverity,
				ERROR_PROCEDURE() AS ErrorProcedure,
				ERROR_LINE() AS ErrorLine,
				ERROR_MESSAGE() AS ErrorMessage;*/
        
    END CATCH
END;

GO 

--exec [dbo].[sp_import_stipendicsa] '1', '_temp1637247421803'
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[Split]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
	DROP FUNCTION [dbo].[Split]
GO

CREATE FUNCTION [dbo].[Split] (@String VARCHAR (MAX), @Delimiter CHAR (1))
   RETURNS @results TABLE (items VARCHAR (MAX))
AS
   BEGIN
     DECLARE @index   INT
     DECLARE @slice   VARCHAR (8000)
     SELECT @index = 1
     IF len (@String) < 1 OR @String IS NULL
         RETURN
     WHILE @index != 0
     BEGIN
         SET @index = charindex (@Delimiter, @String)
         IF @index != 0
           SET @slice = left (@String, @index-1)
         ELSE
           SET @slice = @String
         IF (len (@slice) > 0)
           INSERT INTO @results (Items)
           VALUES (@slice)
         SET @String = right (@String, len (@String)-@index)
         IF len (@String) = 0
           BREAK
     END
     RETURN
   END;

GO

IF EXISTS(select * from menuweb where tableName = 'perfsogliakind' and editType = 'default')
BEGIN
	UPDATE menuweb SET label = 'Denominazione del tipo di soglia' where tableName = 'perfsogliakind' and editType = 'default'
END
ELSE
BEGIN
	exec menuweb_addentry @idmenuwebparent = 468, @idx = 470, @tableName = 'perfsogliakind', @editType = 'default', @label = 'Denominazione del tipo di soglia';
END
GO

IF EXISTS(select * from menuweb where tableName = 'struttura' and editType = 'perf')
BEGIN
	UPDATE menuweb SET label = 'Unità organizzative' where tableName = 'struttura' and editType = 'perf'
END
ELSE
BEGIN
	exec menuweb_addentry @idmenuwebparent = 468, @idx = 474, @tableName = 'struttura', @editType = 'perf', @label = 'Unità organizzative';
END
GO

exec menuweb_addentry @idmenuwebparent = 81, @idx = 516, @tableName = '', @editType = '', @label = 'Analisi dei costi';
exec menuweb_addentry @idmenuwebparent = 516, @idx = 517, @tableName = 'analisiannuale', @editType = 'default', @label = 'Previsione dei costi stipendi nel triennio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 518, @tableName = 'contrattoaggregatokind', @editType = 'default', @label = 'Tipologie di contratto aggregate per costo';

IF EXISTS(select * from menuweb where tableName = 'progettokind' and editType = 'seg')
BEGIN
	UPDATE menuweb SET label = 'Modello/Template di progetto o attività' where tableName = 'progettokind' and editType = 'seg'
END
ELSE
BEGIN
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Modello/Template di progetto o attività';
END
GO

-----------------------

 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contratto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'contrattodefaultview' WHERE listtype = 'default' AND tablename = 'contratto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contratto', 'default', 'contrattodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'analisiannuale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'analisiannualedefaultview' WHERE listtype = 'default' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('analisiannuale', 'default', 'analisiannualedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'elenco' AND tablename = 'inquadramento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'elenco', newtablename = 'inquadramentoelencoview' WHERE listtype = 'elenco' AND tablename = 'inquadramento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'elenco', 'inquadramentoelencoview', 'elenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'integrandi' AND tablename = 'sasd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'integrandi', newtablename = 'sasdintegrandiview' WHERE listtype = 'integrandi' AND tablename = 'sasd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'integrandi', 'sasdintegrandiview', 'integrandi', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amm' AND tablename = 'contratto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amm', newtablename = 'contrattoammview' WHERE listtype = 'amm' AND tablename = 'contratto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contratto', 'amm', 'contrattoammview', 'amm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcontrattikindview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getcontrattikindviewdefaultview' WHERE listtype = 'default' AND tablename = 'getcontrattikindview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcontrattikindview', 'default', 'getcontrattikindviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturaparentresponsabiliview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturaparentresponsabiliviewdefaultview' WHERE listtype = 'default' AND tablename = 'strutturaparentresponsabiliview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturaparentresponsabiliview', 'default', 'strutturaparentresponsabiliviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturaparentview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturaparentviewdefaultview' WHERE listtype = 'default' AND tablename = 'strutturaparentview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturaparentview', 'default', 'strutturaparentviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO


--------------------------------------------

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('analisiannualedefaultview')
GO

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'inquadramentoelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('inquadramentoelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sasdintegrandiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('sasdintegrandiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattoammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattoammview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getcontrattikindviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getcontrattikindviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaparentresponsabiliviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaparentviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaparentviewdefaultview')
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattodefaultview', '"idcontratto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto"' WHERE [tablename] = 'contrattodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('analisiannualedefaultview', '"year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"year"' WHERE [tablename] = 'analisiannualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pcspuntiorganicoviewdefaultview', '"idcontrattokind","year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind","year"' WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('analisiannualedefaultview', '"idanalisiannuale","year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idanalisiannuale","year"' WHERE [tablename] = 'analisiannualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattodefaultview', '"idcontratto","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto","idreg"' WHERE [tablename] = 'contrattodefaultview'
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattokinddefaultview', '"idcontrattokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind"' WHERE [tablename] = 'contrattokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('workpackagesegview', '"idprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idworkpackage"' WHERE [tablename] = 'workpackagesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettosegview', '"idprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto"' WHERE [tablename] = 'progettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'auladefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('auladefaultview', '"idaula","idedificio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaula","idedificio","idsede"' WHERE [tablename] = 'auladefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiodefaultview', '"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudiodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('deliberasegview', '"iddelibera"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddelibera"' WHERE [tablename] = 'deliberasegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegview', '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"' WHERE [tablename] = 'progettocostosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettosegview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegprgview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegprgview', '"idprogetto","idprogettocosto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto"' WHERE [tablename] = 'progettocostosegprgview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegsalview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegsalview', '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"' WHERE [tablename] = 'progettocostosegsalview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettokindsegview', '"idprogettokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettokind"' WHERE [tablename] = 'progettokindsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'inquadramentoelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('inquadramentoelencoview', '"idcontrattokind","idinquadramento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind","idinquadramento"' WHERE [tablename] = 'inquadramentoelencoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sasdintegrandiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sasdintegrandiview', '"idsasd"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsasd"' WHERE [tablename] = 'sasdintegrandiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattoammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattoammview', '"idcontratto","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto","idreg"' WHERE [tablename] = 'contrattoammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getcontrattikindviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getcontrattikindviewdefaultview', '"idcontrattokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind"' WHERE [tablename] = 'getcontrattikindviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaparentresponsabiliviewdefaultview', '"idperfruolo","idreg","idstruttura","idstruttura_parent"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfruolo","idreg","idstruttura","idstruttura_parent"' WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaparentviewdefaultview', '"idstruttura","paridstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura","paridstruttura"' WHERE [tablename] = 'strutturaparentviewdefaultview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'inquadramentoelencoview' AND [listtype] = 'elenco')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('inquadramentoelencoview', 'elenco', 'inquadramento_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'inquadramento_title desc' WHERE [tablename] = 'inquadramentoelencoview' AND [listtype] = 'elenco'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sasdintegrandiview' AND [listtype] = 'integrandi')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sasdintegrandiview', 'integrandi', 'codice asc , sasd_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'codice asc , sasd_title desc' WHERE [tablename] = 'sasdintegrandiview' AND [listtype] = 'integrandi'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getcontrattikindviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getcontrattikindviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'getcontrattikindviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaparentresponsabiliviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaparentviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strutturaparentviewdefaultview' AND [listtype] = 'default'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbunatantumdefaultview', 'default', 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'')) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'')) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbunatantumdefaultview', 'default', 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'') and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'') and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'')) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'')) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaledefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazionepersonaledefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore''))) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore''))) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfvalutazionepersonaledefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore'')) or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore'')) or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendioannuodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendioannuodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendioannuoprevview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendioannuoprevview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcscessazionidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcscessazionidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcsbilanciodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcsbilanciodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcsassunzionidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcsassunzionidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcspuntiorganicoviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokindaccmotivedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavoaccmotivesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoricavodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoricavodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavocontrattokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'cedolinodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'cedolinodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokindcontrattokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendiodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendiodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'insegncaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'insegncaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformcaratteristicaoraerogataview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentocaratteristicaoradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tipologiastudentestrutturasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tipologiastudentestrutturasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzastruview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzastruview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaresponsabiledefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaresponsabiledefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomistrutturetosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomistrutturetosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomistrutturefromsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomistrutturefromsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tirociniocandidaturasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tirociniocandidaturasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'corsostudiostrutturadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'corsostudiostrutturadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissregistry_docentiingressoview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissregistry_docentiingressoview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissregistry_docentidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissregistry_docentidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissingressoview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissingressoview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_docentidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_docentidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_aziendedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_aziendedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_docentidocentiview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_docentidocentiview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogaccessodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogaccessodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaresponsabiledefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaresponsabiledefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcscessazioniviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcscessazioniviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzastruview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzastruview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didproggruppcaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'classescuolacaratteristicaclasseview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'classescuolacaratteristicaclasseview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
END
GO
