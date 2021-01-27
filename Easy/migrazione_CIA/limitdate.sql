
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



