using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeHeirarchy
{
    public class Employee
    {
        private List<string> _employeesUnder = new List<string>();

        public string Id { get; set; }
        public string ManagerId { get; set; }
        public long EmployeeSalary { get; set; }
        public Employee(string id, string managerId, long employeeSalary)
        {
            if (!string.IsNullOrEmpty(managerId))
            {
                Employee manager = EmployeeDb.GetById(managerId);
                if (manager != null)
                {
                    if (manager.CheckCircularReference(id))
                        throw new ArgumentException("Circular reference detected");
                    manager.AddEmployeeUnder(id);
                }
            }
            
            Id = id;
            ManagerId = managerId;
            EmployeeSalary = employeeSalary;
            _employeesUnder = EmployeeDb.Employees.Where(e=>e.ManagerId==Id).Select(e=>e.Id).ToList();
            
        }

        public void SetManager(string managerId)
        {
            if (!string.IsNullOrEmpty(ManagerId))
                if (managerId != ManagerId)
                    throw new ArgumentException("An employee should report to only one manager");
            ManagerId = managerId;
        }
        public void AddEmployeeUnder(string employeeId)
        {
            if (!_employeesUnder.Contains(employeeId))
                _employeesUnder.Add(employeeId);
        }
        

        public long GetSalaryBudget()
        {
            long salaryBudget = 0;
            foreach (var child in _employeesUnder)
            {
                Employee employee = EmployeeDb.GetById(child);
                if (employee != null)
                    salaryBudget = salaryBudget + employee.GetSalaryBudget();
            }
            salaryBudget = salaryBudget + EmployeeSalary;
            return salaryBudget;
        }

        public bool CheckCircularReference(string id)
        {
            var manager = EmployeeDb.GetById(id);
            if (manager == null)
                return false;
            else if (manager.ManagerId == Id)
                return true;
            else
                return CheckCircularReference(manager.ManagerId);
        }
    }
}
