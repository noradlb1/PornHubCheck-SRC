using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Colorful;

namespace PornHubCheck
{
	// Token: 0x02000005 RID: 5
	internal class Program
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002C74 File Offset: 0x00000E74
		private static void Main(string[] args)
		{
			Initialization.checkerMethod();
			Colorful.Console.ReadLine();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002CB0 File Offset: 0x00000EB0
		// Note: this type is marked as 'beforefieldinit'.
		static Program()
		{
			Program.COMBOS = new BlockingCollection<string>();
			Program.PROXIES = new List<string>();
			Program.startDateTime = "";
			Program.cpm2 = 0;
		}

		// Token: 0x04000001 RID: 1
		public static BlockingCollection<string> COMBOS;

		// Token: 0x04000002 RID: 2
		public static List<string> PROXIES;

		// Token: 0x04000003 RID: 3
		public static string startDateTime;

		// Token: 0x04000004 RID: 4
		public static int proxyType;

		// Token: 0x04000005 RID: 5
		public static int hitCnt;

		// Token: 0x04000006 RID: 6
		public static int deadCnt;

		// Token: 0x04000007 RID: 7
		public static int checkedCnt;

		// Token: 0x04000008 RID: 8
		public static int retryCnt;

		// Token: 0x04000009 RID: 9
		public static int comboCount;

		// Token: 0x0400000A RID: 10
		public static int threads;

		// Token: 0x0400000B RID: 11
		public static int cpm;

		// Token: 0x0400000C RID: 12
		public static int cpm2;
	}
}
