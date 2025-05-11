using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

public class CourseController: Controller{
    //Index metodunun olmaması demek mutlaka slash ilet path belirtmeniz lazım demektir

    public IActionResult Details(int? id){
        if(id == null){
            return Redirect("/course/list");
        }
        var course = Repository.GetById(id);

        return View(course);
    }

    public IActionResult List(){
        
        return View(Repository.Courses);
    }
}