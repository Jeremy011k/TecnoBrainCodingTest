using EmployeeHeirarchy;
using System;
using Xunit;

namespace EmployeeHeirarchyTests
{
    public class EmployeeHeirarchyTests
    {
        string testData = "Employee1,Employee8,2000\n" +
                "Employee5,Employee1,2000\n" +
                "Employee2,Employee7,2000\n" +
                "Employee6,Employee2,2000\n" +
                "Employee3,Employee4,2000\n" +
                "Employee4,Employee6,2000\n" +
                "Employee7,Employee6,2000\n" +
                "Employee8,Employee2,2000\n";
        [Fact]
        public void Test1()
        {
            
            Employees employees = new Employees(testData);
            Assert.Equal(10000, employees.GetManagerEmployeeBudget("Employee2"));
            
        }
         [Fact]
        public void Test2()
        {
            
            Employees employees = new Employees(testData);
            Assert.Equal(6000, employees.GetManagerEmployeeBudget("Employee8"));
            
        }


    }
}
