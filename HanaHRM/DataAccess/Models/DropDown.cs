﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HanaHRM.DataAccess.Models
{
    public class DropDown
    {

       public string text { set; get; }
       public  int value { set; get; }
    }
}
