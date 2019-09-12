if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modpagamerrateinexpenselast]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modpagamerrateinexpenselast]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_modpagamerrateinexpenselast(@esercizio int) as
begin
	create table #tabella (
		npay int,
		nmov int,
		paymethod varchar(50),
		treasurer varchar(150),
		errore varchar(200),
		iban varchar(50),
		cin varchar(2),
		el_idbank varchar(20),
		el_idcab varchar(20),
		cc varchar(30),
		tr_idbank varchar(20),
		tr_idcab varchar(20)
	)

	insert into #tabella
		select payment.npay, expense.nmov, paymethod.description, treasurer.description,
		'Non si devono specificare le coordinate bancarie',
		expenselast.iban, expenselast.cin, expenselast.idbank, expenselast.idcab, expenselast.cc, 
		treasurer.idbank, treasurer.idcab
		from expenselast
		join paymethod on paymethod.idpaymethod = expenselast.idpaymethod
		join expense on expense.idexp = expenselast.idexp
		left outer join payment on expenselast.kpay = payment.kpay
		left outer join treasurer on treasurer.idtreasurer = payment.idtreasurer
		where (paymethod.flag & 8) <> 0 and (expenselast.kpay is null or payment.kpaymenttransmission is null)
		and (expenselast.iban is not null or expenselast.idbank is not null or expenselast.idcab is not null or expenselast.cc is not null)
		and expense.ymov = @esercizio
	
	insert into #tabella
		select payment.npay, expense.nmov, paymethod.description, treasurer.description,
		'Le coordinate bancarie sono obbligatorie',
		expenselast.iban, expenselast.cin, expenselast.idbank, expenselast.idcab, expenselast.cc, 
		treasurer.idbank, treasurer.idcab
		from expenselast
		join paymethod on paymethod.idpaymethod = expenselast.idpaymethod
		join expense on expense.idexp = expenselast.idexp
		left outer join payment on expenselast.kpay = payment.kpay
		left outer join treasurer on treasurer.idtreasurer = payment.idtreasurer
		where (paymethod.flag & 4) <> 0 and (expenselast.kpay is null or payment.kpaymenttransmission is null)
		and expenselast.idbank is null and expenselast.idcab is null and expenselast.cc is null
		and expense.ymov = @esercizio
	
	insert into #tabella
		select payment.npay, expense.nmov, paymethod.description, treasurer.description,
		'Specificare il numero di conto e non le altre coordinate bancarie',
		expenselast.iban, expenselast.cin, expenselast.idbank, expenselast.idcab, expenselast.cc, 
		treasurer.idbank, treasurer.idcab
		from expenselast
		join paymethod on paymethod.idpaymethod = expenselast.idpaymethod
		join expense on expense.idexp = expenselast.idexp
		left outer join payment on expenselast.kpay = payment.kpay
		left outer join treasurer on treasurer.idtreasurer = payment.idtreasurer
		where (paymethod.flag & 2) <> 0 and (expenselast.kpay is null or payment.kpaymenttransmission is null)
		and (expenselast.iban is not null or expenselast.idbank is not null or expenselast.idcab is not null or expenselast.cc is null)
		and expense.ymov = @esercizio

	select
		'Mandato' = npay,
		'Mov' = nmov,
		'Tesoriere' = treasurer,
		'Pagamento' = paymethod,
		'Errore'= errore,
		'Iban' = iban,
		'Cin' = cin,
		'Conto' = cc,
		'Abi nel mov' = el_idbank,
		'Cab nel mov' = el_idcab,
		'Abi nel tesoriere' = tr_idbank,
		'Cab nel tesoriere' = tr_idcab
		from #tabella 
		order by npay, nmov
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

