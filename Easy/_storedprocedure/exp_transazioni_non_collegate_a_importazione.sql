
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_transazioni_non_collegate_a_importazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_transazioni_non_collegate_a_importazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amministrazione'
--exec exp_transazioni_non_collegate_a_importazione 2016, D 
CREATE   PROCEDURE [exp_transazioni_non_collegate_a_importazione]
	@ayear smallint,
    @kind  char(1)
AS BEGIN
SELECT
yban as 'Eserc. Transazione',
nban as 'Num. Transazione', 
transactiondate as 'Data Transazione', 
valuedate as 'Data Valuta', 
bankreference as  'Riferimento Banca',
idbankimport as 'Importazione Esiti', 
motive as 'Causale', 
amount as 'Importo', 
ypay as 'Eserc. Mandato', 
npay as 'Num. Mandato',  
yexp as 'Eserc. Mov. Spesa',
nexp as 'Num. Mov. Spesa',
ypro as 'Eserc. Reversale', 
npro as 'Num. Reversale', 
yinc as 'Eserc. Mov. Entrata', 
ninc as 'Num. Mov. Entrata', 
registry as 'Anagrafica', 
upb 'U.P.B.', 
lu as 'User Ultima Modifica', 
lt as 'Ultima modifica'
from banktransactionview
where idbankimport is null and yban = @ayear and kind = @kind

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
