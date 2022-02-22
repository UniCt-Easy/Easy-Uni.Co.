
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



-- GENERAZIONE DATI PER registryclass --
IF not exists(SELECT * FROM [registryclass] WHERE idregistryclass = '21')
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('21','S',{ts '2005-12-23 14:43:09.453'},'Software and more','Societ�, enti commerciali, ditte individuali e studi associati','N','N','S','N','N','N','N','S','S','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-23 15:13:21.453'},'Software and more')
IF not exists(SELECT * FROM [registryclass] WHERE idregistryclass = '22')
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('22','S',{ts '2005-12-23 14:45:39.453'},'Software and more','Persona Fisica','S','N','S','S','S','N','N','S','N','S','N','S','S','S','N','S','N','S','N','S','N','S','N','S','S','N','N',{ts '2008-03-26 16:38:44.907'},'SA')
IF not exists(SELECT * FROM [registryclass] WHERE idregistryclass = '23')
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('23','S',{ts '2005-12-23 14:49:12.640'},'Software and more','Enti non commerciali ed istituzioni internazionali','N','N','S','N','N','N','N','S','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-28 14:32:58.627'},'Software and more')
IF not exists(SELECT * FROM [registryclass] WHERE idregistryclass = '24')
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('24','S',{ts '2005-12-23 14:51:33.610'},'Software and more','Anagrafiche complementari','N','N','S','N','N','N','N','N','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','N','N','S','N',{ts '2005-12-23 15:13:12.813'},'Software and more')
GO

-- FINE GENERAZIONE SCRIPT --

