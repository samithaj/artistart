using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;


namespace artistArtGui
{
    static class downloadFromHttp
    {
        public static string savePath;
        
        
        public static string downloadTextFromHttp(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse result = null;
            Stream ReceiveStream = null;
            StreamReader readerOfStream = null;
            try
            {
                result = req.GetResponse();
                ReceiveStream = result.GetResponseStream();
                readerOfStream = new StreamReader(ReceiveStream);
                return readerOfStream.ReadToEnd();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (readerOfStream != null) readerOfStream.Close();
                if (ReceiveStream != null) ReceiveStream.Close();
            }

        }

        //public static int downloadImageFromHttp(string url, string prefix )
        //{
        //    string path;
        //    int returnValue = 0;
        //    WebRequest req = WebRequest.Create(url);
        //    WebResponse result = null;

        //    string filename = url;
        //    filename = filename.ToString().Remove(filename.ToString().LastIndexOf("/"));
        //    filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
        //    path = savePath + prefix + "_" + filename + ".jpg";
        //    try
        //    {
        //        result = req.GetResponse();
        //        if (File.Exists(savePath)) return 0;
        //        if (SaveBinaryFile(result, path)) returnValue = 1;
        //    }
        //    catch
        //    {
        //        returnValue = -1;
        //    }
        //    finally
        //    {
        //        if (result != null) result.Close();
        //    }
        //    return returnValue;

        //}

        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }

            return value;
        }

        public static Stream downloadThumb(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse result = null;

            try
            {
                result = req.GetResponse();
                return result.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }
    }
}
