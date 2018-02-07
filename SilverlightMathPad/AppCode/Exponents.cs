using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Exponents : Quiz
    {
        protected int QueType;
        protected int number_1, number_2;
        String s;
        StringBuilder question;
        protected int Answer;
        abstract protected int generateNum_1();
        abstract protected int generateNumber_1();

        public Exponents()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {
            QueType = randomDigit(0, 4);

            switch (QueType)
            {
                case 0:
                    //Square
                    number_1 = generateNum_1();
                    Answer = number_1 * number_1;
                    s = questionPrototype.ElementAt(0);
                    question = new StringBuilder(s);
                    question.Replace("number_1", number_1.ToString());
                    break;

                case 1:
                    //Cube
                    number_1 = generateNum_1();
                    Answer = number_1 * number_1 * number_1;
                    s = questionPrototype.ElementAt(1);
                    question = new StringBuilder(s);
                    question.Replace("number_1", number_1.ToString());

                    break;
                case 2:
                    //Log
                    Answer = generateLogAnswer();
                    number_1 = generateNumber_1();
                    number_2 = generateLogNumber_2();
                    s = questionPrototype.ElementAt(2);
                    question = new StringBuilder(s);
                    question.Replace("number_1", number_1.ToString());
                    question.Replace("number_2", number_2.ToString());

                    break;
                case 3:
                    //Exponent
                    number_1 = generateNumber_1();
                    number_2 = generateExpNumber_2();
                    Answer = generateExpAnswer();
                    s = questionPrototype.ElementAt(3);
                    question = new StringBuilder(s);
                    question.Replace("number_1", number_1.ToString());
                    question.Replace("number_2", number_2.ToString());
                    break;
            }
            return question.ToString();
        }


        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Square of number_1?");
            questionPrototype.Add("Cube of number_1?");
            questionPrototype.Add("Log of number_2 to the Base number_1?");
            questionPrototype.Add("Evaluate : number_1^number_2");

        }

        protected override List<String> createOptions()
        {
            switch (QueType)
            {
                case 0:
                    return SquareOptions();
                    break;
                case 1:
                    return CubeOptions();
                    break;
                case 2:
                    return LogOptions();
                    break;
                case 3:
                    return ExpOptions();
                    break;
            }
            return null;
        }

        protected List<String> SquareOptions()
        {

            int type1, type2;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_1).ToString());
            options.Add(System.Math.Abs((number_1 * (number_1 + type1))).ToString());
            options.Add(System.Math.Abs((number_1 * (number_1 + type2))).ToString());
            options.Add(System.Math.Abs((number_1 * (number_1 + type1 + type2))).ToString());
            return options;


        }

        protected List<String> CubeOptions()
        {

            int type1, type2;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add(System.Math.Abs((number_1 * number_1 * number_1)).ToString());
            options.Add(System.Math.Abs((number_1 * number_1 * (number_1 + type1))).ToString());
            options.Add(System.Math.Abs((number_1 * number_1 * (number_1 + type2))).ToString());
            options.Add(System.Math.Abs((number_1 * number_1 * (number_1 + type1 + type2))).ToString());
            return options;


        }

        protected List<String> LogOptions()
        {

            int type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((Answer + type + i).ToString());

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }

            return options;


        }

        protected List<String> ExpOptions()
        {
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            type2 = (Answer + type2 * number_1) > 1 ? type2 : -type2;


            options.Add(Answer.ToString());
            options.Add((Answer + type1 * number_1).ToString());
            options.Add((Answer + type2 * number_1).ToString());
            options.Add((Answer + type2 * number_1 + type1 * number_2).ToString());

            return options;

        }

        protected override string createAnswer()
        {
            return Answer.ToString();
        }

        protected int generateLogAnswer()
        {
            return randomDigit(1, 6);

        }
        protected int generateExpAnswer()
        {
            return CalculateExponent(number_1, number_2);

        }
        protected int CalculateExponent(int Number, int Power)
        {
            int Num = Number;
            for (int i = Power; i > 1; i--)
                Num = Num * Number;

            return Num;
        }

        protected int generateLogNumber_2()
        {
            int Num = number_1;
            for (int i = Answer; i > 1; i--)
                Num = Num * number_1;

            return Num;
        }
        protected int generateExpNumber_2()
        {

            return randomDigit(2, 10);
        }
    }
    class Level1Exponent : Exponents
    {
        protected override int generateNum_1()
        {
            int Num1;
            Num1 = randomDigit(2, 25);
            return Num1;
        }


        protected override int generateNumber_1()
        {
            return randomDigit(2, 4);

        }

    }

    class Level2Exponent : Exponents
    {

        protected override int generateNum_1()
        {
            int Num1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Num1 = randomDigit(25, 50);
            else
            {
                Num1 = randomDigit(1, 10) * 10;
            }

            return Num1;
        }

        protected override int generateNumber_1()
        {
            return randomDigit(4, 7);

        }


    }

    class Level3Exponent : Exponents
    {
        protected override int generateNum_1()
        {
            int Num1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Num1 = randomDigit(50, 75);
            else
            {
                Num1 = randomDigit(1, 10) * 100;
            }

            return Num1;
        }

        protected override int generateNumber_1()
        {
            return randomDigit(7, 10);

        }

    }


    class Level4Exponent : Exponents
    {
        protected override int generateNum_1()
        {
            int Num1;
            int type = randomDigit(0, 2);

            if (type == 0)
                Num1 = randomDigit(75, 100);
            else
            {
                Num1 = randomDigit(1, 10) * 1000;
            }

            return Num1;
        }

        protected override int generateNumber_1()
        {
            return randomDigit(10, 13);

        }
    }

}
