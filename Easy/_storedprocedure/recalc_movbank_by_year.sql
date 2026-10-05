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

--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[recalc_movbank_by_year]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [recalc_movbank_by_year]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
---- ESEMPIO 
EXEC recalc_movbank_by_year  2025        -- continua sugli errori (default)
EXEC recalc_movbank_by_year  2025, 0;	  -- si ferma al primo errore
*/
CREATE PROCEDURE  recalc_movbank_by_year
(
    @ayear INT,
    @continueOnError BIT = 1   -- 1 = continua anche se un record va in errore
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @kpay INT;
    DECLARE @kpro INT;

    --------------------------------------------------------------------
    -- PAYMENTS
    --------------------------------------------------------------------
    DECLARE cur_pay CURSOR LOCAL FAST_FORWARD FOR
        SELECT kpay
        FROM   payment
        WHERE ypay = @ayear;

    OPEN cur_pay;
    FETCH NEXT FROM cur_pay INTO @kpay;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @continueOnError = 1
        BEGIN
            BEGIN TRY
                EXEC compute_payment_bank @kpay;
            END TRY
            BEGIN CATCH
                PRINT CONCAT('Errore compute_payment_bank su kpay=', @kpay, ' : ', ERROR_MESSAGE());
            END CATCH
        END
        ELSE
        BEGIN
            EXEC compute_payment_bank @kpay;
        END

        FETCH NEXT FROM cur_pay INTO @kpay;
    END

    CLOSE cur_pay;
    DEALLOCATE cur_pay;

    --------------------------------------------------------------------
    -- PROCEEDS
    --------------------------------------------------------------------
    DECLARE cur_pro CURSOR LOCAL FAST_FORWARD FOR
        SELECT kpro
        FROM   proceeds
        WHERE ypro = @ayear;

    OPEN cur_pro;
    FETCH NEXT FROM cur_pro INTO @kpro;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @continueOnError = 1
        BEGIN
            BEGIN TRY
                EXEC compute_proceeds_bank @kpro;
            END TRY
            BEGIN CATCH
                PRINT CONCAT('Errore compute_proceeds_bank su kpro=', @kpro, ' : ', ERROR_MESSAGE());
            END CATCH
        END
        ELSE
        BEGIN
            EXEC compute_proceeds_bank @kpro;
        END

        FETCH NEXT FROM cur_pro INTO @kpro;
    END

    CLOSE cur_pro;
    DEALLOCATE cur_pro;
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO