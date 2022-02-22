
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


IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accmotivedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accmotivedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accmotivesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accmotivesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accordoscambiomidettazsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accordoscambiomidettazsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accordoscambiomisegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accordoscambiomisegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accountcoanview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accountcoanview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accreditokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('accreditokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'addresssegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('addresssegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'aoodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('aoodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'aooprincview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('aooprincview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appelloazionekinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('appelloazionekinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appellodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('appellodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appelloerogataview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('appelloerogataview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appellokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('appellokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appexceptiondefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('appexceptiondefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'apppagesdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('apppagesdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'areadidatticadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('areadidatticadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assicurazionedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('assicurazionedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'atecodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('atecodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'attivformappelloview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('attivformappelloview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'attivformgruppoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('attivformgruppoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'attivformpropedview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('attivformpropedview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'aulaseg_childview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('aulaseg_childview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'bandodsiscresitokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('bandodsiscresitokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'bandomobilitaintkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('bandomobilitaintkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'cbmesedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('cbmesedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ccnldefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ccnldefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'cefrdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('cefrdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'changeskinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('changeskinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'classescuolakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('classescuolakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'convalidakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('convalidakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'convenzionesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('convenzionesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudiodotmasview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('corsostudiodotmasview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudioingressoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('corsostudioingressoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudiostatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('corsostudiostatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'costoscontodefkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('costoscontodefkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'decadenzasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('decadenzasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('deliberapraticasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiaraltrekinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('dichiaraltrekinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiardisabilkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('dichiardisabilkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiardisabilsuppkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('dichiardisabilsuppkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiarsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('dichiarsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogannodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogannodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogdotmasview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogdotmasview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogingressoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogingressoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogoridefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogoridefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogorisceltacorsoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogorisceltacorsoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogporzannodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogporzannodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogstatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('didprogstatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'driverupbdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('driverupbdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'duratakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('duratakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'edificioseg_childview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('edificioseg_childview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'esonerocarrieraview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('esonerocarrieraview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'esonerodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('esonerodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'esonerodisabilview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('esonerodisabilview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'esonerotitolostudioview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('esonerotitolostudioview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'expenseviewdettaglio_dei_costiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('expenseviewdettaglio_dei_costiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'fonteindicebibliometricosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('fonteindicebibliometricosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_citydefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_citydefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_cityseg5view')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_cityseg5view')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_citysegchildview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_citysegchildview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_citysegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_citysegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_countrysegchildview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_countrysegchildview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_countrysegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_countrysegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_nationlingueview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_nationlingueview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_nationsegchildview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_nationsegchildview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_nationsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_nationsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'geo_regionsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('geo_regionsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'graduatoriavardefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('graduatoriavardefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'inquadramentodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('inquadramentodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'insegndefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('insegndefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'insegnintegdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('insegnintegdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'inventorytreesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('inventorytreesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizionedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionedidprogview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizionedidprogview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionedotmasview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizionedotmasview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneingressoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneingressoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneseganagstuaccview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneseganagstuaccview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneseganagstumastview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneseganagstumastview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneseganagstusingview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneseganagstusingview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneseganagstustatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneseganagstustatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizioneseganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizioneseganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizionesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionestatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('iscrizionestatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaattachsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('istanzaattachsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('istanzakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'learningagrstudsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('learningagrstudsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'locationdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('locationdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'menuwebdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('menuwebdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'nacedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('nacedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'naturagiurdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('naturagiurdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ofakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ofakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfschedastatusschedastatusview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('perfschedastatusschedastatusview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pettycashsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('pettycashsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pianostudiosegstudview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('pianostudiosegstudview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pianostudiostatusdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('pianostudiostatusdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticaseganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('praticaseganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegistabbrview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('praticasegistabbrview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegisttriview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('praticasegisttriview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'provaaulaview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('provaaulaview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'provadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('provadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'provadotmasview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('provadotmasview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'provaingressoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('provaingressoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'provastatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('provastatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'publicazdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('publicazdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'publicazdocentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('publicazdocentiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'publicazkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('publicazkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'questionariodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('questionariodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'questionariodomkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('questionariodomkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'questionariokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('questionariokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ratadefdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ratadefdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ratadefmoreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ratadefmoreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ratadefscontiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ratadefscontiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ratakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('ratakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryaddressdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryaddressdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryaddresssegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryaddresssegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryaddressuserview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryaddressuserview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryclassaziendeview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryclassaziendeview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryclassdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryclassdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryclasspersoneview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryclasspersoneview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrycoanview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registrycoanview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrydefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registrydefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryprogfinbandosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryprogfinbandosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryprogfinsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('registryprogfinsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoorasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rendicontattivitaprogettoorasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rubricaaddresstype')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rubricaaddresstype')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rubricaregistryclientiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rubricaregistryclientiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rubricaregistrydefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rubricaregistrydefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rubricaregistryrubclientiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rubricaregistryrubclientiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('saldefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sasddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sasddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sedeseg_child_aziendaview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sedeseg_child_aziendaview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sedeseg_childview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sedeseg_childview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sessionedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sessionedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sessionekinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sessionekinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sortingcoanview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sortingcoanview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentodidprogview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentodidprogview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoesitodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoesitodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoingressoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoingressoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoseganagstuaccview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoseganagstuaccview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoseganagstuconsmastview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoseganagstuconsmastview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoseganagstusingview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoseganagstusingview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoseganagstustatoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoseganagstustatoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentoseganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentoseganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentosegstudview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('sostenimentosegstudview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'stipendiokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('stipendiokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strumentofindefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('strumentofindefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('strutturadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('strutturakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaprincview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('strutturaprincview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaseg_childview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('strutturaseg_childview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'studdirittokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('studdirittokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'studprenotkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('studprenotkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tassaconfdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tassaconfdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tassaconfkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tassaconfkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tassacsingconfdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tassacsingconfdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tassaiscrizioneconfdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tassaiscrizioneconfdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tassaistanzaconfdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tassaistanzaconfdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'taxsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('taxsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tipoattformdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tipoattformdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tirociniocandidaturakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tirociniocandidaturakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tirocinioprogettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tirocinioprogettosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tirociniopropostosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tirociniopropostosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tirociniostatodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('tirociniostatodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'upbcoanview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('upbcoanview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'upbdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('upbdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('validatoridefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettokindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaseganagstusonpreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaseganagstusonpreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagstupreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagstupreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segrinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagsturinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagsturinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segpreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrystudentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrystudentiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'learningagrtrainersegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('learningagrtrainersegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionebmisegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('iscrizionebmisegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'bandomisegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('bandomisegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'settoreercsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('settoreercsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryamministrativi_personaleview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryamministrativiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryamministrativiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrydocentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrydocentiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetdiarydocview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoanagammview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoanagview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('workpackagesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettodocview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sededefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('sededefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryistitutiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryistitutiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'edificiodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('edificiodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'auladefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('auladefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryistituti_princview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryistituti_princview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudiodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('corsostudiodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegstudview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegstudview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'titolostudiodocentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('titolostudiodocentiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sostenimentosegconsview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('sostenimentosegconsview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'bandodssegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('bandodssegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiartitolo_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiartitolo_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiarisee_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiarisee_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiardisabil_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiardisabil_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiaraltrititoli_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiaraltrititoli_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiaraltre_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiaraltre_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('saldefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettocostosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettocostosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettocostosegprgview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettocostosegprgview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaeq_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaeq_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettocostosegsalview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettocostosegsalview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'protocollosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('protocollosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzasosp_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzasosp_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzarin_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzarin_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzatru_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzatru_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoorasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoorasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'dichiarkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('dichiarkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'nullaostaimm_seganagstupreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('nullaostaimm_seganagstupreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrationuserauthview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrationuserauthview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrationuserusrview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrationuserusrview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'flowchartsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('flowchartsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetdiaryorasegsalview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetdiaryorasegsalview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoorasegsalview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoorasegsalview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'nullaostaimm_seganagsturinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('nullaostaimm_seganagsturinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzacert_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzacert_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzarein_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzarein_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzapas_seganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzapas_seganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzarein_seganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzarein_seganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegistreinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegistreinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'deliberasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('deliberasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetacquiresegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetacquiresegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzarimb_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzarimb_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaconseg_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaconseg_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pagamentokindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('pagamentokindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'relatorekinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('relatorekinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tesikindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('tesikindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'appellosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('appellosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'creditosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('creditosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'expensesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('expensesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegstudelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegstudelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'itinerationsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('itinerationsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'tesikinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('tesikinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pagamentokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('pagamentokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'protocollorifkindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('protocollorifkindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'protocollodockindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('protocollodockindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegstudelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegstudelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzasegstudelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzasegstudelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('deliberapraticasegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegstuelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegstuelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzasegstuelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzasegstuelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'nullaostaimm_seganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('nullaostaimm_seganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'praticasegistpassview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('praticasegistpassview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzapas_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzapas_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaabbr_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaabbr_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzatri_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzatri_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'affidamentosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('affidamentosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'affidamentodocview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('affidamentodocview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'affidamentodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('affidamentodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'canaleerogataview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('canaleerogataview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'diderogdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('diderogdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'erogazkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('erogazkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'affidamentokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('affidamentokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontaltrokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontaltrokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudionormadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('corsostudionormadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudiolivellodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('corsostudiolivellodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'corsostudiokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('corsostudiokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'flowchartsegammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('flowchartsegammview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryuserview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryuserview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryistitutiesteriview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryistitutiesteriview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryaziendeview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryaziendeview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getdocentiperssdsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getdocentiperssdsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'attivformerogataview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('attivformerogataview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'attivformdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('attivformdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'classescuoladefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('classescuoladefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'ambitoareadiscdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('ambitoareadiscdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('didprogdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'classconsorsualedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('classconsorsualedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'aulakinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('aulakinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getcostididatticadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getcostididatticadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sasdgruppodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('sasdgruppodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'orakindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('orakindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'positionperfview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('positionperfview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfsogliadefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfsogliadefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaperfview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaperfview')
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettostatusdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettostatusdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfschedacambiostatodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfschedacambiostatodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfschedastatusdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfschedastatusdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfvalutazioneateneodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfvalutazioneateneodefaultview')
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfvalutazioneuodefaultview')
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfvalutazionepersonaledefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfvalutazionepersonaledefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettocambiostatodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettocambiostatodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'menuwebtreeview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('menuwebtreeview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettoobiettivovalutazione_altreuoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettoobiettivovalutazione_altreuoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettoobiettivovalutazione_uoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettoobiettivovalutazione_uoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'fasciaiseedefmoreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('fasciaiseedefmoreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'fasciaiseedefscontiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('fasciaiseedefscontiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'fasciaiseedefdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('fasciaiseedefdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'costoscontodefmoreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('costoscontodefmoreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'costoscontodefscontiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('costoscontodefscontiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'upbsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('upbsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getregistrydocentiamministratividefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getregistrydocentiamministratividefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettoactivitykinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettoactivitykinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettoudrmembrokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettoudrmembrokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strumentofindefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strumentofindefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'partnerkinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('partnerkinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'allegatirichiestidefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('allegatirichiestidefaultview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetdiaryorasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('assetdiaryorasegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'debitosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('debitosegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('deliberapraticasegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'pagamentosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('pagamentosegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfindicatoredefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('perfindicatoredefaultview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfstrutturauoconrespview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('perfstrutturauoconrespview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfstrutturauodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('perfstrutturauodefaultview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoorasegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('rendicontattivitaprogettoorasegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'requisitosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('requisitosegview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('saldefaultview')  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES ('validatoridefaultview')  
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getstrutturapersonaledefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getstrutturapersonaledefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'positionsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('positionsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'accordoscambiomidettsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('accordoscambiomidettsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'affidamentodocenteview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('affidamentodocenteview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettodocenteview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettodocenteview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrydocenti_docenteview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrydocenti_docenteview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetdiarydocenteview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetdiarydocenteview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'restrictedfunctionsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('restrictedfunctionsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettocostovarbudgetviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettocostovarbudgetviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettocostobudgetviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryaziende_roview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryaziende_roview')
GO
--IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'positiondefaultview')
--INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('positiondefaultview')
--GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfrequestobbunatantumdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfrequestobbindividualedefaultview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattodefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('analisiannualedefaultview')
GO

GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'inquadramentoelencoview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('inquadramentoelencoview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'sasdintegrandiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('sasdintegrandiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattoammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattoammview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getcontrattikindviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getcontrattikindviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaparentresponsabiliviewdefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaparentviewdefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaparentviewdefaultview')
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'getcontrattidefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('getcontrattidefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryuncategorizedview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryuncategorizedview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'titolokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('titolokinddefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'didprogsuddannokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('didprogsuddannokinddefaultview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'incomedefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('incomedefaultview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'contrattoprevview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('contrattoprevview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrypersoneview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrypersoneview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaperfelenchiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaperfelenchiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'afferenzastruview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('afferenzastruview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'afferenzaammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('afferenzaammview')
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfruolodefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfruolodefaultview')
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfprogettoobiettivoattivitadocentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfprogettoobiettivoattivitadocentiview')
GO


IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'perfobiettivokinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('perfobiettivokinddefaultview')
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettostatuskinddefaultview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettostatuskinddefaultview')
GO
 --insert metadatamanagedtable


IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accmotivedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accmotivedefaultview','"idaccmotive"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccmotive"' WHERE [tablename] = 'accmotivedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accmotivesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accmotivesegview','"idaccmotive"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccmotive"' WHERE [tablename] = 'accmotivesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomidettazsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accordoscambiomidettazsegview','"idaccordoscambiomi","idaccordoscambiomidettaz","idreg_aziende"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccordoscambiomi","idaccordoscambiomidettaz","idreg_aziende"' WHERE [tablename] = 'accordoscambiomidettazsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomisegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accordoscambiomisegview','"idaccordoscambiomi"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccordoscambiomi"' WHERE [tablename] = 'accordoscambiomisegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accountcoanview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accountcoanview','"idacc"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc"' WHERE [tablename] = 'accountcoanview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accreditokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accreditokinddefaultview','"idaccreditokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccreditokind"' WHERE [tablename] = 'accreditokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'addresssegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('addresssegview','"idaddress"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddress"' WHERE [tablename] = 'addresssegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'aoodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('aoodefaultview','"idaoo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaoo"' WHERE [tablename] = 'aoodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'aooprincview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('aooprincview','"idaoo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaoo"' WHERE [tablename] = 'aooprincview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appelloazionekinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appelloazionekinddefaultview','"idappelloazionekind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappelloazionekind"' WHERE [tablename] = 'appelloazionekinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appellodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appellodefaultview','"idappello"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello"' WHERE [tablename] = 'appellodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appelloerogataview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appelloerogataview','"idappello"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello"' WHERE [tablename] = 'appelloerogataview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appellokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appellokinddefaultview','"idappellokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappellokind"' WHERE [tablename] = 'appellokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appexceptiondefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appexceptiondefaultview','"idappexception"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappexception"' WHERE [tablename] = 'appexceptiondefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'apppagesdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('apppagesdefaultview','"idapppages"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idapppages"' WHERE [tablename] = 'apppagesdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'areadidatticadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('areadidatticadefaultview','"idareadidattica"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idareadidattica"' WHERE [tablename] = 'areadidatticadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryorasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiaryorasegview','"idassetdiary","idassetdiaryora","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idassetdiaryora","idworkpackage"' WHERE [tablename] = 'assetdiaryorasegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assicurazionedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assicurazionedefaultview','"idassicurazione"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassicurazione"' WHERE [tablename] = 'assicurazionedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'atecodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('atecodefaultview','"idateco"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idateco"' WHERE [tablename] = 'atecodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformappelloview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('attivformappelloview','"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"' WHERE [tablename] = 'attivformappelloview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformgruppoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('attivformgruppoview','"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"' WHERE [tablename] = 'attivformgruppoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformpropedview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('attivformpropedview','"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"' WHERE [tablename] = 'attivformpropedview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'aulaseg_childview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('aulaseg_childview','"idaula","idedificio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaula","idedificio","idsede"' WHERE [tablename] = 'aulaseg_childview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'bandodsiscresitokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('bandodsiscresitokinddefaultview','"idbandodsiscresitokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandodsiscresitokind"' WHERE [tablename] = 'bandodsiscresitokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomobilitaintkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('bandomobilitaintkinddefaultview','"idbandomobilitaintkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomobilitaintkind"' WHERE [tablename] = 'bandomobilitaintkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'cbmesedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('cbmesedefaultview','"idcbmese"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcbmese"' WHERE [tablename] = 'cbmesedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ccnldefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ccnldefaultview','"idccnl"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idccnl"' WHERE [tablename] = 'ccnldefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'cefrdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('cefrdefaultview','"idcefr"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcefr"' WHERE [tablename] = 'cefrdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'changeskinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('changeskinddefaultview','"idchangeskind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idchangeskind"' WHERE [tablename] = 'changeskinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'classescuolakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('classescuolakinddefaultview','"idclassescuolakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idclassescuolakind"' WHERE [tablename] = 'classescuolakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('convalidakinddefaultview','"idconvalidakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idconvalidakind"' WHERE [tablename] = 'convalidakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'convenzionesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('convenzionesegview','"idconvenzione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idconvenzione","idreg"' WHERE [tablename] = 'convenzionesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiodotmasview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiodotmasview','"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudiodotmasview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudioingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudioingressoview','"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudioingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiostatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiostatoview','"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudiostatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'costoscontodefkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('costoscontodefkinddefaultview','"idcostoscontodefkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodefkind"' WHERE [tablename] = 'costoscontodefkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'decadenzasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('decadenzasegview','"iddecadenza","idiscrizione","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddecadenza","idiscrizione","idreg_studenti"' WHERE [tablename] = 'decadenzasegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('deliberapraticasegview','"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'deliberapraticasegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiaraltrekinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiaraltrekinddefaultview','"iddichiaraltrekind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiaraltrekind"' WHERE [tablename] = 'dichiaraltrekinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiardisabilkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiardisabilkinddefaultview','"iddichiardisabilkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiardisabilkind"' WHERE [tablename] = 'dichiardisabilkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiardisabilsuppkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiardisabilsuppkinddefaultview','"iddichiardisabilsuppkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiardisabilsuppkind"' WHERE [tablename] = 'dichiardisabilsuppkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiarsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiarsegview','"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiarsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogannodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogannodefaultview','"aa","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori"' WHERE [tablename] = 'didprogannodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogdotmasview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogdotmasview','"idcorsostudio","iddidprog"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog"' WHERE [tablename] = 'didprogdotmasview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogingressoview','"idcorsostudio","iddidprog"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog"' WHERE [tablename] = 'didprogingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogoridefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogoridefaultview','"idcorsostudio","iddidprog","iddidprogcurr","iddidprogori"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","iddidprogcurr","iddidprogori"' WHERE [tablename] = 'didprogoridefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogorisceltacorsoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogorisceltacorsoview','"idcorsostudio","iddidprog","iddidprogcurr","iddidprogori"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","iddidprogcurr","iddidprogori"' WHERE [tablename] = 'didprogorisceltacorsoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogporzannodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogporzannodefaultview','"aa","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"' WHERE [tablename] = 'didprogporzannodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogstatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogstatoview','"idcorsostudio","iddidprog"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog"' WHERE [tablename] = 'didprogstatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'driverupbdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('driverupbdefaultview','"iddriverupb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddriverupb"' WHERE [tablename] = 'driverupbdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'duratakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('duratakinddefaultview','"idduratakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idduratakind"' WHERE [tablename] = 'duratakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'edificioseg_childview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('edificioseg_childview','"idedificio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idedificio","idsede"' WHERE [tablename] = 'edificioseg_childview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'esonerocarrieraview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('esonerocarrieraview','"idesonero"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idesonero"' WHERE [tablename] = 'esonerocarrieraview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'esonerodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('esonerodefaultview','"idesonero"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idesonero"' WHERE [tablename] = 'esonerodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'esonerodisabilview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('esonerodisabilview','"idesonero"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idesonero"' WHERE [tablename] = 'esonerodisabilview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'esonerotitolostudioview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('esonerotitolostudioview','"idesonero"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idesonero"' WHERE [tablename] = 'esonerotitolostudioview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'expenseviewdettaglio_dei_costiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('expenseviewdettaglio_dei_costiview','""')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '""' WHERE [tablename] = 'expenseviewdettaglio_dei_costiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'fonteindicebibliometricosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('fonteindicebibliometricosegview','"idfonteindicebibliometrico"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idfonteindicebibliometrico"' WHERE [tablename] = 'fonteindicebibliometricosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_citydefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_citydefaultview','"idcity"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcity"' WHERE [tablename] = 'geo_citydefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_cityseg5view')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_cityseg5view','"idcity"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcity"' WHERE [tablename] = 'geo_cityseg5view'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_citysegchildview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_citysegchildview','"idcity"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcity"' WHERE [tablename] = 'geo_citysegchildview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_citysegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_citysegview','"idcity"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcity"' WHERE [tablename] = 'geo_citysegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_countrysegchildview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_countrysegchildview','"idcountry"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcountry"' WHERE [tablename] = 'geo_countrysegchildview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_countrysegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_countrysegview','"idcountry"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcountry"' WHERE [tablename] = 'geo_countrysegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_nationlingueview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_nationlingueview','"idnation"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnation"' WHERE [tablename] = 'geo_nationlingueview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_nationsegchildview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_nationsegchildview','"idnation"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnation"' WHERE [tablename] = 'geo_nationsegchildview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_nationsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_nationsegview','"idnation"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnation"' WHERE [tablename] = 'geo_nationsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_regionsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_regionsegview','"idregion"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregion"' WHERE [tablename] = 'geo_regionsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'graduatoriavardefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('graduatoriavardefaultview','"idgraduatoriavar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idgraduatoriavar"' WHERE [tablename] = 'graduatoriavardefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'inquadramentodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('inquadramentodefaultview','"idcontrattokind","idinquadramento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind","idinquadramento"' WHERE [tablename] = 'inquadramentodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'insegndefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('insegndefaultview','"idinsegn"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idinsegn"' WHERE [tablename] = 'insegndefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'insegnintegdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('insegnintegdefaultview','"idinsegn","idinsegninteg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idinsegn","idinsegninteg"' WHERE [tablename] = 'insegnintegdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'inventorytreesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('inventorytreesegview','"idinv"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idinv"' WHERE [tablename] = 'inventorytreesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionebmisegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionebmisegview','"idbandomi","idiscrizionebmi","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idreg"' WHERE [tablename] = 'iscrizionebmisegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionedefaultview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizionedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionedidprogview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionedidprogview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizionedidprogview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionedotmasview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionedotmasview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizionedotmasview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneingressoview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneseganagstuaccview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneseganagstuaccview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneseganagstuaccview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneseganagstumastview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneseganagstumastview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneseganagstumastview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneseganagstusingview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneseganagstusingview','"idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneseganagstusingview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneseganagstustatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneseganagstustatoview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneseganagstustatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizioneseganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizioneseganagstuview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizioneseganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionesegview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizionesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionestatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionestatoview','"idcorsostudio","iddidprog","idiscrizione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg"' WHERE [tablename] = 'iscrizionestatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaattachsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaattachsegview','"idattach","idistanza","idistanzakind","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idattach","idistanza","idistanzakind","idreg"' WHERE [tablename] = 'istanzaattachsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzakinddefaultview','"idistanzakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanzakind"' WHERE [tablename] = 'istanzakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'learningagrstudsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('learningagrstudsegview','"idbandomi","idiscrizionebmi","idlearningagrstud","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idlearningagrstud","idreg"' WHERE [tablename] = 'learningagrstudsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'learningagrtrainersegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('learningagrtrainersegview','"idbandomi","idiscrizionebmi","idlearningagrtrainer","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idlearningagrtrainer","idreg"' WHERE [tablename] = 'learningagrtrainersegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'locationdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('locationdefaultview','"idlocation"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idlocation"' WHERE [tablename] = 'locationdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'menuwebdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('menuwebdefaultview','"idmenuweb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idmenuweb"' WHERE [tablename] = 'menuwebdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'nacedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('nacedefaultview','"idnace"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnace"' WHERE [tablename] = 'nacedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'naturagiurdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('naturagiurdefaultview','"idnaturagiur"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnaturagiur"' WHERE [tablename] = 'naturagiurdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ofakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ofakinddefaultview','"idofakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idofakind"' WHERE [tablename] = 'ofakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfschedastatusschedastatusview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfschedastatusschedastatusview','"idperfschedastatus"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfschedastatus"' WHERE [tablename] = 'perfschedastatusschedastatusview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pettycashsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pettycashsegview','"idpettycash"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpettycash"' WHERE [tablename] = 'pettycashsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pianostudiosegstudview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pianostudiosegstudview','"idcorsostudio","iddidprog","idiscrizione","idpianostudio","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idpianostudio","idreg"' WHERE [tablename] = 'pianostudiosegstudview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pianostudiostatusdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pianostudiostatusdefaultview','"idpianostudiostatus"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpianostudiostatus"' WHERE [tablename] = 'pianostudiostatusdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticaseganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticaseganagstuview','"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticaseganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegistabbrview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegistabbrview','"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegistabbrview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegisttriview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegisttriview','"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegisttriview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provaaulaview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provaaulaview','"idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprova"' WHERE [tablename] = 'provaaulaview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provadefaultview','"idappello","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello","idprova"' WHERE [tablename] = 'provadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provadotmasview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provadotmasview','"idcorsostudio","iddidprog","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idprova"' WHERE [tablename] = 'provadotmasview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provaingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provaingressoview','"idcorsostudio","iddidprog","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idprova"' WHERE [tablename] = 'provaingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provastatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provastatoview','"idcorsostudio","iddidprog","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idprova"' WHERE [tablename] = 'provastatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('publicazdefaultview','"idpublicaz"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpublicaz"' WHERE [tablename] = 'publicazdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazdocentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('publicazdocentiview','"idpublicaz"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpublicaz"' WHERE [tablename] = 'publicazdocentiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('publicazkinddefaultview','"idpublicazkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpublicazkind"' WHERE [tablename] = 'publicazkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'questionariodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('questionariodefaultview','"idquestionario"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idquestionario"' WHERE [tablename] = 'questionariodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'questionariodomkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('questionariodomkinddefaultview','"idquestionariodomkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idquestionariodomkind"' WHERE [tablename] = 'questionariodomkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'questionariokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('questionariokinddefaultview','"idquestionariokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idquestionariokind"' WHERE [tablename] = 'questionariokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ratadefdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ratadefdefaultview','"idcostoscontodef","idfasciaiseedef","idratadef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef","idratadef"' WHERE [tablename] = 'ratadefdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ratadefmoreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ratadefmoreview','"idcostoscontodef","idfasciaiseedef","idratadef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef","idratadef"' WHERE [tablename] = 'ratadefmoreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ratadefscontiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ratadefscontiview','"idcostoscontodef","idfasciaiseedef","idratadef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef","idratadef"' WHERE [tablename] = 'ratadefscontiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ratakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ratakinddefaultview','"idratakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idratakind"' WHERE [tablename] = 'ratakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaddressdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaddressdefaultview','"idaddresskind","idreg","start"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddresskind","idreg","start"' WHERE [tablename] = 'registryaddressdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaddresssegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaddresssegview','"idaddresskind","idreg","start"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddresskind","idreg","start"' WHERE [tablename] = 'registryaddresssegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaddressuserview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaddressuserview','"idaddresskind","idreg","start"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddresskind","idreg","start"' WHERE [tablename] = 'registryaddressuserview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryclassaziendeview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryclassaziendeview','"idregistryclass"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregistryclass"' WHERE [tablename] = 'registryclassaziendeview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryclassdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryclassdefaultview','"idregistryclass"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregistryclass"' WHERE [tablename] = 'registryclassdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryclasspersoneview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryclasspersoneview','"idregistryclass"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregistryclass"' WHERE [tablename] = 'registryclasspersoneview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrycoanview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrycoanview','"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrycoanview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydefaultview','"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryprogfinbandosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryprogfinbandosegview','"idreg","idregistryprogfin","idregistryprogfinbando"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg","idregistryprogfin","idregistryprogfinbando"' WHERE [tablename] = 'registryprogfinbandosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryprogfinsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryprogfinsegview','"idreg","idregistryprogfin"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg","idregistryprogfin"' WHERE [tablename] = 'registryprogfinsegview'
GO
--IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rubricaaddresstype')
--INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rubricaaddresstype','idrubricaaddresstype')
--ELSE
--UPDATE [dbo].[metadataprimarykey] SET [primarykey] = 'idrubricaaddresstype' WHERE [tablename] = 'rubricaaddresstype' 
--GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rubricaregistryclientiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rubricaregistryclientiview','"idrubricaregistry"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrubricaregistry"' WHERE [tablename] = 'rubricaregistryclientiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rubricaregistrydefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rubricaregistrydefaultview','"idrubricaregistry"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrubricaregistry"' WHERE [tablename] = 'rubricaregistrydefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rubricaregistryrubclientiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rubricaregistryrubclientiview','"idrubricaregistry"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrubricaregistry"' WHERE [tablename] = 'rubricaregistryrubclientiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('saldefaultview','"idprogetto","idsal"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idsal"' WHERE [tablename] = 'saldefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sasddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sasddefaultview','"idsasd"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsasd"' WHERE [tablename] = 'sasddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sedeseg_child_aziendaview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sedeseg_child_aziendaview','"idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsede"' WHERE [tablename] = 'sedeseg_child_aziendaview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sedeseg_childview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sedeseg_childview','"idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsede"' WHERE [tablename] = 'sedeseg_childview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sessionedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sessionedefaultview','"idsessione"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsessione"' WHERE [tablename] = 'sessionedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sessionekinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sessionekinddefaultview','"idsessionekind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsessionekind"' WHERE [tablename] = 'sessionekinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sortingcoanview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sortingcoanview','"idsor"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsor"' WHERE [tablename] = 'sortingcoanview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentodefaultview','"idappello","idprova","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello","idprova","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentodidprogview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentodidprogview','"idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentodidprogview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoesitodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoesitodefaultview','"idsostenimentoesito"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsostenimentoesito"' WHERE [tablename] = 'sostenimentoesitodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoingressoview','"idcorsostudio","iddidprog","idprova","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idprova","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoseganagstuaccview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoseganagstuaccview','"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoseganagstuaccview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoseganagstuconsmastview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoseganagstuconsmastview','"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoseganagstuconsmastview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoseganagstusingview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoseganagstusingview','"idiscrizione","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idiscrizione","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoseganagstusingview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoseganagstustatoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoseganagstustatoview','"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idprova","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoseganagstustatoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentoseganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentoseganagstuview','"idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentoseganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentosegstudview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentosegstudview','"idattivform","idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idattivform","idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"' WHERE [tablename] = 'sostenimentosegstudview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendiokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('stipendiokinddefaultview','"idstipendiokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstipendiokind"' WHERE [tablename] = 'stipendiokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strumentofindefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strumentofindefaultview','"idstrumentofin"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstrumentofin"' WHERE [tablename] = 'strumentofindefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturadefaultview','"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturakinddefaultview','"idstrutturakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstrutturakind"' WHERE [tablename] = 'strutturakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaprincview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaprincview','"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaprincview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaseg_childview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaseg_childview','"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaseg_childview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'studdirittokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('studdirittokinddefaultview','"idstuddirittokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstuddirittokind"' WHERE [tablename] = 'studdirittokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'studprenotkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('studprenotkinddefaultview','"idstudprenotkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstudprenotkind"' WHERE [tablename] = 'studprenotkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tassaconfdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tassaconfdefaultview','"idtassaconf"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtassaconf"' WHERE [tablename] = 'tassaconfdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tassaconfkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tassaconfkinddefaultview','"idtassaconfkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtassaconfkind"' WHERE [tablename] = 'tassaconfkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tassacsingconfdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tassacsingconfdefaultview','"idtassacsingconf"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtassacsingconf"' WHERE [tablename] = 'tassacsingconfdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tassaiscrizioneconfdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tassaiscrizioneconfdefaultview','"idtassaiscrizioneconf"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtassaiscrizioneconf"' WHERE [tablename] = 'tassaiscrizioneconfdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tassaistanzaconfdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tassaistanzaconfdefaultview','"idtassaistanzaconf"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtassaistanzaconf"' WHERE [tablename] = 'tassaistanzaconfdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'taxsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('taxsegview','"taxcode"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"taxcode"' WHERE [tablename] = 'taxsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tipoattformdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tipoattformdefaultview','"idtipoattform"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtipoattform"' WHERE [tablename] = 'tipoattformdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tirociniocandidaturakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tirociniocandidaturakinddefaultview','"idtirociniocandidaturakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtirociniocandidaturakind"' WHERE [tablename] = 'tirociniocandidaturakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tirocinioprogettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tirocinioprogettosegview','"idreg_referente","idreg_studenti","idtirociniocandidatura","idtirocinioprogetto","idtirocinioproposto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg_referente","idreg_studenti","idtirociniocandidatura","idtirocinioprogetto","idtirocinioproposto"' WHERE [tablename] = 'tirocinioprogettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tirociniopropostosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tirociniopropostosegview','"idreg_referente","idtirocinioproposto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg_referente","idtirocinioproposto"' WHERE [tablename] = 'tirociniopropostosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tirociniostatodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tirociniostatodefaultview','"idtirociniostato"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtirociniostato"' WHERE [tablename] = 'tirociniostatodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'upbcoanview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('upbcoanview','"idupb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idupb"' WHERE [tablename] = 'upbcoanview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'upbdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('upbdefaultview','"idupb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idupb"' WHERE [tablename] = 'upbdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('validatoridefaultview','"idvalidatori"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idvalidatori"' WHERE [tablename] = 'validatoridefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagstupreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagstupreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagstupreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segrinview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segrinview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagsturinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagsturinview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagsturinview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagstuview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segpreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segpreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrystudentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrystudentiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrystudentiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryamministrativi_personaleview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryamministrativi_personaleview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryamministrativiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryamministrativiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryamministrativiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydocentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydocentiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydocentiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'settoreercsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('settoreercsegview', '"idsettoreerc"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsettoreerc"' WHERE [tablename] = 'settoreercsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiarydocview', '"idassetdiary"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary"' WHERE [tablename] = 'assetdiarydocview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettosegview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('workpackagesegview', '"idprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idworkpackage"' WHERE [tablename] = 'workpackagesegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettodocview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogettoanagview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogettoanagammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogettodocview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiarydocview', '"idassetdiary","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idworkpackage"' WHERE [tablename] = 'assetdiarydocview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sededefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sededefaultview', '"idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsede"' WHERE [tablename] = 'sededefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryistitutiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryistitutiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryistitutiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'edificiodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('edificiodefaultview', '"idedificio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idedificio","idsede"' WHERE [tablename] = 'edificiodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryistituti_princview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryistituti_princview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryistituti_princview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomisegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('bandomisegview', '"idbandomi"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi"' WHERE [tablename] = 'bandomisegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegstudview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegstudview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'pratica'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'titolostudiodocentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('titolostudiodocentiview', '"idreg","idtitolostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg","idtitolostudio"' WHERE [tablename] = 'titolostudiodocentiview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sostenimentosegconsview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sostenimentosegconsview', '"idreg","idsostenimento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg","idsostenimento"' WHERE [tablename] = 'sostenimentosegconsview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'bandodssegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('bandodssegview', '"idbandods"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandods"' WHERE [tablename] = 'bandodssegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiartitolo_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiartitolo_segview', '"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiartitolo_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiarisee_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiarisee_segview', '"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiarisee_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiardisabil_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiardisabil_segview', '"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiardisabil_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiaraltrititoli_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiaraltrititoli_segview', '"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiaraltrititoli_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiaraltre_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiaraltre_segview', '"iddichiar","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiar","idreg"' WHERE [tablename] = 'dichiaraltre_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('saldefaultview', '"idprogetto","idsal"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idsal"' WHERE [tablename] = 'saldefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaeq_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaeq_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaeq_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegsalview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegsalview', '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"' WHERE [tablename] = 'progettocosto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettodocview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('protocollosegview', '"protanno","protnumero"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"protanno","protnumero"' WHERE [tablename] = 'protocollosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzasosp_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzasosp_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzasosp_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarin_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarin_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarin_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzatru_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzatru_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzatru_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrationuserauthview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrationuserauthview', '"idregistrationuser"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregistrationuser"' WHERE [tablename] = 'registrationuserauthview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrationuserusrview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrationuserusrview', '"idregistrationuser"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idregistrationuser"' WHERE [tablename] = 'registrationuserusrview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'flowchartsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('flowchartsegview', '"idflowchart"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idflowchart"' WHERE [tablename] = 'flowchartsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'dichiarkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('dichiarkinddefaultview', '"iddichiarkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddichiarkind"' WHERE [tablename] = 'dichiarkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostaimm_seganagstupreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('nullaostaimm_seganagstupreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"' WHERE [tablename] = 'nullaostaimm_seganagstupreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostaimm_seganagsturinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('nullaostaimm_seganagsturinview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"' WHERE [tablename] = 'nullaostaimm_seganagsturinview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzacert_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzacert_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzacert_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarin_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarin_segview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarin_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarin_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarin_segview', '"iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarin_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryorasegsalview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiaryorasegsalview', '"idassetdiary","idassetdiaryora","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idassetdiaryora","idworkpackage"' WHERE [tablename] = 'assetdiaryorasegsalview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoorasegsalview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoorasegsalview', '"idrendicontattivitaprogetto","idrendicontattivitaprogettoora","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idrendicontattivitaprogettoora","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoorasegsalview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarein_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarein_segview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarein_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarein_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarein_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarein_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarein_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarein_segview', '"iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarein_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzapas_seganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzapas_seganagstuview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzapas_seganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarein_seganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarein_seganagstuview', '"iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarein_seganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegistreinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegistreinview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegistreinview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarein_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarein_segview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarein_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetacquiresegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetacquiresegview', '"nassetacquire"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"nassetacquire"' WHERE [tablename] = 'assetacquiresegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzarimb_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzarimb_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzarimb_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaconseg_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaconseg_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaconseg_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tesisegistconsview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tesisegistconsview', '"iderg","idtesi"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iderg","idtesi"' WHERE [tablename] = 'tesisegistconsview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pagamentokindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pagamentokindsegview', '"idpagamentokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpagamentokind"' WHERE [tablename] = 'pagamentokindsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'relatorekinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('relatorekinddefaultview', '"idrelatorekind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrelatorekind"' WHERE [tablename] = 'relatorekinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'relatoredefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('relatoredefaultview', '"idistanza","idreg","idrelatore","idrichitesi"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idreg","idrelatore","idrichitesi"' WHERE [tablename] = 'relatoredefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tesikindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tesikindsegview', '"idtesikind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtesikind"' WHERE [tablename] = 'tesikindsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appellosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appellosegview', '"idappello"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello"' WHERE [tablename] = 'appellosegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'creditosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('creditosegview', '"idcredito","iddebito","idpagamento","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcredito","iddebito","idpagamento","idreg"' WHERE [tablename] = 'creditosegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'expensesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('expensesegview', '"idexp"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idexp"' WHERE [tablename] = 'expensesegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'itinerationsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('itinerationsegview', '"iditineration"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iditineration"' WHERE [tablename] = 'itinerationsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'tesikinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('tesikinddefaultview', '"idtesikind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtesikind"' WHERE [tablename] = 'tesikinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pagamentokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pagamentokinddefaultview', '"idpagamentokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpagamentokind"' WHERE [tablename] = 'pagamentokinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollorifkindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('protocollorifkindsegview', '"idprotocollorifkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprotocollorifkind"' WHERE [tablename] = 'protocollorifkindsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollodockindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('protocollodockindsegview', '"idprotocollodockind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprotocollodockind"' WHERE [tablename] = 'protocollodockindsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaseganagstusonpreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaseganagstusonpreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"' WHERE [tablename] = 'istanzaseganagstusonpreview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegstudelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegstudelencoview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegstudelencoview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzasegview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"' WHERE [tablename] = 'istanzasegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzasegstudelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzasegstudelencoview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"' WHERE [tablename] = 'istanzasegstudelencoview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('deliberapraticasegview', '"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'deliberapraticasegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegstuelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegstuelencoview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegstuelencoview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzasegstuelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzasegstuelencoview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti","paridistanza"' WHERE [tablename] = 'istanzasegstuelencoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostaimm_seganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('nullaostaimm_seganagstuview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idnullaosta","idreg"' WHERE [tablename] = 'nullaostaimm_seganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'praticasegistpassview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('praticasegistpassview', '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'praticasegistpassview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzapas_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzapas_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzapas_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaabbr_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaabbr_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaabbr_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzatri_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzatri_segview', '"idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzatri_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('affidamentosegview', '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"' WHERE [tablename] = 'affidamentosegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('affidamentodocview', '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"' WHERE [tablename] = 'affidamentodocview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'erogazkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('erogazkinddefaultview', '"iderogazkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iderogazkind"' WHERE [tablename] = 'erogazkinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('affidamentokinddefaultview', '"idaffidamentokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaffidamentokind"' WHERE [tablename] = 'affidamentokinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontaltrokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontaltrokinddefaultview', '"idrendicontaltrokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontaltrokind"' WHERE [tablename] = 'rendicontaltrokinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudionormadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudionormadefaultview', '"idcorsostudionorma"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudionorma"' WHERE [tablename] = 'corsostudionormadefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiolivellodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiolivellodefaultview', '"idcorsostudiolivello"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudiolivello"' WHERE [tablename] = 'corsostudiolivellodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiokinddefaultview', '"idcorsostudiokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudiokind"' WHERE [tablename] = 'corsostudiokinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'flowchartsegammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('flowchartsegammview', '"idflowchart"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idflowchart"' WHERE [tablename] = 'flowchartsegammview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryuserview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryuserview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryuserview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryistitutiesteriview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryistitutiesteriview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryistitutiesteriview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaziendeview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaziendeview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryaziendeview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getdocentiperssdsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getdocentiperssdsegview', '"aa","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idreg"' WHERE [tablename] = 'getdocentiperssdsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'classescuoladefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('classescuoladefaultview', '"idclassescuola"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idclassescuola"' WHERE [tablename] = 'classescuoladefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'ambitoareadiscdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('ambitoareadiscdefaultview', '"idambitoareadisc"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idambitoareadisc"' WHERE [tablename] = 'ambitoareadiscdefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'classconsorsualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('classconsorsualedefaultview', '"idclassconsorsuale"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idclassconsorsuale"' WHERE [tablename] = 'classconsorsualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'aulakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('aulakinddefaultview', '"idaulakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaulakind"' WHERE [tablename] = 'aulakinddefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getcostididatticadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getcostididatticadefaultview', '"aa","idaffidamento","idcontrattokind","idcorsostudio","iddidprog","iddidprogcurr","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idcontrattokind","idcorsostudio","iddidprog","iddidprogcurr","idsede"' WHERE [tablename] = 'getcostididattica'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sasdgruppodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sasdgruppodefaultview', '"idsasdgruppo","idtipoattform"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsasdgruppo","idtipoattform"' WHERE [tablename] = 'sasdgruppodefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'orakindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('orakindsegview', '"idorakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idorakind"' WHERE [tablename] = 'orakindsegview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('validatoridefaultview', '""')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '""' WHERE [tablename] = 'validatoridefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('validatoridefaultview', '""')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '""' WHERE [tablename] = 'validatoridefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'positionperfview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('positionperfview', '"idposition"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idposition"' WHERE [tablename] = 'positionperfview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocambiostatodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocambiostatodefaultview', '"idperfprogettocambiostato"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogettocambiostato"' WHERE [tablename] = 'perfprogettocambiostato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'menuwebtreeview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('menuwebtreeview', '"idmenuweb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idmenuweb"' WHERE [tablename] = 'menuwebtreeview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'fasciaiseedefmoreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('fasciaiseedefmoreview', '"idcostoscontodef","idfasciaiseedef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef"' WHERE [tablename] = 'fasciaiseedef'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'fasciaiseedefscontiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('fasciaiseedefscontiview', '"idcostoscontodef","idfasciaiseedef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef"' WHERE [tablename] = 'fasciaiseedef'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'fasciaiseedefdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('fasciaiseedefdefaultview', '"idcostoscontodef","idfasciaiseedef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef","idfasciaiseedef"' WHERE [tablename] = 'fasciaiseedef'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'costoscontodefmoreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('costoscontodefmoreview', '"idcostoscontodef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef"' WHERE [tablename] = 'costoscontodefmoreview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'costoscontodefscontiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('costoscontodefscontiview', '"idcostoscontodef"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcostoscontodef"' WHERE [tablename] = 'costoscontodefscontiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'upbsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('upbsegview', '"idupb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idupb"' WHERE [tablename] = 'upbsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getregistrydocentiamministratividefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getregistrydocentiamministratividefaultview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'getregistrydocentiamministratividefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetsegview', '"idasset","idpiece"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idasset","idpiece"' WHERE [tablename] = 'assetsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoactivitykinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettoactivitykinddefaultview', '"idprogettoactivitykind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettoactivitykind"' WHERE [tablename] = 'progettoactivitykinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoudrmembrokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettoudrmembrokinddefaultview', '"idprogettoudrmembrokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettoudrmembrokind"' WHERE [tablename] = 'progettoudrmembrokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivovalutazione_altreuoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettoobiettivovalutazione_altreuoview', '"idperfprogetto","idperfprogettoobiettivo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogetto","idperfprogettoobiettivo"' WHERE [tablename] = 'perfprogettoobiettivovalutazione_altreuoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivovalutazione_uoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettoobiettivovalutazione_uoview', '"idperfprogetto","idperfprogettoobiettivo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogetto","idperfprogettoobiettivo"' WHERE [tablename] = 'perfprogettoobiettivovalutazione_uoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strumentofindefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strumentofindefaultview', '"idstrumentofin"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstrumentofin"' WHERE [tablename] = 'strumentofindefaultview' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'partnerkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('partnerkinddefaultview', '"idpartnerkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpartnerkind"' WHERE [tablename] = 'partnerkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'allegatirichiestidefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('allegatirichiestidefaultview','"idallegatirichiesti"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idallegatirichiesti"' WHERE [tablename] = 'allegatirichiestidefaultview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryorasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiaryorasegview','"idassetdiary","idassetdiaryora","idworkpackage"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idassetdiaryora","idworkpackage"' WHERE [tablename] = 'assetdiaryorasegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'debitosegview')
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'debitosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('debitosegview','"iddebito","idreg"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddebito","idreg"' WHERE [tablename] = 'debitosegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberapraticasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('deliberapraticasegview','"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddelibera","iddidprog","idiscrizione","idistanza","idistanzakind","idpratica","idreg"' WHERE [tablename] = 'deliberapraticasegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pagamentosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pagamentosegview','"iddebito","idpagamento","idreg"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddebito","idpagamento","idreg"' WHERE [tablename] = 'pagamentosegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatoredefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfindicatoredefaultview','"idperfindicatore"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfindicatore"' WHERE [tablename] = 'perfindicatoredefaultview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfstrutturauoconrespview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfstrutturauoconrespview','"idperfstrutturauo","idstruttura"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfstrutturauo","idstruttura"' WHERE [tablename] = 'perfstrutturauoconrespview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfstrutturauodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfstrutturauodefaultview','"idperfstrutturauo","idstruttura"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfstrutturauo","idstruttura"' WHERE [tablename] = 'perfstrutturauodefaultview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoorasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoorasegview','"idrendicontattivitaprogetto","idrendicontattivitaprogettoora","idworkpackage"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idrendicontattivitaprogettoora","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoorasegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'requisitosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('requisitosegview','"idrequisito"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrequisito"' WHERE [tablename] = 'requisitosegview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'saldefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('saldefaultview','"idprogetto","idsal"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idsal"' WHERE [tablename] = 'saldefaultview'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'validatoridefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('validatoridefaultview','"idvalidatori"')
ELSE  UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idvalidatori"' WHERE [tablename] = 'validatoridefaultview'  
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getstrutturapersonaledefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getstrutturapersonaledefaultview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'getstrutturapersonaledefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaprincview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaprincview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaprincview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaseg_childview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaseg_childview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaseg_childview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturadefaultview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfvalutazioneuodefaultview', '"idperfprogettouo","idperfvalutazioneuo","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogettouo","idperfvalutazioneuo","idstruttura"' WHERE [tablename] = 'perfvalutazioneuodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'convenzionesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('convenzionesegview', '"idconvenzione","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idconvenzione","idreg"' WHERE [tablename] = 'convenzionesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'requisitosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('requisitosegview', '"idrequisito"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrequisito"' WHERE [tablename] = 'requisitosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'upbdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('upbdefaultview', '"idupb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idupb"' WHERE [tablename] = 'upbdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'allegatirichiestidefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('allegatirichiestidefaultview', '"idallegatirichiesti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idallegatirichiesti"' WHERE [tablename] = 'allegatirichiestidefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomisegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accordoscambiomisegview', '"idaccordoscambiomi"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccordoscambiomi"' WHERE [tablename] = 'accordoscambiomisegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'learningagrtrainersegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('learningagrtrainersegview', '"idbandomi","idiscrizionebmi","idlearningagrtrainer","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idlearningagrtrainer","idreg"' WHERE [tablename] = 'learningagrtrainersegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'learningagrstudsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('learningagrstudsegview', '"idbandomi","idiscrizionebmi","idlearningagrstud","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idlearningagrstud","idreg"' WHERE [tablename] = 'learningagrstudsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'iscrizionebmisegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('iscrizionebmisegview', '"idbandomi","idiscrizionebmi","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idbandomi","idiscrizionebmi","idreg"' WHERE [tablename] = 'iscrizionebmisegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomidettsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accordoscambiomidettsegview', '"idaccordoscambiomi","idaccordoscambiomidett","idreg_istitutiesteri"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccordoscambiomi","idaccordoscambiomidett","idreg_istitutiesteri"' WHERE [tablename] = 'accordoscambiomidettsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomidettazsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accordoscambiomidettazsegview', '"idaccordoscambiomi","idaccordoscambiomidettaz","idreg_aziende"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaccordoscambiomi","idaccordoscambiomidettaz","idreg_aziende"' WHERE [tablename] = 'accordoscambiomidettazsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'accountvardetailperfview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('accountvardetailperfview', '"idacc","idupb","nvar","rownum","yvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idupb","nvar","rownum","yvar"' WHERE [tablename] = 'accountvardetailperfview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentodocenteview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('affidamentodocenteview', '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idreg_docenti"' WHERE [tablename] = 'affidamentodocenteview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocenteview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocenteview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettodocenteview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydocenti_docenteview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydocenti_docenteview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydocenti_docenteview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarydocenteview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiarydocenteview', '"idassetdiary","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idworkpackage"' WHERE [tablename] = 'assetdiarydocenteview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'restrictedfunctionsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('restrictedfunctionsegview', '"idrestrictedfunction"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrestrictedfunction"' WHERE [tablename] = 'restrictedfunctionsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostovarbudgetviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocostovarbudgetviewdefaultview', '"idacc","idcostpartition","idinv","idupb","nvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idcostpartition","idinv","idupb","nvar"' WHERE [tablename] = 'perfprogettocostovarbudgetviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocostobudgetviewdefaultview', '"idacc","idcostpartition","idinv","idupb","nvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idcostpartition","idinv","idupb","nvar"' WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocostobudgetviewdefaultview', '"idacc","idcostpartition","idinv","idupb","yvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idcostpartition","idinv","idupb","yvar"' WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocostobudgetviewdefaultview', '"idacc","idcostpartition","idinv","idupb","nvar","rownum","yvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idcostpartition","idinv","idupb","nvar","rownum","yvar"' WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_citydefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('geo_citydefaultview', '"idcity"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcity"' WHERE [tablename] = 'geo_citydefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'addresssegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('addresssegview', '"idaddress"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddress"' WHERE [tablename] = 'addresssegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocostobudgetviewdefaultview', '"idacc","idaccmotive","idcostpartition","idinv","idupb","nvar","rownum","yvar"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idacc","idaccmotive","idcostpartition","idinv","idupb","nvar","rownum","yvar"' WHERE [tablename] = 'perfprogettocostobudgetviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaddresssegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaddresssegview', '"idaddresskind","idreg","start"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaddresskind","idreg","start"' WHERE [tablename] = 'registryaddresssegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydefaultview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'aoodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('aoodefaultview', '"idaoo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaoo"' WHERE [tablename] = 'aoodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturakinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturakinddefaultview', '"idstrutturakind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstrutturakind"' WHERE [tablename] = 'strutturakinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatoredefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfindicatoredefaultview', '"idperfindicatore"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfindicatore"' WHERE [tablename] = 'perfindicatoredefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfvalutazioneuodefaultview', '"idperfvalutazioneuo","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfvalutazioneuo","idstruttura"' WHERE [tablename] = 'perfvalutazioneuodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryaziende_roview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryaziende_roview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryaziende_roview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'naturagiurdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('naturagiurdefaultview', '"idnaturagiur"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idnaturagiur"' WHERE [tablename] = 'naturagiurdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('publicazdefaultview', '"idpublicaz"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idpublicaz"' WHERE [tablename] = 'publicazdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provaingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provaingressoview', '"idcorsostudio","iddidprog","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idprova"' WHERE [tablename] = 'provaingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogingressoview', '"idcorsostudio","iddidprog"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog"' WHERE [tablename] = 'didprogingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'provadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('provadefaultview', '"idappello","idprova"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello","idprova"' WHERE [tablename] = 'provadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudioingressoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudioingressoview', '"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudioingressoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'appellodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('appellodefaultview', '"idappello"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idappello"' WHERE [tablename] = 'appellodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'studprenotkinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('studprenotkinddefaultview', '"idstudprenotkind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstudprenotkind"' WHERE [tablename] = 'studprenotkinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettodefaultview', '"idperfprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogetto"' WHERE [tablename] = 'perfprogettodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('affidamentodefaultview', '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"' WHERE [tablename] = 'affidamentodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'canaleerogataview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('canaleerogataview', '"aa","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"' WHERE [tablename] = 'canaleerogataview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformerogataview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('attivformerogataview', '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"' WHERE [tablename] = 'attivformerogataview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('attivformdefaultview', '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idsede"' WHERE [tablename] = 'attivformdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'diderogdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('diderogdefaultview', '"aa","idcorsostudio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idcorsostudio","idsede"' WHERE [tablename] = 'diderogdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogdefaultview', '"idcorsostudio","iddidprog"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog"' WHERE [tablename] = 'didprogdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonaledefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfvalutazionepersonaledefaultview', '"idperfvalutazionepersonale","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfvalutazionepersonale","idreg"' WHERE [tablename] = 'perfvalutazionepersonaledefaultview'
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneateneodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfvalutazioneateneodefaultview', '"idperfvalutazioneateneo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfvalutazioneateneo"' WHERE [tablename] = 'perfvalutazioneateneodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocambiostatodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettocambiostatodefaultview', '"idperfprogettocambiostato"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogettocambiostato"' WHERE [tablename] = 'perfprogettocambiostatodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfvalutazioneuodefaultview', '"idperfvalutazioneuo","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfvalutazioneuo","idstruttura"' WHERE [tablename] = 'perfvalutazioneuo'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfsogliadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfsogliadefaultview', '"idperfsoglia"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfsoglia"' WHERE [tablename] = 'perfsogliadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'menuwebtreeview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('menuwebtreeview', '"idmenuweb"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idmenuweb"' WHERE [tablename] = 'menuwebtreeview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfschedacambiostatodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfschedacambiostatodefaultview', '"idperfschedacambiostato"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfschedacambiostato"' WHERE [tablename] = 'perfschedacambiostatodefaultview'
GO
--IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'positiondefaultview')
--INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('positiondefaultview', '"idposition"')
--ELSE
--UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idposition"' WHERE [tablename] = 'positiondefaultview'
--GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaperfview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaperfview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaperfview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfrequestobbunatantumdefaultview', '"idperfrequestobbunatantum","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfrequestobbunatantum","idstruttura"' WHERE [tablename] = 'perfrequestobbunatantumdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfrequestobbindividualedefaultview', '"idperfrequestobbindividuale","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfrequestobbindividuale","idreg"' WHERE [tablename] = 'perfrequestobbindividualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfschedastatusdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfschedastatusdefaultview', '"idperfschedastatus"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfschedastatus"' WHERE [tablename] = 'perfschedastatusdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettostatusdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettostatusdefaultview', '"idperfprogettostatus"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogettostatus"' WHERE [tablename] = 'perfprogettostatusdefaultview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattodefaultview', '"idcontratto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto"' WHERE [tablename] = 'contrattodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('analisiannualedefaultview', '"year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"year"' WHERE [tablename] = 'analisiannualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('pcspuntiorganicoviewdefaultview', '"idcontrattokind","year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind","year"' WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'analisiannualedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('analisiannualedefaultview', '"idanalisiannuale","year"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idanalisiannuale","year"' WHERE [tablename] = 'analisiannualedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattodefaultview', '"idcontratto","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto","idreg"' WHERE [tablename] = 'contrattodefaultview'
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattokinddefaultview', '"idcontrattokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind"' WHERE [tablename] = 'contrattokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('workpackagesegview', '"idprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idworkpackage"' WHERE [tablename] = 'workpackagesegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettosegview', '"idprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto"' WHERE [tablename] = 'progettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'auladefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('auladefaultview', '"idaula","idedificio","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idaula","idedificio","idsede"' WHERE [tablename] = 'auladefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('corsostudiodefaultview', '"idcorsostudio"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio"' WHERE [tablename] = 'corsostudiodefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberasegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('deliberasegview', '"iddelibera"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddelibera"' WHERE [tablename] = 'deliberasegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegview', '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"' WHERE [tablename] = 'progettocostosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettosegview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettosegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegprgview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegprgview', '"idprogetto","idprogettocosto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto"' WHERE [tablename] = 'progettocostosegprgview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idprogetto","idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogettoanagview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettocostosegsalview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettocostosegsalview', '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idprogettocosto","idprogettotipocosto","idworkpackage"' WHERE [tablename] = 'progettocostosegsalview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettokindsegview', '"idprogettokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettokind"' WHERE [tablename] = 'progettokindsegview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'inquadramentoelencoview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('inquadramentoelencoview', '"idcontrattokind","idinquadramento"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind","idinquadramento"' WHERE [tablename] = 'inquadramentoelencoview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'sasdintegrandiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('sasdintegrandiview', '"idsasd"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsasd"' WHERE [tablename] = 'sasdintegrandiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattoammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattoammview', '"idcontratto","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto","idreg"' WHERE [tablename] = 'contrattoammview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getcontrattikindviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getcontrattikindviewdefaultview', '"idcontrattokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontrattokind"' WHERE [tablename] = 'getcontrattikindviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaparentresponsabiliviewdefaultview', '"idperfruolo","idreg","idstruttura","idstruttura_parent"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfruolo","idreg","idstruttura","idstruttura_parent"' WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentviewdefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaparentviewdefaultview', '"idstruttura","paridstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura","paridstruttura"' WHERE [tablename] = 'strutturaparentviewdefaultview'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getcontrattidefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getcontrattidefaultview', '"idcontratto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto"' WHERE [tablename] = 'getcontrattidefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryuncategorizedview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryuncategorizedview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryuncategorizedview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'getcostididatticadefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('getcostididatticadefaultview', '"aa","idaffidamento","idcontrattokind","idcorsostudio","iddidprog","iddidprogcurr","idsede"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"aa","idaffidamento","idcontrattokind","idcorsostudio","iddidprog","iddidprogcurr","idsede"' WHERE [tablename] = 'getcostididatticadefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'titolokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('titolokinddefaultview', '"idtitolokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idtitolokind"' WHERE [tablename] = 'titolokinddefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogsuddannokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('didprogsuddannokinddefaultview', '"iddidprogsuddannokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"iddidprogsuddannokind"' WHERE [tablename] = 'didprogsuddannokinddefaultview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'incomedefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('incomedefaultview', '"idinc"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idinc"' WHERE [tablename] = 'incomedefaultview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattoprevview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('contrattoprevview', '"idcontratto","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcontratto","idreg"' WHERE [tablename] = 'contrattoprevview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrypersoneview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrypersoneview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrypersoneview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaperfelenchiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaperfelenchiview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaperfelenchiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('afferenzastruview', '"idafferenza","idreg","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idafferenza","idreg","idstruttura"' WHERE [tablename] = 'afferenzastruview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzaammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('afferenzaammview', '"idafferenza","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idafferenza","idreg"' WHERE [tablename] = 'afferenzaammview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfruolodefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfruolodefaultview', '"idperfruolo"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfruolo"' WHERE [tablename] = 'perfruolodefaultview'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivoattivitadocentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfprogettoobiettivoattivitadocentiview', '"idperfprogetto","idperfprogettoobiettivo","idperfprogettoobiettivoattivita"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfprogetto","idperfprogettoobiettivo","idperfprogettoobiettivoattivita"' WHERE [tablename] = 'perfprogettoobiettivoattivitadocentiview'
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'perfobiettivokinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('perfobiettivokinddefaultview', '"idperfobiettivokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idperfobiettivokind"' WHERE [tablename] = 'perfobiettivokinddefaultview'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettostatuskinddefaultview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettostatuskinddefaultview', '"idprogettostatuskind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettostatuskind"' WHERE [tablename] = 'progettostatuskinddefaultview'
GO
 --insert metadataprimarykey
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'accountcoanview' AND [listtype] = 'coan')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('accountcoanview', 'coan', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'accountcoanview' AND [listtype] = 'coan'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'aooprincview' AND [listtype] = 'princ')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('aooprincview', 'princ', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'aooprincview' AND [listtype] = 'princ'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'attivformappelloview' AND [listtype] = 'appello')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('attivformappelloview', 'appello', 'attivform_sortcode')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'attivform_sortcode' WHERE [tablename] = 'attivformappelloview' AND [listtype] = 'appello'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'attivformgruppoview' AND [listtype] = 'gruppo')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('attivformgruppoview', 'gruppo', 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc ' WHERE [tablename] = 'attivformgruppoview' AND [listtype] = 'gruppo'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'attivformpropedview' AND [listtype] = 'proped')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('attivformpropedview', 'proped', 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ' WHERE [tablename] = 'attivformpropedview' AND [listtype] = 'proped'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'aulaseg_childview' AND [listtype] = 'seg_child')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('aulaseg_childview', 'seg_child', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'aulaseg_childview' AND [listtype] = 'seg_child'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiodotmasview' AND [listtype] = 'dotmas')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudiodotmasview', 'dotmas', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudiodotmasview' AND [listtype] = 'dotmas'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudioingressoview' AND [listtype] = 'ingresso')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudioingressoview', 'ingresso', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudioingressoview' AND [listtype] = 'ingresso'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiostatoview' AND [listtype] = 'stato')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudiostatoview', 'stato', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudiostatoview' AND [listtype] = 'stato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogdotmasview' AND [listtype] = 'dotmas')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogdotmasview', 'dotmas', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'didprogdotmasview' AND [listtype] = 'dotmas'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogingressoview' AND [listtype] = 'ingresso')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogingressoview', 'ingresso', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'didprogingressoview' AND [listtype] = 'ingresso'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogorisceltacorsoview' AND [listtype] = 'sceltacorso')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogorisceltacorsoview', 'sceltacorso', 'didprogori_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogori_title asc ' WHERE [tablename] = 'didprogorisceltacorsoview' AND [listtype] = 'sceltacorso'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogstatoview' AND [listtype] = 'stato')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogstatoview', 'stato', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'didprogstatoview' AND [listtype] = 'stato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'edificioseg_childview' AND [listtype] = 'seg_child')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('edificioseg_childview', 'seg_child', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'edificioseg_childview' AND [listtype] = 'seg_child'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'esonerocarrieraview' AND [listtype] = 'carriera')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('esonerocarrieraview', 'carriera', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'esonerocarrieraview' AND [listtype] = 'carriera'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'esonerodisabilview' AND [listtype] = 'disabil')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('esonerodisabilview', 'disabil', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'esonerodisabilview' AND [listtype] = 'disabil'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'esonerotitolostudioview' AND [listtype] = 'titolostudio')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('esonerotitolostudioview', 'titolostudio', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'esonerotitolostudioview' AND [listtype] = 'titolostudio'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_citysegchildview' AND [listtype] = 'segchild')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_citysegchildview', 'segchild', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_citysegchildview' AND [listtype] = 'segchild'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_countrysegchildview' AND [listtype] = 'segchild')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_countrysegchildview', 'segchild', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_countrysegchildview' AND [listtype] = 'segchild'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_nationlingueview' AND [listtype] = 'lingue')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_nationlingueview', 'lingue', 'lang asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'lang asc ' WHERE [tablename] = 'geo_nationlingueview' AND [listtype] = 'lingue'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_nationsegchildview' AND [listtype] = 'segchild')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_nationsegchildview', 'segchild', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_nationsegchildview' AND [listtype] = 'segchild'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionedidprogview' AND [listtype] = 'didprog')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionedidprogview', 'didprog', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'iscrizionedidprogview' AND [listtype] = 'didprog'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionedotmasview' AND [listtype] = 'dotmas')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionedotmasview', 'dotmas', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'iscrizionedotmasview' AND [listtype] = 'dotmas'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneingressoview' AND [listtype] = 'ingresso')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneingressoview', 'ingresso', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'iscrizioneingressoview' AND [listtype] = 'ingresso'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneseganagstuaccview' AND [listtype] = 'seganagstuacc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneseganagstuaccview', 'seganagstuacc', 'iscrizione_data desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'iscrizione_data desc' WHERE [tablename] = 'iscrizioneseganagstuaccview' AND [listtype] = 'seganagstuacc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneseganagstumastview' AND [listtype] = 'seganagstumast')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneseganagstumastview', 'seganagstumast', 'iscrizione_data desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'iscrizione_data desc' WHERE [tablename] = 'iscrizioneseganagstumastview' AND [listtype] = 'seganagstumast'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneseganagstusingview' AND [listtype] = 'seganagstusing')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneseganagstusingview', 'seganagstusing', 'iscrizione_data desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'iscrizione_data desc' WHERE [tablename] = 'iscrizioneseganagstusingview' AND [listtype] = 'seganagstusing'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneseganagstustatoview' AND [listtype] = 'seganagstustato')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneseganagstustatoview', 'seganagstustato', 'iscrizione_data desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'iscrizione_data desc' WHERE [tablename] = 'iscrizioneseganagstustatoview' AND [listtype] = 'seganagstustato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizioneseganagstuview' AND [listtype] = 'seganagstu')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizioneseganagstuview', 'seganagstu', 'iscrizione_data desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'iscrizione_data desc' WHERE [tablename] = 'iscrizioneseganagstuview' AND [listtype] = 'seganagstu'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionestatoview' AND [listtype] = 'stato')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionestatoview', 'stato', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'iscrizionestatoview' AND [listtype] = 'stato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfschedastatusschedastatusview' AND [listtype] = 'schedastatus')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfschedastatusschedastatusview', 'schedastatus', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfschedastatusschedastatusview' AND [listtype] = 'schedastatus'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'provaaulaview' AND [listtype] = 'aula')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('provaaulaview', 'aula', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'provaaulaview' AND [listtype] = 'aula'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'provadotmasview' AND [listtype] = 'dotmas')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('provadotmasview', 'dotmas', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'provadotmasview' AND [listtype] = 'dotmas'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'provaingressoview' AND [listtype] = 'ingresso')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('provaingressoview', 'ingresso', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'provaingressoview' AND [listtype] = 'ingresso'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'provastatoview' AND [listtype] = 'stato')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('provastatoview', 'stato', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'provastatoview' AND [listtype] = 'stato'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrycoanview' AND [listtype] = 'coan')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrycoanview', 'coan', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'registrycoanview' AND [listtype] = 'coan'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sedeseg_child_aziendaview' AND [listtype] = 'seg_child_azienda')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sedeseg_child_aziendaview', 'seg_child_azienda', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'sedeseg_child_aziendaview' AND [listtype] = 'seg_child_azienda'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sedeseg_childview' AND [listtype] = 'seg_child')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sedeseg_childview', 'seg_child', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'sedeseg_childview' AND [listtype] = 'seg_child'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sortingcoanview' AND [listtype] = 'coan')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sortingcoanview', 'coan', 'description asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'description asc ' WHERE [tablename] = 'sortingcoanview' AND [listtype] = 'coan'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaprincview' AND [listtype] = 'princ')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaprincview', 'princ', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'strutturaprincview' AND [listtype] = 'princ'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaseg_childview' AND [listtype] = 'seg_child')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaseg_childview', 'seg_child', 'struttura_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'struttura_title asc ' WHERE [tablename] = 'strutturaseg_childview' AND [listtype] = 'seg_child'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'upbcoanview' AND [listtype] = 'coan')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('upbcoanview', 'coan', 'upb_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'upb_title asc ' WHERE [tablename] = 'upbcoanview' AND [listtype] = 'coan'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettokindsegview', 'seg', 'progettoactivitykind_title asc , title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettoactivitykind_title asc , title asc ' WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettosegview', 'seg', 'titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'titolobreve asc ' WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrystudentiview' AND [listtype] = 'studenti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrystudentiview', 'studenti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrystudentiview' AND [listtype] = 'studenti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'learningagrtrainersegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('learningagrtrainersegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'learningagrtrainersegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionebmisegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionebmisegview', 'seg', 'registry_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title asc ' WHERE [tablename] = 'iscrizionebmisegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'bandomisegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('bandomisegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'bandomisegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'settoreercsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('settoreercsegview', 'seg', 'settoreerc_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'settoreerc_sortcode desc' WHERE [tablename] = 'settoreercsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrydocentiview' AND [listtype] = 'docenti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrydocentiview', 'docenti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrydocentiview' AND [listtype] = 'docenti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('assetdiarydocview', 'doc', 'progetto_titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progetto_titolobreve asc ' WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettosegview', 'seg', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoanagammview' AND [listtype] = 'anagamm')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoanagammview', 'anagamm', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettoanagammview' AND [listtype] = 'anagamm'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoanagview' AND [listtype] = 'anag')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoanagview', 'anag', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettoanagview' AND [listtype] = 'anag'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'workpackagesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('workpackagesegview', 'seg', 'raggruppamento asc , workpackage_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'raggruppamento asc , workpackage_title asc ' WHERE [tablename] = 'workpackagesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettodocview', 'doc', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sededefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sededefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'sededefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryistitutiview' AND [listtype] = 'istituti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryistitutiview', 'istituti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryistitutiview' AND [listtype] = 'istituti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'edificiodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('edificiodefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'edificiodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'auladefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('auladefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'auladefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryistituti_princview' AND [listtype] = 'istituti_princ')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryistituti_princview', 'istituti_princ', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryistituti_princview' AND [listtype] = 'istituti_princ'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'contrattokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('contrattokinddefaultview', 'default', 'contrattokind_active desc, title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'contrattokind_active desc, title asc ' WHERE [tablename] = 'contrattokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudiodefaultview', 'default', 'title asc , corsostudio_annoistituz asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , corsostudio_annoistituz asc ' WHERE [tablename] = 'corsostudiodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'praticasegstudview' AND [listtype] = 'segstud')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('praticasegstudview', 'segstud', 'registry_title desc, didprog_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc, didprog_title desc' WHERE [tablename] = 'praticasegstudview' AND [listtype] = 'segstud'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'bandodssegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('bandodssegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'bandodssegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'dichiaraltrititoli_segview' AND [listtype] = 'altrititoli_seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('dichiaraltrititoli_segview', 'altrititoli_seg', 'dichiar_altrititoli_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'dichiar_altrititoli_title desc' WHERE [tablename] = 'dichiaraltrititoli_segview' AND [listtype] = 'altrititoli_seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('saldefaultview', 'default', 'start asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'start asc ' WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettocostosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettocostosegview', 'seg', 'progettotipocosto_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettotipocosto_title asc ' WHERE [tablename] = 'progettocostosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettocostosegprgview' AND [listtype] = 'segprg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettocostosegprgview', 'segprg', 'progettotipocosto_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettotipocosto_title asc ' WHERE [tablename] = 'progettocostosegprgview' AND [listtype] = 'segprg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettocostosegprgview' AND [listtype] = 'segprg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettocostosegprgview', 'segprg', 'workpackage_raggruppamento asc , workpackage_title asc , progettotipocosto_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'workpackage_raggruppamento asc , workpackage_title asc , progettotipocosto_title asc ' WHERE [tablename] = 'progettocostosegprgview' AND [listtype] = 'segprg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettocostosegsalview' AND [listtype] = 'segsal')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettocostosegsalview', 'segsal', 'progettotipocosto_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettotipocosto_title asc ' WHERE [tablename] = 'progettocostosegsalview' AND [listtype] = 'segsal'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoorasegview', 'seg', 'rendicontattivitaprogettoora_data asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogettoora_data asc ' WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrationuserauthview' AND [listtype] = 'auth')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrationuserauthview', 'auth', 'surname asc , registrationuser_forename asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'surname asc , registrationuser_forename asc ' WHERE [tablename] = 'registrationuserauthview' AND [listtype] = 'auth'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrationuserusrview' AND [listtype] = 'usr')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrationuserusrview', 'usr', 'surname asc , registrationuser_forename asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'surname asc , registrationuser_forename asc ' WHERE [tablename] = 'registrationuserusrview' AND [listtype] = 'usr'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'flowchartsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('flowchartsegview', 'seg', 'codeflowchart asc , flowchart_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'codeflowchart asc , flowchart_title desc' WHERE [tablename] = 'flowchartsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'dichiarkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('dichiarkinddefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'dichiarkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegsalview' AND [listtype] = 'segsal')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoorasegsalview', 'segsal', 'rendicontattivitaprogettoora_data asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogettoora_data asc ' WHERE [tablename] = 'rendicontattivitaprogettoorasegsalview' AND [listtype] = 'segsal'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'assetacquiresegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('assetacquiresegview', 'seg', 'description asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'description asc ' WHERE [tablename] = 'assetacquiresegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tesisegistconsview' AND [listtype] = 'segistcons')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tesisegistconsview', 'segistcons', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'tesisegistconsview' AND [listtype] = 'segistcons'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'pagamentokindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('pagamentokindsegview', 'seg', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'pagamentokindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'relatorekinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('relatorekinddefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'relatorekinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tesikindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tesikindsegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'tesikindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tesikinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tesikinddefaultview', 'default', 'title desc, tesikind_sortcode asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, tesikind_sortcode asc ' WHERE [tablename] = 'tesikinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'praticasegstudelencoview' AND [listtype] = 'segstudelenco')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('praticasegstudelencoview', 'segstudelenco', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'praticasegstudelencoview' AND [listtype] = 'segstudelenco'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'itinerationsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('itinerationsegview', 'seg', 'itineration_start asc , itineration_stop asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'itineration_start asc , itineration_stop asc ' WHERE [tablename] = 'itinerationsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'pagamentokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('pagamentokinddefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'pagamentokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'protocollorifkindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('protocollorifkindsegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'protocollorifkindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'protocollodockindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('protocollodockindsegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'protocollodockindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'praticasegstudelencoview' AND [listtype] = 'segstudelenco')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('praticasegstudelencoview', 'segstudelenco', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'praticasegstudelencoview' AND [listtype] = 'segstudelenco'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'praticasegstuelencoview' AND [listtype] = 'segstuelenco')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('praticasegstuelencoview', 'segstuelenco', 'registry_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'praticasegstuelencoview' AND [listtype] = 'segstuelenco'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentosegview', 'seg', 'affidamento_riferimento asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'affidamento_riferimento asc ' WHERE [tablename] = 'affidamentosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentodocview' AND [listtype] = 'doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentodocview', 'doc', 'affidamento_riferimento asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'affidamento_riferimento asc ' WHERE [tablename] = 'affidamentodocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentodefaultview', 'default', 'affidamento_riferimento asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'affidamento_riferimento asc ' WHERE [tablename] = 'affidamentodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'canaleerogataview' AND [listtype] = 'erogata')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('canaleerogataview', 'erogata', 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , attivform_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , attivform_title asc ' WHERE [tablename] = 'canaleerogataview' AND [listtype] = 'erogata'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'erogazkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('erogazkinddefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'erogazkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentokinddefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'affidamentokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontaltrokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontaltrokinddefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'rendicontaltrokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudionormadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudionormadefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudionormadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiolivellodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudiolivellodefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudiolivellodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('corsostudiokinddefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'corsostudiokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('flowchartsegammview', 'segamm', 'idflowchart asc , flowchart_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'idflowchart asc , flowchart_title desc' WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'contrattokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('contrattokinddefaultview', 'default', 'contrattokind_active desc, title asc , contrattokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'contrattokind_active desc, title asc , contrattokind_sortcode desc' WHERE [tablename] = 'contrattokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryuserview' AND [listtype] = 'user')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryuserview', 'user', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryuserview' AND [listtype] = 'user'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryistitutiesteriview' AND [listtype] = 'istitutiesteri')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryistitutiesteriview', 'istitutiesteri', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryistitutiesteriview' AND [listtype] = 'istitutiesteri'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryaziendeview' AND [listtype] = 'aziende')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryaziendeview', 'aziende', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryaziendeview' AND [listtype] = 'aziende'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getdocentiperssdsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getdocentiperssdsegview', 'seg', 'getdocentiperssd_costoorario asc , getdocentiperssd_oreperaacontratto asc , getdocentiperssd_oreperaaaffidamento asc , getdocentiperssd_ssd desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'getdocentiperssd_costoorario asc , getdocentiperssd_oreperaacontratto asc , getdocentiperssd_oreperaaaffidamento asc , getdocentiperssd_ssd desc' WHERE [tablename] = 'getdocentiperssdsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'attivformerogataview' AND [listtype] = 'erogata')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('attivformerogataview', 'erogata', 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ' WHERE [tablename] = 'attivformerogataview' AND [listtype] = 'erogata'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'attivformdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('attivformdefaultview', 'default', 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ' WHERE [tablename] = 'attivformdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'classescuoladefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('classescuoladefaultview', 'default', 'sigla asc , classescuola_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'sigla asc , classescuola_title asc ' WHERE [tablename] = 'classescuoladefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'ambitoareadiscdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('ambitoareadiscdefaultview', 'default', 'classescuola_sigla desc, classescuola_title desc, tipoattform_title desc, tipoattform_description desc, ambitoareadisc_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'classescuola_sigla desc, classescuola_title desc, tipoattform_title desc, tipoattform_description desc, ambitoareadisc_sortcode desc' WHERE [tablename] = 'ambitoareadiscdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogdefaultview', 'default', 'title desc, aa desc, sede_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, aa desc, sede_title desc' WHERE [tablename] = 'didprogdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentokinddefaultview', 'default', 'title asc , affidamentokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , affidamentokind_sortcode desc' WHERE [tablename] = 'affidamentokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'classconsorsualedefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('classconsorsualedefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'classconsorsualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'aulakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('aulakinddefaultview', 'default', 'title asc , aulakind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , aulakind_sortcode desc' WHERE [tablename] = 'aulakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getcostididatticadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getcostididatticadefaultview', 'default', 'getcostididattica_corsostudio asc , getcostididattica_sede asc , aa asc , aaprogrammata asc , getcostididattica_curriculum asc , getcostididattica_insegnamento asc , getcostididattica_modulo asc , getcostididattica_affidamento asc , getcostididattica_docente asc , getcostididattica_ruolo asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'getcostididattica_corsostudio asc , getcostididattica_sede asc , aa asc , aaprogrammata asc , getcostididattica_curriculum asc , getcostididattica_insegnamento asc , getcostididattica_modulo asc , getcostididattica_affidamento asc , getcostididattica_docente asc , getcostididattica_ruolo asc ' WHERE [tablename] = 'getcostididatticadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sasdgruppodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sasdgruppodefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'sasdgruppodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'orakindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('orakindsegview', 'seg', 'orakind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'orakind_sortcode desc' WHERE [tablename] = 'orakindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfcomportamentodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfcomportamentodefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfcomportamentodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaperfview' AND [listtype] = 'perf')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaperfview', 'perf', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strutturaperfview' AND [listtype] = 'perf'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettodefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettostatusdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettostatusdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettostatusdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettouomembrodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettouomembrodefaultview', 'default', 'registryamministrativi_idtitle asc , registryamministrativi_surname asc , registryamministrativi_forename asc , registryamministrativi_cf asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registryamministrativi_idtitle asc , registryamministrativi_surname asc , registryamministrativi_forename asc , registryamministrativi_cf asc ' WHERE [tablename] = 'perfprogettouomembrodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfschedastatusdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfschedastatusdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfschedastatusdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('validatoridefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('validatoridefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettouodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettouodefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettouodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'menuwebtreeview' AND [listtype] = 'tree')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('menuwebtreeview', 'tree', 'menuwebparent_label asc , menuweb_sort asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'menuwebparent_label asc , menuweb_sort asc ' WHERE [tablename] = 'menuwebtreeview' AND [listtype] = 'tree'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivovalutazione_altreuoview' AND [listtype] = 'valutazione_altreuo')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettoobiettivovalutazione_altreuoview', 'valutazione_altreuo', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettoobiettivovalutazione_altreuoview' AND [listtype] = 'valutazione_altreuo'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivovalutazione_uoview' AND [listtype] = 'valutazione_uo')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettoobiettivovalutazione_uoview', 'valutazione_uo', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettoobiettivovalutazione_uoview' AND [listtype] = 'valutazione_uo'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'costoscontodefmoreview' AND [listtype] = 'more')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('costoscontodefmoreview', 'more', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'costoscontodefmoreview' AND [listtype] = 'more'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'costoscontodefscontiview' AND [listtype] = 'sconti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('costoscontodefscontiview', 'sconti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'costoscontodefscontiview' AND [listtype] = 'sconti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettoobiettivouoviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettoobiettivopersonaleviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strumentofindefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strumentofindefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strumentofindefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'partnerkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('partnerkinddefaultview', 'default', 'title desc, partnerkind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, partnerkind_sortcode desc' WHERE [tablename] = 'partnerkinddefaultview' AND [listtype] = 'default'
GO
-------------
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'accmotivedefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('accmotivedefaultview', 'default', 'codemotive asc , accmotive_title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'codemotive asc , accmotive_title asc ' WHERE [tablename] = 'accmotivedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'accmotivesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('accmotivesegview', 'seg', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'accmotivesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'accordoscambiomisegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('accordoscambiomisegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'accordoscambiomisegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'accreditokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('accreditokinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'accreditokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'addresssegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('addresssegview', 'seg', 'description asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'description asc ' WHERE [tablename] = 'addresssegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'allegatirichiestidefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('allegatirichiestidefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'allegatirichiestidefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'aoodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('aoodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'aoodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'appelloazionekinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('appelloazionekinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'appelloazionekinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'appellokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('appellokinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'appellokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'apppagesdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('apppagesdefaultview', 'default', 'applicazione_title asc , title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'applicazione_title asc , title desc' WHERE [tablename] = 'apppagesdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'areadidatticadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('areadidatticadefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'areadidatticadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'assetsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('assetsegview', 'seg', 'dropdown_title asc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'dropdown_title asc' WHERE [tablename] = 'assetsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'atecodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('atecodefaultview', 'default', 'codice asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'codice asc ' WHERE [tablename] = 'atecodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'bandodsiscresitokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('bandodsiscresitokinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'bandodsiscresitokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'bandomobilitaintkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('bandomobilitaintkinddefaultview', 'default', 'bandomobilitaintkind_sortcode desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'bandomobilitaintkind_sortcode desc' WHERE [tablename] = 'bandomobilitaintkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'cbmesedefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('cbmesedefaultview', 'default', 'year_year desc, mese_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'year_year desc, mese_title desc' WHERE [tablename] = 'cbmesedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'ccnldefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('ccnldefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'ccnldefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'cefrdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('cefrdefaultview', 'default', 'cefr_sortcode asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'cefr_sortcode asc ' WHERE [tablename] = 'cefrdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'changeskinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('changeskinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'changeskinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'classescuolakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('classescuolakinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'classescuolakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'convalidakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('convalidakinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'convalidakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'convenzionesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('convenzionesegview', 'seg', 'registry_title desc, title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc, title desc' WHERE [tablename] = 'convenzionesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'costoscontodefkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('costoscontodefkinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'costoscontodefkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'debitosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('debitosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'debitosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'decadenzasegview' AND [listtype] = 'seg')
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'decadenzasegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('decadenzasegview', 'seg', 'registrystudenti_title asc , iscrizione_anno asc , iscrizione_iddidprog asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'registrystudenti_title asc , iscrizione_anno asc , iscrizione_iddidprog asc ' WHERE [tablename] = 'decadenzasegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'dichiaraltrekinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('dichiaraltrekinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'dichiaraltrekinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'dichiardisabilkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('dichiardisabilkinddefaultview', 'default', 'title desc, dichiardisabilkind_specification desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, dichiardisabilkind_specification desc' WHERE [tablename] = 'dichiardisabilkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'dichiardisabilsuppkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('dichiardisabilsuppkinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'dichiardisabilsuppkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogannodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogannodefaultview', 'default', 'didproganno_anno desc, aa desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'didproganno_anno desc, aa desc' WHERE [tablename] = 'didprogannodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogoridefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogoridefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'didprogoridefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogporzannodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogporzannodefaultview', 'default', 'didprogporzanno_indice desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogporzanno_indice desc' WHERE [tablename] = 'didprogporzannodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'driverupbdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('driverupbdefaultview', 'default', 'account_title asc , account_codeacc asc , account_ayear asc , upb_codeupb asc , upb_title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'account_title asc , account_codeacc asc , account_ayear asc , upb_codeupb asc , upb_title asc ' WHERE [tablename] = 'driverupbdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'duratakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('duratakinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'duratakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'esonerodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('esonerodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'esonerodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'fonteindicebibliometricosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('fonteindicebibliometricosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'fonteindicebibliometricosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_citysegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_citysegview', 'seg', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_citysegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_countrysegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_countrysegview', 'seg', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_countrysegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_nationsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_nationsegview', 'seg', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_nationsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'geo_regionsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('geo_regionsegview', 'seg', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'geo_regionsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'graduatoriavardefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('graduatoriavardefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'graduatoriavardefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'inquadramentodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('inquadramentodefaultview', 'default', 'inquadramento_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'inquadramento_title desc' WHERE [tablename] = 'inquadramentodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'insegndefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('insegndefaultview', 'default', 'denominazione asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'denominazione asc ' WHERE [tablename] = 'insegndefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'insegnintegdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('insegnintegdefaultview', 'default', 'denominazione asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'denominazione asc ' WHERE [tablename] = 'insegnintegdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'inventorytreesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('inventorytreesegview', 'seg', 'codeinv asc , inventorytree_description asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'codeinv asc , inventorytree_description asc ' WHERE [tablename] = 'inventorytreesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionedefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionedefaultview', 'default', 'registry_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title desc' WHERE [tablename] = 'iscrizionedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionesegview', 'seg', 'didprog_title desc, registry_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprog_title desc, registry_title desc' WHERE [tablename] = 'iscrizionesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'istanzakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('istanzakinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'istanzakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'locationdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('locationdefaultview', 'default', 'locationparent_description asc , description asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'locationparent_description asc , description asc ' WHERE [tablename] = 'locationdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'menuwebdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('menuwebdefaultview', 'default', 'label asc , menuweb_sort asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'label asc , menuweb_sort asc ' WHERE [tablename] = 'menuwebdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'naturagiurdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('naturagiurdefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'naturagiurdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'ofakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('ofakinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'ofakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatoredefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfindicatoredefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfindicatoredefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauoconrespview' AND [listtype] = 'conresp')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfstrutturauoconrespview', 'conresp', 'perfstrutturauo_title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'perfstrutturauo_title asc ' WHERE [tablename] = 'perfstrutturauoconrespview' AND [listtype] = 'conresp'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfstrutturauodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'perfstrutturauodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'pianostudiosegstudview' AND [listtype] = 'segstud')
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'pianostudiosegstudview' AND [listtype] = 'segstud')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('pianostudiosegstudview', 'segstud', 'aa desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'aa desc' WHERE [tablename] = 'pianostudiosegstudview' AND [listtype] = 'segstud'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'pianostudiostatusdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('pianostudiostatusdefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'pianostudiostatusdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettoactivitykinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettoactivitykinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'progettoactivitykinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettoudrmembrokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettoudrmembrokinddefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'progettoudrmembrokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'provadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('provadefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'provadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'publicazdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('publicazdefaultview', 'default', 'title asc , publicaz_title2 asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , publicaz_title2 asc ' WHERE [tablename] = 'publicazdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'publicazdocentiview' AND [listtype] = 'docenti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('publicazdocentiview', 'docenti', 'title asc , publicaz_title2 asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , publicaz_title2 asc ' WHERE [tablename] = 'publicazdocentiview' AND [listtype] = 'docenti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'publicazkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('publicazkinddefaultview', 'default', 'title desc, publicazkind_sortcode asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, publicazkind_sortcode asc ' WHERE [tablename] = 'publicazkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'questionariodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('questionariodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'questionariodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'questionariodomkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('questionariodomkinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'questionariodomkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'questionariokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('questionariokinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'questionariokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'ratakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('ratakinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'ratakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrydefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrydefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrydefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryprogfinbandosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryprogfinbandosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'registryprogfinbandosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryprogfinsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryprogfinsegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'registryprogfinsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoorasegview', 'seg', 'rendicontattivitaprogettoora_data asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogettoora_data asc ' WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'requisitosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('requisitosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'requisitosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('saldefaultview', 'default', 'start asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'start asc ' WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sasddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sasddefaultview', 'default', 'codice asc , sasd_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'codice asc , sasd_title desc' WHERE [tablename] = 'sasddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sessionekinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sessionekinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'sessionekinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sostenimentoesitodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sostenimentoesitodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'sostenimentoesitodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'stipendiokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('stipendiokinddefaultview', 'default', 'contrattokind_title asc , inquadramento_idcontrattokind asc , inquadramento_title asc , stipendiokind_scatto asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'contrattokind_title asc , inquadramento_idcontrattokind asc , inquadramento_title asc , stipendiokind_scatto asc ' WHERE [tablename] = 'stipendiokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturakinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'strutturakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'studdirittokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('studdirittokinddefaultview', 'default', 'studdirittokind_sortorder asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'studdirittokind_sortorder asc ' WHERE [tablename] = 'studdirittokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'studprenotkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('studprenotkinddefaultview', 'default', 'title desc, studprenotkind_sortorder asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, studprenotkind_sortorder asc ' WHERE [tablename] = 'studprenotkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tassaconfdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tassaconfdefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tassaconfdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tassaconfkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tassaconfkinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tassaconfkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tassaiscrizioneconfdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tassaiscrizioneconfdefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tassaiscrizioneconfdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tipoattformdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tipoattformdefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tipoattformdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tirociniocandidaturakinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tirociniocandidaturakinddefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tirociniocandidaturakinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tirocinioprogettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tirocinioprogettosegview', 'seg', 'title desc, tirocinioprogetto_description desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, tirocinioprogetto_description desc' WHERE [tablename] = 'tirocinioprogettosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tirociniopropostosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tirociniopropostosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'tirociniopropostosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'tirociniostatodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('tirociniostatodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'tirociniostatodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'upbdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('upbdefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'upbdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'upbsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('upbsegview', 'seg', 'upb_title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'upb_title desc' WHERE [tablename] = 'upbsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('validatoridefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'debitosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('debitosegview', 'seg', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'debitosegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatoredefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfindicatoredefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfindicatoredefaultview' AND [listtype] = 'default'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauoconrespview' AND [listtype] = 'conresp')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfstrutturauoconrespview', 'conresp', 'perfstrutturauo_title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'perfstrutturauo_title asc ' WHERE [tablename] = 'perfstrutturauoconrespview' AND [listtype] = 'conresp'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfstrutturauodefaultview', 'default', 'title asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'perfstrutturauodefaultview' AND [listtype] = 'default'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg')
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoorasegview', 'seg', 'rendicontattivitaprogettoora_data asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogettoora_data asc ' WHERE [tablename] = 'rendicontattivitaprogettoorasegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('saldefaultview', 'default', 'start asc ')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'start asc ' WHERE [tablename] = 'saldefaultview' AND [listtype] = 'default'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('validatoridefaultview', 'default', 'title desc')
ELSE   UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'validatoridefaultview' AND [listtype] = 'default'  
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getstrutturapersonaledefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getstrutturapersonaledefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'getstrutturapersonaledefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturadefaultview', 'default', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'strutturadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'affidamentodocenteview' AND [listtype] = 'docente')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('affidamentodocenteview', 'docente', 'affidamento_riferimento asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'affidamento_riferimento asc ' WHERE [tablename] = 'affidamentodocenteview' AND [listtype] = 'docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettodocenteview' AND [listtype] = 'docente')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettodocenteview', 'docente', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettodocenteview' AND [listtype] = 'docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrydocenti_docenteview' AND [listtype] = 'docenti_docente')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrydocenti_docenteview', 'docenti_docente', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrydocenti_docenteview' AND [listtype] = 'docenti_docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'assetdiarydocenteview' AND [listtype] = 'docente')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('assetdiarydocenteview', 'docente', 'progetto_titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progetto_titolobreve asc ' WHERE [tablename] = 'assetdiarydocenteview' AND [listtype] = 'docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('flowchartsegammview', 'segamm', 'idflowchart asc , title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'idflowchart asc , title desc' WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('flowchartsegammview', 'segamm', 'idflowchart asc , title desc, flowchart_codeflowchart asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'idflowchart asc , title desc, flowchart_codeflowchart asc ' WHERE [tablename] = 'flowchartsegammview' AND [listtype] = 'segamm'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'restrictedfunctionsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('restrictedfunctionsegview', 'seg', 'description asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'description asc ' WHERE [tablename] = 'restrictedfunctionsegview' AND [listtype] = 'seg'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strumentofindefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strumentofindefaultview', 'default', 'title desc, strumentofin_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, strumentofin_sortcode desc' WHERE [tablename] = 'strumentofindefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'flowchartsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('flowchartsegview', 'seg', 'codeflowchart asc , flowchart_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'codeflowchart asc , flowchart_title asc ' WHERE [tablename] = 'flowchartsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryaziende_roview' AND [listtype] = 'aziende_ro')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryaziende_roview', 'aziende_ro', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryaziende_roview' AND [listtype] = 'aziende_ro'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'naturagiurdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('naturagiurdefaultview', 'default', 'title desc, naturagiur_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, naturagiur_sortcode desc' WHERE [tablename] = 'naturagiurdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfprogettoobiettivouoviewdefaultview', 'default', 'perfprogettoobiettivouoview_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'perfprogettoobiettivouoview_title desc' WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfrequestobbunatantumdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'inquadramentoelencoview' AND [listtype] = 'elenco')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('inquadramentoelencoview', 'elenco', 'inquadramento_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'inquadramento_title desc' WHERE [tablename] = 'inquadramentoelencoview' AND [listtype] = 'elenco'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'sasdintegrandiview' AND [listtype] = 'integrandi')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('sasdintegrandiview', 'integrandi', 'codice asc , sasd_title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'codice asc , sasd_title desc' WHERE [tablename] = 'sasdintegrandiview' AND [listtype] = 'integrandi'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getcontrattikindviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getcontrattikindviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'getcontrattikindviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaparentresponsabiliviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strutturaparentresponsabiliviewdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentviewdefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaparentviewdefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'strutturaparentviewdefaultview' AND [listtype] = 'default'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'appelloazionekinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('appelloazionekinddefaultview', 'default', 'title asc , appelloazionekind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , appelloazionekind_sortcode desc' WHERE [tablename] = 'appelloazionekinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'appellokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('appellokinddefaultview', 'default', 'title asc , appellokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , appellokind_sortcode desc' WHERE [tablename] = 'appellokinddefaultview' AND [listtype] = 'default'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getcontrattidefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getcontrattidefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'getcontrattidefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryuncategorizedview' AND [listtype] = 'uncategorized')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryuncategorizedview', 'uncategorized', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registryuncategorizedview' AND [listtype] = 'uncategorized'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registryuncategorizedview' AND [listtype] = 'uncategorized')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registryuncategorizedview', 'uncategorized', 'title asc , registryclass_description asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , registryclass_description asc ' WHERE [tablename] = 'registryuncategorizedview' AND [listtype] = 'uncategorized'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'erogazkinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('erogazkinddefaultview', 'default', 'title asc , erogazkind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , erogazkind_sortcode desc' WHERE [tablename] = 'erogazkinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'questionariokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('questionariokinddefaultview', 'default', 'title asc , questionariokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , questionariokind_sortcode desc' WHERE [tablename] = 'questionariokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'titolokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('titolokinddefaultview', 'default', 'titolokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'titolokind_sortcode desc' WHERE [tablename] = 'titolokinddefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'areadidatticadefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('areadidatticadefaultview', 'default', 'title asc , areadidattica_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc , areadidattica_sortcode desc' WHERE [tablename] = 'areadidatticadefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'didprogsuddannokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('didprogsuddannokinddefaultview', 'default', 'didprogsuddannokind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'didprogsuddannokind_sortcode desc' WHERE [tablename] = 'didprogsuddannokinddefaultview' AND [listtype] = 'default'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'inquadramentodefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('inquadramentodefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'inquadramentodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrypersoneview' AND [listtype] = 'persone')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrypersoneview', 'persone', 'registry_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title asc ' WHERE [tablename] = 'registrypersoneview' AND [listtype] = 'persone'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaperfelenchiview' AND [listtype] = 'perfelenchi')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaperfelenchiview', 'perfelenchi', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'strutturaperfelenchiview' AND [listtype] = 'perfelenchi'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'getregistrydocentiamministratividefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('getregistrydocentiamministratividefaultview', 'default', 'surname ASC , getregistrydocentiamministrativi_forename ASC ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'surname ASC , getregistrydocentiamministrativi_forename ASC ' WHERE [tablename] = 'getregistrydocentiamministratividefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrationuserusrview' AND [listtype] = 'usr')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrationuserusrview', 'usr', 'surname asc , forename asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'surname asc , forename asc ' WHERE [tablename] = 'registrationuserusrview' AND [listtype] = 'usr'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022


IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'perfobiettivokinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('perfobiettivokinddefaultview', 'default', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'perfobiettivokinddefaultview' AND [listtype] = 'default'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettostatuskinddefaultview' AND [listtype] = 'default')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettostatuskinddefaultview', 'default', 'title desc, progettostatuskind_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc, progettostatuskind_sortcode desc' WHERE [tablename] = 'progettostatuskinddefaultview' AND [listtype] = 'default'
GO
 --insert metadatasorting
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'accmotivesegview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('accmotivesegview','seg','not exists( select x.idaccmotive from accmotive x where x.paridaccmotive = idaccmotive) and idaccmotive in (Select AEO.idaccmotive from accmotiveepoperation AEO where AEO.idaccmotive = idaccmotive AND  AEO.idepoperation IN (''fatacq'',''fatven'',''fondoeco'',''missioni'',''dipen'',''prestocc'',''cococo'',''prestprof'',''spesaocc'',''spesaprof''))')
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'not exists( select x.idaccmotive from accmotive x where x.paridaccmotive = idaccmotive) and idaccmotive in (Select AEO.idaccmotive from accmotiveepoperation AEO where AEO.idaccmotive = idaccmotive AND  AEO.idepoperation IN (''fatacq'',''fatven'',''fondoeco'',''missioni'',''dipen'',''prestocc'',''cococo'',''prestprof'',''spesaocc'',''spesaprof''))' WHERE [tablename] = 'accmotivesegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'addresssegview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('addresssegview','seg','address_active = ''Si''')
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'address_active = ''Si''' WHERE [tablename] = 'addresssegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiodotmasview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('corsostudiodotmasview','dotmas','corsostudio_idcorsostudiokind = 2')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'corsostudio_idcorsostudiokind = 2' WHERE [tablename] = 'corsostudiodotmasview' AND [listtype] = 'dotmas'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudioingressoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('corsostudioingressoview','ingresso','corsostudio_idcorsostudiokind = 12')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'corsostudio_idcorsostudiokind = 12' WHERE [tablename] = 'corsostudioingressoview' AND [listtype] = 'ingresso'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiostatoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('corsostudiostatoview','stato','corsostudio_idcorsostudiokind = 13')  
ELSE 
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'corsostudio_idcorsostudiokind = 13' WHERE [tablename] = 'corsostudiostatoview' AND [listtype] = 'stato' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogdotmasview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('didprogdotmasview','dotmas','(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))' WHERE [tablename] = 'didprogdotmasview' AND [listtype] = 'dotmas'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogingressoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('didprogingressoview','ingresso','(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))')  
ELSE 
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))' WHERE [tablename] = 'didprogingressoview' AND [listtype] = 'ingresso'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogstatoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('didprogstatoview','stato','(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))' WHERE [tablename] = 'didprogstatoview' AND [listtype] = 'stato'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizionedotmasview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizionedotmasview','dotmas','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))' WHERE [tablename] = 'iscrizionedotmasview' AND [listtype] = 'dotmas' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneingressoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneingressoview','ingresso','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))' WHERE [tablename] = 'iscrizioneingressoview' AND [listtype] = 'ingresso'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneseganagstuaccview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneseganagstuaccview','seganagstuacc','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 12))' WHERE [tablename] = 'iscrizioneseganagstuaccview' AND [listtype] = 'seganagstuacc'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneseganagstumastview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneseganagstumastview','seganagstumast','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 2))' WHERE [tablename] = 'iscrizioneseganagstumastview' AND [listtype] = 'seganagstumast' 
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneseganagstusingview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneseganagstusingview','seganagstusing','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (12,13,2)))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (12,13,2)))' WHERE [tablename] = 'iscrizioneseganagstusingview' AND [listtype] = 'seganagstusing'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneseganagstustatoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneseganagstustatoview','seganagstustato','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))' WHERE [tablename] = 'iscrizioneseganagstustatoview' AND [listtype] = 'seganagstustato'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizioneseganagstuview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizioneseganagstuview','seganagstu','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (12,13,2)))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (12,13,2)))' WHERE [tablename] = 'iscrizioneseganagstuview' AND [listtype] = 'seganagstu'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'iscrizionestatoview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('iscrizionestatoview','stato','iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))' WHERE [tablename] = 'iscrizionestatoview' AND [listtype] = 'stato'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'taxsegview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('taxsegview','seg','tax_taxkind IN (2,3,4)')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'tax_taxkind IN (2,3,4)' WHERE [tablename] = 'taxsegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'upbsegview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('upbsegview','seg','not exists (select x.idupb from amministrazione.upb x where x.paridupb = idupb)')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'not exists (select x.idupb from amministrazione.upb x where x.paridupb = idupb)' WHERE [tablename] = 'upbsegview' AND [listtype] = 'seg'  
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segrinview', 'imm_segrin', 'idistanzakind= 15')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind= 15' WHERE [tablename] = 'istanzaimm_segrinview' AND [listtype] = 'imm_segrin'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segview', 'imm_seg', 'idistanzakind = 14')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind = 14' WHERE [tablename] = 'istanzaimm_segview' AND [listtype] = 'imm_seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segpreview', 'imm_segpre', 'idistanzakind = 13')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind = 13' WHERE [tablename] = 'istanzaimm_segpreview' AND [listtype] = 'imm_segpre'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registryamministrativi_personaleview', 'amministrativi_personale', '(idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg=''{usr$idreg}'')' WHERE [tablename] = 'registryamministrativi_personaleview' AND [listtype] = 'amministrativi_personale'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('assetdiarydocview', 'doc', '(assetdiary_idreg =''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(assetdiary_idreg =''{usr$idreg}'')' WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('rendicontattivitaprogettodocview', 'doc', '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')' WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'sededefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('sededefaultview', 'default', 'sede_idreg = (SELECT top(1) idreg from istitutoprinc)')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'sede_idreg = (SELECT top(1) idreg from istitutoprinc)' WHERE [tablename] = 'sededefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryistituti_princview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registryistituti_princview', 'istituti_princ', 'idreg = (SELECT top(1) idreg from istitutoprinc)')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg = (SELECT top(1) idreg from istitutoprinc)' WHERE [tablename] = 'registryistituti_princview' AND [listtype] = 'istituti_princ'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('corsostudiodefaultview', 'default', 'corsostudio_idcorsostudiokind not in (12,13,2)')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'corsostudio_idcorsostudiokind not in (12,13,2)' WHERE [tablename] = 'corsostudiodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentodocview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('affidamentodocview', 'doc', '(idreg_docenti=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg_docenti=''{usr$idreg}'')' WHERE [tablename] = 'affidamentodocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogdefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('didprogdefaultview', 'default', '(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (2,12,13)))')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (2,12,13)))' WHERE [tablename] = 'didprogdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'costoscontodefmoreview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('costoscontodefmoreview', 'more', 'costoscontodef_idcostoscontodefkind = 3 OR costoscontodef_idcostoscontodefkind = 4')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'costoscontodef_idcostoscontodefkind = 3 OR costoscontodef_idcostoscontodefkind = 4' WHERE [tablename] = 'costoscontodefmoreview' AND [listtype] = 'more'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'costoscontodefscontiview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('costoscontodefscontiview', 'sconti', 'costoscontodef_idcostoscontodefkind = 2')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'costoscontodef_idcostoscontodefkind = 2' WHERE [tablename] = 'costoscontodefscontiview' AND [listtype] = 'sconti'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentodocenteview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('affidamentodocenteview', 'docente', '(idreg_docenti=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg_docenti=''{usr$idreg}'')' WHERE [tablename] = 'affidamentodocenteview' AND [listtype] = 'docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettodocenteview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('rendicontattivitaprogettodocenteview', 'docente', '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')' WHERE [tablename] = 'rendicontattivitaprogettodocenteview' AND [listtype] = 'docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrydocenti_docenteview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registrydocenti_docenteview', 'docenti_docente', '(idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg=''{usr$idreg}'')' WHERE [tablename] = 'registrydocenti_docenteview' AND [listtype] = 'docenti_docente'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiarydocenteview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('assetdiarydocenteview', 'docente', '(assetdiary_idreg =''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(assetdiary_idreg =''{usr$idreg}'')' WHERE [tablename] = 'assetdiarydocenteview' AND [listtype] = 'docente'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021

IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'addresssegview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('addresssegview', 'seg', 'address_active = ''S''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'address_active = ''S''' WHERE [tablename] = 'addresssegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryaziende_roview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registryaziende_roview', 'aziende_ro', 'registry_active = ''Si''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'registry_active = ''Si''' WHERE [tablename] = 'registryaziende_roview' AND [listtype] = 'aziende_ro'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbunatantumdefaultview', 'default', 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'')) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg_resp = ''{usr$idreg}'')) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbunatantumdefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbunatantumdefaultview', 'default', 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfrequestobbunatantumdefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'') and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'') and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'') or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualedefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfrequestobbindividualedefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'')) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg = ''{usr$idreg}'' and idperfruolo = ''Responsabile'')) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfrequestobbindividualedefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaledefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazionepersonaledefaultview', 'default', 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore''))) or idreg = ''{usr$idreg}''')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idreg in (select idreg from afferenza where idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore''))) or idreg = ''{usr$idreg}''' WHERE [tablename] = 'perfvalutazionepersonaledefaultview' AND [listtype] = 'default'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuodefaultview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfvalutazioneuodefaultview', 'default', 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore'')) or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idstruttura in (select idstruttura from [dbo].[strutturaparentresponsabiliview] where idreg = ''{usr$idreg}'' and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore'')) or idstruttura  in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where idreg = ''{usr$idreg}'')) )' WHERE [tablename] = 'perfvalutazioneuodefaultview' AND [listtype] = 'default'
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryuncategorizedview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registryuncategorizedview', 'uncategorized', '(idreg NOT IN (select idreg from registry_docenti) AND idreg NOT IN (select idreg from registry_amministrativi) AND idreg NOT IN (select idreg from registry_aziende) AND idreg NOT IN (select idreg from registry_studenti) AND idreg NOT IN (select idreg from registry_istituti) AND idreg NOT IN (select idreg from registry_istitutiesteri) )')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg NOT IN (select idreg from registry_docenti) AND idreg NOT IN (select idreg from registry_amministrativi) AND idreg NOT IN (select idreg from registry_aziende) AND idreg NOT IN (select idreg from registry_studenti) AND idreg NOT IN (select idreg from registry_istituti) AND idreg NOT IN (select idreg from registry_istitutiesteri) )' WHERE [tablename] = 'registryuncategorizedview' AND [listtype] = 'uncategorized'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivoattivitadocentiview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('perfprogettoobiettivoattivitadocentiview', 'docenti', '(perfprogettoobiettivoattivita_idreg =''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(perfprogettoobiettivoattivita_idreg =''{usr$idreg}'')' WHERE [tablename] = 'perfprogettoobiettivoattivitadocentiview' AND [listtype] = 'docenti'
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'upbsegview')  
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('upbsegview','seg','not exists (select x.idupb from upb x where x.paridupb = idupb)')  
ELSE  
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'not exists (select x.idupb from upb x where x.paridupb = idupb)' WHERE [tablename] = 'upbsegview' AND [listtype] = 'seg'  
GO


 --insert metadatastaticfilter 
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachkindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachkindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettosettoreercsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettosettoreercsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'settoreercsegprogview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'settoreercsegprogview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotimesheetdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotimesheetdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotimesheetprogettodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotimesheetprogettodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettorpdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettorpdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachkindprogettostatuskinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotestokindprogettostatuskinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotestokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotestokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettobudgetsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettobudgetsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontattivitaprogettoorasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'assetdiarysegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'assetdiarysegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'assetdiaryseganagview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'assetdiaryseganagview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'sospensionedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'sospensionedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'sospensionedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'sospensionedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'sospensionedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'sospensioneedificiview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'sospensioneedificiview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'sospensioneedificiview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'sospensioneedificiview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'sospensioneedificiview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'sospensioneaulaview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'sospensioneaulaview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'sospensioneaulaview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'sospensioneaulaview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'sospensioneaulaview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'sospensioneprincview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'sospensioneprincview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'sospensioneprincview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'sospensioneprincview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'sospensioneprincview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'istitutoprincdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'istitutoprincdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'istitutoprincdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'istitutoprincdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'istitutoprincdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'corsostudiocaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiocaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiocaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiocaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'corsostudiocaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomiinsegnsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomiinsegnsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomiinsegnsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomiinsegnsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomiinsegnsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tipologiastudentesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tipologiastudentesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tipologiastudentesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tipologiastudentesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tipologiastudentesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandodsserviziosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandodsserviziosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandodsserviziosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandodsserviziosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandodsserviziosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontaltrodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontaltrodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontaltrodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontaltrodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontaltrodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'saldefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'saldefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'saldefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'saldefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'saldefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'contrattokindpositiondefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattokindpositiondefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'contrattokindpositiondefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'contrattokindpositiondefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'contrattokindpositiondefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'salprogettocostodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'salprogettocostodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'salprogettocostodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'salprogettocostodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'salprogettocostodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'salassetdiaryoradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'salassetdiaryoradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'salassetdiaryoradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'salassetdiaryoradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'salassetdiaryoradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'salrenticontattivitaprogettooradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'salrenticontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'salrenticontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'salrenticontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'salrenticontattivitaprogettooradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'salrendicontattivitaprogettooradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'salrendicontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'salrendicontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'salrendicontattivitaprogettooradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'salrendicontattivitaprogettooradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'virtualuserdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'virtualuserdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'virtualuserdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'virtualuserdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'virtualuserdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontattivitaprogettoitinerationdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoitinerationdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettoitinerationdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoitinerationdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontattivitaprogettoitinerationdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontattivitaprogettoyeardefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoyeardefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettoyeardefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoyeardefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontattivitaprogettoyeardefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'workpackageupbsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackageupbsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'workpackageupbsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'workpackageupbsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'workpackageupbsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'diniegoseganagstupreview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'diniegoseganagstupreview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'diniegoseganagstupreview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'diniegoseganagstupreview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'diniegoseganagstupreview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegisteqview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegisteqview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegisteqview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegisteqview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegisteqview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoassetdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoassetdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoassetdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoassetdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoassetdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registrationuserflowchartdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registrationuserflowchartdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrationuserflowchartdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registrationuserflowchartdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registrationuserflowchartdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registrationuserstatusdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registrationuserstatusdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrationuserstatusdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registrationuserstatusdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registrationuserstatusdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'istanzadichiarsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzadichiarsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzadichiarsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'istanzadichiarsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'istanzadichiarsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'protocollodocelementsegsonview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollodocelementsegsonview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'protocollodocelementsegsonview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'protocollodocelementsegsonview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'protocollodocelementsegsonview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegistrinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegistrinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegistrinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegistrinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegistrinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegisttruview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegisttruview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegisttruview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegisttruview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegisttruview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'diniegoseganagsturinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'diniegoseganagsturinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'diniegoseganagsturinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'diniegoseganagsturinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'diniegoseganagsturinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegistreinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegistreinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegistreinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegistreinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegistreinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'diniegosegpraticaview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'diniegosegpraticaview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'diniegosegpraticaview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'diniegosegpraticaview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'diniegosegpraticaview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegpraticaview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegpraticaview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegpraticaview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegpraticaview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegpraticaview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidantesegistreinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidantesegistreinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidantesegistreinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidantesegistreinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidantesegistreinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidasegistreinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidasegistreinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidasegistreinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidasegistreinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidasegistreinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidatosegistreinview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidatosegistreinview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidatosegistreinview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidatosegistreinview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidatosegistreinview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'nullaostasegistsospview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'nullaostasegistsospview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'nullaostasegistsospview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'nullaostasegistsospview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'nullaostasegistsospview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'deliberaistanzasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberaistanzasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'deliberaistanzasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'deliberaistanzasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'deliberaistanzasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'creditoistanza_rimbsegistrimbview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'creditoistanza_rimbsegistrimbview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'creditoistanza_rimbsegistrimbview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'creditoistanza_rimbsegistrimbview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'creditoistanza_rimbsegistrimbview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tesikeywordsegistconsview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tesikeywordsegistconsview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tesikeywordsegistconsview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tesikeywordsegistconsview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tesikeywordsegistconsview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pagamentosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pagamentosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pagamentosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pagamentosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pagamentosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'debitosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'debitosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'debitosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'debitosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'debitosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'richitesisegistconsview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'richitesisegistconsview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'richitesisegistconsview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'richitesisegistconsview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'richitesisegistconsview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tesisegistconsview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tesisegistconsview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tesisegistconsview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tesisegistconsview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tesisegistconsview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'relatoredefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'relatoredefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'relatoredefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'relatoredefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'relatoredefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'relatoresegistconsview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'relatoresegistconsview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'relatoresegistconsview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'relatoresegistconsview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'relatoresegistconsview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'protocollodocelementsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollodocelementsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'protocollodocelementsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'protocollodocelementsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'protocollodocelementsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'protocollodocsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollodocsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'protocollodocsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'protocollodocsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'protocollodocsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'protocollodestinatariosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'protocollodestinatariosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'protocollodestinatariosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'protocollodestinatariosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'protocollodestinatariosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'deliberapraticasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'deliberapraticasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'deliberapraticasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'deliberapraticasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'deliberapraticasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentocaratteristicaorasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentocaratteristicaorasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentocaratteristicaorasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentocaratteristicaorasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentocaratteristicaorasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'getprogettocostoviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'getprogettocostoviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'getprogettocostoviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'getprogettocostoviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'getprogettocostoviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettobudgetvariazionedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettobudgetvariazionedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettobudgetvariazionedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettobudgetvariazionedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettobudgetvariazionedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostotaxsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostotaxsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostotaxsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostotaxsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostotaxsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostoinventorytreesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostoinventorytreesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostoinventorytreesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostoinventorytreesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostoinventorytreesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostocontrattokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostocontrattokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostocontrattokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostocontrattokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostocontrattokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostoaccmotivesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostoaccmotivesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostoaccmotivesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostoaccmotivesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostoaccmotivesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindtaxsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindtaxsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindtaxsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindtaxsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindtaxsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindinventorytreesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindinventorytreesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindinventorytreesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindinventorytreesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindinventorytreesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindcontrattokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindcontrattokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindcontrattokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindcontrattokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindcontrattokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindaccmotivesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindaccmotivesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindaccmotivesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindaccmotivesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindaccmotivesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'lezionesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'lezionesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'lezionesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'lezionesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'lezionesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentocaratteristicasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentocaratteristicasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentocaratteristicasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentocaratteristicasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentocaratteristicasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'contrattodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'contrattodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'contrattodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'contrattodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoregistry_aziendesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoregistry_aziendesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoregistry_aziendesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoregistry_aziendesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoregistry_aziendesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoprorogasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoprorogasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoprorogasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoprorogasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoprorogasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotestosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotestosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotestosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotestosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotestosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'workpackagekindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackagekindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'workpackagekindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'workpackagekindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'workpackagekindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidatosegistpassview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidatosegistpassview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidatosegistpassview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidatosegistpassview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidatosegistpassview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidantesegistpassview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidantesegistpassview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidantesegistpassview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidantesegistpassview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidantesegistpassview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidasegistpassview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidasegistpassview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidasegistpassview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidasegistpassview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidasegistpassview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoudrmembrosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoudrmembrosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoudrmembrosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoudrmembrosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoudrmembrosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoudrsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoudrsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoudrsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoudrsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoudrsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontaltrodocview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontaltrodocview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontaltrodocview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontaltrodocview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontaltrodocview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'lezioneattivformview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'lezioneattivformview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'lezioneattivformview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'lezioneattivformview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'lezioneattivformview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'lezionerendicontview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'lezionerendicontview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'lezionerendicontview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'lezionerendicontview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'lezionerendicontview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'lezionedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'lezionedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'lezionedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'lezionedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'lezionedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convalidasegistabbrview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convalidasegistabbrview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convalidasegistabbrview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convalidasegistabbrview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convalidasegistabbrview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'flowchartusersegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'flowchartusersegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'flowchartusersegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'flowchartusersegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'flowchartusersegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'flowchartrestrictedfunctionsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'flowchartrestrictedfunctionsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'flowchartrestrictedfunctionsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'flowchartrestrictedfunctionsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'flowchartrestrictedfunctionsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'customusersegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'customusersegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'customusersegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'customusersegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'customusersegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'restrictedfunctionsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'restrictedfunctionsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'restrictedfunctionsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'restrictedfunctionsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'restrictedfunctionsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'contrattokindperiododefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'contrattokindperiododefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'contrattokindperiododefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'contrattokindperiododefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'contrattokindperiododefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registryreferenceuserview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registryreferenceuserview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryreferenceuserview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registryreferenceuserview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registryreferenceuserview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registryreferencepersoneview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registryreferencepersoneview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryreferencepersoneview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registryreferencepersoneview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registryreferencepersoneview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registryreferencesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registryreferencesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryreferencesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registryreferencesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registryreferencesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'mutuazionecaratteristicaoradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'mutuazionecaratteristicaoradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'mutuazionecaratteristicaoradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'mutuazionecaratteristicaoradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'mutuazionecaratteristicaoradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'mutuazionecaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'mutuazionecaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'mutuazionecaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'mutuazionecaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'mutuazionecaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformcaratteristicaoradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformcaratteristicaoradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformcaratteristicaoradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformcaratteristicaoradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformcaratteristicaoradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'mutuazionedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'mutuazionedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'mutuazionedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'mutuazionedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'mutuazionedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'appelloattivformseg_childview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'appelloattivformseg_childview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'appelloattivformseg_childview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'appelloattivformseg_childview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'appelloattivformseg_childview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformvalutazionekinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformvalutazionekinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformvalutazionekinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformvalutazionekinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformvalutazionekinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogcurrcaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogcurrcaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogcurrcaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogcurrcaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogcurrcaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformpropeddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformpropeddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformpropeddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformpropeddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformpropeddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformcaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformcaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformcaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformcaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformcaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogclassconsorsualedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogclassconsorsualedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogclassconsorsualedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogclassconsorsualedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogclassconsorsualedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentokindcostooradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentokindcostooradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentokindcostooradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentokindcostooradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentokindcostooradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'getcostididatticaerogataview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'getcostididatticaerogataview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'getcostididatticaerogataview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'getcostididatticaerogataview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'getcostididatticaerogataview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogcurrdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogcurrdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogcurrdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogcurrdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogcurrdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogdatepianodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogdatepianodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogdatepianodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogdatepianodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogdatepianodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprograppstuddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprograppstuddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprograppstuddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprograppstuddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprograppstuddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'corsostudioclassescuoladefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudioclassescuoladefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudioclassescuoladefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'corsostudioclassescuoladefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'corsostudioclassescuoladefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'sasdaffinidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'sasdaffinidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'sasdaffinidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'sasdaffinidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'sasdaffinidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'orakindseg_childview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'orakindseg_childview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'orakindseg_childview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'orakindseg_childview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'orakindseg_childview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfpositionsoglieindividualidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfpositionsoglieindividualidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfpositionsoglieindividualidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfpositionsoglieindividualidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfpositionsoglieindividualidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfpositioncomportamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfpositioncomportamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfpositioncomportamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfpositioncomportamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfpositioncomportamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfpositionattachdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfpositionattachdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfpositionattachdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfpositionattachdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfpositionattachdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfcomportamentosogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfcomportamentosogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfcomportamentosogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfcomportamentosogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfcomportamentosogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfsogliakinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfsogliakinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfsogliakinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfsogliakinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfsogliakinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfcomportamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfcomportamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfcomportamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfcomportamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfcomportamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfstrutturauodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfstrutturauodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfstrutturauodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfstrutturauodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfindicatoresogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatoresogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfindicatoresogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatoresogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfindicatoresogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfindicatoredefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatoredefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfindicatoredefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatoredefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfindicatoredefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfstrutturauoconrespview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfstrutturauoconrespview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfstrutturauoconrespview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturauoconrespview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfstrutturauoconrespview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettouodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettouodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettouodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettouodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettouodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettouomembrodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettouomembrodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettouomembrodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettouomembrodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettouomembrodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettocostovarbudgetdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostovarbudgetdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettocostovarbudgetdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettocostovarbudgetdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettocostovarbudgetdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettocostodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocostodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettocostodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettocostodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettocostodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoattachdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoattachdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoattachdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoattachdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoattachdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoavanzamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoavanzamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoavanzamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoavanzamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoavanzamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivoattivitadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivoattivitadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivoattivitadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivoattivitadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivoattivitadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneateneovalidatoredefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneateneovalidatoredefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneateneovalidatoredefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneateneovalidatoredefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneateneovalidatoredefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneateneoresdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneateneoresdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneateneoresdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneateneoresdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneateneoresdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'validatoridefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'validatoridefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'validatoridefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'validatoridefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'validatoridefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfmissiondefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfmissiondefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfmissiondefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfmissiondefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfmissiondefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneuoattachdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuoattachdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuoattachdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneuoattachdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneuoattachdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivoattivitaattachdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivoattivitaattachdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivoattivitaattachdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivoattivitaattachdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivoattivitaattachdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonaleattachdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonaleattachdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaleattachdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonaleattachdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonaleattachdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfindicatorekinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatorekinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfindicatorekinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatorekinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfindicatorekinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzadocview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzadocview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzadocview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzadocview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzadocview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzaammview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzaammview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzaammview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzaammview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzaammview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivosogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivosogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivosogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivosogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivosogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentocaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentocaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentocaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentocaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentocaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfruolodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfruolodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfruolodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfruolodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfruolodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivoschedauoaltreview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivoschedauoaltreview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivoschedauoaltreview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivoschedauoaltreview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivoschedauoaltreview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivoschedauoview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivoschedauoview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivoschedauoview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivoschedauoview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivoschedauoview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didproggruppdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didproggruppdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didproggruppdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didproggruppdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didproggruppdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'costoscontodefdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'costoscontodefdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'costoscontodefdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'costoscontodefdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'costoscontodefdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivouoviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivouoviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivopersonaleviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneuoindicatoridefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuoindicatoridefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuoindicatoridefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneuoindicatoridefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneuoindicatoridefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettoobiettivosogliasogliaview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettoobiettivosogliasogliaview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettoobiettivosogliasogliaview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettoobiettivosogliasogliaview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettoobiettivosogliasogliaview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonalecomportamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonalecomportamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonalecomportamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonalecomportamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonalecomportamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonaleuodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonaleuodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaleuodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonaleuodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonaleuodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonaleateneodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonaleateneodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaleateneodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonaleateneodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonaleateneodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfobiettiviuodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfobiettiviuodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfobiettiviuodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfobiettiviuodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfobiettiviuodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonaleobiettivodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonaleobiettivodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonaleobiettivodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonaleobiettivodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonaleobiettivodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonalesogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonalesogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonalesogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonalesogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonalesogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettofinanziamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettofinanziamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettofinanziamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettofinanziamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettofinanziamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomiallegatisegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomiallegatisegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomiallegatisegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomiallegatisegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomiallegatisegview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 22/06/2021
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'convenzioneattachsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'convenzioneattachsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'convenzioneattachsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'convenzioneattachsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'convenzioneattachsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomipropedeutsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomipropedeutsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomipropedeutsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomipropedeutsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomipropedeutsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomididprogfromsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomididprogfromsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomididprogfromsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomididprogfromsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomididprogfromsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'getcostoviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'getcostoviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'getcostoviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'getcostoviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'getcostoviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'cefrlanglevelaccordoscambiomidettlangview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'cefrlanglevelaccordoscambiomidettlangview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'cefrlanglevelaccordoscambiomidettlangview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'cefrlanglevelaccordoscambiomidettlangview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'cefrlanglevelaccordoscambiomidettlangview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'accordoscambiomidettsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomidettsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'accordoscambiomidettsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'accordoscambiomidettsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'accordoscambiomidettsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'accordoscambiomidettazsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomidettazsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'accordoscambiomidettazsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'accordoscambiomidettazsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'accordoscambiomidettazsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'accordoscambiomiporzannosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'accordoscambiomiporzannosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'accordoscambiomiporzannosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'accordoscambiomiporzannosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'accordoscambiomiporzannosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'cefrlangleveldefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'cefrlangleveldefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'cefrlangleveldefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'cefrlangleveldefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'cefrlangleveldefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfobiettiviuosogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfobiettiviuosogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfobiettiviuosogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfobiettiviuosogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfobiettiviuosogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'accountvardetailperfview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'accountvardetailperfview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'accountvardetailperfview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'accountvardetailperfview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'accountvardetailperfview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzadocenteview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzadocenteview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzadocenteview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzadocenteview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzadocenteview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontaltrodocenteview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontaltrodocenteview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontaltrodocenteview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontaltrodocenteview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontaltrodocenteview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registrydocenti_docview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydocenti_docview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrydocenti_docview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registrydocenti_docview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registrydocenti_docview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 12/07/2021

IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'timesheettemplatedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'timesheettemplatedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'timesheettemplatedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'timesheettemplatedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'timesheettemplatedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfinterazionekinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfinterazionekinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfinterazionekinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfinterazionekinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfinterazionekinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfinterazionidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfinterazionidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfinterazionidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfinterazionidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfinterazionidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfstrutturaperfindicatoredefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfstrutturaperfindicatoredefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfstrutturaperfindicatoredefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfstrutturaperfindicatoredefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfstrutturaperfindicatoredefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfindicatoresogliavalutazioneview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfindicatoresogliavalutazioneview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfindicatoresogliavalutazioneview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfindicatoresogliavalutazioneview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfindicatoresogliavalutazioneview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'insegnintegcaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'insegnintegcaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'insegnintegcaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'insegnintegcaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'insegnintegcaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformcaratteristicaerogataview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformcaratteristicaerogataview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformcaratteristicaerogataview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformcaratteristicaerogataview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformcaratteristicaerogataview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'canaledefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'canaledefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'canaledefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'canaledefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'canaledefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneuoindicatorisogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneuoindicatorisogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneuoindicatorisogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneuoindicatorisogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneuoindicatorisogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazionepersonalecomportamentosogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazionepersonalecomportamentosogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazionepersonalecomportamentosogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazionepersonalecomportamentosogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazionepersonalecomportamentosogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfvalutazioneateneoresvalidatoridefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfvalutazioneateneoresvalidatoridefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfvalutazioneateneoresvalidatoridefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfvalutazioneateneoresvalidatoridefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfvalutazioneateneoresvalidatoridefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'mansionekinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'mansionekinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'mansionekinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'mansionekinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'mansionekinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettocambiostatoruolomaildestdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocambiostatoruolomaildestdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettocambiostatoruolomaildestdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettocambiostatoruolomaildestdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettocambiostatoruolomaildestdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettocambiostatoperfruolomaildestview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettocambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettocambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettocambiostatoperfruolomaildestview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfschedacambiostatoperfruolomaildestview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfschedacambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfschedacambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfschedacambiostatoperfruolomaildestview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfschedacambiostatoperfruolomaildestview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfruolomaildestview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfruolomaildestview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfruolomaildestview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfruolomaildestview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfruolomaildestview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfschedacambiostatoperfruolodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfschedacambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfschedacambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfschedacambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfschedacambiostatoperfruolodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfprogettocambiostatoperfruolodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfprogettocambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfprogettocambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfprogettocambiostatoperfruolodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfprogettocambiostatoperfruolodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'mansionekindcomportamentodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'mansionekindcomportamentodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'mansionekindcomportamentodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'mansionekindcomportamentodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'mansionekindcomportamentodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfrequestobbunatantumsogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfrequestobbunatantumsogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbunatantumsogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfrequestobbunatantumsogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfrequestobbunatantumsogliadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfrequestobbindividualesogliadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfrequestobbindividualesogliadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfrequestobbindividualesogliadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfrequestobbindividualesogliadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfrequestobbindividualesogliadefaultview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/10/2021
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendioannuodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendioannuodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendioannuodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendioannuoprevview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendioannuoprevview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendioannuoprevview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcscessazionidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcscessazionidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcscessazionidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcsbilanciodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcsbilanciodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcsbilanciodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcsassunzionidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcsassunzionidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcsassunzionidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcspuntiorganicoviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcspuntiorganicoviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokindaccmotivedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokindaccmotivedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavoaccmotivesegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavoaccmotivesegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoricavodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoricavodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoricavodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavocontrattokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavocontrattokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'cedolinodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'cedolinodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'cedolinodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotiporicavokindcontrattokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotiporicavokindcontrattokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'stipendiodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'stipendiodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'stipendiodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'insegncaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'insegncaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'insegncaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'attivformcaratteristicaoraerogataview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'attivformcaratteristicaoraerogataview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'affidamentocaratteristicaoradefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'affidamentocaratteristicaoradefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tipologiastudentestrutturasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tipologiastudentestrutturasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tipologiastudentestrutturasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzastruview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzastruview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaresponsabiledefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaresponsabiledefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomistrutturetosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomistrutturetosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomistrutturetosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'bandomistrutturefromsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'bandomistrutturefromsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'bandomistrutturefromsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tirociniocandidaturasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tirociniocandidaturasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tirociniocandidaturasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'corsostudiostrutturadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'corsostudiostrutturadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'corsostudiostrutturadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissregistry_docentiingressoview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissregistry_docentiingressoview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissregistry_docentiingressoview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissregistry_docentidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissregistry_docentidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissregistry_docentidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissingressoview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissingressoview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissingressoview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'commissdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'commissdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'commissdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_docentidefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_docentidefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_docentidefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_aziendedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_aziendedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_aziendedefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'publicazregistry_docentidocentiview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'publicazregistry_docentidocentiview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'publicazregistry_docentidocentiview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogaccessodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogaccessodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogaccessodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaresponsabiledefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaresponsabiledefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaresponsabiledefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcscessazioniviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcscessazioniviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcscessazioniviewdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'afferenzastruview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'afferenzastruview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'afferenzastruview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didproggruppcaratteristicadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didproggruppcaratteristicadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'classescuolacaratteristicaclasseview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'classescuolacaratteristicaclasseview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'classescuolacaratteristicaclasseview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaparentresponsabiliafferenzaviewdefaultview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 02/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/12/2021
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 23/12/2021

IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'tipoattformsolosiglaview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'tipoattformsolosiglaview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'tipoattformsolosiglaview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'tipoattformsolosiglaview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'tipoattformsolosiglaview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'classescuolaareadefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'classescuolaareadefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'classescuolaareadefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'classescuolaareadefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'classescuolaareadefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'geo_continentdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'geo_continentdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'geo_continentdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'geo_continentdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'geo_continentdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprognumchiusokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprognumchiusokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprognumchiusokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprognumchiusokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprognumchiusokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'didprogporzannokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'didprogporzannokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'didprogporzannokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'didprogporzannokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'didprogporzannokinddefaultview'
END
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/01/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 14/01/2022


IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'registrypersoneview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'registrypersoneview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrypersoneview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'registrypersoneview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'registrypersoneview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 24/01/2022
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'pcsassunzionisimulatedefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'pcsassunzionisimulatedefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'pcsassunzionisimulatedefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'pcsassunzionisimulatedefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'pcsassunzionisimulatedefaultview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 01/02/2022
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaperfelenchiparentview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaperfelenchiparentview'
END
GO
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 08/02/2022
-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 11/02/2022
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfruoloperfobiettivokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfruoloperfobiettivokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfruoloperfobiettivokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfruoloperfobiettivokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfruoloperfobiettivokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfobiettivokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfobiettivokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfobiettivokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfobiettivokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfobiettivokinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'perfruolocontrattokinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'perfruolocontrattokinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'perfruolocontrattokinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'perfruolocontrattokinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'perfruolocontrattokinddefaultview'
END
GO

-------------DA QUA IN POI PER L'AGGIORNAMENTO SUCCESSIVO AL 16/02/2022

 --delete 
