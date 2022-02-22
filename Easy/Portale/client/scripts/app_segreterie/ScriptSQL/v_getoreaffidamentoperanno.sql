
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


/****** Object:  View [Amministrazione].[getoreaffidamentoperanno]    Script Date: 25/09/2020 17:22:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[Amministrazione].[getoreaffidamentoperanno]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [Amministrazione].[getoreaffidamentoperanno]
GO

CREATE VIEW [Amministrazione].[getoreaffidamentoperanno]
AS
SELECT
	aco.aa, 
	a.idreg_docenti,
	SUM( CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'S' 
	THEN aco.ora * isnull(aco.ripetizioni,1)
	ELSE 0 END ) as oreperaacontratto,
	SUM( CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'N' 
	THEN aco.ora * isnull(aco.ripetizioni,1)
	ELSE 0 END ) as oreperaaaffidamento
FROM  dbo.affidamentocaratteristicaora aco
inner join affidamento a on a.idaffidamento = aco.idaffidamento
inner join affidamentokind ak on ak.idaffidamentokind = a.idaffidamentokind 
WHERE a.idreg_docenti is not null
GROUP BY
	aco.aa, 
	a.idreg_docenti
GO
