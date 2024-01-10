using AzureSQLWebAPIMicroservice.Data;
using AzureSQLWebAPIMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureSQLWebAPIMicroservice.Services
{
    public class ExampleModelService
    {
        private readonly ExampleDbContext _context;

        public ExampleModelService(ExampleDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task<ExampleModel> AddExampleModel(ExampleModel model)
        {
            _context.ExampleModels.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        // Read all
        public async Task<List<ExampleModel>> GetAllExampleModels()
        {
            return await _context.ExampleModels.ToListAsync();
        }

        // Read by ID
        public async Task<ExampleModel> GetExampleModelById(int id)
        {
            return await _context.ExampleModels.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Update
        public async Task<ExampleModel> UpdateExampleModel(int id, ExampleModel model)
        {
            var existingModel = await _context.ExampleModels.FirstOrDefaultAsync(e => e.Id == id);
            if (existingModel == null)
            {
                return null;
            }

            existingModel.Name = model.Name;
            // Update other properties as necessary

            _context.Entry(existingModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingModel;
        }

        // Delete
        public async Task<bool> DeleteExampleModel(int id)
        {
            var model = await _context.ExampleModels.FindAsync(id);
            if (model == null)
            {
                return false;
            }

            _context.ExampleModels.Remove(model);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}