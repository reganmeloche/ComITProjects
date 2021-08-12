using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public static class Utilities
    {
        public static DateTime ZeroDate(DateTime dt) {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

    }
}

