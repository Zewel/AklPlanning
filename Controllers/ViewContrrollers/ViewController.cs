using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweaterPlanning.Models;
using System.Drawing;
using IronBarCode;
using System.IO;
using System.Reflection;
using System.Net.NetworkInformation;
using SweaterPlanning.SecureDataClass;

namespace SweaterPlanning.Controllers.ViewContrrollers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DailyTask()
        {
            return View();
        }

        public IActionResult DailyActivityByTimeSlot(DateTime? date, string flag = "Add")
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                ViewBag.ActivityDate = date;
                ViewBag.Flag = flag;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

        }

        public IActionResult DailyActivityByTimeSlotList()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult CapacityProjection()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult MenuCreation()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult WorkCalanderYearly()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult StyleApproval()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult FileUploadDownload()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult StyleApprovalDetails(int styleNo)
        {
            StyleApprovalController aController = new StyleApprovalController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                var result = aController.StyleInfo(styleNo);
                return View(aController.StyleInfo(styleNo));
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult InitialPlanningList()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult InitialPlanningListModify()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult CreateSlot()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult CreateSlot1()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult StyleSearchResult()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult QrCodeExample()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();

                // Shorthand:: Create and save a barcode in a single line of code
                //BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8).ResizeTo(400, 100).SaveAsImage("EAN8.jpeg");


                /*****  IN-DEPTH BARCODE CREATION OPTIONS *****/

                // BarcodeWriter.CreateBarcode creates a GeneratedBarcode which can be styles and exported as an Image object or File
                GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("29909", BarcodeWriterEncoding.Code128).AddBarcodeValueTextBelowBarcode();

                // Style the Barcode in a fluent LINQ style fashion
                MyBarCode.ResizeTo(100, 40).SetMargins(20).AddAnnotationTextAboveBarcode("AKL Store");
                MyBarCode.ChangeBackgroundColor(Color.White);

                // Save MyBarCode as an image file
                //MyBarCode.SaveAsImage("MyBarCode.png");
                //MyBarCode.SaveAsGif("MyBarCode.gif");
                //MyBarCode.SaveAsHtmlFile("MyBarCode.html");
                //MyBarCode.SaveAsJpeg("MyBarCode.jpg");
                //MyBarCode.SaveAsPdf("MyBarCode.Pdf");
                MyBarCode.SaveAsPng("MyBarCode.png");
                //MyBarCode.SaveAsTiff("MyBarCode.tiff");
                //MyBarCode.SaveAsWindowsBitmap("MyBarCode.bmp");

                // Save MyBarCode as a .Net native objects
                Image MyBarCodeImage = MyBarCode.Image;
                BarCode barCode = new BarCode();
                barCode.BarCodeNo = 1;
                barCode.BarCodeImg = ImageToByteArray(MyBarCodeImage);
                return View(barCode);
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            //using (var ms = new MemoryStream())
            //{
            //    imageIn.Save(ms, imageIn.RawFormat);
            //    return ms.ToArray();
            //}
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


        public IActionResult PoSplit()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult CapacityVsOrder()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                //var result = aController.InitialPlanningList();
                //  var projectName = Assembly.GetCallingAssembly().GetName().Name;
                ////var mecaddress = GetMACAddress();
                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult UserControl()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult PlanningMonthChangeFPO()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult DragAndDrop()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult AddEditPo()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult Search()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }


        public IActionResult GanntChart()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult SearchAllTAndA(int styleNo = 0)
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult SearchGRN(int styleNo = 0)
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult BOM()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult ShipmentList()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult StylePlanGanntChart()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult CurrentCapacityStatus()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult MarchantCapacity()
        {

            //InitialPlanningController aController = new InitialPlanningController();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }


        public IActionResult KnittCatagorySegregate()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                CommonDAL commonDAL = new CommonDAL();
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                var ds = commonDAL.ItemCatagoryList();
                return View(ds);
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }


        public IActionResult PlanHistory()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                CommonDAL commonDAL = new CommonDAL();
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                var ds = commonDAL.ItemCatagoryList();
                return View(ds);
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }


        public IActionResult LeftOverStyleEntry()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }

        public IActionResult StyleBookingHistory()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        public IActionResult PlanGanntChart()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
    }
}
