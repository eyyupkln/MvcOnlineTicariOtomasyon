using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class qrcodeController : Controller
    {
        // GET: qrcode
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeGenerator.QRCode carecode = qr.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap image = carecode.GetGraphic(10))
                {
                    image.Save(ms,ImageFormat.Png);
                    ViewBag .carecodeimage="data:image/png;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();

        }
    }
}