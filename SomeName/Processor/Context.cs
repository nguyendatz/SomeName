using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeName.Processor
{
    public class Context
    {
        protected Dictionary<string, List<string>> _ErrorList;

        static private Context _instance = null;

        public Context()
        {
            _ErrorList = new Dictionary<string, List<string>>();
        }
        static public Context GetInstance()
        {
            if (_instance == null)
                _instance = new Context();

            return _instance;
        }

        public void AddError(string key, string errorMsg)
        {
            if (_ErrorList.ContainsKey(key))
            {
                _ErrorList[key].Add(errorMsg);
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(errorMsg);
                _ErrorList.Add(key, list);
            }
        }

        public List<string> GetError(string key)
        {
            if (_ErrorList.ContainsKey(key))
            {
                return _ErrorList[key];
            }
            else
                return null;
        }

        public void ShowError(ShowFormat f)
        {
            f.Show(_ErrorList);
        }

        public int GetCount()
        {
            return _ErrorList.Count;
        }

        public bool HasError()
        {
            return GetCount() != 0;
        }
    }
}