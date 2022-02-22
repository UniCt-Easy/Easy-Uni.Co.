
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



-- GENERAZIONE DATI PER category --
INSERT INTO [category] (idcategory,active,ct,cu,description,lt,lu) VALUES ('NP','S',{ts '2006-01-01 00:00:00.000'},'Software and more','Non Protetta',{ts '2006-01-01 00:00:00.000'},'Software and more')
INSERT INTO [category] (idcategory,active,ct,cu,description,lt,lu) VALUES ('P','S',{ts '2006-01-01 00:00:00.000'},'Software and more','Protetta',{ts '2006-01-01 00:00:00.000'},'Software and more')
GO


-- GENERAZIONE DATI PER centralizedcategory --

-- GENERAZIONE DATI PER maritalstatus --
INSERT INTO [maritalstatus] (idmaritalstatus,active,ct,cu,description,lt,lu) VALUES ('1','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Celibe',{ts '2003-01-01 00:00:00.000'},'Software and more')
INSERT INTO [maritalstatus] (idmaritalstatus,active,ct,cu,description,lt,lu) VALUES ('2','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Nubile',{ts '2003-01-01 00:00:00.000'},'Software and more')
INSERT INTO [maritalstatus] (idmaritalstatus,active,ct,cu,description,lt,lu) VALUES ('3','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Vedova',{ts '2003-01-01 00:00:00.000'},'Software and more')
INSERT INTO [maritalstatus] (idmaritalstatus,active,ct,cu,description,lt,lu) VALUES ('4','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Vedovo',{ts '2003-01-01 00:00:00.000'},'Software and more')
INSERT INTO [maritalstatus] (idmaritalstatus,active,ct,cu,description,lt,lu) VALUES ('5','S',{ts '2003-10-27 15:46:23.000'},'Software and more','Coniugato/a',{ts '2003-10-27 15:46:23.000'},'Software and more')
GO


-- GENERAZIONE DATI PER title --
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('1','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Avv.',{ts '2003-09-19 11:50:18.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('10','S',{ts '2004-01-01 00:00:00.000'},'Software and more','Rag.',{ts '2004-01-01 00:00:00.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('11','S',{ts '2004-01-01 00:00:00.000'},'Software and more','Geom.',{ts '2004-01-01 00:00:00.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('12','S',{ts '2004-01-01 00:00:00.000'},'Software and more','Avv.ssa',{ts '2004-01-01 00:00:00.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('13','S',{ts '2005-09-26 09:24:32.077'},'Software and more','Cav.',{ts '2005-09-26 09:24:32.077'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('2','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Ing.',{ts '2003-09-19 11:50:21.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('3','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Dott.',{ts '2003-09-19 11:50:23.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('4','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Dott.ssa',{ts '2003-09-19 11:50:26.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('5','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Prof.',{ts '2003-09-19 11:50:29.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('6','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Dir.',{ts '2003-09-19 11:50:13.000'},'Software and more')
GO

INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('7','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Sig.',{ts '2003-09-19 11:50:31.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('8','S',{ts '2003-01-01 00:00:00.000'},'Software and more','Sig.ra',{ts '2003-09-19 11:50:33.000'},'Software and more')
INSERT INTO [title] (idtitle,active,ct,cu,description,lt,lu) VALUES ('9','S',{ts '2004-01-01 00:00:00.000'},'Software and more','Prof.ssa',{ts '2004-01-01 00:00:00.000'},'Software and more')
GO


-- GENERAZIONE DATI PER registrykind --

-- GENERAZIONE DATI PER address --
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('1','S','07_SW_AVV','Avviso di pagamento',{ts '2006-03-10 12:41:11.443'},'Software and more')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('2','S','07_SW_CER','Certificazione di ritenuta d''acconto',{ts '2008-02-21 10:44:45.367'},'SA')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('3','S','07_SW_DOM','Domicilio fiscale',{ts '2008-02-21 10:44:47.317'},'SA')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('4','S','07_SW_FAT','Fattura di vendita',{ts '2008-02-21 10:44:49.973'},'SA')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('5','S','07_SW_ORD','Ordine a fornitore',{ts '2008-02-21 10:44:53.600'},'SA')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('7','S','07_SW_DEF','Predefinito',{ts '2006-03-10 12:40:57.333'},'Software and more')
INSERT INTO [address] (idaddress,active,codeaddress,description,lt,lu) VALUES ('8','S','10_SW_FAT2','Cliente fattura di vendita',{ts '2010-02-24 11:24:40.920'},'assistenza')
INSERT INTO [address] (idaddress,codeaddress,description,lt,lu,active) VALUES ('9','07_SW_ANP','Anagrafe delle prestazioni',{ts '2005-07-12 11:26:13.890'},'''SARA''','S')

GO


-- GENERAZIONE DATI PER paymethod --
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('1','S','N',null,null,{ts '1996-12-31 17:35:06.810'},'Software and more','Assegno circolare','8',null,{ts '2008-01-31 14:02:47.593'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('2','S','N',null,null,{ts '2000-01-04 09:37:14.710'},'Software and more','Bonifico Centro Autonomo Spesa','1',null,{ts '2008-01-31 14:02:51.233'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('3','S','N',null,null,{ts '1996-12-31 17:35:06.720'},'Software and more','Bonifico presso altre banche','36',null,{ts '2008-01-31 14:02:56.077'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('4','S','N',null,null,{ts '1996-12-31 17:35:06.640'},'Software and more','Bonifico presso istituto cassiere','20',null,{ts '2008-02-21 11:10:02.927'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('5','S','N',null,null,{ts '1996-12-31 17:35:06.860'},'Software and more','Conto corrente postale','2',null,{ts '2008-01-31 14:03:01.813'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('6','S','N',null,null,{ts '1996-12-31 17:35:06.770'},'Software and more','Esclusiva cassiere','8',null,{ts '2008-01-31 14:03:04.780'},'SA',null,null,null)
INSERT INTO [paymethod] (idpaymethod,active,allowdeputy,committeeamount,committeecode,ct,cu,description,flag,footerpaymentadvice,lt,lu,maxamount,methodbankcode,minamount) VALUES ('7','S','S',null,null,{ts '1996-12-31 17:35:06.860'},'Software and more','Sportello','9',null,{ts '2008-01-31 14:03:07.767'},'SA',null,null,null)
GO


-- GENERAZIONE DATI PER currency --
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('1','DKK',{ts '1999-06-13 19:50:26.710'},'Software and more','Corona danese',{ts '1999-06-13 19:50:26.710'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('2','NOK',{ts '1999-06-13 19:50:26.970'},'Software and more','Corona norvegese',{ts '1999-06-13 19:50:26.970'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('3','SEK',{ts '1999-06-13 19:50:27.040'},'Software and more','Corona svedese',{ts '1999-06-13 19:50:27.040'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('4','AUD',{ts '1999-06-13 19:50:26.600'},'Software and more','Dollaro australiano',{ts '1999-06-13 19:50:26.600'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('5','CAD',{ts '1999-06-13 19:50:26.650'},'Software and more','Dollaro canadese',{ts '1999-06-13 19:50:26.650'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('6','NZD',{ts '1999-06-13 19:50:27.000'},'Software and more','Dollaro neozelandese',{ts '1999-06-13 19:50:27.000'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('7','USD',{ts '1999-06-13 19:50:27.100'},'Software and more','Dollaro statunitense',{ts '1999-06-13 19:50:27.110'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('8','GRD',{ts '1999-06-13 19:50:26.840'},'Software and more','Dracma greca',{ts '1999-06-13 19:50:26.840'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('9','EUR',{ts '1999-06-13 19:50:26.740'},'Software and more','Euro',{ts '1999-06-13 19:50:26.750'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('10','NLG',{ts '1999-06-13 19:50:26.950'},'Software and more','Fiorino olandese',{ts '1999-06-13 19:50:26.950'},'Software and more')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('11','BEF',{ts '1999-06-13 19:50:26.620'},'Software and more','Franco belga',{ts '1999-06-13 19:50:26.630'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('12','FRF',{ts '1999-06-13 19:50:26.790'},'Software and more','Franco francese',{ts '1999-06-13 19:50:26.790'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('13','LUF',{ts '1999-06-13 19:50:26.930'},'Software and more','Franco lussemburghese',{ts '1999-06-13 19:50:26.930'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('14','CHF',{ts '1999-06-13 19:50:26.670'},'Software and more','Franco svizzero',{ts '1999-06-13 19:50:26.670'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('15','IEP',{ts '1999-06-13 19:50:26.860'},'Software and more','Lira Irlandese',{ts '1999-06-13 19:50:26.860'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('16','ITL',{ts '1999-06-13 19:50:26.880'},'Software and more','Lira italiana',{ts '1999-06-13 19:50:26.890'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('17','TRL',{ts '1999-06-13 19:50:27.080'},'Software and more','Lira turca',{ts '1999-06-13 19:50:27.080'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('18','FIM',{ts '1999-06-13 19:50:26.770'},'Software and more','Marco Finlandese',{ts '1999-06-13 19:50:26.770'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('19','DEM',{ts '1999-06-13 19:50:26.690'},'Software and more','Marco tedesco',{ts '1999-06-13 19:50:26.690'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('20','ESP',{ts '1999-06-13 19:50:26.740'},'Software and more','Peseta spagnola',{ts '1999-06-13 19:50:26.740'},'Software and more')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('22','ATS',{ts '1999-06-13 19:50:26.580'},'Software and more','Scellino austriaco',{ts '1999-06-13 19:50:26.580'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('23','PTE',{ts '1999-06-13 19:50:27.020'},'Software and more','Scudo portoghese',{ts '1999-06-13 19:50:27.020'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('24','GBP',{ts '1999-06-13 19:50:26.810'},'Software and more','Sterlina inglese',{ts '1999-06-13 19:50:26.820'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('25','JPY',{ts '1999-06-13 19:50:26.910'},'Software and more','Yen giapponese',{ts '1999-06-13 19:50:26.910'},'Software and more')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('26','ARS',{ts '2009-05-14 14:55:52.530'},'SARA','Peso Argentino',{ts '2009-05-14 14:55:52.530'},'SARA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('27','AED',{ts '2009-09-03 14:31:13.407'},'SA','Dirahm degli Emirati Arabi Uniti',{ts '2009-09-03 14:31:13.407'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('28','AFN',{ts '2009-09-03 14:32:06.670'},'SA','Afghani afgano',{ts '2009-09-03 14:32:22.030'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('29','ALL',{ts '2009-09-03 14:32:59.717'},'SA','Lek albanese',{ts '2009-09-03 14:32:59.717'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('30','AMD',{ts '2009-09-03 14:33:16.483'},'SA','Dram armeno',{ts '2009-09-03 14:33:25.377'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('31','ANG',{ts '2009-09-03 14:33:50.127'},'SA','Fiorino delle Antille olandesi',{ts '2009-09-03 14:33:50.127'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('32','AOA',{ts '2009-09-03 14:34:11.877'},'SA','Kwanza angolano',{ts '2009-09-03 14:34:11.877'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('33','AWG',{ts '2009-09-03 14:34:37.640'},'SA','Fiorino arubano',{ts '2009-09-03 14:34:37.640'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('34','AZN',{ts '2009-09-03 14:35:10.360'},'SA','Manat azero',{ts '2009-09-03 14:35:10.360'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('35','BAM',{ts '2009-09-03 14:35:28.593'},'SA','Marco bosniaco',{ts '2009-09-03 14:35:28.593'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('36','BBD',{ts '2009-09-03 14:36:04.343'},'SA','Dollaro di Barbados',{ts '2009-09-03 14:36:04.343'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('37','BDT',{ts '2009-09-03 14:36:50.983'},'SA','Taka bengalese',{ts '2009-09-03 14:36:50.983'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('38','BGN',{ts '2009-09-03 14:38:13.657'},'SA','Nuovo lev bulgaro',{ts '2009-09-03 14:38:13.657'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('39','BHD',{ts '2009-09-03 14:39:05.530'},'SA','Dinaro del Bahrain',{ts '2009-09-03 14:39:05.530'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('40','BIF',{ts '2009-09-03 14:39:20.877'},'SA','Franco del Burundi',{ts '2009-09-03 14:39:20.877'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('41','BMD',{ts '2009-09-03 14:39:35.233'},'SA','Dollaro delle Bermuda',{ts '2009-09-03 14:39:35.233'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('42','BND',{ts '2009-09-03 14:39:47.813'},'SA','Dollaro del Brunei',{ts '2009-09-03 14:39:47.813'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('43','BOB',{ts '2009-09-03 14:40:01.140'},'SA','Boliviano',{ts '2009-09-03 14:40:01.140'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('44','BRL',{ts '2009-09-03 14:40:14.217'},'SA','Real brasiliano',{ts '2009-09-03 14:40:14.217'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('45','BSD',{ts '2009-09-03 14:40:38.703'},'SA','Dollaro delle Bahamas',{ts '2009-09-03 14:40:38.703'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('46','BTN',{ts '2009-09-03 14:41:02.360'},'SA','Ngultrum del Bhutan',{ts '2009-09-03 14:41:02.360'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('47','BWP',{ts '2009-09-03 14:41:17.733'},'SA','Pula del Botswana',{ts '2009-09-03 14:41:17.733'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('48','BYR',{ts '2009-09-03 14:41:33.517'},'SA','Rublo bielorusso',{ts '2009-09-03 14:41:33.517'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('49','BZD',{ts '2009-09-03 14:42:19.860'},'SA','Dollaro del Belize',{ts '2009-09-03 14:42:19.860'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('50','CDF',{ts '2009-09-03 14:42:45.297'},'SA','Franco congolese',{ts '2009-09-03 14:42:45.297'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('51','CLP',{ts '2009-09-03 14:43:27.890'},'SA','Peso cileno',{ts '2009-09-03 14:43:27.890'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('52','CNY',{ts '2009-09-03 14:44:04.813'},'SA','Renminbi cinese (yuan)',{ts '2009-09-03 14:44:04.813'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('53','COP',{ts '2009-09-03 14:44:18.467'},'SA','Peso colombiano',{ts '2009-09-03 14:44:18.467'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('54','CRC',{ts '2009-09-03 14:44:41.733'},'SA','Colòn constaricano',{ts '2009-09-03 14:44:41.733'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('55','CUP',{ts '2009-09-03 14:44:53.610'},'SA','Peso cubano',{ts '2009-09-03 14:44:53.610'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('56','CVE',{ts '2009-09-03 14:45:12.077'},'SA','Escudo di Capo Verde',{ts '2009-09-03 14:45:12.077'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('57','CZK',{ts '2009-09-03 14:45:29.813'},'SA','Corona ceca',{ts '2009-09-03 14:45:29.813'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('58','DJF',{ts '2009-09-03 14:46:48.530'},'SA','Franco gibutiano',{ts '2009-09-03 14:46:48.530'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('59','DOP',{ts '2009-09-03 14:47:08.453'},'SA','Peso dominicano',{ts '2009-09-03 14:47:08.453'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('60','DZD',{ts '2009-09-03 14:47:25.877'},'SA','Dinaro algerino',{ts '2009-09-03 14:47:25.877'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('61','EEK',{ts '2009-09-03 14:47:40.000'},'SA','Corona estone',{ts '2009-09-03 14:47:40.000'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('62','EGP',{ts '2009-09-03 14:48:03.967'},'SA','Lira egiziana (o sterlina)',{ts '2009-09-03 14:48:03.967'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('63','ERN',{ts '2009-09-03 14:48:20.467'},'SA','Nafka eritreo',{ts '2009-09-03 14:48:20.467'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('64','ETB',{ts '2009-09-03 14:48:31.750'},'SA','Birr etiope',{ts '2009-09-03 14:48:31.750'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('65','FJD',{ts '2009-09-03 14:48:53.280'},'SA','Dollaro delle Figi',{ts '2009-09-03 14:48:53.280'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('66','FKP',{ts '2009-09-03 14:49:09.017'},'SA','Sterlina delle Falkland',{ts '2009-09-03 14:49:09.017'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('67','GEL',{ts '2009-09-03 14:49:37.733'},'SA','Lari georgiano',{ts '2009-09-03 14:49:37.733'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('68','GHC',{ts '2009-09-03 14:50:01.860'},'SA','Cedi ghanese',{ts '2009-09-03 14:50:01.860'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('69','GIP',{ts '2009-09-03 14:50:36.670'},'SA','Sterlina di Gibilterra',{ts '2009-09-03 14:50:36.670'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('70','GMD',{ts '2009-09-03 14:51:15.407'},'SA','Dalasi gambese',{ts '2009-09-03 14:51:15.407'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('71','GNF',{ts '2009-09-03 14:51:47.000'},'SA','Franco guineano',{ts '2009-09-03 14:51:47.000'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('72','GTQ',{ts '2009-09-03 14:52:06.967'},'SA','Quetzal guatemalteco',{ts '2009-09-03 14:52:06.967'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('73','GYD',{ts '2009-09-03 14:52:20.703'},'SA','Dollaro della Guyana',{ts '2009-09-03 14:52:20.703'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('74','HKD',{ts '2009-09-03 14:52:32.547'},'SA','Dollaro di Hong Kong',{ts '2009-09-03 14:52:32.547'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('75','HNL',{ts '2009-09-03 14:52:47.000'},'SA','Lempira honduregna',{ts '2009-09-03 14:52:47.000'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('76','HRK',{ts '2009-09-03 14:53:04.767'},'SA','Kuna croata',{ts '2009-09-03 14:53:04.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('77','HTG',{ts '2009-09-03 14:53:27.017'},'SA','Gourde haitiano',{ts '2009-09-03 14:53:27.017'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('78','HUF',{ts '2009-09-03 14:53:50.110'},'SA','Fiorino ungherese',{ts '2009-09-03 14:53:50.110'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('79','IDR',{ts '2009-09-03 14:54:06.157'},'SA','Rupia indonesiana',{ts '2009-09-03 14:54:06.157'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('80','ILS',{ts '2009-09-03 14:54:22.170'},'SA','Nuovo shekel israeliano',{ts '2009-09-03 14:54:22.170'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('81','INR',{ts '2009-09-03 14:54:44.077'},'SA','Rupia indiana',{ts '2009-09-03 14:54:44.077'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('82','ISK',{ts '2009-09-03 14:55:03.967'},'SA','Corona islandese',{ts '2009-09-03 14:55:03.967'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('83','JMD',{ts '2009-09-03 14:55:18.093'},'SA','Dollaro giamaicano',{ts '2009-09-03 14:55:18.093'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('84','JOD',{ts '2009-09-03 14:55:31.360'},'SA','Dinaro giordano',{ts '2009-09-03 14:55:31.360'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('85','KES',{ts '2009-09-03 14:55:51.517'},'SA','Scellino keniota',{ts '2009-09-03 14:55:51.517'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('86','KGS',{ts '2009-09-03 14:56:07.610'},'SA','Som kirghizo',{ts '2009-09-03 14:56:07.610'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('87','KHR',{ts '2009-09-03 14:56:20.827'},'SA','Real cambogiano',{ts '2009-09-03 14:56:20.827'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('88','KMF',{ts '2009-09-03 14:56:55.687'},'SA','Franco delle Comore',{ts '2009-09-03 14:56:55.687'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('89','KPW',{ts '2009-09-03 14:57:18.890'},'SA','Won nordcoreano',{ts '2009-09-03 14:57:18.890'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('90','KRW',{ts '2009-09-03 14:57:34.483'},'SA','Won sudcoreano',{ts '2009-09-03 14:57:34.483'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('91','KWD',{ts '2009-09-03 14:58:06.577'},'SA','Dinaro kuwaitiano',{ts '2009-09-03 14:58:06.577'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('92','KYD',{ts '2009-09-03 15:00:16.953'},'SA','Dollaro delle Cayman',{ts '2009-09-03 15:00:16.953'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('93','KZT',{ts '2009-09-03 15:00:37.750'},'SA','Tenge kazako',{ts '2009-09-03 15:00:37.750'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('94','LAK',{ts '2009-09-03 15:00:56.170'},'SA','Kip laotiano',{ts '2009-09-03 15:00:56.170'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('95','LBP',{ts '2009-09-03 15:01:08.937'},'SA','Lira libanese',{ts '2009-09-03 15:01:08.937'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('96','LKR',{ts '2009-09-03 15:01:29.483'},'SA','Rupia singalese',{ts '2009-09-03 15:01:29.483'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('97','LRD',{ts '2009-09-03 15:01:41.390'},'SA','Dollaro liberiano',{ts '2009-09-03 15:01:41.390'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('98','LSL',{ts '2009-09-03 15:01:55.390'},'SA','Loti lesothiano',{ts '2009-09-03 15:01:55.390'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('99','LTL',{ts '2009-09-03 15:02:16.517'},'SA','Lita lituano',{ts '2009-09-03 15:02:16.517'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('100','LVL',{ts '2009-09-03 15:02:37.937'},'SA','Lats lettone',{ts '2009-09-03 15:02:37.937'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('101','LYD',{ts '2009-09-03 15:03:02.483'},'SA','Dinaro libico',{ts '2009-09-03 15:03:02.483'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('102','MAD',{ts '2009-09-03 15:03:15.313'},'SA','Dirham marocchino',{ts '2009-09-03 15:03:15.313'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('103','MDL',{ts '2009-09-03 15:03:27.843'},'SA','Leu moldavo',{ts '2009-09-03 15:03:27.843'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('104','MGA',{ts '2009-09-03 15:03:56.437'},'SA','Ariary malgascio',{ts '2009-09-03 15:03:56.437'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('105','MKD',{ts '2009-09-03 15:04:08.953'},'SA','Dinaro macedone',{ts '2009-09-03 15:04:08.953'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('106','MMK',{ts '2009-09-03 15:04:25.127'},'SA','Kyat birmano',{ts '2009-09-03 15:04:25.127'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('107','MNT',{ts '2009-09-03 15:04:39.767'},'SA','Turik mongolo',{ts '2009-09-03 15:04:39.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('108','MOP',{ts '2009-09-03 15:04:55.627'},'SA','Pataca di Macao',{ts '2009-09-03 15:04:55.627'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('109','MRO',{ts '2009-09-03 15:05:25.063'},'SA','Ouguiya mauritana',{ts '2009-09-03 15:05:25.063'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('110','MUR',{ts '2009-09-03 15:05:38.827'},'SA','Rupia mauriziana',{ts '2009-09-03 15:05:38.827'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('111','MVR',{ts '2009-09-03 15:05:53.843'},'SA','Rufiyaa delle Maldive',{ts '2009-09-03 15:05:53.843'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('112','MWK',{ts '2009-09-03 15:06:09.063'},'SA','Kwacha malawiano',{ts '2009-09-03 15:06:09.063'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('113','MXN',{ts '2009-09-03 15:06:22.517'},'SA','Peso messicano',{ts '2009-09-03 15:06:22.517'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('114','MYR',{ts '2009-09-03 15:06:39.733'},'SA','Ringgit malese',{ts '2009-09-03 15:06:39.733'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('115','MZN',{ts '2009-09-03 15:06:58.627'},'SA','Metical namibiano',{ts '2009-09-03 15:06:58.627'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('116','NGN',{ts '2009-09-03 15:07:27.233'},'SA','Naira nigeriana',{ts '2009-09-03 15:07:27.233'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('117','NAD',{ts '2009-09-03 15:07:47.797'},'SA','Dollaro namibiano',{ts '2009-09-03 15:07:47.797'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('118','NIO',{ts '2009-09-03 15:08:07.500'},'SA','Cordoba nicaraguense',{ts '2009-09-03 15:08:07.500'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('119','NPR',{ts '2009-09-03 15:08:32.797'},'SA','Rupia nepalese',{ts '2009-09-03 15:08:32.797'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('120','OMR',{ts '2009-09-03 15:08:56.377'},'SA','Rial dell''Oman',{ts '2009-09-03 15:08:56.377'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('121','PAB',{ts '2009-09-03 15:09:12.563'},'SA','Balboa panamense',{ts '2009-09-03 15:09:12.563'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('122','PEN',{ts '2009-09-03 15:09:26.483'},'SA','Nuevo sol peruviano',{ts '2009-09-03 15:09:26.483'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('123','PGK',{ts '2009-09-03 15:09:43.467'},'SA','Kina papuana',{ts '2009-09-03 15:09:43.467'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('124','PHP',{ts '2009-09-03 15:09:58.640'},'SA','Peso filippino',{ts '2009-09-03 15:09:58.640'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('125','PKR',{ts '2009-09-03 15:10:15.047'},'SA','Rupia pakistana',{ts '2009-09-03 15:10:15.047'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('126','PLN',{ts '2009-09-03 15:10:32.407'},'SA','Zloty polacco',{ts '2009-09-03 15:10:36.377'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('127','PYG',{ts '2009-09-03 15:10:50.610'},'SA','Guarani paraguaiano',{ts '2009-09-03 15:10:50.610'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('128','QAR',{ts '2009-09-03 15:11:04.000'},'SA','Rial del Qatar',{ts '2009-09-03 15:11:04.000'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('129','ROL',{ts '2009-09-03 15:11:14.920'},'SA','Leu rumeno',{ts '2009-09-03 15:11:14.920'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('130','RON',{ts '2009-09-03 15:11:29.767'},'SA','Nuovo leu rumeno',{ts '2009-09-03 15:11:29.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('131','RSD',{ts '2009-09-03 15:11:41.437'},'SA','Dinaro serbo',{ts '2009-09-03 15:11:41.437'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('132','RWF',{ts '2009-09-03 15:12:11.343'},'SA','Franco ruandese',{ts '2009-09-03 15:12:11.343'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('133','SAR',{ts '2009-09-03 15:12:24.093'},'SA','Rial saudita',{ts '2009-09-03 15:12:24.093'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('134','SBD',{ts '2009-09-03 15:12:41.407'},'SA','Dollaro delle Salomone',{ts '2009-09-03 15:12:41.407'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('135','SCR',{ts '2009-09-03 15:12:56.920'},'SA','Rupia delle Seychelles',{ts '2009-09-03 15:12:56.920'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('136','SDG',{ts '2009-09-03 15:13:10.827'},'SA','Sterlina sudanese',{ts '2009-09-03 15:13:10.827'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('137','SHP',{ts '2009-09-03 15:13:47.017'},'SA','Sterlina di Sant''Elena',{ts '2009-09-03 15:13:47.017'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('138','SGD',{ts '2009-09-03 15:14:28.767'},'SA','Dollaro di Singapore',{ts '2009-09-03 15:14:28.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('139','SLL',{ts '2009-09-03 15:14:49.610'},'SA','Leone della Sierra Leone',{ts '2009-09-03 15:14:49.610'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('140','SOS',{ts '2009-09-03 15:15:01.767'},'SA','Scellino somalo',{ts '2009-09-03 15:15:01.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('141','SRD',{ts '2009-09-03 15:15:17.797'},'SA','Dollaro surinamese',{ts '2009-09-03 15:15:17.797'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('142','STD',{ts '2009-09-03 15:15:37.670'},'SA','Dobra di Sao Tomè e Principe',{ts '2009-09-03 15:15:37.670'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('143','SYP',{ts '2009-09-03 15:16:16.233'},'SA','Lira siriana (o sterlina)',{ts '2009-09-03 15:16:16.233'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('144','SZL',{ts '2009-09-03 15:16:32.657'},'SA','Lilangeni dello Swaziland',{ts '2009-09-03 15:16:32.657'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('145','THB',{ts '2009-09-03 15:16:54.733'},'SA','Baht thailandese',{ts '2009-09-03 15:16:54.733'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('146','TJS',{ts '2009-09-03 15:17:07.610'},'SA','Somoni tagico',{ts '2009-09-03 15:17:07.610'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('147','TMM',{ts '2009-09-03 15:17:18.000'},'SA','Manat turkmeno',{ts '2009-09-03 15:17:18.000'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('148','TND',{ts '2009-09-03 15:17:31.093'},'SA','Dinaro tunisino',{ts '2009-09-03 15:17:31.093'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('149','TOP',{ts '2009-09-03 15:17:52.030'},'SA','Pa anga tongano',{ts '2009-09-03 15:17:52.030'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('150','TRY',{ts '2009-09-03 15:18:04.360'},'SA','Nuova lira turca',{ts '2009-09-03 15:18:04.360'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('151','TTD',{ts '2009-09-03 15:18:21.110'},'SA','Dollaro di Trinidad e Tobago',{ts '2009-09-03 15:18:21.110'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('152','TZS',{ts '2009-09-03 15:18:35.767'},'SA','Scellino tanzaniano',{ts '2009-09-03 15:18:35.767'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('153','UAH',{ts '2009-09-03 15:18:52.217'},'SA','Grivnia ucraina',{ts '2009-09-03 15:18:52.217'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('154','UGX',{ts '2009-09-03 15:19:07.093'},'SA','Scellino ugandese',{ts '2009-09-03 15:19:07.093'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('155','UYU',{ts '2009-09-03 15:19:26.797'},'SA','Peso uruguaiano',{ts '2009-09-03 15:19:26.797'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('156','UZS',{ts '2009-09-03 15:19:40.390'},'SA','Som uzbeco',{ts '2009-09-03 15:19:40.390'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('157','VEB',{ts '2009-09-03 15:19:57.047'},'SA','Bolivar venezuelano',{ts '2009-09-03 15:19:57.047'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('158','VND',{ts '2009-09-03 15:20:09.360'},'SA','Dong vietnamita',{ts '2009-09-03 15:20:09.360'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('159','VUV',{ts '2009-09-03 15:20:24.127'},'SA','Vatu di Vanuatu',{ts '2009-09-03 15:20:24.127'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('160','WST',{ts '2009-09-03 15:20:40.250'},'SA','Tala samoano',{ts '2009-09-03 15:20:40.250'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('161','XAF',{ts '2009-09-03 15:20:55.110'},'SA','Franco CFA BEAC',{ts '2009-09-03 15:20:55.110'},'SA')
GO

INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('162','XCD',{ts '2009-09-03 15:21:22.703'},'SA','Dollaro dei Caraibi orientali',{ts '2009-09-03 15:21:22.703'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('163','XOF',{ts '2009-09-03 15:21:58.953'},'SA','Franco CFA BCEAO',{ts '2009-09-03 15:21:58.953'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('164','XPF',{ts '2009-09-03 15:22:11.843'},'SA','Franco CFP',{ts '2009-09-03 15:22:11.843'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('165','YER',{ts '2009-09-03 15:22:23.390'},'SA','Rial yemenita',{ts '2009-09-03 15:22:23.390'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('166','ZAR',{ts '2009-09-03 15:22:35.017'},'SA','Rand sudafricano',{ts '2009-09-03 15:22:35.017'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('167','ZMK',{ts '2009-09-03 15:22:49.467'},'SA','Kwacha zambiano',{ts '2009-09-03 15:22:49.467'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('168','ZWL',{ts '2009-09-03 15:23:05.920'},'SA','Dollaro zimbabwiano',{ts '2009-09-03 15:23:05.920'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('169','LIT',{ts '2009-09-03 15:42:17.907'},'SA','LIT',{ts '2009-09-03 15:42:17.907'},'SA')
INSERT INTO [currency] (idcurrency,codecurrency,ct,cu,description,lt,lu) VALUES ('170','RUB ',{ts '2009-09-03 15:48:48.483'},'SA','Rublo russo',{ts '2009-09-03 15:48:48.483'},'SA')
GO

-- FINE GENERAZIONE SCRIPT --

