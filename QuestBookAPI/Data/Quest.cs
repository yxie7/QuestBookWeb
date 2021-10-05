﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? EstimatedCompletionTime { get; set; }
        public bool? Completed { get; set; }
    }
}
