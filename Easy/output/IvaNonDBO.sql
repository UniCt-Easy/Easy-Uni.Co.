
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



-- GENERAZIONE DATI PER invoicekindregisterkind --
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('1','5',{ts '2006-01-11 16:33:25.607'},'Software and more',{ts '2006-01-11 16:33:25.607'},'Software and more')
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('2','4',{ts '2005-11-30 14:04:58.717'},'Software and more',{ts '2005-11-30 14:04:58.717'},'Software and more')
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('3','6',{ts '2006-03-20 15:44:18.650'},'Software and more',{ts '2006-03-20 15:44:18.650'},'Software and more')
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('4','4',{ts '2006-03-20 15:44:29.573'},'Software and more',{ts '2006-03-20 15:44:29.573'},'Software and more')
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('5','5',{ts '2006-03-20 15:44:26.213'},'Software and more',{ts '2006-03-20 15:44:26.213'},'Software and more')
INSERT INTO [invoicekindregisterkind] (idinvkind,idivaregisterkind,ct,cu,lt,lu) VALUES ('6','6',{ts '2006-03-20 15:44:34.823'},'Software and more',{ts '2006-03-20 15:44:34.823'},'Software and more')
GO


-- GENERAZIONE DATI PER iva_mixed --
INSERT INTO [iva_mixed] (nmixed,ayear,lt,lu,mixed) VALUES ('1','2005',{ts '2005-12-09 10:01:45.517'},'Software and more','0.02')
GO


-- GENERAZIONE DATI PER iva_prorata --
INSERT INTO [iva_prorata] (nprorata,ayear,lt,lu,prorata) VALUES ('1','2005',{ts '2005-12-09 10:01:53.467'},'Software and more','0.8')
GO


-- GENERAZIONE DATI PER invoicekind --
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('1','S',null,'07_D_ACQ_F',{ts '1998-09-18 18:22:24.190'},'Software and more','Fatt. IVA acquisti promiscui','2','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-01-13 10:19:27.093'},'Software and more',null,null,null,null)
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('2','S',null,'07_I_ACQ_F',{ts '1998-09-18 18:22:24.200'},'Software and more','Fatt. IVA acquisti commerciali','0','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-01-13 10:13:29.290'},'Software and more',null,null,null,null)
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('3','S',null,'FATVEN',{ts '2006-03-20 15:39:26.683'},'Software and more','Fattura di vendita','1','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-03-20 15:39:26.683'},'Software and more',null,null,null,null)
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('4','S',null,'NCACQCO',{ts '2006-03-20 15:42:01.353'},'Software and more','NC su Acquisti Commerciali','0','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-03-20 15:42:14.010'},'Software and more',null,null,null,null)
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('5','S',null,'NCACQPRO',{ts '2006-03-20 15:41:40.057'},'Software and more','NC su Acquisti Promiscui','2','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-03-20 15:41:40.057'},'Software and more',null,null,null,null)
INSERT INTO [invoicekind] (idinvkind,active,address,codeinvkind,ct,cu,description,flag,flag_autodocnumbering,formatstring,header,idinvkind_auto,idsor01,idsor02,idsor03,idsor04,idsor05,lt,lu,notes1,notes2,notes3,printingcode) VALUES ('6','S',null,'NCVEND',{ts '2006-03-20 15:42:55.103'},'Software and more','NC su vendita','1','S','{0:yy}/{1:d6}',null,null,null,null,null,null,null,{ts '2006-03-20 15:43:10.307'},'Software and more',null,null,null,null)
GO


-- GENERAZIONE DATI PER ivakind --
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('1','S',null,'STD_00',{ts '2006-01-01 00:00:00.000'},'Software and more','Esente Iva','7',null,{ts '2006-01-01 00:00:00.000'},'Software and more','0','0')
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('2','S',null,'STD_20',{ts '2006-01-01 00:00:00.000'},'Software and more','IVA al 20% Ordinaria','7',null,{ts '2006-01-13 10:17:40.290'},'Software and more','0.2','0')
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('3','S',null,'STD_04',{ts '2006-01-01 00:00:00.000'},'Software and more','IVA al 4%','7',null,{ts '2006-01-13 10:16:57.210'},'Software and more','0.04','0')
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('4','S',null,'STD_30',{ts '2006-01-01 00:00:00.000'},'Software and more','IVAal 10%','7',null,{ts '2006-01-13 10:17:19.733'},'Software and more','0.1','0')
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('5','S',null,'STD_NI',{ts '2006-01-13 10:27:04.103'},'Software and more','Non imponibili art. 72 ','7',null,{ts '2006-01-13 10:27:04.103'},'Software and more','0','0')
INSERT INTO [ivakind] (idivakind,active,annotations,codeivakind,ct,cu,description,flag,idivataxablekind,lt,lu,rate,unabatabilitypercentage) VALUES ('6','S',null,'STD_40',{ts '2006-01-13 10:18:55.280'},'Software and more','Operazione F.c. Iva','7',null,{ts '2006-01-13 10:18:55.280'},'Software and more','0','0')
GO


-- GENERAZIONE DATI PER ivaregisterkind --
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('1','PROT GEN',{ts '2006-01-13 11:10:56.797'},'Software and more','Protocollo generale',null,null,{ts '2006-01-13 11:10:56.797'},'Software and more','P')
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('2','ACQINTRACO',{ts '2006-01-13 11:11:50.250'},'Software and more','Registro degli acq. intracomunitari',null,null,{ts '2006-01-13 11:11:50.250'},'Software and more','A')
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('3','CORRISP',{ts '2006-01-13 11:10:29.907'},'Software and more','Registro dei corrispettivi',null,null,{ts '2006-01-13 11:10:29.907'},'Software and more','V')
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('4','ACQ',{ts '2006-01-01 00:00:00.000'},'Software and more','Registro IVA Acquisti commerciali',null,null,{ts '2006-01-11 16:30:24.157'},'Software and more','A')
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('5','ACQPROM',{ts '2006-01-11 16:28:49.247'},'Software and more','Registro IVA Acquisti promiscui',null,null,{ts '2006-01-11 16:34:05.643'},'Software and more','A')
INSERT INTO [ivaregisterkind] (idivaregisterkind,codeivaregisterkind,ct,cu,description,flagactivity,idivaregisterkindunified,lt,lu,registerclass) VALUES ('6','VEN',{ts '2006-01-01 00:00:00.000'},'Software and more','Registro IVA Vendite commerciali',null,null,{ts '2006-01-11 16:30:37.863'},'Software and more','V')
GO

-- FINE GENERAZIONE SCRIPT --

