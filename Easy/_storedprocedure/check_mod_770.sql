
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_mod_770]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_mod_770]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  PROCEDURE [check_mod_770]
(
	@ayear		  int ,
	@kind         char(1)
)
AS BEGIN
--setuser'amm'
/*
exec [check_mod_770] 2014, 'H'
*/
--SET      @res = 0	
CREATE TABLE #errors (errordescr varchar(255), errorcode int, blockingerror char(1))

if (@kind = 'G') 
BEGIN
--1) Contratti Non Pagati
 if exists (
            select distinct parasubcontract.ycon, 
                  parasubcontract.ncon, exhibitedcud.idexhibitedcud 
           FROM parasubcontract 
           JOIN parasubcontractyear 
             ON parasubcontractyear.idcon =  parasubcontract.idcon  
            AND parasubcontractyear.ayear = @ayear
           join payroll on payroll.idcon = parasubcontract.idcon 
           left outer join exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon 
           where not exists (select * from expensepayroll 
			   join expenselink ON expenselink.idparent = expensepayroll.idexp 
			   join expenselast on expenselast.idexp = expenselink.idchild 
			   join payment on payment.kpay = expenselast.kpay 
			   where payment.kpaymenttransmission is not null 
				and payroll.idpayroll = expensepayroll.idpayroll)
            and isnull(payroll.flagbalance,'N')='N' 
            and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N'  
            and payroll.fiscalyear = @ayear
            and exhibitedcud.fiscalyear = @ayear
) 
begin
	INSERT INTO #errors VALUES('Contratti con cedolini non erogati', 1,'S')
end

--2) Prestazioni Certificazioni CUD
if exists (
     SELECT DISTINCT service.description, parasubcontract.ycon, 
		  parasubcontract.ncon 
           FROM parasubcontract 
           JOIN parasubcontractyear 
			   ON parasubcontractyear.idcon =  parasubcontract.idcon 
            AND parasubcontractyear.ayear =  @ayear
           JOIN registry ON parasubcontract.idreg = registry.idreg 
           JOIN exhibitedcud on exhibitedcud.idlinkedcon = parasubcontract.idcon 
           JOIN service ON service.idser = parasubcontract.idser 
          WHERE EXISTS (select * from payroll JOIN expensepayroll 
			   ON payroll.idpayroll = expensepayroll.idpayroll 
           JOIN expenselink ON expenselink.idparent = expensepayroll.idexp 
           JOIN expenselast on expenselast.idexp = expenselink.idchild 
           WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear = @ayear) 
             AND exhibitedcud.fiscalyear = @ayear
             AND isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' 
             AND ISNULL(service.rec770kind,'')<> 'G' 
) 
begin
	INSERT INTO #errors VALUES('Contratti esibiti come CUD, le cui prestazioni non sono associate al modello 770 ', 2,'S')
end
--3) Prestazioni Certificazioni In Non CUD
if exists (
       			SELECT DISTINCT service.description, parasubcontract.ycon,
                 parasubcontract.ncon 
                 FROM parasubcontract 
                 JOIN parasubcontractyear 
                 ON  parasubcontractyear.idcon =  parasubcontract.idcon 
                 AND  parasubcontractyear.ayear = @ayear
                 JOIN registry ON parasubcontract.idreg = registry.idreg 
                 JOIN exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon 
                 JOIN service ON service.idser = parasubcontract.idser 
           WHERE EXISTS (select * from payroll 
			  JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll 
            JOIN expenselink ON expenselink.idparent = expensepayroll.idexp 
            JOIN expenselast on expenselast.idexp = expenselink.idchild 
           WHERE payroll.idcon = parasubcontract.idcon  
			 AND payroll.fiscalyear =  @ayear) 
           AND   exhibitedcud.fiscalyear = @ayear 
           and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' 
           AND   ISNULL(service.rec770kind,'')<> 'G'  
) 
begin
	INSERT INTO #errors VALUES('Contratti contenenti CUD, con prestazioni 
	non configurate per il modello 770:', 3,'S')
end
--4) CUD in Contratti Non Conguagliati
if exists (
   SELECT parasubcontract.ycon, parasubcontract.ncon, registry.title  
     FROM parasubcontract 
     JOIN parasubcontractyear 
       ON  parasubcontractyear.idcon =  parasubcontract.idcon 
      AND  parasubcontractyear.ayear = @ayear  
     JOIN registry ON parasubcontract.idreg = registry.idreg 
     JOIN service ON service.idser = parasubcontract.idser 
     join exhibitedcud on parasubcontract.idcon = exhibitedcud.idcon 
    WHERE  EXISTS (select * from payroll 
                  WHERE payroll.idcon = parasubcontract.idcon 
                   and payroll.flagbalance = 'S' 
                   and disbursementdate is null 
                   and payroll.fiscalyear = @ayear
                   and exhibitedcud.fiscalyear = @ayear)  
                   and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' 
                   AND ISNULL(service.rec770kind,'') = 'G'
) 
begin
	INSERT INTO #errors VALUES('Percipienti che hanno presentato 
	CUD inseriti in altri contratti di cui è stato erogato il conguaglio ', 4,'S')
end
END
--5) Prestazioni Senza Causale
if ((@kind = 'H') AND
exists (
SELECT DISTINCT isnull(service.servicecode770, service.codeser) as servicecode770, service.description as description
FROM expense 
JOIN expenselast on expense.idexp = expenselast.idexp 
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN service on service.idser=expenselast.idser 
LEFT OUTER JOIN motive770service M 
	ON M.idser = service.idser 
	AND M.ayear  = @ayear  
JOIN registry ON expense.idreg = registry.idreg 
WHERE registry.idregistryclass <> '10'  
	        AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' 
	        AND registryrole.idreg = expense.idreg)  
	        AND  year(paymenttransmission.transmissiondate) = @ayear  
	        AND service.rec770kind = 'H'  
	        AND ((select expenseyear.amount from expenseyear 
	        where expenseyear.idexp = expenselast.idexp) 
	        + ISNULL(  
	        (SELECT SUM(amount) FROM expensevar 
	         WHERE expensevar.idexp = expense.idexp 
             AND  expensevar.yvar = @ayear
	         AND ISNULL(autokind,0) <> 4) 
	         ,0)) > 0  
	         and (select count(*) from expensetax where expensetax.idexp=expense.idexp) > 0 
	        and m.idmot is null 
) )
begin
	INSERT INTO #errors VALUES('Prestazioni record H senza causale.', 5,'S')
end

--6) Presenza Provvigioni
if ((@kind = 'H') AND
exists (

            SELECT DISTINCT registry.title AS title, 
			  ISNULL(registry.cf, registry.foreigncf) AS cf  
            FROM expense  
            JOIN expenselast on expense.idexp = expenselast.idexp 
            JOIN payment  
              ON payment.kpay = expenselast.kpay 
            JOIN paymenttransmission  
              ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission  
            JOIN service on service.idser=expenselast.idser  
            LEFT OUTER JOIN motive770service M
              ON M.idser = service.idser
             AND M.ayear = @ayear  
            JOIN registry ON expense.idreg = registry.idreg 
            WHERE registry.idregistryclass <> '10' 
            AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' 
			  AND registryrole.idreg = expense.idreg)
            AND year(paymenttransmission.transmissiondate) = @ayear
            AND service.rec770kind = 'H'
            AND ((select expenseyear.amount from expenseyear 
					where expenseyear.idexp = expenselast.idexp)  
                  + ISNULL( 
            (SELECT SUM(amount) FROM expensevar
             WHERE expensevar.idexp = expense.idexp
             AND expensevar.yvar <= @ayear 
             AND ISNULL(autokind,0) <> 4) ,0)) > 0 
              AND
            (select count(*) from expensetax where 
                 expensetax.idexp=expense.idexp) > 0 
             AND isnull(service.servicecode770, service.codeser) = '07_PROVVIGIONI'
)) 
begin
	INSERT INTO #errors VALUES('Sono state pagate delle provvigioni. Controllare le causali delle dichiarazioni nelle quali sono state usate', 6,'S')
end

select * from #errors

END
 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
 
