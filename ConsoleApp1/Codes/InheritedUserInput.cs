using System;
using System.Text;

namespace ConsoleApp1.Codes
{
    public class TextInput
    {
        protected readonly StringBuilder InputBuilder = new StringBuilder();

        public virtual void Add(char c)
        {
            InputBuilder.Append(c);
        }

        public string GetValue()
        {
            return InputBuilder.ToString();
        }
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            if (int.TryParse(c.ToString(), out _))
                base.Add(c);
        }
    }

    public class InheritedUserInput
    {
        public static void Run()
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Console.WriteLine(input.GetValue());
        }
    }
}