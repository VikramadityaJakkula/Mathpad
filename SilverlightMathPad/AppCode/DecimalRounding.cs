using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class DecimalRounding : Quiz
    {
        protected decimal number_1;
        abstract protected decimal generateNumber_1();
        public DecimalRounding()
        {
            createQuestionPrototype();
        }

        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString());
            return question.ToString();
        }

        protected String buildSolution(decimal number_1, int round)
        {

            decimal answer = number_1;
            StringBuilder s = new StringBuilder(4000);
            int count = number_1.ToString().Length - 2 - round;
            int digit;
            s.AppendFormat("<b>Detailed Solution:</b><br>");
            for (int i = 0; i < count; i++)
            {
                digit = Convert.ToInt16(answer.ToString().Substring(count - i + round + 1, 1));
                s.AppendFormat("<br><br><b>Step {0}: Consider the {1} decimal place value:{2}</b>", i + 1, count - i + round, digit);
                if (digit > 5)
                {
                    s.AppendFormat("<br> Here {0} is greater than 5, so 1 is carried forward to next decimal level.", digit);
                }
                else if (digit == 5)
                {
                    s.AppendFormat("<br> Here {0} is equal to 5, so 1 is carried forward to next decimal level.", digit);
                }
                else
                {
                    s.AppendFormat("<br> Here {0} is less than 5, so the value in this decimal level is neglected.", digit);
                }
                answer = System.Math.Round(answer, count - i + round - 1);

                s.AppendFormat("<br> So the Number is changed to: {0}", answer);
            }
            s.AppendFormat("<br><br><b> Answer :</b>");
            s.AppendFormat("{0}", answer);
            return s.ToString();

        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Convert: number_1");

        }

    }



    class Level1Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(2, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 1);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 1);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 10)).ToString());
            options.Add((answer - (type1 / 10)).ToString());
            options.Add((answer + type2 / 10).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }

    class Level2Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(3, 4);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 1);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 1);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 10)).ToString());
            options.Add((answer - (type1 / 10)).ToString());
            options.Add((answer + type2 / 10).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }

    class Level3Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(4, 5);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 1);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 1);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 10)).ToString());
            options.Add((answer - (type1 / 10)).ToString());
            options.Add((answer + type2 / 10).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }

    class Level4Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(2, 5);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 1);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 1);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 10)).ToString());
            options.Add((answer - (type1 / 10)).ToString());
            options.Add((answer + type2 / 10).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }

    class Level5Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(3,4);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 2);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 2);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 100)).ToString());
            options.Add((answer - (type1 / 100)).ToString());
            options.Add((answer + type2 / 100).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }


    }

    class Level6Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(4,5);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 2);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 2);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 100)).ToString());
            options.Add((answer - (type1 / 100)).ToString());
            options.Add((answer + type2 / 100).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }


    }

    class Level7Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(5, 6);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 2);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 2);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 100)).ToString());
            options.Add((answer - (type1 / 100)).ToString());
            options.Add((answer + type2 / 100).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }


    }

    class Level8Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(4, 5);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 3);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 3);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 1000)).ToString());
            options.Add((answer - (type1 / 1000)).ToString());
            options.Add((answer + type2 / 1000).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }

     

    }

    class Level9Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(5, 6);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 3);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 3);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 1000)).ToString());
            options.Add((answer - (type1 / 1000)).ToString());
            options.Add((answer + type2 / 1000).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }

    class Level10Rounding : DecimalRounding
    {
        protected override decimal generateNumber_1()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(6, 7);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 10).ToString();
            return Convert.ToDecimal(Number1);
        }

        protected override string createAnswer()
        {
            decimal answer = System.Math.Round(number_1, 3);
            return answer.ToString();
        }
        protected override List<String> createOptions()
        {

            decimal answer = System.Math.Round(number_1, 3);

            List<String> options = new List<String>();

            decimal type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + (type1 / 1000)).ToString());
            options.Add((answer - (type1 / 1000)).ToString());
            options.Add((answer + type2 / 1000).ToString());
            //  options.Add((answer + type2 / 10 + type1 / 10).ToString());


            return options;



        }



    }
}
