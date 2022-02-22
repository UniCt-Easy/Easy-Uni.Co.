
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


/****** Object:  View [dbo].[lezioneview]    Script Date: 14/07/2020 12:38:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[lezioneview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[lezioneview]
GO

CREATE VIEW [dbo].[lezioneview]
AS
SELECT        dbo.affidamento.title, dbo.lezione.idlezione, dbo.lezione.idaffidamento, dbo.lezione.idcanale, dbo.lezione.idattivform, dbo.lezione.iddidprogporzanno, dbo.lezione.iddidproganno, dbo.lezione.iddidprogori, 
                         dbo.lezione.iddidprogcurr, dbo.lezione.iddidprog, dbo.lezione.stop, dbo.lezione.idaula, dbo.lezione.idsede, dbo.lezione.idedificio, dbo.lezione.ct, dbo.lezione.start, dbo.lezione.cu, dbo.lezione.lt, dbo.lezione.lu, 
                         dbo.lezione.idcorsostudio, dbo.lezione.aa, dbo.lezione.visita, dbo.lezione.nonsvolta, dbo.lezione.stage, dbo.lezione.idreg_docenti
FROM            dbo.affidamento INNER JOIN
                         dbo.lezione ON dbo.affidamento.idaffidamento = dbo.lezione.idaffidamento
GO


