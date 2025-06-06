﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using TaskManagement.Services.DTOs.TaskItem;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.UI.Controllers
{
    [Authorize]
    public class TaskItemController : Controller
    {
        #region Config
        private readonly ITaskItemService _service;
        public TaskItemController(ITaskItemService service)
        {
            _service = service;
        }
        #endregion

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var filter = new TaskFilterDTO();
            var model = await _service.GetAllAsQueryable(filter);
 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TaskFilterDTO filter)
        {
            var model = await _service.GetAllAsQueryable(filter);
            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItemDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = await _service.AddTaskItemAsync(dto);
                    if (isAdded)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var task = await _service.GetTaskItemAsync(id);
            if (task == null) return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskItemDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = await _service.UpdateTaskitemAsync(dto);
                    if(isUpdated) return RedirectToAction("Index");
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
        }
        #endregion

        #region Completed Toggle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var task = await _service.GetTaskItemAsync(id);
            if (task == null) return NotFound();

            await _service.ToggleIsCompletedAsync(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.GetTaskItemAsync(id);
            if (task == null) return NotFound();

            await _service.DeleteTaskItemAsync(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
