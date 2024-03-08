
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti_doc' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti_doc',newtablename = 'registrydocenti_docview' WHERE listtype = 'docenti_doc' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti_doc','registry',null,null,null,null,'docenti_doc','registrydocenti_docview')
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
