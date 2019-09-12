--setuser 'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_carime_ins_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_carime_ins_new]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



