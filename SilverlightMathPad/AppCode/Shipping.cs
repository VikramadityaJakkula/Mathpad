using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Shipping : Quiz
    {
        protected int Price_Org, Shipping_Percnt, QueType;
        protected decimal Shipping_Amt, Price_Act;
        protected decimal Answer;
        protected string AnswerFormat;
       abstract protected int generateShipping();
         //abstract protected int generatePrice();
        //abstract protected decimal CalculateShipping();
        //abstract protected decimal CalculatePriceAct();


        public Shipping()
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
            Shipping_Percnt = generateShipping();
            Shipping_Amt = CalculateShipping();
            Price_Act = CalculatePriceAct();



            question.Replace("Price_Org", Price_Org.ToString());
            question.Replace("Shipping_Percnt", Shipping_Percnt.ToString());
            question.Replace("Shipping_Amt", Shipping_Amt.ToString());
            question.Replace("Price_Act", Price_Act.ToString());
            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("If the cost of a computer is $Price_Org with shipping charges of Shipping_Percnt%, calculate the shipping price?");
            questionPrototype.Add("The cost of a watch is $Price_Org with shipping charges of $Shipping_Amt. What is the shipping rate in percent(%)?");
            questionPrototype.Add("Cedric was charged Shipping_Percnt% as shipping charge for purchasing a book, which costed $Shipping_Amt. What was the price of book?");
            questionPrototype.Add("A CD that costs $Price_Org is being sold for $Price_Act including Shipping charges. Calculate shipping price?");
            questionPrototype.Add("The price of the IPod is $Price_Org. If shipping charge is Shipping_Percnt%, what is the total cost?");
        }
        protected  decimal CalculateShipping()
        {
            decimal Num;
            Num = (Convert.ToDecimal(Price_Org) * Convert.ToDecimal(Shipping_Percnt)) / 100;
            return Num;
        }
        protected  decimal CalculatePriceAct()
        {
            decimal Num;
            Num = Price_Org + Shipping_Amt;
            return Num;
        }
        protected override string createAnswer()
        {

            if (QueType == 0)
            {
                AnswerFormat = "0.00";
                Answer = Price_Act;
            }
            else if (QueType == 1)
            {
                AnswerFormat = "p";
                Answer = Shipping_Percnt;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "0.00";
                Answer = Price_Org;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "0.00";
                Answer = Shipping_Amt;
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
                return randomDigit(25, 51) * 10;
            else if (QueType == 1)
                return randomDigit(1, 26) * 10;
            else if (QueType == 2)
                return randomDigit(1, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;

            else
                return randomDigit(1, 11) * 5;



        }
    }


    class Level1Shipping : Shipping
    {
        protected override int generateShipping()
        {
            return randomDigit(1, 3);
        }
    }
    class Level2Shipping : Shipping
    {
        protected override int generateShipping()
        {
            return randomDigit(3, 5);
        }
    }
    class Level3Shipping : Shipping
    {
        protected override int generateShipping()
        {
            return randomDigit(5, 7);
        }
    }
    class Level4Shipping : Shipping
    {
        protected override int generateShipping()
        {
            return randomDigit(7, 9);
        }
    }
    class Level5Shipping : Shipping
    {
        protected override int generateShipping()
        {
            return randomDigit(9, 11);
        }
    }


}
