
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


--[DBO]--
-- CREAZIONE PROCEDURE [dbo].[GenerateRule]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[GenerateRule]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GenerateRule]
GO
CREATE PROCEDURE [dbo].[GenerateRule]
            @table varchar(1024)
           ,@code varchar(30)
           ,@message varchar(960)
           ,@post char(1)
           ,@warning char(1)
           ,@ins char(1)
           ,@upd char(1)
           ,@del char(1)
           ,@sql varchar(6000)
	   ,@executor varchar(60)				-- utente che sta eseguento la procedura (per il log)
	  AS
BEGIN

	IF NOT EXISTS(select [idaudit] from [amministrazione].[audit] where [idaudit] = @code) 
	BEGIN 
		INSERT INTO [amministrazione].[audit]
           ([idaudit]
           ,[consequence]
           ,[flagsystem]
           ,[lt]
           ,[lu]
           ,[severity]
           ,[title])
		VALUES
           (@code
           ,null
           ,'N'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,CASE WHEN @warning = 'B' THEN 'E' ELSE 'W' END --E bloccante W warning
           ,substring(@code + ' - ' + @message,0,127))
	END

	IF (@ins = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'I' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheck int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'I'
           ,@code
           ,@idcheck
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

	IF (@upd = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'U' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheckU int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'U'
           ,@code
           ,@idcheckU
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

	IF (@del = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'D' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheckD int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'D'
           ,@code
           ,@idcheckD
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

END
GO
