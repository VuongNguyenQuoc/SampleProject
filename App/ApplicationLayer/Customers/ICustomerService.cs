﻿using App.ApplicationLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Customers
{
    public interface ICustomerService
    {       
        CustomerDto Add(CustomerDto customerDto);      
    }
}
