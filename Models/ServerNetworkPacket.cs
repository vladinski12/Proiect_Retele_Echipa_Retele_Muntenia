using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Retele_Echipa_Retele_Muntenia.Models
{
	public enum ServerActions
	{
		NotifyClientsWhenClientConnects,
		NotifyClientsWhenClientSendsQuery,
		NotifyClientSendWMIData,
	}

	internal class ServerNetworkPacket
	{
		private ServerActions action;
		public ServerNetworkPacket(ServerActions action)
		{
			this.action = action;
		}
		public ServerActions Action { get => action; set => action = value; }
	}

	internal class NotifyClientsWhenClientConnectsPacket : ServerNetworkPacket
	{
		private string clientName;
		public NotifyClientsWhenClientConnectsPacket(string clientName) : base(ServerActions.NotifyClientsWhenClientConnects)
		{
			this.clientName = clientName;
		}
		public string ClientName { get => clientName; set => clientName = value; }

	}

	internal class NotifyClientsWhenClientSendsQueryPacket : ServerNetworkPacket
	{
		private string clientName;
		public NotifyClientsWhenClientSendsQueryPacket(string clientName) : base(ServerActions.NotifyClientsWhenClientSendsQuery)
		{
			this.clientName = clientName;
		}
		public string ClientName { get => clientName; set => clientName = value; }
	}	

	internal class NotifyClientSendWMIDataPacket : ServerNetworkPacket
	{
		private string clientName;
		private WMIData wmiData;
		public NotifyClientSendWMIDataPacket(string clientName, WMIData wmiData) : base(ServerActions.NotifyClientSendWMIData)
		{
			this.clientName = clientName;
			this.wmiData = wmiData;
		}
		public string ClientName { get => clientName; set => clientName = value; }
		internal WMIData WmiData { get => wmiData; set => wmiData = value; }
	}	

}
