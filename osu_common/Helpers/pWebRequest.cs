using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using Fasterflect;

namespace ClassLibrary2.osu_common.Helpers
{
    class pWebRequest
    {
        public const String ClassName = "\u0023\u003DqDr7OatPrwqpqI9ORGby5yftBGlGIxKhODo3Q1KgYlzM\u003D"; // search for HttpWebReqest

        public struct Fields
        {
            public const String Url = "\u0023\u003DqRTli6_850v4LcQU47lP4dA\u003D\u003D"; //Line 28
        }
        public struct Methods
        {
            public const String CreateWebRequest = "\u0023\u003Dq25Ga6YlrG4b40hmuEv9BtoyU36neywp2Cp\u0024nFYQgjos\u003D";
            public const String BullShit = "\u0023\u003Dqlwizoz9oRRLiNVaIAA5ju5Sh\u00242LgfRzvMxAjJiBgseA\u003D"; //Line 414
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

        public static MethodInfo CreateWebRequest = Type.Method(Methods.CreateWebRequest);
        public static MethodInfo Bullshit = Type.Method(Methods.BullShit);

    }
}
