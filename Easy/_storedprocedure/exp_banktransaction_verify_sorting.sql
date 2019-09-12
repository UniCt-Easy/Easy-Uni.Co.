if exists (select * from dbo.sysobjects where id = object_id(N'[exp_banktransaction_verify_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_banktransaction_verify_sorting]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [exp_banktransaction_verify_sorting]

 @ayear int,
 @start datetime,
 @stop datetime,
 @codesorkind varchar(20)

AS BEGIN



select 
	bt.amount,
	SUM(bts2.amount) AS 'Classificato', 
	bt.amount - SUM( bts2.amount) AS 'Da Classificare', 
	bt.yban, 
	bt.nban 
from banktransaction bt
	join banktransactionsorting bts2
		 on bt.yban = bts2.yban
		and bt.nban = bts2.nban
	join sorting s
		on bts2.idsor = s.idsor
	join sortingkind sk
		on s.idsorkind = sk.idsorkind
	where bt.amount != (select sum(bts.amount) from  banktransactionsorting bts
						where  bt.yban = bts.yban
								and bt.nban = bts.nban
						group by bts.yban, bts.nban)
and sk.codesorkind =@codesorkind
and bt.yban = @ayear 
and (transactiondate >= @start OR @start = null)
and (transactiondate <= @stop OR @stop = null)
GROUP BY bt.yban, bt.nban ,bt.amount
ORDER BY bt.yban, bt.nban

END




