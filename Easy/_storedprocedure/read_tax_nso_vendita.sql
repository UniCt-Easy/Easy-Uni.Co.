
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


if exists (select * from dbo.sysobjects where id = object_id(N'[read_tax_nso_vendita]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [read_tax_nso_vendita]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure read_tax_nso_vendita (
	@idestimkind	varchar(20),
	@yestim			smallint,
	@nestim			int,
	@res decimal(19,6) out
) as
BEGIN
	DECLARE @idnso_vendita int
	select @idnso_vendita = idnso_vendita  from estimate where idestimkind= @idestimkind and yestim = @yestim and nestim = @nestim

	SET @res = 0

	-- Parte nuova
	declare @alltext varchar(max)
	set @alltext =  (select xml from  nso_vendita S where S.idnso_vendita= @idnso_vendita)
	
	set @alltext = (select dbo.f_removespecialchar(@alltext))

	declare @x XML	
	select @x = 
		cast(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(@alltext,
			'xmlns:xs="http://www.w3.org/2001/XMLSchema"', ''), 
			'xmlns="http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader"',''),
			'xmlns="urn:oasis:names:specification:ubl:schema:xsd:Order-2"' ,	''),
			'xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"',		''),
			'xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"',			''),
			'xmlns="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"',			''),
	        'xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"',		   ''),
		    'xmlns:ns4="urn:oasis:names:specification:ubl:schema:xsd:Order-2"',		   ''),
            'xmlns:ns2="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"',		   ''),
            'xmlns:ns3="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"',		   ''),
			'cbc:',				''),
			'ns3:',				''),
			'ns4:',				''),
			'cac:',				'')	   
			
		as XML)

	declare @perc float
	declare @amount float
	SET @perc = isnull(@x.value('sum(//OrderLine/LineItem/Item/ClassifiedTaxCategory/Percent)[1]','float') ,0)
	SET @amount = isnull(@x.value('sum(//OrderLine/LineItem/LineExtensionAmount)[1]','float') ,0)

	set @res= convert(decimal(19,6), @amount * @perc)
	 

END

/*
cac:OrderLine/cac:LineItem/cac:Item/cac:ClassifiedTaxCategory/cbc:Percent

cac:OrderLine/cac:LineItem/cbc:LineExtensionAmount
*/
GO


