﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Enabled { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
