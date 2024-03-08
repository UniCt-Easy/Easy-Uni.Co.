
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


if exists (select * from dbo.sysobjects where id = object_id(N'[fill_departmenttax]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [fill_departmenttax]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [fill_departmenttax]
(
	@dep varchar(50),
	@ayear smallint, 
	@stop datetime
)
AS BEGIN



CREATE TABLE #tempunifiedtax (
	tempid int identity(1,1),
	[idunifiedtax] [int] NULL ,
	[taxcode] [int] NOT NULL ,
	[nbracket] [int] NULL ,
	[abatements] [decimal](19, 2) NULL ,
	[adminnumerator] [decimal](19, 6) NULL ,
	[admindenominator] [decimal](19, 6) NULL ,
	[adminrate] [decimal](19, 6) NULL ,
	[admintax] [decimal](19, 2) NULL ,
	[employnumerator] [decimal](19, 6) NULL ,
	[employdenominator] [decimal](19, 6) NULL ,
	[employrate] [decimal](19, 6) NULL ,
	[employtax] [decimal](19, 2) NULL ,
	[taxablenumerator] [decimal](19, 6) NULL ,
	[taxabledenominator] [decimal](19, 6) NULL ,
	[taxablegross] [decimal](19, 2) NULL ,
	[taxablenet] [decimal](19, 2) NULL ,
	[exemptionquota] [decimal](19, 2) NULL ,
	[competencydate] [datetime] NULL ,
	[idcity] [int] NULL ,
	[idfiscaltaxregion] [varchar] (5) NULL ,
	[ayear] [smallint] NULL ,
	[ct] [datetime] NOT NULL ,
	[cu] [varchar] (64) NOT NULL ,
	[lt] [datetime] NOT NULL ,
	[lu] [varchar] (64) NOT NULL ,
	[nmonth] [smallint] NULL ,
	[iddbdepartment] [varchar] (50) NULL ,
	[idreg] [int] NULL ,
	[ymov] [smallint] NULL ,
	[nmov] [int] NULL ,
	[npay] [int] NULL ,
	[idexp] [int] NULL,
	trasmdate datetime null,
	servicestart datetime null,
	servicestop datetime null
) 


insert into #tempunifiedtax(taxcode,nbracket,abatements,
		adminnumerator,admindenominator,adminrate,admintax,
		employnumerator,employdenominator,employrate,employtax,
		taxablenumerator,taxabledenominator,
		taxablegross,taxablenet,exemptionquota,competencydate,
		idcity,idfiscaltaxregion,ayear,ct,cu,lt,lu,
		iddbdepartment,idreg,ymov,nmov,npay,idexp,trasmdate,servicestart,servicestop)
select ET.taxcode, ET.nbracket, ET.abatements,
		ET.adminnumerator,ET.admindenominator,ET.adminrate,ET.admintax,
		ET.employnumerator,ET.employdenominator,ET.employrate,ET.employtax,
		ET.taxablenumerator,ET.taxabledenominator,
		ET.taxablegross,ET.taxablenet,ET.exemptionquota,ET.competencydate,
		ET.idcity,ET.idfiscaltaxregion,isnull(ET.ayear,year(paymenttransmission.transmissiondate)) ,getdate(),ET.cu,getdate(),ET.lu,
		@dep,E.idreg,E.ymov,E.nmov,payment.npay,ET.idexp,
		paymenttransmission.transmissiondate,EL.servicestart, EL.servicestop
	from expensetax ET
		join expenselast EL
			on EL.idexp = ET.idexp
		join expense E on 
			E.idexp=ET.idexp
		join payment 
			on payment.kpay = EL.kpay
		join paymenttransmission 
			on paymenttransmission.kpaymenttransmission = 
			payment.kpaymenttransmission
	where  -- ritenute ancora non raccolte del periodo considerato. A gennaio sono prese anche quelle dell'anno precedente
	       -- invece da febbraio in poi tutte quelle dell'anno (sino alla data) ancora non prese	
		ET.idunifiedtax is null 
/*	task 11058 si decide di prendere tutto il non ancora preso	
		and		(  (month(@stop)=1 and (E.ymov=@ayear-1))
					OR
				(month(@stop)>=1 and (E.ymov=@ayear) and (paymenttransmission.transmissiondate<=@stop)  )	
					)
*/

update #tempunifiedtax set nmonth=month(trasmdate)
update #tempunifiedtax set nmonth=12 where ayear<year(trasmdate)
update #tempunifiedtax set ayear=year(trasmdate)-1 where ayear<year(trasmdate)

declare @maxidunifiedtax int
set @maxidunifiedtax= isnull( (select max(idunifiedtax) from unifiedtax),0)
update #tempunifiedtax set idunifiedtax= tempid+@maxidunifiedtax

begin transaction 
insert into unifiedtax (idunifiedtax,taxcode,nbracket,abatements,
		adminnumerator,admindenominator,adminrate,admintax,
		employnumerator,employdenominator,employrate,employtax,
		taxablenumerator,taxabledenominator,
		taxablegross,taxablenet,exemptionquota,competencydate,
		idcity,idfiscaltaxregion,ayear,ct,cu,lt,lu,
		nmonth,iddbdepartment,idreg,ymov,nmov,npay,idexp,servicestart,servicestop)
select  idunifiedtax,taxcode,nbracket,abatements,
		adminnumerator,admindenominator,adminrate,admintax,
		employnumerator,employdenominator,employrate,employtax,
		taxablenumerator,taxabledenominator,
		taxablegross,taxablenet,exemptionquota,competencydate,
		idcity,idfiscaltaxregion,ayear,getdate(),cu,getdate(),lu,
		nmonth,iddbdepartment,idreg,ymov,nmov,npay,idexp,servicestart,servicestop
	from #tempunifiedtax

update UT set UT.idunifiedtax = TEMPU.idunifiedtax  
		from expensetax  UT 
		join #tempunifiedtax TEMPU on UT.idexp=TEMPU.idexp and UT.taxcode=TEMPU.taxcode and UT.nbracket=TEMPU.nbracket

commit transaction



CREATE TABLE #tempunifiedtaxcorrige (
	tempid int identity(1,1),
	[idunifiedtaxcorrige] [int] NULL ,
	[idexpensetaxcorrige] [int] NOT NULL ,
	[taxcode] [int] NOT NULL ,
	[ayear] [smallint] NULL ,
	[employamount] [decimal](19, 2) NULL ,
	[adminamount] [decimal](19, 2) NULL ,
	[idcity] [int] NULL ,
	[idfiscaltaxregion] [varchar] (5) NULL ,
	[adate] [datetime] NULL ,
	[ct] [datetime] NOT NULL ,
	[cu] [varchar] (64) NOT NULL ,
	[lt] [datetime] NOT NULL ,
	[lu] [varchar] (64) NOT NULL ,
	[nmonth] [smallint] NULL ,
	[iddbdepartment] [varchar] (50) NULL ,
	[idreg] [int] NULL ,
	[ymov] [smallint] NULL ,
	[nmov] [int] NULL ,
	[npay] [int] NULL ,
	[idexp] [int] NULL,
	servicestart datetime null,
	servicestop datetime null

)

insert into #tempunifiedtaxcorrige (idexpensetaxcorrige,taxcode,ayear,
					employamount,adminamount,idcity,idfiscaltaxregion,adate,
					ct,cu,lt,lu,
					iddbdepartment,idreg,ymov,nmov,npay,idexp,servicestart,servicestop)
	select EC.idexpensetaxcorrige,EC.taxcode,isnull(EC.ayear, year(EC.adate)),
					EC.employamount,EC.adminamount,EC.idcity,EC.idfiscaltaxregion,EC.adate,
					EC.ct,EC.cu,EC.lt,EC.lu,
					@dep,E.idreg,E.ymov,E.nmov,payment.npay,EC.idexp,EL.servicestart,EL.servicestop
	from expensetaxcorrige EC
		join expenselast EL
			on EL.idexp = EC.idexp
		join expense E on 
			E.idexp=EC.idexp
		join payment 
			on payment.kpay = EL.kpay
		join paymenttransmission 
			on paymenttransmission.kpaymenttransmission = 
			payment.kpaymenttransmission
	where  -- ritenute ancora non raccolte del periodo considerato. A gennaio sono prese anche quelle dell'anno precedente
	       -- invece da febbraio in poi tutte quelle dell'anno (sino alla data) ancora non prese	
		EC.idunifiedtaxcorrige is null 
		/*and
		(  (month(@stop)=1 and (E.ymov=@ayear-1))
		   OR
		   (month(@stop)>=1 and (E.ymov=@ayear) and (EC.adate<=@stop)  )	
		)
		*/

update #tempunifiedtaxcorrige set nmonth=month(adate)
update #tempunifiedtaxcorrige set nmonth=12 where ayear<year(adate)
update #tempunifiedtaxcorrige set ayear=year(adate)-1 where ayear<year(adate)

declare @maxidunifiedtaxcorrige int
set @maxidunifiedtaxcorrige= isnull( (select max(idunifiedtaxcorrige) from unifiedtaxcorrige),0)
update #tempunifiedtaxcorrige set idunifiedtaxcorrige= tempid+@maxidunifiedtaxcorrige



begin transaction 
insert into unifiedtaxcorrige (idunifiedtaxcorrige,idexpensetaxcorrige,taxcode,ayear,
					employamount,adminamount,idcity,idfiscaltaxregion,adate,
					ct,cu,lt,lu,
					nmonth,iddbdepartment,idreg,ymov,nmov,npay,idexp,servicestart,servicestop)
select	idunifiedtaxcorrige,idexpensetaxcorrige,taxcode,ayear,
					employamount,adminamount,idcity,idfiscaltaxregion,adate,
					ct,cu,lt,lu,
					nmonth,iddbdepartment,idreg,ymov,nmov,npay,idexp,servicestart,servicestop
	from #tempunifiedtaxcorrige

update UT set UT.idunifiedtaxcorrige = TEMPU.idunifiedtaxcorrige  
		from expensetaxcorrige  UT 
		join #tempunifiedtaxcorrige TEMPU on UT.idexp=TEMPU.idexp and UT.idexpensetaxcorrige=TEMPU.idexpensetaxcorrige 

commit transaction


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

