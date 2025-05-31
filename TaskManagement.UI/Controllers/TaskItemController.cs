using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using TaskManagement.Services.DTOs.TaskItem;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.UI.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _service;
        public TaskItemController(ITaskItemService service)
        {
            _service = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTaskItemDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddTaskItemAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _service.GetTaskItemAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,EditTaskItemDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateTaskitemAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
