using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Wesley.Infrastructure.Helpers
{
    public class Utils
    {
        // ���ε����ť֮��ĵ�������������1000����
        private static readonly int MIN_CLICK_DELAY_TIME = 1000;
        private static long lastClickTime;
        public static bool IsFastClick()
        {
            bool flag = false;
            long curClickTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            if ((curClickTime - lastClickTime) >= MIN_CLICK_DELAY_TIME)
            {
                flag = true;
            }
            lastClickTime = curClickTime;
            return flag;
        }
    }

    /// <summary>
    /// ������������
    /// </summary>
    public partial class CommonHelper
    {
        /// <summary>
        /// ��ʽ��json�ַ���
        /// </summary>
        /// <param name="sourJsonStr"></param>
        /// <returns></returns>
        public static string FormatJsonStr(string sourJsonStr)
        {
            var serializer = new JsonSerializer();
            using (var tr = new StringReader(sourJsonStr))
            {
                using (var jtr = new JsonTextReader(tr))
                {
                    object obj = serializer.Deserialize(jtr);
                    return obj != null ? obj.ToString() : sourJsonStr;
                }
            }
        }


        public static string ConvetToSeconds(int duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
            string str = "";
            if (ts.Days > 0)
            {
                str = ts.Days.ToString() + "��" + ts.Hours.ToString() + "ʱ" + ts.Minutes.ToString() + "��" + ts.Seconds + "��";
            }
            else if (ts.Hours > 0)
            {
                str = ts.Hours.ToString() + "ʱ" + ts.Minutes.ToString() + "��" + ts.Seconds + "��";
            }
            else if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = ts.Minutes.ToString() + "��" + ts.Seconds + "��";
            }
            else if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = ts.Seconds + "��";
            }
            return str;
        }

        /// <summary>
        /// 166��189��199 ����
        /// </summary>
        /// <param name="str_handset"></param>
        /// <param name="stand"></param>
        /// <returns></returns>
        public static bool IsPhoneNo(string str_handset, bool stand)
        {
            if (stand)
            {
                return Regex.IsMatch(str_handset, "^(0\\d{2,3}\\d{7,8}(\\d{3,5}){0,1})|(((19[0-9])|(18[0-9])|(16[0-9])|(13[0-9])|(15([0-3]|[5-9]))|(18[0-9])|(17[0-9])|(14[0-9]))\\d{8})$");
            }
            else
            {
                return Regex.IsMatch(str_handset, "^(0\\d{2,3}-?\\d{7,8}(-\\d{3,5}){0,1})|(((19[0-9])|(18[0-9])|(16[0-9])|(13[0-9])|(15([0-3]|[5-9]))|(18[0-9])|(17[0-9])|(14[0-9]))\\d{8})$");
            }
        }

        /// <summary>
        /// �� Stream ת�� byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // ���õ�ǰ����λ��Ϊ���Ŀ�ʼ 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// �� byte[] ת�� Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }


        /// <summary>
        /// ��ȡʱ���
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time, int length = 13)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString().Substring(0, length);
        }
        /// <summary>  
        /// ��c# DateTimeʱ���ʽת��ΪUnixʱ�����ʽ  
        /// </summary>  
        /// <param name="time">ʱ��</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = System.TimeZoneInfo.ConvertTimeToUtc(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //��10000����Ϊ13λ      
            return t;
        }




        #region ���ɵ��ݺ�
        /// <summary>
        /// ���ɵ��ݺ�
        /// </summary>
        /// <param name="billType">��������</param>
        /// <param name="storeId">������id</param>
        /// <returns>����+7+12</returns>
        public static string GetBillNumber(string billType, int storeId)
        {
            string stamp = GetTimeStamp(DateTime.Now, 12);
            int realCount = 0;
            var str = storeId.ToString();
            //7λ�����̱�ţ�֧�ְ����
            if (str.Length > 7)
            {
                var start = int.Parse(str.Substring(0, 7));
                var end = int.Parse(str.Substring(7, str.Length - 7));
                storeId = start + end;
            }
            var numArry = GetNumHash(storeId, ref realCount);
            int[] arry = new int[7];
            for (var i = 0; i < 7; i++)
            {
                if (realCount > i)
                {
                    arry[i] = numArry[i];
                }
                else
                {
                    arry[i] = 0;
                }
            }
            string billNumber = billType + "" + string.Join("", arry) + "" + stamp;
            return billNumber;
        }

        /// <summary>
        ///  ������ת����������
        /// </summary>
        /// <example>10 ת�� num[0]=1 num[1]=0 </example>
        /// <param name="showNumber">��������</param>
        /// <param name="realCount">���ص�ʵ�ʴ�С�������鳤��</param>
        /// <returns>��������</returns>
        public static int[] GetNumHash(int showNumber, ref int realCount)
        {
            int[] num_hash = new int[10];
            int index = 0;
            while (showNumber / 10 != 0)
            {
                num_hash[index] = (showNumber % 10);
                showNumber /= 10;
                index++;
            }
            num_hash[index] = showNumber;
            realCount = index + 1;
            return num_hash;
        }

        #endregion


        /// <summary>
        /// ��ȡö������
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            try
            {
                string value = enumValue.ToString();
                FieldInfo field = enumValue.GetType().GetField(value);
                //��ȡ��������
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //����������û��ʱ��ֱ�ӷ�������
                if (objs == null || objs.Length == 0)
                {
                    return value;
                }

                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
                return descriptionAttribute.Description;
            }
            catch (Exception)
            {
                return enumValue.ToString();
            }
        }


        /// ��ȡö������(����֧��)
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription<TEnum>(TEnum enumValue)
        {
            try
            {
                string value = enumValue.ToString();
                FieldInfo field = enumValue.GetType().GetField(value);
                //��ȡ��������
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //����������û��ʱ��ֱ�ӷ�������
                if (objs == null || objs.Length == 0)
                {
                    return value;
                }

                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
                return descriptionAttribute.Description;
            }
            catch (Exception)
            {
                return enumValue.ToString();
            }
        }

        /// <summary>
        /// ��ȡö������(����֧��)
        /// </summary>
        /// <typeparam name="TEnum">ö��</typeparam>
        /// <param name="i">ö�پ���ֵ</param>
        /// <returns></returns>
        public static string GetEnumDescription<TEnum>(int i)
        {
            try
            {
                foreach (var item in Enum.GetValues(typeof(TEnum)))
                {
                    if ((int)item == i)
                    {
                        return GetEnumDescription<TEnum>((TEnum)item);
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }


        ///// <summary>
        ///// ��ȡ��С��λת��
        ///// </summary>
        ///// <param name="bigUnitIdint">��λ</param>
        ///// <param name="strokeUnitId">�е�λ</param>
        ///// <param name="smallUnitId">С��λ</param>
        ///// <param name="bigQuantity">��תС����</param>
        ///// <param name="strokeQuantity">��תС����</param>
        ///// <param name="thisUnitId">��ǰ��λ</param>
        ///// <returns></returns>
        //public static int GetSmallConversionQuantity(int bigUnitId, int strokeUnitId, int smallUnitId, int bigQuantity, int strokeQuantity, int thisUnitId)
        //{
        //    int result;
        //    //��
        //    if (thisUnitId == bigUnitId)
        //    {
        //        result = bigQuantity;
        //    }
        //    else
        //    {
        //        //��
        //        if (thisUnitId == strokeQuantity)
        //        {
        //            result = strokeQuantity;
        //        }
        //        //С
        //        else
        //        {
        //            result = 1;
        //        }
        //    }

        //    if (result == 0)
        //    {
        //        result = 1;
        //    }
        //    return result;
        //}


        /// <summary>
        /// �����������ĸ�����
        /// </summary>
        /// <param name="IntStr">���ɳ���</param>
        /// <returns></returns>
        public static string GenerateStrchar(int Length)
        {
            return Str_char(Length, false);
        }

        /// <summary>
        /// �����������ĸ�����
        /// </summary>
        /// <param name="Length">���ɳ���</param>
        /// <param name="Sleep">�Ƿ�Ҫ������ǰ����ǰ�߳���ֹ�Ա����ظ�</param>
        /// <returns></returns>
        public static string Str_char(int Length, bool Sleep)
        {
            if (Sleep)
            {
                System.Threading.Thread.Sleep(3);
            }

            char[] Pattern = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }

        /// <summary>
        /// ���ַ�����ָ��λ�ÿ�ʼ��ȡ���ַ�����β���˷���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str.Replace(" ", "").Trim(), startIndex, str.Length);
        }

        /// <summary>
        /// ���ַ�����ָ��λ�ý�ȡָ�����ȵ����ַ���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <param name="length">���ַ����ĳ���</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length *= -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex -= length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length += startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if (str.Length - startIndex < length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }


    }

    public static class TypeExtensions
    {
        // The Trim method only trims 0x0009, 0x000a, 0x000b, 0x000c, 0x000d, 0x0085, 0x2028, and 0x2029.
        // This array adds in control characters.
        public static readonly char[] WhiteSpaceChars = new char[] { (char)0x00, (char)0x01, (char)0x02, (char)0x03, (char)0x04, (char)0x05,
            (char)0x06, (char)0x07, (char)0x08, (char)0x09, (char)0x0a, (char)0x0b, (char)0x0c, (char)0x0d, (char)0x0e, (char)0x0f,
            (char)0x10, (char)0x11, (char)0x12, (char)0x13, (char)0x14, (char)0x15, (char)0x16, (char)0x17, (char)0x18, (char)0x19, (char)0x20,
            (char)0x1a, (char)0x1b, (char)0x1c, (char)0x1d, (char)0x1e, (char)0x1f, (char)0x7f, (char)0x85, (char)0x2028, (char)0x2029 };

        /// <summary> 
        /// Gets a value that indicates whether or not the collection is empty. 
        /// </summary> 
        public static bool IsNullOrBlank(this string s)
        {
            if (s == null || s.Trim(WhiteSpaceChars).Length == 0)
            {
                return true;
            }

            return false;
        }

        public static bool NotNullOrBlank(this string s)
        {
            if (s == null || s.Trim(WhiteSpaceChars).Length == 0)
            {
                return false;
            }

            return true;
        }
    }

    public class ToolsClass
    {
        /// <summary>
        /// �ж�һ���ַ����Ƿ�Ϊurl
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
