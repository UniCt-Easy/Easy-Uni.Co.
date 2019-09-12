if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_carime_var_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_carime_var_new]
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

