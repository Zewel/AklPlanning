
using SweaterPlanning.DllClass;
using SweaterPlanning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class HomeDAL : DataAccessLayer
    {
        private IEnumerable<Menu> MenuList(int userId, int moduleId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@LoginUserId", userId));
                aParameters.Add(new SqlParameter("@ModuleId", moduleId));
                DataTable dt = GetDataTable("UserWiseMenu_sp", aParameters,true);
                IEnumerable<Menu> menu = DataTableToList.ToListof<Menu>(dt);
                return menu;
            }
            catch (Exception  )
            {
                throw;
               //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public List<MenuParent> Parent(int userId, int moduleId)
        {
            try
            {
                List<MenuParent> menuParents = new List<MenuParent>();


                IEnumerable<Menu> menus = MenuList(userId, moduleId);

                IEnumerable<Menu> tempStepOneList = menus.Where(x => x.MenuStepId == 1 && x.ParantId == 0);
                MenuParent aMenuStepOne;
                foreach (var aItem in tempStepOneList)
                {
                    aMenuStepOne = new MenuParent();
                    aMenuStepOne.MenuId = aItem.MenuId;
                    aMenuStepOne.MenuName = aItem.MenuName;
                    aMenuStepOne.ControllerName = aItem.ControllerName;
                    aMenuStepOne.ActionName = aItem.ActionName;
                    aMenuStepOne.MenuChildList = GetMenuStepTwo(aItem.MenuId, menus);
                    menuParents.Add(aMenuStepOne);
                }
                return menuParents;

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
        private List<MenuChild> GetMenuStepTwo(int ParantId, IEnumerable<Menu> menuOperationsList)
        {
            try
            {
                List<MenuChild> aStepTwoList = new List<MenuChild>();

                IEnumerable<Menu> tempStepOneList = menuOperationsList.Where(x => x.MenuStepId == 2 && x.ParantId == ParantId);
                MenuChild aMenuStepTwo;
                foreach (var aItem in tempStepOneList)
                {
                    aMenuStepTwo = new MenuChild();
                    aMenuStepTwo.MenuId = aItem.MenuId;
                    aMenuStepTwo.MenuName = aItem.MenuName;
                    aMenuStepTwo.ControllerName = aItem.ControllerName;
                    aMenuStepTwo.ActionName = aItem.ActionName;
                    aMenuStepTwo.MenuSubChildList = GetMenuStepThree(aItem.MenuId, menuOperationsList);
                    aStepTwoList.Add(aMenuStepTwo);
                }


                return aStepTwoList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<MenuSubChild> GetMenuStepThree(int ParantId, IEnumerable<Menu> menuOperationsList)
        {
            try
            {
                List<MenuSubChild> aStepThreeList = new List<MenuSubChild>();

                IEnumerable<Menu> tempStepOneList = menuOperationsList.Where(x => x.MenuStepId == 3 && x.ParantId == ParantId);
                MenuSubChild aMenuStepThree;
                foreach (var aItem in tempStepOneList)
                {
                    aMenuStepThree = new MenuSubChild();
                    aMenuStepThree.MenuId = aItem.MenuId;
                    aMenuStepThree.MenuName = aItem.MenuName;
                    aMenuStepThree.ControllerName = aItem.ControllerName;
                    aMenuStepThree.ActionName = aItem.ActionName;
                    aStepThreeList.Add(aMenuStepThree);
                }
                return aStepThreeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
