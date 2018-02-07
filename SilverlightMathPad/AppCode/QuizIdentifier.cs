using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SilverlightMathPad
{
    public class QuizIdentifier
    {
        //  Hashtable quizIDTable;
        Quiz quiz;

        public QuizIdentifier()
        {
            //   quizIDTable = new Hashtable();
            // populateHashTable();
        }

        public Quiz identifiedQuiz(String quizID, int Level)
        {

            identifyQuiz(quizID, Level);
            return quiz;
        }

        void identifyQuiz(string quizID, int Level)
        {
            switch (quizID)
            {
                case "Addition":
                    identifyAddition(Level);
                    break;
                case "Subtraction":
                    identifySubtraction(Level);
                    break;
                case "Multiplication":
                    identifyMultiplication(Level);
                    break;
                case "Division":
                    identifyDivision(Level);
                    break;
                case "Time":
                    identifyTime(Level);
                    break;
                case "Percentage":
                    identifyPercentage(Level);
                    break;
                case "SimpleInterest":
                    identifySimpleInterest(Level);
                    break;
                case "Discount":
                    identifyDiscount(Level);
                    break;
                case "Rounding":
                    identifyRounding(Level);
                    break;
                case "SalesTax":
                    identifySalesTax(Level);
                    break;
                case "SalesTaxWithPrice":
                    identifySalesTaxWithPrice(Level);
                    break;
                case "Commission":
                    identifyCommission(Level);
                    break;
                case "Shipping":
                    identifyShipping(Level);
                    break;
                case "Tips":
                    identifyTips(Level);
                    break;
                case "Fractions":
                    identifyFractions(Level);
                    break;
                case "Currency":
                    identifyCurrency(Level);
                    break;
                case "Exponents":
                    identifyExponents(Level);
                    break;
                    
            }
        }

        void identifyExponents(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Exponent());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Exponent());
                    break;
                case 3:
                    setQuiz((Quiz)new Level1Exponent());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Exponent());
                    break;
                case 5:
                    setQuiz((Quiz)new Level2Exponent());
                    break;
                case 6:
                    setQuiz((Quiz)new Level2Exponent());
                    break;
                case 7:
                    setQuiz((Quiz)new Level3Exponent());
                    break;
                case 8:
                    setQuiz((Quiz)new Level3Exponent());
                    break;
                case 9:
                    setQuiz((Quiz)new Level4Exponent());
                    break;
                case 10:
                    setQuiz((Quiz)new Level4Exponent());
                    break;
            }



        }
        void identifyCurrency(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Currency());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Currency());
                    break;
                case 3:
                    setQuiz((Quiz)new Level1Currency());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Currency());
                    break;
                case 5:
                    setQuiz((Quiz)new Level2Currency());
                    break;
                case 6:
                    setQuiz((Quiz)new Level2Currency());
                    break;
                case 7:
                    setQuiz((Quiz)new Level3Currency());
                    break;
                case 8:
                    setQuiz((Quiz)new Level3Currency());
                    break;
                case 9:
                    setQuiz((Quiz)new Level4Currency());
                    break;
                case 10:
                    setQuiz((Quiz)new Level4Currency());
                    break;
            }



        }

        void identifyFractions(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Fraction());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Fraction());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Fraction());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Fraction());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Fraction());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Fraction());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Fraction());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Fraction());
                    break;
                case 9:
                    setQuiz((Quiz)new   Level9Fraction());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Fraction());
                    break;
            }



        }

        void identifyAddition(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Addition());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Addition());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Addition());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Addition());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Addition());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Addition());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Addition());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Addition());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Addition());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Addition());
                    break;
            }



        }

        void identifySubtraction(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Subtraction());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Subtraction());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Subtraction());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Subtraction());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Subtraction());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Subtraction());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Subtraction());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Subtraction());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Subtraction());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Subtraction());
                    break;
            }



        }

        void identifyMultiplication(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Multiplication());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Multiplication());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Multiplication());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Multiplication());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Multiplication());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Multiplication());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Multiplication());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Multiplication());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Multiplication());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Multiplication());
                    break;
            }



        }
      
        void identifyDivision(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Division());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Division());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Division());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Division());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Division());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Division());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Division());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Division());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Division());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Division());
                    break;
            }



        }

        void identifyTime(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Time());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Time());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Time());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Time());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Time());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Time());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Time());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Time());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Time());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Time());
                    break;
            }



        }

        void identifyPercentage(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Percentage());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Percentage());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Percentage());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Percentage());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Percentage());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Percentage());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Percentage());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Percentage());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Percentage());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Percentage());
                    break;
            }



        }

        void identifySimpleInterest(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1SI());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2SI());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3SI());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4SI());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5SI());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6SI());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7SI());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8SI());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9SI());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10SI());
                    break;
            }



        }

        void identifyDiscount(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Discount());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Discount());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2Discount());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Discount());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3Discount());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3Discount());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4Discount());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4Discount());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5Discount());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5Discount());
                    break;
            }



        }

        void identifyRounding(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Rounding());
                    break;
                case 2:
                    setQuiz((Quiz)new Level2Rounding());
                    break;
                case 3:
                    setQuiz((Quiz)new Level3Rounding());
                    break;
                case 4:
                    setQuiz((Quiz)new Level4Rounding());
                    break;
                case 5:
                    setQuiz((Quiz)new Level5Rounding());
                    break;
                case 6:
                    setQuiz((Quiz)new Level6Rounding());
                    break;
                case 7:
                    setQuiz((Quiz)new Level7Rounding());
                    break;
                case 8:
                    setQuiz((Quiz)new Level8Rounding());
                    break;
                case 9:
                    setQuiz((Quiz)new Level9Rounding());
                    break;
                case 10:
                    setQuiz((Quiz)new Level10Rounding());
                    break;
            }



        }

        void identifySalesTax(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new  Level1SalesTax());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1SalesTax());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2SalesTax());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2SalesTax());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3SalesTax());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3SalesTax());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4SalesTax());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4SalesTax());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5SalesTax());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5SalesTax());
                    break;
            }
        }

        void identifySalesTaxWithPrice(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1SalesTaxPrice());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1SalesTaxPrice());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2SalesTaxPrice());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2SalesTaxPrice());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3SalesTaxPrice());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3SalesTaxPrice());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4SalesTaxPrice());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4SalesTaxPrice());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5SalesTaxPrice());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5SalesTaxPrice());
                    break;
            }
        }

        void identifyCommission(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Commission());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Commission());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2Commission());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Commission());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3Commission());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3Commission());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4Commission());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4Commission());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5Commission());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5Commission());
                    break;
            }
        }

        void identifyShipping(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Shipping());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Shipping());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2Shipping());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Shipping());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3Shipping());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3Shipping());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4Shipping());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4Shipping());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5Shipping());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5Shipping());
                    break;
            }
        }

        void identifyTips(int Level)
        {
            switch (Level)
            {
                case 1:
                    setQuiz((Quiz)new Level1Tips());
                    break;
                case 2:
                    setQuiz((Quiz)new Level1Tips());
                    break;
                case 3:
                    setQuiz((Quiz)new Level2Tips());
                    break;
                case 4:
                    setQuiz((Quiz)new Level2Tips());
                    break;
                case 5:
                    setQuiz((Quiz)new Level3Tips());
                    break;
                case 6:
                    setQuiz((Quiz)new Level3Tips());
                    break;
                case 7:
                    setQuiz((Quiz)new Level4Tips());
                    break;
                case 8:
                    setQuiz((Quiz)new Level4Tips());
                    break;
                case 9:
                    setQuiz((Quiz)new Level5Tips());
                    break;
                case 10:
                    setQuiz((Quiz)new Level5Tips());
                    break;
            }
        }
        void setQuiz(Quiz quiz)
        {
            this.quiz = quiz;
        }


        private void populateHashTable()
        {


            //Addition
            // quizIDTable.Add(@"5cb3961b-511e-4262-90c0-478824a44a31", 101);
            // quizIDTable.Add(@"3a64064d-59e5-44a7-8e28-3219f117ea42", 102);
            // quizIDTable.Add(@"b44bfb53-8d7e-4108-8024-0cb5f2653595", 103);
            // quizIDTable.Add(@"c77b4c76-8e57-4bf5-96c1-80866945bc76", 104);
            // quizIDTable.Add(@"139fee51-f585-4f32-b2ac-446f9015eaf1", 105);
            // //Subtraction
            // quizIDTable.Add(@"b45bddfb-944f-46ff-b98b-213298a5677e", 201);
            // quizIDTable.Add(@"208a1826-8251-4407-9f9a-6a6a131ac91f", 202);
            // quizIDTable.Add(@"2ed0ab96-a3e6-4a20-b8bf-78e04e711739", 203);
            // quizIDTable.Add(@"f0379a40-7c2d-4626-9e30-7c849f0241ae", 204);
            // quizIDTable.Add(@"17986e8b-a5d6-462c-8912-ac0274aee2af", 205);
            // //Multilication
            // quizIDTable.Add(@"b8708d2c-935d-48e3-861d-0a664db56b1c", 301);
            // quizIDTable.Add(@"91dd636f-d043-4f5b-a8d0-43baa31cdb36", 302);
            // quizIDTable.Add(@"48be5798-6521-400a-b644-0bc63c312f76", 303);
            // quizIDTable.Add(@"3e44231f-09e7-453d-ba8f-664cd53c46d2", 304);
            // //Division
            // quizIDTable.Add(@"973caf36-815a-420a-a376-de31a040d824", 401);
            // quizIDTable.Add(@"f5b1fad5-bf70-4239-acda-b4a7eeb06490", 402);
            // quizIDTable.Add(@"62ac9f7a-fa94-4b2a-b249-f2c6377d4ee7", 403);
            // quizIDTable.Add(@"916bfaee-221c-43f4-955d-98d69ed0ccc2", 404);
            // quizIDTable.Add(@"95efa83b-bf2e-430d-b03f-767c6f860973", 405);
            // quizIDTable.Add(@"b5aa88ff-4dd0-4b7c-afaf-1a014482046f", 406);
            // quizIDTable.Add(@"f0ad7d75-2c80-4a82-875b-6936a5f3fab2", 407);
            // quizIDTable.Add(@"7a4e5989-5882-4b71-9261-63f3f9435c09", 408);
            // quizIDTable.Add(@"992d73aa-fdea-4b96-bc7b-ece492db7ea1", 409);
            // quizIDTable.Add(@"eda5b856-becd-41a8-8ab7-ce80769212a7", 410);

            // //Time Functions
            // quizIDTable.Add(@"3F691386-6107-4166-B5CF-F48532F1A6C7", 501);
            // quizIDTable.Add(@"498B1CD1-6F5B-4766-A08E-56EC007B8FF5", 502);
            // quizIDTable.Add(@"86E245E0-C54E-4ada-AF27-B9044ADC08F2", 503);
            // quizIDTable.Add(@"66DD0945-258B-4016-B341-779496328F6D", 504);
            // quizIDTable.Add(@"E9AE0DB9-AD58-43e2-AFCD-7E407A549A75", 506);
            // quizIDTable.Add(@"5968EB4B-C486-435e-B3A2-DEE504E6EFC9", 505);

            // //Rounding Functions
            // quizIDTable.Add(@"832A7AEC-5E92-42d7-BC76-CCFAE786D9A5", 601);
            // quizIDTable.Add(@"F4FC1BB7-6CFC-439a-9B8A-261251124622", 602);
            // quizIDTable.Add(@"CFA6B36D-95F3-4641-BFC7-D1C5C50068BC", 603);

            // //Fraction Functions
            // quizIDTable.Add(@"768022B5-9141-4574-9EB1-72D185F0FAF6", 701);
            // quizIDTable.Add(@"14E4FDF1-D8C9-4a95-A3E0-F856A2958330", 702);
            // quizIDTable.Add(@"E53B688A-37B4-4fa1-92C1-92BA6E80304F", 703);

            // //Percentage Functions
            // quizIDTable.Add(@"F7AB6F95-69D3-4611-BED8-362857A3A65C", 801);
            // quizIDTable.Add(@"C850925C-A661-4990-93F3-2365988C8DFC", 802);
            // quizIDTable.Add(@"BA16694F-3034-49b2-B339-DB32AC84B674", 803);

            // //Functions
            // quizIDTable.Add(@"75DD4361-B58B-4cc9-8572-00E0F7809F78", 901);
            // quizIDTable.Add(@"9371C7DB-A24B-4be1-9FEE-6B7A85DB400B", 902);
            // quizIDTable.Add(@"FF6D685A-ECE6-4c0c-A946-A22F3323ACAD", 903);
            // quizIDTable.Add(@"8629C229-097B-450e-B152-B6FBCD580C6A", 904);

            // //Discount
            // quizIDTable.Add(@"0EB2C22A-DDF4-4565-B97D-293795C31655", 1001);

            // //Commision
            // quizIDTable.Add(@"CB6BD55A-C356-4ff7-AB5E-10D471A64492", 1101);

            // //Simple Interest
            // quizIDTable.Add(@"0134BBB6-EA9E-4556-8313-987B84C03F70", 1201);

            // //Currency
            // quizIDTable.Add(@"781F7BEE-DA32-4555-9F26-1C618E31E3EA", 1301);
            // quizIDTable.Add(@"6C514174-186D-42b0-9836-7F4A685B5983", 1302);
            // quizIDTable.Add(@"5D1D8CE1-3DD5-4354-900C-4D69202EBF1A", 1303);
            // quizIDTable.Add(@"76F8CD7A-4BF6-49b6-A440-1C2D87CA2DCE", 1304);
            // quizIDTable.Add(@"573ACD8A-F063-4119-8DB5-08E5D7B7F095", 1305);
            // quizIDTable.Add(@"4268C829-71F0-4541-BECC-0788904230B8", 1306);
            // quizIDTable.Add(@"C44C06C6-A9F9-473b-9523-A4CFBEDD0AC7", 1307);
            // quizIDTable.Add(@"26C7E609-D0A5-4912-9858-4706DF85AEAB", 1308);
            // quizIDTable.Add(@"C85C4AA1-E053-4541-AC41-CDBF9F03EEB4", 1309);

            // //Calculating sales tax
            // quizIDTable.Add(@"80826568-BAAD-4327-B79E-49068F05DAD3", 1401);

            //   //Calculating shipping
            // quizIDTable.Add(@"BB6B6730-CA4F-4f43-BE12-6FC9BD0402A7", 1501);

            // //Estimating tips
            // quizIDTable.Add(@"AE88C8DC-74AB-42c4-B591-05274860F50D", 1601);

            ////Calculating price with sales tax
            // quizIDTable.Add(@"C623FE9F-4D6B-471b-8029-8D2D497D188B", 1701);


        }

    }
}
