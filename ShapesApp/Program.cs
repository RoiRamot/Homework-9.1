using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesLibs;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Define Shapes
           Rectangle shape1 = new Rectangle(10,15);
           Rectangle shape2 = new Rectangle(20,5);
           Rectangle shape3 = new Rectangle(5,30);
           Ellipse shape4 = new Ellipse(5,5);
           Ellipse shape5 = new Ellipse(9,30);
           Ellipse shape6 = new Ellipse(99,20);
           Circle shape7 = new Circle(5);
           Circle shape8 = new Circle(9);
           Circle shape9 = new Circle(99);

            //Adding New shapes to list
            ShapeManager shapeManager = new ShapeManager();
            shapeManager.Add(shape1);
            shapeManager.Add(shape2);
            shapeManager.Add(shape3);
            shapeManager.Add(shape4);
            shapeManager.Add(shape5);
            shapeManager.Add(shape6);
            shapeManager.Add(shape7);
            shapeManager.Add(shape8);
            shapeManager.Add(shape9);



            Console.WriteLine("Display Method");
            shapeManager.DisplayAll();
            
            Console.WriteLine();
            Console.WriteLine("Save Method");
            Console.WriteLine(shapeManager.Save());
            
            Console.ReadLine();


        }

       public class ShapeManager
        {
           ArrayList ShapesList = new ArrayList();

            public void Add(object shape)
            {
                ShapesList.Add(shape);
            }

            public void DisplayAll()
            {
                foreach (var obj in ShapesList)
                {
                    if (obj is Shape)
                    {
                        Shape shape = (Shape)obj;
                        Console.WriteLine(shape.Area);
                        shape.Display();
                    }
                    
                }
            }


            public int Count
            {
                get { return ShapesList.Count; }
                private set{}
            }

            public string Save()
            {
                StringBuilder sb= new StringBuilder();
                foreach (var shape in ShapesList)
                {
                    if (shape is IPersist)
                    {
                        IPersist p = (IPersist) shape;
                        p.Write(sb);
                    }
                }

                return sb.ToString();
            }

           public object this[int i]
           {
               get { return ShapesList[i]; }
           }
        }
    }
}
