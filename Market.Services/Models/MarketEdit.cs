using MediatR;
using ResponceModel;

namespace Market.Services.Models;

public class MarketEdit : IRequest<ResponseData<Market>>
{

}

public class MarketEditM : MarketEdit
{
    public Guid Id { get; set; }
}