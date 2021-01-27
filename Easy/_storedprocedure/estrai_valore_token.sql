
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


 /****** Object:  UserDefinedFunction [dbo].[estrai_valore_token]    Script Date: 10/26/2015 10:43:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estrai_valore_token]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[estrai_valore_token]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  UserDefinedFunction [dbo].[estrai_valore_token]    Script Date: 10/26/2015 10:41:33 ******/
CREATE FUNCTION [dbo].[estrai_valore_token](@template [nvarchar](max), @S [nvarchar](max), @token [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [Sqlfunctions].[SqlFun].[estrai_valore_token]
GO

 sp_configure 'clr enabled', 1;
 RECONFIGURE
 go
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
