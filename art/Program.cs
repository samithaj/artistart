using System;
using System.Collections.Generic;
using System.Text;

namespace art
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.GetLength(0) != 3)
            {
                Console.WriteLine(
                    "Help: art.exe <artist> <path> <images> \r\n!important:path must include filename,or downloaded images will be somewhere else. \r\nWhy:%path% is easier for foobar than $replace(%path%,%filename_ext%,)\r\nPress any key to close."
                    );
                Console.ReadKey();
                return;
            }

            fetchArtists itFetch;
            string path = args[1];

            path = args[1].Remove(args[1].LastIndexOf(@"\") + 1);

            if (args.GetLength(0) >= 1)
                itFetch = new fetchArtists(args[0], path, args[2]);
            else
                itFetch = new fetchArtists();

            Console.WriteLine("artist:" + args[0] + "\r\n\r\npath:" + path + "\r\n\r\nimages:" + args[2] + " images");

            itFetch.fetchArtList();
            itFetch.output();
            itFetch.saveImage(3);

        }
    }
}
