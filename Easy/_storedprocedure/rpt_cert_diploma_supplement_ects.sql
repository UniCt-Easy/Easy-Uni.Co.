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

--setuser setuser 'amministrazione'
-- CREAZIONE PROCEDURE [rpt_cert_diploma_supplement_ects]
IF EXISTS (select * from sysobjects where id = object_id(N'[rpt_cert_diploma_supplement_ects]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [rpt_cert_diploma_supplement_ects]
GO

--exec rpt_cert_diploma_supplement_ects 1, '31/12/2025', 1, 30
CREATE PROCEDURE [rpt_cert_diploma_supplement_ects]
	@idisced					int,
	@reportdate					varchar(20),
	@years       				int,
	@scale						int	-- 30 o 110, scala da filtrare
	--@idiscrizione				int,
	--@nprotocollo				int,
	--@statusprofessionale		varchar(64),
	--@strumentisti				char(1),
	--@informazioniaggiuntive		varchar(1024),
	--@date						date,
	--@lang						char(2)
	AS
BEGIN

    DECLARE
        @reportstart DATE,
        @reportstop DATE = CONVERT(DATE, @reportdate, 103),

		@scalemax int = @scale + 1,
		@scalemin int = convert(int, @scale * 0.6)

    SET @reportstart = DATEADD(year, -@years, @reportstop);

PRINT 'reporting grades from ' + CAST(@scalemin AS VARCHAR) + ' to ' + CAST(@scalemax AS VARCHAR) + ' and in the ' + CONVERT(VARCHAR(10), @reportstart, 120) + ' to ' + CONVERT(VARCHAR(10), @reportstop, 120) + ' interval';
    WITH MaxCT AS (
        SELECT
            grading_scale,
            MAX(ct) AS max_ct_in_group
        FROM
            ectsdatapoint edp
        WHERE
            @reportstart <= edp.start AND edp.stop <= @reportstop
			AND edp.idisced = @idisced
        GROUP BY
            grading_scale
    )
    SELECT
		edp.grading_scale
		,edp.n_marks
		,edp.ratio as ratio
		,edp.percentile as percentile
		,edp.idisced
		,edp.idectsdatapoint
		,edp.start
		,edp.stop
		,edp.ct
		,edp.cu
		,edp.lt
		,edp.lu
    FROM
        ectsdatapoint edp
    JOIN
        MaxCT ON edp.grading_scale = MaxCT.grading_scale AND edp.ct = MaxCT.max_ct_in_group
    WHERE
        @reportstart <= edp.start AND edp.stop <= @reportstop
		AND edp.idisced = @idisced
		AND @scalemin <= edp.grading_scale AND edp.grading_scale <= @scalemax
END

GO


