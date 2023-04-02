using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class Deducciones
    {
        public static double ASF { get; } = 0.0304;
        public static double AFP { get;  } = 0.0287;
        public static double ISR { get;  } = 0.07;
        public static int limitISR { get; } = 34685;
    }

}