using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Client.Models;
using System.Management;

namespace Proiect_Retele_Echipa_Retele_Muntenia
{
	public partial class Form1 : Form
	{
		private TcpClient _client;
		private PacketReader _packetReader;
		private List<User> _users;

		public Form1()
		{
			InitializeComponent();
			_client = new TcpClient();
			_users = new List<User>();
			IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
			foreach (IPAddress address in localIP)
			{
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					clientIPTextBox.Text = address.ToString();
				}
			}
			queryTextBox.ReadOnly = true;
		}

		private void clientConnectButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (_client.Connected)
				{
					MessageBox.Show("Client is already connected");
					return;
				}
				int port;
				if (!int.TryParse(clientPortTextBox.Text, out port))
				{
					MessageBox.Show("Invalid port");
					return;
				}
				_client.Connect("127.0.0.1", port);
				_packetReader = new PacketReader(_client.GetStream());
				var connectPacket = new PacketBuilder();
				connectPacket.WriteOpCode(0);
				connectPacket.WriteString(_client.Client.RemoteEndPoint.ToString());
				connectPacket.WriteString(ExecuteWMIQuery("SELECT Name FROM Win32_ComputerSystem"));
				_client.Client.Send(connectPacket.GetPacketBytes());
				ReadPackets();

				outputTextBox.AppendText("Connected to server");
				outputTextBox.AppendText(Environment.NewLine);
				clientPortTextBox.Enabled = false;
				clientConnectButton.Enabled = false;
				queryTextBox.ReadOnly = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void queryButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (clientsListBox.SelectedItems.Count == 0)
				{
					MessageBox.Show("No clients selected");
					return;
				}
				if (string.IsNullOrEmpty(queryTextBox.Text))
				{
					MessageBox.Show("Query is empty");
					return;
				}
				foreach (var item in clientsListBox.SelectedItems)
				{
					var queryPacket = new PacketBuilder();
					queryPacket.WriteOpCode(3);
					queryPacket.WriteString(item.ToString().Split("Address:")[1].Trim());
					queryPacket.WriteString(queryTextBox.Text);
					_client.Client.Send(queryPacket.GetPacketBytes());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ReadPackets()
		{
			Task.Run(() =>
			{
				while (true)
				{
					var opcode = _packetReader.ReadByte();
					switch (opcode)
					{
						case 1:
							{
								var address = _packetReader.ReadMessage();
								var name = _packetReader.ReadMessage();
								if (_users.Any(u => u.Address == address))
								{
									break;
								}
								_users.Add(new User(address, name));
								clientsListBox.Invoke(new Action(() =>
								{
									clientsListBox.Items.Add($"Name: {name} - Address: {address}");
								}));
								break;
							}
						case 2:
							{
								var address = _packetReader.ReadMessage();
								_users.RemoveAll(u => u.Address == address);
								clientsListBox.Invoke(new Action(() =>
								{
									clientsListBox.Items.Remove(address);
								}));
								break;
							}
						case 4:
							{
								var targetAddress = _packetReader.ReadMessage();
								var query = _packetReader.ReadMessage();
								var queryResult = ExecuteWMIQuery(query);
								var wmiPacket = new PacketBuilder();
								wmiPacket.WriteOpCode(5);
								wmiPacket.WriteString(targetAddress);
								wmiPacket.WriteString(_client.Client.RemoteEndPoint.ToString());
								wmiPacket.WriteString(JsonConvert.SerializeObject(queryResult));
								_client.Client.Send(wmiPacket.GetPacketBytes());
								outputTextBox.Invoke(new Action(() =>
								{
									outputTextBox.AppendText($"Sent WMI data to {targetAddress}");
									outputTextBox.AppendText(Environment.NewLine);

								}));
								break;
							}
						case 6:
							{
								var fromAddress = _packetReader.ReadMessage();
								var data = _packetReader.ReadMessage();
								var wmiData = JsonConvert.DeserializeObject(data);
								outputTextBox.Invoke(new Action(() =>
								{
									outputTextBox.AppendText($"Received WMI data from {fromAddress}");
									outputTextBox.AppendText(Environment.NewLine);
									outputTextBox.AppendText(wmiData.ToString());
								}));
								break;
							}
						case 7:
							{
								var message = _packetReader.ReadMessage();
								MessageBox.Show(message);
								_client.Dispose();
								this.Close();
								break;
							}
						default:
							MessageBox.Show("Invalid opcode");
							break;
					}
				}
			});
		}

		public string ExecuteWMIQuery(string query)
		{
			string result = "";
			Dictionary<string, string> queryResult = new Dictionary<string, string>();
			ConnectionOptions options = new ConnectionOptions();
			options.Impersonation = ImpersonationLevel.Impersonate;
			ManagementScope scope = new ManagementScope(@"\\.\root\cimv2", options);
			scope.Connect();
			ObjectQuery objectQuery = new ObjectQuery(query);
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, objectQuery);
			ManagementObjectCollection queryCollection = searcher.Get();
			foreach (ManagementObject queryObject in queryCollection)
			{
				foreach (PropertyData property in queryObject.Properties)
				{
					if (!queryResult.ContainsKey(property.Name))
					{
						queryResult[property.Name] = property.Value.ToString();
					}
				}
			}
			foreach (var item in queryResult)
			{
				result += $"{item.Key} : {item.Value}\n";
			}
			return result;
		}
	}
}
