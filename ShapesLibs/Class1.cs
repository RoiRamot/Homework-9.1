using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibs
{

    public interface IPersist
    {
        void Write(StringBuilder sb);
    }
   public abstract class Shape
    {
        public ConsoleColor Color { get; set; }
        public abstract int Area { get;}

        public Shape(ConsoleColor color)
        {
            Color = color;
        }

        public Shape()
        {
            Color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.ForegroundColor = Color;
        }
    }

    public class Rectangle : Shape, IPersist, IComparable
    {

        public int Height;
        public int Width;
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public override int Area
        {
            get
            {
                int area = Height*Width;
                return area;
            }
        }

        public override void Display()
        {
            Console.WriteLine(Height);
            Console.WriteLine(Width);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(Height.ToString());
            sb.AppendLine(Width.ToString());
        }

        public int CompareTo(object obj)
        {
            Rectangle otherRectangle = obj as Rectangle;
            if (otherRectangle!=null)
            {
                return this.Area.CompareTo(otherRectangle.Area);
            }
            else
            {
                throw new Exception("unable to compare");
            }
        }
    }

    public class Ellipse : Shape, IPersist
    {

        public int Height;
        public int Width;
        public Ellipse(int height, int width)
        {
            Height = height;
            Width = width;
        }    
        public Ellipse()
        {
            Height = 10;
            Width = 10;
        }

        public override int Area
        {
            get
            {

                int area = Convert.ToInt32(System.Math.PI) * (Height * Width);
                return area;
            }
        }


        public virtual void Write(StringBuilder sb)
        {
            sb.AppendLine(Height.ToString(CultureInfo.InvariantCulture));
            sb.AppendLine(Width.ToString(CultureInfo.InvariantCulture));
        }
    }

    public class Circle : Ellipse
    {
        public int Radius;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public override int Area
        {
            get
            {

                int area = Convert.ToInt32(System.Math.PI)*Radius*2;
                return area;
            }
        }

        public override void Display()
        {
            Console.WriteLine(Radius);
        }

        public override void Write(StringBuilder sb)
        {
           sb.AppendLine(Radius.ToString(CultureInfo.InvariantCulture));
        }
    }

}
