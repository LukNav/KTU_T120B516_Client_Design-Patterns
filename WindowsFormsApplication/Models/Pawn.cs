using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    public class Pawn
    {
        public Pawn(Position position, string imageName, int health, int cost, int speed, int damage)
        {
            Position=position;
            ImageName=imageName;
            Health=health;
            Cost=cost;
            Speed=speed;
            Damage=damage;
        }

        public Position Position { get; set; }
        public string ImageName { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
    }
}
