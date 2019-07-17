using ClosedXML.Excel;
using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Layer.Functions
{
    public static class FuncionesExcel
    {
        #region -----Carga De Archivos Excel-----
        public static List<InfoFieldBook> GetData(string pathToExcelFile)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);

            //Query a worksheet with a header row  
            var rows = (from a in ConxObject.UrlConnexion.Worksheet<InfoFieldBook>(0)
                        select a).ToList();

            return rows;
        }

        public static List<EntryList> GetEntryListFile(string pathToExcelFile)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);

            //Query a worksheet with a header row  
            var rows = (from a in ConxObject.UrlConnexion.Worksheet<EntryList>(0)
                        select a).ToList();

            return rows;
        }

        public static List<InfoFieldBook> GetInfoFieldBookFile(string pathToExcelFile)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);

            //Query a worksheet with a header row  
            var rows = (from a in ConxObject.UrlConnexion.Worksheet<InfoFieldBook>(0)
                        select a).ToList();

            return rows;
        }

        public static List<SplitEuidDto> GetSplitFile(string pathToExcelFile)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);

            //Query a worksheet with a header row  
            var rows = (from a in ConxObject.UrlConnexion.Worksheet<SplitEuidDto>(0)
                        select a).ToList();

            return rows;
        } 
        #endregion

        #region -----Exportar Data-----
        //Template Entry-List
        public static XLWorkbook ExportaTemplateEntryList(CentroCostoExperimentoDto item, string euidInicio)
        {
            int index = 2;
            XLWorkbook book = new XLWorkbook(@"C:\Templates\Entry_List.xlsx");
            var hoja = book.Worksheet("Entry-List");

            var inicio = long.Parse(euidInicio) + 2535;
            var fin = item.NumeroEuid + inicio;

            for (long i = inicio; i < fin; i++)
            {
                hoja.Cell("A" + index).Value = i.ToString();
                hoja.Cell("B" + index).Value = item.Year;
                hoja.Cell("C" + index).Value = item.Country;
                hoja.Cell("D" + index).Value = item.Location;
                hoja.Cell("E" + index).Value = "";
                hoja.Cell("F" + index).Value = "";
                hoja.Cell("G" + index).Value = "";
                hoja.Cell("H" + index).Value = item.ExpName;
                hoja.Cell("I" + index).Value = item.ProjectLead;
                hoja.Cell("J" + index).Value = item.centro_costo;
                hoja.Cell("K" + index).Value = item.Crop;
                hoja.Cell("L" + index).Value = "";
                hoja.Cell("M" + index).Value = item.ProjectCode;
                hoja.Cell("N" + index).Value = item.Event;
                hoja.Cell("O" + index).Value = item.Sag;
                hoja.Cell("P" + index).Value = item.CodInternacion;
                hoja.Cell("Q" + index).Value = item.CodReception;
                hoja.Cell("R" + index).Value = item.Cliente;
                hoja.Cell("S" + index).Value = "";
                hoja.Cell("T" + index).Value = "";
                hoja.Cell("U" + index).Value = item.ResImportacion;
                hoja.Cell("V" + index).Value = item.GranosHilera;
                hoja.Cell("W" + index).Value = item.BreedersInstructions1;
                hoja.Cell("X" + index).Value = item.BreedersInstructions2;
                hoja.Cell("Y" + index).Value = item.BreedersInstructions3;
                hoja.Cell("Z" + index).Value = item.BreedersInstructions4;
                hoja.Cell("AA" + index).Value = item.NombreOwner;
                hoja.Cell("AB" + index).Value = "";
                hoja.Cell("AC" + index).Value = "";

                index++;
            }

            return book;
        }
        //Detalle Entry-List
        public static XLWorkbook ExportaDetalleEntryList(List<EntryList> items)
        {
            int index = 2;
            XLWorkbook book = new XLWorkbook(@"C:\Templates\Detalle_Entry_List.xlsx");
            var hoja = book.Worksheet("Carga-Entry-List");

            foreach (var item in items)
            {
                hoja.Cell("A" + index).Value = item.Euid;
                hoja.Cell("B" + index).Value = item.Year;
                hoja.Cell("C" + index).Value = item.Country;
                hoja.Cell("D" + index).Value = item.Location;
                hoja.Cell("E" + index).Value = item.Rng;
                hoja.Cell("F" + index).Value = item.Plt;
                hoja.Cell("G" + index).Value = item.Ent;
                hoja.Cell("H" + index).Value = item.ExpName;
                hoja.Cell("I" + index).Value = item.ProjectLead;
                hoja.Cell("J" + index).Value = item.Cc;
                hoja.Cell("K" + index).Value = item.Crop;
                hoja.Cell("L" + index).Value = item.Obs;
                hoja.Cell("M" + index).Value = item.ProjectCode;
                hoja.Cell("N" + index).Value = item.GmoEvent;
                hoja.Cell("O" + index).Value = item.Sag;
                hoja.Cell("P" + index).Value = item.CodInternacion;
                hoja.Cell("Q" + index).Value = item.CodReception;
                hoja.Cell("R" + index).Value = item.Client;
                hoja.Cell("S" + index).Value = item.EntName;
                hoja.Cell("T" + index).Value = item.EntRole;
                hoja.Cell("U" + index).Value = item.ResImportacion;
                hoja.Cell("V" + index).Value = item.GranosHilera;
                hoja.Cell("W" + index).Value = item.Bi1;
                hoja.Cell("X" + index).Value = item.Bi2;
                hoja.Cell("Y" + index).Value = item.Bi3;
                hoja.Cell("Z" + index).Value = item.Bi4;
                hoja.Cell("AA" + index).Value = item.Owner;
                hoja.Cell("AB" + index).Value = item.CodPermanencia;
                hoja.Cell("AC" + index).Value = item.LotId;

                index++;
            }

            return book;
        }
        //Template Entry-List
        public static XLWorkbook ExportaTemplateInfoFieldBook(List<EntryListDto> data)
        {
            int index = 2;
            XLWorkbook book = new XLWorkbook(@"C:\Templates\InfoFieldBook.xlsx");
            var hoja = book.Worksheet("Data");

            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value = item.Euid;
                hoja.Cell("B" + index).Value = item.IndEuid;
                hoja.Cell("C" + index).Value = item.Year;
                hoja.Cell("D" + index).Value = item.Country;
                hoja.Cell("E" + index).Value = item.Location;
                hoja.Cell("F" + index).Value = "";
                hoja.Cell("G" + index).Value = "";
                hoja.Cell("H" + index).Value = "";
                hoja.Cell("I" + index).Value = "";
                hoja.Cell("J" + index).Value = "";
               
                hoja.Cell("K" + index).Value = item.Rng;
                hoja.Cell("L" + index).Value = item.Plt;
                hoja.Cell("M" + index).Value = item.Ent;
                hoja.Cell("N" + index).Value = item.ExpName;
                hoja.Cell("O" + index).Value = item.ProjectLead;
                hoja.Cell("P" + index).Value = item.Cc;


                hoja.Cell("Q" + index).Value = "";
                hoja.Cell("R" + index).Value = "";
                hoja.Cell("S" + index).Value = "";
                hoja.Cell("T" + index).Value = "";
                hoja.Cell("U" + index).Value = "";
                hoja.Cell("V" + index).Value = "";

                hoja.Cell("W" + index).Value = item.Crop;
                hoja.Cell("X" + index).Value = item.Obs;
                hoja.Cell("Y" + index).Value = item.ProjectCode;
                hoja.Cell("Z" + index).Value = item.GmoEvent;
                hoja.Cell("AA" + index).Value = item.Sag;
                hoja.Cell("AB" + index).Value = item.CodInternacion;
                hoja.Cell("AC" + index).Value = item.CodReception;
                hoja.Cell("AD" + index).Value = item.Client;
                hoja.Cell("AE" + index).Value = item.EntName;
                hoja.Cell("AF" + index).Value = item.EntRole;
                hoja.Cell("AG" + index).Value = item.ResImportacion;
                hoja.Cell("AH" + index).Value = item.GranosHilera;
                hoja.Cell("AI" + index).Value = item.Bi1;
                hoja.Cell("AJ" + index).Value = item.Bi2;
                hoja.Cell("AK" + index).Value = item.Bi3;
                hoja.Cell("AL" + index).Value = item.Bi4;
                hoja.Cell("AM" + index).Value = item.Owner;
                hoja.Cell("AN" + index).Value = item.CodPermanencia;
                hoja.Cell("AO" + index).Value = item.LotId;

                index++;
            }

            return book;
        }
        public static XLWorkbook ExportToExcel<T>(IEnumerable<T> data, string worksheetTitle, List<string[]> titles)
        {
            var wb = new XLWorkbook(); //create workbook
            var ws = wb.Worksheets.Add(worksheetTitle); //add worksheet to workbook

            ws.Cell(1, 1).InsertData(titles); //insert titles to first row

            if (data != null && data.Count() > 0)
            {
                //insert data to from second row on
                ws.Cell(2, 1).InsertData(data);
            }

            //save file to memory stream and return it as byte array
            //var ms = new MemoryStream();
            //wb.SaveAs(ms);

            return wb;
        }
        public static XLWorkbook ExportaPackingList(List<EncPackingListDto> data, List<DetailPackingListDto> dataDetail, string shipmentCode)
        {
            if (!Directory.Exists(@"C:\Templates"))
            {
                if (!File.Exists(@"C:\Templates\PackingList.xlsx"))
                {
                    return null;
                }
            }

            XLWorkbook book = new XLWorkbook(@"C:\Templates\PackingList.xlsx");
            var hoja = book.Worksheet("Header Packing List");
            int index = 6;

            hoja.Cell("B3").Value = shipmentCode;

            //Encabezado
            hoja.Cell("B3").Value = shipmentCode;

            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value = item.fechaEnvio;
                hoja.Cell("B" + index).Value = item.shipTo;
                hoja.Cell("C" + index).Value = item.palletEnvio;
                hoja.Cell("D" + index).Value = item.pesoPallet;
                hoja.Cell("E" + index).Value = item.MaterialPallet;
                hoja.Cell("F" + index).Value = item.MedidaPallet;
                hoja.Cell("G" + index).Value = item.bultoEnvio;
                hoja.Cell("H" + index).Value = item.pesoBulto;
                hoja.Cell("I" + index).Value = item.MaterialBulto;
                hoja.Cell("J" + index).Value = item.MedidaBulto;
                hoja.Cell("K" + index).Value = item.NumeroCaja;
                hoja.Cell("L" + index).Value = item.cajaEnvio;
                hoja.Cell("M" + index).Value = item.pesoNeto;
                hoja.Cell("N" + index).Value = item.pesoBruto;
                hoja.Cell("O" + index).Value = item.Contenido;
                hoja.Cell("P" + index).Value = item.Gmo;
                hoja.Cell("Q" + index).Value = item.country;
                hoja.Cell("R" + index).Value = item.state;
                hoja.Cell("S" + index).Value = item.city;
                hoja.Cell("T" + index).Value = item.address;
                hoja.Cell("U" + index).Value = item.zipCode;
                hoja.Cell("V" + index).Value = item.contact;
                hoja.Cell("W" + index).Value = item.email;
                hoja.Cell("X" + index).Value = item.phone;
                hoja.Cell("Y" + index).Value = item.client;
                index++;
            }


            var hoja2 = book.Worksheet("Detail Packing List");
            hoja2.Cell("B3").Value = shipmentCode;
            index = 6;

            //Detalle
            foreach (var item in dataDetail)
            {
                hoja2.Cell("A" + index).Value = item.cajaEnvio;
                hoja2.Cell("B" + index).Value = item.shipTo;
                hoja2.Cell("C" + index).Value = item.euid;
                hoja2.Cell("D" + index).Value = item.indEuid;
                hoja2.Cell("E" + index).Value = item.fechaPacking;
                hoja2.Cell("F" + index).Value = item.totalWeight;
                hoja2.Cell("G" + index).Value = item.totalKernels;
                hoja2.Cell("H" + index).Value = item.totalEar;
                hoja2.Cell("I" + index).Value = item.country;
                hoja2.Cell("J" + index).Value = item.location;
                hoja2.Cell("K" + index).Value = item.expName;
                hoja2.Cell("L" + index).Value = item.bc1;
                hoja2.Cell("M" + index).Value = item.bc2;
                hoja2.Cell("N" + index).Value = item.bc3;
                hoja2.Cell("O" + index).Value = item.bc4;
                hoja2.Cell("P" + index).Value = item.projectLead;
                hoja2.Cell("Q" + index).Value = item.cc;
                hoja2.Cell("R" + index).Value = item.crop;
                hoja2.Cell("S" + index).Value = item.obs;
                hoja2.Cell("T" + index).Value = item.client;
                hoja2.Cell("U" + index).Value = item.gmoEvent;
                hoja2.Cell("V" + index).Value = item.sag;
                hoja2.Cell("W" + index).Value = item.codInternation;
                hoja2.Cell("X" + index).Value = item.codReception;
                index++;
            }

            return book;
        }
        public static XLWorkbook ExportaTracking(TrackingDto data, string filtro, string valor)
        {
            if (!Directory.Exists(@"C:\Templates"))
            {
                if (!File.Exists(@"C:\Templates\TrackingList.xlsx"))
                {
                    return null;
                }
            }

            XLWorkbook book = new XLWorkbook(@"C:\Templates\TrackingList.xlsx");
            var hojaE = book.Worksheet("Entry List");
            int index = 7;

            hojaE.Cell("B3").Value = filtro;
            hojaE.Cell("B4").Value = DateTime.Now.Date;
            hojaE.Cell("C3").Value = valor;

            foreach (var item in data.EntryList)
            {
                hojaE.Cell("A" + index).Value = item.Euid;
                hojaE.Cell("B" + index).Value = item.Year;
                hojaE.Cell("C" + index).Value = item.Country;
                hojaE.Cell("D" + index).Value = item.Location;
                hojaE.Cell("E" + index).Value = item.Rng;
                hojaE.Cell("F" + index).Value = item.Plt;
                hojaE.Cell("G" + index).Value = item.Ent;
                hojaE.Cell("H" + index).Value = item.ExpName;
                hojaE.Cell("I" + index).Value = item.ProjectLead;
                hojaE.Cell("J" + index).Value = item.Cc;
                hojaE.Cell("K" + index).Value = item.Crop;
                hojaE.Cell("L" + index).Value = item.Obs;
                hojaE.Cell("M" + index).Value = item.ProjectCode;
                hojaE.Cell("N" + index).Value = item.GmoEvent;
                hojaE.Cell("O" + index).Value = item.Sag;
                hojaE.Cell("P" + index).Value = item.CodInternacion;
                hojaE.Cell("Q" + index).Value = item.Client;
                hojaE.Cell("R" + index).Value = item.EntName;
                hojaE.Cell("S" + index).Value = item.EntRole;
                hojaE.Cell("T" + index).Value = item.ResImportacion;
                hojaE.Cell("U" + index).Value = item.GranosHilera;
                hojaE.Cell("V" + index).Value = item.Bi1;
                hojaE.Cell("W" + index).Value = item.Bi2;
                hojaE.Cell("X" + index).Value = item.Bi3;
                hojaE.Cell("Y" + index).Value = item.Bi4;
                hojaE.Cell("Z" + index).Value = item.Owner;
                hojaE.Cell("AA" + index).Value = item.CodPermanencia;
                hojaE.Cell("AB" + index).Value = item.LotId;
                index++;
            }

            var hoja = book.Worksheet("Tracking");
            index = 7;

            hoja.Cell("B3").Value = filtro;
            hoja.Cell("B4").Value = DateTime.Now.Date;
            hoja.Cell("C3").Value = valor;

            foreach (var item in data.Info)
            {
                hoja.Cell("A" + index).Value = item.euid;
                hoja.Cell("B" + index).Value = item.indEuid;
                hoja.Cell("C" + index).Value = item.year;
                hoja.Cell("D" + index).Value = item.country;
                hoja.Cell("E" + index).Value = item.location;
                hoja.Cell("F" + index).Value = item.order;
                hoja.Cell("G" + index).Value = item.breedersCode1;
                hoja.Cell("H" + index).Value = item.breedersCode2;
                hoja.Cell("I" + index).Value = item.breedersCode3;
                hoja.Cell("J" + index).Value = item.breedersCode4;
                hoja.Cell("K" + index).Value = item.rng;
                hoja.Cell("L" + index).Value = item.ent;
                hoja.Cell("M" + index).Value = item.opExpName;
                hoja.Cell("N" + index).Value = item.projecLead;
                hoja.Cell("O" + index).Value = item.cc;
                hoja.Cell("P" + index).Value = item.shipTo;
                hoja.Cell("Q" + index).Value = item.crop;
                hoja.Cell("R" + index).Value = item.obs;
                hoja.Cell("S" + index).Value = item.projectCode;
                hoja.Cell("T" + index).Value = item.gmoEvent;
                hoja.Cell("U" + index).Value = item.sag;
                hoja.Cell("V" + index).Value = item.codInternacion;
                hoja.Cell("W" + index).Value = item.codReception;
                hoja.Cell("X" + index).Value = item.client;
                index++;
            }

            //Rogging
            var hojaR = book.Worksheet("Rogging");
            hojaR.Cell("B3").Value = filtro;
            hojaR.Cell("B4").Value = DateTime.Now.Date;
            hojaR.Cell("C3").Value = valor;
            index = 7;
            if (data.Rogging != null)
            {
                foreach (var item in data.Rogging)
                {
                    hojaR.Cell("A" + index).Value = item.Euid;
                    hojaR.Cell("B" + index).Value = item.FechaRogging;
                    hojaR.Cell("C" + index).Value = item.Reason;
                    hojaR.Cell("D" + index).Value = item.Year;
                    hojaR.Cell("E" + index).Value = item.Country;
                    hojaR.Cell("F" + index).Value = item.Location;
                    hojaR.Cell("G" + index).Value = item.Rng;
                    hojaR.Cell("H" + index).Value = item.Plt;
                    hojaR.Cell("I" + index).Value = item.Ent;
                    hojaR.Cell("J" + index).Value = item.ExpName;
                    hojaR.Cell("K" + index).Value = item.ProjectLead;
                    hojaR.Cell("L" + index).Value = item.Cc;
                    hojaR.Cell("M" + index).Value = item.Crop;
                    hojaR.Cell("N" + index).Value = item.Obs;
                    hojaR.Cell("O" + index).Value = item.ProjectCode;
                    hojaR.Cell("P" + index).Value = item.GmoEvent;
                    hojaR.Cell("Q" + index).Value = item.Sag;
                    hojaR.Cell("R" + index).Value = item.CodInternacion;
                    hojaR.Cell("S" + index).Value = item.Client;
                    hojaR.Cell("T" + index).Value = item.EntName;
                    hojaR.Cell("U" + index).Value = item.EntRole;
                    hojaR.Cell("V" + index).Value = item.ResImportacion;
                    hojaR.Cell("W" + index).Value = item.GranosHilera;
                    hojaR.Cell("X" + index).Value = item.Bi1;
                    hojaR.Cell("Y" + index).Value = item.Bi2;
                    hojaR.Cell("Z" + index).Value = item.Bi3;
                    hojaR.Cell("AA" + index).Value = item.Bi4;
                    hojaR.Cell("AB" + index).Value = item.Owner;
                    hojaR.Cell("AC" + index).Value = item.CodPermanencia;
                    hojaR.Cell("AD" + index).Value = item.LotId;
                    index++;
                }
            }

            //Cosecha
            var hoja2 = book.Worksheet("Cosecha");
            hoja2.Cell("B3").Value = filtro;
            hoja2.Cell("B4").Value = DateTime.Now.Date;
            hoja2.Cell("C3").Value = valor;
            index = 7;
            if (data.Cosecha != null)
            {
                foreach (var item in data.Cosecha)
                {
                    hoja2.Cell("A" + index).Value = item.Euid;
                    hoja2.Cell("B" + index).Value = item.FechaCosecha;
                    hoja2.Cell("C" + index).Value = item.Bin;
                    hoja2.Cell("D" + index).Value = item.order;
                    hoja2.Cell("E" + index).Value = item.breedersCode1;
                    hoja2.Cell("F" + index).Value = item.breedersCode2;
                    hoja2.Cell("G" + index).Value = item.breedersCode3;
                    hoja2.Cell("H" + index).Value = item.breedersCode4;
                    hoja2.Cell("I" + index).Value = item.crop;
                    hoja2.Cell("J" + index).Value = item.client;
                    hoja2.Cell("K" + index).Value = item.projecLead;
                    hoja2.Cell("L" + index).Value = item.location;
                    hoja2.Cell("M" + index).Value = item.opExpName;
                    hoja2.Cell("N" + index).Value = item.gmoEvent;
                    hoja2.Cell("O" + index).Value = item.sag;
                    index++;
                }
            }

            //Secado
            var hoja3 = book.Worksheet("Secado");
            hoja3.Cell("B3").Value = filtro;
            hoja3.Cell("B4").Value = DateTime.Now.Date;
            hoja3.Cell("C3").Value = valor;
            index = 7;
            if (data.Secado != null)
            {
                foreach (var item in data.Secado)
                {
                    hoja3.Cell("A" + index).Value = item.euid;
                    hoja3.Cell("B" + index).Value = item.fechaInicio;
                    hoja3.Cell("C" + index).Value = item.fechaTermino;
                    hoja3.Cell("D" + index).Value = item.cajaSecador;
                    hoja3.Cell("E" + index).Value = item.order;
                    hoja3.Cell("F" + index).Value = item.breedersCode1;
                    hoja3.Cell("G" + index).Value = item.breedersCode2;
                    hoja3.Cell("H" + index).Value = item.breedersCode3;
                    hoja3.Cell("I" + index).Value = item.breedersCode4;
                    hoja3.Cell("J" + index).Value = item.crop;
                    hoja3.Cell("K" + index).Value = item.client;
                    hoja3.Cell("L" + index).Value = item.projecLead;
                    hoja3.Cell("M" + index).Value = item.location;
                    hoja3.Cell("N" + index).Value = item.opExpName;
                    hoja3.Cell("O" + index).Value = item.gmoEvent;
                    hoja3.Cell("P" + index).Value = item.sag;
                    index++;
                }
            }

            //Desgrane
            var hoja4 = book.Worksheet("Desgrane");
            hoja4.Cell("B3").Value = filtro;
            hoja4.Cell("B4").Value = DateTime.Now.Date;
            hoja4.Cell("C3").Value = valor;
            index = 7;
            if (data.Desgrane != null)
            {
                foreach (var item in data.Desgrane)
                {
                    hoja4.Cell("A" + index).Value = item.euid;
                    hoja4.Cell("B" + index).Value = item.fecha;
                    hoja4.Cell("C" + index).Value = item.sheller;
                    hoja4.Cell("D" + index).Value = item.shelling;
                    hoja4.Cell("E" + index).Value = item.instructions;
                    hoja4.Cell("F" + index).Value = item.order;
                    hoja4.Cell("G" + index).Value = item.breedersCode1;
                    hoja4.Cell("H" + index).Value = item.breedersCode2;
                    hoja4.Cell("I" + index).Value = item.breedersCode3;
                    hoja4.Cell("J" + index).Value = item.breedersCode4;
                    hoja4.Cell("K" + index).Value = item.crop;
                    hoja4.Cell("L" + index).Value = item.client;
                    hoja4.Cell("M" + index).Value = item.projecLead;
                    hoja4.Cell("N" + index).Value = item.location;
                    hoja4.Cell("O" + index).Value = item.opExpName;
                    hoja4.Cell("P" + index).Value = item.gmoEvent;
                    hoja4.Cell("Q" + index).Value = item.sag;
                    index++;
                }
            }

            //Packing
            var hoja5 = book.Worksheet("Packing");
            hoja5.Cell("B3").Value = filtro;
            hoja5.Cell("B4").Value = DateTime.Now.Date;
            hoja5.Cell("C3").Value = valor;
            index = 7;
            if (data.Packing != null)
            {
                foreach (var item in data.Packing)
                {
                    hoja5.Cell("A" + index).Value = item.euid;
                    hoja5.Cell("B" + index).Value = item.indEuid;
                    hoja5.Cell("C" + index).Value = item.fechaPacking;
                    hoja5.Cell("D" + index).Value = item.totalWeight;
                    hoja5.Cell("E" + index).Value = item.totalKernels;
                    hoja5.Cell("F" + index).Value = item.totalEars;
                    hoja4.Cell("G" + index).Value = item.shelling;
                    hoja4.Cell("H" + index).Value = item.instructions;
                    hoja4.Cell("I" + index).Value = item.targears;
                    hoja4.Cell("J" + index).Value = item.targetKern;
                    hoja4.Cell("K" + index).Value = item.targetWg;
                    hoja5.Cell("L" + index).Value = item.order;
                    hoja5.Cell("M" + index).Value = item.breedersCode1;
                    hoja5.Cell("N" + index).Value = item.breedersCode2;
                    hoja5.Cell("O" + index).Value = item.breedersCode3;
                    hoja5.Cell("P" + index).Value = item.breedersCode4;
                    hoja5.Cell("Q" + index).Value = item.crop;
                    hoja5.Cell("R" + index).Value = item.client;
                    hoja5.Cell("S" + index).Value = item.projecLead;
                    hoja5.Cell("T" + index).Value = item.location;
                    hoja5.Cell("U" + index).Value = item.opExpName;
                    hoja5.Cell("V" + index).Value = item.gmoEvent;
                    hoja5.Cell("W" + index).Value = item.sag;
                    index++;
                }
            }

            //Llenado
            var hoja6 = book.Worksheet("Cajas");
            hoja6.Cell("B3").Value = filtro;
            hoja6.Cell("B4").Value = DateTime.Now.Date;
            hoja6.Cell("C3").Value = valor;
            index = 7;
            if (data.Caja != null)
            {
                foreach (var item in data.Shipping)
                {
                    hoja6.Cell("A" + index).Value = item.euid;
                    hoja6.Cell("B" + index).Value = item.indEuid;
                    hoja6.Cell("C" + index).Value = item.fechaPreparacion;
                    hoja6.Cell("D" + index).Value = item.cajaEnvio;
                    hoja6.Cell("E" + index).Value = item.order;
                    hoja6.Cell("F" + index).Value = item.breedersCode1;
                    hoja6.Cell("G" + index).Value = item.breedersCode2;
                    hoja6.Cell("H" + index).Value = item.breedersCode3;
                    hoja6.Cell("I" + index).Value = item.breedersCode4;
                    hoja6.Cell("J" + index).Value = item.crop;
                    hoja6.Cell("K" + index).Value = item.client;
                    hoja6.Cell("L" + index).Value = item.projecLead;
                    hoja6.Cell("M" + index).Value = item.location;
                    hoja6.Cell("N" + index).Value = item.opExpName;
                    hoja6.Cell("O" + index).Value = item.gmoEvent;
                    hoja6.Cell("P" + index).Value = item.sag;
                    index++;
                }
            }

            //Envio
            var hoja7 = book.Worksheet("Envío");
            hoja7.Cell("B3").Value = filtro;
            hoja7.Cell("B4").Value = DateTime.Now.Date;
            hoja7.Cell("C3").Value = valor;
            index = 7;
            if (data.Caja != null)
            {
                foreach (var item in data.Caja)
                {
                    hoja7.Cell("A" + index).Value = item.shipTo;
                    hoja7.Cell("B" + index).Value = item.cajaEnvio;
                    hoja7.Cell("C" + index).Value = item.creacion;
                    hoja7.Cell("D" + index).Value = item.envio;
                    hoja7.Cell("E" + index).Value = item.shipmentCode;
                    hoja7.Cell("F" + index).Value = item.pesoNeto;
                    hoja7.Cell("G" + index).Value = item.pesoBruto;
                    index++;
                }
            }

            return book;
        }
        public static XLWorkbook ExportaEficiencia(List<DetalleEficienciaDto> data, DateTime fechaInicio, DateTime fechaTermino, string opcion)
        {
            if (!Directory.Exists(@"C:\Templates"))
            {
                if (!File.Exists(@"C:\Templates\Eficiencia.xlsx"))
                {
                    return null;
                }
            }

            XLWorkbook book = new XLWorkbook(@"C:\Templates\Eficiencia.xlsx");
            var hoja = book.Worksheet("Eficiencia");
            int index = 7;

            hoja.Cell("B3").Value = fechaInicio.ToShortDateString();
            hoja.Cell("B4").Value = fechaTermino.ToShortDateString();
            hoja.Cell("E3").Value = opcion;
            hoja.SheetView.Freeze(6, 13);

            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value = (item.Fecha == DateTime.MinValue) ? "" : item.Fecha.ToShortDateString();
                hoja.Cell("B" + index).Value = item.Usuario;
                hoja.Cell("C" + index).Value = item.Euid;
                hoja.Cell("D" + index).Value = item.IndEuid;
                hoja.Cell("E" + index).Value = item.Crop;
                hoja.Cell("F" + index).Value = item.Client;
                hoja.Cell("G" + index).Value = item.ProjectLead;
                hoja.Cell("H" + index).Value = item.Location;
                hoja.Cell("I" + index).Value = item.ExpName;
                hoja.Cell("J" + index).Value = item.GmoEvent;
                hoja.Cell("K" + index).Value = item.Sag;
                hoja.Cell("L" + index).Value = item.Time;
                hoja.Cell("M" + index).Value = item.EuidHora;

                if (item.Usuario == "Sub Total" || item.Usuario == "Total")
                {
                    var range = hoja.Range("A" + index + ":M" + index);
                    range.Style.Fill.BackgroundColor = XLColor.Gray;
                    range.Style.Font.Bold = true;
                    hoja.Cell("C" + index).Value = item.Euid.Replace(".", "");
                    hoja.Cell("C" + index).Style.NumberFormat.Format = "#,##0";
                    hoja.Cell("D" + index).Value = item.IndEuid.Replace(".", "");
                    hoja.Cell("D" + index).Style.NumberFormat.Format = "#,##0";
                    index += 2;
                }
                else
                {
                    index++;
                }
            }

            return book;
        }
        public static XLWorkbook ExportaGuiaDespacho(List<DatosGuia> data,string nombreHoja, List<string[]> titles)
        {
            int index = 2;
            var wb = new XLWorkbook(); //create workbook
            var hoja = wb.Worksheets.Add(nombreHoja);

            hoja.Cell(1, 1).InsertData(titles);

            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value =item.FechaGuia;
                hoja.Cell("B" + index).Value = item.Origen;
                hoja.Cell("C" + index).Value = item.Destino;
                hoja.Cell("D" + index).Value = item.Location;
                hoja.Cell("E" + index).Value = item.Crop;
                hoja.Cell("F" + index).Value = item.Experimento;
                hoja.Cell("G" + index).Value = item.Evento;
                hoja.Cell("H" + index).Value = item.Gmo;
                hoja.Cell("I" + index).Value = item.Sag;
                hoja.Cell("J" + index).Value = item.Cc;
                hoja.Cell("K" + index).Value = item.CodInternacion;
                hoja.Cell("L" + index).Value = item.NumeroEuid;
                hoja.Cell("M" + index).Value = item.Kilos;
                hoja.Cell("N" + index).Value = item.Conductor;
                hoja.Cell("O" + index).Value = item.Rut;
                hoja.Cell("P" + index).Value = item.Patente;
                hoja.Cell("Q" + index).Value = item.FechaCreacion;
                hoja.Cell("R" + index).Value = item.UsuarioCreacion;
                index++;
            }

            return wb;
        }
        public static bool CreaTemplate(string nombre, List<string[]> titles)
        {
            bool result = false;
            var wb = new XLWorkbook(); //create workbook
            switch (nombre)
            {
                case "PackingList":
                    result=CreaPackingList(wb, titles, nombre);
                    break;
            }

            return result;
        }

        private static bool CreaPackingList(XLWorkbook wb, List<string[]> titles, string titulo)
        {
            try
            {
                var ws = wb.Worksheets.Add("Header Packing List"); //add worksheet to workbook
                //var range = ws.Range(;
                //range.Style.Fill.BackgroundColor = XLColor.Gray;
                //range.Style.Font.Bold = true;
                //hoja.Cell("C" + index).Value = item.Euid.Replace(".", "");
                //hoja.Cell("C" + index).Style.NumberFormat.Format = "#,##0";
                //hoja.Cell("D" + index).Value = item.IndEuid.Replace(".", "");
                //hoja.Cell("D" + index).Style.NumberFormat.Format = "#,##0";

                ws.Cell(5, 1).InsertData(titles);

                var ms = new MemoryStream();
                wb.SaveAs(@"C:\Templates\" + titulo + ".xlsx");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        #endregion

        public static ResultadoCarga SaveExcelData(List<InfoFieldBook> data)
        {
            int rowUpdated = 0;
            int rowInserted = 0;
            ResultadoCarga status = new ResultadoCarga();
            InfoFieldBook ultimoProcesado = new InfoFieldBook();

            try
            {
                foreach (var result in data)
                {
                    var row = InfoFieldBookBusiness.GetIndEuid(result.indEuid, result.euid);
                    if (row != null)
                    {
                        rowUpdated++;
                        row.fechaModificacion = DateTime.Now;
                    }
                    else
                    {
                        row = new InfoFieldBook();
                        rowInserted++;
                        row.fechaCarga = DateTime.Now;
                    }

                    row.breedersCode1 = result.breedersCode1;
                    row.breedersCode2 = result.breedersCode2;
                    row.breedersCode3 = result.breedersCode3;
                    row.breedersCode4 = result.breedersCode4;
                    row.cc = result.cc;
                    row.client = result.client;
                    row.codInternacion = result.codInternacion;
                    row.codReception = result.codReception;
                    row.country = result.country;
                    row.crop = result.crop;
                    row.ent = result.ent;
                    row.euid = result.euid;
                    row.gmoEvent = result.gmoEvent;
                    row.indEuid = result.indEuid;
                    row.instructions = result.instructions;
                    row.location = result.location;
                    row.obs = result.obs;
                    row.opExpName = result.opExpName;
                    row.order = result.order;
                    row.plt = result.plt;
                    row.projecLead = result.projecLead;
                    row.projectCode = result.projectCode;
                    row.rng = result.rng;
                    row.sag = result.sag;
                    row.shelling = result.shelling;
                    row.shipTo = result.shipTo;
                    row.targears = result.targears;
                    row.targetKern = result.targetKern;
                    row.targetWg = result.targetWg;
                    row.year = result.year;

                    ultimoProcesado = row;
                    var obj = InfoFieldBookBusiness.GrabaInformacion(row);

                }
            }
            catch (Exception ex)
            {
                status.Error = "Error: " + ex.Message;
            }

            status.TotalRows = data.Count();
            status.NumeroActualizados = rowUpdated;
            status.NumeroInsertados = rowInserted;
            status.UltimoProcesado = ultimoProcesado;

            return status;
        }

        #region -----Exporta Datos De Los Mantenedores-----
        public static XLWorkbook ExportaEntryList(List<EntryList> items)
        {
            int index = 2;
            XLWorkbook book = new XLWorkbook(@"C:\Templates\Entry_List.xlsx");
            var hoja = book.Worksheet("Entry-List");

            foreach (var item in items)
            {
                hoja.Cell("A" + index).Value = item.Euid;
                hoja.Cell("B" + index).Value = item.Year;
                hoja.Cell("C" + index).Value = item.Country;
                hoja.Cell("D" + index).Value = item.Location;
                hoja.Cell("E" + index).Value = item.Rng;
                hoja.Cell("F" + index).Value = item.Plt;
                hoja.Cell("G" + index).Value = item.Ent;
                hoja.Cell("H" + index).Value = item.ExpName;
                hoja.Cell("I" + index).Value = item.ProjectLead;
                hoja.Cell("J" + index).Value = item.Cc;
                hoja.Cell("K" + index).Value = item.Crop;
                hoja.Cell("L" + index).Value = item.Obs;
                hoja.Cell("M" + index).Value = item.ProjectCode;
                hoja.Cell("N" + index).Value = item.GmoEvent;
                hoja.Cell("O" + index).Value = item.Sag;
                hoja.Cell("P" + index).Value = item.CodInternacion;
                hoja.Cell("Q" + index).Value = item.CodReception;
                hoja.Cell("R" + index).Value = item.Client;
                hoja.Cell("S" + index).Value = item.EntName;
                hoja.Cell("T" + index).Value = item.EntRole;
                hoja.Cell("U" + index).Value = item.ResImportacion;
                hoja.Cell("V" + index).Value = item.GranosHilera;
                hoja.Cell("W" + index).Value = item.Bi1;
                hoja.Cell("X" + index).Value = item.Bi2;
                hoja.Cell("Y" + index).Value = item.Bi3;
                hoja.Cell("Z" + index).Value = item.Bi4;
                hoja.Cell("AA" + index).Value = item.Owner;
                hoja.Cell("AB" + index).Value = item.CodPermanencia;
                hoja.Cell("AC" + index).Value = item.LotId;

                index++;
            }

            return book;
        }

        public static XLWorkbook ExportaInfoFieldBook(List<InfoFieldBook> data, List<string> titulos)
        {
            int index = 1;
            var wb = new XLWorkbook(); //create workbook
            var hoja = wb.Worksheets.Add("InfoFieldBook"); //add worksheet to workbook

            var range = hoja.Range(1, 1, 1, titulos.Count);
            range.Style.Fill.BackgroundColor = XLColor.Silver;
            range.Style.Font.FontName = "Calibri";
            range.Style.Font.Bold = true;
            range.Style.Font.FontSize = 9;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            foreach (var item in titulos)
            {
                hoja.Cell(1, index).Value = item;
                index++;
            }

            range = hoja.Range(2, 1, data.Count + 1, titulos.Count);
            range.Style.Font.FontName = "Calibri";
            range.Style.Font.Bold = true;
            range.Style.Font.FontSize = 9;

            index = 2;
            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value = item.euid;
                hoja.Cell("B" + index).Value = item.indEuid;
                hoja.Cell("C" + index).Value = item.order;
                hoja.Cell("D" + index).Value = item.breedersCode1;
                hoja.Cell("E" + index).Value = item.breedersCode2;
                hoja.Cell("F" + index).Value = item.breedersCode3;
                hoja.Cell("G" + index).Value = item.breedersCode4;
                hoja.Cell("H" + index).Value = item.shelling;
                hoja.Cell("I" + index).Value = item.instructions;
                hoja.Cell("J" + index).Value = item.targears;
                hoja.Cell("K" + index).Value = item.targetKern;
                hoja.Cell("L" + index).Value = item.targetWg;
                hoja.Cell("M" + index).Value = item.shipTo;
                index++;
            }

            hoja.Columns().AdjustToContents();

            return wb;
        }

        #endregion

        #region -----Reporte Rows Tags-----
        public static XLWorkbook ExportaRowsTags(List<string> titulos,List<EntryList> data)
        {
            int index = 1;
            var wb = new XLWorkbook(); //create workbook
            var hoja=wb.Worksheets.Add("Rows Tags"); //add worksheet to workbook

            var range= hoja.Range(1, 1, 1, titulos.Count);
            range.Style.Fill.BackgroundColor = XLColor.Silver;
            range.Style.Font.FontName = "Calibri";
            range.Style.Font.Bold = true;
            range.Style.Font.FontSize = 9;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            //hoja.Cell("C" + index).Value = item.Euid.Replace(".", "");
            //hoja.Cell("C" + index).Style.NumberFormat.Format = "#,##0";
            //hoja.Cell("D" + index).Value = item.IndEuid.Replace(".", "");
            //hoja.Cell("D" + index).Style.NumberFormat.Format = "#,##0";

            foreach (var item in titulos)
            {
                hoja.Cell(1,index).Value = item;
                index++;
            }

            range = hoja.Range(2, 1, data.Count+1, titulos.Count);
            range.Style.Font.FontName = "Calibri";
            range.Style.Font.Bold = true;
            range.Style.Font.FontSize = 9;

            index = 2;
            foreach (var item in data)
            {
                hoja.Cell("A" + index).Value = item.Euid;
                hoja.Cell("B" + index).Value = item.Rng;
                hoja.Cell("C" + index).Value = item.Plt;
                hoja.Cell("D" + index).Value = item.Ent;
                hoja.Cell("E" + index).Value = item.EntName;
                hoja.Cell("F" + index).Value = item.Location;
                hoja.Cell("G" + index).Value = item.ExpName;
                index++;
            }

            hoja.Columns().AdjustToContents();

            return wb;
        }
        #endregion
    }
}
