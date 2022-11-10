using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ChristmasTree and two Decorators
            ChristmasTree c = new ChristmasTree();
            Ornaments d1 = new Ornaments();
            Lights d2 = new Lights();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Tree"
    abstract class Tree
    {
        public abstract void Operation();
    }

    // "ChristmasTree"
    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("Creation of Christmas tree");
        }
    }
    // "Decorator"
    abstract class Decorator : Tree
    {
        protected Tree component;

        public void SetComponent(Tree component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "Ornaments"
    class Ornaments : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("Hang Christmas ornaments");
        }
    }

    // "Lights" 
    class Lights : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("Turn on the Christmas lights");
        }
        void AddedBehavior()
        { }
    }
}