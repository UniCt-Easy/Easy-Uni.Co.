
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


-- CREAZIONE VISTA pagamentosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pagamentosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pagamentosegview]
GO

CREATE VIEW [dbo].[pagamentosegview] AS 
SELECT  pagamento.ct AS pagamento_ct, pagamento.cu AS pagamento_cu, pagamento.dataora AS pagamento_dataora, pagamento.iddebito, pagamento.idpagamento,
 [dbo].pagamentokind.title AS pagamentokind_title, pagamento.idpagamentokind AS pagamento_idpagamentokind, pagamento.idreg, pagamento.lt AS pagamento_lt, pagamento.lu AS pagamento_lu
FROM [dbo].pagamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].pagamentokind WITH (NOLOCK) ON pagamento.idpagamentokind = [dbo].pagamentokind.idpagamentokind
WHERE  pagamento.iddebito IS NOT NULL  AND pagamento.idpagamento IS NOT NULL  AND pagamento.idreg IS NOT NULL 
GO

-- VERIFICA DI pagamentosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pagamentosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','int','ASSISTENZA','iddebito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','int','ASSISTENZA','idpagamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','datetime','ASSISTENZA','pagamento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','varchar(64)','ASSISTENZA','pagamento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pagamentosegview','datetime','ASSISTENZA','pagamento_dataora','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pagamentosegview','int','ASSISTENZA','pagamento_idpagamentokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','datetime','ASSISTENZA','pagamento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentosegview','varchar(64)','ASSISTENZA','pagamento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pagamentosegview','varchar(50)','ASSISTENZA','pagamentokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pagamentosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pagamentosegview')
UPDATE customobject set isreal = 'N' where objectname = 'pagamentosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pagamentosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
