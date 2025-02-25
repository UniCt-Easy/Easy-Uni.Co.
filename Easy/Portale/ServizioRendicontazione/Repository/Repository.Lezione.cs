
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


using Microsoft.EntityFrameworkCore;
using ServizioRendicontazione.Models;

namespace ServizioRendicontazione.Repositories
{
	public partial class Repository
	{
        // ==============================================================
        // LEZIONE
        // ==============================================================
        public List<lezione> AllLezione(int idreg)
        {
			// Le lezioni dal primo gennaio del primo anno da considerare
			if (idreg != 0)
                return _context.leziones.AsNoTracking().Where(w => w.idreg_docenti == idreg && w.Cu == common.cu).ToList();
			else
				return _context.leziones.AsNoTracking().Where(w => w.Cu == common.cu).ToList();
        }

		public bool AnyLezione(int idreg, DateTime inizioLezione, DateTime fineLezione, string aaaa_aaaa_Lezione)
		{
			return _context.leziones.Any(w => w.idreg_docenti == idreg
												   && w.start == inizioLezione
													&& w.stop == fineLezione
													  && w.aa == aaaa_aaaa_Lezione);
		}

		public void UpdateTitoloLezione(int idLezione, string titolo)
		{
			try
			{
				lezione lez = _context.leziones.FirstOrDefault(m => m.idlezione == idLezione);

				if (lez != null)
				{
					lez.titolo = titolo;
					_context.SaveChanges();
				}
			}
			catch (Exception Ex)
			{
				common.logInfo($"Errore UpdateTitoloLezione({idLezione},{titolo}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		public void AddLezione(int idcorsostudio,
							   int iddidprog,
							   int iddidprogcurr,
							   int iddidprogori,
							   int iddidproganno,
							   int iddidprogporzanno,
							   int idattivform,
							   int idsede,
							   int idaffidamento,
							   int idcanale,
							   int idreg_docenti,
						  DateTime start,
						  DateTime stop,
						    string aa,
							string titolo)
		{
			int idlezione = 0;
			
			try { idlezione = _context.leziones.AsNoTracking().Max(m => m.idlezione); } catch { }

			try
			{
				idlezione++;

				lezione lez = new lezione()
				{
					idlezione = idlezione,
					idaffidamento = idaffidamento,
					idcanale = idcanale,
					idattivform = idattivform,
					iddidprogporzanno = iddidprogporzanno,
					iddidproganno = iddidproganno,
					iddidprogori = iddidprogori,
					iddidprogcurr = iddidprogcurr,
					iddidprog = iddidprog,
					idsede = idsede,
					idcorsostudio = idcorsostudio,
					aa = aa,
					idreg_docenti = idreg_docenti,
					start = start,
					stop = stop,

					idaula = 0,
					idedificio = 0,

					nonsvolta = null,
					stage = null,
					visita = null,

					titolo = titolo
				};

				_context.Add(lez);
				_context.SaveChanges();
			}
			catch (Exception Ex)
			{
				common.logInfo($"Errore AddLezione({idcorsostudio},{iddidprog},{iddidprogcurr},{iddidprogori},{iddidproganno},{iddidprogporzanno},{idattivform},{idsede},{idaffidamento},{idcanale},{idreg_docenti},{start},{stop},{aa}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		public void DeleteLezione(int idlezione)
		{
			try
			{
				lezione lez = _context.leziones.AsNoTracking().FirstOrDefault(w => w.idlezione == idlezione);

				_context.Remove(lez);
				_context.SaveChanges();

			}
			catch (Exception Ex)
			{
				common.logInfo($"DeleteLezione({idlezione}): \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}

		public void PuliziaDidattica()
		{
			try
			{
				_context.Database.ExecuteSqlRaw(sqlPuliziaDidattica);
			}
			catch (Exception Ex)
			{
				common.logInfo("PuliziaDidattica: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
        }

        public void EliminaLezioni(string idLezList)
        {
            try
            {
				string delLez = $"delete lezione where idlezione in ({idLezList})";

                _context.Database.ExecuteSqlRaw(delLez);
            }
            catch (Exception Ex)
            {
                common.logInfo("PuliziaDidattica: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
            }
        }

        public void ClearDidattica()
		{
			try
			{
				_context.Database.ExecuteSqlRaw(sqlClearDidattica);
			}
			catch (Exception Ex)
			{
				common.logInfo("ClearDidattica: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}
		}


		// ========================================================================================================================================================================================================
		//																								SQL
		// ========================================================================================================================================================================================================
		string sqlPuliziaDidattica = @"IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[_rendicontdidattica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[_rendicontdidattica](
		[idrendicontdidattica] [int] NOT NULL,
		[idreg] [int] NOT NULL,
		[ct] [datetime] NULL,
		[cu] [varchar](64) NULL,
		[idsede] [int] NULL,
		[lt] [datetime] NULL,
		[lu] [varchar](64) NULL,
		[start] [datetime] NULL,
		[stop] [datetime] NULL,
		[title] [varchar](4000) NULL,
		[idlezione] [int] NOT NULL
	) ON [PRIMARY]
END

INSERT INTO dbo._rendicontdidattica
SELECT [idrendicontdidattica]
      ,[idreg]
      ,dbo.rendicontdidattica.[ct]
      ,dbo.rendicontdidattica.[cu]
      ,dbo.rendicontdidattica.[idsede]
      ,dbo.rendicontdidattica.[lt]
      ,dbo.rendicontdidattica.[lu]
      ,dbo.rendicontdidattica.[start]
      ,dbo.rendicontdidattica.[stop]
      ,[title]
	  ,dbo.lezione.idlezione
FROM dbo.rendicontdidattica 
inner join dbo.lezione on dbo.rendicontdidattica.idreg = dbo.lezione.idreg_docenti and dbo.lezione.start = dbo.rendicontdidattica.start;

DELETE rendicontdidattica
FROM rendicontdidattica INNER JOIN lezione
ON rendicontdidattica.idreg = lezione.idreg_docenti and lezione.start = rendicontdidattica.start;";


		// ========================================================================================================================================================================================================
		//																								SQL
		// ========================================================================================================================================================================================================
		string sqlClearDidattica = @"
delete areadidattica		where cu = 'ApiEsse3';
delete classescuola			where lu = 'ApiEsse3';
delete corsostudionorma		where lu = 'ApiEsse3';
delete corsostudiokind		where cu = 'ApiEsse3';
delete orakind				where cu = 'ApiEsse3';
delete insegn				where cu = 'ApiEsse3';
delete struttura			where cu = 'ApiEsse3';
delete lezione				where cu = 'ApiEsse3';
delete affidamento			where cu = 'ApiEsse3';
delete canale				where cu = 'ApiEsse3';
delete attivform			where cu = 'ApiEsse3';
delete didprogporzanno		where cu = 'ApiEsse3';
delete didproganno			where cu = 'ApiEsse3';
delete didprogori			where cu = 'ApiEsse3';
delete didprogcurr			where cu = 'ApiEsse3';
delete didprog;
delete corsostudio			where cu = 'ApiEsse3';";
	}
}
