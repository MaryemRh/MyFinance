﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data;
using Data.Infrastructure;
using Data.Repositories;

namespace Service
{
    public class ServiceCategory : EntityService<Category>
    {
        public ServiceCategory(): base()
        {

        }
      
    }
}
