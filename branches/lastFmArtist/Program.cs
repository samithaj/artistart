using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lastFmArtist
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //<---Parse Start
            bool isValid = false;
            
            int[] position = { -1, -1, -1 };

            #region Get Properties' Positions
            if (args != null)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (args[i].IndexOf("/") == 0)
                    {
                        for (int j = 0; j <= 2; j++)
                        {
                            if (position[j] == -1)
                            {
                                position[j] = i;
                                break;
                            }
                        }
                    }
                }
            } 
            #endregion

            string[] artistList = new string[0];
            string path = "";
            int num = 0;

            //Test arguments
            if (position[0] != -1 && position[1] != -1 && position[2] != -1)
            {
                #region Get arguments!
                for (int i = 0; i <= 2; i++)
                {
                    switch (args[position[i]])
                    {
                        case "/artist":
                            {
                                if (i != 2)
                                {
                                    artistList = new string[position[i + 1] - position[i] - 1];
                                    for (int j = position[i] + 1, l = 0; j < position[i + 1]; j++)
                                    {
                                        artistList[l++] = args[j];
                                    }
                                }
                                else
                                {
                                    artistList = new string[args.Length - position[i] - 1];
                                    for (int j = position[i] + 1, l = 0; j < args.Length; j++)
                                    {
                                        artistList[l++] = args[j];
                                    }
                                }
                            } break;
                        case "/path":
                            {
                                if (position[i] + 1 < args.Length)
                                    path = args[position[i] + 1];
                            } break;
                        case "/num":
                            {
                                try
                                {
                                    num = int.Parse(args[position[i] + 1]);
                                }
                                catch
                                {
                                    MessageBox.Show("Invalid Page Number");
                                }
                            } break;
                    }
                }
                #endregion

                if (num != 0 && artistList.Length != 0 && path != string.Empty)
                {
                    isValid = true;
                }
            }
            //--->Parse Completed
            if (isValid)
            {
                Application.Run(new mainForm(artistList, path, num));

            }
            else
            {
                Application.Run(new mainForm());
            }
        }
    }
}
