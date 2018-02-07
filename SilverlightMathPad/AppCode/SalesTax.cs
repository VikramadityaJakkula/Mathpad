using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class SalesTax : Quiz
    {
        protected int Price_Org, SalesTax_Percnt, QueType;
        protected decimal SalesTax_Amt, Price_Act;
        protected decimal Answer;
        protected string AnswerFormat;
        abstract protected int generateSalesTax();
     //   abstract protected int generatePrice();
       // abstract protected decimal CalculateSalesTax();
      //  abstract protected decimal CalculatePriceAct();


        public SalesTax()
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
            SalesTax_Percnt = generateSalesTax();
            SalesTax_Amt = CalculateSalesTax();
            Price_Act = CalculatePriceAct();



            question.Replace("Price_Org", Price_Org.ToString());
            question.Replace("SalesTax_Percnt", SalesTax_Percnt.ToString());
            question.Replace("SalesTax_Amt", SalesTax_Amt.ToString());
            question.Replace("Price_Act", Price_Act.ToString());
            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("The original price of a Jacket was $Price_Org, and John has to pay sales tax of $SalesTax_Amt. What is the sales tax rate(%)?");
            questionPrototype.Add("Cedric was charged SalesTax_Percnt% as sales tax for purchase of a book, which meant $SalesTax_Amt. What was the price of book?");
            questionPrototype.Add("What is the total price, if price of 10 apples are $Price_Org and the sales tax at SalesTax_Percnt%?");
            questionPrototype.Add("How much did I spend if I brought a shirt of $Price_Org with sales tax of SalesTax_Percnt%?");
            questionPrototype.Add("The cost of the IPod is $Price_Org, but an amount of $SalesTax_Amt is charged as  sales tax. What is the sales tax rate(%)?");
        }

        protected  decimal CalculateSalesTax()
        {
            decimal Num;
            Num = (Convert.ToDecimal(Price_Org) * Convert.ToDecimal(SalesTax_Percnt)) / 100;
            return Num;
        }
        protected  decimal CalculatePriceAct()
        {
            decimal Num;
            Num = Price_Org + SalesTax_Amt;
            return Num;
        }
        protected override string createAnswer()
        {


            if (QueType == 0 || QueType == 4)
            {
                AnswerFormat = "p";
                Answer = SalesTax_Percnt;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "0.00";
                Answer = Price_Org;
            }

            else
            {
                AnswerFormat = "0.00";
                Answer = Price_Act;
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
        protected  int generatePrice()
        {


            if (QueType == 0)
                return randomDigit(5, 26) * 10;
            else if (QueType == 1)
                return randomDigit(5, 51) * 10;
            else if (QueType == 2)
                return randomDigit(1, 11) * 5;
            else if (QueType == 3)
                return randomDigit(5, 26) * 10;
            else
                return randomDigit(5, 51) * 10;
        }
    }

    class Level1SalesTax : SalesTax
    {
        protected override int generateSalesTax()
        {
            return randomDigit(1, 4);
        }
    }
    class Level2SalesTax : SalesTax
    {
        protected override int generateSalesTax()
        {
            return randomDigit(4, 7);
        }
    }
    class Level3SalesTax : SalesTax
    {
        protected override int generateSalesTax()
        {
            return randomDigit(7, 10);
        }
    }
    class Level4SalesTax : SalesTax
    {
        protected override int generateSalesTax()
        {
            return randomDigit(10, 13);
        }
    }
    class Level5SalesTax : SalesTax
    {
        protected override int generateSalesTax()
        {
            return randomDigit(13, 16);
        }
    }


}
