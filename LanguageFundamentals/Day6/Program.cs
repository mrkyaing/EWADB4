// See https://aka.ms/new-console-template for more information
using Day6;

Console.WriteLine("Hello, World!");
Human human = new Human()
{
    Type = "human",
    Name = "Mg Mg",
    LifeSpan = 21,
    BlodType = "B",
    IdCard = "12/Datka(11)123456",
    Occupitition = "Student"
};
Dog dog = new Dog()
{
    Type = "dog",
    Name = "Juccy",
    LifeSpan = 20,
};
Console.WriteLine(human);
human.Sound();
Console.WriteLine(dog);
dog.Sound();

