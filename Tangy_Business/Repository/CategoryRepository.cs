using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<CategoryDTO> Create(CategoryDTO objDTO)
    {
        var category = _mapper.Map<CategoryDTO, Category>(objDTO);
        category.CreatedDate =DateTime.Now;

        var addedObj = await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();

        return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
    }

    public async Task<CategoryDTO> Update(CategoryDTO objDTO)
    {
        var objFromDb = await _db.Categories.FirstOrDefaultAsync(category => category.Id==objDTO.Id);
        if (objFromDb != null)
        {
            objFromDb.Name = objDTO.Name;
            _db.Categories.Update(objFromDb);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(objFromDb);
        }

        return objDTO;

    }

    public async Task<int> Delete(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(category => category.Id==id);
        if (obj != null)
        {
            _db.Categories.Remove(obj);
            return await _db.SaveChangesAsync();
        }

        return 0;

    }

    public async Task<CategoryDTO> Get(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(category => category.Id==id);
        
        return obj != null ? _mapper.Map<Category, CategoryDTO>(obj) : new CategoryDTO();
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
    }
}