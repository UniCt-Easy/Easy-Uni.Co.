 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_fin_upb_available_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_fin_upb_available_partition]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO
 

 