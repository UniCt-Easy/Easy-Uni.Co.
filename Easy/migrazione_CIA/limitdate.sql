update finvar set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),yvar), 105)
		where year(adate)>yvar
go

update expensevar set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),yvar), 105)
		where year(adate)>yvar
go

update incomevar set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),yvar), 105)
		where year(adate)>yvar
go

update expense set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ymov), 105)
		where year(adate)>ymov
go

update income set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ymov), 105)
		where year(adate)>ymov
go


update payment set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ypay), 105)
		where year(adate)>ypay
go

update proceeds set adate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ypro), 105)
		where year(adate)>ypro
go


update payment set printdate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ypay), 105)
		where year(adate)>ypay
go

update proceeds set printdate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ypro), 105)
		where year(adate)>ypro
go


update paymenttransmission set transmissiondate=CONVERT(datetime, '31-12-' + CONVERT(char(4),ypaymenttransmission), 105)
		where year(transmissiondate)>ypaymenttransmission
go

update proceedstransmission set transmissiondate=CONVERT(datetime, '31-12-' + CONVERT(char(4),yproceedstransmission), 105)
		where year(transmissiondate)>yproceedstransmission
go


--/////////////////////////////////////////////////////////////////////////


update finvar set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),yvar), 105)
		where year(adate)<yvar
go

update expensevar set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),yvar), 105)
		where year(adate)<yvar
go

update incomevar set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),yvar), 105)
		where year(adate)<yvar
go

update expense set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ymov), 105)
		where year(adate)<ymov
go

update income set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ymov), 105)
		where year(adate)<ymov
go


update payment set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ypay), 105)
		where year(adate)<ypay
go

update proceeds set adate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ypro), 105)
		where year(adate)<ypro
go


update payment set printdate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ypay), 105)
		where year(adate)<ypay
go

update proceeds set printdate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ypro), 105)
		where year(adate)<ypro
go


update paymenttransmission set transmissiondate=CONVERT(datetime, '01-01-' + CONVERT(char(4),ypaymenttransmission), 105)
		where year(transmissiondate)<ypaymenttransmission
go

update proceedstransmission set transmissiondate=CONVERT(datetime, '01-01-' + CONVERT(char(4),yproceedstransmission), 105)
		where year(transmissiondate)<yproceedstransmission
go



