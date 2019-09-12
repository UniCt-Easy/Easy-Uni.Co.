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
