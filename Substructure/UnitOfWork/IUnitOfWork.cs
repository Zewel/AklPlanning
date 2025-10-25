
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweaterPlanning.Models;
using SweaterPlanning.Substructure.Repository;

namespace SweaterPlanning.Substructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TaskType> TblTaskTypeRepository { get; }
        IRepository<DailyActivity> TblDailyActivityRepository { get; }
        IRepository<Years> TblYearsRepository { get; }
        IRepository<Months> TblMonthsRepository { get; }
        IRepository<YearlyAmanWeekend> TblYearlyAmanWeekendRepository { get; }
        IRepository<MonthWiseWorkingDay> TblMonthWiseWorkingDay { get; }
        IRepository<LogTable> TblLogTableRepository { get; }
        IRepository<Factory> TblFactoryRepository { get; }
        IRepository<UserInfo> TblUserInfoRepository { get; }
    }
}
