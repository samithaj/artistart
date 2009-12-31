﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Collections;


namespace art
{
    class fetchArtists
    {
        public string artistName;
        public XmlDocument Artlist;
        public ArrayList urlList;
        public string path;
        public string limit;

        public fetchArtists(string artist, string outpath, string max)
        {
            artistName = artist;
            path = outpath;
            limit = max;
        }
        public fetchArtists()
        {
        }

        public void fetchArtList()
        {

            if (artistName == null) return;
            Artlist = new XmlDocument();

            WebRequest req = WebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=artist.getimages&artist=" + artistName + "&api_key=aa55f6dc630a531d0a093c1ca77df129&limit=" + limit);
            WebResponse result = req.GetResponse();

            Stream ReceiveStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(ReceiveStream);
            try
            {
                Artlist.LoadXml(readerOfStream.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            ReceiveStream.Close();
            result.Close();


            XmlNodeList nodeList = Artlist.GetElementsByTagName("size");

            urlList = new ArrayList();
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList.Item(i).Attributes != null && nodeList.Item(i).Attributes["name"].Value == "original")
                {
                    urlList.Add(nodeList.Item(i).InnerText);
                }
            }
        }

        public void output()
        {
            Console.WriteLine("images to be fetched:");
            foreach (string list in urlList)
            {
                Console.WriteLine(list);
            }
        }


        public void saveImage(int i)
        {
            string src;
            if (urlList != null)
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\r\nfetching " + urlList[j].ToString());
                    src=path + artistName + "_" + (j).ToString() + ".jpg";
                    if (!File.Exists(src))
                    {
                        WebRequest req = WebRequest.Create(urlList[j].ToString());
                        WebResponse resoult = req.GetResponse();
                        SaveBinaryFile(resoult, src);
                        Console.Write("...done!");
                    }
                    else
                    {
                        Console.WriteLine("...already downloaded!");
                    }
                }
        }

        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (File.Exists(savePath)) File.Delete(savePath);
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
    }
}