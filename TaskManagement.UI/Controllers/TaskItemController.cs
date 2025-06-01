using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using TaskManagement.Services.DTOs.TaskItem;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.UI.Controllers
{
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
            var result = await _service.GetAllTaskItemAsync();
            var model = new TaskFilterDTO
            {
                Tasks = result
            };
            return View(model);
        }

        [HttpPost]
        public  IActionResult Index(TaskFilterDTO filter)
        {
            var model = _service.GetAllAsQueryable(filter);
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
            catch (Exception)
            {

                return RedirectToAction("Create", dto);
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
            catch (Exception)
            {

                return View(dto);
            }
        }
        #endregion

        #region Completed Toggle
        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var task = await _service.GetTaskItemAsync(id);
            if (task == null) return NotFound();

            await _service.ToggleIsCompletedAsync(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
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
