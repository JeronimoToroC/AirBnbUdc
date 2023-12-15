using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models;
using AirBnbUdC.GUI.Models.Parameters;
using AirBnbUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AirBnbUdC.GUI.Controllers.Parameters
{
    public class MultimediaTypeController : Controller
    {
        private IMultimediaTypeApplication app = new MultimediaTypeImplementationApplication();

        MultimediaTypeMapperGUI mapper = new MultimediaTypeMapperGUI();

        // GET: CountryModels
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: CountryModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaTypeModel multimediaTypeModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);
        }

        // GET: CountryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MultimediaTypeName ")] MultimediaTypeModel multimediaTypeModel)
        {
            if (ModelState.IsValid)
            {
                MultimediaTypeDTO multimediaTypeDTO = mapper.MapperT2toT1(multimediaTypeModel);
                app.CreateRecord(multimediaTypeDTO);  
                return RedirectToAction("Index");
            }

            return View(multimediaTypeModel);
        }

        // GET: CountryModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaTypeModel multimediaTypeModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);
        }

        // POST: CountryModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MultimediaTypeName ")] MultimediaTypeModel multimediaTypeModel)
        {
            if (ModelState.IsValid)
            {
                MultimediaTypeDTO multimediaTypeDTO = mapper.MapperT2toT1(multimediaTypeModel);
                app.UpdateRecord(multimediaTypeDTO);
                return RedirectToAction("Index");
            }
            return View(multimediaTypeModel);
        }

        // GET: CountryModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaTypeModel multimediaTypeModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);
        }

        // POST: CountryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }




        public ActionResult GenerateReport(string format = "PDF")
        {
            var list = app.GetAllRecords(string.Empty);
            MultimediaTypeMapperGUI multimediaTypeMapperGUI = new MultimediaTypeMapperGUI();
            List<MultimediaTypeReportModel> recordsList = new List<MultimediaTypeReportModel>();

            foreach (var multimediaType in list)
            {
                recordsList.Add(
                    new MultimediaTypeReportModel()
                    {
                        Id = multimediaType.Id.ToString(),
                        MultimediaTypeName = multimediaType.MultimediaTypeName,
                       
                    });
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/MultimediaTypeReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("MultimediaTypeDataSet", recordsList);
            lr.DataSources.Add(datasource);


            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }

    }
}
