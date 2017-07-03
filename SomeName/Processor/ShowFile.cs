using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Processor
{
    public class ShowFile : ShowFormat
    {
        private string _FileName;

        public ShowFile(string FileName)
        {
            _FileName = FileName;
        }

        public override void Show(Dictionary<string, List<string>> Data)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(_FileName);
            foreach (KeyValuePair<string, List<string>> e in Data)
            {
                for (int i = 0; i < e.Value.Count; i++)
                {
                    file.WriteLine(string.Format("{0}: {1}\n", e.Key, e.Value[i]));
                }
            }
            file.Close();
        }
    }
}