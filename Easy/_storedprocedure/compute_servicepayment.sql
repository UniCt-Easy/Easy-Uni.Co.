
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_servicepayment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_servicepayment]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE compute_servicepayment(
	@ayear	smallint,
	@tipo char(1) 
)
AS BEGIN

-- exec compute_servicepayment 2011, 'C'
CREATE TABLE #MYservicepayment(
	iddbdepartment varchar(50),
	is_blocked	char(1),
	is_changed	char(1),
	is_delivered	char(1),
	nservreg	int,
	payedamount	decimal(19,2),
	semesterpay	int,
	ypay	int,
	yservreg	int,
	idreg int,
	employkind	char(1)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @dip_nome varchar(300)
DECLARE @dip_nome2 varchar(300)
DECLARE @description varchar(150)
DECLARE @name varchar(150)
declare @query nvarchar(4000)

DECLARE crsdepartment INSENSITIVE CURSOR FOR
	SELECT iddbdepartment FROM dbdepartment 
	WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	OPEN crsdepartment 
FETCH NEXT FROM crsdepartment INTO @iddbdepartment

        WHILE @@fetch_status=0 begin
        	SET @dip_nome = @iddbdepartment + '.servicepayment'
			SET @dip_nome2 = @iddbdepartment + '.serviceregistry'
                SET  @query = ' 
							INSERT INTO #MYservicepayment(iddbdepartment,
							is_blocked,is_changed,is_delivered,nservreg,payedamount,semesterpay,ypay,yservreg, idreg, employkind)'
							+
							' SELECT  ' +''''+ @iddbdepartment+'''' +'as iddbdepartment,
							P.is_blocked, P.is_changed, P.is_delivered, P.nservreg, P.payedamount, P.semesterpay, P.ypay, P.yservreg, R.idreg, R.employkind
							FROM ' + @dip_nome + ' as P'
							+ ' JOIN ' + @dip_nome2 + ' as R'
							+ ' ON P.yservreg = R.yservreg AND P.nservreg = R.nservreg'
                            + ' WHERE P.yservreg =  '+ convert(varchar(4), @ayear)
               EXEC sp_executesql @query
PRINT @query

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

deallocate crsdepartment

-- Per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
-- ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
DECLARE @codeaddress varchar(20)
SET @codeaddress = '07_SW_ANP'

DECLARE @idaddress int
SELECT @idaddress = idaddress from address WHERE @codeaddress = '07_SW_ANP'
if (@tipo='d')
Begin
	DELETE FROM #MYservicepayment WHERE idreg not in (select idreg from address where idaddress = @idaddress)
End

SELECT 
	iddbdepartment,
	is_blocked,is_changed,is_delivered,nservreg,payedamount,semesterpay,ypay,yservreg, idreg
FROM #MYservicepayment
WHERE employkind = @tipo
	/*AND (
		( @Paythisyear='S' AND ypay = yservreg ) 
		OR ( @Paythisyear='N')
		)*/

-- DROP TABLE #MYservicepayment


END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


