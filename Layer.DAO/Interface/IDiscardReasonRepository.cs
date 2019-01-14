﻿using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    public interface IDiscardReasonRepository: IGenericRepository<DiscardReason>
    {
        List<DiscardReason> GetAllData();
        
    }
}
