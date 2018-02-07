using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Fraction : Quiz
    {
        protected int QueType;
        protected int Numerator_1, Numerator_2, Numerator_3, Denominator_1, Denominator_2, Denominator_3, Numerator, Denominator;
        abstract protected int generateNumerator(int Denominator);
        String s;
        StringBuilder question;
        abstract protected int generateDenominator();
        protected string Answer;
      

        public Fraction()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {
            QueType = randomDigit(0, 3);

            switch (QueType)
            {
                case 0:
                    Denominator_1 = generateDenominator();
                    Denominator_2 = generateDenominator();
                    Numerator_1 = generateNumerator(Denominator_1);
                    Numerator_2 = generateNumerator(Denominator_2);
                    s = questionPrototype.ElementAt(0);
                    question = new StringBuilder(s);
                    question.Replace("Numerator_1", Numerator_1.ToString());
                    question.Replace("Numerator_2", Numerator_2.ToString());
                    question.Replace("Denominator_1", Denominator_1.ToString());
                    question.Replace("Denominator_2", Denominator_2.ToString());
                    break;

                case 1:
                    decimal Number1, Number2;
                    int temp;
                         s = questionPrototype.ElementAt(1);
                    question = new StringBuilder(s);
                    Denominator_1 = generateDenominator();
                    Denominator_2 = generateDenominator();
                    Numerator_1 = generateNumerator(Denominator_1);
                    Numerator_2 = generateNumerator(Denominator_2);
                    Number1 = Convert.ToDecimal(Numerator_1) / Convert.ToDecimal(Denominator_1);
                    Number2 = Convert.ToDecimal(Numerator_2) / Convert.ToDecimal(Denominator_2);
                    while (Number1 == Number2)
                    {
                        Denominator_1 = generateDenominator();
                        Denominator_2 = generateDenominator();
                        Numerator_1 = generateNumerator(Denominator_1);
                        Numerator_2 = generateNumerator(Denominator_2);

                        Number1 = Convert.ToDecimal(Numerator_1) / Convert.ToDecimal(Denominator_1);
                        Number2 = Convert.ToDecimal(Numerator_2) / Convert.ToDecimal(Denominator_2);
                    }
                    if (Number2 > Number1)
                    {
                        temp = Numerator_1;
                        Numerator_1 = Numerator_2;
                        Numerator_2 = temp;
                        temp = Denominator_1;
                        Denominator_1 = Denominator_2;
                        Denominator_2 = temp;
                    }
                    question.Replace("Numerator_1", Numerator_1.ToString());
                    question.Replace("Numerator_2", Numerator_2.ToString());
                    question.Replace("Denominator_1", Denominator_1.ToString());
                    question.Replace("Denominator_2", Denominator_2.ToString());
                    break;
                case 2:
                         s = questionPrototype.ElementAt(2);
                    question = new StringBuilder(s);
                    Denominator_1 = generateDenominator();
                    Denominator_2 = generateDenominator();
                    Denominator_3 = generateDenominator();
                    Numerator_1 = generateNumerator(Denominator_1);
                    Numerator_2 = generateNumerator(Denominator_2);
                    Numerator_3 = generateNumerator(Denominator_3);

                    Answer = OrderFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2, Numerator_3, Denominator_3);
                    while (Answer == "Error")
                    {
                        Denominator_1 = generateDenominator();
                        Denominator_2 = generateDenominator();
                        Denominator_3 = generateDenominator();
                        Numerator_1 = generateNumerator(Denominator_1);
                        Numerator_2 = generateNumerator(Denominator_2);
                        Numerator_3 = generateNumerator(Denominator_3);
                        Answer = OrderFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2, Numerator_3, Denominator_3);

                    }

                    question.Replace("Numerator_1", Numerator_1.ToString());
                    question.Replace("Numerator_2", Numerator_2.ToString());
                    question.Replace("Numerator_3", Numerator_3.ToString());
                    question.Replace("Denominator_1", Denominator_1.ToString());
                    question.Replace("Denominator_2", Denominator_2.ToString());
                    question.Replace("Denominator_3", Denominator_3.ToString());


                    break;
            }



            return question.ToString();
        }

        protected string OrderFractions(int N1, int D1, int N2, int D2, int N3, int D3)
        {
            int MaxNumber = 0, LCD = 0, temp = 0, Multiplier1 = 1, Multiplier2 = 1, Multiplier3 = 1;

            if ((D1 == D2) && (D1 == D3))
            {
                LCD = D1;
                Multiplier1 = 1;
                Multiplier2 = 1;
                Multiplier3 = 1;
            }
            else
            {
                if ((D1 >= D2) && (D1 >= D3))
                    LCD = D1;
                else if ((D2 >= D1) && (D2 >= D3))
                    LCD = D2;
                else if ((D3 >= D2) && (D3 >= D1))
                    LCD = D3;

                MaxNumber = D1 * D2 * D3;
                for (int i = 1; i <= MaxNumber; i++)
                {
                    temp = LCD * i;
                    if ((temp % D2 == 0) && (temp % D1 == 0) && (temp % D3 == 0))
                    {
                        LCD = temp;
                        Multiplier1 = LCD / D1;
                        Multiplier2 = LCD / D2;
                        Multiplier3 = LCD / D3;
                        break;
                    }
                }

            }

            Denominator = LCD;
            int Num1, Num2, Num3;
            Num1 = N1 * Multiplier1;
            Num2 = N2 * Multiplier2;
            Num3 = N3 * Multiplier3;

            if ((Num1 == Num2) || (Num2 == Num3) || (Num1 == Num3))
                return "Error";
            else
            {
                if ((Num1 > Num2) && (Num2 > Num3))
                    //1,2,3
                    return N1.ToString() + "/" + D1.ToString() + " > " + N2.ToString() + "/" + D2.ToString() + " > " + N3.ToString() + "/" + D3.ToString();
                else if ((Num1 > Num3) && (Num3 > Num2))
                    //1,3,2
                    return N1.ToString() + "/" + D1.ToString() + " > " + N3.ToString() + "/" + D3.ToString() + " > " + N2.ToString() + "/" + D2.ToString();
                else if ((Num2 > Num1) && (Num1 > Num3))
                    //2,1,3
                    return N2.ToString() + "/" + D2.ToString() + " > " + N1.ToString() + "/" + D1.ToString() + " > " + N3.ToString() + "/" + D3.ToString();
                else if ((Num2 > Num3) && (Num3 > Num1))
                    //2,3,1
                    return N2.ToString() + "/" + D2.ToString() + " > " + N3.ToString() + "/" + D3.ToString() + " > " + N1.ToString() + "/" + D1.ToString();
                else if ((Num3 > Num1) && (Num1 > Num2))
                    //3,1,2
                    return N3.ToString() + "/" + D3.ToString() + " > " + N1.ToString() + "/" + D1.ToString() + " > " + N2.ToString() + "/" + D2.ToString();
                else if ((Num3 > Num2) && (Num2 > Num1))
                    //3,2,1
                    return N3.ToString() + "/" + D3.ToString() + " > " + N2.ToString() + "/" + D2.ToString() + " > " + N1.ToString() + "/" + D1.ToString();
                else
                    return "Error";
            }
        }

        protected string addFractions(int N1, int D1, int N2, int D2)
        {
            int MaxNumber = 0, LCD = 0, temp = 0, Multiplier1 = 1, Multiplier2 = 1;

            if (D1 == D2)
            {
                LCD = D1;
                Multiplier1 = 1;
                Multiplier2 = 1;
            }
            else
            {
                if (D1 > D2)
                    LCD = D1;
                else if (D1 < D2)
                    LCD = D2;

                MaxNumber = D1 * D2;
                for (int i = 1; i <= MaxNumber; i++)
                {
                    temp = LCD * i;
                    if ((temp % D2 == 0) && (temp % D1 == 0))
                    {
                        LCD = temp;
                        Multiplier1 = LCD / D1;
                        Multiplier2 = LCD / D2;
                        break;
                    }
                }

            }

            Denominator = LCD;
            Numerator = (N1 * Multiplier1 + N2 * Multiplier2);
            int Min;

            if (Denominator == Numerator)
            {
                Numerator = 1;
                Denominator = 1;

            }
            else
            {
                if (Denominator > Numerator)
                    Min = Numerator;
                else
                    Min = Denominator;
                for (int i = Min; i >= 1; i--)
                {
                    if ((Numerator % i == 0) && (Denominator % i == 0))
                    {
                        Numerator = Numerator / i;
                        Denominator = Denominator / i;
                    }
                }
            }

            return Numerator.ToString() + " / " + Denominator.ToString();
        }

        protected string SubtractFractions(int N1, int D1, int N2, int D2)
        {
            int MaxNumber = 0, LCD = 0, temp = 0, Multiplier1 = 1, Multiplier2 = 1;

            if (D1 == D2)
            {
                LCD = D1;
                Multiplier1 = 1;
                Multiplier2 = 1;
            }
            else
            {
                if (D1 > D2)
                    LCD = D1;
                else if (D1 < D2)
                    LCD = D2;

                MaxNumber = D1 * D2;
                for (int i = 1; i <= MaxNumber; i++)
                {
                    temp = LCD * i;
                    if ((temp % D2 == 0) && (temp % D1 == 0))
                    {
                        LCD = temp;
                        Multiplier1 = LCD / D1;
                        Multiplier2 = LCD / D2;
                        break;
                    }
                }

            }

            Denominator = LCD;
            Numerator = (N1 * Multiplier1 - N2 * Multiplier2);

            int Min;

            if (Denominator == Numerator)
            {
                Numerator = 1;
                Denominator = 1;

            }
            else
            {
                if (Denominator > Numerator)
                    Min = Numerator;
                else
                    Min = Denominator;
                for (int i = Min; i >= 1; i--)
                {
                    if ((Numerator % i == 0) && (Denominator % i == 0))
                    {
                        Numerator = Numerator / i;
                        Denominator = Denominator / i;
                    }
                }
            }

            return Numerator.ToString() + " / " + Denominator.ToString();
        }
  
        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("Numerator_1/Denominator_1 + Numerator_2/Denominator_2");
            questionPrototype.Add("Numerator_1/Denominator_1 - Numerator_2/Denominator_2");
            questionPrototype.Add("Numerator_1/Denominator_1,Numerator_2/Denominator_2,Numerator_3/Denominator_3");

        }
      
        protected override List<String> createOptions()
        {
            switch (QueType)
            {
                case 0:
                    return AdditionOptions();
                    break;
                case 1:
                    return SubtractionOptions();
                    break;
                case 2:
                    return OrderOptions();
                    break;
                    }
            return null;
        }

        protected  List<String> AdditionOptions()
        {

            List<String> options = new List<String>();

            int type1, type2;
            type2 = randomDigit(1, 2);
            type1 = randomDigit(type2, 3);

            options.Add(addFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2));
            options.Add(addFractions(Numerator_1, Denominator_1 + type2, Numerator_2, Denominator_2));
            options.Add(addFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2 + type2));
            options.Add(addFractions(Numerator_1 + type1, Denominator_1, Numerator_2, Denominator_2));


            return options;

        }

        protected  List<String> SubtractionOptions()
        {

            List<String> options = new List<String>();

            int type1, type2;
            type2 = randomDigit(1, 2);
            type1 = randomDigit(type2, 3);


            options.Add(SubtractFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2));
            options.Add(SubtractFractions(Numerator_1, Denominator_1 + type2, Numerator_2, Denominator_2));
            options.Add(SubtractFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2 + type2));
            options.Add(SubtractFractions(Numerator_1 + type1, Denominator_1, Numerator_2, Denominator_2));

            return options;



        }

        protected List<String> OrderOptions()
        {

            List<String> options = new List<String>();

            int type1, type2;
            type2 = randomDigit(1, 2);
            type1 = randomDigit(type2, 3);
            string[] strValues = new string[3];
            strValues = Answer.Split('>');

            options.Add(Answer);
            options.Add(strValues[2].ToString().Trim() + " > " + strValues[1].ToString().Trim() + " > " + strValues[0].ToString().Trim());
            options.Add(strValues[2].ToString().Trim() + " > " + strValues[0].ToString().Trim() + " > " + strValues[1].ToString().Trim());
            options.Add(strValues[0].ToString().Trim() + " > " + strValues[2].ToString().Trim() + " > " + strValues[1].ToString().Trim());

            return options;
        }

        protected override string createAnswer()
        {
            switch (QueType)
             {
                case 0:
                      return addFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2);
                    break;
                case 1:
                       return SubtractFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2);
                    break;
                case 2:
                     return OrderFractions(Numerator_1, Denominator_1, Numerator_2, Denominator_2, Numerator_3, Denominator_3);
                    break;
                    }
            return null;
         
        }

    }
    class Level1Fraction: Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(2, 5);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, Denominator);
        }
}
    class Level2Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(2, 5);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, Denominator);
        }
    }
    class Level3Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(5, 10);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, 5);
        }





    }

    class Level4Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(5, 10);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(2, Denominator);
        }





    }

    class Level5Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(10, 15);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, 10);
        }

    }

    class Level6Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(10, 15);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(5, Denominator);
        }

    }
  
    class Level7Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(15, 20);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, 15);
        }

    }

    class Level8Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(15, 20);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(10, Denominator);
        }

    }
  
    class Level9Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(20, 25);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(1, 20);
        }

    }

    class Level10Fraction : Fraction
    {

        protected override int generateDenominator()
        {
            return randomDigit(20, 25);
        }

        protected override int generateNumerator(int Denominator)
        {
            return randomDigit(15, Denominator);
        }





    }
 
}
