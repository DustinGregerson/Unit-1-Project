using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

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
        

        //message to represent each flag
        string[] errorAt = 
        {"length",
         "width",
         "height"};

        //final error message
        string errorMessage = "";
        public void ValidateStrings()
        {
            //regex to check if the value entered contains only numbers
            string AllNumberPattern = @"^(\d+)$|^(\d+\.\d+)$|^(\.\d+)$";
            Regex NumberCheck = new Regex(AllNumberPattern);

            //sets the bit flags to display diffrent message strings

            //NOTE:i dont plan to continue doing this
            //i just wanted to see if i could pull it off.
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
            //data is sectioned to 2 bits per section
            //01 is a null error
            //10 is a regex fail
            int mask=0x3;
            for(int i=0;i<errorAt.Length;i++)
            {
                //ever loop move to the next section
                switch((bitFlags >> i * 2)&mask)
                {
                    case 0x1: errorMessage += "<div>You have to enter a numeric value in the "+errorAt[i]+" text feild</div><br>";
                        break;
                    case 0x2:
                              errorMessage += "<div>You Must enter a valid number ie (1.1, 1, .1) in the " + errorAt[i] + " text feild</div><br>";
                    break;
                }
                
            }
            return errorMessage;
        }
        public string calcCube()
        {
            if (bitFlags > 0)
            {
                return "";
            }
            else
            {
                //it is not possiable for these values to be null if validation has been done
                return "" + (int.Parse(length) * int.Parse(width) * int.Parse(height));
            }
        }
    }
}
