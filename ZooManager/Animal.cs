using System;
namespace ZooManager
{
    public class Animal
    {
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        public int distance = 1;
        
        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }


        static public int Seek(int x, int y, Direction d, int distance, string target)
        {
            int addY = 1;
            int addX = 1;
            switch (d)
            {
                case Direction.up:
                    addY = -1;
                    break;
                case Direction.down:
                    addY = 1;
                    break;
                case Direction.left:
                    addX = -1;
                    break;
                case Direction.right:
                    addX = 1;
                    break;
            }
            for (int i = 0; i < distance; i++) // Add a for loop to hold the iteration of movement.
            {
                if (d == Direction.up || d == Direction.down)
                {
                    y += addY; // move on y axis
                }

                if (d == Direction.left || d == Direction.right)
                {
                    x += addX; // move on x axis
                }
                if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) break; // when touch the edge, jump out the for loop
                if (Game.animalZones[y][x].occupant != null)
                {
                    if (Game.animalZones[y][x].occupant.species == target)
                    {
                        int numbers = i + 1;
                        Console.WriteLine("distance: " + numbers);
                        return i + 1;  // return the number of squares to the target.
                    }
                }
            }
            return 0;
        }


        public void Hunt(string target)
        {
            if (Seek(location.x, location.y, Direction.up, distance, target) == 1)
            {
                Game.Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, distance, target) == 1)
            {
                Game.Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, distance, target) == 1)
            {
                Game.Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, distance, target) == 1)
            {
                Game.Attack(this, Direction.right);
            }
        }

        public virtual void Flee(string target)
        {
            if (Seek(location.x, location.y, Direction.up, distance, target) == 1)
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Seek(location.x, location.y, Direction.down,distance, target) == 1)
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Seek(location.x, location.y, Direction.left,distance, target) == 1)
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Seek(location.x, location.y, Direction.right,distance, target) == 1)
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
        }

        public int Move(Direction d, int distance)
        {
            int moveDistance = 0;
            for(int i=0; i < distance; i++)
            {
                switch (d)
                {
                    case Direction.up:
                        if(location.y - 1 >= 0 && Game.animalZones[location.y - 1][location.x].occupant == null)
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y - 1][this.location.x].occupant = this;
                            //this.location.y--;
                            Console.WriteLine("Escaped!");
                            moveDistance++;
                        }
                        break;
                    case Direction.down:
                        if (location.y + 1 <= Game.numCellsY - 1 && Game.animalZones[location.y + 1][location.x].occupant == null)
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y + 1][this.location.x].occupant = this;
                            //this.location.y++;
                            Console.WriteLine("Escaped!");
                            moveDistance++;
                        }
                        break;
                    case Direction.left:
                        if (location.x - 1 >= 0 && Game.animalZones[location.y][location.x - 1].occupant == null)
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y][this.location.x - 1].occupant = this;
                            //this.location.x--;
                            Console.WriteLine("Escaped!");
                            moveDistance++;
                        }
                        break;
                    case Direction.right:
                        if (location.x + 1 <= Game.numCellsX - 1 && Game.animalZones[location.y][location.x + 1].occupant == null)
                        {
                            Game.animalZones[location.y][location.x + 1].occupant = this;
                            Game.animalZones[location.y][location.x].occupant = null;
                            //this.location.x++;
                            Console.WriteLine("Escaped!");
                            moveDistance++;
                        }
                        break;
                }
            }
            return moveDistance;
        }
    }
}
