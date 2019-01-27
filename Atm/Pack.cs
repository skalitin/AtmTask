namespace Atm
{
    public struct Pack
    {
        public Pack(int value, int count)
        {
            Value = value;
            Count = count;
        }
        public int Value { get; set; }
        public int Count { get; set; }
        public int Amount => Value * Count;
    }
}
