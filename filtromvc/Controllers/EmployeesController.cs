using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using filtromvc.Controllers;
using filtromvc.Models;
using filtromvc.Data;


namespace filtromvc.Controllers {
    public class EmployeesController : Controller
    {
            public readonly BaseContext _context;
          
            public EmployeesController(BaseContext context)
        {
            _context = context;
           
        }  

          public async Task<IActionResult> Index(){
          var employees = await _context.Employees.ToListAsync();
          return View(employees);
        }

        public async Task<IActionResult> Details(int? id){
            var employees = await _context.Employees.FindAsync(id);
            return View(employees);
        }
      public IActionResult Create()
        {
            return View();
        }
    [HttpPost]
      public async Task<IActionResult> Create(Employee employee){
            /* if(ModelState.IsValid){ 
                string nombreArchivo = archivo.FileName;
                string path = "";

                 switch(ubicacion){

                case 0:
                    path = await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Uploads);
                break;
                case 1:
                    path = await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Images);
                break;
                case 2:
                    path = await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Documents);
                break;
                case 3:
                    path = await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Temp);
                break;
               

            }
                if(archivo!= null){
                   
                    job.LogoCompany = nombreArchivo;
                } */
            
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
            
            
        }

         public async Task<IActionResult> Edit(int? id){
            return View(await _context.Employees.FirstOrDefaultAsync(x =>x.Id == id));

        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(Employee employee){
           
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(employee);
        }

         public async Task<IActionResult> Delete(int id, Employee employee)
        {
        
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

         public ActionResult Search(string searchTerm)
{
    var employees = _context.Employees.ToList(); // Obtener 

    if (!string.IsNullOrEmpty(searchTerm))
    {
        
        var searchTermLower = searchTerm.ToLower();
        employees = employees.Where(u => u.Names.ToLower().Contains(searchTermLower)).ToList();
    }

    return PartialView("_JobList", employees); // Devolver vista parcial con lista de sectores
}



       
    }
    }
