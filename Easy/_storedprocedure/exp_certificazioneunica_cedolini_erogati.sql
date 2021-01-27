
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_cedolini_erogati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_cedolini_erogati]
GO
 
--exec [exp_certificazioneunica_cedolini_erogati]  2016, NULL
CREATE PROCEDURE [exp_certificazioneunica_cedolini_erogati]
(
	@annodichiarazione int,
	@cf varchar(20)
 ) 
 AS BEGIN
	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1
	DECLARE @maxexpensephase varchar(20)
	SELECT  @maxexpensephase = description  FROM expensephase
	WHERE nphase = (SELECT MAX(nphase) FROM expensephase) 
 
	create table #contratti
	(
		idcon varchar(8),
		ycon int,
		ncon int,
		idpayroll int, -- Cedolino di conguaglio
		idreg int,
		title VARCHAR(200),
		cf varchar(16) 
	)
	
	-- Tabella dei cedolini
	create table #cedolini (
		idcedolino int, 
		ycon int,
		ncon int,
		title varchar(200),
		cf varchar(16),
		idexp int,
		idcon varchar(8),
		npayroll int,
		feegross decimal(19,2),
		datacompetenza datetime, 
		startpayroll datetime,
		stoppayroll datetime,
		contabilizzazione varchar(200),
		description varchar(200),
		mandato varchar(200)
	)
	

	INSERT INTO #contratti
	(
		idreg,
		title,
		cf,
		ycon,
		ncon,
		idcon,
		idpayroll
	)
	
	SELECT DISTINCT co.idreg, registry.title, registry.cf , co.ycon, co.ncon, co.idcon, ce.idpayroll     
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		JOIN registry ON registry.idreg = co.idreg
	WHERE ce.fiscalyear=@annoredditi AND ce.flagbalance = 'S'
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
		AND ce.disbursementdate is not null
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		ORDER BY registry.cf 
		
 --select * from #contratti
		-- a questo punto mi inserisco anche i cedolini non di conguaglio che sono stati erogati
		INSERT INTO #cedolini
		(title, cf, ycon, ncon, idcedolino, npayroll, idexp, idcon, feegross, datacompetenza, startpayroll, stoppayroll,contabilizzazione, description, mandato)
		SELECT  #contratti.title,#contratti.cf,#contratti.ycon, #contratti.ncon, payroll.idpayroll, payroll.npayroll,  
			expensepayroll.idexp,	payroll.idcon,  payroll.feegross,
			transmissiondate, payroll.start, payroll.stop,
			@maxexpensephase + ' ' +convert(varchar(4),expense.ymov) + + '/' + convert(varchar(10),expense.nmov ) ,
			expense.description  as 'Descrizione',
			convert(varchar(4),payment.ypay) + + '/' + convert(varchar(10),payment.npay ) 
		from expensepayroll
		join payroll on payroll.idpayroll=expensepayroll.idpayroll
		join expenselink ON expenselink.idparent = expensepayroll.idexp
		join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
		join expense on expenselast.idexp = expense.idexp 
		join payment on payment.kpay=expenselast.kpay
		join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
		join #contratti on payroll.idcon=#contratti.idcon
		where fiscalyear=@annoredditi 
		order by title,payroll.stop
		 	 
	SELECT title, cf, ycon, ncon, npayroll, feegross as 'Comp. Lordo',  contabilizzazione, description, mandato, datacompetenza as 'Data Trasm.', startpayroll as 'Inizio', stoppayroll as 'Fine' FROM #cedolini


END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
