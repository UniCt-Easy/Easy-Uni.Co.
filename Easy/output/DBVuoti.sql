
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


 
-- GENERAZIONE DATI PER role --
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('01','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Dipendenti dell''Ateneo','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('02','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Dipendenti di altra Amministrazione','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('03','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Dottorandi di Ricerca','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('04','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Assegnisti di Ricerca','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('05','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Borsisti','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('06','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Professori a contratto','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('07','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Collaboratori coordinati e continuativi','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('08','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Lavoratori autonomi occasionali','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('09','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Studenti','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('10','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Studenti Laurea Specialistica','05',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
GO

INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('11','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Collaboratori non residenti','06',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('12','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Studenti non residenti','06',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('13','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Professionisti con P.Iva','07',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('14','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Professori a contratto con P.Iva','07',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('15','S',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''','Studi Associati','08',{ts '2006-01-01 00:00:00.000'},'''DBO_PO''')
INSERT INTO [role] (idrole,active,ct,cu,description,idregistryclass,lt,lu) VALUES ('16','S',{ts '2006-02-27 16:42:00.953'},'''SARA''','Per Mandati Collettivi','10',{ts '2006-02-27 16:42:00.953'},'''SARA''')
GO


-- GENERAZIONE DATI PER stamphandling --
INSERT INTO [stamphandling] (idstamphandling,active,ct,cu,description,flagdefault,handlingbankcode,lt,lu) VALUES ('003','S',{ts '2002-11-27 11:13:44.147'},'''DBO_PO''','Carico Beneficiario','N',null,{ts '2002-11-27 11:13:44.147'},'''DBO_PO''')
INSERT INTO [stamphandling] (idstamphandling,active,ct,cu,description,flagdefault,handlingbankcode,lt,lu) VALUES ('025','S',{ts '2002-11-27 11:13:44.147'},'''DBO_PO''','Esente','S','',{ts '2006-09-11 11:49:37.903'},'''NINO''')
INSERT INTO [stamphandling] (idstamphandling,active,ct,cu,description,flagdefault,handlingbankcode,lt,lu) VALUES ('027','S',{ts '2002-11-27 11:13:44.163'},'''DBO_PO''','Carico Ente','N',null,{ts '2002-11-27 11:13:44.163'},'''DBO_PO''')
GO

-- FINE GENERAZIONE SCRIPT --

