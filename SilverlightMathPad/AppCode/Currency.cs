using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilverlightMathPad
{
    abstract class Currency : Quiz
    {
        protected int QueCatType, QueSubType;
        String s;
        StringBuilder question;
        abstract protected int generateNumber_1();
    
        protected int number_1, number_2, Unit_1, Unit_2;
        protected string UnitName_1, UnitName_2;
        protected string Answer;

        protected int CurrencyEuroConvertor(string Unit1, String Unit2, int value1)
        {
            switch (Unit1)
            {
                case "cent":
                    switch (Unit2)
                    {
                        case "cent": return value1;
                    }
                    break;

                case "euro":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 100;
                        case "euro": return value1;
                    }
                    break;
            }
            return 0;

        }
        protected int CurrencyUSConvertor(string Unit1, String Unit2, int value1)
        {
            switch (Unit1)
            {
                case "cent":
                    switch (Unit2)
                    {
                        case "cent": return value1;
                    }
                    break;
                case "nickel":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 5;
                        case "nickel": return value1;
                    }
                    break;
                case "dime":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 10;
                        case "nickel": return value1 * 2;
                        case "dime": return value1;
                    }
                    break;
                case "quarter":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 25;
                        case "nickel": return value1 * 5;
                        //   case "dime": return value1 * 2.5;
                        case "quarter": return value1;
                    }
                    break;
                case "dollar":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 100;
                        case "nickel": return value1 * 20;
                        case "dime": return value1 * 10;
                        case "quarter": return value1 * 4;
                        case "dollar": return value1;
                    }
                    break;
            }
            return 0;

        }

        public Currency()
        {
            createQuestionPrototype();
        }
        protected int generateUSUnit_1()
        {
            switch (QueSubType)
            {
                case 3:
                    return randomDigit(0, 5);
                    break;
                case 4:
                    return randomDigit(0, 5);
                    break;
                case 5:
                    return randomDigit(1, 5);
                    break;
            }
            return 0;

        }
        protected int generateUnit_2(int Unit1)
        {
            switch (QueCatType)
            {
                case 0:
                    return randomDigit(0, Unit1 + 1);
                    break;
                case 1:
                    return randomDigit(0, Unit1 + 1);
                    break;
                case 2:
                    return randomDigit(0, Unit1);
                    break;
            }
            return 0;
        }
        protected string generateUSUnitName(int Unit)
        {
            if (Unit == 0)
                return "cent";
            else if (Unit == 1)
                return "nickel";
            else if (Unit == 2)
                return "dime";
            else if (Unit == 3)
                return "quarter";
            else
                return "dollar";
        }
        protected int generateEuroUnit_1()
        {

            switch (QueSubType)
            {
                case 3:
                    return randomDigit(0, 2);
                    break;
                case 4:
                    return randomDigit(0, 2);
                    break;
                case 5:
                    return randomDigit(1, 2);
                    break;
            }
            return 0;

        }

        protected string generateEuroUnitName(int Unit)
        {
            if (Unit == 0)
                return "cent";
            else
                return "euro";
        }

        protected int CurrencyCanadaConvertor(string Unit1, String Unit2, int value1)
        {


            switch (Unit1)
            {
                case "cent":
                    switch (Unit2)
                    {
                        case "cent": return value1;
                    }
                    break;
                case "nickel":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 5;
                        case "nickel": return value1;
                    }
                    break;
                case "dime":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 10;
                        case "nickel": return value1 * 2;
                        case "dime": return value1;
                    }
                    break;
                case "quarter":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 25;
                        case "nickel": return value1 * 5;
                        //   case "dime": return value1 * 2.5;
                        case "quarter": return value1;
                    }
                    break;
                case "half dollar":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 50;
                        case "nickel": return value1 * 10;
                        case "dime": return value1 * 5;
                        case "quarter": return value1 * 2;
                        case "half dollar": return value1;
                    }
                    break;

                case "loonie":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 100;
                        case "nickel": return value1 * 20;
                        case "dime": return value1 * 10;
                        case "quarter": return value1 * 4;
                        case "half dollar": return value1 * 2;
                        case "loonie": return value1;
                    }
                    break;

                case "toonie":
                    switch (Unit2)
                    {
                        case "cent": return value1 * 200;
                        case "nickel": return value1 * 40;
                        case "dime": return value1 * 20;
                        case "quarter": return value1 * 8;
                        case "half dollar": return value1 * 4;
                        case "loonie": return value1 * 2;
                        case "toonie": return value1;
                    }
                    break;

            }
            return 0;

        }

        protected int generateCanadaUnit_1()
        {

            switch (QueSubType)
            {
                case 3:
                    return randomDigit(0, 7);
                    break;
                case 4:
                    return randomDigit(0, 7);
                    break;
                case 5:
                    return randomDigit(1, 7);
                    break;
            }
            return 0;

        }

        protected string generateCanadaUnitName(int Unit)
        {
            if (Unit == 0)
                return "cent";
            else if (Unit == 1)
                return "nickel";
            else if (Unit == 2)
                return "dime";
            else if (Unit == 3)
                return "quarter";
            else if (Unit == 4)
                return "half dollar";
            else if (Unit == 5)
                return "loonie";
            else
                return "toonie";
        }
        protected override String createQuestion()
        {
            QueCatType = randomDigit(0, 3);
            QueSubType = randomDigit(3, 6);

            switch (QueCatType)
            {
                case 0:
                    //Addition
                    s = questionPrototype.ElementAt(0);
                    question = new StringBuilder(s);
                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            Unit_1 = generateUSUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateUSUnitName(Unit_1);
                            UnitName_2 = generateUSUnitName(Unit_2);
                            while (UnitName_1 == "quarter" && UnitName_2 == "dime")
                            {
                                Unit_1 = generateUSUnit_1();
                                Unit_2 = generateUnit_2(Unit_1);
                                UnitName_1 = generateUSUnitName(Unit_1);
                                UnitName_2 = generateUSUnitName(Unit_2);
                            }
                            break;
                        case 4:
                            //Euro
                            Unit_1 = generateEuroUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateEuroUnitName(Unit_1);
                            UnitName_2 = generateEuroUnitName(Unit_2);
                            break;
                        case 5:
                            //Canada
                            Unit_1 = generateCanadaUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateCanadaUnitName(Unit_1);
                            UnitName_2 = generateCanadaUnitName(Unit_2);
                            break;
                    }
                    number_1 = generateNumber_1();
                    number_2 = generateNumber_1();

                    question.Replace("number_1", number_1.ToString());
                    question.Replace("number_2", number_2.ToString());
                    question.Replace("unit_1", UnitName_1);
                    question.Replace("unit_2", UnitName_2);

                    break;
                case 1:
                    //Subtract
                    s = questionPrototype.ElementAt(1);
                    question = new StringBuilder(s);
                    number_1 = generateNumber_1();

                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            Unit_1 = generateUSUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateUSUnitName(Unit_1);
                            UnitName_2 = generateUSUnitName(Unit_2);
                            while (UnitName_1 == "quarter" && UnitName_2 == "dime")
                            {
                                Unit_1 = generateUSUnit_1();
                                Unit_2 = generateUnit_2(Unit_1);
                                UnitName_1 = generateUSUnitName(Unit_1);
                                UnitName_2 = generateUSUnitName(Unit_2);
                            }

                            number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);

                            while ((CurrencyUSConvertor(UnitName_1, UnitName_2, number_1)) <= number_2)
                            {
                                number_1 = generateNumber_1();
                                number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);
                            }
                            break;
                        case 4:
                            //Euro
                            Unit_1 = generateEuroUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateEuroUnitName(Unit_1);
                            UnitName_2 = generateEuroUnitName(Unit_2);


                            number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);

                            while ((CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1)) <= number_2)
                            {
                                number_1 = generateNumber_1();
                                number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);
                            }
                            break;
                        case 5:
                            //Canada
                            Unit_1 = generateCanadaUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateCanadaUnitName(Unit_1);
                            UnitName_2 = generateCanadaUnitName(Unit_2);


                            number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);

                            while ((CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1)) <= number_2)
                            {
                                number_1 = generateNumber_1();
                                number_2 = generateNumber_2(number_1, UnitName_1, UnitName_2);
                            }
                            break;
                    }
                    question.Replace("number_1", number_1.ToString());
                    question.Replace("number_2", number_2.ToString());
                    question.Replace("unit_1", UnitName_1);
                    question.Replace("unit_2", UnitName_2);


                    break;
                case 2:
                    //Convert
                    s = questionPrototype.ElementAt(2);
                    question = new StringBuilder(s);

                    number_1 = generateNumber_1();


                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            Unit_1 = generateUSUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateUSUnitName(Unit_1);
                            UnitName_2 = generateUSUnitName(Unit_2);
                            while (UnitName_1 == "quarter" && UnitName_2 == "dime")
                            {
                                Unit_1 = generateUSUnit_1();
                                Unit_2 = generateUnit_2(Unit_1);
                                UnitName_1 = generateUSUnitName(Unit_1);
                                UnitName_2 = generateUSUnitName(Unit_2);
                            }
                            break;
                        case 4:
                            //Euro
                            Unit_1 = generateEuroUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateEuroUnitName(Unit_1);
                            UnitName_2 = generateEuroUnitName(Unit_2);
                            break;
                        case 5:
                            //Canada
                            Unit_1 = generateCanadaUnit_1();
                            Unit_2 = generateUnit_2(Unit_1);
                            UnitName_1 = generateCanadaUnitName(Unit_1);
                            UnitName_2 = generateCanadaUnitName(Unit_2);
                            break;
                    }
                    question.Replace("number_1", number_1.ToString());
                    question.Replace("unit_1", UnitName_1);
                    question.Replace("unit_2", UnitName_2);


                    break;

            }



            return question.ToString();
        }

        protected override void createQuestionPrototype()
        {
            questionPrototype.Add("number_1 unit_1 + number_2 unit_2");
            questionPrototype.Add("number_1 unit_1 - number_2 unit_2");
            questionPrototype.Add("Convert number_1 unit_1 To unit_2");
        }

        protected override List<String> createOptions()
        {
            switch (QueCatType)
            {
                case 0:
                    return createAdditionOptions();
                    break;
                case 1:
                    return createSubtractionOptions();
                    break;
                case 2:
                    return createConversionOptions();
                    break;
            }
            return null;
        }

        protected List<String> createAdditionOptions()
        {
            int answer = 0;
            switch (QueSubType)
            {
                case 3:
                    answer = CurrencyUSConvertor(UnitName_1, UnitName_2, number_1) + number_2;
                    break;
                case 4:
                    answer = CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1) + number_2;
                    break;
                case 5:
                    answer = CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1) + number_2;
                    break;
            }

            List<String> options = new List<String>();
            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
            type2 = (answer + type2) > 1 ? type2 : -type2;
            options.Add(answer.ToString() + " " + UnitName_2);
            options.Add((answer + type1).ToString() + " " + UnitName_2);
            options.Add((answer + type2).ToString() + " " + UnitName_2);
            options.Add((answer + type2 + type1).ToString() + " " + UnitName_2);
            return options;
        }

        protected List<String> createSubtractionOptions()
        {

            int answer = 0;
            switch (QueSubType)
            {
                case 3:
                    answer = CurrencyUSConvertor(UnitName_1, UnitName_2, number_1) - number_2;
                    break;
                case 4:
                    answer = CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1) - number_2;
                    break;
                case 5:
                    answer = CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1) - number_2;
                    break;
            }
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
            type2 = (answer + type2) > 1 ? type2 : -type2;
            options.Add(answer.ToString() + " " + UnitName_2);
            options.Add((answer + type1).ToString() + " " + UnitName_2);
            options.Add((answer + type2).ToString() + " " + UnitName_2);
            options.Add((answer + type2 + type1).ToString() + " " + UnitName_2);
            return options;
        }

        protected List<String> createConversionOptions()
        {
            int answer = 0;
            switch (QueSubType)
            {
                case 3:
                    answer = CurrencyUSConvertor(UnitName_1, UnitName_2, number_1);
                    break;
                case 4:
                    answer = CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1);
                    break;
                case 5:
                    answer = CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1);
                    break;
            }
            List<String> options = new List<String>();

            int type1, type2;
            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 10 : -10;
            type2 = (answer + type2) > 1 ? type2 : -type2;
            options.Add(answer.ToString() + " " + UnitName_2);
            options.Add((answer + type1).ToString() + " " + UnitName_2);
            options.Add((answer + type2).ToString() + " " + UnitName_2);
            options.Add((answer + type2 + type1).ToString() + " " + UnitName_2);
            return options;
        }

        protected override string createAnswer()
        {
            switch (QueCatType)
            {
                case 0:
                    //Addition
                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            return (CurrencyUSConvertor(UnitName_1, UnitName_2, number_1) + number_2).ToString() + " " + UnitName_2;
                            break;
                        case 4:
                            //Euro
                            return (CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1) + number_2).ToString() + " " + UnitName_2;
                            break;
                        case 5:
                            //Canada
                            return (CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1) + number_2).ToString() + " " + UnitName_2;
                            break;
                    }
                    break;
                case 1:
                    //Subtract
                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            return (CurrencyUSConvertor(UnitName_1, UnitName_2, number_1) - number_2).ToString() + " " + UnitName_2;
                            break;
                        case 4:
                            //Euro
                            return (CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1) - number_2).ToString() + " " + UnitName_2;
                            break;
                        case 5:
                            //Canada
                            return (CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1) - number_2).ToString() + " " + UnitName_2;
                            break;
                    }
                    break;
                case 2:
                    //Convert
                    switch (QueSubType)
                    {
                        case 3:
                            //US
                            return (CurrencyUSConvertor(UnitName_1, UnitName_2, number_1)).ToString() + " " + UnitName_2;
                            break;
                        case 4:
                            //Euro
                            return (CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1)).ToString() + " " + UnitName_2;
                            break;
                        case 5:
                            //Canada
                            return (CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1)).ToString() + " " + UnitName_2;
                            break;
                    }
                    break;
            }
            return null;
        }

        protected  int generateNumber_2(int Num1, string Unit1, string Unit2)
        {
            int Max;
            switch (QueSubType)
            {
                case 3:
                    Max = (CurrencyUSConvertor(UnitName_1, UnitName_2, number_1) / 5);
                    Max = Max > 19 ? 19 : Max;
                    return randomDigit(1, Max) * 5;
                    break;
                case 4:
                    Max = (CurrencyEuroConvertor(UnitName_1, UnitName_2, number_1) / 2);
                    Max = Max > 49 ? 49 : Max;
                    return randomDigit(1, Max) * 2;
                    break;
                case 5:
                    Max = (CurrencyCanadaConvertor(UnitName_1, UnitName_2, number_1) / 5);
                    Max = Max > 19 ? 19 : Max;
                    return randomDigit(1, Max) * 5;
                    break;
            }
            return 0;

        }

    }
    class Level1Currency : Currency
    {
        protected override int generateNumber_1()
        {
            switch (QueSubType)
            {
                case 3:
                    return randomDigit(1, 3) * 5;
                    break;
                case 4:
                    return randomDigit(1, 6) * 2;
                    break;
                case 5:
                    return randomDigit(1, 3) * 5;
                    break;
            }
            return 0;
        }

  
    }

    class Level2Currency : Currency
    {
        protected override int generateNumber_1()
        {
            switch (QueSubType)
            {
                case 3:
                    return randomDigit(3, 6) * 5;
                    break;
                case 4:
                    return randomDigit(6, 11) * 2;
                    break;
                case 5:
                    return randomDigit(3, 6) * 5;
                    break;
            }
            return 0;
        }


    }

    class Level3Currency : Currency
    {
        protected override int generateNumber_1()
        {
            switch (QueSubType)
            {
                case 3:
                    return randomDigit(6, 9) * 5;
                    break;
                case 4:
                    return randomDigit(11, 16) * 2;
                    break;
                case 5:
                    return randomDigit(6, 9) * 5;
                    break;
            }
            return 0;
        }


    }

    class Level4Currency : Currency
    {
        protected override int generateNumber_1()
        {
            switch (QueSubType)
            {
                case 3:
                    return randomDigit(9, 12) * 5;
                    break;
                case 4:
                    return randomDigit(16, 21) * 2;
                    break;
                case 5:
                    return randomDigit(9, 12) * 5;
                    break;
            }
            return 0;
        }


    }

 
}
