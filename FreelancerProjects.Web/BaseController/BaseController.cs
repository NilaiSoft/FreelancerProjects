using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FreelancerProjects.Models;
using FreelancerProjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerProjects.Web.BaseController
{
    [Area("store")]
    public class BaseController<TEntity, TVModel> : Controller,
        IBaseController<TEntity, TVModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity, TVModel> _repository;
        private readonly IMapper _mapper;

        public BaseController(IRepository<TEntity, TVModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IActionResult> Index()
        {
            var entity = await _repository.GetsAsync();
            var model = _mapper.Map<IList<TVModel>>(entity);
            return View(model);
        }

        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TVModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);

            var result = await _repository.AddAndSaveChangesAsync(model);
            return RedirectToAction("Index");
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var model = await _repository.GetAsync(x => x.Id == id);
            var model2 = _mapper.Map<TVModel>(model);
            return View(model2);
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
            return View(model);
        }
    }
}
