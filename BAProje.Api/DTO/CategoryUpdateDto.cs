using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
