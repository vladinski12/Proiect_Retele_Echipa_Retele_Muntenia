using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Retele_Echipa_Retele_Muntenia.Models
{
	internal class WMIData
	{
		private string clientName;

		public WMIData(string clientName)
		{
			this.clientName = clientName;
		}

		public string ClientName { get => clientName; set => clientName = value; }

		public override string? ToString()
		{
			return String.Format("Client Name: {0}", clientName);
		}
	}
}
