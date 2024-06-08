// See https://aka.ms/new-console-template for more information
using Day5;

Console.WriteLine("Hello, World!");
Cat cat=new Cat();
cat.Name="jack";
cat.Type="pet";
cat.Eat();
cat.Sleep();
cat.Sound();
Console.WriteLine(cat);
Dog dog=new Dog();
dog.Name="jukky";
dog.Type="pitbull";
dog.Eat();
dog.Sleep();
dog.Sound();
Console.WriteLine(dog);