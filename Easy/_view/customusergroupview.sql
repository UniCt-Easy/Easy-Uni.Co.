-- CREAZIONE VISTA [customusergroupview]
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customusergroupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[customusergroupview]
GO

CREATE VIEW dbo.customusergroupview
AS  
SELECT  
			 U.idcustomuser, U.username,G.idcustomgroup,G.groupname  , G.description
FROM         dbo.customusergroup   CUG
JOIN		 dbo.customuser  U ON   CUG.idcustomuser = U.idcustomuser
JOIN		 dbo.customgroup G ON   CUG.idcustomgroup = G.idcustomgroup
                     

GO


 