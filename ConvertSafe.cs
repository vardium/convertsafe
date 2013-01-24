using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Reflection;

namespace Ipucu.Utility
{
    [Serializable]
    public abstract class ConvertSafe
    {
        public static T ToGeneric<T>(object o) { return ToGeneric(o, default(T)); }
        public static T ToGeneric<T>(object o, T defaultValue)
        {
            if (o == null) { return defaultValue; }

            try { return (T)o; }
            catch { }

            Type genericType = typeof(T);
            MethodInfo tryParseMethod = genericType.GetMethod("TryParse", new[] { typeof(string), genericType.MakeByRefType() });

            if (tryParseMethod != null)
            {
                T retVal = defaultValue;
                object[] args = new object[] { o.ToString(), retVal };

                ParameterModifier modifiers = new ParameterModifier(2);
                modifiers[1] = true;  // ref

                if ((bool)genericType.InvokeMember("TryParse", BindingFlags.InvokeMethod, null, null, args, new[] { modifiers }, null, null))
                {
                    retVal = (T)args[1];
                }

                return retVal;
            }

            if (genericType.IsEnum)
            {
                try { return (T)Enum.Parse(genericType, o.ToString(), true); }
                catch {  }
            }

            return defaultValue;
        }

        public static short ToShort(object obj) { return ToShort(obj, 0); }
        public static short ToShort(object obj, short defaultValue) { return ToGeneric(obj, defaultValue); }

        public static int ToInt(object obj) { return ToInt(obj, 0); }
        public static int ToInt(object obj, int defaultValue) { return ToGeneric(obj, defaultValue); }

        public static long ToLong(object obj) { return ToShort(obj, 0); }
        public static long ToLong(object obj, long defaultValue) { return ToGeneric(obj, defaultValue); }

        public static Int16 ToInt16(object obj) { return ToInt16(obj, 0); }
        public static Int16 ToInt16(object obj, Int16 defaultValue) { return ToGeneric(obj, defaultValue); }

        public static Int32 ToInt32(object obj) { return ToInt32(obj, 0); }
        public static Int32 ToInt32(object obj, Int32 defaultValue) { return ToGeneric(obj, defaultValue); }

        public static Int64 ToInt64(object obj) { return ToInt64(obj, 0); }
        public static Int64 ToInt64(object obj, Int64 defaultValue) { return ToGeneric(obj, defaultValue); }

        public static decimal ToDecimal(object obj) { return ToDecimal(obj, 0); }
        public static decimal ToDecimal(object obj, decimal defaultValue) { return ToGeneric(obj, defaultValue); }

        public static double ToDouble(object obj) { return ToDouble(obj, 0); }
        public static double ToDouble(object obj, double defaultValue) { return ToGeneric(obj, defaultValue); }

        public static bool ToBoolean(object obj) { return ToBoolean(obj, false); }
        public static bool ToBoolean(object obj, bool defaultValue) { return ToGeneric(obj, defaultValue); }

    }
}
