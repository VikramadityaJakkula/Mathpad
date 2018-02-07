using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Commission : Quiz
    {
        protected int Commission_Percent, Sales_Amt, QueType, Base_Sal;
        protected decimal Commission_Amt, Total_Sal, Sales_Act;
        protected decimal Answer;
        protected string AnswerFormat;
       // abstract protected int generateSalesPrice();
        abstract protected int generateCommission();
        // abstract protected decimal CalculateCommission();
        //abstract protected decimal CalculatePriceAct();


        public Commission()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            QueType = randomDigit(0, 4);

            String s;


            if (QueType == 0)
            {
                s = questionPrototype.ElementAt(0);
                Sales_Amt = generateSalesPrice();
                Commission_Percent = generateCommission();
                Commission_Amt = (Convert.ToDecimal(Sales_Amt) * Convert.ToDecimal(Commission_Percent)) / 100;
            }
            else if (QueType == 1)
            {
                s = questionPrototype.ElementAt(1);
                Sales_Amt = generateSalesPrice();
                Base_Sal = generateSalesPrice(); ;
                Commission_Percent = generateCommission();
                Commission_Amt = (Convert.ToDecimal(Sales_Amt) * Convert.ToDecimal(Commission_Percent)) / 100;
                Total_Sal = Base_Sal + Commission_Amt;
            }

            else if (QueType == 2)
            {
                s = questionPrototype.ElementAt(2);
                Sales_Amt = generateSalesPrice();
                Commission_Percent = generateCommission();
                Commission_Amt = (Convert.ToDecimal(Sales_Amt) * Convert.ToDecimal(Commission_Percent)) / 100;
                Sales_Act = Sales_Amt - Commission_Amt;
            }
            else
            {
                s = questionPrototype.ElementAt(3);
                Sales_Amt = generateSalesPrice();
                Commission_Percent = generateCommission();
                Commission_Amt = (Convert.ToDecimal(Sales_Amt) * Convert.ToDecimal(Commission_Percent)) / 100;
            }

            StringBuilder question = new StringBuilder(s);

            question.Replace("Base_Sal", Base_Sal.ToString());
            question.Replace("Total_Sal", Total_Sal.ToString());
            question.Replace("Commission_Amt", Commission_Amt.ToString());
            question.Replace("Sales_Act", Sales_Act.ToString());
            question.Replace("Commission_Percent", Commission_Percent.ToString());
            question.Replace("Sales_Amt", Sales_Amt.ToString());

            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {

            questionPrototype.Add("A Salesman receives a Commission of Commission_Percent% of Sales. If Sales is Sales_Amt$, how much money did the Salesman earn?");
            questionPrototype.Add("A Job offers $Base_Sal salary and  Commission_Percent% commission. How many dollars in sales would generate $Total_Sal?");
            questionPrototype.Add("A agent receives a commission of Commission_Percent% of the sale price. What should be the sale price if the seller wants $Sales_Act?");
            questionPrototype.Add("A Real estate agent recieved a commission of $Commission_Amt. How much % did he charge if the Property is sold for $Sales_Amt?");

            //  questionPrototype.Add("<b> Evaluate :<br>&nbsp;Jason is paid $500 per month plus a commission of 4% of the first $2,500 of his sales over of his sales, and 6% of his sales over $2,500. Last month his sales totaled $22,100. Find Jason's wages for the month?</b>");
        }

        protected  int generateSalesPrice()
        {
            int Number1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Number1 = randomDigit(1, 10) * 100;
            else
                Number1 = randomDigit(1, 10) * 1000;

            return Number1;


        }
        //protected override decimal CalculateCommission()
        //{
        //    decimal Num = 0;
        //    Num = (Convert.ToDecimal(Sales_Amt) * Convert.ToDecimal(Commission_Percent)) / 100;
        //    return Num;
        //}
        protected  decimal CalculatePriceAct()
        {
            decimal Num = 0;
            // Num = Price_Org - Discount_Amt;
            return Num;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Commission_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "0.00";
                Answer = Sales_Amt;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "0.00";
                Answer = Sales_Amt;
            }

            else
            {
                AnswerFormat = "p";
                Answer = Commission_Percent;
            }
            if (AnswerFormat == "0.00")
                return Answer.ToString();
            else
                return Answer.ToString() + "%";

        }

        protected override List<String> createOptions()
        {
            //List<String> options = new List<String>();

            //decimal type1, type2;
            //type1 = randomDigit(1, 3);
            //type2 = randomDigit(3, 4);
            //string[] temp = new string[2];
            //temp = Answer.ToString().Split('.');
            //int count = temp[0].Length - 1;
            //for (int i = count; i > 0; i--)
            //{
            //    type1 = type1 * 10;
            //    type2 = type2 * 10;
            //}
            //if (AnswerFormat == "p")
            //{
            //    options.Add(Answer.ToString() + "%");
            //    options.Add((Answer + type1).ToString() + "%");
            //    options.Add((Answer + type2).ToString() + "%");
            //    options.Add((Answer + type2 + type1).ToString() + "%");
            //}
            //else
            //{
            //    options.Add(Answer.ToString());
            //    options.Add((Answer + type1).ToString());
            //    options.Add((Answer + type2).ToString());
            //    options.Add((Answer + type2 + type1).ToString());
            //}

            //return options;
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
            //else
            //{
            //    for (int i = 0; i < 4; i++)
            //        options.Add((Answer + type * Num + i * Num).ToString(AnswerFormat));
            //}

            //if (options.Contains("-1"))
            //{
            //    options.Remove("-1");
            //    options.Add("3");
            //}
            //return options;
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
            else
            {
                options.Add(Answer.ToString(AnswerFormat));
                options.Add((Answer + type1).ToString(AnswerFormat));
                options.Add((Answer + type2).ToString(AnswerFormat));
                options.Add((Answer + type2 + type1).ToString(AnswerFormat));
            }

            return options;

        }


    }

    class Level1Commission : Commission
    {
        protected override int generateCommission()
        {
            return randomDigit(1, 3);
        }
    }
    class Level2Commission : Commission
    {
        protected override int generateCommission()
        {
            return randomDigit(3, 5);
        }
    }
    class Level3Commission : Commission
    {
        protected override int generateCommission()
        {
            return randomDigit(5,7);
        }
    }
    class Level4Commission : Commission
    {
        protected override int generateCommission()
        {
            return randomDigit(7, 9);
        }
    }
    class Level5Commission : Commission
    {
        protected override int generateCommission()
        {
            return randomDigit(9, 11);
        }
    }

}
