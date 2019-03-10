using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Subtitles
{
    public static class StringExtend 
    {
        public static string MyReplace(this string source, int startInd, int x)
        {
            string tmp = source.Remove(startInd, x.ToString("D2").Length);
            string tmp2 = tmp.Insert(startInd, x.ToString("D2"));
            return tmp2;
        }
        public static string MyReplace2(this string source, int startInd, int x)
        {
            string tmp = source.Remove(startInd, x.ToString("D3").Length);
            string tmp2 = tmp.Insert(startInd, x.ToString("D3"));
            return tmp2;
        }
    }

}
