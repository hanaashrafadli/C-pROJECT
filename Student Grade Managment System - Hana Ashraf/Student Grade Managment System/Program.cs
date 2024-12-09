namespace Student_Grade_Management_System___Hana_Ashraf
{
    enum Grades
    {
        A,
        B,
        C,
        D,
        F,

    }

    struct Scores
    {
        public double[] subjects;
    }
    struct studentData
    {
        public string Name;
        public int ID;
        public Scores studentScores;
        public double subjectsScoreSum;
        public double studentAverage;
        public Grades studentGrade;
    }

    internal class Program
    {
      static studentData[] calculateAverage (int subjectsNumber, studentData[] Students, double subjectsSum)
      {
            
            for (int i = 0; i < Students.Length; i++)
            {
                for (int j = 0; j < subjectsNumber; j++)
                {
                    Students[i].subjectsScoreSum += Students[i].studentScores.subjects[j];
                }
                Students[i].studentAverage = Students[i].subjectsScoreSum / subjectsNumber;
                
            }
            return Students;

      }
        static studentData[] assignGrades (studentData[] Students, Grades studentGrade)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].studentAverage >= 90)
                    Students[i].studentGrade = Grades.A;
                else if (Students[i].studentAverage >= 80 && Students[i].studentAverage < 90)
                    Students[i].studentGrade = Grades.B;
                else if (Students[i].studentAverage >= 70 && Students[i].studentAverage < 80)
                    Students[i].studentGrade = Grades.C;
                else if (Students[i].studentAverage >= 60 && Students[i].studentAverage < 70)
                    Students[i].studentGrade = Grades.D;
                else
                    Students[i].studentGrade = Grades.F;

            }
            return Students;

 

        }
        

        static void Main(string[] args)
        {

            Console.Write("please enter number of students\n");
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            studentData[] Students = new studentData[studentsNumber];
            Console.Write("please enter number of Subjects\n");
            int subjectsNumber = Convert.ToInt32(Console.ReadLine());
            double subjectsSum = 0;
            Grades studentGrade = Grades.A;


            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"Please enter number {i + 1} student Name");
                Students[i].Name = Console.ReadLine();
                Console.WriteLine($"Please enter number {Students[i].Name}'s ID");
                Students[i].ID = Convert.ToInt32(Console.ReadLine());

                Students[i].studentScores.subjects = new double[subjectsNumber];

                
                for (int j = 0; j < subjectsNumber; j++)
                {
                    Console.WriteLine($"Please enter {Students[i].Name}'s Scores \n Subject {j + 1} = ");
                    Students[i].studentScores.subjects[j] = Convert.ToDouble(Console.ReadLine());
    
                }
                

            }





            Console.WriteLine("Do you want to search for student's data ? \n (yes / no )");
            string searchAgreement;
            searchAgreement = Console.ReadLine().ToLower ();
            

            if (searchAgreement == "yes")
            {
                
                Console.WriteLine("please Enter student id \n ID:");
                int enteredId;
                bool isNotValid = true ;
                while (isNotValid == true)
                {
                    enteredId = Convert.ToInt32(Console.ReadLine());
                    for (int k = 0; k < Students.Length; k++)
                    {

                        if (enteredId == Students[k].ID)
                        {
                            Console.WriteLine($"Student name : {Students[k].Name} \n Student Scores: ");

                            for (int i = 0; i < subjectsNumber; i++)
                            {
                                Console.WriteLine($"Subject {i + 1} = {Students[k].studentScores.subjects[i]}\n ");

                            }
                            isNotValid = false ;
                            break;
                        }
                        
                                         
                    }
                    if (isNotValid == true)
                    {
                        Console.WriteLine("Wrong ID please enter a valid one");
                    }

                }
            }
            // searching for student data by Id



            Console.WriteLine("do you need to update any of student data?");
            string updateDataAgreement = Console.ReadLine().ToLower();
            bool updateData = true ;
            if (updateDataAgreement == "yes")
            {
                Console.WriteLine("Please enter the student ID to update their data.");
                int enteredId;
                enteredId = Convert.ToInt32(Console.ReadLine());
                int studentNumber;
                for (int k = 0; k < Students.Length; k++)
                {
                    if (enteredId == Students[k].ID)
                    {
                        studentNumber = k;
                        Console.WriteLine("Please enter the updated data");
                        Console.WriteLine($"Updated student Name: ");
                        Students[studentNumber].Name = Console.ReadLine();
                        Console.WriteLine($"Updated {Students[studentNumber].Name}'s ID");
                        Students[studentNumber].ID = Convert.ToInt32(Console.ReadLine());

                        Students[studentNumber].studentScores.subjects = new double[subjectsNumber];


                        for (int j = 0; j < subjectsNumber; j++)
                        {
                            Console.WriteLine($"Please enter {Students[studentNumber].Name}'s Scores \n Subject {j + 1} = ");
                            Students[studentNumber].studentScores.subjects[j] = Convert.ToInt32(Console.ReadLine());

                        }


                    }
                   
                }

            }

            Students = calculateAverage(subjectsNumber, Students, subjectsSum);
            Students = assignGrades(Students, studentGrade);
            for (int k = 0; k < Students.Length; k++)
            {
                Console.WriteLine($"{k + 1} -  Name =  {Students[k].Name} \t ID = {Students[k].ID} \t Average = {Students[k].studentAverage} \t Score = {Students[k].studentGrade}");

            }

            Console.WriteLine("All students averege:");
            for (int k = 0;k < Students.Length; k++)
            {
                Console.WriteLine($"{k+1}- {Students[k].Name} = {Students[k].studentAverage}\n");

            }
            Console.WriteLine($"Students list who passed grade D");
            for (int k = 0;k<Students.Length; k++)
            {

                if (Students[k].studentGrade != Grades.F)
                {
                    Console.WriteLine($"{Students[k].Name}");
                }

            }
            Console.WriteLine($"Students list who Failed:");
            for (int k = 0; k < Students.Length; k++)
            {

                if (Students[k].studentGrade == Grades.F)
                {
                    Console.WriteLine($"{Students[k].Name}");
                }

            }
            double largestAverage = 0;
            for ( int k = 0;k<Students.Length;k++)
            {

                if (largestAverage < Students[k].studentAverage)
                {
                    largestAverage = Students[k].studentAverage;
                    Console.WriteLine($"the highest average grade is {largestAverage} and it's for {Students[k].Name} ");
                }

            }

        }
    }
}
