using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaProje.Business.Interfaces;
using BaProje.WebApi.CustomFilters;
using BAProje.Entities.Concrete;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllSortedByNameAsync()));
            
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.FindByIdAsync(id)));
        }
        [Authorize]
        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id,CategoryUpdateDto categoryUpdateDto)
        {
            if (categoryUpdateDto.Id != id)
                return BadRequest("geçersiz id");
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(new Category { Id = id });
            return NoContent();
        }
        
        


    }
}