
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_serviceregistrysingle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_serviceregistrysingle]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE check_serviceregistrysingle(
	@ayear	smallint 
)
AS BEGIN

-- exec check_serviceregistrysingle 2010
CREATE TABLE #error (message varchar(400))


INSERT INTO #error (message)
(SELECT 'L'' incarico ' + CONVERT(varchar(6),serviceregistry.yservreg)  + '/'+CONVERT(varchar(6),serviceregistry.nservreg)
 + ' ha codice Attività Economica non valido'
FROM serviceregistry 
JOIN financialactivity 
	ON serviceregistry.idfinancialactivity = financialactivity.idfinancialactivity 
WHERE financialactivity.ayear = @ayear and active='N'
)


INSERT INTO #error (message)
(SELECT 'L'' incarico ' + CONVERT(varchar(6),serviceregistry.yservreg)  + '/'+CONVERT(varchar(6),serviceregistry.nservreg)
 + ' ha codice Tipo Rapporto non valido'
FROM serviceregistry  
JOIN apcontractkind 
	 ON serviceregistry.idapcontractkind = apcontractkind.idapcontractkind 
 WHERE apcontractkind.ayear = @ayear and active='N' 
)


INSERT INTO #error (message)
(SELECT 'L'' incarico ' + CONVERT(varchar(6),serviceregistry.yservreg)  + '/'+CONVERT(varchar(6),serviceregistry.nservreg)
 + ' ha codice Modalità Acquisizione non valido'
FROM serviceregistry  
JOIN acquirekind 
	ON serviceregistry.idacquirekind=acquirekind.idacquirekind
WHERE acquirekind.ayear = @ayear and active='N' 
)

INSERT INTO #error (message)
(SELECT 'L'' incarico ' + CONVERT(varchar(6),serviceregistry.yservreg)  + '/'+CONVERT(varchar(6),serviceregistry.nservreg)
 + ' ha Esercizio Incarico incoerente con il periodo della prestazione avente '
	+'Data Inizio '+
	Convert (varchar(2),datepart(dd,serviceregistry.start))+'/'+Convert (varchar(2),datepart(mm,serviceregistry.start))+ '/'+Convert (varchar(4),datepart(yy,serviceregistry.start))
	+' Data Fine '+
	Convert (varchar(2),datepart(dd,serviceregistry.stop))+'/'+Convert (varchar(2),datepart(mm,serviceregistry.stop))+ '/'+Convert (varchar(4),datepart(yy,serviceregistry.stop))
FROM serviceregistry 
WHERE yservreg < year(start) OR 
       (yservreg> year(stop) and year(stop) is not null ) 
	and yservreg = @ayear
)

 
INSERT INTO #error (message)
(SELECT 'Il pagamento non sarà trasmesso ' + CONVERT(varchar(6),servicepayment.yservreg)  + '/'+CONVERT(varchar(6),servicepayment.nservreg)
 + ' perchè si riferisce ad un incarico con anno di riferimento diverso da quello del pagamento '
FROM servicepayment
WHERE yservreg <> ypay
	and yservreg = @ayear
)

DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento'  
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')


IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT @departmentname as 'Dipartimento', message FROM #error
	RETURN
END

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


