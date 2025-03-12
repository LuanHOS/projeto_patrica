using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
	internal class pai
	{
		protected int id;

		public pai()
		{
			id = 0;
		}
		public pai(int id)
		{
			this.id = id;
		}

		public int Id { get; set; }
	}
}
