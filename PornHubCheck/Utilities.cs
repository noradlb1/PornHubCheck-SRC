using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Colorful;

namespace PornHubCheck
{
	// Token: 0x02000007 RID: 7
	internal class Utilities
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00003250 File Offset: 0x00001450
		public static void WriteTitle()
		{
			Colorful.Console.Title = string.Format("PornHubCheck | Edit By MONSTERMC - cracked by dark#5000 | Checked: {0}/{1} | Hits: {2} | Dead: {3} | Retries: {4} | CPM: {5} | https://magholarabeee.blogspot.com/", new object[]
			{
				Program.checkedCnt,
				Program.comboCount,
				Program.hitCnt,
				Program.deadCnt,
				Program.retryCnt,
				(int)((uint)Program.cpm * (uint)60)
			});
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000032D0 File Offset: 0x000014D0
		public static void writeTime(string TEXT, Color color)
		{
			DateTime dateTime = default(DateTime);
			Colorful.Console.Write(DateTime.Now.ToString("hh:mm") + " | ", Color.Crimson);
			if (TEXT == null)
			{
			}
			Colorful.Console.WriteLine(TEXT, color);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003334 File Offset: 0x00001534
		public static void writeToText(string LINE)
		{
			try
			{
				using (TextWriter textWriter = new StreamWriter(Program.startDateTime + "/Hits.txt", true))
				{
					textWriter.WriteLine(LINE);
				}
			}
            catch
            {

            }
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000033E4 File Offset: 0x000015E4
		public static void writeTimeNL(string TEXT, Color color)
		{
			DateTime dateTime = default(DateTime);
			Colorful.Console.Write(DateTime.Now.ToString("hh:mm") + " | ", Color.Crimson);
			string value = TEXT;
			if (TEXT == null)
			{
				value = "";
			}
			Colorful.Console.Write(value, color);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003464 File Offset: 0x00001664
		// Note: this type is marked as 'beforefieldinit'.
		static Utilities()
		{
			Utilities.@lock = new object();
		}

		// Token: 0x04000010 RID: 16
		private static object @lock;
	}
}
