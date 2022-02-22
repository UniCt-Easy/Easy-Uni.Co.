
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


IF EXISTS(select * from sysobjects where id = object_id(N'[getcostididattica]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcostididattica]
GO

-- CREAZIONE VISTA getcostididattica
CREATE VIEW [getcostididattica]
AS
select 
	--indici
	a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr, af.idinsegn, af.idinsegninteg , a.idaffidamento, a.idaffidamentokind, a.idreg_docenti, 
	isnull(ck.idcontrattokind,1000) as idcontrattokind,
	--label
	cs.title as corsostudio, s.title as sede, d.aa as aaprogrammata, cu.title as curriculum, i.denominazione as insegnamento, ii.denominazione as modulo, 
	isnull(ak.title,'') + ' ' + isnull(akco.title,'') as affidamento, 
	doc.title as docente, isnull(ck.title,'Ruolo non definito') as ruolo,
	--parametri da cui dipende il calcolo
	CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'S' THEN 'SI' ELSE 'NO' END as costoorariodacontratto,
	 --ak.costoora,akco.costoora, c.costoora,ora,ripetizioni,
	--costo
	sum(ora*isnull(ripetizioni,1)* 
		CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'S' THEN isnull(c.costoora,0) ELSE isnull(akco.costoora,0) END
	) as costo
from affidamentocaratteristicaora aco
	INNER JOIN affidamento a on a.idaffidamento = aco.idaffidamento
	inner join affidamentokind ak on ak.idaffidamentokind = a.idaffidamentokind
	left outer join affidamentokindcostoora akco on akco.idaffidamentokind = a.idaffidamentokind and akco.aa = a.aa
	inner join corsostudio as cs on cs.idcorsostudio = a.idcorsostudio
	inner join sede s on s.idsede = a.idsede
	inner join didprog d on d.iddidprog = a.iddidprog
	inner join didprogcurr cu on cu.iddidprogcurr = a.iddidprogcurr
	inner join attivform af on af.idattivform = a.idattivform 
	inner join insegn i on i.idinsegn = af.idinsegn
	left outer join insegninteg ii on ii.idinsegninteg = af.idinsegninteg 
	left outer join registry doc on doc.idreg = a.idreg_docenti
	left outer join getcontratti c on c.idreg = a.idreg_docenti and NOT(isnull(c.stop,'20400101') < a.start or c.start > a.stop)
	left outer join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
group by a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr,af.idinsegn, af.idinsegninteg , a.idaffidamento, a.idaffidamentokind, a.idreg_docenti, ck.idcontrattokind,
	cs.title, s.title, d.aa, cu.title, i.denominazione, ii.denominazione, doc.title, ak.title, akco.title, ck.title,
	isnull(ak.costoorariodacontratto,'N')--,ak.costoora,akco.costoora, c.costoora,ora,ripetizioni
--order by a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr, a.idaffidamento, a.idreg_docenti, ck.idcontrattokind

GO

-- VERIFICA DI getcostididattica IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcostididattica'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(9)','ASSISTENZA','aaprogrammata','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','nvarchar(1075)','ASSISTENZA','affidamento','1075','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(1024)','ASSISTENZA','corsostudio','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','decimal(38,2)','ASSISTENZA','costo','17','N','decimal','System.Decimal','','2','''ASSISTENZA''','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','char(1)','ASSISTENZA','costoorariodacontratto','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(256)','ASSISTENZA','curriculum','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(101)','ASSISTENZA','docente','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','int','ASSISTENZA','idinsegninteg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(256)','ASSISTENZA','insegnamento','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','varchar(256)','ASSISTENZA','modulo','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididattica','varchar(50)','ASSISTENZA','ruolo','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididattica','nvarchar(1024)','ASSISTENZA','sede','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getcostididattica IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcostididattica')
UPDATE customobject set isreal = 'N' where objectname = 'getcostididattica'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcostididattica', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

