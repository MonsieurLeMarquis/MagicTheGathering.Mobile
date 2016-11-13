using System;
using System.Net;
using System.IO;

namespace MTG.DataExtractor.Network
{
    public class HttpRequest
    {

        public static string Get(string URL)
        {
            string Resultat = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                request.Method = "GET";
                if (Proxy.Valid())
                {
                    request.Proxy = Proxy.GetProxy();
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    Resultat = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch (Exception)
            {
            }
            return Resultat;
        }

        public static bool DownloadRemoteImageFile(string uri, string fileName)
        {
            bool Success = true;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                if (Proxy.Valid())
                {
                    request.Proxy = Proxy.GetProxy();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect) &&
                    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
            }
            catch (Exception)
            {
                Success = false;
            }
            return Success;
        }

        public static bool DownloadRemoteDocxFile(string uri, string fileName)
        {
            bool Success = true;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                if (Proxy.Valid())
                {
                    request.Proxy = Proxy.GetProxy();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect))
                {
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
            }
            catch (Exception)
            {
                Success = false;
            }
            return Success;
        }

    }
}
