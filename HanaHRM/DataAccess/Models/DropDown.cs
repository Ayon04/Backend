using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HanaHRM.DataAccess.Models
{
    public class DropDown
    {

        string text { set; get; }
        string value { set; get; }
    }
}
