SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- notifyStatusChange 'RICH',2016,1
if exists (select * from dbo.sysobjects where id = object_id(N'[notifyStatusChange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [notifyStatusChange]
GO

CREATE PROCEDURE [notifyStatusChange]
(
	@idcustomuser varchar(50),
	@idflowchart varchar(50),
	@idmankind varchar(20),
	@yman smallint,
	@nman int
) AS
BEGIN
	select 'x'
	
END


