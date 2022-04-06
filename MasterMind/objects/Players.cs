namespace MasterMind
{
    class Players
    {
        public string Name;
        public int Attempts;
        
        public override string ToString()
        {
            return Name + " [" + Attempts + "]";
        }
    }
}