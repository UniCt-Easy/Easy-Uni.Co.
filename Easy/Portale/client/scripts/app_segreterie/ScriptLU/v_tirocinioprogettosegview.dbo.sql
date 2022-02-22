
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


-- CREAZIONE VISTA tirocinioprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirocinioprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tirocinioprogettosegview]
GO

CREATE VIEW [dbo].[tirocinioprogettosegview] AS 
SELECT  tirocinioprogetto.competenze AS tirocinioprogetto_competenze, tirocinioprogetto.ct AS tirocinioprogetto_ct, tirocinioprogetto.cu AS tirocinioprogetto_cu, tirocinioprogetto.datafineeffettiva AS tirocinioprogetto_datafineeffettiva, tirocinioprogetto.datafineprevista AS tirocinioprogetto_datafineprevista, tirocinioprogetto.datainizioeffettiva AS tirocinioprogetto_datainizioeffettiva, tirocinioprogetto.datainizioprevista AS tirocinioprogetto_datainizioprevista, tirocinioprogetto.dataverbale AS tirocinioprogetto_dataverbale, tirocinioprogetto.description AS tirocinioprogetto_description, tirocinioprogetto.description_en AS tirocinioprogetto_description_en,
 [dbo].aoo.title AS aoo_title, tirocinioprogetto.idaoo,
 registry_registry_docentidocenti.title AS registrydocenti_title, tirocinioprogetto.idreg_docenti, tirocinioprogetto.idreg_referente, tirocinioprogetto.idreg_studenti,
 [dbo].sede.title AS sede_title, tirocinioprogetto.idsede,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, tirocinioprogetto.idstruttura, tirocinioprogetto.idtirociniocandidatura, tirocinioprogetto.idtirocinioprogetto, tirocinioprogetto.idtirocinioproposto,
 [dbo].tirociniostato.title AS tirociniostato_title, tirocinioprogetto.idtirociniostato AS tirocinioprogetto_idtirociniostato, tirocinioprogetto.lt AS tirocinioprogetto_lt, tirocinioprogetto.lu AS tirocinioprogetto_lu, tirocinioprogetto.ore AS tirocinioprogetto_ore, tirocinioprogetto.protanno AS tirocinioprogetto_protanno, tirocinioprogetto.protnumero AS tirocinioprogetto_protnumero, tirocinioprogetto.tempiaccesso AS tirocinioprogetto_tempiaccesso, tirocinioprogetto.title, tirocinioprogetto.title_en AS tirocinioprogetto_title_en,(select top 1 attivitasvolta 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_attivitasvolta,
						(select top 1 autovalutazione 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_autovalutazione,
						(select top 1 competenze 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_competenze,
						(select top 1 conclusioni 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_conclusioni,
						(select top 1 considerazioni 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_considerazioni,
						(select top 1 descrazienda 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_descrazienda,
						(select top 1 introduzione 
						from dbo.tirociniorelazione 
						where dbo.tirociniorelazione.idtirocinioprogetto = tirocinioprogetto.idtirocinioprogetto
						 order by tirociniorelazione.attivitasvolta asc ) as tirociniorelazione_introduzione,
 isnull('Titolo: ' + tirocinioprogetto.title + '; ','') + ' ' + isnull('Descrizione: ' + tirocinioprogetto.description + '; ','') + ' ' + isnull('Tipologia Tipo: ' + [dbo].strutturakind.title + '; ','') as dropdown_title
FROM [dbo].tirocinioprogetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON tirocinioprogetto.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON tirocinioprogetto.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_docentidocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registry_registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON tirocinioprogetto.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON tirocinioprogetto.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN [dbo].tirociniostato WITH (NOLOCK) ON tirocinioprogetto.idtirociniostato = [dbo].tirociniostato.idtirociniostato
WHERE  tirocinioprogetto.idreg_referente IS NOT NULL  AND tirocinioprogetto.idreg_studenti IS NOT NULL  AND tirocinioprogetto.idtirociniocandidatura IS NOT NULL  AND tirocinioprogetto.idtirocinioprogetto IS NOT NULL  AND tirocinioprogetto.idtirocinioproposto IS NOT NULL 
GO

