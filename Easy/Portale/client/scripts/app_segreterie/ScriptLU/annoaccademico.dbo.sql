
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


-- CREAZIONE TABELLA annoaccademico --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[annoaccademico]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[annoaccademico] (
aa nvarchar(9) NOT NULL,
 CONSTRAINT xpkannoaccademico PRIMARY KEY (aa
)
)
END
GO

-- VERIFICA STRUTTURA annoaccademico --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'annoaccademico' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [annoaccademico] ADD aa nvarchar(9) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('annoaccademico') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [annoaccademico] drop constraint '+@vincolo)
END
GO


-- GENERAZIONE DATI PER annoaccademico --
IF exists(SELECT * FROM [annoaccademico] WHERE aa = '1999/2000')
UPDATE [annoaccademico] SET WHERE aa = '1999/2000'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('1999/2000')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2000/2001')
UPDATE [annoaccademico] SET WHERE aa = '2000/2001'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2000/2001')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2001/2002')
UPDATE [annoaccademico] SET WHERE aa = '2001/2002'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2001/2002')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2002/2003')
UPDATE [annoaccademico] SET WHERE aa = '2002/2003'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2002/2003')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2003/2004')
UPDATE [annoaccademico] SET WHERE aa = '2003/2004'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2003/2004')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2004/2005')
UPDATE [annoaccademico] SET WHERE aa = '2004/2005'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2004/2005')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2005/2006')
UPDATE [annoaccademico] SET WHERE aa = '2005/2006'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2005/2006')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2006/2007')
UPDATE [annoaccademico] SET WHERE aa = '2006/2007'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2006/2007')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2007/2008')
UPDATE [annoaccademico] SET WHERE aa = '2007/2008'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2007/2008')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2008/2009')
UPDATE [annoaccademico] SET WHERE aa = '2008/2009'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2008/2009')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2009/2010')
UPDATE [annoaccademico] SET WHERE aa = '2009/2010'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2009/2010')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2010/2011')
UPDATE [annoaccademico] SET WHERE aa = '2010/2011'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2010/2011')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2011/2012')
UPDATE [annoaccademico] SET WHERE aa = '2011/2012'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2011/2012')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2012/2013')
UPDATE [annoaccademico] SET WHERE aa = '2012/2013'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2012/2013')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2013/2014')
UPDATE [annoaccademico] SET WHERE aa = '2013/2014'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2013/2014')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2014/2015')
UPDATE [annoaccademico] SET WHERE aa = '2014/2015'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2014/2015')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2015/2016')
UPDATE [annoaccademico] SET WHERE aa = '2015/2016'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2015/2016')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2016/2017')
UPDATE [annoaccademico] SET WHERE aa = '2016/2017'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2016/2017')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2017/2018')
UPDATE [annoaccademico] SET WHERE aa = '2017/2018'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2017/2018')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2018/2019')
UPDATE [annoaccademico] SET WHERE aa = '2018/2019'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2018/2019')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2019/2020')
UPDATE [annoaccademico] SET WHERE aa = '2019/2020'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2019/2020')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2020/2021')
UPDATE [annoaccademico] SET WHERE aa = '2020/2021'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2020/2021')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2021/2022')
UPDATE [annoaccademico] SET WHERE aa = '2021/2022'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2021/2022')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2022/2023')
UPDATE [annoaccademico] SET WHERE aa = '2022/2023'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2022/2023')
GO

IF exists(SELECT * FROM [annoaccademico] WHERE aa = '2024/2025')
UPDATE [annoaccademico] SET WHERE aa = '2024/2025'
ELSE
INSERT INTO [annoaccademico] (aa) VALUES ('2024/2025')
GO

