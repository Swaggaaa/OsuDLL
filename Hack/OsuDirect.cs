using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using ClassLibrary2.osu_common.Helpers;
using Fasterflect;

namespace ClassLibrary2.Hack
{
    class OsuDirect
    {
        public static Dictionary<string, HookManager> HookDictionary = new Dictionary<string, HookManager>();

        private static HttpWebRequest CreateWebRequest(object sender)
        {
            //Console.WriteLine(sender.GetType());
            try
            {

                var url = (string)sender
                    .GetFieldValue(pWebRequest.Fields.Url, Flags.AllMembers);

                if (url.StartsWith(@"https://osu.ppy.sh/d/"))
                {
                    Console.WriteLine("Starts with: {0}", url);
                    int pos = url.IndexOf("?u");
                    url = url.Substring(0, pos);
                    url = url.Replace("https://osu.ppy.sh/d", @"https://m.zxq.co");
                    url += ".osz";
                    Console.WriteLine("{0}", url);
                    sender
                    .SetFieldValue(pWebRequest.Fields.Url, url, Flags.AllMembers);
                    return WebRequest.Create(url) as HttpWebRequest;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return (HttpWebRequest)HookDictionary["pWebRequest.CreateWebRequest"].CallOriginal(sender);
        }

        private static void BullShit(object sender)
        {
            Console.WriteLine("Go fuck yourself bullshit function");
            return;
        }

        public static void Init()
        {
            HookDictionary["pWebRequest.CreateWebRequest"] = new HookManager(pWebRequest.CreateWebRequest, ((Func<object, HttpWebRequest>)CreateWebRequest).Method);
            HookDictionary["pWebRequest.BullShit"] = new HookManager(pWebRequest.Bullshit, ((Action<object>)BullShit).Method);

            foreach (var hookManager in HookDictionary)
            {
                Console.WriteLine("Installing hook on " + hookManager.Key);
                hookManager.Value.Install();
            }
        }
    }
}
