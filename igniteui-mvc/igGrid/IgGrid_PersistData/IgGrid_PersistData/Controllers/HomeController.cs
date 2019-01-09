using IgGrid_PersistData.Models;
using IgGrid_PersistData.Repositories;
using Infragistics.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IgGrid_PersistData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getData()
        {
            var items = DummyRepository.getItems();

            //igGrid にバインドするデータをリターン
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateData()
        {
            var gridModel = new GridModel();

            //igGrid トランザクション
            var transactions =
                gridModel.LoadTransactions<Item>(HttpContext.Request.Form["ig_transactions"]);

            //トランザクションの情報を元にサーバー側のデータを更新
            foreach (var t in transactions)
            {
                DummyRepository.updateItem(rowId: int.Parse(t.rowId), colName: t.col, value: t.value);
            }

            JsonResult result = new JsonResult();
            Dictionary<string, bool> response = new Dictionary<string, bool>();

            response.Add("Success", true);
            result.Data = response;

            //実行結果をリターン
            return result;
        }
    }
}