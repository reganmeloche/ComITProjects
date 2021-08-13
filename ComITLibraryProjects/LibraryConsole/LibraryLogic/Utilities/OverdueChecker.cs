using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class OverdueChecker : ICheckOverdueBooks
    {
        public bool IsOverdue(DateTime dueDate) {
            return DateTime.Now > dueDate;
        }
    }
}
