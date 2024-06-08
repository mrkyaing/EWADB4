// See https://aka.ms/new-console-template for more information
using Day7;
Console.WriteLine("Hello, World!");
EnglishPeople englishPeople=new EnglishPeople(){
Name="Smith",
Address="USA"
};
englishPeople.DisplayInfo();
Console.WriteLine(englishPeople);
JapanesePeople japanesePeople=new JapanesePeople(){
Name="Amoi",
Address="Tokaya"
};
japanesePeople.AboutMe();
japanesePeople.SayGreetingMessage();
