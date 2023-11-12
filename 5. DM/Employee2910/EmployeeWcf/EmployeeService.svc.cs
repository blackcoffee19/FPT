using EmployeeWcf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        EmployeeDBEntities ctx = new EmployeeDBEntities();

        public async Task<List<EmployeeContact>> FindAll()
        {
            return await ctx.Employees.Select(a => new EmployeeContact { EmployeeId = a.EmployeeId, Password = a.Password, EmployeeName = a.EmployeeName, Age = (int)a.Age }).ToListAsync();
        }
        public async Task<EmployeeContact> Create(EmployeeContact emp)
        {
            Employee em = new Employee
            {
                EmployeeId = emp.EmployeeId,
                Password = emp.Password,
                Age = emp.Age,
                EmployeeName = emp.EmployeeName,
            };
            try
            {
                ctx.Employees.Add(em);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return new EmployeeContact { Age=em.Age,EmployeeId=em.EmployeeId,EmployeeName=em.EmployeeName,Password=em.Password};
        }
        public async Task<EmployeeContact> FindById(string id)
        {
            Employee emp = await ctx.Employees.FirstOrDefaultAsync(xo => xo.EmployeeId == id);
            if(emp == null)
            {
                return null;
            }
            else
            {
                return new EmployeeContact { 
                    EmployeeId = emp.EmployeeId,
                    Password = emp.Password,
                    EmployeeName = emp.EmployeeName,
                    Age = emp.Age
                };
            }
        }
        public async Task<EmployeeContact> Login (string username, string password)
        {
            Employee emo = await ctx.Employees.FirstOrDefaultAsync(x => x.EmployeeId == username && x.Password == password);
            return new EmployeeContact { 
                EmployeeId= emo.EmployeeId,
                EmployeeName = emo.EmployeeName,
                Password = emo.Password,
                Age= emo.Age
            };
        }
        public async Task<bool> Update(EmployeeContact emp)
        {
            if (emp == null)
            {
                return false;
            }
            Employee em = new Employee
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                Age = emp.Age,
                Password = emp.Password
            };
            ctx.Entry(em).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                Employee em = await ctx.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
                ctx.Entry(em).State = EntityState.Deleted;
                await ctx.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
