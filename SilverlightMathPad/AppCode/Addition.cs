using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverlightMathPad
{
    abstract class Addition : Quiz
    {
                protected int number_1, number_2;
       
        abstract protected int generateNumber_1();
        abstract protected int generateNumber_2(int number_1);

        public Addition()
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
        protected int[] expandNumber(int number,int size)
        {
            int[] num = new int[size];
            int i = 0;
            while(i<size)
            {
                num[i]=(number % 10);
                number /= 10;
                i++;
            }
            return num;
        }

        protected void expressNumber(int[] num, String[] place, StringBuilder s,int steps)
        {
            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} {1} +", num[i], place[i]);
            s.AppendFormat(" {0} {1} =", num[0], place[0]);

            for (int i = steps - 1; i > 0; i--)
                s.AppendFormat(" {0} +", num[i]*(int)Math.Pow(10,i));
            s.AppendFormat(" {0}", num[0]);

        }

        //protected String buildSolution(int[] num1, int[] num2 , int steps)
        //{
        //    StringBuilder s = new StringBuilder(4000);
        //    String[] place = new String[] {"Ones", "Tens", "Hundreds" };
        //    int carry = 0, sum=0;
        //    int[] num = new int[steps];

        //    s.AppendFormat("<b> Expand the Numbers:</b><br> {0} = ", number_1);
        //    expressNumber(num1, place, s, steps);
        //    s.AppendFormat("<br> {0} = ", number_2);
        //    expressNumber(num2, place, s, steps);

        //    for (int i = 0; i < steps; i++)
        //    {

        //        s.AppendFormat("<br><br><b> Step {0}: Add the {1} place value </b>", i + 1, place[i]);
                
        //        if (carry != 0)
        //        {
        //            s.AppendFormat("<b> along with the carry.</b>", carry, place[i]);
        //            s.AppendFormat("<br> {0} + {1} + {2} = {3} {4}", num1[i], num2[i], carry, sum = num1[i] + num2[i] + carry, place[i]);
        //        }
        //        else
        //            s.AppendFormat("<br> {0} + {1} = {2} {3}", num1[i], num2[i], sum = num1[i] + num2[i], place[i]);

        //        if (sum >= 10 && (i + 1) != steps)
        //        {
        //            s.AppendFormat("<br> {0} {3} = {1} {4} + {2} {3}", sum, 1, sum -= 10, place[i], place[i + 1]);
        //            s.AppendFormat("<br> Here {0} is taken into the sum and 1 is carried to the {1} place level.", sum, place[i + 1]);
        //            carry = 1;
        //        }
        //        else
        //        {
        //            s.AppendFormat("<br> Here {0} is taken into the sum.", sum);
        //            carry = 0;
        //        }
        //        s.AppendFormat("<br> {0} place value : {1}", place[i], sum);
        //        num[i]=sum;sum = 0;
        //    }

        //    for(int i =0;i<steps;i++)
        //        sum+=num[i]*(int)Math.Pow(10,i);

        //    s.AppendFormat("<br><br><b> Answer :</b>");

        //    expressNumber(num, place, s, steps);
        //    s.AppendFormat(" = {0}", sum);
            
        //    return s.ToString();
        //}

        protected override List<String> createOptions()
        {
            return new List<String>();
        }

        protected override string createAnswer()
        {
            return (number_1 + number_2).ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add(" number_1 + number_2  = ?");
          /*  questionPrototype.Add(" Evaluate : \n  number_1 \n+ number_2 \n");
            questionPrototype.Add(" Mickey has number_1 marbles . Minnie gave him number_2 more marbles. How many does marbles does mickey have now.\n");
            questionPrototype.Add(" Danny bought a ball for number_1 $ and a book for number_2 $.How much should he pay?\n");
            questionPrototype.Add(" Try this : number_1 + number_2 ?\n");
            questionPrototype.Add(" A sack has number_1 apples . If number_2 more apples are added to it, how many apples are there in the sack \n");
            questionPrototype.Add(" A school has number_1 boys and number_2 girls . What is the total number of kids in the school?\n");
            questionPrototype.Add(" Fill in the Blank : \n number_1 + number_2 = ___________ \n");
            questionPrototype.Add(" Solve : \n number_1 + number_2 \n");
            questionPrototype.Add(" What is number_1 + number_2 ?\n");
        
           */ }
        
    }


    class Level1Addition : Addition
    {
        protected override int generateNumber_1()
        {
            return randomDigit(1, 10);
        }

        protected override int generateNumber_2(int number_1)
        {
            return randomDigit(1, 10);
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2 , type = -randomDigit(0,4);
            List<String> options = new List<String>();

            for (int i = 0; i < 4; i++)
                options.Add((answer + type + i).ToString());

            if(options.Contains("-1"))
            {
                options.Remove("-1");
                options.Add("3");
            }
            
            return options;
        }

       

    }
    
    class Level2Addition : Addition
    {
        protected override int generateNumber_1() 
        {
            
            return r.Next(10,50);
         }
       
        protected override int generateNumber_2(int number_1)
        {
            int number_2=0 , second_digit = number_1 % 10;
            
            number_2 += 10* randomDigit(1,10) + randomDigit(0,(10-second_digit)) ;
            
            return number_2; 
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
            List<String> options = new List<String>();

            int type1,type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + type1).ToString());
            options.Add((answer + type2).ToString());
            options.Add((answer + type2 + type1).ToString());
            
            return options;
        }

       

    }

    class Level3Addition : Addition
    {
        protected override int generateNumber_1()
        {

            return r.Next(50, 100);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = number_1 % 10;

            number_2 += 10 * randomDigit(1, 10) + randomDigit(0, (10 - second_digit));

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + type1).ToString());
            options.Add((answer + type2).ToString());
            options.Add((answer + type2 + type1).ToString());

            return options;
        }

       

    }
   
    class Level4Addition : Addition
    {
        protected override int generateNumber_1() 
        {
            int number_1 = 0;
            
            do
            {
                number_1 = r.Next(10, 50);
            }
            while (number_1 % 10 == 0);
            
            return number_1; 
        }

        protected override int generateNumber_2(int number_1) 
        {
            int number_2 = 0 , second_digit = number_1 % 10 ;
            number_2 += 10 * randomDigit(1,10) + randomDigit((10 - second_digit), 10);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + type1).ToString());
            options.Add((answer + type2).ToString());
            options.Add((answer + type2 + type1).ToString());

            return options;
        }

     

    }

    class Level5Addition : Addition
    {
        protected override int generateNumber_1()
        {
            int number_1 = 0;

            do
            {
                number_1 = r.Next(50, 100);
            }
            while (number_1 % 10 == 0);

            return number_1;
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = number_1 % 10;
            number_2 += 10 * randomDigit(1, 10) + randomDigit((10 - second_digit), 10);
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;

            options.Add(answer.ToString());
            options.Add((answer + type1).ToString());
            options.Add((answer + type2).ToString());
            options.Add((answer + type2 + type1).ToString());

            return options;
        }

       

    }

    class Level6Addition : Addition
    {
        protected override int generateNumber_1()
        {
            return r.Next(100, 200); 
        }
        
        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0 , second_digit = (number_1 / 10) % 10 , third_digit = number_1 %10;
            
            number_2 += 100 * randomDigit(1, 10) + 10 * randomDigit(0, (10 - second_digit))
                + randomDigit(0, (10 - third_digit));
            
            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
            List<String> options = new List<String>();

            int type1 = 0, type2 = 0 , type3 =0;

            switch(randomDigit(1,4))
            {
                case 1 :
                    type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
                    type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
                    type3 = randomDigit(1, 3) == 1 ? 100 : -100;
                    break;
                case 2 :
                    type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
                    type2 = (randomDigit(1, 3) == 1) ? 100 : -100;
                    type3 = randomDigit(1, 3) == 1 ? 10 : -10;
                    break;
                case 3 :
                    type1 = (randomDigit(1, 3) == 1) ? 100 : -100;
                    type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
                    type3 = randomDigit(1, 3) == 1 ? 1 : -1;
                    break;
            }
            
            options.Add(answer.ToString());
            options.Add((answer + type1 + (randomDigit(1,3)==1 ? type3 : 0)).ToString());
            options.Add((answer + type2 + (randomDigit(1, 3) == 1 ? type3 : 0)).ToString());
            options.Add((answer + type2 + type1 + (randomDigit(1, 3) == 1 ? type3 : 0)).ToString());

            return options;
        }

    

    }

    class Level7Addition : Addition
    {
        protected override int generateNumber_1()
        {
            return r.Next(200, 500);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = (number_1 / 10) % 10, third_digit = number_1 % 10;

            number_2 += 100 * randomDigit(1, 10) + 10 * randomDigit(0, (10 - second_digit))
                + randomDigit(0, (10 - third_digit));

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
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

      

    }

    class Level8Addition : Addition
    {
        protected override int generateNumber_1()
        {
            return r.Next(500, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = (number_1 / 10) % 10, third_digit = number_1 % 10;

            number_2 += 100 * randomDigit(1, 10) + 10 * randomDigit(0, (10 - second_digit))
                + randomDigit(0, (10 - third_digit));

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
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

       

    }
 
    class Level9Addition : Addition
    {
        protected override int generateNumber_1() 
        { 
            return r.Next(100,500);
        }

        protected override int generateNumber_2(int number_1) 
        {
            int number_2=0 , second_digit = (number_1 / 10 ) % 10, third_digit = number_1%10;
           
            number_2 += 100 * randomDigit(1, 10);

            switch (randomDigit(1, 3))
            {
                case 1:
                    if (second_digit == 0)
                    {
                        second_digit = randomDigit(1,10);
                        this.number_1 += second_digit * 10;
                    }
                    number_2 += 10*randomDigit(10-second_digit,10) + randomDigit(0,10-third_digit);
                    break;
                case 2:
                    if (third_digit == 0)
                    {
                        third_digit = randomDigit(1, 10);
                        this.number_1 += third_digit;
                    }
                    number_2 += 10*randomDigit(0,10) + randomDigit(10 - third_digit, 10);
                    break;
            }

            return number_2; 
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
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

     
    }

    
    
    
    
    class Level10Addition : Addition
    {
        protected override int generateNumber_1()
        {
            return r.Next(500, 1000);
        }

        protected override int generateNumber_2(int number_1)
        {
            int number_2 = 0, second_digit = (number_1 / 10) % 10, third_digit = number_1 % 10;

            number_2 += 100 * randomDigit(1, 10);

            switch (randomDigit(1, 3))
            {
                case 1:
                    if (second_digit == 0)
                    {
                        second_digit = randomDigit(1, 10);
                        this.number_1 += second_digit * 10;
                    }
                    number_2 += 10 * randomDigit(10 - second_digit, 10) + randomDigit(0, 10 - third_digit);
                    break;
                case 2:
                    if (third_digit == 0)
                    {
                        third_digit = randomDigit(1, 10);
                        this.number_1 += third_digit;
                    }
                    number_2 += 10 * randomDigit(0, 10) + randomDigit(10 - third_digit, 10);
                    break;
            }

            return number_2;
        }

        protected override List<String> createOptions()
        {
            int answer = number_1 + number_2;
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

      

    } 

 
}
