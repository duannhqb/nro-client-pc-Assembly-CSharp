using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// Token: 0x02000028 RID: 40
public class Session_ME2 : ISession
{
	// Token: 0x0600016A RID: 362 RVA: 0x000045F9 File Offset: 0x000027F9
	public Session_ME2()
	{
		Debug.Log("init Session_ME");
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00004714 File Offset: 0x00002914
	public void clearSendingMessage()
	{
		Session_ME2.sender.sendingMessage.Clear();
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00004725 File Offset: 0x00002925
	public static Session_ME2 gI()
	{
		if (Session_ME2.instance == null)
		{
			Session_ME2.instance = new Session_ME2();
		}
		return Session_ME2.instance;
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00004740 File Offset: 0x00002940
	public bool isConnected()
	{
		return Session_ME2.connected;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00004747 File Offset: 0x00002947
	public void setHandler(IMessageHandler msgHandler)
	{
		Session_ME2.messageHandler = msgHandler;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0000D854 File Offset: 0x0000BA54
	public void connect(string host, int port)
	{
		if (Session_ME2.connected || Session_ME2.connecting)
		{
			return;
		}
		this.host = host;
		this.port = port;
		Session_ME2.getKeyComplete = false;
		Session_ME2.sc = null;
		Debug.Log("connecting...!");
		Debug.Log("host: " + host);
		Debug.Log("port: " + port);
		Session_ME2.initThread = new Thread(new ThreadStart(this.NetworkInit));
		Session_ME2.initThread.Start();
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0000D8E0 File Offset: 0x0000BAE0
	private void NetworkInit()
	{
		Session_ME2.isCancel = false;
		Session_ME2.connecting = true;
		Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
		Session_ME2.connected = true;
		try
		{
			this.doConnect(this.host, this.port);
			Session_ME2.messageHandler.onConnectOK(Session_ME2.isMainSession);
		}
		catch (Exception)
		{
			if (Session_ME2.messageHandler != null)
			{
				this.close();
				Session_ME2.messageHandler.onConnectionFail(Session_ME2.isMainSession);
			}
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x0000D968 File Offset: 0x0000BB68
	public void doConnect(string host, int port)
	{
		Session_ME2.sc = new TcpClient();
		Session_ME2.sc.Connect(host, port);
		Session_ME2.dataStream = Session_ME2.sc.GetStream();
		Session_ME2.dis = new BinaryReader(Session_ME2.dataStream, new UTF8Encoding());
		Session_ME2.dos = new BinaryWriter(Session_ME2.dataStream, new UTF8Encoding());
		new Thread(new ThreadStart(Session_ME2.sender.run)).Start();
		Session_ME2.MessageCollector @object = new Session_ME2.MessageCollector();
		Cout.LogError("new -----");
		Session_ME2.collectorThread = new Thread(new ThreadStart(@object.run));
		Session_ME2.collectorThread.Start();
		Session_ME2.timeConnected = Session_ME2.currentTimeMillis();
		Session_ME2.connecting = false;
		Session_ME2.doSendMessage(new Message(-27));
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000474F File Offset: 0x0000294F
	public void sendMessage(Message message)
	{
		Res.outz("SEND MSG: " + message.command);
		Session_ME2.sender.AddMessage(message);
	}

	// Token: 0x06000173 RID: 371 RVA: 0x0000DA28 File Offset: 0x0000BC28
	private static void doSendMessage(Message m)
	{
		sbyte[] data = m.getData();
		try
		{
			if (Session_ME2.getKeyComplete)
			{
				sbyte value = Session_ME2.writeKey(m.command);
				Session_ME2.dos.Write(value);
			}
			else
			{
				Session_ME2.dos.Write(m.command);
			}
			if (data != null)
			{
				int num = data.Length;
				if (Session_ME2.getKeyComplete)
				{
					int num2 = (int)Session_ME2.writeKey((sbyte)(num >> 8));
					Session_ME2.dos.Write((sbyte)num2);
					int num3 = (int)Session_ME2.writeKey((sbyte)(num & 255));
					Session_ME2.dos.Write((sbyte)num3);
				}
				else
				{
					Session_ME2.dos.Write((ushort)num);
				}
				if (Session_ME2.getKeyComplete)
				{
					for (int i = 0; i < data.Length; i++)
					{
						sbyte value2 = Session_ME2.writeKey(data[i]);
						Session_ME2.dos.Write(value2);
					}
				}
				Session_ME2.sendByteCount += 5 + data.Length;
			}
			else
			{
				if (Session_ME2.getKeyComplete)
				{
					int num4 = 0;
					int num5 = (int)Session_ME2.writeKey((sbyte)(num4 >> 8));
					Session_ME2.dos.Write((sbyte)num5);
					int num6 = (int)Session_ME2.writeKey((sbyte)(num4 & 255));
					Session_ME2.dos.Write((sbyte)num6);
				}
				else
				{
					Session_ME2.dos.Write(0);
				}
				Session_ME2.sendByteCount += 5;
			}
			Session_ME2.dos.Flush();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x0000DBB8 File Offset: 0x0000BDB8
	public static sbyte readKey(sbyte b)
	{
		sbyte[] array = Session_ME2.key;
		sbyte b2 = Session_ME2.curR;
		Session_ME2.curR = (sbyte)((int)b2 + 1);
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME2.curR >= Session_ME2.key.Length)
		{
			Session_ME2.curR = (sbyte)((int)Session_ME2.curR % (int)((sbyte)Session_ME2.key.Length));
		}
		return result;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x0000DC18 File Offset: 0x0000BE18
	public static sbyte writeKey(sbyte b)
	{
		sbyte[] array = Session_ME2.key;
		sbyte b2 = Session_ME2.curW;
		Session_ME2.curW = (sbyte)((int)b2 + 1);
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME2.curW >= Session_ME2.key.Length)
		{
			Session_ME2.curW = (sbyte)((int)Session_ME2.curW % (int)((sbyte)Session_ME2.key.Length));
		}
		return result;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00004776 File Offset: 0x00002976
	public static void onRecieveMsg(Message msg)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			Session_ME2.messageHandler.onMessage(msg);
		}
		else
		{
			Session_ME2.recieveMsg.addElement(msg);
		}
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0000DC78 File Offset: 0x0000BE78
	public static void update()
	{
		while (Session_ME2.recieveMsg.size() > 0)
		{
			Message message = (Message)Session_ME2.recieveMsg.elementAt(0);
			if (Controller.isStopReadMessage)
			{
				return;
			}
			if (message == null)
			{
				Session_ME2.recieveMsg.removeElementAt(0);
				return;
			}
			Session_ME2.messageHandler.onMessage(message);
			Session_ME2.recieveMsg.removeElementAt(0);
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x000047AC File Offset: 0x000029AC
	public void close()
	{
		Session_ME2.cleanNetwork();
	}

	// Token: 0x06000179 RID: 377 RVA: 0x0000DCE0 File Offset: 0x0000BEE0
	private static void cleanNetwork()
	{
		Session_ME2.key = null;
		Session_ME2.curR = 0;
		Session_ME2.curW = 0;
		try
		{
			Session_ME2.connected = false;
			Session_ME2.connecting = false;
			if (Session_ME2.sc != null)
			{
				Session_ME2.sc.Close();
				Session_ME2.sc = null;
			}
			if (Session_ME2.dataStream != null)
			{
				Session_ME2.dataStream.Close();
				Session_ME2.dataStream = null;
			}
			if (Session_ME2.dos != null)
			{
				Session_ME2.dos.Close();
				Session_ME2.dos = null;
			}
			if (Session_ME2.dis != null)
			{
				Session_ME2.dis.Close();
				Session_ME2.dis = null;
			}
			Session_ME2.sendThread = null;
			Session_ME2.collectorThread = null;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x000046B6 File Offset: 0x000028B6
	public static int currentTimeMillis()
	{
		return Environment.TickCount;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00003B40 File Offset: 0x00001D40
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00008494 File Offset: 0x00006694
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x04000143 RID: 323
	protected static Session_ME2 instance = new Session_ME2();

	// Token: 0x04000144 RID: 324
	private static NetworkStream dataStream;

	// Token: 0x04000145 RID: 325
	private static BinaryReader dis;

	// Token: 0x04000146 RID: 326
	private static BinaryWriter dos;

	// Token: 0x04000147 RID: 327
	public static IMessageHandler messageHandler;

	// Token: 0x04000148 RID: 328
	public static bool isMainSession = true;

	// Token: 0x04000149 RID: 329
	private static TcpClient sc;

	// Token: 0x0400014A RID: 330
	public static bool connected;

	// Token: 0x0400014B RID: 331
	public static bool connecting;

	// Token: 0x0400014C RID: 332
	private static Session_ME2.Sender sender = new Session_ME2.Sender();

	// Token: 0x0400014D RID: 333
	public static Thread initThread;

	// Token: 0x0400014E RID: 334
	public static Thread collectorThread;

	// Token: 0x0400014F RID: 335
	public static Thread sendThread;

	// Token: 0x04000150 RID: 336
	public static int sendByteCount;

	// Token: 0x04000151 RID: 337
	public static int recvByteCount;

	// Token: 0x04000152 RID: 338
	private static bool getKeyComplete;

	// Token: 0x04000153 RID: 339
	public static sbyte[] key = null;

	// Token: 0x04000154 RID: 340
	private static sbyte curR;

	// Token: 0x04000155 RID: 341
	private static sbyte curW;

	// Token: 0x04000156 RID: 342
	private static int timeConnected;

	// Token: 0x04000157 RID: 343
	private long lastTimeConn;

	// Token: 0x04000158 RID: 344
	public static string strRecvByteCount = string.Empty;

	// Token: 0x04000159 RID: 345
	public static bool isCancel;

	// Token: 0x0400015A RID: 346
	private string host;

	// Token: 0x0400015B RID: 347
	private int port;

	// Token: 0x0400015C RID: 348
	public static MyVector recieveMsg = new MyVector();

	// Token: 0x02000029 RID: 41
	public class Sender
	{
		// Token: 0x0600017E RID: 382 RVA: 0x000047E9 File Offset: 0x000029E9
		public Sender()
		{
			this.sendingMessage = new List<Message>();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000047FC File Offset: 0x000029FC
		public void AddMessage(Message message)
		{
			this.sendingMessage.Add(message);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000DD9C File Offset: 0x0000BF9C
		public void run()
		{
			while (Session_ME2.connected)
			{
				try
				{
					if (Session_ME2.getKeyComplete)
					{
						while (this.sendingMessage.Count > 0)
						{
							Message m = this.sendingMessage[0];
							Session_ME2.doSendMessage(m);
							this.sendingMessage.RemoveAt(0);
						}
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception ex)
					{
						Cout.LogError(ex.ToString());
					}
				}
				catch (Exception)
				{
					Res.outz("error send message! ");
				}
			}
		}

		// Token: 0x0400015D RID: 349
		public List<Message> sendingMessage;
	}

	// Token: 0x0200002A RID: 42
	private class MessageCollector
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000DE44 File Offset: 0x0000C044
		public void run()
		{
			try
			{
				while (Session_ME2.connected)
				{
					Message message = this.readMessage();
					if (message == null)
					{
						break;
					}
					try
					{
						if ((int)message.command == -27)
						{
							this.getKey(message);
						}
						else
						{
							Session_ME2.onRecieveMsg(message);
						}
					}
					catch (Exception)
					{
						Cout.println("LOI NHAN  MESS THU 1");
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception)
					{
						Cout.println("LOI NHAN  MESS THU 2");
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("error read message!");
				Debug.Log(ex.Message.ToString());
			}
			if (Session_ME2.connected)
			{
				if (Session_ME2.messageHandler != null)
				{
					if (Session_ME2.currentTimeMillis() - Session_ME2.timeConnected > 500)
					{
						Session_ME2.messageHandler.onDisconnected(Session_ME2.isMainSession);
					}
					else
					{
						Session_ME2.messageHandler.onConnectionFail(Session_ME2.isMainSession);
					}
				}
				if (Session_ME2.sc != null)
				{
					Session_ME2.cleanNetwork();
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000DF70 File Offset: 0x0000C170
		private void getKey(Message message)
		{
			try
			{
				sbyte b = message.reader().readSByte();
				Session_ME2.key = new sbyte[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					Session_ME2.key[i] = message.reader().readSByte();
				}
				for (int j = 0; j < Session_ME2.key.Length - 1; j++)
				{
					sbyte[] key = Session_ME2.key;
					int num = j + 1;
					key[num] = (sbyte)((int)key[num] ^ (int)Session_ME2.key[j]);
				}
				Session_ME2.getKeyComplete = true;
				GameMidlet.IP2 = message.reader().readUTF();
				GameMidlet.PORT2 = message.reader().readInt();
				GameMidlet.isConnect2 = ((int)message.reader().readByte() != 0);
				if (Session_ME2.isMainSession && GameMidlet.isConnect2)
				{
					GameCanvas.connect2();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000E068 File Offset: 0x0000C268
		private Message readMessage2(sbyte cmd)
		{
			int num = (int)Session_ME2.readKey(Session_ME2.dis.ReadSByte()) + 128;
			int num2 = (int)Session_ME2.readKey(Session_ME2.dis.ReadSByte()) + 128;
			int num3 = (int)Session_ME2.readKey(Session_ME2.dis.ReadSByte()) + 128;
			int num4 = (num3 * 256 + num2) * 256 + num;
			Cout.LogError("SIZE = " + num4);
			sbyte[] array = new sbyte[num4];
			byte[] src = Session_ME2.dis.ReadBytes(num4);
			Buffer.BlockCopy(src, 0, array, 0, num4);
			Session_ME2.recvByteCount += 5 + num4;
			int num5 = Session_ME2.recvByteCount + Session_ME2.sendByteCount;
			Session_ME2.strRecvByteCount = string.Concat(new object[]
			{
				num5 / 1024,
				".",
				num5 % 1024 / 102,
				"Kb"
			});
			if (Session_ME2.getKeyComplete)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Session_ME2.readKey(array[i]);
				}
			}
			return new Message(cmd, array);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
		private Message readMessage()
		{
			try
			{
				sbyte b = Session_ME2.dis.ReadSByte();
				if (Session_ME2.getKeyComplete)
				{
					b = Session_ME2.readKey(b);
				}
				if ((int)b == -32 || (int)b == -66 || (int)b == 11 || (int)b == -67 || (int)b == -74 || (int)b == -87)
				{
					return this.readMessage2(b);
				}
				int num;
				if (Session_ME2.getKeyComplete)
				{
					sbyte b2 = Session_ME2.dis.ReadSByte();
					sbyte b3 = Session_ME2.dis.ReadSByte();
					num = (((int)Session_ME2.readKey(b2) & 255) << 8 | ((int)Session_ME2.readKey(b3) & 255));
				}
				else
				{
					sbyte b4 = Session_ME2.dis.ReadSByte();
					sbyte b5 = Session_ME2.dis.ReadSByte();
					num = (((int)b4 & 65280) | ((int)b5 & 255));
				}
				sbyte[] array = new sbyte[num];
				byte[] src = Session_ME2.dis.ReadBytes(num);
				Buffer.BlockCopy(src, 0, array, 0, num);
				Session_ME2.recvByteCount += 5 + num;
				int num2 = Session_ME2.recvByteCount + Session_ME2.sendByteCount;
				Session_ME2.strRecvByteCount = string.Concat(new object[]
				{
					num2 / 1024,
					".",
					num2 % 1024 / 102,
					"Kb"
				});
				if (Session_ME2.getKeyComplete)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Session_ME2.readKey(array[i]);
					}
				}
				return new Message(b, array);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.StackTrace.ToString());
			}
			return null;
		}
	}
}
