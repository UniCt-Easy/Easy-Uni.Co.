
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA getregistrydocentiamministrativi
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getregistrydocentiamministrativi]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getregistrydocentiamministrativi]
GO


CREATE VIEW [dbo].[getregistrydocentiamministrativi]
AS
SELECT
	dbo.registry.idreg, dbo.registry.extmatricula, dbo.registry.forename, dbo.registry.surname, dbo.registry.cf, 
	i.title as istituto, dbo.sasd.codice as ssd, 
	(select top 1 title from struttura where idstruttura = (select top 1 idstruttura from afferenza a where a.idreg = d.idreg ORDER BY a.start desc) ) as struttura, 
	(select top 1 title from contrattokind ck where ck.idcontrattokind = (select top 1 idcontrattokind from contratto c where c.idreg = d.idreg ORDER BY c.start desc)) as contratto
FROM dbo.registry 
	INNER JOIN dbo.registry_docenti d ON dbo.registry.idreg = d.idreg 
	LEFT OUTER JOIN sasd on sasd.idsasd = d.idsasd
	LEFT OUTER JOIN registry i on i.idreg = d.idreg_istituti	
UNION
SELECT
	dbo.registry.idreg, dbo.registry.extmatricula, dbo.registry.forename, dbo.registry.surname, dbo.registry.cf, 
	(select top 1 title from registry i where i.idreg = (select top 1 ip.idreg from istitutoprinc ip)) as istituto, null as ssd, 
	(select top 1 title from struttura where idstruttura = (select top 1 idstruttura from afferenza af where a.idreg = af.idreg ORDER BY af.start desc) ) as struttura, 
	(select top 1 title from contrattokind ck where ck.idcontrattokind = (select top 1 idcontrattokind from contratto c where c.idreg = a.idreg ORDER BY c.start desc)) as contratto
FROM dbo.registry 
	INNER JOIN dbo.registry_amministrativi a ON dbo.registry.idreg = a.idreg
WHERE dbo.registry.idreg not in (select idreg from registry_docenti)


GO
