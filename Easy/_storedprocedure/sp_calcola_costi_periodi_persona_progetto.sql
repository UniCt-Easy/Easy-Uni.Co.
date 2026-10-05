/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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


-- controllare la coerenza con la versione presente in D:\progetti\Portale\client\scripts\app_segreterie\ScriptLU-- CREAZIONE PROCEDURE [sp_calcola_costi_periodi_persona_progetto]

IF EXISTS (select * from sysobjects where id = object_id(N'[sp_calcola_costi_periodi_persona_progetto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [sp_calcola_costi_periodi_persona_progetto]
GO

CREATE procedure [sp_calcola_costi_periodi_persona_progetto]
(
	@idreg nvarchar(255),
	@idprogetto nvarchar(255),
	@idprogettokind nvarchar(255)
)
AS
BEGIN

IF NOT EXISTS(select * from sysobjects where id = object_id(N'[costoorariomembroattivitaprogettoperiodo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [costoorariomembroattivitaprogettoperiodo](
		[costoorarioeffettivo] [decimal](10, 2) NULL,
		[idprogetto] [int] NOT NULL,
		[titolobreve] [nvarchar](2048) NULL,
		[start] [date] NULL,
		[stop] [date] NULL,
		[datacontabile] [date] NULL,
		[idprogettoudrmembro] [int] NOT NULL,
		[idreg] [int] NULL,
		[costoorario] [decimal](10, 2) NULL,
		[startmembro] [date] NULL,
		[stopmembro] [date] NULL,
		[idprogettokind] [int] NULL,
		[oredivisionecostostipendio] [int] NOT NULL,
		[stipendioannoprec] [char](1) NOT NULL,
		[irap] [char](1) NOT NULL,
		[costostandard] [decimal](18, 2) NULL,
		[idregistrylegalstatus] [int] NOT NULL,
		[startcontratto] [date] NULL,
		[stopcontratto] [date] NULL,
		[idposition] [int] NULL,
		[livello] [int] NULL,
		[incomeclass] [smallint] NULL,
		[idinquadramento] [int] NULL,
		[totale_inquadramento] [decimal](9, 2) NULL,
		[totale_position] [decimal](9, 2) NULL,
		[oremincompitidida] [int] NOT NULL,
		[DataInizioSovrapposizioneProgettoContratto] [date] NULL,
		[DataFineSovrapposizioneProgettoContratto] [date] NULL,
		[CountContrattoMembro] [bigint] NULL,
		[idcostoorario] [int] NULL,
		[totale_costoorario] [decimal](18, 2) NULL,
		[irapcostoorario] [decimal](18, 2) NULL,
		[startcostoorario] [date] NULL,
		[stopcostoorario] [date] NULL,
		[DataInizioSovrapposizioneProgettoContrattoCostoorario] [date] NULL,
		[DataFineSovrapposizioneProgettoContrattoCostoOrario] [date] NULL,
		[idmese] [int] NOT NULL,
		[anno] [int] NULL,
		[totale_cedolino] [decimal](18, 2) NULL,
		[irap_cedolino] [decimal](18, 2) NULL,
		[totale_stipendioannuo] [decimal](19, 2) NULL,
		[irap_stipendioannuo] [decimal](19, 2) NULL,
		[totale_stipendiotabellare] [decimal](18, 2) NULL,
		[irap_stipendiotabellare] [decimal](18, 2) NULL,
		[startstipendio] [date] NULL,
		[stopstipendio] [date] NULL,
		[DataInizioSovrapposizioneProgettoContrattoCostoOrarioStipendio] [date] NULL,
		[DataFineSovrapposizioneProgettoContrattoCostoOrarioStipendio] [date] NULL
	) ON [PRIMARY]
END

DELETE costoorariomembroattivitaprogettoperiodo 
WHERE idprogetto <> (select ISNULL(idprogetto_otheractivities,99999999) from confprogetti)
	AND idprogetto <> (select ISNULL(idprogetto_otherresearchactivities,99999999) from confprogetti)
	AND (idreg = @idreg OR @idreg = '') -- membro del progetto / contratto - servizio di ruolo
	AND (idprogetto = @idprogetto OR @idprogetto = '') -- progetto
	AND (idprogettokind = @idprogettokind OR @idprogettokind = '') -- modello del progetto / costo standard

INSERT INTO costoorariomembroattivitaprogettoperiodo 
SELECT * FROM costoorariomembroattivitaprogettoperiodoview 
WHERE idprogetto <> (select ISNULL(idprogetto_otheractivities,99999999) from confprogetti)
	AND idprogetto <> (select ISNULL(idprogetto_otherresearchactivities,99999999) from confprogetti)
	AND (idreg = @idreg OR @idreg = '') -- membro del progetto / contratto - servizio di ruolo
	AND (idprogetto = @idprogetto OR @idprogetto = '') -- progetto
	AND (idprogettokind = @idprogettokind OR @idprogettokind = '') -- modello del progetto / costo standard

END

GO

