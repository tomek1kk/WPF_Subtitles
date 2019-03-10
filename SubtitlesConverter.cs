using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace WPF_Subtitles
{
    class SubtitlesConverter
    {
        public static void Convert(string path, int ms, string outpath, ref bool excp)
        {
            string line;

            try
            {
                StreamReader streamReader = new StreamReader(path);
                if (outpath == "")
                    outpath = "out.srt";
                StreamWriter streamWriter = new StreamWriter(outpath);

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (Time.CheckIfItsTime(line) == true)
                    {
                        Time time = new Time(line);
                        time.Move(ms);
                        streamWriter.WriteLine(time.ToString());
                    }
                    else
                    {
                        streamWriter.WriteLine(line);
                    }
                }
                excp = false;
                streamWriter.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                excp = true;
            }



        }
    }
}
