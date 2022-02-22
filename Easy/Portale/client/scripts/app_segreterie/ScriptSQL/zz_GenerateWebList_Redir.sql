
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


--select * from web_listredir
-- GENERAZIONE DATI PER web_listredir --
IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accmotive')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'accmotivedefaultview' WHERE listtype = 'default' AND tablename = 'accmotive'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','accmotive',null,null,null,null,'default','accmotivedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accmotive')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'accmotivesegview' WHERE listtype = 'seg' AND tablename = 'accmotive'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','accmotive',null,null,null,null,'seg','accmotivesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'accordoscambiomisegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','accordoscambiomi',null,null,null,null,'seg','accordoscambiomisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accreditokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'accreditokinddefaultview' WHERE listtype = 'default' AND tablename = 'accreditokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','accreditokind',null,null,null,null,'default','accreditokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'address')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'addresssegview' WHERE listtype = 'seg' AND tablename = 'address'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','address',null,null,null,null,'seg','addresssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'affidamentodefaultview' WHERE listtype = 'default' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','affidamento',null,null,null,null,'default','affidamentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'affidamentodocview' WHERE listtype = 'doc' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','affidamento',null,null,null,null,'doc','affidamentodocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'affidamentosegview' WHERE listtype = 'seg' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','affidamento',null,null,null,null,'seg','affidamentosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamentokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'affidamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','affidamentokind',null,null,null,null,'default','affidamentokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ambitoareadisc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ambitoareadiscdefaultview' WHERE listtype = 'default' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ambitoareadisc',null,null,null,null,'default','ambitoareadiscdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aoo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'aoodefaultview' WHERE listtype = 'default' AND tablename = 'aoo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aoo',null,null,null,null,'default','aoodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'aoo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'princ',newtablename = 'aooprincview' WHERE listtype = 'princ' AND tablename = 'aoo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('princ','aoo',null,null,null,null,'princ','aooprincview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appellodefaultview' WHERE listtype = 'default' AND tablename = 'appello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appello',null,null,null,null,'default','appellodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'appello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'appelloerogataview' WHERE listtype = 'erogata' AND tablename = 'appello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','appello',null,null,null,null,'erogata','appelloerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appelloazionekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appelloazionekinddefaultview' WHERE listtype = 'default' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appelloazionekind',null,null,null,null,'default','appelloazionekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appellokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appellokinddefaultview' WHERE listtype = 'default' AND tablename = 'appellokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appellokind',null,null,null,null,'default','appellokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'areadidattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'areadidatticadefaultview' WHERE listtype = 'default' AND tablename = 'areadidattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','areadidattica',null,null,null,null,'default','areadidatticadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'asset')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'assetsegview' WHERE listtype = 'seg' AND tablename = 'asset'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','asset',null,null,null,null,'seg','assetsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'assetacquire')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'assetacquiresegview' WHERE listtype = 'seg' AND tablename = 'assetacquire'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','assetacquire',null,null,null,null,'seg','assetacquiresegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'assetdiary')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'assetdiarydocview' WHERE listtype = 'doc' AND tablename = 'assetdiary'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','assetdiary',null,null,null,null,'doc','assetdiarydocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'assicurazione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'assicurazionedefaultview' WHERE listtype = 'default' AND tablename = 'assicurazione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','assicurazione',null,null,null,null,'default','assicurazionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ateco')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'atecodefaultview' WHERE listtype = 'default' AND tablename = 'ateco'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ateco',null,null,null,null,'default','atecodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'appello' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'appello',newtablename = 'attivformappelloview' WHERE listtype = 'appello' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('appello','attivform',null,null,null,null,'appello','attivformappelloview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'attivformdefaultview' WHERE listtype = 'default' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','attivform',null,null,null,null,'default','attivformdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'attivformerogataview' WHERE listtype = 'erogata' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','attivform',null,null,null,null,'erogata','attivformerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'gruppo' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'gruppo',newtablename = 'attivformgruppoview' WHERE listtype = 'gruppo' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('gruppo','attivform',null,null,null,null,'gruppo','attivformgruppoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'proped' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'proped',newtablename = 'attivformpropedview' WHERE listtype = 'proped' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('proped','attivform',null,null,null,null,'proped','attivformpropedview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aula')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'auladefaultview' WHERE listtype = 'default' AND tablename = 'aula'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aula',null,null,null,null,'default','auladefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'aula')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'aulaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'aula'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','aula',null,null,null,null,'seg_child','aulaseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aulakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'aulakinddefaultview' WHERE listtype = 'default' AND tablename = 'aulakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aulakind',null,null,null,null,'default','aulakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandods')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'bandodssegview' WHERE listtype = 'seg' AND tablename = 'bandods'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','bandods',null,null,null,null,'seg','bandodssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandomi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'bandomisegview' WHERE listtype = 'seg' AND tablename = 'bandomi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','bandomi',null,null,null,null,'seg','bandomisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'bandomobilitaintkinddefaultview' WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','bandomobilitaintkind',null,null,null,null,'default','bandomobilitaintkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'canale')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'canaleerogataview' WHERE listtype = 'erogata' AND tablename = 'canale'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','canale',null,null,null,null,'erogata','canaleerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ccnl')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ccnldefaultview' WHERE listtype = 'default' AND tablename = 'ccnl'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ccnl',null,null,null,null,'default','ccnldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefr')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'cefrdefaultview' WHERE listtype = 'default' AND tablename = 'cefr'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','cefr',null,null,null,null,'default','cefrdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefrlanglevel')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'cefrlangleveldefaultview' WHERE listtype = 'default' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','cefrlanglevel',null,null,null,null,'default','cefrlangleveldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'changeskind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'changeskinddefaultview' WHERE listtype = 'default' AND tablename = 'changeskind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','changeskind',null,null,null,null,'default','changeskinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classconsorsuale')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classconsorsualedefaultview' WHERE listtype = 'default' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classconsorsuale',null,null,null,null,'default','classconsorsualedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuola')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classescuoladefaultview' WHERE listtype = 'default' AND tablename = 'classescuola'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classescuola',null,null,null,null,'default','classescuoladefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuolakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classescuolakinddefaultview' WHERE listtype = 'default' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classescuolakind',null,null,null,null,'default','classescuolakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contrattokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'contrattokinddefaultview' WHERE listtype = 'default' AND tablename = 'contrattokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','contrattokind',null,null,null,null,'default','contrattokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'convenzione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'convenzionesegview' WHERE listtype = 'seg' AND tablename = 'convenzione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','convenzione',null,null,null,null,'seg','convenzionesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudio',null,null,null,null,'default','corsostudiodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'corsostudiodotmasview' WHERE listtype = 'dotmas' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','corsostudio',null,null,null,null,'dotmas','corsostudiodotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'corsostudioingressoview' WHERE listtype = 'ingresso' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','corsostudio',null,null,null,null,'ingresso','corsostudioingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'corsostudiostatoview' WHERE listtype = 'stato' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','corsostudio',null,null,null,null,'stato','corsostudiostatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiokinddefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudiokind',null,null,null,null,'default','corsostudiokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiolivello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiolivellodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudiolivello',null,null,null,null,'default','corsostudiolivellodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudionorma')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudionormadefaultview' WHERE listtype = 'default' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudionorma',null,null,null,null,'default','corsostudionormadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'costoscontodef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'costoscontodefmoreview' WHERE listtype = 'more' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','costoscontodef',null,null,null,null,'more','costoscontodefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'costoscontodef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'costoscontodefscontiview' WHERE listtype = 'sconti' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','costoscontodef',null,null,null,null,'sconti','costoscontodefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'costoscontodefkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'costoscontodefkinddefaultview' WHERE listtype = 'default' AND tablename = 'costoscontodefkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','costoscontodefkind',null,null,null,null,'default','costoscontodefkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'decadenza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'decadenzasegview' WHERE listtype = 'seg' AND tablename = 'decadenza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','decadenza',null,null,null,null,'seg','decadenzasegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'delibera')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'deliberasegview' WHERE listtype = 'seg' AND tablename = 'delibera'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','delibera',null,null,null,null,'seg','deliberasegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'altre_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'altre_seg',newtablename = 'dichiaraltre_segview' WHERE listtype = 'altre_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('altre_seg','dichiar',null,null,null,null,'altre_seg','dichiaraltre_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'altrititoli_seg',newtablename = 'dichiaraltrititoli_segview' WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('altrititoli_seg','dichiar',null,null,null,null,'altrititoli_seg','dichiaraltrititoli_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil_seg',newtablename = 'dichiardisabil_segview' WHERE listtype = 'disabil_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil_seg','dichiar',null,null,null,null,'disabil_seg','dichiardisabil_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil_seganagstu' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil_seganagstu',newtablename = 'dichiardisabil_seganagstuview' WHERE listtype = 'disabil_seganagstu' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil_seganagstu','dichiar',null,null,null,null,'disabil_seganagstu','dichiardisabil_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'isee_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'isee_seg',newtablename = 'dichiarisee_segview' WHERE listtype = 'isee_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('isee_seg','dichiar',null,null,null,null,'isee_seg','dichiarisee_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'isee_seganagstu' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'isee_seganagstu',newtablename = 'dichiarisee_seganagstuview' WHERE listtype = 'isee_seganagstu' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('isee_seganagstu','dichiar',null,null,null,null,'isee_seganagstu','dichiarisee_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'dichiarsegview' WHERE listtype = 'seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','dichiar',null,null,null,null,'seg','dichiarsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'titolo_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'titolo_seg',newtablename = 'dichiartitolo_segview' WHERE listtype = 'titolo_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('titolo_seg','dichiar',null,null,null,null,'titolo_seg','dichiartitolo_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiaraltrekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiaraltrekinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiaraltrekind',null,null,null,null,'default','dichiaraltrekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiardisabilkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiardisabilkind',null,null,null,null,'default','dichiardisabilkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiardisabilsuppkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiardisabilsuppkind',null,null,null,null,'default','dichiardisabilsuppkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiarkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiarkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiarkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiarkind',null,null,null,null,'default','dichiarkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'diderog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'diderogdefaultview' WHERE listtype = 'default' AND tablename = 'diderog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','diderog',null,null,null,null,'default','diderogdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogdefaultview' WHERE listtype = 'default' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprog',null,null,null,null,'default','didprogdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'didprogdotmasview' WHERE listtype = 'dotmas' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','didprog',null,null,null,null,'dotmas','didprogdotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'didprogingressoview' WHERE listtype = 'ingresso' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','didprog',null,null,null,null,'ingresso','didprogingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'didprogstatoview' WHERE listtype = 'stato' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','didprog',null,null,null,null,'stato','didprogstatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didproganno')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogannodefaultview' WHERE listtype = 'default' AND tablename = 'didproganno'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didproganno',null,null,null,null,'default','didprogannodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogori')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogoridefaultview' WHERE listtype = 'default' AND tablename = 'didprogori'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprogori',null,null,null,null,'default','didprogoridefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sceltacorso' AND tablename = 'didprogori')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sceltacorso',newtablename = 'didprogorisceltacorsoview' WHERE listtype = 'sceltacorso' AND tablename = 'didprogori'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sceltacorso','didprogori',null,null,null,null,'sceltacorso','didprogorisceltacorsoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogporzanno')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogporzannodefaultview' WHERE listtype = 'default' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprogporzanno',null,null,null,null,'default','didprogporzannodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'duratakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'duratakinddefaultview' WHERE listtype = 'default' AND tablename = 'duratakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','duratakind',null,null,null,null,'default','duratakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'edificio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'edificiodefaultview' WHERE listtype = 'default' AND tablename = 'edificio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','edificio',null,null,null,null,'default','edificiodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'edificio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'edificioseg_childview' WHERE listtype = 'seg_child' AND tablename = 'edificio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','edificio',null,null,null,null,'seg_child','edificioseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'erogazkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'erogazkinddefaultview' WHERE listtype = 'default' AND tablename = 'erogazkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','erogazkind',null,null,null,null,'default','erogazkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'carriera' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'carriera',newtablename = 'esonerocarrieraview' WHERE listtype = 'carriera' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('carriera','esonero',null,null,null,null,'carriera','esonerocarrieraview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'esonerodefaultview' WHERE listtype = 'default' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','esonero',null,null,null,null,'default','esonerodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil',newtablename = 'esonerodisabilview' WHERE listtype = 'disabil' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil','esonero',null,null,null,null,'disabil','esonerodisabilview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'titolostudio' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'titolostudio',newtablename = 'esonerotitolostudioview' WHERE listtype = 'titolostudio' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('titolostudio','esonero',null,null,null,null,'titolostudio','esonerotitolostudioview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'expense')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'expensesegview' WHERE listtype = 'seg' AND tablename = 'expense'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','expense',null,null,null,null,'seg','expensesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'fasciaiseedefdefaultview' WHERE listtype = 'default' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','fasciaiseedef',null,null,null,null,'default','fasciaiseedefdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'fasciaiseedefmoreview' WHERE listtype = 'more' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','fasciaiseedef',null,null,null,null,'more','fasciaiseedefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'fasciaiseedefscontiview' WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','fasciaiseedef',null,null,null,null,'sconti','fasciaiseedefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'fonteindicebibliometricosegview' WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','fonteindicebibliometrico',null,null,null,null,'seg','fonteindicebibliometricosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'geo_citydefaultview' WHERE listtype = 'default' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','geo_city',null,null,null,null,'default','geo_citydefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_citysegview' WHERE listtype = 'seg' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_city',null,null,null,null,'seg','geo_citysegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg5' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg5',newtablename = 'geo_cityseg5view' WHERE listtype = 'seg5' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg5','geo_city',null,null,null,null,'seg5','geo_cityseg5view')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_citysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_city',null,null,null,null,'segchild','geo_citysegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_country')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_countrysegview' WHERE listtype = 'seg' AND tablename = 'geo_country'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_country',null,null,null,null,'seg','geo_countrysegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_country')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_countrysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_country'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_country',null,null,null,null,'segchild','geo_countrysegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'lingue' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'lingue',newtablename = 'geo_nationlingueview' WHERE listtype = 'lingue' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('lingue','geo_nation',null,null,null,null,'lingue','geo_nationlingueview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_nationsegview' WHERE listtype = 'seg' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_nation',null,null,null,null,'seg','geo_nationsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_nationsegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_nation',null,null,null,null,'segchild','geo_nationsegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_region')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_regionsegview' WHERE listtype = 'seg' AND tablename = 'geo_region'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_region',null,null,null,null,'seg','geo_regionsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcostididattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getcostididatticadefaultview' WHERE listtype = 'default' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getcostididattica',null,null,null,null,'default','getcostididatticadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'getcostididattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'getcostididatticaerogataview' WHERE listtype = 'erogata' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','getcostididattica',null,null,null,null,'erogata','getcostididatticaerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'getdocentiperssd')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'getdocentiperssdsegview' WHERE listtype = 'seg' AND tablename = 'getdocentiperssd'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','getdocentiperssd',null,null,null,null,'seg','getdocentiperssdsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getprogettocostoliquidatoview')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getprogettocostoliquidatoviewdefaultview' WHERE listtype = 'default' AND tablename = 'getprogettocostoliquidatoview'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getprogettocostoliquidatoview',null,null,null,null,'default','getprogettocostoliquidatoviewdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getprogettocostoview')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getprogettocostoviewdefaultview' WHERE listtype = 'default' AND tablename = 'getprogettocostoview'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getprogettocostoview',null,null,null,null,'default','getprogettocostoviewdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getregistrydocentiamministratividefaultview' WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getregistrydocentiamministrativi',null,null,null,null,'default','getregistrydocentiamministratividefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'graduatoriavar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'graduatoriavardefaultview' WHERE listtype = 'default' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','graduatoriavar',null,null,null,null,'default','graduatoriavardefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'inquadramento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'inquadramentodefaultview' WHERE listtype = 'default' AND tablename = 'inquadramento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','inquadramento',null,null,null,null,'default','inquadramentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegn')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'insegndefaultview' WHERE listtype = 'default' AND tablename = 'insegn'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','insegn',null,null,null,null,'default','insegndefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegninteg')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'insegnintegdefaultview' WHERE listtype = 'default' AND tablename = 'insegninteg'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','insegninteg',null,null,null,null,'default','insegnintegdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'inventorytree')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'inventorytreesegview' WHERE listtype = 'seg' AND tablename = 'inventorytree'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','inventorytree',null,null,null,null,'seg','inventorytreesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'iscrizionedefaultview' WHERE listtype = 'default' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','iscrizione',null,null,null,null,'default','iscrizionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'didprog',newtablename = 'iscrizionedidprogview' WHERE listtype = 'didprog' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('didprog','iscrizione',null,null,null,null,'didprog','iscrizionedidprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'iscrizionedotmasview' WHERE listtype = 'dotmas' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','iscrizione',null,null,null,null,'dotmas','iscrizionedotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'iscrizioneingressoview' WHERE listtype = 'ingresso' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','iscrizione',null,null,null,null,'ingresso','iscrizioneingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionesegview' WHERE listtype = 'seg' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizione',null,null,null,null,'seg','iscrizionesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstu',newtablename = 'iscrizioneseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstu','iscrizione',null,null,null,null,'seganagstu','iscrizioneseganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuacc',newtablename = 'iscrizioneseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuacc','iscrizione',null,null,null,null,'seganagstuacc','iscrizioneseganagstuaccview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstumast',newtablename = 'iscrizioneseganagstumastview' WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstumast','iscrizione',null,null,null,null,'seganagstumast','iscrizioneseganagstumastview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusing',newtablename = 'iscrizioneseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusing','iscrizione',null,null,null,null,'seganagstusing','iscrizioneseganagstusingview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstustato',newtablename = 'iscrizioneseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstustato','iscrizione',null,null,null,null,'seganagstustato','iscrizioneseganagstustatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'iscrizionestatoview' WHERE listtype = 'stato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','iscrizione',null,null,null,null,'stato','iscrizionestatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionebmisegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizionebmi',null,null,null,null,'seg','iscrizionebmisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmiattach')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionebmiattachsegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmiattach'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizionebmiattach',null,null,null,null,'seg','iscrizionebmiattachsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'cert_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'cert_seg',newtablename = 'istanzacert_segview' WHERE listtype = 'cert_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('cert_seg','istanza',null,null,null,null,'cert_seg','istanzacert_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'eq_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'eq_seg',newtablename = 'istanzaeq_segview' WHERE listtype = 'eq_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('eq_seg','istanza',null,null,null,null,'eq_seg','istanzaeq_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seg',newtablename = 'istanzaimm_segview' WHERE listtype = 'imm_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seg','istanza',null,null,null,null,'imm_seg','istanzaimm_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstu',newtablename = 'istanzaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstu','istanza',null,null,null,null,'imm_seganagstu','istanzaimm_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstupre',newtablename = 'istanzaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstupre','istanza',null,null,null,null,'imm_seganagstupre','istanzaimm_seganagstupreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagsturin',newtablename = 'istanzaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagsturin','istanza',null,null,null,null,'imm_seganagsturin','istanzaimm_seganagsturinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_segpre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_segpre',newtablename = 'istanzaimm_segpreview' WHERE listtype = 'imm_segpre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_segpre','istanza',null,null,null,null,'imm_segpre','istanzaimm_segpreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_segrin' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_segrin',newtablename = 'istanzaimm_segrinview' WHERE listtype = 'imm_segrin' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_segrin','istanza',null,null,null,null,'imm_segrin','istanzaimm_segrinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'pas_seganagstu',newtablename = 'istanzapas_seganagstuview' WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('pas_seganagstu','istanza',null,null,null,null,'pas_seganagstu','istanzapas_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rin_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'rin_seg',newtablename = 'istanzarin_segview' WHERE listtype = 'rin_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('rin_seg','istanza',null,null,null,null,'rin_seg','istanzarin_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusonpre',newtablename = 'istanzaseganagstusonpreview' WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusonpre','istanza',null,null,null,null,'seganagstusonpre','istanzaseganagstusonpreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sosp_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sosp_seg',newtablename = 'istanzasosp_segview' WHERE listtype = 'sosp_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sosp_seg','istanza',null,null,null,null,'sosp_seg','istanzasosp_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'tru_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'tru_seg',newtablename = 'istanzatru_segview' WHERE listtype = 'tru_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('tru_seg','istanza',null,null,null,null,'tru_seg','istanzatru_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'istanzaattach')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'istanzaattachsegview' WHERE listtype = 'seg' AND tablename = 'istanzaattach'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','istanzaattach',null,null,null,null,'seg','istanzaattachsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'istanzakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'istanzakinddefaultview' WHERE listtype = 'default' AND tablename = 'istanzakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','istanzakind',null,null,null,null,'default','istanzakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'itineration')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'itinerationsegview' WHERE listtype = 'seg' AND tablename = 'itineration'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','itineration',null,null,null,null,'seg','itinerationsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrstud')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'learningagrstudsegview' WHERE listtype = 'seg' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','learningagrstud',null,null,null,null,'seg','learningagrstudsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrtrainer')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'learningagrtrainersegview' WHERE listtype = 'seg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','learningagrtrainer',null,null,null,null,'seg','learningagrtrainersegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'nace')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'nacedefaultview' WHERE listtype = 'default' AND tablename = 'nace'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','nace',null,null,null,null,'default','nacedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'naturagiur')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'naturagiurdefaultview' WHERE listtype = 'default' AND tablename = 'naturagiur'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','naturagiur',null,null,null,null,'default','naturagiurdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstu',newtablename = 'nullaostaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstu','nullaosta',null,null,null,null,'imm_seganagstu','nullaostaimm_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstupre',newtablename = 'nullaostaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstupre','nullaosta',null,null,null,null,'imm_seganagstupre','nullaostaimm_seganagstupreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagsturin',newtablename = 'nullaostaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagsturin','nullaosta',null,null,null,null,'imm_seganagsturin','nullaostaimm_seganagsturinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ofakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ofakinddefaultview' WHERE listtype = 'default' AND tablename = 'ofakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ofakind',null,null,null,null,'default','ofakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'orakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'orakindsegview' WHERE listtype = 'seg' AND tablename = 'orakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','orakind',null,null,null,null,'seg','orakindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pagamentokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'pagamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'pagamentokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','pagamentokind',null,null,null,null,'default','pagamentokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pettycash')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'pettycashsegview' WHERE listtype = 'seg' AND tablename = 'pettycash'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','pettycash',null,null,null,null,'seg','pettycashsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pianostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'pianostudiosegstudview' WHERE listtype = 'segstud' AND tablename = 'pianostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','pianostudio',null,null,null,null,'segstud','pianostudiosegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pianostudiostatus')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'pianostudiostatusdefaultview' WHERE listtype = 'default' AND tablename = 'pianostudiostatus'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','pianostudiostatus',null,null,null,null,'default','pianostudiostatusdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pratica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'praticasegstudview' WHERE listtype = 'segstud' AND tablename = 'pratica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','pratica',null,null,null,null,'segstud','praticasegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettosegview' WHERE listtype = 'seg' AND tablename = 'progetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progetto',null,null,null,null,'seg','progettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoactivitykind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoactivitykinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoactivitykind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoactivitykind',null,null,null,null,'default','progettoactivitykinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoasset')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoassetdefaultview' WHERE listtype = 'default' AND tablename = 'progettoasset'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoasset',null,null,null,null,'default','progettoassetdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettokindsegview' WHERE listtype = 'seg' AND tablename = 'progettokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progettokind',null,null,null,null,'seg','progettokindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettotipocosto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettotipocostosegview' WHERE listtype = 'seg' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progettotipocosto',null,null,null,null,'seg','progettotipocostosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoudrmembrokinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoudrmembrokind',null,null,null,null,'default','progettoudrmembrokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollosegview' WHERE listtype = 'seg' AND tablename = 'protocollo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollo',null,null,null,null,'seg','protocollosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollodockind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollodockindsegview' WHERE listtype = 'seg' AND tablename = 'protocollodockind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollodockind',null,null,null,null,'seg','protocollodockindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollorifkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollorifkindsegview' WHERE listtype = 'seg' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollorifkind',null,null,null,null,'seg','protocollorifkindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aula' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aula',newtablename = 'provaaulaview' WHERE listtype = 'aula' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aula','prova',null,null,null,null,'aula','provaaulaview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'provadefaultview' WHERE listtype = 'default' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','prova',null,null,null,null,'default','provadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'provadotmasview' WHERE listtype = 'dotmas' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','prova',null,null,null,null,'dotmas','provadotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'provaingressoview' WHERE listtype = 'ingresso' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','prova',null,null,null,null,'ingresso','provaingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'provastatoview' WHERE listtype = 'stato' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','prova',null,null,null,null,'stato','provastatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicaz')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'publicazdefaultview' WHERE listtype = 'default' AND tablename = 'publicaz'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','publicaz',null,null,null,null,'default','publicazdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'publicaz')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'publicazdocentiview' WHERE listtype = 'docenti' AND tablename = 'publicaz'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','publicaz',null,null,null,null,'docenti','publicazdocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicazkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'publicazkinddefaultview' WHERE listtype = 'default' AND tablename = 'publicazkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','publicazkind',null,null,null,null,'default','publicazkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionario')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariodefaultview' WHERE listtype = 'default' AND tablename = 'questionario'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionario',null,null,null,null,'default','questionariodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariodomkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariodomkinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariodomkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionariodomkind',null,null,null,null,'default','questionariodomkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariokinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionariokind',null,null,null,null,'default','questionariokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ratadefdefaultview' WHERE listtype = 'default' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ratadef',null,null,null,null,'default','ratadefdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'ratadefmoreview' WHERE listtype = 'more' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','ratadef',null,null,null,null,'more','ratadefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'ratadefscontiview' WHERE listtype = 'sconti' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','ratadef',null,null,null,null,'sconti','ratadefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ratakinddefaultview' WHERE listtype = 'default' AND tablename = 'ratakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ratakind',null,null,null,null,'default','ratakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amministrativi' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'amministrativi',newtablename = 'registryamministrativiview' WHERE listtype = 'amministrativi' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('amministrativi','registry',null,null,null,null,'amministrativi','registryamministrativiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amministrativi_personale' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'amministrativi_personale',newtablename = 'registryamministrativi_personaleview' WHERE listtype = 'amministrativi_personale' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('amministrativi_personale','registry',null,null,null,null,'amministrativi_personale','registryamministrativi_personaleview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aziende',newtablename = 'registryaziendeview' WHERE listtype = 'aziende' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aziende','registry',null,null,null,null,'aziende','registryaziendeview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'registrydocentiview' WHERE listtype = 'docenti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','registry',null,null,null,null,'docenti','registrydocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istituti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istituti',newtablename = 'registryistitutiview' WHERE listtype = 'istituti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istituti','registry',null,null,null,null,'istituti','registryistitutiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istituti_princ' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istituti_princ',newtablename = 'registryistituti_princview' WHERE listtype = 'istituti_princ' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istituti_princ','registry',null,null,null,null,'istituti_princ','registryistituti_princview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istitutiesteri' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istitutiesteri',newtablename = 'registryistitutiesteriview' WHERE listtype = 'istitutiesteri' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istitutiesteri','registry',null,null,null,null,'istitutiesteri','registryistitutiesteriview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'studenti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'studenti',newtablename = 'registrystudentiview' WHERE listtype = 'studenti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('studenti','registry',null,null,null,null,'studenti','registrystudentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'user',newtablename = 'registryuserview' WHERE listtype = 'user' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('user','registry',null,null,null,null,'user','registryuserview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryaddresssegview' WHERE listtype = 'seg' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryaddress',null,null,null,null,'seg','registryaddresssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segistituti' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segistituti',newtablename = 'registryaddresssegistitutiview' WHERE listtype = 'segistituti' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segistituti','registryaddress',null,null,null,null,'segistituti','registryaddresssegistitutiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'user',newtablename = 'registryaddressuserview' WHERE listtype = 'user' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('user','registryaddress',null,null,null,null,'user','registryaddressuserview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registryclass')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aziende',newtablename = 'registryclassaziendeview' WHERE listtype = 'aziende' AND tablename = 'registryclass'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aziende','registryclass',null,null,null,null,'aziende','registryclassaziendeview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'persone' AND tablename = 'registryclass')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'persone',newtablename = 'registryclasspersoneview' WHERE listtype = 'persone' AND tablename = 'registryclass'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('persone','registryclass',null,null,null,null,'persone','registryclasspersoneview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfin')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryprogfinsegview' WHERE listtype = 'seg' AND tablename = 'registryprogfin'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryprogfin',null,null,null,null,'seg','registryprogfinsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfinbando')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryprogfinbandosegview' WHERE listtype = 'seg' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryprogfinbando',null,null,null,null,'seg','registryprogfinbandosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'rendicontaltrokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'rendicontaltrokinddefaultview' WHERE listtype = 'default' AND tablename = 'rendicontaltrokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','rendicontaltrokind',null,null,null,null,'default','rendicontaltrokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'anag',newtablename = 'rendicontattivitaprogettoanagview' WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('anag','rendicontattivitaprogetto',null,null,null,null,'anag','rendicontattivitaprogettoanagview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'anagamm',newtablename = 'rendicontattivitaprogettoanagammview' WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('anagamm','rendicontattivitaprogetto',null,null,null,null,'anagamm','rendicontattivitaprogettoanagammview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'rendicontattivitaprogettodocview' WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','rendicontattivitaprogetto',null,null,null,null,'doc','rendicontattivitaprogettodocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'rendicontattivitaprogettosegview' WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','rendicontattivitaprogetto',null,null,null,null,'seg','rendicontattivitaprogettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sal')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'saldefaultview' WHERE listtype = 'default' AND tablename = 'sal'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sal',null,null,null,null,'default','saldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasd')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sasddefaultview' WHERE listtype = 'default' AND tablename = 'sasd'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sasd',null,null,null,null,'default','sasddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasdgruppo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sasdgruppodefaultview' WHERE listtype = 'default' AND tablename = 'sasdgruppo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sasdgruppo',null,null,null,null,'default','sasdgruppodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sededefaultview' WHERE listtype = 'default' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sede',null,null,null,null,'default','sededefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'sedeseg_childview' WHERE listtype = 'seg_child' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','sede',null,null,null,null,'seg_child','sedeseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child_azienda' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child_azienda',newtablename = 'sedeseg_child_aziendaview' WHERE listtype = 'seg_child_azienda' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child_azienda','sede',null,null,null,null,'seg_child_azienda','sedeseg_child_aziendaview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sessionedefaultview' WHERE listtype = 'default' AND tablename = 'sessione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sessione',null,null,null,null,'default','sessionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessionekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sessionekinddefaultview' WHERE listtype = 'default' AND tablename = 'sessionekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sessionekind',null,null,null,null,'default','sessionekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'settoreerc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'settoreercsegview' WHERE listtype = 'seg' AND tablename = 'settoreerc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','settoreerc',null,null,null,null,'seg','settoreercsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segprog' AND tablename = 'settoreerc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segprog',newtablename = 'settoreercsegprogview' WHERE listtype = 'segprog' AND tablename = 'settoreerc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segprog','settoreerc',null,null,null,null,'segprog','settoreercsegprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'treeusable' AND tablename = 'sorting')
UPDATE [web_listredir] SET ct = {ts '2018-07-31 10:32:50.150'},cu = 'sa',lt = {ts '2018-07-31 10:32:50.150'},lu = 'sa',newlisttype = 'tree',newtablename = 'sortingusable' WHERE listtype = 'treeusable' AND tablename = 'sorting'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('treeusable','sorting',{ts '2018-07-31 10:32:50.150'},'sa',{ts '2018-07-31 10:32:50.150'},'sa','tree','sortingusable')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sostenimentodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sostenimento',null,null,null,null,'default','sostenimentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'didprog',newtablename = 'sostenimentodidprogview' WHERE listtype = 'didprog' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('didprog','sostenimento',null,null,null,null,'didprog','sostenimentodidprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'sostenimentoingressoview' WHERE listtype = 'ingresso' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','sostenimento',null,null,null,null,'ingresso','sostenimentoingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstu',newtablename = 'sostenimentoseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstu','sostenimento',null,null,null,null,'seganagstu','sostenimentoseganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuacc',newtablename = 'sostenimentoseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuacc','sostenimento',null,null,null,null,'seganagstuacc','sostenimentoseganagstuaccview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuconsmast',newtablename = 'sostenimentoseganagstuconsmastview' WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuconsmast','sostenimento',null,null,null,null,'seganagstuconsmast','sostenimentoseganagstuconsmastview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusing',newtablename = 'sostenimentoseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusing','sostenimento',null,null,null,null,'seganagstusing','sostenimentoseganagstusingview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstustato',newtablename = 'sostenimentoseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstustato','sostenimento',null,null,null,null,'seganagstustato','sostenimentoseganagstustatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segcons' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segcons',newtablename = 'sostenimentosegconsview' WHERE listtype = 'segcons' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segcons','sostenimento',null,null,null,null,'segcons','sostenimentosegconsview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'sostenimentosegstudview' WHERE listtype = 'segstud' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','sostenimento',null,null,null,null,'segstud','sostenimentosegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimentoesito')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sostenimentoesitodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sostenimentoesito',null,null,null,null,'default','sostenimentoesitodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'stipendiokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'stipendiokinddefaultview' WHERE listtype = 'default' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','stipendiokind',null,null,null,null,'default','stipendiokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'strutturadefaultview' WHERE listtype = 'default' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','struttura',null,null,null,null,'default','strutturadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'princ',newtablename = 'strutturaprincview' WHERE listtype = 'princ' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('princ','struttura',null,null,null,null,'princ','strutturaprincview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'strutturaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','struttura',null,null,null,null,'seg_child','strutturaseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'strutturakinddefaultview' WHERE listtype = 'default' AND tablename = 'strutturakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','strutturakind',null,null,null,null,'default','strutturakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studdirittokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'studdirittokinddefaultview' WHERE listtype = 'default' AND tablename = 'studdirittokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','studdirittokind',null,null,null,null,'default','studdirittokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studprenotkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'studprenotkinddefaultview' WHERE listtype = 'default' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','studprenotkind',null,null,null,null,'default','studprenotkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaconf',null,null,null,null,'default','tassaconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconfkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaconfkinddefaultview' WHERE listtype = 'default' AND tablename = 'tassaconfkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaconfkind',null,null,null,null,'default','tassaconfkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassacsingconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassacsingconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassacsingconf',null,null,null,null,'default','tassacsingconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaiscrizioneconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaiscrizioneconf',null,null,null,null,'default','tassaiscrizioneconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaistanzaconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaistanzaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaistanzaconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaistanzaconf',null,null,null,null,'default','tassaistanzaconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tax')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'taxsegview' WHERE listtype = 'seg' AND tablename = 'tax'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tax',null,null,null,null,'seg','taxsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tipoattform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tipoattformdefaultview' WHERE listtype = 'default' AND tablename = 'tipoattform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tipoattform',null,null,null,null,'default','tipoattformdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tipologiastudente')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tipologiastudentesegview' WHERE listtype = 'seg' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tipologiastudente',null,null,null,null,'seg','tipologiastudentesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tirociniocandidaturakinddefaultview' WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tirociniocandidaturakind',null,null,null,null,'default','tirociniocandidaturakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tirocinioprogettosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tirocinioprogetto',null,null,null,null,'seg','tirocinioprogettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioproposto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tirociniopropostosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioproposto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tirocinioproposto',null,null,null,null,'seg','tirociniopropostosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniostato')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tirociniostatodefaultview' WHERE listtype = 'default' AND tablename = 'tirociniostato'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tirociniostato',null,null,null,null,'default','tirociniostatodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'titolostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'titolostudiodocentiview' WHERE listtype = 'docenti' AND tablename = 'titolostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','titolostudio',null,null,null,null,'docenti','titolostudiodocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segtitolo' AND tablename = 'titolostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segtitolo',newtablename = 'titolostudiosegtitoloview' WHERE listtype = 'segtitolo' AND tablename = 'titolostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segtitolo','titolostudio',null,null,null,null,'segtitolo','titolostudiosegtitoloview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'upb')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'upbsegview' WHERE listtype = 'seg' AND tablename = 'upb'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','upb',null,null,null,null,'seg','upbsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'workpackage')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'workpackagesegview' WHERE listtype = 'seg' AND tablename = 'workpackage'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','workpackage',null,null,null,null,'seg','workpackagesegview')
GO

 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'progettosegview' WHERE listtype = 'seg' AND tablename = 'progetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusonpre', newtablename = 'istanzaseganagstusonpreview' WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstupre', newtablename = 'nullaostaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'didprog', newtablename = 'sostenimentodidprogview' WHERE listtype = 'didprog' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryaddress')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryaddresssegview' WHERE listtype = 'seg' AND tablename = 'registryaddress'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg5' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg5', newtablename = 'geo_cityseg5view' WHERE listtype = 'seg5' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg5', 'geo_cityseg5view', 'seg5', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'amministrativi_personale' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amministrativi_personale', newtablename = 'registryamministrativi_personaleview' WHERE listtype = 'amministrativi_personale' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi_personale', 'registryamministrativi_personaleview', 'amministrativi_personale', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sal')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'saldefaultview' WHERE listtype = 'default' AND tablename = 'sal'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sal', 'default', 'saldefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'assetdiary')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'assetdiarydocview' WHERE listtype = 'doc' AND tablename = 'assetdiary'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'doc', 'assetdiarydocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'rendicontattivitaprogettodocview' WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'doc', 'rendicontattivitaprogettodocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'affidamentodocview' WHERE listtype = 'doc' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'doc', 'affidamentodocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'progettoudrmembrokinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoudrmembrokind', 'default', 'progettoudrmembrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'assetacquire')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'assetacquiresegview' WHERE listtype = 'seg' AND tablename = 'assetacquire'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accmotive')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'accmotivedefaultview' WHERE listtype = 'default' AND tablename = 'accmotive'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getregistrydocentiamministratividefaultview' WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcostididattica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getcostididatticadefaultview' WHERE listtype = 'default' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'getdocentiperssd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'getdocentiperssdsegview' WHERE listtype = 'seg' AND tablename = 'getdocentiperssd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'delibera')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'deliberasegview' WHERE listtype = 'seg' AND tablename = 'delibera'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'istanzaattach')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'istanzaattachsegview' WHERE listtype = 'seg' AND tablename = 'istanzaattach'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'cert_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'cert_seg', newtablename = 'istanzacert_segview' WHERE listtype = 'cert_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sosp_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sosp_seg', newtablename = 'istanzasosp_segview' WHERE listtype = 'sosp_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'tru_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'tru_seg', newtablename = 'istanzatru_segview' WHERE listtype = 'tru_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'eq_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'eq_seg', newtablename = 'istanzaeq_segview' WHERE listtype = 'eq_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'titolo_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'titolo_seg', newtablename = 'dichiartitolo_segview' WHERE listtype = 'titolo_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiaraltrekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiaraltrekinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segcons' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segcons', newtablename = 'sostenimentosegconsview' WHERE listtype = 'segcons' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiardisabilsuppkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiardisabilkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'disabil_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'disabil_seg', newtablename = 'dichiardisabil_segview' WHERE listtype = 'disabil_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'altre_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'altre_seg', newtablename = 'dichiaraltre_segview' WHERE listtype = 'altre_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'altrititoli_seg', newtablename = 'dichiaraltrititoli_segview' WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'isee_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'isee_seg', newtablename = 'dichiarisee_segview' WHERE listtype = 'isee_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandodsiscresitokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'bandodsiscresitokinddefaultview' WHERE listtype = 'default' AND tablename = 'bandodsiscresitokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandodsiscresitokind', 'default', 'bandodsiscresitokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accreditokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'accreditokinddefaultview' WHERE listtype = 'default' AND tablename = 'accreditokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandodsservizio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandodsserviziosegview' WHERE listtype = 'seg' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandodsservizio', 'seg', 'bandodsserviziosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandods')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandodssegview' WHERE listtype = 'seg' AND tablename = 'bandods'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrstud')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'learningagrstudsegview' WHERE listtype = 'seg' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'assicurazione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'assicurazionedefaultview' WHERE listtype = 'default' AND tablename = 'assicurazione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'bandomobilitaintkinddefaultview' WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefr')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'cefrdefaultview' WHERE listtype = 'default' AND tablename = 'cefr'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomidett')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomidettsegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomidett', 'seg', 'accordoscambiomidettsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'iscrizionebmisegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandomi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandomisegview' WHERE listtype = 'seg' AND tablename = 'bandomi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomidettaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomidettazsegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomidettaz', 'seg', 'accordoscambiomidettazsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomisegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'location')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'locationdefaultview' WHERE listtype = 'default' AND tablename = 'location'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('location', 'default', 'locationdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'inventorytree')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'inventorytreesegview' WHERE listtype = 'seg' AND tablename = 'inventorytree'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'naturagiur')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'naturagiurdefaultview' WHERE listtype = 'default' AND tablename = 'naturagiur'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'duratakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'duratakinddefaultview' WHERE listtype = 'default' AND tablename = 'duratakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'inquadramento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'inquadramentodefaultview' WHERE listtype = 'default' AND tablename = 'inquadramento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'stipendiokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'stipendiokinddefaultview' WHERE listtype = 'default' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'tirocinioprogettosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'provadotmasview' WHERE listtype = 'dotmas' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'provastatoview' WHERE listtype = 'stato' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioproposto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'tirociniopropostosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioproposto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'convenzione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'convenzionesegview' WHERE listtype = 'seg' AND tablename = 'convenzione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'changeskind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'changeskinddefaultview' WHERE listtype = 'default' AND tablename = 'changeskind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'praticasegstudview' WHERE listtype = 'segstud' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pettycash')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'pettycashsegview' WHERE listtype = 'seg' AND tablename = 'pettycash'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'expense')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'expensesegview' WHERE listtype = 'seg' AND tablename = 'expense'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'decadenza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'decadenzasegview' WHERE listtype = 'seg' AND tablename = 'decadenza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'itineration')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'itinerationsegview' WHERE listtype = 'seg' AND tablename = 'itineration'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tax')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'taxsegview' WHERE listtype = 'seg' AND tablename = 'tax'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segprog' AND tablename = 'settoreerc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segprog', newtablename = 'settoreercsegprogview' WHERE listtype = 'segprog' AND tablename = 'settoreerc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'settoreerc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'settoreercsegview' WHERE listtype = 'seg' AND tablename = 'settoreerc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfinbando')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryprogfinbandosegview' WHERE listtype = 'seg' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfin')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryprogfinsegview' WHERE listtype = 'seg' AND tablename = 'registryprogfin'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'upb')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'upbsegview' WHERE listtype = 'seg' AND tablename = 'upb'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accmotive')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accmotivesegview' WHERE listtype = 'seg' AND tablename = 'accmotive'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoactivitykind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'progettoactivitykinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoactivitykind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'asset')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'assetsegview' WHERE listtype = 'seg' AND tablename = 'asset'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'anagamm', newtablename = 'rendicontattivitaprogettoanagammview' WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'anag', newtablename = 'rendicontattivitaprogettoanagview' WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'amministrativi' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amministrativi', newtablename = 'registryamministrativiview' WHERE listtype = 'amministrativi' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'fonteindicebibliometricosegview' WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'progettokindsegview' WHERE listtype = 'seg' AND tablename = 'progettokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'orakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'orakindsegview' WHERE listtype = 'seg' AND tablename = 'orakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'rendicontattivitaprogettosegview' WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'workpackage')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'workpackagesegview' WHERE listtype = 'seg' AND tablename = 'workpackage'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ambitoareadisc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ambitoareadiscdefaultview' WHERE listtype = 'default' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuolakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classescuolakinddefaultview' WHERE listtype = 'default' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasdgruppo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sasdgruppodefaultview' WHERE listtype = 'default' AND tablename = 'sasdgruppo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagsturin', newtablename = 'nullaostaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstu', newtablename = 'nullaostaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstustato', newtablename = 'sostenimentoseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuconsmast', newtablename = 'sostenimentoseganagstuconsmastview' WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuacc', newtablename = 'sostenimentoseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'iscrizionedefaultview' WHERE listtype = 'default' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'praticaseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'seganagstu', 'praticaseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sceltacorso' AND tablename = 'didprogori')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sceltacorso', newtablename = 'didprogorisceltacorsoview' WHERE listtype = 'sceltacorso' AND tablename = 'didprogori'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiarkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiarkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiarkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'dichiarsegview' WHERE listtype = 'seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagsturin', newtablename = 'istanzaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_segrin' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_segrin', newtablename = 'istanzaimm_segrinview' WHERE listtype = 'imm_segrin' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seg', newtablename = 'istanzaimm_segview' WHERE listtype = 'imm_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstu', newtablename = 'istanzaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_segpre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_segpre', newtablename = 'istanzaimm_segpreview' WHERE listtype = 'imm_segpre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollorifkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollorifkindsegview' WHERE listtype = 'seg' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollodockind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollodockindsegview' WHERE listtype = 'seg' AND tablename = 'protocollodockind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollosegview' WHERE listtype = 'seg' AND tablename = 'protocollo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstupre', newtablename = 'istanzaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ateco')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'atecodefaultview' WHERE listtype = 'default' AND tablename = 'ateco'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'nace')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'nacedefaultview' WHERE listtype = 'default' AND tablename = 'nace'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusing', newtablename = 'sostenimentoseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'sostenimentosegstudview' WHERE listtype = 'segstud' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusing', newtablename = 'iscrizioneseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pianostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'pianostudiosegstudview' WHERE listtype = 'segstud' AND tablename = 'pianostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'didprog', newtablename = 'iscrizionedidprogview' WHERE listtype = 'didprog' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'iscrizionesegview' WHERE listtype = 'seg' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'iscrizionestatoview' WHERE listtype = 'stato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'iscrizionedotmasview' WHERE listtype = 'dotmas' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'didprogstatoview' WHERE listtype = 'stato' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'corsostudiostatoview' WHERE listtype = 'stato' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'didprogdotmasview' WHERE listtype = 'dotmas' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'corsostudiodotmasview' WHERE listtype = 'dotmas' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pianostudiostatus')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'pianostudiostatusdefaultview' WHERE listtype = 'default' AND tablename = 'pianostudiostatus'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'iscrizioneingressoview' WHERE listtype = 'ingresso' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'sostenimentoseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstustato', newtablename = 'iscrizioneseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstumast', newtablename = 'iscrizioneseganagstumastview' WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuacc', newtablename = 'iscrizioneseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'sostenimentoingressoview' WHERE listtype = 'ingresso' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimentoesito')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sostenimentoesitodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'iscrizioneseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sostenimentodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'appello' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'appello', newtablename = 'attivformappelloview' WHERE listtype = 'appello' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appelloazionekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appelloazionekinddefaultview' WHERE listtype = 'default' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ofakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ofakinddefaultview' WHERE listtype = 'default' AND tablename = 'ofakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniostato')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tirociniostatodefaultview' WHERE listtype = 'default' AND tablename = 'tirociniostato'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tirociniocandidaturakinddefaultview' WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariodomkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariodomkinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariodomkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariokinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'istanzakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'istanzakinddefaultview' WHERE listtype = 'default' AND tablename = 'istanzakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'costoscontodefkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'costoscontodefkinddefaultview' WHERE listtype = 'default' AND tablename = 'costoscontodefkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'carriera' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'carriera', newtablename = 'esonerocarrieraview' WHERE listtype = 'carriera' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'titolostudio' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'titolostudio', newtablename = 'esonerotitolostudioview' WHERE listtype = 'titolostudio' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'disabil' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'disabil', newtablename = 'esonerodisabilview' WHERE listtype = 'disabil' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'esonerodefaultview' WHERE listtype = 'default' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaistanzaconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaistanzaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaistanzaconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaiscrizioneconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconfkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaconfkinddefaultview' WHERE listtype = 'default' AND tablename = 'tassaconfkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pagamentokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'pagamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'pagamentokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ratakinddefaultview' WHERE listtype = 'default' AND tablename = 'ratakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'ratadefmoreview' WHERE listtype = 'more' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'fasciaiseedefmoreview' WHERE listtype = 'more' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'costoscontodef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'costoscontodefmoreview' WHERE listtype = 'more' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'ratadefscontiview' WHERE listtype = 'sconti' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'fasciaiseedefscontiview' WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'costoscontodef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'costoscontodefscontiview' WHERE listtype = 'sconti' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ratadefdefaultview' WHERE listtype = 'default' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'fasciaiseedefdefaultview' WHERE listtype = 'default' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'aoo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'princ', newtablename = 'aooprincview' WHERE listtype = 'princ' AND tablename = 'aoo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'princ', newtablename = 'strutturaprincview' WHERE listtype = 'princ' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istituti_princ' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istituti_princ', newtablename = 'registryistituti_princview' WHERE listtype = 'istituti_princ' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'graduatoriavar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'graduatoriavardefaultview' WHERE listtype = 'default' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionario')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariodefaultview' WHERE listtype = 'default' AND tablename = 'questionario'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'proped' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'proped', newtablename = 'attivformpropedview' WHERE listtype = 'proped' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registryaddress')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'user', newtablename = 'registryaddressuserview' WHERE listtype = 'user' AND tablename = 'registryaddress'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'user', newtablename = 'registryuserview' WHERE listtype = 'user' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aziende', newtablename = 'registryclassaziendeview' WHERE listtype = 'aziende' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'affidamentosegview' WHERE listtype = 'seg' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'provadefaultview' WHERE listtype = 'default' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appellokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appellokinddefaultview' WHERE listtype = 'default' AND tablename = 'appellokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessionekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sessionekinddefaultview' WHERE listtype = 'default' AND tablename = 'sessionekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sessionedefaultview' WHERE listtype = 'default' AND tablename = 'sessione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appellodefaultview' WHERE listtype = 'default' AND tablename = 'appello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'erogazkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'erogazkinddefaultview' WHERE listtype = 'default' AND tablename = 'erogazkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamentokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'affidamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'gruppo' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'gruppo', newtablename = 'attivformgruppoview' WHERE listtype = 'gruppo' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'appello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'appelloerogataview' WHERE listtype = 'erogata' AND tablename = 'appello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'provaingressoview' WHERE listtype = 'ingresso' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aulakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'aulakinddefaultview' WHERE listtype = 'default' AND tablename = 'aulakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'attivformerogataview' WHERE listtype = 'erogata' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'diderog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'diderogdefaultview' WHERE listtype = 'default' AND tablename = 'diderog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tipoattform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tipoattformdefaultview' WHERE listtype = 'default' AND tablename = 'tipoattform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'canale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'canaleerogataview' WHERE listtype = 'erogata' AND tablename = 'canale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'didprogingressoview' WHERE listtype = 'ingresso' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'corsostudioingressoview' WHERE listtype = 'ingresso' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child_azienda' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child_azienda', newtablename = 'sedeseg_child_aziendaview' WHERE listtype = 'seg_child_azienda' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiolivello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiolivellodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'address')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'addresssegview' WHERE listtype = 'seg' AND tablename = 'address'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'sedeseg_childview' WHERE listtype = 'seg_child' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturakinddefaultview' WHERE listtype = 'default' AND tablename = 'strutturakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'affidamentodefaultview' WHERE listtype = 'default' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudionorma')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudionormadefaultview' WHERE listtype = 'default' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_citysegview' WHERE listtype = 'seg' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_country')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_countrysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_country'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_citysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_nationsegview' WHERE listtype = 'seg' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_region')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_regionsegview' WHERE listtype = 'seg' AND tablename = 'geo_region'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'lingue' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'lingue', newtablename = 'geo_nationlingueview' WHERE listtype = 'lingue' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_nationsegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_country')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_countrysegview' WHERE listtype = 'seg' AND tablename = 'geo_country'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'geo_citydefaultview' WHERE listtype = 'default' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aoo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'aoodefaultview' WHERE listtype = 'default' AND tablename = 'aoo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'upb')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'upbdefaultview' WHERE listtype = 'default' AND tablename = 'upb'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'strutturaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuola')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classescuoladefaultview' WHERE listtype = 'default' AND tablename = 'classescuola'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegninteg')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'insegnintegdefaultview' WHERE listtype = 'default' AND tablename = 'insegninteg'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegn')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'insegndefaultview' WHERE listtype = 'default' AND tablename = 'insegn'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'attivformdefaultview' WHERE listtype = 'default' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogporzanno')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogporzannodefaultview' WHERE listtype = 'default' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didproganno')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogannodefaultview' WHERE listtype = 'default' AND tablename = 'didproganno'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogori')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogoridefaultview' WHERE listtype = 'default' AND tablename = 'didprogori'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogdefaultview' WHERE listtype = 'default' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'persone' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'persone', newtablename = 'registryclasspersoneview' WHERE listtype = 'persone' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'registryclassdefaultview' WHERE listtype = 'default' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'titolostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'titolostudiodocentiview' WHERE listtype = 'docenti' AND tablename = 'titolostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'publicaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'publicazdocentiview' WHERE listtype = 'docenti' AND tablename = 'publicaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiokinddefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'areadidattica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'areadidatticadefaultview' WHERE listtype = 'default' AND tablename = 'areadidattica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'aula')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'aulaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'aula'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'edificio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'edificioseg_childview' WHERE listtype = 'seg_child' AND tablename = 'edificio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ccnl')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ccnldefaultview' WHERE listtype = 'default' AND tablename = 'ccnl'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aula' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aula', newtablename = 'provaaulaview' WHERE listtype = 'aula' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studprenotkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'studprenotkinddefaultview' WHERE listtype = 'default' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studdirittokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'studdirittokinddefaultview' WHERE listtype = 'default' AND tablename = 'studdirittokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'studenti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'studenti', newtablename = 'registrystudentiview' WHERE listtype = 'studenti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sasddefaultview' WHERE listtype = 'default' AND tablename = 'sasd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'rendicontaltrokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'rendicontaltrokinddefaultview' WHERE listtype = 'default' AND tablename = 'rendicontaltrokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istitutiesteri' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istitutiesteri', newtablename = 'registryistitutiesteriview' WHERE listtype = 'istitutiesteri' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istituti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istituti', newtablename = 'registryistitutiview' WHERE listtype = 'istituti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aziende', newtablename = 'registryaziendeview' WHERE listtype = 'aziende' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'registrydefaultview' WHERE listtype = 'default' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicazkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'publicazkinddefaultview' WHERE listtype = 'default' AND tablename = 'publicazkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'publicazdefaultview' WHERE listtype = 'default' AND tablename = 'publicaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturadefaultview' WHERE listtype = 'default' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sededefaultview' WHERE listtype = 'default' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'edificio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'edificiodefaultview' WHERE listtype = 'default' AND tablename = 'edificio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aula')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'auladefaultview' WHERE listtype = 'default' AND tablename = 'aula'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'registrydocentiview' WHERE listtype = 'docenti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contrattokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'contrattokinddefaultview' WHERE listtype = 'default' AND tablename = 'contrattokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classconsorsuale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classconsorsualedefaultview' WHERE listtype = 'default' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrtrainer')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'learningagrtrainersegview' WHERE listtype = 'seg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettocosto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'progettocostosegview' WHERE listtype = 'seg' AND tablename = 'progettocosto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettocosto', 'seg', 'progettocostosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segprg' AND tablename = 'progettocosto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segprg', newtablename = 'progettocostosegprgview' WHERE listtype = 'segprg' AND tablename = 'progettocosto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettocosto', 'segprg', 'progettocostosegprgview', 'segprg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segsal' AND tablename = 'progettocosto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segsal', newtablename = 'progettocostosegsalview' WHERE listtype = 'segsal' AND tablename = 'progettocosto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettocosto', 'segsal', 'progettocostosegsalview', 'segsal', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'assetdiaryora')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'assetdiaryorasegview' WHERE listtype = 'seg' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiaryora', 'seg', 'assetdiaryorasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogettoora')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'rendicontattivitaprogettoorasegview' WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogettoora', 'seg', 'rendicontattivitaprogettoorasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rin_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'rin_seg', newtablename = 'istanzarin_segview' WHERE listtype = 'rin_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rin_seg', 'istanzarin_segview', 'rin_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'auth' AND tablename = 'registrationuser')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'auth', newtablename = 'registrationuserauthview' WHERE listtype = 'auth' AND tablename = 'registrationuser'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registrationuser', 'auth', 'registrationuserauthview', 'auth', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'usr' AND tablename = 'registrationuser')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'usr', newtablename = 'registrationuserusrview' WHERE listtype = 'usr' AND tablename = 'registrationuser'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registrationuser', 'usr', 'registrationuserusrview', 'usr', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'flowchart')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'flowchartsegview' WHERE listtype = 'seg' AND tablename = 'flowchart'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('flowchart', 'seg', 'flowchartsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segsal' AND tablename = 'assetdiaryora')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segsal', newtablename = 'assetdiaryorasegsalview' WHERE listtype = 'segsal' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiaryora', 'segsal', 'assetdiaryorasegsalview', 'segsal', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segsal' AND tablename = 'rendicontattivitaprogettoora')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segsal', newtablename = 'rendicontattivitaprogettoorasegsalview' WHERE listtype = 'segsal' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogettoora', 'segsal', 'rendicontattivitaprogettoorasegsalview', 'segsal', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rein_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'rein_seg', newtablename = 'istanzarein_segview' WHERE listtype = 'rein_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rein_seg', 'istanzarein_segview', 'rein_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'pas_seganagstu', newtablename = 'istanzapas_seganagstuview' WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seganagstu', 'istanzapas_seganagstuview', 'pas_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstudelenco' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstudelenco', newtablename = 'praticasegstudelencoview' WHERE listtype = 'segstudelenco' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstudelenco', 'praticasegstudelencoview', 'segstudelenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rein_seganagstu' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'rein_seganagstu', newtablename = 'istanzarein_seganagstuview' WHERE listtype = 'rein_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rein_seganagstu', 'istanzarein_seganagstuview', 'rein_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segistrein' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segistrein', newtablename = 'praticasegistreinview' WHERE listtype = 'segistrein' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segistrein', 'praticasegistreinview', 'segistrein', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rimb_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'rimb_seg', newtablename = 'istanzarimb_segview' WHERE listtype = 'rimb_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rimb_seg', 'istanzarimb_segview', 'rimb_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'conseg_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'conseg_seg', newtablename = 'istanzaconseg_segview' WHERE listtype = 'conseg_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'conseg_seg', 'istanzaconseg_segview', 'conseg_seg', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pagamentokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'pagamentokindsegview' WHERE listtype = 'seg' AND tablename = 'pagamentokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'seg', 'pagamentokindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'relatorekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'relatorekinddefaultview' WHERE listtype = 'default' AND tablename = 'relatorekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('relatorekind', 'default', 'relatorekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tesikind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'tesikindsegview' WHERE listtype = 'seg' AND tablename = 'tesikind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tesikind', 'seg', 'tesikindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'appello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'appellosegview' WHERE listtype = 'seg' AND tablename = 'appello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'seg', 'appellosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'credito')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'creditosegview' WHERE listtype = 'seg' AND tablename = 'credito'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('credito', 'seg', 'creditosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pagamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'pagamentosegview' WHERE listtype = 'seg' AND tablename = 'pagamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamento', 'seg', 'pagamentosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'debito')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'debitosegview' WHERE listtype = 'seg' AND tablename = 'debito'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('debito', 'seg', 'debitosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tesikind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tesikinddefaultview' WHERE listtype = 'default' AND tablename = 'tesikind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tesikind', 'default', 'tesikinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'istanzasegview' WHERE listtype = 'seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seg', 'istanzasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstudelenco' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstudelenco', newtablename = 'praticasegstudelencoview' WHERE listtype = 'segstudelenco' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstudelenco', 'praticasegstudelencoview', 'segstudelenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstudelenco' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstudelenco', newtablename = 'istanzasegstudelencoview' WHERE listtype = 'segstudelenco' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'segstudelenco', 'istanzasegstudelencoview', 'segstudelenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'deliberapratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'deliberapraticasegview' WHERE listtype = 'seg' AND tablename = 'deliberapratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('deliberapratica', 'seg', 'deliberapraticasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstuelenco' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstuelenco', newtablename = 'praticasegstuelencoview' WHERE listtype = 'segstuelenco' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstuelenco', 'praticasegstuelencoview', 'segstuelenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstuelenco' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstuelenco', newtablename = 'istanzasegstuelencoview' WHERE listtype = 'segstuelenco' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'segstuelenco', 'istanzasegstuelencoview', 'segstuelenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segistpass' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segistpass', newtablename = 'praticasegistpassview' WHERE listtype = 'segistpass' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segistpass', 'praticasegistpassview', 'segistpass', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'pas_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'pas_seg', newtablename = 'istanzapas_segview' WHERE listtype = 'pas_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seg', 'istanzapas_segview', 'pas_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'abbr_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'abbr_seg', newtablename = 'istanzaabbr_segview' WHERE listtype = 'abbr_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'abbr_seg', 'istanzaabbr_segview', 'abbr_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'tri_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'tri_seg', newtablename = 'istanzatri_segview' WHERE listtype = 'tri_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tri_seg', 'istanzatri_segview', 'tri_seg', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segamm' AND tablename = 'flowchart')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segamm', newtablename = 'flowchartsegammview' WHERE listtype = 'segamm' AND tablename = 'flowchart'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('flowchart', 'segamm', 'flowchartsegammview', 'segamm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'perf' AND tablename = 'position')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'perf', newtablename = 'positionperfview' WHERE listtype = 'perf' AND tablename = 'position'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('position', 'perf', 'positionperfview', 'perf', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfsoglia')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfsogliadefaultview' WHERE listtype = 'default' AND tablename = 'perfsoglia'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfsoglia', 'default', 'perfsogliadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'perf' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'perf', newtablename = 'strutturaperfview' WHERE listtype = 'perf' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'perf', 'strutturaperfview', 'perf', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfprogettodefaultview' WHERE listtype = 'default' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogetto', 'default', 'perfprogettodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfprogettostatus')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfprogettostatusdefaultview' WHERE listtype = 'default' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettostatus', 'default', 'perfprogettostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'conresp' AND tablename = 'perfstrutturauo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'conresp', newtablename = 'perfstrutturauoconrespview' WHERE listtype = 'conresp' AND tablename = 'perfstrutturauo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfstrutturauo', 'conresp', 'perfstrutturauoconrespview', 'conresp', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfschedacambiostato')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfschedacambiostatodefaultview' WHERE listtype = 'default' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfschedacambiostato', 'default', 'perfschedacambiostatodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfstrutturauo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfstrutturauodefaultview' WHERE listtype = 'default' AND tablename = 'perfstrutturauo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfstrutturauo', 'default', 'perfstrutturauodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfschedastatus')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfschedastatusdefaultview' WHERE listtype = 'default' AND tablename = 'perfschedastatus'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfschedastatus', 'default', 'perfschedastatusdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfvalutazioneateneo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfvalutazioneateneodefaultview' WHERE listtype = 'default' AND tablename = 'perfvalutazioneateneo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfvalutazioneateneo', 'default', 'perfvalutazioneateneodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfvalutazioneuo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfvalutazioneuodefaultview' WHERE listtype = 'default' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfvalutazioneuo', 'default', 'perfvalutazioneuodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfvalutazionepersonale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfvalutazionepersonaledefaultview' WHERE listtype = 'default' AND tablename = 'perfvalutazionepersonale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfvalutazionepersonale', 'default', 'perfvalutazionepersonaledefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfprogettocambiostato')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfprogettocambiostatodefaultview' WHERE listtype = 'default' AND tablename = 'perfprogettocambiostato'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettocambiostato', 'default', 'perfprogettocambiostatodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'tree' AND tablename = 'menuweb')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'tree', newtablename = 'menuwebtreeview' WHERE listtype = 'tree' AND tablename = 'menuweb'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('menuweb', 'tree', 'menuwebtreeview', 'tree', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'valutazione_altreuo' AND tablename = 'perfprogettoobiettivo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'valutazione_altreuo', newtablename = 'perfprogettoobiettivovalutazione_altreuoview' WHERE listtype = 'valutazione_altreuo' AND tablename = 'perfprogettoobiettivo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettoobiettivo', 'valutazione_altreuo', 'perfprogettoobiettivovalutazione_altreuoview', 'valutazione_altreuo', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'valutazione_uo' AND tablename = 'perfprogettoobiettivo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'valutazione_uo', newtablename = 'perfprogettoobiettivovalutazione_uoview' WHERE listtype = 'valutazione_uo' AND tablename = 'perfprogettoobiettivo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettoobiettivo', 'valutazione_uo', 'perfprogettoobiettivovalutazione_uoview', 'valutazione_uo', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfindicatore')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfindicatoredefaultview' WHERE listtype = 'default' AND tablename = 'perfindicatore'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfindicatore', 'default', 'perfindicatoredefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strumentofin')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strumentofindefaultview' WHERE listtype = 'default' AND tablename = 'strumentofin'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strumentofin', 'default', 'strumentofindefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'partnerkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'partnerkinddefaultview' WHERE listtype = 'default' AND tablename = 'partnerkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('partnerkind', 'default', 'partnerkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getstrutturapersonale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getstrutturapersonaledefaultview' WHERE listtype = 'default' AND tablename = 'getstrutturapersonale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getstrutturapersonale', 'default', 'getstrutturapersonaledefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'position')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'positionsegview' WHERE listtype = 'seg' AND tablename = 'position'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('position', 'seg', 'positionsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'requisito')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'requisitosegview' WHERE listtype = 'seg' AND tablename = 'requisito'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('requisito', 'seg', 'requisitosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'allegatirichiesti')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'allegatirichiestidefaultview' WHERE listtype = 'default' AND tablename = 'allegatirichiesti'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('allegatirichiesti', 'default', 'allegatirichiestidefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docente' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docente', newtablename = 'affidamentodocenteview' WHERE listtype = 'docente' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'docente', 'affidamentodocenteview', 'docente', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docente' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docente', newtablename = 'rendicontattivitaprogettodocenteview' WHERE listtype = 'docente' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'docente', 'rendicontattivitaprogettodocenteview', 'docente', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti_docente' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti_docente', newtablename = 'registrydocenti_docenteview' WHERE listtype = 'docenti_docente' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti_docente', 'registrydocenti_docenteview', 'docenti_docente', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docente' AND tablename = 'assetdiary')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docente', newtablename = 'assetdiarydocenteview' WHERE listtype = 'docente' AND tablename = 'assetdiary'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'docente', 'assetdiarydocenteview', 'docente', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'restrictedfunction')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'restrictedfunctionsegview' WHERE listtype = 'seg' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('restrictedfunction', 'seg', 'restrictedfunctionsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfprogettocostovarbudgetview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfprogettocostovarbudgetviewdefaultview' WHERE listtype = 'default' AND tablename = 'perfprogettocostovarbudgetview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettocostovarbudgetview', 'default', 'perfprogettocostovarbudgetviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfprogettocostobudgetview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfprogettocostobudgetviewdefaultview' WHERE listtype = 'default' AND tablename = 'perfprogettocostobudgetview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettocostobudgetview', 'default', 'perfprogettocostobudgetviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aziende_ro' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aziende_ro', newtablename = 'registryaziende_roview' WHERE listtype = 'aziende_ro' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende_ro', 'registryaziende_roview', 'aziende_ro', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'valutazione' AND tablename = 'perfindicatore')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'valutazione', newtablename = 'perfindicatorevalutazioneview' WHERE listtype = 'valutazione' AND tablename = 'perfindicatore'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfindicatore', 'valutazione', 'perfindicatorevalutazioneview', 'valutazione', NULL, NULL, NULL, NULL)
GO
 
 
-- IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'position')
--UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'positiondefaultview' WHERE listtype = 'default' AND tablename = 'position'
--ELSE
--INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('position', 'default', 'positiondefaultview', 'default', NULL, NULL, NULL, NULL)
--GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfrequestobbunatantum')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfrequestobbunatantumdefaultview' WHERE listtype = 'default' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfrequestobbunatantum', 'default', 'perfrequestobbunatantumdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfrequestobbindividuale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfrequestobbindividualedefaultview' WHERE listtype = 'default' AND tablename = 'perfrequestobbindividuale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfrequestobbindividuale', 'default', 'perfrequestobbindividualedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contratto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'contrattodefaultview' WHERE listtype = 'default' AND tablename = 'contratto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contratto', 'default', 'contrattodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'analisiannuale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'analisiannualedefaultview' WHERE listtype = 'default' AND tablename = 'analisiannuale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('analisiannuale', 'default', 'analisiannualedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'elenco' AND tablename = 'inquadramento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'elenco', newtablename = 'inquadramentoelencoview' WHERE listtype = 'elenco' AND tablename = 'inquadramento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'elenco', 'inquadramentoelencoview', 'elenco', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'integrandi' AND tablename = 'sasd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'integrandi', newtablename = 'sasdintegrandiview' WHERE listtype = 'integrandi' AND tablename = 'sasd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'integrandi', 'sasdintegrandiview', 'integrandi', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amm' AND tablename = 'contratto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amm', newtablename = 'contrattoammview' WHERE listtype = 'amm' AND tablename = 'contratto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contratto', 'amm', 'contrattoammview', 'amm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcontrattikindview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getcontrattikindviewdefaultview' WHERE listtype = 'default' AND tablename = 'getcontrattikindview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcontrattikindview', 'default', 'getcontrattikindviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturaparentresponsabiliview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturaparentresponsabiliviewdefaultview' WHERE listtype = 'default' AND tablename = 'strutturaparentresponsabiliview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturaparentresponsabiliview', 'default', 'strutturaparentresponsabiliviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturaparentview')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturaparentviewdefaultview' WHERE listtype = 'default' AND tablename = 'strutturaparentview'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturaparentview', 'default', 'strutturaparentviewdefaultview', 'default', NULL, NULL, NULL, NULL)
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcontratti')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getcontrattidefaultview' WHERE listtype = 'default' AND tablename = 'getcontratti'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcontratti', 'default', 'getcontrattidefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'uncategorized' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'uncategorized', newtablename = 'registryuncategorizedview' WHERE listtype = 'uncategorized' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'uncategorized', 'registryuncategorizedview', 'uncategorized', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021

 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'titolokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'titolokinddefaultview' WHERE listtype = 'default' AND tablename = 'titolokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolokind', 'default', 'titolokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogsuddannokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogsuddannokinddefaultview' WHERE listtype = 'default' AND tablename = 'didprogsuddannokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogsuddannokind', 'default', 'didprogsuddannokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'income')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'incomedefaultview' WHERE listtype = 'default' AND tablename = 'income'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('income', 'default', 'incomedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'prev' AND tablename = 'contratto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'prev', newtablename = 'contrattoprevview' WHERE listtype = 'prev' AND tablename = 'contratto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contratto', 'prev', 'contrattoprevview', 'prev', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'persone' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'persone', newtablename = 'registrypersoneview' WHERE listtype = 'persone' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'persone', 'registrypersoneview', 'persone', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'perfelenchi' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'perfelenchi', newtablename = 'strutturaperfelenchiview' WHERE listtype = 'perfelenchi' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'perfelenchi', 'strutturaperfelenchiview', 'perfelenchi', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stru' AND tablename = 'afferenza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stru', newtablename = 'afferenzastruview' WHERE listtype = 'stru' AND tablename = 'afferenza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('afferenza', 'stru', 'afferenzastruview', 'stru', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amm' AND tablename = 'afferenza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amm', newtablename = 'afferenzaammview' WHERE listtype = 'amm' AND tablename = 'afferenza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('afferenza', 'amm', 'afferenzaammview', 'amm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfruolo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfruolodefaultview' WHERE listtype = 'default' AND tablename = 'perfruolo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfruolo', 'default', 'perfruolodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'perfprogettoobiettivoattivitadocentiview' WHERE listtype = 'docenti' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfprogettoobiettivoattivita', 'docenti', 'perfprogettoobiettivoattivitadocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'perfobiettivokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'perfobiettivokinddefaultview' WHERE listtype = 'default' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('perfobiettivokind', 'default', 'perfobiettivokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettostatuskind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'progettostatuskinddefaultview' WHERE listtype = 'default' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettostatuskind', 'default', 'progettostatuskinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 --insert

------------------------DA LASCIARE IN FONDO COME PARACADUTE--------------------------------
IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'lista',newtablename = 'registrymainview' WHERE listtype = 'default' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','registry',null,null,null,null,'lista','registrymainview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'upb')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'upbview' WHERE listtype = 'default' AND tablename = 'upb'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','upb',null,null,null,null,'default','upbview')
GO
--Verificare
--IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registryclass')
--UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'registryclassdefaultview' WHERE listtype = 'default' AND tablename = 'registryclass'
--ELSE
--INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','registryclass',null,null,null,null,'default','registryclassdefaultview')
--GO

-- ELIMINAZIONE DATI PER web_listredir --


IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotimesheetdefaultview')
DELETE web_listredir WHERE newtablename = 'progettotimesheetdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotimesheetprogettodefaultview')
DELETE web_listredir WHERE newtablename = 'progettotimesheetprogettodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettorpdefaultview')
DELETE web_listredir WHERE newtablename = 'progettorpdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettoattachkindprogettostatuskinddefaultview')
DELETE web_listredir WHERE newtablename = 'progettoattachkindprogettostatuskinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotestokindprogettostatuskinddefaultview')
DELETE web_listredir WHERE newtablename = 'progettotestokindprogettostatuskinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoattachkindsegview')
DELETE web_listredir WHERE newtablename = 'progettoattachkindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotestokindsegview')
DELETE web_listredir WHERE newtablename = 'progettotestokindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettosettoreercsegview')
DELETE web_listredir WHERE newtablename = 'progettosettoreercsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segprog' AND newtablename = 'settoreercsegprogview')
DELETE web_listredir WHERE newtablename = 'settoreercsegprogview' and listtype = 'segprog'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettobudgetsegview')
DELETE web_listredir WHERE newtablename = 'progettobudgetsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'rendicontattivitaprogettoorasegview')
DELETE web_listredir WHERE newtablename = 'rendicontattivitaprogettoorasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'assetdiarysegview')
DELETE web_listredir WHERE newtablename = 'assetdiarysegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'assetdiaryorasegview')
DELETE web_listredir WHERE newtablename = 'assetdiaryorasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seganag' AND newtablename = 'assetdiaryseganagview')
DELETE web_listredir WHERE newtablename = 'assetdiaryseganagview' and listtype = 'seganag'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'sospensionedefaultview')
DELETE web_listredir WHERE newtablename = 'sospensionedefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'edifici' AND newtablename = 'sospensioneedificiview')
DELETE web_listredir WHERE newtablename = 'sospensioneedificiview' and listtype = 'edifici'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'aula' AND newtablename = 'sospensioneaulaview')
DELETE web_listredir WHERE newtablename = 'sospensioneaulaview' and listtype = 'aula'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'princ' AND newtablename = 'sospensioneprincview')
DELETE web_listredir WHERE newtablename = 'sospensioneprincview' and listtype = 'princ'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'istitutoprincdefaultview')
DELETE web_listredir WHERE newtablename = 'istitutoprincdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'corsostudiocaratteristicadefaultview')
DELETE web_listredir WHERE newtablename = 'corsostudiocaratteristicadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'bandomiinsegnsegview')
DELETE web_listredir WHERE newtablename = 'bandomiinsegnsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'tipologiastudentesegview')
DELETE web_listredir WHERE newtablename = 'tipologiastudentesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'bandodsserviziosegview')
DELETE web_listredir WHERE newtablename = 'bandodsserviziosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'rendicontaltrodefaultview')
DELETE web_listredir WHERE newtablename = 'rendicontaltrodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'rendicontdefaultview')
DELETE web_listredir WHERE newtablename = 'rendicontdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'saldefaultview')
DELETE web_listredir WHERE newtablename = 'saldefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'contrattokindpositiondefaultview')
DELETE web_listredir WHERE newtablename = 'contrattokindpositiondefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'salprogettocostodefaultview')
DELETE web_listredir WHERE newtablename = 'salprogettocostodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'salassetdiaryoradefaultview')
DELETE web_listredir WHERE newtablename = 'salassetdiaryoradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'salrenticontattivitaprogettooradefaultview')
DELETE web_listredir WHERE newtablename = 'salrenticontattivitaprogettooradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'salrendicontattivitaprogettooradefaultview')
DELETE web_listredir WHERE newtablename = 'salrendicontattivitaprogettooradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'virtualuserdefaultview')
DELETE web_listredir WHERE newtablename = 'virtualuserdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'rendicontattivitaprogettoitinerationdefaultview')
DELETE web_listredir WHERE newtablename = 'rendicontattivitaprogettoitinerationdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'rendicontattivitaprogettoyeardefaultview')
DELETE web_listredir WHERE newtablename = 'rendicontattivitaprogettoyeardefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'workpackageupbsegview')
DELETE web_listredir WHERE newtablename = 'workpackageupbsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstupre' AND newtablename = 'diniegoseganagstupreview')
DELETE web_listredir WHERE newtablename = 'diniegoseganagstupreview' and listtype = 'seganagstupre'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segisteq' AND newtablename = 'nullaostasegisteqview')
DELETE web_listredir WHERE newtablename = 'nullaostasegisteqview' and listtype = 'segisteq'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettoassetdefaultview')
DELETE web_listredir WHERE newtablename = 'progettoassetdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'istanzadichiarsegview')
DELETE web_listredir WHERE newtablename = 'istanzadichiarsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segson' AND newtablename = 'protocollodocelementsegsonview')
DELETE web_listredir WHERE newtablename = 'protocollodocelementsegsonview' and listtype = 'segson'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'registrationuserflowchartdefaultview')
DELETE web_listredir WHERE newtablename = 'registrationuserflowchartdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'registrationuserstatusdefaultview')
DELETE web_listredir WHERE newtablename = 'registrationuserstatusdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoudrmembrosegview')
DELETE web_listredir WHERE newtablename = 'progettoudrmembrosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoudrsegview')
DELETE web_listredir WHERE newtablename = 'progettoudrsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'affidamentocaratteristicaorasegview')
DELETE web_listredir WHERE newtablename = 'affidamentocaratteristicaorasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'getprogettocostoviewdefaultview')
DELETE web_listredir WHERE newtablename = 'getprogettocostoviewdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettobudgetvariazionedefaultview')
DELETE web_listredir WHERE newtablename = 'progettobudgetvariazionedefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostotaxsegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostotaxsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostoinventorytreesegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostoinventorytreesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostocontrattokindsegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostocontrattokindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostoaccmotivesegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostoaccmotivesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostokindtaxsegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostokindtaxsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostokindinventorytreesegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostokindinventorytreesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostokindcontrattokindsegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostokindcontrattokindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostokindaccmotivesegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostokindaccmotivesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'lezionesegview')
DELETE web_listredir WHERE newtablename = 'lezionesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'affidamentocaratteristicasegview')
DELETE web_listredir WHERE newtablename = 'affidamentocaratteristicasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'contrattodefaultview')
DELETE web_listredir WHERE newtablename = 'contrattodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoregistry_aziendesegview')
DELETE web_listredir WHERE newtablename = 'progettoregistry_aziendesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoattachsegview')
DELETE web_listredir WHERE newtablename = 'progettoattachsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoprorogasegview')
DELETE web_listredir WHERE newtablename = 'progettoprorogasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotestosegview')
DELETE web_listredir WHERE newtablename = 'progettotestosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostosegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotipocostokindsegview')
DELETE web_listredir WHERE newtablename = 'progettotipocostokindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'workpackagekindsegview')
DELETE web_listredir WHERE newtablename = 'workpackagekindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrin' AND newtablename = 'nullaostasegistrinview')
DELETE web_listredir WHERE newtablename = 'nullaostasegistrinview' and listtype = 'segistrin'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segisttru' AND newtablename = 'nullaostasegisttruview')
DELETE web_listredir WHERE newtablename = 'nullaostasegisttruview' and listtype = 'segisttru'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seganagsturin' AND newtablename = 'diniegoseganagsturinview')
DELETE web_listredir WHERE newtablename = 'diniegoseganagsturinview' and listtype = 'seganagsturin'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrein' AND newtablename = 'nullaostasegistreinview')
DELETE web_listredir WHERE newtablename = 'nullaostasegistreinview' and listtype = 'segistrein'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segpratica' AND newtablename = 'diniegosegpraticaview')
DELETE web_listredir WHERE newtablename = 'diniegosegpraticaview' and listtype = 'segpratica'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segpratica' AND newtablename = 'nullaostasegpraticaview')
DELETE web_listredir WHERE newtablename = 'nullaostasegpraticaview' and listtype = 'segpratica'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrein' AND newtablename = 'convalidantesegistreinview')
DELETE web_listredir WHERE newtablename = 'convalidantesegistreinview' and listtype = 'segistrein'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrein' AND newtablename = 'convalidasegistreinview')
DELETE web_listredir WHERE newtablename = 'convalidasegistreinview' and listtype = 'segistrein'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrein' AND newtablename = 'convalidatosegistreinview')
DELETE web_listredir WHERE newtablename = 'convalidatosegistreinview' and listtype = 'segistrein'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistsosp' AND newtablename = 'nullaostasegistsospview')
DELETE web_listredir WHERE newtablename = 'nullaostasegistsospview' and listtype = 'segistsosp'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'deliberaistanzasegview')
DELETE web_listredir WHERE newtablename = 'deliberaistanzasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistrimb' AND newtablename = 'creditoistanza_rimbsegistrimbview')
DELETE web_listredir WHERE newtablename = 'creditoistanza_rimbsegistrimbview' and listtype = 'segistrimb'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistcons' AND newtablename = 'tesikeywordsegistconsview')
DELETE web_listredir WHERE newtablename = 'tesikeywordsegistconsview' and listtype = 'segistcons'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'pagamentosegview')
DELETE web_listredir WHERE newtablename = 'pagamentosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'debitosegview')
DELETE web_listredir WHERE newtablename = 'debitosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistcons' AND newtablename = 'richitesisegistconsview')
DELETE web_listredir WHERE newtablename = 'richitesisegistconsview' and listtype = 'segistcons'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistcons' AND newtablename = 'tesisegistconsview')
DELETE web_listredir WHERE newtablename = 'tesisegistconsview' and listtype = 'segistcons'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'relatoredefaultview')
DELETE web_listredir WHERE newtablename = 'relatoredefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistcons' AND newtablename = 'relatoresegistconsview')
DELETE web_listredir WHERE newtablename = 'relatoresegistconsview' and listtype = 'segistcons'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'protocollodocelementsegview')
DELETE web_listredir WHERE newtablename = 'protocollodocelementsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'protocollodocsegview')
DELETE web_listredir WHERE newtablename = 'protocollodocsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'protocollodestinatariosegview')
DELETE web_listredir WHERE newtablename = 'protocollodestinatariosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'deliberapraticasegview')
DELETE web_listredir WHERE newtablename = 'deliberapraticasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistpass' AND newtablename = 'convalidatosegistpassview')
DELETE web_listredir WHERE newtablename = 'convalidatosegistpassview' and listtype = 'segistpass'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistpass' AND newtablename = 'convalidantesegistpassview')
DELETE web_listredir WHERE newtablename = 'convalidantesegistpassview' and listtype = 'segistpass'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistpass' AND newtablename = 'convalidasegistpassview')
DELETE web_listredir WHERE newtablename = 'convalidasegistpassview' and listtype = 'segistpass'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND newtablename = 'rendicontaltrodocview')
DELETE web_listredir WHERE newtablename = 'rendicontaltrodocview' and listtype = 'doc'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'attivform' AND newtablename = 'lezioneattivformview')
DELETE web_listredir WHERE newtablename = 'lezioneattivformview' and listtype = 'attivform'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'rendicont' AND newtablename = 'lezionerendicontview')
DELETE web_listredir WHERE newtablename = 'lezionerendicontview' and listtype = 'rendicont'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'lezionedefaultview')
DELETE web_listredir WHERE newtablename = 'lezionedefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segistabbr' AND newtablename = 'convalidasegistabbrview')
DELETE web_listredir WHERE newtablename = 'convalidasegistabbrview' and listtype = 'segistabbr'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'flowchartusersegview')
DELETE web_listredir WHERE newtablename = 'flowchartusersegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'flowchartrestrictedfunctionsegview')
DELETE web_listredir WHERE newtablename = 'flowchartrestrictedfunctionsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'customusersegview')
DELETE web_listredir WHERE newtablename = 'customusersegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'restrictedfunctionsegview')
DELETE web_listredir WHERE newtablename = 'restrictedfunctionsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'contrattokindperiododefaultview')
DELETE web_listredir WHERE newtablename = 'contrattokindperiododefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'user' AND newtablename = 'registryreferenceuserview')
DELETE web_listredir WHERE newtablename = 'registryreferenceuserview' and listtype = 'user'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'persone' AND newtablename = 'registryreferencepersoneview')
DELETE web_listredir WHERE newtablename = 'registryreferencepersoneview' and listtype = 'persone'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'registryreferencesegview')
DELETE web_listredir WHERE newtablename = 'registryreferencesegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'mutuazionecaratteristicaoradefaultview')
DELETE web_listredir WHERE newtablename = 'mutuazionecaratteristicaoradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'mutuazionecaratteristicadefaultview')
DELETE web_listredir WHERE newtablename = 'mutuazionecaratteristicadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'attivformcaratteristicaoradefaultview')
DELETE web_listredir WHERE newtablename = 'attivformcaratteristicaoradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'mutuazionedefaultview')
DELETE web_listredir WHERE newtablename = 'mutuazionedefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND newtablename = 'appelloattivformseg_childview')
DELETE web_listredir WHERE newtablename = 'appelloattivformseg_childview' and listtype = 'seg_child'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'attivformvalutazionekinddefaultview')
DELETE web_listredir WHERE newtablename = 'attivformvalutazionekinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didprogcurrcaratteristicadefaultview')
DELETE web_listredir WHERE newtablename = 'didprogcurrcaratteristicadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'attivformpropeddefaultview')
DELETE web_listredir WHERE newtablename = 'attivformpropeddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'attivformcaratteristicadefaultview')
DELETE web_listredir WHERE newtablename = 'attivformcaratteristicadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didprogclassconsorsualedefaultview')
DELETE web_listredir WHERE newtablename = 'didprogclassconsorsualedefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'affidamentokindcostooradefaultview')
DELETE web_listredir WHERE newtablename = 'affidamentokindcostooradefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND newtablename = 'getcostididatticaerogataview')
DELETE web_listredir WHERE newtablename = 'getcostididatticaerogataview' and listtype = 'erogata'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didprogcurrdefaultview')
DELETE web_listredir WHERE newtablename = 'didprogcurrdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didprogdatepianodefaultview')
DELETE web_listredir WHERE newtablename = 'didprogdatepianodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didprograppstuddefaultview')
DELETE web_listredir WHERE newtablename = 'didprograppstuddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'corsostudioclassescuoladefaultview')
DELETE web_listredir WHERE newtablename = 'corsostudioclassescuoladefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'sasdaffinidefaultview')
DELETE web_listredir WHERE newtablename = 'sasdaffinidefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND newtablename = 'orakindseg_childview')
DELETE web_listredir WHERE newtablename = 'orakindseg_childview' and listtype = 'seg_child'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfpositionsoglieindividualidefaultview')
DELETE web_listredir WHERE newtablename = 'perfpositionsoglieindividualidefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfpositioncomportamentodefaultview')
DELETE web_listredir WHERE newtablename = 'perfpositioncomportamentodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfpositionattachdefaultview')
DELETE web_listredir WHERE newtablename = 'perfpositionattachdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfcomportamentosogliadefaultview')
DELETE web_listredir WHERE newtablename = 'perfcomportamentosogliadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfsogliakinddefaultview')
DELETE web_listredir WHERE newtablename = 'perfsogliakinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfcomportamentodefaultview')
DELETE web_listredir WHERE newtablename = 'perfcomportamentodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfstrutturauodefaultview')
DELETE web_listredir WHERE newtablename = 'perfstrutturauodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfindicatoresogliadefaultview')
DELETE web_listredir WHERE newtablename = 'perfindicatoresogliadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfindicatoredefaultview')
DELETE web_listredir WHERE newtablename = 'perfindicatoredefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'conresp' AND newtablename = 'perfstrutturauoconrespview')
DELETE web_listredir WHERE newtablename = 'perfstrutturauoconrespview' and listtype = 'conresp'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettouodefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettouodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettouomembrodefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettouomembrodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettocostovarbudgetdefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettocostovarbudgetdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettocostodefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettocostodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoattachdefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoattachdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoavanzamentodefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoavanzamentodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivodefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivoattivitadefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivoattivitadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazioneateneovalidatoredefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazioneateneovalidatoredefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazioneateneoresdefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazioneateneoresdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'validatoridefaultview')
DELETE web_listredir WHERE newtablename = 'validatoridefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfmissiondefaultview')
DELETE web_listredir WHERE newtablename = 'perfmissiondefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazioneuoattachdefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazioneuoattachdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivoattivitaattachdefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivoattivitaattachdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonaleattachdefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonaleattachdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfindicatorekinddefaultview')
DELETE web_listredir WHERE newtablename = 'perfindicatorekinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND newtablename = 'afferenzadocview')
DELETE web_listredir WHERE newtablename = 'afferenzadocview' and listtype = 'doc'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'amm' AND newtablename = 'afferenzaammview')
DELETE web_listredir WHERE newtablename = 'afferenzaammview' and listtype = 'amm'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivosogliadefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivosogliadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'affidamentocaratteristicadefaultview')
DELETE web_listredir WHERE newtablename = 'affidamentocaratteristicadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfruolodefaultview')
DELETE web_listredir WHERE newtablename = 'perfruolodefaultview' and listtype = 'default'
GO

IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'didproggruppdefaultview')
DELETE web_listredir WHERE newtablename = 'didproggruppdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'costoscontodefdefaultview')
DELETE web_listredir WHERE newtablename = 'costoscontodefdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'schedauoaltre' AND newtablename = 'perfprogettoobiettivoschedauoaltreview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivoschedauoaltreview' and listtype = 'schedauoaltre'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'schedauo' AND newtablename = 'perfprogettoobiettivoschedauoview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivoschedauoview' and listtype = 'schedauo'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivouoviewdefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivouoviewdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfprogettoobiettivopersonaleviewdefaultview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivopersonaleviewdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazioneuoindicatoridefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazioneuoindicatoridefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'soglia' AND newtablename = 'perfprogettoobiettivosogliasogliaview')
DELETE web_listredir WHERE newtablename = 'perfprogettoobiettivosogliasogliaview' and listtype = 'soglia'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonalecomportamentodefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonalecomportamentodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonaleuodefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonaleuodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonaleateneodefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonaleateneodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfobiettiviuodefaultview')
DELETE web_listredir WHERE newtablename = 'perfobiettiviuodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonaleobiettivodefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonaleobiettivodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfvalutazionepersonalesogliadefaultview')
DELETE web_listredir WHERE newtablename = 'perfvalutazionepersonalesogliadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettofinanziamentodefaultview')
DELETE web_listredir WHERE newtablename = 'progettofinanziamentodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'bandomiallegatisegview')
DELETE web_listredir WHERE newtablename = 'bandomiallegatisegview' and listtype = 'seg'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'convenzioneattachsegview')
DELETE web_listredir WHERE newtablename = 'convenzioneattachsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'bandomipropedeutsegview')
DELETE web_listredir WHERE newtablename = 'bandomipropedeutsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'bandomididprogfromsegview')
DELETE web_listredir WHERE newtablename = 'bandomididprogfromsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'getcostoviewdefaultview')
DELETE web_listredir WHERE newtablename = 'getcostoviewdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'accordoscambiomidettlang' AND newtablename = 'cefrlanglevelaccordoscambiomidettlangview')
DELETE web_listredir WHERE newtablename = 'cefrlanglevelaccordoscambiomidettlangview' and listtype = 'accordoscambiomidettlang'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'accordoscambiomidettsegview')
DELETE web_listredir WHERE newtablename = 'accordoscambiomidettsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'accordoscambiomidettazsegview')
DELETE web_listredir WHERE newtablename = 'accordoscambiomidettazsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'accordoscambiomiporzannosegview')
DELETE web_listredir WHERE newtablename = 'accordoscambiomiporzannosegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'cefrlangleveldefaultview')
DELETE web_listredir WHERE newtablename = 'cefrlangleveldefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'perfobiettiviuosogliadefaultview')
DELETE web_listredir WHERE newtablename = 'perfobiettiviuosogliadefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'perf' AND newtablename = 'accountvardetailperfview')
DELETE web_listredir WHERE newtablename = 'accountvardetailperfview' and listtype = 'perf'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'docente' AND newtablename = 'afferenzadocenteview')
DELETE web_listredir WHERE newtablename = 'afferenzadocenteview' and listtype = 'docente'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'docente' AND newtablename = 'rendicontaltrodocenteview')
DELETE web_listredir WHERE newtablename = 'rendicontaltrodocenteview' and listtype = 'docente'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'docenti_doc' AND newtablename = 'registry')
DELETE web_listredir WHERE newtablename = 'registrydocenti_docview' and listtype = 'docente'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

--delete
