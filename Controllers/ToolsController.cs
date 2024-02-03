using Ghostscript.NET.Processor;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Thufy.Enums;
using Thufy.Models;
using WebGrease.Activities;


namespace Thufy.Controllers
{
    public class ToolsController : BaseController
    {
        public ActionResult Index()
        {
            Alert("teste", "t", NotificationType.success);
            return View();
        }

        [Route("IndexPdfTools")]
        public ActionResult IndexPdfTools()
        {
            return View("~/Views/PdfTools/IndexPdfTools.cshtml");
        }

        [HttpGet]
        [Route("tools/Comprimir")]
        public ActionResult Comprimir()
        {
            return View("~/Views/PdfTools/Tools/Comprimir.cshtml");
        }

        [HttpPost]
        [Route("tools/Comprimir")]
        public ActionResult Comprimir(ComprimirModel model)
        {
            string typeCompression;


            switch (model.CompressionType)
            {
                case 1: typeCompression = "printer"; break;
                case 2: typeCompression = "ebook"; break;
                case 3: typeCompression = "screen"; break;
                default:  typeCompression = "ebook"; break;

            }

            try
            {
                string Arquivo = "";
                if (model.InputFile.ContentLength > 0)
                {
                    Arquivo = Path.GetFileName(model.InputFile.FileName);
                    var caminhoEntrada = Path.Combine(Server.MapPath("~/Files"), Arquivo);
                    string arquivoSalvo = caminhoEntrada;
                    model.InputFile.SaveAs(arquivoSalvo);

                    string arquivoComprimido = "Comprimido_" + Arquivo;
                    var caminhoSaida = Path.Combine(Server.MapPath("~/Files"), arquivoComprimido);


                    using (var processor = new GhostscriptProcessor())
                    {
                        var ghostscriptArgs = new List<string>();

                        ghostscriptArgs.Add("-q");
                        ghostscriptArgs.Add("-dNOPAUSE");
                        ghostscriptArgs.Add("-dBATCH");
                        ghostscriptArgs.Add("-dSAFER");
                        ghostscriptArgs.Add("-sDEVICE=pdfwrite");
                        ghostscriptArgs.Add($"-sOutputFile={caminhoSaida}");
                        ghostscriptArgs.Add("-dCompatibilityLevel=1.4"); // Pode ajustar conforme necessário
                        ghostscriptArgs.Add($"-dPDFSETTINGS=/{typeCompression}"); // Pode ajustar conforme necessário
                        ghostscriptArgs.Add(caminhoEntrada);

                        processor.StartProcessing(ghostscriptArgs.ToArray(), null);

                    }

                    byte[] fileBytes = System.IO.File.ReadAllBytes(caminhoSaida);                 
                    System.IO.File.Delete(caminhoEntrada);
                    System.IO.File.Delete(caminhoSaida);

                    AlertToast("Arquivo Comprimido com Sucesso!", NotificationType.success);


                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, Arquivo + "_Comprimido.pdf");

                }

            }
            catch (Exception)
            {
                AlertToast("Algo deu errado!", NotificationType.error);
                return View();
            }

            return View();
        }

    }
}