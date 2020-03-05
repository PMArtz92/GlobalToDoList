using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    //Commented by Pasan[03/04/2020] We will use these enums to return error status or success status for operator methods. Unit test methods also use these enums for testing.
    public static class OperationStatusCodes
    {
        public const int SUCCESS = 1;
        public const int INVALID_PARAMTERS = -1;
        public const int INVALID_OPERARION = -2;
        public const int NOT_FOUND = -3;
        public const int INVALID_FORMAT = -4;
    }
}
