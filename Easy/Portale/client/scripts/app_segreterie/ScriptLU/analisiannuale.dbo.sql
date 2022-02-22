
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


-- CREAZIONE TABELLA analisiannuale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannuale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[analisiannuale] (
idanalisiannuale int NOT NULL,
contrattiincarichiinsegnamento0 decimal(19,2) NULL,
contrattiincarichiinsegnamento1 decimal(19,2) NULL,
contrattiincarichiinsegnamento2 decimal(19,2) NULL,
contrattiincarichiinsegnamento3 decimal(19,2) NULL,
costopt decimal(19,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
ffo0 decimal(19,2) NULL,
ffo1 decimal(19,2) NULL,
ffo2 decimal(19,2) NULL,
ffo3 decimal(19,2) NULL,
finanzesternicontrattiincarichiinsegnamento0 decimal(19,2) NULL,
finanzesternicontrattiincarichiinsegnamento1 decimal(19,2) NULL,
finanzesternicontrattiincarichiinsegnamento2 decimal(19,2) NULL,
finanzesternicontrattiincarichiinsegnamento3 decimal(19,2) NULL,
finanzesternidirPTA0 decimal(19,2) NULL,
finanzesternidirPTA1 decimal(19,2) NULL,
finanzesternidirPTA2 decimal(19,2) NULL,
finanzesternidirPTA3 decimal(19,2) NULL,
finanzesternidocenti0 decimal(19,2) NULL,
finanzesternidocenti1 decimal(19,2) NULL,
finanzesternidocenti2 decimal(19,2) NULL,
finanzesternidocenti3 decimal(19,2) NULL,
fondocontrattazioneintegrativa0 decimal(19,2) NULL,
fondocontrattazioneintegrativa1 decimal(19,2) NULL,
fondocontrattazioneintegrativa2 decimal(19,2) NULL,
fondocontrattazioneintegrativa3 decimal(19,2) NULL,
incrementodocenti1 decimal(19,2) NULL,
incrementodocenti2 decimal(19,2) NULL,
incrementodocenti3 decimal(19,2) NULL,
lt datetime NULL,
lu varchar(64) NULL,
programmazionetriennale0 decimal(19,2) NULL,
programmazionetriennale1 decimal(19,2) NULL,
programmazionetriennale2 decimal(19,2) NULL,
programmazionetriennale3 decimal(19,2) NULL,
speseDG0 decimal(19,2) NULL,
speseDG1 decimal(19,2) NULL,
speseDG2 decimal(19,2) NULL,
speseDG3 decimal(19,2) NULL,
spesedirPTA0 decimal(19,2) NULL,
spesedirPTA1 decimal(19,2) NULL,
spesedirPTA2 decimal(19,2) NULL,
spesedirPTA3 decimal(19,2) NULL,
spesedocenti0 decimal(19,2) NULL,
spesedocenti1 decimal(19,2) NULL,
spesedocenti2 decimal(19,2) NULL,
spesedocenti3 decimal(19,2) NULL,
speseriduzione0 decimal(19,2) NULL,
speseriduzione1 decimal(19,2) NULL,
speseriduzione2 decimal(19,2) NULL,
speseriduzione3 decimal(19,2) NULL,
tasse0 decimal(19,2) NULL,
tasse1 decimal(19,2) NULL,
tasse2 decimal(19,2) NULL,
tasse3 decimal(19,2) NULL,
totspesepersonalecaricoateneo0 decimal(19,2) NULL,
totspesepersonalecaricoateneo1 decimal(19,2) NULL,
totspesepersonalecaricoateneo2 decimal(19,2) NULL,
totspesepersonalecaricoateneo3 decimal(19,2) NULL,
trattamentostipintegrativoCEL0 decimal(19,2) NULL,
trattamentostipintegrativoCEL1 decimal(19,2) NULL,
trattamentostipintegrativoCEL2 decimal(19,2) NULL,
trattamentostipintegrativoCEL3 decimal(19,2) NULL,
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'contrattiincarichiinsegnamento0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD contrattiincarichiinsegnamento0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN contrattiincarichiinsegnamento0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'contrattiincarichiinsegnamento1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD contrattiincarichiinsegnamento1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN contrattiincarichiinsegnamento1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'contrattiincarichiinsegnamento2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD contrattiincarichiinsegnamento2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN contrattiincarichiinsegnamento2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'contrattiincarichiinsegnamento3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD contrattiincarichiinsegnamento3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN contrattiincarichiinsegnamento3 decimal(19,2) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'ffo0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD ffo0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN ffo0 decimal(19,2) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternicontrattiincarichiinsegnamento0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternicontrattiincarichiinsegnamento0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternicontrattiincarichiinsegnamento0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternicontrattiincarichiinsegnamento1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternicontrattiincarichiinsegnamento1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternicontrattiincarichiinsegnamento1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternicontrattiincarichiinsegnamento2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternicontrattiincarichiinsegnamento2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternicontrattiincarichiinsegnamento2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternicontrattiincarichiinsegnamento3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternicontrattiincarichiinsegnamento3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternicontrattiincarichiinsegnamento3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidirPTA0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidirPTA0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidirPTA0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidirPTA1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidirPTA1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidirPTA1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidirPTA2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidirPTA2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidirPTA2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidirPTA3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidirPTA3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidirPTA3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidocenti0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidocenti0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidocenti0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidocenti1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidocenti1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidocenti1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidocenti2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidocenti2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidocenti2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'finanzesternidocenti3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD finanzesternidocenti3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN finanzesternidocenti3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'fondocontrattazioneintegrativa0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD fondocontrattazioneintegrativa0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN fondocontrattazioneintegrativa0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'fondocontrattazioneintegrativa1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD fondocontrattazioneintegrativa1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN fondocontrattazioneintegrativa1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'fondocontrattazioneintegrativa2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD fondocontrattazioneintegrativa2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN fondocontrattazioneintegrativa2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'fondocontrattazioneintegrativa3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD fondocontrattazioneintegrativa3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN fondocontrattazioneintegrativa3 decimal(19,2) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'programmazionetriennale0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD programmazionetriennale0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN programmazionetriennale0 decimal(19,2) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseDG0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseDG0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseDG0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseDG1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseDG1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseDG1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseDG2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseDG2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseDG2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseDG3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseDG3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseDG3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedirPTA0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedirPTA0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedirPTA0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedirPTA1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedirPTA1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedirPTA1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedirPTA2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedirPTA2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedirPTA2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedirPTA3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedirPTA3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedirPTA3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedocenti0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedocenti0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedocenti0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedocenti1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedocenti1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedocenti1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedocenti2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedocenti2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedocenti2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'spesedocenti3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD spesedocenti3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN spesedocenti3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseriduzione0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseriduzione0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseriduzione0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseriduzione1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseriduzione1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseriduzione1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseriduzione2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseriduzione2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseriduzione2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'speseriduzione3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD speseriduzione3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN speseriduzione3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'tasse0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD tasse0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN tasse0 decimal(19,2) NULL
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'totspesepersonalecaricoateneo0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD totspesepersonalecaricoateneo0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN totspesepersonalecaricoateneo0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'totspesepersonalecaricoateneo1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD totspesepersonalecaricoateneo1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN totspesepersonalecaricoateneo1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'totspesepersonalecaricoateneo2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD totspesepersonalecaricoateneo2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN totspesepersonalecaricoateneo2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'totspesepersonalecaricoateneo3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD totspesepersonalecaricoateneo3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN totspesepersonalecaricoateneo3 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'trattamentostipintegrativoCEL0' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD trattamentostipintegrativoCEL0 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN trattamentostipintegrativoCEL0 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'trattamentostipintegrativoCEL1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD trattamentostipintegrativoCEL1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN trattamentostipintegrativoCEL1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'trattamentostipintegrativoCEL2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD trattamentostipintegrativoCEL2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN trattamentostipintegrativoCEL2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'analisiannuale' and C.name = 'trattamentostipintegrativoCEL3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [analisiannuale] ADD trattamentostipintegrativoCEL3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [analisiannuale] ALTER COLUMN trattamentostipintegrativoCEL3 decimal(19,2) NULL
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

