using Lib.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.EmployeeService
{
    public interface IEmployeeServices
    {
        List<EmployeeDetail> GetEmployeeList();

        bool AddEmployee(EmployeeDetail model);

        EmployeeDetail GetEmployeeById(int Id);

        bool EditEmployee(EmployeeDetail model);

        bool DeleteEmployee(int Id);
    }
}
