
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[fill_departmentclawback]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [fill_departmentclawback]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [fill_departmentclawback]
(
	@dep varchar(50),
	@ayear smallint, 
	@stop datetime
)
AS BEGIN

--[fill_departmentclawback] 'amm', 2013, {d '2013-12-31'}

CREATE TABLE #tempunifiedclawback (
	tempid int identity(1,1),
	idunifiedclawback int,
	amount decimal(19,2),
	iddbdepartment varchar(50),
	idreg int ,
	ct datetime,
	cu varchar(64),
	lt datetime,
	lu varchar(64),
	idclawback  int,
	ymov int,
	nmov int ,
	npay int ,
	idexp int ,
	fiscaltaxcode varchar(20),
	identifying_marks varchar(20),
	code varchar(10),
	tiporiga char,
	rifb_month int,
	rifb_year int,
	rifa_month int ,
	rifa_year int ,
	rifa varchar(10),
	trasmdate datetime null,
	ayear int,
	nmonth int
) 


insert into #tempunifiedclawback(amount, 
iddbdepartment, idreg, ct, cu, lt, lu,
idclawback, ymov, nmov,npay, idexp, fiscaltaxcode, identifying_marks,
code, tiporiga, rifb_month, rifb_year, rifa_month, rifa_year,rifa, trasmdate,ayear,nmonth)
select amount, @dep, E.idreg, getdate(),EC.cu,getdate(),EC.lu,EC.idclawback, 
	   E.ymov, E.nmov,payment.npay,EC.idexp, EC.fiscaltaxcode, EC.identifying_marks,
	   EC.code, EC.tiporiga, EC.rifb_month, EC.rifb_year, EC.rifa_month, EC.rifa_year, EC.rifa,
	   paymenttransmission.transmissiondate,year(paymenttransmission.transmissiondate), month(paymenttransmission.transmissiondate)
	from expenseclawback EC
		join clawback C
			ON EC.idclawback = C.idclawback 
			AND ISNULL(C.flagf24ep,'N') = 'S' 
		join expenselast EL
			on EL.idexp = EC.idexp
		join expense E on 
			E.idexp=EC.idexp
		join payment 
			on payment.kpay = EL.kpay
		join paymenttransmission 
			on paymenttransmission.kpaymenttransmission = 
			payment.kpaymenttransmission
	where  	
		EC.idunifiedclawback is null and
		(  (month(@stop)=1 and (E.ymov=@ayear-1))
		   OR
		   (month(@stop)>=1 and (E.ymov=@ayear) and (paymenttransmission.transmissiondate<=@stop)  )	
		)

declare @maxidunifiedclawback int
set @maxidunifiedclawback= isnull( (select max(idunifiedclawback) from unifiedclawback),0)
update #tempunifiedclawback set idunifiedclawback= tempid+@maxidunifiedclawback

--select * from #tempunifiedclawback

begin transaction 
insert into unifiedclawback(idunifiedclawback, amount, 
	iddbdepartment, idreg, ct, cu, lt, lu,
	idclawback, ymov, nmov,npay, idexp, fiscaltaxcode, identifying_marks,
	code, tiporiga, rifb_month, rifb_year, rifa_month, rifa_year,rifa,
	ayear, nmonth
		)
select  @maxidunifiedclawback + tempid, amount, 
	iddbdepartment, idreg, ct, cu, lt, lu,
	idclawback, ymov, nmov,npay, idexp, fiscaltaxcode, identifying_marks,
	code, tiporiga, rifb_month, rifb_year, rifa_month, rifa_year,rifa ,	ayear, nmonth
	from #tempunifiedclawback

update UC set UC.idunifiedclawback= TEMPU.idunifiedclawback 
  from expenseclawback  UC 
  join #tempunifiedclawback TEMPU on UC.idexp = TEMPU.idexp and UC.idclawback = TEMPU.idclawback  

commit transaction

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

