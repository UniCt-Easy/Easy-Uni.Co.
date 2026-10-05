/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_segversamentistudenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_segversamentistudenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_segversamentistudenti
(
	@ayear int,
	@idcostoscontodefdettagliokind int,
	@mode char(1)-- D: dettagliata, R : raggruppata per tipo versamento
)
AS 
BEGIN

/*
========================================================================================================================
	l’elenco di tutti i versamenti dell’imposta di bollo effettuati dagli studenti
	nel periodo dal 01/01/20xx al 31/12/20xx5, 
	relativi all'anno solare di input
========================================================================================================================
*/
DECLARE @datainizio DATE;
DECLARE @datafine DATE;

SET @datainizio = CAST(CAST(@ayear AS VARCHAR(4)) + '-01-01' AS DATE);
SET @datafine = CAST(CAST(@ayear AS VARCHAR(4)) + '-12-31' AS DATE);

if(@mode='D')
Begin
	select  r.title as Anagrafica, r.idreg as CodiceAnagrafica,
	iscr.Matricola , d.title as Casuale , 
	dett.Importo as ImportoVersato,CDkind.title as TipoVersamento , IUV ,
	 CONVERT(VARCHAR, p.dataora, 101) as DataPagamento
	from pagamento p
	join debito d on p.iddebito = d.iddebito
	join debitodettaglio dett on dett.iddebito = p.iddebito
	join costoscontodefdettaglio CD on cd.idcostoscontodef =dett.idcostoscontodef
	join costoscontodefdettagliokind CDkind on  CD.idcostoscontodefdettagliokind = CDkind.idcostoscontodefdettagliokind
	join registry r on p.idreg =r.idreg
--	left outer join iscrizioneanno i on d.idiscrizioneanno = i.idiscrizioneanno
	left outer join iscrizione iscr on d.idiscrizione = iscr.idiscrizione
	where (CDkind.idcostoscontodefdettagliokind =@idcostoscontodefdettagliokind or @idcostoscontodefdettagliokind is null)
		and p.dataora between @datainizio and @datafine
	order by r.title, iscr.Matricola , d.title , iuv
End

if(@mode='R')
Begin
	select d.title as Casuale , sum(dett.Importo) as ImportoVersato ,CDkind.title as  TipoVersamento 
	from pagamento p
	join debito d on p.iddebito = d.iddebito
	join debitodettaglio dett on dett.iddebito = p.iddebito
	join costoscontodefdettaglio CD on cd.idcostoscontodef =dett.idcostoscontodef
	join costoscontodefdettagliokind CDkind on  CD.idcostoscontodefdettagliokind = CDkind.idcostoscontodefdettagliokind
	where (CDkind.idcostoscontodefdettagliokind = @idcostoscontodefdettagliokind or @idcostoscontodefdettagliokind is null)
		and p.dataora between @datainizio and @datafine
	group by d.title, CDkind.title
	order by d.title
End

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

