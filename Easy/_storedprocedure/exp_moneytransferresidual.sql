
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_moneytransferresidual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_moneytransferresidual]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE exp_moneytransferresidual
	@ytransfer int,
	@idtreasurersource   int, 
	@idtreasurerdest     int,
	@mode char(1)-- modalità: Raggruppa o Tutti

	AS
BEGIN
-- exec [exp_moneytransferresidual] 2013, null, null, 'R'
-- exec [exp_moneytransferresidual] 2013, null, null, 'T'
if(@mode='R')
Begin
/*
;WITH importooperazione(amount, moneytotransfer, idtreasurerincome, idtreasurer)
as (
	select sum(amount), sum(moneytotransfer), idtreasurerincome, idtreasurer
	from moneytotransfer_available_view 
	where y = @ytransfer
		AND (idtreasurerincome = @idtreasurersource or @idtreasurersource is null)
		AND (idtreasurer =  @idtreasurerdest or @idtreasurerdest is null)
	group by idtreasurerincome, idtreasurer	
)

	SELECT 
		T1.description as 'Cassiere per l''incasso',
		importooperazione.amount as 'Importo Destinato',
		sum(M.amount) as 'Importo Girofondato',
		importooperazione.moneytotransfer as 'Importo da Girofondare',
		T2.description as 'Cassiere del progetto finanziato'
	FROM  moneytransfer M	
	JOIN treasurer T1
		on M.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on M.idtreasurerdest = T2.idtreasurer 
	left outer JOIN importooperazione
		ON importooperazione.idtreasurerincome = M.idtreasurersource 
		AND importooperazione.idtreasurer = M.idtreasurerdest
	WHERE M.ytransfer = @ytransfer
		and (M.idtreasurersource = @idtreasurersource or @idtreasurersource is null)
		and (M.idtreasurerdest = @idtreasurerdest or @idtreasurerdest is null)
	GROUP BY T1.description, T2.description,importooperazione.amount,importooperazione.moneytotransfer
	ORDER BY T1.description,T2.description
*/
	SELECT 
		T1.description as 'Cassiere per l''incasso',
		sum(V.amount) as 'Importo Destinato',
		sum(M.amount) as 'Importo Girofondato',
		sum(V.moneytotransfer) as 'Importo da Girofondare',
		T2.description as 'Cassiere del progetto finanziato'
	FROM  moneytransfer M	
	JOIN treasurer T1
		on M.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on M.idtreasurerdest = T2.idtreasurer 
	LEFT OUTER JOIN moneytotransfer_available_view V
		on V.y = isnull(M.yproceedspart, M.yvar) and V.n = isnull(M.nproceedspart, M.nvar)
	WHERE M.ytransfer = @ytransfer
		and (M.idtreasurersource = @idtreasurersource or @idtreasurersource is null)
		and (M.idtreasurerdest = @idtreasurerdest or @idtreasurerdest is null)
		and ((M.yvar is not null and V.ndet = M.rownum) OR	M.yvar is  null )
	GROUP BY T1.description,T2.description
	ORDER BY T1.description,T2.description
		
End
Else
Begin
	SELECT 
		V.kind as 'Tipo',
		V.y as 'Esercizio',
		V.n as 'Numero',
		M.ntransfer as 'Op.Girofondo',
		T1.description as 'Cassiere per l''incasso',
		V.amount as 'Importo Destinato',
		M.amount as 'Importo Girofondato',
		V.moneytotransfer as 'Importo da Girofondare',
		T2.description as 'Cassiere del progetto finanziato',
		V.codeupb as 'Cod.Progetto Finanziato',
		V.upb as 'Progetto Finanziato',
		V.codefin as 'Cod.Bilancio',
		V.finance as 'Bilancio'
	FROM  moneytransfer M	
	JOIN treasurer T1
		on M.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on M.idtreasurerdest = T2.idtreasurer 
	LEFT OUTER JOIN moneytotransfer_available_view V
		on V.y = isnull(M.yproceedspart, M.yvar) and V.n = isnull(M.nproceedspart, M.nvar)
	WHERE M.ytransfer = @ytransfer
		and (M.idtreasurersource = @idtreasurersource or @idtreasurersource is null)
		and (M.idtreasurerdest = @idtreasurerdest or @idtreasurerdest is null)
		and ((M.yvar is not null and V.ndet = M.rownum) OR	M.yvar is  null )
	ORDER BY T1.description,T2.description, V.y, V.n
end		
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 exec [exp_moneytransferresidual] 2013, null, null, 'T'

GO
exec [exp_moneytransferresidual] 2013, null, null, 'R'
GO

