if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitgirofondiprestiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitgirofondiprestiti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--exp_sitgirofondiprestiti null,'S'
CREATE   PROCEDURE exp_sitgirofondiprestiti
	@idtreasurersource   int=null, --> Cassiere del Dipartimento
	@showdetail char(1)
	AS
BEGIN
 
-- Deve essere specificato almeno un cassiere
	DECLARE @Dettagli TABLE(
	idtreasurersource int,
	idtreasurerdest int,
	description varchar(200),
	amountprestato decimal(19,2),
	amountricevuto decimal(19,2),
	ytransfer smallint,
	ntransfer int,
	adate datetime
	)

	INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, description, amountprestato, ytransfer, ntransfer, adate)
	SELECT idtreasurersource, idtreasurerdest,description, amount, ytransfer, ntransfer,adate
	FROM moneytransfer 
	WHERE 
		(idtreasurersource = @idtreasurersource) 
		and transferkind = 'P'
		
	INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, description,amountricevuto, ytransfer, ntransfer, adate)
	SELECT idtreasurerdest, idtreasurersource,description,  - amount, ytransfer, ntransfer,adate 
	FROM moneytransfer 
	WHERE 	(idtreasurerdest = @idtreasurersource ) 
		and transferkind = 'P'

if(@showdetail = 'S')
Begin
	SELECT 
		isnull(T1.header, T1.description) as 'Cassiere Principale',
		D.ytransfer as  'Eserc.Girofondo',
		D.ntransfer as  'Num.Girofondo',
		D.description as 'Descrizione',
		D.adate as 'Data Girofondo',
		D.amountprestato as 'Importo Erogato',
		-(D.amountricevuto) as 'Importo Ricevuto',
		isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
	FROM  @Dettagli D
	JOIN treasurer T1
		on D.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on D.idtreasurerdest = T2.idtreasurer 
	order by isnull(T1.header, T1.description), isnull(T2.header, T2.description), D.adate, D.ntransfer


End
Else
Begin	
	SELECT 
		isnull(T1.header, T1.description) as 'Cassiere Principale',
		sum(D.amountprestato) as 'Importo Erogato',
		-(sum(D.amountricevuto)) as 'Importo Ricevuto',
		case when ( sum(isnull(D.amountprestato,0) + isnull(D.amountricevuto,0)) )>0  --> Il segno � +, perch� il campo � memorizzato col -.
			then sum(isnull(D.amountprestato,0) + isnull(D.amountricevuto,0))
			else null 
		end  as 'Girofondi da ricevere',
		case when ( sum(isnull(D.amountprestato,0) + isnull(D.amountricevuto,0)) )< 0
			then -(sum(isnull(D.amountprestato,0) + isnull(D.amountricevuto,0)))
			else null 
		end  as 'Girofondi da effettuare',
		isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
	FROM  @Dettagli D
	JOIN treasurer T1
		on D.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on D.idtreasurerdest = T2.idtreasurer 
	group by isnull(T1.header, T1.description), isnull(T2.header, T2.description)
	order by isnull(T1.header, T1.description), isnull(T2.header, T2.description)

End
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


	
