
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;


namespace BLL.Services
{
    //public class ReportsService : IReportsService
    //{
    //    IDbRepository db;
    //    public ReportsService(IDbRepository db)
    //    { 
    //        this.db = db;
    //    }

    //    public List<SPResult> ExecSP(int study_year, int housing)
    //    {
    //       return db.Reports.ExecuteSP(study_year, housing);
    //    }

    //    public List<ReportData> Report1(int val)
    //    {
    //        return db.Reports.Report1(val);
    //    }
    //}
}
