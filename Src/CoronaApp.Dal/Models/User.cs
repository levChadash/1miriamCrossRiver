﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MinLength(8)]

    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
}

