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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_inquadranagrafiche_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_inquadranagrafiche_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser'amministrazione'
CREATE  PROCEDURE [compute_inquadranagrafiche_csa](
	@matricolastart int,
	@matricolastop int
)
AS BEGIN
/*
L'idea alla base dell'esecuzione della stored procedure, che disattiva le righe della tabella registrylegalstatus con il campo inquadramento impostato a NULL, 
è quella di mantenere Easy allineato con CSA. 
In pratica, se un record in Easy non presenta un valore nel campo inquadramento, si presume che non provenga da un'importazione, e pertanto deve essere disattivato.
Tuttavia, questo comportamento non è adatto per Unibas, poiché la loro vista di frontiera non include la colonna inquadramento. 
Di conseguenza, la stored procedure non dovrebbe intervenire in questi casi, evitando di disattivare le righe.
Per gestire correttamente questa eccezione, interrogheremo la vista di frontiera tramite LinkedServer: se la colonna inquadramento non è presente, 
la stored procedure non eseguirà alcuna operazione.
*/

		declare @dbservername varchar(200)
		select @dbservername = dbservername from linkedserveraccess

		DECLARE @EASY_INQUADRAMENTI nvarchar(4000)
		SET @EASY_INQUADRAMENTI = @dbservername +'.EASY_INQUADRAMENTI'

		DECLARE @query_EASY_INQUADRAMENTI nvarchar(4000)
		DECLARE @COL_Inq int

		BEGIN TRY

				DECLARE @SqlQuery NVARCHAR(MAX) = 
				'declare @x varchar(50)
				set @x = (select top 1 Inquadramento 
				FROM ' + @EASY_INQUADRAMENTI + ' ) ' 

				EXEC sp_executesql @SqlQuery
			  -- PRINT 'La colonna esiste sulla tabella.';
				set @COL_Inq=1
			END TRY
			BEGIN CATCH
				--PRINT 'Errore durante la verifica della colonna o linked server non disponibile.';
				set @COL_Inq=0
    
		END CATCH;

		if (@COL_Inq <> 0) -- colonna INQUADRAMENTO presente
		Begin
			update RLS
			set RLS.active  = 'N', RLS.lu='scriptactive', RLS.lt=getdate()
			from registrylegalstatus RLS
				inner join registry R 
				on  RLS.idreg = R.idreg 
			where ISNUMERIC(R.extmatricula) =1 
			and  isnull(R.extmatricula,0) >= isnull(@matricolastart,0) 
			and RLS.active='S'
			and RLS.csa_class is null
			and ( @matricolastop is null or	isnull(r.extmatricula,0) <= isnull(@matricolastop,0) )
		End
		else
		Begin
			return
		end

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


