using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class Subtraction : Quiz
    {
        protected int number_1, number_2;
        abstract protected int generateNumber_1();
        abstract protected int generateNumber_2(int number_1);
        public Subtraction()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {
            number_1 = generateNumber_1();
            number_2 = generateNumber_2(number_1);
            String s = questionPrototype.ElementAt(0);
            StringBuilder question = new StringBuilder(s);
            question.Replace("number_1", number_1.ToString());
            question.Replace("number_2", number_2.ToString());
            return question.ToString();
        }
       
        protected override List<String> createOptions()
        {
            return null;
        }

        protected override string createAnswer()
        {
            return (number_1 - number_2).ToString();
        }

       

        protected void expressNumber(int[] num, String[] place, StringBuilder s, int steps)
        {
            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} {1} +", num[i], place[i]);
            s.AppendFormat(" {0} {1} =", num[0], place[0]);

            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} +", num[i] * (int)Math.Pow(10, i));
            s.AppendFormat(" {0}", num[0]);

        }

        protected void expressBorrow(StringBuilder s, int[] num, String[] place, int i, int steps)
        {
            if (num[i + 1] == 0)
            {
                s.AppendFormat("<br> Since there are 0 {0} in {1} we borrow from higher place value.", place[i + 1], number_1);
                expressBorrow(s, num, place, i + 1, steps);
            }

            //               s.AppendFormat("<br> We can write {0} {1} = {2} {1} + 10 {3}", num[i + 1], place[i + 1], num[i + 1] - 1, place[i]);

            s.AppendFormat("<br> On borrowing 10 {0} from the {1} place value,", place[i], place[i + 1]);
            s.AppendFormat("<br> {0} in {1} place becomes {2} and {3} in {4} place becomes {5}.", num[i], place[i], num[i] + 10, num[i + 1], place[i + 1], num[i + 1] - 1);

            num[i + 1]--;
            num[i] += 10;
            //                expressNumber(num, place, s, steps);


        }

        //protected String buildSolution(int[] num1, int[] num2, int steps)
        //{
        //    StringBuilder s = new StringBuilder(4000);
        //    String[] place = new String[] { "Ones", "Tens", "Hundreds" };
        //    int diff = 0;
        //    int[] num = new int[steps];

        //    s.AppendFormat("<b> Expand the Numbers :</b><br> {0} = ", number_1);
        //    expressNumber(num1, place, s, steps);

        //    s.AppendFormat("<br> {0} = ", number_2);
        //    expressNumber(num2, place, s, steps);

        //    for (int i = 0; i < steps; i++)
        //    {

        //        s.AppendFormat("<br><br><b> Step {0}: Subtract the {1} place value.</b>", i + 1, place[i]);

        //        if (num1[i] < num2[i])
        //        {
        //            s.AppendFormat("<br> Since {0} &lt {1} , borrow 10 {2} from higher place value.", num1[i], num2[i], place[i]);
        //            expressBorrow(s, num1, place, i, steps);
        //        }
        //        s.AppendFormat("<br>Then {0} - {1} = {2} {3}", num1[i], num2[i], diff = num1[i] - num2[i], place[i]);
        //        s.AppendFormat("<br> {0} place value: {1} ", place[i], diff);

        //        num[i] = diff;
        //        diff = 0;
        //    }

        //    for (int i = 0; i < steps; i++)
        //        diff += num[i] * (int)Math.Pow(10, i);

        //    s.AppendFormat("<br><br><b> Answer : </b>");

        //    expressNumber(num, place, s, steps);
        //    s.AppendFormat(" = {0}", diff);

        //    return s.ToString();
        //}

        protected int[] expandNumber(int number, int size)
        {
            int[] num = new int[size];
            int i = 0;
            while (i < size)
            {
                num[i] = (number % 10);
                number /= 10;
                i++;
            }
            return num;
        }


        protected List<String> createOptionsSingleDigitAnswer()
        {
            int answer = number_1 - number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer + type + i).ToString());

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }

            if (options.Contains("-2"))
            {
                options.Remove("-2");
                options.Add("4");
            }


            return options;
        }

        protected List<String> createOptionsDoubleDigitAnswer()
        {
            int answer = number_1 - number_2;
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            type2 = (answer + type2) > 1 ? type2 : -type2;

            options.Add(answer.ToString());
            options.Add((answer + type1).ToString());
            options.Add((answer + type2).ToString());
            options.Add((answer + type2 + type1).ToString());

            return options;
        }


        protected List<String> createOptionsTripleDigitAnswer()
        {
            int answer = number_1 - number_2;
            List<String> options = new List<String>();

            int type1 = 0, type2 = 0, type3 = 0;

            switch (randomDigit(1, 4))
            {
                case 1:
                    type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
                    type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
                    type3 = randomDigit(1, 3) == 1 ? 100 : -100;
                    break;
                case 2:
                    type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
                    type2 = (randomDigit(1, 3) == 1) ? 100 : -100;
                    type3 = randomDigit(1, 3) == 1 ? 10 : -10;
                    break;
                case 3:
                    type1 = (randomDigit(1, 3) == 1) ? 100 : -100;
                    type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
                    type3 = randomDigit(1, 3) == 1 ? 1 : -1;
                    break;
            }

            options.Add(answer.ToString());
            options.Add((answer + type1 + (randomDigit(1, 3) == 1 ? type3 : 0)).ToString());
            options.Add((answer + type2 + (randomDigit(1, 3) == 1 ? type3 : 0)).ToString());
            options.Add((answer + type2 + type1 + (randomDigit(1, 3) == 1 ? type3 : 0)).ToString());

            return options;
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add(" number_1 - number_2  = ?");
           // questionPrototype.Add("<b> Evaluate :<br>&nbsp;&nbsp; number_1 <br>&nbsp;- number_2 </b>");
            /*questionPrototype.Add(" Evaluate :   number_1 - number_2 \n");
            questionPrototype.Add(" Daisy has number_1 tofees . Shee gave Bravo number_2  marbles. How many tofees does Daisy have now.\n");
            questionPrototype.Add(" I have number_1 $. If I spend number_2 $ , how much money dollars will be left?\n");
            questionPrototype.Add(" Try this : number_1 - number_2 ?\n");
            questionPrototype.Add(" A box has number_1 oranges . If number_2 oranges are removed from it, how many oranges are left in the box \n");
            questionPrototype.Add(" Peter had number_1 pins. He lost number_2 pins. How many pins does he have now?\n");
            questionPrototype.Add(" Fill in the Blank : \n number_1 - number_2 = ___________ \n");
            questionPrototype.Add(" Solve : \n number_1 - number_2 \n");
            questionPrototype.Add(" What is number_1 - number_2 ?\n");
            */
        }
    }

    class Level1Subtraction : Subtraction
    {
        protected override  int generateNumber_1()
        {
            return randomDigit(2, 10);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(1, number_1);
        }

        protected override List<String> createOptions()
        {
            return createOptionsSingleDigitAnswer();
        }

    }

    class Level2Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            return r.Next(11, 50);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2, second_digit = number_1 / 10, first_digit = number_1 % 10;
            do
            {
                number_2 = 0;
                number_2 += 10 * randomDigit(1, second_digit + 1) + randomDigit(0, first_digit + 1);
            } while (number_2 == number_1);

            return number_2;
        }

        protected override List<String> createOptions()
        {
            return createOptionsDoubleDigitAnswer();
        }



    }

    class Level3Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            return r.Next(51, 100);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2, second_digit = number_1 / 10, first_digit = number_1 % 10;
            do
            {
                number_2 = 0;
                number_2 += 10 * randomDigit(1, second_digit + 1) + randomDigit(0, first_digit + 1);
            } while (number_2 == number_1);

            return number_2;
        }

        protected override List<String> createOptions()
        {
            return createOptionsDoubleDigitAnswer();
        }

      

    }

    class Level4Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            int number_1 = 0;
            number_1 += 10 * randomDigit(2, 5) + randomDigit(0, 9);
            return number_1;
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = number_1 / 10, first_digit = number_1 % 10;
            number_2 += 10 * randomDigit(1, second_digit) + randomDigit(first_digit + 1, 10);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            return createOptionsDoubleDigitAnswer();
        }

        

    }

    class Level5Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            int number_1 = 0;
            number_1 += 10 * randomDigit(6, 10) + randomDigit(0, 9);
            return number_1;
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = number_1 / 10, first_digit = number_1 % 10;
            number_2 += 10 * randomDigit(1, second_digit) + randomDigit(first_digit + 1, 10);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            return createOptionsDoubleDigitAnswer();
        }



    }

    class Level6Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            return r.Next(101, 200);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2, third_digit = number_1 / 100, second_digit = (number_1 / 10) % 10, first_digit = number_1 % 10;

            do
            {
                number_2 = 0;
                number_2 += 100 * randomDigit(1, third_digit + 1) + 10 * randomDigit(0, second_digit + 1) + randomDigit(0, first_digit + 1);
            } while (number_2 == number_1);

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 - number_2;
            if (answer / 100 == 0)
                return createOptionsDoubleDigitAnswer();
            else
                return createOptionsTripleDigitAnswer();

        }

       
    }

    class Level7Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            return r.Next(201, 500);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2, third_digit = number_1 / 100, second_digit = (number_1 / 10) % 10, first_digit = number_1 % 10;

            do
            {
                number_2 = 0;
                number_2 += 100 * randomDigit(1, third_digit + 1) + 10 * randomDigit(0, second_digit + 1) + randomDigit(0, first_digit + 1);
            } while (number_2 == number_1);

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 - number_2;
            if (answer / 100 == 0)
                return createOptionsDoubleDigitAnswer();
            else
                return createOptionsTripleDigitAnswer();

        }


    }

    class Level8Subtraction : Subtraction
    {
        protected override int generateNumber_1()
        {
            return r.Next(501, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2, third_digit = number_1 / 100, second_digit = (number_1 / 10) % 10, first_digit = number_1 % 10;

            do
            {
                number_2 = 0;
                number_2 += 100 * randomDigit(1, third_digit + 1) + 10 * randomDigit(0, second_digit + 1) + randomDigit(0, first_digit + 1);
            } while (number_2 == number_1);

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 - number_2;
            if (answer / 100 == 0)
                return createOptionsDoubleDigitAnswer();
            else
                return createOptionsTripleDigitAnswer();

        }


    }

    class Level9Subtraction : Subtraction
    {
        int type = 1;
        protected override int generateNumber_1()
        {
            int number_1 = 0;
            switch (randomDigit(1, 3))
            {
                case 1:
                    type = 1;
                    number_1 += 100 * randomDigit(2, 5) + 10 * randomDigit(0, 9) + randomDigit(0, 10);
                    break;
                case 2:
                    type = 2;
                    number_1 += 10 * r.Next(11, 100) + randomDigit(0, 9);
                    break;
            }
            return number_1;

        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, third_digit = number_1 / 100, second_digit = (number_1 / 10) % 10, first_digit = number_1 % 10;
            switch (type)
            {
                case 1:
                    number_2 += 100 * randomDigit(1, third_digit) + 10 * randomDigit(second_digit + 1, 10) + randomDigit(0, first_digit + 1);
                    break;
                case 2:
                    number_2 += 10 * r.Next(10, number_1 / 10) + randomDigit(first_digit + 1, 10);
                    break;
            }
            return number_2;
        }

        protected override List<String> createOptions()
        {

            if ((number_1 - number_2) / 100 == 0)
                return createOptionsDoubleDigitAnswer();
            else
                return createOptionsTripleDigitAnswer();

        }

        
    }

    class Level10Subtraction : Subtraction
    {
        int type = 1;
        protected override int generateNumber_1()
        {
            int number_1 = 0;
            switch (randomDigit(1, 3))
            {
                case 1:
                    type = 1;
                    number_1 += 100 * randomDigit(6, 10) + 10 * randomDigit(0, 9) + randomDigit(0, 10);
                    break;
                case 2:
                    type = 2;
                    number_1 += 10 * r.Next(11, 100) + randomDigit(0, 9);
                    break;
            }
            return number_1;

        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, third_digit = number_1 / 100, second_digit = (number_1 / 10) % 10, first_digit = number_1 % 10;
            switch (type)
            {
                case 1:
                    number_2 += 100 * randomDigit(1, third_digit) + 10 * randomDigit(second_digit + 1, 10) + randomDigit(0, first_digit + 1);
                    break;
                case 2:
                    number_2 += 10 * r.Next(10, number_1 / 10) + randomDigit(first_digit + 1, 10);
                    break;
            }
            return number_2;
        }

        protected override List<String> createOptions()
        {

            if ((number_1 - number_2) / 100 == 0)
                return createOptionsDoubleDigitAnswer();
            else
                return createOptionsTripleDigitAnswer();

        }


    }

}
