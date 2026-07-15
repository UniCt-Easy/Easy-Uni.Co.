/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using System.Data;

namespace FlussoStudentiService
{
	public class Easy_PostData_NoBLNoTimeStamp : PostData
	{
		override public string GetOptimisticClause(DataRow R)
		{
			if (R.Table.PrimaryKey != null)
			{
				if ((R.Table.Columns["lu"] != null) &&
					(R.Table.Columns["lt"] != null) &&
					R.Table.PrimaryKey.Length > 0)
				{
					int keylen = R.Table.PrimaryKey.Length;
					DataColumn[] Cs = new DataColumn[keylen + 2];
					for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
					Cs[keylen] = R.Table.Columns["lu"];
					Cs[keylen + 1] = R.Table.Columns["lt"];
					return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
				}
			}

			return base.GetOptimisticClause(R);
		}

	}
}
