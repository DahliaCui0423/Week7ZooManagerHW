using System;
namespace ZooManager
{
    public class Raptor : Bird
    {
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = new Random().Next(1, 2); // reaction time 1
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a raptor.");
            Hunt("cat");
            Hunt("mouse");
        }


    }
}
