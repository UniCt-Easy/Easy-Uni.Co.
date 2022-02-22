
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


 
-- GENERAZIONE DATI PER sortingkind --
INSERT INTO [sortingkind] (idsorkind,active,ct,cu,description,flagcheckavailability,flagdate,flagforced,flagmultiple,forcedN1,forcedN2,forcedN3,forcedN4,forcedN5,forcedS1,forcedS2,forcedS3,forcedS4,forcedS5,forcedv1,forcedv2,forcedv3,forcedv4,forcedv5,labelfordate,labeln1,labeln2,labeln3,labeln4,labeln5,labels1,labels2,labels3,labels4,labels5,labelv1,labelv2,labelv3,labelv4,labelv5,lockedN1,lockedN2,lockedN3,lockedN4,lockedN5,lockedS1,lockedS2,lockedS3,lockedS4,lockedS5,lockedv1,lockedv2,lockedv3,lockedv4,lockedv5,lt,lu,nodatelabel,nphaseexpense,nphaseincome,sortinglevel,totalexpression) VALUES ('_CLBIL',null,{ts '2006-03-03 19:50:34.707'},'SA','ex class. bilancio','N',null,'N','N',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,{ts '2006-03-03 19:50:34.707'},'''SA''',null,null,null,null,null)
GO


-- GENERAZIONE DATI PER sortinglevel --
INSERT INTO [sortinglevel] (idsorkind,nlevel,codekind,codelen,ct,cu,description,flagrestart,flagusable,lt,lu) VALUES ('_CLBIL','1','A','3',{ts '2006-03-03 19:50:34.707'},'SA','Livello 1 di classbilancio','S','S',{ts '2006-03-03 19:50:34.707'},'''SA''')
GO


-- GENERAZIONE DATI PER sorting --
INSERT INTO [sorting] (idsor,idsorkind,ct,cu,defaultN1,defaultN2,defaultN3,defaultN4,defaultN5,defaultS1,defaultS2,defaultS3,defaultS4,defaultS5,defaultv1,defaultv2,defaultv3,defaultv4,defaultv5,description,flagnodate,lt,lu,movkind,nlevel,paridsor,printingorder,rtf,sortcode,txt) VALUES ('0001','_CLBIL',{ts '2006-12-18 15:40:44.983'},'Software And More',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'Assistenza',null,{ts '2006-12-18 15:40:44.983'},'''Software And More''',null,'1',null,null,null,'ASS',null)
INSERT INTO [sorting] (idsor,idsorkind,ct,cu,defaultN1,defaultN2,defaultN3,defaultN4,defaultN5,defaultS1,defaultS2,defaultS3,defaultS4,defaultS5,defaultv1,defaultv2,defaultv3,defaultv4,defaultv5,description,flagnodate,lt,lu,movkind,nlevel,paridsor,printingorder,rtf,sortcode,txt) VALUES ('0002','_CLBIL',{ts '2006-12-18 15:40:44.983'},'Software And More',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'Congiunta',null,{ts '2006-12-18 15:40:44.983'},'''Software And More''',null,'1',null,null,null,'CON',null)
INSERT INTO [sorting] (idsor,idsorkind,ct,cu,defaultN1,defaultN2,defaultN3,defaultN4,defaultN5,defaultS1,defaultS2,defaultS3,defaultS4,defaultS5,defaultv1,defaultv2,defaultv3,defaultv4,defaultv5,description,flagnodate,lt,lu,movkind,nlevel,paridsor,printingorder,rtf,sortcode,txt) VALUES ('0003','_CLBIL',{ts '2006-12-18 15:40:44.983'},'Software And More',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'Didattica',null,{ts '2006-12-18 15:40:44.983'},'''Software And More''',null,'1',null,null,null,'DID',null)
INSERT INTO [sorting] (idsor,idsorkind,ct,cu,defaultN1,defaultN2,defaultN3,defaultN4,defaultN5,defaultS1,defaultS2,defaultS3,defaultS4,defaultS5,defaultv1,defaultv2,defaultv3,defaultv4,defaultv5,description,flagnodate,lt,lu,movkind,nlevel,paridsor,printingorder,rtf,sortcode,txt) VALUES ('0004','_CLBIL',{ts '2006-12-18 15:40:44.983'},'Software And More',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'Ricerca',null,{ts '2006-12-18 15:40:44.983'},'''Software And More''',null,'1',null,null,null,'RIC',null)
GO


-- GENERAZIONE DATI PER sortingapplicability --
INSERT INTO [sortingapplicability] (idsorkind,tablename,ct,cu,lt,lu) VALUES ('_CLBIL','fin',{ts '2006-12-22 13:46:03.929'},'Install',{ts '2006-12-22 13:46:03.929'},'Install')
GO

-- FINE GENERAZIONE SCRIPT --

