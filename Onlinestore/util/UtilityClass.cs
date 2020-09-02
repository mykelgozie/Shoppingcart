using System;
using System.Collections.Generic;
using System.Text;

namespace Onlinestore.util
{
   public  class UtilityClass
    {

        public static string CheckIfEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Invalid Input");
            }

            return value;

        }

        public  static int CheckIfIntEmpty(int value)
        {
            if (value == null )
            {
                throw new Exception("Invalid Input");
            }

            return value;

        }

    }
}
