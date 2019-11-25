using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //simple singleton
            //Parallel.Invoke(
            //    () => FromEmployee(),
            //    () => FromStudent()
            //    );

            //eager singleton

            //Parallel.Invoke(
            //    () => FromEmployeeEager(),
            //    () => FromStudentEager()
            //    );

            //lazy
            Parallel.Invoke(
                () => FromEmployeeLazy(),
                () => FromStudentLazy()
                );

            Console.ReadLine();
        }

        private static void FromStudent()
        {
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");
        }

        private static void FromEmployee()
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("from Employee");
        }

        private static void FromStudentEager()
        {
            SingletonEager fromStudent = SingletonEager.GetInstance;
            fromStudent.PrintDetails("From Student SingletonEager");
        }

        private static void FromEmployeeEager()
        {
            SingletonEager fromEmployee = SingletonEager.GetInstance;
            fromEmployee.PrintDetails("from Employee SingletonEager");
        }

        private static void FromStudentLazy()
        {
            SingletonLazy fromStudent = SingletonLazy.GetInstance;
            fromStudent.PrintDetails("From Student SingletonLazy");
        }

        private static void FromEmployeeLazy()
        {
            SingletonLazy fromEmployee = SingletonLazy.GetInstance;
            fromEmployee.PrintDetails("from Employee SingletonLazy");
        }
    }
}
