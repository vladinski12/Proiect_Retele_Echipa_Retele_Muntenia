using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using Proiect_Retele_Echipa_Retele_Muntenia.Models;
using Newtonsoft.Json;

namespace Proiect_Retele_Echipa_Retele_Muntenia
{

	// SERVER:
	// serverStartButton_Click - start server
	// backgroundWorker1_DoWork - accept client connections
	// backgroundWorker2_DoWork - handle client sent packets

	// CLIENT: 
	// clientConnectButton_Click - connect to server
	// backgroundWorker3_DoWork - handle server data sent to client
	// queryButton_Click - send query to server

	public partial class Form1 : Form
	{
		private TcpListener listener;
		private TcpClient client;
		private List<TcpClient> clients;
		private StreamReader reader;
		private StreamWriter writer;

		/// <summary>
		/// Set default server IP address
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			clients = new List<TcpClient>();
			IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
			foreach (IPAddress address in localIP)
			{
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					serverIPTextBox.Text = address.ToString();
				}
			}
		}

		/// <summary>
		/// SERVER: Handle server start button click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void serverStartButton_Click(object sender, EventArgs e)
		{
			int port;
			if (!int.TryParse(serverPortTextBox.Text, out port))
			{
				MessageBox.Show("Invalid port number");
				return;
			}
			try
			{
				listener = new TcpListener(IPAddress.Any, port);
				listener.Start();
				outputTextBox.AppendText(String.Format("Server started on {0}:{1}", serverIPTextBox.Text, serverPortTextBox.Text));
				outputTextBox.AppendText(Environment.NewLine);
				//clientConnectButton.Enabled = false;
				//queryButton.Enabled = false;
				Thread thread = new Thread(HandleClientConnections);
				thread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// CLIENT: Handle client connection button click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clientConnectButton_Click(object sender, EventArgs e)
		{
			try
			{
				client = new TcpClient();
				IPEndPoint clientEnpoint = new IPEndPoint(IPAddress.Parse(clientIPTextBox.Text), int.Parse(clientPortTextBox.Text));
				client.Connect(clientEnpoint);
				outputTextBox.AppendText(String.Format("Connected to server on {0}:{1}", clientIPTextBox.Text, clientPortTextBox.Text));
				outputTextBox.AppendText(Environment.NewLine);
				reader = new StreamReader(client.GetStream());
				writer = new StreamWriter(client.GetStream());
				writer.AutoFlush = true;
				serverStartButton.Enabled = false;
				Thread clientThread = new Thread(HandleServerDataSent);
				clientThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// CLIENT: Handle send query button click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void queryButton_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> clientsToQuery = new List<string>();
				foreach (var item in clientsListBox.SelectedItems)
				{
					clientsToQuery.Add(item.ToString());
				}
				ClientNetworkPacket clientNetworkPacket = new SendQueryPacket(clientsToQuery);
				string json = JsonConvert.SerializeObject(clientNetworkPacket);
				writer.WriteLine(json);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// SERVER: Handle connections from clients
		/// </summary>
		private void HandleClientConnections()
		{
			while (true)
			{
				TcpClient client = listener.AcceptTcpClient();
				clients.Add(client);
				outputTextBox.Invoke(new MethodInvoker(delegate ()
				{
					outputTextBox.AppendText(String.Format("Client connected: {0}", client.Client.RemoteEndPoint.ToString()));
					outputTextBox.AppendText(Environment.NewLine);
				}));
				Thread serverThread = new Thread(() => HandleClientSentPackets(client));
				serverThread.Start();
			}
		}


		/// <summary>
		/// SERVER: Handle client sent packets
		/// </summary>
		/// <param name="client"></param>
		private void HandleClientSentPackets(TcpClient client)
		{
			try
			{
				using StreamReader reader = new StreamReader(client.GetStream());
				using StreamWriter writer = new StreamWriter(client.GetStream());
				writer.AutoFlush = true;
				clientsListBox.Invoke(new MethodInvoker(delegate ()
				{
					clientsListBox.Items.Add(client.Client.RemoteEndPoint.ToString());
				}));
				foreach (TcpClient item in clients)
				{
					ServerNetworkPacket serverNetworkPacket = new NotifyClientsWhenClientConnectsPacket(client.Client.RemoteEndPoint.ToString());
					string jsonToSend = JsonConvert.SerializeObject(serverNetworkPacket);
					writer.WriteLine(jsonToSend);
				}
				while (client.Connected)
				{
					string json = reader.ReadLine();
					outputTextBox.Invoke(new MethodInvoker(delegate ()
					{
						outputTextBox.AppendText(String.Format("Received data from client {0} - {1}", client.Client.RemoteEndPoint.ToString(),json));
						outputTextBox.AppendText(Environment.NewLine);
					}));
					ClientNetworkPacket packet = JsonConvert.DeserializeObject<ClientNetworkPacket>(json);
					if (packet.Action == ClientActions.SendQuery)
					{
						SendQueryPacket sendQueryPacket = JsonConvert.DeserializeObject<SendQueryPacket>(json);
						foreach (string clientAddress in sendQueryPacket.ClientsToQuery)
						{
							foreach (TcpClient item in clients)
							{
								if (item.Connected && item.Client.RemoteEndPoint.ToString() == clientAddress)
								{
									using StreamWriter writerClient = new StreamWriter(item.GetStream());
									writerClient.AutoFlush = true;
									ServerNetworkPacket serverNetworkPacket = new NotifyClientsWhenClientSendsQueryPacket(client.Client.RemoteEndPoint.ToString());
									string jsonToSend = JsonConvert.SerializeObject(serverNetworkPacket);
									writerClient.WriteLine(jsonToSend);
								}
							}
						}
					}
					if (packet.Action == ClientActions.SendWMIData)
					{
						SendWMIDataPacket sendWMIDataPacket = JsonConvert.DeserializeObject<SendWMIDataPacket>(json);
						WMIData wmiData = sendWMIDataPacket.wmiData;
						outputTextBox.Invoke(new MethodInvoker(delegate ()
						{
							outputTextBox.AppendText(String.Format("Received WMI data from client {0}", wmiData.ClientName));
							outputTextBox.AppendText(Environment.NewLine);
						}));
						TcpClient targetClient = clients.Find(x => x.Client.RemoteEndPoint.ToString() == sendWMIDataPacket.TargetClient);
						using StreamWriter writerClient = new StreamWriter(targetClient.GetStream());
						writerClient.AutoFlush = true;
						ServerNetworkPacket serverNetworkPacket = new NotifyClientSendWMIDataPacket(client.Client.RemoteEndPoint.ToString(), wmiData);
						string jsonToSend = JsonConvert.SerializeObject(serverNetworkPacket);
						writerClient.WriteLine(jsonToSend);
					}
				}
				clients.Remove(client);
				client.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// CLIENT: Handle server data sent to client
		/// </summary>
		private void HandleServerDataSent()
		{
			try
			{
				while (client.Connected)
				{
					string json = reader.ReadLine();

					ServerNetworkPacket packet = JsonConvert.DeserializeObject<ServerNetworkPacket>(json);
					if (packet.Action == ServerActions.NotifyClientsWhenClientConnects)
					{
						NotifyClientsWhenClientConnectsPacket notifyClientsWhenClientConnectsPacket = JsonConvert.DeserializeObject<NotifyClientsWhenClientConnectsPacket>(json);
						clientsListBox.Invoke(new MethodInvoker(delegate ()
						{
							clientsListBox.Items.Add(notifyClientsWhenClientConnectsPacket.ClientName);
						}));
					}
					else if (packet.Action == ServerActions.NotifyClientsWhenClientSendsQuery)
					{
						NotifyClientsWhenClientSendsQueryPacket notifyClientsWhenClientSendsQueryPacket = JsonConvert.DeserializeObject<NotifyClientsWhenClientSendsQueryPacket>(json);
						outputTextBox.Invoke(new MethodInvoker(delegate ()
						{
							outputTextBox.AppendText(String.Format("Client {0} sent a query", notifyClientsWhenClientSendsQueryPacket.ClientName));
							outputTextBox.AppendText(Environment.NewLine);
						}));
						WMIData wmiData = new WMIData(notifyClientsWhenClientSendsQueryPacket.ClientName);
						ClientNetworkPacket clientNetworkPacket = new SendWMIDataPacket(notifyClientsWhenClientSendsQueryPacket.ClientName, wmiData);
						string jsonToSend = JsonConvert.SerializeObject(clientNetworkPacket);
						writer.WriteLine(jsonToSend);
					}
					else if (packet.Action == ServerActions.NotifyClientSendWMIData)
					{
						NotifyClientSendWMIDataPacket notifyClientSendWMIDataPacket = JsonConvert.DeserializeObject<NotifyClientSendWMIDataPacket>(json);
						outputTextBox.Invoke(new MethodInvoker(delegate ()
						{
							outputTextBox.AppendText(String.Format("Received WMI data from client {0}", notifyClientSendWMIDataPacket.WmiData.ToString()));
							outputTextBox.AppendText(Environment.NewLine);
						}));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
