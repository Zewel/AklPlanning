
using System;
using SweaterPlanning.Models;
using SweaterPlanning.Substructure.Repository;

namespace SweaterPlanning.Substructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CodeDbSet context { get; set; }
        public UnitOfWork(CodeDbSet context)
        {
            this.context = context;
        }
        private IRepository<TaskType> tblTaskTypeRepository;
        public IRepository<TaskType> TblTaskTypeRepository
        {
            get
            {
                if (this.tblTaskTypeRepository == null)
                    this.tblTaskTypeRepository = new GenericRepository<TaskType>(context);
                return tblTaskTypeRepository;
            }
        }
        private IRepository<DailyActivity> tblDailyActivityRepository;
        public IRepository<DailyActivity> TblDailyActivityRepository
        {
            get
            {
                if (this.tblDailyActivityRepository == null)
                    this.tblDailyActivityRepository = new GenericRepository<DailyActivity>(context);
                return tblDailyActivityRepository;
            }
        }

        private IRepository<Years> tblYearsRepository;
        public IRepository<Years> TblYearsRepository
        {
            get
            {
                if (this.tblYearsRepository == null)
                    this.tblYearsRepository = new GenericRepository<Years>(context);
                return tblYearsRepository;
            }
        }
        private IRepository<Months> tblMonthsRepository;
        public IRepository<Months> TblMonthsRepository
        {
            get
            {
                if (this.tblMonthsRepository == null)
                    this.tblMonthsRepository = new GenericRepository<Months>(context);
                return tblMonthsRepository;
            }
        } 
        private IRepository<YearlyAmanWeekend> tblYearlyAmanWeekendRepository;
        public IRepository<YearlyAmanWeekend> TblYearlyAmanWeekendRepository
        {
            get
            {
                if (this.tblYearlyAmanWeekendRepository == null)
                    this.tblYearlyAmanWeekendRepository = new GenericRepository<YearlyAmanWeekend>(context);
                return tblYearlyAmanWeekendRepository;
            }
        }
        private IRepository<MonthWiseWorkingDay> tblMonthWiseWorkingDay;
        public IRepository<MonthWiseWorkingDay> TblMonthWiseWorkingDay
        {
            get
            {
                if (this.tblMonthWiseWorkingDay == null)
                    this.tblMonthWiseWorkingDay = new GenericRepository<MonthWiseWorkingDay>(context);
                return tblMonthWiseWorkingDay;
            }
        }
        private IRepository<LogTable> tblLogTableRepository;
        public IRepository<LogTable> TblLogTableRepository
        {
            get
            {
                if (this.tblLogTableRepository == null)
                    this.tblLogTableRepository = new GenericRepository<LogTable>(context);
                return tblLogTableRepository;
            }
        }
        private IRepository<Factory> tblFactoryRepository;
        public IRepository<Factory> TblFactoryRepository
        {
            get
            {
                if (this.tblFactoryRepository == null)
                    this.tblFactoryRepository = new GenericRepository<Factory>(context);
                return tblFactoryRepository;
            }
        }
        private IRepository<UserInfo> tblUserInfoRepository;
        public IRepository<UserInfo> TblUserInfoRepository
        {
            get
            {
                if (this.tblUserInfoRepository == null)
                    this.tblUserInfoRepository = new GenericRepository<UserInfo>(context);
                return tblUserInfoRepository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
