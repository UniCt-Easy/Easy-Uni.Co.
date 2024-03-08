
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


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServizioRendicontazione.Models
{
	public partial class registryMin
	{
		public int Idreg { get; set; }
		public string Cf { get; set; }
	}

	public partial class registry
	{
		[Display(Description = "Identity")]
		[Column("idreg")]
		public int Idreg { get; set; }

		[Required]
		[Column("active")]
		[StringLength(1)]
		public string Active { get; set; }

		[Column("annotation")]
		[StringLength(400)]
		public string Annotation { get; set; }

		[Column("authorization_free")]
		[StringLength(1)]
		public string AuthorizationFree { get; set; }

		[Column("badgecode")]
		[StringLength(20)]
		public string Badgecode { get; set; }

		[DataType(DataType.Date)]
		[Column("birthdate", TypeName = "date")]
		public DateTime? Birthdate { get; set; }

		[Column("cf")]
		[StringLength(16)]
		public string Cf { get; set; }

		[Column("Ct", TypeName = "datetime")]
		public DateTime Ct { get; set; }

		[Required]
		[Column("Cu")]
		[StringLength(64)]
		public string Cu { get; set; }

		[Column("extmatricula")]
		[StringLength(40)]
		public string Extmatricula { get; set; }

		[Column("foreigncf")]
		[StringLength(40)]
		public string Foreigncf { get; set; }

		[Column("forename")]
		[StringLength(50)]
		public string Forename { get; set; }

		[Column("gender")]
		[StringLength(1)]
		public string Gender { get; set; }

		[Column("idaccmotivecredit")]
		[StringLength(36)]
		public string Idaccmotivecredit { get; set; }

		[Column("idaccmotivedebit")]
		[StringLength(36)]
		public string Idaccmotivedebit { get; set; }

		[Column("idcategory")]
		[StringLength(2)]
		public string Idcategory { get; set; }

		[Column("idcentralizedcategory")]
		[StringLength(20)]
		public string Idcentralizedcategory { get; set; }

		[Column("idcity")]
		public int? Idcity { get; set; }
		[Column("idmaritalstatus")]
		[StringLength(20)]
		public string Idmaritalstatus { get; set; }

		[Column("idnation")]
		public int? Idnation { get; set; }

		[Column("idregistryclass")]
		[StringLength(2)]
		public string Idregistryclass { get; set; }

		[Column("idregistrykind")]
		public int? Idregistrykind { get; set; }

		[Column("idtitle")]
		[StringLength(20)]
		public string Idtitle { get; set; }

		[Column("location")]
		[StringLength(50)]
		public string Location { get; set; }

		[Column("Lt", TypeName = "datetime")]
		public DateTime Lt { get; set; }

		[Required]
		[Column("Lu")]
		[StringLength(64)]
		public string Lu { get; set; }

		[Column("maritalsurname")]
		[StringLength(50)]
		public string Maritalsurname { get; set; }

		[Column("multi_cf")]
		[StringLength(1)]
		public string MultiCf { get; set; }

		[Column("p_iva")]
		[StringLength(15)]
		public string PIva { get; set; }

		[Column("residence")]
		public int Residence { get; set; }

		[Column("rtf", TypeName = "image")]
		public byte[] Rtf { get; set; }

		[Column("surname")]
		[StringLength(50)]
		public string Surname { get; set; }

		[Required]
		[Column("title")]
		[StringLength(100)]
		public string Title { get; set; }

		[Column("toredirect")]
		public int? Toredirect { get; set; }

		[Column("txt", TypeName = "text")]
		public string Txt { get; set; }

		[Column("ccp")]
		[StringLength(12)]
		public string Ccp { get; set; }

		[Column("flagbankitaliaproceeds")]
		[StringLength(1)]
		public string Flagbankitaliaproceeds { get; set; }

		[Column("idexternal")]
		public int? Idexternal { get; set; }

		[Column("ipa_fe")]
		[StringLength(7)]
		public string IpaFe { get; set; }

		[Column("flag_pa")]
		[StringLength(1)]
		public string FlagPa { get; set; }

		[Column("sdi_defrifamm")]
		[StringLength(20)]
		public string SdiDefrifamm { get; set; }

		[Column("sdi_norifamm")]
		[StringLength(1)]
		public string SdiNorifamm { get; set; }

		[Column("email_fe")]
		[StringLength(200)]
		public string EmailFe { get; set; }

		[Column("pec_fe")]
		[StringLength(200)]
		public string PecFe { get; set; }

		[Column("ipa_perlapa")]
		[StringLength(100)]
		public string IpaPerlapa { get; set; }

		[Column("extension")]
		[StringLength(200)]
		public string Extension { get; set; }
	}
}
