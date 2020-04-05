using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDTestProject.BusinessLayer
{
   public  class CalculatorManager
    {
        // BDD için SpecFlow extension un kurulu olması lazım
        // https://specflow.org/getting-started/

        private Memories _memories;

        public CalculatorManager(Memories memories)
        {
            _memories = memories;
        }

        public  bool Addnumber(int i)
        {
            IdentityManagment.IsAuthenticated();
            _memories.Numbers.Add(i);
            return true;
        }

        public  bool RemoveNumber(int i)
        {
            IdentityManagment.IsAuthenticated();
            _memories.Numbers.Remove(i);
            return true;
        }

        public   int SumAllMemories()
        {
            IdentityManagment.IsAuthenticated();
            return _memories.Numbers.Sum();
        }

        public  int Sum(int[] a)
        {
            IdentityManagment.IsAuthenticated();
            return a.Sum();
        }

        public void ClearMemeories()
        {
            _memories.Numbers.Clear();
        }

        public  int Multiply(int[] a)
        {
            IdentityManagment.IsAuthenticated();
            return a.ToMultiply();
        }

    }
}
