﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerWebApp.Models
{
    public class Planner
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Progress { get; set; }

        public Planner()
        {
                
        }
    }
}
