using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    static class Pomocnik
    {
        static bool checkISBN(uint ISBN)
        {
            if (ISBN < 0)
                return false;
            else
                return true;            
        }
    }
}
