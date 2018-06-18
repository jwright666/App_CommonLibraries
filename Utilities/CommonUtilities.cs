using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Utilities
{
    /// <summary>
    /// Created by jwright Jan 4, 2011
    /// 
    /// this class is utilities like string format, datatime format and etc.
    /// </summary>
    public class CommonUtilities
    {
        public static String FormatString(string stringToFormat)
        {
            string retValue = "";
            try
            {
                if (stringToFormat != null)
                {
                    retValue = stringToFormat.Replace("'", "''");
                }
            }
            catch (Exception ex) { throw ex; }

            return retValue;
        }

        #region Date Utilities
        public static string ConvertDateAndTimeForSQLPurpose(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string hour = date.Hour.ToString();
            string min = date.Minute.ToString();
            string sec = date.Second.ToString();
            string tempdate = "";
            tempdate = year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec;
            return tempdate;
        }

        public static string ConvertDateForSQLPurpose(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string tempdate = "";
            tempdate = year + "-" + month + "-" + day;
            return tempdate;
        }

        public static string ConvertDateAndTimeWithZeroSecForSQLPurpose(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string hour = date.Hour.ToString();
            string min = date.Minute.ToString();
            string sec = date.Second.ToString();
            string tempdate = "";
            tempdate = year + "-" + month + "-" + day + " " + hour + ":" + min + ":00";
            return tempdate;
        }

        //20130503 - Gerry added method to get sql smalldatetime minimum value
        //reason some sql table fields are smalldatetime datatype range(January 1, 1900 to June 6, 2079)
        public static DateTime GetSQLDateTimeMinimumValue()
        {
            return new DateTime(1900, 1, 1, 0, 0, 0); // January 1, 1900 00:00:00
        }
        //20130503 - Gerry added method to get sql smalldatetime maximum value  
        //reason some sql table fields are smalldatetime datatype
        //this can be use in search  end  criteria
        public static DateTime GetSQLDateTimeMaximumValue()
        {
            return new DateTime(2079, 6, 6, 0, 0, 0); // June 6, 2079 00:00:00
        }
        #endregion

        #region ConvertNumbersToWords
        public string ShowNumbersInWords(string numb, bool isCurrency, string currencyName, int decimalDigits, string decimalSeparator)
        {
            numb = decimal.Round(decimal.Parse(numb), decimalDigits).ToString();
            string val = "",
                wholeNo = numb,
                points = "",
                andStr = "",
                pointStr = "",
                endStr = (isCurrency) ? ("Only") : ("");

            try
            {
                int decimalPlace = numb.IndexOf(decimalSeparator);
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace).ToString();
                    points = numb.Substring(decimalPlace + 1);
                    if (points.Length == 1) { points += "0"; }
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? (" and") : (" point"); // just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                        pointStr = TranslateCents(points);
                    }
                }
                string tempWholeNum = ConvertWholeNumbers(wholeNo);
                val = String.Format("{0} {1}{2} {3}",
                                    tempWholeNum,
                                    tempWholeNum.Equals(string.Empty) ? "" : (currencyName + andStr).ToString(),
                                    pointStr,
                                    endStr);
            }

            catch {; }

            return val;
        }

        private string ConvertWholeNumbers(string number)
        {
            string word = "";
            //number = decimal.Parse(number).ToString();
            try
            {
                bool beginsZero = false; //tests for 0XX
                bool isDone = false;     //test if already translated
                double dblAmt = (Convert.ToDouble(number));

                if (dblAmt > 0)
                {
                    //test for zero or digit zero in a numeric
                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;
                    int pos = 0; //store digit grouping

                    string place = "";  //digit grouping name:hundres,thousand,etc...

                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = Ones(number);
                            isDone = true;
                            break;

                        case 2://tens' range
                            word = Tens(number);
                            isDone = true;
                            break;

                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = number[0].ToString().Equals("0") ? " " : " Hundred ";
                            break;

                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;

                        case 7://millions' range
                        case 8:
                        case 9:
                        case 10:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;

                        case 11://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;

                        //add extra case options for anything above Billion...

                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        word = ConvertWholeNumbers(number.Substring(0, pos)) + place + ConvertWholeNumbers(number.Substring(pos));
                        //check for trailing zeros
                        //if (beginsZero)
                        //{
                        //    word = " and " + word.Trim();
                        //}
                    }

                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }

            catch {; }

            return word.Trim();
        }

        private string Tens(string digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;

                case 11:
                    name = "Eleven";
                    break;

                case 12:
                    name = "Twelve";
                    break;

                case 13:
                    name = "Thirteen";
                    break;

                case 14:
                    name = "Fourteen";
                    break;

                case 15:
                    name = "Fifteen";
                    break;

                case 16:
                    name = "Sixteen";
                    break;

                case 17:
                    name = "Seventeen";
                    break;

                case 18:
                    name = "Eighteen";
                    break;

                case 19:
                    name = "Nineteen";
                    break;

                case 20:
                    name = "Twenty";
                    break;

                case 30:
                    name = "Thirty";
                    break;

                case 40:
                    name = "Fourty";
                    break;

                case 50:
                    name = "Fifty";
                    break;

                case 60:
                    name = "Sixty";
                    break;

                case 70:
                    name = "Seventy";
                    break;

                case 80:
                    name = "Eighty";
                    break;

                case 90:
                    name = "Ninety";
                    break;

                default:
                    if (digt > 0)
                    {
                        name = Tens(digit.Substring(0, 1) + "0") + " " + Ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private string Ones(string digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;

                case 2:
                    name = "Two";
                    break;

                case 3:
                    name = "Three";
                    break;

                case 4:
                    name = "Four";
                    break;

                case 5:
                    name = "Five";
                    break;

                case 6:
                    name = "Six";
                    break;

                case 7:
                    name = "Seven";
                    break;

                case 8:
                    name = "Eight";
                    break;

                case 9:
                    name = "Nine";
                    break;

            }
            return name;
        }

        private string TranslateCents(string cents)
        {
            String cts = "", digit = "", engOne = "";

            //for (int i = 0; i < cents.Length; i++)
            //{
            digit = cents[0].ToString();
            if (cents[0].Equals("0") && !cents[1].Equals("0"))
                engOne = Ones(cents.TrimStart('0'));//"Zero";

            else
                engOne = Tens(cents);//Ones(digit);//ConvertWholeNumbers(cents);

            cts += " " + engOne;
            //}
            return cts;
        }
        #endregion
    }
}
