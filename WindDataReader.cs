using System;
using System.Globalization;
using System.Net;
using System.Xml;

namespace Capture.WindData
{
    public class WindDataReader
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        WebClient wc;
        XmlDocument xmlDoc;
        string weatherDataURL;

        public WindDataReader(string weatherDataURL)
        {
            this.weatherDataURL = weatherDataURL;
            wc = new WebClient();
            xmlDoc = new XmlDocument();
        }
        public WindData GetNextData()
        {
            var xmlResponse = wc.DownloadString(weatherDataURL);
            xmlDoc.LoadXml(xmlResponse);

            var windSpeedNode = xmlDoc.SelectSingleNode("//*[local-name()='element'][@name='avg_wnd_spd_10m_pst1mt']");
            var windspeed = ((XmlElement)windSpeedNode).GetAttribute("value");
            var windDirectionnode = xmlDoc.SelectSingleNode("//*[local-name()='element'][@name='avg_wnd_dir_10m_pst1mt']");
            var windDirection = ((XmlElement)windDirectionnode).GetAttribute("value");
            var resultTimeNode = xmlDoc.SelectSingleNode("//*[local-name()='resultTime']/*[local-name()='TimeInstant']/*[local-name()='timePosition'] ");
            var resultTIme = resultTimeNode.InnerText;

            var windData = new WindData { ResultTime = DateTime.ParseExact(resultTIme, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", provider), Direction = double.Parse(windDirection), Speed = double.Parse(windspeed) };
            return windData;
        }
    }
}