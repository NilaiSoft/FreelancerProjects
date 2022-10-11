using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FreelancerProjects.Models;
using FreelancerProjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FreelancerProjects.Web.Customer.BaseController
{
    [Area("customer")]
    [Authorize]
    public class CustomerBaseController<TEntity, TVModel> : Controller,
        ICustomerBaseController<TEntity, TVModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity, TVModel> _repository;
        private readonly IMapper _mapper;

        public CustomerBaseController(IRepository<TEntity, TVModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IActionResult> Index()
        {
            var entity = await _repository.GetsAsync();
            return View(_mapper.Map<IList<TVModel>>(entity));
        }

        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TVModel entity)
        {
            var result = await _repository.AddAndSaveChangesAsync(_mapper.Map<TEntity>(entity));
            return RedirectToAction("Index");
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var model = await _repository.GetAsync(x => x.Id == id);
            return View(_mapper.Map<TVModel>(model));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TVModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);
            var result = await _repository.EditAsync(model);
            return RedirectToAction("Index");
        }

        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(x => x.Id == id);
            return RedirectToAction("Index");
        }

        public virtual async Task<IActionResult> Details(int id)
        {
            var model = await _repository.GetAsync(x => x.Id == id);
            return View(_mapper.Map<TVModel>(model));
        }
    }
}
