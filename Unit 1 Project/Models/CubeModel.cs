using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

//Author Dustin Gregerson
//Date 9/16/23

//Description:
//gathers the information the user entered in the index.cshtml form and finds the cubic area of the numbers entered
//data is valididated with regex and if null statments
//bit flags are used to parse togeather a error message if anything went wrong
//the error message or the results are output onto the results.cshtml
//after the user hits the submit button

//however the calculator will only handel a cubic area of up to 9223367638808264704 by design
//hopefully who ever is useing this knows how to use the metric system if they need a bigger number

namespace Unit_1_Project.Models
{
    public class CubeModel
    {
        public string? width { get; set; }
        public string? height { get; set; }

        public string? length { get; set; }

        public double areaCube { get; set; }

        //all bits set to zero
        public int bitFlags { get; set; }
        

        //error location message to represent each flag
        string[] errorAt = 
        {"LENGTH",
         "WIDTH",
         "HEIGHT"};

        //final error message
        string errorMessage = "";
        public void ValidateStrings()
        {
            //regex to check if the value entered contains only numbers and is a integer or a double
            string AllNumberPattern = @"^(\d+)$|^(\d+\.\d+)$|^(\.\d+)$";
            Regex NumberCheck = new Regex(AllNumberPattern);

            //each error can be 10 or 01 and the flags are chuncked to 2 bits each
            if (length == null) {
                bitFlags = 1;
            }
            else if (NumberCheck.Match(length).Success)
            {
               
            }
            else
            {
                bitFlags = bitFlags | 0x2;
            }

            if (width == null)
            {
                bitFlags = bitFlags | 0x4;
            }
            else if (NumberCheck.Match(width).Success)
            {
                
            }
            else
            {
                bitFlags |= 0x8;
            }

            if (height == null)
            {
                bitFlags = bitFlags | 0x10;
            }
            else if (NumberCheck.Match(height).Success)
            {

            }
            else
            {
                bitFlags = bitFlags | 0x20;
            }
            

        }

        public string ErrorMessageParser()
        {
            //data is cuncked to 2 bits per chunk
            //01 is a null error
            //10 is a regex fail

            //two least significant bit fliped to 1
            int mask=0x3;
            for(int i=0;i<errorAt.Length;i++)
            {
                //every iteration move to the next chunk
                switch((bitFlags >> i * 2)&mask)
                {
                    case 0x1: errorMessage += "<div>You have to enter a numeric value in the "+errorAt[i]+" text feild</div>";
                        break;
                    case 0x2:
                              errorMessage += "<div>You Must enter a valid number ie (1.1 , 1 , .1 ) in the " + errorAt[i] + " text feild</div>";
                    break;
                }
                
            }
            return errorMessage;
        }
      
        public string calcCube()
        {
                //convents the string inputs to decimals
                decimal Length = decimal.Parse(length);
                decimal Width = decimal.Parse(width);
                decimal Height = decimal.Parse(height);

                
                //6291455 to check the sum of all numbers so the largest number this calculator can return is
                //9,223,367,638,808,264,704 a slightly less than a int 64
                if (Length+Width+Height<= 6291455)
                {
                    
                    return "" + Length*Width*Height;
                }
                else
                {
                    return "You have entered in valid numbers but the numbers you have entered are to large. All numbers added togeather can not be greater than 6291455";
                }
        }
    }
}
