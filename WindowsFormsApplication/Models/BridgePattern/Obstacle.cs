using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BridgePattern
{
    public class Obstacle
    {
        public Position Position { get; set; }
        public string ImageName { get; set; }

        protected ObstacleType ObstacleType;

        public Obstacle(ObstacleType obstacleType, Position position, string imageName)
        {
            this.ObstacleType = obstacleType;
            this.Position = position;
            this.ImageName = imageName;
        }

        public void ObstacleEffect()
        {
            ObstacleType.HazardEffect();
        }

        public bool BlocksPath()
        {
            return ObstacleType.IsBlocking();
        }
    }
}
