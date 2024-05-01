namespace Proiect_Retele_Echipa_Retele_Muntenia.Models
{
	public enum ClientActions
	{
		SendQuery,
		SendWMIData,
	}
	internal class ClientNetworkPacket
	{
		private ClientActions action;
		public ClientNetworkPacket(ClientActions action)
		{
			this.action = action;
		}
		public ClientActions Action { get => action; set => action = value; }
	}

	internal class SendQueryPacket : ClientNetworkPacket
	{
		private List<string> clientsToQuery;
		public SendQueryPacket(List<string> clientsToQuery) : base(ClientActions.SendQuery)
		{
			this.clientsToQuery = clientsToQuery;
		}
		public List<string> ClientsToQuery { get => clientsToQuery; set => clientsToQuery = value; }

	}

	internal class SendWMIDataPacket : ClientNetworkPacket
	{
		private string targetClient;
		public WMIData wmiData;
		public SendWMIDataPacket(string targetClient, WMIData wmiData) : base(ClientActions.SendWMIData)
		{
			this.targetClient = targetClient;
			this.wmiData = wmiData;
		}
		public string TargetClient { get => targetClient; set => targetClient = value; }
	}
}
