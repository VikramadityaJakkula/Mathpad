using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class SimpleInterest : Quiz
    {
        protected int Pricipal_Amt, NoOf_Years, QueType;
        protected decimal Interest_Rate, Interest_Amt, Sum_Amt;
        protected decimal Answer;
        protected string AnswerFormat;
        abstract protected int generatePrincipal();
        abstract protected int generateYears();
        abstract protected decimal generateInterestRate();
        abstract protected decimal CalculateInterest();

        public SimpleInterest()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {
            QueType = randomDigit(0, 7);
            String s;
            if (QueType == 0)
                s = questionPrototype.ElementAt(0);
            else if (QueType == 1)
                s = questionPrototype.ElementAt(1);
            else if (QueType == 2)
                s = questionPrototype.ElementAt(2);
            else if (QueType == 3)
                s = questionPrototype.ElementAt(3);
            else if (QueType == 4)
                s = questionPrototype.ElementAt(4);
            else if (QueType == 5)
                s = questionPrototype.ElementAt(5);
            else
                s = questionPrototype.ElementAt(6);

            StringBuilder question = new StringBuilder(s);

            Pricipal_Amt = generatePrincipal();
            Interest_Rate = generateInterestRate();
            NoOf_Years = generateYears();
            Interest_Amt = CalculateInterest();
            Sum_Amt = Pricipal_Amt + Interest_Amt;


            question.Replace("Pricipal_Amt", Pricipal_Amt.ToString());
            question.Replace("Interest_Rate", Interest_Rate.ToString());
            question.Replace("NoOf_Years", NoOf_Years.ToString());
            question.Replace("Sum_Amt", Sum_Amt.ToString());
            question.Replace("Interest_Amt", Interest_Amt.ToString());

            return question.ToString();
        }




        protected override void createQuestionPrototype()
        {

            questionPrototype.Add("How much money do I need (principal) to get $Interest_Amt at Interest_Rate% in NoOf_Years years?");
            questionPrototype.Add("How many years will it take if I invest $Pricipal_Amt at Interest_Rate% to make $Interest_Amt?");
            questionPrototype.Add("How many years will it take for $Pricipal_Amt to make $Interest_Amt at Interest_Rate%?");
            questionPrototype.Add("Find the simple interest earned on a principal $Pricipal_Amt at an annual interest rate of Interest_Rate% for NoOf_Years years.");
            questionPrototype.Add("Terry's investment of $Pricipal_Amt in the stock market earned $Interest_Amt in NoOf_Years years. Find the simple interest rate.");
            questionPrototype.Add("Khaild invests $Pricipal_Amt at Interest_Rate per annum, for NoOf_Years year. How much interest has he earned?");
            questionPrototype.Add("Josie puts $Pricipal_Amt in a bank for NoOf_Years years at Interest_Rate% interest rate. How much is in the account at the end of NoOf_Years years?");
            // questionPrototype.Add("<b> Evaluate :<br>&nbsp;If Ben invests 4000 at 4% interest per year, how much additional money must he invest at 5.5% annual interest to ensure that the interest he receives each year is 4.5% of the total amount invested?</b>");


        }
        protected override List<String> createOptions()
        {
            List<String> options = new List<String>();
            int type1, type2;
            string[] temp = new string[2];
            temp = Answer.ToString().Split('.');
            int count = temp[0].Length - 1;
            int Num = 1;
            for (int i = count; i > 0; i--)
                Num = Num * 10;

            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 2 : -2;
            type1 = type1 * Num;
            type2 = type2 * Num;

            type2 = (Answer + type2) > 1 ? type2 : -type2;
            if (AnswerFormat == "p")
            {
                options.Add(Answer.ToString() + "%");
                options.Add((Answer + type1).ToString() + "%");
                options.Add((Answer + type2).ToString() + "%");
                options.Add((Answer + type2 + type1).ToString() + "%");
            }
            else if (AnswerFormat == "0.00")
            {
                options.Add(Answer.ToString(AnswerFormat));
                options.Add((Answer + type1).ToString(AnswerFormat));
                options.Add((Answer + type2).ToString(AnswerFormat));
                options.Add((Answer + type2 + type1).ToString(AnswerFormat));
            }
            else
            {
                options.Add(Answer.ToString());
                options.Add((Answer + type1).ToString());
                options.Add((Answer + type2).ToString());
                options.Add((Answer + type2 + type1).ToString());
            }
            return options;

            //List<String> options = new List<String>();

            //int type = -randomDigit(0, 4);
            //string[] temp = new string[2];
            //temp = Answer.ToString().Split('.');
            //int count = temp[0].Length - 1;
            //int Num = 1;
            //for (int i = count; i > 0; i--)
            //    Num = Num * 10;


            //if (AnswerFormat == "p")
            //{
            //    for (int i = 0; i < 4; i++)
            //        options.Add((Answer + type * Num + i * Num).ToString() + "%");
            //}
            //else if (AnswerFormat == "0.00")
            //{
            //    for (int i = 0; i < 4; i++)
            //        options.Add((Answer + type * Num + i * Num).ToString(AnswerFormat));
            //}
            //else
            //{
            //    for (int i = 0; i < 4; i++)
            //        options.Add((Answer + type * Num + i * Num).ToString());
            //}


            //return options;
        }

    }


    class Level1SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(1, 3) * 100;
            else
                Number1 = randomDigit(1, 3) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(1, 3);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 3).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level2SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(1, 3) * 100;
            else
                Number1 = randomDigit(1, 3) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(3, 5);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 3).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level3SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(1, 3) * 100;
            else
                Number1 = randomDigit(1, 3) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(1, 3);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(3, 5).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level4SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(3, 5) * 100;
            else
                Number1 = randomDigit(3, 5) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(1, 3);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 3).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level5SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(3, 5) * 100;
            else
                Number1 = randomDigit(3, 5) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(3, 7);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(1, 3).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level6SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(3, 5) * 100;
            else
                Number1 = randomDigit(3, 5) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(3, 7);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(3, 7).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level7SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(3, 7) * 100;
            else
                Number1 = randomDigit(3, 7) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(3, 7);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(3, 7).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level8SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(7, 10) * 100;
            else
                Number1 = randomDigit(7, 10) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(7, 10);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(3, 7).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level9SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(7, 10) * 100;
            else
                Number1 = randomDigit(7, 10) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(1, 5);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(7, 10).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

    class Level10SI : SimpleInterest
    {



        protected override int generatePrincipal()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(7, 10) * 100;
            else
                Number1 = randomDigit(7, 10) * 1000;

            return Number1;
        }
        protected override int generateYears()
        {
            return randomDigit(7, 10);
        }
        protected override decimal generateInterestRate()
        {
            string Number1 = randomDigit(1, 10).ToString();
            Number1 = Number1 + ".";
            int type = randomDigit(0, 3);
            for (int i = type; i > 0; i--)
                Number1 = Number1 + randomDigit(7, 10).ToString();

            return Convert.ToDecimal(Number1);


        }

        protected override decimal CalculateInterest()
        {
            // I = Prt 
            return (Pricipal_Amt * Interest_Rate * NoOf_Years) / 100;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Pricipal_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "i";
                Answer = NoOf_Years;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "p";
                Answer = Interest_Rate;
            }
            else if (QueType == 5)
            {
                AnswerFormat = "0.00";
                Answer = Interest_Amt;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Sum_Amt;
            }

            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else if (AnswerFormat == "p")
                return Answer.ToString() + "%";
            else
                return Answer.ToString();
        }




    }

}
