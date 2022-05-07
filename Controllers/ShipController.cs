using Microsoft.AspNetCore.Mvc;
using Port.Domain.Data;
using Port.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Port.Domain.Provider;
using System;
using Port.Domain.ErrorHandling;

namespace Port.Controller
{
    [ApiController]
    [Route("Ship")]
    public class ShipController : ControllerBase
    {
        private readonly IShipDataProvider _shipDataProvider;
        public ShipController(IShipDataProvider shipDataProvider)
        {
            _shipDataProvider = shipDataProvider;
        }

        [HttpGet]
        [Route("GetAllShips")]
        public async Task<ActionResult<List<Ship>>> GetAllShips([FromServices] ShipDataContext context)
        {
            try
            {
                var ships = await _shipDataProvider.GetAllShipsAsync();
                if(ships.Count>0)
                return ships;
                else
                return Problem(statusCode:404,detail: "No record found",title:ApiErrorCodes.API_RESOURCE_NOT_FOUND_ERROR,type:"internal");
     
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        [Route("AddShip")]
        public async Task<ActionResult<Ship>> Post([FromBody] Ship model)
        {
            try
            {
                if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
                bool isCodeValid = await _shipDataProvider.ValidateCode(model);
                if(!isCodeValid)
                {
                     return Problem(statusCode:412,detail: "Code can not be duplicate",title:ApiErrorCodes.API_RESOURCE_DUPLICATION_ERROR,type:"internal");
                }

                await _shipDataProvider.AddShipAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetShip/{Id}")]
         public async Task<ActionResult<Ship>> GetShip(int id)
        {
            try
            {
                Ship ship = await _shipDataProvider.GetShipAsync(id);
                if(ship!=null)
                return ship;
                else
                return Problem(statusCode:404,detail: "Record doesnt exist for give Id",title:ApiErrorCodes.API_RESOURCE_NOT_FOUND_ERROR,type:"internal");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateShip")]
        public async Task<ActionResult<Ship>> UpdateShip([FromBody] Ship model)
        {
            try
            {
                Ship ship = await _shipDataProvider.UpdateShipAsync(model);
                if(ship!=null)
                return ship;
                else
                return Problem(statusCode:404,detail: "Record doesnt exist for give Id",title:ApiErrorCodes.API_RESOURCE_NOT_FOUND_ERROR,type:"internal");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteShip/{Id}")]
        public async Task<ActionResult<bool>> DeleteShip(int id)
        {
            try
            {
              bool result= await _shipDataProvider.DeleteShipAsync(id);
              if(result==true)
              return result;
              else 
              return Problem(statusCode:404,detail: "Record doesnt exist for give Id",title:ApiErrorCodes.API_RESOURCE_NOT_FOUND_ERROR,type:"internal");
              //return BadRequest(new ApiBadRequestException(ApiErrorCodes.API_RESOURCE_NOT_FOUND_ERROR,"Record doesnt exist for give Id"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

   
}