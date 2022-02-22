
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


-- CREAZIONE VISTA registrationuserauthview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserauthview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrationuserauthview]
GO

CREATE VIEW [dbo].[registrationuserauthview] AS SELECT  registrationuser.cf AS registrationuser_cf, registrationuser.email AS registrationuser_email, registrationuser.esercizio AS registrationuser_esercizio, registrationuser.forename AS registrationuser_forename, registrationuser.idregistrationuser, [dbo].registrationuserstatus.title AS registrationuserstatus_title, registrationuser.idregistrationuserstatus AS registrationuser_idregistrationuserstatus, registrationuser.login AS registrationuser_login, registrationuser.matricola AS registrationuser_matricola, registrationuser.surname, registrationuser.userkind AS registrationuser_userkind, [dbo].usertype.usertype AS usertype_usertype, registrationuser.usertype AS registrationuser_usertype, isnull('Cognome: ' + registrationuser.surname + '; ','') + ' ' + isnull('Nome: ' + registrationuser.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registrationuser.cf + '; ','') as dropdown_title FROM [dbo].registrationuser WITH (NOLOCK)  LEFT OUTER JOIN [dbo].registrationuserstatus WITH (NOLOCK) ON registrationuser.idregistrationuserstatus = [dbo].registrationuserstatus.idregistrationuserstatus LEFT OUTER JOIN [dbo].usertype WITH (NOLOCK) ON registrationuser.usertype = [dbo].usertype.usertype WHERE  registrationuser.idregistrationuser IS NOT NULL 
GO

