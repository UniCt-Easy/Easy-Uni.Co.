
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

