using Lib.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lib.Service.EmployeeService
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly employeedbContext _context;
        public EmployeeServices(employeedbContext context)
        {
            _context = context;                            
        }

        public List<EmployeeDetail> GetEmployeeList()
        {
            List<EmployeeDetail> employeList = new List<EmployeeDetail>();

            employeList = _context.EmployeeDetail.ToList();

            return employeList;
        }

        public bool AddEmployee(EmployeeDetail model)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    model.CreateOn = DateTime.Now;
                    model.LastupdateOn = DateTime.Now;

                    _context.EmployeeDetail.Add(model);
                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public EmployeeDetail GetEmployeeById(int Id)
        {
            var data = _context.EmployeeDetail.Where(a => a.Id == Id).FirstOrDefault();

            if (data != null)
            {
                var model = new EmployeeDetail
                {
                    Id = data.Id,
                    Emplyoee = data.Emplyoee,
                    Departmet = data.Departmet,
                    Emailid = data.Emailid,
                    LastupdateOn = data.LastupdateOn
                };


                return model;
            }

            return new EmployeeDetail();
        }

        public bool EditEmployee(EmployeeDetail model)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.EmployeeDetail.FirstOrDefault(a => a.Id == model.Id);

                    if (data != null)
                    {
                        data.Emplyoee = model.Emplyoee;
                        data.Emailid = model.Emailid;
                        data.Departmet = model.Departmet;
                        data.LastupdateOn = DateTime.Now;

                        _context.EmployeeDetail.Update(data);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }


                    return false;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool DeleteEmployee(int Id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.EmployeeDetail.FirstOrDefault(a => a.Id == Id);

                    if (data != null)
                    {
                        _context.EmployeeDetail.Remove(data);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }


                    return false;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
