using System.IO;
using System.Net;
using System.Text;

namespace TemporaryMailApp.Logic
{
    class HelpQuery
    {
        private string Key { set; get; }
        private string site = "https://post-shift.ru/api.php?action=";
        public string CreatingMail(string name)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}new&name={name}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                string info= stream.ReadToEnd();
                int index= info.IndexOf("Key:");
                Key = info.Substring(index + 5);
                return info;
            }
        }
        public string ListOfEmails()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}getlist&key={Key}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string LifeTime()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}livetime&key={Key}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string LifeTimeMin()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}update&key={Key}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string RemoveEmail()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}delete&key={Key}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string ClearEmail()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}clear&key={Key}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string RemoveAllEmail()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}deleteall");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
        public string MessageText(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"{site}getmail&key={Key}&id={id}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
