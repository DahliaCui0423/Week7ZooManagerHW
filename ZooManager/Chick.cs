using System;
namespace ZooManager
{
    public class Chick : Bird
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11); // reaction time 6 to 10
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick.");
            Flee("cat");
        }


    }
}
