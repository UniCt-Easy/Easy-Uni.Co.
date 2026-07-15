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

if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_transf_paydisposition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure  [closeyear_transf_paydisposition]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- EXEC  [closeyear_transf_paydisposition] 2014
--UPDATE paydisposition SET ayear =  2014, 
--lt = GetDate(), lu = 'transf_paydisposition_' + convert(varchar(4),2014)
--WHERE  ayear = 2015 and kpay is null 
CREATE PROCEDURE [closeyear_transf_paydisposition]
(
	@ayear int  -- esercizio da trasferire
)
AS BEGIN
	-----------------------------------------------------------------------------------------
	---------------- QUESTA PROCEDURA TRASFERISCE LE DISPOSIZIONI DI PAGAMENTO --------------
	---------- NON ASSOCIATE A MANDATO DAL VECCHIO AL NUOVO ESERCIZIO -----------------------
	-----------------------------------------------------------------------------------------

	-- Verifico se ci sono dettagli di disposizioni di pagamento non pagate
	IF EXISTS (SELECT * FROM paydisposition p
				join paydispositiondetail pd on p.idpaydisposition = pd.idpaydisposition
				WHERE p.ayear = @ayear and p.kpay is null and pd.idexp is null)
	BEGIN		
		DECLARE @idpaydisposition int
		DECLARE @iddetail int
		DECLARE @ndetail int

		-- Cursore per ciclare su ogni disposizione di pagamento
		DECLARE cursorepaydisposition CURSOR FOR
		SELECT DISTINCT p.idpaydisposition FROM paydisposition p
				join paydispositiondetail pd on p.idpaydisposition = pd.idpaydisposition
				WHERE p.ayear = @ayear and p.kpay is null and pd.idexp is null

		DECLARE @idmax int
				
		OPEN cursorepaydisposition
		FETCH NEXT FROM cursorepaydisposition
		INTO @idpaydisposition

		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- Se non è stato pagato nessun dettaglio trasferisco tutta la disposizione
			if ((SELECT COUNT(*) FROM paydispositiondetail WHERE idpaydisposition = @idpaydisposition) = 
				(SELECT COUNT(*) FROM paydisposition p
					join paydispositiondetail pd on p.idpaydisposition = pd.idpaydisposition
					WHERE p.ayear = @ayear and p.kpay is null and pd.idexp is null
					and pd.idpaydisposition = @idpaydisposition))
			BEGIN
				UPDATE paydisposition SET ayear = @ayear +1, 
				lt = GETDATE(), lu = 'transf_paydisposition_' + convert(varchar(4),@ayear)
				WHERE idpaydisposition = @idpaydisposition
			END
			ELSE
			BEGIN
				select @idmax = max(idpaydisposition) + 1
				from paydisposition

				-- Creo una nuova disposizione di pagamento
				INSERT INTO paydisposition 
				(
					idpaydisposition
					,ayear
					,ct
					,cu
					,description
					,kpay
					,lt
					,lu
					,motive
					,idcbimotive
				)
				SELECT
					@idmax
					,@ayear + 1
					,GETDATE()
					,'transf_paydisposition_' + convert(varchar(4),@ayear)
					,description
					,kpay
					,GETDATE()
					,'transf_paydisposition_' + convert(varchar(4),@ayear)
					,motive
					,idcbimotive
				from paydisposition
				where idpaydisposition = @idpaydisposition

				set @ndetail = 1
			
				-- Cursore per ciclare su ogni dettaglio da trasferire
				DECLARE cursoredetail CURSOR FOR
				SELECT pd.iddetail from paydisposition p
					join paydispositiondetail pd on p.idpaydisposition = pd.idpaydisposition
					WHERE p.ayear = @ayear and p.kpay is null and pd.idexp is null
					and pd.idpaydisposition = @idpaydisposition

				OPEN cursoredetail
				FETCH NEXT FROM cursoredetail
				INTO @iddetail

				WHILE @@FETCH_STATUS = 0
				BEGIN
					-- Creo il nuovo dettaglio da inserire nella nuova disposizione
					insert into paydispositiondetail
					(
						idpaydisposition
						,iddetail
						,abi
						,address
						,amount
						,birthdate
						,cab
						,cap
						,cf
						,ct
						,cu
						,forename
						,gender
						,idcity
						,idnation
						,location
						,lt
						,lu
						,motive
						,province
						,surname
						,email
						,cc
						,cin
						,iban
						,idcbimotive
						,flaghuman
						,p_iva
						,title
						,paymentcode
						,paymethodcode
						,academicyear
						,calendaryear
						,degreecode
						,degreekind
						,flagtaxrefund
						,flag
						,idchargehandling
						,idexp
					)
					select
						@idmax
						,@ndetail
						,abi
						,address
						,amount
						,birthdate
						,cab
						,cap
						,cf
						,GETDATE()
						,'transf_paydisposition_' + convert(varchar(4),@ayear)
						,forename
						,gender
						,idcity
						,idnation
						,location
						,GETDATE()
						,'transf_paydisposition_' + convert(varchar(4),@ayear)
						,motive
						,province
						,surname
						,email
						,cc
						,cin
						,iban
						,idcbimotive
						,flaghuman
						,p_iva
						,title
						,paymentcode
						,paymethodcode
						,academicyear
						,calendaryear
						,degreecode
						,degreekind
						,flagtaxrefund
						,flag
						,idchargehandling
						,idexp
					from paydispositiondetail
					where idpaydisposition = @idpaydisposition
					and iddetail = @iddetail

					set @ndetail = @ndetail + 1
										
					-- Elimino il dettaglio dalla disposizione dell'anno precedente
					 DELETE FROM paydispositiondetail
					 WHERE idpaydisposition = @idpaydisposition
						and iddetail = @iddetail

					FETCH NEXT FROM cursoredetail
					INTO @iddetail
				END
			
				CLOSE cursoredetail
				DEALLOCATE cursoredetail
			END			

			FETCH NEXT FROM cursorepaydisposition
			INTO @idpaydisposition
		END

		CLOSE cursorepaydisposition
		DEALLOCATE cursorepaydisposition

		SELECT idpaydisposition as '#id',
			ayear as 'Esercizio',
			description as 'Descrizione',
			motive as 'Causale',
			total as 'Totale'
		FROM paydispositionview 
		WHERE ayear = @ayear + 1 and
		lu = 'transf_paydisposition_' + convert(varchar(4),@ayear)

	END
	ELSE
	BEGIN
		SELECT   null as '#id',
		null as 'Esercizio',
		null as 'Descrizione',
		null as 'Causale',
		null as 'Totale'
	END

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 