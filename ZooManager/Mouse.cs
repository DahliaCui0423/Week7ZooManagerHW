using System;
namespace ZooManager
{
    public class Mouse : Animal
    {
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            distance = 1;
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Flee("cat");
            
        }



        public override void Flee(string target)
        {
            int directionIndex = new Random().Next(0, 4);
            Direction randomDirection = Direction.left;
            if (Seek(location.x, location.y, Direction.up, distance, target) == 1 && location.y > 0)
            {
                if (directionIndex == 2)
                {
                    directionIndex++;
                }
                randomDirection = (Direction)Enum.GetValues(typeof(Direction)).GetValue(directionIndex);
                Console.WriteLine("Direction: " + randomDirection);
                Move(randomDirection, 2);
                return;
            }
            if (Seek(location.x, location.y, Direction.down, distance, target) == 1 && location.y < Game.numCellsY - 1)
            {
                if (directionIndex == 3)
                {
                    directionIndex = 0;
                }
                randomDirection = (Direction)Enum.GetValues(typeof(Direction)).GetValue(directionIndex);
                Console.WriteLine("Direction: " + randomDirection);
                Move(randomDirection, 2);
                return;
            }
            if (Seek(location.x, location.y, Direction.left, distance, target) == 1 && location.x > 0)
            {

                if (directionIndex == 0)
                {
                    directionIndex++;
                }
                randomDirection = (Direction)Enum.GetValues(typeof(Direction)).GetValue(directionIndex);
                Console.WriteLine("Direction: " + randomDirection);
                Move(randomDirection, 2);
                return;
            }
            if (Seek(location.x, location.y, Direction.right, distance, target) == 1 && location.x < Game.numCellsX - 1)
            {

                if (directionIndex == 1)
                {
                    directionIndex++;
                }
                randomDirection = (Direction)Enum.GetValues(typeof(Direction)).GetValue(directionIndex);
                Console.WriteLine("Direction: " + randomDirection);
                Move(randomDirection, 2);
                return;
            }

            Console.Write(name + " escaped, location: " + location.x + "," + location.y);
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */

    }
}

