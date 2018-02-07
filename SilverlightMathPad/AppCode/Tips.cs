using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Tips : Quiz
    {
        protected int Price_Org, Tips_Percnt, QueType;
        protected decimal Tips_Amt, Price_Act;
        protected decimal Answer;
        protected string AnswerFormat;
        abstract protected int generateTips();
      //  abstract protected int generatePrice();
      //  abstract protected decimal CalculateTips();
      //  abstract protected decimal CalculatePriceAct();


        public Tips()
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
            Tips_Percnt = generateTips();
            Tips_Amt = CalculateTips();
            Price_Act = CalculatePriceAct();



            question.Replace("Price_Org", Price_Org.ToString());
            question.Replace("Tips_Percnt", Tips_Percnt.ToString());
            question.Replace("Tips_Amt", Tips_Amt.ToString());
            question.Replace("Price_Act", Price_Act.ToString());
            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("If the bill amount at restaurant is $Price_Org and you decide to give a tip of Tips_Percnt%, calculate the total Amount paid?");
            questionPrototype.Add("Sandra had a bill of $Price_Org at the Parlour, and she paid a tip of $Tips_Amt. What is the percentage tip rate(%)?");
            questionPrototype.Add("John usually pays tip of Tips_Percnt%. What is the bill amount if he paid the waiter $Tips_Amt?");
            questionPrototype.Add("For a drink which costs $Price_Org, bar attender was paid $Price_Act. Calculate percentage of tip(%)?");
            questionPrototype.Add("The price of a hair cut in a Spa $Price_Org. If tip charge is Tips_Percnt%, what is the total cost?");

        }
        protected  decimal CalculateTips()
        {
            decimal Num;
            Num = (Convert.ToDecimal(Price_Org) * Convert.ToDecimal(Tips_Percnt)) / 100;
            return Num;
        }
        protected  decimal CalculatePriceAct()
        {
            decimal Num;
            Num = Price_Org + Tips_Amt;
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
                Answer = Tips_Percnt;
            }
            else if (QueType == 2)
            {
                AnswerFormat = "0.00";
                Answer = Price_Org;
            }
            else if (QueType == 3)
            {
                AnswerFormat = "p";
                Answer = Tips_Percnt;
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
                return randomDigit(10, 26) * 10;
            else if (QueType == 2)
                return randomDigit(10, 51) * 10;
            else if (QueType == 3)
                return randomDigit(1, 11) * 2;

            else
                return randomDigit(3, 11) * 5;



        }
    }


    class Level1Tips : Tips
    {
        protected override int generateTips()
        {
            return randomDigit(9, 12);
        }

    }
    class Level2Tips : Tips
    {
        protected override int generateTips()
        {
            return randomDigit(12, 15);
        }

    }
    class Level3Tips : Tips
    {
        protected override int generateTips()
        {
            return randomDigit(15, 18);
        }

    }
    class Level4Tips : Tips
    {
        protected override int generateTips()
        {
            return randomDigit(18, 21);
        }

    }
    class Level5Tips : Tips
    {
        protected override int generateTips()
        {
            return randomDigit(21, 24);
        }

    }

}
