
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


/*
****************************************************************************************************************************************************************************************
RIMOSSA COL TASK 5835.
****************************************************************************************************************************************************************************************
Di seguito gli script per configurarla:

-- GENERAZIONE DATI PER exportfunction --
IF exists(SELECT * FROM [exportfunction] WHERE procedurename = 'exp_elencopagamenti')
UPDATE [exportfunction] SET ct = {ts '2007-05-16 14:19:46.327'},cu = '''SA''',description = 'Elenco Pagamenti',fileextension = null,fileformat = 'E',lt = {ts '2007-05-16 14:43:19.577'},lu = '''SA''',modulename = 'Verifiche e controlli sulla spesa',timeout = '100',webvisible = 'N' WHERE procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunction] (procedurename,ct,cu,description,fileextension,fileformat,lt,lu,modulename,timeout,webvisible) VALUES ('exp_elencopagamenti',{ts '2007-05-16 14:19:46.327'},'''SA''','Elenco Pagamenti',null,'E',{ts '2007-05-16 14:43:19.577'},'''SA''','Verifiche e controlli sulla spesa','100','N')
GO


-- GENERAZIONE DATI PER exportfunctionparam --
IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'adatemax' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:06.140'},cu = '''SA''',datasource = null,description = 'Al giorno',displaymember = null,filter = null,help = null,hint = null,hintkind = '31/12',iscombobox = 'N',lt = {ts '2007-05-16 14:47:57.843'},lu = '''SA''',noselectionforall = 'N',number = '5',selectioncode = null,systype = 'DateTime',tag = 'd',valuemember = null WHERE paramname = 'adatemax' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('adatemax','exp_elencopagamenti',{ts '2007-05-16 14:40:06.140'},'''SA''',null,'Al giorno',null,null,null,null,'31/12','N',{ts '2007-05-16 14:47:57.843'},'''SA''','N','5',null,'DateTime','d',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'adatemin' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:06.140'},cu = '''SA''',datasource = null,description = 'Dal giorno',displaymember = null,filter = null,help = null,hint = null,hintkind = '1/1',iscombobox = 'N',lt = {ts '2007-05-16 14:46:17.717'},lu = '''SA''',noselectionforall = 'N',number = '4',selectioncode = null,systype = 'DateTime',tag = 'd',valuemember = null WHERE paramname = 'adatemin' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('adatemin','exp_elencopagamenti',{ts '2007-05-16 14:40:06.140'},'''SA''',null,'Dal giorno',null,null,null,null,'1/1','N',{ts '2007-05-16 14:46:17.717'},'''SA''','N','4',null,'DateTime','d',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'codefin' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:06.140'},cu = '''SA''',datasource = null,description = 'Voce di bilancio',displaymember = null,filter = null,help = null,hint = '%',hintkind = 'STRING',iscombobox = 'N',lt = {ts '2007-05-17 10:34:29.297'},lu = '''SA''',noselectionforall = 'N',number = '6',selectioncode = null,systype = 'String',tag = 'g',valuemember = null WHERE paramname = 'codefin' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('codefin','exp_elencopagamenti',{ts '2007-05-16 14:40:06.140'},'''SA''',null,'Voce di bilancio',null,null,null,'%','STRING','N',{ts '2007-05-17 10:34:29.297'},'''SA''','N','6',null,'String','g',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'nmovparent' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-10-17 16:40:49.927'},cu = 'SARA',datasource = null,description = 'Numero del movimento padre',displaymember = null,filter = null,help = 'Lasciare vuoto per vedere tutti i pagamenti',hint = null,hintkind = 'NOHINT',iscombobox = 'N',lt = {ts '2007-10-18 09:51:52.750'},lu = 'SARA',noselectionforall = 'N',number = '9',selectioncode = null,systype = 'String',tag = 'g',valuemember = null WHERE paramname = 'nmovparent' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('nmovparent','exp_elencopagamenti',{ts '2007-10-17 16:40:49.927'},'SARA',null,'Numero del movimento padre',null,null,'Lasciare vuoto per vedere tutti i pagamenti',null,'NOHINT','N',{ts '2007-10-18 09:51:52.750'},'SARA','N','9',null,'String','g',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'nphaseparent' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-10-17 16:51:41.487'},cu = 'SARA',datasource = 'expensephase',description = 'Fase del movimento Padre',displaymember = 'description',filter = null,help = 'Lasciare vuoto per vedere tutti i pagamenti',hint = null,hintkind = 'NOHINT',iscombobox = 'S',lt = {ts '2007-10-19 13:32:58.000'},lu = 'NINO',noselectionforall = 'N',number = '7',selectioncode = null,systype = 'Byte',tag = null,valuemember = 'nphase' WHERE paramname = 'nphaseparent' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('nphaseparent','exp_elencopagamenti',{ts '2007-10-17 16:51:41.487'},'SARA','expensephase','Fase del movimento Padre','description',null,'Lasciare vuoto per vedere tutti i pagamenti',null,'NOHINT','S',{ts '2007-10-19 13:32:58.000'},'NINO','N','7',null,'Byte',null,'nphase')
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'registry' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:06.140'},cu = '''SA''',datasource = null,description = 'Percipiente',displaymember = null,filter = null,help = null,hint = '%',hintkind = 'STRING',iscombobox = 'N',lt = {ts '2007-05-16 14:46:17.717'},lu = '''SA''',noselectionforall = 'N',number = '3',selectioncode = null,systype = 'String',tag = 'g',valuemember = null WHERE paramname = 'registry' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('registry','exp_elencopagamenti',{ts '2007-05-16 14:40:06.140'},'''SA''',null,'Percipiente',null,null,null,'%','STRING','N',{ts '2007-05-16 14:46:17.717'},'''SA''','N','3',null,'String','g',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ymax' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:06.140'},cu = '''SA''',datasource = null,description = 'All''anno',displaymember = null,filter = null,help = null,hint = null,hintkind = 'ACCOUNTYEAR',iscombobox = 'N',lt = {ts '2007-05-16 14:46:17.717'},lu = '''SA''',noselectionforall = 'N',number = '2',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'ymax' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ymax','exp_elencopagamenti',{ts '2007-05-16 14:40:06.140'},'''SA''',null,'All''anno',null,null,null,null,'ACCOUNTYEAR','N',{ts '2007-05-16 14:46:17.717'},'''SA''','N','2',null,'Int32','year',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ymin' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-05-16 14:40:05.937'},cu = '''SA''',datasource = null,description = 'Dall''anno',displaymember = null,filter = null,help = null,hint = null,hintkind = 'ACCOUNTYEAR',iscombobox = 'N',lt = {ts '2007-05-16 14:46:17.717'},lu = '''SA''',noselectionforall = 'N',number = '1',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'ymin' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ymin','exp_elencopagamenti',{ts '2007-05-16 14:40:05.937'},'''SA''',null,'Dall''anno',null,null,null,null,'ACCOUNTYEAR','N',{ts '2007-05-16 14:46:17.717'},'''SA''','N','1',null,'Int32','year',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ymovparent' AND procedurename = 'exp_elencopagamenti')
UPDATE [exportfunctionparam] SET ct = {ts '2007-10-17 16:39:13.287'},cu = 'SARA',datasource = null,description = 'Esercizio del movimento padre',displaymember = null,filter = null,help = 'Lasciare vuoto per vedere tutti i pagamenti',hint = null,hintkind = 'NOHINT',iscombobox = 'N',lt = {ts '2007-10-17 16:41:17.847'},lu = 'SARA',noselectionforall = 'N',number = '8',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'ymovparent' AND procedurename = 'exp_elencopagamenti'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ymovparent','exp_elencopagamenti',{ts '2007-10-17 16:39:13.287'},'SARA',null,'Esercizio del movimento padre',null,null,'Lasciare vuoto per vedere tutti i pagamenti',null,'NOHINT','N',{ts '2007-10-17 16:41:17.847'},'SARA','N','8',null,'Int32','year',null)
GO

-- FINE GENERAZIONE SCRIPT --


*/
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elencopagamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elencopagamenti]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE  exp_elencopagamenti (
	@ymin int,
	@ymax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@nphaseparent tinyint,
	@ymovparent  int,
	@nmovparent  int
) 
as begin
/* Versione 1.0.1 del 20/12/2007 ultima modifica: MARIA */

declare @idexp int
IF (@nphaseparent IS NULL OR @ymovparent IS NULL OR @nmovparent IS NULL)
	BEGIN
		SET @idexp = null	
	END
Else
	BEGIN
	   	SET @idexp = (select idexp 
				from expense 
				where ymov = @ymovparent 
				and nmov   = @nmovparent 
				and nphase = @nphaseparent) 
	END

/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
select expense.idexp, 
	expenseyear.ayear, 
	expense.idreg, expenseyear.idfin 
	into #prova
	from expense
	join expenseyear 
		on expenseyear.idexp=expense.idexp 
		and (@ymin is null or expenseyear.ayear >= @ymin)
		and (@ymax is null or expenseyear.ayear <= @ymax)
	join expenselast 
		on expenseyear.idexp=expenselast.idexp 
	join registry 
		on expense.idreg=registry.idreg 
		and (@registry is null or registry.title like @registry)
	join fin 
		on fin.idfin=expenseyear.idfin 
		and (@codefin is null or codefin like @codefin)
	JOIN expenselink 
		ON expenselink.idchild = expenselast.idexp  
		AND expenselink.idparent = ISNULL(@idexp,expenselast.idexp) 
	where 
	(@adatemin is null or adate >= @adatemin)
	and (@adatemax is null or adate <= @adatemax)

select 	ymov as 'Esercizio pagamento',
	nmov as 'Numero pagamento',
	codefin as 'Codice bilancio',
	fin.title as 'Voce di bilancio',
	registry.title as 'Beneficiario',
	description as 'Descrizione',
	expensetotal.curramount as 'Importo corrente',
	(select sum(employtax) from expensetax where expensetax.idexp=#prova.idexp) as 'Importo ritenute associate',
	(select sum(amount) from expenseclawback where expenseclawback.idexp=#prova.idexp) as 'Importo recuperi associati',
	expensetotal.curramount
		-(select isnull(sum(employtax),0) from expensetax where expensetax.idexp=#prova.idexp)
		-(select isnull(sum(amount),0) from expenseclawback where expenseclawback.idexp=#prova.idexp) as 'Netto',
	expense.adate as 'Data contabile',
	expense.ymov as 'Esercizio mandato',
	payment.npay as 'Numero mandato',
	paymenttransmission.ypaymenttransmission as 'Eserc. distinta trasm.',
	paymenttransmission.npaymenttransmission as 'Num. distinta trasm.',
	paymenttransmission.transmissiondate as 'Data trasmissione',
	expense.cu as 'cu'
	from #prova
	left outer join fin 
		on fin.idfin=#prova.idfin
	left outer join registry 
		on registry.idreg=#prova.idreg
	left outer join expense 
		on expense.idexp=#prova.idexp
	join expenselast 
		on expenselast.idexp=expense.idexp
	left outer join expensetotal 
		ON expensetotal.idexp = #prova.idexp AND expensetotal.ayear = #prova.ayear 
	left outer join payment
		ON expenselast.kpay = payment.kpay
	left outer join paymenttransmission
		ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
	order by expense.ymov, expense.nmov
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

