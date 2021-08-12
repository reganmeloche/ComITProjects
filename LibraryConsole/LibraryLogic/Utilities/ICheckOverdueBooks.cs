using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public interface ICheckOverdueBooks
    {
        bool IsOverdue(DateTime dueDate);
    }
}
