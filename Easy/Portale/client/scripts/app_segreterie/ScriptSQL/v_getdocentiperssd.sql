
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




/****** Object:  View [Amministrazione].[getdocentiperssd]    Script Date: 25/09/2020 17:21:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[Amministrazione].[getdocentiperssd]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [Amministrazione].[getdocentiperssd]
GO

CREATE VIEW [Amministrazione].[getdocentiperssd]
AS
SELECT
	dbo.registry.idreg, 
	dbo.registry.surname AS cognome, 
	dbo.registry.forename AS nome, 
	dbo.registry_docenti.matricola AS matricola, 
	dbo.sasd.idsasd, 
	dbo.sasd.codice AS ssd, 
	dbo.struttura.title AS struttura,
	c.title as contratto,
	c.costoora  as costoorario,
	c.start  as iniziocontratto,
	isnull(c.stop,'20400101')  as terminecontratto,
	c.tempdef  as tempodefinito,
	c.parttime,
	oremaxdida,
	oremindida,
	o.aa,
	oreperaacontratto,
	oreperaaaffidamento
FROM dbo.registry 
INNER JOIN dbo.registry_docenti ON dbo.registry.idreg = dbo.registry_docenti.idreg 
INNER JOIN dbo.sasd ON dbo.registry_docenti.idsasd = dbo.sasd.idsasd
INNER JOIN dbo.struttura ON dbo.registry_docenti.idstruttura = dbo.struttura.idstruttura
inner join [Amministrazione].[GetOreAffidamentoPerAnno] o on o.idreg_docenti = dbo.registry.idreg
inner join [Amministrazione].[GetContratti] c on c.idreg = dbo.registry.idreg and c.start < SUBSTRING(o.aa,1,4) + '0831' AND isnull(c.stop,'20400101') > SUBSTRING(o.aa,6,4) + '0801' 
--order by Cognome, Nome, Matricola



GO


