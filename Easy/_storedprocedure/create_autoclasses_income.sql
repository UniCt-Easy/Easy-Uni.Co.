
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


if exists (select * from dbo.sysobjects where id = object_id(N'[create_autoclasses_income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [create_autoclasses_income]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/* Versione 1.0.0 del 11/09/2007 ultima modifica: PIERO */


CREATE PROCEDURE [create_autoclasses_income] 
@ayear int,
@idinc int,
@idreg int,
@idupb varchar(36),
@nphase tinyint,
@idfin int,
@idman int,
@amount decimal(23,2),
--@idsortingkind int,
@idsor int,
@idsubclass smallint,
@classifamount decimal(23,2),
@description varchar(150),
@flagnodate char(1),
@flagnocompleted char(1),
@start datetime,
@stop datetime,
@valueN1 decimal(23,2),
@valueN2 decimal(23,2),
@valueN3 decimal(23,2), 
@valueN4 decimal(23,2),
@valueN5 decimal(23,2),
@valueS1 varchar(20),
@valueS2 varchar(20),
@valueS3 varchar(20),
@valueS4 varchar(20),
@valueS5 varchar(20),
@valueV1 decimal(23,6),
@valueV2 decimal(23,6),
@valueV3 decimal(23,6),
@valueV4 decimal(23,6),
@valueV5 decimal(23,6)
AS
declare @idsorkindmaster int
select  @idsorkindmaster = idsorkind from sorting S where idsor=@idsor


select 		'idsorkind' = sorting.idsorkind,
		'idsor' = sortingtranslation.idsortingchild,
		'idinc' = @idinc, 
		'idsubclass' = 1 , 
		'amount' = @classifamount*sortingtranslation.numerator/sortingtranslation.denominator ,
		'description' = 'classificato automaticamente' ,
		'txt' = null,
		'rtf' = null,
		'cu'  = 'ASSISTENZA',
		'ct' = getdate(),
		'lu' = 'ASSISTENZA',
		'lt' = getdate(),
		'flagnodate' = sortingtranslation.flagnodate , 
		'tobecontinued' = 'N' , 
		'start' = @start , 
		'stop' = @stop ,
		'valuen1' = CASE sortingtranslation.defaultn1
				WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
				ELSE 0
			END,
		'valuen2' = CASE sortingtranslation.defaultn2
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuen3' = CASE sortingtranslation.defaultn3
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuen4' =  CASE sortingtranslation.defaultn4
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuen5' =  CASE sortingtranslation.defaultn5
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'values1' = sortingtranslation.defaults1,
		'values2' = sortingtranslation.defaults2 ,
		'values3' = sortingtranslation.defaults3 ,
		'values4' = sortingtranslation.defaults4,
		'values5' = sortingtranslation.defaults5,
		'valuev1' = CASE sortingtranslation.defaultv1
				WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
				ELSE 0
			END,
		'valuev2' = CASE sortingtranslation.defaultv2
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuev3' = CASE sortingtranslation.defaultv3
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuev4' =  CASE sortingtranslation.defaultv4
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'valuev5' =  CASE sortingtranslation.defaultv5
			WHEN '@' THEN @classifamount*sortingtranslation.numerator/sortingtranslation.denominator
			ELSE 0
		END,
		'ayear' = @ayear,
		'paridsorkind' = null , 
		'paridsor' = @idsor , 
		'paridsubclass' = @idsubclass
FROM sortingtranslation
JOIN sorting
	ON sorting.idsor = sortingtranslation.idsortingchild
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
WHERE idsortingmaster = @idsor and isnull(sortingkind.idparentkind,0)<> @idsorkindmaster
      AND ISNULL(sortingkind.active,'S')='S'
	 AND sortingkind.nphaseincome is not null
UNION ALL
select 		'idsorkind' = SKchild.idsorkind,
		'idsor' = S2.idsor,
		'idinc' = @idinc, 
		'idsubclass' = 1 , 
		'amount' = @classifamount ,
		'description' = 'classificato automaticamente' ,
		'txt' = null,
 		'rtf' = null,
		'cu'  = 'ASSISTENZA',
		'ct' = getdate(),
		'lu' = 'ASSISTENZA',
		'lt' = getdate(),
		'flagnodate' = 'S' , 
		'tobecontinued' = 'N' , 
		'start' = @start , 
		'stop' = @stop ,
		'valuen1' = 0,
		'valuen2' = 0,
		'valuen3' = 0,
		'valuen4' = 0,
		'valuen5' = 0,
		'values1' = null,
		'values2' = null,
		'values3' = null ,
		'values4' = null,
		'values5' = null,
		'valuev1' = 0,
		'valuev2' = 0,
		'valuev3' = 0,
		'valuev4' = 0,
		'valuev5' = 0,
		'ayear' = @ayear,
		'paridsorkind' = @idsorkindmaster , 
		'paridsor' = @idsor, 
		'paridsubclass' = @idsubclass
FROM sorting S1 
JOIN sortingkind SKmaster
	ON SKmaster.idsorkind = S1.idsorkind
join sortingkind SKchild
	on SKchild.idparentkind= SKmaster.idsorkind
join sorting S2
	on S2.idsorkind=SKchild.idsorkind and S1.sortcode=S2.sortcode and S1.movkind=S2.movkind
WHERE S1.idsor = @idsor 
	     AND ISNULL(SKchild.active,'S')='S'
		AND SKmaster.nphaseincome is not null
		AND SKchild.nphaseincome is not null


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

