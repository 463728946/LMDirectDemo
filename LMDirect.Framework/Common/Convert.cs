using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Framework.Common
{
    public static class Converter
    {
        public static string ToHex(this object obj)
        {
            if (obj == null)
                return null;

            if (obj.GetType().Equals(typeof(byte)))
                return ((byte)obj).ToString("X2");

            if (obj.GetType().Equals(typeof(byte[])))
                return ToHex((byte[])obj);

            return obj.ToString();
        }

        public static string ToHex(this byte[] bytes)
        {
            if (bytes == null)
                return null;
            var str = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                str += bytes[i].ToString("X2");
            }
            return str;
        }

        public static DateTime ToDateTime(this byte[] bytes)
        {
            var hex = ToHex(bytes);
            var seconds = Convert.ToInt32(hex, 16);
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(seconds);
        }

        public static byte[] ToBytes(this string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static byte[] ToBytes(this DateTime dt)
        {
            return BitConverter.GetBytes(dt.Ticks);
        }
    }

    //private T2 Converts<T, T2>(T source, T2 target)
    //{
    //    if (target == null)
    //        target = Activator.CreateInstance<T2>();

    //    Type t = source.GetType();
    //    var ass = Assembly.GetAssembly(t);
    //    var propertysPropertyInfos = t.GetProperties();
    //    foreach (PropertyInfo item in propertysPropertyInfos)
    //    {
    //        try
    //        {
    //            var name = item.Name;
    //            var type = item.PropertyType;
    //            object value = item.GetValue(source, null);

    //            if (ass.ExportedTypes.Any(x => x == type) && value != null)
    //                Converts(value, target);

    //            var field = target.GetType().GetProperty(name);
    //            if (field != null)
    //            {
    //                var newValue = new object();
    //                var targetTypeFullName = field.PropertyType.FullName;
    //                if (targetTypeFullName == type.FullName)
    //                {
    //                    newValue = value;
    //                }
    //                else
    //                {
    //                    var hex = Converter.ObjectToHex(value);
    //                    if (targetTypeFullName == typeof(string).FullName)
    //                    {
    //                        newValue = hex;
    //                    }
    //                    else if (targetTypeFullName == typeof(bool).FullName)
    //                    {
    //                        newValue = Convert.ToBoolean(hex);
    //                    }
    //                    else if (targetTypeFullName == typeof(DateTime).FullName)
    //                    {
    //                        newValue = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToInt32(hex, 16));

    //                    }
    //                    else if (targetTypeFullName == typeof(double).FullName || targetTypeFullName == typeof(int).FullName)
    //                    {
    //                        newValue = Convert.ToInt32(hex, 16);
    //                    }
    //                    else
    //                    {
    //                        newValue = value;
    //                    }
    //                }
    //                field.SetValue(target, newValue);


    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e);
    //            throw;
    //        }

    //    }
    //    return target;
    //}





}
