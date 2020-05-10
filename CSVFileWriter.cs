using System;
using System.IO;

namespace Capture.WindData
{
    public class CSVFileWriter
    {
        private TextWriter writer;
        private FileInfo currentFile;

        public CSVFileWriter()
        {
            CreateFile();
        }

        internal void WriteData(WindData windData)
        {
            writer.WriteLine(DateTime.Now + ", " + windData.ResultTime + ", " + windData.Speed + ", " + windData.Direction);
            writer.Flush();
            CheckFile();
        }

        private void CheckFile()
        {
            if (currentFile.Length > 5000000)
            {
                CreateFile();
            }
        }

        private void CreateFile()
        {
            var fileName = "c:\\temp\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            writer = File.CreateText(fileName);
            currentFile = new FileInfo(fileName);
            WriteHeader();
        }

        private void WriteHeader()
        {
            writer.WriteLine("System Time, Result Time, Wind Speed, Wind Direction");
        }
    }
}