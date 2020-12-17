namespace Library.Types
{
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            Name = "Stereobank";
            AvailableCards = new[] {"Black", "White", "Iron"};
        }
    }
}