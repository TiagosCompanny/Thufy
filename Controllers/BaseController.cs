using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thufy.Enums;

namespace Thufy.Controllers
{
    public class BaseController : Controller
    {
        public void Alert(string message, string title, NotificationType notificationType)
        {
            var alertMessage = "swal({" +
                               $"title: '{title}', " +
                               $"text: '{message}', " +
                               $"type: '{notificationType}', " +
                               "position: 'bottom-end', " +
                               "width: '30rem', " +
                               "timer: 15000, " +
                               "showConfirmButton: false, " +
                               "confirmButtonClass: 'rounded-0', " +
                               "customClass: 'rounded-0' " +
                               "})";

            TempData["Notification"] = alertMessage;
        }
        public void AlertToast(string title, NotificationType notificationType)
        {
            var alertMessage = "swal({" +
                               $"title: '{title}', " +
                               $"type: '{notificationType}', " +
                               "position: 'bottom-end', " +
                               "timer: 3000, " +
                               "toast: true, " +
                               "showConfirmButton: false, " +
                               "confirmButtonClass: 'rounded-0' " +
                               "})";

            TempData["Notification"] = alertMessage;
        }
    }
}