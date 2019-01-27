using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Atm
{
    public class Terminal
    {
        ICollection<Pack> load_;
        public Terminal(ICollection<Pack> load) => this.load_ = load;
        public string Take(int value)
        {
            var sorted = load_.ToArray();
            Array.Sort<Pack>(sorted, (x,y) => y.Value - x.Value);
            
            var result = new List<Pack>();
            foreach(var each in sorted)
            {
                int count = value / each.Value;
                if(count > 0)
                {
                    var pack = new Pack(each.Value, count);
                    result.Add(pack);
                    value -= pack.Amount;
                }
            }
            
            return value == 0 ? Format(result) : "Error"; 
        }
        public static string Format(IEnumerable<Pack> packs)
        {
            var result = new StringBuilder();
            foreach(var each in packs)
            {
                result.Append($"{each.Count}x{each.Value} ");
            }
            return result.ToString();
        }
    }
}
