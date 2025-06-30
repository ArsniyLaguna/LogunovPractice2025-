using System;

namespace task04
{
    public interface ISpaceship
    {
        void MoveForward();
        void Rotate(int angle);
        void Fire();
        int Speed { get; }
        int FirePower { get; }
    }

    public class Cruiser : ISpaceship
    {
        private int angle;

        public int Speed => 50;
        public int FirePower => 100;

        public void MoveForward()
        {
            Console.WriteLine("Cruiser slowly moves forward.");
        }

        public void Rotate(int angle)
        {
            this.angle += angle;
            Console.WriteLine($"Cruiser rotated to {this.angle} degrees");
        }

        public void Fire()
        {
            Console.WriteLine("Cruiser fired a big photon rocket!");
        }
    }

    public class Fighter : ISpaceship
    {
        private int currentRotation = 0;

        public int Speed => 100;
        public int FirePower => 40;

        public void MoveForward()
        {
            Console.WriteLine("Fighter zooms forward!");
        }

        public void Rotate(int angle)
        {
            currentRotation += angle;
            Console.WriteLine($"Fighter rotated by {angle} degrees");
        }

        public void Fire()
        {
            Console.WriteLine("Fighter fired weak photon rocket.");
        }
    }
}