namespace RpgLibrary.Items
{
    public class Reagent : BaseItem
    {
        public Reagent(
            string name,
            string type,
            int price,
            float weight) : base(name, type, price, weight, null)
        {
            
        }

        public override object Clone()
        {
            return new Reagent(Name, Type, Price, Weight);
        }
    }
}
