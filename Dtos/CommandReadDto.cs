﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYTestingASPNETCore.Dtos
{
    public class CommandReadDto
    {
      
        public int Id { get; set; }
        public String HowTo { get; set; }
        public String Line { get; set; }
        public String Platform { get; set; }
    }
}
