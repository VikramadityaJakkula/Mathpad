using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class Division : Quiz
    {
        abstract protected int generateNumber_1();
        abstract protected int generateNumber_2(int number_1);
        protected int number_1, number_2;
         public Division()
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
        // number_1 = dividend number_2 = divisor
        
        protected override List<String> createOptions()
        {
            return new List<string>();
        }

        protected string createAnswerWithoutRemainder()
        {
            return (number_1 / number_2).ToString();
        }

        protected string createAnswerWithRemainder()
        {
            return ((number_1 / number_2) + ", Remainder: " + (number_1 % number_2)).ToString();
        }

       

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

        protected void expressNumber(int[] num, String[] place, StringBuilder s, int steps)
        {
            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} {1} +", num[i], place[i]);
            s.AppendFormat(" {0} {1} =", num[0], place[0]);

            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} +", num[i] * (int)Math.Pow(10, i));
            s.AppendFormat(" {0}", num[0]);

        }


        //protected String buildSolution(int[] num1 , int num2, int steps)
        //{
        //    StringBuilder s = new StringBuilder(4000);
        //    String[] place = new String[] { "Ones", "Tens", "Hundreds" };
        //    int dividend=0,quotient=0,rem=0;
        //    int[] num = new int[steps];

        //    s.AppendFormat("<br> Use the Long Division to solve . Each step has Division,Multiplication,followed by Subtraction.[DMS]");
        //    s.AppendFormat("<br><br><b> Expand: </b> {0} = ", number_1);
        //    expressNumber(num1, place, s, steps);

        //    for (int i = steps-1; i >= 0; i--)
        //    {

        //        s.AppendFormat("<br><br><b> Step {0}: Consider the {1} place value.</b>", steps - i, place[i]);
        //        s.AppendFormat("<br> Old Remainder = {0}", rem, num2);
        //        s.AppendFormat("<br> New Dividend = Old Remainder X 10 + {3} Place Value = {0} X 10 + {1} = {2}", rem, num1[i], dividend = rem * 10 + num1[i], place[i]);
        //        s.AppendFormat("<br> D: Number of {3} in Quotient = New Dividend / Divisor = {0} / {1} = {2}", dividend, num2, dividend / num2, place[i]);
        //        s.AppendFormat("<br> M: {0} X {1} = {2} ", num2, dividend / num2, num2 * (dividend / num2));
        //        s.AppendFormat("<br> S: Remainder = {0} - {1} = {2} ", dividend, num2 * (dividend / num2), dividend % num2);
        //        rem = dividend%num2;
        //        num[i] = dividend / num2;
        //    }        
             

        //    for (int i = 0; i < steps; i++)
        //        quotient += num[i] * (int)Math.Pow(10, i);

        //    s.AppendFormat("<br><br> Quotient =");
        //    expressNumber(num , place, s, steps);
        //    s.AppendFormat(" = {0}", quotient);
        //    s.AppendFormat("<br> Remainder = {0}<br />", rem);
        //    return s.ToString();
        //}

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add(" number_1 ÷ number_2  = ?");
           // questionPrototype.Add("<b> Evaluate :<br>&nbsp;&nbsp; number_1 <br>&nbsp;&divide number_2 </b>");
            /*questionPrototype.Add(" Subtract :\n  number_2 from number_1 \n");
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
 
        protected int swap(int number_1,int number_2)
        {
            this.number_1 = number_2;
            return number_1;
        }
    }

    class Level1Division : Division
    {
        protected override int generateNumber_1()
        {
            return randomDigit(1, 6);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, max = (int)Math.Ceiling(10.0/number_1);
            number_2 = number_1 * randomDigit(1, max);
            return swap(number_1,number_2);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 / number_2, type = -randomDigit(0, 4);
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

        protected override string createAnswer()
        {
            return createAnswerWithoutRemainder();    
        }

      


    }

    class Level2Division : Division
    {
        protected override int generateNumber_1()
        {  
            return randomDigit(3,10);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0;
            do
            {
                number_2 = randomDigit(2, number_1);
            } while (number_1 % number_2 == 0);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int quo = number_1 / number_2, rem = number_1 % number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            int type1 = randomDigit(1, 3) == 1 ? -1 : 1;
            int type2 = randomDigit(1, 3) == 1 ? -1 : 1;

            if (rem + type1 == 0)
                type1 = -type1;

            options.Add((quo + ", Remainder: " + rem).ToString());
            options.Add((quo+", Remainder: "+(rem+type1)).ToString());
            options.Add(((quo+type2)+", Remainder: "+rem).ToString());
            options.Add(((quo+type2)+", Remainder: "+(rem+type1)).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithRemainder();    
        }

       
    }

    class Level3Division : Division
    {
        protected override int generateNumber_1()
        {
            return randomDigit(2,10);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, max = (int)Math.Ceiling(100.0/number_1) , min = (int)Math.Ceiling(10.0/number_1);
            number_2 = number_1 * r.Next(min, max);
            return swap(number_1,number_2);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 / number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer + type + i).ToString());

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithoutRemainder();
        }

       

    }

    class Level4Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(10,100);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0;
            do
            {
               number_2 = randomDigit(2, 10);
            } while (number_1 % number_2 == 0);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int quo = number_1 / number_2, rem = number_1 % number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            int type1 = randomDigit(1, 3) == 1 ? -1 : 1;
            int type2 = randomDigit(1, 3) == 1 ? -1 : 1;

            if (rem + type1 == 0)
                type1 = -type1;

            options.Add((quo + ", Remainder: " + rem).ToString());
            options.Add((quo + ", Remainder: " + (rem + type1)).ToString());
            options.Add(((quo + type2) + ", Remainder: " + rem).ToString());
            options.Add(((quo + type2) + ", Remainder: " + (rem + type1)).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithRemainder();
        }

      
    }

    class Level5Division : Division
    {
        protected override int generateNumber_1()
        {
            return randomDigit(2, 10);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, max = (int)Math.Ceiling(1000.0/number_1) , min = (int)Math.Ceiling(100.0/number_1);
            number_2 = number_1 * r.Next(min,max);
            return swap(number_1, number_2);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 / number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer + type + i).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithoutRemainder();
        }

        

    }

    class Level6Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0;
            do
            {
                number_2 = randomDigit(2, 10);
            } while (number_1 % number_2 == 0);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int quo = number_1 / number_2, rem = number_1 % number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            int type1 = randomDigit(1, 3) == 1 ? -1 : 1;
            int type2 = randomDigit(1, 3) == 1 ? -1 : 1;

            if (rem + type1 == 0)
                type1 = -type1;

            options.Add((quo + ", Remainder: " + rem).ToString());
            options.Add((quo + ", Remainder: " + (rem + type1)).ToString());
            options.Add(((quo + type2) + ", Remainder: " + rem).ToString());
            options.Add(((quo + type2) + ", Remainder: " + (rem + type1)).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithRemainder();
        }

       
    }

    class Level7Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(10,50);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, min=2, max = (int)Math.Ceiling(100.0/number_1);
            number_2 = number_1 * randomDigit(min, max);
            return swap(number_1,number_2);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 / number_2, type = -randomDigit(0, 4);
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

        protected override string createAnswer()
        {
            return createAnswerWithoutRemainder();
        }

       
    }

    class Level8Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(11,100);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0;
            do
            {
                number_2 = randomDigit(10, number_1);
            } while (number_1 % number_2 == 0);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int quo = number_1 / number_2, rem = number_1 % number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            int type1 = randomDigit(1, 3) == 1 ? -1 : 1;
            int type2 = randomDigit(1, 3) == 1 ? -1 : 1;

            if (rem + type1 == 0)
                type1 = -type1;

            options.Add((quo + ", Remainder: " + rem).ToString());
            options.Add((quo + ", Remainder: " + (rem + type1)).ToString());
            options.Add(((quo + type2) + ", Remainder: " + rem).ToString());
            options.Add(((quo + type2) + ", Remainder: " + (rem + type1)).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithRemainder();
        }

      
    }

    class Level9Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(10,100);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, max = (int)Math.Ceiling(1000.0 / number_1), min = (int)Math.Ceiling(100.0 / number_1);
            number_2 = number_1 * r.Next(min, max);
            return swap(number_1, number_2);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 / number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer + type + i).ToString());

            if (options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }


            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithoutRemainder();
        }

       
    }

    class Level10Division : Division
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0;
            do
            {
                number_2 = r.Next(10,100);
            } while (number_1 % number_2 == 0);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int quo = number_1 / number_2, rem = number_1 % number_2, type = -randomDigit(0, 4);
            List<String> options = new List<String>();

            int type1 = randomDigit(1, 3) == 1 ? -1 : 1;
            int type2 = randomDigit(1, 3) == 1 ? -1 : 1;

            if (rem + type1 == 0)
                type1 = -type1;

            options.Add((quo + ", Remainder: " + rem).ToString());
            options.Add((quo + ", Remainder: " + (rem + type1)).ToString());
            options.Add(((quo + type2) + ", Remainder: " + rem).ToString());
            options.Add(((quo + type2) + ", Remainder: " + (rem + type1)).ToString());

            return options;
        }

        protected override string createAnswer()
        {
            return createAnswerWithRemainder();
        }

       
    }

}
