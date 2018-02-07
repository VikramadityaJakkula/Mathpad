using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class TimeConvertion : Quiz
    {
        protected DateTime number_1;
        abstract protected DateTime generateNumber_1();
        public TimeConvertion()
        {
            createQuestionPrototype();
        }
        
       
    }

    class Level1Time : TimeConvertion
    {
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Convert number_1 to Minute");
        }
        protected override DateTime generateNumber_1()
        {
            // return randomDigit(1, 12);

            int randomHours = randomDigit(1, 6);
            int randomMinutes = randomDigit(0, 10);

            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);

            return timeOfDayDate; ;


        }
        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("hh") + "Hrs " + number_1.ToString("mm") + "Min");
            return question.ToString();
        }
        protected override List<String> createOptions()
        {

            int answer = Convert.ToInt16(number_1.ToString("hh")) * 60 + Convert.ToInt16(number_1.ToString("mm"));
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString() + "Mins");
            options.Add((answer + type1 * 60).ToString() + "Mins");
            options.Add((answer + type2).ToString() + "Mins");
            options.Add((answer + type2 + type1 * 60).ToString() + "Mins");

            return options;
        }
        protected override string createAnswer()
        {
            int Ans = Convert.ToInt16(number_1.ToString("hh")) * 60 + Convert.ToInt16(number_1.ToString("mm"));
            return Ans.ToString() + "Mins";

        }
        //protected override String createSolution()
        //{

        //    return buildSolution(number_1);
        //}
    
    }



    class Level2Time : TimeConvertion
    {
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Convert number_1 to Seconds");
        }
        protected override DateTime generateNumber_1()
        {
            // return randomDigit(1, 12);

            int randomSeconds = randomDigit(0, 10);
            int randomMinutes = randomDigit(0, 10);

            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);

            // return timeOfDayDate.ToString("hh:mm:ss tt");
            return timeOfDayDate;

        }
      
        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("mm") + "Min " + number_1.ToString("ss") + "Seconds");
            question.Replace("number_2", "");
            return question.ToString();
        }
        protected override List<String> createOptions()
        {

            int answer = Convert.ToInt16(number_1.ToString("mm")) * 60 + Convert.ToInt16(number_1.ToString("ss"));
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString() + "Seconds");
            options.Add((answer + type1 * 60).ToString() + "Seconds");
            options.Add((answer + type2).ToString() + "Seconds");
            options.Add((answer + type2 + type1 * 60).ToString() + "Seconds");

            return options;

        }
        //protected override String createSolution()
        //{

        //    return buildSolution(number_1);
        //}
        protected override string createAnswer()
        {
            int Ans = Convert.ToInt16(number_1.ToString("mm")) * 60 + Convert.ToInt16(number_1.ToString("ss"));
            return Ans.ToString() + "Seconds";

        }
       
    }

    class Level3Time : TimeConvertion
    {
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Convert number_1 to Minute");
        }
        protected override DateTime generateNumber_1()
        {
            // return randomDigit(1, 12);

            int randomHours = randomDigit(5, 10);
            int randomMinutes = randomDigit(10, 59);

            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddHours(randomHours);

            return timeOfDayDate; ;


        }
        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("hh") + "Hrs " + number_1.ToString("mm") + "Min");
            return question.ToString();
        }
        protected override List<String> createOptions()
        {

            int answer = Convert.ToInt16(number_1.ToString("hh")) * 60 + Convert.ToInt16(number_1.ToString("mm"));
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString() + "Mins");
            options.Add((answer + type1 * 60).ToString() + "Mins");
            options.Add((answer + type2).ToString() + "Mins");
            options.Add((answer + type2 + type1 * 60).ToString() + "Mins");

            return options;
        }
        protected override string createAnswer()
        {
            int Ans = Convert.ToInt16(number_1.ToString("hh")) * 60 + Convert.ToInt16(number_1.ToString("mm"));
            return Ans.ToString() + "Mins";

        }
        //protected override String createSolution()
        //{

        //    return buildSolution(number_1);
        //}

    }

    class Level4Time : TimeConvertion
    {
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Convert number_1 to Seconds");
        }
        protected override DateTime generateNumber_1()
        {
            // return randomDigit(1, 12);

            int randomSeconds = randomDigit(11, 59);
            int randomMinutes = randomDigit(11, 59);

            DateTime timeOfDayDate; // = default(DateTime);
            timeOfDayDate = Convert.ToDateTime("00:00:00");

            timeOfDayDate = timeOfDayDate.AddMinutes(randomMinutes);
            timeOfDayDate = timeOfDayDate.AddSeconds(randomSeconds);

            // return timeOfDayDate.ToString("hh:mm:ss tt");
            return timeOfDayDate;

        }

        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString("mm") + "Min " + number_1.ToString("ss") + "Seconds");
            question.Replace("number_2", "");
            return question.ToString();
        }
        protected override List<String> createOptions()
        {

            int answer = Convert.ToInt16(number_1.ToString("mm")) * 60 + Convert.ToInt16(number_1.ToString("ss"));
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString() + "Seconds");
            options.Add((answer + type1 * 60).ToString() + "Seconds");
            options.Add((answer + type2).ToString() + "Seconds");
            options.Add((answer + type2 + type1 * 60).ToString() + "Seconds");

            return options;

        }
        //protected override String createSolution()
        //{

        //    return buildSolution(number_1);
        //}
        protected override string createAnswer()
        {
            int Ans = Convert.ToInt16(number_1.ToString("mm")) * 60 + Convert.ToInt16(number_1.ToString("ss"));
            return Ans.ToString() + "Seconds";

        }

    }
}
