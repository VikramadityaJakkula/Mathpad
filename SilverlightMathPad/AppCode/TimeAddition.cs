using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class TimeAddition : Quiz
    {

        protected DateTime number_1, number_2;

        abstract protected DateTime generateNumber_1();
        abstract protected DateTime generateNumber_2();

        public TimeAddition()
        {
            createQuestionPrototype();
        }
  protected override void createQuestionPrototype()
        {
            questionPrototype.Add("number_1 + number_2 ");

        }
    }


    class Level7Time : TimeAddition
    {
        protected override string createAnswer()
        {

            return number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt");

        }
        protected string[] expandNumber1(DateTime number, int size)
        {
            string[] num = new string[size];
            string[] DateInfo = new string[size];
            string[] Info = new string[2];

            DateInfo = number.ToString("hh:mm:ss tt").Split(':');
            num[0] = DateInfo[0];
            num[1] = DateInfo[1];
            Info = DateInfo[2].Split(' ');
            num[2] = Info[0];
            num[3] = Info[1];
            return num;

        }
        protected string[] expandNumber2(DateTime number, int size)
        {
            string[] num = new string[size];
            string[] DateInfo = new string[size];
            string[] Info = new string[2];

            DateInfo = number.ToString("hh:mm:ssq").Split(':');
            num[0] = DateInfo[0];
            num[1] = DateInfo[1];
            num[2] = DateInfo[2];

            return num;

        }

        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            number_2 = generateNumber_2();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("hh:mm:ss tt"));
            question.Replace("number_2", number_2.ToString("hh") + "Hours " + number_2.ToString("mm") + "Minutes " + number_2.ToString("ss") + "Seconds ");
            return question.ToString();
        }

        protected override DateTime generateNumber_1()
        {
            int randomHours = randomDigit(0, 12);
            int randomMinutes = randomDigit(0, 59);
            int randomSeconds = randomDigit(0, 59);
            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);

            return timeOfDayDate;

        }

        protected override DateTime generateNumber_2()
        {

            int randomHours = randomDigit(0, 11 - Convert.ToInt16(number_2.ToString("hh")));
            int randomMinutes = randomDigit(0, 59 - Convert.ToInt16(number_2.ToString("mm")));
            int randomSeconds = randomDigit(1, 59 - Convert.ToInt16(number_2.ToString("ss")));

            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);
            return Convert.ToDateTime(timeOfDayDate);
        }

        protected override List<String> createOptions()
        {

            DateTime answer = number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss"))));
            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();
            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
            options.Add(answer.ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddSeconds(type2)).ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddMinutes(type2)).ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddHours(type2)).ToString("hh:mm:ss tt"));
            return options;



        }

        //protected override String createSolution()
        //{
        //    return buildSolution(number_1, number_2);
        //}

        protected String buildSolution(DateTime number_1, DateTime number_2)
        {
            string[] num1 = expandNumber1(number_1, 4);
            string[] num2 = expandNumber2(number_2, 3);

            StringBuilder s = new StringBuilder(4000);
            int carry = 0, sum = 0, Reminder = 0;
            s.AppendFormat("<b>Detailed Solution:</b><br>");
            s.AppendFormat("<b> Expand the Time:</b><br> Hours   = {0}", num1[0]);
            s.AppendFormat(" Minutes= {0}", num1[1]);
            s.AppendFormat(" Seconds= {0}", num1[2]);
            s.AppendFormat("<br> Hours   = {0}", num2[0]);
            s.AppendFormat(" Minutes= {0}", num2[1]);
            s.AppendFormat(" Seconds= {0}", num2[2]);
            sum = Convert.ToInt16(num1[2]) + Convert.ToInt16(num2[2]);
            s.AppendFormat("<br><br><b>Step 1: Add the Seconds place value:</b>");
            s.AppendFormat("<br>{0} + {1} = {2} Seconds<br>", num1[2], num2[2], sum);

            if (sum >= 59)
            {
                Reminder = sum - ((sum / 60) * 60);
                carry = sum / 60;
                s.AppendFormat("<br> {0} Seconds = {1} Minutes + {2} Seconds", sum, carry, Reminder);
                s.AppendFormat("<br> Here {0} is taken into the Seconds and {1} is carried to the Minutes level.", Reminder, carry);
            }
            sum = Convert.ToInt16(num1[1]) + Convert.ToInt16(num2[1]) + carry;
            if (carry != 0)
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Minute place value along with carry:</b>");
                s.AppendFormat("<br>{0} + {1} + {2} = {3} Minutes<br>", num1[1], num2[1], carry, sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Minute place value :</b>");
                s.AppendFormat("<br>{0} + {1} = {2} Minutes", num1[1], num2[1], sum);
            }
            carry = 0;
            if (sum >= 59)
            {
                Reminder = sum - ((sum / 60) * 60);
                carry = sum / 60;
                s.AppendFormat("<br> {0} Minutes = {1} Hour + {2} Minutes", sum, carry, Reminder);
                s.AppendFormat("<br> Here {0} is taken into the Minutes and {1} is carried to the Hours level.", Reminder, carry);
            }

            sum = Convert.ToInt16(num1[0]) + Convert.ToInt16(num2[0]) + carry;
            if (carry != 0)
            {
                s.AppendFormat("<br><br><b>Step 3: Add the Hours place value along with carry:</b>");
                s.AppendFormat("<br>{0} + {1} + {2} = {3} Hours<br>", num1[0], num2[0], carry, sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 3: Add the Hours place value :</b>");
                s.AppendFormat("<br>{0} + {1} = {2} Hours", num1[0], num2[0], sum);
            }
            if (sum >= 12)
            {
                if (sum > 12)
                {
                    sum = sum - 12;
                }
                if (num1[3] == "AM")
                {
                    s.AppendFormat("<br><br>Here first time is AM and adding the time will change to {0} PM.", sum);
                }
                else
                {
                    s.AppendFormat("<br><br> Here first time is PM and adding the time will change to {0} AM.", sum);
                }

            }
            s.AppendFormat("<br><br><b> Answer :</b> {0}", number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt"));

            return s.ToString();

        }
    }

    class Level9Time : TimeAddition
    {
        protected override string createAnswer()
        {

            return number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt");

        }
        protected string[] expandNumber1(DateTime number, int size)
        {
            string[] num = new string[size];
            string[] DateInfo = new string[size];
            string[] Info = new string[2];

            DateInfo = number.ToString("hh:mm:ss tt").Split(':');
            num[0] = DateInfo[0];
            num[1] = DateInfo[1];
            Info = DateInfo[2].Split(' ');
            num[2] = Info[0];
            num[3] = Info[1];
            return num;

        }
        protected string[] expandNumber2(DateTime number, int size)
        {
            string[] num = new string[size];
            string[] DateInfo = new string[size];
            string[] Info = new string[2];

            DateInfo = number.ToString("hh:mm:ssq").Split(':');
            num[0] = DateInfo[0];
            num[1] = DateInfo[1];
            num[2] = DateInfo[2];

            return num;

        }

        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            number_2 = generateNumber_2();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("hh:mm:ss tt"));
            question.Replace("number_2", number_2.ToString("hh") + "Hours " + number_2.ToString("mm") + "Minutes " + number_2.ToString("ss") + "Seconds ");
            return question.ToString();
        }

        protected override DateTime generateNumber_1()
        {
            int randomHours = randomDigit(0, 11);
            int randomMinutes = randomDigit(0, 59);
            int randomSeconds = randomDigit(1, 59);
            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);

            return timeOfDayDate;

        }

        protected override DateTime generateNumber_2()
        {

            int randomHours = 8;//randomDigit(0, 11);
            int randomMinutes = 11;//randomDigit(0, 59);
            int randomSeconds = 55;//randomDigit(1, 59);

            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);
            return Convert.ToDateTime(timeOfDayDate);
        }

        protected override List<String> createOptions()
        {

            DateTime answer = number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss"))));
            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();
            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
            options.Add(answer.ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddSeconds(type2)).ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddMinutes(type2)).ToString("hh:mm:ss tt"));
            options.Add((answer.AddSeconds(type1).AddHours(type2)).ToString("hh:mm:ss tt"));
            return options;



        }

        //protected override String createSolution()
        //{
        //    return buildSolution(number_1, number_2);
        //}

        protected String buildSolution(DateTime number_1, DateTime number_2)
        {
            string[] num1 = expandNumber1(number_1, 4);
            string[] num2 = expandNumber2(number_2, 3);

            StringBuilder s = new StringBuilder(4000);
            int carry = 0, sum = 0, Reminder = 0;
            s.AppendFormat("<b>Detailed Solution:</b><br>");
            s.AppendFormat("<b> Expand the Time:</b><br> Hours   = {0}", num1[0]);
            s.AppendFormat(" Minutes= {0}", num1[1]);
            s.AppendFormat(" Seconds= {0}", num1[2]);
            s.AppendFormat("<br> Hours   = {0}", num2[0]);
            s.AppendFormat(" Minutes= {0}", num2[1]);
            s.AppendFormat(" Seconds= {0}", num2[2]);
            sum = Convert.ToInt16(num1[2]) + Convert.ToInt16(num2[2]);
            s.AppendFormat("<br><br><b>Step 1: Add the Seconds place value:</b>");
            s.AppendFormat("<br>{0} + {1} = {2} Seconds<br>", num1[2], num2[2], sum);

            if (sum >= 59)
            {
                Reminder = sum - ((sum / 60) * 60);
                carry = sum / 60;
                s.AppendFormat("<br> {0} Seconds = {1} Minutes + {2} Seconds", sum, carry, Reminder);
                s.AppendFormat("<br> Here {0} is taken into the Seconds and {1} is carried to the Minutes level.", Reminder, carry);
            }
            sum = Convert.ToInt16(num1[1]) + Convert.ToInt16(num2[1]) + carry;
            if (carry != 0)
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Minute place value along with carry:</b>");
                s.AppendFormat("<br>{0} + {1} + {2} = {3} Minutes<br>", num1[1], num2[1], carry, sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Minute place value :</b>");
                s.AppendFormat("<br>{0} + {1} = {2} Minutes", num1[1], num2[1], sum);
            }
            carry = 0;
            if (sum >= 59)
            {
                Reminder = sum - ((sum / 60) * 60);
                carry = sum / 60;
                s.AppendFormat("<br> {0} Minutes = {1} Hour + {2} Minutes", sum, carry, Reminder);
                s.AppendFormat("<br> Here {0} is taken into the Minutes and {1} is carried to the Hours level.", Reminder, carry);
            }

            sum = Convert.ToInt16(num1[0]) + Convert.ToInt16(num2[0]) + carry;
            if (carry != 0)
            {
                s.AppendFormat("<br><br><b>Step 3: Add the Hours place value along with carry:</b>");
                s.AppendFormat("<br>{0} + {1} + {2} = {3} Hours<br>", num1[0], num2[0], carry, sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 3: Add the Hours place value :</b>");
                s.AppendFormat("<br>{0} + {1} = {2} Hours", num1[0], num2[0], sum);
            }
            if (sum >= 12)
            {
                if (sum > 12)
                {
                    sum = sum - 12;
                }
                if (num1[3] == "AM")
                {
                    s.AppendFormat("<br><br>Here first time is AM and adding the time will change to {0} PM.", sum);
                }
                else
                {
                    s.AppendFormat("<br><br> Here first time is PM and adding the time will change to {0} AM.", sum);
                }

            }
            s.AppendFormat("<br><br><b> Answer :</b> {0}", number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt"));

            return s.ToString();

        }
    }

    class Level5Time : TimeAddition
    {
        protected override string createAnswer()
        {

            DateTime answer = number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));
            return answer.ToString("hh") + "Hours " + answer.ToString("mm") + "Minutes";
        }

        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            number_2 = generateNumber_2();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("hh") + "Hours " + number_1.ToString("mm") + "Minutes ");
            question.Replace("number_2", number_2.ToString("hh") + "Hours " + number_2.ToString("mm") + "Minutes ");
            return question.ToString();
        }

        protected override DateTime generateNumber_1()
        {
            int randomHours = randomDigit(1, 11);
            int randomMinutes = randomDigit(0, 59);

            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);

            return timeOfDayDate;

        }

        protected override DateTime generateNumber_2()
        {
            int Time1 = Convert.ToInt16(number_1.ToString("hh"));
            int hr = 11 - Time1;
            int randomHours = randomDigit(1, hr);
            int randomMinutes = randomDigit(0, 59);

            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);
            return timeOfDayDate;
        }

        protected override List<String> createOptions()
        {

            DateTime answer = number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));
            DateTime temp;
            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();
            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString("hh") + "Hours " + answer.ToString("mm") + "Minutes");

            temp = answer.AddMinutes(type1).AddMinutes(type2);
            options.Add(temp.ToString("hh") + "Hours " + temp.ToString("mm") + "Minutes");

            temp = answer.AddMinutes(type1).AddMinutes(type2 + 60);
            options.Add(temp.ToString("hh") + "Hours " + temp.ToString("mm") + "Minutes");

            temp = answer.AddMinutes(type1).AddHours(type2);
            options.Add(temp.ToString("hh") + "Hours " + temp.ToString("mm") + "Minutes");

            return options;



        }

        //protected override String createSolution()
        //{
        //    return buildSolution(number_1, number_2);
        //}

        protected String buildSolution(DateTime number_1, DateTime number_2)
        {
            //string[] num1 = expandNumber1(number_1, 4);
            //string[] num2 = expandNumber2(number_2, 3);

            StringBuilder s = new StringBuilder(4000);
            int carry = 0, sum = 0, Reminder = 0;
            s.AppendFormat("<b>Detailed Solution:</b><br>");
            s.AppendFormat("<b> Expand the Time:</b><br> Hours   = {0}", number_1.ToString("hh"));
            s.AppendFormat(" Minutes= {0}", number_1.ToString("mm"));
            s.AppendFormat("<br> Hours   = {0}", number_2.ToString("hh"));
            s.AppendFormat(" Minutes= {0}", number_2.ToString("mm"));

            sum = Convert.ToInt16(number_1.ToString("mm")) + Convert.ToInt16(number_2.ToString("mm"));
            s.AppendFormat("<br><br><b>Step 1: Add the Minute place value :</b>");
            s.AppendFormat("<br>{0} + {1} = {2} Minutes", number_1.ToString("mm"), number_2.ToString("mm"), sum);

            if (sum >= 59)
            {
                Reminder = sum - ((sum / 60) * 60);
                carry = sum / 60;
                s.AppendFormat("<br> {0} Minutes = {1} Hour + {2} Minutes", sum, carry, Reminder);
                s.AppendFormat("<br> Here {0} is taken into the Minutes and {1} is carried to the Hours level.", Reminder, carry);
            }

            sum = Convert.ToInt16(number_1.ToString("hh")) + Convert.ToInt16(number_2.ToString("hh"));
            if (carry != 0)
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Hours place value along with carry:</b>");
                s.AppendFormat("<br>{0} + {1} + {2} = {3} Hours<br>", number_1.ToString("hh"), number_2.ToString("hh"), carry, sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 2: Add the Hours place value :</b>");
                s.AppendFormat("<br>{0} + {1} = {2} Hours", number_1.ToString("hh"), number_2.ToString("hh"), sum);
            }
            //if (sum >= 12)
            //{
            //    if (sum > 12)
            //    {
            //        sum = sum - 12;
            //    }
            //    if (num1[3] == "AM")
            //    {
            //        s.AppendFormat("<br><br>Here first time is AM and adding the time will change to {0} PM.", sum);
            //    }
            //    else
            //    {
            //        s.AppendFormat("<br><br> Here first time is PM and adding the time will change to {0} AM.", sum);
            //    }

            //}
            DateTime answer = number_1.Add(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));
            s.AppendFormat("<br><br><b> Answer :</b> {0}", answer.ToString("hh") + "Hours " + answer.ToString("mm") + "Minutes");
            return s.ToString();

        }
    }

}
