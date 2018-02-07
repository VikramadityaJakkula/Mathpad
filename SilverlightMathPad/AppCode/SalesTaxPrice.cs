using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class SalesTaxPrice : Quiz
    {
        protected int Price_Org, SalesTaxPrice_Percnt, QueType;
        protected decimal SalesTaxPrice_Amt, Price_Act;
        protected decimal Answer;
        protected string AnswerFormat;
        abstract protected int generateSalesTaxPrice();
     //   abstract protected int generatePrice();
       // abstract protected decimal CalculateSalesTaxPrice();
        //abstract protected decimal CalculatePriceAct();


        public SalesTaxPrice()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            QueType = randomDigit(0, 5);

            String s;


            if (QueType == 0)
                s = questionPrototype.ElementAt(0);
            else if (QueType == 1)
                s = questionPrototype.ElementAt(1);
            else if (QueType == 2)
                s = questionPrototype.ElementAt(2);
            else if (QueType == 3)
                s = questionPrototype.ElementAt(3);
            else
                s = questionPrototype.ElementAt(4);


            StringBuilder question = new StringBuilder(s);

            Price_Org = generatePrice();
            SalesTaxPrice_Percnt = generateSalesTaxPrice();
            SalesTaxPrice_Amt = CalculateSalesTaxPrice();
            Price_Act = CalculatePriceAct();



            question.Replace("Price_Org", Price_Org.ToString());
            question.Replace("SalesTaxPrice_Percnt", SalesTaxPrice_Percnt.ToString());
            question.Replace("SalesTaxPrice_Amt", SalesTaxPrice_Amt.ToString());
            question.Replace("Price_Act", Price_Act.ToString());
            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("The price of a calculator was $Price_Org. What is the total bill amount if sales tax is SalesTaxPrice_Percnt%?");
            questionPrototype.Add("The price of a doll is $Price_Org. If sales tax is SalesTaxPrice_Percnt% what is the bill amount?");
            questionPrototype.Add("A music CD costs $Price_Org, excluding sales tax. Calculate the total cost if sales tax is SalesTaxPrice_Percnt%?");
            questionPrototype.Add("A pen that costs $Price_Org is being sold for $Price_Act including Sales tax. Calculate percentage of the sales tax(%)?");
            questionPrototype.Add("A Shirt which costs $Price_Org is sold for $Price_Act including Sales tax. Calculate percentage of the sales tax(%)?");
        }

        protected  int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(1, 31) * 10;
            else if (QueType == 1)
                return randomDigit(1, 51) * 10;
            else if (QueType == 2)
                return randomDigit(1, 21) * 2;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;
            else
                return randomDigit(1, 11) * 5;
        }

        protected  decimal CalculateSalesTaxPrice()
        {
            decimal Num;
            Num = (Convert.ToDecimal(Price_Org) * Convert.ToDecimal(SalesTaxPrice_Percnt)) / 100;
            return Num;
        }
        protected  decimal CalculatePriceAct()
        {
            decimal Num;
            Num = Price_Org + SalesTaxPrice_Amt;
            return Num;
        }
        protected override string createAnswer()
        {

            if (QueType == 0 || QueType == 1 || QueType == 2)
            {
                AnswerFormat = "0.00";
                Answer = Price_Act;
            }
            else if (QueType == 3 || QueType == 4)
            {
                AnswerFormat = "p";
                Answer = SalesTaxPrice_Percnt;
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

    class Level1SalesTaxPrice : SalesTaxPrice
    {
        protected override int generateSalesTaxPrice()
        {
            return randomDigit(1, 4);
        }
    }
    class Level2SalesTaxPrice : SalesTaxPrice
    {
        protected override int generateSalesTaxPrice()
        {
            return randomDigit(4, 7);
        }
    }
    class Level3SalesTaxPrice : SalesTaxPrice
    {
        protected override int generateSalesTaxPrice()
        {
            return randomDigit(7, 10);
        }
    }
    class Level4SalesTaxPrice : SalesTaxPrice
    {
        protected override int generateSalesTaxPrice()
        {
            return randomDigit(10, 13);
        }
    }
    class Level5SalesTaxPrice : SalesTaxPrice
    {
        protected override int generateSalesTaxPrice()
        {
            return randomDigit(13, 16);
        }
    }


}
