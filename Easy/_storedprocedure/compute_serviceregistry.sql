
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_serviceregistry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_serviceregistry]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE compute_serviceregistry(
	@ayear	smallint ,
	@semestre int,
	@tipo char(1)
)
AS BEGIN
-- exec compute_serviceregistry 2011, 2,'C'
CREATE TABLE #MYserviceregistry(
	iddbdepartment varchar(50),
	annotation	varchar(400),
	authorizationdate	datetime,
	birthdate	datetime,
	cf	varchar(16),
	codcity	varchar(20),
	description	varchar(200),
	employkind	char(1),
	expectedamount	decimal(19,2),
	flagforeign	char(1),
	forename	varchar(60),
	gender	char(1),
	id_service	varchar(50),
	idacquirekind	varchar(20),
	idapactivitykind	varchar(20),
	idapcontractkind	varchar(20),
	idapmanager	varchar(20),
	idapregistrykind	varchar(20),
	idcity	int,
	idconsultingkind	varchar(20),
	iddepartment	int,
	idfinancialactivity	varchar(20),
	idreg	int,
	idrelated	varchar(50),
	is_annulled	char(1),
	is_blocked	char(1),
	is_changed	char(1),
	is_delivered	char(1),
	nservreg	int,
	officeduty	char(1),
	p_iva	varchar(15),
	pa_cf	varchar(16),
	pa_code	varchar(50),
	pa_title	varchar(80),
	payment	char(1),
	referencerule	varchar(500),
	referencesemester	int,
	regulation	char(1),
	servicevariation	varchar(200),
	start	datetime,
	stop	datetime,
	surname	varchar(60),
	title	varchar(150),
	ypay	int,
	yservreg int,
	paragraph	varchar(50),
	article	varchar(50),
	articlenumber	varchar(50),
	referencedate	datetime,
	idreferencerule	varchar(20),
	idapfinancialactivity	int,
	rulespecifics	char(1),
	expectationsdate	datetime,
	senderreporting	varchar	(20)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @dip_nome varchar(300)
DECLARE @description varchar(150)
DECLARE @name varchar(150)
declare @query nvarchar(4000)

DECLARE crsdepartment INSENSITIVE CURSOR FOR
	SELECT iddbdepartment FROM dbdepartment
	WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	OPEN crsdepartment 
FETCH NEXT FROM crsdepartment INTO @iddbdepartment

        WHILE @@fetch_status=0 begin
        	SET @dip_nome = @iddbdepartment + '.serviceregistry'
			
                SET  @query = ' 
							INSERT INTO #MYserviceregistry(iddbdepartment,
							annotation, authorizationdate, birthdate, cf, codcity, description, employkind,expectedamount,
							flagforeign, forename, gender, id_service, idacquirekind, idapactivitykind, idapcontractkind, idapmanager,
							idapregistrykind,  idcity, idconsultingkind, iddepartment, idfinancialactivity, idreg,idrelated,
							is_annulled, is_blocked, is_changed, is_delivered,  nservreg, officeduty, p_iva, pa_cf,	pa_code,
							pa_title, payment, 	referencerule, referencesemester,   regulation, servicevariation, start, stop,
							surname, title, ypay, yservreg,
							paragraph,article,articlenumber,referencedate,idreferencerule,idapfinancialactivity,rulespecifics,expectationsdate,senderreporting
							)'
							+
							'select ' +''''+ @iddbdepartment+'''' +'as iddbdepartment,
							annotation, authorizationdate, birthdate, cf, codcity,  description, employkind,expectedamount,
							flagforeign, forename, gender, id_service, idacquirekind, idapactivitykind, idapcontractkind, idapmanager,
							idapregistrykind,  idcity, idconsultingkind, iddepartment, idfinancialactivity, idreg,idrelated,
							is_annulled, is_blocked, is_changed, is_delivered,  nservreg, officeduty, p_iva, pa_cf,	pa_code,
							pa_title, payment, 	referencerule, referencesemester,   regulation, servicevariation, start, stop,
							surname, title, ypay, yservreg,
							paragraph,article,articlenumber,referencedate,idreferencerule,idapfinancialactivity,rulespecifics,expectationsdate,senderreporting
							from '       
                                + @dip_nome
                                + ' where yservreg =  '+ convert(varchar(4), @ayear)
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
	DELETE FROM #MYserviceregistry WHERE idreg not in (select idreg from address where idaddress = @idaddress)
End


SELECT 
	iddbdepartment,
	annotation, authorizationdate, birthdate, cf, codcity,  description, employkind,expectedamount,
	flagforeign, forename, gender, id_service, idacquirekind, idapactivitykind, idapcontractkind, idapmanager,
	idapregistrykind,  idcity, idconsultingkind, iddepartment, idfinancialactivity, idreg,idrelated,
	is_annulled, is_blocked, is_changed, is_delivered,  nservreg, officeduty, p_iva, pa_cf,	pa_code,
	pa_title, payment, 	referencerule, referencesemester,   regulation, servicevariation, start, stop,
	surname, title, ypay, yservreg,
	paragraph,article,articlenumber,referencedate,idreferencerule,idapfinancialactivity,
	rulespecifics,expectationsdate,senderreporting  
FROM #MYserviceregistry
WHERE employkind = @tipo
	AND ( referencesemester = @semestre OR @semestre IS NULL) 

-- DROP TABLE #MYserviceregistry


END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
