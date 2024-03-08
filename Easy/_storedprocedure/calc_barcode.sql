
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


if exists (select * from dbo.sysobjects where id = object_id(N'[calc_barcode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [calc_barcode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE    PROCEDURE [calc_barcode]
	@chaine varchar(128), /* Chaine codée */
	@barcode varchar(100) OUTPUT

AS BEGIN

/*
declare @barcode varchar(100)
execute calc_barcode 'sgahsgtw1552', @barcode OUTPUT
select @barcode
*/

DECLARE @Code128 varchar(100)
DECLARE @tableB bit --boolean  
DECLARE @checksum int
DECLARE @mini int /* nbr de caractères numériques en suivant */
DECLARE @dummy int  /* Traitement de 2 caractères à la fois */

DECLARE @ind int /* Indice d'avancement dans la chaine de caractère */

SET @ind = 1

SET @checksum = 0

IF Len(@chaine)  = 0 
BEGIN  
	print '1'
	SET @barcode = NULL
	RETURN
END  


--###############################################
--#                     #
--# Première partie : vérification de la chaine #
--#                     #
--###############################################  
	
SET @ind = 1
WHILE (@ind <= Len(@chaine))
	BEGIN  
		IF (ASCII(SUBSTRING(@chaine, @ind, 1))) between 32 and 126  
		BEGIN  
			SET @ind = @ind + 1
		END  
		ELSE
		BEGIN -- carattere non valido   
		print '2'
			SET @barcode = NULL
			RETURN
		END  
	END  

--##############################################
--#                    #
--# Deuxieme partie : encodage de la chaine en #
--#  optimisant l'usage des table B et C       #
--#                    #
--##############################################  
  
  
SET @Code128 = ''
SET @tableB = 1																													
																															
SET @ind = 1      
WHILE @ind <= Len(@chaine)
	BEGIN 
			IF @tableB = 1 --is true
			--Voir si c'est intéressant de passer en table C
			--Oui pour 4 chiffres au début ou a la fin, sinon pour 6 chiffres
      
			BEGIN	 			
				IF ((@ind = 1) Or (@ind + 3 = Len(@chaine)))
					SET @mini = 4
				ELSE 
					SET @mini = 6 
					
				 --TestNum : si les mini caractères à partir de ind son numériques, alors mini = 0
				SET @mini = @mini - 1
				
				IF (@ind + @mini) <= Len(@chaine)
				BEGIN	 
					While @mini >= 0
					BEGIN	 
						--select ASCII(SUBSTRING(@chaine, @ind + @mini, 1)) , SUBSTRING(@chaine, @ind + @mini, 1)																												
						IF  (ASCII(SUBSTRING(@chaine, @ind + @mini, 1))) < 48 Or (ASCII(SUBSTRING(@chaine, @ind + @mini, 1))) > 57 
							 BEGIN  
								print '3'
							 	--SET @barcode = NULL
								BREAK
							 END  
						SET @mini = @mini - 1;
					END  	 																										
				END   
				
				 --Si mini < 0 on passe en table C 
				IF @mini < 0 
				BEGIN        
					IF @ind = 1    --Débuter sur la table C         
						SET @Code128 =   CHAR(210) 
					ELSE --Commuter sur la table C
						SET @Code128 = @Code128 + CHAR(204)  
					SET @tableB = 0
				END  
				
				ELSE
					IF @ind = 1  SET @Code128 =   CHAR(209) 
			END		 
			
																	 
			If @tableB = 0 --On est sur la table C, on va essayer de traiter 2 chiffres																												 
			BEGIN   
				SET @mini = 2;
                set @mini =  @mini - 1;
				
				IF (@ind + @mini) <= Len(@chaine) 
					While @mini  >= 0
					BEGIN   
						IF (ASCII(SUBSTRING(@chaine, @ind + @mini, 1))) < 48 Or (ASCII(SUBSTRING(@chaine, @ind + @mini, 1))) > 57 
						BREAK
						SET @mini = @mini - 1
							
					END   
				

				IF @mini < 0     --OK Pour 2 chiffres, les traiter
				BEGIN 
					DECLARE @str varchar(100)
					SET @str = SUBSTRING(@chaine, @ind, 2)  
					SET @dummy = CONVERT(int,@str)
				
					IF	(@dummy) < 95 
						SET @dummy= @dummy + 32
					ELSE 
						SET @dummy = @dummy + 105

					SET @Code128 =   @Code128 + CHAR(@dummy)  
					SET @ind = @ind + 2
				END 
				ELSE		
					BEGIN  --On a pas deux chiffres, retourner en table B  
						SET @Code128 = @Code128 + CHAR(205)				 
						SET @tableB = 1
					END  
			End  
																																						 
			IF @tableB = 1
			BEGIN  

				SET @Code128 =	 @Code128 +  SUBSTRING(@chaine, @ind, 1) 
				SET @ind = @ind + 1
			END  
		END  --del while 																									 
	 
		SET @ind=1
		WHILE @ind <= Len(@Code128)
		BEGIN
			SET @dummy = ASCII(SUBSTRING(@Code128, @ind, 1))
			IF (@dummy < 127) 
				SET @dummy = @dummy - 32
			ELSE	
				SET @dummy = @dummy - 105
			If @ind = 1 SET @checksum = @dummy
			SET @checksum = (@checksum + (@ind - 1) * @dummy) % 103
			SET @ind=@ind + 1
		END -- END DEL WHILE
		
		  --Calcul du code ascii de la clef de controle
		IF @checksum < 95
			SET @checksum =@checksum + 32
		ELSE
			SET @checksum = @checksum + 105
			
		SET @Code128 =  @Code128 + CHAR(@checksum) + CHAR(211) 		
																														
SET @barcode = @Code128
END

GO

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
