using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName
{
    public class ShowMsgBox : ShowFormat
    {
        public override void Show(Dictionary<string, List<string>> Data)
        {
            string msg = "";

            foreach (KeyValuePair<string, List<string>> e in Data)
            {
                for (int i = 0; i < e.Value.Count; i++)
                {
                    msg += string.Format("{0}: {1}\n", e.Key, e.Value[i]);
                }
            }

            MessageBox.Show(msg);
        }
    }
}
