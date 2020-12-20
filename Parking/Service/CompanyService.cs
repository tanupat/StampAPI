using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Stamp;
using Parking.Entity;

namespace Parking.Service
{
    public class CompanyService : ICompany
    {
        WarpsystemEntities _dbWarp = new WarpsystemEntities();
        public List<CompanyModel> CheckLevelCompany(string ternCode)
        {
            List<CompanyModel> company_list = new List<CompanyModel>();
            company_list = this._dbWarp.PkDepartments.Where(c => c.CompanyID == ternCode).Select(x => new CompanyModel
            { TernCode = x.CompanyID, CompanyName = x.DeptName, TernsubCode = x.DeptID }).ToList();
            return company_list;
        }

        public string CompanyName(string terncode, string ternsubcode)
        {
            string companyName = this._dbWarp.PkDepartments.Where(x => x.CompanyID == terncode &
             x.DeptID == ternsubcode).Select(c =>
             c.DeptName).SingleOrDefault().ToString();

            return companyName;
        }
    }
}