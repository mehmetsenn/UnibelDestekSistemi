using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnibelDestekSistemi.Models.DataTableModels;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;

namespace UnibelDestekSistemi.Controllers.Staff
{

    public class AdvancedSearchController : BaseController
    {
        unibeldestekContext _db = new unibeldestekContext();
        AdvancedSearchViewModel viewModel = new AdvancedSearchViewModel();


        Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
        public List<DataTableAdvancedSearchBilet> customDataTableResult = new List<DataTableAdvancedSearchBilet>();

        public List<Bilet> searchResults = new List<Bilet>();
        public List<Bilet> tempResult = new List<Bilet>();
        public List<ActualValue> tempSearchValues = new List<ActualValue>();
        public List<DataTableAdvancedSearchBilet> dataTableResult = new List<DataTableAdvancedSearchBilet>();
        string queryString = "SELECT * FROM dbo.Bilet WHERE ";

        public IActionResult Index()
        {
            ViewBag.pageHeader = "ADVANCED SEARCH";
            ViewBag.status = _db.Durum.ToList();
            ViewBag.department = _db.Departman.ToList();
            ViewBag.type = _db.Tip.ToList();
            ViewBag.priority = _db.Oncelik.ToList();
            ViewBag.company = _db.Sirketler.ToList();
            ViewBag.owner = _db.Kullanici.Where(x => x.FkRolId.Equals(1) || x.FkRolId.Equals(4)).ToList();

            


            return View();
        }

        [HttpPost]
        [Route("/getCustomSearchResult")]
        public IActionResult GetCustomSearchConditionsAjaxRequest([FromBody] CustomSearchConditionRules customConditions)
        {
            queryString = "SELECT * FROM dbo.Bilet WHERE ";
            queryDictionary.Clear();
            



            prepareCustomSearchQuery(customConditions);
            


            var biletler = _db.Bilet.FromSql(queryString).ToList();

            if (dataTableResult.Count() > 0)
            {
                dataTableResult.Clear();
            }

            foreach (var bilet in biletler)
            {
                var dataTableFormattedBilet = new DataTableAdvancedSearchBilet();
                dataTableFormattedBilet.Id = bilet.BiletId;
                dataTableFormattedBilet.Date = bilet.BiletGonderimTarihi;
                dataTableFormattedBilet.Subject = bilet.BiletBasligi;
                dataTableFormattedBilet.Company = _db.Departman.SingleOrDefault(x => x.DepartmanId.Equals(bilet.FkBiletDepartmanId)).DepartmanAdi;
                dataTableFormattedBilet.Priority = _db.Oncelik.SingleOrDefault(x => x.OncelikId.Equals(bilet.FkOncelikId)).OncelikAdi;
                dataTableFormattedBilet.Owner = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(bilet.FkCalisanKullaniciId)).KullaniciAdi;
                dataTableFormattedBilet.Due = bilet.BiletGonderimTarihi.ToShortDateString() + " " + bilet.BiletGonderimTarihi.ToLongTimeString();
                customDataTableResult.Add(dataTableFormattedBilet);
            }


            return Json(customDataTableResult);

        }




        public void prepareCustomSearchQuery(CustomSearchConditionRules customConditions) {

            queryDictionary.Add("company", "(");
            queryDictionary.Add("status", "(");
            queryDictionary.Add("type", "(");
            queryDictionary.Add("priority", "(");
            queryDictionary.Add("department", "(");
            queryDictionary.Add("owner", "(");





            foreach (var item in customConditions.conditionValues)
            {

                switch (item.conditionName)
                {
                    case "company":
                        if (queryDictionary.ContainsKey(item.conditionName))
                        {
                            if (queryDictionary[item.conditionName] == "(")
                            {
                                queryDictionary[item.conditionName] += " Fk_BiletGonderenId = " + item.searchIdValue + "";
                            }
                            queryDictionary[item.conditionName] += " OR Fk_BiletGonderenId = " + item.searchIdValue + "";
                        }


                        break;
                    case "status":
                        if (queryDictionary.ContainsKey(item.conditionName))
                        {
                            if (queryDictionary[item.conditionName] == "(")
                            {
                                queryDictionary[item.conditionName] += " Fk_BiletDurumID = " + item.searchIdValue + "";
                            }
                            queryDictionary[item.conditionName] += " OR Fk_BiletDurumID = " + item.searchIdValue + "";
                        }


                        break;
                    case "type":
                        if (queryDictionary.ContainsKey(item.conditionName))
                        {
                            if (queryDictionary[item.conditionName] == "(")
                            {
                                queryDictionary[item.conditionName] += " Fk_BiletTurID = " + item.searchIdValue + "";
                            }
                            queryDictionary[item.conditionName] += " OR Fk_BiletTurID = " + item.searchIdValue + "";
                        }
                        break;
                    case "priority":
                        if (queryDictionary.ContainsKey(item.conditionName))
                        {
                            if (queryDictionary[item.conditionName] == "(")
                            {
                                queryDictionary[item.conditionName] += " Fk_OncelikID = " + item.searchIdValue + "";
                            }
                            queryDictionary[item.conditionName] += " OR Fk_OncelikID = " + item.searchIdValue + "";
                        }


                        break;
                    default:
                        break;
                }







            }
            queryDictionary["company"] += ")";
            if (queryDictionary["company"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("company");
                if (queryDictionary["status"] != "(")
                {
                    queryString += " AND ";
                }
                
            }

            queryDictionary["status"] += ")";
            if (queryDictionary["status"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("status");
                if (queryDictionary["type"] != "(")
                {
                    queryString += " AND ";
                }
            }
            queryDictionary["type"] += ")";
            if (queryDictionary["type"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("type");
                if (queryDictionary["priority"] != "(")
                {
                    queryString += " AND ";
                }
            }
            queryDictionary["priority"] += ")";
            if (queryDictionary["priority"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("priority");
                if (queryDictionary["department"] != "(")
                {
                    queryString += " AND ";
                }
            }
            queryDictionary["department"] += ")";
            if (queryDictionary["department"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("priority");
                if (queryDictionary["owner"] != "(")
                {
                    queryString += " AND ";
                }
            }
            queryDictionary["owner"] += ")";
            if (queryDictionary["owner"] != "()")
            {
                queryString += queryDictionary.GetValueOrDefault("priority");
                //if (queryDictionary["priority"] != "(")
                //{
                //    queryString += " AND ";
                //}
            }
        }



        [HttpPost]
        [Route("/getsearchresult")]
        public IActionResult GetSearchConditionsAjaxRequest([FromBody] SearchConditionRules[] conditions)
        {

            


            foreach (var item in conditions)
            {
                Debug.WriteLine(item.condition + " " + item.actualValue);
            }
            //_db.Bilet.Where( x => x.FkBiletDurumId.Equals(condition[i].value)).toList()
            //

            //Condition listemizi her istek yapıldığında siliyoruz ki farklı arama koşullarında liste 
            //eski elemanlardan kurtulsun
            if (searchResults.Count() > 0)
            {
                searchResults.Clear();
            }

            if (dataTableResult.Count() > 0)
            {
                dataTableResult.Clear();
            }

            foreach (var item in conditions)
            {
                switch (item.condition)
                {
                    case "status":
                        foreach (var searchValue in item.actualValue)
                        {

                            tempResult = _db.Bilet.Where(x => x.FkBiletDurumId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;

                    case "company":

                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.FkBiletGonderenId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }


                        break;

                    case "priority":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.FkOncelikId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "type":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.FkBiletTurId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "department":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.FkBiletDepartmanId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "id":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.BiletId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "subject":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.BiletBasligi.Contains(searchValue.searchValue)).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "owner":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.FkCalisanKullaniciId.Equals(int.Parse(searchValue.searchValue))).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    case "date":
                        foreach (var searchValue in item.actualValue)
                        {
                            tempResult = _db.Bilet.Where(x => x.BiletGonderimTarihi < searchValue.startDate).ToList<Bilet>();
                            addToTempSearchResult(tempResult);
                        }
                        break;
                    default:
                        break;
                }





            }


            foreach (var bilet in searchResults)
            {
                var dataTableFormattedBilet = new DataTableAdvancedSearchBilet();
                dataTableFormattedBilet.Id = bilet.BiletId;
                dataTableFormattedBilet.Date = bilet.BiletGonderimTarihi;
                dataTableFormattedBilet.Subject = bilet.BiletBasligi;
                dataTableFormattedBilet.Company = _db.Departman.SingleOrDefault(x => x.DepartmanId.Equals(bilet.FkBiletDepartmanId)).DepartmanAdi;
                dataTableFormattedBilet.Priority = _db.Oncelik.SingleOrDefault(x => x.OncelikId.Equals(bilet.FkOncelikId)).OncelikAdi;
                dataTableFormattedBilet.Owner = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(bilet.FkCalisanKullaniciId)).KullaniciAdi;
                dataTableFormattedBilet.Due = bilet.BiletGonderimTarihi.ToShortDateString() + " " + bilet.BiletGonderimTarihi.ToLongTimeString();
                dataTableResult.Add(dataTableFormattedBilet);
            }

            return Json(dataTableResult);
        }

        public void addToTempSearchResult(List<Bilet> tempResult)
        {

            foreach (var item2 in tempResult)
            {
                searchResults.Add(item2);
            }

        }
    }
}