
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_contratti_g]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_certificazioneunica_contratti_g
GO
-- setuser 'amministrazione'
-- exp_certificazioneunica_contratti_g 2019
CREATE PROCEDURE exp_certificazioneunica_contratti_g
 -- estraggo l'elenco dei contratti con  problematiche relative alla certificazione unica nell'anno considerato
 (
	@annodichiarazione int
 )
AS BEGIN
	declare @annoredditi int
set @annoredditi = @annodichiarazione -1 

--1) contratti con ritenute fiscali e che sono a loro volta cud di contratti senza ritenute fiscali
SELECT '1 - Contratti con ritenute fiscali inseriti come CUD in altri contratti senza ritenute fiscali' as 'Elenco',   co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  
	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contr. collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		join  exhibitedcud cud on cud.idlinkedcon = co.idcon
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 
	WHERE  
		 NOT EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co1.idser
							AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    )            

		--  mentre il contratto ha ritenute fiscali
		AND EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co.idser
							 AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    ) 
	 
 UNION ALL
	 --select * from exhibitedcud where ayear = 2014

--1) contratti con ritenute fiscali e che sono a loro volta cud di contratti senza ritenute fiscali
SELECT '2 - Contratti senza ritenute fiscali inseriti come CUD in altri contratti con ritenute fiscali' as 'Elenco',   co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  
	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contr. collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		join  exhibitedcud cud on cud.idlinkedcon = co.idcon
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 
	WHERE -- inserito in cud con ritenute fiscali 
		EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co1.idser
							AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    )            
		--  mentre il contratto stesso  non ha ritenute fiscali
		AND NOT EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co.idser
							 AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    ) 
	 
	  UNION ALL
--2) elenco dei contratti non hanno ritenute fiscali, che sono a loro volta cud di altri contratti,  
--   e hanno dei cud collegati con ritenute fiscali 
SELECT '3 Contratti che non hanno ritenute fiscali, inseriti a loro volta come CUD in altri contratti, e aventi dei CUD collegati con ritenute fiscali' as 'Elenco',  co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  
	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contratto Collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		--- il contratto è collegato come cud ad altro contratto 
		join exhibitedcud cud on cud.idlinkedcon = co.idcon
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 


	WHERE  
		--  mentre il contratto stesso non ha ritenute fiscali
		NOT EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co.idser
							 AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    ) 
		--- il contratto contiene altri contratti come cud, i quali contengono le ritenute fiscali		    
		AND EXISTS ( SELECT * FROM exhibitedcud cud1 
		JOIN parasubcontract co2 ON cud1.idcon = co2.idcon
		JOIN parasubcontractyear im2 ON cud1.idcon = im2.idcon AND im2.ayear = @annoredditi 
		WHERE  cud1.idcon = co.idcon
		-- i cud in esso contenuti hanno le ritenute fiscali
		AND EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co2.idser
						AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
					 )    
		)        

		 UNION ALL
--4) contratti con ritenute fiscali e che sono a loro volta cud di contratti non conguagliati nell''anno redditi 
SELECT '4 - Contratti con ritenute fiscali inseriti come CUD in altri contratti non conguagliati nell''anno redditi ' as 'Elenco',   co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  
	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contr. collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		join  exhibitedcud cud on cud.idlinkedcon = co.idcon and cud.fiscalyear = @annoredditi 
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 
	WHERE  
		--  mentre il contratto ha ritenute fiscali
		EXISTS (SELECT * from servicetaxview where servicetaxview.idser = co.idser
							 AND  servicetaxview.taxkind = 1	AND servicetaxview.taxref <> '14_BONUS_FISCALE' AND servicetaxview.geoappliance IS NULL
						    ) 
 
	   AND NOT EXISTS (SELECT * FROM payroll WHERE payroll.idcon = co1.idcon and payroll.fiscalyear = @annoredditi and payroll.flagbalance = 'S' )
	   

	UNION ALL
	SELECT '5 - Contratti con ultimo cedolino non trasmesso inserito come CUD in altri contratti conguagliati nell''anno redditi ' as 'Elenco',   co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  

	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contr. collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		join  exhibitedcud cud on cud.idlinkedcon = co.idcon
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 
	WHERE  --l'ultimo cedolino non è stato trasmesso 
		NOT EXISTS (SELECT * FROM expensepayroll join payroll on payroll.idpayroll=expensepayroll.idpayroll
							 join expenselink ON expenselink.idparent = expensepayroll.idexp
							 join expenselast on expenselast.idexp = expenselink.idchild 
							 join payment on payment.kpay=expenselast.kpay
							 join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission  
							 WHERE payroll.idcon=co.idcon AND payroll.fiscalyear = @annoredditi 
							 AND paymenttransmission.ypaymenttransmission = @annoredditi	
							 AND payroll.npayroll = (select max(npayroll) FROM payroll cedconguaglio where cedconguaglio.idcon=co.idcon AND cedconguaglio.fiscalyear = @annoredditi and
													 cedconguaglio.flagbalance = 'S' )				
	    )            
		--  mentre il contratto ha l'ultimo cedolino erogato e trasmesso
		AND EXISTS (SELECT * FROM expensepayroll join payroll on payroll.idpayroll=expensepayroll.idpayroll
							 join expenselink ON expenselink.idparent = expensepayroll.idexp
							 join expenselast on expenselast.idexp = expenselink.idchild
							 join payment on payment.kpay=expenselast.kpay
							 join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
							 WHERE payroll.idcon=co1.idcon AND payroll.fiscalyear = @annoredditi 
							 AND paymenttransmission.ypaymenttransmission = @annoredditi
							 AND payroll.npayroll = (select max(npayroll) FROM payroll cedconguaglio where cedconguaglio.idcon=co1.idcon AND cedconguaglio.fiscalyear = @annoredditi and
													 cedconguaglio.flagbalance = 'S' )	
	    ) 
	UNION ALL
	--setuser 'amministrazione'
	SELECT '6 - Contratti con due conguagli nell''anno redditi ' as 'Elenco',   co.idcon,co.ycon as 'Es. Contratto', co.ncon as 'N. contratto', co.duty as 'Mansione',  

	co.start as 'Data inizio',  co.stop as 'Data fine',im.flagexcludefromcertificate as 'Escludi da Cert. Unica', r.title as 'Anagrafica', r.cf as 'CF', r.birthdate as 'Nato il', ISNULL(service.servicecode770,service.codeser) as 'Cod. Prest.',
       service.description as 'Prestazione', service.rec770kind as 'Tipo Rec. CU',
	   co1.idcon as 'Inserito come CUD in (idcon)', convert(varchar(4),co1.ycon) + '/'+convert(varchar(10),co1.ncon)    as 'Inserito come CUD in',
	   im1.flagexcludefromcertificate as 'Escludi Contr. collegato da Cert. Unica'
	FROM  
		parasubcontract co  
        JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		join registry R ON R.idreg = co.idreg 
		join  exhibitedcud cud on cud.idlinkedcon = co.idcon
		JOIN parasubcontract co1 ON cud.idcon = co1.idcon
		JOIN parasubcontractyear im1 ON cud.idcon = im1.idcon AND im1.ayear = @annoredditi 
	WHERE  --due o più conguagli 
		 (select COUNT(*) FROM payroll cedconguaglio where cedconguaglio.idcon=co.idcon AND cedconguaglio.fiscalyear = @annoredditi and
													 cedconguaglio.flagbalance = 'S' )>1					
	    OR
		 (select COUNT(*) FROM payroll cedconguaglio where cedconguaglio.idcon=co1.idcon AND cedconguaglio.fiscalyear = @annoredditi and
													 cedconguaglio.flagbalance = 'S' )>1				
		 
	END
	GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
