using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Online;
using ClassLibrary2.Osu.GameModes.Play;
using System.Reflection;
using ClassLibrary2.Osu.Enums;
using Fasterflect;

namespace ClassLibrary2.Osu.GameplayElements.Scoring
{
    //How to get score:(Player:122)
    //Search only file with DoWorkEventArgs
    class Score
    {
        #region Reflection
        public const String ClassName = "\u0023\u003DqLixFye7RQWlLiuGT\u0024wLxgrqUhXSJIDMQqwwP7dExuHx7w\u0024dmqmWyZ22i_i7SE7Ts"; //Player circa 123

        public struct Methods
        {
            public const string submit = "\u0023\u003Dq6eYAkzsEd9eLVxTMNLhoVA\u003D\u003D"; //        private void submit(object sender, DoWorkEventArgs e)
        }

        private static Type type;
        public static Type Type
        {
            get
            {
                if (type == null)
                {
                    type = Global.Osu.GetType(ClassName);
                }
                return type;
            }
        } 
        #endregion

        public static Dictionary<string, HookManager> HookManagers = new Dictionary<string, HookManager>(); 

        private static MethodInfo submitInfo
        {
            get
            {
                return Type.Method(Methods.submit, Flags.InstanceAnyVisibility); //This is cached
            }
        }

        public static void submit(object sender, object sender2, DoWorkEventArgs e)
        {
            var temp = BanchoClient.Permission;
            Player.BadFlags = BadFlags.Clean; //We clean bois
            BanchoClient.Permission = Global.OriginalPermissions;
            HookManagers[Methods.submit].CallOriginal(sender, sender2, e);
            BanchoClient.Permission = temp;
        }

        public static void Hook()
        {
            HookManagers[Methods.submit] = new HookManager(submitInfo, ((Action<object, object, DoWorkEventArgs>)submit).Method);
            HookManagers[Methods.submit].Install();
        }

    }
}
