﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public class Response
    {
        public string _result { get; set; }
        public List<Rule> _summary { get; set; }
    }
}