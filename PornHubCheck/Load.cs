using System;
using System.Drawing;
using System.IO;

namespace PornHubCheck
{
	// Token: 0x02000004 RID: 4
	internal class Load
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000026B4 File Offset: 0x000008B4
		public static bool loadCombos()
		{
			bool result;
			try
			{
				Utilities.writeTime("Drag in Combo File.", Color.Coral);
				using (Stream stream = new FileStream(Colorful.Console.ReadLine().Replace((char)34, (char)32), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (Stream stream2 = new BufferedStream(stream))
					{
						using (TextReader textReader = new StreamReader(stream2))
						{
							for (;;)
							{
								string text = textReader.ReadLine();
								if(text == null)
                                {
                                    break;
                                }
								Program.COMBOS.Add(text);
							}
							if ((((uint)Program.COMBOS.Count > (uint)0) ? 1u : 0u) != (uint)0)
							{
								Utilities.writeTime(string.Format("Loaded {0} Combos.", Program.COMBOS.Count), Color.Coral);
								Program.comboCount = Program.COMBOS.Count;
								result = true;
							}
							else
							{
								Utilities.writeTime("Empty File.", Color.Crimson);
								result = false;
							}
						}
					}
				}
			}
			catch
			{
				Utilities.writeTime("Error Loading.", Color.Crimson);
				result = false;
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000028E4 File Offset: 0x00000AE4
		public static bool loadProxies()
		{
			bool result;
			try
			{
				Utilities.writeTime("Drag in Proxy File.", Color.Coral);
				using (Stream stream = new FileStream(Colorful.Console.ReadLine().Replace((char)34, (char)32), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (Stream stream2 = new BufferedStream(stream))
					{
						using (TextReader textReader = new StreamReader(stream2))
						{
							for (;;)
							{
								string text = textReader.ReadLine();
								if(text == null)
                                {
                                    break;
                                }
								Program.PROXIES.Add(text);
							}
							if ((((uint)Program.PROXIES.Count > (uint)0) ? 1u : 0u) != (uint)0)
							{
								Utilities.writeTime(string.Format("Loaded {0} Proxies.", Program.PROXIES.Count), Color.Coral);
								result = true;
							}
							else
							{
								Utilities.writeTime("Empty File.", Color.Crimson);
								result = false;
							}
						}
					}
				}
			}
			catch
			{
				Utilities.writeTime("Error Loading.", Color.Crimson);
				result = false;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002B04 File Offset: 0x00000D04
		public static void proxySelect()
		{
			try
			{
				Colorful.Console.WriteLine("Select Proxy Type:", Color.Coral);
				Colorful.Console.WriteLine("[#1] | HTTPS", Color.Coral);
				Colorful.Console.WriteLine("[#2] | SOCKS4", Color.Coral);
				Colorful.Console.WriteLine("[#3] | SOCKS5", Color.Coral);
				Colorful.Console.WriteLine("[#0] | Proxyless", Color.Coral);
				Program.proxyType = Convert.ToInt32(Colorful.Console.ReadLine());
				uint num;
				if ((((uint)Program.proxyType < (uint)0) ? 1u : 0u) == (uint)0)
				{
					num = (((uint)Program.proxyType > (uint)3) ? 1u : 0u);
				}
				else
				{
					num = (uint)1;
				}
				if (num != (uint)0)
				{
					Load.proxySelect();
				}
			}
			catch
			{
				Load.proxySelect();
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002BDC File Offset: 0x00000DDC
		public static void getThreads()
		{
			try
			{
				Utilities.writeTime("Thread Count?", Color.Coral);
				Program.threads = Convert.ToInt32(Colorful.Console.ReadLine());
				if ((((((uint)Program.threads > (uint)0) ? 1u : 0u) == (uint)0) ? 1u : 0u) != (uint)0)
				{
					Load.getThreads();
				}
			}
			catch
			{
				Load.getThreads();
			}
		}
	}
}
