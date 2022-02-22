
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


-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO

CREATE VIEW [progettosegview] AS 
SELECT  progetto.idprogetto,
 [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, progetto.title AS progetto_title, progetto.title_en AS progetto_title_en, progetto.titolobreve, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu,
 registryaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin,
 [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, progetto.progfinanziamentotxt AS progetto_progfinanziamentotxt,
 [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.bandoriferimentotxt AS progetto_bandoriferimentotxt,
 [dbo].strumentofin.title AS strumentofin_title, progetto.idstrumentofin,
 [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, progetto.finanziamento AS progetto_finanziamento, progetto.finanziatoretxt AS progetto_finanziatoretxt, progetto.description AS progetto_description, progetto.cup AS progetto_cup, progetto.codiceidentificativo AS progetto_codiceidentificativo,
 [dbo].title.description AS title_description, registryamm.idtitle AS registryamm_idtitle, registryamm.surname AS registryamm_surname, registryamm.forename AS registryamm_forename, registryamm.cf AS registryamm_cf, progetto.idreg_amm,
 [dbo].registry.title AS registry_title, progetto.idreg,
 registryaziende.title AS registryaziende_title, progetto.idreg_aziende, progetto.capofilatxt AS progetto_capofilatxt,
 [dbo].partnerkind.title AS partnerkind_title, progetto.idpartnerkind AS progetto_idpartnerkind, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.data AS progetto_data, progetto.dataesito AS progetto_dataesito, progetto.datacontabile AS progetto_datacontabile, progetto.durata AS progetto_durata,
 [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.totalbudget AS progetto_totalbudget, progetto.budget AS progetto_budget, progetto.contributoente AS progetto_contributoente, progetto.contributo AS progetto_contributo, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate,
 [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, progetto.url AS progetto_url, progetto.totalcontributo AS progetto_totalcontributo, progetto.contributoenterichiesto AS progetto_contributoenterichiesto, progetto.contributorichiesto AS progetto_contributorichiesto,
 isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title
FROM progetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg
LEFT OUTER JOIN [dbo].registry AS registryaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registryaziende_fin.idreg
LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin
LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando
LEFT OUTER JOIN [dbo].strumentofin WITH (NOLOCK) ON progetto.idstrumentofin = [dbo].strumentofin.idstrumentofin
LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind
LEFT OUTER JOIN [dbo].registry AS registryamm WITH (NOLOCK) ON progetto.idreg_amm = registryamm.idreg
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registryamm.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registryaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registryaziende.idreg
LEFT OUTER JOIN [dbo].partnerkind WITH (NOLOCK) ON progetto.idpartnerkind = [dbo].partnerkind.idpartnerkind
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio
WHERE  progetto.idprogetto IS NOT NULL 
GO

