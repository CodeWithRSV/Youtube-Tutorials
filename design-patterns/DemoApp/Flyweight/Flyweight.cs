using System.Drawing;

namespace DemoApp
{
    public class MovingParticle
    {

        public (int, int) Coords { get; set; }
        public Particle ParticleType { get; set; }
        public string Vector { get; set; }
        public decimal Speed { get; set; }

        public MovingParticle((int, int) coords, string vector, decimal speed, Particle particleType)
        {
            Coords = coords;
            Vector = vector;
            Speed = speed;
            ParticleType = particleType;
        }

        public void Move()
        {
            ParticleType.Move(Coords,Vector,Speed);
        }

        public void Draw(object canvas)
        {
            ParticleType.Draw(Coords, canvas);

        }
    }
    
    public class Particle
    {
        public Particle(Color color, string image)
        {
            Color = color;
            Image = image;
        }

        public Color Color { get; }
        public string Image { get; }
        public void Move((int,int) coords, string vector, decimal speed)
        {
            //Logic to move particle 
        }

        public void Draw((int, int) coords, object canvas)
        {
            //Logic to draw particle
        }
    }
    
    public class ParticleFactory
    {
        Dictionary<(string, Color), Particle> particlesCache = new Dictionary<(string, Color), Particle>();
        public Particle GetParticle(string image,Color color)
        {
            (string,Color) pair = (image,color);
            if(!particlesCache.ContainsKey(pair))
                particlesCache.Add(pair, new Particle(color,image));
            return particlesCache[pair];
        }
    }
    
    public class Game
    {
        ParticleFactory factory = new ParticleFactory();
        public MovingParticle[] GetBulletParticles()
        {

            Particle particle = factory.GetParticle("bulet.png", Color.Gold);
            return
            [
                new MovingParticle((1,1),"Up",2.4m,particle),
                new MovingParticle((2, 3), "Down", 2.0m, particle),
                new MovingParticle((4, 1), "Left", 1.4m, particle),
                new MovingParticle((3, 2), "Right", 2.1m, particle),
                new MovingParticle((9, 6), "Up", 1.1m, particle),
                new MovingParticle((4, 3), "Down", 1.9m, particle)
            ];
        }
    }
}
