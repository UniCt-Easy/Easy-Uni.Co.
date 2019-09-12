SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_entry]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_entry]
GO

create        TRIGGER [trigger_i_entry] ON [entry] FOR INSERT
AS BEGIN
	DECLARE @yentry int
	DECLARE @nentry int

	SELECT
		@yentry = yentry, 
		@nentry = nentry
	FROM inserted
	
	insert into entrytotal(yentry, nentry, amount)
	values (@yentry, @nentry, 0)

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 