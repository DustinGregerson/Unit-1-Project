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
        int bitFlags = 0;

        //message to represent each flag
        string[] errorAt = 
        {"width",
         "height",
         "length"};

        //final error message
        string errorMessage = "";
        public void ValidateStrings()
        {
            //regex to check if the value entered contains only numbers
            string AllNumberPattern = @"^(\d+)$|^(\d+\.\d+)$|^(\.\d+)$";
            Regex NumberCheck = new Regex(AllNumberPattern);

            //sets the bit flags
            if (width == null) {
                bitFlags = 1;
            }
            else if (NumberCheck.Match(width).Success)
            {
               
            }
            else
            {
                bitFlags = bitFlags | 0x2;
            }

            if (height == null)
            {
                bitFlags = bitFlags | 0x4;
            }
            else if (NumberCheck.Match(height).Success)
            {
                
            }
            else
            {
                bitFlags |= 0x8;
            }

            if (length==null)
            {
                bitFlags = bitFlags | 0x10;
            }
            else if (NumberCheck.Match(length).Success)
            {
                
            }
            else
            {
                bitFlags = bitFlags | 0x20;
            }

        }

        public string ErrorMessageParser()
        {
            int mask=0x3;
            for(int i=0;i<errorAt.Length;i++)
            {
                switch((bitFlags >> i * 2)&mask)
                {
                    case 0x2: errorMessage += "You have to enter a numeric value in the "+errorAt[i]+" text feild";
                        break;
                    case 0x4:
                              errorMessage += "You Must enter a valid number ie (1.1, 1, .1) in the" + errorAt[i] + " text feild";
                    break;
                }
                
            }
            return errorMessage;
        }
    }
}
