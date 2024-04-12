using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using filtromvc.Controllers;
using filtromvc.Models;
using filtromvc.Data;


namespace filtromvc.Controllers {
    public class JobsController : Controller
    {
            public readonly BaseContext _context;
          
            public JobsController(BaseContext context)
        {
            _context = context;
           
        }  

          public async Task<IActionResult> Index(){
          var jobs = await _context.Jobs.ToListAsync();
          return View(jobs);
        }

        public async Task<IActionResult> Details(int? id){
            var jobs = await _context.Jobs.FindAsync(id);
            return View(jobs);
        }
      public IActionResult Create()
        {
            return View();
        }
    [HttpPost]
      public async Task<IActionResult> Create(Job job){
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
            
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
            
            
        }

         public async Task<IActionResult> Edit(int? id){
            return View(await _context.Jobs.FirstOrDefaultAsync(x =>x.Id == id));

        }
        [HttpPost]
        

        public async Task<IActionResult> Edit(Job job){
           
                _context.Jobs.Update(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
        }

         public async Task<IActionResult> Delete(int id, Job job)
        {
        
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

         public ActionResult Search(string searchTerm)
{
    var jobs = _context.Jobs.ToList(); // Obtener 

    if (!string.IsNullOrEmpty(searchTerm))
    {
        
        var searchTermLower = searchTerm.ToLower();
        jobs = jobs.Where(u => u.NameCompany.ToLower().Contains(searchTermLower)).ToList();
    }

    return PartialView("_JobList", jobs); // Devolver vista parcial con lista de sectores
}





       
    }
    }
