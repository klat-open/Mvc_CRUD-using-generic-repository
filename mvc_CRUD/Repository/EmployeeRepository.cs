using mvc_CRUD.Abstract;
using mvc_CRUD.DAL;
using mvc_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_CRUD.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository{}

    public interface IEmployeeRepository: IRepository<Employee>{}
}

