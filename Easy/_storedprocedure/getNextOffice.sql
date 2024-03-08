
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[getNextOffice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [getNextOffice]
GO

CREATE PROCEDURE [getNextOffice]
(
	@idcustomuser varchar(50),
	@idflowchart varchar(50),
	@idmankind varchar(20),
	@yman smallint,
	@nman int
) AS
BEGIN
-- getNextOffice null, null, 'RICH',2016,1
-- 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5:Approvato - 6:Annullato
declare @oldstatus int
select @oldstatus = idmandatestatus from mandate where idmankind=@idmankind and yman=@yman and nman=@nman 
declare @newstatus int
set @newstatus =  @oldstatus
if (@oldstatus =1) set @newstatus = 2
if (@oldstatus =3) set @newstatus = 1
if (@oldstatus =2) set @newstatus = 1
-- Se @oldstatus non è 1, 2 o 3, @newstatus null return 
if ( @oldstatus not in (1,2,3)  ) 
Begin
	return
End


/* output:
 Una o più righe così formate:
 idoffice					int					id dell'ufficio a cui inoltrare la pratica
 oggetto_mail_ricevente		varchar(max)		oggetto mail a ufficio ricevente
 testo_mail_ricevente		varchar(max)		testo mail a ufficio ricevente
 email_ricevente			varchar(max)		email ufficio ricevente
 oggetto_mail_richiededente	varchar(max)		oggetto mail a richiededente
 testo_mail_richiededente	varchar(max)		testo mail a richiededente
 email_richiedente			varchar(max)		email richiededente
 skip_default				char(1)				se passato come S, fa si che il programma non invii le consuete mail che di solito invia
 new_idmandatestatus		int					id nuovo stato in cui si troverà la pratica (da tabella mandatestatus)

 Se la SP (getNextOffice) restituisce una sola riga, la scelta si intende obbligata e non è presentata all’operatore. 
 Altrimenti, in generale, è presentato all’operatore l’elenco delle opzioni restituito dalla SP, e in base alla sua scelta, 
	la pratica cambia di stato ed è inoltrata all’ufficio collegato a quella scelta, e sono inviate le mail indicate dalla SP per quella scelta.
  Inoltre è richiamata una sp notifyStatusChange con la chiave del documento per agevolare UniCT nell’espletamento di eventuali attività correlate.
*/

 select null as idoffice,
		null as oggetto_mail_ricevente,
		null as testo_mail_ricevente,
		null as email_ricevente,
		null as oggetto_mail_richiedente,
		null as testo_mail_richiedente,
		null as email_richiedente,
		'N'  as skip_default,
		@newstatus as new_idmandatestatus

END

GO
