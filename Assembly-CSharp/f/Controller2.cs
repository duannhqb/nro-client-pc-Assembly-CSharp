using System;
using Assets.src.g;

namespace Assets.src.f
{
	// Token: 0x02000094 RID: 148
	internal class Controller2
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x000398CC File Offset: 0x00037ACC
		public static void readMessage(Message msg)
		{
			try
			{
				Res.outz("cmd=" + msg.command);
				sbyte command = msg.command;
				switch ((int)command + 128)
				{
				case 0:
					Controller2.readInfoEffChar(msg);
					break;
				case 1:
					Controller2.readLuckyRound(msg);
					break;
				case 2:
				{
					sbyte b = msg.reader().readByte();
					Res.outz("type quay= " + b);
					if ((int)b == 1)
					{
						sbyte b2 = msg.reader().readByte();
						string num = msg.reader().readUTF();
						string finish = msg.reader().readUTF();
						GameScr.gI().showWinNumber(num, finish);
					}
					if ((int)b == 0)
					{
						GameScr.gI().showYourNumber(msg.reader().readUTF());
					}
					break;
				}
				case 3:
				{
					ChatTextField.gI().isShow = false;
					string text = msg.reader().readUTF();
					Res.outz("titile= " + text);
					sbyte b3 = msg.reader().readByte();
					ClientInput.gI().setInput((int)b3, text);
					for (int i = 0; i < (int)b3; i++)
					{
						ClientInput.gI().tf[i].name = msg.reader().readUTF();
						sbyte b4 = msg.reader().readByte();
						if ((int)b4 == 0)
						{
							ClientInput.gI().tf[i].setIputType(TField.INPUT_TYPE_NUMERIC);
						}
						if ((int)b4 == 1)
						{
							ClientInput.gI().tf[i].setIputType(TField.INPUT_TYPE_ANY);
						}
						if ((int)b4 == 2)
						{
							ClientInput.gI().tf[i].setIputType(TField.INPUT_TYPE_PASSWORD);
						}
					}
					break;
				}
				case 4:
				{
					sbyte b5 = msg.reader().readByte();
					sbyte b6 = msg.reader().readByte();
					if ((int)b6 == 0)
					{
						if ((int)b5 == 2)
						{
							int num2 = msg.reader().readInt();
							if (num2 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeEffect();
							}
							else if (GameScr.findCharInMap(num2) != null)
							{
								GameScr.findCharInMap(num2).removeEffect();
							}
						}
						int num3 = (int)msg.reader().readUnsignedByte();
						int num4 = msg.reader().readInt();
						if (num3 == 32)
						{
							if ((int)b5 == 1)
							{
								int num5 = msg.reader().readInt();
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().holdEffID = num3;
									GameScr.findCharInMap(num5).setHoldChar(global::Char.myCharz());
								}
								else if (GameScr.findCharInMap(num4) != null && num5 != global::Char.myCharz().charID)
								{
									GameScr.findCharInMap(num4).holdEffID = num3;
									GameScr.findCharInMap(num5).setHoldChar(GameScr.findCharInMap(num4));
								}
								else if (GameScr.findCharInMap(num4) != null && num5 == global::Char.myCharz().charID)
								{
									GameScr.findCharInMap(num4).holdEffID = num3;
									global::Char.myCharz().setHoldChar(GameScr.findCharInMap(num4));
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeHoleEff();
							}
							else if (GameScr.findCharInMap(num4) != null)
							{
								GameScr.findCharInMap(num4).removeHoleEff();
							}
						}
						if (num3 == 33)
						{
							if ((int)b5 == 1)
							{
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().protectEff = true;
								}
								else if (GameScr.findCharInMap(num4) != null)
								{
									GameScr.findCharInMap(num4).protectEff = true;
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeProtectEff();
							}
							else if (GameScr.findCharInMap(num4) != null)
							{
								GameScr.findCharInMap(num4).removeProtectEff();
							}
						}
						if (num3 == 39)
						{
							if ((int)b5 == 1)
							{
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().huytSao = true;
								}
								else if (GameScr.findCharInMap(num4) != null)
								{
									GameScr.findCharInMap(num4).huytSao = true;
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeHuytSao();
							}
							else if (GameScr.findCharInMap(num4) != null)
							{
								GameScr.findCharInMap(num4).removeHuytSao();
							}
						}
						if (num3 == 40)
						{
							if ((int)b5 == 1)
							{
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().blindEff = true;
								}
								else if (GameScr.findCharInMap(num4) != null)
								{
									GameScr.findCharInMap(num4).blindEff = true;
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeBlindEff();
							}
							else if (GameScr.findCharInMap(num4) != null)
							{
								GameScr.findCharInMap(num4).removeBlindEff();
							}
						}
						if (num3 == 41)
						{
							if ((int)b5 == 1)
							{
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().sleepEff = true;
								}
								else if (GameScr.findCharInMap(num4) != null)
								{
									GameScr.findCharInMap(num4).sleepEff = true;
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().removeSleepEff();
							}
							else if (GameScr.findCharInMap(num4) != null)
							{
								GameScr.findCharInMap(num4).removeSleepEff();
							}
						}
						if (num3 == 42)
						{
							if ((int)b5 == 1)
							{
								if (num4 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().stone = true;
								}
							}
							else if (num4 == global::Char.myCharz().charID)
							{
								global::Char.myCharz().stone = false;
							}
						}
					}
					if ((int)b6 == 1)
					{
						int num6 = (int)msg.reader().readUnsignedByte();
						sbyte b7 = msg.reader().readByte();
						Res.outz(string.Concat(new object[]
						{
							"modbHoldID= ",
							b7,
							" skillID= ",
							num6,
							"eff ID= ",
							b5
						}));
						if (num6 == 32)
						{
							if ((int)b5 == 1)
							{
								int num7 = msg.reader().readInt();
								if (num7 == global::Char.myCharz().charID)
								{
									GameScr.findMobInMap(b7).holdEffID = num6;
									global::Char.myCharz().setHoldMob(GameScr.findMobInMap(b7));
								}
								else if (GameScr.findCharInMap(num7) != null)
								{
									GameScr.findMobInMap(b7).holdEffID = num6;
									GameScr.findCharInMap(num7).setHoldMob(GameScr.findMobInMap(b7));
								}
							}
							else
							{
								GameScr.findMobInMap(b7).removeHoldEff();
							}
						}
						if (num6 == 40)
						{
							if ((int)b5 == 1)
							{
								GameScr.findMobInMap(b7).blindEff = true;
							}
							else
							{
								GameScr.findMobInMap(b7).removeBlindEff();
							}
						}
						if (num6 == 41)
						{
							if ((int)b5 == 1)
							{
								GameScr.findMobInMap(b7).sleepEff = true;
							}
							else
							{
								GameScr.findMobInMap(b7).removeSleepEff();
							}
						}
					}
					break;
				}
				case 5:
				{
					int charId = msg.reader().readInt();
					if (GameScr.findCharInMap(charId) != null)
					{
						GameScr.findCharInMap(charId).perCentMp = (int)msg.reader().readByte();
					}
					break;
				}
				case 6:
				{
					short id = msg.reader().readShort();
					Npc npc = GameScr.findNPCInMap(id);
					sbyte b8 = msg.reader().readByte();
					npc.duahau = new int[(int)b8];
					Res.outz("N DUA HAU= " + b8);
					for (int j = 0; j < (int)b8; j++)
					{
						npc.duahau[j] = (int)msg.reader().readShort();
					}
					npc.setStatus(msg.reader().readByte(), msg.reader().readInt());
					break;
				}
				case 7:
				{
					long num8 = mSystem.currentTimeMillis();
					Service.logMap = num8 - Service.curCheckMap;
					Service.gI().sendCheckMap();
					break;
				}
				case 8:
				{
					long num9 = mSystem.currentTimeMillis();
					Service.logController = num9 - Service.curCheckController;
					Service.gI().sendCheckController();
					break;
				}
				case 9:
					global::Char.myCharz().rank = msg.reader().readInt();
					break;
				default:
					switch (command)
					{
					case 121:
						mSystem.publicID = msg.reader().readUTF();
						mSystem.strAdmob = msg.reader().readUTF();
						Res.outz("SHOW AD public ID= " + mSystem.publicID);
						mSystem.createAdmob();
						break;
					case 122:
					{
						short num10 = msg.reader().readShort();
						Res.outz("second login = " + num10);
						LoginScr.timeLogin = num10;
						LoginScr.currTimeLogin = (LoginScr.lastTimeLogin = mSystem.currentTimeMillis());
						GameCanvas.endDlg();
						break;
					}
					case 123:
					{
						Res.outz("SET POSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSss");
						int num11 = msg.reader().readInt();
						short xPos = msg.reader().readShort();
						short yPos = msg.reader().readShort();
						sbyte b9 = msg.reader().readByte();
						global::Char @char = null;
						if (num11 == global::Char.myCharz().charID)
						{
							@char = global::Char.myCharz();
						}
						else if (GameScr.findCharInMap(num11) != null)
						{
							@char = GameScr.findCharInMap(num11);
						}
						if (@char != null)
						{
							ServerEffect.addServerEffect(((int)b9 != 0) ? 173 : 60, @char, 1);
							@char.setPos(xPos, yPos, b9);
						}
						break;
					}
					case 124:
					{
						short num12 = msg.reader().readShort();
						string text2 = msg.reader().readUTF();
						Res.outz(string.Concat(new object[]
						{
							"noi chuyen = ",
							text2,
							"npc ID= ",
							num12
						}));
						Npc npc2 = GameScr.findNPCInMap(num12);
						if (npc2 != null)
						{
							npc2.addInfo(text2);
						}
						break;
					}
					case 125:
					{
						sbyte fusion = msg.reader().readByte();
						int num13 = msg.reader().readInt();
						if (num13 == global::Char.myCharz().charID)
						{
							global::Char.myCharz().setFusion(fusion);
						}
						else if (GameScr.findCharInMap(num13) != null)
						{
							GameScr.findCharInMap(num13).setFusion(fusion);
						}
						break;
					}
					default:
						switch (command)
						{
						case 48:
						{
							sbyte b10 = msg.reader().readByte();
							ServerListScreen.ipSelect = (int)b10;
							GameCanvas.instance.doResetToLoginScr(GameCanvas.serverScreen);
							Session_ME.gI().close();
							GameCanvas.endDlg();
							ServerListScreen.waitToLogin = true;
							break;
						}
						default:
							switch (command)
							{
							case 100:
							{
								sbyte b11 = msg.reader().readByte();
								sbyte b12 = msg.reader().readByte();
								Item item = null;
								if ((int)b11 == 0)
								{
									item = global::Char.myCharz().arrItemBody[(int)b12];
								}
								if ((int)b11 == 1)
								{
									item = global::Char.myCharz().arrItemBag[(int)b12];
								}
								short num14 = msg.reader().readShort();
								if (num14 != -1)
								{
									item.template = ItemTemplates.get(num14);
									item.quantity = msg.reader().readInt();
									item.info = msg.reader().readUTF();
									item.content = msg.reader().readUTF();
									sbyte b13 = msg.reader().readByte();
									if ((int)b13 != 0)
									{
										item.itemOption = new ItemOption[(int)b13];
										for (int k = 0; k < item.itemOption.Length; k++)
										{
											int num15 = (int)msg.reader().readUnsignedByte();
											Res.outz("id o= " + num15);
											int param = (int)msg.reader().readUnsignedShort();
											if (num15 != -1)
											{
												item.itemOption[k] = new ItemOption(num15, param);
											}
										}
									}
								}
								break;
							}
							case 101:
							{
								Res.outz("big boss--------------------------------------------------");
								BigBoss bigBoss = Mob.getBigBoss();
								if (bigBoss != null)
								{
									sbyte b14 = msg.reader().readByte();
									if ((int)b14 == 0 || (int)b14 == 1 || (int)b14 == 2 || (int)b14 == 4 || (int)b14 == 3)
									{
										if ((int)b14 == 3)
										{
											bigBoss.xTo = (bigBoss.xFirst = (int)msg.reader().readShort());
											bigBoss.yTo = (bigBoss.yFirst = (int)msg.reader().readShort());
											bigBoss.setFly();
										}
										else
										{
											sbyte b15 = msg.reader().readByte();
											Res.outz("CHUONG nChar= " + b15);
											global::Char[] array = new global::Char[(int)b15];
											int[] array2 = new int[(int)b15];
											for (int l = 0; l < (int)b15; l++)
											{
												int num16 = msg.reader().readInt();
												Res.outz("char ID=" + num16);
												array[l] = null;
												if (num16 != global::Char.myCharz().charID)
												{
													array[l] = GameScr.findCharInMap(num16);
												}
												else
												{
													array[l] = global::Char.myCharz();
												}
												array2[l] = msg.reader().readInt();
											}
											bigBoss.setAttack(array, array2, b14);
										}
									}
									if ((int)b14 == 5)
									{
										bigBoss.haftBody = true;
										bigBoss.status = 2;
									}
									if ((int)b14 == 6)
									{
										bigBoss.getDataB2();
										bigBoss.x = (int)msg.reader().readShort();
										bigBoss.y = (int)msg.reader().readShort();
									}
									if ((int)b14 == 7)
									{
										bigBoss.setAttack(null, null, b14);
									}
									if ((int)b14 == 8)
									{
										bigBoss.xTo = (bigBoss.xFirst = (int)msg.reader().readShort());
										bigBoss.yTo = (bigBoss.yFirst = (int)msg.reader().readShort());
										bigBoss.status = 2;
									}
									if ((int)b14 == 9)
									{
										bigBoss.x = (bigBoss.y = (bigBoss.xTo = (bigBoss.yTo = (bigBoss.xFirst = (bigBoss.yFirst = -1000)))));
									}
								}
								break;
							}
							case 102:
							{
								sbyte b16 = msg.reader().readByte();
								if ((int)b16 == 0 || (int)b16 == 1 || (int)b16 == 2 || (int)b16 == 6)
								{
									BigBoss2 bigBoss2 = Mob.getBigBoss2();
									if (bigBoss2 == null)
									{
										break;
									}
									if ((int)b16 == 6)
									{
										bigBoss2.x = (bigBoss2.y = (bigBoss2.xTo = (bigBoss2.yTo = (bigBoss2.xFirst = (bigBoss2.yFirst = -1000)))));
										break;
									}
									sbyte b17 = msg.reader().readByte();
									global::Char[] array3 = new global::Char[(int)b17];
									int[] array4 = new int[(int)b17];
									for (int m = 0; m < (int)b17; m++)
									{
										int num17 = msg.reader().readInt();
										array3[m] = null;
										if (num17 != global::Char.myCharz().charID)
										{
											array3[m] = GameScr.findCharInMap(num17);
										}
										else
										{
											array3[m] = global::Char.myCharz();
										}
										array4[m] = msg.reader().readInt();
									}
									bigBoss2.setAttack(array3, array4, b16);
								}
								if ((int)b16 == 3 || (int)b16 == 4 || (int)b16 == 5 || (int)b16 == 7)
								{
									BachTuoc bachTuoc = Mob.getBachTuoc();
									if (bachTuoc == null)
									{
										break;
									}
									if ((int)b16 == 7)
									{
										bachTuoc.x = (bachTuoc.y = (bachTuoc.xTo = (bachTuoc.yTo = (bachTuoc.xFirst = (bachTuoc.yFirst = -1000)))));
										break;
									}
									if ((int)b16 == 3 || (int)b16 == 4)
									{
										sbyte b18 = msg.reader().readByte();
										global::Char[] array5 = new global::Char[(int)b18];
										int[] array6 = new int[(int)b18];
										for (int n = 0; n < (int)b18; n++)
										{
											int num18 = msg.reader().readInt();
											array5[n] = null;
											if (num18 != global::Char.myCharz().charID)
											{
												array5[n] = GameScr.findCharInMap(num18);
											}
											else
											{
												array5[n] = global::Char.myCharz();
											}
											array6[n] = msg.reader().readInt();
										}
										bachTuoc.setAttack(array5, array6, b16);
									}
									if ((int)b16 == 5)
									{
										short xMoveTo = msg.reader().readShort();
										bachTuoc.move(xMoveTo);
									}
								}
								if ((int)b16 > 9 && (int)b16 < 30)
								{
									Controller2.readActionBoss(msg, (int)b16);
								}
								break;
							}
							default:
								if (command != 113)
								{
									if (command != 114)
									{
										if (command != 31)
										{
											if (command != 42)
											{
												if (command == 93)
												{
													string text3 = msg.reader().readUTF();
													text3 = Res.changeString(text3);
													GameScr.gI().chatVip(text3);
												}
											}
											else
											{
												GameCanvas.endDlg();
												LoginScr.isContinueToLogin = false;
												global::Char.isLoadingMap = false;
												sbyte haveName = msg.reader().readByte();
												if (GameCanvas.registerScr == null)
												{
													GameCanvas.registerScr = new RegisterScreen(haveName);
												}
												GameCanvas.registerScr.switchToMe();
											}
										}
										else
										{
											int num19 = msg.reader().readInt();
											sbyte b19 = msg.reader().readByte();
											if ((int)b19 == 1)
											{
												short smallID = msg.reader().readShort();
												sbyte b20 = -1;
												int[] array7 = null;
												short wimg = 0;
												short himg = 0;
												try
												{
													b20 = msg.reader().readByte();
													if ((int)b20 > 0)
													{
														sbyte b21 = msg.reader().readByte();
														array7 = new int[(int)b21];
														for (int num20 = 0; num20 < (int)b21; num20++)
														{
															array7[num20] = (int)msg.reader().readByte();
														}
														wimg = msg.reader().readShort();
														himg = msg.reader().readShort();
													}
												}
												catch (Exception ex)
												{
												}
												if (num19 == global::Char.myCharz().charID)
												{
													global::Char.myCharz().petFollow = new PetFollow();
													global::Char.myCharz().petFollow.smallID = smallID;
													if ((int)b20 > 0)
													{
														global::Char.myCharz().petFollow.SetImg((int)b20, array7, (int)wimg, (int)himg);
													}
												}
												else
												{
													global::Char char2 = GameScr.findCharInMap(num19);
													char2.petFollow = new PetFollow();
													char2.petFollow.smallID = smallID;
													if ((int)b20 > 0)
													{
														char2.petFollow.SetImg((int)b20, array7, (int)wimg, (int)himg);
													}
												}
											}
											else if (num19 == global::Char.myCharz().charID)
											{
												global::Char.myCharz().petFollow.remove();
												global::Char.myCharz().petFollow = null;
											}
											else
											{
												global::Char char3 = GameScr.findCharInMap(num19);
												char3.petFollow.remove();
												char3.petFollow = null;
											}
										}
									}
									else
									{
										try
										{
											string text4 = msg.reader().readUTF();
											mSystem.curINAPP = msg.reader().readByte();
											mSystem.maxINAPP = msg.reader().readByte();
										}
										catch (Exception ex2)
										{
										}
									}
								}
								else
								{
									int loop = (int)msg.reader().readByte();
									int layer = (int)msg.reader().readByte();
									int id2 = (int)msg.reader().readUnsignedByte();
									short x = msg.reader().readShort();
									short y = msg.reader().readShort();
									short loopCount = msg.reader().readShort();
									EffecMn.addEff(new Effect(id2, (int)x, (int)y, layer, loop, (int)loopCount));
								}
								break;
							}
							break;
						case 51:
						{
							int charId2 = msg.reader().readInt();
							Mabu mabu = (Mabu)GameScr.findCharInMap(charId2);
							sbyte id3 = msg.reader().readByte();
							short x2 = msg.reader().readShort();
							short y2 = msg.reader().readShort();
							sbyte b22 = msg.reader().readByte();
							global::Char[] array8 = new global::Char[(int)b22];
							int[] array9 = new int[(int)b22];
							for (int num21 = 0; num21 < (int)b22; num21++)
							{
								int num22 = msg.reader().readInt();
								Res.outz("char ID=" + num22);
								array8[num21] = null;
								if (num22 != global::Char.myCharz().charID)
								{
									array8[num21] = GameScr.findCharInMap(num22);
								}
								else
								{
									array8[num21] = global::Char.myCharz();
								}
								array9[num21] = msg.reader().readInt();
							}
							mabu.setSkill(id3, x2, y2, array8, array9);
							break;
						}
						case 52:
						{
							sbyte b23 = msg.reader().readByte();
							if ((int)b23 == 1)
							{
								int num23 = msg.reader().readInt();
								if (num23 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().setMabuHold(true);
									global::Char.myCharz().cx = (int)msg.reader().readShort();
									global::Char.myCharz().cy = (int)msg.reader().readShort();
								}
								else
								{
									global::Char char4 = GameScr.findCharInMap(num23);
									if (char4 != null)
									{
										char4.setMabuHold(true);
										char4.cx = (int)msg.reader().readShort();
										char4.cy = (int)msg.reader().readShort();
									}
								}
							}
							if ((int)b23 == 0)
							{
								int num24 = msg.reader().readInt();
								if (num24 == global::Char.myCharz().charID)
								{
									global::Char.myCharz().setMabuHold(false);
								}
								else
								{
									global::Char char5 = GameScr.findCharInMap(num24);
									if (char5 != null)
									{
										char5.setMabuHold(false);
									}
								}
							}
							if ((int)b23 == 2)
							{
								int charId3 = msg.reader().readInt();
								int id4 = msg.reader().readInt();
								Mabu mabu2 = (Mabu)GameScr.findCharInMap(charId3);
								mabu2.eat(id4);
							}
							if ((int)b23 == 3)
							{
								GameScr.mabuPercent = msg.reader().readByte();
							}
							break;
						}
						}
						break;
					case 127:
						Controller2.readInfoRada(msg);
						break;
					}
					break;
				case 11:
					GameScr.gI().tMabuEff = 0;
					GameScr.gI().percentMabu = msg.reader().readByte();
					if ((int)GameScr.gI().percentMabu == 100)
					{
						GameScr.gI().mabuEff = true;
					}
					if ((int)GameScr.gI().percentMabu == 101)
					{
						Npc.mabuEff = true;
					}
					break;
				case 12:
					GameScr.canAutoPlay = ((int)msg.reader().readByte() == 1);
					break;
				case 13:
					global::Char.myCharz().setPowerInfo(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
					break;
				case 15:
				{
					sbyte[] array10 = new sbyte[5];
					for (int num25 = 0; num25 < 5; num25++)
					{
						array10[num25] = msg.reader().readByte();
						Res.outz("vlue i= " + array10[num25]);
					}
					GameScr.gI().onKSkill(array10);
					GameScr.gI().onOSkill(array10);
					GameScr.gI().onCSkill(array10);
					break;
				}
				case 17:
				{
					short num26 = msg.reader().readShort();
					ImageSource.vSource = new MyVector();
					for (int num27 = 0; num27 < (int)num26; num27++)
					{
						string id5 = msg.reader().readUTF();
						sbyte version = msg.reader().readByte();
						ImageSource.vSource.addElement(new ImageSource(id5, version));
					}
					ImageSource.checkRMS();
					ImageSource.saveRMS();
					break;
				}
				case 18:
				{
					sbyte b24 = msg.reader().readByte();
					if ((int)b24 == 1)
					{
						int num28 = msg.reader().readInt();
						sbyte[] array11 = Rms.loadRMS(num28 + string.Empty);
						if (array11 == null)
						{
							Service.gI().sendServerData(1, -1, null);
						}
						else
						{
							Service.gI().sendServerData(1, num28, array11);
						}
					}
					if ((int)b24 == 0)
					{
						int num29 = msg.reader().readInt();
						short num30 = msg.reader().readShort();
						sbyte[] data = new sbyte[(int)num30];
						msg.reader().read(ref data, 0, (int)num30);
						Rms.saveRMS(num29 + string.Empty, data);
					}
					break;
				}
				case 22:
				{
					short num31 = msg.reader().readShort();
					int num32 = (int)msg.reader().readShort();
					if (ItemTime.isExistItem((int)num31))
					{
						ItemTime.getItemById((int)num31).initTime(num32);
					}
					else
					{
						ItemTime o = new ItemTime(num31, num32);
						global::Char.vItemTime.addElement(o);
					}
					break;
				}
				case 23:
					TransportScr.gI().time = 0;
					TransportScr.gI().maxTime = msg.reader().readShort();
					TransportScr.gI().last = (TransportScr.gI().curr = mSystem.currentTimeMillis());
					TransportScr.gI().type = msg.reader().readByte();
					TransportScr.gI().switchToMe();
					break;
				case 25:
				{
					sbyte b25 = msg.reader().readByte();
					if ((int)b25 == 0)
					{
						GameCanvas.panel.vFlag.removeAllElements();
						sbyte b26 = msg.reader().readByte();
						for (int num33 = 0; num33 < (int)b26; num33++)
						{
							Item item2 = new Item();
							short num34 = msg.reader().readShort();
							if (num34 != -1)
							{
								item2.template = ItemTemplates.get(num34);
								sbyte b27 = msg.reader().readByte();
								if ((int)b27 != -1)
								{
									item2.itemOption = new ItemOption[(int)b27];
									for (int num35 = 0; num35 < item2.itemOption.Length; num35++)
									{
										int num36 = (int)msg.reader().readUnsignedByte();
										int param2 = (int)msg.reader().readUnsignedShort();
										if (num36 != -1)
										{
											item2.itemOption[num35] = new ItemOption(num36, param2);
										}
									}
								}
							}
							GameCanvas.panel.vFlag.addElement(item2);
						}
						GameCanvas.panel.setTypeFlag();
						GameCanvas.panel.show();
					}
					else if ((int)b25 == 1)
					{
						int num37 = msg.reader().readInt();
						sbyte b28 = msg.reader().readByte();
						Res.outz(string.Concat(new object[]
						{
							"---------------actionFlag1:  ",
							num37,
							" : ",
							b28
						}));
						if (num37 == global::Char.myCharz().charID)
						{
							global::Char.myCharz().cFlag = b28;
						}
						else if (GameScr.findCharInMap(num37) != null)
						{
							GameScr.findCharInMap(num37).cFlag = b28;
						}
						GameScr.gI().getFlagImage(num37, b28);
					}
					else if ((int)b25 == 2)
					{
						sbyte b29 = msg.reader().readByte();
						int num38 = (int)msg.reader().readShort();
						PKFlag pkflag = new PKFlag();
						pkflag.cflag = b29;
						pkflag.IDimageFlag = num38;
						GameScr.vFlag.addElement(pkflag);
						for (int num39 = 0; num39 < GameScr.vFlag.size(); num39++)
						{
							PKFlag pkflag2 = (PKFlag)GameScr.vFlag.elementAt(num39);
							Res.outz(string.Concat(new object[]
							{
								"i: ",
								num39,
								"  cflag: ",
								pkflag2.cflag,
								"   IDimageFlag: ",
								pkflag2.IDimageFlag
							}));
						}
						for (int num40 = 0; num40 < GameScr.vCharInMap.size(); num40++)
						{
							global::Char char6 = (global::Char)GameScr.vCharInMap.elementAt(num40);
							if (char6 != null && (int)char6.cFlag == (int)b29)
							{
								char6.flagImage = num38;
							}
						}
						if ((int)global::Char.myCharz().cFlag == (int)b29)
						{
							global::Char.myCharz().flagImage = num38;
						}
					}
					break;
				}
				case 26:
				{
					sbyte b30 = msg.reader().readByte();
					if ((int)b30 != 0)
					{
						if ((int)b30 == 1)
						{
							GameCanvas.loginScr.isLogin2 = false;
							Service.gI().login(Rms.loadRMSString("acc"), Rms.loadRMSString("pass"), GameMidlet.VERSION, 0);
							LoginScr.isLoggingIn = true;
						}
					}
					break;
				}
				case 27:
				{
					GameCanvas.loginScr.isLogin2 = true;
					GameCanvas.connect();
					string text5 = msg.reader().readUTF();
					Rms.saveRMSString("userAo" + ServerListScreen.ipSelect, text5);
					Service.gI().setClientType();
					Service.gI().login(text5, string.Empty, GameMidlet.VERSION, 1);
					break;
				}
				case 28:
				{
					InfoDlg.hide();
					bool flag = false;
					if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
					{
						flag = true;
					}
					sbyte b31 = msg.reader().readByte();
					Res.outz("t Indxe= " + b31);
					GameCanvas.panel.maxPageShop[(int)b31] = (int)msg.reader().readByte();
					GameCanvas.panel.currPageShop[(int)b31] = (int)msg.reader().readByte();
					Res.outz(string.Concat(new object[]
					{
						"max page= ",
						GameCanvas.panel.maxPageShop[(int)b31],
						" curr page= ",
						GameCanvas.panel.currPageShop[(int)b31]
					}));
					int num41 = (int)msg.reader().readUnsignedByte();
					global::Char.myCharz().arrItemShop[(int)b31] = new Item[num41];
					for (int num42 = 0; num42 < num41; num42++)
					{
						short num43 = msg.reader().readShort();
						if (num43 != -1)
						{
							Res.outz("template id= " + num43);
							global::Char.myCharz().arrItemShop[(int)b31][num42] = new Item();
							global::Char.myCharz().arrItemShop[(int)b31][num42].template = ItemTemplates.get(num43);
							global::Char.myCharz().arrItemShop[(int)b31][num42].itemId = (int)msg.reader().readShort();
							global::Char.myCharz().arrItemShop[(int)b31][num42].buyCoin = msg.reader().readInt();
							global::Char.myCharz().arrItemShop[(int)b31][num42].buyGold = msg.reader().readInt();
							global::Char.myCharz().arrItemShop[(int)b31][num42].buyType = msg.reader().readByte();
							global::Char.myCharz().arrItemShop[(int)b31][num42].quantity = (int)msg.reader().readByte();
							global::Char.myCharz().arrItemShop[(int)b31][num42].isMe = msg.reader().readByte();
							Panel.strWantToBuy = mResources.say_wat_do_u_want_to_buy;
							sbyte b32 = msg.reader().readByte();
							if ((int)b32 != -1)
							{
								global::Char.myCharz().arrItemShop[(int)b31][num42].itemOption = new ItemOption[(int)b32];
								for (int num44 = 0; num44 < global::Char.myCharz().arrItemShop[(int)b31][num42].itemOption.Length; num44++)
								{
									int num45 = (int)msg.reader().readUnsignedByte();
									int param3 = (int)msg.reader().readUnsignedShort();
									if (num45 != -1)
									{
										global::Char.myCharz().arrItemShop[(int)b31][num42].itemOption[num44] = new ItemOption(num45, param3);
										global::Char.myCharz().arrItemShop[(int)b31][num42].compare = GameCanvas.panel.getCompare(global::Char.myCharz().arrItemShop[(int)b31][num42]);
									}
								}
							}
							sbyte b33 = msg.reader().readByte();
							if ((int)b33 == 1)
							{
								int headTemp = (int)msg.reader().readShort();
								int bodyTemp = (int)msg.reader().readShort();
								int legTemp = (int)msg.reader().readShort();
								int bagTemp = (int)msg.reader().readShort();
								global::Char.myCharz().arrItemShop[(int)b31][num42].setPartTemp(headTemp, bodyTemp, legTemp, bagTemp);
							}
						}
					}
					if (flag)
					{
						GameCanvas.panel2.setTabKiGui();
					}
					GameCanvas.panel.setTabShop();
					GameCanvas.panel.cmy = (GameCanvas.panel.cmtoY = 0);
					break;
				}
				case 39:
					GameCanvas.open3Hour = ((int)msg.reader().readByte() == 1);
					break;
				}
			}
			catch (Exception ex3)
			{
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0003BA94 File Offset: 0x00039C94
		private static void readLuckyRound(Message msg)
		{
			try
			{
				sbyte b = msg.reader().readByte();
				if ((int)b == 0)
				{
					sbyte b2 = msg.reader().readByte();
					short[] array = new short[(int)b2];
					for (int i = 0; i < (int)b2; i++)
					{
						array[i] = msg.reader().readShort();
					}
					sbyte b3 = msg.reader().readByte();
					int price = msg.reader().readInt();
					short idTicket = msg.reader().readShort();
					CrackBallScr.gI().SetCrackBallScr(array, (byte)b3, price, idTicket);
				}
				else if ((int)b == 1)
				{
					sbyte b4 = msg.reader().readByte();
					short[] array2 = new short[(int)b4];
					for (int j = 0; j < (int)b4; j++)
					{
						array2[j] = msg.reader().readShort();
					}
					CrackBallScr.gI().DoneCrackBallScr(array2);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0003BB98 File Offset: 0x00039D98
		private static void readInfoRada(Message msg)
		{
			try
			{
				sbyte b = msg.reader().readByte();
				if ((int)b == 0)
				{
					RadarScr.gI();
					MyVector myVector = new MyVector(string.Empty);
					short num = msg.reader().readShort();
					int num2 = 0;
					for (int i = 0; i < (int)num; i++)
					{
						Info_RadaScr info_RadaScr = new Info_RadaScr();
						int id = (int)msg.reader().readShort();
						int no = i + 1;
						int idIcon = (int)msg.reader().readShort();
						sbyte rank = msg.reader().readByte();
						sbyte amount = msg.reader().readByte();
						sbyte max_amount = msg.reader().readByte();
						short templateId = -1;
						global::Char charInfo = null;
						sbyte b2 = msg.reader().readByte();
						if ((int)b2 == 0)
						{
							templateId = msg.reader().readShort();
						}
						else
						{
							int head = (int)msg.reader().readShort();
							int body = (int)msg.reader().readShort();
							int leg = (int)msg.reader().readShort();
							int bag = (int)msg.reader().readShort();
							charInfo = Info_RadaScr.SetCharInfo(head, body, leg, bag);
						}
						string name = msg.reader().readUTF();
						string info = msg.reader().readUTF();
						sbyte b3 = msg.reader().readByte();
						sbyte use = msg.reader().readByte();
						sbyte b4 = msg.reader().readByte();
						ItemOption[] array = null;
						if ((int)b4 != 0)
						{
							array = new ItemOption[(int)b4];
							for (int j = 0; j < array.Length; j++)
							{
								int num3 = (int)msg.reader().readUnsignedByte();
								int param = (int)msg.reader().readUnsignedShort();
								sbyte activeCard = msg.reader().readByte();
								if (num3 != -1)
								{
									array[j] = new ItemOption(num3, param);
									array[j].activeCard = activeCard;
								}
							}
						}
						info_RadaScr.SetInfo(id, no, idIcon, rank, b2, templateId, name, info, charInfo, array);
						info_RadaScr.SetLevel(b3);
						info_RadaScr.SetUse(use);
						info_RadaScr.SetAmount(amount, max_amount);
						myVector.addElement(info_RadaScr);
						if ((int)b3 > 0)
						{
							num2++;
						}
					}
					RadarScr.gI().SetRadarScr(myVector, num2, (int)num);
					RadarScr.gI().switchToMe();
				}
				else if ((int)b == 1)
				{
					int id2 = (int)msg.reader().readShort();
					sbyte use2 = msg.reader().readByte();
					if (Info_RadaScr.GetInfo(RadarScr.list, id2) != null)
					{
						Info_RadaScr.GetInfo(RadarScr.list, id2).SetUse(use2);
					}
					RadarScr.SetListUse();
				}
				else if ((int)b == 2)
				{
					int num4 = (int)msg.reader().readShort();
					sbyte level = msg.reader().readByte();
					int num5 = 0;
					for (int k = 0; k < RadarScr.list.size(); k++)
					{
						Info_RadaScr info_RadaScr2 = (Info_RadaScr)RadarScr.list.elementAt(k);
						if (info_RadaScr2 != null)
						{
							if (info_RadaScr2.id == num4)
							{
								info_RadaScr2.SetLevel(level);
							}
							if ((int)info_RadaScr2.level > 0)
							{
								num5++;
							}
						}
					}
					RadarScr.SetNum(num5, RadarScr.list.size());
					if (Info_RadaScr.GetInfo(RadarScr.listUse, num4) != null)
					{
						Info_RadaScr.GetInfo(RadarScr.listUse, num4).SetLevel(level);
					}
				}
				else if ((int)b == 3)
				{
					int id3 = (int)msg.reader().readShort();
					sbyte amount2 = msg.reader().readByte();
					sbyte max_amount2 = msg.reader().readByte();
					if (Info_RadaScr.GetInfo(RadarScr.list, id3) != null)
					{
						Info_RadaScr.GetInfo(RadarScr.list, id3).SetAmount(amount2, max_amount2);
					}
					if (Info_RadaScr.GetInfo(RadarScr.listUse, id3) != null)
					{
						Info_RadaScr.GetInfo(RadarScr.listUse, id3).SetAmount(amount2, max_amount2);
					}
				}
				else if ((int)b == 4)
				{
					int num6 = msg.reader().readInt();
					short idAuraEff = msg.reader().readShort();
					global::Char @char;
					if (num6 == global::Char.myCharz().charID)
					{
						@char = global::Char.myCharz();
					}
					else
					{
						@char = GameScr.findCharInMap(num6);
					}
					if (@char != null)
					{
						@char.idAuraEff = idAuraEff;
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0003BFE4 File Offset: 0x0003A1E4
		private static void readInfoEffChar(Message msg)
		{
			try
			{
				sbyte b = msg.reader().readByte();
				int num = msg.reader().readInt();
				global::Char @char;
				if (num == global::Char.myCharz().charID)
				{
					@char = global::Char.myCharz();
				}
				else
				{
					@char = GameScr.findCharInMap(num);
				}
				if ((int)b == 0)
				{
					int id = (int)msg.reader().readShort();
					int layer = (int)msg.reader().readByte();
					int loop = (int)msg.reader().readByte();
					short loopCount = msg.reader().readShort();
					sbyte isStand = msg.reader().readByte();
					if (@char != null)
					{
						@char.addEffChar(new Effect(id, @char, layer, loop, (int)loopCount, isStand));
					}
				}
				else if ((int)b == 1)
				{
					int id2 = (int)msg.reader().readShort();
					if (@char != null)
					{
						@char.removeEffChar(0, id2);
					}
				}
				else if ((int)b == 2)
				{
					if (@char != null)
					{
						@char.removeEffChar(-1, 0);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0003C100 File Offset: 0x0003A300
		private static void readActionBoss(Message msg, int actionBoss)
		{
			try
			{
				sbyte idBoss = msg.reader().readByte();
				NewBoss newBoss = Mob.getNewBoss(idBoss);
				if (newBoss != null)
				{
					if (actionBoss == 10)
					{
						short xMoveTo = msg.reader().readShort();
						short yMoveTo = msg.reader().readShort();
						newBoss.move(xMoveTo, yMoveTo);
					}
					if (actionBoss >= 11 && actionBoss <= 20)
					{
						sbyte b = msg.reader().readByte();
						global::Char[] array = new global::Char[(int)b];
						int[] array2 = new int[(int)b];
						for (int i = 0; i < (int)b; i++)
						{
							int num = msg.reader().readInt();
							array[i] = null;
							if (num != global::Char.myCharz().charID)
							{
								array[i] = GameScr.findCharInMap(num);
							}
							else
							{
								array[i] = global::Char.myCharz();
							}
							array2[i] = msg.reader().readInt();
						}
						sbyte dir = msg.reader().readByte();
						newBoss.setAttack(array, array2, (sbyte)(actionBoss - 10), dir);
					}
					if (actionBoss == 21)
					{
						newBoss.xTo = (int)msg.reader().readShort();
						newBoss.yTo = (int)msg.reader().readShort();
						newBoss.setFly();
					}
					if (actionBoss == 22)
					{
					}
					if (actionBoss == 23)
					{
						newBoss.setDie();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}
}
