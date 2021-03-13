namespace LoveLetter.Cards
{
    public class Guard : Card
    {
        public Guard()
        {
            Name = "Guard";
            Description =
                "Name a non-Guard card and choose another player. If they have that card they're out of the round.";
            Value = 1;
        }
        
        public override void DoAction()
        {
            throw new System.NotImplementedException();
        }
    }
}