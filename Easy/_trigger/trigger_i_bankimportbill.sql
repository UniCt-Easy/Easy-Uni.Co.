

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_bankimportbill]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_bankimportbill]
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [trigger_i_bankimportbill]
   ON [bankimportbill] FOR INSERT  
AS 
BEGIN
	SET NOCOUNT ON;
	update bill set total = isnull(total,0)+case when I.amount>0 then I.amount else 0 end,
			 reduction = isnull(reduction,0)+case when I.amount<0 then  -I.amount else 0 end,
			 lt=getdate(),lu='trg'
			from bill
			join inserted I
			on  bill.ybill=i.ybill and bill.nbill=i.nbill and bill.billkind=i.billkind


	insert into bill(billkind,ybill,nbill,
		registry,total,reduction,adate,active,motive,ct,cu,lt,lu,
		idtreasurer, banknum,idbank)
	select I.billkind,I.ybill,I.nbill,I.registry, 
			case when I.amount>0 then I.amount else 0 end,
			 case when I.amount<0 then  -I.amount else 0 end
	,I.adate,'S',I.motive,
	getdate(),'trg',getdate(),'trg',
	I.idtreasurer,I.banknum,I.idbank
	from inserted I
	left  outer join bill b on b.ybill=i.ybill and b.nbill=i.nbill and b.billkind=i.billkind
	where b.ybill is null
   

END
GO
