namespace LoveLetter.Cards
{
    public class Baron : Card
    {
        public Baron()
        {
            Name = "Baron";
            Description =
                "You and another player secretly compare hands. The player with the lower value is out of the round.";
            Value = 3;
        }
        
        public override void DoAction()
        {
            throw new System.NotImplementedException();
        }
    }
}