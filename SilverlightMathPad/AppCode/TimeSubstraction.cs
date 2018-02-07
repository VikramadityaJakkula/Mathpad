using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class TimeSubtraction : Quiz
    {
        public TimeSubtraction()
        {
            createQuestionPrototype();
        }
        protected DateTime number_1, number_2;

        abstract protected DateTime generateNumber_1();
        abstract protected DateTime generateNumber_2();

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
            //while (i < size)
            //{
            //    num[i] = (number % 10);
            //    number /= 10;
            //    i++;
            //}
            return num;

        }
        protected string[] expandNumber2(DateTime number, int size)
        {
            string[] num = new string[size];
            string[] DateInfo = new string[size];
            string[] Info = new string[2];

            DateInfo = number.ToString("hh:mm:ss").Split(':');
            num[0] = DateInfo[0];
            num[1] = DateInfo[1];
            num[2] = DateInfo[2];

            return num;

        }
       
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("number_1 - number_2 ");
        }
    }

    class Level8Time : TimeSubtraction
    {
        protected override string createAnswer()
        {

            return number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt");

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
            int randomHours = randomDigit(0, 23);
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
            return timeOfDayDate;
        }
        protected override List<String> createOptions()
        {

            //timeSpan.Hours=Convert.ToInt16(number_2.ToString("hh"));
            //  timeSpan.Minutes=Convert.ToInt16(number_2.ToString("mm"));
            //  timeSpan.Seconds=Convert.ToInt16(number_2.ToString("ss"));


            DateTime answer = number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss"))));

            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer.AddSeconds(type).AddSeconds(i)).ToString("hh:mm:ss tt"));

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }

            return options;


        }

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

            s.AppendFormat("<br><br><b>Step 1: Subtract the Seconds place value:</b>");
            if (Convert.ToInt16(num2[2]) > Convert.ToInt16(num1[2]))
            {
                if (num1[1] == "00")
                {
                    s.AppendFormat("<br> Since {0} &lt {1} and Minute value is 00, borrow 60 Seconds from Hour place value.", num1[2], num2[2]);
                    if (num1[0] == "12")
                    {
                        if (num1[3] == "AM")
                        {
                            s.AppendFormat("<br><br>Here first time is AM and Subtracting 1 Hour will change to {0} PM.", Convert.ToInt16(num1[0]) - 1);
                            num1[3] = "PM";
                        }
                        else
                        {
                            s.AppendFormat("<br><br> Here first time is PM and Subtracting 1 Hour will change to {0} AM.", Convert.ToInt16(num1[0]) - 1);
                            num1[3] = "AM";
                        }
                    }
                    if (num1[0] == "01")
                    {
                        num1[0] = "12";
                    }
                    else
                    {
                        num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) - 1);
                    }
                    num1[1] = "59";
                    num1[2] = Convert.ToString(Convert.ToInt16(num1[2]) + 60);
                }
                else
                {
                    s.AppendFormat("<br> Since {0} &lt {1} , borrow 60 Seconds from Minute place value.", num1[2], num2[2]);
                    num1[1] = Convert.ToString(Convert.ToInt16(num1[1]) - 1);
                }
                s.AppendFormat("<br> Adding 1 Minute to {0}={1} Seconds", num1[2], Convert.ToInt16(num1[2]) + 60);
                num1[2] = Convert.ToString(Convert.ToInt16(num1[2]) + 60);
            }
            sum = Convert.ToInt16(num1[2]) - Convert.ToInt16(num2[2]);
            s.AppendFormat("<br>{0} - {1} = {2} Seconds<br>", num1[2], num2[2], sum);

            s.AppendFormat("<br><br><b>Step 2: Subtract the Minutes place value:</b>");
            //Subtract Minutes
            if (Convert.ToInt16(num2[1]) > Convert.ToInt16(num1[1]))
            {
                s.AppendFormat("<br> Since {0} &lt {1} , borrow 60 Minutes from Hours place value.", num1[1], num2[1]);
                if (num1[0] == "12")
                {
                    if (num1[3] == "AM")
                    {
                        s.AppendFormat("<br><br>Here first time is AM and Subtracting 1 Hour will change to {0} PM.", Convert.ToInt16(num1[0]) - 1);
                        num1[3] = "PM";
                    }
                    else
                    {
                        s.AppendFormat("<br><br> Here first time is PM and Subtracting 1 Hour will change to {0} AM.", Convert.ToInt16(num1[0]) - 1);
                        num1[3] = "AM";
                    }

                }
                if (num1[0] == "01")
                {
                    num1[0] = "12";
                }
                else
                {
                    num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) - 1);
                }
                s.AppendFormat("<br> Adding 1 Hour to {0}={1} Minutes", num1[1], Convert.ToInt16(num1[1]) + 60);
                num1[1] = Convert.ToString(Convert.ToInt16(num1[1]) + 60);
            }
            sum = Convert.ToInt16(num1[1]) - Convert.ToInt16(num2[1]);
            s.AppendFormat("<br>{0} - {1} = {2} Minutes<br>", num1[1], num2[1], sum);


            s.AppendFormat("<br><br><b>Step 3: Subtract the Hours place value:</b>");
            //Subtract Hours
            if ((Convert.ToInt16(num2[0]) > Convert.ToInt16(num1[0])) || (Convert.ToInt16(num1[0]) == 12))
            {
                if (Convert.ToInt16(num1[0]) != 12)
                {
                    num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) + 12);
                }
                if (num1[3] == "AM")
                {
                    s.AppendFormat("<br><br>Here first time is AM and Subtracting {0} Hour will change to {1} PM.", num2[0], Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]));
                    num1[3] = "PM";
                }
                else
                {
                    s.AppendFormat("<br><br> Here first time is PM and Subtracting {0} Hour will change to {1} AM.", num2[0], Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]));
                    num1[3] = "AM";
                }
            }
            else if (Convert.ToInt16(num2[0]) == Convert.ToInt16(num1[0]))
            {
                sum = Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]);
                s.AppendFormat("<br>{0} - {1} = {2}, which is 12 Hours<br>", num1[0], num2[0], sum);
            }
            else
            {
                sum = Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]);
                s.AppendFormat("<br>{0} - {1} = {2} Hours<br>", num1[0], num2[0], sum);
            }
            s.AppendFormat("<br><br><b> Answer :</b> {0}", number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt"));
            return s.ToString();

        }
    }

    class Level10Time : TimeSubtraction
    {
        protected override string createAnswer()
        {

            return number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt");

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
            int randomHours = randomDigit(0, 23);
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
            int randomHours = randomDigit(0, 11);
            int randomMinutes = randomDigit(0, 59);
            int randomSeconds = randomDigit(1, 59);
            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);
            return timeOfDayDate;
        }
        protected override List<String> createOptions()
        {

            //timeSpan.Hours=Convert.ToInt16(number_2.ToString("hh"));
            //  timeSpan.Minutes=Convert.ToInt16(number_2.ToString("mm"));
            //  timeSpan.Seconds=Convert.ToInt16(number_2.ToString("ss"));


            DateTime answer = number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss"))));

            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer.AddSeconds(type).AddSeconds(i)).ToString("hh:mm:ss tt"));

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }

            return options;


        }

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

            s.AppendFormat("<br><br><b>Step 1: Subtract the Seconds place value:</b>");
            if (Convert.ToInt16(num2[2]) > Convert.ToInt16(num1[2]))
            {
                if (num1[1] == "00")
                {
                    s.AppendFormat("<br> Since {0} &lt {1} and Minute value is 00, borrow 60 Seconds from Hour place value.", num1[2], num2[2]);
                    if (num1[0] == "12")
                    {
                        if (num1[3] == "AM")
                        {
                            s.AppendFormat("<br><br>Here first time is AM and Subtracting 1 Hour will change to {0} PM.", Convert.ToInt16(num1[0]) - 1);
                            num1[3] = "PM";
                        }
                        else
                        {
                            s.AppendFormat("<br><br> Here first time is PM and Subtracting 1 Hour will change to {0} AM.", Convert.ToInt16(num1[0]) - 1);
                            num1[3] = "AM";
                        }
                    }
                    if (num1[0] == "01")
                    {
                        num1[0] = "12";
                    }
                    else
                    {
                        num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) - 1);
                    }
                    num1[1] = "59";
                    num1[2] = Convert.ToString(Convert.ToInt16(num1[2]) + 60);
                }
                else
                {
                    s.AppendFormat("<br> Since {0} &lt {1} , borrow 60 Seconds from Minute place value.", num1[2], num2[2]);
                    num1[1] = Convert.ToString(Convert.ToInt16(num1[1]) - 1);
                }
                s.AppendFormat("<br> Adding 1 Minute to {0}={1} Seconds", num1[2], Convert.ToInt16(num1[2]) + 60);
                num1[2] = Convert.ToString(Convert.ToInt16(num1[2]) + 60);
            }
            sum = Convert.ToInt16(num1[2]) - Convert.ToInt16(num2[2]);
            s.AppendFormat("<br>{0} - {1} = {2} Seconds<br>", num1[2], num2[2], sum);

            s.AppendFormat("<br><br><b>Step 2: Subtract the Minutes place value:</b>");
            //Subtract Minutes
            if (Convert.ToInt16(num2[1]) > Convert.ToInt16(num1[1]))
            {
                s.AppendFormat("<br> Since {0} &lt {1} , borrow 60 Minutes from Hours place value.", num1[1], num2[1]);
                if (num1[0] == "12")
                {
                    if (num1[3] == "AM")
                    {
                        s.AppendFormat("<br><br>Here first time is AM and Subtracting 1 Hour will change to {0} PM.", Convert.ToInt16(num1[0]) - 1);
                        num1[3] = "PM";
                    }
                    else
                    {
                        s.AppendFormat("<br><br> Here first time is PM and Subtracting 1 Hour will change to {0} AM.", Convert.ToInt16(num1[0]) - 1);
                        num1[3] = "AM";
                    }

                }
                if (num1[0] == "01")
                {
                    num1[0] = "12";
                }
                else
                {
                    num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) - 1);
                }
                s.AppendFormat("<br> Adding 1 Hour to {0}={1} Minutes", num1[1], Convert.ToInt16(num1[1]) + 60);
                num1[1] = Convert.ToString(Convert.ToInt16(num1[1]) + 60);
            }
            sum = Convert.ToInt16(num1[1]) - Convert.ToInt16(num2[1]);
            s.AppendFormat("<br>{0} - {1} = {2} Minutes<br>", num1[1], num2[1], sum);


            s.AppendFormat("<br><br><b>Step 3: Subtract the Hours place value:</b>");
            //Subtract Hours
            if ((Convert.ToInt16(num2[0]) > Convert.ToInt16(num1[0])) || (Convert.ToInt16(num1[0]) == 12))
            {
                if (Convert.ToInt16(num1[0]) != 12)
                {
                    num1[0] = Convert.ToString(Convert.ToInt16(num1[0]) + 12);
                }
                if (num1[3] == "AM")
                {
                    s.AppendFormat("<br><br>Here first time is AM and Subtracting {0} Hour will change to {1} PM.", num2[0], Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]));
                    num1[3] = "PM";
                }
                else
                {
                    s.AppendFormat("<br><br> Here first time is PM and Subtracting {0} Hour will change to {1} AM.", num2[0], Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]));
                    num1[3] = "AM";
                }
            }
            else if (Convert.ToInt16(num2[0]) == Convert.ToInt16(num1[0]))
            {
                sum = Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]);
                s.AppendFormat("<br>{0} - {1} = {2}, which is 12 Hours<br>", num1[0], num2[0], sum);
            }
            else
            {
                sum = Convert.ToInt16(num1[0]) - Convert.ToInt16(num2[0]);
                s.AppendFormat("<br>{0} - {1} = {2} Hours<br>", num1[0], num2[0], sum);
            }
            s.AppendFormat("<br><br><b> Answer :</b> {0}", number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), Convert.ToInt16(number_2.ToString("ss")))).ToString("hh:mm:ss tt"));
            return s.ToString();

        }
    }

    class Level6Time : TimeSubtraction
    {
        protected override string createAnswer()
        {
            DateTime answer = number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));
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
            int randomHours = randomDigit(3, 12);
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
            int hr = 12 - Time1;
            int randomHours = randomDigit(1, Time1 - 2);
            int randomMinutes = randomDigit(0, 59);

            DateTime timeOfDayDate = default(DateTime);
            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);
            return timeOfDayDate;
        }

        protected override List<String> createOptions()
        {

            DateTime answer = number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));
            DateTime temp;
            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();
            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString("hh") + "Hours " + answer.ToString("mm") + "Minutes");

            temp = answer.AddMinutes(type1).AddMinutes(type2);
            options.Add(temp.ToString("hh") + "Hours " + temp.ToString("mm") + "Minutes");

            temp = answer.AddMinutes(type1).AddMinutes(type2 - 60);
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

            s.AppendFormat("<br><br><b>Step 2: Subtract the Minutes place value:</b>");
            //Subtract Minutes
            int Min = Convert.ToInt16(number_1.ToString("mm"));
            if (Convert.ToInt16(number_2.ToString("mm")) > Convert.ToInt16(number_1.ToString("mm")))
            {
                s.AppendFormat("<br> Since {0} &lt {1} , borrow 60 Minutes from Hours place value.", number_1.ToString("mm"), number_2.ToString("mm"));

                s.AppendFormat("<br> Adding 1 Hour to {0}={1} Minutes", number_1.ToString("mm"), Convert.ToInt16(number_1.ToString("mm")) + 60);
                Min = Min + 60;
                carry = -1;
            }
            sum = Min - Convert.ToInt16(number_2.ToString("mm"));
            s.AppendFormat("<br>{0} - {1} = {2} Minutes<br>", Min, number_2.ToString("mm"), sum);


            //Subtract Hours

            sum = Convert.ToInt16(number_1.ToString("hh")) - Convert.ToInt16(number_2.ToString("hh")) + carry;
            if (carry == 0)
            {
                s.AppendFormat("<br><br><b>Step 3: Subtract the Hours place value:</b>");
                s.AppendFormat("<br>{0} - {1} = {2} Hours<br>", number_1.ToString("hh"), number_2.ToString("hh"), sum);
            }
            else
            {
                s.AppendFormat("<br><br><b>Step 3: Subtract the Hours place value, with carry:</b>");
                s.AppendFormat("<br>{0} - {1} -1 = {2} Hours<br>", number_1.ToString("hh"), number_2.ToString("hh"), sum);
            }

            DateTime answer = number_1.Subtract(new TimeSpan(Convert.ToInt16(number_2.ToString("hh")), Convert.ToInt16(number_2.ToString("mm")), 0));

            s.AppendFormat("<br><br><b> Answer :</b> {0}", answer.ToString("hh") + "Hours " + answer.ToString("mm") + "Minutes");
            return s.ToString();

        }
    }


}
