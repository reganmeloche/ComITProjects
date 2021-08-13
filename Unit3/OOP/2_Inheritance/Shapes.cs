using System;

namespace Unit3
{
    // abstract class - cannot instantiate it
    public abstract class Shape
    {
        public Shape() {
            Console.WriteLine("Shape constructed");
        }

        public abstract double GetArea(); // no body allowed

    }

    public class Square : Shape {

        private double _sideLength;

        public Square(double sideLength) {
            _sideLength = sideLength;
            Console.WriteLine("Square constructed");
        }

        // must be marked override in derived classes
        public override double GetArea() {
            return _sideLength * _sideLength;
        }
    }

    public class Rectangle : Shape {
        private double _length;
        private double _width;

        public Rectangle(double length, double width) {
            _length = length;
            _width = width;
            Console.WriteLine("Rectangle constructed");
        }

        public override double GetArea() {
            return _length * _width;
        }
    }

    // public class Circle : Shape {

    // }

    // public class Triangle : Shape {

    // }
}
