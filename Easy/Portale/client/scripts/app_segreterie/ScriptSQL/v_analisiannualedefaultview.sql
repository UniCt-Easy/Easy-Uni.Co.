
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


-- CREAZIONE VISTA analisiannualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[analisiannualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[analisiannualedefaultview]
GO

CREATE VIEW [dbo].[analisiannualedefaultview] AS 
SELECT  analisiannuale.contrattiincarichiinsegnamento0 AS analisiannuale_contrattiincarichiinsegnamento0, analisiannuale.contrattiincarichiinsegnamento1 AS analisiannuale_contrattiincarichiinsegnamento1, analisiannuale.contrattiincarichiinsegnamento2 AS analisiannuale_contrattiincarichiinsegnamento2, analisiannuale.contrattiincarichiinsegnamento3 AS analisiannuale_contrattiincarichiinsegnamento3, analisiannuale.costopt AS analisiannuale_costopt, analisiannuale.ct AS analisiannuale_ct, analisiannuale.cu AS analisiannuale_cu, analisiannuale.ffo0 AS analisiannuale_ffo0, analisiannuale.ffo1 AS analisiannuale_ffo1, analisiannuale.ffo2 AS analisiannuale_ffo2, analisiannuale.ffo3 AS analisiannuale_ffo3, analisiannuale.finanzesternicontrattiincarichiinsegnamento0 AS analisiannuale_finanzesternicontrattiincarichiinsegnamento0, analisiannuale.finanzesternicontrattiincarichiinsegnamento1 AS analisiannuale_finanzesternicontrattiincarichiinsegnamento1, analisiannuale.finanzesternicontrattiincarichiinsegnamento2 AS analisiannuale_finanzesternicontrattiincarichiinsegnamento2, analisiannuale.finanzesternicontrattiincarichiinsegnamento3 AS analisiannuale_finanzesternicontrattiincarichiinsegnamento3, analisiannuale.finanzesternidirPTA0 AS analisiannuale_finanzesternidirPTA0, analisiannuale.finanzesternidirPTA1 AS analisiannuale_finanzesternidirPTA1, analisiannuale.finanzesternidirPTA2 AS analisiannuale_finanzesternidirPTA2, analisiannuale.finanzesternidirPTA3 AS analisiannuale_finanzesternidirPTA3, analisiannuale.finanzesternidocenti0 AS analisiannuale_finanzesternidocenti0, analisiannuale.finanzesternidocenti1 AS analisiannuale_finanzesternidocenti1, analisiannuale.finanzesternidocenti2 AS analisiannuale_finanzesternidocenti2, analisiannuale.finanzesternidocenti3 AS analisiannuale_finanzesternidocenti3, analisiannuale.fondocontrattazioneintegrativa0 AS analisiannuale_fondocontrattazioneintegrativa0, analisiannuale.fondocontrattazioneintegrativa1 AS analisiannuale_fondocontrattazioneintegrativa1, analisiannuale.fondocontrattazioneintegrativa2 AS analisiannuale_fondocontrattazioneintegrativa2, analisiannuale.fondocontrattazioneintegrativa3 AS analisiannuale_fondocontrattazioneintegrativa3, analisiannuale.idanalisiannuale, analisiannuale.incrementodocenti1 AS analisiannuale_incrementodocenti1, analisiannuale.incrementodocenti2 AS analisiannuale_incrementodocenti2, analisiannuale.incrementodocenti3 AS analisiannuale_incrementodocenti3, analisiannuale.lt AS analisiannuale_lt, analisiannuale.lu AS analisiannuale_lu, analisiannuale.programmazionetriennale0 AS analisiannuale_programmazionetriennale0, analisiannuale.programmazionetriennale1 AS analisiannuale_programmazionetriennale1, analisiannuale.programmazionetriennale2 AS analisiannuale_programmazionetriennale2, analisiannuale.programmazionetriennale3 AS analisiannuale_programmazionetriennale3, analisiannuale.speseDG0 AS analisiannuale_speseDG0, analisiannuale.speseDG1 AS analisiannuale_speseDG1, analisiannuale.speseDG2 AS analisiannuale_speseDG2, analisiannuale.speseDG3 AS analisiannuale_speseDG3, analisiannuale.spesedirPTA0 AS analisiannuale_spesedirPTA0, analisiannuale.spesedirPTA1 AS analisiannuale_spesedirPTA1, analisiannuale.spesedirPTA2 AS analisiannuale_spesedirPTA2, analisiannuale.spesedirPTA3 AS analisiannuale_spesedirPTA3, analisiannuale.spesedocenti0 AS analisiannuale_spesedocenti0, analisiannuale.spesedocenti1 AS analisiannuale_spesedocenti1, analisiannuale.spesedocenti2 AS analisiannuale_spesedocenti2, analisiannuale.spesedocenti3 AS analisiannuale_spesedocenti3, analisiannuale.speseriduzione0 AS analisiannuale_speseriduzione0, analisiannuale.speseriduzione1 AS analisiannuale_speseriduzione1, analisiannuale.speseriduzione2 AS analisiannuale_speseriduzione2, analisiannuale.speseriduzione3 AS analisiannuale_speseriduzione3, analisiannuale.tasse0 AS analisiannuale_tasse0, analisiannuale.tasse1 AS analisiannuale_tasse1, analisiannuale.tasse2 AS analisiannuale_tasse2, analisiannuale.tasse3 AS analisiannuale_tasse3, analisiannuale.totspesepersonalecaricoateneo0 AS analisiannuale_totspesepersonalecaricoateneo0, analisiannuale.totspesepersonalecaricoateneo1 AS analisiannuale_totspesepersonalecaricoateneo1, analisiannuale.totspesepersonalecaricoateneo2 AS analisiannuale_totspesepersonalecaricoateneo2, analisiannuale.totspesepersonalecaricoateneo3 AS analisiannuale_totspesepersonalecaricoateneo3, analisiannuale.trattamentostipintegrativoCEL0 AS analisiannuale_trattamentostipintegrativoCEL0, analisiannuale.trattamentostipintegrativoCEL1 AS analisiannuale_trattamentostipintegrativoCEL1, analisiannuale.trattamentostipintegrativoCEL2 AS analisiannuale_trattamentostipintegrativoCEL2, analisiannuale.trattamentostipintegrativoCEL3 AS analisiannuale_trattamentostipintegrativoCEL3, analisiannuale.year
FROM [dbo].analisiannuale WITH (NOLOCK) 
WHERE  analisiannuale.idanalisiannuale IS NOT NULL  AND analisiannuale.year IS NOT NULL 
GO

-- VERIFICA DI analisiannualedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'analisiannualedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_contrattiincarichiinsegnamento0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_contrattiincarichiinsegnamento1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_contrattiincarichiinsegnamento2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_contrattiincarichiinsegnamento3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_costopt','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','datetime','','analisiannuale_ct','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','varchar(64)','','analisiannuale_cu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_ffo0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_ffo1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_ffo2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_ffo3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternicontrattiincarichiinsegnamento0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternicontrattiincarichiinsegnamento1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternicontrattiincarichiinsegnamento2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternicontrattiincarichiinsegnamento3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidirPTA0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidirPTA1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidirPTA2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidirPTA3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidocenti0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_finanzesternidocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_fondocontrattazioneintegrativa0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_fondocontrattazioneintegrativa1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_fondocontrattazioneintegrativa2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_fondocontrattazioneintegrativa3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_incrementodocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_incrementodocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_incrementodocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','datetime','','analisiannuale_lt','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','varchar(64)','','analisiannuale_lu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_programmazionetriennale0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_programmazionetriennale1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_programmazionetriennale2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_programmazionetriennale3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseDG0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseDG1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseDG2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseDG3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedirPTA0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedirPTA1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedirPTA2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedirPTA3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedocenti0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedocenti1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedocenti2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_spesedocenti3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseriduzione0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseriduzione1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseriduzione2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_speseriduzione3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_tasse0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_tasse1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_tasse2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_tasse3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_totspesepersonalecaricoateneo0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_totspesepersonalecaricoateneo1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_totspesepersonalecaricoateneo2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_totspesepersonalecaricoateneo3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_trattamentostipintegrativoCEL0','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_trattamentostipintegrativoCEL1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_trattamentostipintegrativoCEL2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','analisiannualedefaultview','decimal(19,2)','','analisiannuale_trattamentostipintegrativoCEL3','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','analisiannualedefaultview','int','','idanalisiannuale','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','analisiannualedefaultview','int','ASSISTENZA','year','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI analisiannualedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'analisiannualedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'analisiannualedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('analisiannualedefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
