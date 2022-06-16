using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.XamarinApp.Models
{
    public class DataStore
    {
        private List<string> _store = new List<string>();

        public void SetValue(string test)
        {
            _store.Add(test);
        }

        public List<string> GetList()
        {
            return _store;
        }
    }
}
