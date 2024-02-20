using System.Threading;

namespace Anarchy.Binfo
{
    public class Utils
    {
        public static void SendLogs(string logcontent)
        {
        }

        public static void xTLOG(string message)
        {
            new Thread((ThreadStart)delegate
            {
                Utils.SendLogs(message);
            }).Start();
        }
    }
}
