using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class Multiplication : Quiz
    {
        protected int number_1, number_2;

        abstract protected int generateNumber_1();
        abstract protected int generateNumber_2(int number_1);

        public Multiplication()
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
            return (number_1 * number_2).ToString();
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

        protected String buildSolution(int[] num1, int steps)
        {
            StringBuilder s = new StringBuilder(4000);
            String[] place = new String[] { "Ones", "Tens", "Hundreds" };
            int sum = 0;
            int[] num = new int[steps];

            s.AppendFormat("<b> Expand : </b>{0} = ", number_1);
            expressNumber(num1, place, s, steps);

            for (int i = 0; i < steps; i++)
            {

                s.AppendFormat("<br><br> <b>Step {0}: Multiply the {1} </b>", i + 1, place[i]);
                s.AppendFormat("<br>The {4} place value in {5} is {1}.<br> {0} X {1} X {2} = {3}", number_2, num1[i], (int)Math.Pow(10, i),
                                  sum = num1[i] * number_2 * (int)Math.Pow(10, i), place[i], number_1);
                num[i] = sum;
                sum = 0;
            }

            for (int i = 0; i < steps; i++)
                sum += num[i];

            s.AppendFormat("<br><br><b> Answer :</b>");

            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} +", num[i]);
            s.AppendFormat(" {0} = {1}", num[0], sum);

            return s.ToString();

        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add(" number_1 x number_2  = ?");
            // questionPrototype.Add("<b> Evaluate :<br>&nbsp;&nbsp; number_1 <br>&nbsp;x number_2 </b>");
            /*questionPrototype.Add(" Multiply :\n  number_2 with number_1 \n");
            questionPrototype.Add(" I have number_1 boxes . Each box has number_2 kites. How many kites do I have?\n");
            questionPrototype.Add(" Robin bought number_1 gifts. Each gift costs number_2 $ . How much should he pay?\n");
            questionPrototype.Add(" Try this : number_1 X number_2 ?\n");
            questionPrototype.Add(" Each class has number_2 kids. If there are number_2 classes in the school, how many kids are there in the school? \n");
            questionPrototype.Add(" I have number_2 friends. If I want to give each of them number_2 pencils, how many pencils should I buy? \n");
            questionPrototype.Add(" Fill in the Blank : \n number_1 X number_2 = ___________ \n");
            questionPrototype.Add(" Solve : \n number_1 X number_2 \n");
            questionPrototype.Add(" What is number_1 X number_2 ?\n");
            */
        }
    }

    class Level1Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return randomDigit(1, 6);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(2, 6);
        }

        protected override List<String> createOptions()
        {
            int type = -randomDigit(0, 4);
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
            {

                if (number_2 + type + i > 0)
                    options.Add((number_1 * (number_2 + type + i)).ToString());
                else
                    options.Add((number_1 * -(number_2 + type + i)).ToString());
            }

            return options;
        }



    }
    class Level2Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return randomDigit(5, 10);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(6, 10);
        }

        protected override List<String> createOptions()
        {
            int type = -randomDigit(0, 4);
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
            {

                if (number_2 + type + i > 0)
                    options.Add((number_1 * (number_2 + type + i)).ToString());
                else
                    options.Add((number_1 * -(number_2 + type + i)).ToString());
            }

            return options;
        }



    }
    class Level3Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return (randomDigit(1, 6) * 10) + randomDigit(1, 6);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(2, 6);
        }

        protected override List<String> createOptions()
        {
            int type1, type2;
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1)).ToString());
            options.Add((number_1 * (number_2 + type2)).ToString());
            options.Add((number_1 * (number_2 + type1 + type2)).ToString());
            return options;
        }



    }
    class Level4Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return (randomDigit(1, 6) * 10) + randomDigit(1, 6);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(2, 10);
        }

        protected override List<String> createOptions()
        {
            int type1, type2;
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1)).ToString());
            options.Add((number_1 * (number_2 + type2)).ToString());
            options.Add((number_1 * (number_2 + type1 + type2)).ToString());
            return options;
        }



    }
    class Level5Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return randomDigit(10, 100);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(2, 10);
        }

        protected override List<String> createOptions()
        {
            int type1, type2;
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1)).ToString());
            options.Add((number_1 * (number_2 + type2)).ToString());
            options.Add((number_1 * (number_2 + type1 + type2)).ToString());
            return options;
        }



    }
    class Level6Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return (randomDigit(1, 6) * 10) + randomDigit(1, 6);
        }

        protected override int generateNumber_2(int number_1)
        {
            return (randomDigit(1, 6) * 10) + randomDigit(1, 6);
        }

        protected override List<String> createOptions()
        {
            int type1, type2;
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1)).ToString());
            options.Add((number_1 * (number_2 + type2)).ToString());
            options.Add((number_1 * (number_2 + type1 + type2)).ToString());
            return options;
        }



    }
    class Level7Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return r.Next(10, 100);
        }

        protected override int generateNumber_2(int number_1)
        {
            return r.Next(10, 100);
        }

        protected override List<String> createOptions()
        {
            int type1, type2;
            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

            List<String> options = new List<String>();

            type1 = randomDigit(1, 3) == 1 ? -1 : +1;
            type2 = randomDigit(1, 3) == 1 ? -10 : +10;

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1)).ToString());
            options.Add((number_1 * (number_2 + type2)).ToString());
            options.Add((number_1 * (number_2 + type1 + type2)).ToString());
            return options;
        }



    }
    class Level8Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            return r.Next(1, 10);
        }

        protected override List<String> createOptions()
        {

            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

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

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type1 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            return options;

        }




    }
    class Level9Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            return r.Next(10, 100);
        }

        protected override List<String> createOptions()
        {

            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

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

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type1 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            return options;

        }




    }
    class Level10Multiplication : Multiplication
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            return r.Next(100, 1000);
        }

        protected override List<String> createOptions()
        {

            int number_1 = this.number_1 <= this.number_2 ? this.number_1 : this.number_2,
                number_2 = (this.number_2 * this.number_1) / number_1;

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

            options.Add((number_1 * number_2).ToString());
            options.Add((number_1 * (number_2 + type1 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            options.Add((number_1 * (number_2 + type1 + type2 + (randomDigit(1, 3) == 1 ? type3 : 0))).ToString());
            return options;

        }




    }

}
