
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



-- GENERAZIONE DATI PER report --
IF not exists(SELECT * FROM [report] WHERE reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [report] (reportname,active,description,filename,flag_both,flag_cash,flag_comp,groupname,modulename,orientation,papersize,sp_doupdate,timeout,webvisible) 
VALUES ('bilancioconsuntivo_S_cassa','S','Conto consuntivo annuale spese','bilconsuntivo_spese_cassa.rpt','N','S','N','Bilancio','Finanziaria','P','A4',null,null,'S')

-- chi ha un bilancio di sola cassa NON deve vedere questa stampa
update report set flag_cash = 'N' where reportname = 'bilancioconsuntivocassa_S'


-- GENERAZIONE DATI PER reportparameter --
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'ayear' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ayear','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:03:03.830'},'''PINO''',null,'Esercizio',null,null,'Inserire l''esercizio',null,null,'ACCOUNTYEAR','N',{ts '2006-01-26 10:03:10.737'},'''PINO''','N','1',null,'Int32','year',null)
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'date' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('date','bilancioconsuntivo_S_cassa',null,null,null,'Data',null,null,'Inserire la data',null,null,'ACCOUNTDATE','N',null,null,'N','2',null,'DateTime','d',null)
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'finpart' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('finpart','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:03:44.640'},'''PINO''',null,'Parte bilancio',null,null,'Inserire la parte bilancio (deve essere S)',null,'S','STRING','N',{ts '2006-01-26 10:04:24.360'},'''PINO''','N','3','costant.hidden','String','g',null)
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'idupb' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('idupb','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:09:25.750'},'''PINO''','upb','Codice UPB','codeupb',null,'Selezionare il codice dell''U.P.B.',null,'%','STRING','N',{ts '2006-09-07 16:26:30.127'},'''SARA''','S','5','custom.UPB','String','g','idupb')
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'levelusable' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('levelusable','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:06:06.890'},'''PINO''','finlevel','Livello operativo','description','(ayear=<%sys[esercizio]%>) AND (flagusable=''S'')','Inserire il livello di bilancio (operativo)',null,null,'NOHINT','S',{ts '2006-09-07 16:31:19.547'},'''SARA''','N','7',null,'String','g','nlevel')
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'showchildupb' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('showchildupb','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:22:03.000'},'''PINO''',null,'Mostra livelli sottostanti',null,null,'Visualizza i livelli sottostanti l''UPB selezionato',null,'N','STRING','N',{ts '2006-09-07 16:31:19.737'},'''SARA''','N','6','check.S|N|Visualizza i  livelli sottostanti','String','g',null)
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'showupb' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('showupb','bilancioconsuntivo_S_cassa',{ts '2006-01-26 10:10:47.750'},'''PINO''',null,'Visualizza UPB',null,null,'Visualizza l''UPB nella stampa.',null,'S','STRING','N',{ts '2006-09-07 16:30:52.657'},'''SARA''','N','4','check.S|N|Mostra UPB.','String','g',null)
IF not exists(SELECT * FROM [reportparameter] WHERE paramname = 'suppressifblank' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportparameter] (paramname,reportname,ct,cu,datasource,description,displaymember,filter,help,help2,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('suppressifblank','bilancioconsuntivo_S_cassa',{ts '2006-02-13 15:33:44.563'},'''SARA''',null,'Nascondi',null,null,'Nascondi voci di bilancio inutilizzate.',null,'S','STRING','N',{ts '2006-09-07 16:28:17.313'},'''SARA''','N','8','check.S|N|Nascondi','String','g',null)
GO


-- GENERAZIONE DATI PER reportadditionalparam --
IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'IntestazioneReport' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('IntestazioneReport','bilancioconsuntivo_S_cassa',null,null,null,null,'Rendiconto finanziario','Parametro che imposta la denominazione del prospetto da stampare')
IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'MostraDataStampa' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('MostraDataStampa','bilancioconsuntivo_S_cassa',null,null,{ts '2007-01-16 10:48:30.233'},'''SARA''','S','Parametro che gestisce la visualizzazione delle informazioni inerenti la data di stampa (S = Visualizza, N = Non Visualizza)')
IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'MostraDenominazioneUniversita' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('MostraDenominazioneUniversita','bilancioconsuntivo_S_cassa',null,null,null,null,'S','Parametro che gestisce la visualizzazione del nome dell''università (S = Visualizza, N = Non Visualizza)')
IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'MostraLogo' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('MostraLogo','bilancioconsuntivo_S_cassa',null,null,null,null,'S','Parametro che gestisce la visualizzazione del logo dell''università (S = Visualizza, N = Non Visualizza)')
IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'MostraNomeDipartimento' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('MostraNomeDipartimento','bilancioconsuntivo_S_cassa',null,null,null,null,'S','Parametro che gestisce la visualizzazione del nome dell''ente (S = Visualizza, N = Non Visualizza)')
/*IF not exists(SELECT * FROM [reportadditionalparam] WHERE paramname = 'MostraScambioCol8Con5' AND reportname = 'bilancioconsuntivo_S_cassa')
INSERT INTO [reportadditionalparam] (paramname,reportname,ct,cu,lt,lu,paramvalue,title) VALUES ('MostraScambioCol8Con5','bilancioconsuntivo_S_cassa',null,null,null,null,'N','Parametro che gestisce la visualizzazione della differenza tra le colonne 5 e 8 (S = Visualizza (8-5), N = Visualizza (5-8))')
*/
GO

-- FINE GENERAZIONE SCRIPT --





