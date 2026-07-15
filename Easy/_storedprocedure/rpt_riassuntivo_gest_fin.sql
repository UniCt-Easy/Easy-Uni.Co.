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

-- setuser setuser 'amministrazione'
-- CREAZIONE PROCEDURE [rpt_riassuntivo_gest_fin]
IF EXISTS (select * from sysobjects where id = object_id(N'[rpt_riassuntivo_gest_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [rpt_riassuntivo_gest_fin]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_riassuntivo_gest_fin '2025'
CREATE PROCEDURE [rpt_riassuntivo_gest_fin]
	@ayear smallint
AS
BEGIN

	declare @ayear_prev smallint
	set @ayear_prev = @ayear - 1

	declare @levelusable tinyint = 2

	DECLARE @minoplevel tinyint
	SELECT @minoplevel = min(nlevel)
	FROM finlevel
	WHERE ayear = @ayear and (flag&2)<>0
	
	DECLARE @levelusable_original tinyint	
	SET @levelusable_original = @levelusable

	IF(@levelusable < @minoplevel)
	begin
		SET @levelusable = @minoplevel
	end
	
	declare @fixedidupb varchar(36)
	set @fixedidupb = '0001'

	DECLARE @infoadvance char(1)
	SELECT @infoadvance = paramvalue
	FROM generalreportparameter
	WHERE idparam = 'MostraAvanzo'

	declare @fin_kind tinyint
	SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear

	CREATE TABLE #data
	(
		e_a1_comp decimal(19,2),
		e_a1_cassa decimal(19,2),
		e_a1_comp_prev decimal(19,2),
		e_a1_cassa_prev decimal(19,2),
		e_a2_comp decimal(19,2),
		e_a2_cassa decimal(19,2),
		e_a2_comp_prev decimal(19,2),
		e_a2_cassa_prev decimal(19,2),
		e_a3_comp decimal(19,2),
		e_a3_cassa decimal(19,2),
		e_a3_comp_prev decimal(19,2),
		e_a3_cassa_prev decimal(19,2),
		e_b1_comp decimal(19,2),
		e_b1_cassa decimal(19,2),
		e_b1_comp_prev decimal(19,2),
		e_b1_cassa_prev decimal(19,2),
		e_b2_comp decimal(19,2),
		e_b2_cassa decimal(19,2),
		e_b2_comp_prev decimal(19,2),
		e_b2_cassa_prev decimal(19,2),
		e_b3_comp decimal(19,2),
		e_b3_cassa decimal(19,2),
		e_b3_comp_prev decimal(19,2),
		e_b3_cassa_prev decimal(19,2),
		e_c1_comp decimal(19,2),
		e_c1_cassa decimal(19,2),
		e_c1_comp_prev decimal(19,2),
		e_c1_cassa_prev decimal(19,2),
		e_d1_comp decimal(19,2),
		e_d1_cassa decimal(19,2),
		e_d1_comp_prev decimal(19,2),
		e_d1_cassa_prev decimal(19,2),
		u_a1_comp decimal(19,2),
		u_a1_cassa decimal(19,2),
		u_a1_comp_prev decimal(19,2),
		u_a1_cassa_prev decimal(19,2),
		u_a2_comp decimal(19,2),
		u_a2_cassa decimal(19,2),
		u_a2_comp_prev decimal(19,2),
		u_a2_cassa_prev decimal(19,2),
		u_b1_comp decimal(19,2),
		u_b1_cassa decimal(19,2),
		u_b1_comp_prev decimal(19,2),
		u_b1_cassa_prev decimal(19,2),
		u_b2_comp decimal(19,2),
		u_b2_cassa decimal(19,2),
		u_b2_comp_prev decimal(19,2),
		u_b2_cassa_prev decimal(19,2),
		u_b3_comp decimal(19,2),
		u_b3_cassa decimal(19,2),
		u_b3_comp_prev decimal(19,2),
		u_b3_cassa_prev decimal(19,2),
		u_c1_comp decimal(19,2),
		u_c1_cassa decimal(19,2),
		u_c1_comp_prev decimal(19,2),
		u_c1_cassa_prev decimal(19,2),
		u_d1_comp decimal(19,2),
		u_d1_cassa decimal(19,2),
		u_d1_comp_prev decimal(19,2),
		u_d1_cassa_prev decimal(19,2)
	);

	WITH CommonData AS (
		select 
			f5.codefin,
			f5.flag,
			finyear.prevision as comp,
			finyear.secondaryprev as cassa,
			finyear.previousprevision as comp_prev,
			case
				when @fin_kind = 2
					then finyear.prevision 
					else finyear.previoussecondaryprev			
			end as cassa_prev
		from finyear 
		join fin f5 on finyear.idfin=f5.idfin
		JOIN finlevel fl ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
		where f5.ayear = @ayear
				AND (f5.nlevel = @levelusable
					OR (f5.nlevel < @levelusable
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
						AND (fl.flag&2)<>0
					   )
					)
				AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0))
	)
	INSERT INTO #data (
		e_a1_comp,
		e_a1_cassa,
		e_a1_comp_prev,
		e_a1_cassa_prev,
		e_a2_comp,
		e_a2_cassa,
		e_a2_comp_prev,
		e_a2_cassa_prev,
		e_a3_comp,
		e_a3_cassa,
		e_a3_comp_prev,
		e_a3_cassa_prev,
		e_b1_comp,
		e_b1_cassa,
		e_b1_comp_prev,
		e_b1_cassa_prev,
		e_b2_comp,
		e_b2_cassa,
		e_b2_comp_prev,
		e_b2_cassa_prev,
		e_b3_comp,
		e_b3_cassa,
		e_b3_comp_prev,
		e_b3_cassa_prev,
		e_c1_comp,
		e_c1_cassa,
		e_c1_comp_prev,
		e_c1_cassa_prev,
		e_d1_comp,
		e_d1_cassa,
		e_d1_comp_prev,
		e_d1_cassa_prev,
		u_a1_comp,
		u_a1_cassa,
		u_a1_comp_prev,
		u_a1_cassa_prev,
		u_a2_comp,
		u_a2_cassa,
		u_a2_comp_prev,
		u_a2_cassa_prev,
		u_b1_comp,
		u_b1_cassa,
		u_b1_comp_prev,
		u_b1_cassa_prev,
		u_b2_comp,
		u_b2_cassa,
		u_b2_comp_prev,
		u_b2_cassa_prev,
		u_b3_comp,
		u_b3_cassa,
		u_b3_comp_prev,
		u_b3_cassa_prev,
		u_c1_comp,
		u_c1_cassa,
		u_c1_comp_prev,
		u_c1_cassa_prev,
		u_d1_comp,
		u_d1_cassa,
		u_d1_comp_prev,
		u_d1_cassa_prev
	)
	SELECT
	-- ENTRATE
	-- ENTRATE CONTRIBUTIVE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '11%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '11%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '11%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '11%' THEN cassa_prev END), 0),
	-- ENTRATE DERIVANTI DA TRASFERIMENTI
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '12%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '12%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '12%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '12%' THEN cassa_prev END), 0),
	-- ALTRE ENTRATE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '13%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '13%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '13%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '13%' THEN cassa_prev END), 0),
	-- ENTRATE PER L'ALIENAZIONE DI BENI PATRIMONIALI
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '21%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '21%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '21%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '21%' THEN cassa_prev END), 0),
	-- ENTRATE DERIVANTI DA TRASFERIMENTI IN CONTO CAPITALE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '22%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '22%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '22%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '22%' THEN cassa_prev END), 0),
	-- ACCENSIONE DI PRESTITI (E)
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '23%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '23%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '23%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '23%' THEN cassa_prev END), 0),
	-- C) ENTRATE PER PARTITE DI GIRO
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '3%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '3%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '3%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '3%' THEN cassa_prev END), 0),
	-- D) UTILIZZO DELL'AVANZO DI AMMINISTRAZIONE INIZIALE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '9%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '9%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '9%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 0) AND codefin LIKE '9%' THEN cassa_prev END), 0),
	-- USCITE
	-- FUNZIONAMENTO
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '11%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '11%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '11%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '11%' THEN cassa_prev END), 0),
	-- INTERVENTI DIVERSI
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '12%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '12%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '12%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '12%' THEN cassa_prev END), 0),
	-- INVESTIMENTI
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '21%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '21%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '21%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '21%' THEN cassa_prev END), 0),
	-- ONERI COMUNI
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '22%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '22%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '22%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '22%' THEN cassa_prev END), 0),
	-- ACCANTONAMENTI PER SPESE FUTURE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '23%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '23%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '23%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '23%' THEN cassa_prev END), 0),
	-- C1) USCITE PER PARTITE DI GIRO
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '3%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '3%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '3%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '3%' THEN cassa_prev END), 0),
	-- D1) COPERTURA DEL DISAVANZO DI AMMINISTRAZIONE INIZIALE
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '9%' THEN comp END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '9%' THEN cassa END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '9%' THEN comp_prev END), 0),
		ISNULL(SUM(CASE WHEN ((flag & 1) = 1) AND codefin LIKE '9%' THEN cassa_prev END), 0)
	FROM CommonData;

	SELECT
		e_a1_comp,
		e_a1_cassa,
		e_a1_comp_prev,
		e_a1_cassa_prev,
		e_a2_comp,
		e_a2_cassa,
		e_a2_comp_prev,
		e_a2_cassa_prev,
		e_a3_comp,
		e_a3_cassa,
		e_a3_comp_prev,
		e_a3_cassa_prev,
		e_b1_comp,
		e_b1_cassa,
		e_b1_comp_prev,
		e_b1_cassa_prev,
		e_b2_comp,
		e_b2_cassa,
		e_b2_comp_prev,
		e_b2_cassa_prev,
		e_b3_comp,
		e_b3_cassa,
		e_b3_comp_prev,
		e_b3_cassa_prev,
		e_c1_comp,
		e_c1_cassa,
		e_c1_comp_prev,
		e_c1_cassa_prev,
		e_d1_comp,
		e_d1_cassa,
		e_d1_comp_prev,
		e_d1_cassa_prev,
		u_a1_comp,
		u_a1_cassa,
		u_a1_comp_prev,
		u_a1_cassa_prev,
		u_a2_comp,
		u_a2_cassa,
		u_a2_comp_prev,
		u_a2_cassa_prev,
		u_b1_comp,
		u_b1_cassa,
		u_b1_comp_prev,
		u_b1_cassa_prev,
		u_b2_comp,
		u_b2_cassa,
		u_b2_comp_prev,
		u_b2_cassa_prev,
		u_b3_comp,
		u_b3_cassa,
		u_b3_comp_prev,
		u_b3_cassa_prev,
		u_c1_comp,
		u_c1_cassa,
		u_c1_comp_prev,
		u_c1_cassa_prev,
		u_d1_comp,
		u_d1_cassa,
		u_d1_comp_prev,
		u_d1_cassa_prev
	FROM #data

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO