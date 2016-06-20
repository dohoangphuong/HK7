using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSimulation
{
    class Student
    {
        private string Name;
        private string ID;
        private DateTime Birthday;
        private double CSProgramingScore;
        private double RequirementAnalyzeScore;
        private double SoftwareDesignScore;
        private double CodeAndUTScore;
        private double FSoftManagementToolScore;

        /// <summary> 
        /// The class default constructor. 
        /// </summary>
        public Student()
        { 
        }

        /// <summary> 
        /// The class constructor. 
        /// </summary>
        public Student(string name, string id, DateTime birthday, double csProgramingScore, double requirementAnalyzeScore,
                    double softwareDesignScore, double codeAndUTScore, double fSoftManagementToolScore)
        {
            Name = name;
            ID = id;
            Birthday = birthday;
            CSProgramingScore = csProgramingScore;
            RequirementAnalyzeScore = requirementAnalyzeScore;
            SoftwareDesignScore = softwareDesignScore;
            CodeAndUTScore = codeAndUTScore;
            FSoftManagementToolScore = fSoftManagementToolScore;
        }

        /// <summary> 
        /// Display the current student infomation in the console windows 
        /// </summary>
        public void PrintInfomation()
        {
            Console.WriteLine("{0}\t{1}\t{2}\tC#: {3}\tRA: {4}\tSD: {5}" 
            + "\tCaUT: {6}\tFMT: {7}", Name, ID, Birthday.ToShortDateString(), 
            CSProgramingScore , RequirementAnalyzeScore, SoftwareDesignScore, CodeAndUTScore, FSoftManagementToolScore);
        }
    }
}
