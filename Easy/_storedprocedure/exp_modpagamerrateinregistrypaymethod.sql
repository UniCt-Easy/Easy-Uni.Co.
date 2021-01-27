
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modpagamerrateinregistrypaymethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modpagamerrateinregistrypaymethod]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_modpagamerrateinregistrypaymethod as
begin
	create table #tabella (
		idreg int,
		title varchar(100),
		idregistrypaymethod int,
		paymethod varchar(50),
		errore varchar(200),
		iban varchar(50),
		cin varchar(20),
		idbank varchar(20),
		idcab varchar(20),
		cc varchar(30),
	)
	
	insert into #tabella
		select registrypaymethod.idreg, registry.title, registrypaymethod.idregistrypaymethod, paymethod.description,
		'Non si devono specificare le coordinate bancarie',
		registrypaymethod.iban, registrypaymethod.cin, registrypaymethod.idbank, registrypaymethod.idcab, registrypaymethod.cc
		from registrypaymethod
		join registry on registry.idreg = registrypaymethod.idreg
		join paymethod on paymethod.idpaymethod = registrypaymethod.idpaymethod
		where (paymethod.flag & 8) <> 0
		and registrypaymethod.active = 'S'
		and (registrypaymethod.iban is not null or registrypaymethod.idbank is not null or registrypaymethod.idcab is not null or registrypaymethod.cc is not null)
	
	insert into #tabella
		select registrypaymethod.idreg, registry.title, registrypaymethod.idregistrypaymethod, paymethod.description,
		'Le coordinate bancarie sono obbligatorie',
		registrypaymethod.iban, registrypaymethod.cin, registrypaymethod.idbank, registrypaymethod.idcab, registrypaymethod.cc
		from registrypaymethod
		join registry on registry.idreg = registrypaymethod.idreg
		join paymethod on paymethod.idpaymethod = registrypaymethod.idpaymethod
		where (paymethod.flag & 4) <> 0
		and registrypaymethod.active = 'S'
		and registrypaymethod.idbank is null and registrypaymethod.idcab is null and registrypaymethod.cc is null
	
	insert into #tabella
		select registrypaymethod.idreg, registry.title, registrypaymethod.idregistrypaymethod, paymethod.description,
		'Specificare il numero di conto e non le altre coordinate bancarie',
		registrypaymethod.iban, registrypaymethod.cin, registrypaymethod.idbank, registrypaymethod.idcab, registrypaymethod.cc
		from registrypaymethod
		join registry on registry.idreg = registrypaymethod.idreg
		join paymethod on paymethod.idpaymethod = registrypaymethod.idpaymethod
		where (paymethod.flag & 2) <> 0
		and registrypaymethod.active = 'S'
		and (registrypaymethod.iban is not null or registrypaymethod.idbank is not null or registrypaymethod.idcab is not null or registrypaymethod.cc is null)

	select
		'Codice' = idreg,
		'Creditore' = title,
		'N.pagam.' = idregistrypaymethod,
		'Pagamento' = paymethod,
		'Errore'= errore,
		'Iban' = iban,
		'Cin' = cin,
		'Conto' = cc,
		'Abi' = idbank,
		'Cab' = idcab
		from #tabella 
		order by title, idregistrypaymethod
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

