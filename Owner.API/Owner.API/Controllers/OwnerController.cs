using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owner.API.Controllers
{

    [ApiController]
    [Route("Owners")]
    public class OwnerController : ControllerBase
    {

        private static List<OwnerModel> OwnerList = new List<OwnerModel>()
      {
          new OwnerModel{
              Id=2,
              Name = "Eda",
              Date=new DateTime(1998,04,22),
              Comment="ABC",
              OwnershipType="First",
          },

           new OwnerModel{
              Id=1,
              Name = "Seda",
              Date=new DateTime(1999,05,23),
              Comment="DEF",
              OwnershipType="Second",
          },

            new OwnerModel{
              Id=3,
              Name = "Sema",
              Date=new DateTime(1997,03,21),
              Comment="GJK",
              OwnershipType="Third",
          },



      };

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("all")]
        [HttpGet]

        public IActionResult  GetOwner()                                  //get all owners
        {
            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<OwnerModel>();
            return Ok( ownerList);
        }



        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Consumes("application/json")]                                 //only excepts application/json


        public IActionResult AddOwner(OwnerModel model)
        {
            var ownerList = new List<OwnerModel>();
            ownerList.Add(model);

            if (ownerList.Any(e => e.Comment.Contains("hack")))       //if comment includes "hack" return bad request
            return BadRequest();
            else       
            return Ok(ownerList);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {

            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<OwnerModel>();
            var ownerModel = ownerList.FirstOrDefault(x => x.Id == id);              //delete by id
            if (ownerModel == null)
            return NotFound("Try again");
            ownerList.Remove(ownerModel);
            return Ok(ownerList);
            


        }
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerModel))]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         [HttpPut]

         [Route("updated")]
        public IActionResult Update(int id , OwnerModel ownerModel)
        {
            if (id != ownerModel.Id)
            return NotFound(" Try again"); 

            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<OwnerModel>();
            var update = ownerList.FirstOrDefault(x => x.Id == id);
            update.Name = ownerModel.Name;
            update.Date = ownerModel.Date;
            update.Comment = ownerModel.Comment;
            update.OwnershipType = ownerModel.OwnershipType;

            return Ok(update);


        }

    }
}
