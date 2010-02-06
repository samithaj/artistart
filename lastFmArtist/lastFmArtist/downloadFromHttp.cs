using System;
using System.IO;
using System.Net;


namespace lastFmArtist
{
    //public delegate void numberChangedHandler();

    //static class downloadFromHttp
    //{
    //    public static event numberChangedHandler numberChanged;

    //    //public static string savePath = @"K:\artistart\by_artistName\";

    //    private static int downloading;

    //    public static int downloadThread
    //    {
    //        get
    //        {
    //            return downloading;
    //        }
    //        set
    //        {
    //            downloading = value;
    //            numberChanged();
    //        }
    //    }




        //Download text file containing image addresses from Server.
        //Here used to download the XML file containing images' addresses.
        //public static string downloadTextFromHttp(string url)
        //{
        //    WebRequest req = WebRequest.Create(url);
        //    WebResponse result = null;
        //    Stream ReceiveStream = null;
        //    StreamReader readerOfStream = null;

        //    //this is for my testing..I have a very poor Internet connection.
        //    req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
        //    //cache end.
        //    try
        //    {
        //        result = req.GetResponse();
        //        ReceiveStream = result.GetResponseStream();
        //        readerOfStream = new StreamReader(ReceiveStream);
        //        return readerOfStream.ReadToEnd();
        //    }
        //    catch (Exception err)
        //    {
        //        System.Windows.Forms.MessageBox.Show(err.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        if (readerOfStream != null) readerOfStream.Close();
        //        if (ReceiveStream != null) ReceiveStream.Close();
        //    }

        //}

        //Download image from server, code moved to imageShow class
        /*
        public static int downloadImageFromHttp(string url, string prefix )
        {
            string path;
            int returnValue = 0;
            WebRequest req = WebRequest.Create(url);
            WebResponse result = null;

            string filename = url;
            filename = filename.ToString().Remove(filename.ToString().LastIndexOf("/"));
            filename = filename.Remove(0, filename.LastIndexOf("/") + 1);
            path = savePath + prefix + "_" + filename + ".jpg";
            try
            {
                result = req.GetResponse();
                if (File.Exists(savePath)) return 0;
                if (SaveBinaryFile(result, path)) returnValue = 1;
            }
            catch
            {
                returnValue = -1;
            }
            finally
            {
                if (result != null) result.Close();
            }
            return returnValue;

        }
        */

        //Save file.code moved to imageShow class
        /*
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
        */

        //Download small previews, return Stream class for Image.
        //public static Stream downloadThumb(string url)
        //{
        //    WebRequest req = WebRequest.Create(url);
        //    WebResponse result = null;
        //    req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
        //    try
        //    {
        //        result = req.GetResponse();
        //        return result.GetResponseStream();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


    //}
}
