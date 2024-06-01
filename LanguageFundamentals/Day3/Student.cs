namespace StudentInfo
{
    public class Student
    {
        public string Id;
        public string Name;
        public Student(){

        }
        public Student(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public static void SayHello()
        {
            System.Console.WriteLine("Hello");
        }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }

        public List<Student> getAllStudent(){
            return new List<Student>(){
             new Student("s1","Mg mg "),
             new Student("s2","Aye Aye")
            };
        }

        public override string ToString()
        {
            return $"Id:{Id},Name:{Name}";
        }
    
    }
}