using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class Session_ME : ISession
{
	// Token: 0x0600014E RID: 334 RVA: 0x000045F9 File Offset: 0x000027F9
	public Session_ME()
	{
		Debug.Log("init Session_ME");
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0000460B File Offset: 0x0000280B
	public void clearSendingMessage()
	{
		Session_ME.sender.sendingMessage.Clear();
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0000461C File Offset: 0x0000281C
	public static Session_ME gI()
	{
		if (Session_ME.instance == null)
		{
			Session_ME.instance = new Session_ME();
		}
		return Session_ME.instance;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00004637 File Offset: 0x00002837
	public bool isConnected()
	{
		return Session_ME.connected;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x0000463E File Offset: 0x0000283E
	public void setHandler(IMessageHandler msgHandler)
	{
		Session_ME.messageHandler = msgHandler;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x0000CCFC File Offset: 0x0000AEFC
	public void connect(string host, int port)
	{
		if (Session_ME.connected || Session_ME.connecting)
		{
			return;
		}
		if (Session_ME.isMainSession)
		{
			ServerListScreen.testConnect = -1;
		}
		this.host = host;
		this.port = port;
		Session_ME.getKeyComplete = false;
		Session_ME.sc = null;
		Debug.Log("connecting...!");
		Debug.Log("host: " + host);
		Debug.Log("port: " + port);
		Session_ME.initThread = new Thread(new ThreadStart(this.NetworkInit));
		Session_ME.initThread.Start();
	}

	// Token: 0x06000154 RID: 340 RVA: 0x0000CD98 File Offset: 0x0000AF98
	private void NetworkInit()
	{
		Session_ME.isCancel = false;
		Session_ME.connecting = true;
		Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
		Session_ME.connected = true;
		try
		{
			this.doConnect(this.host, this.port);
			Session_ME.messageHandler.onConnectOK(Session_ME.isMainSession);
		}
		catch (Exception)
		{
			if (Session_ME.messageHandler != null)
			{
				this.close();
				Session_ME.messageHandler.onConnectionFail(Session_ME.isMainSession);
			}
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x0000CE20 File Offset: 0x0000B020
	public void doConnect(string host, int port)
	{
		Session_ME.sc = new TcpClient();
		Session_ME.sc.Connect(host, port);
		Session_ME.dataStream = Session_ME.sc.GetStream();
		Session_ME.dis = new BinaryReader(Session_ME.dataStream, new UTF8Encoding());
		Session_ME.dos = new BinaryWriter(Session_ME.dataStream, new UTF8Encoding());
		new Thread(new ThreadStart(Session_ME.sender.run)).Start();
		Session_ME.MessageCollector @object = new Session_ME.MessageCollector();
		Cout.LogError("new -----");
		Session_ME.collectorThread = new Thread(new ThreadStart(@object.run));
		Session_ME.collectorThread.Start();
		Session_ME.timeConnected = Session_ME.currentTimeMillis();
		Session_ME.connecting = false;
		Session_ME.doSendMessage(new Message(-27));
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00004646 File Offset: 0x00002846
	public void sendMessage(Message message)
	{
		Session_ME.count++;
		Res.outz("SEND MSG: " + message.command);
		Session_ME.sender.AddMessage(message);
	}

	// Token: 0x06000157 RID: 343 RVA: 0x0000CEE0 File Offset: 0x0000B0E0
	private static void doSendMessage(Message m)
	{
		sbyte[] data = m.getData();
		try
		{
			if (Session_ME.getKeyComplete)
			{
				sbyte value = Session_ME.writeKey(m.command);
				Session_ME.dos.Write(value);
			}
			else
			{
				Session_ME.dos.Write(m.command);
			}
			if (data != null)
			{
				int num = data.Length;
				if (Session_ME.getKeyComplete)
				{
					int num2 = (int)Session_ME.writeKey((sbyte)(num >> 8));
					Session_ME.dos.Write((sbyte)num2);
					int num3 = (int)Session_ME.writeKey((sbyte)(num & 255));
					Session_ME.dos.Write((sbyte)num3);
				}
				else
				{
					Session_ME.dos.Write((ushort)num);
				}
				if (Session_ME.getKeyComplete)
				{
					for (int i = 0; i < data.Length; i++)
					{
						sbyte value2 = Session_ME.writeKey(data[i]);
						Session_ME.dos.Write(value2);
					}
				}
				Session_ME.sendByteCount += 5 + data.Length;
			}
			else
			{
				if (Session_ME.getKeyComplete)
				{
					int num4 = 0;
					int num5 = (int)Session_ME.writeKey((sbyte)(num4 >> 8));
					Session_ME.dos.Write((sbyte)num5);
					int num6 = (int)Session_ME.writeKey((sbyte)(num4 & 255));
					Session_ME.dos.Write((sbyte)num6);
				}
				else
				{
					Session_ME.dos.Write(0);
				}
				Session_ME.sendByteCount += 5;
			}
			Session_ME.dos.Flush();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000D070 File Offset: 0x0000B270
	public static sbyte readKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curR;
		Session_ME.curR = (sbyte)((int)b2 + 1);
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME.curR >= Session_ME.key.Length)
		{
			Session_ME.curR = (sbyte)((int)Session_ME.curR % (int)((sbyte)Session_ME.key.Length));
		}
		return result;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000D0D0 File Offset: 0x0000B2D0
	public static sbyte writeKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curW;
		Session_ME.curW = (sbyte)((int)b2 + 1);
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME.curW >= Session_ME.key.Length)
		{
			Session_ME.curW = (sbyte)((int)Session_ME.curW % (int)((sbyte)Session_ME.key.Length));
		}
		return result;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00004679 File Offset: 0x00002879
	public static void onRecieveMsg(Message msg)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			Session_ME.messageHandler.onMessage(msg);
		}
		else
		{
			Session_ME.recieveMsg.addElement(msg);
		}
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000D130 File Offset: 0x0000B330
	public static void update()
	{
		while (Session_ME.recieveMsg.size() > 0)
		{
			Message message = (Message)Session_ME.recieveMsg.elementAt(0);
			if (Controller.isStopReadMessage)
			{
				return;
			}
			if (message == null)
			{
				Session_ME.recieveMsg.removeElementAt(0);
				return;
			}
			Session_ME.messageHandler.onMessage(message);
			Session_ME.recieveMsg.removeElementAt(0);
		}
	}

	// Token: 0x0600015C RID: 348 RVA: 0x000046AF File Offset: 0x000028AF
	public void close()
	{
		Session_ME.cleanNetwork();
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000D198 File Offset: 0x0000B398
	private static void cleanNetwork()
	{
		Session_ME.key = null;
		Session_ME.curR = 0;
		Session_ME.curW = 0;
		try
		{
			Session_ME.connected = false;
			Session_ME.connecting = false;
			if (Session_ME.sc != null)
			{
				Session_ME.sc.Close();
				Session_ME.sc = null;
			}
			if (Session_ME.dataStream != null)
			{
				Session_ME.dataStream.Close();
				Session_ME.dataStream = null;
			}
			if (Session_ME.dos != null)
			{
				Session_ME.dos.Close();
				Session_ME.dos = null;
			}
			if (Session_ME.dis != null)
			{
				Session_ME.dis.Close();
				Session_ME.dis = null;
			}
			Session_ME.sendThread = null;
			Session_ME.collectorThread = null;
			if (Session_ME.isMainSession)
			{
				ServerListScreen.testConnect = 0;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x000046B6 File Offset: 0x000028B6
	public static int currentTimeMillis()
	{
		return Environment.TickCount;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00003B40 File Offset: 0x00001D40
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00008494 File Offset: 0x00006694
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

	// Token: 0x04000127 RID: 295
	protected static Session_ME instance = new Session_ME();

	// Token: 0x04000128 RID: 296
	private static NetworkStream dataStream;

	// Token: 0x04000129 RID: 297
	private static BinaryReader dis;

	// Token: 0x0400012A RID: 298
	private static BinaryWriter dos;

	// Token: 0x0400012B RID: 299
	public static IMessageHandler messageHandler;

	// Token: 0x0400012C RID: 300
	public static bool isMainSession = true;

	// Token: 0x0400012D RID: 301
	private static TcpClient sc;

	// Token: 0x0400012E RID: 302
	public static bool connected;

	// Token: 0x0400012F RID: 303
	public static bool connecting;

	// Token: 0x04000130 RID: 304
	private static Session_ME.Sender sender = new Session_ME.Sender();

	// Token: 0x04000131 RID: 305
	public static Thread initThread;

	// Token: 0x04000132 RID: 306
	public static Thread collectorThread;

	// Token: 0x04000133 RID: 307
	public static Thread sendThread;

	// Token: 0x04000134 RID: 308
	public static int sendByteCount;

	// Token: 0x04000135 RID: 309
	public static int recvByteCount;

	// Token: 0x04000136 RID: 310
	private static bool getKeyComplete;

	// Token: 0x04000137 RID: 311
	public static sbyte[] key = null;

	// Token: 0x04000138 RID: 312
	private static sbyte curR;

	// Token: 0x04000139 RID: 313
	private static sbyte curW;

	// Token: 0x0400013A RID: 314
	private static int timeConnected;

	// Token: 0x0400013B RID: 315
	private long lastTimeConn;

	// Token: 0x0400013C RID: 316
	public static string strRecvByteCount = string.Empty;

	// Token: 0x0400013D RID: 317
	public static bool isCancel;

	// Token: 0x0400013E RID: 318
	private string host;

	// Token: 0x0400013F RID: 319
	private int port;

	// Token: 0x04000140 RID: 320
	public static int count;

	// Token: 0x04000141 RID: 321
	public static MyVector recieveMsg = new MyVector();

	// Token: 0x02000026 RID: 38
	public class Sender
	{
		// Token: 0x06000162 RID: 354 RVA: 0x000046F3 File Offset: 0x000028F3
		public Sender()
		{
			this.sendingMessage = new List<Message>();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004706 File Offset: 0x00002906
		public void AddMessage(Message message)
		{
			this.sendingMessage.Add(message);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000D264 File Offset: 0x0000B464
		public void run()
		{
			while (Session_ME.connected)
			{
				try
				{
					if (Session_ME.getKeyComplete)
					{
						while (this.sendingMessage.Count > 0)
						{
							Message m = this.sendingMessage[0];
							Session_ME.doSendMessage(m);
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

		// Token: 0x04000142 RID: 322
		public List<Message> sendingMessage;
	}

	// Token: 0x02000027 RID: 39
	private class MessageCollector
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0000D30C File Offset: 0x0000B50C
		public void run()
		{
			try
			{
				while (Session_ME.connected)
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
							Session_ME.onRecieveMsg(message);
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
			if (Session_ME.connected)
			{
				if (Session_ME.messageHandler != null)
				{
					if (Session_ME.currentTimeMillis() - Session_ME.timeConnected > 500)
					{
						Session_ME.messageHandler.onDisconnected(Session_ME.isMainSession);
					}
					else
					{
						Session_ME.messageHandler.onConnectionFail(Session_ME.isMainSession);
					}
				}
				if (Session_ME.sc != null)
				{
					Session_ME.cleanNetwork();
				}
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000D438 File Offset: 0x0000B638
		private void getKey(Message message)
		{
			try
			{
				sbyte b = message.reader().readSByte();
				Session_ME.key = new sbyte[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					Session_ME.key[i] = message.reader().readSByte();
				}
				for (int j = 0; j < Session_ME.key.Length - 1; j++)
				{
					sbyte[] key = Session_ME.key;
					int num = j + 1;
					key[num] = (sbyte)((int)key[num] ^ (int)Session_ME.key[j]);
				}
				Session_ME.getKeyComplete = true;
				GameMidlet.IP2 = message.reader().readUTF();
				GameMidlet.PORT2 = message.reader().readInt();
				GameMidlet.isConnect2 = ((int)message.reader().readByte() != 0);
				if (Session_ME.isMainSession && GameMidlet.isConnect2)
				{
					GameCanvas.connect2();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000D530 File Offset: 0x0000B730
		private Message readMessage2(sbyte cmd)
		{
			int num = (int)Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128;
			int num2 = (int)Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128;
			int num3 = (int)Session_ME.readKey(Session_ME.dis.ReadSByte()) + 128;
			int num4 = (num3 * 256 + num2) * 256 + num;
			Cout.LogError("SIZE = " + num4);
			sbyte[] array = new sbyte[num4];
			byte[] src = Session_ME.dis.ReadBytes(num4);
			Buffer.BlockCopy(src, 0, array, 0, num4);
			Session_ME.recvByteCount += 5 + num4;
			int num5 = Session_ME.recvByteCount + Session_ME.sendByteCount;
			Session_ME.strRecvByteCount = string.Concat(new object[]
			{
				num5 / 1024,
				".",
				num5 % 1024 / 102,
				"Kb"
			});
			if (Session_ME.getKeyComplete)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Session_ME.readKey(array[i]);
				}
			}
			return new Message(cmd, array);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000D66C File Offset: 0x0000B86C
		private Message readMessage()
		{
			try
			{
				sbyte b = Session_ME.dis.ReadSByte();
				if (Session_ME.getKeyComplete)
				{
					b = Session_ME.readKey(b);
				}
				if ((int)b == -32 || (int)b == -66 || (int)b == 11 || (int)b == -67 || (int)b == -74 || (int)b == -87 || (int)b == 66)
				{
					return this.readMessage2(b);
				}
				int num;
				if (Session_ME.getKeyComplete)
				{
					sbyte b2 = Session_ME.dis.ReadSByte();
					sbyte b3 = Session_ME.dis.ReadSByte();
					num = (((int)Session_ME.readKey(b2) & 255) << 8 | ((int)Session_ME.readKey(b3) & 255));
				}
				else
				{
					sbyte b4 = Session_ME.dis.ReadSByte();
					sbyte b5 = Session_ME.dis.ReadSByte();
					num = (((int)b4 & 65280) | ((int)b5 & 255));
				}
				sbyte[] array = new sbyte[num];
				byte[] src = Session_ME.dis.ReadBytes(num);
				Buffer.BlockCopy(src, 0, array, 0, num);
				Session_ME.recvByteCount += 5 + num;
				int num2 = Session_ME.recvByteCount + Session_ME.sendByteCount;
				Session_ME.strRecvByteCount = string.Concat(new object[]
				{
					num2 / 1024,
					".",
					num2 % 1024 / 102,
					"Kb"
				});
				if (Session_ME.getKeyComplete)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Session_ME.readKey(array[i]);
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
