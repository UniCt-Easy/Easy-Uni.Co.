
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


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace ServizioRendicontazione.Data
{
    public partial class ApplicationDbContext : DbContext
    {
		private const string CrLf = "\r\n";
		private const string Ct = "Ct";
		private const string Cu = "Cu";
		private const string Lt = "Lt";
		private const string Lu = "Lu";

		public override int SaveChanges()
		{
			DateTime _ct = DateTime.Now;
			string _cu = common.cu;

			try
            {
				// ===================================================================================
				// CHECK Ct, Cu, Lt, Lu for ADDED 
				// ===================================================================================
				if (ChangeTracker.Entries().Any(x => x.State == EntityState.Added))
				{
					try
					{
						List<EntityEntry> entityEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();
						foreach (EntityEntry entityEntry in entityEntries)
						{
							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Ct))
								if (entityEntry.Property(Ct).CurrentValue == null || (DateTime)entityEntry.Property(Ct).CurrentValue == new DateTime())
									entityEntry.Property(Ct).CurrentValue = _ct;
							
							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Cu))
								if (string.IsNullOrEmpty(entityEntry.Property(Cu).CurrentValue?.ToString()))
									entityEntry.Property(Cu).CurrentValue = _cu;
							
							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Lt))
								if (entityEntry.Property(Lt).CurrentValue == null || (DateTime)entityEntry.Property(Lt).CurrentValue == new DateTime())
									entityEntry.Property(Lt).CurrentValue = _ct;

							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Lu))
								if (string.IsNullOrEmpty(entityEntry.Property(Lu).CurrentValue?.ToString()))
									entityEntry.Property(Lu).CurrentValue = _cu;
						}
					}
					catch
					{
						// L'aggiornamento dei campi Ct, Cu, Lt, Lu avviene solo se presenti, quindi l'errore è improbabile
						// tuttavia se accadesse, non è grave e tale da fermare l'operazione di insert che procederà comunque
						// invio la notifica dell'eventuale errore via mail
					}
				}

				// ===================================================================================
				// CHECK Lt, Lu for UPDATED
				// ===================================================================================
				if (ChangeTracker.Entries().Any(x => x.State == EntityState.Modified))
				{
					try
					{
						List<EntityEntry> entityEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
						foreach (EntityEntry entityEntry in entityEntries)
						{
							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Lt))
								if (entityEntry.Property(Lt).CurrentValue == null || (DateTime)entityEntry.Property(Lt).CurrentValue == new DateTime())
									entityEntry.Property(Lt).CurrentValue = _ct;

							if (entityEntry.Metadata.GetProperties().Any(w => w.Name == Lu))
								if (string.IsNullOrEmpty(entityEntry.Property(Lu).CurrentValue?.ToString()))
									entityEntry.Property(Lu).CurrentValue = _cu;
						}
					}
					catch
					{
						// L'aggiornamento dei campi Ct, Cu, Lt, Lu avviene solo se presenti, quindi l'errore è improbabile
						// tuttavia se accadesse, non è grave e tale da fermare l'operazione di update che procederà comunque
						// invio la notifica dell'eventuale errore via mail
					}
				}

				return base.SaveChanges();
			}
            catch (Exception Ex)
            {
				throw (Exception)Activator.CreateInstance(Ex.GetType(), Ex.InnerException + GetEntries(), Ex);
            }
            
        }

		private string GetEntries()
		{
			string entries = "";

			try
			{
				List<EntityEntry> entityEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
				foreach (EntityEntry entityEntry in entityEntries)
				{
					entries += GetEntity(entityEntry);
				}
			}
			catch { }

			return entries;
		}

		private string GetEntity(EntityEntry entityEntry)
		{
			return CrLf + "[" + entityEntry.Entity.GetType().Name + "]" +
					CrLf + JsonConvert.SerializeObject(entityEntry.Entity)
										.Replace("{\"", "")
										.Replace("}", "")
										.Replace("\":", ": ")
										.Replace(",\"", CrLf);
		}
	}
}
