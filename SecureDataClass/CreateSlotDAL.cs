
using SweaterPlanning.DllClass;
using SweaterPlanning.Models;
using SweaterPlanning.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class CreateSlotDAL : DataAccessLayer
    {
        public dynamic StartDateEndDate(int yearId, int factoryId, int brandId, int guageId, int leadTime)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@FactoryId", factoryId));
                aParameters.Add(new SqlParameter("@BrandId", brandId));
                aParameters.Add(new SqlParameter("@GaugeId", guageId));
                aParameters.Add(new SqlParameter("@LeadTime", leadTime));

                DataTable dt = GetDataTable("GetStartEndDate_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic SvaeSlot(PlanningSlotMaster entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@yearId", entity.YearId));
                aParameters.Add(new SqlParameter("@FactoryId", entity.FactoryId));
                aParameters.Add(new SqlParameter("@BrandId", entity.BrandId));
                aParameters.Add(new SqlParameter("@GaugeId", entity.GaugeId));
                aParameters.Add(new SqlParameter("@LeadTime", entity.LeadTime));
                aParameters.Add(new SqlParameter("@StartDate", entity.StartDate));
                aParameters.Add(new SqlParameter("@EndDate", entity.EndDate));
                aParameters.Add(new SqlParameter("@StageId", entity.StageId));
                aParameters.Add(new SqlParameter("@CreateBy", entity.CreateBy));
                aParameters.Add(new SqlParameter("@CreateDate", entity.CreateDate));
                aParameters.Add(new SqlParameter("@MachineQty", entity.NoOfMachine));

                bool dt = SaveData("SaveSlot_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic SlotList(int yearId,int factoryId=0, string styleNumber=null)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@FactoryId", factoryId));
                aParameters.Add(new SqlParameter("@StyleNumber", styleNumber));
                DataSet dt = GetDataSet("PlanningSlotList_sp", aParameters, true);
                DataTable factoryList = dt.Tables[0];
                DataTable aTable = dt.Tables[1];
                List<FactoryListView> factoryListViews = DataTableToList.ToListof<FactoryListView>(factoryList);
                PlaneSlotView aVeiw = new PlaneSlotView();
                IEnumerable<PlaneSlotView> aPlaneSlotList = DataTableToList.ToListof<PlaneSlotView>(aTable);
                var result = aPlaneSlotList.Select(i => new { i.PlaneSlotMasterId }).Distinct().ToList();
                List<PlanningSlotMasterView> distPlaneSlotMasterView = new List<PlanningSlotMasterView>();
                List<PlanningSlotDetailsView> planningSlotDetailsViews = new List<PlanningSlotDetailsView>();
                foreach (var data in aPlaneSlotList)
                {
                    PlanningSlotDetailsView planningSlotDetail = new PlanningSlotDetailsView();
                    if (data.PlanningSlotDetailsId > 0)
                    {
                        planningSlotDetail.PlanningSlotDetailsId = data.PlanningSlotDetailsId;
                        planningSlotDetail.PlaneMasterId = data.PlaneMasterId;
                        planningSlotDetail.POCod = data.POCod;
                        planningSlotDetail.PONo = data.PONo;
                        planningSlotDetail.PoQty = data.PoQty;
                        planningSlotDetail.stylecode = data.stylecode;
                        planningSlotDetail.StyleNumber = data.StyleNumber;
                        planningSlotDetail.SmvKn = data.SmvKn;
                        planningSlotDetail.RequiredMachine = data.RequiredMachine;
                        planningSlotDetail.Remarks = data.Remarks;
                        planningSlotDetail.TrialDate = data.TrialDate;
                        planningSlotDetail.DeliveryDate = data.ExftyNew;
                        planningSlotDetail.CriticalTyp = data.CriticalTyp;
                        planningSlotDetail.DaybeforeKnitt = data.DaybeforeKnitt;
                        planningSlotDetail.KnittQty = data.KnittQty;
                        planningSlotDetail.FlagStatus = data.FlagStatus;
                        planningSlotDetail.PoSplitId = data.PoSplitId;
                        planningSlotDetailsViews.Add(planningSlotDetail);
                    }
                }

                foreach (var item in result)
                {
                    PlanningSlotMasterView planningSlotMasterView = new PlanningSlotMasterView();
                    var re = aPlaneSlotList.Where(i => i.PlaneSlotMasterId == item.PlaneSlotMasterId).Select(i => i).FirstOrDefault();
                    planningSlotMasterView.PlaneSlotMasterId = re.PlaneSlotMasterId;
                    planningSlotMasterView.YearId = re.YearId;
                    planningSlotMasterView.YearName = re.YearName;
                    planningSlotMasterView.FactoryId = re.FactoryId;
                    planningSlotMasterView.ShortForm = re.ShortForm;
                    planningSlotMasterView.BrandId = re.BrandId;
                    planningSlotMasterView.McnType = re.McnType;
                    planningSlotMasterView.GaugeId = re.GaugeId;
                    planningSlotMasterView.GaugeDesc = re.GaugeDesc;
                    planningSlotMasterView.LeadTime = re.LeadTime;
                    planningSlotMasterView.NoOfMachine = re.NoOfMachine;
                    planningSlotMasterView.StartDate = re.StartDate;
                    planningSlotMasterView.EndDate = re.EndDate;
                    planningSlotMasterView.StageName = re.StageName;
                    planningSlotMasterView.SlotDetailsViews = planningSlotDetailsViews.Where(i => i.PlaneMasterId == item.PlaneSlotMasterId).ToList();
                    distPlaneSlotMasterView.Add(planningSlotMasterView);
                }

                var tuple = new Tuple<List<FactoryListView>, List<PlanningSlotMasterView>>(factoryListViews, distPlaneSlotMasterView);
                return tuple;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic SlotListFull(int yearId, int factoryId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@FactoryId", factoryId));
                DataSet dt = GetDataSet("PlanningSlotListLoadFull_sp", aParameters, true);
                DataTable factoryList = dt.Tables[0];
                DataTable aTable = dt.Tables[1];
                List<FactoryListView> factoryListViews = DataTableToList.ToListof<FactoryListView>(factoryList);
                PlaneSlotView aVeiw = new PlaneSlotView();
                IEnumerable<PlaneSlotView> aPlaneSlotList = DataTableToList.ToListof<PlaneSlotView>(aTable);
                var result = aPlaneSlotList.Select(i => new { i.PlaneSlotMasterId }).Distinct().ToList();
                List<PlanningSlotMasterView> distPlaneSlotMasterView = new List<PlanningSlotMasterView>();
                List<PlanningSlotDetailsView> planningSlotDetailsViews = new List<PlanningSlotDetailsView>();
                foreach (var data in aPlaneSlotList)
                {
                    PlanningSlotDetailsView planningSlotDetail = new PlanningSlotDetailsView();
                    if (data.PlanningSlotDetailsId > 0)
                    {
                        planningSlotDetail.PlanningSlotDetailsId = data.PlanningSlotDetailsId;
                        planningSlotDetail.PlaneMasterId = data.PlaneMasterId;
                        planningSlotDetail.POCod = data.POCod;
                        planningSlotDetail.PONo = data.PONo;
                        planningSlotDetail.PoQty = data.PoQty;
                        planningSlotDetail.stylecode = data.stylecode;
                        planningSlotDetail.StyleNumber = data.StyleNumber;
                        planningSlotDetail.SmvKn = data.SmvKn;
                        planningSlotDetail.RequiredMachine = data.RequiredMachine;
                        planningSlotDetail.Remarks = data.Remarks;
                        planningSlotDetail.TrialDate = data.TrialDate;
                        planningSlotDetail.DeliveryDate = data.ExftyNew;
                        planningSlotDetail.CriticalTyp = data.CriticalTyp;
                        planningSlotDetail.DaybeforeKnitt = data.DaybeforeKnitt;
                        planningSlotDetail.KnittQty = data.KnittQty;
                        planningSlotDetail.FlagStatus = data.FlagStatus;
                        planningSlotDetail.PoSplitId = data.PoSplitId;
                        planningSlotDetailsViews.Add(planningSlotDetail);
                    }
                }

                foreach (var item in result)
                {
                    PlanningSlotMasterView planningSlotMasterView = new PlanningSlotMasterView();
                    var re = aPlaneSlotList.Where(i => i.PlaneSlotMasterId == item.PlaneSlotMasterId).Select(i => i).FirstOrDefault();
                    planningSlotMasterView.PlaneSlotMasterId = re.PlaneSlotMasterId;
                    planningSlotMasterView.YearId = re.YearId;
                    planningSlotMasterView.YearName = re.YearName;
                    planningSlotMasterView.FactoryId = re.FactoryId;
                    planningSlotMasterView.ShortForm = re.ShortForm;
                    planningSlotMasterView.BrandId = re.BrandId;
                    planningSlotMasterView.McnType = re.McnType;
                    planningSlotMasterView.GaugeId = re.GaugeId;
                    planningSlotMasterView.GaugeDesc = re.GaugeDesc;
                    planningSlotMasterView.LeadTime = re.LeadTime;
                    planningSlotMasterView.NoOfMachine = re.NoOfMachine;
                    planningSlotMasterView.StartDate = re.StartDate;
                    planningSlotMasterView.EndDate = re.EndDate;
                    planningSlotMasterView.StageName = re.StageName;
                    planningSlotMasterView.SlotDetailsViews = planningSlotDetailsViews.Where(i => i.PlaneMasterId == item.PlaneSlotMasterId).ToList();
                    distPlaneSlotMasterView.Add(planningSlotMasterView);
                }

                var tuple = new Tuple<List<FactoryListView>, List<PlanningSlotMasterView>>(factoryListViews, distPlaneSlotMasterView);
                return tuple;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic AllPoNO(int slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                DataTable dt = GetDataTable("GetAllPOForPlanning", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetLastDateForPlanning(int yearId, int factoryId, int brandId, int guageId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@FactoryId", factoryId));
                aParameters.Add(new SqlParameter("@BrandId", brandId));
                aParameters.Add(new SqlParameter("@GaugeId", guageId));

                DataTable dt = GetDataTable("GetLastDateOfPlanning", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic CalculateLastDateForPlanning(DateTime firstDate, int leadTime)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@FirstDate", firstDate));
                aParameters.Add(new SqlParameter("@LeadTime", leadTime));

                DataTable dt = GetDataTable("CalculateLastDate_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetStyleInfo(int poId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoId", poId));
                DataTable dt = GetDataTable("GetStyleInfoByPoId", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetStyleInfoAllSplitPo(int poId, int splitId, int poOwnerType)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoId", poId));
                aParameters.Add(new SqlParameter("@PoSplitId", splitId));
                aParameters.Add(new SqlParameter("@PoType", poOwnerType));
                DataTable dt = GetDataTable("GetStyleInfoByPoIdWithSplit", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetSlotDetailFCalCuMcn(int slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                DataTable dt = GetDataTable("GetSlotDetailsFCalCuMcn", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetSlotDetail(int slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                DataTable dt = GetDataTable("AllPoInSlot", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetSlotInfo(int slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                DataTable dt = GetDataTable("GetSlotInfo_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic SaveAllPo(IEnumerable<PlanningSlotDetails> entity, int userId, int LeadTime = 0)
        {
            try
            {
                bool dt = false;
                var updateData=new DataTable();
                var planningSlotMastId = entity.FirstOrDefault().PlaneSlotMasterId;
                if (LeadTime > 0)
                {
                    updateData = ChangeLeadTime(planningSlotMastId, LeadTime, userId);
                }


                if (updateData.Rows.Count>0)
                {
                    SqlConnectionOpen("Planning_NW");
                    foreach (var item in entity)
                    {
                        if (item.PlanningSlotDetailsId == 0)
                        {
                            List<SqlParameter> aListParameters = new List<SqlParameter>();
                            aListParameters.Add(new SqlParameter("@PlaneSlotMasterId", item.PlaneSlotMasterId));
                            aListParameters.Add(new SqlParameter("@POCod", item.POCod));
                            aListParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                            aListParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                            aListParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                            aListParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                            aListParameters.Add(new SqlParameter("@userID", userId));
                            aListParameters.Add(new SqlParameter("@CreateDate", DateTime.Now));
                            aListParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                            aListParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                            aListParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                            aListParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                            aListParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                            aListParameters.Add(new SqlParameter("@PoSplitId", item.PoSplitId));
                            aListParameters.Add(new SqlParameter("@PoOwnerType", item.PoOwnType));

                            dt = SaveData("SavePlanningDetails_sp", aListParameters, true);
                        }
                        else
                        {
                            List<SqlParameter> aListParameters = new List<SqlParameter>();
                            aListParameters.Add(new SqlParameter("@PlanningSlotDetailsId", item.PlanningSlotDetailsId));
                            aListParameters.Add(new SqlParameter("@PlaneSlotMasterId", item.PlaneSlotMasterId));
                            aListParameters.Add(new SqlParameter("@POCod", item.POCod));
                            aListParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                            aListParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                            aListParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                            aListParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                            aListParameters.Add(new SqlParameter("@userID", item.CreateBy));
                            aListParameters.Add(new SqlParameter("@CreateDate", item.CreateDate));
                            aListParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                            aListParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                            aListParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                            aListParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                            aListParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                            aListParameters.Add(new SqlParameter("@PoSplitId", item.PoSplitId));
                            aListParameters.Add(new SqlParameter("@EditBy", userId));
                            aListParameters.Add(new SqlParameter("@PoOwnerType", item.PoOwnType));
                            dt = SaveData("UpdatePlanningDetails_sp", aListParameters, true);
                        }
                    }
                }
                else
                {
                    SqlConnectionOpen("Planning_NW");
                    foreach (var item in entity)
                    {
                        if (item.PlanningSlotDetailsId == 0)
                        {
                            List<SqlParameter> aListParameters = new List<SqlParameter>();
                            aListParameters.Add(new SqlParameter("@PlaneSlotMasterId", item.PlaneSlotMasterId));
                            aListParameters.Add(new SqlParameter("@POCod", item.POCod));
                            aListParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                            aListParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                            aListParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                            aListParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                            aListParameters.Add(new SqlParameter("@userID", userId));
                            aListParameters.Add(new SqlParameter("@CreateDate", DateTime.Now));
                            aListParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                            aListParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                            aListParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                            aListParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                            aListParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                            aListParameters.Add(new SqlParameter("@PoSplitId", item.PoSplitId));
                            aListParameters.Add(new SqlParameter("@PoOwnerType", item.PoOwnType));

                            dt = SaveData("SavePlanningDetails_sp", aListParameters, true);
                        }
                        else
                        {
                            List<SqlParameter> aListParameters = new List<SqlParameter>();
                            aListParameters.Add(new SqlParameter("@PlanningSlotDetailsId", item.PlanningSlotDetailsId));
                            aListParameters.Add(new SqlParameter("@PlaneSlotMasterId", item.PlaneSlotMasterId));
                            aListParameters.Add(new SqlParameter("@POCod", item.POCod));
                            aListParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                            aListParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                            aListParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                            aListParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                            aListParameters.Add(new SqlParameter("@userID", item.CreateBy));
                            aListParameters.Add(new SqlParameter("@CreateDate", item.CreateDate));
                            aListParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                            aListParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                            aListParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                            aListParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                            aListParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                            aListParameters.Add(new SqlParameter("@PoSplitId", item.PoSplitId));
                            aListParameters.Add(new SqlParameter("@EditBy", userId));
                            aListParameters.Add(new SqlParameter("@PoOwnerType", item.PoOwnType));
                            dt = SaveData("UpdatePlanningDetails_sp", aListParameters, true);
                        }
                    }
                }

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic ChangeLeadTime(int planningSlotMastId, int LeadTime, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PlanSlotMasterId", planningSlotMastId));
                aParameters.Add(new SqlParameter("@NewLeadTime", LeadTime));
                aParameters.Add(new SqlParameter("@UserId", userId));
                var dt = GetDataTable("LeadTimeChange_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SqlConnectionClose();
            }

        }
        public dynamic GetAllPOBySlotId(string slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                DataTable dt = GetDataTable("AllPoListBySlotId", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic DeletePO(int poId, int poSplitId, int user)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@POID", poId));
                aParameters.Add(new SqlParameter("@PoSplitId", poSplitId));
                aParameters.Add(new SqlParameter("@User", user));
                bool dt = SaveData("DeletePo_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic StartDateEndDateFCNS(int slotId, int newLeadTime)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@slotId", slotId));
                aParameters.Add(new SqlParameter("@newLeadTime", newLeadTime));
                DataTable dt = GetDataTable("GetStartEndDateFNewLeadTiem_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic SaveSlotAndDetails(PlanningSlotMaster entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@yearId", entity.YearId));
                aParameters.Add(new SqlParameter("@FactoryId", entity.FactoryId));
                aParameters.Add(new SqlParameter("@BrandId", entity.BrandId));
                aParameters.Add(new SqlParameter("@GaugeId", entity.GaugeId));
                aParameters.Add(new SqlParameter("@LeadTime", entity.LeadTime));
                aParameters.Add(new SqlParameter("@StartDate", entity.StartDate));
                aParameters.Add(new SqlParameter("@EndDate", entity.EndDate));
                aParameters.Add(new SqlParameter("@StageId", entity.StageId));
                aParameters.Add(new SqlParameter("@CreateBy", entity.CreateBy));
                aParameters.Add(new SqlParameter("@CreateDate", entity.CreateDate));
                aParameters.Add(new SqlParameter("@MachineQty", entity.NoOfMachine));

                int pk = SaveDataReturnPrimaryKey("SaveSlotReturnPK_sp", aParameters);
                bool data = false;
                foreach (var item in entity.PlanningSlotDetails)
                {
                    //SqlConnectionOpen("Planning_NW");
                    List<SqlParameter> bParameters = new List<SqlParameter>();
                    bParameters.Add(new SqlParameter("@PlaneSlotMasterId", pk));
                    bParameters.Add(new SqlParameter("@POCod", item.POCod));
                    bParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                    bParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                    bParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                    bParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                    bParameters.Add(new SqlParameter("@userID", entity.CreateBy));
                    bParameters.Add(new SqlParameter("@CreateDate", DateTime.Now));
                    bParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                    bParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                    bParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                    bParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                    bParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                    data = SaveData("SavePlanningDetails_sp", bParameters, true);
                }
                return data;
            }
            catch (Exception)
            {
                SqlConnectionClose(true);
                throw;
            }
            finally
            {
                SqlConnectionClose();
            }

        }

        public dynamic DeleteAllSlot(string slotId, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotList", slotId));
                aParameters.Add(new SqlParameter("@DeleteBy", userId));
                aParameters.Add(new SqlParameter("@DeleteDate", DateTime.Now));
                var dt = SaveData("DeleteAllSlot_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic SwappingPo(int destinationSltNo, int SlotDetailsId, int numberOfMainSlot)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@destinationSltNo", destinationSltNo));
                aParameters.Add(new SqlParameter("@SlotDetailsId", SlotDetailsId));
                aParameters.Add(new SqlParameter("@numberOfMainSlot", numberOfMainSlot));
                DataTable dt = GetDataTable("SwappingPo_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic AllSplitPoNO(int slotId, string styleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                aParameters.Add(new SqlParameter("@StyleName", styleNo));
                DataTable dt = GetDataTable("GetAllSplitPOForPlanning", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetStyleInfoWithSplit(int poId, int splitId = 0)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoId", poId));
                aParameters.Add(new SqlParameter("@PoId", splitId));
                DataTable dt = GetDataTable("GetStyleInfoByPoId", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic SvaeHistory(StyleHistory entity, int createBy)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StyleId", entity.StyleId));
                aParameters.Add(new SqlParameter("@PoId", entity.PoId));
                aParameters.Add(new SqlParameter("@StatusType", entity.StatusType));
                aParameters.Add(new SqlParameter("@CurrentCmnt", entity.CurrentStatus));
                aParameters.Add(new SqlParameter("@MerchantCmnt", entity.MerchantComments));
                aParameters.Add(new SqlParameter("@PlannerProposeDate", entity.PlannerProposeDate));
                aParameters.Add(new SqlParameter("@FlagId", entity.FlagId));
                aParameters.Add(new SqlParameter("@CreateBy", createBy));
                aParameters.Add(new SqlParameter("@CreateDate", DateTime.Now));

                bool dt = SaveData("SaveStyleHistory_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic Completeslot(int slotId, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SlotId", slotId));
                aParameters.Add(new SqlParameter("@UserId", userId));


                bool dt = SaveData("CompletePlanningSlotList_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic SaveLeftOverStyle(LeftOverStyleMaster entity,  int userId)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
               
                //entity.PoApprovals.ForEach(c => { c.UserId = userId; c.CreateDate = DateTime.Now; });
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@SimilarStyleId", entity.SimilarStyleId));
                aParameters.Add(new SqlParameter("@LeftOverStyleNo", entity.LeftOverStyleNo));
                aParameters.Add(new SqlParameter("@StyleDesc", entity.StyleDesc));
                aParameters.Add(new SqlParameter("@StyleType", entity.StyleType));
                aParameters.Add(new SqlParameter("@YarnDesc", entity.YarnDesc));
                aParameters.Add(new SqlParameter("@CreateBy", userId));
                aParameters.Add(new SqlParameter("@BarndId", entity.BarndId));
                aParameters.Add(new SqlParameter("@GaugeId", entity.GaugeId));
                aParameters.Add(new SqlParameter("@KnttSMV", entity.KnttSMV));
                aParameters.Add(new SqlParameter("@BuyerId", entity.BuyerId));
                aParameters.Add(new SqlParameter("@LeftOverPoList", ListToDatatable.ToDataTable(entity.LeftOverPoDetailsLst)));
                //aParameters.Add(new SqlParameter("@POList", entity.PoApprovals));

                var data = SaveData("SaveLeftOverStyle_sp", aParameters);
               
                return data;
            }
            catch (Exception)
            {
                SqlConnectionClose(true);
                throw;
            }
            finally
            {
                SqlConnectionClose();
            }

        }

        public dynamic LeftOverStyleList()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
               // List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@SlotId", slotId));
                //aParameters.Add(new SqlParameter("@UserId", userId));


                var dt = GetDataTable("LeftOverStyleList_sp", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic StylePlanSummary(string slotId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StyleNo", slotId));
                DataTable dt = GetDataTable("StylePlanStatus_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }



    }
}
