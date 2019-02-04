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

        private Dictionary<int, int> TakeInternal(List<Pack> packsInput, Dictionary<int, int> accumulator, int value)
        {
            var packs = new List<Pack>(packsInput);
            var rest = value;

            for(int i = 0; i < packs.Count; i++)
            {
                var pack = packs[i];
                if(pack.Count == 0 || pack.Value > rest)
                    continue;

                rest -= pack.Value;
                packs[i] = new Pack(pack.Value, pack.Count - 1);

                int previous = 0;
                accumulator.TryGetValue(pack.Value, out previous);
                accumulator[pack.Value] = previous + 1;

                if(rest == 0)
                    return accumulator;

                var temp = new Dictionary<int, int>(accumulator);
                var result = TakeInternal(packs, temp, rest);
                if (result != null)
                    return result;
            }

            return rest == 0 ? accumulator : null;
        }

        public string Take(int value)
        {
            var sorted = load_.OrderByDescending(p => p.Value).ToList();
            var result = TakeInternal(sorted, new Dictionary<int, int>(), value);
            if(result != null)
            {
                var packs = result.Select(each => new Pack(each.Key, each.Value))
                                  .OrderByDescending(p => p.Value)
                                  .ToList();
                return Format(packs);
            } 
            else
            {
                return "Error";
            }
        }

        public static string Format(IEnumerable<Pack> packs)
        {
            var temp = from pack in packs select pack.ToString();
            return String.Join(' ', temp);
        }
    }
}
