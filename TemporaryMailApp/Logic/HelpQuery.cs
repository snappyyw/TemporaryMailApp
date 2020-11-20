using System.IO;
using System.Net;
using System.Text;

namespace TemporaryMailApp.Logic
{
    class HelpQuery
    {
        public string key { set; get; }
        public string Operations(string oper)
        {
            string site = "https://post-shift.ru/api.php?action=" + oper;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                string stroka= stream.ReadToEnd();
                if (oper.Contains("new&name="))
                {
                    int index = stroka.IndexOf("Key:");
                    key = stroka.Substring(index + 5);
                }
                return stroka;
            }
        }
    }
}
