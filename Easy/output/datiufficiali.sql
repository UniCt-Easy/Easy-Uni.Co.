
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


update service set active='N'
GO
update tax set active='N'
GO
-- Tabella SERVICE
CREATE TABLE #service(  idser varchar(20), active char(1), allowedit char(1), certificatekind char(1), description varchar(50), flagalwaysinfiscalmodels char(1), flagapplyabatements char(1), flagonlyfiscalabatement char(1), idmotive int, itinerationvisible char(1), ivaamount varchar(50), module varchar(15), rec770kind varchar(50))

INSERT INTO #service(idser, active, allowedit, certificatekind, description, flagalwaysinfiscalmodels, flagapplyabatements, flagonlyfiscalabatement, idmotive, itinerationvisible, ivaamount, module, rec770kind) SELECT idser, active, allowedit, certificatekind, description, flagalwaysinfiscalmodels, flagapplyabatements, flagonlyfiscalabatement, idmotive, itinerationvisible, ivaamount, module, rec770kind  FROM service

DELETE FROM service


-- GENERAZIONE DATI PER service --
IF not exists(SELECT * FROM [service] WHERE idser = '1')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('1','S','N','S','05_ASSRICM',{ts '2006-01-01 00:00:00.000'},'Software and more','Assegnisti di ricerca mutuati','N','S','N','N','N','N',null,'N',null,{ts '2007-03-09 10:51:11.767'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '2')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('2','S','N','S','05_ASSRINM',{ts '2006-01-01 00:00:00.000'},'Software and more','Assegnisti di ricerca non mutuati','N','S','N','N','N','N',null,'N',null,{ts '2006-01-01 00:00:00.000'},'Software and more','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '3')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('3','S','N','I','05_TUTORM',{ts '2006-01-01 00:00:00.000'},'Software and more','Attività di tutorato - mutuati','N','S','N','N','N','N',null,'N',null,{ts '2008-02-19 10:00:48.967'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '4')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('4','S','N','I','05_TUTORNM',{ts '2006-01-01 00:00:00.000'},'Software and more','Attività di tutorato - non mutuati','N','S','N','N','N','N',null,'N',null,{ts '2008-02-19 10:00:54.140'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '5')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('5','N','S','U','07_BRS_ESE',{ts '2006-01-01 00:00:00.000'},'Software and more','Borse di studio esenti','N','N','N','N','N','N',null,'N',null,{ts '2008-04-24 16:18:08.203'},'SA','OCCASIONALE','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '6')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('6','S','N','U','07_BRS_GEN',{ts '2006-01-01 00:00:00.000'},'Software and more','Borse di studio non esenti','N','S','N','N','S','N',null,'N',null,{ts '2006-01-01 00:00:00.000'},'Software and more','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '7')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('7','N','N','C','07_BRS_CVZ',{ts '2006-02-09 09:06:25.790'},'Software and more','Borse stud.stranieri in convenzione','N','N','N','S','S','N',null,'N',null,{ts '2008-04-24 16:14:58.487'},'SA','OCCASIONALE','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '8')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('8','N','N','T','07_BRS_STN',{ts '2006-02-09 09:02:57.383'},'Software and more','Borse studio stranieri non convenz.','N','N','N','S','S','N',null,'N',null,{ts '2008-02-18 15:41:44.077'},'SA','OCCASIONALE','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '9')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('9','S','N','U','07_COPENOINPS',{ts '2007-03-05 15:50:42.530'},'''SA''','Co.co.co pensionati no inps - art. 4 D.M. 282/96 ','N','S','N','N','S','N',null,'N',null,{ts '2007-03-05 15:55:20.517'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '10')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('10','S','N','U','05_COORDM',{ts '2006-01-01 00:00:00.000'},'Software and more','Co.co.co. mutuati','N','S','N','N','S','N',null,'N',null,{ts '2006-11-08 12:36:03.420'},'''SA''','COCOCO','G',null,'N')
GO

IF not exists(SELECT * FROM [service] WHERE idser = '11')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('11','S','N','U','05_COORDN',{ts '2006-01-01 00:00:00.000'},'Software and more','Co.co.co. non mutuati','N','S','N','N','S','N',null,'N',null,{ts '2006-11-08 12:36:07.093'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '12')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('12','S','N','U','05_COORDP',{ts '2006-01-01 00:00:00.000'},'Software and more','Co.co.co. pensionati','N','S','N','N','S','N',null,'N',null,{ts '2006-11-08 12:36:10.640'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '13')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('13','N','N','U','05_COOSTRA',{ts '2006-02-09 09:15:09.180'},'Software and more','Co.co.co.stranieri non mut.non conv','N','N','N','S','S','N',null,'N',null,{ts '2006-11-08 09:29:57.517'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '14')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('14','S','N','C','05_COSTCON',{ts '2006-02-09 09:16:25.290'},'Software and more','CoCoCo stranieri non mut.in convenz con INPS','N','N','N','S','S','N',null,'N',null,{ts '2008-05-14 14:33:23.020'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '15')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('15','S','N','C','07_CMP_STNCVZ',{ts '2006-01-01 00:00:00.000'},'Software and more','Compensi a stranieri in convenzione','N','N','N','S','S','N',null,'N',null,{ts '2008-02-18 15:42:07.767'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '16')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('16','S','N','T','07_CMP_STN',{ts '2006-01-01 00:00:00.000'},'Software and more','Compensi a stranieri non in convenz','N','N','N','S','S','N',null,'N',null,{ts '2008-02-18 15:42:45.843'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '17')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('17','S','N','A','07_RCR_TERZI',{ts '2006-01-01 00:00:00.000'},'Software and more','Compensi da c/terzi conv.Ricerca','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 15:43:56.420'},'SA','DIPENDENTE','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '18')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('18','S','N','F','07_DAT_M',{ts '2006-01-01 00:00:00.000'},'Software and more','Diritti d''autore mutuati','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 15:45:51.813'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '19')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('19','S','N','F','07_DAT_N',{ts '2006-01-01 00:00:00.000'},'Software and more','Diritti d''autore non mutuati','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 15:45:59.467'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '20')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('20','S','N','F','07_DAT_P',{ts '2006-01-01 00:00:00.000'},'Software and more','Diritti d''autore pensionati','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 15:46:05.453'},'SA','OCCASIONALE','H',null,'N')
GO

IF not exists(SELECT * FROM [service] WHERE idser = '21')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('21','S','N','F','07_DAT_U35',{ts '2007-03-14 11:15:37.907'},'''SA''','Diritti d''autore percipiente < 35 anni','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 15:46:09.937'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '22')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('22','S','N','F','07_DAT_I',{ts '2006-01-01 00:00:00.000'},'Software and more','Diritti d''autore titolari part. IVA','N','N','N','N','S','N',null,'N','IVA',{ts '2008-02-18 15:46:15.390'},'SA','PROFESSIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '23')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('23','S','N','A','07_MSS_ASS',{ts '2006-01-01 00:00:00.000'},'Software and more','Missione a dipendenti di altre amm.','N','N','N','N','S','N',null,'S',null,{ts '2008-02-18 15:46:44.377'},'SA','MISSIONE','',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '24')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('24','S','N','A','07_MSS_RIC',{ts '2006-05-12 14:05:04.670'},'''SA''','Missione ai sensi DM 1.2.2005 n.18','N','N','N','N','S','N',null,'S',null,{ts '2008-02-18 15:46:58.140'},'SA',null,null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '25')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('25','S','N','A','07_MSS_DIP',{ts '2006-01-01 00:00:00.000'},'Software and more','Missione dipendenti','N','N','N','N','S','N',null,'S',null,{ts '2008-02-18 16:01:09.390'},'SA','MISSIONE','',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '26')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('26','S','S','A','07_MISSDIPINPGI',{ts '2007-05-14 14:25:07.167'},'''MLUISAS''','Missione dipendenti contributi INPGI','N','N','N','N','S','N',null,'S',null,{ts '2008-02-18 16:01:19.953'},'SA',null,'*',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '27')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('27','S','N','A','07_MSS_OUT',{ts '2006-10-31 09:18:22.750'},'''SA''','Missioni a estranei','N','N','N','N','N','N',null,'S',null,{ts '2008-02-18 16:01:27.563'},'SA',null,null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '28')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('28','S','N','F','07_OCC_P',{ts '2006-01-01 00:00:00.000'},'Software and more','Occasionale - pensione diretta','N','N','N','N','S','S',null,'N',null,{ts '2008-02-18 15:47:19.483'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '29')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('29','S','N','F','07_OCC_M',{ts '2006-01-01 00:00:00.000'},'Software and more','Occasionale mutuati','N','N','N','N','S','S',null,'N',null,{ts '2008-02-18 15:47:25.687'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '30')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('30','S','N','F','07_OCC_N',{ts '2006-01-01 00:00:00.000'},'Software and more','Occasionale non mutuati','N','N','N','N','S','S',null,'N',null,{ts '2008-02-18 15:47:35.483'},'SA','OCCASIONALE','H',null,'N')
GO

IF not exists(SELECT * FROM [service] WHERE idser = '31')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('31','S','N','U','05_CORNOINPS',{ts '2006-11-07 15:23:15.593'},'''SA''','Prest. Co.Co. residenti-esenti INPS x convenzione','N','S','N','N','S','N',null,'N',null,{ts '2006-11-07 15:29:33.437'},'''SA''','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '32')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('32','S','S',null,'07_GENERICA',{ts '2006-01-01 00:00:00.000'},'Software and more','Prestazione generica','N','N','N','N','N','N',null,'N',null,{ts '2008-02-19 10:41:04.937'},'SA',null,null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '33')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('33','S','N','F','07_PRF',{ts '2006-01-01 00:00:00.000'},'Software and more','Prestazione professionale con IVA','N','N','N','N','S','N',null,'N','Iva',{ts '2008-02-18 15:48:14.110'},'SA','PROFESSIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '34')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('34','S','N','A','07_SUPPLENZE',{ts '2007-10-22 15:45:41.670'},'SA','Supplenze personale interno','N','N','N','N','S','N',null,'N',null,{ts '2008-02-19 10:04:15.517'},'SA','DIPENDENTE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '35')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('35','S','N','F','07_PROVVIGIONI',{ts '2007-12-20 15:42:33.250'},'SA','Compensi su provvigioni','N','N','N','N','S','N',null,'N',null,{ts '2008-02-18 16:00:34.983'},'SA','PROFESSIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '36')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('36','S','N','U','05_COORDN_L.326/03',{ts '2008-02-19 13:50:27.483'},'SA','Co.co.co. non mutuati art. 3 legge 326/2003','N','S','N','N','S','N',null,'N',null,{ts '2008-02-19 13:52:11.750'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '37')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('37','S','N','A','07_SUPPLENZE_EST',{ts '2008-02-29 16:10:56.797'},'SA','Supplenze personale esterno','N','N','N','N','S','N',null,'N',null,{ts '2008-02-29 16:11:23.467'},'SA','DIPENDENTE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '38')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('38','S','N','U','08_BRS_CST',{ts '2008-04-04 15:30:15.390'},'SA','Borse studio stranieri non convenz. (CoCoCo)','N','N','N','S','S','N',null,'N',null,{ts '2008-04-04 15:30:15.390'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '39')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('39','S','N','U','08_COOSTRA',{ts '2008-04-18 16:45:59.267'},'Software and more','Compensi a stranieri non mut.non conv','N','N','N','S','S','N',null,'N',null,{ts '2008-04-18 16:45:59.267'},'SARA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '40')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('40','S','S',null,'07_BRS_ESE_COC',{ts '2008-04-24 16:11:26.673'},'SA','Borse di studio esenti (cococo)','N','N','N','N','N','N',null,'N',null,{ts '2008-04-28 10:26:31.720'},'SA','COCOCO','G',null,'N')
GO

IF not exists(SELECT * FROM [service] WHERE idser = '41')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('41','S','N','C','07_BRS_CVZ_COC',{ts '2008-04-24 16:12:27.047'},'SA','Borse stud.stranieri in convenzione (parasubord.)','N','N','N','S','S','N',null,'N',null,{ts '2008-04-28 10:28:23.267'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '42')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('42','S','N','P','08_PREMI',{ts '2008-05-12 00:00:00.000'},'SA','Premi di studio e altri premi (art. 69 del TUIR)','N','N','N','N','N','N',null,'N',null,{ts '2008-05-12 11:24:04.437'},'SA','DIPENDENTE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '43')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('43','S','N','C','08_COSTCON_NOINPS',{ts '2008-05-14 14:29:55.757'},'SA','CoCoCo stranieri in convenz. per IRPEF - INPS','N','S','N','S','S','N',null,'N',null,{ts '2008-05-14 14:39:59.453'},'SA','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '44')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('44','S','N',null,'08_CONTRIB_C_ESERC',{ts '2008-06-13 00:00:00.000'},'SA','Contributi conto eserc. (DPR 600/73 art. 28, c 2)','N','N','N','N','N','N',null,'N',null,{ts '2008-06-13 00:00:00.000'},'SA','DIPENDENTE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '45')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('45','S','N','F','09_OCC_M_COMM',{ts '2009-04-17 10:42:01.343'},'SA','Occasionale mutuati - attività commerciale','N','N','N','N','S','S',null,'N',null,{ts '2009-04-17 10:42:01.343'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '46')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('46','S','N','F','09_OCC_N_COMM',{ts '2009-04-17 10:43:18.860'},'SA','Occasionale non mutuati - attività commerciale','N','N','N','N','S','S',null,'N',null,{ts '2009-04-17 10:43:18.860'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '47')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('47','S','N','F','07_PRF_ESE',{ts '2009-05-05 11:11:38.787'},'SARA','Prestaz. profess. senza applicazione Rit.d''acconto','N','N','N','N','S','N',null,'N','Iva',{ts '2009-05-05 11:11:38.787'},'SARA','PROFESSIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '48')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('48','S','N','F','08_OCCASGIORNAL',{ts '2008-12-15 15:20:05.063'},'SA','Prestazione occasionale giornalisti','N','N','N','N','N','N',null,'N',null,{ts '2008-12-15 15:20:05.063'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '49')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('49','S','N','F','10_OCC_ESENT',{ts '2010-01-27 13:20:43.983'},'SA','Occasionale con eseclusione INPS - DM 282/96','N','N','N','N','N','S',null,'N',null,{ts '2010-01-27 13:39:56.890'},'SA','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '50')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('50','S','N','T','10_PRF_STRA',{ts '2010-03-30 10:47:37.810'},'Software and more','Prestazione professionale stranieri','N','N','N','N','N','N',null,'N',null,{ts '2010-03-30 10:47:37.810'},'Software and more','PROFESSIONALE','H',null,'N')
GO

IF not exists(SELECT * FROM [service] WHERE idser = '51')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('51','S','N','C','10_COSTCONMUT',{ts '2010-09-16 12:01:35.657'},'sa','CoCoCo stranieri mutuati in convenz con INPS','N','N','N','S','S','N',null,'N',null,{ts '2010-09-16 12:01:35.657'},'sa','COCOCO','G',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '52')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('52','S',null,null,'CMP_COMM_STNCVZ',{ts '2011-02-16 14:11:44.640'},'sara','Stranieri in convenzione att. commerciale','N','N','N','N','N','N',null,'S',null,{ts '2011-02-16 14:11:44.640'},'Software and more','OCCASIONALE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '53')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('53','S',null,null,'CMP_COMM_STN',{ts '2011-02-16 14:11:44.707'},'Software and more','Stranieri non in convenzione attività commerciale','N','N','N','N','N','N',null,'S',null,{ts '2011-02-16 14:11:44.707'},'Software and more','OCCASIONALE',null,null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '54')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('54','S',null,'F','07_DAS_C',{ts '2011-04-07 09:57:43.827'},'sa','Diritti d''autore stranieri in convenzione','N','N','N','N','N','N',null,'S',null,{ts '2011-04-07 09:57:43.827'},'sa',null,'H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '55')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('55','S','N','G','11_PIGNORA',{ts '2011-04-18 13:32:21.127'},'sara','Pignoramento presso Terzi con ritenuta d''acconto','N','N','S','N','N','N',null,'N',null,{ts '2011-05-04 11:04:44.500'},'sara','DIPENDENTE','I',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '56')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('56','S','N','G','11_PIGNORA_ESE',{ts '2011-04-18 16:58:19.983'},'sara','Pignoramento presso Terzi senza ritenuta d''acconto','N','N','S','N','N','N',null,'N',null,{ts '2011-05-04 11:04:51.640'},'sara','DIPENDENTE','I',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '57')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('57','S','N','T','11_AUTORESTRANCONV',{ts '2011-07-18 14:29:27.703'},'sa','Diritti d''autore stranieri non in convenzione','N','N','N','N','N','N',null,'N',null,{ts '2011-07-18 14:29:27.703'},'sa','OCCASIONALE','H',null,'N')
IF not exists(SELECT * FROM [service] WHERE idser = '58')
INSERT INTO [service] (idser,active,allowedit,certificatekind,codeser,ct,cu,description,flagalwaysinfiscalmodels,flagapplyabatements,flagdistraint,flagforeign,flagneedbalance,flagonlyfiscalabatement,idmotive,itinerationvisible,ivaamount,lt,lu,module,rec770kind,voce8000,webdefault) VALUES ('58','S','N',null,'12_PREMINORIT',{ts '2012-03-22 12:09:58.453'},'sa','Premi per meriti artistici, scientifici o sociali','S','N','N','N','N','N',null,'N',null,{ts '2012-03-22 12:09:58.453'},'sa','DIPENDENTE',null,null,'N')
GO

-- FINE GENERAZIONE SCRIPT --

UPDATE #service SET description = 'ZZ' +  CASE WHEN DATALENGTH(description) < 48 THEN description  ELSE SUBSTRING(description,1,48) END  WHERE EXISTS(SELECT * FROM service s1 WHERE s1.description = #service.description) 

INSERT INTO service ( idser, active, allowedit, certificatekind, description, flagalwaysinfiscalmodels, flagapplyabatements, flagonlyfiscalabatement, idmotive, itinerationvisible, ivaamount, module, rec770kind, ct, cu, lt, lu)  SELECT idser, active, allowedit, certificatekind, description, flagalwaysinfiscalmodels, flagapplyabatements, flagonlyfiscalabatement, idmotive, itinerationvisible, ivaamount, module, rec770kind,  GETDATE(), 'IMPORT', GETDATE(), '''IMPORT'''  FROM #service WHERE NOT EXISTS(SELECT * FROM service s1 WHERE s1.idser = #service.idser)

DROP TABLE #service
GO
-- Tabella ITINERATIONREFUNDKIND
CREATE TABLE #itinerationrefundkind(  iditinerationrefundkind varchar(20), description varchar(150), idaccmotive varchar(36), iditinerationrefundkindgroup int)

INSERT INTO #itinerationrefundkind(iditinerationrefundkind, description, idaccmotive, iditinerationrefundkindgroup) SELECT iditinerationrefundkind, description, idaccmotive, iditinerationrefundkindgroup FROM itinerationrefundkind

DELETE FROM itinerationrefundkind


-- GENERAZIONE DATI PER itinerationrefundkind --
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '1')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('1','S','07_FLY',{ts '2006-01-01 00:00:00.000'},'Software and more','Aereo, spese per biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '2')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('2','S','07_HOTEL',{ts '2006-01-01 00:00:00.000'},'Software and more','Albergo, spese per pernottamento','S','S',null,null,'2',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '3')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('3','S','ANTMISS',{ts '2003-12-03 10:34:51.000'},'DERRICO','ANTICIPO MISSIONE','S','S',null,'00070019','4',{ts '2007-05-05 16:06:09.797'},'''NINO''')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '4')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('4','S','07_BUS',{ts '2006-01-01 00:00:00.000'},'Software and more','Autobus, spese per il biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '5')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('5','S','07_MOBRENT',{ts '2006-01-01 00:00:00.000'},'Software and more','Autonoleggio, spese per','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '6')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('6','S','07_FUEL',{ts '2006-01-01 00:00:00.000'},'Software and more','Carburanti, spese per','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '7')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('7','S','07_CONFERENCE',{ts '2006-01-01 00:00:00.000'},'Software and more','Congresso, spese per iscrizione','S','S',null,null,'4',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '8')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('8','S','07_BERTH',{ts '2006-01-01 00:00:00.000'},'Software and more','Cuccetta, spese per supplemento','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '9')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('9','S','07_BOAT',{ts '2006-01-01 00:00:00.000'},'Software and more','Nave, spese per il biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '10')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('10','S','07_MEAL',{ts '2006-01-01 00:00:00.000'},'Software and more','Pasti, spese per','S','S',null,null,'1',{ts '2006-01-01 00:00:00.000'},'Software and more')
GO

IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '11')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('11','S','07_FEE',{ts '2006-01-01 00:00:00.000'},'Software and more','Pedaggi, spese per','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '12')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('12','S','07_BED',{ts '2006-01-01 00:00:00.000'},'Software and more','Posto letto, spese per supplemento','S','S',null,null,'1',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '13')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('13','S','QUOTE',{ts '2006-01-01 00:00:00.000'},'Software and more','QUOTA ASSOCIATIVA','S','S',null,null,'4',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '14')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('14','S','POSTEGGIO',{ts '2004-01-19 10:08:40.000'},'DERRICO','Rimb.so Posteggio Auto','S','S',null,'00070020','3',{ts '2007-05-05 16:01:21.250'},'''NINO''')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '15')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('15','S','07_CAB',{ts '2006-01-01 00:00:00.000'},'sa','Rimborso Taxi','S','S',null,null,'3',{ts '2006-05-09 13:53:38.017'},'''sa''')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '16')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('16','S','SP. SUPPL.',{ts '2003-08-07 13:43:24.000'},'derrico','Spese varie rimborsabili','S','S',null,'00070020','4',{ts '2007-05-05 16:06:24.483'},'''NINO''')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '17')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('17','S','07_EXTRA',{ts '2006-01-01 00:00:00.000'},'Software and more','Supplemento, spese per il biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '18')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('18','S','TASSEAEREO',{ts '2003-08-07 15:07:56.000'},'ruberto','Tasse per biglietto aereo','S','S',null,'00070019','3',{ts '2007-05-05 16:02:24.467'},'''NINO''')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '19')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('19','S','07_TRAIN',{ts '2006-01-01 00:00:00.000'},'Software and more','Treno, spese per il biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '20')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('20','S','07_WAGONLIT',{ts '2006-01-01 00:00:00.000'},'Software and more','Vagone letto, spese per biglietto','S','S',null,null,'3',{ts '2006-01-01 00:00:00.000'},'Software and more')
GO

IF not exists(SELECT * FROM [itinerationrefundkind] WHERE iditinerationrefundkind = '21')
INSERT INTO [itinerationrefundkind] (iditinerationrefundkind,active,codeitinerationrefundkind,ct,cu,description,flagadvance,flagbalance,flagmedia,idaccmotive,iditinerationrefundkindgroup,lt,lu) VALUES ('21','S','07_FORFETTARIO',{ts '2011-11-21 14:04:17.093'},'SW','Rimborso forfettario','S','S',null,null,'5',{ts '2011-11-21 14:04:17.093'},'sw')
GO

-- FINE GENERAZIONE SCRIPT --

UPDATE #itinerationrefundkind SET description = 'ZZ' +  CASE WHEN DATALENGTH(description) < 148 THEN description  ELSE SUBSTRING(description,1,148) END  WHERE EXISTS(SELECT * FROM itinerationrefundkind i1 WHERE i1.description = #itinerationrefundkind.description) 

INSERT INTO itinerationrefundkind ( iditinerationrefundkind, description, idaccmotive, iditinerationrefundkindgroup, ct, cu, lt, lu)  SELECT iditinerationrefundkind, description, idaccmotive, iditinerationrefundkindgroup, GETDATE(), 'IMPORT', GETDATE(), '''IMPORT'''  FROM #itinerationrefundkind WHERE NOT EXISTS (SELECT * FROM itinerationrefundkind i1 WHERE i1.iditinerationrefundkind = #itinerationrefundkind.iditinerationrefundkind)

DROP TABLE #itinerationrefundkind
GO
-- Tabella TAX
CREATE TABLE #tax(  taxcode varchar(20), active char(1), appliancebasis char(1), description varchar(50), fiscaltaxcode varchar(20),  flagunabatable char(1), geoappliance char(1), taxablecode varchar(20), taxkind char(1), idaccmotive_cost varchar(36),  idaccmotive_debit varchar(36), idaccmotive_pay varchar(36)) 

INSERT INTO #tax(taxcode, active, appliancebasis, description, fiscaltaxcode, flagunabatable, geoappliance, taxablecode, taxkind, idaccmotive_cost, idaccmotive_debit, idaccmotive_pay) SELECT taxcode, active, appliancebasis, description, fiscaltaxcode, flagunabatable, geoappliance, taxablecode, taxkind, idaccmotive_cost, idaccmotive_debit, idaccmotive_pay  FROM tax

DELETE FROM tax


-- GENERAZIONE DATI PER tax --
IF not exists(SELECT * FROM [tax] WHERE taxcode = '1')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('1','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Addizionale comunale IRPEF','384E','N','C',null,null,null,{ts '2008-05-30 11:48:42.657'},'SA',null,'ADDIRPEF','1','05_ADDCOMU')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '2')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('2','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Addizionale regionale IRPEF','381E','N','R',null,null,null,{ts '2008-05-30 11:49:23.407'},'SA',null,'ADDIRPEF','1','05_ADDREGI')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '3')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('3','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Ritenuta Inail',null,'N',null,null,null,null,{ts '2006-01-17 09:33:39.920'},'Software and more',null,'ASSICUR','4','05_INAIL')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '4')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('4','S','A',{ts '2007-01-24 14:26:49.610'},'''NINO''','Acconto Addizionale Comunale IRPEF','385E','N','C',null,null,null,{ts '2008-05-30 11:50:27.467'},'SA',null,'ADDIRPEF','1','07_ACC_ADDCOM')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '5')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('5','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Rit. acconto 20% su 75% lordo','104E','S',null,null,null,null,{ts '2008-05-30 11:53:10.797'},'SA',null,'IRPEF','1','07_ACC_DAT')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '6')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('6','S',null,{ts '2007-03-13 15:18:41.890'},'''SA''','Rit. acconto 20% su 60% lordo','104E','S',null,null,null,null,{ts '2008-05-30 11:53:23.420'},'SA',null,'IRPEF','1','07_ACC_DAT_40')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '7')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('7','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Ritenuta d''Acconto','104E','N',null,null,null,null,{ts '2008-05-30 11:53:34.890'},'SA',null,'IRPEF','1','07_ACC_FISC')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '8')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('8','S',null,{ts '2006-07-17 16:04:53.850'},'SA','Addizionale Comunale da CAF','384E','N','C',null,null,null,{ts '2008-05-30 12:14:19.670'},'SA',null,'ADDIRPEF','5','07_ADDCOMCAF')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '9')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('9','S',null,{ts '2006-07-17 16:05:09.787'},'SA','Addizionale Regionale da CAF','381E','N','R',null,null,null,{ts '2008-05-30 12:15:14.733'},'SA',null,'ADDIRPEF','5','07_ADDREGCAF')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '10')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('10','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Fondo Credito','P909','N',null,null,null,null,{ts '2006-03-06 12:00:41.377'},'Software and more',null,'PREVIDENZA','3','07_FDOCRE')
GO

IF not exists(SELECT * FROM [tax] WHERE taxcode = '11')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('11','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Contributo Previdenziale Ammin.','P101','N',null,null,null,null,{ts '2006-03-06 12:00:51.627'},'Software and more',null,'PREVIDENZA','3','07_INPDAP_CAMM')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '12')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('12','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Contributo Previdenziale Dipendenti','P101','N',null,null,null,null,{ts '2006-03-06 12:01:50.343'},'Software and more',null,'PREVIDENZA','3','07_INPDAP_CDIP')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '13')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('13','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','INPS soggetti mutuati','C10','N',null,null,null,null,{ts '2006-01-17 09:34:13.500'},'Software and more',null,'PREVIDENZA','3','07_INPS_M')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '14')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('14','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','INPS soggetti non mutuati','CXX','N',null,null,null,null,{ts '2006-01-17 13:38:04.890'},'Software and more',null,'PREVIDENZA','3','07_INPS_N')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '15')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('15','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','INPS titolari pensione diretta','C10','N',null,null,null,null,{ts '2006-01-01 00:00:00.000'},'Software and more',null,'PREVIDENZA','3','07_INPS_P')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '16')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('16','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','IRAP dipendenti','380E','N',null,null,null,null,{ts '2008-05-30 11:55:04.063'},'SA',null,'ASSISTENZA','2','07_IRAP')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '17')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('17','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','IRAP autonomi/assimilati','380E','N',null,null,null,null,{ts '2008-05-30 11:55:10.750'},'SA',null,'ASSISTENZA','2','07_IRAP_CO')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '18')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('18','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Ritenuta IRPEF assimilati','100E','N',null,null,null,null,{ts '2008-05-30 11:55:47.280'},'SA',null,'IRPEF','1','07_IRPEF_ASS')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '19')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('19','S','S',{ts '2006-01-01 00:00:00.000'},'Software and more','IRPEF da dichiarazione C.A.F.','100E','N',null,null,null,null,{ts '2008-05-30 12:16:19.890'},'SA',null,'ADDIRPEF','5','07_IRPEF_CAF')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '20')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('20','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Rit.IRPEF stranieri con Convenzione',null,'S',null,null,null,null,{ts '2008-05-30 12:11:03.877'},'SA',null,'IRPEF','1','07_IRPEF_FC')
GO

IF not exists(SELECT * FROM [tax] WHERE taxcode = '21')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('21','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Ritenuta IRPEF stranieri','104E','N',null,null,null,null,{ts '2008-05-30 12:05:25.953'},'SA',null,'IRPEF','1','07_IRPEF_FO')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '22')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('22','S',null,{ts '2006-01-01 00:00:00.000'},'Software and more','Ritenuta IRPEF dipendenti','100E','N',null,null,null,null,{ts '2008-05-30 11:56:59.687'},'SA',null,'IRPEF','1','07_IRPEF_GEN')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '23')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('23','S','S',{ts '2006-01-01 00:00:00.000'},'Software and more','IRPEF Prima Rata di Acconto','100E','N',null,null,null,null,{ts '2008-05-30 12:16:37.657'},'SA',null,'ADDIRPEF','5','07_IRPEF_R1')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '24')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('24','S','S',{ts '2006-01-01 00:00:00.000'},'Software and more','IRPEF Seconda Rata di Acconto','100E','N',null,null,null,null,{ts '2008-05-30 12:16:46.610'},'SA',null,'ADDIRPEF','5','07_IRPEF_R2')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '25')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('25','S','S',{ts '2006-01-01 00:00:00.000'},'Software and more','Acconto su Tassazione Separata',null,'N',null,null,null,null,{ts '2008-05-30 12:17:50.127'},'SA',null,'ADDIRPEF','5','07_TASSASEP')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '26')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('26','S',null,{ts '2007-12-20 15:43:45.313'},'SA','Rit. acconto sul 50% del lordo','104E','S',null,null,null,null,{ts '2008-05-30 12:06:00.610'},'SA',null,'IRPEF','1','07_ACC_DAT_50')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '27')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('27','S',null,{ts '2008-02-19 13:42:00.360'},'SA','Ritenuta IRPEF legge n. 326 del 2003','100E','N',null,null,null,null,{ts '2008-05-30 12:11:20.377'},'SA',null,'IRPEF','1','07_IRPEF_L.326/03')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '28')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('28','S',null,{ts '2008-02-22 11:30:00.140'},'SA','INPS legge n. 326 del 2003',null,'N',null,null,null,null,{ts '2008-02-22 12:36:40.453'},'SA',null,'PREVIDENZA','3','07_INPS_L.326/03')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '29')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('29','S',null,{ts '2008-04-04 15:34:48.157'},'SA','Ritenuta IRPEF stranieri Co.Co.Co.','100E','N',null,null,null,null,{ts '2008-04-04 15:34:48.157'},'SA',null,'IRPEF','1','08_IRPEF_FOC')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '30')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('30','S',null,{ts '2008-05-12 10:35:49.577'},'SARA','Ritenuta su premi e vincite art.30 DPR 600/73','107E','S',null,null,null,null,{ts '2008-05-30 12:08:24.407'},'SA',null,'IRPEF','1','08_IMPOSTA_PREMI')
GO

IF not exists(SELECT * FROM [tax] WHERE taxcode = '31')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('31','S',null,{ts '2008-06-13 00:00:00.000'},'SARA','Ritenuta d''acconto 4%',null,'S',null,null,null,null,{ts '2008-06-13 00:00:00.000'},'SARA',null,'IRPEF','1','08_RITACC_4')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '32')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('32','S',null,{ts '2008-05-29 11:21:53.963'},'NINO','Addizionale Comunale Rateizzata',null,'N','C',null,null,null,{ts '2008-05-29 12:52:37.747'},'NINO',null,'ADDIRPEF','5','08_ADDCOMRATA')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '33')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('33','S',null,{ts '2008-05-29 11:22:29.120'},'NINO','Addizionale Regionale Rateizzata',null,'N','R',null,null,null,{ts '2008-05-29 12:52:40.980'},'NINO',null,'ADDIRPEF','5','08_ADDREGRATA')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '34')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('34','S',null,{ts '2008-07-17 10:41:54.627'},'NINO','Acconto Addizionale Comunale da CAF','385E','N','C',null,null,null,{ts '2008-07-17 10:50:01.437'},'NINO',null,'ADDIRPEF','5','08_ACCADDCOMCAF')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '35')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('35','S',null,{ts '2009-04-17 10:36:08.110'},'SA','IRAP autonomi/assimilati attività commerciale','380E','N',null,null,null,null,{ts '2009-04-17 10:36:08.110'},'SA',null,null,'2','09_IRAP_COMMERC')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '36')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('36','S',null,{ts '2009-05-05 11:14:22.647'},'SARA','Ritenuta d''Acconto per prestazioni Esenti',null,'N',null,null,null,null,{ts '2009-05-05 11:31:53.803'},'SARA',null,'IRPEF','1','07_ACC_FISC_ESE')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '38')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('38','S',null,{ts '2011-04-18 13:35:17.483'},'sara','Ritenuta alla fonte su somme pignorate','112E','S',null,null,null,null,{ts '2011-04-18 15:49:09.360'},'sara',null,'IRPEF','1','11_ACC_PIGNORA')
IF not exists(SELECT * FROM [tax] WHERE taxcode = '39')
INSERT INTO [tax] (taxcode,active,appliancebasis,ct,cu,description,fiscaltaxcode,flagunabatable,geoappliance,idaccmotive_cost,idaccmotive_debit,idaccmotive_pay,lt,lu,maintaxcode,taxablecode,taxkind,taxref) VALUES ('39','S',null,{ts '2012-04-02 14:59:19.610'},'sa','Esenzione su Premi',null,'N',null,null,null,null,{ts '2012-04-02 15:00:02.280'},'sa',null,'IRPEF','1','12_PREMI_ES')
GO

-- FINE GENERAZIONE SCRIPT --

UPDATE #tax SET description = 'ZZ' +  CASE WHEN DATALENGTH(description) < 48 THEN description  ELSE SUBSTRING(description,1,48) END  WHERE EXISTS(SELECT * FROM tax t1 WHERE t1.description = #tax.description) 

INSERT INTO tax ( taxcode, active, appliancebasis, description, fiscaltaxcode, flagunabatable, geoappliance,  idaccmotive_cost, idaccmotive_debit, idaccmotive_pay, taxablecode, taxkind,  ct, cu, lt, lu)  SELECT taxcode, active, appliancebasis, description, fiscaltaxcode, flagunabatable, geoappliance, idaccmotive_cost, idaccmotive_debit, idaccmotive_pay, taxablecode, taxkind,  GETDATE(), 'IMPORT', GETDATE(), '''IMPORT'''  FROM #tax WHERE NOT EXISTS (SELECT * FROM tax t1 WHERE t1.taxcode = #tax.taxcode)

DROP TABLE #tax
GO
