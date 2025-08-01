using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AGL.Api.ApplicationCore.Utilities
{
    public static class Util
    {
        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
        public static Type GetEnumType(string enumName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(enumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }
            return null;
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string GetFromToDt(DateTime? from, DateTime? to)
        {
            var ret = "";

            ret = (from == null ? "" : from.Value.ToString("yyyy-MM-dd"));

            if(from!=null && to!=null)
                ret = $"{ret} ~ ";

            ret = $"{ret}{(to == null ? "" : to.Value.ToString("yyyy-MM-dd"))}";

            return ret;
        }

        public static string ToPrice(object prc)
        {
            if (prc == null) return "";
            if (prc is Int32)
            {
                return ((Int32)prc).ToString("N0");
            }
            else if (prc is Int64)
            {
                return ((Int64)prc).ToString("N0");
            }
            else
            {
                Int64 n = 0;
                try
                {
                    string s = prc.ToString();
                    int pos = s.LastIndexOf('.');
                    if (pos == -1)
                    {
                        s = Regex.Replace(s, "[^-0-9]", "");
                        n = Int64.Parse(s);
                        return n.ToString("N0");
                    }
                    else
                    {
                        var num = Int64.Parse(Regex.Replace(s.Substring(0, pos), "[^-0-9]", ""));
                        var frac = s.Substring(pos + 1);
                        if (string.IsNullOrEmpty(frac))
                        {
                            return num.ToString("N0");
                        }
                        else
                        {
                            return num.ToString("N0") + "." + frac;
                        }
                    }
                }
                catch { }
                return prc.ToString();
            }
        }


        public static string ToDecimalPrice(decimal? price, string currency="")
        {

            var _price = price ?? 0;
            var rst = "0";

            try
            {
                if (new string[] { "KRW", "JPY", "TWD", "" }.Contains(currency))
                    rst = _price % 1 == 0 ? _price.ToString("F0") : _price.ToString("F2");
                else
                    rst = _price.ToString("F2");
            }
            catch { }

            return rst;

        }


        public static string RSubSting(string Text, int TextLenth) {
            string ConvertText;
            if (Text.Length < TextLenth)
            {
                TextLenth = Text.Length;
            }
            ConvertText = Text.Substring(TextLenth, Text.Length - TextLenth);
            return ConvertText;
        }

        public static string addHyphen(string tel) {

            var retunStr = string.Empty;
            var t1 = string.Empty;
            var t2 = string.Empty;
            var t3 = string.Empty;

            tel = tel.Replace("-", "");

            if (tel.Length == 8)     //1588-xxxx
            {
                t1 = tel.Substring(0, 4);
                t2 = tel.Substring(4, 4);
                retunStr = t1 + "-" + t2;
            }
            else if (tel.Length == 9)    //02-xxx-xxxx
            {
                t1 = tel.Substring(0, 2);
                t2 = tel.Substring(2, 3);
                t3 = tel.Substring(5, 4);
                retunStr = t1 + "-" + t2 + "-" + t3;
            }
            else if (tel.Length == 10)
            {
                if (tel.Substring(0, 2) == "01")     //휴대전화 01x-xxx-xxxx
                {
                    t1 = tel.Substring(0, 3);
                    t2 = tel.Substring(3, 3);
                    t3 = tel.Substring(6, 4);
                    retunStr = t1 + "-" + t2 + "-" + t3;
                }
                else if (tel.Substring(0, 2) == "02")
                {
                    t1 = tel.Substring(0, 2);
                    t2 = tel.Substring(2, 4);
                    t3 = tel.Substring(6, 4);
                    retunStr = t1 + "-" + t2 + "-" + t3;
                }
                else
                {
                    t1 = tel.Substring(0, 3);
                    t2 = tel.Substring(3, 3);
                    t3 = tel.Substring(6, 4);
                    retunStr = t1 + "-" + t2 + "-" + t3;
                }
            }
            else if (tel.Length == 11)   //xxx-xxxx-xxxx(휴대전화,070)
            {
                t1 = tel.Substring(0, 3);
                t2 = tel.Substring(3, 4);
                t3 = tel.Substring(7, 4);
                retunStr = t1 + "-" + t2 + "-" + t3;
            }

            return retunStr;
        }

        public static string GetStrMark(string str, int len, string strMark)
        {
            var rst = string.Empty;


            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            
            var tmpStr = new string(chars);
            var iCnt = 1;

            foreach(var item in tmpStr)
            {
                

                rst += item.ToString();
                if (iCnt % len == 0 && iCnt!=tmpStr.Length)
                    rst += strMark;

                iCnt++;
            }


            char[] rstChars = rst.ToCharArray();
            Array.Reverse(rstChars);


            return new string(rstChars);


        }


        public static string DisplayK(int i)
        {
            string rst = string.Empty;

            if (i >= 1000)
            {
                rst = $"{(i / 1000).ToString("#,##0")}K";

            }
            else
                rst = i.ToString();


            return rst;

        }


        public static string DisplayComma(string str)
        {
            string rst = string.Empty;

            int i = 0;

            try
            {
                i = Convert.ToInt32(str);

            if (i >= 1000)
                {
                    rst = $"{i.ToString("#,##0")}";

                }
                else
                    rst = i.ToString();

            }
            catch { 
            }

            return rst;

        }



        public static bool SetIsMedia(string ext)
        {
            return new string[] { "mp4", "mov", "wmv", "webm", "mxf", "avi", "avchd", "hevc" }.Contains(ext.ToLower()) ? true : false;
        }


		public static DateTime? ConvertDateTime(string str)
		{
			DateTime? cDate = null;
			if (str == null)
			{
				return cDate;
			}

			if (str.Length == 8)
			{
				try
				{
					cDate = new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2)));
				}
				catch { }
			}
			else if (str.Length == 12)
			{
				try
				{
					cDate = new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2)),
						Convert.ToInt32(str.Substring(8, 2)), Convert.ToInt32(str.Substring(10, 2)), 0);
				}
				catch { }

			}
			else if (str.Length == 14)
			{
				try
				{
					cDate = new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2)),
						Convert.ToInt32(str.Substring(8, 2)), Convert.ToInt32(str.Substring(10, 2)), Convert.ToInt32(str.Substring(12, 2)));
				}
				catch { }

			}
			return cDate;
		}


        public static dynamic GetReader(DbDataReader reader, string column)
        {
            var iCol = reader.GetOrdinal(column);


			var isNull = reader.IsDBNull(iCol);

            switch(reader.GetFieldType(iCol).Name)
            {
                case "String":
                    return isNull ? "" : reader.GetString(reader.GetOrdinal(column));
				case "Decimal":
					return isNull ? Convert.ToDecimal(0) : reader.GetDecimal(reader.GetOrdinal(column));
				case "Int32":
					return isNull ? 0 : reader.GetInt32(reader.GetOrdinal(column));
                default:
                    return "";
			}


        }

        public static string RemoveCommas(string value)
        {
            return value.Replace(",", "");
        }



        /// <summary>
        /// 위도, 경도를 통한 거리(km) 계산
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <returns></returns>
        public static int GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371.0; // 지구의 반지름 (단위: km)

            // 위도와 경도를 라디안으로 변환합니다.
            double latRad1 = ToRadians(lat1);
            double lonRad1 = ToRadians(lon1);
            double latRad2 = ToRadians(lat2);
            double lonRad2 = ToRadians(lon2);

            // 위도와 경도의 차이를 계산합니다.
            double dLat = latRad2 - latRad1;
            double dLon = lonRad2 - lonRad1;

            // 하버사인 공식을 적용합니다.
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(latRad1) * Math.Cos(latRad2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // 거리를 계산합니다.
            double distance = Math.Truncate(R * c);

            return  Convert.ToInt32(distance);
        }

        public static double ToRadians(double angle)
        {
            return angle * Math.PI / 180.0;
        }
        public static string GetMinute(string strTime)

        {
            // "0600" 문자열을 "HHmm" 형식으로 변환
            TimeSpan time = TimeSpan.ParseExact(strTime, "hhmm", null);

            
            int totalMinutes = (int)time.TotalMinutes;
            return totalMinutes.ToString();

		}


        public static string UfnDayKindReturn(int dayKind)
        {
            string dayKindList = string.Empty;
            string dayKind1 = null;
            string dayKind2 = null;
            string dayKind3 = null;
            string dayKind4 = null;
            string dayKind5 = null;
            string dayKind6 = null;
            string dayKind7 = null;

            if (dayKind == 0)
                return "0";

            if (dayKind % 2 == 1)
            {
                dayKind -= 1;
                dayKind1 = "1"; // 일
            }

            if (dayKind >= 64)
            {
                dayKind -= 64;
                dayKind7 = "7"; // 토
            }

            if (dayKind >= 32)
            {
                dayKind -= 32;
                dayKind6 = "6"; // 금
            }

            if (dayKind >= 16)
            {
                dayKind -= 16;
                dayKind5 = "5"; // 목
            }

            if (dayKind >= 8)
            {
                dayKind -= 8;
                dayKind4 = "4"; // 수
            }

            if (dayKind >= 4)
            {
                dayKind -= 4;
                dayKind3 = "3"; // 화
            }

            if (dayKind >= 2)
            {
                dayKind -= 2;
                dayKind2 = "2"; // 월
            }

            dayKindList = (dayKind1 ?? string.Empty) +
                          (dayKind2 ?? string.Empty) +
                          (dayKind3 ?? string.Empty) +
                          (dayKind4 ?? string.Empty) +
                          (dayKind5 ?? string.Empty) +
                          (dayKind6 ?? string.Empty) +
                          (dayKind7 ?? string.Empty);

            return dayKindList;
        }

        public static string ToDecimalPriceComma(decimal? price, string currency = "")
        {

            var _price = price ?? 0;
            var rst = "0";

            try
            {
                if (new string[] { "KRW", "JPY", "TWD", "" }.Contains(currency))
                    rst = _price % 1 == 0 ? _price.ToString("N0") : _price.ToString("N2");
                else
                    rst = _price.ToString("N2");
            }
            catch { }

            return rst;

        }


        public static string ToDecimalPriceString(decimal? price, string currency = "")
		    {
			    var _price = price ?? 0m;

			    // 소수점 표시 여부에 따라 포맷 지정
			    bool noDecimals = new[] { "KRW", "JPY", "TWD", "" }.Contains(currency) && _price % 1 == 0;
			    string format = noDecimals ? "#,##0" : "#,##0.00";

			    // CultureInfo를 지정하면 천 단위 구분자(,) 등을 지역별로 자동 처리합니다.
			    // 여기서는 invariant 문화권을 쓰고, 필요하면 CultureInfo.GetCultureInfo("ko-KR") 같은 식으로 변경하세요.
			    return _price.ToString(format, CultureInfo.InvariantCulture);
		    }


        public static decimal SetDecimal(decimal inputVal, string currency)
        {
            return currency switch
            {
                "USD" or "EUR" or "SGD" or "GBP"
                    => Math.Round(inputVal * 1.00m, 0, MidpointRounding.AwayFromZero),
                "KRW" => Math.Floor(inputVal / 100) * 100,
                "JPY" => Math.Floor(inputVal / 10) * 10,
                _ => Math.Floor(inputVal),
            };
        }
    }

}
