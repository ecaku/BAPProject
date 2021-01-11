using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CategoryAddDto:IDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
