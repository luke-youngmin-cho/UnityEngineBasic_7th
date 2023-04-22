using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class PlayerUI
    {
        private string _hpText;

       

        public void Refresh(int hp)
        {
            _hpText = hp.ToString();
            Console.WriteLine(_hpText);
        }
    }
}
