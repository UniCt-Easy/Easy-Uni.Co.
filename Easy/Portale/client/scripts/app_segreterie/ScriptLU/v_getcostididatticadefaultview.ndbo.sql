
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


-- CREAZIONE VISTA getcostididatticadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[getcostididatticadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcostididatticadefaultview]
GO

CREATE VIEW [getcostididatticadefaultview] AS 
SELECT  getcostididattica.aa, getcostididattica.aaprogrammata, getcostididattica.affidamento AS getcostididattica_affidamento, getcostididattica.corsostudio AS getcostididattica_corsostudio, getcostididattica.costo AS getcostididattica_costo, getcostididattica.costoorariodacontratto AS getcostididattica_costoorariodacontratto, getcostididattica.curriculum AS getcostididattica_curriculum, getcostididattica.docente AS getcostididattica_docente, getcostididattica.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, getcostididattica.idaffidamentokind AS getcostididattica_idaffidamentokind,
 [dbo].contrattokind.title AS contrattokind_title, getcostididattica.idcontrattokind,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, getcostididattica.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].didprog.idsede AS didprog_idsede, getcostididattica.iddidprog,
 [dbo].didprogcurr.title AS didprogcurr_title, getcostididattica.iddidprogcurr,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, getcostididattica.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, getcostididattica.idinsegninteg,
 registrydocenti.title AS registrydocenti_title, getcostididattica.idreg_docenti,
 sede_getcostididattica.title AS sede_getcostididattica_title, getcostididattica.idsede, getcostididattica.insegnamento AS getcostididattica_insegnamento, getcostididattica.modulo AS getcostididattica_modulo, getcostididattica.ruolo AS getcostididattica_ruolo, getcostididattica.sede AS getcostididattica_sede
FROM getcostididattica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON getcostididattica.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON getcostididattica.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON getcostididattica.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON getcostididattica.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON [dbo].didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON getcostididattica.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON getcostididattica.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON getcostididattica.idinsegninteg = [dbo].insegninteg.idinsegninteg
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON getcostididattica.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrydocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registrydocenti.idreg
LEFT OUTER JOIN [dbo].sede AS sede_getcostididattica WITH (NOLOCK) ON getcostididattica.idsede = sede_getcostididattica.idsede
WHERE  getcostididattica.aa IS NOT NULL  AND getcostididattica.idaffidamento IS NOT NULL  AND getcostididattica.idcontrattokind IS NOT NULL  AND getcostididattica.idcorsostudio IS NOT NULL  AND getcostididattica.iddidprog IS NOT NULL  AND getcostididattica.iddidprogcurr IS NOT NULL  AND getcostididattica.idsede IS NOT NULL 
GO

