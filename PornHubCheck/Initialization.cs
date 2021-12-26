using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Colorful;
using Figgle;

namespace PornHubCheck
{
	// Token: 0x02000003 RID: 3
	internal class Initialization
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002434 File Offset: 0x00000634
		public static void debuggerCheck()
		{
			for (;;)
			{
				Process[] processes = Process.GetProcesses();
				uint num = (uint)0;
				while (((num < (uint)processes.Length) ? 1u : 0u) != (uint)0)
				{
					object obj = processes[(int)num];
					uint num2;
					if ((obj.ToString().Contains("Fiddler") ? 1u : 0u) == (uint)0 && (obj.ToString().Contains("HTTPDebuggerSvc") ? 1u : 0u) == (uint)0)
					{
						num2 = (obj.ToString().Contains("Wireshark") ? 1u : 0u);
					}
					else
					{
						num2 = (uint)1;
					}
					if (num2 != (uint)0)
					{
						Environment.Exit(0);
					}
					num += (uint)1;
				}
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000024F0 File Offset: 0x000006F0
		public static void checkerMethod()
		{
			DateTime dateTime = default(DateTime);
			Program.startDateTime = DateTime.Now.ToString("MM.dd.yyyy H.mm");
			Colorful.Console.Title = "PornHubCheck | By SDS - cracked by dark#5000 | https://cto.d4rk.fr/";
			Colorful.Console.Title = "PornHubCheck | By SDS - cracked by dark#5000 | https://cto.d4rk.fr/";
			Initialization.mainMenu();
			string startDateTime = Program.startDateTime;
			if (startDateTime == null)
			{
			}
			if ((((Directory.Exists(startDateTime) ? 1u : 0u) == (uint)0) ? 1u : 0u) != (uint)0)
			{
				Directory.CreateDirectory(Program.startDateTime);
			}
			Module.__VMFUNCTION__5586();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002584 File Offset: 0x00000784
		public static void mainMenu()
		{
			int? num = null;
			Colorful.Console.Clear();
			FiggleFont rectangles = FiggleFonts.Rectangles;
			string text = rectangles.Render("PornHubCheck", null);
			string[] array = text.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.None);
			uint num2 = (uint)0;
			while (((num2 < (uint)array.Length) ? 1u : 0u) != (uint)0)
			{
				string text2 = (string)array[(int)num2];
				Colorful.Console.SetCursorPosition((int)(((uint)Colorful.Console.WindowWidth - (uint)text2.Length) / (uint)2), Colorful.Console.CursorTop);
				Colorful.Console.WriteLine(text2, Color.Coral);
				num2 += (uint)1;
			}
			string text3 = "[CODED BY SDS - CRACKED BY dark#5000]";
			string text4 = "[https://cto.d4rk.fr/]";
			Colorful.Console.SetCursorPosition((int)(((uint)Colorful.Console.WindowWidth - (uint)text3.Length) / (uint)2), Colorful.Console.CursorTop);
			Colorful.Console.WriteLine(text3, Color.Crimson);
			Colorful.Console.SetCursorPosition((int)(((uint)Colorful.Console.WindowWidth - (uint)text4.Length) / (uint)2), Colorful.Console.CursorTop);
			Colorful.Console.WriteLine(text4, Color.Crimson);
		}
	}
}
