using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WPF_Subtitles
{
    class SubtitlesConverter
    {
        public static void Convert(string path, int ms, string outpath)
        {
            string line;

            StreamReader streamReader = new StreamReader(path);
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
                    //System.Windows.MessageBox.Show(line);
                    streamWriter.WriteLine(line);
                }
            }
            streamWriter.Close();

        }
    }
}
