using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Discount : Quiz
    {
        protected int Price_Org, Discount_Percnt, QueType;
        protected decimal Discount_Amt, Price_Act;
        protected decimal Answer;
        protected string AnswerFormat;
        abstract protected int generateDiscount();
        abstract protected int generatePrice();
       // abstract protected decimal CalculateDiscount();
        //abstract protected decimal CalculatePriceAct();


        public Discount()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            QueType = randomDigit(0, 6);

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
            else
                s = questionPrototype.ElementAt(5);

            StringBuilder question = new StringBuilder(s);

            Price_Org = generatePrice();
            Discount_Percnt = generateDiscount();
            Discount_Amt = CalculateDiscount();
            Price_Act = CalculatePriceAct();



            question.Replace("Price_Org", Price_Org.ToString());
            question.Replace("Discount_Percnt", Discount_Percnt.ToString());
            question.Replace("Discount_Amt", Discount_Amt.ToString());
            question.Replace("Price_Act", Price_Act.ToString());
            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {

            questionPrototype.Add("The original price of a Calculator was $Price_Org, and Cedric got a Discount_Percnt% discount. How much was the discount?");
            questionPrototype.Add("The original price of a Jacket was $Price_Org, and John got a $Discount_Amt discount. How many percent off was the discount?");
            questionPrototype.Add("Ned's discount was Discount_Percnt% off the original price, which meant a $Discount_Amt discount. What was the original price?");
            questionPrototype.Add("A quality pen that normally costs $Price_Org is being sold for only $Price_Act. Calculate percentage of the marked price?");
            questionPrototype.Add("A movie ticket at PVR Cinemas is $Price_Org. On Tuesdays they offer Discount_Percnt% discount. How much the ticket cost on Tuesdays?");
            questionPrototype.Add("A store is giving Discount_Percnt% discount. John purchased a CD and paid $Price_Act. What is the actual price of this CD?");
        }

        protected  decimal CalculateDiscount()
        {
            decimal Num;
            Num = (Convert.ToDecimal(Price_Org) * Convert.ToDecimal(Discount_Percnt)) / 100;
            return Num;
        }
        protected  decimal CalculatePriceAct()
        {
            decimal Num;
            Num = Price_Org - Discount_Amt;
            return Num;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Discount_Amt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "p";
                Answer = Discount_Percnt;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "0.00";
                Answer = Price_Org;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "p";
                Answer = Discount_Percnt;
            }
            else if (QueType == 4)
            {
                AnswerFormat = "0.00";
                Answer = Price_Act;
            }
            else
            {
                AnswerFormat = "0.00";
                Answer = Price_Org;
            }
            if (AnswerFormat == "0.00")
                return Answer.ToString(AnswerFormat);
            else
                return Answer.ToString() + "%";

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
            else
            {
                options.Add(Answer.ToString(AnswerFormat));
                options.Add((Answer + type1).ToString(AnswerFormat));
                options.Add((Answer + type2).ToString(AnswerFormat));
                options.Add((Answer + type2 + type1).ToString(AnswerFormat));
            }

            return options;
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
            //    options.Add(Answer.ToString(AnswerFormat));
            //    options.Add((Answer + type1).ToString(AnswerFormat));
            //    options.Add((Answer + type2).ToString(AnswerFormat));
            //    options.Add((Answer + type2 + type1).ToString(AnswerFormat));
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



        }
    }


    class Level1Discount : Discount
    {

        protected override int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else if (QueType == 4)
                return randomDigit(1, 6) * 5;
            else
                return randomDigit(1, 11) * 5;



        }
        protected override int generateDiscount()
        {
            return randomDigit(1, 11);
        }

    }
    class Level2Discount : Discount
    {

        protected override int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else if (QueType == 4)
                return randomDigit(1, 6) * 5;
            else
                return randomDigit(1, 11) * 5;



        }
        protected override int generateDiscount()
        {
            return randomDigit(11, 21);
        }

    }
    class Level3Discount : Discount
    {

        protected override int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else if (QueType == 4)
                return randomDigit(1, 6) * 5;
            else
                return randomDigit(1, 11) * 5;



        }
        protected override int generateDiscount()
        {
            return randomDigit(21, 31);
        }

    }
    class Level4Discount : Discount
    {

        protected override int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else if (QueType == 4)
                return randomDigit(1, 6) * 5;
            else
                return randomDigit(1, 11) * 5;



        }
        protected override int generateDiscount()
        {
            return randomDigit(31, 41);
        }

    }
    class Level5Discount : Discount
    {

        protected override int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else if (QueType == 4)
                return randomDigit(1, 6) * 5;
            else
                return randomDigit(1, 11) * 5;



        }
        protected override int generateDiscount()
        {
            return randomDigit(41, 51);
        }

    }
}
