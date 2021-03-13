namespace LoveLetter.Cards
{
    public class Priest : Card
    {
        public Priest()
        {
            Name = "Priest";
            Description = "Look at another player's hand.";
            Value = 2;
        }

        public override void DoAction()
        {
            throw new System.NotImplementedException();
        }
    }
}