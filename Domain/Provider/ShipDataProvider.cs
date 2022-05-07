using Port.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Port.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Port.Domain.Provider
{
    public class ShipDataProvider : IShipDataProvider
    {
        private readonly ShipDataContext _context;
        public ShipDataProvider(ShipDataContext context)
        {
            _context = context;
        }

        public async Task<List<Ship>> GetAllShipsAsync()
        {
            if (_context != null)
            {
                var ships = await _context.Ships.ToListAsync();
                return ships;
            }
            return null;
        }

        public async Task<Ship> AddShipAsync(Ship entity)
        {
            if ((_context != null) && (entity != null))
            {

                entity.Code = entity.Code.ToUpper();
                entity.CreatedDate = DateTime.UtcNow;
                // entity.Code = _numbergenerator.Random();
                _context.Ships.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
        public async Task<bool> ValidateCode(Ship entity)
        {
            var ship = await _context.Ships.ToListAsync();
            foreach (Ship value in ship)
            {
                if (value.Code == entity.Code.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<bool> DeleteShipAsync(int shipId)
        {
            if (_context != null)
            {
                Ship shipObj = _context.Ships.Where(ship => ship.Id == shipId).SingleOrDefault();
                if (shipObj != null)
                {
                    _context.Ships.Remove(shipObj);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<Ship> GetShipAsync(int shipId)
        {
            if (_context != null)
            {
                Ship ship = await _context.Ships.Where(temp => temp.Id == shipId).SingleOrDefaultAsync();
                return ship;
            }
            return null;
        }

        public async Task<Ship> UpdateShipAsync(Ship entity)
        {
            Ship existingShip = await _context.Ships.Where(temp => temp.Id == entity.Id).SingleAsync();
            if ((existingShip != null) && (_context != null))
            {
                entity.Id = existingShip.Id;
                entity.Code = entity.Code.ToUpper();
                entity.UpdatedDate = DateTime.UtcNow;
                _context.Entry(existingShip).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}