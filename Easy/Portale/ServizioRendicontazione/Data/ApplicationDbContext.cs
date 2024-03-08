
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
using ServizioRendicontazione.Models;
using EasyCommerce.Models;

namespace ServizioRendicontazione.Data
{
    public partial class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// ===========================================================================
		// REGISTRY
		// ===========================================================================
		public virtual DbSet<registry> registries { get; set; }


		// ===========================================================================
		// LEZIONE
		// ===========================================================================
		public virtual DbSet<areadidattica> areadidatticas { get; set; }
		public virtual DbSet<classescuola> classescuolas { get; set; }
		public virtual DbSet<corsostudio> corsostudios { get; set; }
		public virtual DbSet<corsostudiokind> corsostudiokinds { get; set; }
		public virtual DbSet<corsostudionorma> corsostudionormas { get; set; }
		public virtual DbSet<classescuolakind> classescuolakinds { get; set; }
		public virtual DbSet<didprog> didprogs { get; set; }
		public virtual DbSet<didprogcurr> didprogcurrs { get; set; }
		public virtual DbSet<didprogori> didprogoris { get; set; }
		public virtual DbSet<didproganno> didprogannos { get; set; }
		public virtual DbSet<didprogporzanno> didprogporzannos { get; set; }
		public virtual DbSet<attivform> attivforms { get; set; }
		public virtual DbSet<orakind> orakinds { get; set; }
		public virtual DbSet<canale> canales { get; set; }
		public virtual DbSet<affidamento> affidamentos { get; set; }
		public virtual DbSet<lezione> leziones { get; set; }
		public virtual DbSet<sede> sedes { get; set; }
		public virtual DbSet<GeoCityview> GeoCityviews { get; set; }
		public virtual DbSet<insegn> insegns { get; set; }
		public virtual DbSet<struttura> strutturas { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// ===========================================================================
			// REGISTRY
			// ===========================================================================
			modelBuilder.Entity<registry>().ToTable("registry", common.schemaDbo);
			modelBuilder.Entity<registry>().HasKey(k => k.Idreg);


			// ===========================================================================
			// LEZIONE
			// ===========================================================================
			modelBuilder.Entity<areadidattica>().ToTable("areadidattica", common.schemaDbo);
			modelBuilder.Entity<areadidattica>().HasKey(e => e.idareadidattica);

			modelBuilder.Entity<classescuola>().ToTable("classescuola", common.schemaDbo);
			modelBuilder.Entity<classescuola>().HasKey(e => e.idclassescuola);

			modelBuilder.Entity<corsostudio>().ToTable("corsostudio", common.schemaDbo);
			modelBuilder.Entity<corsostudio>().HasKey(e => e.idcorsostudio);

			modelBuilder.Entity<corsostudiokind>().ToTable("corsostudiokind", common.schemaDbo);
			modelBuilder.Entity<corsostudiokind>().HasKey(e => e.idcorsostudiokind);

			modelBuilder.Entity<corsostudionorma>().ToTable("corsostudionorma", common.schemaDbo);
			modelBuilder.Entity<corsostudionorma>().HasKey(e => e.idcorsostudionorma);

            modelBuilder.Entity<classescuolakind>().ToTable("classescuolakind", common.schemaDbo);
            modelBuilder.Entity<classescuolakind>().HasKey(e => e.idclassescuolakind);

            modelBuilder.Entity<didprog>().ToTable("didprog", common.schemaDbo);
			modelBuilder.Entity<didprog>().HasKey(e => new { 
				e.iddidprog, 
				e.idcorsostudio
			});

			modelBuilder.Entity<didprogcurr>().ToTable("didprogcurr", common.schemaDbo);
			modelBuilder.Entity<didprogcurr>().HasKey(e => new {
				e.iddidprogcurr, 
				e.iddidprog, 
				e.idcorsostudio
			});

			modelBuilder.Entity<didprogori>().ToTable("didprogori", common.schemaDbo);
			modelBuilder.Entity<didprogori>().HasKey(e => new {
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.idcorsostudio
			});

			modelBuilder.Entity<didproganno>().ToTable("didproganno", common.schemaDbo);
			modelBuilder.Entity<didproganno>().HasKey(e => new { 
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.aa,
				e.idcorsostudio
			});

			modelBuilder.Entity<didprogporzanno>().ToTable("didprogporzanno", common.schemaDbo);
			modelBuilder.Entity<didprogporzanno>().HasKey(e => new {
				e.iddidprogporzanno,
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog, 
				e.idcorsostudio, 
				e.aa
			});

			modelBuilder.Entity<attivform>().ToTable("attivform", common.schemaDbo);
			modelBuilder.Entity<attivform>().HasKey(e => new {
				e.idattivform,
				e.iddidprogporzanno,
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.idcorsostudio,
				e.aa,
				e.idsede
			});

			modelBuilder.Entity<orakind>().ToTable("orakind", common.schemaDbo);
			modelBuilder.Entity<orakind>().HasKey(e => e.idorakind);

			modelBuilder.Entity<canale>().ToTable("canale", common.schemaDbo);
			modelBuilder.Entity<canale>().HasKey(e => new {
				e.idcanale,
				e.idattivform,
				e.iddidprogporzanno,
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.idcorsostudio,
				e.aa });

			modelBuilder.Entity<affidamento>().ToTable("affidamento", common.schemaDbo);
			modelBuilder.Entity<affidamento>().HasKey(e => new {
				e.idaffidamento,
				e.idcanale,
				e.idattivform,
				e.iddidprogporzanno,
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.idcorsostudio,
				e.aa });

			modelBuilder.Entity<lezione>().ToTable("lezione", common.schemaDbo);
			modelBuilder.Entity<lezione>().HasKey(e => new {
				e.idlezione,
				e.idaffidamento,
				e.idcanale,
				e.idattivform,
				e.iddidprogporzanno,
				e.iddidproganno,
				e.iddidprogori,
				e.iddidprogcurr,
				e.iddidprog,
				e.idaula,
				e.idsede,
				e.idedificio,
				e.idcorsostudio,
				e.aa,
				e.idreg_docenti
			});

			modelBuilder.Entity<sede>().ToTable("sede", common.schemaDbo);
			modelBuilder.Entity<sede>().HasKey(e => e.idsede);

			modelBuilder.Entity<GeoCityview>().ToView("geo_cityview", common.schemaDbo);
			modelBuilder.Entity<GeoCityview>().HasKey(k => k.Idcity);

			modelBuilder.Entity<insegn>().ToTable("insegn", common.schemaDbo);
			modelBuilder.Entity<insegn>().HasKey(e => e.idinsegn);

			modelBuilder.Entity<struttura>().ToTable("struttura", common.schemaDbo);
			modelBuilder.Entity<struttura>().HasKey(e => e.idstruttura);
		}
	}
}
