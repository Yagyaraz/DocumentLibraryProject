using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Interface
{
    public interface IDashboardCount
    {
        DashboardCountModel SendData();
    }
}