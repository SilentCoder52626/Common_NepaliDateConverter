using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NepaliDateConverter
{
    public interface IDateConverterService
    {
        DateTime ToAD(string date);
        NepaliDate ToBS(DateTime date);

    }
}
