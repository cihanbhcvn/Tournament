using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ILotService
    {
        IDataResult<Lot> DrawLottery(DrawLotteryDto drawLotteryDto);
    }
}
