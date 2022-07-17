using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static EmployeeHeirarchy.Employees;

namespace EmployeeHeirarchy
{

    
    public class Employees
    {
        
        public Employees(string csv)
        {
            using var stringReadr = new StringReader(csv);

            int count = 0;
            string line;
            int ceos = 0;

            while ((line = stringReadr.ReadLine()) != null)
            {
                count++;
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                    throw new ArgumentException("Not a valid csv");
                long salary;
                if (!long.TryParse(parts[2], out salary))
                    throw new ArgumentException($"Salary value in row {count} is invalid");
                if (string.IsNullOrEmpty(parts[0]))
                    throw new ArgumentException($"Employee in row {count} has no Id");
                if (string.IsNullOrEmpty(parts[1]))
                    ceos++;
                if (ceos > 1)
                    throw new ArgumentException($"More than one CEO defined");

                if (EmployeeDb.EmployeeExists(parts[0]))
                    throw new ArgumentException("Employee already Exists");

                EmployeeDb.AddEmployee(new Employee(parts[0], parts[1], salary));
            }
        }

        public long GetManagerEmployeeBudget(string managerId)
        {
            long salaryBudget=0;
            Employee employee = EmployeeDb.GetById(managerId);
            if (employee == null)
                throw new InvalidOperationException("Manager does not exist");
            salaryBudget = salaryBudget + employee.GetSalaryBudget();
            return salaryBudget;
        }


        
    }
    public static class EmployeeDb
    {
        public static List<Employee> Employees = new List<Employee>();
        public static bool EmployeeExists(string id)
        {
            return Employees.Any(employee => employee.Id == id);
        }

        public static Employee GetById(string id)
        {
            return Employees.FirstOrDefault(employee => employee.Id == id);
        }

        internal static void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
    }
}

