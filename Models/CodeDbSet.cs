using Microsoft.EntityFrameworkCore;
using SweaterPlanning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class CodeDbSet:DbContext
    {
        public CodeDbSet(DbContextOptions<CodeDbSet> options)
           : base(options)
        {
        }
        //public Microsoft.EntityFrameworkCore.DbSet<TaskType> TaskType { get; set; }
     //   public DbSet<DailyActivity> DailyActivity { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<MonthWiseWorkingDay> MonthWiseWorkingDay { get; set; }
        public DbSet<Years> Years { get; set; }
        public DbSet<Months> Months { get; set; }
        public DbSet<Gauge> Gauges { get; set; }
        public DbSet<GaugeGroup> gaugeGroups { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<MachineBrand> MachineBrands { get; set; }
        public DbSet<MachineQuantity> MachineQuantities { get; set; }
        public DbSet<YearlyCapacityProjection> YearlyCapacityProjections { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Marchant> Marchants { get; set; }
        public DbSet<CapacityAllocate> CapacityAllocates { get; set; }
        public DbSet<YearlyAmanWeekend> YearlyAmanWeekends { get; set; }
        public DbSet<LogTable> LogTables { get; set; }
    }
}
