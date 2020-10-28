using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using POC.BLL.DTO;
using POC.BLL.Interfaces;
using POC.BLL.Mapper;
using POC.DAL.Entities;
using POC.DAL.Interfaces;

namespace POC.BLL.Services
{
  public class CanvasService : ICanvasService
  {
    private readonly IUnitOfWork _unitOfWork;

    public CanvasService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task CreateCanvasAsync(CanvasDTO canvasDTO)
    {
      var canvas = ObjMapper.Map<CanvasDTO, Canvas>(canvasDTO);
      _unitOfWork.Canvas.Create(canvas);
      await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCanvasByIdAsync(string Id)
    {
      var canvas = await _unitOfWork.Canvas.FindByIdAsync(Id);
      _unitOfWork.Canvas.Delete(canvas);
      await _unitOfWork.SaveAsync();
    }

    public IQueryable<CanvasDTO> GetCanvas()
    {
      var result = _unitOfWork.Canvas.FindAll().ProjectTo<CanvasDTO>(ObjMapper.configuration);
      return result;
    }
  }
}