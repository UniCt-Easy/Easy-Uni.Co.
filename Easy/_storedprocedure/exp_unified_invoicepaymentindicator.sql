
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_invoicepaymentindicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_invoicepaymentindicator]
GO

 
CREATE  PROCEDURE [exp_unified_invoicepaymentindicator](
	@year 			int,
	@idivaregisterkind 	int,
	@idinvkind 		int, 	
	@start datetime,
	@stop datetime,
	@unified char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@mode char(1)-- M: Considera la data Mandato	T: Considera la data Trasmissione
) 

AS BEGIN	

/*
Ultima modifica Gianni 31/01/2015

*/

	DECLARE @codeinvkind  varchar(20)
	SET @codeinvkind = (SELECT codeinvkind FROM invoicekind WHERE idinvkind = @idinvkind)
	
	DECLARE @codeivaregisterkind varchar(20)
	DECLARE @idivaregisterkindunified int
	SELECT  @codeivaregisterkind	  = codeivaregisterkind,
		    @idivaregisterkindunified = idivaregisterkindunified  FROM ivaregisterkind WHERE idivaregisterkind = @idivaregisterkind


	print @idivaregisterkindunified

	IF (@unified <> 'S')
	BEGIN
	        EXEC exp_invoicepaymentindicator @year, @idivaregisterkind, @codeinvkind, @codeivaregisterkind, @start, @stop, @unified, @idsor01, @idsor02, @idsor03, @idsor04, @idsor05,@mode
	        RETURN
	END 
	
	----------------------------------------------------------------------------- 
	---- commento la parte successiva che evidentemente non viene aggiornata ----
	----------------------------------------------------------------------------- 
	/*
	CREATE TABLE #outtable
	(
		departmentname			varchar(200),
		attributo_1 varchar(600), 
		attributo_2 varchar(600), 
		attributo_3 varchar(600), 
		attributo_4 varchar(600), 
		attributo_5 varchar(600), 
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		flagbuysell varchar(20),
		doc varchar(35),
		docdate smalldatetime,	
		adate datetime,
		registry varchar(200),
		description varchar(150),
		linked decimal(19,2),
		residual decimal(19,2),
		totalpayed decimal(19,2),
		protocoldate datetime,
		transmissiondate datetime,
		paymentfromadate int,
		paymentfromprotocoldate int,
		paymentfromexpiring int
	)

	declare @iddbdepartment varchar(50)
	declare @departmentname varchar(150)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment, description from dbdepartment
	where   (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment, @departmentname
	while @@fetch_status=0 begin
			declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.exp_invoicepaymentindicator'
	
	
IF (
	   (@idsor01 is not null) OR (@idsor02 is not null) OR (@idsor03 is not null) OR 
	   (@idsor04 is not null) OR (@idsor05 is not null)
    )
    begin
		insert into #outtable 
			(
				attributo_1				,
				attributo_2				,
				attributo_3				,
				attributo_4				,
				attributo_5				,
				invoicekind				,
				yinv					,
				ninv					,
				flagbuysell				,
				doc						,
				docdate					,	
				registry				,
				description				,
				linked					,
				residual				,
				totalpayed				,
				adate					,
				protocoldate			,
				transmissiondate		,
				paymentfromadate		,
				paymentfromprotocoldate ,
				paymentfromexpiring
			)

			exec @dip_nomesp @year, @idivaregisterkind, @codeinvkind, @codeivaregisterkind, @start, @stop, @unified, @idsor01, @idsor02, @idsor03, @idsor04, @idsor05
			end
			else
			begin 
			insert into #outtable 
			(
				invoicekind				,
				yinv					,
				ninv					,
				flagbuysell				,
				doc						,
				docdate					,	
				registry				,
				description				,
				linked					,
				residual				,
				totalpayed				,
				adate					,
				protocoldate			,
				transmissiondate		,
				paymentfromadate		,
				paymentfromprotocoldate ,
				paymentfromexpiring 
			)

			exec @dip_nomesp @year, @idivaregisterkind, @codeinvkind, @codeivaregisterkind, @start, @stop, @unified, @idsor01, @idsor02, @idsor03, @idsor04, @idsor05
			end
			UPDATE #outtable  SET departmentname = @departmentname WHERE departmentname is null 
		fetch next from @crsdepartment into @iddbdepartment, @departmentname
	END
	
	IF (
	   (@idsor01 is not null) OR (@idsor02 is not null) OR (@idsor03 is not null) OR 
	   (@idsor04 is not null) OR (@idsor05 is not null)
    )
    BEGIN
	SELECT 
			departmentname as 'Dipartimento', 
			attributo_1 AS 'Attributo 1',
			attributo_2 AS 'Attributo 2',
			attributo_3  AS 'Attributo 3',
			attributo_4  AS 'Attributo 4',
			attributo_5  AS 'Attributo 5',
			invoicekind AS 'Tipo', 
			yinv AS 'Esercizio', 
			ninv AS 'Numero', 
			CASE flagbuysell
				WHEN 'A' THEN 'Acquisto'
				WHEN 'V' THEN 'Vendita'
				ELSE null
			END AS 'A/V', 
			doc AS  'Num. Doc. Coll.',
			docdate AS  'Data Doc. Coll.',
			registry AS 'Cliente/Fornitore',
			description AS 'Descrizione',
			linked AS 'Tot.Contabilizzato',
			residual AS 'Totale da Contabilizzare',
			totalpayed AS 'Tot.Pagato',
			adate AS 'Data Registrazione',
			protocoldate AS 'Data Protocollo',
			transmissiondate AS 'Data del pagamento',
			paymentfromadate AS 'GG. Pagamento da Data Registrazione',
			paymentfromprotocoldate AS 'GG. Pagamento da Data Protocollo',
			paymentfromexpiring AS 'GG. Pagamento da Data di Scadenza'	
	FROM #outtable
	END
	ELSE
	BEGIN
	SELECT 
			departmentname as 'Dipartimento', 
			invoicekind AS 'Tipo', 
			yinv AS 'Esercizio', 
			ninv AS 'Numero', 
			CASE flagbuysell
				WHEN 'A' THEN 'Acquisto'
				WHEN 'V' THEN 'Vendita'
				ELSE null
			END AS 'A/V', 
			doc AS  'Num. Doc. Coll.',
			docdate AS  'Data Doc. Coll.',
			registry AS 'Cliente/Fornitore',
			description AS 'Descrizione',
			linked AS 'Tot.Contabilizzato',
			residual AS 'Totale da Contabilizzare',
			totalpayed AS 'Tot.Pagato',
			adate AS 'Data Registrazione',
			protocoldate AS 'Data Protocollo',
			transmissiondate AS 'Data del pagamento',
			paymentfromadate AS 'GG. Pagamento da Data Registrazione',
			paymentfromprotocoldate AS 'GG. Pagamento da Data Protocollo',
			paymentfromexpiring AS 'GG. Pagamento da Data di Scadenza'	
	FROM #outtable
	END
	*/
END


GO


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




