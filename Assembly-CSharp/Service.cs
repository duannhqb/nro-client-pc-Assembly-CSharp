using System;
using Assets.src.g;

// Token: 0x02000096 RID: 150
public class Service
{
	// Token: 0x0600048B RID: 1163 RVA: 0x000060AA File Offset: 0x000042AA
	public static Service gI()
	{
		if (Service.instance == null)
		{
			Service.instance = new Service();
		}
		return Service.instance;
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0003C8B4 File Offset: 0x0003AAB4
	public void gotoPlayer(int id)
	{
		Message message = null;
		try
		{
			message = new Message(18);
			message.writer().writeInt(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0003C920 File Offset: 0x0003AB20
	public void androidPack()
	{
		if (mSystem.android_pack == null)
		{
			return;
		}
		Message message = null;
		try
		{
			message = new Message(126);
			message.writer().writeUTF(mSystem.android_pack);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0003C998 File Offset: 0x0003AB98
	public void charInfo(string day, string month, string year, string address, string cmnd, string dayCmnd, string noiCapCmnd, string sdt, string name)
	{
		Message message = null;
		try
		{
			message = new Message(42);
			message.writer().writeUTF(day);
			message.writer().writeUTF(month);
			message.writer().writeUTF(year);
			message.writer().writeUTF(address);
			message.writer().writeUTF(cmnd);
			message.writer().writeUTF(dayCmnd);
			message.writer().writeUTF(noiCapCmnd);
			message.writer().writeUTF(sdt);
			message.writer().writeUTF(name);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0003CA68 File Offset: 0x0003AC68
	public void androidPack2()
	{
		if (mSystem.android_pack == null)
		{
			return;
		}
		Message message = null;
		try
		{
			message = new Message(126);
			message.writer().writeUTF(mSystem.android_pack);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0003CB20 File Offset: 0x0003AD20
	public void checkAd(sbyte status)
	{
		Message message = null;
		try
		{
			message = new Message(-44);
			message.writer().writeByte(status);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0003CB8C File Offset: 0x0003AD8C
	public void combine(sbyte action, MyVector id)
	{
		Res.outz("combine");
		Message message = null;
		try
		{
			message = new Message(-81);
			message.writer().writeByte(action);
			if ((int)action == 1)
			{
				message.writer().writeByte(id.size());
				for (int i = 0; i < id.size(); i++)
				{
					message.writer().writeByte(((Item)id.elementAt(i)).indexUI);
					Res.outz("gui id " + ((Item)id.elementAt(i)).indexUI);
				}
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0003CC64 File Offset: 0x0003AE64
	public void giaodich(sbyte action, int playerID, sbyte index, int num)
	{
		Res.outz2("giao dich action = " + action);
		Message message = null;
		try
		{
			message = new Message(-86);
			message.writer().writeByte(action);
			if ((int)action == 0 || (int)action == 1)
			{
				Res.outz2(">>>> len playerID =" + playerID);
				message.writer().writeInt(playerID);
			}
			if ((int)action == 2)
			{
				Res.outz2(string.Concat(new object[]
				{
					"gui len index =",
					index,
					" num= ",
					num
				}));
				message.writer().writeByte(index);
				message.writer().writeInt(num);
			}
			if ((int)action == 4)
			{
				Res.outz2(">>>> len index =" + index);
				message.writer().writeByte(index);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0003CD84 File Offset: 0x0003AF84
	public void sendClientInput(TField[] t)
	{
		Message message = null;
		try
		{
			Res.outz(" gui input ");
			message = new Message(-125);
			Res.outz("byte lent = " + t.Length);
			message.writer().writeByte(t.Length);
			for (int i = 0; i < t.Length; i++)
			{
				message.writer().writeUTF(t[i].getText());
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0003CE2C File Offset: 0x0003B02C
	public void speacialSkill(sbyte index)
	{
		Message message = null;
		try
		{
			message = new Message(112);
			message.writer().writeByte(index);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0003CE98 File Offset: 0x0003B098
	public void test(short x, short y)
	{
		Res.outz(string.Concat(new object[]
		{
			"gui x= ",
			x,
			" y= ",
			y
		}));
		Message message = null;
		try
		{
			message = new Message(0);
			message.writer().writeShort(x);
			message.writer().writeShort(y);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0003CF40 File Offset: 0x0003B140
	public void test2()
	{
		Res.outz("gui test1");
		Message message = null;
		try
		{
			message = new Message(1);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x00003984 File Offset: 0x00001B84
	public void testJoint()
	{
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0003CFA8 File Offset: 0x0003B1A8
	public void mobCapcha(char ch)
	{
		Res.outz("cap char c= " + ch);
		Message message = null;
		try
		{
			message = new Message(-85);
			message.writer().writeChar(ch);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0003D01C File Offset: 0x0003B21C
	public void friend(sbyte action, int playerId)
	{
		Res.outz("add friend");
		Message message = null;
		try
		{
			message = new Message(-80);
			message.writer().writeByte(action);
			if (playerId != -1)
			{
				message.writer().writeInt(playerId);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0003D0AC File Offset: 0x0003B2AC
	public void getArchivemnt(int index)
	{
		Res.outz("get ngoc");
		Message message = null;
		try
		{
			message = new Message(-76);
			message.writer().writeByte(index);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x0003D12C File Offset: 0x0003B32C
	public void getPlayerMenu(int playerID)
	{
		Message message = null;
		try
		{
			message = new Message(-79);
			message.writer().writeInt(playerID);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0003D18C File Offset: 0x0003B38C
	public void clanImage(sbyte id)
	{
		Message message = null;
		try
		{
			message = new Message(-62);
			message.writer().writeByte(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x0003D200 File Offset: 0x0003B400
	public void skill_not_focus(sbyte status)
	{
		Message message = null;
		try
		{
			message = new Message(-45);
			message.writer().writeByte(status);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x0003D274 File Offset: 0x0003B474
	public void clanDonate(int id)
	{
		Message message = null;
		try
		{
			message = new Message(-54);
			message.writer().writeInt(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x0003D2E8 File Offset: 0x0003B4E8
	public void clanMessage(int type, string text, int clanID)
	{
		Message message = null;
		try
		{
			message = new Message(-51);
			message.writer().writeByte(type);
			if (type == 0)
			{
				message.writer().writeUTF(text);
			}
			if (type == 2)
			{
				message.writer().writeInt(clanID);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x0003D380 File Offset: 0x0003B580
	public void useItem(sbyte type, sbyte where, sbyte index, short template)
	{
		Cout.println("USE ITEM! " + type);
		if (global::Char.myCharz().statusMe == 14)
		{
			return;
		}
		Message message = null;
		try
		{
			message = new Message(-43);
			message.writer().writeByte(type);
			message.writer().writeByte(where);
			message.writer().writeByte(index);
			if ((int)index == -1)
			{
				message.writer().writeShort(template);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x0003D434 File Offset: 0x0003B634
	public void joinClan(int id, sbyte action)
	{
		Message message = null;
		try
		{
			message = new Message(-49);
			message.writer().writeInt(id);
			message.writer().writeByte(action);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x0003D4B4 File Offset: 0x0003B6B4
	public void clanMember(int id)
	{
		Message message = null;
		try
		{
			message = new Message(-50);
			message.writer().writeInt(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0003D528 File Offset: 0x0003B728
	public void searchClan(string text)
	{
		Message message = null;
		try
		{
			message = new Message(-47);
			message.writer().writeUTF(text);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0003D59C File Offset: 0x0003B79C
	public void requestClan(short id)
	{
		Message message = null;
		try
		{
			message = new Message(-53);
			message.writer().writeShort(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0003D610 File Offset: 0x0003B810
	public void clanRemote(int id, sbyte role)
	{
		Message message = null;
		try
		{
			message = new Message(-56);
			message.writer().writeInt(id);
			message.writer().writeByte(role);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0003D690 File Offset: 0x0003B890
	public void leaveClan()
	{
		Message message = null;
		try
		{
			message = new Message(-55);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0003D6F8 File Offset: 0x0003B8F8
	public void clanInvite(sbyte action, int playerID, int clanID, int code)
	{
		Message message = null;
		try
		{
			message = new Message(-57);
			message.writer().writeByte(action);
			if ((int)action == 0)
			{
				message.writer().writeInt(playerID);
			}
			if ((int)action == 1 || (int)action == 2)
			{
				message.writer().writeInt(clanID);
				message.writer().writeInt(code);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0003D7A8 File Offset: 0x0003B9A8
	public void getClan(sbyte action, sbyte id, string text)
	{
		Message message = null;
		try
		{
			message = new Message(-46);
			message.writer().writeByte(action);
			if ((int)action == 2 || (int)action == 4)
			{
				message.writer().writeByte(id);
				message.writer().writeUTF(text);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0003D844 File Offset: 0x0003BA44
	public void updateCaption(sbyte gender)
	{
		Message message = null;
		try
		{
			message = new Message(-41);
			message.writer().writeByte(gender);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x0003D8B8 File Offset: 0x0003BAB8
	public void getItem(sbyte type, sbyte id)
	{
		Message message = null;
		try
		{
			message = new Message(-40);
			message.writer().writeByte(type);
			message.writer().writeByte(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0003D938 File Offset: 0x0003BB38
	public void getTask(int npcTemplateId, int menuId, int optionId)
	{
		Message message = null;
		try
		{
			message = new Message(40);
			message.writer().writeByte(npcTemplateId);
			message.writer().writeByte(menuId);
			if (optionId >= 0)
			{
				message.writer().writeByte(optionId);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0003D9CC File Offset: 0x0003BBCC
	public Message messageNotLogin(sbyte command)
	{
		Message message = new Message(-29);
		message.writer().writeByte(command);
		return message;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0003D9F0 File Offset: 0x0003BBF0
	public Message messageNotMap(sbyte command)
	{
		Message message = new Message(-28);
		message.writer().writeByte(command);
		return message;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0003DA14 File Offset: 0x0003BC14
	public static Message messageSubCommand(sbyte command)
	{
		Message message = new Message(-30);
		message.writer().writeByte(command);
		return message;
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0003DA38 File Offset: 0x0003BC38
	public void setClientType()
	{
		if (Rms.loadRMSInt("clienttype") != -1)
		{
			Main.typeClient = Rms.loadRMSInt("clienttype");
		}
		try
		{
			Message message = this.messageNotLogin(2);
			message.writer().writeByte(Main.typeClient);
			message.writer().writeByte(mGraphics.zoomLevel);
			message.writer().writeBoolean(false);
			message.writer().writeInt(GameCanvas.w);
			message.writer().writeInt(GameCanvas.h);
			message.writer().writeBoolean(TField.isQwerty);
			message.writer().writeBoolean(GameCanvas.isTouch);
			message.writer().writeUTF(GameCanvas.getPlatformName() + "|" + GameMidlet.VERSION);
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x0003DB3C File Offset: 0x0003BD3C
	public void setClientType2()
	{
		Res.outz("SET CLIENT TYPE");
		if (Rms.loadRMSInt("clienttype") != -1)
		{
			mSystem.clientType = Rms.loadRMSInt("clienttype");
		}
		try
		{
			Res.outz("setType");
			Message message = this.messageNotLogin(2);
			message.writer().writeByte(mSystem.clientType);
			message.writer().writeByte(mGraphics.zoomLevel);
			Res.outz("gui zoomlevel = " + mGraphics.zoomLevel);
			message.writer().writeBoolean(false);
			message.writer().writeInt(GameCanvas.w);
			message.writer().writeInt(GameCanvas.h);
			message.writer().writeBoolean(TField.isQwerty);
			message.writer().writeBoolean(GameCanvas.isTouch);
			message.writer().writeUTF(GameCanvas.getPlatformName() + "|" + GameMidlet.VERSION);
			this.session = Session_ME2.gI();
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
			message.cleanup();
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x0003DC78 File Offset: 0x0003BE78
	public void sendCheckController()
	{
		Message message = null;
		try
		{
			message = new Message(-120);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			Service.curCheckController = mSystem.currentTimeMillis();
			message.cleanup();
		}
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x0003DCD4 File Offset: 0x0003BED4
	public void sendCheckMap()
	{
		Message message = null;
		try
		{
			message = new Message(-121);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			Service.curCheckMap = mSystem.currentTimeMillis();
			message.cleanup();
		}
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0003DD30 File Offset: 0x0003BF30
	public void login(string username, string pass, string version, sbyte type)
	{
		try
		{
			Message message = this.messageNotLogin(0);
			message.writer().writeUTF(username);
			message.writer().writeUTF(pass);
			message.writer().writeUTF(version);
			message.writer().writeByte(type);
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x0003DDBC File Offset: 0x0003BFBC
	public void requestRegister(string username, string pass, string usernameAo, string passAo, string version)
	{
		try
		{
			Message message = this.messageNotLogin(1);
			message.writer().writeUTF(username);
			message.writer().writeUTF(pass);
			if (usernameAo != null && !usernameAo.Equals(string.Empty))
			{
				message.writer().writeUTF(usernameAo);
				message.writer().writeUTF("a");
			}
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x0003DE60 File Offset: 0x0003C060
	public void requestChangeMap()
	{
		Message message = new Message(-23);
		this.session.sendMessage(message);
		message.cleanup();
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x0003DE88 File Offset: 0x0003C088
	public void magicTree(sbyte type)
	{
		Message message = new Message(-34);
		try
		{
			message.writer().writeByte(type);
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x0003DED8 File Offset: 0x0003C0D8
	public void requestChangeZone(int zoneId, int indexUI)
	{
		Message message = new Message(21);
		try
		{
			message.writer().writeByte(zoneId);
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0003DF28 File Offset: 0x0003C128
	public void checkMMove(int second)
	{
		Message message = new Message(-78);
		try
		{
			message.writer().writeInt(second);
			this.session.sendMessage(message);
			message.cleanup();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0003DF78 File Offset: 0x0003C178
	public void charMove()
	{
		int num = global::Char.myCharz().cx - global::Char.myCharz().cxSend;
		int num2 = global::Char.myCharz().cy - global::Char.myCharz().cySend;
		if (global::Char.ischangingMap || (num == 0 && num2 == 0) || Controller.isStopReadMessage || global::Char.myCharz().isTeleport || global::Char.myCharz().cy <= 0 || global::Char.myCharz().telePortSkill)
		{
			return;
		}
		try
		{
			Message message = new Message(-7);
			global::Char.myCharz().cxSend = global::Char.myCharz().cx;
			global::Char.myCharz().cySend = global::Char.myCharz().cy;
			global::Char.myCharz().cdirSend = global::Char.myCharz().cdir;
			global::Char.myCharz().cactFirst = global::Char.myCharz().statusMe;
			if (TileMap.tileTypeAt(global::Char.myCharz().cx / (int)TileMap.size, global::Char.myCharz().cy / (int)TileMap.size) == 0)
			{
				message.writer().writeByte(1);
				if (global::Char.myCharz().canFly)
				{
					if (!global::Char.myCharz().isHaveMount)
					{
						global::Char.myCharz().cMP -= global::Char.myCharz().cMPGoc / 100 * (((int)global::Char.myCharz().isMonkey != 1) ? 1 : 2);
					}
					if (global::Char.myCharz().cMP < 0)
					{
						global::Char.myCharz().cMP = 0;
					}
					GameScr.gI().isInjureMp = true;
					GameScr.gI().twMp = 0;
				}
			}
			else
			{
				message.writer().writeByte(0);
			}
			message.writer().writeShort(global::Char.myCharz().cx);
			if (num2 != 0)
			{
				message.writer().writeShort(global::Char.myCharz().cy);
			}
			this.session.sendMessage(message);
			GameScr.tickMove++;
			message.cleanup();
		}
		catch (Exception ex)
		{
			Cout.LogError("LOI CHAR MOVE " + ex.ToString());
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0003E1B4 File Offset: 0x0003C3B4
	public void selectCharToPlay(string charname)
	{
		Message message = new Message(-28);
		try
		{
			message.writer().writeByte(1);
			message.writer().writeUTF(charname);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		this.session.sendMessage(message);
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x00003984 File Offset: 0x00001B84
	public void selectZone(sbyte sub, int value)
	{
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0003E220 File Offset: 0x0003C420
	public void createChar(string name, int gender, int hair)
	{
		Message message = new Message(-28);
		try
		{
			message.writer().writeByte(2);
			message.writer().writeUTF(name);
			message.writer().writeByte(gender);
			message.writer().writeByte(hair);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		this.session.sendMessage(message);
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0003E2A4 File Offset: 0x0003C4A4
	public void requestModTemplate(int modTemplateId)
	{
		Message message = null;
		try
		{
			message = new Message(11);
			message.writer().writeByte(modTemplateId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x0003E318 File Offset: 0x0003C518
	public void requestNpcTemplate(int npcTemplateId)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(12);
			message.writer().writeByte(npcTemplateId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0003E38C File Offset: 0x0003C58C
	public void requestSkill(int skillId)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(9);
			message.writer().writeShort(skillId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x0003E400 File Offset: 0x0003C600
	public void requestItemInfo(int typeUI, int indexUI)
	{
		Message message = null;
		try
		{
			message = new Message(35);
			message.writer().writeByte(typeUI);
			message.writer().writeByte(indexUI);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x0003E480 File Offset: 0x0003C680
	public void requestItemPlayer(int charId, int indexUI)
	{
		Message message = null;
		try
		{
			message = new Message(90);
			message.writer().writeInt(charId);
			message.writer().writeByte(indexUI);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x0003E500 File Offset: 0x0003C700
	public void upSkill(int skillTemplateId, int point)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(17);
			message.writer().writeShort(skillTemplateId);
			message.writer().writeByte(point);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0003E580 File Offset: 0x0003C780
	public void saleItem(sbyte action, sbyte type, short id)
	{
		Message message = null;
		try
		{
			message = new Message(7);
			message.writer().writeByte(action);
			message.writer().writeByte(type);
			message.writer().writeShort(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0003E60C File Offset: 0x0003C80C
	public void buyItem(sbyte type, int id, int quantity)
	{
		Message message = null;
		try
		{
			message = new Message(6);
			message.writer().writeByte(type);
			message.writer().writeShort(id);
			if (quantity > 1)
			{
				message.writer().writeShort(quantity);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x0003E6A0 File Offset: 0x0003C8A0
	public void selectSkill(int skillTemplateId)
	{
		Cout.println(global::Char.myCharz().cName + " SELECT SKILL " + skillTemplateId);
		Message message = null;
		try
		{
			message = new Message(34);
			message.writer().writeShort(skillTemplateId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0003E734 File Offset: 0x0003C934
	public void getEffData(short id)
	{
		Message message = null;
		try
		{
			message = new Message(-66);
			message.writer().writeShort(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x0003E7A8 File Offset: 0x0003C9A8
	public void openUIZone()
	{
		Message message = null;
		try
		{
			message = new Message(29);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x0003E810 File Offset: 0x0003CA10
	public void confirmMenu(short npcID, sbyte select)
	{
		Res.outz("confirme menu" + select);
		Message message = null;
		try
		{
			message = new Message(32);
			message.writer().writeShort(npcID);
			message.writer().writeByte(select);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x0003E8A4 File Offset: 0x0003CAA4
	public void openMenu(int npcId)
	{
		Message message = null;
		try
		{
			message = new Message(33);
			message.writer().writeShort(npcId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x0003E918 File Offset: 0x0003CB18
	public void menu(int npcId, int menuId, int optionId)
	{
		Cout.println("menuid: " + menuId);
		Message message = null;
		try
		{
			message = new Message(22);
			message.writer().writeByte(npcId);
			message.writer().writeByte(menuId);
			message.writer().writeByte(optionId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0003E9B8 File Offset: 0x0003CBB8
	public void menuId(short menuId)
	{
		Message message = null;
		try
		{
			message = new Message(27);
			message.writer().writeShort(menuId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x0003EA2C File Offset: 0x0003CC2C
	public void textBoxId(short menuId, string str)
	{
		Message message = null;
		try
		{
			message = new Message(88);
			message.writer().writeShort(menuId);
			message.writer().writeUTF(str);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x0003EAAC File Offset: 0x0003CCAC
	public void requestItem(int typeUI)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(22);
			message.writer().writeByte(typeUI);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0003EB20 File Offset: 0x0003CD20
	public void boxSort()
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(19);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0003EB88 File Offset: 0x0003CD88
	public void boxCoinIn(int coinIn)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(20);
			message.writer().writeInt(coinIn);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x0003EBFC File Offset: 0x0003CDFC
	public void boxCoinOut(int coinOut)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(21);
			message.writer().writeInt(coinOut);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x0003EC70 File Offset: 0x0003CE70
	public void upgradeItem(Item item, Item[] items, bool isGold)
	{
		GameCanvas.msgdlg.pleasewait();
		Message message = null;
		try
		{
			message = new Message(14);
			message.writer().writeBoolean(isGold);
			message.writer().writeByte(item.indexUI);
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
				{
					message.writer().writeByte(items[i].indexUI);
				}
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x0003ED30 File Offset: 0x0003CF30
	public void crystalCollectLock(Item[] items)
	{
		GameCanvas.msgdlg.pleasewait();
		Message message = null;
		try
		{
			message = new Message(13);
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
				{
					message.writer().writeByte(items[i].indexUI);
				}
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x0003EDD0 File Offset: 0x0003CFD0
	public void acceptInviteTrade(int playerMapId)
	{
		Message message = null;
		try
		{
			message = new Message(37);
			message.writer().writeInt(playerMapId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x0003EE44 File Offset: 0x0003D044
	public void cancelInviteTrade()
	{
		Message message = null;
		try
		{
			message = new Message(50);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0003EEAC File Offset: 0x0003D0AC
	public void tradeAccept()
	{
		Message message = null;
		try
		{
			message = new Message(39);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0003EF14 File Offset: 0x0003D114
	public void tradeItemLock(int coin, Item[] items)
	{
		Message message = null;
		try
		{
			message = new Message(38);
			message.writer().writeInt(coin);
			int num = 0;
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
				{
					num++;
				}
			}
			message.writer().writeByte(num);
			for (int j = 0; j < items.Length; j++)
			{
				if (items[j] != null)
				{
					message.writer().writeByte(items[j].indexUI);
				}
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0003EFE8 File Offset: 0x0003D1E8
	public void sendPlayerAttack(MyVector vMob, MyVector vChar, int type)
	{
		try
		{
			Message message = null;
			if (type != 0)
			{
				if (vMob.size() > 0 && vChar.size() > 0)
				{
					if (type == 1)
					{
						message = new Message(-4);
					}
					else if (type == 2)
					{
						message = new Message(67);
					}
					message.writer().writeByte(vMob.size());
					for (int i = 0; i < vMob.size(); i++)
					{
						Mob mob = (Mob)vMob.elementAt(i);
						message.writer().writeByte(mob.mobId);
					}
					for (int j = 0; j < vChar.size(); j++)
					{
						global::Char @char = (global::Char)vChar.elementAt(j);
						if (@char != null)
						{
							message.writer().writeInt(@char.charID);
						}
						else
						{
							message.writer().writeInt(-1);
						}
					}
				}
				else if (vMob.size() > 0)
				{
					message = new Message(54);
					for (int k = 0; k < vMob.size(); k++)
					{
						Mob mob2 = (Mob)vMob.elementAt(k);
						if (!mob2.isMobMe)
						{
							message.writer().writeByte(mob2.mobId);
						}
						else
						{
							message.writer().writeByte(-1);
							message.writer().writeInt(mob2.mobId);
						}
					}
				}
				else if (vChar.size() > 0)
				{
					message = new Message(-60);
					for (int l = 0; l < vChar.size(); l++)
					{
						global::Char char2 = (global::Char)vChar.elementAt(l);
						message.writer().writeInt(char2.charID);
					}
				}
				if (message != null)
				{
					this.session.sendMessage(message);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x0003F1EC File Offset: 0x0003D3EC
	public void pickItem(int itemMapId)
	{
		Message message = null;
		try
		{
			message = new Message(-20);
			message.writer().writeShort(itemMapId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x0003F260 File Offset: 0x0003D460
	public void throwItem(int index)
	{
		Message message = null;
		try
		{
			message = new Message(-18);
			message.writer().writeByte(index);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x0003F2D4 File Offset: 0x0003D4D4
	public void returnTownFromDead()
	{
		Message message = null;
		try
		{
			message = new Message(-15);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x0003F33C File Offset: 0x0003D53C
	public void wakeUpFromDead()
	{
		Message message = null;
		try
		{
			message = new Message(-16);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x0003F3A4 File Offset: 0x0003D5A4
	public void chat(string text)
	{
		Message message = null;
		try
		{
			message = new Message(44);
			message.writer().writeUTF(text);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x0003F418 File Offset: 0x0003D618
	public void updateData()
	{
		Message message = null;
		try
		{
			message = new Message(-87);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x0003F4C0 File Offset: 0x0003D6C0
	public void updateMap()
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(6);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x0003F568 File Offset: 0x0003D768
	public void updateSkill()
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(7);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x0003F604 File Offset: 0x0003D804
	public void updateItem()
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(8);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x0003F6A0 File Offset: 0x0003D8A0
	public void clientOk()
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(13);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x0003F708 File Offset: 0x0003D908
	public void tradeInvite(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(36);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x0003F77C File Offset: 0x0003D97C
	public void addFriend(string name)
	{
		Message message = null;
		try
		{
			message = new Message(53);
			message.writer().writeUTF(name);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x0003F7F0 File Offset: 0x0003D9F0
	public void addPartyAccept(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(76);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x0003F864 File Offset: 0x0003DA64
	public void addPartyCancel(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(77);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x0003F8D8 File Offset: 0x0003DAD8
	public void testInvite(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(59);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x0003F94C File Offset: 0x0003DB4C
	public void addCuuSat(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(62);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x0003F9C0 File Offset: 0x0003DBC0
	public void addParty(string name)
	{
		Message message = null;
		try
		{
			message = new Message(75);
			message.writer().writeUTF(name);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x0003FA34 File Offset: 0x0003DC34
	public void player_vs_player(sbyte action, sbyte type, int playerId)
	{
		Message message = null;
		try
		{
			message = new Message(-59);
			message.writer().writeByte(action);
			message.writer().writeByte(type);
			message.writer().writeInt(playerId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x0003FAC0 File Offset: 0x0003DCC0
	public void requestMaptemplate(int maptemplateId)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(10);
			message.writer().writeByte(maptemplateId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x0003FB34 File Offset: 0x0003DD34
	public void outParty()
	{
		Message message = null;
		try
		{
			message = new Message(79);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x0003FB9C File Offset: 0x0003DD9C
	public void requestPlayerInfo(MyVector chars)
	{
		Message message = null;
		try
		{
			message = new Message(18);
			message.writer().writeByte(chars.size());
			for (int i = 0; i < chars.size(); i++)
			{
				global::Char @char = (global::Char)chars.elementAt(i);
				message.writer().writeInt(@char.charID);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x0003FC4C File Offset: 0x0003DE4C
	public void pleaseInputParty(string str)
	{
		Message message = null;
		try
		{
			message = new Message(16);
			message.writer().writeUTF(str);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x0003FCC0 File Offset: 0x0003DEC0
	public void acceptPleaseParty(string str)
	{
		Message message = null;
		try
		{
			message = new Message(17);
			message.writer().writeUTF(str);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x0003FD34 File Offset: 0x0003DF34
	public void chatPlayer(string text, int id)
	{
		Res.outz("chat player text = " + text);
		Message message = null;
		try
		{
			message = new Message(-72);
			message.writer().writeInt(id);
			message.writer().writeUTF(text);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x0003FDC4 File Offset: 0x0003DFC4
	public void chatGlobal(string text)
	{
		Message message = null;
		try
		{
			message = new Message(-71);
			message.writer().writeUTF(text);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x0003FE38 File Offset: 0x0003E038
	public void chatPrivate(string to, string text)
	{
		Message message = null;
		try
		{
			message = new Message(91);
			message.writer().writeUTF(to);
			message.writer().writeUTF(text);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x0003FEB8 File Offset: 0x0003E0B8
	public void sendCardInfo(string NAP, string PIN)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(16);
			message.writer().writeUTF(NAP);
			message.writer().writeUTF(PIN);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x0003FF38 File Offset: 0x0003E138
	public void saveRms(string key, sbyte[] data)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(60);
			message.writer().writeUTF(key);
			message.writer().writeInt(data.Length);
			message.writer().write(data);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x0003FFC8 File Offset: 0x0003E1C8
	public void loadRMS(string key)
	{
		Cout.println("REQUEST RMS");
		Message message = null;
		try
		{
			message = Service.messageSubCommand(61);
			message.writer().writeUTF(key);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00040048 File Offset: 0x0003E248
	public void clearTask()
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(17);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x000400B0 File Offset: 0x0003E2B0
	public void changeName(string name, int id)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(18);
			message.writer().writeInt(id);
			message.writer().writeUTF(name);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00040130 File Offset: 0x0003E330
	public void requestIcon(int id)
	{
		GameCanvas.connect();
		Message message = null;
		try
		{
			Res.outz("REQUEST ICON " + id);
			message = new Message(-67);
			message.writer().writeInt(id);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x000401FC File Offset: 0x0003E3FC
	public void doConvertUpgrade(int index1, int index2, int index3)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(33);
			message.writer().writeByte(index1);
			message.writer().writeByte(index2);
			message.writer().writeByte(index3);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00040288 File Offset: 0x0003E488
	public void inviteClanDun(string name)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(34);
			message.writer().writeUTF(name);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000402FC File Offset: 0x0003E4FC
	public void inputNumSplit(int indexItem, int numSplit)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(40);
			message.writer().writeByte(indexItem);
			message.writer().writeInt(numSplit);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x0004037C File Offset: 0x0003E57C
	public void activeAccProtect(int pass)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(37);
			message.writer().writeInt(pass);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x000403F0 File Offset: 0x0003E5F0
	public void clearAccProtect(int pass)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(41);
			message.writer().writeInt(pass);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x00040464 File Offset: 0x0003E664
	public void updateActive(int passOld, int passNew)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(38);
			message.writer().writeInt(passOld);
			message.writer().writeInt(passNew);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000404E4 File Offset: 0x0003E6E4
	public void openLockAccProtect(int pass2)
	{
		Message message = null;
		try
		{
			message = this.messageNotMap(39);
			message.writer().writeInt(pass2);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00040558 File Offset: 0x0003E758
	public void getBgTemplate(short id)
	{
		Message message = null;
		try
		{
			message = new Message(-32);
			message.writer().writeShort(id);
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0004060C File Offset: 0x0003E80C
	public void getMapOffline()
	{
		Message message = null;
		try
		{
			message = new Message(-33);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00040674 File Offset: 0x0003E874
	public void finishUpdate()
	{
		Message message = null;
		try
		{
			message = new Message(-38);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x000406DC File Offset: 0x0003E8DC
	public void finishLoadMap()
	{
		Message message = null;
		try
		{
			message = new Message(-39);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x00040744 File Offset: 0x0003E944
	public void getChest(sbyte action)
	{
		Message message = null;
		try
		{
			message = new Message(-35);
			message.writer().writeByte(action);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x000407B8 File Offset: 0x0003E9B8
	public void requestBagImage(sbyte ID)
	{
		Message message = null;
		try
		{
			message = new Message(-63);
			message.writer().writeByte(ID);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x0004082C File Offset: 0x0003EA2C
	public void getBag(sbyte action)
	{
		Message message = null;
		try
		{
			message = new Message(-36);
			message.writer().writeByte(action);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000408A0 File Offset: 0x0003EAA0
	public void getBody(sbyte action)
	{
		Message message = null;
		try
		{
			message = new Message(-37);
			message.writer().writeByte(action);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00040914 File Offset: 0x0003EB14
	public void login2(string user)
	{
		Res.outz("Login 2");
		Message message = null;
		try
		{
			message = new Message(-101);
			message.writer().writeUTF(user);
			message.writer().writeByte(1);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00040988 File Offset: 0x0003EB88
	public void getMagicTree(sbyte action)
	{
		Message message = null;
		try
		{
			message = new Message(-34);
			message.writer().writeByte(action);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000409FC File Offset: 0x0003EBFC
	public void upPotential(int typePotential, int num)
	{
		Message message = null;
		try
		{
			message = Service.messageSubCommand(16);
			message.writer().writeByte(typePotential);
			message.writer().writeShort(num);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00040A7C File Offset: 0x0003EC7C
	public void getResource(sbyte action, MyVector vResourceIndex)
	{
		Res.outz("request resource action= " + action);
		Message message = null;
		try
		{
			message = new Message(-74);
			message.writer().writeByte(action);
			if ((int)action == 2 && vResourceIndex != null)
			{
				message.writer().writeShort(vResourceIndex.size());
				for (int i = 0; i < vResourceIndex.size(); i++)
				{
					message.writer().writeShort(short.Parse((string)vResourceIndex.elementAt(i)));
				}
			}
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				Service.reciveFromMainSession = true;
				this.session = Session_ME.gI();
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			Cout.println(ex.Message + ex.StackTrace);
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00040B9C File Offset: 0x0003ED9C
	public void requestMapSelect(int selected)
	{
		Res.outz("request magic tree");
		Message message = null;
		try
		{
			message = new Message(-91);
			message.writer().writeByte(selected);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00040C04 File Offset: 0x0003EE04
	public void petInfo()
	{
		Message message = null;
		try
		{
			message = new Message(-107);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00040C58 File Offset: 0x0003EE58
	public void sendTop(string topName, sbyte selected)
	{
		Message message = null;
		try
		{
			message = new Message(-96);
			message.writer().writeUTF(topName);
			message.writer().writeByte(selected);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00040CC4 File Offset: 0x0003EEC4
	public void enemy(sbyte b, int charID)
	{
		Message message = null;
		Res.outz("add enemy");
		try
		{
			message = new Message(-99);
			message.writer().writeByte(b);
			if ((int)b == 1 || (int)b == 2)
			{
				message.writer().writeInt(charID);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x00040D48 File Offset: 0x0003EF48
	public void kigui(sbyte action, int itemId, sbyte moneyType, int money, int quaintly)
	{
		Message message = null;
		try
		{
			Res.outz("ki gui action= " + action);
			message = new Message(-100);
			message.writer().writeByte(action);
			if ((int)action == 0)
			{
				message.writer().writeShort(itemId);
				message.writer().writeByte(moneyType);
				message.writer().writeInt(money);
				message.writer().writeByte((sbyte)quaintly);
			}
			if ((int)action == 1 || (int)action == 2)
			{
				message.writer().writeShort(itemId);
			}
			if ((int)action == 3)
			{
				message.writer().writeShort(itemId);
				message.writer().writeByte(moneyType);
				message.writer().writeInt(money);
			}
			if ((int)action == 4)
			{
				message.writer().writeByte(moneyType);
				message.writer().writeByte(money);
				Res.outz(string.Concat(new object[]
				{
					"currTab= ",
					moneyType,
					" page= ",
					money
				}));
			}
			if ((int)action == 5)
			{
				message.writer().writeShort(itemId);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00040EC0 File Offset: 0x0003F0C0
	public void getFlag(sbyte action, sbyte flagType)
	{
		Message message = null;
		try
		{
			message = new Message(-103);
			message.writer().writeByte(action);
			Res.outz(string.Concat(new object[]
			{
				"------------service--  ",
				action,
				"   ",
				flagType
			}));
			if ((int)action != 0)
			{
				message.writer().writeByte(flagType);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x00040F64 File Offset: 0x0003F164
	public void setLockInventory(int pass)
	{
		Message message = null;
		try
		{
			Res.outz("------------setLockInventory:     " + pass);
			message = new Message(-104);
			message.writer().writeInt(pass);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00040FD8 File Offset: 0x0003F1D8
	public void petStatus(sbyte status)
	{
		Message message = null;
		try
		{
			message = new Message(-108);
			message.writer().writeByte(status);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00041038 File Offset: 0x0003F238
	public void transportNow()
	{
		Message message = null;
		try
		{
			Res.outz("------------transportNow  ");
			message = new Message(-105);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00041094 File Offset: 0x0003F294
	public void funsion(sbyte type)
	{
		Message message = null;
		try
		{
			Res.outz("FUNSION");
			message = new Message(125);
			message.writer().writeByte(type);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00041108 File Offset: 0x0003F308
	public void imageSource(MyVector vID)
	{
		Message message = null;
		try
		{
			Res.outz("IMAGE SOURCE size= " + vID.size());
			message = new Message(-111);
			message.writer().writeShort(vID.size());
			if (vID.size() > 0)
			{
				for (int i = 0; i < vID.size(); i++)
				{
					Res.outz("gui len str " + ((ImageSource)vID.elementAt(i)).id);
					message.writer().writeUTF(((ImageSource)vID.elementAt(i)).id);
				}
			}
			if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
			{
				this.session = Session_ME2.gI();
			}
			else
			{
				this.session = Session_ME.gI();
				Service.reciveFromMainSession = true;
			}
			this.session.sendMessage(message);
			this.session = Session_ME.gI();
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00041234 File Offset: 0x0003F434
	public void getQuayso()
	{
		Message message = null;
		try
		{
			message = new Message(-126);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00041294 File Offset: 0x0003F494
	public void sendServerData(sbyte action, int id, sbyte[] data)
	{
		Message message = null;
		try
		{
			Res.outz("SERVER DATA");
			message = new Message(-110);
			message.writer().writeByte(action);
			if ((int)action == 1)
			{
				message.writer().writeInt(id);
				if (data != null)
				{
					int num = data.Length;
					message.writer().writeShort(num);
					message.writer().write(ref data, 0, num);
				}
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00041334 File Offset: 0x0003F534
	public void changeOnKeyScr(sbyte[] skill)
	{
		Message message = null;
		try
		{
			message = new Message(-113);
			for (int i = 0; i < 5; i++)
			{
				message.writer().writeByte(skill[i]);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x000413B4 File Offset: 0x0003F5B4
	public void requestPean()
	{
		Message message = null;
		try
		{
			message = new Message(-114);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00041414 File Offset: 0x0003F614
	public void sendThachDau(int id)
	{
		Res.outz("GUI THACH DAU");
		Message message = null;
		try
		{
			message = new Message(-118);
			message.writer().writeInt(id);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00041488 File Offset: 0x0003F688
	public void messagePlayerMenu(int charId)
	{
		Message message = null;
		try
		{
			message = new Message(-30);
			message.writer().writeByte(63);
			message.writer().writeInt(charId);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00041500 File Offset: 0x0003F700
	public void playerMenuAction(int charId, short select)
	{
		Message message = null;
		try
		{
			message = new Message(-30);
			message.writer().writeByte(64);
			message.writer().writeInt(charId);
			message.writer().writeShort(select);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00041584 File Offset: 0x0003F784
	public void getImgByName(string nameImg)
	{
		Message message = null;
		try
		{
			message = new Message(66);
			message.writer().writeUTF(nameImg);
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x000415E4 File Offset: 0x0003F7E4
	public void SendCrackBall(byte type, byte soluong)
	{
		Message message = new Message(-127);
		try
		{
			message.writer().writeByte((int)type);
			if (soluong > 0)
			{
				message.writer().writeByte((int)soluong);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00041654 File Offset: 0x0003F854
	public void SendRada(int i, int id)
	{
		Message message = new Message(sbyte.MaxValue);
		try
		{
			message.writer().writeByte(i);
			if (id != -1)
			{
				message.writer().writeShort(id);
			}
			this.session.sendMessage(message);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			message.cleanup();
		}
	}

	// Token: 0x04000916 RID: 2326
	private ISession session = Session_ME.gI();

	// Token: 0x04000917 RID: 2327
	protected static Service instance;

	// Token: 0x04000918 RID: 2328
	public static long curCheckController;

	// Token: 0x04000919 RID: 2329
	public static long curCheckMap;

	// Token: 0x0400091A RID: 2330
	public static long logController;

	// Token: 0x0400091B RID: 2331
	public static long logMap;

	// Token: 0x0400091C RID: 2332
	public int demGui;

	// Token: 0x0400091D RID: 2333
	public static bool reciveFromMainSession;
}
