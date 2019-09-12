-- Aggiornamento tabella FINVAR e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Codifica - N (Normale) = 1; R (Ripartizione) = 2; A (Assestamento) = 3; S (Storno) = 4
UPDATE mandatedetail SET assetkind =
CASE
	WHEN assetkind = 'I' THEN 'A'
	WHEN assetkind = 'N' THEN 'P'
	WHEN assetkind = 'S' THEN 'S'
	WHEN assetkind IS NULL THEN 'O'
	ELSE 'O'
END
GO

ALTER TABLE [mandatedetail] ALTER COLUMN assetkind char(1) NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'mandatedetail' AND field = 'assetkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'char',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.String',sqldeclaration = 'char(1)',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-11-27 09:43:40.217'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-11-27 09:43:40.217'} WHERE tablename = 'mandatedetail' AND field = 'assetkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('mandatedetail','assetkind','N','char','1',null,null,'System.String','char(1)','N','',null,'S',{ts '2007-11-27 09:43:40.217'},'''NINO''','NINO',{ts '2007-11-27 09:43:40.217'})
GO

