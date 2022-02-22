
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


/****** Object:  Table [dbo].[didprognumchiusokind]    Script Date: 24/07/2020 12:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[didprognumchiusokind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[didprognumchiusokind](
	[iddidprognumchiusokind] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[sortcode] [int] NOT NULL,
	[active] [char](1) NOT NULL,
	[lt] [datetime] NOT NULL,
	[lu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_didprognumchiusokind] PRIMARY KEY CLUSTERED 
(
	[iddidprognumchiusokind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[didprogporzannokind]    Script Date: 24/07/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[didprogporzannokind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[didprogporzannokind](
	[iddidprogporzannokind] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[ct] [datetime] NOT NULL,
	[cu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_didprogporzannokind] PRIMARY KEY CLUSTERED 
(
	[iddidprogporzannokind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[didprogsuddannokind]    Script Date: 24/07/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[didprogsuddannokind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[didprogsuddannokind](
	[iddidprogsuddannokind] [int] NOT NULL,
	[title] [varchar](50) NULL,
	[sortcode] [int] NULL,
	[active] [char](1) NULL,
	[lt] [datetime] NOT NULL,
	[lu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_didprogsuddannokind] PRIMARY KEY CLUSTERED 
(
	[iddidprogsuddannokind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[esoneroanskind]    Script Date: 24/07/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[esoneroanskind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[esoneroanskind](
	[idesoneroanskind] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](256) NOT NULL,
	[sortcode] [int] NOT NULL,
	[active] [char](1) NOT NULL,
	[ct] [datetime] NOT NULL,
	[cu] [varchar](64) NOT NULL,
	[lt] [datetime] NOT NULL,
	[lu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_esoneroanskind] PRIMARY KEY CLUSTERED 
(
	[idesoneroanskind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[statuskind]    Script Date: 24/07/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[statuskind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[statuskind](
	[idstatuskind] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[sortcode] [int] NOT NULL,
	[istanze] [char](1) NOT NULL,
	[istanzedelibera] [char](1) NOT NULL,
	[delibera] [char](1) NOT NULL,
	[pratica] [char](1) NOT NULL,
	[ct] [datetime] NOT NULL,
	[cu] [varchar](64) NOT NULL,
	[lt] [datetime] NOT NULL,
	[lu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_statuskind] PRIMARY KEY CLUSTERED 
(
	[idstatuskind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO



/****** Object:  Table [dbo].[titolokind]    Script Date: 24/07/2020 12:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[titolokind]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[titolokind](
	[idtitolokind] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[sortcode] [int] NOT NULL,
	[active] [char](1) NOT NULL,
	[lt] [datetime] NOT NULL,
	[lu] [varchar](64) NOT NULL,
 CONSTRAINT [PK_titolokind] PRIMARY KEY CLUSTERED 
(
	[idtitolokind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO



-- GENERAZIONE DATI PER didprognumchiusokind --
IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '1')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'No' WHERE iddidprognumchiusokind = '1'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','No')
GO

IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '2')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Locale' WHERE iddidprognumchiusokind = '2'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Locale')
GO

IF exists(SELECT * FROM [didprognumchiusokind] WHERE iddidprognumchiusokind = '3')
UPDATE [didprognumchiusokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Nazionale' WHERE iddidprognumchiusokind = '3'
ELSE
INSERT INTO [didprognumchiusokind] (iddidprognumchiusokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Nazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER didprogporzannokind --
IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '1')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',title = 'Mensile' WHERE iddidprogporzannokind = '1'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Mensile')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '2')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Bimestrale' WHERE iddidprogporzannokind = '2'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('2',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Bimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '3')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Trimestrale' WHERE iddidprogporzannokind = '3'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('3',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Trimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '4')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Quadrimestrale' WHERE iddidprogporzannokind = '4'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('4',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Quadrimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '5')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Semestrale' WHERE iddidprogporzannokind = '5'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('5',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Semestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '6')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Annuale' WHERE iddidprogporzannokind = '6'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('6',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Annuale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER didprogsuddannokind --
IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '1')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'mensile' WHERE iddidprogsuddannokind = '1'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','mensile')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '2')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'bimestrale' WHERE iddidprogsuddannokind = '2'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','bimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '3')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'trimestrale' WHERE iddidprogsuddannokind = '3'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','trimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '4')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'quadrimestrale' WHERE iddidprogsuddannokind = '4'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','quadrimestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '5')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'semestrale' WHERE iddidprogsuddannokind = '5'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','semestrale')
GO

IF exists(SELECT * FROM [didprogsuddannokind] WHERE iddidprogsuddannokind = '6')
UPDATE [didprogsuddannokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'annuale' WHERE iddidprogsuddannokind = '6'
ELSE
INSERT INTO [didprogsuddannokind] (iddidprogsuddannokind,active,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','annuale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER esoneroanskind --
IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '1')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Merito per laurea',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Merito per laurea' WHERE idesoneroanskind = '1'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Merito per laurea',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Merito per laurea')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '2')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Disabilità',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Disabilità' WHERE idesoneroanskind = '2'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Disabilità',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Disabilità')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '3')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Borsa Adisu',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Borsa Adisu' WHERE idesoneroanskind = '3'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Borsa Adisu',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Borsa Adisu')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '4')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Borsa Governo',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Borsa Governo' WHERE idesoneroanskind = '4'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Borsa Governo',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Borsa Governo')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '5')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Borsa convenzione',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Borsa convenzione' WHERE idesoneroanskind = '5'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Borsa convenzione',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Borsa convenzione')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '6')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Esonero su richiesta',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'Esonero su richiesta' WHERE idesoneroanskind = '6'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Esonero su richiesta',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','Esonero su richiesta')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '7')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Esonero Per merito di abilità (Vincitore di Gare ecc.)',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'Merito per Abilità' WHERE idesoneroanskind = '7'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Esonero Per merito di abilità (Vincitore di Gare ecc.)',{ts '2018-06-11 11:35:00.653'},'ferdinando','7','Merito per Abilità')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '8')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Esonero per particolari situazioni sociali (Vittime terrorismo, Misure restrittive Libertà ecc.)',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '8',title = 'Condizione Sociale' WHERE idesoneroanskind = '8'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Esonero per particolari situazioni sociali (Vittime terrorismo, Misure restrittive Libertà ecc.)',{ts '2018-06-11 11:35:00.653'},'ferdinando','8','Condizione Sociale')
GO

IF exists(SELECT * FROM [esoneroanskind] WHERE idesoneroanskind = '9')
UPDATE [esoneroanskind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Altro',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '9',title = 'Altro' WHERE idesoneroanskind = '9'
ELSE
INSERT INTO [esoneroanskind] (idesoneroanskind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Altro',{ts '2018-06-11 11:35:00.653'},'ferdinando','9','Altro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER statuskind --
IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '1')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'S',istanze = 'S',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'N',sortcode = '1',title = 'in bozza' WHERE idstatuskind = '1'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('1',{ts '2018-06-11 11:35:00.653'},'ferdinando','S','S','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','1','in bozza')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '2')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'N',istanze = 'S',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'N',sortcode = '2',title = 'Inviata' WHERE idstatuskind = '2'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('2',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','S','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','2','Inviata')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '3')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'N',istanze = 'S',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'N',sortcode = '3',title = 'Rigettata' WHERE idstatuskind = '3'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('3',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','S','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','3','Rigettata')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '4')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'N',istanze = 'N',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'S',sortcode = '4',title = 'In lavorazione' WHERE idstatuskind = '4'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('4',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','N','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','S','4','In lavorazione')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '5')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'N',istanze = 'N',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'S',sortcode = '5',title = 'In attesa di delibera' WHERE idstatuskind = '5'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('5',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','N','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','S','5','In attesa di delibera')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '6')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'S',istanze = 'N',istanzedelibera = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'S',sortcode = '6',title = 'Deliberata' WHERE idstatuskind = '6'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('6',{ts '2018-06-11 11:35:00.653'},'ferdinando','S','N','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','S','6','Deliberata')
GO

IF exists(SELECT * FROM [statuskind] WHERE idstatuskind = '7')
UPDATE [statuskind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',delibera = 'N',istanze = 'S',istanzedelibera = 'N',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',pratica = 'N',sortcode = '7',title = 'Accolta' WHERE idstatuskind = '7'
ELSE
INSERT INTO [statuskind] (idstatuskind,ct,cu,delibera,istanze,istanzedelibera,lt,lu,pratica,sortcode,title) VALUES ('7',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','S','N',{ts '2018-06-11 11:35:00.653'},'ferdinando','N','7','Accolta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER titolokind --
IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '1')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Normale' WHERE idtitolokind = '1'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Normale')
GO

IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '2')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Congiunto' WHERE idtitolokind = '2'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Congiunto')
GO

IF exists(SELECT * FROM [titolokind] WHERE idtitolokind = '3')
UPDATE [titolokind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Doppio' WHERE idtitolokind = '3'
ELSE
INSERT INTO [titolokind] (idtitolokind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Doppio')
GO

-- FINE GENERAZIONE SCRIPT --

