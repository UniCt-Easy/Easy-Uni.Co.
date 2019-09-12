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

declare @oldstatus int
select @oldstatus = idmandatestatus from mandate where idmankind=@idmankind and yman=@yman and nman=@nman 
declare @newstatus int
set @newstatus =  @oldstatus
if (@oldstatus =1) set @newstatus = 2
if (@oldstatus =3) set @newstatus = 1
if (@oldstatus =2) set @newstatus = 1
-- Se @oldstatus non � 1, 2 o 3, @newstatus null return 
if ( @oldstatus not in (1,2,3)  ) 
Begin
	return
End


/* output:
 Una o pi� righe cos� formate:
 idoffice					int					id dell'ufficio a cui inoltrare la pratica
 oggetto_mail_ricevente		varchar(max)		oggetto mail a ufficio ricevente
 testo_mail_ricevente		varchar(max)		testo mail a ufficio ricevente
 email_ricevente			varchar(max)		email ufficio ricevente
 oggetto_mail_richiededente	varchar(max)		oggetto mail a richiededente
 testo_mail_richiededente	varchar(max)		testo mail a richiededente
 email_richiedente			varchar(max)		email richiededente
 skip_default				char(1)				se passato come S, fa si che il programma non invii le consuete mail che di solito invia
 new_idmandatestatus		int					id nuovo stato in cui si trover� la pratica (da tabella mandatestatus)

 Se la SP (getNextOffice) restituisce una sola riga, la scelta si intende obbligata e non � presentata all�operatore. 
 Altrimenti, in generale, � presentato all�operatore l�elenco delle opzioni restituito dalla SP, e in base alla sua scelta, 
	la pratica cambia di stato ed � inoltrata all�ufficio collegato a quella scelta, e sono inviate le mail indicate dalla SP per quella scelta.
  Inoltre � richiamata una sp notifyStatusChange con la chiave del documento per agevolare UniCT nell�espletamento di eventuali attivit� correlate.
*/

 select null as idoffice,
		null as oggetto_mail_ricevente,
		null as testo_mail_ricevente,
		null as email_ricevente,
		null as oggetto_mail_richiededente,
		null as testo_mail_richiededente,
		null as email_richiedente,
		'N'  as skip_default,
		@newstatus as new_idmandatestatus

END

GO
