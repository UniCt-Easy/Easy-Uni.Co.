
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_flussocreditidetail_incongruenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_flussocreditidetail_incongruenti]
GO
--setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec [exp_flussocreditidetail_incongruenti] 2023
CREATE PROCEDURE [exp_flussocreditidetail_incongruenti]
(
	@ayear int 
)
AS 
BEGIN
-- Questa stored procedure mostra i  dettagli flusso crediti con importi incongruenti rispetto agli incassi 
-- il dettaglio credito è individuato da iduniqueformcode (codice bollettino univoco)
-- Viene anche mostrato il sospeso, con il suo importo di apertura e importo da coprire, perchè lo stesso non 
-- si riesce a chiudere a causa dell'anomalia degli importi dei crediti ricevuti dal servizio studenti
-- che rendono impossibile l'elaborazione degli incassi

  CREATE TABLE #flussocreditidetail_incongruenti
  (
	  iduniqueformcode varchar(50),
	  sum_incassi decimal(19,2),
	  sum_crediti decimal(19,2),
	  nbill int, 
	  total decimal(19,2),
	  covered decimal(19,2),
	  tocover decimal(19,2) 
  )

  insert into #flussocreditidetail_incongruenti
  select flussoincassidetail.iduniqueformcode, SUM(flussoincassidetail.importo) as sum_incassi, 
  flussocreditidetail1.sum_crediti, flussoincassi.nbill , bolletta.total,bolletta.covered , bolletta.tocover 
  from flussoincassidetail
  join flussoincassi on flussoincassi.idflusso= flussoincassidetail.idflusso
  join 
  ( select iduniqueformcode, sum(importoversamento) as sum_crediti  from
  flussocreditidetail 
  where stop is null
  group by iduniqueformcode
  ) AS flussocreditidetail1 on flussocreditidetail1.iduniqueformcode = flussoincassidetail.iduniqueformcode
  left outer join 
  (select ybill, nbill, total, tocover, covered from billview  
      where  billkind = 'C'  and ybill = @ayear
  )  as bolletta on bolletta.nbill = flussoincassi.nbill and bolletta.ybill = @ayear
 
 
  where flussoincassi.ayear = @ayear  --  and flussoincassidetail.iduniqueformcode = '300000000703088285' 
  group by flussoincassidetail.iduniqueformcode,flussoincassi.nbill, flussocreditidetail1.sum_crediti,bolletta.total, bolletta.covered,  bolletta.tocover 
  having SUM(flussoincassidetail.importo) <  flussocreditidetail1.sum_crediti


  --select * from #flussocreditidetail_incongruenti

  select 
  @ayear as 'Esercizio',
  idflusso as '# flusso cred.', 
  iddetail as 'dett. flusso cred.', 
  FLC.iduniqueformcode as 'Cod. bollettino univoco', 
  FLC.iuv as 'IUV', 
  FLC.importoversamento as 'Importo dett. credito', 
  CRI.sum_crediti as 'Somma crediti bollettino',
  CRI.sum_incassi as 'Somma incassi bollettino',
  CRI.nbill as 'N° sospeso entrata',
  CRI.total as 'Importo di apertura sospeso',
  -- CRI.covered as 'Importo sospeso associato',
  CRI.tocover  as 'Importo sospeso da coprire' ,
  FLC.description as 'Descr. dett. credito', 
  FLC.cf as 'CF' , 
  FLC.registry as 'Anagrafica',  
  /*idestimkind_main as 'Tipo. Contr. attivo',*/ 
  FLC.estimkind_det as 'Tipo Contr. attivo', 
  FLC.yestim as 'Eserc. Contr. attivo', 
  FLC.nestim  as 'Numero Contr. attivo', 
  FLC.rownum  as 'n° riga Contr. attivo' 
  
 -- FLC.datacreazioneflusso as 'Data creazione flusso' 

  /*,**/ from  flussocreditidetailview FLC 
  join #flussocreditidetail_incongruenti CRI on FLC.iduniqueformcode = CRI.iduniqueformcode
 END 

 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

