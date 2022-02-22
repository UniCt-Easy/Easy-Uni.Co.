
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

-- VERIFICA DI analisiannuale IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'analisiannuale'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','analisiannuale','int','Generator','idanalisiannuale','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','contrattiincarichiinsegnamento0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','contrattiincarichiinsegnamento1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','contrattiincarichiinsegnamento2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','contrattiincarichiinsegnamento3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','costopt','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','datetime','Generator','ct','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','varchar(64)','Generator','cu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','ffo0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','ffo1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','ffo2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','ffo3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternicontrattiincarichiinsegnamento0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternicontrattiincarichiinsegnamento1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternicontrattiincarichiinsegnamento2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternicontrattiincarichiinsegnamento3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidirPTA0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidirPTA1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidirPTA2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidirPTA3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidocenti0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','finanzesternidocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','fondocontrattazioneintegrativa0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','fondocontrattazioneintegrativa1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','fondocontrattazioneintegrativa2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','fondocontrattazioneintegrativa3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','incrementodocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','incrementodocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','incrementodocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','datetime','Generator','lt','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','varchar(64)','Generator','lu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','programmazionetriennale0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','programmazionetriennale1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','programmazionetriennale2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','programmazionetriennale3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseDG0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseDG1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseDG2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseDG3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedirPTA0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedirPTA1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedirPTA2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedirPTA3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedocenti0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','spesedocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseriduzione0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseriduzione1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseriduzione2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','speseriduzione3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','tasse0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','tasse1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','tasse2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','tasse3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','totspesepersonalecaricoateneo0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','totspesepersonalecaricoateneo1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','totspesepersonalecaricoateneo2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','totspesepersonalecaricoateneo3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','trattamentostipintegrativoCEL0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','trattamentostipintegrativoCEL1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','trattamentostipintegrativoCEL2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannuale','decimal(19,2)','Generator','trattamentostipintegrativoCEL3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','analisiannuale','int','assistenza','year','4','S','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI analisiannuale IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'analisiannuale')
UPDATE customobject set isreal = 'S' where objectname = 'analisiannuale'
ELSE
INSERT INTO customobject (objectname, isreal) values('analisiannuale', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'analisiannuale')
UPDATE [tabledescr] SET description = 'Previsione dei costi stipendi nel triennio',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-21 11:53:21.850'},lu = 'Generator',title = 'Previsione dei costi stipendi nel triennio' WHERE tablename = 'analisiannuale'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('analisiannuale','Previsione dei costi stipendi nel triennio','2','S',{ts '2022-01-21 11:53:21.850'},'Generator','Previsione dei costi stipendi nel triennio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'contrattiincarichiinsegnamento0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contrattiincarichiinsegnamento0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contrattiincarichiinsegnamento0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contrattiincarichiinsegnamento1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contrattiincarichiinsegnamento1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contrattiincarichiinsegnamento1','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contrattiincarichiinsegnamento2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contrattiincarichiinsegnamento2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contrattiincarichiinsegnamento2','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contrattiincarichiinsegnamento3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contrattiincarichiinsegnamento3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contrattiincarichiinsegnamento3','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costopt' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-21 16:25:16.610'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costopt' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costopt','analisiannuale','9','19','2','','S',{ts '2021-10-21 16:25:16.610'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-18 09:51:26.717'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','analisiannuale','8',null,null,'','S',{ts '2021-11-18 09:51:26.717'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-18 09:51:26.717'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','analisiannuale','64',null,null,'','S',{ts '2021-11-18 09:51:26.717'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ffo0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ffo0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ffo0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ffo1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ffo1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ffo1','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ffo2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ffo2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ffo2','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ffo3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ffo3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ffo3','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternicontrattiincarichiinsegnamento0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-23 09:50:08.607'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternicontrattiincarichiinsegnamento0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternicontrattiincarichiinsegnamento0','analisiannuale','9','19','2','','S',{ts '2021-12-23 09:50:08.607'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternicontrattiincarichiinsegnamento1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-23 09:50:08.607'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternicontrattiincarichiinsegnamento1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternicontrattiincarichiinsegnamento1','analisiannuale','9','19','2','','S',{ts '2021-12-23 09:50:08.607'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternicontrattiincarichiinsegnamento2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-23 09:50:08.607'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternicontrattiincarichiinsegnamento2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternicontrattiincarichiinsegnamento2','analisiannuale','9','19','2','','S',{ts '2021-12-23 09:50:08.607'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternicontrattiincarichiinsegnamento3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-23 09:50:08.607'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternicontrattiincarichiinsegnamento3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternicontrattiincarichiinsegnamento3','analisiannuale','9','19','2','','S',{ts '2021-12-23 09:50:08.607'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidirPTA0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidirPTA0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidirPTA0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidirPTA1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidirPTA1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidirPTA1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidirPTA2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidirPTA2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidirPTA2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidirPTA3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidirPTA3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidirPTA3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidocenti0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidocenti0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidocenti0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidocenti1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidocenti1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidocenti1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidocenti2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidocenti2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidocenti2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanzesternidocenti3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'finanzesternidocenti3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanzesternidocenti3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fondocontrattazioneintegrativa' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 18:10:18.720'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'fondocontrattazioneintegrativa' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fondocontrattazioneintegrativa','analisiannuale','9','19','2','','S',{ts '2021-12-21 18:10:18.720'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fondocontrattazioneintegrativa0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'fondocontrattazioneintegrativa0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fondocontrattazioneintegrativa0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fondocontrattazioneintegrativa1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'fondocontrattazioneintegrativa1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fondocontrattazioneintegrativa1','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fondocontrattazioneintegrativa2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'fondocontrattazioneintegrativa2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fondocontrattazioneintegrativa2','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fondocontrattazioneintegrativa3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-16 13:11:56.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'fondocontrattazioneintegrativa3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fondocontrattazioneintegrativa3','analisiannuale','9','19','2','','S',{ts '2021-12-16 13:11:56.930'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idanalisiannuale' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-21 16:25:16.610'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idanalisiannuale' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idanalisiannuale','analisiannuale','4',null,null,'','S',{ts '2021-10-21 16:25:16.610'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'incrementodocenti1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = '',kind = 'S',lt = {ts '2021-10-21 16:25:16.610'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'incrementodocenti1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('incrementodocenti1','analisiannuale','9','19','6','','S',{ts '2021-10-21 16:25:16.610'},'Generator','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'incrementodocenti2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = '',kind = 'S',lt = {ts '2021-10-21 16:25:16.610'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'incrementodocenti2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('incrementodocenti2','analisiannuale','9','19','6','','S',{ts '2021-10-21 16:25:16.610'},'Generator','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'incrementodocenti3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = '',kind = 'S',lt = {ts '2021-10-21 16:25:16.610'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'incrementodocenti3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('incrementodocenti3','analisiannuale','9','19','6','','S',{ts '2021-10-21 16:25:16.610'},'Generator','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-18 09:51:26.717'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','analisiannuale','8',null,null,'','S',{ts '2021-11-18 09:51:26.717'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-18 09:51:26.717'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','analisiannuale','64',null,null,'','S',{ts '2021-11-18 09:51:26.717'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programmazionetriennale0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'programmazionetriennale0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programmazionetriennale0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programmazionetriennale1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-29 12:26:23.440'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'programmazionetriennale1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programmazionetriennale1','analisiannuale','9','19','2','','S',{ts '2021-11-29 12:26:23.440'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programmazionetriennale2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-29 12:26:23.440'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'programmazionetriennale2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programmazionetriennale2','analisiannuale','9','19','2','','S',{ts '2021-11-29 12:26:23.440'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programmazionetriennale3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-29 12:26:23.440'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'programmazionetriennale3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programmazionetriennale3','analisiannuale','9','19','2','','S',{ts '2021-11-29 12:26:23.440'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseDG0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseDG0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseDG0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseDG1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseDG1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseDG1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseDG2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseDG2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseDG2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseDG3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseDG3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseDG3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedirPTA0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedirPTA0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedirPTA0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedirPTA1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedirPTA1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedirPTA1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedirPTA2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedirPTA2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedirPTA2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedirPTA3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedirPTA3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedirPTA3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedocenti0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedocenti0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedocenti0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedocenti1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedocenti1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedocenti1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedocenti2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedocenti2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedocenti2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'spesedocenti3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'spesedocenti3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('spesedocenti3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseriduzione0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2022-01-19 17:25:25.140'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseriduzione0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseriduzione0','analisiannuale','9','19','2','','S',{ts '2022-01-19 17:25:25.140'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseriduzione1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2022-01-19 17:25:25.140'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseriduzione1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseriduzione1','analisiannuale','9','19','2','','S',{ts '2022-01-19 17:25:25.140'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseriduzione2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2022-01-19 17:25:25.140'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseriduzione2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseriduzione2','analisiannuale','9','19','2','','S',{ts '2022-01-19 17:25:25.140'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'speseriduzione3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2022-01-19 17:25:25.140'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'speseriduzione3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('speseriduzione3','analisiannuale','9','19','2','','S',{ts '2022-01-19 17:25:25.140'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tasse0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tasse0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tasse0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tasse1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tasse1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tasse1','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tasse2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tasse2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tasse2','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tasse3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-19 12:25:01.490'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tasse3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tasse3','analisiannuale','9','19','2','','S',{ts '2021-11-19 12:25:01.490'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totspesepersonalecaricoateneo0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totspesepersonalecaricoateneo0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totspesepersonalecaricoateneo0','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totspesepersonalecaricoateneo1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totspesepersonalecaricoateneo1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totspesepersonalecaricoateneo1','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totspesepersonalecaricoateneo2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totspesepersonalecaricoateneo2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totspesepersonalecaricoateneo2','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totspesepersonalecaricoateneo3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 17:18:18.280'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totspesepersonalecaricoateneo3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totspesepersonalecaricoateneo3','analisiannuale','9','19','2','','S',{ts '2021-12-21 17:18:18.280'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'trattamentostipintegrativoCEL0' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 18:18:50.690'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'trattamentostipintegrativoCEL0' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('trattamentostipintegrativoCEL0','analisiannuale','9','19','2','','S',{ts '2021-12-21 18:18:50.690'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'trattamentostipintegrativoCEL1' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 18:18:50.690'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'trattamentostipintegrativoCEL1' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('trattamentostipintegrativoCEL1','analisiannuale','9','19','2','','S',{ts '2021-12-21 18:18:50.690'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'trattamentostipintegrativoCEL2' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 18:18:50.690'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'trattamentostipintegrativoCEL2' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('trattamentostipintegrativoCEL2','analisiannuale','9','19','2','','S',{ts '2021-12-21 18:18:50.690'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'trattamentostipintegrativoCEL3' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-12-21 18:18:50.690'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'trattamentostipintegrativoCEL3' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('trattamentostipintegrativoCEL3','analisiannuale','9','19','2','','S',{ts '2021-12-21 18:18:50.690'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'analisiannuale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-15 09:49:33.807'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','analisiannuale','4',null,null,'','S',{ts '2021-10-15 09:49:33.807'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

