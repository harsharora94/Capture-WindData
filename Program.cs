using System.Threading;

namespace Capture.WindData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dataurl = "http://dd.weather.gc.ca/observations/swob-ml/latest/CTBF-AUTO-minute-swob.xml";
            // create a writer object
            var fileWriter = new CSVFileWriter();

            // create source reader
            var datareader = new WindDataReader(dataurl);

            while (true)
            {
                var windData = datareader.GetNextData();
                fileWriter.WriteData(windData);
                Thread.Sleep(5000);
            }
        }
    }
}