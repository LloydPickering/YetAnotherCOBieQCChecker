using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xbim.CobieExpress.IO;
using Xbim.CobieLiteUk;

namespace YetAnotherCOBieQCReporter
{
    class Processor
    {
        public static bool ProcessFromExcel(string inputFilename, string outputFilename)
        {
            try
            {
                using (TextWriter report = File.CreateText(outputFilename))
                {
                    String msg;
                    var facility = Facility.ReadCobie(inputFilename, out msg);

                    facility.ValidateUK2012(report, true);
                    report.Flush();

                }
            }
            
            catch (Exception) {
                return false;
            }
            return true;
        }
    }
}
