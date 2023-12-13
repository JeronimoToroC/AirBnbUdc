using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirBnbUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;

namespace AirBnbUdC.GUI.Controllers.Parameters
{
    public class PropertyOwnerController: Controller
    {
        private IPropertyOwnerApplication app = new PropertyOwnerImplementationApplication();

        PropertyOwnerMapperGUI mapper = new PropertyOwnerMapperGUI();

        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,CellPhone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.CreateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }

            return View(propertyOwnerModel);
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: CountryModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FirstName,FamilyName,Email,CellPhone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.UpdateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }
            return View(propertyOwnerModel);
        }

        // GET: CountryModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
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
            PropertyOwnerMapperGUI propertyOwnerMapperGUI = new PropertyOwnerMapperGUI();
            List<PropertyOwnerReportModel> recordsList = new List<PropertyOwnerReportModel>();

            foreach (var property in list)
            {
                recordsList.Add(
                    new PropertyOwnerReportModel()
                    {
                        Id = property.Id.ToString(),
                        FirstName = property.FirstName,
                       FamilyName = property.FamilyName,
                       Email = property.Email,
                       CellPhone = property.CellPhone,
                    });
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/PropertyOwnerReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("PropertyOwnerDataSet", recordsList);
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
