<<<<<<< Updated upstream
﻿using BLL_1.DTO;
using System;
using System.Collections.Generic;
=======
﻿using BLL.DTO;
>>>>>>> Stashed changes
using System.Data.Entity;

namespace TSP.API
{
    public class OfficeContext : DbContext
    {
        public DbSet<EmployeeDTO> Employess { get; set; }
    }
}
