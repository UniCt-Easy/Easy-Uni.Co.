
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_dipendentiassimilato_dati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_dipendentiassimilato_dati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE exp_interscambio_csa_dipendentiassimilato_dati
 (
	@datagenerazione datetime,
	@ayear int,
	@ateneo varchar(5),
--	@tiporecord varchar(2) ,
	@tipoCompenso char(1), -- Assume valori T = Conto Terzi, C = CO.CO.CO. , B = Borse di studio, M = Missioni
	@start datetime,
	@stop datetime
)
AS 
/*

exec exp_interscambio_csa_dipendentiassimilato_dati {ts '2012-12-31 01:02:03'} ,2012, '70136', 'M', {ts '2012-01-01 01:02:03'} , {ts '2012-12-31 01:02:03'} 

 */
BEGIN


DECLARE @annoredditi int
SET @annoredditi = @ayear
--------------------------------------------------------------------------------------- Interroghiamo i singoli dipartimenti ----------------------------------------------------------------

CREATE TABLE #Compensi(
		departmentname varchar(500),
		iddb_idexp varchar(60),-- iddb(50) + idexp(10)
		idregistrylegalstatus int,
		voce8000 varchar(4),
		importo decimal(19,2),
		idreg int,
		ymov smallint,
		nmov int,
		paymentdate smalldatetime
		)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
			where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		if(@tipoCompenso in ('T','C','B')) 	set @dip_nomesp = @iddbdepartment + '.exp_interscambio_csa_dipendentiassimilato_single'
		if(@tipoCompenso in ('M'))			set @dip_nomesp = @iddbdepartment + '.exp_interscambio_csa_missioni_single'

		INSERT INTO #Compensi(
				idreg,
				departmentname,
				iddb_idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				ymov,
				nmov,
				paymentdate
		)
		exec @dip_nomesp @datagenerazione, @ayear, @ateneo, @tipoCompenso, @start, @stop
		fetch next from @crsdepartment into @iddbdepartment
	
	END

SELECT 
	C.departmentname as 'Dip.',
	R.title as Anagrafica,
	R.idreg as 'Cod.Anagr.',
	RLS.csa_role as Ruolo,
	V.voce as voce,
	V.description as Descrizione,
	C.Importo,
	C.ymov as'Eserc.',
	C.nmov as 'N.Mov.',
	SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(C.paymentdate)))) +
	CONVERT(varchar(2),DAY(C.paymentdate)) + '/'+
	SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(C.paymentdate)))) +
	CONVERT(varchar(2),MONTH(C.paymentdate))+'/'+
	+CONVERT(varchar(4),YEAR(C.paymentdate))
	 as'Data Pag.'
FROM #Compensi C
JOIN registry R
	ON R.idreg = C.idreg
JOIN voce8000 V
	ON V.voce = C.voce8000
JOIN registrylegalstatus RLS
	ON C.idreg = RLS.idreg
	AND C.idregistrylegalstatus = RLS.idregistrylegalstatus
WHERE R.extmatricula IS NOT NULL
		AND RLS.csa_role IS NOT NULL
		AND RLS.csa_compartment IS NOT NULL
ORDER BY R.title, C.nmov, C.voce8000

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


